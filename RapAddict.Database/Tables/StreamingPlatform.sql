CREATE TABLE [dbo].[StreamingPlatform]
(
	[Id] INT NOT NULL IDENTITY, 
    [Name] NVARCHAR(50) NOT NULL, 
    CONSTRAINT [PK_StreamingPlatform] PRIMARY KEY ([Id]), 
    CONSTRAINT [UK_StreamingPlatform_Name] UNIQUE ([Name]) 
)
