CREATE PROCEDURE [dbo].[CreateVideo]
	@Title nvarchar(100),
	@ReleaseDate datetime2(7),
	@Url nvarchar(2083),
	@DurationMs int
AS
	BEGIN
		BEGIN TRY
			SET NOCOUNT ON;

			IF LEN(TRIM(@Title)) = 0
				RAISERROR('Le titre est requis.', 16, 1);
			IF LEN(TRIM(@Url)) = 0
				RAISERROR('L''url est requise.', 16, 1);

			IF EXISTS (SELECT * FROM [Video] WHERE [Url] = @Url)
				RAISERROR('L''URL est déjà associée à une vidéo', 16, 1);

			INSERT INTO [Video] ([Title], [ReleaseDate], [Url], [DurationMs])
			OUTPUT [inserted].[Id]
			VALUES (@Title, @ReleaseDate, @Url, @DurationMs)

		END TRY
		BEGIN CATCH
			THROW;
		END CATCH
	END
RETURN 0
