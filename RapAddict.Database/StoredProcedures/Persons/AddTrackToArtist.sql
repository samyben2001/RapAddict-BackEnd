CREATE PROCEDURE [dbo].[AddTrackToArtist]
	@ArtistId int,
	@TrackId int
AS
	SET NOCOUNT ON;
	INSERT INTO [ArtistTracks] ([ArtistId], [TrackId])
	VALUES (@ArtistId, @TrackId)
RETURN 0
