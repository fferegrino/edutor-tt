CREATE TABLE [dbo].[Enrollments]
(
	[GroupId] INT NOT NULL , 
    [StudentId] INT NOT NULL, 
    CONSTRAINT [PK_Enrollments] PRIMARY KEY (StudentId, GroupId), 
    CONSTRAINT [FK_Enrollments_ToStudents] FOREIGN KEY ([StudentId]) REFERENCES [Students]([StudentId])  ON DELETE CASCADE,
	CONSTRAINT [FK_Enrollments_ToGroups] FOREIGN KEY ([GroupId]) REFERENCES [Groups]([GroupId]) ON DELETE CASCADE
)
