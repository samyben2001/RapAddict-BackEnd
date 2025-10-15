CREATE PROCEDURE [dbo].[AddStreamingPlatformToAlbum]
	@AlbumId int,
	@StreamingPlatformId int,
	@AlbumPlatformId nvarchar(100)
AS
	SET NOCOUNT ON;
	INSERT INTO [AlbumStreamingPlatforms] ([AlbumId], [StreamingPlatformId], [AlbumStreamingPlatformId])
	VALUES (@AlbumId, @StreamingPlatformId, @AlbumPlatformId)
RETURN 0
