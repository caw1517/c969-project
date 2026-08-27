# Context

Glossary for C969 (BOP4 Task 1) — a WinForms scheduling app over a fixed MySQL schema.
Decisions and their reasoning live on the [wayfinder map](https://github.com/caw1517/c969-project/issues/1), not here.

## Time

The schema has **no time zone column**, so the zone of any stored value is a convention the
application enforces. Three distinct zones are in play and conflating them is the main hazard.

- **UTC** — the storage zone. Every `DATETIME` in the database is UTC, including `createDate`.
  There are no exceptions to this rule. Any value in memory that did not just come off a form
  control is UTC.

- **Local** — the machine's zone, `TimeZoneInfo.Local`. The only zone the user ever sees or types.
  Values live in this zone exclusively inside form controls, at the moment of entry and the
  moment of display. Called *local*, never "user time" — see below.

- **Eastern** — the business-hours zone. Appointments are valid only 9:00–17:00 Mon–Fri eastern,
  regardless of where the user is. This zone is used **only** to answer "is this slot legal?" and
  is never displayed and never stored.

**"User time zone"** is the rubric's phrase (A5), not ours. In code and conversation it means
*local* — resolve to that term to avoid implying a per-user stored preference, which does not
exist. There is no user-level zone setting; the machine's zone is the user's zone.

**Edge** — the boundary where conversion happens: the DB reader/parameter on one side, the form
control on the other. "Convert at the edges" means nothing between those two points is ever local.

## Records

- **Customer** — a person in the `customer` table. Has exactly one **Address**, which in turn
  resolves through **City** to **Country**. Not the same as a *User*.
- **User** — a login account in the `user` table (`test`/`test`). Appointments belong to a User as
  well as a Customer; A7's second report is per-User, not per-Customer.
- **Appointment** — links one Customer to one User over a start/end span. Carries a **type**,
  which A3 requires be captured and A7's first report groups by.

## Language and location

Two different questions that a login form answers at the same moment, deliberately kept apart.

- **Location** — *where the user is*, resolved as `TimeZoneInfo.Local` and shown as a label.
  Drives nothing but display and the time conversions described above. This is what the rubric
  means by "determines a user's location" (A1a).

- **Language** — *what the user reads*, resolved as a **culture** and chosen explicitly via a
  toggle on the login form. Defaults to the detected `CurrentUICulture` but the user overrides it.

Choosing a language must **never** change the location, and detecting a location must never
change the language. They are two mechanisms, not one — a German-reading user in Phoenix is an
ordinary case, not a contradiction.

- **Culture** — a `CultureInfo`, the .NET handle for a language. This project uses **neutral**
  cultures (`de`, not `de-DE`) so regional variants fall back to the language rather than to
  English. Only two exist here: the neutral default (English) and `de`.

- **Localized string** — a string resolved from `.resx` at display time rather than written
  inline. Only the **login form's** strings are localized; everywhere else in the app, strings are
  plain English literals, and that is a deliberate scope boundary rather than an oversight.
