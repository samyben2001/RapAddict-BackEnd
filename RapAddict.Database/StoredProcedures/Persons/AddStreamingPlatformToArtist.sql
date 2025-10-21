CREATE PROCEDURE [dbo].[AddStreamingPlatformToArtist]
	@ArtistId int,
	@StreamingPlatformId int,
	@ArtistPlatformId nvarchar(100)
AS
	SET NOCOUNT ON;
	INSERT INTO [ArtistStreamingPlatforms] ([ArtistId], [StreamingPlatformId], [ArtistStreamingPlatformId])
	VALUES (@ArtistId, @StreamingPlatformId, @ArtistPlatformId)
RETURN 0
