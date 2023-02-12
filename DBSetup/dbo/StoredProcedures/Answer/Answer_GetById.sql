CREATE PROCEDURE [dbo].[Answer_GetById] @AnswerId int
AS
BEGIN
  SET NOCOUNT ON

  SELECT
    AnswerId,
    Content,
    UserName,
    Created
  FROM [dbo].[Answer]
  WHERE AnswerId = @AnswerId
END