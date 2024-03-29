﻿CREATE TABLE [dbo].[Invitations]
(
	[StudentId] INT NOT NULL,
	[EventId] INT NOT NULL, 
    [Rsvp] BIT NULL, 
    CONSTRAINT [PK_Invitations] PRIMARY KEY (StudentId, [EventId]), 
    CONSTRAINT [FK_Invitations_ToEvents] FOREIGN KEY ([EventId]) REFERENCES [Events]([EventId]) ON DELETE CASCADE,
    CONSTRAINT [FK_Invitations_ToStudents] FOREIGN KEY ([StudentId]) REFERENCES [Students]([StudentId])  ON DELETE CASCADE
)
