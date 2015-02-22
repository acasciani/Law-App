-- add column for field _holidayDate
ALTER TABLE [Holiday] ADD [HolidayDate] datetime NULL

go

UPDATE [Holiday] SET [HolidayDate] = getdate()

go

ALTER TABLE [Holiday] ALTER COLUMN [HolidayDate] datetime NOT NULL

go

-- dropping unknown column [dte]
ALTER TABLE [Holiday] DROP COLUMN [dte]

go

