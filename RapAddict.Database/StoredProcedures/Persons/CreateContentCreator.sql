CREATE PROCEDURE [dbo].[CreateContentCreator]
	@Id int
AS
	INSERT INTO [ContentCreator] ([Id])
	VALUES (@Id)
RETURN 0
