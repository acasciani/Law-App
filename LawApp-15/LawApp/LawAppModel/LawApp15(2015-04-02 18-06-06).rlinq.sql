-- add column for field _holidayEndDate
ALTER TABLE [Holiday] ADD [HolidayEndDate] datetime NULL

go

-- add column for field _isVacation
ALTER TABLE [Holiday] ADD [IsVacation] tinyint NULL

go

UPDATE [Holiday] SET [IsVacation] = 0

go

ALTER TABLE [Holiday] ALTER COLUMN [IsVacation] tinyint NOT NULL

go

