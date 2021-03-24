USE [dotazioni2021]
GO
/****** Object:  Table [dbo].[Panda_FR937FT]    Script Date: 03/24/2021 16:05:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Panda_FR937FT](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Vettura] [varchar](30) NULL,
	[data] [date] NULL,
	[km] [int] NULL,
	[intervento] [varchar](330) NULL,
	[litri] [float] NULL,
	[euro] [float] NULL,
	[gasolio_euro/litro] [float] NULL,
 CONSTRAINT [PK_dotazioni2021_Panda_FR937FT] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
