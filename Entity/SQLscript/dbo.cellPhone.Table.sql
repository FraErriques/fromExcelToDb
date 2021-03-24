USE [dotazioni2021]
GO
/****** Object:  Table [dbo].[cellPhone]    Script Date: 03/24/2021 16:05:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[cellPhone](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[beneficiario] [varchar](150) NULL,
	[oggetto] [varchar](350) NULL,
	[matricola] [varchar](200) NULL,
	[note] [text] NULL,
 CONSTRAINT [PK_dotazioni2021_cellPhone] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
