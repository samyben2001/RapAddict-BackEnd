CREATE PROCEDURE [dbo].[GetJournalists]
	@Pseudo nvarchar(100) = NULL,
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


        -- Get Filtered Artist Count
        DECLARE @c int
        SELECT 
            @c = COUNT(*)
        FROM 
            [Journalist] as j
        JOIN 
            [Person] as p ON p.Id = j.Id
        WHERE 
            (@Pseudo IS NULL OR p.[Pseudo] LIKE '%' + @Pseudo + '%')

        IF @c = 0   
			RAISERROR('Aucun élément!', 16, 1)

		IF @PageNumber > CEILING(CAST(@c AS FLOAT) / @PageSize)
			RAISERROR('Page Incorrecte!', 16, 1)

        -- Return Count
        SELECT @c AS TotalCount;

        DECLARE @Offset int = (@PageNumber - 1) * @PageSize;
        -- Get Filtered Artist
        SELECT 
            p.[Id], p.[Pseudo], [p].AddedDate, p.[ImageUrl]
        FROM 
            [Journalist] as j
        JOIN 
            [Person] as p ON p.Id = j.Id
        WHERE 
            (@Pseudo IS NULL OR p.[Pseudo] LIKE '%' + @Pseudo + '%')
        ORDER BY 
            p.[Pseudo] DESC
        OFFSET @Offset ROWS
        FETCH NEXT @PageSize ROWS ONLY;
    END TRY
	BEGIN CATCH
		THROW;
	END CATCH
END
RETURN 0
