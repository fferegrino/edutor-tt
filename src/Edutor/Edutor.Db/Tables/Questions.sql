CREATE TABLE [dbo].[Questions]
(
	[QuestionId] INT NOT NULL PRIMARY KEY IDENTITY,
	[SchoolUserId] INT NOT NULL,
	[Text] VARCHAR(50) NOT NULL,
	[ExpirationDate] DATE NOT NULL,
	CONSTRAINT [FK_Questions_ToSchoolUsers] FOREIGN KEY ([SchoolUserId]) REFERENCES [SchoolUsers]([SchoolUserId])
)
