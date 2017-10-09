

/*
Autor:			Dovlecel Vlad
Descriere:		returneaza toti angajatii
Modificat:		Cristina Muntean
					Descriere modificare: am modificat procedura stocata astfel incat sa returneze toti angajatii activi, angajati
										in luna curenta sau intr-o luna anterioara acesteia, angajati ai angajatorului trimis ca parametru, se face o 
										selectie si in functie de categoria angajatilor
Modificat:		Ionel Popa
					Descriere modificare: am modificat procedura sa poate returna toti angajatii indiferent de data angajarii
					Daca @CategorieID = -2 atunci se vor returna toti acesti angajati
				Ionel Popa
					Descriere modificare: am modificat ultimul select: trebuie sa returneze si angajatii care sunt lichidati in luna curenta
					
*/
ALTER PROCEDURE dbo.GetAllAngajati
(
	@CategorieID int,
	@AngajatorID int
)
AS

DECLARE @DataCurenta datetime --data de 1 a lunii curente
DECLARE @DataEndLuna datetime --data de sfarsit a lunii curente

if ( @CategorieID = -2)
begin
	select *
	from AngajatFull
	where  AngajatorID=@AngajatorID
	order by NumeIntreg 
	
	return
end

SET @DataCurenta = (SELECT Data 
		   FROM Sal_Luni
		   WHERE Activ=1 AND AngajatorID=@AngajatorID)

--este setata ultima zi a lunii curente
SET @DataEndLuna = DATEADD(dd, - DAY(DATEADD(mm, 1, @DataCurenta)), DATEADD(mm, 1, @DataCurenta))
print @DataEndLuna
if( @CategorieID > 0 )
begin
	select *

	from AngajatFull

	where CategorieID = @CategorieID AND Lichidat = 0 AND Activ = 0  AND  DATEDIFF(day, DataDeLa, @DataEndLuna)>=0 AND AngajatorID=@AngajatorID

	order by NumeIntreg
end
else begin
	select *

	from AngajatFull
	where Activ = 0 AND
	 ( Lichidat = 0 or ( Lichidat = 1 and (DataLichidare between @DataCurenta and @DataEndLuna))) AND
	  DATEDIFF(day, DataDeLa, @DataEndLuna)>=0 AND
	   AngajatorID=@AngajatorID
	order by NumeIntreg
end
