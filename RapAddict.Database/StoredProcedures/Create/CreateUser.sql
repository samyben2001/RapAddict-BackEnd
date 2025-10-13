CREATE PROCEDURE [dbo].[CreateUser]
	@Username nvarchar(50),
	@Email nvarchar(50),
	@Password nvarchar(256),
	@FirstName nvarchar(50),
	@LastName nvarchar(50)
AS
	BEGIN
		BEGIN TRY
			SET NOCOUNT ON;

			IF LEN(TRIM(@Username)) = 0
				RAISERROR('Le nom d''utilisiateur est requis.', 16, 1);

			IF LEN(TRIM(@Email)) = 0
				RAISERROR('L''adresse email est requise.', 16, 1)

			IF LEN(TRIM(@Email)) < 7 OR @Email NOT LIKE '%_@__%.__%'
				RAISERROR('Format invalide pour l''adresse email. (*@**.**)', 16, 1);

			IF EXISTS (SELECT * FROM [User] WHERE [Email] = @Email)
				RAISERROR('L''adresse email est déja utilisée', 16, 1);

			IF EXISTS (SELECT * FROM [User] WHERE [Username] = @Username)
				RAISERROR('L''username est déja utilisé', 16, 1);

			INSERT INTO [User] ([Username], [Email], [Password], [FirstName], [LastName])
			OUTPUT [inserted].[Id]
			VALUES(@Username, @Email, dbo.HashAndSalt(@Password), @FirstName, @LastName)
		END TRY
		BEGIN CATCH
			THROW;
		END CATCH
	END
RETURN 0
