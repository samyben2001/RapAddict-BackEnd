CREATE PROCEDURE [dbo].[CreateArtist]
	@Id int
AS
	INSERT INTO [Artist] ([Id])
	VALUES (@Id)
RETURN 0
