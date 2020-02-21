CREATE PROCEDURE [dbo].[AruAvailable]
	@Id int
AS
BEGIN
SELECT
[dbo].[Aru].[Mennyiseg]
FROM
[dbo].[Aru]
WHERE
[dbo].[Aru].[Id] = @Id
END