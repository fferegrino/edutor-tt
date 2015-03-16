CREATE TABLE [dbo].[SchoolUsers]
(
	[SchoolUserId] INT NOT NULL PRIMARY KEY,
	[Position] CHAR(1) NOT NULL,
    CONSTRAINT [FK_SchoolUsers_ToUsers] FOREIGN KEY ([SchoolUserId]) REFERENCES [Users](UserId)
)
