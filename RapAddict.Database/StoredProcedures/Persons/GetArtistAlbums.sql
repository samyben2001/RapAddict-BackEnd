CREATE PROCEDURE [dbo].[GetArtistAlbums]
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

		-- Get ArtistAlbums Count
		DECLARE @c int
		SELECT @c = count(*)
		FROM [Album] as a
		JOIN [ArtistAlbums] as aa ON aa.AlbumId = a.Id
		WHERE aa.ArtistId = @Id

        IF @c = 0   
			RAISERROR('Aucun élément!', 16, 1)

		IF @PageNumber > CEILING(CAST(@c AS FLOAT) / @PageSize)
			RAISERROR('Page Incorrecte!', 16, 1)

        -- Return Count
        SELECT @c AS TotalCount;

		DECLARE @Offset int = (@PageNumber - 1) * @PageSize;
		-- Get ArtistAlbums
		SELECT a.[Id], a.[Title], a.[ReleaseDate], a.[DurationMs], a.[CoverUrl] 
		FROM [Album] as a
		JOIN [ArtistAlbums] as aa ON aa.AlbumId = a.Id
		WHERE aa.ArtistId = @Id
		ORDER BY 
			a.[Title] ASC
		OFFSET @Offset ROWS
		FETCH NEXT @PageSize ROWS ONLY;

	END TRY
	BEGIN CATCH
		THROW;
	END CATCH

RETURN 0
