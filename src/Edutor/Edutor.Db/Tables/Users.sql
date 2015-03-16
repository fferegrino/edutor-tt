CREATE TABLE [dbo].[Users]
(
	[UserId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Type] CHAR(1) NOT NULL, 
    [Name] VARCHAR(60) NOT NULL, 
    [Curp] CHAR(18) NOT NULL, 
    [Email] VARCHAR(50) NOT NULL, 
    [Address] VARCHAR(512) NOT NULL, 
    [Mobile] VARCHAR(10) NULL, 
    [Phone] VARCHAR(10) NULL
)

GO

CREATE UNIQUE INDEX [IX_Users_Curp] ON [dbo].[Users] ([Curp])
GO
CREATE UNIQUE INDEX [IX_Users_Email] ON [dbo].[Users] ([Email])
GO
