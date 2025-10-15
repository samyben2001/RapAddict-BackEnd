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

    DECLARE @Offset int = (@PageNumber - 1) * @PageSize;

    SELECT 
        [Id], 
        [Title], 
        [ReleaseDate], 
        [DurationMs]
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
END
RETURN 0
