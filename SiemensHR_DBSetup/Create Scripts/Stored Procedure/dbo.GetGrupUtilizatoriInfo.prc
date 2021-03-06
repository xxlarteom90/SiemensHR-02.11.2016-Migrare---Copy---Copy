SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetGrupUtilizatoriInfo]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetGrupUtilizatoriInfo]
GO

--Autor:     Muntean Raluca Cristina
--Data:      28.07.2005
--Nume:      GetGrupUtilizatoriInfo
--Descriere: returneaza detaliile despre un grup de utilizatori

CREATE PROCEDURE GetGrupUtilizatoriInfo
(
		@GrupID int
)

AS
	SELECT *
	FROM GrupuriUtilizatori
	WHERE GrupID = @GrupID
	
	RETURN 

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

