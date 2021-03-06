SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[DeletePaginaPpAplicatie]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[DeletePaginaPpAplicatie]
GO

--Autor:     Muntean Raluca Cristina
--Data:      28.07.2005
--Nume:      DeletePaginaPpAplicatie
--Descriere: sterge o inregistrare din tabela

CREATE PROCEDURE DeletePaginaPpAplicatie
(
	@PaginaID int
)
AS


--delete pagina
begin tran DPagina
	delete from PaginaPpAplicatie with(xlock) 
	where PaginaID = @PaginaID
	if(@@ERROR <> 0)
	begin
		rollback tran DPagina
	end
	else
	begin
		commit tran DPagina
	end

RETURN
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

