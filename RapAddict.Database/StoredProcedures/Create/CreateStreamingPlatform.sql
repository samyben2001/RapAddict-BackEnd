CREATE PROCEDURE [dbo].[CreateStreamingPlatform]
	@Name nvarchar(50)
AS
	BEGIN
		BEGIN TRY
			SET NOCOUNT ON;

			IF LEN(TRIM(@Name)) = 0
				RAISERROR('Le nom est requis.', 16, 1);

			IF EXISTS (SELECT * FROM [StreamingPlatform] WHERE [Name] = @Name)
				RAISERROR('Ce nom est déja utilisé', 16, 1);

			INSERT INTO [StreamingPlatform] ([Name])
			OUTPUT [inserted].[Id]
			VALUES (@Name)

		END TRY
		BEGIN CATCH
			THROW;
		END CATCH
	END
RETURN 0
