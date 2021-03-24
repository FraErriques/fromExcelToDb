USE [dotazioni2021]
GO
/****** Object:  StoredProcedure [dbo].[usp_getCardSIMTIMnonAttiveInBBT_READ]    Script Date: 03/24/2021 16:05:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[usp_getCardSIMTIMnonAttiveInBBT_READ]
as
select  -- NB. query per nei record TIM, ma non in quelli BBT  -----------
COUNT(tim.numero) as 'SIM attiva in Telecom ma in disuso in BBT'
from
[dotazioni2021].[dbo].[SIM_TIM] tim
where
tim.numero not in (select numero from [dotazioni2021].[dbo].[SIM_BBT] )
GO
