 /*
Nume procedura:	EvolutieSalariiAngajatiDept
Autor:			Ciobanu Alexandru
Data:			31.08.2005
Descriere:		 Selecteaza veniturile angajatilor dintr-un anume departament intr-o perioada de timp predefinita
					Tabela EvolutieSalarAngDept selecteaza numele angajatilor, departamentul, venitul brut 
					si venitul net pe toata perioada pe care s-au calculat salarii
*/
CREATE PROCEDURE dbo.EvolutieSalariiAngajatiDept
	(
		@dept varchar(10),
		@dataStop datetime,
		@dataStart datetime
	)
AS

SELECT    Nume, VenitBrut as Venit, Data
FROM         EvolutieSalarAngDept
WHERE     (Departament = @dept) AND (Data1 BETWEEN @dataStart AND @dataStop)
ORDER BY Nume  