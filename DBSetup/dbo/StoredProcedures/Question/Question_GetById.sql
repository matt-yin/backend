CREATE PROCEDURE [dbo].[Question_GetById] @QuestionId int
AS
BEGIN
  SET NOCOUNT ON

  SELECT
    QuestionId,
    Title,
    Content,
    UserId,
    UserName,
    Created
  FROM [dbo].[Question]
  WHERE QuestionId = @QuestionId
END