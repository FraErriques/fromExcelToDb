USE [dotazioni2021]
GO

DECLARE	@return_value int



       EXEC [dbo].[usp_SIMTIMnonAttiveInBBT_LOAD]
EXEC [dbo].[usp_getCardSIMTIMnonAttiveInBBT_READ]

       EXEC [dbo].[usp_SIMBBTnonInContratto_LOAD]
EXEC [dbo].[usp_getCardSIMBBTnonInContratto_READ]
