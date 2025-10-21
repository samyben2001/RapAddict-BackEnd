CREATE TABLE [dbo].[Track]
(
	[Id] INT NOT NULL IDENTITY, 
    [Title] NVARCHAR(100) NOT NULL, 
    [ReleaseDate] DATETIME2 NULL, 
    [DurationMs] INT NULL, 
    [ClipId] INT NULL, 
    [Lyrics] TEXT NULL, 
    [AddedDate] DATETIME2 NOT NULL DEFAULT GETDATE(), 
    CONSTRAINT [PK_Track] PRIMARY KEY ([Id]), 
    CONSTRAINT [FK_Track_ToClip] FOREIGN KEY ([ClipId]) REFERENCES [Clip]([Id])
)
