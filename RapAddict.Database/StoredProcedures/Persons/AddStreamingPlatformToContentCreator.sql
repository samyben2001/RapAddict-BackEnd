CREATE PROCEDURE [dbo].[AddStreamingPlatformToContentCreator]
	@ContentCreatorId int,
	@StreamingPlatformId int,
	@ContentCreatorPlatformId nvarchar(100)
AS
	SET NOCOUNT ON;
	INSERT INTO [ContentCreatorStreamingPlatforms] ([ContentCreatorId], [StreamingPlatformId], [ContentCreatorStreamingPlatformId])
	VALUES (@ContentCreatorId, @StreamingPlatformId, @ContentCreatorPlatformId)
RETURN 0
