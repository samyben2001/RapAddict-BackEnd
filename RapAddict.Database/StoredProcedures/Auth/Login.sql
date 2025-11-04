CREATE PROCEDURE [dbo].[Login]
	@login NVARCHAR(320),
	@password NVARCHAR(128)
AS
BEGIN
	SELECT	[Id],
			[Username],
			[Email],
			[InscriptionDate]
		FROM [User]
		WHERE	([Email] = @login OR [Username] = @login)
			AND	[Password] = dbo.HashAndSalt(@Password)
END
RETURN 0
