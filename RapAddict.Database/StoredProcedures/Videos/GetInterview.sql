CREATE PROCEDURE [dbo].[GetInterview]
	@Id int
AS
	SET NOCOUNT ON;

	-- Get Interview
	SELECT 
		i.[Id], v.[Title], v.[ReleaseDate], v.[DurationMs], v.[Url], v.[AddedDate], p.[Id] 'JId', p.[Pseudo] 'JPseudo', p.[AddedDate] 'JAddedDate', p.[ImageUrl] 'JImageUrl'
	FROM [Interview] as i
	JOIN [Video] as v ON v.Id = i.Id
	JOIN [Person] as p ON p.Id = i.JournalistId
	WHERE i.Id = @Id

	-- Get Interviewed Artists
	SELECT 
		p.[Id], p.[Pseudo], p.[AddedDate], p.[ImageUrl]
	FROM [Interview] as i
	JOIN [InterviewArtists] as ia ON ia.VideoId = i.Id
	JOIN [Person] as p ON p.Id = ia.ArtistId
	WHERE i.Id = @Id
RETURN 0