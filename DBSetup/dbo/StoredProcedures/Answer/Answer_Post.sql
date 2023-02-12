CREATE PROCEDURE [dbo].[Answer_Post] @QuestionId int,
@Content nvarchar(max),
@UserId nvarchar(150),
@UserName nvarchar(150),
@Created datetime2
AS
BEGIN
  SET NOCOUNT ON

  INSERT INTO [dbo].[Answer] (Content, UserId, UserName, Created, QuestionId)
    VALUES (@Content, @UserId, @UserName, @Created, @QuestionId)
END