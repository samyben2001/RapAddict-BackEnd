CREATE TABLE [dbo].[ArtistAlbums]
(
	[ArtistId] INT NOT NULL, 
    [AlbumId] INT NOT NULL, 
    CONSTRAINT [FK_ArtistAlbums_Artist] FOREIGN KEY ([ArtistId]) REFERENCES [Artist]([Id]), 
    CONSTRAINT [FK_ArtistAlbums_Album] FOREIGN KEY ([AlbumId]) REFERENCES [Album]([Id]), 
    CONSTRAINT [PK_ArtistAlbums] PRIMARY KEY ([ArtistId], [AlbumId]) 
)
