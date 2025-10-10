CREATE TABLE [dbo].[AlbumTracks]
(
	[AlbumId] INT NOT NULL , 
    [TrackId] INT NOT NULL, 
    [Position] INT NULL, 
    CONSTRAINT [FK_AlbumTracks_Album] FOREIGN KEY ([AlbumId]) REFERENCES [Album]([Id]), 
    CONSTRAINT [FK_AlbumTracks_Track] FOREIGN KEY ([TrackId]) REFERENCES [Track]([Id]), 
    CONSTRAINT [PK_AlbumTracks] PRIMARY KEY ([AlbumId], [TrackId])
)
