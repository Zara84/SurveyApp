CREATE PROCEDURE [dbo].[GetParentQuestionsFromCat]
	@catId int
AS
	SELECT * from Questions as q where (q.CategoryId = @catId and q.ParentId is NULL)
RETURN 0
