﻿CREATE TABLE [dbo].[Notifications]
(
	[NotificationId] INT NOT NULL PRIMARY KEY IDENTITY,
	[SchoolUserId] INT NOT NULL,
	[GroupId] INT NOT NULL,
	[Text] VARCHAR(300) NOT NULL,
    [CreationDate] DATETIME NOT NULL, 
	CONSTRAINT [FK_Notifications_ToSchoolUsers] FOREIGN KEY ([SchoolUserId]) REFERENCES [Users]([UserId]),
	CONSTRAINT [FK_Notifications_ToGroups] FOREIGN KEY ([GroupId]) REFERENCES [Groups]([GroupId])
)
