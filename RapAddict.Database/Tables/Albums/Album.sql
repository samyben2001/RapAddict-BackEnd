CREATE TABLE [dbo].[Album]
(
	[Id] INT NOT NULL, 
    [Title] NVARCHAR(100) NOT NULL, 
    [ReleaseDate] DATETIME2 NULL, 
    [DurationMs] INT NULL, 
    CONSTRAINT [PK_Album] PRIMARY KEY ([Id]) 
)
