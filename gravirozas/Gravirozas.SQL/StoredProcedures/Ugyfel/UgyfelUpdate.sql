CREATE PROCEDURE [dbo].[UgyfelUpdate]
	@Id INT,
	@Nev NVARCHAR(255),
	@Cim NVARCHAR(255),
	@Telefonszam NVARCHAR(255)
AS
BEGIN
UPDATE [dbo].[Ugyfel]
SET
[Nev] = @Nev,
[Cim] = @Cim,
[Telefonszam] = @Telefonszam
WHERE
[dbo].[Ugyfel].[Id] = @Id
END
