SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[InsertGrupPagini]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[InsertGrupPagini]
GO

--Autor:     Muntean Raluca Cristina
--Data:      28.07.2005
--Nume:      InsertGrupPagini
--Descriere: insereaza o inregistrare in tabela GrupPagini

CREATE PROCEDURE InsertGrupPagini
(
	@GrupID int,
	@PaginaID int,
	@GrupPaginaID int=-1 OUTPUT	
)
AS


--insereaza o inregistrare in tabela GrupPagini
begin tran IGrupPagina
	insert into GrupPagini with(xlock) (PaginaID, GrupID) 
		values (@PaginaID, @GrupID)
	if(@@ERROR <> 0)
	begin
		rollback tran IGrupPagina
	end
	else
	begin
		commit tran IGrupPagina
		set @GrupPaginaID = @@IDENTITY 
	end

RETURN
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

