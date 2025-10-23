CREATE PROCEDURE [dbo].[GetArtistTracks]
	@Id int
AS
	SET NOCOUNT ON;
	SELECT t.[Id], t.[Title], t.[ReleaseDate], t.[DurationMs]
	FROM [Track] as t
	JOIN [ArtistTracks] as [at] ON [at].TrackId = t.Id
	WHERE [at].ArtistId = @Id
RETURN 0
