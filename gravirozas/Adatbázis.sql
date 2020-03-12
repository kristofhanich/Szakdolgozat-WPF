USE [master]
GO
/****** Object:  Database [gravirozasDB]    Script Date: 12/03/2020 10:10:32 ******/
CREATE DATABASE [gravirozasDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'gravirozasDB', FILENAME = N'C:\Users\MacBook\AppData\Local\Microsoft\Microsoft SQL Server Local DB\Instances\MSSQLLocalDBgravirozasDB_Primary.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'gravirozasDB_log', FILENAME = N'C:\Users\MacBook\AppData\Local\Microsoft\Microsoft SQL Server Local DB\Instances\MSSQLLocalDBgravirozasDB_Primary.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [gravirozasDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [gravirozasDB] SET ANSI_NULL_DEFAULT ON 
GO
ALTER DATABASE [gravirozasDB] SET ANSI_NULLS ON 
GO
ALTER DATABASE [gravirozasDB] SET ANSI_PADDING ON 
GO
ALTER DATABASE [gravirozasDB] SET ANSI_WARNINGS ON 
GO
ALTER DATABASE [gravirozasDB] SET ARITHABORT ON 
GO
ALTER DATABASE [gravirozasDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [gravirozasDB] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [gravirozasDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [gravirozasDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [gravirozasDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [gravirozasDB] SET CURSOR_DEFAULT  LOCAL 
GO
ALTER DATABASE [gravirozasDB] SET CONCAT_NULL_YIELDS_NULL ON 
GO
ALTER DATABASE [gravirozasDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [gravirozasDB] SET QUOTED_IDENTIFIER ON 
GO
ALTER DATABASE [gravirozasDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [gravirozasDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [gravirozasDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [gravirozasDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [gravirozasDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [gravirozasDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [gravirozasDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [gravirozasDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [gravirozasDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [gravirozasDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [gravirozasDB] SET  MULTI_USER 
GO
ALTER DATABASE [gravirozasDB] SET PAGE_VERIFY NONE  
GO
ALTER DATABASE [gravirozasDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [gravirozasDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [gravirozasDB] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [gravirozasDB]
GO
/****** Object:  StoredProcedure [dbo].[AruAvailable]    Script Date: 12/03/2020 10:10:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AruAvailable]
	@Id int
AS
BEGIN
SELECT
[dbo].[Aru].[Mennyiseg]
FROM
[dbo].[Aru]
WHERE
[dbo].[Aru].[Id] = @Id
END
GO
/****** Object:  StoredProcedure [dbo].[AruCreate]    Script Date: 12/03/2020 10:10:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AruCreate]
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
GO
/****** Object:  StoredProcedure [dbo].[AruDelete]    Script Date: 12/03/2020 10:10:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AruDelete]
	@Id int
AS
BEGIN
DELETE [dbo].[Aru]
WHERE [dbo].[Aru].[Id] = @Id
END
GO
/****** Object:  StoredProcedure [dbo].[AruFelvitel]    Script Date: 12/03/2020 10:10:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
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
GO
/****** Object:  StoredProcedure [dbo].[AruGetAll]    Script Date: 12/03/2020 10:10:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
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
GO
/****** Object:  StoredProcedure [dbo].[AruGetByID]    Script Date: 12/03/2020 10:10:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AruGetByID]
	@Id int
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
[dbo].[Aru].[Id] =@Id
END
GO
/****** Object:  StoredProcedure [dbo].[AruGetByName]    Script Date: 12/03/2020 10:10:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
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
GO
/****** Object:  StoredProcedure [dbo].[AruUpdate]    Script Date: 12/03/2020 10:10:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
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
GO
/****** Object:  StoredProcedure [dbo].[AruUpdateMennyiseg]    Script Date: 12/03/2020 10:10:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
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
GO
/****** Object:  StoredProcedure [dbo].[CreateKapcsolat]    Script Date: 12/03/2020 10:10:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
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
GO
/****** Object:  StoredProcedure [dbo].[KapcsolatGetAll]    Script Date: 12/03/2020 10:10:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[KapcsolatGetAll]

AS
BEGIN
SELECT
[dbo].[Kapcsolat].[UgyfelID],
[dbo].[Kapcsolat].[AruID],
[dbo].[Kapcsolat].[Datum],
[dbo].[Kapcsolat].[HatarIdo],
[dbo].[Kapcsolat].[Darab],
[dbo].[Kapcsolat].[TeljesAr]
FROM
[dbo].[Kapcsolat]
END
GO
/****** Object:  StoredProcedure [dbo].[KapcsolatGetByID]    Script Date: 12/03/2020 10:10:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
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
GO
/****** Object:  StoredProcedure [dbo].[KapcsolatListaGetAll]    Script Date: 12/03/2020 10:10:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[KapcsolatListaGetAll]
AS
BEGIN
SELECT
[dbo].[Ugyfel].[Nev] as UgyfelNev,
[dbo].[Aru].[Nev] as AruNev,
[dbo].[Kapcsolat].[Datum],
[dbo].[Kapcsolat].[HatarIdo],
[dbo].[Kapcsolat].[Darab],
[dbo].[Kapcsolat].[TeljesAr]
FROM
[dbo].[Kapcsolat]
INNER JOIN 
Ugyfel ON
Kapcsolat.UgyfelID=Ugyfel.Id
INNER JOIN 
Aru ON
Aru.Id=Kapcsolat.AruID
END
GO
/****** Object:  StoredProcedure [dbo].[UgyfelCreate]    Script Date: 12/03/2020 10:10:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
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
GO
/****** Object:  StoredProcedure [dbo].[UgyfelDelete]    Script Date: 12/03/2020 10:10:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UgyfelDelete]
	@Id int
AS
BEGIN
DELETE [dbo].[Ugyfel]
WHERE [dbo].[Ugyfel].[Id] = @Id
END
GO
/****** Object:  StoredProcedure [dbo].[UgyfelGetAll]    Script Date: 12/03/2020 10:10:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UgyfelGetAll]

AS
BEGIN
SELECT
[dbo].[Ugyfel].[Id],
[dbo].[Ugyfel].[Nev],
[dbo].[Ugyfel].[Cim],
[dbo].[Ugyfel].[Telefonszam]
FROM
[dbo].[Ugyfel]
END
GO
/****** Object:  StoredProcedure [dbo].[UgyfelGetByID]    Script Date: 12/03/2020 10:10:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UgyfelGetByID]
	@Id int
AS
BEGIN
SELECT
[dbo].[Ugyfel].[Id],
[dbo].[Ugyfel].[Nev],
[dbo].[Ugyfel].[Cim],
[dbo].[Ugyfel].[Telefonszam]
FROM
[dbo].[Ugyfel]
where
[dbo].[Ugyfel].[Id] = @Id
END
GO
/****** Object:  StoredProcedure [dbo].[UgyfelUpdate]    Script Date: 12/03/2020 10:10:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
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
GO
/****** Object:  Table [dbo].[Aru]    Script Date: 12/03/2020 10:10:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Aru](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nev] [nvarchar](255) NOT NULL,
	[Leiras] [text] NOT NULL,
	[Mennyiseg] [int] NOT NULL,
	[Ar] [int] NOT NULL,
	[Kep] [nvarchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Kapcsolat]    Script Date: 12/03/2020 10:10:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Kapcsolat](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UgyfelID] [int] NOT NULL,
	[AruID] [int] NOT NULL,
	[Datum] [datetime] NOT NULL,
	[HatarIdo] [datetime] NOT NULL,
	[Darab] [int] NOT NULL,
	[TeljesAr] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Ugyfel]    Script Date: 12/03/2020 10:10:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ugyfel](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nev] [nvarchar](255) NOT NULL,
	[Cim] [nvarchar](255) NOT NULL,
	[Telefonszam] [nvarchar](12) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Index [Aruindex]    Script Date: 12/03/2020 10:10:32 ******/
CREATE NONCLUSTERED INDEX [Aruindex] ON [dbo].[Kapcsolat]
(
	[AruID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [ugyfelxindex]    Script Date: 12/03/2020 10:10:32 ******/
CREATE NONCLUSTERED INDEX [ugyfelxindex] ON [dbo].[Kapcsolat]
(
	[UgyfelID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
USE [master]
GO
ALTER DATABASE [gravirozasDB] SET  READ_WRITE 
GO
