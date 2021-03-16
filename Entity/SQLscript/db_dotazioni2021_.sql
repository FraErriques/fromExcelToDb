
USE [master]
GO

/****** Object:  Database [dotazioni2021]    Script Date: 03/16/2021 17:27:41 ******/
CREATE DATABASE [dotazioni2021] ON  PRIMARY 
( NAME = N'dotazioni2021', FILENAME = N'C:\root\dataSql\dat\dotazioni2021.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'dotazioni2021_log', FILENAME = N'C:\root\dataSql\log\dotazioni2021_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [dotazioni2021] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [dotazioni2021].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [dotazioni2021] SET ANSI_NULL_DEFAULT OFF
GO
ALTER DATABASE [dotazioni2021] SET ANSI_NULLS OFF
GO
ALTER DATABASE [dotazioni2021] SET ANSI_PADDING OFF
GO
ALTER DATABASE [dotazioni2021] SET ANSI_WARNINGS OFF
GO
ALTER DATABASE [dotazioni2021] SET ARITHABORT OFF
GO
ALTER DATABASE [dotazioni2021] SET AUTO_CLOSE OFF
GO
ALTER DATABASE [dotazioni2021] SET AUTO_CREATE_STATISTICS ON
GO
ALTER DATABASE [dotazioni2021] SET AUTO_SHRINK OFF
GO
ALTER DATABASE [dotazioni2021] SET AUTO_UPDATE_STATISTICS ON
GO
ALTER DATABASE [dotazioni2021] SET CURSOR_CLOSE_ON_COMMIT OFF
GO
ALTER DATABASE [dotazioni2021] SET CURSOR_DEFAULT  GLOBAL
GO
ALTER DATABASE [dotazioni2021] SET CONCAT_NULL_YIELDS_NULL OFF
GO
ALTER DATABASE [dotazioni2021] SET NUMERIC_ROUNDABORT OFF
GO
ALTER DATABASE [dotazioni2021] SET QUOTED_IDENTIFIER OFF
GO
ALTER DATABASE [dotazioni2021] SET RECURSIVE_TRIGGERS OFF
GO
ALTER DATABASE [dotazioni2021] SET  DISABLE_BROKER
GO
ALTER DATABASE [dotazioni2021] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO
ALTER DATABASE [dotazioni2021] SET DATE_CORRELATION_OPTIMIZATION OFF
GO
ALTER DATABASE [dotazioni2021] SET TRUSTWORTHY OFF
GO
ALTER DATABASE [dotazioni2021] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO
ALTER DATABASE [dotazioni2021] SET PARAMETERIZATION SIMPLE
GO
ALTER DATABASE [dotazioni2021] SET READ_COMMITTED_SNAPSHOT OFF
GO
ALTER DATABASE [dotazioni2021] SET HONOR_BROKER_PRIORITY OFF
GO
ALTER DATABASE [dotazioni2021] SET  READ_WRITE
GO
ALTER DATABASE [dotazioni2021] SET RECOVERY SIMPLE
GO
ALTER DATABASE [dotazioni2021] SET  MULTI_USER
GO
ALTER DATABASE [dotazioni2021] SET PAGE_VERIFY CHECKSUM
GO
ALTER DATABASE [dotazioni2021] SET DB_CHAINING OFF
GO



USE [dotazioni2021]
GO
/****** Object:  Table [dbo].[SIM_TIM]    Script Date: 03/16/2021 17:27:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SIM_TIM](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[beneficiario] [varchar](150) NULL,
	[servizio] [varchar](150) NULL,
	[numero] [varchar](30) NULL,
	[PIN] [varchar](4) NULL,
	[PUK] [varchar](8) NULL,
	[ICCID] [varchar](150) NULL,
	[registrazione] [date] NULL,
	[note] [text] NULL,
 CONSTRAINT [PK_dotazioni2021_SIM_TIM] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [AK_dotazioni2021_SIM_TIM] UNIQUE NONCLUSTERED 
(
	[numero] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO


/****** Object:  Table [dbo].[SIM_BBT]    Script Date: 03/16/2021 17:27:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SIM_BBT](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[beneficiario] [varchar](150) NULL,
	[servizio] [varchar](150) NULL,
	[numero] [varchar](30) NULL,
	[PIN] [varchar](4) NULL,
	[PUK] [varchar](8) NULL,
	[ICCID] [varchar](150) NULL,
	[registrazione] [date] NULL,
	[note] [text] NULL,
 CONSTRAINT [PK_dotazioni2021_SIM_BBT] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [AK_dotazioni2021_SIM_BBT] UNIQUE NONCLUSTERED 
(
	[numero] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO


/****** Object:  Table [dbo].[PC]    Script Date: 03/16/2021 17:27:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PC](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[beneficiario] [varchar](150) NULL,
	[oggetto] [varchar](350) NULL,
	[matricola] [varchar](200) NULL,
	[note] [text] NULL,
 CONSTRAINT [PK_dotazioni2021_PC] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [AK_dotazioni2021_PC] UNIQUE NONCLUSTERED 
(
	[matricola] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO


/****** Object:  Table [dbo].[Panda_FR937FT]    Script Date: 03/16/2021 17:27:42 ******/
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


/****** Object:  Table [dbo].[cellPhone]    Script Date: 03/16/2021 17:27:42 ******/
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
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [AK_dotazioni2021_cellPhone] UNIQUE NONCLUSTERED 
(
	[matricola] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO


/****** Object:  Table [dbo].[accessori]    Script Date: 03/16/2021 17:27:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[accessori](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[beneficiario] [varchar](150) NULL,
	[oggetto] [varchar](350) NULL,
	[matricola] [varchar](200) NULL,
	[note] [text] NULL,
 CONSTRAINT [PK_dotazioni2021_accessori] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [AK_dotazioni2021_accessori] UNIQUE NONCLUSTERED 
(
	[matricola] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO




/****** Object:  StoredProcedure [dbo].[usp_SIMTIMnonAttiveInBBT_LOAD]    Script Date: 03/16/2021 17:27:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[usp_SIMTIMnonAttiveInBBT_LOAD]
as
select  -- NB. query per nei record TIM, ma non in quelli BBT  -----------
tim.*
from
[dotazioni2021].[dbo].[SIM_TIM] tim
where
tim.numero not in (select numero from [dotazioni2021].[dbo].[SIM_BBT] )
GO


/****** Object:  StoredProcedure [dbo].[usp_SIMBBTnonInContratto_LOAD]    Script Date: 03/16/2021 17:27:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[usp_SIMBBTnonInContratto_LOAD]
as
select  -- NB. query per schede non in contratto: ovvero nei recordBBT ma non in quelli TIM -----------
bbt.*
from
[dotazioni2021].[dbo].[SIM_BBT] bbt
where
bbt.numero not in (select numero from [dotazioni2021].[dbo].[SIM_TIM] )
GO


/****** Object:  StoredProcedure [dbo].[usp_SIM_TIM_INSERT]    Script Date: 03/16/2021 17:27:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[usp_SIM_TIM_INSERT]
	-- id   identity pk,
	@beneficiario	[varchar](150),
	@servizio		[varchar](150),
	@numero			[varchar](30),
	@PIN			[varchar](4),
	@PUK			[varchar](8),
	@ICCID			[varchar](150),
	@registrazione	[date],-- filtered tobe inside [2000, now]
	@note			[text]
as
--
insert into [dotazioni2021].[dbo].[SIM_TIM]
(
	--[id],			
	[beneficiario]	,
	[servizio]		,
	[numero]		,
	[PIN]			,
	[PUK]			,
	[ICCID]			,
	[registrazione]	,
	[note]
	   )
  values(
	--[id],		
	@beneficiario,
	@servizio,
	@numero,
	@PIN,
	@PUK,
	@ICCID,
	@registrazione,
	@note 
)
GO


/****** Object:  StoredProcedure [dbo].[usp_SIM_BBT_INSERT]    Script Date: 03/16/2021 17:27:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[usp_SIM_BBT_INSERT]
	-- id   identity pk,
	@beneficiario	[varchar](150),
	@servizio		[varchar](150),
	@numero			[varchar](30),
	@PIN			[varchar](4),
	@PUK			[varchar](8),
	@ICCID			[varchar](150),
	@registrazione	[date],-- filtered tobe inside [2000, now]
	@note			[text]
as
--
insert into [dotazioni2021].[dbo].[SIM_BBT]
(
	--[id],			
	[beneficiario]	,
	[servizio]		,
	[numero]		,
	[PIN]			,
	[PUK]			,
	[ICCID]			,
	[registrazione]	,
	[note]
	   )
  values(
	--[id],		
	@beneficiario,
	@servizio,
	@numero,
	@PIN,
	@PUK,
	@ICCID,
	@registrazione,
	@note 
)
GO


/****** Object:  StoredProcedure [dbo].[usp_PC_INSERT]    Script Date: 03/16/2021 17:27:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[usp_PC_INSERT]
	-- id   identity pk
	@beneficiario	[varchar](150),
	@oggetto [varchar](350),
	@matricola [varchar](200),
	@note [text]
as
--
insert into [dotazioni2021].[dbo].[PC]
(
	--[id]    identity pk		
	[beneficiario]	,
	[oggetto]		,
	[matricola]		,
	[note]
	   )
  values(
	--[id],		
	@beneficiario,
	@oggetto,
	@matricola,
	@note
)
GO


/****** Object:  StoredProcedure [dbo].[usp_Panda_FR937FT_INSERT]    Script Date: 03/16/2021 17:27:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[usp_Panda_FR937FT_INSERT]
	--[id]				[int] IDENTITY(1,1) NOT NULL,
	@Vettura			[varchar](30) ,
	@data				[date] ,
	@km					[int] ,
	@intervento			[varchar](330) ,
	@litri				[float] ,
	@euro				[float] ,
	@gasolio_euro_litro	[float] 
as
--
insert into [dotazioni2021].[dbo].[Panda_FR937FT]
(
	-- [id] [int] IDENTITY(1,1) NOT NULL
	[Vettura],
	[data],
	[km],
	[intervento],
	[litri],
	[euro],
	[gasolio_euro/litro] -- NB. sosituzione di '/' con '_' nel parametro
	   )
  values(
	--[id] [int] IDENTITY(1,1) NOT NULL
	@Vettura			,
	@data				,
	@km					,
	@intervento			,
	@litri				,
	@euro				,
	@gasolio_euro_litro	  -- NB. sosituzione di '/' con '_' nel parametro
)
GO


/****** Object:  StoredProcedure [dbo].[usp_getCardSIMTIMnonAttiveInBBT_READ]    Script Date: 03/16/2021 17:27:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[usp_getCardSIMTIMnonAttiveInBBT_READ]
as
select  -- NB. query per nei record TIM, ma non in quelli BBT  -----------
COUNT(tim.numero)
from
[dotazioni2021].[dbo].[SIM_TIM] tim
where
tim.numero not in (select numero from [dotazioni2021].[dbo].[SIM_BBT] )
GO


/****** Object:  StoredProcedure [dbo].[usp_getCardSIMBBTnonInContratto_READ]    Script Date: 03/16/2021 17:27:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[usp_getCardSIMBBTnonInContratto_READ]
as
select
COUNT(bbt.numero)
from
[dotazioni2021].[dbo].[SIM_BBT] bbt
where
bbt.numero not in (select numero from [dotazioni2021].[dbo].[SIM_TIM] )
GO


/****** Object:  StoredProcedure [dbo].[usp_cellPhone_INSERT]    Script Date: 03/16/2021 17:27:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[usp_cellPhone_INSERT]
	-- id   identity pk
	@beneficiario	[varchar](150),
	@oggetto [varchar](350),
	@matricola [varchar](200),
	@note [text]
as
--
insert into [dotazioni2021].[dbo].[cellPhone]
(
	--[id]    identity pk		
	[beneficiario]	,
	[oggetto]		,
	[matricola]		,
	[note]
	   )
  values(
	--[id],		
	@beneficiario,
	@oggetto,
	@matricola,
	@note
)
GO


/****** Object:  StoredProcedure [dbo].[usp_accessori_INSERT]    Script Date: 03/16/2021 17:27:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[usp_accessori_INSERT]
	-- id   identity pk
	@beneficiario	[varchar](150),
	@oggetto [varchar](350),
	@matricola [varchar](200),
	@note [text]
as
--
insert into [dotazioni2021].[dbo].[accessori]
(
	--[id]    identity pk		
	[beneficiario]	,
	[oggetto]		,
	[matricola]		,
	[note]
	   )
  values(
	--[id],		
	@beneficiario,
	@oggetto,
	@matricola,
	@note
)
GO
