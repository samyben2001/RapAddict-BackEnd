CREATE PROCEDURE [dbo].[GetClips]
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

		IF @PageSize <= 0
			RAISERROR('Le nombre d''éléments par page ne peut pas être inférieur à 1', 16, 1)

		IF @PageSize > 50
			RAISERROR('Le nombre d''éléments par page ne peut dépassé 50', 16, 1)

        -- Get Filtered Album Count
		DECLARE @c int
        SELECT 
            @c = COUNT(*)
        FROM 
            [Video] as v
        JOIN [Clip] as c ON c.Id = v.Id
        WHERE 
            (@Title IS NULL OR v.[Title] LIKE '%' + @Title + '%') AND
            (@Year IS NULL OR YEAR(v.[ReleaseDate]) = @Year) AND
            (@Month IS NULL OR MONTH(v.[ReleaseDate]) = @Month) AND
            (@Day IS NULL OR DAY(v.[ReleaseDate]) = @Day)

        IF @c = 0   
			RAISERROR('Aucun élément!', 16, 1)

		IF @PageNumber > CEILING(CAST(@c AS FLOAT) / @PageSize)
			RAISERROR('Page Incorrecte!', 16, 1)

        -- Return Count
        SELECT @c AS TotalCount;


        DECLARE @Offset int = (@PageNumber - 1) * @PageSize;
        -- Get Filtered Album
        SELECT 
            v.[Id], 
            v.[Title], 
            v.[ReleaseDate], 
            v.[DurationMs],
            v.[Url],
            v.[AddedDate],
            p.[Id] 'AId',
            p.[Pseudo] 'APseudo',
            p.[AddedDate] 'AAddedDate',
            p.[ImageUrl] 'AImageUrl'
        FROM 
            [Video] as v
        JOIN [Clip] as c ON c.Id = v.Id
        JOIN [Person] as p ON p.Id = c.ArtistId
        WHERE 
            (@Title IS NULL OR v.[Title] LIKE '%' + @Title + '%') AND
            (@Year IS NULL OR YEAR(v.[ReleaseDate]) = @Year) AND
            (@Month IS NULL OR MONTH(v.[ReleaseDate]) = @Month) AND
            (@Day IS NULL OR DAY(v.[ReleaseDate]) = @Day)
        ORDER BY 
            v.[AddedDate] DESC
        OFFSET @Offset ROWS
        FETCH NEXT @PageSize ROWS ONLY;

	END TRY
	BEGIN CATCH
		THROW;
	END CATCH
END
RETURN 0

