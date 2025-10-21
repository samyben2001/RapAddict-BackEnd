CREATE PROCEDURE [dbo].[GetAlbum]
	@Id int
AS
	SET NOCOUNT ON;

	-- Get Album
	SELECT a.[Id], a.[Title], a.[ReleaseDate], a.[DurationMs], a.[CoverUrl]
	FROM [Album] as a
	WHERE a.Id = @Id

	-- Get Album Tracks
	SELECT t.Id, t.Title, Position, t.DurationMs, t.ClipId, t.Lyrics, t.ReleaseDate From Track as t
	LEFT JOIN AlbumTracks as [at] on [at].AlbumId = @Id
	ORDER BY Position ASC

	-- Get Album StreamingPlatform
	SELECT sp.[Name], asp.AlbumStreamingPlatformId as 'AlbumId' FROM [StreamingPlatform] as sp
	LEFT JOIN [AlbumStreamingPlatforms] as asp ON asp.AlbumId = @Id
RETURN 0
