CREATE TABLE [dbo].[ClipArtists]
(
    [ArtistId] INT NOT NULL, 
    [VideoId] INT NOT NULL, 
    CONSTRAINT [FK_ClipArtists_ToArtist] FOREIGN KEY ([ArtistId]) REFERENCES [Artist]([Id]), 
    CONSTRAINT [FK_ClipArtists_ToVideo] FOREIGN KEY ([VideoId]) REFERENCES [Video]([Id]), 
    CONSTRAINT [PK_ClipArtists] PRIMARY KEY ([ArtistId], [VideoId])
)
