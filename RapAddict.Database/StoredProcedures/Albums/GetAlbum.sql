CREATE PROCEDURE [dbo].[GetAlbum]
	@Id int
AS
	SET NOCOUNT ON;

	-- Get Album
	SELECT a.[Id], a.[Title], a.[ReleaseDate], a.[DurationMs], a.[CoverUrl]
	FROM [Album] as a
	WHERE a.Id = @Id

	-- Get Album Tracks
	SELECT t.Id, t.Title, [at].Position, t.DurationMs, t.ClipId, t.Lyrics, t.ReleaseDate, [at].AlbumId 
	FROM Track as t
	JOIN AlbumTracks as [at] on [at].TrackId = t.Id AND [at].AlbumId = @Id
	ORDER BY Position ASC

	-- Get Album StreamingPlatforms
	SELECT sp.[Name], asp.AlbumStreamingPlatformId as 'AlbumPlatformId' FROM [StreamingPlatform] as sp
	JOIN [AlbumStreamingPlatforms] as asp ON asp.StreamingPlatformId = sp.Id AND asp.AlbumId = @Id
RETURN 0
