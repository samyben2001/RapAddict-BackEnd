CREATE TABLE [dbo].[ArtistTracks]
(
	[ArtistId] INT NOT NULL , 
    [TrackId] INT NOT NULL, 
    CONSTRAINT [FK_ArtistTracks_Artist] FOREIGN KEY ([ArtistId]) REFERENCES [Artist]([Id]), 
    CONSTRAINT [FK_ArtistTracks_Track] FOREIGN KEY ([TrackId]) REFERENCES [Track]([Id]), 
    CONSTRAINT [PK_ArtistTracks] PRIMARY KEY ([ArtistId], [TrackId])
)
