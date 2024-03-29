﻿CREATE TABLE [dbo].[Users]
(
	[UserId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Type] CHAR(1) NOT NULL, 
    [Name] VARCHAR(70) NOT NULL, 
    [Curp] CHAR(18) NOT NULL, 
    [Email] VARCHAR(60) NOT NULL, 
    [Address] VARCHAR(512) NOT NULL, 
    [Mobile] VARCHAR(10) NULL, 
    [Phone] VARCHAR(10) NULL, 
    [Job] VARCHAR(20) NULL,  
    [JobTelephone] VARCHAR(10) NULL, 
	[Position] CHAR(1) NULL, 
	[Password] CHAR(64) NULL
)

GO

CREATE UNIQUE INDEX [IX_Users_Curp] ON [dbo].[Users] ([Curp])
GO
CREATE UNIQUE INDEX [IX_Users_Email] ON [dbo].[Users] ([Email])
GO
