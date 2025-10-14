CREATE TABLE [dbo].[FreestyleArtists]
(
    [ArtistId] INT NOT NULL, 
    [VideoId] INT NOT NULL, 
    CONSTRAINT [PK_FreestyleArtists] PRIMARY KEY ([ArtistId], [VideoId]),
    CONSTRAINT [FK_FreestyleArtists_ToArtist] FOREIGN KEY ([ArtistId]) REFERENCES [Artist]([Id]), 
    CONSTRAINT [FK_FreestyleArtists_ToVideo] FOREIGN KEY ([VideoId]) REFERENCES [Video]([Id]) 
)
