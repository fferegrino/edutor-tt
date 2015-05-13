CREATE TABLE [dbo].[Answers]
(
	[StudentId] INT NOT NULL,
	[QuestionId] INT NOT NULL,
	[ActualAnswerId] INT NULL, 
	[Date] DATE NULL, 
    CONSTRAINT [PK_Answers] PRIMARY KEY (StudentId, [QuestionId]), 
    CONSTRAINT [FK_Answers_ToQuestions] FOREIGN KEY ([QuestionId]) REFERENCES [Questions]([QuestionId]),
    CONSTRAINT [FK_Answers_ToStudents] FOREIGN KEY ([StudentId]) REFERENCES [Students]([StudentId]),
	CONSTRAINT [FK_Answers_ToPossibleAnswers] FOREIGN KEY ([QuestionId],[ActualAnswerId]) REFERENCES [PossibleAnswers]([QuestionId],[PossibleAnswerId])
)
