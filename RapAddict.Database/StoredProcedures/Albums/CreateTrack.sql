CREATE PROCEDURE [dbo].[CreateTrack]
	@Title nvarchar(100),
	@ReleaseDate datetime2(7),
	@DurationMs int,
	@Lyrics text
AS
	BEGIN
		BEGIN TRY
			SET NOCOUNT ON;

			IF LEN(TRIM(@Title)) = 0
				RAISERROR('Le titre est requis.', 16, 1);

			INSERT INTO [Track] ([Title], [ReleaseDate], [DurationMs], [Lyrics])
			OUTPUT [inserted].[Id]
			VALUES (@Title, @ReleaseDate, @DurationMs, @Lyrics)

		END TRY
		BEGIN CATCH
			THROW;
		END CATCH
	END
RETURN 0
