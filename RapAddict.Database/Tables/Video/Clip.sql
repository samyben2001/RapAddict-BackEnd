CREATE TABLE [dbo].[Clip]
(
	[Id] INT NOT NULL, 
    [ArtistId] INT NOT NULL, 
    CONSTRAINT [PK_Clip] PRIMARY KEY ([Id]), 
    CONSTRAINT [FK_Clip_ToVideo] FOREIGN KEY ([Id]) REFERENCES [Video]([Id]), 
    CONSTRAINT [FK_Clip_ToArtist] FOREIGN KEY ([ArtistId]) REFERENCES [Artist]([Id]) 
)
