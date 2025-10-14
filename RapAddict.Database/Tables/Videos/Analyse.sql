CREATE TABLE [dbo].[Analyse]
(
	[Id] INT NOT NULL, 
    [ContentCreatorId] INT NOT NULL, 
    CONSTRAINT [PK_Analyse] PRIMARY KEY ([Id]), 
    CONSTRAINT [FK_Analyse_ToVideo] FOREIGN KEY ([Id]) REFERENCES [Video]([Id]), 
    CONSTRAINT [FK_Analyse_ToContentCreator] FOREIGN KEY ([ContentCreatorId]) REFERENCES [ContentCreator]([Id])
)
