ALTER TABLE [TSC_Break] ADD CONSTRAINT [ref_TSC_Break_SignedWebUser] FOREIGN KEY ([WebUserId]) REFERENCES [SignedWebUser]([WebUserId])

go

