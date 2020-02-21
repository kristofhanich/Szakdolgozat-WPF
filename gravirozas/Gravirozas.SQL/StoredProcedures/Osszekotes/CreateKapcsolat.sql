CREATE PROCEDURE [dbo].[CreateKapcsolat]
	@UgyfelID int,
	@AruID int,
	@Darab int,
	@HatarIdo DateTime,
	@TeljesAr int
AS
BEGIN
INSERT INTO [dbo].Kapcsolat
(
[UgyfelID],[AruID],[Datum],[Darab],HatarIdo,[TeljesAr]
)
VALUES
(
@UgyfelID,@AruID,GETDATE(),@Darab,@HatarIdo,@TeljesAr
)
END