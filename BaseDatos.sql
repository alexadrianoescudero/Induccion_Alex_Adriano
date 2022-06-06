create database DemoPichincha
go
USE [DemoPichincha]
GO
/****** Object:  Table [dbo].[Asignacioncliente]    Script Date: 6/6/2022 9:44:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Asignacioncliente](
	[ac_Id] [int] IDENTITY(1,1) NOT NULL,
	[ac_Identificacion_cliente] [varchar](10) NOT NULL,
	[ac_id_Patio] [int] NOT NULL,
	[ac_fecha_creacion] [datetime] NOT NULL,
 CONSTRAINT [PK_Asignacioncliente] PRIMARY KEY CLUSTERED 
(
	[ac_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cliente]    Script Date: 6/6/2022 9:44:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cliente](
	[cl_identificacion] [varchar](10) NOT NULL,
	[cl_nombres] [varchar](50) NOT NULL,
	[cl_edad] [int] NOT NULL,
	[cl_fecha_nacimiento] [date] NOT NULL,
	[cl_apellidos] [varchar](50) NOT NULL,
	[cl_direccion] [varchar](50) NOT NULL,
	[cl_telefono] [varchar](10) NOT NULL,
	[cl_estado_civil] [int] NOT NULL,
	[cl_identificacion_conyugue] [varchar](10) NOT NULL,
	[cl_nombre_conyugue] [varchar](50) NOT NULL,
	[cl_sujeto_credito] [int] NULL,
 CONSTRAINT [PK_Cliente_1] PRIMARY KEY CLUSTERED 
(
	[cl_identificacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ejecutivo]    Script Date: 6/6/2022 9:44:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ejecutivo](
	[ej_identificacion] [varchar](10) NOT NULL,
	[ej_nombre] [varchar](50) NOT NULL,
	[ej_apellido] [varchar](50) NOT NULL,
	[ej_direccion] [varchar](50) NOT NULL,
	[ej_telefono] [varchar](15) NOT NULL,
	[ej_celular] [varchar](15) NOT NULL,
	[ej_edad] [int] NOT NULL,
	[ej_Patio] [int] NOT NULL,
 CONSTRAINT [PK_Ejecutivo_1] PRIMARY KEY CLUSTERED 
(
	[ej_identificacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Marca]    Script Date: 6/6/2022 9:44:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Marca](
	[ma_id] [int] IDENTITY(1,1) NOT NULL,
	[ma_nombre] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Marca] PRIMARY KEY CLUSTERED 
(
	[ma_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Patio]    Script Date: 6/6/2022 9:44:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Patio](
	[pa_id] [int] IDENTITY(1,1) NOT NULL,
	[pa_nombre] [varchar](50) NOT NULL,
	[pa_direccion] [varchar](50) NOT NULL,
	[pa_telefono] [varchar](10) NOT NULL,
	[pa_numero_punto_venta] [int] NOT NULL,
 CONSTRAINT [PK_Patio] PRIMARY KEY CLUSTERED 
(
	[pa_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SolicitudCredito]    Script Date: 6/6/2022 9:44:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SolicitudCredito](
	[sc_id] [int] IDENTITY(1,1) NOT NULL,
	[sc_identificacion_cliente] [varchar](10) NOT NULL,
	[sc_Patio] [int] NOT NULL,
	[sc_Vehiculo] [int] NOT NULL,
	[sc_meses_plazo] [int] NOT NULL,
	[sc_cuotas] [int] NOT NULL,
	[sc_entrada] [money] NOT NULL,
	[sc_identificacion_ejecutivo] [varchar](10) NOT NULL,
	[sc_observacion] [varchar](max) NULL,
	[sc_estado] [int] NOT NULL,
 CONSTRAINT [PK_SolicitudCredito] PRIMARY KEY CLUSTERED 
(
	[sc_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Vehiculo]    Script Date: 6/6/2022 9:44:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Vehiculo](
	[ve_id] [int] IDENTITY(1,1) NOT NULL,
	[ve_placa] [varchar](8) NOT NULL,
	[ve_modelo] [varchar](50) NOT NULL,
	[ve_numero_chasis] [varchar](50) NOT NULL,
	[ve_marca_id] [int] NOT NULL,
	[ve_tipo] [varchar](50) NOT NULL,
	[ve_cilindraje] [varchar](50) NOT NULL,
	[ve_avaluo] [money] NOT NULL,
 CONSTRAINT [PK_Vehiculo] PRIMARY KEY CLUSTERED 
(
	[ve_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Asignacioncliente] ON 
GO
INSERT [dbo].[Asignacioncliente] ([ac_Id], [ac_Identificacion_cliente], [ac_id_Patio], [ac_fecha_creacion]) VALUES (4, N'0604434970', 1, CAST(N'2022-06-03T16:13:44.277' AS DateTime))
GO
INSERT [dbo].[Asignacioncliente] ([ac_Id], [ac_Identificacion_cliente], [ac_id_Patio], [ac_fecha_creacion]) VALUES (12, N'0604434970', 1, CAST(N'2022-06-03T17:09:46.160' AS DateTime))
GO
INSERT [dbo].[Asignacioncliente] ([ac_Id], [ac_Identificacion_cliente], [ac_id_Patio], [ac_fecha_creacion]) VALUES (13, N'0604434970', 1, CAST(N'2022-06-04T19:36:03.117' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[Asignacioncliente] OFF
GO
INSERT [dbo].[Cliente] ([cl_identificacion], [cl_nombres], [cl_edad], [cl_fecha_nacimiento], [cl_apellidos], [cl_direccion], [cl_telefono], [cl_estado_civil], [cl_identificacion_conyugue], [cl_nombre_conyugue], [cl_sujeto_credito]) VALUES (N'0604434970', N'Cliente10 Modificado', 28, CAST(N'1994-05-05' AS Date), N' Apellido10', N'Direccion10', N'0995691211', 3, N'0604434570', N'Conyugue10', 1)
GO
INSERT [dbo].[Cliente] ([cl_identificacion], [cl_nombres], [cl_edad], [cl_fecha_nacimiento], [cl_apellidos], [cl_direccion], [cl_telefono], [cl_estado_civil], [cl_identificacion_conyugue], [cl_nombre_conyugue], [cl_sujeto_credito]) VALUES (N'0604434971', N'Cliente1', 28, CAST(N'1994-05-05' AS Date), N'Apellido1', N'Direcci?n1', N'0995691214', 1, N'0604434571', N'Conyugue1', 1)
GO
INSERT [dbo].[Cliente] ([cl_identificacion], [cl_nombres], [cl_edad], [cl_fecha_nacimiento], [cl_apellidos], [cl_direccion], [cl_telefono], [cl_estado_civil], [cl_identificacion_conyugue], [cl_nombre_conyugue], [cl_sujeto_credito]) VALUES (N'0604434972', N'Cliente2', 28, CAST(N'1994-05-05' AS Date), N'Apellido2', N'Direcci?n2', N'0995691214', 2, N'0604434572', N'Conyugue2', 1)
GO
INSERT [dbo].[Cliente] ([cl_identificacion], [cl_nombres], [cl_edad], [cl_fecha_nacimiento], [cl_apellidos], [cl_direccion], [cl_telefono], [cl_estado_civil], [cl_identificacion_conyugue], [cl_nombre_conyugue], [cl_sujeto_credito]) VALUES (N'0604434973', N'Cliente3', 28, CAST(N'1994-05-05' AS Date), N'Apellido3', N'Direcci?n3', N'0995691214', 1, N'0604434573', N'Conyugue3', 1)
GO
INSERT [dbo].[Cliente] ([cl_identificacion], [cl_nombres], [cl_edad], [cl_fecha_nacimiento], [cl_apellidos], [cl_direccion], [cl_telefono], [cl_estado_civil], [cl_identificacion_conyugue], [cl_nombre_conyugue], [cl_sujeto_credito]) VALUES (N'0604434974', N'Cliente4', 28, CAST(N'1994-05-05' AS Date), N'Apellido4', N'Direcci?n4', N'0995691214', 3, N'0604434574', N'Conyugue4', 1)
GO
INSERT [dbo].[Cliente] ([cl_identificacion], [cl_nombres], [cl_edad], [cl_fecha_nacimiento], [cl_apellidos], [cl_direccion], [cl_telefono], [cl_estado_civil], [cl_identificacion_conyugue], [cl_nombre_conyugue], [cl_sujeto_credito]) VALUES (N'0604434975', N'Cliente5', 28, CAST(N'1994-05-05' AS Date), N'Apellido5', N'Direccion5', N'0995691211', 3, N'0604434575', N'Conyugue5', 1)
GO
INSERT [dbo].[Cliente] ([cl_identificacion], [cl_nombres], [cl_edad], [cl_fecha_nacimiento], [cl_apellidos], [cl_direccion], [cl_telefono], [cl_estado_civil], [cl_identificacion_conyugue], [cl_nombre_conyugue], [cl_sujeto_credito]) VALUES (N'0604434976', N'Cliente6', 28, CAST(N'1994-05-05' AS Date), N'Apellido6', N'Direccion6', N'0995691211', 3, N'0604434576', N'Conyugue6', 1)
GO
INSERT [dbo].[Cliente] ([cl_identificacion], [cl_nombres], [cl_edad], [cl_fecha_nacimiento], [cl_apellidos], [cl_direccion], [cl_telefono], [cl_estado_civil], [cl_identificacion_conyugue], [cl_nombre_conyugue], [cl_sujeto_credito]) VALUES (N'0604434977', N'Cliente7', 28, CAST(N'1994-05-05' AS Date), N'Apellido7', N'Direccion7', N'0995691211', 3, N'0604434577', N'Conyugue7', 1)
GO
INSERT [dbo].[Cliente] ([cl_identificacion], [cl_nombres], [cl_edad], [cl_fecha_nacimiento], [cl_apellidos], [cl_direccion], [cl_telefono], [cl_estado_civil], [cl_identificacion_conyugue], [cl_nombre_conyugue], [cl_sujeto_credito]) VALUES (N'0604434978', N'Cliente8', 28, CAST(N'1994-05-05' AS Date), N'Apellido8', N'Direccion8', N'0995691211', 3, N'0604434578', N'Conyugue8', 1)
GO
INSERT [dbo].[Cliente] ([cl_identificacion], [cl_nombres], [cl_edad], [cl_fecha_nacimiento], [cl_apellidos], [cl_direccion], [cl_telefono], [cl_estado_civil], [cl_identificacion_conyugue], [cl_nombre_conyugue], [cl_sujeto_credito]) VALUES (N'0604434979', N'Cliente9', 28, CAST(N'1994-05-05' AS Date), N'Apellido9', N'Direccion9', N'0995691211', 3, N'0604434579', N'Conyugue9', 1)
GO
INSERT [dbo].[Cliente] ([cl_identificacion], [cl_nombres], [cl_edad], [cl_fecha_nacimiento], [cl_apellidos], [cl_direccion], [cl_telefono], [cl_estado_civil], [cl_identificacion_conyugue], [cl_nombre_conyugue], [cl_sujeto_credito]) VALUES (N'0604434980', N'Cliente20', 28, CAST(N'1994-05-05' AS Date), N'Apellido20', N'Direccion20', N'0995691211', 3, N'0604434580', N'Conyugue20', 0)
GO
INSERT [dbo].[Cliente] ([cl_identificacion], [cl_nombres], [cl_edad], [cl_fecha_nacimiento], [cl_apellidos], [cl_direccion], [cl_telefono], [cl_estado_civil], [cl_identificacion_conyugue], [cl_nombre_conyugue], [cl_sujeto_credito]) VALUES (N'0604434981', N'Cliente11', 28, CAST(N'1994-05-05' AS Date), N'Apellido11', N'Direccion11', N'0995691211', 3, N'0604434581', N'Conyugue11', 1)
GO
INSERT [dbo].[Cliente] ([cl_identificacion], [cl_nombres], [cl_edad], [cl_fecha_nacimiento], [cl_apellidos], [cl_direccion], [cl_telefono], [cl_estado_civil], [cl_identificacion_conyugue], [cl_nombre_conyugue], [cl_sujeto_credito]) VALUES (N'0604434982', N'Cliente12', 28, CAST(N'1994-05-05' AS Date), N'Apellido12', N'Direccion12', N'0995691211', 3, N'0604434582', N'Conyugue12', 1)
GO
INSERT [dbo].[Cliente] ([cl_identificacion], [cl_nombres], [cl_edad], [cl_fecha_nacimiento], [cl_apellidos], [cl_direccion], [cl_telefono], [cl_estado_civil], [cl_identificacion_conyugue], [cl_nombre_conyugue], [cl_sujeto_credito]) VALUES (N'0604434983', N'Cliente13', 28, CAST(N'1994-05-05' AS Date), N'Apellido13', N'Direccion13', N'0995691211', 3, N'0604434583', N'Conyugue13', 1)
GO
INSERT [dbo].[Cliente] ([cl_identificacion], [cl_nombres], [cl_edad], [cl_fecha_nacimiento], [cl_apellidos], [cl_direccion], [cl_telefono], [cl_estado_civil], [cl_identificacion_conyugue], [cl_nombre_conyugue], [cl_sujeto_credito]) VALUES (N'0604434984', N'Cliente14', 28, CAST(N'1994-05-05' AS Date), N'Apellido14', N'Direccion14', N'0995691211', 3, N'0604434584', N'Conyugue14', 1)
GO
INSERT [dbo].[Cliente] ([cl_identificacion], [cl_nombres], [cl_edad], [cl_fecha_nacimiento], [cl_apellidos], [cl_direccion], [cl_telefono], [cl_estado_civil], [cl_identificacion_conyugue], [cl_nombre_conyugue], [cl_sujeto_credito]) VALUES (N'0604434985', N'Cliente15', 28, CAST(N'1994-05-05' AS Date), N'Apellido15', N'Direccion15', N'0995691211', 3, N'0604434585', N'Conyugue15', 1)
GO
INSERT [dbo].[Cliente] ([cl_identificacion], [cl_nombres], [cl_edad], [cl_fecha_nacimiento], [cl_apellidos], [cl_direccion], [cl_telefono], [cl_estado_civil], [cl_identificacion_conyugue], [cl_nombre_conyugue], [cl_sujeto_credito]) VALUES (N'0604434986', N'Cliente16', 28, CAST(N'1994-05-05' AS Date), N'Apellido16', N'Direccion16', N'0995691211', 3, N'0604434586', N'Conyugue16', 0)
GO
INSERT [dbo].[Cliente] ([cl_identificacion], [cl_nombres], [cl_edad], [cl_fecha_nacimiento], [cl_apellidos], [cl_direccion], [cl_telefono], [cl_estado_civil], [cl_identificacion_conyugue], [cl_nombre_conyugue], [cl_sujeto_credito]) VALUES (N'0604434987', N'Cliente17', 28, CAST(N'1994-05-05' AS Date), N'Apellido17', N'Direccion17', N'0995691211', 3, N'0604434587', N'Conyugue17', 0)
GO
INSERT [dbo].[Cliente] ([cl_identificacion], [cl_nombres], [cl_edad], [cl_fecha_nacimiento], [cl_apellidos], [cl_direccion], [cl_telefono], [cl_estado_civil], [cl_identificacion_conyugue], [cl_nombre_conyugue], [cl_sujeto_credito]) VALUES (N'0604434988', N'Cliente18', 28, CAST(N'1994-05-05' AS Date), N'Apellido18', N'Direccion18', N'0995691211', 3, N'0604434588', N'Conyugue18', 0)
GO
INSERT [dbo].[Cliente] ([cl_identificacion], [cl_nombres], [cl_edad], [cl_fecha_nacimiento], [cl_apellidos], [cl_direccion], [cl_telefono], [cl_estado_civil], [cl_identificacion_conyugue], [cl_nombre_conyugue], [cl_sujeto_credito]) VALUES (N'0604434989', N'Cliente19', 28, CAST(N'1994-05-05' AS Date), N'Apellido19', N'Direccion19', N'0995691211', 3, N'0604434589', N'Conyugue19', 0)
GO
INSERT [dbo].[Ejecutivo] ([ej_identificacion], [ej_nombre], [ej_apellido], [ej_direccion], [ej_telefono], [ej_celular], [ej_edad], [ej_Patio]) VALUES (N'0604434570', N'Nombre10', N'Apellido10', N'Guayllabamba', N'022222222', N'0999999999', 27, 1)
GO
INSERT [dbo].[Ejecutivo] ([ej_identificacion], [ej_nombre], [ej_apellido], [ej_direccion], [ej_telefono], [ej_celular], [ej_edad], [ej_Patio]) VALUES (N'0604434571', N'Nombre1', N'Apellido1', N'Guayllabamba', N'022222222', N'0999999999', 27, 1)
GO
INSERT [dbo].[Ejecutivo] ([ej_identificacion], [ej_nombre], [ej_apellido], [ej_direccion], [ej_telefono], [ej_celular], [ej_edad], [ej_Patio]) VALUES (N'0604434572', N'Nombre2', N'Apellido2', N'Guayllabamba', N'022222222', N'0999999999', 27, 1)
GO
INSERT [dbo].[Ejecutivo] ([ej_identificacion], [ej_nombre], [ej_apellido], [ej_direccion], [ej_telefono], [ej_celular], [ej_edad], [ej_Patio]) VALUES (N'0604434573', N'Nombre3', N'Apellido3', N'Guayllabamba', N'022222222', N'0999999999', 27, 1)
GO
INSERT [dbo].[Ejecutivo] ([ej_identificacion], [ej_nombre], [ej_apellido], [ej_direccion], [ej_telefono], [ej_celular], [ej_edad], [ej_Patio]) VALUES (N'0604434574', N'Nombre4', N'Apellido4', N'Guayllabamba', N'022222222', N'0999999999', 27, 1)
GO
INSERT [dbo].[Ejecutivo] ([ej_identificacion], [ej_nombre], [ej_apellido], [ej_direccion], [ej_telefono], [ej_celular], [ej_edad], [ej_Patio]) VALUES (N'0604434575', N'Nombre5', N'Apellido5', N'Guayllabamba', N'022222222', N'0999999999', 27, 1)
GO
INSERT [dbo].[Ejecutivo] ([ej_identificacion], [ej_nombre], [ej_apellido], [ej_direccion], [ej_telefono], [ej_celular], [ej_edad], [ej_Patio]) VALUES (N'0604434576', N'Nombre6', N'Apellido6', N'Guayllabamba', N'022222222', N'0999999999', 27, 1)
GO
INSERT [dbo].[Ejecutivo] ([ej_identificacion], [ej_nombre], [ej_apellido], [ej_direccion], [ej_telefono], [ej_celular], [ej_edad], [ej_Patio]) VALUES (N'0604434577', N'Nombre7', N'Apellido7', N'Guayllabamba', N'022222222', N'0999999999', 27, 1)
GO
INSERT [dbo].[Ejecutivo] ([ej_identificacion], [ej_nombre], [ej_apellido], [ej_direccion], [ej_telefono], [ej_celular], [ej_edad], [ej_Patio]) VALUES (N'0604434578', N'Nombre8', N'Apellido8', N'Guayllabamba', N'022222222', N'0999999999', 27, 1)
GO
INSERT [dbo].[Ejecutivo] ([ej_identificacion], [ej_nombre], [ej_apellido], [ej_direccion], [ej_telefono], [ej_celular], [ej_edad], [ej_Patio]) VALUES (N'0604434579', N'Nombre9', N'Apellido9', N'Guayllabamba', N'022222222', N'0999999999', 27, 1)
GO
INSERT [dbo].[Ejecutivo] ([ej_identificacion], [ej_nombre], [ej_apellido], [ej_direccion], [ej_telefono], [ej_celular], [ej_edad], [ej_Patio]) VALUES (N'0604434580', N'Nombre20', N'Apellido20', N'Guayllabamba', N'022222222', N'0999999999', 27, 1)
GO
INSERT [dbo].[Ejecutivo] ([ej_identificacion], [ej_nombre], [ej_apellido], [ej_direccion], [ej_telefono], [ej_celular], [ej_edad], [ej_Patio]) VALUES (N'0604434581', N'Nombre11', N'Apellido11', N'Guayllabamba', N'022222222', N'0999999999', 27, 1)
GO
INSERT [dbo].[Ejecutivo] ([ej_identificacion], [ej_nombre], [ej_apellido], [ej_direccion], [ej_telefono], [ej_celular], [ej_edad], [ej_Patio]) VALUES (N'0604434582', N'Nombre12', N'Apellido12', N'Guayllabamba', N'022222222', N'0999999999', 27, 1)
GO
INSERT [dbo].[Ejecutivo] ([ej_identificacion], [ej_nombre], [ej_apellido], [ej_direccion], [ej_telefono], [ej_celular], [ej_edad], [ej_Patio]) VALUES (N'0604434583', N'Nombre13', N'Apellido13', N'Guayllabamba', N'022222222', N'0999999999', 27, 1)
GO
INSERT [dbo].[Ejecutivo] ([ej_identificacion], [ej_nombre], [ej_apellido], [ej_direccion], [ej_telefono], [ej_celular], [ej_edad], [ej_Patio]) VALUES (N'0604434584', N'Nombre14', N'Apellido14', N'Guayllabamba', N'022222222', N'0999999999', 27, 1)
GO
INSERT [dbo].[Ejecutivo] ([ej_identificacion], [ej_nombre], [ej_apellido], [ej_direccion], [ej_telefono], [ej_celular], [ej_edad], [ej_Patio]) VALUES (N'0604434585', N'Nombre15', N'Apellido15', N'Guayllabamba', N'022222222', N'0999999999', 27, 1)
GO
INSERT [dbo].[Ejecutivo] ([ej_identificacion], [ej_nombre], [ej_apellido], [ej_direccion], [ej_telefono], [ej_celular], [ej_edad], [ej_Patio]) VALUES (N'0604434586', N'Nombre16', N'Apellido16', N'Guayllabamba', N'022222222', N'0999999999', 27, 1)
GO
INSERT [dbo].[Ejecutivo] ([ej_identificacion], [ej_nombre], [ej_apellido], [ej_direccion], [ej_telefono], [ej_celular], [ej_edad], [ej_Patio]) VALUES (N'0604434587', N'Nombre17', N'Apellido17', N'Guayllabamba', N'022222222', N'0999999999', 27, 1)
GO
INSERT [dbo].[Ejecutivo] ([ej_identificacion], [ej_nombre], [ej_apellido], [ej_direccion], [ej_telefono], [ej_celular], [ej_edad], [ej_Patio]) VALUES (N'0604434588', N'Nombre18', N'Apellido18', N'Guayllabamba', N'022222222', N'0999999999', 27, 1)
GO
INSERT [dbo].[Ejecutivo] ([ej_identificacion], [ej_nombre], [ej_apellido], [ej_direccion], [ej_telefono], [ej_celular], [ej_edad], [ej_Patio]) VALUES (N'0604434589', N'Nombre19', N'Apellido19', N'Guayllabamba', N'022222222', N'0999999999', 27, 1)
GO
SET IDENTITY_INSERT [dbo].[Marca] ON 
GO
INSERT [dbo].[Marca] ([ma_id], [ma_nombre]) VALUES (1017, N'Chevrolet')
GO
INSERT [dbo].[Marca] ([ma_id], [ma_nombre]) VALUES (1018, N'KIA')
GO
INSERT [dbo].[Marca] ([ma_id], [ma_nombre]) VALUES (1019, N'Hyundai')
GO
INSERT [dbo].[Marca] ([ma_id], [ma_nombre]) VALUES (1020, N'Toyota')
GO
INSERT [dbo].[Marca] ([ma_id], [ma_nombre]) VALUES (1021, N'Great Wall')
GO
INSERT [dbo].[Marca] ([ma_id], [ma_nombre]) VALUES (1022, N'JAC')
GO
INSERT [dbo].[Marca] ([ma_id], [ma_nombre]) VALUES (1023, N'Chery')
GO
INSERT [dbo].[Marca] ([ma_id], [ma_nombre]) VALUES (1024, N'Renault')
GO
SET IDENTITY_INSERT [dbo].[Marca] OFF
GO
SET IDENTITY_INSERT [dbo].[Patio] ON 
GO
INSERT [dbo].[Patio] ([pa_id], [pa_nombre], [pa_direccion], [pa_telefono], [pa_numero_punto_venta]) VALUES (1, N'Matriz', N'NNUU', N'02222222', 1)
GO
INSERT [dbo].[Patio] ([pa_id], [pa_nombre], [pa_direccion], [pa_telefono], [pa_numero_punto_venta]) VALUES (2, N'Patio dos Modificado', N'Solca', N'0912123456', 0)
GO
SET IDENTITY_INSERT [dbo].[Patio] OFF
GO
SET IDENTITY_INSERT [dbo].[SolicitudCredito] ON 
GO
INSERT [dbo].[SolicitudCredito] ([sc_id], [sc_identificacion_cliente], [sc_Patio], [sc_Vehiculo], [sc_meses_plazo], [sc_cuotas], [sc_entrada], [sc_identificacion_ejecutivo], [sc_observacion], [sc_estado]) VALUES (3, N'0604434970', 1, 4, 10, 1000, 500.0000, N'0604434571', N'hola', 2)
GO
INSERT [dbo].[SolicitudCredito] ([sc_id], [sc_identificacion_cliente], [sc_Patio], [sc_Vehiculo], [sc_meses_plazo], [sc_cuotas], [sc_entrada], [sc_identificacion_ejecutivo], [sc_observacion], [sc_estado]) VALUES (11, N'0604434970', 1, 5, 10, 1000, 500.0000, N'0604434571', N'hola', 1)
GO
INSERT [dbo].[SolicitudCredito] ([sc_id], [sc_identificacion_cliente], [sc_Patio], [sc_Vehiculo], [sc_meses_plazo], [sc_cuotas], [sc_entrada], [sc_identificacion_ejecutivo], [sc_observacion], [sc_estado]) VALUES (12, N'0604434970', 1, 4, 10, 1000, 500.0000, N'0604434571', N'Ninguna', 1)
GO
SET IDENTITY_INSERT [dbo].[SolicitudCredito] OFF
GO
SET IDENTITY_INSERT [dbo].[Vehiculo] ON 
GO
INSERT [dbo].[Vehiculo] ([ve_id], [ve_placa], [ve_modelo], [ve_numero_chasis], [ve_marca_id], [ve_tipo], [ve_cilindraje], [ve_avaluo]) VALUES (4, N'ppp-1233', N'Basico', N'23', 1018, N'Pequeno', N'200', 10000.0000)
GO
INSERT [dbo].[Vehiculo] ([ve_id], [ve_placa], [ve_modelo], [ve_numero_chasis], [ve_marca_id], [ve_tipo], [ve_cilindraje], [ve_avaluo]) VALUES (5, N'ppp-3211', N'Medio', N'233', 1018, N'gRANDE', N'100', 100000.0000)
GO
SET IDENTITY_INSERT [dbo].[Vehiculo] OFF
GO
ALTER TABLE [dbo].[Asignacioncliente]  WITH CHECK ADD  CONSTRAINT [FK_Asignacioncliente_Cliente] FOREIGN KEY([ac_Identificacion_cliente])
REFERENCES [dbo].[Cliente] ([cl_identificacion])
GO
ALTER TABLE [dbo].[Asignacioncliente] CHECK CONSTRAINT [FK_Asignacioncliente_Cliente]
GO
ALTER TABLE [dbo].[Asignacioncliente]  WITH CHECK ADD  CONSTRAINT [FK_Asignacioncliente_Patio] FOREIGN KEY([ac_id_Patio])
REFERENCES [dbo].[Patio] ([pa_id])
GO
ALTER TABLE [dbo].[Asignacioncliente] CHECK CONSTRAINT [FK_Asignacioncliente_Patio]
GO
ALTER TABLE [dbo].[Ejecutivo]  WITH CHECK ADD  CONSTRAINT [FK_Ejecutivo_Patio] FOREIGN KEY([ej_Patio])
REFERENCES [dbo].[Patio] ([pa_id])
GO
ALTER TABLE [dbo].[Ejecutivo] CHECK CONSTRAINT [FK_Ejecutivo_Patio]
GO
ALTER TABLE [dbo].[SolicitudCredito]  WITH CHECK ADD  CONSTRAINT [FK_SolicitudCredito_Cliente] FOREIGN KEY([sc_identificacion_cliente])
REFERENCES [dbo].[Cliente] ([cl_identificacion])
GO
ALTER TABLE [dbo].[SolicitudCredito] CHECK CONSTRAINT [FK_SolicitudCredito_Cliente]
GO
ALTER TABLE [dbo].[SolicitudCredito]  WITH CHECK ADD  CONSTRAINT [FK_SolicitudCredito_Ejecutivo] FOREIGN KEY([sc_identificacion_ejecutivo])
REFERENCES [dbo].[Ejecutivo] ([ej_identificacion])
GO
ALTER TABLE [dbo].[SolicitudCredito] CHECK CONSTRAINT [FK_SolicitudCredito_Ejecutivo]
GO
ALTER TABLE [dbo].[SolicitudCredito]  WITH CHECK ADD  CONSTRAINT [FK_SolicitudCredito_Patio] FOREIGN KEY([sc_Patio])
REFERENCES [dbo].[Patio] ([pa_id])
GO
ALTER TABLE [dbo].[SolicitudCredito] CHECK CONSTRAINT [FK_SolicitudCredito_Patio]
GO
ALTER TABLE [dbo].[SolicitudCredito]  WITH CHECK ADD  CONSTRAINT [FK_SolicitudCredito_Vehiculo] FOREIGN KEY([sc_Vehiculo])
REFERENCES [dbo].[Vehiculo] ([ve_id])
GO
ALTER TABLE [dbo].[SolicitudCredito] CHECK CONSTRAINT [FK_SolicitudCredito_Vehiculo]
GO
ALTER TABLE [dbo].[Vehiculo]  WITH CHECK ADD  CONSTRAINT [FK_Vehiculo_Marca] FOREIGN KEY([ve_marca_id])
REFERENCES [dbo].[Marca] ([ma_id])
GO
ALTER TABLE [dbo].[Vehiculo] CHECK CONSTRAINT [FK_Vehiculo_Marca]
GO
