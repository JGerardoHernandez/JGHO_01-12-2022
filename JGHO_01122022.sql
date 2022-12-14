USE [master]
GO
/****** Object:  Database [JGHO_01122022]    Script Date: 20/12/2022 05:49:03 p. m. ******/
CREATE DATABASE [JGHO_01122022]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'JGHO_01122022', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\JGHO_01122022.mdf' , SIZE = 3136KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'JGHO_01122022_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\JGHO_01122022_log.ldf' , SIZE = 784KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [JGHO_01122022] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [JGHO_01122022].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [JGHO_01122022] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [JGHO_01122022] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [JGHO_01122022] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [JGHO_01122022] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [JGHO_01122022] SET ARITHABORT OFF 
GO
ALTER DATABASE [JGHO_01122022] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [JGHO_01122022] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [JGHO_01122022] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [JGHO_01122022] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [JGHO_01122022] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [JGHO_01122022] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [JGHO_01122022] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [JGHO_01122022] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [JGHO_01122022] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [JGHO_01122022] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [JGHO_01122022] SET  ENABLE_BROKER 
GO
ALTER DATABASE [JGHO_01122022] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [JGHO_01122022] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [JGHO_01122022] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [JGHO_01122022] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [JGHO_01122022] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [JGHO_01122022] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [JGHO_01122022] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [JGHO_01122022] SET RECOVERY FULL 
GO
ALTER DATABASE [JGHO_01122022] SET  MULTI_USER 
GO
ALTER DATABASE [JGHO_01122022] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [JGHO_01122022] SET DB_CHAINING OFF 
GO
ALTER DATABASE [JGHO_01122022] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [JGHO_01122022] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
EXEC sys.sp_db_vardecimal_storage_format N'JGHO_01122022', N'ON'
GO
USE [JGHO_01122022]
GO
/****** Object:  StoredProcedure [dbo].[ActualizarAlumno]    Script Date: 20/12/2022 05:49:03 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ActualizarAlumno]
@IdAlumno INT,
@Nombre VARCHAR(50),
@ApellidoPaterno VARCHAR(50),
@ApellidoMaterno VARCHAR(50),
@Imagen VARCHAR (MAX)
AS 
UPDATE Alumno
   SET [Nombre] = @Nombre
      ,[ApellidoPaterno] = @ApellidoPaterno
      ,[ApellidoMaterno] = @ApellidoMaterno
	  ,[Imagen] = @Imagen
 WHERE IdAlumno = @IdAlumno
GO
/****** Object:  StoredProcedure [dbo].[ActualizarAlumnoMateria]    Script Date: 20/12/2022 05:49:03 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ActualizarAlumnoMateria]
@IdAlumnoMateria INT,
@IdAlumno INT,
@IdMateria INT
AS
UPDATE AlumnosMaterias
   SET [IdAlumno] = @IdAlumno
      ,[IdMateria] = @IdMateria
 WHERE IdAlumnoMateria = @IdAlumnoMateria
GO
/****** Object:  StoredProcedure [dbo].[ActualizarMateria]    Script Date: 20/12/2022 05:49:03 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ActualizarMateria]
@IdMateria INT,
@Nombre VARCHAR(50),
@Costo DECIMAL(18,2)
AS
UPDATE Materia
   SET [Nombre] = @Nombre
      ,[Costo] = @Costo
 WHERE IdMateria = @IdMateria
GO
/****** Object:  StoredProcedure [dbo].[EliminarAlumno]    Script Date: 20/12/2022 05:49:03 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[EliminarAlumno]
@IdAlumno INT
AS 
DELETE FROM Alumno
      WHERE IdAlumno = @IdAlumno
GO
/****** Object:  StoredProcedure [dbo].[EliminarAlumnoMateria]    Script Date: 20/12/2022 05:49:03 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[EliminarAlumnoMateria]
@IdMateria INT,
@IdAlumno INT 
AS
DELETE FROM AlumnosMaterias
WHERE IdAlumno = @IdAlumno AND IdMateria = @IdMateria


GO
/****** Object:  StoredProcedure [dbo].[EliminarMateria]    Script Date: 20/12/2022 05:49:03 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[EliminarMateria]
@IdMateria INT
AS
DELETE FROM Materia
      WHERE IdMateria = @IdMateria
GO
/****** Object:  StoredProcedure [dbo].[GetByIdUserName]    Script Date: 20/12/2022 05:49:03 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetByIdUserName]
@UserName VARCHAR(50)
AS 
SELECT 
	Usuario.UserName,
	Usuario.Password,
	Usuario.Nombre,
	Usuario.ApellidoPaterno,
	Usuario.ApellidoMaterno
FROM Usuario
WHERE Usuario.UserName = @UserName
GO
/****** Object:  StoredProcedure [dbo].[InsertAlumno]    Script Date: 20/12/2022 05:49:03 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[InsertAlumno]
@Nombre VARCHAR(50),
@ApellidoPaterno VARCHAR(50),
@ApellidoMaterno VARCHAR(50),
@Imagen VARCHAR(MAX)
AS 
INSERT INTO Alumno
           (Nombre
           ,ApellidoPaterno
           ,ApellidoMaterno
		   ,Imagen)
     VALUES
           (@Nombre
           ,@ApellidoPaterno
           ,@ApellidoMaterno
		   ,@Imagen)
GO
/****** Object:  StoredProcedure [dbo].[InsertAlumnoMateria]    Script Date: 20/12/2022 05:49:03 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[InsertAlumnoMateria]
@IdAlumno INT,
@IdMateria INT
AS
INSERT INTO AlumnosMaterias
           (IdAlumno
           ,IdMateria)
     VALUES
           (@IdAlumno
           ,@IdMateria)
GO
/****** Object:  StoredProcedure [dbo].[InsertMateria]    Script Date: 20/12/2022 05:49:03 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[InsertMateria]
@Nombre VARCHAR(50),
@Costo DECIMAL(18,2)
AS
INSERT INTO Materia
           (Nombre
           ,Costo)
     VALUES
           (@Nombre
           ,@Costo)
GO
/****** Object:  StoredProcedure [dbo].[MateriasNoAsignadasAlumno]    Script Date: 20/12/2022 05:49:03 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[MateriasNoAsignadasAlumno]
@IdAlumno INT
AS
SELECT Materia.IdMateria,-- ISNULL(AlumnosMaterias.IdAlumno,0) AS IdAlumno, ISNULL(AlumnosMaterias.IdAlumnoMateria,0) AS IdAlumnoMateria,
Materia.Nombre, Materia.Costo FROM Materia
--LEFT JOIN AlumnosMaterias
--ON Materia.IdMateria = AlumnosMaterias.IdMateria 
WHERE Materia.IdMateria NOT IN(
SELECT Materia.IdMateria FROM AlumnosMaterias
LEFT JOIN Materia
ON  Materia.IdMateria = AlumnosMaterias.IdMateria
LEFT JOIN Alumno
ON AlumnosMaterias.IdAlumno = Alumno.IdAlumno
WHERE Alumno.IdAlumno = @IdAlumno)


GO
/****** Object:  StoredProcedure [dbo].[ObtenerMateriasAsignadasAlumno]    Script Date: 20/12/2022 05:49:03 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ObtenerMateriasAsignadasAlumno]
@IdAlumno INT
AS
SELECT IdAlumnoMateria,
		AlumnosMaterias.IdAlumno,
		AlumnosMaterias.IdMateria,
		Materia.Nombre AS 'NombreMateria',
		Materia.Costo

FROM AlumnosMaterias

INNER JOIN Materia ON AlumnosMaterias.IdMateria = Materia.IdMateria

WHERE AlumnosMaterias.IdAlumno = @IdAlumno
GO
/****** Object:  StoredProcedure [dbo].[SelectAlumno]    Script Date: 20/12/2022 05:49:03 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SelectAlumno]
AS 
SELECT 
IdAlumno,
Nombre,
ApellidoPaterno,
ApellidoMaterno,
Imagen
FROM Alumno
GO
/****** Object:  StoredProcedure [dbo].[SelectMateria]    Script Date: 20/12/2022 05:49:03 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SelectMateria]
AS
SELECT
Materia.IdMateria,--ISNULL(AlumnosMaterias.IdAlumno,0) AS IdAlumno, ISNULL(AlumnosMaterias.IdAlumnoMateria,0) AS IdAlumnoMateria, 
Materia.Nombre, Materia.Costo FROM Materia
--LEFT JOIN AlumnosMaterias
--ON AlumnosMaterias.IdMateria = Materia.IdMateria 
GO
/****** Object:  StoredProcedure [dbo].[SelectPorIdAlumno]    Script Date: 20/12/2022 05:49:03 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SelectPorIdAlumno]
@IdAlumno INT 
AS 
SELECT 
IdAlumno,
Nombre,
ApellidoPaterno,
ApellidoMaterno,
Imagen
FROM Alumno
WHERE IdAlumno = @IdAlumno
GO
/****** Object:  StoredProcedure [dbo].[SelectPorIdMateria]    Script Date: 20/12/2022 05:49:03 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SelectPorIdMateria]
@IdAlumno INT
AS
SELECT Materia.IdMateria,ISNULL(AlumnosMaterias.IdAlumno,0) AS IdAlumno, ISNULL(AlumnosMaterias.IdAlumnoMateria,0) AS IdAlumnoMateria, Materia.Nombre, Materia.Costo FROM Materia
LEFT JOIN AlumnosMaterias
ON Materia.IdMateria = AlumnosMaterias.IdMateria 
WHERE Materia.IdMateria = @IdAlumno
GO
/****** Object:  Table [dbo].[Alumno]    Script Date: 20/12/2022 05:49:03 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Alumno](
	[IdAlumno] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NULL,
	[ApellidoPaterno] [varchar](50) NULL,
	[ApellidoMaterno] [varchar](50) NULL,
	[Imagen] [varchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[IdAlumno] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[AlumnosMaterias]    Script Date: 20/12/2022 05:49:03 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AlumnosMaterias](
	[IdAlumnoMateria] [int] IDENTITY(1,1) NOT NULL,
	[IdAlumno] [int] NULL,
	[IdMateria] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdAlumnoMateria] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Materia]    Script Date: 20/12/2022 05:49:03 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Materia](
	[IdMateria] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NULL,
	[Costo] [decimal](18, 2) NULL,
PRIMARY KEY CLUSTERED 
(
	[IdMateria] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 20/12/2022 05:49:03 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Usuario](
	[UserName] [varchar](50) NULL,
	[Password] [varchar](50) NULL,
	[Nombre] [varchar](50) NULL,
	[ApellidoPaterno] [varchar](50) NULL,
	[ApellidoMaterno] [varchar](50) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Alumno] ON 

INSERT [dbo].[Alumno] ([IdAlumno], [Nombre], [ApellidoPaterno], [ApellidoMaterno], [Imagen]) VALUES (1, N'Jose Gerardo', N'Hernandez', N'Ortega', N'')
INSERT [dbo].[Alumno] ([IdAlumno], [Nombre], [ApellidoPaterno], [ApellidoMaterno], [Imagen]) VALUES (2, N'Leonardo', N'Escogido', N'Perez', N'')
INSERT [dbo].[Alumno] ([IdAlumno], [Nombre], [ApellidoPaterno], [ApellidoMaterno], [Imagen]) VALUES (3, N'Luis1', N'Rodriguez', N'Domingo', N'')
INSERT [dbo].[Alumno] ([IdAlumno], [Nombre], [ApellidoPaterno], [ApellidoMaterno], [Imagen]) VALUES (4, N'Edgar', N'Ortega', N'Perez', N'')
INSERT [dbo].[Alumno] ([IdAlumno], [Nombre], [ApellidoPaterno], [ApellidoMaterno], [Imagen]) VALUES (11, N'Javier', N'Montes', N'Montes', N'')
SET IDENTITY_INSERT [dbo].[Alumno] OFF
SET IDENTITY_INSERT [dbo].[AlumnosMaterias] ON 

INSERT [dbo].[AlumnosMaterias] ([IdAlumnoMateria], [IdAlumno], [IdMateria]) VALUES (39, 1, 1)
INSERT [dbo].[AlumnosMaterias] ([IdAlumnoMateria], [IdAlumno], [IdMateria]) VALUES (40, 2, 1)
INSERT [dbo].[AlumnosMaterias] ([IdAlumnoMateria], [IdAlumno], [IdMateria]) VALUES (41, 3, 1)
INSERT [dbo].[AlumnosMaterias] ([IdAlumnoMateria], [IdAlumno], [IdMateria]) VALUES (42, 1, 2)
INSERT [dbo].[AlumnosMaterias] ([IdAlumnoMateria], [IdAlumno], [IdMateria]) VALUES (43, 2, 2)
INSERT [dbo].[AlumnosMaterias] ([IdAlumnoMateria], [IdAlumno], [IdMateria]) VALUES (44, 3, 3)
INSERT [dbo].[AlumnosMaterias] ([IdAlumnoMateria], [IdAlumno], [IdMateria]) VALUES (45, 2, 3)
INSERT [dbo].[AlumnosMaterias] ([IdAlumnoMateria], [IdAlumno], [IdMateria]) VALUES (46, 4, 3)
INSERT [dbo].[AlumnosMaterias] ([IdAlumnoMateria], [IdAlumno], [IdMateria]) VALUES (47, 4, 2)
INSERT [dbo].[AlumnosMaterias] ([IdAlumnoMateria], [IdAlumno], [IdMateria]) VALUES (48, 4, 1)
INSERT [dbo].[AlumnosMaterias] ([IdAlumnoMateria], [IdAlumno], [IdMateria]) VALUES (49, 1, 3)
INSERT [dbo].[AlumnosMaterias] ([IdAlumnoMateria], [IdAlumno], [IdMateria]) VALUES (50, 3, 2)
INSERT [dbo].[AlumnosMaterias] ([IdAlumnoMateria], [IdAlumno], [IdMateria]) VALUES (51, 11, 2)
INSERT [dbo].[AlumnosMaterias] ([IdAlumnoMateria], [IdAlumno], [IdMateria]) VALUES (52, 11, 1)
INSERT [dbo].[AlumnosMaterias] ([IdAlumnoMateria], [IdAlumno], [IdMateria]) VALUES (53, 11, 3)
INSERT [dbo].[AlumnosMaterias] ([IdAlumnoMateria], [IdAlumno], [IdMateria]) VALUES (54, 1, 18)
INSERT [dbo].[AlumnosMaterias] ([IdAlumnoMateria], [IdAlumno], [IdMateria]) VALUES (55, 2, 18)
INSERT [dbo].[AlumnosMaterias] ([IdAlumnoMateria], [IdAlumno], [IdMateria]) VALUES (56, 11, 18)
SET IDENTITY_INSERT [dbo].[AlumnosMaterias] OFF
SET IDENTITY_INSERT [dbo].[Materia] ON 

INSERT [dbo].[Materia] ([IdMateria], [Nombre], [Costo]) VALUES (1, N'Matematicas', CAST(150.00 AS Decimal(18, 2)))
INSERT [dbo].[Materia] ([IdMateria], [Nombre], [Costo]) VALUES (2, N'Ingles1', CAST(200.00 AS Decimal(18, 2)))
INSERT [dbo].[Materia] ([IdMateria], [Nombre], [Costo]) VALUES (3, N'Ciencias Naturales 1', CAST(350.00 AS Decimal(18, 2)))
INSERT [dbo].[Materia] ([IdMateria], [Nombre], [Costo]) VALUES (18, N'Fisica', CAST(400.00 AS Decimal(18, 2)))
SET IDENTITY_INSERT [dbo].[Materia] OFF
INSERT [dbo].[Usuario] ([UserName], [Password], [Nombre], [ApellidoPaterno], [ApellidoMaterno]) VALUES (N'gerardo', N'1997', N'Jose', N'Hernandez', N'Ortega')
INSERT [dbo].[Usuario] ([UserName], [Password], [Nombre], [ApellidoPaterno], [ApellidoMaterno]) VALUES (N'gerard', N'1998', N'Gerardo', N'Ramirez', N'Perez')
INSERT [dbo].[Usuario] ([UserName], [Password], [Nombre], [ApellidoPaterno], [ApellidoMaterno]) VALUES (N'omar', N'1999', N'Omar', N'Rosales', N'Montes')
ALTER TABLE [dbo].[AlumnosMaterias]  WITH CHECK ADD FOREIGN KEY([IdAlumno])
REFERENCES [dbo].[Alumno] ([IdAlumno])
GO
ALTER TABLE [dbo].[AlumnosMaterias]  WITH CHECK ADD FOREIGN KEY([IdMateria])
REFERENCES [dbo].[Materia] ([IdMateria])
GO
USE [master]
GO
ALTER DATABASE [JGHO_01122022] SET  READ_WRITE 
GO
