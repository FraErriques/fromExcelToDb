USE [dotazioni2021]
GO
/****** Object:  StoredProcedure [dbo].[usp_getCardSIMBBTnonInContratto_READ]    Script Date: 03/24/2021 16:05:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[usp_getCardSIMBBTnonInContratto_READ]
as
select
COUNT(bbt.numero) as 'SIM in elenco BBT non piu attive in contratto'
from
[dotazioni2021].[dbo].[SIM_BBT] bbt
where
bbt.numero not in (select numero from [dotazioni2021].[dbo].[SIM_TIM] )
GO
