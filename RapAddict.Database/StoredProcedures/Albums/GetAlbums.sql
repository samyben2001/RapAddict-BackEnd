CREATE PROCEDURE [dbo].[GetAlbums]
	@Title nvarchar(100) = NULL,
	@Year int = NULL,
	@Month int = NULL,
	@Day int = NULL,
    @PageNumber int = 1,
    @PageSize int = 10
AS
BEGIN
    SET NOCOUNT ON;
	BEGIN TRY
		IF @PageNumber <= 0
			RAISERROR('La page sélectionée ne peut pas être inférieure à 1', 16, 1)

		IF @PageNumber <= 0
			RAISERROR('Le nombre d''éléments par page ne peut pas être inférieur à 1', 16, 1)

		IF @PageSize > 50
			RAISERROR('Le nombre d''éléments par page ne peut dépassé 50', 16, 1)

        -- Get Filtered Album Count
		DECLARE @c int
        SELECT 
            @c = COUNT(*)
        FROM 
            [Album]
        WHERE 
            (@Title IS NULL OR [Title] LIKE '%' + @Title + '%') AND
            (@Year IS NULL OR YEAR([ReleaseDate]) = @Year) AND
            (@Month IS NULL OR MONTH([ReleaseDate]) = @Month) AND
            (@Day IS NULL OR DAY([ReleaseDate]) = @Day)

		IF @PageNumber > CEILING(CAST(@c AS FLOAT) / @PageSize)
			RAISERROR('Page Incorrecte! Aucun élément!', 16, 1)

        -- Return Count
        SELECT @c AS TotalCount;


        DECLARE @Offset int = (@PageNumber - 1) * @PageSize;
        -- Get Filtered Album
        SELECT 
            [Id], 
            [Title], 
            [ReleaseDate], 
            [DurationMs],
            [CoverUrl]
        FROM 
            [Album]
        WHERE 
            (@Title IS NULL OR [Title] LIKE '%' + @Title + '%') AND
            (@Year IS NULL OR YEAR([ReleaseDate]) = @Year) AND
            (@Month IS NULL OR MONTH([ReleaseDate]) = @Month) AND
            (@Day IS NULL OR DAY([ReleaseDate]) = @Day)
        ORDER BY 
            [Title] DESC
        OFFSET @Offset ROWS
        FETCH NEXT @PageSize ROWS ONLY;

	END TRY
	BEGIN CATCH
		THROW;
	END CATCH
END
RETURN 0
