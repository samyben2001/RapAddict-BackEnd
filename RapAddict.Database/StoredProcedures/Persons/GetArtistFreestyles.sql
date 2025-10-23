CREATE PROCEDURE [dbo].[GetArtistFreestyles]
	@Id int
AS
	SET NOCOUNT ON;

	SELECT v.[Id], v.[Title], v.[ReleaseDate], v.[DurationMs], v.[Url], v.[AddedDate]
	FROM [Freestyle] as f
	JOIN [Video] as v ON v.Id = f.id
	JOIN [FreestyleArtists] as fa ON fa.VideoId = f.Id
	WHERE fa.ArtistId = @Id
RETURN 0
