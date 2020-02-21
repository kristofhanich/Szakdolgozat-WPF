CREATE PROCEDURE [dbo].[AruUpdate]
	@Id INT,
	@Nev NVARCHAR(255),
	@Leiras Text,
	@Mennyiseg int,
	@Ar INT,
	@Kep NVARCHAR(255)
AS
BEGIN
UPDATE [dbo].[Aru]
SET
Nev=@Nev,
Leiras=@Leiras,
Mennyiseg=@Mennyiseg,
Ar=@Ar,
Kep=@Kep
WHERE
[dbo].[Aru].[Id] = @Id
END