USE [dotazioni2021]
GO
/****** Object:  StoredProcedure [dbo].[usp_SIMBBT_inContratto_LOAD]    Script Date: 03/24/2021 16:05:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[usp_SIMBBT_inContratto_LOAD]
as
select
	bbt.beneficiario
	,bbt.servizio
	,bbt.numero
from 
	SIM_BBT bbt
	,SIM_TIM tim
where
	tim.numero like '%'+bbt.numero+'%'
order by bbt.beneficiario
GO
