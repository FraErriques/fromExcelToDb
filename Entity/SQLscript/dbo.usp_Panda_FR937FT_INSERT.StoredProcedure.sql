USE [dotazioni2021]
GO
/****** Object:  StoredProcedure [dbo].[usp_Panda_FR937FT_INSERT]    Script Date: 03/24/2021 16:05:32 ******/
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
