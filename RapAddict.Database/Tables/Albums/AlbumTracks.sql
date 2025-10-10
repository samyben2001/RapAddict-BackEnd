CREATE TABLE [dbo].[AlbumTracks]
(
	[AlbumId] INT NOT NULL , 
    [TrackId] INT NOT NULL, 
    [Position] INT NULL, 
    CONSTRAINT [PK_AlbumTracks] PRIMARY KEY ([AlbumId], [TrackId])
)
