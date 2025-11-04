CREATE PROCEDURE [dbo].[GetJournalist]
	@Id int
AS
	-- Get Journalist Infos
	SELECT j.Id, p.Pseudo, p.AddedDate, p.FirstName, p.LastName, p.ImageUrl
	FROM [Journalist] as j
	JOIN [Person] as p ON p.Id = j.Id
	WHERE j.Id = @Id
	
	-- Get Journalist Interview
	SELECT i.[Id], v.[Title], v.[ReleaseDate], v.[DurationMs], v.[Url], v.[AddedDate] FROM [Interview] as i
	JOIN [Video] as v ON v.Id = i.Id
	WHERE i.JournalistId = @Id
	
	-- Get Journalist Social Media
	SELECT sm.[Name], psm.PersonSocialMediaPlatformId as 'IdFromPlatform'
	FROM [SocialMediaPlatform] as sm
	JOIN [PersonSocialMediaPlatforms] as psm ON psm.SocialMediaPlatformId = sm.Id
	WHERE psm.PersonId = @Id

	-- Get Journalist Streaming Platform
	SELECT sp.[Name], jsp.JournalistStreamingPlatformId as 'IdFromPlatform'
	FROM [StreamingPlatform] as sp
	JOIN [JournalistStreamingPlatforms] as jsp ON jsp.StreamingPlatformId = sp.Id
	WHERE jsp.JournalistId = @Id

RETURN 0
