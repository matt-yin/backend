CREATE PROCEDURE [dbo].[Question_Get]
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
END