CREATE PROCEDURE [dbo].[AddStreamingPlatformToJournalist]
	@JournalistId int,
	@StreamingPlatformId int,
	@JournalistPlatformId nvarchar(100)
AS
	SET NOCOUNT ON;
	INSERT INTO [JournalistStreamingPlatforms] ([JournalistId], [StreamingPlatformId], [JournalistStreamingPlatformId])
	VALUES (@JournalistId, @StreamingPlatformId, @JournalistPlatformId)
RETURN 0
