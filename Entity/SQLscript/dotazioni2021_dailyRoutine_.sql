--truncate table  dotazioni2021.dbo.SIM_BBT
--truncate table dotazioni2021.dbo.cellPhone
--truncate table dotazioni2021.dbo.PC
--truncate table dotazioni2021.dbo.accessori

select COUNT(*) from dotazioni2021.dbo.SIM_BBT
select COUNT(*) from dotazioni2021.dbo.cellPhone 
select COUNT(*) from dotazioni2021.dbo.PC
select COUNT(*) from dotazioni2021.dbo.accessori
select * from dotazioni2021.dbo.SIM_BBT
select * from dotazioni2021.dbo.cellPhone 
select * from dotazioni2021.dbo.PC
select * from dotazioni2021.dbo.accessori

select COUNT(*) from dotazioni2021.dbo.Panda_FR937FT
select COUNT(*) from dotazioni2021.dbo.genericaAuto 
select * from dotazioni2021.dbo.genericaAuto order by id
--delete from dotazioni2021.dbo.genericaAuto where id>=1301
select * from dotazioni2021.dbo.genericaAuto order by Vettura
select * from dotazioni2021.dbo.genericaAuto order by km
select * from dotazioni2021.dbo.genericaAuto order by euro
select * from dotazioni2021.dbo.genericaAuto where vettura is NULL
--delete from dotazioni2021.dbo.genericaAuto where vettura is NULL
select * from dotazioni2021.dbo.genericaAuto where vettura like '%vettura%'
--delete from dotazioni2021.dbo.genericaAuto where vettura like '%vettura%'
select COUNT(*) from dotazioni2021.dbo.genericaAuto 
select distinct Vettura from dotazioni2021.dbo.genericaAuto order by Vettura

select COUNT(*) from dotazioni2021.dbo.SIM_BBT
select COUNT(*) from dotazioni2021.dbo.SIM_TIM
select * from dotazioni2021.dbo.SIM_BBT order by numero
select * from dotazioni2021.dbo.SIM_TIM order by numero
select * from dotazioni2021.dbo.SIM_BBT order by beneficiario
select * from dotazioni2021.dbo.SIM_TIM order by beneficiario -- NB. #11 potenziali-inattive.

select * from dotazioni2021.dbo.SIM_TIM where numero is NULL
select * from dotazioni2021.dbo.SIM_TIM where beneficiario is NULL
exec usp_SIMTIMnonAttiveInBBT_LOAD
select * from dotazioni2021.dbo.SIM_BBT where numero is NULL
--delete from dotazioni2021.dbo.SIM_BBT where numero is NULL

select * from dotazioni2021.dbo.Panda_FR937FT
select * from dotazioni2021.dbo.cellPhone 
select COUNT(*) from dotazioni2021.dbo.cellPhone where oggetto is NULL
select * from dotazioni2021.dbo.cellPhone where oggetto is NULL
--delete from dotazioni2021.dbo.cellPhone where oggetto is NULL
select * from dotazioni2021.dbo.PC
select * from dotazioni2021.dbo.PC where oggetto is NULL
--delete from dotazioni2021.dbo.PC where oggetto is NULL
select * from dotazioni2021.dbo.accessori
select * from dotazioni2021.dbo.accessori where oggetto is NULL
--delete from dotazioni2021.dbo.accessori where oggetto is NULL
--##
       EXEC [dbo].[usp_SIMTIMnonAttiveInBBT_LOAD]
EXEC [dbo].[usp_getCardSIMTIMnonAttiveInBBT_READ]

       EXEC [dbo].[usp_SIMBBTnonInContratto_LOAD]
EXEC [dbo].[usp_getCardSIMBBTnonInContratto_READ]
--##
EXEC [dbo].[usp_getCardSIMTIMnonAttiveInBBT_READ]
EXEC [dbo].[usp_getCardSIMBBTnonInContratto_READ]

-- delete from dotazioni2021.dbo.SIM_BBT where [id] between 87 and 91 Trigonos
 --delete from dotazioni2021.dbo.SIM_BBT 
 --where  [id]=7  or [id]=37


select COUNT(bbt.id) 
from 
	SIM_BBT bbt
	,SIM_TIM tim
where
	tim.ICCID like '%'+bbt.ICCID+'%'

select 
	bbt.beneficiario
	,bbt.servizio
	,bbt.numero
from 
SIM_TIM tim
,SIM_BBT bbt
where tim.numero = bbt.numero
  

exec usp_SIMBBT_inContratto_LOAD
exec usp_SIMBBTnonInContratto_LOAD
	


--##

-- create tmp table
--select
--	tim.id				as tim_id
--	,bbt.beneficiario	as bbt_beneficiario
--into dotazioni2021.[dbo].[beneficiariTIM]	
--from 
--	dotazioni2021.dbo.SIM_TIM  tim
--	,dotazioni2021.dbo.SIM_BBT bbt
--where
--	tim.numero=bbt.numero

-- NB. update from !
--UPDATE dotazioni2021.dbo.SIM_TIM 
--SET dotazioni2021.dbo.SIM_TIM.beneficiario = dotazioni2021.dbo.SIM_BBT.beneficiario
--FROM
--dotazioni2021.dbo.SIM_TIM
--,dotazioni2021.dbo.SIM_BBT
--WHERE 
--dotazioni2021.dbo.SIM_TIM.numero = dotazioni2021.dbo.SIM_BBT.numero


--USE [dotazioni2021]
--GO
--SET ANSI_NULLS ON
--GO
--SET QUOTED_IDENTIFIER ON
--GO
--SET ANSI_PADDING ON
--GO

--CREATE TABLE [dbo].[genericaAuto](
--	[id] [int] IDENTITY(1,1) NOT NULL,
--	[Vettura] [varchar](30) NULL,
--	[data] [date] NULL,
--	[km] [int] NULL,
--	[intervento] [varchar](330) NULL,
--	[litri] [float] NULL,
--	[euro] [float] NULL,
--	[gasolio_euro/litro] [float] NULL,
-- CONSTRAINT [PK_dotazioni2021_genericaAuto] PRIMARY KEY CLUSTERED 
--(
--	[id] ASC
--)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
--) ON [PRIMARY]

--GO
--SET ANSI_PADDING OFF
--GO
--##
--USE [dotazioni2021]
--GO
--SET ANSI_NULLS ON
--GO
--SET QUOTED_IDENTIFIER ON
--GO

--create procedure [dbo].[usp_genericaAuto_INSERT]
--	--[id]				[int] IDENTITY(1,1) NOT NULL,
--	@Vettura			[varchar](30) ,
--	@data				[date] ,
--	@km					[int] ,
--	@intervento			[varchar](330) ,
--	@litri				[float] ,
--	@euro				[float] ,
--	@gasolio_euro_litro	[float] 
--as
----
--insert into [dotazioni2021].[dbo].[genericaAuto]
--(
--	-- [id] [int] IDENTITY(1,1) NOT NULL
--	[Vettura],
--	[data],
--	[km],
--	[intervento],
--	[litri],
--	[euro],
--	[gasolio_euro/litro] -- NB. sosituzione di '/' con '_' nel parametro
--	   )
--  values(
--	--[id] [int] IDENTITY(1,1) NOT NULL
--	@Vettura			,
--	@data				,
--	@km					,
--	@intervento			,
--	@litri				,
--	@euro				,
--	@gasolio_euro_litro	  -- NB. sosituzione di '/' con '_' nel parametro
--)

--GO

