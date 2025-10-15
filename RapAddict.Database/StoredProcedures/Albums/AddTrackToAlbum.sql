CREATE PROCEDURE [dbo].[AddTrackToAlbum]
	@AlbumId int,
	@TrackId int,
	@Position int
AS
	SET NOCOUNT ON;
	INSERT INTO [AlbumTracks] ([AlbumId], [TrackId], [Position])
	VALUES (@AlbumId, @TrackId, @Position)
RETURN 0