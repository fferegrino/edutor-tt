CREATE TABLE [dbo].[NotificationDetails]
(
	[StudentId] INT NOT NULL,
	[NotificationId] INT NOT NULL,
	[Seen] BIT, 
    CONSTRAINT [PK_NotificationDetails] PRIMARY KEY (StudentId, [NotificationId]),
    CONSTRAINT [FK_NotificationDetails_ToStudents] FOREIGN KEY ([StudentId]) REFERENCES [Students]([StudentId]),
	CONSTRAINT [FK_NotificationDetails_ToNotifications] FOREIGN KEY ([NotificationId]) REFERENCES [Notifications]([NotificationId])
)
