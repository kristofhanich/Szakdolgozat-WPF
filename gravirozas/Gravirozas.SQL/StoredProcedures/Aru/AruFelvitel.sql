CREATE PROCEDURE [dbo].[AruFelvitel]
	@Nev NVARCHAR(255),
	@Leiras TEXT,
	@Mennyiseg int,
	@Ar INT,
	@Kep NVARCHAR(255)
AS
BEGIN
INSERT INTO [dbo].[Aru]
(
[Nev],[Leiras],[Mennyiseg],[Ar],[Kep]
)
VALUES
(
@Nev,@Leiras,@Mennyiseg,@Ar,@Kep
)

SELECT CONVERT(int,SCOPE_IDENTITY());
END
