CREATE TABLE [dbo].[Person]
(
	[Id] INT NOT NULL , 
    [Pseudo] NVARCHAR(100) NOT NULL, 
    [FirstName] NVARCHAR(100) NULL, 
    [LastName] NVARCHAR(100) NULL, 
    CONSTRAINT [PK_Person] PRIMARY KEY ([Id])
)
