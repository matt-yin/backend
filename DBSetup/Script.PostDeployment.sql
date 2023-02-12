IF NOT EXISTS (SELECT 1 FROM [dbo].[Question])
BEGIN
	INSERT INTO [dbo].[Question](Title, Content, UserId, UserName, Created)
	VALUES ('Why should I learn TypeScript?', 'TypeScript seems to be getting popular so I wondered whether it is worth my time learning it? What benefits does it give over JavaScript?', '1', 'bob.test@test.com', '2021-01-18 14:32'),
	('Which state management tool should I use?', 'There seem to be a fair few state management tools around for React - React, Unstated, ... Which one should I use?', '2', 'jane.test@test.com', '2021-01-18 14:48')
END
GO

IF NOT EXISTS (SELECT 1 FROM [dbo].[Answer])
BEGIN
	INSERT INTO [dbo].[Answer](Content, UserId, UserName, Created, QuestionId)
	VALUES ('To catch problems earlier speeding up your developments', '2', 'jane.test@test.com', '2021-01-18 14:40', 1),
	('So, that you can use the JavaScript features of tomorrow, today', '3', 'fred.test@test.com', '2021-01-18 16:18', 1)
END
GO