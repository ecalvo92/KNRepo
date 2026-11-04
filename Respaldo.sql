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

SET IDENTITY_INSERT [dbo].[tLibro] ON 
GO
INSERT [dbo].[tLibro] ([IdLibro], [Titulo], [Autor], [Sinopsis], [Portada], [Genero], [Precio], [Estado]) VALUES (1, N'Tadeo, aprendiz de pirata', N'MÉNDEZ MONASTERIO, KIKO', N'Para realizar su mayor ilusión, ser pirata, Tadeo, en cuanto tuvo edad, se lanzó al mar en una antigua barquita de pesca, pertrechada ahora con dos cañones y rebautizada con el nombre de “La Espada del Mar”. Sabía Tadeo que lo primero que tenía que hacer era entrevistarse con el gobernador de la Isla del Sable, el famoso pirata Barbagrís, y presentarle sus respetos. Cuando por fin consigue arribar a la isla y presentarse, Barbagrís se ríe de su aspecto enclenque y le comenta que para ser pirata hay que robar oro: sin él, nunca será nadie. Novela de aventuras enmarcada en un ambiente de piratas que parodia y reescribe las normas de tal subgénero adaptándolo además a las claves de la literatura infantil. A partir de un texto ágil y ameno, el autor nos presenta una divertida novela de aventuras, en la que Tadeo, un hombrecillo pequeño y gran marinero, tendrá como principal problema para conseguir su propósito no sólo su aspecto, sino su propia conciencia. A partir de 10 años', N'https://books.google.com/books/content?id=FaSaDwAAQBAJ&printsec=frontcover&img=1&zoom=1&edge=curl&source=gbs_api', N'Juvenile Fiction', CAST(7200.00 AS Decimal(10, 2)), 1)
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