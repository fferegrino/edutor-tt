CREATE TABLE [dbo].[Students]
(
	[StudentId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [TutorId] INT NOT NULL, 
	[TutorRelationship] CHAR(3) NOT NULL, 
	[IsActive] BIT NOT NULL DEFAULT 0,
    [Address] VARCHAR(512) NOT NULL, 
    [Phone] VARCHAR(10) NULL,
    [Name] VARCHAR(60) NOT NULL,
    [Curp] CHAR(18) NOT NULL, 
    [Token] CHAR(10) NOT NULL, 
    --[Email] VARCHAR(50) NOT NULL, 
    CONSTRAINT [FK_Students_ToTutors] FOREIGN KEY (TutorId) REFERENCES [Users]([UserId])
)
