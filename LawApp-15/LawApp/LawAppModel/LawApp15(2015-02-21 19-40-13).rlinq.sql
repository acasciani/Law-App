-- LawAppModel.Holiday
CREATE TABLE [Holiday] (
    [dte] datetime NOT NULL,                -- _date
    [Description] varchar(255) NULL,        -- _description
    [HolidayId] int NOT NULL,               -- _holidayId
    [nme] varchar(255) NULL,                -- _name
    CONSTRAINT [pk_Holiday] PRIMARY KEY ([HolidayId])
)

go

