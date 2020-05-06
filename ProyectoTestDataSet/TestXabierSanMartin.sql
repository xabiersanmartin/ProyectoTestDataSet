CREATE DATABASE TestXabierSanMartin

USE [TestXabierSanMartin]
GO
/****** Object:  Table [dbo].[Categorias]    Script Date: 25/03/2020 16:31:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categorias](
	[IdCategoria] [int] NOT NULL IDENTITY,
	[Descripcion] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_TCategorias] PRIMARY KEY CLUSTERED 
(
	[IdCategoria] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CategoriasTests]    Script Date: 25/03/2020 16:31:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CategoriasTests](
	[IdCategoria] [int] NOT NULL,
	[IdTest] [int] NOT NULL,
 CONSTRAINT [PK_TCategoriasTests] PRIMARY KEY CLUSTERED 
(
	[IdCategoria] ASC,
	[IdTest] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Preguntas]    Script Date: 25/03/2020 16:31:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Preguntas](
	[IdPregunta] [int] NOT NULL IDENTITY,
	[Enunciado] [nvarchar](100) NOT NULL,
	[RespV] [bit] NOT NULL,
	[IdTest] [int] NOT NULL,
 CONSTRAINT [PK_TPreguntas] PRIMARY KEY CLUSTERED 
(
	[IdPregunta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Test]    Script Date: 25/03/2020 16:31:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Test](
	[IdTest] [int] NOT NULL IDENTITY,
	[Descripcion] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_TTest] PRIMARY KEY CLUSTERED 
(
	[IdTest] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[CategoriasTests]  WITH CHECK ADD  CONSTRAINT [FK_CategoriasTests_Categorias] FOREIGN KEY([IdCategoria])
REFERENCES [dbo].[Categorias] ([IdCategoria])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CategoriasTests] CHECK CONSTRAINT [FK_CategoriasTests_Categorias]
GO
ALTER TABLE [dbo].[CategoriasTests]  WITH CHECK ADD  CONSTRAINT [FK_CategoriasTests_Test] FOREIGN KEY([IdTest])
REFERENCES [dbo].[Test] ([IdTest])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CategoriasTests] CHECK CONSTRAINT [FK_CategoriasTests_Test]
GO
ALTER TABLE [dbo].[Preguntas]  WITH CHECK ADD  CONSTRAINT [FK_TPreguntas_TTest] FOREIGN KEY([IdTest])
REFERENCES [dbo].[Test] ([IdTest])
GO
ALTER TABLE [dbo].[Preguntas] CHECK CONSTRAINT [FK_TPreguntas_TTest]
GO


INSERT [dbo].[Categorias] ([Descripcion]) VALUES (N'Deporte')
INSERT [dbo].[Categorias] ([Descripcion]) VALUES (N'Historia')
INSERT [dbo].[Categorias] ([Descripcion]) VALUES (N'Geografia')
INSERT [dbo].[Categorias] ([Descripcion]) VALUES (N'Literatura')

INSERT [dbo].[Test] ([Descripcion]) VALUES (N'Futbol')
INSERT [dbo].[Test] ([Descripcion]) VALUES (N'II Guerra Mundial')
INSERT [dbo].[Test] ([Descripcion]) VALUES (N'Paises')
INSERT [dbo].[Test] ([Descripcion]) VALUES (N'Capitales')
INSERT [dbo].[Test] ([Descripcion]) VALUES (N'Primer Imperio Frances')
INSERT [dbo].[Test] ([Descripcion]) VALUES (N'Arte Moderno')

INSERT [dbo].[CategoriasTests] ([IdCategoria], [IdTest]) VALUES (1, 1)
INSERT [dbo].[CategoriasTests] ([IdCategoria], [IdTest]) VALUES (2, 2)
INSERT [dbo].[CategoriasTests] ([IdCategoria], [IdTest]) VALUES (2, 5)
INSERT [dbo].[CategoriasTests] ([IdCategoria], [IdTest]) VALUES (3, 3)
INSERT [dbo].[CategoriasTests] ([IdCategoria], [IdTest]) VALUES (3, 4)
INSERT [dbo].[CategoriasTests] ([IdCategoria], [IdTest]) VALUES (4, 6)

INSERT [dbo].[Preguntas] ([Enunciado], [RespV], [IdTest]) VALUES (N'¿Nacio Napoleon en el año 1769?', 1, 5)
INSERT [dbo].[Preguntas] ([Enunciado], [RespV], [IdTest]) VALUES (N'¿Perdio Napoleon en Waterloo?', 1, 5)
INSERT [dbo].[Preguntas] ([Enunciado], [RespV], [IdTest]) VALUES (N'Leo Messi, juega en el FC Barcelona', 1, 1)
INSERT [dbo].[Preguntas] ([Enunciado], [RespV], [IdTest]) VALUES (N'Moscu pertenece al lado Asiatico', 0, 4)
INSERT [dbo].[Preguntas] ([Enunciado], [RespV], [IdTest]) VALUES (N'España antes era llamado Hispania', 1, 3)
INSERT [dbo].[Preguntas] ([Enunciado], [RespV], [IdTest]) VALUES (N'Estados Unidos tiene 624 millones de habitantes', 0, 3)
INSERT [dbo].[Preguntas] ([Enunciado], [RespV], [IdTest]) VALUES (N'Macedonia es la capital de Albania', 0, 4)
INSERT [dbo].[Preguntas] ([Enunciado], [RespV], [IdTest]) VALUES (N'Fue Henrich Himmler el lider de Auswitch', 1, 2)
INSERT [dbo].[Preguntas] ([Enunciado], [RespV], [IdTest]) VALUES (N'Al final de la guerra cayeron dos bombas atomicas a Nagasaki y Osaka?', 1, 2)
INSERT [dbo].[Preguntas] ([Enunciado], [RespV], [IdTest]) VALUES (N'La noche estrellada fue pintada por Pablo Picasso?', 0, 6)





