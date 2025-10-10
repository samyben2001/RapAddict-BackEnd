CREATE TABLE [dbo].[TrackStreamingPlatforms]
(
	[TrackId] INT NOT NULL , 
    [StreamingPlatformId] INT NOT NULL, 
    [Url] NVARCHAR(2083) NOT NULL, 
    CONSTRAINT [FK_TrackStreamingPlatforms_Track] FOREIGN KEY ([TrackId]) REFERENCES [Track]([Id]), 
    CONSTRAINT [FK_TrackStreamingPlatforms_StreamingPlatform] FOREIGN KEY ([StreamingPlatformId]) REFERENCES [StreamingPlatform]([Id]), 
    CONSTRAINT [PK_TrackStreamingPlatforms] PRIMARY KEY ([TrackId], [StreamingPlatformId])
)