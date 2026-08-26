-- C969 seed data
--
-- Brings the stock WGU sample data in line with the assignment's three offices:
-- Phoenix AZ, New York NY, London England.
--
-- Re-runnable. Every statement is idempotent, so running this twice is a no-op.
-- Run it whenever the data gets into a bad state while testing customer delete.
--
-- Schema notes (see docs/Schema.md):
--   - Every column is NOT NULL with no default, so every INSERT supplies every column.
--   - `createDate` is DATETIME and must be supplied.
--   - `lastUpdate` is a TIMESTAMP auto-maintained by MySQL and is deliberately never written.
--   - It is `createdBy` (with the "d") and `lastUpdateBy` (without). That inconsistency is real.
--
-- Not seeded here: appointments. Those are created through the app, which is better
-- evidence the app works. The two stock 2019-01-01 rows are left in place by choice.

-- ---------------------------------------------------------------------------
-- country: add the UK, which London needs and the stock data lacks.
-- ---------------------------------------------------------------------------

INSERT INTO country (country, createDate, createdBy, lastUpdateBy)
SELECT 'United Kingdom', UTC_TIMESTAMP(), 'test', 'test'
WHERE NOT EXISTS (SELECT 1 FROM country WHERE country = 'United Kingdom');

-- ---------------------------------------------------------------------------
-- city: add Phoenix and London.
--
-- These two complete the assignment's office trio alongside the existing
-- New York. The three are a near-perfect DST test set for A5:
--   Phoenix   - US Mountain, does NOT observe DST
--   New York  - US Eastern, observes US DST
--   London    - GMT/BST, observes a different continent's DST calendar
-- ---------------------------------------------------------------------------

INSERT INTO city (city, countryId, createDate, createdBy, lastUpdateBy)
SELECT 'Phoenix', (SELECT countryId FROM country WHERE country = 'US'),
       UTC_TIMESTAMP(), 'test', 'test'
WHERE NOT EXISTS (SELECT 1 FROM city WHERE city = 'Phoenix');

INSERT INTO city (city, countryId, createDate, createdBy, lastUpdateBy)
SELECT 'London', (SELECT countryId FROM country WHERE country = 'United Kingdom'),
       UTC_TIMESTAMP(), 'test', 'test'
WHERE NOT EXISTS (SELECT 1 FROM city WHERE city = 'London');
