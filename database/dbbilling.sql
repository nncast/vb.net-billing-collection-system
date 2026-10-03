-- ============================================================================
--  BillingAndCollectionSystem — database schema
--  Database: dbbilling   (matches every form's Connect(...) call)
--  Engine:   InnoDB (required for the foreign keys below)
--
--  This file was reverse-engineered from the app's own CRUD code — every
--  table, column, and constraint here exists because a SELECT/INSERT/UPDATE/
--  DELETE in the VB.NET forms actually reads or writes it. Referenced from:
--    Conn.vb                          -> Connect(..., "dbbilling", ...)
--    Admin/Sections-a/frmConsumer-a.vb -> tblconsumers
--    Admin/Sections-a/frmRate.vb       -> tblrates
--    Admin/Sections-a/frmReading.vb    -> tblreadings, tblconsumers,
--                                         tblbills, tblpayments
--    Admin/Sections-a/frmBills.vb      -> tblbills, tblreadings,
--                                         tblconsumers, tblrates, tblpayments
--    Admin/Sections-a/frmPayments.vb   -> tblpayments, tblbills,
--                                         tblreadings, tblconsumers
--    Admin/Sections-a/frmHome-a.vb     -> dashboard counts/joins only
--    Admin/Sections-a/frmReport.vb     -> monthly report joins only
--
--  Relationships: consumer -> readings -> bill (one per reading) -> payments.
--  Every foreign key cascades on delete, because frmConsumer-a.vb deletes a
--  consumer with a single DELETE and promises "all related data" goes too.
--
--  Import this before running the app (SQLYog / phpMyAdmin / mysql CLI):
--      mysql -u root -p < dbbilling.sql
-- ============================================================================

CREATE DATABASE IF NOT EXISTS dbbilling
  CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci;

USE dbbilling;

SET FOREIGN_KEY_CHECKS = 0;

-- ----------------------------------------------------------------------------
-- tblconsumers
--   Full CRUD in frmConsumer-a.vb; looked up by name in frmReading.vb and
--   joined into every bill/payment/report list.
-- ----------------------------------------------------------------------------
DROP TABLE IF EXISTS tblconsumers;
CREATE TABLE tblconsumers (
  id       INT UNSIGNED NOT NULL AUTO_INCREMENT,
  fname    VARCHAR(50)  NOT NULL,
  lname    VARCHAR(50)  NOT NULL,
  phone    VARCHAR(20)  NOT NULL,
  address  VARCHAR(255) NOT NULL,
  PRIMARY KEY (id)
) ENGINE=InnoDB;

-- ----------------------------------------------------------------------------
-- tblrates
--   Full CRUD in frmRate.vb (date is set with NOW() on insert). frmBills.vb
--   prices a bill with the newest rate (ORDER BY id DESC LIMIT 1), so at
--   least one row must exist before a bill can be created — see seed data.
-- ----------------------------------------------------------------------------
DROP TABLE IF EXISTS tblrates;
CREATE TABLE tblrates (
  id    INT UNSIGNED  NOT NULL AUTO_INCREMENT,
  date  DATETIME      NOT NULL,
  rate  DECIMAL(10,2) NOT NULL,
  PRIMARY KEY (id),
  KEY idx_rates_date (date)
) ENGINE=InnoDB;

-- ----------------------------------------------------------------------------
-- tblreadings
--   Full CRUD in frmReading.vb. prev/curr are meter readings; usage is
--   always computed as (curr - prev), never stored. The form allows only
--   one reading per consumer per month (checked in code).
-- ----------------------------------------------------------------------------
DROP TABLE IF EXISTS tblreadings;
CREATE TABLE tblreadings (
  id          INT UNSIGNED  NOT NULL AUTO_INCREMENT,
  consumerid  INT UNSIGNED  NOT NULL,
  date        DATE          NOT NULL,
  prev        DECIMAL(12,2) NOT NULL,
  curr        DECIMAL(12,2) NOT NULL,
  PRIMARY KEY (id),
  KEY idx_readings_consumer_date (consumerid, date),
  CONSTRAINT fk_readings_consumer
    FOREIGN KEY (consumerid) REFERENCES tblconsumers (id)
    ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB;

-- ----------------------------------------------------------------------------
-- tblbills
--   Full CRUD in frmBills.vb, one bill per reading (readingid is UNIQUE —
--   the form also checks this, and lists only readings with no bill yet).
--   status is 'Unpaid' or 'Paid' from the form's combo box, or 'Partial'
--   when frmPayments.vb recalculates it after a payment.
-- ----------------------------------------------------------------------------
DROP TABLE IF EXISTS tblbills;
CREATE TABLE tblbills (
  id         INT UNSIGNED  NOT NULL AUTO_INCREMENT,
  readingid  INT UNSIGNED  NOT NULL,
  duedate    DATE          NOT NULL,
  amount     DECIMAL(12,2) NOT NULL,
  status     VARCHAR(10)   NOT NULL DEFAULT 'Unpaid',
  PRIMARY KEY (id),
  UNIQUE KEY uq_bills_reading (readingid),
  KEY idx_bills_status (status),
  CONSTRAINT fk_bills_reading
    FOREIGN KEY (readingid) REFERENCES tblreadings (id)
    ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB;

-- ----------------------------------------------------------------------------
-- tblpayments
--   Full CRUD in frmPayments.vb (partial payments allowed, total capped at
--   the bill amount). frmBills.vb also inserts one automatically when a bill
--   is saved as 'Paid' with no payments yet.
-- ----------------------------------------------------------------------------
DROP TABLE IF EXISTS tblpayments;
CREATE TABLE tblpayments (
  id      INT UNSIGNED  NOT NULL AUTO_INCREMENT,
  billid  INT UNSIGNED  NOT NULL,
  date    DATE          NOT NULL,
  amount  DECIMAL(12,2) NOT NULL,
  PRIMARY KEY (id),
  KEY idx_payments_bill (billid),
  KEY idx_payments_date (date),
  CONSTRAINT fk_payments_bill
    FOREIGN KEY (billid) REFERENCES tblbills (id)
    ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB;

SET FOREIGN_KEY_CHECKS = 1;

-- ============================================================================
--  Seed data — a starting rate (required before any bill can be created)
--  plus a few sample records so every screen has something to show.
--  Bill amounts = usage x rate (12.50/kWh); statuses match the payments.
--  Dates are relative to the day you import this file (readings at the end
--  of the last two months, one payment today), so the home dashboard's
--  "this month" total and current-year chart have data to show.
--  Everything except the rate is safe to delete.
-- ============================================================================

INSERT INTO tblrates (date, rate) VALUES
  (CURDATE() - INTERVAL 3 MONTH, 12.50);

INSERT INTO tblconsumers (fname, lname, phone, address) VALUES
  ('Juan', 'Dela Cruz', '0917-123-4567', 'Purok 1, Brgy. San Isidro'),
  ('Maria', 'Santos', '0918-765-4321', 'Purok 3, Brgy. Poblacion');

INSERT INTO tblreadings (consumerid, date, prev, curr) VALUES
  (1, LAST_DAY(CURDATE() - INTERVAL 2 MONTH), 0.00,   120.00),
  (1, LAST_DAY(CURDATE() - INTERVAL 1 MONTH), 120.00, 250.00),
  (2, LAST_DAY(CURDATE() - INTERVAL 1 MONTH), 0.00,   90.00);

-- Due dates are 15 days after each reading, as frmBills.vb suggests.
INSERT INTO tblbills (readingid, duedate, amount, status) VALUES
  (1, LAST_DAY(CURDATE() - INTERVAL 2 MONTH) + INTERVAL 15 DAY, 1500.00, 'Paid'),
  (2, LAST_DAY(CURDATE() - INTERVAL 1 MONTH) + INTERVAL 15 DAY, 1625.00, 'Partial'),
  (3, LAST_DAY(CURDATE() - INTERVAL 1 MONTH) + INTERVAL 15 DAY, 1125.00, 'Unpaid');

INSERT INTO tblpayments (billid, date, amount) VALUES
  (1, LAST_DAY(CURDATE() - INTERVAL 2 MONTH) + INTERVAL 10 DAY, 1500.00),
  (2, CURDATE(), 1000.00);
