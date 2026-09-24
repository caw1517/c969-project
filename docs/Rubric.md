---
type: note
date: 2026-07-15
status: active
project: C969
area: school
tags: [c969, rubric]
---

# C969 Rubric Checklist

Source: `WGU Performance Assessment.html` in this folder — **BOP4 Task 1: C# Application Development**.
Section letters below match the rubric aspects exactly (A1a, A2b, …) so you can talk to an
evaluator in their own terms.

**How to use:** check the box when it's done *and verified in the running app*, not when the
code is written. Fill **Evidence** with the class/method that satisfies it — that's what you
need if it comes back for revision. Tag `#blocker` on anything stuck and it surfaces on [[_C969-Hub]].

> [!note] Review status — 2026-09-02
> `[x]` marks an item supported by the evidence available in this review. Runtime-dependent
> items remain unchecked unless they were actually exercised in the running app. The project
> rebuild succeeds, but it reports three compiler warnings and no automated test project exists.

> [!warning] Hard constraints from the task
> - **No frameworks or external libraries except the .NET Framework.**
> - The database has no data — you must populate it.
> - Username and password to log in must both be the word **`test`**.
> - The MySQL database structure **cannot be modified** — it's shared with other systems.
> - Offices: Phoenix AZ, New York NY, London England. That's your time zone / language spread.

---

## A1 — Login Form

- [x] **A1a** — Log-in form accurately determines a user's location *(verified in login-form smoke test)*
- [x] **A1b** — Form translates log-in *and error control* messages into English and one additional language *(verified: English/German login, error, and time-zone labels)*
- [x] **A1c** — Consistently and accurately verifies the correct username and password *(verified: valid, invalid, and inactive-user cases)*

**Evidence:** `LoginForm` uses `TimeZoneInfo.Local.DisplayName` for the location label, and the
running test displayed the expected Pacific time-zone value. `LoginStrings` contains
English/German resources, and the completed tests verified the localized login/error controls and
time-zone label. `DatabaseManager.AuthenticateUser` uses parameterized checks; the completed tests
verified the valid `test`/`test` case plus invalid and inactive-user rejection. The committed
`sql/seed.sql` still does not recreate the complete required user state on an empty database.

## A2 — Customer Records

- [x] **A2** — Add, update, and delete customer records in the database, functioning properly
- [x] **A2a** — Validation, all three required:
    - [x] Record includes name, address, and phone number fields
    - [x] Fields are trimmed and non-empty
    - [x] Phone number field allows only digits and dashes
- [x] **A2b** — Exception handling working for all three operations:
    - [x] add
    - [x] update
    - [x] delete database

**Evidence (2026-09-20):** `CustomerForm.TrimInput` and `ValidateCustomerInput` normalize text,
require name/primary address/phone/postal code and country/city selections, enforce schema lengths,
and restrict phone values to ASCII digits and dashes. Invalid input returns before persistence.
Country and city selectors use stable IDs, with city choices filtered by country.
`DatabaseManager.AddCustomer` inserts a fresh address and its customer in one parameterized
transaction. `EditCustomer` updates the existing customer/address pair in a transaction while
preserving creation audit fields. Both use the current session for audit names; inserts use UTC
creation time, and neither operation writes the database-maintained `lastUpdate`.
`CustomerForm.saveEditCustomerButton_Click` has separate Add/Edit exception paths and returns OK
after successful persistence. `MainForm` refreshes the customer grid after successful operations.
`MainForm.deleteCustomerButton_Click` requires selection and confirmation, calls transactional
`DatabaseManager.DeleteCustomer`, and handles foreign-key error 1451 with instructions to delete
the customer's appointments first. Successful deletion removes the customer then its address;
appointments and shared city/country records are preserved. Other failures have Delete-specific
messaging, and Edit/Delete refresh failures are distinguished from write failures.

Customer work is tracked in closed issues [#7](https://github.com/caw1517/c969-project/issues/7),
[#27](https://github.com/caw1517/c969-project/issues/27),
[#28](https://github.com/caw1517/c969-project/issues/28), and
[#29](https://github.com/caw1517/c969-project/issues/29). On 2026-09-20, the user explicitly confirmed
that all Customer Add/Edit/Delete, validation, and controlled failure/rollback checks passed.
This confirmation resolves the older issue notes that left runtime verification pending.
Runtime verification is user-reported, not independently executed by the reviewing agent.

## A3 — Appointments

- [x] **A3** — Add, update, delete appointments; capture appointment type; link to a specific customer record
- [x] **A3a** — Validation, both required:
    - [x] Appointments only during business hours 9:00 a.m.–5:00 p.m., Mon–Fri, **eastern standard time**
    - [x] Overlapping appointments prevented
- [x] **A3b** — Exception handling working for all three operations:
    - [x] add
    - [x] update
    - [x] delete database

**Evidence (2026-09-20):** Add (#32) and Edit (#33) are implemented in `AppointmentForm`,
`DatabaseManager`, and `MainForm`. Both capture Type and Customer, validate local inputs against
the same Eastern business date and 09:00–17:00 weekday window, and check global overlap.
Edit excludes its own ID, preserves ownership and creation audit fields, and checks row existence
inside a transaction so unchanged saves succeed while missing rows fail. Separate Add/Edit
exception paths include overlap lookup failures; Cancel writes nothing. The six explicit grid
columns display local times, and refresh failures are distinguished from successful saves.
Add runtime evidence is recorded in #32; the user reported all Edit tests complete on 2026-09-20.
Runtime verification was user-reported, not independently executed by the reviewing agents.
Delete (#34) is implemented in `DatabaseManager.DeleteAppointment` and
`MainForm.deleteAppointmentButton_Click`, with one Designer event subscription. It requires
selection and Yes/No confirmation (default No), deletes by a typed appointment ID parameter,
reports missing rows, and separates Delete failures from successful deletion followed by a
refresh failure. On 2026-09-20 the user confirmed all requested runtime checks passed: no selection,
declined deletion, confirmed deletion and refresh, preservation of Customer/User/other appointments,
missing-row handling, controlled Delete failure, and controlled refresh failure after deletion.
The reviewing agent verified the code and build: 0 errors and 14 existing warnings. Runtime
checks were user-reported. This completes A3 and A3b; the changes are awaiting the user's commit.

## A4 — Calendar View

- [x] **A4** — View the calendar **by month**, and view appointments on a **specific day** by selecting a day from that calendar

> Note: the rubric asks for month view + select-a-day. It does *not* require a separate week view.

**Evidence (2026-09-20):** Month view is implemented in `MainForm.ConfigureCalendarLayout`,
`ConfigureCalendarBehavior`, `RefreshCalendarView`, and `calendarDataTable_CellFormatting`
for [#35](https://github.com/caw1517/c969-project/issues/35). The view filters a separate list
by local start year/month, preserves UTC models and the full appointment collection, orders by
UTC start then appointment ID, and displays local timestamps with month and time-zone labels.
`LoadAppointments` refreshes the calendar after successful loads and CRUD and marks failed loads
unavailable while preserving operation-specific errors and the selected date.
Standards and specification reviews found no actionable defects. A fresh rebuild to a temporary
output directory passed with 0 errors and 14 existing warnings; normal output was locked by the
running application/debugger. The user reported passing startup, month/year navigation, empty
months, CRUD including moving an appointment outside the month, full-list preservation, minimum
1100 x 600 layout, UTC/local boundaries, DST display, and failed-load recovery checks.
The user confirmed Pacific (`Pacific Standard Time`) as the test zone and restoration of any
temporary machine-zone change. Runtime checks were user-reported, not agent-executed.
Selected-day filtering and Show whole month are also implemented and verified for
[#36](https://github.com/caw1517/c969-project/issues/36), completing A4 and parent
[#12](https://github.com/caw1517/c969-project/issues/12). `_calendarDayMode` selects local-start
date equality or year/month membership. `DateChanged` and `DateSelected` enter day mode;
`showWholeMonthButton_Click` restores month mode. The native calendar is initialized before
subscribing to selection events. Date and mode survive tab changes and appointment reloads.
The user reported all requested runtime checks passed: populated/empty days, selecting the
highlighted day, month restoration, keyboard/month/year navigation, minimum-size layout,
Add/Edit/Delete including movement into/out of the selected day, full-list preservation,
UTC/local date differences, local-midnight crossing, DST display, and reload failure/recovery.
The user reported the verification zone as PST (Pacific) and confirmed temporary zone changes
were restored. These runtime checks were user-reported, not independently agent-executed.
The final rebuild passed with 0 errors and 14 existing warnings; whitespace checks passed.
Changes remain uncommitted for the user to commit.

## A5 — Time Zones

- [x] **A5** — Appointment times automatically adjust based on user time zone **and daylight saving time**

**Evidence (2026-09-20):** `TimeHelper` converts machine-local form input to UTC and UTC to local
for grid/editor display; Eastern conversion is used only for validation. Add/Edit persist UTC
and the reader assigns `DateTimeKind.Utc`. The user reported the Edit checks complete, including
the local-time round trip. The completion record in [#31](https://github.com/caw1517/c969-project/issues/31)
confirms local display against stored UTC and DST checks for October 30 and November 2, 2026,
accounting for the machine's time zone. Runtime verification was user-reported, not independently
executed by the reviewing agents. The parent #11 review found no functional gaps in appointment
CRUD or time conversion; the project build passed. A3, A3a, A3b, and A5 are complete.

## A6 — Alerts

- [ ] **A6** — On login, alert the user if they have an appointment within 15 minutes

**Evidence:** Not implemented. Login does not query the current user's upcoming appointments or
display a 15-minute alert.

## A7 — Reports

Must use **collection classes**, and **each of the three reports needs its own lambda expression**.
The rubric explicitly fails this if "less than 3 of the reports incorporate a lambda expression."

- [x] Number of appointment types by month
- [ ] Schedule for each **user**
- [ ] One additional report of your choice — Appointment Count by Customer
- [ ] All three use collection classes
- [ ] All three each contain a lambda expression

**Evidence (2026-09-24):** Types by Month is implemented for
[#38](https://github.com/caw1517/c969-project/issues/38). `MainForm.ConfigureReportsLayout`
creates the three Reports sub-tabs and an explicit read-only Year/Month/Type/Count grid with
automatic columns and user row creation/deletion disabled. `RefreshTypesByMonthReport` consumes
the shared `List<AppointmentDisplay>`, uses its own `GroupBy(appointment => ...)` lambda to group
all appointments by local start year, numeric month, and type, counts each group, sorts by
year/month/type, and materializes a `List<AppointmentTypeCountRow>`. `TimeHelper.ToLocal` derives
grouping keys without changing the appointment objects' UTC timestamps. No report-specific query
or additional library is used.

`RefreshReports` runs on successful and failed `LoadAppointments` paths, including post-Add/Edit/Delete
reloads. Successful empty loads show no appointments; failures clear the report and show unavailable
while preserving the existing successful-write/failed-refresh messages. Subsequent successful loads
restore the report.

The agent executed the implementation build (0 errors, 14 existing warnings) and whitespace checks.
The user confirmed the layout and, on 2026-09-24, all requested runtime checks: repeated-type counts,
separate types and years, Add/Edit/Delete refresh including type/month changes, UTC/local month-boundary
grouping, successful empty loads, failed reload clearing/unavailable state, and successful recovery.
Runtime verification is user-reported, not independently agent-executed.

User Schedules and Appointment Count by Customer remain pending; their sub-tabs currently provide
the layout only. The requirements for all three reports to use collections and their own lambdas
remain unchecked until the remaining reports are implemented and verified.

## A8 — Activity Log

- [x] **A8** — Record timestamp and username of each login to a text file named exactly `Login_History.txt` *(verified: three successful logins recorded)*
- [x] Each new record is **appended** — the rubric explicitly fails this if each login creates a new file *(verified: all three records remained in one file)*

**Evidence:** `LoginHistoryModule.RecordLogin` builds the exact filename, writes a UTC timestamp
and username, and calls `File.AppendAllText`; `LoginForm` calls it after successful authentication.
The completed runtime verification confirmed three successful logins produced three records in
the same `Login_History.txt` file.

## B — Submission

- [x] **B1** — Project saved/exported in Visual Studio format *(verified: `.slnx`/`.csproj` and successful rebuild)*
- [ ] **B2** — Project **completely** exported as a ZIP (folder/project structure intact)

## C — Professional Communication

- [ ] **C** — Grammar, spelling, punctuation, and fluency throughout the submission *(open: visible strings include “Adress” and “Calender”)*

---

## Competencies Being Assessed

Useful for sanity-checking that your design actually demonstrates each one:

| Code | Competency |
|---|---|
| 4041.4.1 | Database and file server applications using advanced constructs |
| 4041.4.2 | Lambda expressions to meet requirements more efficiently |
| 4041.4.3 | **Nongeneric and generic collections** to manipulate data |
| 4041.4.4 | Localization/globalization APIs for users in various regions |
| 4041.4.5 | Advanced exception control |

---

## Not A Graded Aspect, But Do It Anyway

Not named in this version's rubric — I checked. Worth doing regardless:

- [x] Parameterized queries everywhere, no string concatenation into SQL *(all current user-input SQL is parameterized; CRUD SQL does not exist yet)*
- [ ] Timestamps stored UTC in the DB, converted for display. Not optional in practice: the schema has **no time zone column and `start`/`end` are bare `DATETIME`**, so UTC storage is what makes A3a (9–5 EST) and A5 (user tz + DST) both achievable. See [[Schema]].

---

## Verification Notes — 2026-09-02

- `dotnet build C969-Project.slnx --no-restore -t:Rebuild` succeeds with 0 errors and 3 warnings
  in `LoginForm.cs` (two uninitialized non-nullable properties and one unused field).
- The completed runtime verification covered the local Pacific time-zone label, English/German
  login and error localization, valid/invalid/inactive login cases, and three successful login
  history writes. A1b, A1c, A8, and the append requirement are now marked complete.
- A read-only check of the configured local database found 4 countries, 7 cities, 3 addresses,
  3 customers, 2 users, and 2 appointments; the committed `sql/seed.sql` still does not recreate
  that complete state on an empty database.
- The hard constraint against external libraries remains open: `C969-Project.csproj` references
  `MySql.Data`.
- The project targets `net10.0-windows`, while the hard constraint says “.NET Framework”; this
  compatibility point predates the review range and should be confirmed with the evaluator.
- No automated test files or test projects are present.

---

## Supporting Docs

- [x] **`Database ERD.pdf`** — in this folder, extracted to [[Schema]]
- [x] Performance Assessment Lab Area — the task links a virtual lab environment; confirm whether you're expected to use it
