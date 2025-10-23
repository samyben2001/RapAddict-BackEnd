CREATE PROCEDURE [dbo].[GetArtistInterviews]
	@Id int
AS
	SET NOCOUNT ON;

	SELECT v.[Id], v.[Title], v.[ReleaseDate], v.[DurationMs], v.[Url], v.[AddedDate]
	FROM [Interview] as i
	JOIN [Video] as v ON v.Id = i.id
	JOIN [InterviewArtists] as ia ON ia.VideoId = i.Id
	WHERE ia.ArtistId = @Id
RETURN 0
