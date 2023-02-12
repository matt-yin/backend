CREATE PROCEDURE [dbo].[Answer_Put] @AnswerId int,
@Content nvarchar(max)
AS
BEGIN
  SET NOCOUNT ON

  UPDATE [dbo].[Answer]
  SET Content = @Content
  WHERE AnswerId = @AnswerId
END