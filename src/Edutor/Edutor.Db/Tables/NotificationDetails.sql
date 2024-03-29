﻿CREATE TABLE [dbo].[NotificationDetails]
(
	[StudentId] INT NOT NULL,
	[NotificationId] INT NOT NULL,
	[Seen] BIT NOT NULL, 
    CONSTRAINT [PK_NotificationDetails] PRIMARY KEY (StudentId, [NotificationId]),
    CONSTRAINT [FK_NotificationDetails_ToStudents] FOREIGN KEY ([StudentId]) REFERENCES [Students]([StudentId])  ON DELETE CASCADE,
	CONSTRAINT [FK_NotificationDetails_ToNotifications] FOREIGN KEY ([NotificationId]) REFERENCES [Notifications]([NotificationId]) ON DELETE CASCADE
)
