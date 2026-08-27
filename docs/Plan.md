---
type: note
date: 2026-08-21
status: active
project: C969
area: school
tags: [c969, plan]
---

# C969 Build Plan

Ordered chunks to finish the project. Each is small enough to finish and commit in one sitting.
Rubric aspects in **bold** map to [[Rubric]]; column names come from [[Schema]].

**Ordering principle:** three things are foundational and cheap to get wrong late —
the seed data, the current-user session, and the UTC time convention. Each one, done after the
code that depends on it, means rewriting that code. They're steps 0–2 for that reason. Everything
after is roughly rubric order.

---

## Step 0 — Seed the database

**Blocks:** literally everything below.

The DB ships empty. Nothing is testable until it isn't.

- [ ] Write a seed script — plain `.sql` file, run once by hand, kept in `docs/` or a `sql/` folder
- [ ] Populate in FK order: `country` -> `city` -> `address` -> `customer`
- [ ] Cities: Phoenix, New York, London (matches the three offices; gives A5 real zone variety)
- [ ] `user` row with `userName='test'`, `password='test'`, `active=1`
- [ ] A few `customer` rows with **no NULLs** in `address2` / `postalCode` / `phone`

> `GetCustomers()` uses `reader.GetString(...)` on those three columns and will throw on NULL.
> Either seed them non-null or make the reads null-safe now — cheaper now than debugging it later.

**Done when:** the customers grid populates on launch with real rows.

---

## Step 1 — Session + audit plumbing

**Blocks:** every INSERT and UPDATE in the project.

Every table needs `createdBy` / `lastUpdateBy` (see [[Schema]] for the naming traps). There's
currently no notion of "who is logged in," so without this every write hardcodes a placeholder
you come back and fix.

- [ ] Static `Session` class: `CurrentUserName`, `CurrentUserId`
- [ ] Fix `AuditableModel` — `UpdatedDate`/`LastUpdatedBy` -> `LastUpdate`/`LastUpdateBy`
- [ ] Decide how audit columns get stamped: one helper that binds `createDate`, `createdBy`,
      `lastUpdateBy` given a command, rather than repeating it in six methods
- [ ] Fix `App.config` `providerName` — currently `System.Data.SqlClient`, should be
      `MySql.Data.MySqlClient`
- [ ] Drop the `MessageBox.Show("Connected to Database")` from `StartConnection()`

**Done when:** `Session.CurrentUserName` can be set and read; nothing else visibly changes.

---

## Step 2 — Time convention **(A5 foundation)**

**Blocks:** all of A3, A4, A6, A7. Do this *before* the first appointment INSERT.

If appointments get written in local time first, business-hours validation, overlap detection,
the calendar, the 15-minute alert, and the reports are all built on the wrong base and get
rewritten. See [[Schema]] for why the schema forces this.

- [ ] `TimeHelper` static class, two directions:
    - `ToUtc(DateTime local)` / `ToLocal(DateTime utc)` — user's zone, for display
    - `ToEastern(DateTime utc)` — for the 9–5 business-hours check only
- [ ] Use `TimeZoneInfo`, never a hardcoded offset — **A5** names DST explicitly
- [ ] Sanity-check a date on each side of a DST boundary before moving on

**Done when:** a round-trip local -> UTC -> local returns the original, on both sides of a DST
change.

---

## Step 3 — Finish customer CRUD **(A2, A2a, A2b)**

The write path here is the template A3 will copy. Worth getting the shape right once.

- [ ] Populate `countryCustomerSelectBox` from `country`; cascade `cityCustomerSelectBox` off the
      selected country
- [ ] On edit, preselect the customer's existing country/city
- [ ] `AddCustomer` — INSERT `address` first, then `customer` with the new `addressId`
- [ ] `UpdateCustomer` — UPDATE both `address` and `customer`
- [ ] `DeleteCustomer` + wire up `deleteCustomerButton` (no handler exists yet)
- [ ] Confirmation prompt before delete
- [ ] Refresh the grid after each operation
- [ ] `saveEditCustomerButton_Click` currently shows validation errors then **falls through and
      saves anyway** — needs a `return`
- [ ] **A2a** phone validation: digits and dashes only. Nothing else currently enforces this
- [ ] **A2a** trim all fields before validating and before binding
- [ ] **A2b** try/catch around each of add / update / delete separately, with a message the user
      can actually act on
- [ ] Parameterized queries throughout — no string concatenation into SQL

> Delete has an FK consideration: a customer with appointments can't be deleted while they exist.
> Decide now — block with a clear message, or cascade. Blocking is simpler and easier to defend.

**Done when:** add, edit, and delete all round-trip to the DB and survive bad input without
crashing.

---

## Step 4 — Login form **(A1, A1a, A1b, A1c)** + **A8**

**Blocks:** A6. Also retro-fills `Session` from step 1 with a real user.

- [ ] Login form, shown before `MainForm` — change `Program.cs` to run login first and only open
      `MainForm` on success
- [ ] **A1c** validate against the `user` table, parameterized. `test` / `test`
- [ ] **A1a** detect and display user location — `TimeZoneInfo.Local` and/or
      `CultureInfo.CurrentCulture`
- [ ] **A1b** translate login labels **and error messages** into English + one other language.
      Use `.resx` resource files keyed off `CurrentUICulture` — this is the localization API the
      competencies list wants to see
- [ ] Set `Session.CurrentUserName` / `CurrentUserId` on success
- [ ] **A8** append timestamp + username to `Login_History.txt`
    - [ ] Filename exactly that
    - [ ] **Append, never overwrite** — the rubric fails this outright if each login makes a new
          file. `File.AppendAllText`, not `WriteAllText`
    - [ ] Verify by logging in three times and checking all three lines are present

**Done when:** login gates the app, both languages render, and three logins produce three lines
in one file.

---

## Step 5 — Appointment CRUD **(A3, A3b)**

- [ ] `Appointment` model + `AppointmentDisplay` (joined customer name, user name)
- [ ] `GetAppointments()`, converting UTC -> local on read (step 2)
- [ ] Appointments tab: grid + Add / Edit / Delete buttons
- [ ] Appointment form: customer picker (**A3** requires the link to a customer record),
      **type** field, title, description, location, contact, url, start, end
- [ ] Add / Update / Delete against the DB, converting local -> UTC on write
- [ ] **A3b** try/catch around each of the three operations separately

**Done when:** appointments round-trip and the stored `start`/`end` are visibly UTC in the DB
while displaying correctly in the app.

---

## Step 6 — Appointment validation **(A3a)**

Separate step from step 5 on purpose — it's fiddly, and easier to get right against a working
CRUD path than tangled up in one.

- [ ] Business hours: 9:00–17:00, Mon–Fri, **eastern** — convert to eastern first, then check
- [ ] Reject weekends
- [ ] Overlap detection: query existing appointments for a conflicting range
    - [ ] On **edit**, exclude the appointment being edited from its own overlap check — classic
          bug, it always reports a conflict with itself
    - [ ] Decide scope: per-user or global. Per-user is the usual reading
- [ ] Clear message naming which rule was broken

**Done when:** a Saturday booking, an 8am booking, and a double-booking are each rejected with a
distinct message.

---

## Step 7 — Calendar view **(A4)**

- [ ] `MonthCalendar` on the calendar tab
- [ ] **Month view** of appointments
- [ ] Selecting a day filters to that day's appointments

> The rubric wants month view + select-a-day. A separate week view is **not** required — skip it
> unless everything else is done.

**Done when:** picking a day shows only that day's appointments.

---

## Step 8 — Reports **(A7)**

Needs appointment data, so it lands here. Three reports, and the rubric fails this if fewer than
three use a lambda.

- [ ] Report 1 — number of appointment types by month
- [ ] Report 2 — schedule for each user
- [ ] Report 3 — **appointments per customer** (`GroupBy` over the collection you already have;
      no new query needed)
- [ ] All three use **collection classes** (competency 4041.4.3 wants generic collections)
- [ ] All three **each** contain a lambda — one per report, not three in one
- [ ] Render somewhere on the reports tab

> Alternatives for report 3 if you'd rather: appointments by country (reuses the existing
> customer join chain), or total appointment hours per month. Appointments-per-customer is the
> cheapest.

**Done when:** all three render, and you can point at the specific lambda in each.

---

## Step 9 — Login alert **(A6)**

Small, and depends on both login (step 4) and appointments (step 5).

- [ ] After successful login, check the current user's appointments
- [ ] Alert if one starts within 15 minutes
- [ ] Compare in a single consistent zone — UTC is easiest
- [ ] Test both branches: one appointment inside the window, one outside

---

## Step 10 — Polish and submit **(B1, B2, C)**

- [ ] Remove leftovers — `maskedTextBox1` in `Form1.Designer.cs` is unused
- [ ] Walk [[Rubric]] top to bottom and fill in every **Evidence** line with the class/method
      that satisfies it. This is what you need if it comes back for revision
- [ ] Re-verify **A8** appends after all the later changes
- [ ] **C** — proofread anything user-facing: form labels, message boxes, validation strings
- [ ] **B1/B2** — export in Visual Studio format, ZIP with folder structure intact

---

## Suggested commit points

One per step, roughly. Steps 3, 5, and 8 are the big ones and could reasonably split in two
(read path / write path for 3 and 5; one commit per report for 8).

## Risk notes

- **Step 2 is the one to not skip or defer.** It's the cheapest step here and the most expensive
  to retrofit.
- **A8 append** and **A7's three-lambda rule** are the two places the rubric says it fails you
  outright. Both are easy to satisfy and easy to half-satisfy without noticing.
- Steps 0–2 produce almost nothing visible. That's expected — resist reordering them behind
  something more satisfying.
