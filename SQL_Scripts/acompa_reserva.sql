/****** Object:  Table [hotel].[acompanantes_reservaciones]    Script Date: 2022-11-17 9:33:30 p. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [hotel].[acompanantes_reservaciones](
	[id_invitados_reservacion] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[id_reservacion] [numeric](18, 0) NOT NULL,
	[nombre_completo_invitado] [varchar](100) NOT NULL,
	[edad_invitado] [numeric](18, 0) NOT NULL,
	[tipo_invitado] [varchar](1) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_invitados_reservacion] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [hotel].[acompanantes_reservaciones]  WITH CHECK ADD  CONSTRAINT [FK_acompanantes_reservaciones_reservaciones] FOREIGN KEY([id_reservacion])
REFERENCES [hotel].[reservaciones] ([id_reservacion])
GO

ALTER TABLE [hotel].[acompanantes_reservaciones] CHECK CONSTRAINT [FK_acompanantes_reservaciones_reservaciones]
GO

