SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sal_DeleteSituatieLunaraAngajat]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sal_DeleteSituatieLunaraAngajat]
GO


--Author:     Cristina Muntean
--Date:       13.09.2005
--Description:Sterge situatia lunara a unui angajat dintr-o anumita luna. 

CREATE PROCEDURE sal_DeleteSituatieLunaraAngajat
(
	@LunaID int,--id-ul lunii
	@AngajatID int,--id-ul angajatului
	@rc int OUTPUT
)

as
set @rc = 0

begin tran DSituatieLunaraAngajat
	--Sterge situatia lunara a angajatului
	delete from sal_SituatieLunaraAngajati with(xlock) where LunaID=@LunaID AND AngajatID=@AngajatID
	if(@@ERROR <> 0)
	begin
		rollback tran  DSituatieLunaraAngajat
		set @rc = @@ERROR
	end
	else
	begin
		commit tran  DSituatieLunaraAngajat
		set @rc = 0
	end
	
RETURN

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

