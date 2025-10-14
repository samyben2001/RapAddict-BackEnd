CREATE TABLE [dbo].[Journalist]
(
	[Id] INT NOT NULL, 
    CONSTRAINT [PK_Journalist] PRIMARY KEY ([Id]), 
    CONSTRAINT [FK_Journalist_ToPerson] FOREIGN KEY ([Id]) REFERENCES [Person]([Id]) 
)
