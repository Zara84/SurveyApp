CREATE TABLE [dbo].[Subcategories]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] VARCHAR(50) NOT NULL, 
    [ParentId] INT NOT NULL foreign key ([ParentId]) references Categories(Id)
)
