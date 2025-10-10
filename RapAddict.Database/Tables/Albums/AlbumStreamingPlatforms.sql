CREATE TABLE [dbo].[AlbumStreamingPlatforms]
(
	[AlbumId] INT NOT NULL , 
    [StreamingPlatformId] INT NOT NULL, 
    [Url] NVARCHAR(2083) NOT NULL, 
    CONSTRAINT [PK_AlbumStreamingPlatforms] PRIMARY KEY ([AlbumId], [StreamingPlatformId])
)
