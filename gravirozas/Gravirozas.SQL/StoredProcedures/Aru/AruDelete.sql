CREATE PROCEDURE [dbo].[AruDelete]
	@Id int
AS
BEGIN
DELETE [dbo].[Aru]
WHERE [dbo].[Aru].[Id] = @Id
END
