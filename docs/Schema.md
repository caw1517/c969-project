---
type: note
date: 2026-08-21
status: active
project: C969
area: school
tags: [c969, schema, reference]
---

# Schema

Extracted from `Database ERD.pdf` in this folder. **This structure cannot be modified** — it's
shared with other systems (hard constraint from the task). Referenced by [[Rubric]].

## Audit columns

Every one of the seven tables carries the same four:

| Column | Type | Notes |
|---|---|---|
| `createDate` | `DATETIME` | Set explicitly on INSERT. Not auto. |
| `createdBy` | `VARCHAR(40)` | Username string, not a FK to `user`. |
| `lastUpdate` | `TIMESTAMP` | **Auto-populated by MySQL.** Don't write it. |
| `lastUpdateBy` | `VARCHAR(40)` | Username string. Set on INSERT *and* UPDATE. |

> [!warning] Naming traps
> - It is `lastUpdateBy`, **not** `lastUpdatedBy`. `Models.cs` currently has the wrong name on
>   `AuditableModel` — harmless until the first write, then it's a mismatch to chase.
> - It is `lastUpdate`, **not** `lastUpdated`.
> - `createdBy` has the "d", `lastUpdateBy` does not. They are inconsistent in the real schema.
>   That's not a typo in this note.
> - `createDate` is `DATETIME` and must be supplied. `lastUpdate` is `TIMESTAMP` and must not be.

## Tables

### `country`
```
countryId    INT(10)      PK
country      VARCHAR(50)
+ audit columns
```

### `city`
```
cityId       INT(10)      PK
city         VARCHAR(50)
countryId    INT(10)      FK -> country.countryId
+ audit columns
```

### `address`
```
addressId    INT(10)      PK
address      VARCHAR(50)
address2     VARCHAR(50)
cityId       INT(10)      FK -> city.cityId
postalCode   VARCHAR(10)
phone        VARCHAR(20)
+ audit columns
```

### `customer`
```
customerId   INT(10)      PK
customerName VARCHAR(45)   <- 45, not 50. Shorter than every other name column.
addressId    INT(10)      FK -> address.addressId
active       TINYINT(1)
+ audit columns
```

### `user`
```
userId       INT          PK
userName     VARCHAR(50)
password     VARCHAR(50)   <- plaintext by design. Assessment wants test/test.
active       TINYINT
+ audit columns
```

### `appointment`
```
appointmentId INT(10)     PK
customerId    INT(10)     FK -> customer.customerId
userId        INT         FK -> user.userId
title         VARCHAR(255)
description   TEXT
location      TEXT
contact       TEXT
type          TEXT         <- A3 "appointment type" lives here
url           VARCHAR(255)
start         DATETIME     <- no time zone column. See below.
end           DATETIME
+ audit columns
```

## The time zone problem

`start` and `end` are bare `DATETIME` with **no time zone column anywhere in the schema**. The
database cannot tell you what zone a stored time is in — that convention has to live in the
application and be applied consistently.

Two rubric aspects depend on getting this right:

- **A3a** — appointments restricted to 9:00–5:00 Mon–Fri *eastern standard time*
- **A5** — times displayed adjusted to the *user's* zone, including daylight saving

**Convention: store UTC, convert at the edges.** Every write converts local → UTC immediately
before the parameter is bound; every read converts UTC → local immediately after the reader
returns. Nothing in between ever handles a local time.

Use `TimeZoneInfo` for the conversions, not fixed offsets — a fixed `-5` breaks across DST, and
A5 names daylight saving explicitly. Eastern is
`TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time")` on Windows; despite the name that
ID covers EDT too, so it handles the DST shift on its own.

Note that A3a's 9–5 window is checked in **eastern** time regardless of where the user is. A user
in London booking a slot sees their own local times (A5) but the validity of the slot is decided
after converting to eastern. Those are two different conversions and it's worth keeping them as
two clearly separate helpers.

## Relationship chain

```
country -> city -> address -> customer -> appointment <- user
```

A customer's country is four joins away. `DatabaseManager.GetCustomers()` already walks that
chain; the same shape works for a per-country appointments report.

## Seeding

The database ships **empty** — the task says so, and it means nothing below the login form is
testable until rows exist. Seed order follows the FK chain:

```
country -> city -> address -> customer
user
appointment  (needs both customer and user)
```

The three offices named in the task are Phoenix AZ, New York NY, and London England — that's the
intended spread of cities/countries and the source of the time zone variety A5 wants to show off.

`user` needs at least one row with `userName = 'test'` and `password = 'test'`.
