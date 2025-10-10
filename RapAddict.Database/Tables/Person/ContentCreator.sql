CREATE TABLE [dbo].[ContentCreator]
(
	[Id] INT NOT NULL, 
    CONSTRAINT [PK_ContentCreator] PRIMARY KEY ([Id]), 
    CONSTRAINT [FK_ContentCreator_ToPerson] FOREIGN KEY ([Id]) REFERENCES [Person]([Id]) 
)
