CREATE PROCEDURE [dbo].[KapcsolatGetAll]

AS
BEGIN
SELECT
[dbo].[Kapcsolat].[UgyfelID],
[dbo].[Kapcsolat].[AruID],
[dbo].[Kapcsolat].[Datum],
[dbo].[Kapcsolat].[HatarIdo],
[dbo].[Kapcsolat].[Darab],
[dbo].[Kapcsolat].[TeljesAr]
FROM
[dbo].[Kapcsolat]
END