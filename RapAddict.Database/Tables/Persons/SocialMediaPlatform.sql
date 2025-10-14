CREATE TABLE [dbo].[SocialMediaPlatform]
(
	[Id] INT NOT NULL IDENTITY, 
    [Name] NVARCHAR(50) NOT NULL, 
    CONSTRAINT [PK_SocialMediaPlatform] PRIMARY KEY ([Id]), 
    CONSTRAINT [UK_SocialMediaPlatform_Name] UNIQUE ([Name])
)
