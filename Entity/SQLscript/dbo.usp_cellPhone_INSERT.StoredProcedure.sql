USE [dotazioni2021]
GO
/****** Object:  StoredProcedure [dbo].[usp_cellPhone_INSERT]    Script Date: 03/24/2021 16:05:32 ******/
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
