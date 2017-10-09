/*
	Author: 		Ionel Popa
	Description: 	Calculeaza deducerile personale ... dedp
					dedp = dedp=ROUNDUP(IF(VenitBrut<=1000;250+PersoaneIntretinere*100;IF(VenitBrut>=3000;0;(250+PersoaneIntretinere*100)*(1-(VenitBrut-100)/2000)));-FactorRotunjire)
	Params:			@LunaID in ... id-ul lunii active
					@AngajatID in ... id-ul angajatului pentru care se calculeaza baza de calcul
					@VenitBrut in ... venitul brut al angajatului
					@FactorRotunjire in ... suma se va rotunji la 10^FactorRotunjire
					@DeduceriPersonale out ... deducerile personale pentru angajat
	Change history:
				Ionel Popa: 03 mar 2005
					S-a modificat formula de calcul a deducerilor personale astfel: Atunci cand angajatul are cumul de functii (adica e cu functia de baza la alta societate) deducerile personale sunt egale cu 0.
					In restul cazurilor ramane valabila  formula de mai sus.
				Ionel Popa: 13 oct 2005
					Numarul de persoane in intretinere nu esta acelasi cu numarul de copii. 
					Persoanele in intretinere se tin in tabela AngajatPersoaneIntretinere
*/
ALTER PROCEDURE spCalculDeduceriPersonale
(
	@LunaID int,
	@AngajatID int,
	@VenitBrut money,
	@FactorRotunjire int,
	@DeduceriPersonale money OUTPUT
)
AS

declare @PersoaneIntretinere int
declare @FunctiaDeBazaInAltaSocietate int

--extragem numarul de persoane in intretinere pentru angajatul respectiv
--select @PersoaneIntretinere = NrCopii from angajati where AngajatID = @AngajatID
select @PersoaneIntretinere = count(*) from AngajatPersoaneInIntretinere where AngajatID = @AngajatID

--extragem informatii despre modul de incadrare al angajatului ... daca este sau nu cu functia de incadrare in cadrul societatii
select @FunctiaDeBazaInAltaSocietate = ModIncadrare from angajati where AngajatID = @AngajatID

if @FunctiaDeBazaInAltaSocietate = 1
begin
	set @DeduceriPersonale = 0
	return
end

--calculam deducerile personale
if @VenitBrut <= 1000
	begin
		set @DeduceriPersonale = 250 + 100 * @PersoaneIntretinere
	end
else
	begin
		if @VenitBrut >= 3000
			begin
				set @DeduceriPersonale = 0
			end
		else
			begin
				set @DeduceriPersonale = ( 250 + 100 * @PersoaneIntretinere) * ( 1 - ((@VenitBrut - 1000) / 2000 ))
			end
	end

set @DeduceriPersonale = [SiemensHR_Test].[dbo].[RoundUpSumOfMoney](@DeduceriPersonale, 1)

RETURN 