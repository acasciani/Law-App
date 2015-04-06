-- System.Collections.Generic.IList`1 LawAppModel.UserRole._permissions
CREATE TABLE [UserRole_Permission] (
    [UserRoleId] int NOT NULL,
    [PermissionId] int NOT NULL,
    CONSTRAINT [pk_UserRole_Permission] PRIMARY KEY ([UserRoleId], [PermissionId])
)

go

ALTER TABLE [UserRole_Permission] ADD CONSTRAINT [ref_UsrRl_Prmssn_UsrR_F7B3E2F7] FOREIGN KEY ([UserRoleId]) REFERENCES [UserRole]([UserRoleId])

go

ALTER TABLE [UserRole_Permission] ADD CONSTRAINT [ref_UsrRl_Prmssn_Prms_08993DBF] FOREIGN KEY ([PermissionId]) REFERENCES [Permission]([PermissionId])

go

