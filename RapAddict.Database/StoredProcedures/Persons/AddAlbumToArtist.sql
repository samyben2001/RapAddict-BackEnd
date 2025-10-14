CREATE PROCEDURE [dbo].[AddAlbumToArtist]
	@ArtistId int,
	@AlbumId int
AS
	INSERT INTO [ArtistAlbums] ([ArtistId], [AlbumId])
	VALUES (@ArtistId, @AlbumId)
RETURN 0
