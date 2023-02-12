CREATE PROCEDURE [dbo].[Question_Unanswered]
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
  FROM [dbo].[Question] q
  WHERE NOT EXISTS (SELECT
    1
  FROM [dbo].[Answer] a
  WHERE q.QuestionId = a.QuestionId)
END