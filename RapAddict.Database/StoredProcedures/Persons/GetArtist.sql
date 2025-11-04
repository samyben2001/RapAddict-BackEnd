CREATE PROCEDURE [dbo].[GetArtist]
	@Id int
AS
	-- Get Artist Infos
	SELECT a.Id, p.Pseudo, p.AddedDate, p.FirstName, p.LastName, p.ImageUrl
	FROM [Artist] as a
	JOIN [Person] as p ON p.Id = a.Id
	WHERE a.Id = @Id
	
	-- Get Artist Social Media
	SELECT sm.[Name], psm.PersonSocialMediaPlatformId as 'IdFromPlatform'
	FROM [SocialMediaPlatform] as sm
	JOIN [PersonSocialMediaPlatforms] as psm ON psm.SocialMediaPlatformId = sm.Id
	WHERE psm.PersonId = @Id

	-- Get Artist Streaming Platform
	SELECT sp.[Name], asp.ArtistStreamingPlatformId as 'IdFromPlatform'
	FROM [StreamingPlatform] as sp
	JOIN [ArtistStreamingPlatforms] as asp ON asp.StreamingPlatformId = sp.Id
	WHERE asp.ArtistId = @Id
RETURN 0
