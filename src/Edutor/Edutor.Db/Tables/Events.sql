CREATE TABLE [dbo].[Events]
(
	[EventId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [SchoolUserId] INT NOT NULL, 
	[GroupId] INT NOT NULL DEFAULT 0,
    [Name] VARCHAR(60) NOT NULL, 
    [Date] DATETIME NOT NULL, 
    [CreationDate] DATETIME NOT NULL, 
    [Description] VARCHAR(500) NOT NULL, 
    CONSTRAINT [FK_Events_ToSchoolUsers] FOREIGN KEY ([SchoolUserId]) REFERENCES [Users]([UserId])  ON DELETE CASCADE, 
    CONSTRAINT [FK_Events_ToGroups] FOREIGN KEY ([GroupId]) REFERENCES [Groups]([GroupId])
)
