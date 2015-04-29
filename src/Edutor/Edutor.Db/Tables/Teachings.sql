CREATE TABLE [dbo].[Teachings]
(
	[GroupId] INT NOT NULL , 
    [SchoolUserId] INT NOT NULL, 
    CONSTRAINT [PK_Teachings] PRIMARY KEY ([SchoolUserId], [GroupId]), 
    CONSTRAINT [FK_Teachings_ToSchoolUsers] FOREIGN KEY ([SchoolUserId]) REFERENCES [Users]([UserId]),
	CONSTRAINT [FK_Teachings_ToGroups] FOREIGN KEY ([GroupId]) REFERENCES [Groups]([GroupId])
)
