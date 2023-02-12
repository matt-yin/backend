CREATE PROCEDURE [dbo].[Question_Search] @Search nvarchar(100)
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
  WHERE Title LIKE '%' + @Search + '%'

  UNION

  SELECT
    QuestionId,
    Title,
    Content,
    UserId,
    UserName,
    Created
  FROM [dbo].[Question]
  WHERE Content LIKE '%' + @Search + '%'

END