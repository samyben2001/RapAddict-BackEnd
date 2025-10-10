CREATE TABLE [dbo].[User]
(
	[Id] INT NOT NULL , 
    [Username] NVARCHAR(50) NOT NULL, 
    [Email] NVARCHAR(384) NULL, 
    [InscriptionDate] DATETIME2 NOT NULL DEFAULT GETDATE(), 
    [Password] VARBINARY(128) NOT NULL, 
    [FirstName] NVARCHAR(50) NULL, 
    [LastName] NVARCHAR(50) NULL, 
    CONSTRAINT [PK_User] PRIMARY KEY ([Id]), 
    CONSTRAINT [UK_User_Username] UNIQUE ([Username])
)
