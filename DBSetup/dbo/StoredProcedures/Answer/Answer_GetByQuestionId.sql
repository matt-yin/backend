CREATE PROCEDURE [dbo].[Answer_GetByQuestionId] @QuestionId int
AS
BEGIN
  SET NOCOUNT ON

  SELECT
    AnswerId,
    QuestionId,
    Content,
    UserName,
    Created
  FROM [dbo].[Answer]
  WHERE QuestionId = @QuestionId
END