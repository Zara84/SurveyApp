CREATE TABLE [dbo].[Questions]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [QuestionText] VARCHAR(MAX) NOT NULL, 
    [AnswerTypeId] INT NOT NULL FOREIGN KEY ([AnswerTypeId]) REFERENCES [AnswerTypes](Id), 
    [ParentId] INT NULL FOREIGN KEY([ParentId]) REFERENCES Questions(Id), 
    [CategoryId] INT NOT NULL Foreign key ([CategoryId]) references Categories(Id), 
    [SubcategoryId] INT NOT NULL foreign key (SubcategoryID) references Subcategories(Id)
)
