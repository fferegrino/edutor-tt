﻿CREATE TABLE [dbo].[Notifications]
(
	[NotificationId] INT NOT NULL PRIMARY KEY IDENTITY,
	[SchoolUserId] INT NOT NULL,
	[Text] VARCHAR(200) NOT NULL,
	CONSTRAINT [FK_Notifications_SchoolUsers] FOREIGN KEY ([SchoolUserId]) REFERENCES [SchoolUsers]([SchoolUserId])
)