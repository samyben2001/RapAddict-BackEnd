CREATE PROCEDURE [dbo].[CreateInterview]
	@Id int,
	@JournalistId int
AS
	INSERT INTO [Interview] ([Id], [JournalistId])
	VALUES (@Id, @JournalistId)
RETURN 0
