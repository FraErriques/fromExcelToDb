--truncate table  dotazioni2021.dbo.SIM_BBT
--truncate table dotazioni2021.dbo.Panda_FR937FT
--truncate table dotazioni2021.dbo.cellPhone


select COUNT(*) from dotazioni2021.dbo.Panda_FR937FT
select COUNT(*) from dotazioni2021.dbo.cellPhone 
select COUNT(*) from dotazioni2021.dbo.PC
select COUNT(*) from dotazioni2021.dbo.accessori

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
