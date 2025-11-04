CREATE PROCEDURE [dbo].[GetAnalyse]
	@Id int
AS
	SET NOCOUNT ON;

	-- Get Analyse
	SELECT 
		a.[Id], v.[Title], v.[ReleaseDate], v.[DurationMs], v.[Url], v.[AddedDate], p.[Id] 'CCId', p.[Pseudo] 'CCPseudo', p.[AddedDate] 'CCAddedDate', p.[ImageUrl] 'CCImageUrl'
	FROM [Analyse] as a
	JOIN [Video] as v ON v.Id = a.Id
	JOIN [Person] as p ON p.Id = a.ContentCreatorId
	WHERE a.Id = @Id

	-- Get Analysed Artists
	SELECT 
		p.[Id], p.[Pseudo], p.[AddedDate], p.[ImageUrl]
	FROM [Analyse] as a
	JOIN [AnalyseArtists] as aa ON aa.VideoId = a.Id
	JOIN [Person] as p ON p.Id = aa.ArtistId
	WHERE a.Id = @Id
RETURN 0
