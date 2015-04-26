ALTER TABLE [TSC_Calendar] DROP CONSTRAINT [ref_TSC_Calendar_SignedWebUser]

go

-- Index 'idx_TSC_Calendar_WebUserId' was detected in the database but with a different configuration. It will be recreated
DROP INDEX [idx_TSC_Calendar_WebUserId] ON [TSC_Calendar]

go

-- Column was read from database as: [WebUserId] int null
-- modify column for field _signedWebUser
UPDATE [TSC_Calendar]
   SET [WebUserId] = 0 -- Add your own default value here, for when [WebUserId] is null.
 WHERE [WebUserId] IS NULL

go

ALTER TABLE [TSC_Calendar] ALTER COLUMN [WebUserId] int NOT NULL

go

ALTER TABLE [TSC_Calendar] ADD CONSTRAINT [ref_TSC_Calendar_SignedWebUser] FOREIGN KEY ([WebUserId]) REFERENCES [SignedWebUser]([WebUserId])

go

-- Index 'idx_TSC_Calendar_WebUserId' was detected in the database but with a different configuration. It will be recreated
CREATE INDEX [idx_TSC_Calendar_WebUserId] ON [TSC_Calendar]([WebUserId])

go

