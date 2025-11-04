CREATE PROCEDURE [dbo].[GetArtistClips]
	@Id int,
    @PageNumber int = 1,
    @PageSize int = 10
AS
	SET NOCOUNT ON;
	BEGIN TRY
		IF @PageNumber <= 0
			RAISERROR('La page sélectionée ne peut pas être inférieure à 1', 16, 1)

		IF @PageSize <= 0
			RAISERROR('Le nombre d''éléments par page ne peut pas être inférieur à 1', 16, 1)

		IF @PageSize > 50
			RAISERROR('Le nombre d''éléments par page ne peut dépassé 50', 16, 1)

		DECLARE @c int
		SELECT @c = COUNT(*)
		FROM [Clip] as c
		JOIN [Video] as v ON v.Id = c.id
		JOIN [ClipArtists] as ca ON ca.VideoId = c.Id
		WHERE ca.ArtistId = @Id

        IF @c = 0   
			RAISERROR('Aucun élément!', 16, 1)

		IF @PageNumber > CEILING(CAST(@c AS FLOAT) / @PageSize)
			RAISERROR('Page Incorrecte!', 16, 1)

        -- Return Count
        SELECT @c AS TotalCount;

		DECLARE @Offset int = (@PageNumber - 1) * @PageSize;
		SELECT v.[Id], c.[ArtistId], v.[Title], v.[ReleaseDate], v.[DurationMs], v.[Url], v.[AddedDate]
		FROM [Clip] as c
		JOIN [Video] as v ON v.Id = c.id
		WHERE c.ArtistId = @Id
		ORDER BY 
			v.[Title] ASC
		OFFSET @Offset ROWS
		FETCH NEXT @PageSize ROWS ONLY;

	END TRY
	BEGIN CATCH
		THROW;
	END CATCH
RETURN 0
