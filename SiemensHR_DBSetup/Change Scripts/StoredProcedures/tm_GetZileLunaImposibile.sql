

ALTER PROCEDURE dbo.tm_GetZileLunaImposibile
(
@Luna int,
@An int,
@DataExpirare datetime --expirare contract munca
)

AS

--Modified:    Cristina Raluca Muntean
--Date:        13.09.2005
--Description: Data trebuie sa fie mai mare sau egala cu @DataExpirare pentru e se genera 
--             corect pontajul.
select * 

from tm_zile 

where datepart(mm,Data)=@Luna and
	datepart(yy,Data)=@An and
	DATEDIFF(Day,Data,@DataExpirare)<=0
 