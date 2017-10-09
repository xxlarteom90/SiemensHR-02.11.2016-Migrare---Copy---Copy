SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetPaginiGrup]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetPaginiGrup]
GO

--Autor:     Muntean Raluca Cristina
--Data:      28.07.2005
--Nume:      GetPaginiGrup
--Descriere: returneaza toate paginile la care are acces un grup

CREATE PROCEDURE GetPaginiGrup
(
		@GrupID int
)

AS
	SELECT *
	FROM GrupPagini
	WHERE GrupID=@GrupID
	
	RETURN 

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

