-- LawAppModel.Application
CREATE TABLE [Application] (
    [ApplicationId] int IDENTITY NOT NULL,  -- _applicationId
    [ApplicationName] varchar(255) NULL,    -- _applicationName
    [Description] varchar(255) NULL,        -- _description
    CONSTRAINT [pk_Application] PRIMARY KEY ([ApplicationId])
)

go

-- LawAppModel.SignedWebUser
CREATE TABLE [SignedWebUser] (
    [CreationDate] datetime NOT NULL,       -- _creationDate
    [Email] varchar(255) NULL,              -- _email
    [ModificationDate] datetime NULL,       -- _modificationDate
    [UserPassword] varchar(255) NULL,       -- _userPassword
    [WebUserId] int IDENTITY NOT NULL,      -- _webUserId
    CONSTRAINT [pk_SignedWebUser] PRIMARY KEY ([WebUserId])
)

go

-- LawAppModel.UserRole
CREATE TABLE [UserRole] (
    [ApplicationId] int NOT NULL,           -- _application1
    [RoleName] varchar(255) NULL,           -- _roleName
    [UserRoleId] int IDENTITY NOT NULL,     -- _userRoleId
    CONSTRAINT [pk_UserRole] PRIMARY KEY ([UserRoleId])
)

go

-- System.Collections.Generic.IList`1 LawAppModel.UserRole._signedWebUsers
CREATE TABLE [UserRole_SignedWebUser] (
    [UserRoleId] int NOT NULL,
    [WebUserId] int NOT NULL,
    CONSTRAINT [pk_UserRole_SignedWebUser] PRIMARY KEY ([UserRoleId], [WebUserId])
)

go

ALTER TABLE [UserRole] ADD CONSTRAINT [ref_UserRole_Application] FOREIGN KEY ([ApplicationId]) REFERENCES [Application]([ApplicationId])

go

ALTER TABLE [UserRole_SignedWebUser] ADD CONSTRAINT [ref_UsrRl_SgndWbUsr_U_B251E08F] FOREIGN KEY ([UserRoleId]) REFERENCES [UserRole]([UserRoleId])

go

ALTER TABLE [UserRole_SignedWebUser] ADD CONSTRAINT [ref_UsrRl_SgndWbUsr_S_E91BD99F] FOREIGN KEY ([WebUserId]) REFERENCES [SignedWebUser]([WebUserId])

go

-- Index 'idx_UserRole_ApplicationId' was not detected in the database. It will be created
CREATE INDEX [idx_UserRole_ApplicationId] ON [UserRole]([ApplicationId])

go

-- Index 'idx_UsrRl_SgndWbUser_WebUserId' was not detected in the database. It will be created
CREATE INDEX [idx_UsrRl_SgndWbUser_WebUserId] ON [UserRole_SignedWebUser]([WebUserId])

go

