CREATE TABLE [dbo].[InterviewArtists]
(
    [ArtistId] INT NOT NULL, 
    [VideoId] INT NOT NULL, 
    CONSTRAINT [PK_InterviewArtists] PRIMARY KEY ([ArtistId], [VideoId]), 
    CONSTRAINT [FK_InterviewArtists_ToArtist] FOREIGN KEY ([ArtistId]) REFERENCES [Artist]([Id]), 
    CONSTRAINT [FK_InterviewArtists_ToVideo] FOREIGN KEY ([VideoId]) REFERENCES [Video]([Id]) 
)
