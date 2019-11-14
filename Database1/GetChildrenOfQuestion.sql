CREATE PROCEDURE [dbo].[GetChildrenOfQuestion]
	@qID int
AS
	SELECT * from Questions as q where q.ParentId = @qID

RETURN 0
