CREATE PROCEDURE [dbo].[CreatePerson]
	@Pseudo nvarchar(100),
	@FirstName nvarchar(100),
	@LastName nvarchar(100), 
	@ImageUrl nvarchar(2083)
AS
	BEGIN
		BEGIN TRY
			SET NOCOUNT ON;

			IF LEN(TRIM(@Pseudo)) = 0
				RAISERROR('Le pseudo est requis.', 16, 1);

			INSERT INTO [Person] (Pseudo, FirstName, LastName, ImageUrl)
			OUTPUT [inserted].[Id]
			VALUES (@Pseudo, @FirstName, @LastName, @ImageUrl)

		END TRY
		BEGIN CATCH
			THROW;
		END CATCH
	END
RETURN 0
