CREATE PROCEDURE [dbo].[CreateAlbum]
	@Title nvarchar(100),
	@ReleaseDate datetime2(7),
	@DurationMs int
AS
	BEGIN
		BEGIN TRY
			SET NOCOUNT ON;

			IF LEN(TRIM(@Title)) = 0
				RAISERROR('Le titre est requis.', 16, 1);

			INSERT INTO [Album] ([Title], [ReleaseDate], [DurationMs])
			OUTPUT [inserted].[Id]
			VALUES (@Title, @ReleaseDate, @DurationMs)

		END TRY
		BEGIN CATCH
			THROW;
		END CATCH
	END
RETURN 0
