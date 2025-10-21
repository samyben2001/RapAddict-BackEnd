CREATE PROCEDURE [dbo].[GetAlbumTracks]
	@AlbumId int 
AS
	SELECT t.Id, t.Title, Position, t.DurationMs, t.ClipId, t.Lyrics, t.ReleaseDate From Track as t
	JOIN AlbumTracks on t.Id = TrackId
	JOIN Album as a on a.Id = @AlbumId 
	ORDER BY Position ASC
RETURN 0
