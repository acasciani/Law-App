-- LawAppModel.TSC_Break
CREATE TABLE [TSC_Break] (
    [brak] int NOT NULL,                    -- _break
    [BreakId] bigint IDENTITY NOT NULL,     -- _breakId
    [ClearExisting] tinyint NOT NULL,       -- _clearExisting
    [FirstNight] datetime NULL,             -- _firstNight
    [LastNight] datetime NULL,              -- _lastNight
    [ParentBFirst] tinyint NOT NULL,        -- _parentBFirst
    [ParentBFull] tinyint NOT NULL,         -- _parentBFull
    [ParentBSecond] tinyint NOT NULL,       -- _parentBSecond
    [ShowBreak] tinyint NOT NULL,           -- _showBreak
    [CalendarId] bigint NULL,               -- _tSC_Calendar
    CONSTRAINT [pk_TSC_Break] PRIMARY KEY ([BreakId])
)

go

-- LawAppModel.TSC_Calendar
CREATE TABLE [TSC_Calendar] (
    [CalendarId] bigint IDENTITY NOT NULL,  -- _calendarId
    [CaseName] varchar(255) NULL,           -- _caseName
    [CaseNumber] varchar(255) NULL,         -- _caseNumber
    [CreateDate] datetime NOT NULL,         -- _createDate
    [DisplayHolidays] tinyint NOT NULL,     -- _displayHolidays
    [Exhibit] varchar(255) NULL,            -- _exhibit
    [LastSaved] datetime NOT NULL,          -- _lastSaved
    [WebUserId] int NULL,                   -- _signedWebUser
    [WeekendsActive] tinyint NOT NULL,      -- _weekendsActive
    [WeekendsStart] datetime NOT NULL,      -- _weekendsStart
    [yr] smallint NOT NULL,                 -- _year
    CONSTRAINT [pk_TSC_Calendar] PRIMARY KEY ([CalendarId])
)

go

-- LawAppModel.TSC_IndividualOvernight
CREATE TABLE [TSC_IndividualOvernight] (
    [DayOfWeek] int NOT NULL,               -- _dayOfWeek
    [EveryActive] tinyint NOT NULL,         -- _everyActive
    [EveryOtherActive] tinyint NOT NULL,    -- _everyOtherActive
    [IndividualOvernightId] bigint IDENTITY NOT NULL, -- _individualOvernightId
    [StartDate] datetime NULL,              -- _startDate
    [CalendarId] bigint NULL,               -- _tSC_Calendar
    CONSTRAINT [pk_TSC_IndividualOvernight] PRIMARY KEY ([IndividualOvernightId])
)

go

-- LawAppModel.TSC_UniqueDays
CREATE TABLE [TSC_UniqueDays] (
    [dte] datetime NOT NULL,                -- _date
    [dy] smallint NOT NULL,                 -- _day
    [DayClass] varchar(255) NULL,           -- _dayClass
    [CalendarId] bigint NULL,               -- _tSC_Calendar
    [UniqueDayId] bigint IDENTITY NOT NULL, -- _uniqueDayId
    CONSTRAINT [pk_TSC_UniqueDays] PRIMARY KEY ([UniqueDayId])
)

go

ALTER TABLE [TSC_Break] ADD CONSTRAINT [ref_TSC_Break_TSC_Calendar] FOREIGN KEY ([CalendarId]) REFERENCES [TSC_Calendar]([CalendarId])

go

ALTER TABLE [TSC_Calendar] ADD CONSTRAINT [ref_TSC_Calendar_SignedWebUser] FOREIGN KEY ([WebUserId]) REFERENCES [SignedWebUser]([WebUserId])

go

ALTER TABLE [TSC_IndividualOvernight] ADD CONSTRAINT [ref_TSC_IndvdlOvrnght_6D00C9FC] FOREIGN KEY ([CalendarId]) REFERENCES [TSC_Calendar]([CalendarId])

go

ALTER TABLE [TSC_UniqueDays] ADD CONSTRAINT [ref_TSC_UnqDys_TSC_Cl_8A7346DA] FOREIGN KEY ([CalendarId]) REFERENCES [TSC_Calendar]([CalendarId])

go

-- Index 'idx_TSC_Break_CalendarId' was not detected in the database. It will be created
CREATE INDEX [idx_TSC_Break_CalendarId] ON [TSC_Break]([CalendarId])

go

-- Index 'idx_TSC_Calendar_WebUserId' was not detected in the database. It will be created
CREATE INDEX [idx_TSC_Calendar_WebUserId] ON [TSC_Calendar]([WebUserId])

go

-- Index 'idx_TSC_IndvdlOvrnght_ClndarId' was not detected in the database. It will be created
CREATE INDEX [idx_TSC_IndvdlOvrnght_ClndarId] ON [TSC_IndividualOvernight]([CalendarId])

go

-- Index 'idx_TSC_UniqueDays_CalendarId' was not detected in the database. It will be created
CREATE INDEX [idx_TSC_UniqueDays_CalendarId] ON [TSC_UniqueDays]([CalendarId])

go

