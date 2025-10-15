CREATE PROCEDURE [dbo].[AddArtistToFreestyle]
	@FreestyleId int,
	@ArtistId int
AS
	SET NOCOUNT ON;
	INSERT INTO [FreestyleArtists] ([VideoId], [ArtistId])
	VALUES (@FreestyleId, @ArtistId)
RETURN 0
