SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[UpdateGrupPagini]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[UpdateGrupPagini]
GO

--Autor:     Muntean Raluca Cristina
--Data:      28.07.2005
--Nume:     UpdateGrupPagini
--Descriere: face update unei inregistrare din tabela GrupPagini

CREATE PROCEDURE UpdateGrupPagini
(
	@GrupPaginaID int,
	@GrupID int,
	@PaginaID int	
)
AS


--face update unei inregistrare din tabela GrupPagini
begin tran UGrupPagina
	update GrupPagini with(xlock) 
		set PaginaID = @PaginaID,
			GrupID = @GrupID
	if(@@ERROR <> 0)
	begin
		rollback tran UGrupPagina
	end
	else
	begin
		commit tran UGrupPagina
	end

RETURN
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

