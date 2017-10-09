
-- Autor : Gosman Rares
 -- Denumire : GetCheckupuriAngajat
 -- Descriere : Intoarce o lista cu checkupuri angajat
 --Change history: Ionel Popa ... 26.08.2005
--					- daca responsabilid este null atunci se va returna valoarea -1


ALTER PROCEDURE GetCheckupuriAngajat
(
	@AngajatID int
	
)
as

select angajati.*, checkupid, necesarinstruire, dataurmatorului, isnull(responsabilid, -1) as responsabilid, Checkupuri.angajatid, dataefectuarii, checkupfile from Checkupuri 
left join Angajati on Checkupuri.ResponsabilID = Angajati.AngajatID
where Checkupuri.AngajatID=@AngajatID order by DataEfectuarii desc
