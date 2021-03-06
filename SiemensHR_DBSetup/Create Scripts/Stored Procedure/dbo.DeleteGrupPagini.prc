SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[DeleteGrupPagini]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[DeleteGrupPagini]
GO

--Autor:     Muntean Raluca Cristina
--Data:      28.07.2005
--Nume:      DeleteGrupPagini
--Descriere: sterge o inregistrare din tabela

CREATE PROCEDURE DeleteGrupPagini
(
	@GrupPaginaID int
)
AS


--delete grup pagina
begin tran DGrupPagina
	delete from GrupPagini with(xlock) 
	where GrupPaginaID = @GrupPaginaID
	if(@@ERROR <> 0)
	begin
		rollback tran DGrupPagina
	end
	else
	begin
		commit tran DGrupPagina
	end

RETURN
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

