CREATE TABLE [dbo].[AnalyseArtists]
(
    [ArtistId] INT NOT NULL, 
    [VideoId] INT NOT NULL, 
    CONSTRAINT [FK_AnalyseArtists_ToArtist] FOREIGN KEY ([ArtistId]) REFERENCES [Artist]([Id]), 
    CONSTRAINT [FK_AnalyseArtists_ToVideo] FOREIGN KEY ([VideoId]) REFERENCES [Video]([Id]), 
    CONSTRAINT [PK_AnalyseArtists] PRIMARY KEY ([ArtistId], [VideoId])
)
