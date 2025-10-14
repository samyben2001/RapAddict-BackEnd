CREATE PROCEDURE [dbo].[CreateJournalist]
	@Id int
AS
	INSERT INTO [Journalist] ([Id])
	VALUES (@Id)
RETURN 0
