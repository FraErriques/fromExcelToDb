USE [dotazioni2021]
GO
/****** Object:  StoredProcedure [dbo].[usp_SIM_TIM_INSERT]    Script Date: 03/24/2021 16:05:32 ******/
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
