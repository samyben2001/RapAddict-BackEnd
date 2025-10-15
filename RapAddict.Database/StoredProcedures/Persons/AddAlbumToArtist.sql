CREATE PROCEDURE [dbo].[AddAlbumToArtist]
	@ArtistId int,
	@AlbumId int
AS
	SET NOCOUNT ON;
	INSERT INTO [ArtistAlbums] ([ArtistId], [AlbumId])
	VALUES (@ArtistId, @AlbumId)
RETURN 0
