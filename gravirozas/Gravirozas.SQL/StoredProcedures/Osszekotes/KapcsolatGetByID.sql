CREATE PROCEDURE [dbo].[KapcsolatGetByID]
	
@Id int
AS
BEGIN
SELECT
[dbo].[Kapcsolat].[Id],
[dbo].[Kapcsolat].[AruID],
[dbo].[Kapcsolat].[UgyfelID],
[dbo].[Kapcsolat].[Darab],
[dbo].[Kapcsolat].[Datum],
[dbo].[Kapcsolat].[HatarIdo],
[dbo].[Kapcsolat].[TeljesAr]
FROM
[dbo].[Kapcsolat]
where
[dbo].[Kapcsolat].[Id] = @Id
END
