CREATE TABLE [dbo].[TrackStreamingPlatforms]
(
	[TrackId] INT NOT NULL , 
    [StreamingPlatformId] INT NOT NULL, 
    [Url] NVARCHAR(2083) NOT NULL, 
    CONSTRAINT [PK_TrackStreamingPlatforms] PRIMARY KEY ([TrackId], [StreamingPlatformId])
)