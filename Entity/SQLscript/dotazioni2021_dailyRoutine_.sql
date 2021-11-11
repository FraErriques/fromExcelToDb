--truncate table  dotazioni2021.dbo.SIM_BBT
--truncate table dotazioni2021.dbo.cellPhone
--truncate table dotazioni2021.dbo.PC
--truncate table dotazioni2021.dbo.accessori

select COUNT(*) from dotazioni2021.dbo.SIM_BBT
select * from dotazioni2021.dbo.SIM_BBT
where beneficiario in (
'Eisenstecken'
,'Gruber'
,'Mazzucato'
,'Erriques'
,'Fornari'
,'Malucelli'
,'Marottoli'
,'Pichierri'
,'Pozzati'
,'Rughetti'
,'Schivari'
,'Sibilla'
,'Voza'
,'Ristich'
,'Salvi'
)


select 
	[id],beneficiario,servizio
	 from dotazioni2021.dbo.SIM_BBT
where beneficiario in (
'Eisenstecken'
,'Gruber'
,'Mazzucato'
,'Erriques'
,'Fornari'
,'Malucelli'
,'Marottoli'
,'Pichierri'
,'Pozzati'
,'Rughetti'
,'Schivari'
,'Sibilla'
,'Voza'
,'Ristich'
,'Salvi'
)

select 
	[id],beneficiario,servizio
	 from dotazioni2021.dbo.SIM_BBT
select * from dotazioni2021.dbo.SIM_BBT
where [id] in (
25
,27
,34
,38
,52
,54
,57
,63
,64
,67
,71
,73
,74
,76
,87
)

--update dotazioni2021.dbo.SIM_BBT
--set
--PIN='3680'
--,PUK='77869743'
--,registrazione='8/4/2021'
--,note=''
--where [id]=43
select * from  dotazioni2021.dbo.SIM_BBT
where [id]=43

select * from dotazioni2021.dbo.cellPhone
where beneficiario like '%Iusco%'

--insert into dotazioni2021.dbo.cellPhone
--(--id
--beneficiario
--,oggetto
--,matricola
--,note ) values(
----id
--'Iusco'
--,'SAMSUNG A21S'
--,'S/N RF8R31EN6WW'
--,'completo di istruzioni, batteria, auricolare, caricabatteria, cavo dati'
--)



--update dotazioni2021.dbo.PC
--set note='completo di batteria, carica batteria e docking station della postazione dedicata'
--where [id]=33

--update dotazioni2021.dbo.SIM_BBT
--set note='Pacchetto addizionale 100Gb/mese traffico dati, Offerta Commerciale Prot. n. 474246-P; Accordo Quadro Rubr. 323/2017/AADG del 16.11.2017;Atto Integrativo n. 23.'
--where [id] in (
--25
--,27
--,34
--,38
--,52
--,54
--,57
--,63
--,64
--,67
--,71
--,73
--,74
--,76
--,87
--)



select COUNT(*) from dotazioni2021.dbo.SIM_BBT where PIN is NULL
select COUNT(*) from dotazioni2021.dbo.SIM_BBT where PUK is NULL
select COUNT(*) from dotazioni2021.dbo.cellPhone 
select COUNT(*) from dotazioni2021.dbo.PC
select COUNT(*) from dotazioni2021.dbo.accessori
select * from dotazioni2021.dbo.SIM_BBT order by beneficiario
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


USE [dotazioni2021]
GO

/****** Object:  StoredProcedure [dbo].[usp_SIMTIMnonAttiveInBBT_LOAD]    Script Date: 04/06/2021 16:30:29 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


--  procedure [dbo].[usp_SIMTIMnonAttiveInBBT_LOAD]

select  -- NB. query per nei record TIM, ma non in quelli BBT  -----------
tim.*
from
[dotazioni2021].[dbo].[SIM_TIM] tim
where
tim.numero not in (select numero from [dotazioni2021].[dbo].[SIM_BBT] )
GO

select  -- NB. query per nei record TIM, ma non in quelli BBT  -----------
tim.*
from
[dotazioni2021].[dbo].[SIM_TIM] tim
where
tim.numero not in (select numero from [dotazioni2021].[dbo].[SIM_BBT] )
order by tim.beneficiario
GO

select COUNT(*) from dotazioni2021.dbo.SIM_BBT
select COUNT(*) from dotazioni2021.dbo.SIM_TIM

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
