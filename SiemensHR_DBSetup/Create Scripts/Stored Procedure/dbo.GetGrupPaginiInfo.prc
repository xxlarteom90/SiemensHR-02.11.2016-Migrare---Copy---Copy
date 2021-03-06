SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetGrupPaginiInfo]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetGrupPaginiInfo]
GO

--Autor:     Muntean Raluca Cristina
--Data:      28.07.2005
--Nume:      GetGrupPaginiInfo
--Descriere: returneaza detaliile o inregistrare din tabela GrupPagini
CREATE PROCEDURE GetGrupPaginiInfo 
(
		@GrupPaginaID int
)

AS
	SELECT *
	FROM GrupPagini
	WHERE GrupPaginaID = @GrupPaginaID
	
	RETURN 

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

