CREATE PROCEDURE [dbo].[AddStreamingPlatformToTrack]
	@TrackId int,
	@StreamingPlatformId int,
	@TrackPlatformId nvarchar(100)
AS
	SET NOCOUNT ON;
	INSERT INTO [TrackStreamingPlatforms] ([TrackId], [StreamingPlatformId], [TrackStreamingPlatformId])
	VALUES (@TrackId, @StreamingPlatformId, @TrackPlatformId)
RETURN 0
