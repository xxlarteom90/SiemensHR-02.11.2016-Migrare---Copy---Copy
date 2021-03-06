SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[InsertGrupUtilizatori]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[InsertGrupUtilizatori]
GO

--Autor:     Muntean Raluca Cristina
--Data:      28.07.2005
--Nume:      InsertGrupUtilizatori
--Descriere: insereaza o inregistrare in tabela GrupuriUtilizatori

CREATE PROCEDURE InsertGrupUtilizatori
(
	@NumeGrup nvarchar(50),
	@DescriereGrup nvarchar(100),
	@GrupID int=-1 OUTPUT	
)
AS


--insereaza o inregistrare in tabela GrupuriUtilizatori
begin tran IGrup
	insert into GrupuriUtilizatori with(xlock) (NumeGrup, DescriereGrup) 
		values (@NumeGrup, @DescriereGrup)
	if(@@ERROR <> 0)
	begin
		rollback tran IGrup
	end
	else
	begin
		commit tran IGrup
		set @GrupID = @@IDENTITY 
	end

RETURN
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

