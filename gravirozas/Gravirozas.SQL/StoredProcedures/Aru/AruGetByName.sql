CREATE PROCEDURE [dbo].[AruGetByName]
	@nev nvarchar(255)
AS
BEGIN
SELECT
[dbo].[Aru].[Id],
[dbo].[Aru].[Nev],
[dbo].[Aru].[Leiras],
[dbo].[Aru].[Mennyiseg],
[dbo].[Aru].[Ar],
[dbo].[Aru].[Kep]
FROM
[dbo].[Aru]
WHERE
[dbo].[Aru].[Nev] =@nev
END