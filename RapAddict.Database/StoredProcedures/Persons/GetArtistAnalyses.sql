CREATE PROCEDURE [dbo].[GetArtistAnalyses]
	@Id int
AS
	SET NOCOUNT ON;

	SELECT v.[Id], v.[Title], v.[ReleaseDate], v.[DurationMs], v.[Url], v.[AddedDate]
	FROM [Analyse] as a
	JOIN [Video] as v ON v.Id = a.id
	JOIN [AnalyseArtists] as aa ON aa.VideoId = a.Id
	WHERE aa.ArtistId = @Id
RETURN 0
