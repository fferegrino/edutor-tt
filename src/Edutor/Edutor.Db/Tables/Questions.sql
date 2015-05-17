CREATE TABLE [dbo].[Questions]
(
	[QuestionId] INT NOT NULL PRIMARY KEY IDENTITY,
	[SchoolUserId] INT NOT NULL,
	[GroupId] INT NOT NULL,
	[Text] VARCHAR(50) NOT NULL,
	[ExpirationDate] DATE NOT NULL,
    [CreationDate] DATETIME NOT NULL, 
	CONSTRAINT [FK_Questions_ToSchoolUsers] FOREIGN KEY ([SchoolUserId]) REFERENCES [Users]([UserId]),
	CONSTRAINT [FK_Questions_ToGroups] FOREIGN KEY ([GroupId]) REFERENCES [Groups]([GroupId])
)
