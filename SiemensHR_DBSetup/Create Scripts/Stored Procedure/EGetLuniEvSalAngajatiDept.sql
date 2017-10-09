 /*
Nume procedura:	EGetLuniEvSalAngajatiDept
Autor:			Ciobanu Alexandru
Data:			1.09.2005
Descriere:		Selecteaza lunile situate in perioada dataStart - dataStop din tabela EvolutieSalarAngDept.
					Tabela EvolutieSalarAngDept selecteaza numele angajatilor, departamentul, venitul brut 
					si venitul net pe toata perioada pe care s-au calculat salarii.
*/
CREATE PROCEDURE dbo.EGetLuniEvSalAngajatiDept
	(
		@dataStart datetime,
		@dataStop datetime
	)
AS
	SELECT DISTINCT Data, Data1
	FROM         EvolutieSalarAngDept
	WHERE     (Data1 BETWEEN @dataStart AND @dataStop)
	ORDER BY Data1 