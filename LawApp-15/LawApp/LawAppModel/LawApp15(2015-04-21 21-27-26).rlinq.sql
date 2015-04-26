ALTER TABLE [TSC_Break] DROP CONSTRAINT [ref_TSC_Break_SignedWebUser]

go

-- dropping unknown column [WebUserId]
ALTER TABLE [TSC_Break] DROP COLUMN [WebUserId]

go

-- add column for field _signedWebUser
ALTER TABLE [TSC_UniqueDays] ADD [WebUserId] int NULL

go

UPDATE [TSC_UniqueDays] SET [WebUserId] = 0

go

ALTER TABLE [TSC_UniqueDays] ALTER COLUMN [WebUserId] int NOT NULL

go

ALTER TABLE [TSC_UniqueDays] ADD CONSTRAINT [ref_TSC_UnqDys_SgndWb_BCB5FFD7] FOREIGN KEY ([WebUserId]) REFERENCES [SignedWebUser]([WebUserId])

go

