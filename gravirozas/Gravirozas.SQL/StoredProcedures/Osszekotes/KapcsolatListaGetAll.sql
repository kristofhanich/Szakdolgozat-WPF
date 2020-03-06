CREATE PROCEDURE [dbo].[KapcsolatListaGetAll]
AS
BEGIN
SELECT
[dbo].[Ugyfel].[Nev] as UgyfelNev,
[dbo].[Aru].[Nev] as AruNev,
[dbo].[Kapcsolat].[Datum],
[dbo].[Kapcsolat].[HatarIdo],
[dbo].[Kapcsolat].[Darab],
[dbo].[Kapcsolat].[TeljesAr]
FROM
[dbo].[Kapcsolat]
INNER JOIN 
Ugyfel ON
Kapcsolat.UgyfelID=Ugyfel.Id
INNER JOIN 
Aru ON
Aru.Id=Kapcsolat.AruID
END