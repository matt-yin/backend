CREATE PROCEDURE [dbo].[Question_Put] @QuestionId int,
@Title nvarchar(255),
@Content nvarchar(max)
AS
BEGIN
  SET NOCOUNT ON

  UPDATE [dbo].[Question]
  SET Title = @Title,
      Content = @Content
  WHERE QuestionId = @QuestionId
END