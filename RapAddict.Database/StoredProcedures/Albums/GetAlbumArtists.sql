CREATE PROCEDURE [dbo].[GetAlbumArtists]
	@Id int
AS
	-- Get Album Artist
	SELECT 
        p.[Id], p.[Pseudo], p.[AddedDate], p.[ImageUrl]
    FROM 
        [Artist] as a
    JOIN 
        [Person] as p ON p.Id = a.Id
	JOIN [ArtistAlbums] as aa ON aa.ArtistId = p.Id
    WHERE aa.AlbumId = @Id
RETURN 0
