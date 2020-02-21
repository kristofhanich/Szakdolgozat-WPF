CREATE PROCEDURE [dbo].[UgyfelDelete]
	@Id int
AS
BEGIN
DELETE [dbo].[Ugyfel]
WHERE [dbo].[Ugyfel].[Id] = @Id
END
