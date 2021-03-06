SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetPaginiPpAplicInfo]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetPaginiPpAplicInfo]
GO

--Autor:     Muntean Raluca Cristina
--Data:      28.07.2005
--Nume:      GetPaginiPpAplicInfo
--Descriere: returneaza detaliile despre o pagina principala a aplicatiei

CREATE PROCEDURE GetPaginiPpAplicInfo
(
		@PaginaID int
)
AS
	SELECT * 
	FROM PaginiPpAplicatie
	WHERE PaginaID = @PaginaID
	
	RETURN 

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

