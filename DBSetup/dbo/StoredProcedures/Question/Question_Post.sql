CREATE PROCEDURE [dbo].[Question_Post] @Title nvarchar(255),
@Content nvarchar(max),
@UserId nvarchar(150),
@UserName nvarchar(150),
@Created datetime2
AS
BEGIN
  SET NOCOUNT ON

  INSERT INTO [dbo].[Question] (Title, Content, UserId, UserName, Created)
    VALUES (@Title, @Content, @UserId, @UserName, @Created)

  SELECT
    SCOPE_IDENTITY() AS QuestionId
END