CREATE TABLE [dbo].[ArtistAlbums]
(
	[ArtistId] INT NOT NULL, 
    [AlbumId] INT NOT NULL, 
    CONSTRAINT [PK_ArtistAlbums] PRIMARY KEY ([ArtistId], [AlbumId]) 
)
