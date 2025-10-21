CREATE PROCEDURE [dbo].[GetArtists]
	@Pseudo nvarchar(100) = NULL,
    @PageNumber int = 1,
    @PageSize int = 10
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @Offset int = (@PageNumber - 1) * @PageSize;

    -- Get Filtered Artist
    SELECT 
        p.[Id], p.[Pseudo], p.[ImageUrl]
    FROM 
        [Artist] as a
    JOIN 
        [Person] as p ON p.Id = a.Id
    WHERE 
        (@Pseudo IS NULL OR p.[Pseudo] LIKE '%' + @Pseudo + '%')
    ORDER BY 
        p.[Pseudo] DESC
    OFFSET @Offset ROWS
    FETCH NEXT @PageSize ROWS ONLY;

    -- Get Filtered Artist Count
    SELECT 
        COUNT(*)
    FROM 
        [Artist] as a
    JOIN 
        [Person] as p ON p.Id = a.Id
    WHERE 
        (@Pseudo IS NULL OR p.[Pseudo] LIKE '%' + @Pseudo + '%')
END
RETURN 0
