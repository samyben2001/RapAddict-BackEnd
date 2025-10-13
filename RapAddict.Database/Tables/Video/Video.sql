CREATE TABLE [dbo].[Video]
(
	[Id] INT NOT NULL IDENTITY, 
    [Title] NVARCHAR(100) NOT NULL, 
    [ReleaseDate] DATETIME2 NULL, 
    [Url] NVARCHAR(2083) NOT NULL, 
    [DurationMs] INT NULL, 
    CONSTRAINT [PK_Video] PRIMARY KEY ([Id]), 
    CONSTRAINT [UK_Video_Url] UNIQUE ([Url]) 
)
