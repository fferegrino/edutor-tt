CREATE TABLE [dbo].[Tutors]
(
	[UserId] INT NOT NULL PRIMARY KEY, 
    [Job] VARCHAR(20) NULL, 
    [JobTelephone] VARCHAR(10) NULL, 
    CONSTRAINT [FK_Tutors_ToUsers] FOREIGN KEY ([UserId]) REFERENCES [Users](UserId)
)
