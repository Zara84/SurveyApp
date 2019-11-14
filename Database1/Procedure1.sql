CREATE PROCEDURE [dbo].GetCatAndSubcat
	
AS
	SELECT Categories.Name, Subcategories.Name 
	from Categories Inner Join Subcategories on Categories.Id = Subcategories.ParentId
GO
