CREATE PROCEDURE [dbo].[AddArtistToInterview]
	@InterviewId int,
	@ArtistId int
AS
	SET NOCOUNT ON;
	INSERT INTO [InterviewArtists] ([VideoId], [ArtistId])
	VALUES (@InterviewId, @ArtistId)
RETURN 0
