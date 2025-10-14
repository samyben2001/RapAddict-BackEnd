CREATE PROCEDURE [dbo].[CreateFreestyle]
	@Id int
AS
	INSERT INTO [Freestyle] ([Id])
	VALUES (@Id)
RETURN 0
