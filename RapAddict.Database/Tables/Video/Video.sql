CREATE TABLE [dbo].[Video]
(
	[Id] INT NOT NULL, 
    [Title] NVARCHAR(100) NOT NULL, 
    [ReleaseDate] DATETIME2 NULL, 
    [Url] NVARCHAR(2083) NOT NULL, 
    [DurationMs] INT NULL, 
    CONSTRAINT [PK_Video] PRIMARY KEY ([Id]) 
)
