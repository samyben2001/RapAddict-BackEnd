CREATE TABLE [dbo].[PersonSocialMediaPlatforms]
(
	[PersonId] INT NOT NULL, 
    [SocialMediaPlatformId] INT NOT NULL, 
    [Url] NVARCHAR(2083) NOT NULL, 
    CONSTRAINT [FK_PersonSocialMediaPlatforms_Person] FOREIGN KEY ([PersonId]) REFERENCES [Person]([Id]), 
    CONSTRAINT [FK_PersonSocialMediaPlatforms_SocialMediaPlatform] FOREIGN KEY ([SocialMediaPlatformId]) REFERENCES [SocialMediaPlatform]([Id]), 
    CONSTRAINT [PK_PersonSocialMediaPlatforms] PRIMARY KEY ([PersonId], [SocialMediaPlatformId]) 
)
