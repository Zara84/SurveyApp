CREATE PROCEDURE [dbo].[GetQuestionsFromCat]
	@catId int = 0
AS
	SELECT * from Questions where Questions.CategoryId = @catId

RETURN 0
