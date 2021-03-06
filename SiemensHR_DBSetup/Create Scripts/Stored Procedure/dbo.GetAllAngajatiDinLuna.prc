SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetAllAngajatiDinLuna]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetAllAngajatiDinLuna]
GO

/*
Autor:			Cristina Raluca Muntean
Data:           13.09.2005
Descriere:		returneaza toti angajatii care au avut contract in luna trimisa ca parametru					
*/
CREATE PROCEDURE dbo.GetAllAngajatiDinLuna
(
	@LunaID int,
	@AngajatorID int
)
AS

DECLARE @DataCurenta datetime --data de 1 a lunii curente
DECLARE @DataEndLuna datetime --data de sfarsit a lunii curente

SET @DataCurenta = (SELECT Data 
		   FROM Sal_Luni
		   WHERE LunaID = @LunaID)

--este setata ultima zi a lunii curente
SET @DataEndLuna = DATEADD(dd, - DAY(DATEADD(mm, 1, @DataCurenta)), DATEADD(mm, 1, @DataCurenta))
print @DataEndLuna

select *
from AngajatFull
where Activ = 0 AND
(Lichidat = 0 or ( Lichidat = 1 and ((DataLichidare between @DataCurenta and @DataEndLuna) or (DATEDIFF(day,@DataEndLuna, DataLichidare)>=0)))) AND
DATEDIFF(day, DataDeLa, @DataEndLuna)>=0 AND 
AngajatorID=@AngajatorID
order by NumeIntreg


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

