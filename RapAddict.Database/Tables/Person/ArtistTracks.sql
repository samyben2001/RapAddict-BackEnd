CREATE TABLE [dbo].[ArtistTracks]
(
	[ArtistId] INT NOT NULL , 
    [TrackId] INT NOT NULL, 
    CONSTRAINT [PK_ArtistTracks] PRIMARY KEY ([ArtistId], [TrackId])
)
