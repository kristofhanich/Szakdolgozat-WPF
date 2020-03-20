CREATE PROCEDURE [dbo].[UgyfelListaGetAll]
AS
BEGIN
SELECT
[dbo].[Ugyfel].[Nev],
[dbo].[Ugyfel].[Cim],
[dbo].[Ugyfel].[Telefonszam]
FROM
[dbo].[Ugyfel]
END