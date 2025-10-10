CREATE TABLE [dbo].[Artist]
(
	[Id] INT NOT NULL, 
    CONSTRAINT [PK_Artist] PRIMARY KEY ([Id]), 
    CONSTRAINT [FK_Artist_ToPerson] FOREIGN KEY ([Id]) REFERENCES [Person]([Id]) 
)
