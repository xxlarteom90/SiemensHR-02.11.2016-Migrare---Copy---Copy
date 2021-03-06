SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[InsertPaginaPpAplicatie]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[InsertPaginaPpAplicatie]
GO

--Autor:     Muntean Raluca Cristina
--Data:      28.07.2005
--Nume:      InsertPaginaPpAplicatie
--Descriere: insereaza o pagina principala a aplicatiei

CREATE PROCEDURE InsertPaginaPpAplicatie
(
	@NumePagina nvarchar(50),
	@DescrierePagina nvarchar(100),
	@PaginaID int=-1 OUTPUT	
)
AS


--insert pagina
begin tran IPagina
	insert into PaginaPpAplicatie with(xlock) (NumePagina, DescrierePagina) 
		values (@NumePagina, @DescrierePagina)
	if(@@ERROR <> 0)
	begin
		rollback tran IPagina
	end
	else
	begin
		commit tran IPagina
		set @PaginaID = @@IDENTITY 
	end

RETURN
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

