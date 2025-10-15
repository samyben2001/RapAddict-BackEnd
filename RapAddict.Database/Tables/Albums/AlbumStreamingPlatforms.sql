CREATE TABLE [dbo].[AlbumStreamingPlatforms]
(
	[AlbumId] INT NOT NULL , 
    [StreamingPlatformId] INT NOT NULL, 
    [AlbumStreamingPlatformId] NVARCHAR(100) NOT NULL, 
    CONSTRAINT [FK_AlbumStreamingPlatforms_Album] FOREIGN KEY ([AlbumId]) REFERENCES [Album]([Id]), 
    CONSTRAINT [FK_AlbumStreamingPlatforms_StreamingPlatform] FOREIGN KEY ([StreamingPlatformId]) REFERENCES [StreamingPlatform]([Id]), 
    CONSTRAINT [PK_AlbumStreamingPlatforms] PRIMARY KEY ([AlbumId], [StreamingPlatformId]), 
    CONSTRAINT [UK_AlbumStreamingPlatforms_AlbumStreamingPlatformId] UNIQUE ([AlbumStreamingPlatformId])
)
