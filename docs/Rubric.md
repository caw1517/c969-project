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

> [!warning] Hard constraints from the task
> - **No frameworks or external libraries except the .NET Framework.**
> - The database has no data — you must populate it.
> - Username and password to log in must both be the word **`test`**.
> - The MySQL database structure **cannot be modified** — it's shared with other systems.
> - Offices: Phoenix AZ, New York NY, London England. That's your time zone / language spread.

---

## A1 — Login Form

- [ ] **A1a** — Log-in form accurately determines a user's location
- [ ] **A1b** — Form translates log-in *and error control* messages into English and one additional language
- [ ] **A1c** — Consistently and accurately verifies the correct username and password

**Evidence:**

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

**Evidence:**

## A3 — Appointments

- [ ] **A3** — Add, update, delete appointments; capture appointment type; link to a specific customer record
- [ ] **A3a** — Validation, both required:
    - [ ] Appointments only during business hours 9:00 a.m.–5:00 p.m., Mon–Fri, **eastern standard time**
    - [ ] Overlapping appointments prevented
- [ ] **A3b** — Exception handling working for all three operations:
    - [ ] add
    - [ ] update
    - [ ] delete database

**Evidence:**

## A4 — Calendar View

- [ ] **A4** — View the calendar **by month**, and view appointments on a **specific day** by selecting a day from that calendar

> Note: the rubric asks for month view + select-a-day. It does *not* require a separate week view.

**Evidence:**

## A5 — Time Zones

- [ ] **A5** — Appointment times automatically adjust based on user time zone **and daylight saving time**

**Evidence:**

## A6 — Alerts

- [ ] **A6** — On login, alert the user if they have an appointment within 15 minutes

**Evidence:**

## A7 — Reports

Must use **collection classes**, and **each of the three reports needs its own lambda expression**.
The rubric explicitly fails this if "less than 3 of the reports incorporate a lambda expression."

- [ ] Number of appointment types by month
- [ ] Schedule for each **user**
- [ ] One additional report of your choice — write down which one:
- [ ] All three use collection classes
- [ ] All three each contain a lambda expression

**Evidence:**

## A8 — Activity Log

- [ ] **A8** — Record timestamp and username of each login to a text file named exactly `Login_History.txt`
- [ ] Each new record is **appended** — the rubric explicitly fails this if each login creates a new file

**Evidence:**

## B — Submission

- [ ] **B1** — Project saved/exported in Visual Studio format
- [ ] **B2** — Project **completely** exported as a ZIP (folder/project structure intact)

## C — Professional Communication

- [ ] **C** — Grammar, spelling, punctuation, and fluency throughout the submission

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

- [ ] Parameterized queries everywhere, no string concatenation into SQL
- [ ] Timestamps stored UTC in the DB, converted for display. Not optional in practice: the schema has **no time zone column and `start`/`end` are bare `DATETIME`**, so UTC storage is what makes A3a (9–5 EST) and A5 (user tz + DST) both achievable. See [[Schema]].

---

## Supporting Docs

- [x] **`Database ERD.pdf`** — in this folder, extracted to [[Schema]]
- [x] Performance Assessment Lab Area — the task links a virtual lab environment; confirm whether you're expected to use it
