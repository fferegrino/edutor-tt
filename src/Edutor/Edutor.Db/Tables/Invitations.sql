CREATE TABLE [dbo].[Invitations]
(
	[StudentId] INT NOT NULL,
	[EventId] INT NOT NULL, 
    CONSTRAINT [PK_Invitations] PRIMARY KEY (StudentId, [EventId]), 
    CONSTRAINT [FK_Invitations_ToEvents] FOREIGN KEY ([EventId]) REFERENCES [Events]([EventId]),
    CONSTRAINT [FK_Invitations_ToStudents] FOREIGN KEY ([StudentId]) REFERENCES [Students]([StudentId])
)
