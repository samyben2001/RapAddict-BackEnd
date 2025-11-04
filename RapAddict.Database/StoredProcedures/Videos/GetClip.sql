CREATE PROCEDURE [dbo].[GetClip]
	@Id int
AS
	SET NOCOUNT ON;

	-- Get Clip
	SELECT 
		c.[Id], v.[Title], v.[ReleaseDate], v.[DurationMs], v.[Url], v.[AddedDate], p.[Id] 'AId', p.[Pseudo] 'APseudo', p.[AddedDate] 'AAddedDate', p.[ImageUrl] 'AImageUrl'
	FROM [Clip] as c
	JOIN [Video] as v ON v.Id = c.Id
	JOIN [Person] as p ON p.Id = c.ArtistId
	WHERE c.Id = @Id

	-- Get Clipped Artists
	SELECT 
		p.[Id], p.[Pseudo], p.[AddedDate], p.[ImageUrl]
	FROM [Clip] as c
	JOIN [ClipArtists] as ca ON ca.VideoId = c.Id
	JOIN [Person] as p ON p.Id = ca.ArtistId
	WHERE c.Id = @Id
RETURN 0
