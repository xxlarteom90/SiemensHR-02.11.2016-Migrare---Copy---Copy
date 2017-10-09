




/*
	Author: 		Ionel Popa
	Description: 	Calculeaza venitul brut, bazele de calcul, contributiile, retul de plata pentru un angajat
	Params:			@LunaID in ... id-ul lunii active
				    @AngajatID in ... id-ul angajatului pentru care se calculeaza baza de calcul
	History change:		Popa Ionel - 12 may 2005
					Din cauza despartirii venitului brut in mai multi termeni a trebuit sa fie calculati inainte de calculul venitului brut
					Acestia sunt: Salariu de incadrare realizat, indemnizatia de conducere realizata, drepturi banesti aferente concediului de odihna, drepturi banesti aferente concediului de ev deosebite, drepturi banesti aferente orelor suplimentare
				Popa Ionel - 16 may 2005
					Contributiile trebuie majorate dupa virgula. Din aceasta cauza s-au modificat tipurile contributiilor de la money la numeric. Astfel conversia se face automat.
					Venitul brut trebuie majorat dupa virgula. Din aceasta cauza s-a modificat tipul variabilei care stoca venitul brut din money in numeric. Astfel conversia se face automat.
				Popa Ionel - 26 may 2005
					Drepturile banesti trebuie sa fie rotunjite dupa virgula ( salariulIncadrareRealizat, indemnizatieConducereRealizata,drepturiBanestiConcediuOdihna, drepturiBanestiConcediuEvDeosebite, drepturiBanestiOreSuplimentare)
				Popa Ionel - 02 june 2005
					Am rotunjit indemnizatia de concediu medical. Apelul care facea rotunjirea era in procedura care facea calculul indemnizatiei de concediu medical
				Popa Ionel - 24 june 2005
					Am adaugat in algoritmul salarial si baza de calcul a contributiei angajatului la fondul de sanatate aferent concediilor medicale de orice tip SI contributia care se deduce din aceasta
				Popa Ionel - 04 july 2005
					Am adaugat cod care calculeata contributiile angajatorului raportate la fiecare angajat
				Popa Ionel - 14 oct 2005
					Din cauza trecerii la RON a trebuit sa se modifice conversia.Toate contributiile se majoreaza superior.Am folosit functia ROUND.
*/
ALTER PROCEDURE spCalculDateSalariuAngajat
(
	@LunaID int, --id-ul lunii
	@AngajatID int --id-ul angajatului
)
AS

--ADDED: Ionel Popa
--reprezinta id-ul angajatorului la care e atasat angajatul
declare @AngajatorID as int
--id-urile tipurilor de baze de calcul din tabela sal_BazaCalculTipuri
declare @bcContribIndivSomajID as int
declare @bcContribIndivAsigSocialeID as int
declare @bcContribIndivAsigSanatateID as int
--ADDED: Ionel Popa ... 24062005
declare @bazaCalculContribSupDinCASID int
--id-urile tipurilor de contributii individuale din tabela sal_ContributiiIndivTipuri
declare @contribIndivSomajID as int
declare @contribIndivAsigSocialeID as int
declare @contribIndivAsigSanatateID as int
--ADDED: Ionel Popa ... 24062005
declare @ContributieFondSanDinAsigSocID as int
--datele referitoare la salariul angajatului
declare @tarifOrar as money
declare @prime as money
declare @avans as money
declare @alteRetineri as money
declare @indemnizatieConcediuMedical as money
declare @sumaConcediuBoalaFirma as money
declare @sumaConcediuBoalaBASS as money
declare @venitBrut as money
declare @bazaCalculContribIndivSomaj as money
declare @bazaCalculContribIndivAsigSociale as money
declare @bazaCalculContribIndivAsigSanatate as money
declare @contribIndivSomaj as money
declare @contribIndivAsigSociale as money
declare @contribIndivAsigSanatate as money
declare @venitNet as money
declare @deduceriPersonale as money
declare @venitImpozabil as money
declare @impozit as money
declare @alteDrepturi as money
declare @alteDrepturiNet as money
declare @alteDrepturiBrut as money
declare @ajutorDeces money
declare @salariulNet as money
declare @retineri as money
declare @regularizare money
declare @totalRetineri as money
declare @restPlata as money
declare @nrConcediiMedicale as int
--venitul brut a fost recalculat ca o suma de mai multi membri
declare @salariulIncadrareRealizat as bigint
declare @indemnizatieConducereRealizata as  bigint
declare @drepturiBanestiConcediuOdihna as bigint
declare @drepturiBanestiConcediuEvDeosebite as bigint
declare @drepturiBanestiOreSuplimentare as bigint
--ADDED: Ionel Popa
declare @bazaCalculContribSupDinCAS money
declare @ContributieFondSanDinAsigSoc money
--ADDED: Ionel Popa
--baza de calcul al contributiei de somaj a angajatorului, APLICATA PE UN ANGAJAT: bcu1som
declare @BCSomajUnitateIndiv money
declare @BCSomajUnitateIndivID int --id-ul tipului bazei
--baza de calcul al contributiei unitatii la asigurarile sociale, APLICATA PE UN ANGAJAT: bccu1as
declare @BCAsigSocUnitateIndiv money
declare @BCAsigSocUnitateIndivID int --id-ul tipului bazei
--baza de calcul al contributiei angajatorului la fondul de accidente de munca si boli profesionale, APLICATA PE UN ANGAJAT: bcu1risc
declare @BCFondAccidBoliUnitateIndiv money
declare @BCFondAccidBoliUnitateIndivID int --id-ul tipului bazei
--baza de calcul al contributiei unitatii la fondul de solidaritate cu persoanele cu dizabilitati, APLICATA PE UN ANGAJAT: bcu1sol
declare @BCFondSolidaritateUnitateIndiv money
declare @BCFondSolidaritateUnitateIndivID int --id-ul tipului bazei
--baza de calcul al contributiei unitatii la directia de munca si protectie sociala, APLICATA PE UN ANGAJAT: bcu1dmps
declare @BCDirectiaMuncaUnitateIndiv money
declare @BCDirectiaMuncaUnitateIndivID int --id-ul tipului bazei
--baza de calcul al contributiei de sanatate a angajatorului, APLICATA PE UN ANGAJAT: bcu1san
declare @BCSanatateUnitateIndiv money
declare @BCSanatateUnitateIndivID int --id-ul tipului bazei
--contributia unitatii la asigurarile sociale, APLICATA PE UN ANGAJAT: cu1cas
declare @ContribAsigSocialeUnitateIndiv money
declare @ContribAsigSocialeUnitateIndivID int --id-ul tipului contributiei
--contributia unitatii la directia de munca si protectie sociala, APLICATA PE UN ANGAJAT: cu1dmps
declare @ContribDirMuncaUnitateIndiv money
declare @ContribDirMuncaUnitateIndivID int --id-ul tipului contributiei
--contributia angajatorului la fondul de accidente de munca si boli profesionale, APLICATA PE UN ANGAJAT: cu1risc
declare @ContribFondAccidBoliUnitateIndiv money
declare @ContribFondAccidBoliUnitateIndivID int --id-ul tipului contributiei
--contributia de somaj a angajatorului, APLICATA PE UN ANGAJAT: cu1som
declare @ContribSomajUnitateIndiv money
declare @ContribSomajUnitateIndivID int --id-ul tipului contributiei
--contributia de sanatate a angajatorului, APLICATA PE UN ANGAJAT: cu1san
declare @ContribSanUnitateIndiv money
declare @ContribSanUnitateIndivID int --id-ul tipului contributiei
--contributia unitatii la fondul de solidaritate cu persoanele cu dizabilitati, APLICATA PE UN ANGAJAT: cu1sol
declare @ContribFonsSolidaritateUnitateIndiv money
declare @ContribFonsSolidaritateUnitateIndivID int --id-ul tipului contributiei


--extragem id-ul angajatorului
set @AngajatorID = (select AngajatorID from Angajati where AngajatID = @AngajatID)

--este afisat id-ul angajatului
print 'AngajatID = ' + cast(@angajatID as nvarchar(32))

--calculam tariful orar
exec spCalculTarifOrarAngajat @AngajatID, @LunaID, @tarifOrar  OUTPUT
print 'Tarif orar = ' + cast(@tarifOrar as nvarchar(32))

--calculam indemnizatia pentru concediu de boala
exec spCalculIndemnizatieConcediuMedicalAngajat @AngajatID, @LunaID, 'CM', @indemnizatieConcediuMedical OUTPUT
set @indemnizatieConcediuMedical = [SiemensHR_Test].[dbo].[RoundUpSumOfMoney]( @indemnizatieConcediuMedical, 0)
print 'Indemnizatie concediu medical = ' + cast(@indemnizatieConcediuMedical as nvarchar(32))
	
--MODIFIED: Cristina Muntean... calcul sume concediu boala platite de firma si de BASS
exec spCalculSumeConcediuBoalaFirmaSiBass @AngajatID, @LunaID, @sumaConcediuBoalaFirma OUTPUT , @sumaConcediuBoalaBASS OUTPUT 
--suma de concediu de boala platita de firma
SET @sumaConcediuBoalaFirma = [SiemensHR_Test].[dbo].[RoundUpSumOfMoney]( @sumaConcediuBoalaFirma, 0)
print 'Suma concediu boala firma = ' + cast(@sumaConcediuBoalaFirma as nvarchar(32))
--suma de concediu de boala platita de BASS
SET @sumaConcediuBoalaBASS = @indemnizatieConcediuMedical -  @sumaConcediuBoalaFirma
print 'Suma concediu boala BASS = ' + cast(@sumaConcediuBoalaBASS as nvarchar(32))

--MODIFIED:Cristina Muntean ... calcul @alteDrepturi
--calculam alte drepturi in valoare bruta
set @alteDrepturiBrut = (SELECT  AlteDrepturi
					FROM Sal_SituatieLunaraAngajati INNER JOIN
					Angajati ON Sal_SituatieLunaraAngajati.AngajatID=Angajati.AngajatID
					WHERE Sal_SituatieLunaraAngajati.AngajatID=@AngajatID AND Sal_SituatieLunaraAngajati.LunaID=@LunaID)

set @ajutorDeces = (SELECT  AjutorDeces
					FROM Sal_SituatieLunaraAngajati INNER JOIN
					Angajati ON Sal_SituatieLunaraAngajati.AngajatID=Angajati.AngajatID
					WHERE Sal_SituatieLunaraAngajati.AngajatID=@AngajatID AND Sal_SituatieLunaraAngajati.LunaID=@LunaID)
					
set @alteDrepturiNet =(SELECT  AlteDrepturiNet
					FROM Sal_SituatieLunaraAngajati INNER JOIN
					Angajati ON Sal_SituatieLunaraAngajati.AngajatID=Angajati.AngajatID
					WHERE Sal_SituatieLunaraAngajati.AngajatID=@AngajatID AND Sal_SituatieLunaraAngajati.LunaID=@LunaID)

if(@alteDrepturiNet<>0)					
	--calculam valoarea bruta pentru alte drepturi in valoare neta
	exec spCalculAlteDrepturiBrut @AngajatID, @LunaID, @alteDrepturiNet OUTPUT

--calculam total alte drepturi in valoare bruta
set @alteDrepturi = @alteDrepturiNet + @alteDrepturiBrut + @ajutorDeces

print 'alte drepturi = ' + cast(@alteDrepturi as nvarchar(32))

--calculam salariul incadrare angajat necesar in calculul venitului brut
exec spCalculSalariuIncadrareRealizat @LunaID, @AngajatID, @salariulIncadrareRealizat OUTPUT
print 'salariul incadrare realizat = ' + cast( @salariulIncadrareRealizat as nvarchar(32))

--calculam indemnizatia de conducere realizata necesata in calculul venitului brut
exec spCalculIndemnizatieConducereRealizata @LunaID, @AngajatID, @indemnizatieConducereRealizata OUTPUT
print 'indemnizatia incadrare realizat = ' + cast( @indemnizatieConducereRealizata as nvarchar(32))

--calculam drepturile banesti aferente concediului de odihna; sunt necesare in calculul venitului brut
exec spCalculDrepturiBanestiConcediuOdihna @LunaID, @AngajatID, @drepturiBanestiConcediuOdihna OUTPUT
print 'drepturi banesti concediu odihnarealizat = ' + cast( @drepturiBanestiConcediuOdihna as nvarchar(32))

--calculam drepturile banesti aferente concediului de evenimente deosebite; sunt necesare in calculul venitului brut
exec spCalculDrepturiBanestiConcediuEvDeosebite @LunaID, @AngajatID, @drepturiBanestiConcediuEvDeosebite OUTPUT
print 'drepturi banesti concediu ev deosebite = ' + cast( @drepturiBanestiConcediuEvDeosebite as nvarchar(32))


--calculam drepturile banesti aferente orelor suplimentare; sunt necesare in calculul venitului brut
exec spCalculDrepturiBanestiOreSuplimentare @LunaID, @AngajatID, @tarifOrar, @drepturiBanestiOreSuplimentare OUTPUT
print 'drepturi banesti ore suplimentare = ' + cast( @drepturiBanestiOreSuplimentare as nvarchar(32))


--calculam venitul brut
--exec spCalculVenitBrutAngajat @AngajatID, @LunaID, @tarifOrar, @indemnizatieConcediuMedical, @alteDrepturi, @venitBrut OUTPUT
exec spCalculVenitBrutAngajat @AngajatID, @LunaID, @tarifOrar, @indemnizatieConcediuMedical, @alteDrepturi, @salariulIncadrareRealizat, @indemnizatieConducereRealizata, @drepturiBanestiConcediuOdihna, @drepturiBanestiConcediuEvDeosebite, @drepturiBanestiOreSuplimentare, @venitBrut OUTPUT 
print 'venit brut = ' + cast(@venitBrut as nvarchar(32))

-- calculam baza calcul a contributiei individuale la somaj
exec spCalculBazaContributieIndivSomaj @LunaID, @AngajatID, @tarifOrar,  @bazaCalculContribIndivSomaj OUTPUT
print 'baza somaj = ' + cast(@bazaCalculContribIndivSomaj as nvarchar(32))

--calculam baza calcul a contributiei individuale la asigurarile sociale
exec spCalculBazaCalcAsigSocialeAngajat @LunaID, @AngajatID, @indemnizatieConcediuMedical, @venitBrut,  @bazaCalculContribIndivAsigSociale OUTPUT
print 'baza asigurari sociale = ' + cast(@bazaCalculContribIndivAsigSociale as nvarchar(32))

--calculam baza de calcul a  contributiei individuale la asigurarile de sanatate
exec spCalculBazaCalcAsigDeSanatateAngajat @AngajatID, @LunaID, @indemnizatieConcediuMedical, @venitBrut,  @bazaCalculContribIndivAsigSanatate OUTPUT
print 'baza sanatate = ' + cast(@bazaCalculContribIndivAsigSanatate as nvarchar(32))

--ADDED: Ionel Popa
--calculam baza de calcul a contributiei angajatului la fondul de sanatate aferent concediilor medicale de orice tip
exec spCalculBazaCalcContribSupDinCAS @LunaID, @AngajatID, @bazaCalculContribSupDinCAS OUTPUT

--calculam contributia individuala la fondul de somaj
exec spCalculContributieIndivSomaj @LunaID, @AngajatID,  @bazaCalculContribIndivSomaj,  @contribIndivSomaj OUTPUT
set @contribIndivSomaj = round( @contribIndivSomaj, 0)
print 'contributie somaj = ' + cast(@contribIndivSomaj as nvarchar(32))

--calculam  contributia individuala la asigurarile sociale
exec spCalculContributieIndivAsigSociale @LunaID, @AngajatID,  @bazaCalculContribIndivAsigSociale,  @contribIndivAsigSociale OUTPUT
set @contribIndivAsigSociale = round( @contribIndivAsigSociale, 0)
print 'contributie asigurari sociale = ' + cast(@contribIndivAsigSociale as nvarchar(32))

--calculam contributia individuala la asigurarile de sanatate
exec spCalculContributieIndivAsigSanatate @LunaID, @AngajatID, @bazaCalculContribIndivAsigSanatate, @contribIndivAsigSanatate OUTPUT
set @contribIndivAsigSanatate = round( @contribIndivAsigSanatate, 0)
print 'contributie sanatate = ' + cast(@contribIndivAsigSanatate as nvarchar(32))

--ADDED: Ionel Popa
--calculam contributia la fondul de sanatate aferenta concediilor de boala care e suportata din bugetul asigurarilor sociale
exec spCalculContributieFondSanDinCas @LunaID, @AngajatID, @bazaCalculContribSupDinCAS ,@ContributieFondSanDinAsigSoc OUTPUT

--calculam venitul net
exec spCalculVenitNet @LunaID, @AngajatID, @venitBrut, @contribIndivSomaj, @contribIndivAsigSanatate,  @contribIndivAsigSociale,  @venitNet OUTPUT
print 'venit net = ' + cast(@venitNet as nvarchar(32))

--calculam deducerile personale pentru angajat
exec spCalculDeduceriPersonale @LunaID, @AngajatID, @venitBrut, 5, @deduceriPersonale OUTPUT
print 'deduceri personale = ' + cast(@deduceriPersonale as nvarchar(32))

--calculam venitul impozabil pentru angajat
exec spCalculVenitImpozabil @LunaID, @AngajatID, @venitNet, @deduceriPersonale,  @venitImpozabil OUTPUT
print 'venit impozabil = ' + cast(@venitImpozabil as nvarchar(32))

--calculam impozitul platit de angajat
exec spCalculImpozit @LunaID, @AngajatID, @venitImpozabil, @impozit OUTPUT
--added: Muntean Raluca Cristina 26.08.2005
--se face rotunjirea
set @impozit = [SiemensHR_Test].[dbo].[RoundUpSumOfMoney]( @impozit, 0)
print 'impozit = ' + cast(@impozit as nvarchar(32))

--calculam salariul net al angajatului
exec spCalculSalariuNet @LunaID, @AngajatID, @venitNet, @impozit, @salariulNet OUTPUT
print 'salariu net = ' + cast(@salariulNet as nvarchar(32))

--MODIFIED: Cristina Muntean ... calcul total retineri
--calculam total retineri angajat
exec spCalculRetineriAngajat @LunaID, @AngajatID, @retineri OUTPUT
print 'retineri = ' + cast(@retineri as nvarchar(32))

--calculam restul de plata al angajatului
exec spCalculRestPlata @LunaID, @AngajatID, @salariulNet, @retineri, @restPlata OUTPUT
print 'Rest plata = ' + cast(@restPlata as nvarchar(32))

--MODIFIED: Cristina Muntean ... sunt inserate datele in tabele
--suma primelor
set @prime = (SELECT (PrimeProiect+PrimeSpeciale)as prime
              FROM sal_SituatieLunaraAngajati
              WHERE AngajatID=@AngajatID AND LunaID=@LunaID) 

--avans
set @avans = (SELECT Avans
              FROM sal_SituatieLunaraAngajati
              WHERE AngajatID=@AngajatID AND LunaID=@LunaID) 
       
--alte retineri       
set @alteRetineri = (SELECT Retineri
              FROM sal_SituatieLunaraAngajati
              WHERE AngajatID=@AngajatID AND LunaID=@LunaID) 

--se calculeaza totalul retinerilor dupa formula:
--totalRetineri = avans + alteRetineri + contributieIndividualaSomaj + contributieIndividualaAsigurariSociale + contributieIndividualaAsigurariSanatate + impozit      
set @totalRetineri = @retineri + @contribIndivSomaj + @contribIndivAsigSociale + @contribIndivAsigSanatate + @impozit

--ADDED: Muntean Raluca Cristina 
set @regularizare = (SELECT Regularizare
              FROM sal_SituatieLunaraAngajati
              WHERE AngajatID=@AngajatID AND LunaID=@LunaID) 

--este inserata o inregistrare in tabela sal_StatDePlata
begin tran IStatDePlata
	insert into sal_StatDePlata with(xlock) (AngajatID, LunaID, Prime, AlteDrepturi, IndemnizatieConcediuMedical,
	VenitBrut, VenitNet, DeduceriPersonale, BazaImpozitare, Impozit, SalariuNet, Avans, Retineri, Regularizare, TotalRetineri,
	RestDePlata, SalariuIncadrareRealizat, IndemnizatieConducereRealizata, DrepturiBanestiConcediuOdihna, 
	DrepturiBanestiConcediuEvDeosebite, DrepturiBanestiOreSuplimentare, SumaConcediuBoalaFirma, SumaConcediuBoalaBASS, AjutorDeces) 
	values (@AngajatID, @LunaID, @prime, @alteDrepturi, @indemnizatieConcediuMedical,
	@venitBrut, @venitNet, @deduceriPersonale, @venitImpozabil, @impozit, @salariulNet, @avans, @alteRetineri, @regularizare, @totalRetineri,
	@restPlata, @salariulIncadrareRealizat, @indemnizatieConducereRealizata, @drepturiBanestiConcediuOdihna, 
	@drepturiBanestiConcediuEvDeosebite, @drepturiBanestiOreSuplimentare, @sumaConcediuBoalaFirma, @sumaConcediuBoalaBASS, @ajutorDeces) 
	if(@@ERROR <> 0)
	begin
		rollback tran IStatDePlata
	end
	else
	begin
		commit tran IStatDePlata
	end


--ADDED: Ionel Popa
--calculam baza de calcul al contributiei de somaj a angajatorului, APLICATA PE UN ANGAJAT: bcu1som
exec spCalculBazaCalculContributieSomajAngajator 0 , @AngajatID, @LunaID, @BCSomajUnitateIndiv output
print 'Baza de calcul al contributiei de somaj a angajatorului ANGAJAT = ' + cast(@BCSomajUnitateIndiv as nvarchar(32))

--calculam baza de calcul al contributiei unitatii la asigurarile sociale, APLICATA PE UN ANGAJAT: bccu1as
exec spCalculBazaCalcAsigSocialeUnitate 0, 0, @AngajatID, @LunaID, @BCAsigSocUnitateIndiv output
print 'Baza de calcul al contributiei unitatii la asigurarile sociale ANGAJAT = ' + cast(@BCAsigSocUnitateIndiv as nvarchar(32))

--calculam baza de calcul al contributiei angajatorului la fondul de accidente de munca si boli profesionale, APLICATA PE UN ANGAJAT: bcu1risc
exec spCalculBazaCalculFondRiscUnitate @LunaID, 0, @AngajatID, @BCFondAccidBoliUnitateIndiv output
print 'Baza de calcul al contributiei angajatorului la fondul de accidente de munca si boli profesionale ANGAJAT = ' + cast(@BCFondAccidBoliUnitateIndiv as nvarchar(32))

--calculam baza de calcul al contributiei unitatii la fondul de solidaritate cu persoanele cu dizabilitati, APLICATA PE UN ANGAJAT: bcu1sol
exec spCalculBazaCalculFondSolidaritateUnitate 0, @LunaID, @AngajatID, @BCFondSolidaritateUnitateIndiv output
print 'Baza de calcul al contributiei unitatii la fondul de solidaritate cu persoanele cu dizabilitati ANGAJAT = ' + cast(@BCFondSolidaritateUnitateIndiv as nvarchar(32))

-- calculam baza de calcul al contributiei unitatii la directia de munca si protectie sociala, APLICATA PE UN ANGAJAT: bcu1dmps
exec spCalculBazaCalculDirectiaDeMuncaUnitate @LunaID, 0, @AngajatID, @BCDirectiaMuncaUnitateIndiv output
print 'Baza de calcul al contributiei unitatii la directia de munca si protectie sociala ANGAJAT = ' + cast(@BCDirectiaMuncaUnitateIndiv as nvarchar(32))

--calculam baza de calcul al contributiei de sanatate a angajatorului, APLICATA PE UN ANGAJAT: bcu1san
exec spCalculBazaCalculSanatateUnitate @LunaID, 0, @AngajatID, @BCSanatateUnitateIndiv output
print 'Baza de calcul al contributiei de sanatate a angajatorului ANGAJAT = ' + cast(@BCSanatateUnitateIndiv as nvarchar(32))

--calculam contributia unitatii la asigurarile sociale, APLICATA PE UN ANGAJAT: cu1cas
exec spCalculContributieAsigSocialeUnitate @LunaID, @BCAsigSocUnitateIndiv, @ContribAsigSocialeUnitateIndiv output
print 'Contributia unitatii la asigurarile sociale ANGAJAT = ' + cast(@ContribAsigSocialeUnitateIndiv as nvarchar(32))

--calculam contributia unitatii la directia de munca si protectie sociala, APLICATA PE UN ANGAJAT: cu1dmps
exec spCalculContributieDirMuncaProtSociala @LunaID, @AngajatorID, @BCDirectiaMuncaUnitateIndiv, @ContribDirMuncaUnitateIndiv output
print 'Contributia unitatii la directia de munca si protectie sociala ANGAJAT = ' + cast(@ContribDirMuncaUnitateIndiv as nvarchar(32))

--calculam contributia angajatorului la fondul de accidente de munca si boli profesionale, APLICATA PE UN ANGAJAT: cu1risc
exec spCalculContributieFondAccidenteSiBoliUnitate @AngajatorID, @LunaID, @BCFondAccidBoliUnitateIndiv, @ContribFondAccidBoliUnitateIndiv output
print 'Contributia angajatorului la fondul de accidente de munca si boli profesionale ANGAJAT = ' + cast(@ContribFondAccidBoliUnitateIndiv as nvarchar(32))

--calculam contributia de somaj a angajatorului, APLICATA PE UN ANGAJAT: cu1som
exec spCalculContributieSomajUnitate @LunaID, @BCSomajUnitateIndiv, @ContribSomajUnitateIndiv output
print 'Contributia de somaj a angajatorului ANGAJAT = ' + cast(@ContribSomajUnitateIndiv as nvarchar(32))

--calculam contributia de sanatate a angajatorului, APLICATA PE UN ANGAJAT: cu1san
exec spCalculContributieSanatateUnitate @LunaID, @BCSanatateUnitateIndiv, @ContribSanUnitateIndiv output
print 'Contributia de sanatate a angajatorului ANGAJAT = ' + cast(@ContribSanUnitateIndiv as nvarchar(32))

--calculam contributia unitatii la fondul de solidaritate cu persoanele cu dizabilitati, APLICATA PE UN ANGAJAT: cu1sol
exec spCalculContributieFondSolidaritateUnitate @LunaID, @BCFondSolidaritateUnitateIndiv, @ContribFonsSolidaritateUnitateIndiv output
print 'Contributia unitatii la fondul de solidaritate cu persoanele cu dizabilitati ANGAJAT = ' + cast(@ContribFonsSolidaritateUnitateIndiv as nvarchar(32))

--Se insereaza bazele de calcul si contributiile in baza de date
--mai intai se calculeaza id-urile tipurilor de baze de calcul si a contributiilor conform codurile
--este obtinut id-ul pentru fiecare baza de calcul
set @bcContribIndivSomajID = (SELECT BazaCalculID
							  FROM sal_BazeCalculTipuri
							  WHERE Cod = 'BCISOM')
--print 'bcContribIndivSomajID = ' + cast(@bcContribIndivSomajID as nvarchar(32))
							  
set @bcContribIndivAsigSocialeID = (SELECT BazaCalculID
							  FROM sal_BazeCalculTipuri
							  WHERE Cod = 'BCICAS')
--print 'bcContribIndivAsigSocialeID = ' + cast(@bcContribIndivAsigSocialeID as nvarchar(32))

set @bcContribIndivAsigSanatateID = (SELECT BazaCalculID
							  FROM sal_BazeCalculTipuri
							  WHERE Cod = 'BCISAN')

--print 'bcContribIndivAsigSanatateID = ' + cast(@bcContribIndivAsigSanatateID as nvarchar(32))

set @bazaCalculContribSupDinCASID = (
					SELECT BazaCalculID
							  FROM sal_BazeCalculTipuri
							  WHERE Cod = 'BCSANDINCAS'
					)
--ADDED: Ionel Popa
--se calculeaza id-urile bazelor de calcul pentru contributiile angajatorului raportate la fiecare individ
set @BCSomajUnitateIndivID = (
					SELECT BazaCalculID
							  FROM sal_BazeCalculTipuri
							  WHERE Cod = 'BCU1SOM'
					)
print '@BCSomajUnitateIndivID = ' + cast(@BCSomajUnitateIndivID as nvarchar(32))

set @BCAsigSocUnitateIndivID = (
					SELECT BazaCalculID
							  FROM sal_BazeCalculTipuri
							  WHERE Cod = 'BCCU1AS'
					)
print '@BCAsigSocUnitateIndivID = ' + cast(@BCAsigSocUnitateIndivID as nvarchar(32))

					
set @BCFondAccidBoliUnitateIndivID = (
					SELECT BazaCalculID
							  FROM sal_BazeCalculTipuri
							  WHERE Cod = 'BCU1RISC'
					)
print '@BCFondAccidBoliUnitateIndivID = ' + cast(@BCFondAccidBoliUnitateIndivID as nvarchar(32))

					
set @BCFondSolidaritateUnitateIndivID = (
					SELECT BazaCalculID
							  FROM sal_BazeCalculTipuri
							  WHERE Cod = 'BCU1SOL'
					)
print '@BCFondSolidaritateUnitateIndivID = ' + cast(@BCFondSolidaritateUnitateIndivID as nvarchar(32))


set @BCDirectiaMuncaUnitateIndivID = (
					SELECT BazaCalculID
							  FROM sal_BazeCalculTipuri
							  WHERE Cod = 'BCU1DMPS'
					)
print '@BCDirectiaMuncaUnitateIndivID = ' + cast(@BCDirectiaMuncaUnitateIndivID as nvarchar(32))

					
set @BCSanatateUnitateIndivID = (
					SELECT BazaCalculID
							  FROM sal_BazeCalculTipuri
							  WHERE Cod = 'BCU1SAN'
					)
print '@BCSanatateUnitateIndivID = ' + cast(@BCSanatateUnitateIndivID as nvarchar(32))

					
--sunt inserate bazele de calcul in tabela sal_BazaCalculLuna
--baza de calcul al contributiei individuale la somaj
begin tran IBazaCalculIndivSomaj
	insert into sal_BazeCalculLuna with(xlock) (AngajatID, BazaCalculID, LunaID, Valoare) 
	values (@AngajatID, @bcContribIndivSomajID, @LunaID, @bazaCalculContribIndivSomaj) 
	if(@@ERROR <> 0)
	begin
		rollback tran IBazaCalculIndivSomaj
	end
	else
	begin
		commit tran IBazaCalculIndivSomaj
	end

--baza de calcul al contributiei individuale de asigurari sociale	
begin tran IBContribIndivAsigSociale
	insert into sal_BazeCalculLuna with(xlock) (AngajatID, BazaCalculID, LunaID, Valoare) 
	values (@AngajatID, @bcContribIndivAsigSocialeID, @LunaID, @bazaCalculContribIndivAsigSociale) 
	if(@@ERROR <> 0)
	begin
		rollback tran IBCContribIndivAsigSociale
	end
	else
	begin
		commit tran IBCContribIndivAsigSociale
	end
	
--baza de calcul al contributiei individuale de asigurari de sanatate	
begin tran IBCContribIndivAsigSanatate
	insert into sal_BazeCalculLuna with(xlock) (AngajatID, BazaCalculID, LunaID, Valoare) 
	values (@AngajatID, @bazaCalculContribSupDinCASID, @LunaID, @bazaCalculContribSupDinCAS) 
	if(@@ERROR <> 0)
	begin
		rollback tran IBCContribIndivAsigSanatate
	end
	else
	begin
		commit tran IBCContribIndivAsigSanatate
	end

--baza de calcul a contributiei angajatului la fondul de sanatate aferent concediilor medicale de orice tip
begin tran IBCContribFondSanSupAsigSoc
	insert into sal_BazeCalculLuna with(xlock) (AngajatID, BazaCalculID, LunaID, Valoare) 
	values (@AngajatID, @bcContribIndivAsigSanatateID, @LunaID, @bazaCalculContribIndivAsigSanatate) 
	if(@@ERROR <> 0)
	begin
		rollback tran IBCContribFondSanSupAsigSoc
	end
	else
	begin
		commit tran IBCContribFondSanSupAsigSoc
	end

--ADDED: Ionel Popa
--inseram contributiile angajatorului raportate la individ in baza de date

-- bcu1som
begin tran IBCSomajUnitateIndiv
	insert into sal_BazeCalculLuna with(xlock) (AngajatID, BazaCalculID, LunaID, Valoare) 
	values (@AngajatID, @BCSomajUnitateIndivID, @LunaID, @BCSomajUnitateIndiv) 
	if(@@ERROR <> 0)
	begin
		rollback tran IBCSomajUnitateIndiv
	end
	else
	begin
		commit tran IBCSomajUnitateIndiv
	end

--bccu1as
begin tran IBCAsigSocUnitateIndiv
	insert into sal_BazeCalculLuna with(xlock) (AngajatID, BazaCalculID, LunaID, Valoare) 
	values (@AngajatID, @BCAsigSocUnitateIndivID, @LunaID, @BCAsigSocUnitateIndiv) 
	if(@@ERROR <> 0)
	begin
		rollback tran IBCAsigSocUnitateIndiv
	end
	else
	begin
		commit tran IBCAsigSocUnitateIndiv
	end

--bcu1risc
begin tran IBCFondAccidBoliUnitateIndiv
	insert into sal_BazeCalculLuna with(xlock) (AngajatID, BazaCalculID, LunaID, Valoare) 
	values (@AngajatID, @BCFondAccidBoliUnitateIndivID, @LunaID, @BCFondAccidBoliUnitateIndiv) 
	if(@@ERROR <> 0)
	begin
		rollback tran IBCFondAccidBoliUnitateIndiv
	end
	else
	begin
		commit tran IBCFondAccidBoliUnitateIndiv
	end

--bcu1sol
begin tran IBCFondSolidaritateUnitateIndiv
	insert into sal_BazeCalculLuna with(xlock) (AngajatID, BazaCalculID, LunaID, Valoare) 
	values (@AngajatID, @BCFondSolidaritateUnitateIndivID, @LunaID, @BCFondSolidaritateUnitateIndiv) 
	if(@@ERROR <> 0)
	begin
		rollback tran IBCFondSolidaritateUnitateIndiv
	end
	else
	begin
		commit tran IBCFondSolidaritateUnitateIndiv
	end

--bcu1dmps
begin tran IBCDirectiaMuncaUnitateIndiv
	insert into sal_BazeCalculLuna with(xlock) (AngajatID, BazaCalculID, LunaID, Valoare) 
	values (@AngajatID, @BCDirectiaMuncaUnitateIndivID, @LunaID, @BCDirectiaMuncaUnitateIndiv) 
	if(@@ERROR <> 0)
	begin
		rollback tran IBCDirectiaMuncaUnitateIndiv
	end
	else
	begin
		commit tran IBCDirectiaMuncaUnitateIndiv
	end

--bcu1san
begin tran IBCSanatateUnitateIndiv
	insert into sal_BazeCalculLuna with(xlock) (AngajatID, BazaCalculID, LunaID, Valoare) 
	values (@AngajatID, @BCSanatateUnitateIndivID, @LunaID, @BCSanatateUnitateIndiv) 
	if(@@ERROR <> 0)
	begin
		rollback tran IBCSanatateUnitateIndiv
	end
	else
	begin
		commit tran IBCSanatateUnitateIndiv
	end


	
--este obtinut id-ul pentru fiecare contributie
set @contribIndivSomajID = (SELECT ContributieIndivID
							  FROM sal_ContributiiIndivTipuri
							  WHERE Cod = 'CISOM')
--print 'contribIndivSomajID = ' + cast(@contribIndivSomajID as nvarchar(32))
							  
set @contribIndivAsigSocialeID = (SELECT ContributieIndivID
							  FROM sal_ContributiiIndivTipuri
							  WHERE Cod = 'CICAS')
--print 'contribIndivAsigSocialeID = ' + cast(@contribIndivAsigSocialeID as nvarchar(32))

set @contribIndivAsigSanatateID = (SELECT ContributieIndivID
							  FROM sal_ContributiiIndivTipuri
							  WHERE Cod = 'CISAN')	
--print 'contribIndivAsigSanatateID = ' + cast(@contribIndivAsigSanatateID as nvarchar(32))

set @ContributieFondSanDinAsigSocID = (SELECT ContributieIndivID
							  FROM sal_ContributiiIndivTipuri
							  WHERE Cod = 'CSANCBDINCAS')	
						  
--ADDED: Ionel Popa
--extragem id-urile tipurilor de contributii ale angajatorului raportate la individ

set @ContribAsigSocialeUnitateIndivID = (SELECT ContributieIndivID
							  FROM sal_ContributiiIndivTipuri
							  WHERE Cod = 'CU1CAS')

print '@ContribAsigSocialeUnitateIndivID = ' + cast(@ContribAsigSocialeUnitateIndivID as nvarchar(32))
							  
set @ContribDirMuncaUnitateIndivID = (SELECT ContributieIndivID
							  FROM sal_ContributiiIndivTipuri
							  WHERE Cod = 'CU1DMPS')

print '@ContribDirMuncaUnitateIndivID = ' + cast(@ContribDirMuncaUnitateIndivID as nvarchar(32))

							  
set @ContribFondAccidBoliUnitateIndivID = (SELECT ContributieIndivID
							  FROM sal_ContributiiIndivTipuri
							  WHERE Cod = 'CU1RISC')

print '@ContribFondAccidBoliUnitateIndivID = ' + cast(@ContribFondAccidBoliUnitateIndivID as nvarchar(32))

							  
set @ContribSomajUnitateIndivID = (SELECT ContributieIndivID
							  FROM sal_ContributiiIndivTipuri
							  WHERE Cod = 'CU1SOM')
							  
print '@ContribSomajUnitateIndivID = ' + cast(@ContribSomajUnitateIndivID as nvarchar(32))
							  
							  
set @ContribSanUnitateIndivID = (SELECT ContributieIndivID
							  FROM sal_ContributiiIndivTipuri
							  WHERE Cod = 'CU1SAN')
							  
print '@ContribSanUnitateIndivID = ' + cast(@ContribSanUnitateIndivID as nvarchar(32))
							  
							  
set @ContribFonsSolidaritateUnitateIndivID = (SELECT ContributieIndivID
							  FROM sal_ContributiiIndivTipuri
							  WHERE Cod = 'CU1SOL')					  

print '@ContribFonsSolidaritateUnitateIndivID = ' + cast(@ContribFonsSolidaritateUnitateIndivID as nvarchar(32))



--sunt inserate contributiile individuale in tabela sal_ContributiiIndivLuna
--contributia individuale la somaj
begin tran IContribIndivSomaj
	insert into sal_ContributiiIndivLuna with(xlock) (AngajatID, ContributieIndivID, LunaID, Valoare) 
	values (@AngajatID, @contribIndivSomajID, @LunaID, @contribIndivSomaj) 
	if(@@ERROR <> 0)
	begin
		rollback tran IContribIndivSomaj
	end
	else
	begin
		commit tran IContribIndivSomaj
	end

--baza de calcul al contributiei individuale de asigurari sociale	
begin tran ICalculContribIndivAsigSociale
	insert into sal_ContributiiIndivLuna with(xlock) (AngajatID, ContributieIndivID, LunaID, Valoare) 
	values (@AngajatID, @contribIndivAsigSocialeID, @LunaID, @contribIndivAsigSociale) 
	if(@@ERROR <> 0)
	begin
		rollback tran IContribIndivAsigSociale
	end
	else
	begin
		commit tran IContribIndivAsigSociale
	end
	
--baza de calcul al contributiei individuale de asigurari de sanatate	
begin tran IContribIndivAsigSanatate
	insert into sal_ContributiiIndivLuna with(xlock) (AngajatID, ContributieIndivID, LunaID, Valoare) 
	values (@AngajatID, @contribIndivAsigSanatateID, @LunaID, @contribIndivAsigSanatate) 

	if(@@ERROR <> 0)
	begin
		rollback tran IContribIndivAsigSanatate
	end
	else
	begin
		commit tran IContribIndivAsigSanatate
	end

-- contributia la fondul de sanatate aferenta CB care e suportata din bugetul asigurarilor sociale
begin tran IContribFondSanSupAsigSoc
	insert into sal_ContributiiIndivLuna with(xlock) (AngajatID, ContributieIndivID, LunaID, Valoare) 
	values (@AngajatID, @ContributieFondSanDinAsigSocID, @LunaID, @ContributieFondSanDinAsigSoc) 

	if(@@ERROR <> 0)
	begin
		rollback tran IContribFondSanSupAsigSoc
	end
	else
	begin
		commit tran IContribFondSanSupAsigSoc
	end

--ADDED: Ionel Popa
--inseram contributiile in baza de date

--cu1cas
begin tran IContribAsigSocialeUnitateIndiv
	insert into sal_ContributiiIndivLuna with(xlock) (AngajatID, ContributieIndivID, LunaID, Valoare) 
	values (@AngajatID, @ContribAsigSocialeUnitateIndivID, @LunaID, @ContribAsigSocialeUnitateIndiv) 

	if(@@ERROR <> 0)
	begin
		rollback tran IContribAsigSocialeUnitateIndiv
	end
	else
	begin
		commit tran IContribAsigSocialeUnitateIndiv
	end

--cu1dmps
begin tran IContribDirMuncaUnitateIndiv
	insert into sal_ContributiiIndivLuna with(xlock) (AngajatID, ContributieIndivID, LunaID, Valoare) 
	values (@AngajatID, @ContribDirMuncaUnitateIndivID, @LunaID, @ContribDirMuncaUnitateIndiv) 

	if(@@ERROR <> 0)
	begin
		rollback tran IContribDirMuncaUnitateIndiv
	end
	else
	begin
		commit tran IContribDirMuncaUnitateIndiv
	end

--cu1risc
begin tran ICFondAccidBoliUnitateIndiv
	insert into sal_ContributiiIndivLuna with(xlock) (AngajatID, ContributieIndivID, LunaID, Valoare) 
	values (@AngajatID, @ContribFondAccidBoliUnitateIndivID, @LunaID, @ContribFondAccidBoliUnitateIndiv) 

	if(@@ERROR <> 0)
	begin
		rollback tran ICFondAccidBoliUnitateIndiv
	end
	else
	begin
		commit tran ICFondAccidBoliUnitateIndiv
	end

--cu1som
begin tran IContribSomajUnitateIndiv
	insert into sal_ContributiiIndivLuna with(xlock) (AngajatID, ContributieIndivID, LunaID, Valoare) 
	values (@AngajatID, @ContribSomajUnitateIndivID, @LunaID, @ContribSomajUnitateIndiv) 

	if(@@ERROR <> 0)
	begin
		rollback tran IContribSomajUnitateIndiv
	end
	else
	begin
		commit tran IContribSomajUnitateIndiv
	end

--cu1san
begin tran IContribSanUnitateIndiv
	insert into sal_ContributiiIndivLuna with(xlock) (AngajatID, ContributieIndivID, LunaID, Valoare) 
	values (@AngajatID, @ContribSanUnitateIndivID, @LunaID, @ContribSanUnitateIndiv) 

	if(@@ERROR <> 0)
	begin
		rollback tran IContribSanUnitateIndiv
	end
	else
	begin
		commit tran IContribSanUnitateIndiv
	end

--cu1sol
begin tran ICFonsSolidaritateUnitateIndiv
	insert into sal_ContributiiIndivLuna with(xlock) (AngajatID, ContributieIndivID, LunaID, Valoare) 
	values (@AngajatID, @ContribFonsSolidaritateUnitateIndivID, @LunaID, @ContribFonsSolidaritateUnitateIndiv) 

	if(@@ERROR <> 0)
	begin
		rollback tran ICFonsSolidaritateUnitateIndiv
	end
	else
	begin
		commit tran ICFonsSolidaritateUnitateIndiv
	end