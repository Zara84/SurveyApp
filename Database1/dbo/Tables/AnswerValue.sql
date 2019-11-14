CREATE TABLE [dbo].[AnswerValues]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Value] VARCHAR(MAX) NOT NULL, 
    [AnswerTypeId] INT NOT NULL FOREIGN KEY ([AnswerTypeId]) REFERENCES [AnswerTypes](Id)
)
