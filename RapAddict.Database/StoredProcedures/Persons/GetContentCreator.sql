CREATE PROCEDURE [dbo].[GetContentCreator]
	@Id int
AS
	-- Get ContentCreator Infos
	SELECT cc.Id, p.Pseudo, p.AddedDate, p.FirstName, p.LastName, p.ImageUrl
	FROM [ContentCreator] as cc
	JOIN [Person] as p ON p.Id = cc.Id
	WHERE cc.Id = @Id
	
	-- Get ContentCreator Analyses
	SELECT a.[Id], v.[Title], v.[ReleaseDate], v.[DurationMs], v.[Url], v.[AddedDate] FROM [Analyse] as a
	JOIN [Video] as v ON v.Id = a.Id
	WHERE a.ContentCreatorId = @Id
	
	-- Get ContentCreator Social Media
	SELECT sm.[Name], psm.PersonSocialMediaPlatformId as 'IdFromPlatform'
	FROM [SocialMediaPlatform] as sm
	JOIN [PersonSocialMediaPlatforms] as psm ON psm.SocialMediaPlatformId = sm.Id
	WHERE psm.PersonId = @Id

	-- Get ContentCreator Streaming Platform
	SELECT sp.[Name], ccsp.ContentCreatorStreamingPlatformId as 'IdFromPlatform'
	FROM [StreamingPlatform] as sp
	JOIN [ContentCreatorStreamingPlatforms] as ccsp ON ccsp.StreamingPlatformId = sp.Id
	WHERE ccsp.ContentCreatorId = @Id

RETURN 0
