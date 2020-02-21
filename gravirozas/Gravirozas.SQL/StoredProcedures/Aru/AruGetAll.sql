CREATE PROCEDURE [dbo].[AruGetAll]

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
END