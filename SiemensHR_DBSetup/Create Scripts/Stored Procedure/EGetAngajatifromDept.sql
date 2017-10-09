  /*
	Denumire procedura: EGetAngajatifromDept
	Autor:				Alex Ciobanu
	Data:				05.09.2005
	Descriere:			Selecteaza numele tuturor angajatilor dintr-un anume departament
 */
 CREATE PROCEDURE dbo.EGetAngajatifromDept
 (
	@NumeDept as varchar(10)
 )
 AS
SELECT AngajatID, NumeIntreg FROM dbo.AngajatFull WHERE (DepartamentDenumire = @NumeDept)
ORDER BY NumeIntreg 