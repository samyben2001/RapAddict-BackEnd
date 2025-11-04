CREATE PROCEDURE [dbo].[GetFreestyle]
	@Id int
AS
	SET NOCOUNT ON;

	-- Get Freestyle
	SELECT 
		f.[Id], v.[Title], v.[ReleaseDate], v.[DurationMs], v.[Url], v.[AddedDate]
	FROM [Freestyle] as f
	JOIN [Video] as v ON v.Id = f.Id
	WHERE f.Id = @Id

	-- Get Freestyler Artists
	SELECT 
		p.[Id], p.[Pseudo], p.[AddedDate], p.[ImageUrl]
	FROM [Freestyle] as f
	JOIN [FreestyleArtists] as fa ON fa.VideoId = f.Id
	JOIN [Person] as p ON p.Id = fa.ArtistId
	WHERE f.Id = @Id
RETURN 0
