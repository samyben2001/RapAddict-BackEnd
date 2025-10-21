CREATE PROCEDURE [dbo].[GetAlbum]
	@Id int
AS
	SET NOCOUNT ON;

	SELECT a.[Id], a.[Title], a.[ReleaseDate], a.[DurationMs], a.[CoverUrl], sp.[Name] as 'StreamingPlatform', asp.AlbumStreamingPlatformId as 'StreamingPlatformId' 
	FROM [Album] as a
	LEFT JOIN AlbumStreamingPlatforms as asp ON asp.AlbumId = a.Id
	LEFT JOIN StreamingPlatform as sp ON sp.Id = asp.StreamingPlatformId
	WHERE a.Id = @Id

	SELECT t.Id, t.Title, Position, t.DurationMs, t.ClipId, t.Lyrics, t.ReleaseDate From Track as t
	JOIN AlbumTracks on t.Id = TrackId
	JOIN Album as a on a.Id = @Id 
	ORDER BY Position ASC
RETURN 0
