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

- [ ] **A2** — Add, update, and delete customer records in the database, functioning properly
- [ ] **A2a** — Validation, all three required:
    - [ ] Record includes name, address, and phone number fields
    - [ ] Fields are trimmed and non-empty
    - [ ] Phone number field allows only digits and dashes
- [ ] **A2b** — Exception handling working for all three operations:
    - [ ] add
    - [ ] update
    - [ ] delete database

**Evidence:** Not implemented. `CustomerForm.saveEditCustomerButton_Click` has empty Add/Edit
branches, `deleteCustomerButton` has no handler, and the validation only checks blankness. It does
not trim fields, enforce digits-and-dashes-only phone input, write to the database, refresh the
grid, or handle add/update/delete exceptions.

## A3 — Appointments

- [ ] **A3** — Add, update, delete appointments; capture appointment type; link to a specific customer record
- [x] **A3a** — Validation, both required:
    - [x] Appointments only during business hours 9:00 a.m.–5:00 p.m., Mon–Fri, **eastern standard time**
    - [x] Overlapping appointments prevented
- [ ] **A3b** — Exception handling working for all three operations:
    - [x] add
    - [x] update
    - [ ] delete database

**Evidence (2026-09-20):** Add (#32) and Edit (#33) are implemented in `AppointmentForm`,
`DatabaseManager`, and `MainForm`. Both capture Type and Customer, validate local inputs against
the same Eastern business date and 09:00–17:00 weekday window, and check global overlap.
Edit excludes its own ID, preserves ownership and creation audit fields, and checks row existence
inside a transaction so unchanged saves succeed while missing rows fail. Separate Add/Edit
exception paths include overlap lookup failures; Cancel writes nothing. The six explicit grid
columns display local times, and refresh failures are distinguished from successful saves.
Add runtime evidence is recorded in #32; the user reported all Edit tests complete on 2026-09-20.
Runtime verification was user-reported, not independently executed by the reviewing agents.
Delete remains outstanding, so the overall A3 and A3b boxes remain open.

## A4 — Calendar View

- [ ] **A4** — View the calendar **by month**, and view appointments on a **specific day** by selecting a day from that calendar

> Note: the rubric asks for month view + select-a-day. It does *not* require a separate week view.

**Evidence:** Not implemented. The Calendar tab is an empty placeholder; no month calendar,
appointment display, or day-selection filter exists.

## A5 — Time Zones

- [ ] **A5** — Appointment times automatically adjust based on user time zone **and daylight saving time**

**Evidence (2026-09-20):** `TimeHelper` converts machine-local form input to UTC and UTC to local
for grid/editor display; Eastern conversion is used only for validation. Add/Edit persist UTC
and the reader assigns `DateTimeKind.Utc`. The user reported the Edit checks complete, including
the local-time round trip. A dedicated DST verification record remains needed before checking
the complete A5 requirement.

## A6 — Alerts

- [ ] **A6** — On login, alert the user if they have an appointment within 15 minutes

**Evidence:** Not implemented. Login does not query the current user's upcoming appointments or
display a 15-minute alert.

## A7 — Reports

Must use **collection classes**, and **each of the three reports needs its own lambda expression**.
The rubric explicitly fails this if "less than 3 of the reports incorporate a lambda expression."

- [ ] Number of appointment types by month
- [ ] Schedule for each **user**
- [ ] One additional report of your choice — write down which one:
- [ ] All three use collection classes
- [ ] All three each contain a lambda expression

**Evidence:** Not implemented. The Reports tab is an empty placeholder; none of the three required
reports, collection-based processing, or three separate lambdas exists. The additional report has
not yet been selected.

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
