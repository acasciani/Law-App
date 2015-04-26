-- add column for field _signedWebUser
ALTER TABLE [TSC_Break] ADD [WebUserId] int NULL

go

UPDATE [TSC_Break] SET [WebUserId] = 0

go

ALTER TABLE [TSC_Break] ALTER COLUMN [WebUserId] int NOT NULL

go

ALTER TABLE [TSC_Break] ADD CONSTRAINT [ref_TSC_Break_SignedWebUser] FOREIGN KEY ([WebUserId]) REFERENCES [SignedWebUser]([WebUserId])

go

