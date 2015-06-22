CREATE TABLE [dbo].[Conversations]
(
	[ConversationId] INT NOT NULL PRIMARY KEY IDENTITY,
	[User1Id] INT NOT NULL,
	[User2Id] INT NOT NULL, 
    CONSTRAINT [FK_Conversations_ToUsers1] FOREIGN KEY (User1Id) REFERENCES [Users]([UserId]) ON DELETE CASCADE,
	CONSTRAINT [FK_Conversations_ToUsers2] FOREIGN KEY (User2Id) REFERENCES [Users]([UserId])
)
