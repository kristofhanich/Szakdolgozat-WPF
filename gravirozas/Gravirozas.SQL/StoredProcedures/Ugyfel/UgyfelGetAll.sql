CREATE PROCEDURE [dbo].[UgyfelGetAll]

AS
BEGIN
SELECT
[dbo].[Ugyfel].[Id],
[dbo].[Ugyfel].[Nev],
[dbo].[Ugyfel].[Cim],
[dbo].[Ugyfel].[Telefonszam]
FROM
[dbo].[Ugyfel]
END