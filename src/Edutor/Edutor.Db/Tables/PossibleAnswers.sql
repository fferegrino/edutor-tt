CREATE TABLE [dbo].[PossibleAnswers]
(
	[QuestionId] INT NOT NULL,
	[AnswerId] INT NOT NULL, 
	[Text] VARCHAR(100) NOT NULL, 
    CONSTRAINT [PK_PossibleAnswers] PRIMARY KEY ([QuestionId], [AnswerId]), 
    CONSTRAINT [FK_PossibleAnswers_ToQuestions] FOREIGN KEY ([QuestionId]) REFERENCES [Questions]([QuestionId])
)
