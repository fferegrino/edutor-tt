CREATE TABLE [dbo].[Events]
(
	[EventId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [SchoolUserId] INT NOT NULL, 
	[GroupId] INT NOT NULL, 
    [Name] VARCHAR(30) NOT NULL, 
    [Date] DATETIME NOT NULL, 
    [CreationDate] DATETIME NOT NULL, 
    [Description] VARCHAR(255) NOT NULL, 
    CONSTRAINT [FK_Events_ToSchoolUsers] FOREIGN KEY ([SchoolUserId]) REFERENCES [Users]([UserId])
)
