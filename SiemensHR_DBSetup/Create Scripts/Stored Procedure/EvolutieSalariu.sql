 /*
Nume procedura:	EvolutieSalariu
Autor:			Ciobanu Alexandru
Data:			30.08.2005
Descriere:		Selecteaza pentru un angajat dintr-un departament venitul net si venitul brut pe ultimele @tspan luni

*/
CREATE PROCEDURE dbo.EvolutieSalariu
	(
		@dept nvarchar(10),
		@angid int,
		@tspan int
	)
AS	
SELECT     CASE MONTH(Sal_Luni.Data) 
                      WHEN 1 THEN 'Ian.' WHEN 2 THEN 'Feb.' WHEN 3 THEN 'Mar.' WHEN 4 THEN 'Apr.' WHEN 5 THEN 'Mai.' WHEN 6 THEN 'Iun.' WHEN 7 THEN 'Iul.' WHEN
                       8 THEN 'Aug.' WHEN 9 THEN 'Sep.' WHEN 10 THEN 'Oct.' WHEN 11 THEN 'Noi.' WHEN 12 THEN 'Dec.' END + ' ' + CAST(YEAR(Sal_Luni.Data) 
                      AS varchar(4)) AS Data, sal_StatDePlata.VenitBrut AS VenitBrut, sal_StatDePlata.VenitNet AS VenitNet, sal_StatDePlata.AngajatID
FROM         Sal_Luni INNER JOIN
                      sal_StatDePlata ON Sal_Luni.LunaID = sal_StatDePlata.LunaID INNER JOIN
                      AngajatFull ON sal_StatDePlata.AngajatID = AngajatFull.AngajatID
WHERE     (sal_StatDePlata.AngajatID = @angid) AND (AngajatFull.DepartamentDenumire = @dept) AND (DATEDIFF(month, Sal_Luni.Data, GETDATE()) <= @tspan)