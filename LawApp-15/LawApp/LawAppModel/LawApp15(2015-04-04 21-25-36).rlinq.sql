-- LawAppModel.Permission
CREATE TABLE [Permission] (
    [PermissionId] int IDENTITY NOT NULL,   -- _permissionId
    [PermissionName] varchar(255) NULL,     -- _permissionName
    [RequiresLogin] int NOT NULL,           -- _requiresLogin
    CONSTRAINT [pk_Permission] PRIMARY KEY ([PermissionId])
)

go

-- LawAppModel.Person
CREATE TABLE [Person] (
    [FName] varchar(255) NULL,              -- _fName
    [LName] varchar(255) NULL,              -- _lName
    [PersonId] int IDENTITY NOT NULL,       -- _personId
    CONSTRAINT [pk_Person] PRIMARY KEY ([PersonId])
)

go

