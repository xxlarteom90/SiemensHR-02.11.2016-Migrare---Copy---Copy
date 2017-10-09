
/*
* Autor:		Mircea Albutiu, PSE RO BS TH
* Nume:			GetAngajatInfo
* Descriere:	Intoarce toate datele unui angajat
* Modificat:	Alexandru Mihai, adaugat NumeAngajator :)
  Modificat:    Cristina Raluca Muntean, adaugat Sporuri, AlteAdaosuri, NrZileCOSupl, EchIndProtectie, EchIndLucru,
                MatIgiSan, AlimProtectie, AlteDrSiObl, AlteClauzeCIM, PerProba
                Ionel Popa: simplificat procedura
*/
ALTER PROCEDURE GetAngajatInfo 
(
	@AngajatID int
)
as 

SELECT     AngajatFull.*, SituatieMilitara.*
			
FROM         AngajatFull LEFT JOIN
                      SituatieMilitara ON SituatieMilitara.AngajatID = AngajatFull.AngajatID
WHERE     AngajatFull.AngajatID = @AngajatID