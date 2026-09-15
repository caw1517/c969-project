# Appointment CRUD implementation spec

For [Build appointment CRUD (A3, A3b)](https://github.com/caw1517/c969-project/issues/11).
Form decisions confirmed with the human on 2026-09-14. The human implements the C#;
this ticket stays open until the implementation is verified together.

## Agreed scope

- Required: a selected Customer, trimmed nonempty Type, Start, and End.
- Optional: Title, Description, Location, Contact, and Url. Trim text; store blank
  values as empty strings, never NULL. Limit Title and Url to 255 characters.
  No URL-format rule is required.
- Type is free text. Customer picker lists all customers, including inactive ones,
  binds by CustomerId, and starts without a selection on Add.
- New appointments belong to Session.CurrentUserId. Editing preserves UserId;
  there is no User picker. Audit names use Session.CurrentUserName.
- Follow the existing CustomerForm modal Add/Edit, Save/Cancel pattern. Include
  controls for the optional fields, with no additional required-field rules.
- Use two complete local date/time inputs and a TimeZoneInfo.Local.DisplayName
  label. Use minute precision consistently, including zeroing hidden seconds on
  values submitted from these controls.
- Calendar, reports, and the login alert remain separate tickets.

## Model and method contracts

Use the existing C969_Project.Database namespace and static DatabaseManager
methods. These are signatures and field contracts, not implementation code.

| Type | Properties |
| --- | --- |
| Appointment : AuditableModel | int AppointmentId, CustomerId, UserId; string Title, Description, Location, Contact, Type, Url; DateTime Start, End |
| AppointmentDisplay : Appointment | string CustomerName, UserName |
| AppointmentConflict | int AppointmentId; string Title; DateTime Start, End |

All Start and End values in these models are UTC. The display model's name means
it includes joined names; it does **not** mean its timestamps become local.

| Signature | Contract |
| --- | --- |
| List<AppointmentDisplay> GetAppointments() | Read all appointments, join customer and user names, order by start then appointmentId. Return UTC timestamps with Kind.Utc. |
| AppointmentConflict? FindConflict(DateTime startUtc, DateTime endUtc, int? excludeAppointmentId) | Query all appointments; return one conflict or null. Add excludes nothing; Edit excludes its own ID. |
| void AddAppointment(Appointment appointment) | Insert a validated appointment, using the current session for ownership and audit names. |
| void EditAppointment(Appointment appointment) | Update editable fields by AppointmentId; leave UserId and creation audit fields unchanged. |
| void DeleteAppointment(int appointmentId) | Delete only the selected appointment. |
| AppointmentForm() | Add mode. |
| AppointmentForm(AppointmentDisplay appointment) | Edit mode; retain the original appointment ID and owner. |
| static DateTime TimeHelper.ToUtc(DateTime local) | Convert the machine-local form value to UTC using TimeZoneInfo. |
| static DateTime TimeHelper.ToLocal(DateTime utc) | Convert UTC to machine-local for controls and messages. |
| static DateTime TimeHelper.ToEastern(DateTime utc) | Convert UTC to Eastern solely for validation. |

Cache the Windows Eastern Standard Time zone, which includes daylight saving.
Normalize database start/end values with DateTime.SpecifyKind(value, Utc); assigning
a Kind is not a clock conversion. Convert local input once before validation, and
write exactly the UTC values validated. Convert to local only when filling editor
controls, formatting grid cells, or rendering messages. Keep the bound collection
UTC so later reports/calendar can reuse it.

## Save and validation behavior

Trim and check required fields first. Convert the form values to UTC, reporting
an invalid local clock value as a validation error. Then apply these time rules
in order, stopping at the first failure:

1. End must be strictly after Start.
2. Both Eastern endpoints must be Monday through Friday.
3. Both Eastern endpoints must have the **same date**, with Start at or after
   09:00 and End at or before 17:00. With positive duration, these bounds place
   both endpoints inside the business window.
4. Query for global overlap at save time, using the same open connection as the
   write. A conflict exists when newStart < existingEnd and newEnd > existingStart.
   The SQL exclusion is `(@excludeId IS NULL OR appointmentId <> @excludeId)`;
   bind a missing exclusion as DBNull.Value. Use LIMIT 1.

Back-to-back appointments are legal. An Edit must not conflict with itself.
Name a conflict using its title, falling back to "Appointment {id}" when blank,
and show its Start/End in local time. Business-hours errors explicitly say
"Eastern Time". These checks prevent conflicts visible to the query; they do not
promise concurrency protection against simultaneous writes by other systems.

**Correction to the earlier overlap decision:** time-of-day comparisons alone
do not prevent multi-day appointments. Monday 10:00 to Tuesday 11:00 would pass
them. The explicit same-Eastern-date check above is required by the business window.

## Database writes and failures

- Use typed parameters and the existing open-connection guard. Do not change the schema.
- INSERT supplies customerId, userId, all six text columns, start, end,
  createDate, createdBy, and lastUpdateBy. Let the DB generate appointmentId.
- createDate is DateTime.UtcNow. Never use NOW() for a UTC timestamp.
- UPDATE changes customerId, the six text columns, start, end, and lastUpdateBy.
  Preserve userId, createDate, and createdBy. Never write lastUpdate.
- Do not assume a raw auto-maintained TIMESTAMP read is UTC without accounting
  for the MySQL session zone. This feature need not select/display lastUpdate.
- Keep Add, Edit, and Delete in separate operation-specific try/catch paths,
  each with an understandable error message (A3b). The relevant Save path also
  catches failure of the overlap query; a failed check must never proceed to write.
- Retain inputs and keep the dialog open after a failure. Return DialogResult.OK
  only after a successful write; Cancel writes nothing.
- UPDATE/DELETE must identify the selected row by ID; do not report a missing row
  as success. An unchanged edit can legitimately have zero changed rows depending
  on connector settings, so distinguish that case from a missing row.
- Confirm Delete with Yes/No, default No. No selection means no operation.

## Appointments tab

Use an explicit, read-only full-row selection grid with Customer, User, Type,
Title, Start, and End columns. Hide IDs/internal fields, clear selection after
binding, and label the local time zone. Add opens a blank modal; Edit opens the
selected row. Refresh after successful Add/Edit/Delete. Catch loading failures.
If the write succeeds but refresh fails, say the appointment was saved/deleted
and the list could not refresh; do not invite a duplicate Save.

## Implementation order

1. Models and TimeHelper contracts.
2. GetAppointments and grid loading with local formatting.
3. AppointmentForm and field/time validation.
4. FindConflict, Add, and Edit with separate exception handling.
5. Delete confirmation, error handling, and refresh.
6. Build and perform the checks below together.

## Acceptance checks

Record results only after running them; none are claimed complete by this spec.

- Add with customer/type/times only. Confirm the specific customer link, current
  UserId, type, and empty optional text in the DB; confirm the local grid display.
- Reject missing customer, empty or whitespace-only type, and End <= Start.
- Edit customer/type/times, confirm persistence, and confirm the original owner
  and creation audit fields remain unchanged. Title-only and unchanged saves
  must not conflict with themselves.
- In Eastern time, allow a weekday 09:00 start and 17:00 end; reject weekends,
  08:59 starts, 17:01 ends, and Monday 10:00 to Tuesday 11:00.
- Reject overlap with a different customer/user, including containment; allow
  one appointment to start exactly when another ends.
- Cancel Add/Edit and decline Delete without modifying data. Confirm Delete
  removes only the selected appointment and refreshes the grid.
- Exercise each Add/Edit/Delete failure path separately with a controlled DB
  failure. Verify a failed overlap lookup prevents Save and inputs remain intact.
- Compare entered local Start/End with the stored UTC values and their displayed
  round trip. For DST, use Friday **2026-10-30** and Monday **2026-11-02**, both
  at a legal Eastern time, and verify the expected offset for each date using
  TimeZoneInfo. The earlier November 1/8 examples are Sundays and cannot be
  valid business-hours appointments. A zone without DST will not itself shift.
- Build successfully. After runtime verification, update the relevant A3/A3a/A3b
  and A5 evidence in docs/Rubric.md, post the ticket resolution, and update the
  map's decision index. Keep the ticket open until that verification is complete.
