CREATE PROCEDURE [dbo].[UgyfelGetByID]
	@Id int
AS
BEGIN
SELECT
[dbo].[Ugyfel].[Id],
[dbo].[Ugyfel].[Nev],
[dbo].[Ugyfel].[Cim],
[dbo].[Ugyfel].[Telefonszam]
FROM
[dbo].[Ugyfel]
where
[dbo].[Ugyfel].[Id] = @Id
END