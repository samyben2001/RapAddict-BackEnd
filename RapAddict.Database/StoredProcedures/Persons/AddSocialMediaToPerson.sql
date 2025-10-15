CREATE PROCEDURE [dbo].[AddSocialMediaToPerson]
	@PersonId int,
	@SocialMediaId int,
	@PlatformId nvarchar(100)
AS
	SET NOCOUNT ON;
	INSERT INTO [PersonSocialMediaPlatforms] ([PersonId], [SocialMediaPlatformId], [PersonSocialMediaPlatformId])
	VALUES (@PersonId, @SocialMediaId, @PlatformId)
RETURN 0