CREATE TABLE [dbo].[Freestyle]
(
	[Id] INT NOT NULL, 
    CONSTRAINT [PK_Freestyle] PRIMARY KEY ([Id]), 
    CONSTRAINT [FK_Freestyle_ToVideo] FOREIGN KEY ([Id]) REFERENCES [Video]([Id]) 
)
