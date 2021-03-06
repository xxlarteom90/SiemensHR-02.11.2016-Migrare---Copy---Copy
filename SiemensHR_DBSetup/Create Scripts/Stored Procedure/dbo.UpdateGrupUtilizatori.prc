SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[UpdateGrupUtilizatori]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[UpdateGrupUtilizatori]
GO

--Autor:     Muntean Raluca Cristina
--Data:      28.07.2005
--Nume:      UpdateGrupUtilizatori
--Descriere: face update unei inregistrari din tabela GrupuriUtilizatori

CREATE PROCEDURE UpdateGrupUtilizatori
(
	@GrupID int,
	@NumeGrup nvarchar(50),
	@DescriereGrup nvarchar(100)	
)
AS


--insereaza o inregistrare in tabela GrupuriUtilizatori
begin tran UGrup
	update GrupuriUtilizatori with(xlock) 
		set NumeGrup=@NumeGrup,
		DescriereGrup=@DescriereGrup
	if(@@ERROR <> 0)
	begin
		rollback tran UGrup
	end
	else
	begin
		commit tran UGrup 
	end

RETURN
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

