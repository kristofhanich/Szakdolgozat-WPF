CREATE TABLE [dbo].[Kapcsolat]
(
	[ID] INT NOT NULL PRIMARY KEY IDENTITY,
	[UgyfelID] INT NOT NULL,
	[AruID] INT NOT NULL,
	[Datum] DateTime NOT NULL,
	[HatarIdo] DateTime NOT NULL,
	[Darab] INT NOT NULL,
	[TeljesAr] INT NOT NULL
)

GO

CREATE INDEX [ugyfelxindex] ON [dbo].[Kapcsolat] (UgyfelID)

GO

CREATE INDEX [Aruindex] ON [dbo].[Kapcsolat] (AruID)
