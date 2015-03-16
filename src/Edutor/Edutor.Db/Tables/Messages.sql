CREATE TABLE [dbo].[Messages]
(
	[MessageId] INT NOT NULL PRIMARY KEY IDENTITY,
	[ConversationId] INT NOT NULL,
	[FromId] INT NOT NULL,
	[ToId] INT NOT NULL,
	[SentDate] DATETIME NOT NULL,
	[SeenDate] DATETIME,
	[Text] VARCHAR(400) NOT NULL,
	CONSTRAINT [FK_Messages_ToConversations] FOREIGN KEY (ConversationId) REFERENCES [Conversations]([ConversationId]),
    CONSTRAINT [FK_Messages_ToUsersFrom] FOREIGN KEY (FromId) REFERENCES [Users]([UserId]),
    CONSTRAINT [FK_Messages_ToUsersTo] FOREIGN KEY (ToId) REFERENCES [Users]([UserId])
)
