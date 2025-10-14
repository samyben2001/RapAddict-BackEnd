CREATE PROCEDURE [dbo].[CreateClip]
	@Id int,	
	@ArtistId int
AS
	INSERT INTO [Clip] ([Id], [ArtistId])
	VALUES (@Id, @ArtistId)
RETURN 0
