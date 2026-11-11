USE [master]
GO

CREATE DATABASE [KN_BD]
GO

USE [KN_BD]
GO

CREATE TABLE [dbo].[tError](
	[IdError] [bigint] IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](max) NOT NULL,
	[FechaHora] [datetime] NOT NULL,
	[Origen] [varchar](50) NOT NULL,
	[IdUsuario] [int] NOT NULL,
 CONSTRAINT [PK_tError] PRIMARY KEY CLUSTERED 
(
	[IdError] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

CREATE TABLE [dbo].[tLibro](
	[IdLibro] [int] IDENTITY(1,1) NOT NULL,
	[Titulo] [varchar](200) NOT NULL,
	[Autor] [varchar](200) NOT NULL,
	[Sinopsis] [varchar](max) NOT NULL,
	[Portada] [varchar](200) NOT NULL,
	[Genero] [varchar](100) NOT NULL,
	[Precio] [decimal](10, 2) NOT NULL,
	[Estado] [bit] NOT NULL,
 CONSTRAINT [PK_tLibro] PRIMARY KEY CLUSTERED 
(
	[IdLibro] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

CREATE TABLE [dbo].[tRol](
	[IdRol] [int] IDENTITY(1,1) NOT NULL,
	[NombreRol] [varchar](100) NOT NULL,
 CONSTRAINT [PK_tRol] PRIMARY KEY CLUSTERED 
(
	[IdRol] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[tUsuario](
	[IdUsuario] [int] IDENTITY(1,1) NOT NULL,
	[Identificacion] [nvarchar](20) NOT NULL,
	[NombreCompleto] [nvarchar](250) NOT NULL,
	[CorreoElectronico] [nvarchar](100) NOT NULL,
	[Contrasenna] [nvarchar](15) NOT NULL,
	[Estado] [bit] NOT NULL,
	[IdRol] [int] NOT NULL,
 CONSTRAINT [PK_tUsuario] PRIMARY KEY CLUSTERED 
(
	[IdUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

SET IDENTITY_INSERT [dbo].[tError] ON 
GO
INSERT [dbo].[tError] ([IdError], [Descripcion], [FechaHora], [Origen], [IdUsuario]) VALUES (1, N'Value cannot be null.
Parameter name: stringToEscape', CAST(N'2026-11-10T19:05:35.893' AS DateTime), N'Libro - ConsultarLibrosAPI', 1)
GO
INSERT [dbo].[tError] ([IdError], [Descripcion], [FechaHora], [Origen], [IdUsuario]) VALUES (2, N'Value cannot be null.
Parameter name: stringToEscape', CAST(N'2026-11-10T19:05:40.317' AS DateTime), N'Libro - ConsultarLibrosAPI', 1)
GO
INSERT [dbo].[tError] ([IdError], [Descripcion], [FechaHora], [Origen], [IdUsuario]) VALUES (3, N'Value cannot be null.
Parameter name: stringToEscape', CAST(N'2026-11-10T19:05:41.470' AS DateTime), N'Libro - ConsultarLibrosAPI', 1)
GO
INSERT [dbo].[tError] ([IdError], [Descripcion], [FechaHora], [Origen], [IdUsuario]) VALUES (4, N'Value cannot be null.
Parameter name: stringToEscape', CAST(N'2026-11-10T19:05:41.923' AS DateTime), N'Libro - ConsultarLibrosAPI', 1)
GO
INSERT [dbo].[tError] ([IdError], [Descripcion], [FechaHora], [Origen], [IdUsuario]) VALUES (5, N'Value cannot be null.
Parameter name: stringToEscape', CAST(N'2026-11-10T19:05:42.313' AS DateTime), N'Libro - ConsultarLibrosAPI', 1)
GO
INSERT [dbo].[tError] ([IdError], [Descripcion], [FechaHora], [Origen], [IdUsuario]) VALUES (6, N'Value cannot be null.
Parameter name: stringToEscape', CAST(N'2026-11-10T19:05:42.680' AS DateTime), N'Libro - ConsultarLibrosAPI', 1)
GO
INSERT [dbo].[tError] ([IdError], [Descripcion], [FechaHora], [Origen], [IdUsuario]) VALUES (7, N'Value cannot be null.
Parameter name: stringToEscape', CAST(N'2026-11-10T19:05:44.363' AS DateTime), N'Libro - ConsultarLibrosAPI', 1)
GO
SET IDENTITY_INSERT [dbo].[tError] OFF
GO

SET IDENTITY_INSERT [dbo].[tLibro] ON 
GO
INSERT [dbo].[tLibro] ([IdLibro], [Titulo], [Autor], [Sinopsis], [Portada], [Genero], [Precio], [Estado]) VALUES (1, N'Superman on the Couch', N'Danny Fingeroth', N'Why are so many of the superhero myths tied up with loss, often violent, of parents or parental figures? What is the significance of the dual identity? What makes some superhuman figures "good" and others "evil"? Why are so many of the prime superheroes white and male? How has the superhero evolved over the course of the 20th and early 21st centuries? And how might the myths be changing? Why is it that the key superhero archetypes - Superman, Batman, Wonder Woman, Spider-Man, the X-Men - touch primal needs and experiences in everyone? Why has the superhero moved beyond the pages of comics into other media? All these topics, and more, are covered in this lively and original exploration of the reasons why the superhero - in comic books, films, and TV - is such a potent myth for our times and culture.>', N'https://books.google.com/books/content?id=lFIyvSxR_SkC&printsec=frontcover&img=1&zoom=1&edge=curl&source=gbs_api', N'Comics & Graphic Novels', CAST(12000.00 AS Decimal(10, 2)), 0)
GO
INSERT [dbo].[tLibro] ([IdLibro], [Titulo], [Autor], [Sinopsis], [Portada], [Genero], [Precio], [Estado]) VALUES (2, N'Percy Jackson and the Titan''s Curse (Book 3)', N'Rick Riordan J', N'The third book in the bestselling Percy Jackson and the Olympians series. Now with a new cover look! Discover the story behind the Disney+ series. HALF BOY - HALF GOD - ALL HERO. It''s not every day you find yourself in combat with a half-lion, half human. . . Percy Jackson has a lot on his plate. A powerful goddess has gone missing. The Greek gods are on the brink of war with the Titans. And there''s the minor threat of a mystery beast that could destroy Mount Olympus forever. This time, Percy''s going to need help and he''s found two powerful demigods for the job. . .There''s just the small problem of the prophecy. The one that has predicted not all of them will survive. But when you''re the son of a Greek god, it happens. Right?', N'https://tse4.mm.bing.net/th/id/OIP.9O7aQWJkHENJPnTqtwJ-PgHaKi?r=0&rs=1&pid=ImgDetMain&o=7&rm=3', N'Juvenile Fictions', CAST(10000.00 AS Decimal(10, 2)), 0)
GO
INSERT [dbo].[tLibro] ([IdLibro], [Titulo], [Autor], [Sinopsis], [Portada], [Genero], [Precio], [Estado]) VALUES (3, N'Pirates of the Caribbean, Jack Sparrow', N'Rob Kidd', N'Meet Disney''s Jack Sparrow', N'https://es.web.img3.acsta.net/pictures/14/03/25/11/14/498694.jpg', N'Adventure stories, American', CAST(15000.00 AS Decimal(10, 2)), 1)
GO
SET IDENTITY_INSERT [dbo].[tLibro] OFF
GO

SET IDENTITY_INSERT [dbo].[tRol] ON 
GO
INSERT [dbo].[tRol] ([IdRol], [NombreRol]) VALUES (1, N'Usuario')
GO
INSERT [dbo].[tRol] ([IdRol], [NombreRol]) VALUES (2, N'Administrador')
GO
SET IDENTITY_INSERT [dbo].[tRol] OFF
GO

SET IDENTITY_INSERT [dbo].[tUsuario] ON 
GO
INSERT [dbo].[tUsuario] ([IdUsuario], [Identificacion], [NombreCompleto], [CorreoElectronico], [Contrasenna], [Estado], [IdRol]) VALUES (1, N'304590415', N'Eduardo', N'ecalvo90415@ufide.ac.cr', N'90415', 1, 2)
GO
INSERT [dbo].[tUsuario] ([IdUsuario], [Identificacion], [NombreCompleto], [CorreoElectronico], [Contrasenna], [Estado], [IdRol]) VALUES (21, N'120060050', N'Alejandro Arroyo', N'aarroyo60050@ufide.ac.cr', N'87654321Sap', 1, 1)
GO
INSERT [dbo].[tUsuario] ([IdUsuario], [Identificacion], [NombreCompleto], [CorreoElectronico], [Contrasenna], [Estado], [IdRol]) VALUES (22, N'119620522', N'Sebastian Lopez', N'slopez20522@ufide.ac.cr', N'224466', 1, 1)
GO
SET IDENTITY_INSERT [dbo].[tUsuario] OFF
GO

ALTER TABLE [dbo].[tUsuario] ADD  CONSTRAINT [UK_CorreoElectronico] UNIQUE NONCLUSTERED 
(
	[CorreoElectronico] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO

ALTER TABLE [dbo].[tUsuario] ADD  CONSTRAINT [UK_Identificacion] UNIQUE NONCLUSTERED 
(
	[Identificacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO

ALTER TABLE [dbo].[tUsuario]  WITH CHECK ADD  CONSTRAINT [FK_tUsuario_tRol] FOREIGN KEY([IdRol])
REFERENCES [dbo].[tRol] ([IdRol])
GO
ALTER TABLE [dbo].[tUsuario] CHECK CONSTRAINT [FK_tUsuario_tRol]
GO

CREATE PROCEDURE [dbo].[sp_IniciarSesionUsuario]
	@CorreoElectronico nvarchar(100),
	@Contrasenna nvarchar(15)
AS
BEGIN

    SELECT  IdUsuario,Identificacion,NombreCompleto,CorreoElectronico,
            Contrasenna,Estado,U.IdRol,R.NombreRol
      FROM  dbo.tUsuario U
      INNER JOIN dbo.tRol R ON U.IdRol = R.IdRol 
      WHERE CorreoElectronico = @CorreoElectronico
        AND Contrasenna = @Contrasenna
        AND Estado = 1

END
GO

CREATE PROCEDURE [dbo].[sp_RegistrarError]
	@Descripcion    varchar(max), 
    @FechaHora      datetime,
    @Origen         varchar(50), 
    @IdUsuario      int
AS
BEGIN

    INSERT INTO tError(Descripcion,FechaHora,Origen,IdUsuario)
    VALUES (@Descripcion, @FechaHora, @Origen, @IdUsuario)

END
GO

CREATE PROCEDURE [dbo].[sp_RegistrarUsuario]
	@Identificacion nvarchar(20),
	@NombreCompleto nvarchar(250),
	@CorreoElectronico nvarchar(100),
	@Contrasenna nvarchar(15)
AS
BEGIN

	DECLARE @EstadoActivo bit = 1
	DECLARE @RolUsuario int = 1
	
    INSERT INTO dbo.tUsuario (Identificacion,NombreCompleto,CorreoElectronico,Contrasenna,Estado,IdRol)
    VALUES (@Identificacion,@NombreCompleto,@CorreoElectronico,@Contrasenna,@EstadoActivo,@RolUsuario)

END
GO