SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[DeleteGrupUtilizatori]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[DeleteGrupUtilizatori]
GO

--Autor:     Muntean Raluca Cristina
--Data:      28.07.2005
--Nume:      DeleteGrupUtilizatori
--Descriere: sterge o inregistrare din tabela

CREATE PROCEDURE DeleteGrupUtilizatori
(
	@GrupID int
)
AS


--delete grup
begin tran DGrup
	delete from GrupuriUtilizatori with(xlock) 
	where GrupID = @GrupID
	if(@@ERROR <> 0)
	begin
		rollback tran DGrup
	end
	else
	begin
		commit tran DGrup
	end

RETURN
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

