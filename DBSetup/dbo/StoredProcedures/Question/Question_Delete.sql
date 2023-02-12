CREATE PROCEDURE [dbo].[Question_Delete] @QuestionId int
AS
BEGIN
  SET NOCOUNT ON

  DELETE FROM [dbo].[Question]
  WHERE QuestionId = @QuestionId
END