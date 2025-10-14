CREATE PROCEDURE [dbo].[CreateAnalyse]
	@Id int,
	@ContentCreatorId int
AS
	INSERT INTO [Analyse] ([Id], [ContentCreatorId])
	VALUES (@Id, @ContentCreatorId)
RETURN 0
