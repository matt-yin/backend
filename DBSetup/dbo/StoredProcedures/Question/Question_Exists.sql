CREATE PROCEDURE [dbo].[Question_Exists] @QuestionId int
AS
BEGIN
  SET NOCOUNT ON

  SELECT
    CASE
      WHEN EXISTS (SELECT
          QuestionId
        FROM [dbo].[Question]
        WHERE QuestionId = @QuestionId) THEN CAST(1 AS bit)
      ELSE CAST(0 AS bit)
    END
    AS Result
END