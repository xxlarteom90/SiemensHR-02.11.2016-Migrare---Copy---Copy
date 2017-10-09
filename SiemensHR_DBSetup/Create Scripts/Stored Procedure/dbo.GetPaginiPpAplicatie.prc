SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetPaginiPpAplicatie]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetPaginiPpAplicatie]
GO

--Autor:     Muntean Raluca Cristina
--Data:      28.07.2005
--Nume:      GetPaginiPpAplicatie
--Descriere: returneaza toate paginile principale ale aplicatiei

CREATE PROCEDURE GetPaginiPpAplicatie

AS

	SELECT * 
	FROM PaginiPpAplicatie
	 
	RETURN 

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

