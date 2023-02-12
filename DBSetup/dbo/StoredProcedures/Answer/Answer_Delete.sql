CREATE PROCEDURE [dbo].[Answer_Delete] @answerId int
AS
BEGIN
  SET NOCOUNT ON

  DELETE FROM [dbo].[Answer]
  WHERE AnswerId = @answerId
END