CREATE TABLE [dbo].[JournalistStreamingPlatforms]
(
	[JournalistId] INT NOT NULL , 
    [StreamingPlatformId] INT NOT NULL, 
    [JournalistStreamingPlatformId] NVARCHAR(100) NULL, 
    CONSTRAINT [PK_JournalistStreamingPlatform] PRIMARY KEY ([JournalistId], [StreamingPlatformId]),
    CONSTRAINT [FK_JournalistStreamingPlatform_Artist] FOREIGN KEY ([JournalistId]) REFERENCES [Journalist]([Id]), 
    CONSTRAINT [FK_JournalistStreamingPlatform_StreamingPlatform] FOREIGN KEY ([StreamingPlatformId]) REFERENCES [StreamingPlatform]([Id]), 
    CONSTRAINT [UK_JournalistStreamingPlatform_ArtistStreaminPlatformId] UNIQUE ([JournalistStreamingPlatformId])
)
