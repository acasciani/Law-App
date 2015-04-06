-- add column for field _person
ALTER TABLE [SignedWebUser] ADD [PersonId] int NULL

go

-- System.Collections.Generic.IList`1 LawAppModel.SignedWebUser._permissions
CREATE TABLE [SignedWebUser_Permission] (
    [WebUserId] int NOT NULL,
    [PermissionId] int NOT NULL,
    CONSTRAINT [pk_SignedWebUser_Permission] PRIMARY KEY ([WebUserId], [PermissionId])
)

go

ALTER TABLE [SignedWebUser] ADD CONSTRAINT [ref_SignedWebUser_Person] FOREIGN KEY ([PersonId]) REFERENCES [Person]([PersonId])

go

ALTER TABLE [SignedWebUser_Permission] ADD CONSTRAINT [ref_SgndWbUsr_Prmssn__2740C748] FOREIGN KEY ([WebUserId]) REFERENCES [SignedWebUser]([WebUserId])

go

ALTER TABLE [SignedWebUser_Permission] ADD CONSTRAINT [ref_SgndWbUsr_Prmssn__C73AD92C] FOREIGN KEY ([PermissionId]) REFERENCES [Permission]([PermissionId])

go

