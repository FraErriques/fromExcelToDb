USE [dotazioni2021]
GO
/****** Object:  StoredProcedure [dbo].[usp_SIMBBTnonInContratto_LOAD]    Script Date: 03/24/2021 16:05:32 ******/
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
