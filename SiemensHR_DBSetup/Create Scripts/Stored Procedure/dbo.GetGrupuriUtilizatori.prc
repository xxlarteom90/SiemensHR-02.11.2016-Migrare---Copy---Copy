SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetGrupuriUtilizatori]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetGrupuriUtilizatori]
GO

--Autor:     Muntean Raluca Cristina
--Data:      28.07.2005
--Nume:      GetGrupuriUtilizatori
--Descriere: returneaza toate grupurile de utilizatori

CREATE PROCEDURE GetGrupuriUtilizatori

AS
	SELECT *
	FROM GrupuriUtilizatori
	
	RETURN 

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

