﻿CREATE TABLE [dbo].[Groups]
(
	[GroupId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] VARCHAR(20) NOT NULL,
	[Subject] VARCHAR(35) NOT NULL,
	[FromDate] DATE NOT NULL,
	[ToDate] DATE  NULL
)
