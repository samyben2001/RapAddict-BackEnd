CREATE PROCEDURE [dbo].[AddArtistToClip]
	@ClipId int,
	@ArtistId int
AS
	SET NOCOUNT ON;
	INSERT INTO [ClipArtists] ([VideoId], [ArtistId])
	VALUES (@ClipId, @ArtistId)
RETURN 0
