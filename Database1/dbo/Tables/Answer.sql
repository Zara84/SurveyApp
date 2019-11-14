CREATE TABLE [dbo].[Answers]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [QuestionId] INT NOT NULL Foreign key ([QuestionId]) references Questions(Id), 
    [RespondentId] INT NOT NULL, 
    [AnswerValueId] INT NOT NULL foreign key ([AnswerValueId]) references [AnswerValues](Id)
)
