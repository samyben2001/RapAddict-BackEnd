CREATE TABLE [dbo].[Interview]
(
	[Id] INT NOT NULL, 
    [JournalistId] INT NOT NULL, 
    CONSTRAINT [PK_Interview] PRIMARY KEY ([Id]), 
    CONSTRAINT [FK_Interview_ToVideo] FOREIGN KEY ([Id]) REFERENCES [Video]([Id]), 
    CONSTRAINT [FK_Interview_ToJournalist] FOREIGN KEY ([JournalistId]) REFERENCES [Journalist]([Id]) 
)
