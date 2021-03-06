SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[UpdatePaginaPpAplicatie]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[UpdatePaginaPpAplicatie]
GO

--Autor:     Muntean Raluca Cristina
--Data:      28.07.2005
--Nume:      UpdatePaginaPpAplicatie
--Descriere: face update unei pagini principale a aplicatiei

CREATE PROCEDURE UpdatePaginaPpAplicatie
(

	@PaginaID int,	
	@NumePagina nvarchar(50),
	@DescrierePagina nvarchar(100)
)
AS


--update pagina
begin tran UPagina
	update PaginaPpAplicatie with(xlock) 
		set NumePagina = @NumePagina,
			DescrierePagina = @NumePagina
	if(@@ERROR <> 0)
	begin
		rollback tran UPagina
	end
	else
	begin
		commit tran UPagina
	end

RETURN
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

