ALTER TABLE [TSC_Calendar] DROP CONSTRAINT [ref_TSC_Calendar_SignedWebUser]

go

-- Dropping index 'idx_TSC_Calendar_WebUserId2' which is not configured in OpenAccess but exists on the database.
DROP INDEX [idx_TSC_Calendar_WebUserId2] ON [TSC_Calendar]

go

-- dropping unknown column [WebUserId2]
ALTER TABLE [TSC_Calendar] DROP COLUMN [WebUserId2]

go

ALTER TABLE [TSC_Calendar] ADD CONSTRAINT [ref_TSC_Calendar_SignedWebUser] FOREIGN KEY ([WebUserId]) REFERENCES [SignedWebUser]([WebUserId])

go

-- Index 'idx_TSC_Calendar_WebUserId' was not detected in the database. It will be created
CREATE INDEX [idx_TSC_Calendar_WebUserId] ON [TSC_Calendar]([WebUserId])

go

