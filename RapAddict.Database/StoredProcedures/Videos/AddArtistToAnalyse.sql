CREATE PROCEDURE [dbo].[AddArtistToAnalyse]
	@AnalyseId int,
	@ArtistId int
AS
	SET NOCOUNT ON;
	INSERT INTO [AnalyseArtists] ([VideoId], [ArtistId])
	VALUES (@AnalyseId, @ArtistId)
RETURN 0
