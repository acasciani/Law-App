ALTER TABLE [TSC_Calendar] DROP CONSTRAINT [ref_TSC_Calendar_SignedWebUser]

go

-- Dropping index 'idx_TSC_Calendar_WebUserId' which is not configured in OpenAccess but exists on the database.
DROP INDEX [idx_TSC_Calendar_WebUserId] ON [TSC_Calendar]

go

-- add column for field _signedWebUser
ALTER TABLE [TSC_Calendar] ADD [WebUserId2] int NULL

go

ALTER TABLE [TSC_Calendar] ADD CONSTRAINT [ref_TSC_Calendar_SignedWebUser] FOREIGN KEY ([WebUserId2]) REFERENCES [SignedWebUser]([WebUserId])

go

-- Index 'idx_TSC_Calendar_WebUserId2' was not detected in the database. It will be created
CREATE INDEX [idx_TSC_Calendar_WebUserId2] ON [TSC_Calendar]([WebUserId2])

go

