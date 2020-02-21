CREATE PROCEDURE [dbo].[AruUpdateMennyiseg]
	@Id INT,
	@Mennyiseg int
AS
BEGIN
UPDATE [dbo].[Aru]
SET
[Mennyiseg] = @Mennyiseg
WHERE
[dbo].[Aru].[Id] = @Id
END