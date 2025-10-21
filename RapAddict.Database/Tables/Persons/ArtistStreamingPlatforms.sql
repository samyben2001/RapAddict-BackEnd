CREATE TABLE [dbo].[ArtistStreamingPlatforms]
(
	[ArtistId] INT NOT NULL , 
    [StreamingPlatformId] INT NOT NULL, 
    [ArtistStreamingPlatformId] NVARCHAR(100) NULL, 
    CONSTRAINT [PK_ArtistStreamingPlatform] PRIMARY KEY ([ArtistId], [StreamingPlatformId]),
    CONSTRAINT [FK_ArtistStreamingPlatform_Artist] FOREIGN KEY ([ArtistId]) REFERENCES [Artist]([Id]), 
    CONSTRAINT [FK_ArtistStreamingPlatform_StreamingPlatform] FOREIGN KEY ([StreamingPlatformId]) REFERENCES [StreamingPlatform]([Id]), 
    CONSTRAINT [UK_ArtistStreamingPlatform_ArtistStreaminPlatformId] UNIQUE ([ArtistStreamingPlatformId])
)
