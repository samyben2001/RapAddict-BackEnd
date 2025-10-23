CREATE PROCEDURE [dbo].[GetArtistClips]
	@Id int
AS
	SET NOCOUNT ON;

	SELECT v.[Id], v.[Title], v.[ReleaseDate], v.[DurationMs], v.[Url], v.[AddedDate]
	FROM [Clip] as c
	JOIN [Video] as v ON v.Id = c.id
	JOIN [ClipArtists] as ca ON ca.VideoId = c.Id
	WHERE ca.ArtistId = @Id
RETURN 0
