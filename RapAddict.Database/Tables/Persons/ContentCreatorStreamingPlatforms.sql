CREATE TABLE [dbo].[ContentCreatorStreamingPlatforms]
(
	[ContentCreatorId] INT NOT NULL , 
    [StreamingPlatformId] INT NOT NULL, 
    [ContentCreatorStreamingPlatformId] NVARCHAR(100) NULL, 
    CONSTRAINT [PK_ContentCreatorStreamingPlatform] PRIMARY KEY ([ContentCreatorId], [StreamingPlatformId]),
    CONSTRAINT [FK_ContentCreatorStreamingPlatform_Artist] FOREIGN KEY ([ContentCreatorId]) REFERENCES [ContentCreator]([Id]), 
    CONSTRAINT [FK_ContentCreatorStreamingPlatform_StreamingPlatform] FOREIGN KEY ([StreamingPlatformId]) REFERENCES [StreamingPlatform]([Id]), 
    CONSTRAINT [UK_ContentCreatorStreamingPlatform_ArtistStreaminPlatformId] UNIQUE ([ContentCreatorStreamingPlatformId])
)
