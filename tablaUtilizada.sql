USE [autenticacion]
GO

/****** Object:  Table [dbo].[persona]    Script Date: 30/10/2016 02:19:40 p.m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[persona](
	[nombre] [varchar](20) NOT NULL,
	[apellido1] [varchar](20) NOT NULL,
	[apellido2] [varchar](20) NULL,
	[cedula] [varchar](11) NOT NULL,
	[carne] [varchar](10) NOT NULL,
	[sexo] [bit] NOT NULL,
	[fechaNac] [date] NOT NULL,
	[email] [varchar](40) NULL,
	[id] [nvarchar](128) NULL,
PRIMARY KEY CLUSTERED 
(
	[cedula] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[persona]  WITH CHECK ADD FOREIGN KEY([id])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO


