CREATE PROCEDURE [dbo].[UgyfelCreate]
	@Nev NVARCHAR(255),
	@Cim NVARCHAR(255),
	@Telefonszam NVARCHAR(255)
AS
BEGIN
INSERT INTO [dbo].[Ugyfel]
(
[Nev],[Cim],[Telefonszam]
)
VALUES
(
@Nev,@Cim,@Telefonszam
)

SELECT CONVERT(int,SCOPE_IDENTITY());
END
