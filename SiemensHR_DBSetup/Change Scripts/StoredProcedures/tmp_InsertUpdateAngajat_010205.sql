
/*
* Autor:		Mircea Albutiu, PSE RO BS TH
* Nume:			InsertAngajat
* Descriere:	Insereaza un angajat 
* Modificat:    Cristina Raluca Muntean, am adaugat: Sporuri, AlteAdaosuri, NrZileCOSupl, EchIndProtectie,
				EchIndLucru, MatIgiSan, AlimProtectie, AlteDrSiObl, AlteClauzeCIM, PerProba
				Ionel Popa - 07.02.2005: am adaugat un camp nou: AlerteSpeciale precum si adaugarea unui apel de procedura stocata InsertAlerte
				Ionel Popa - 17.08.2005: am adaugat un camp lichidat si pensionat si toate logica din spate
				Ionel Popa - 31.08.2005: atunci cand un angajat se delichideaza se sterge si linia din tabela Lichidari asociata acestei lichidari
*/
ALTER PROCEDURE tmp_InsertUpdateAngajat_010205
(
--Angajat
		@AngajatID int,
		@AngajatorID int,
		@Marca nvarchar(8),
		@Nume nvarchar(50),
		@Prenume nvarchar(50),
		@NumeAnterior nvarchar(50),
		@TitluID int = NULL,
		@Poza image = NULL,
		@StudiuID int,
		@AnAbsolvire nvarchar(4),
		@NrDiploma varchar(50),
		@Descriere nvarchar(100) = NULL,
		@ModIncadrare bit,
		@ProgramLucru tinyint,
		@Telefon nvarchar(25) = NULL,
		@StareCivila tinyint,
		@NrCopii tinyint,
		@Sex char(1),
		@TipFisaFiscala bit,
		@AniVechimeMunca tinyint,
		@LuniVechimeMunca tinyint,
		@ZileVechimeMunca tinyint,
		@AreCardBancar bit,
--pt categoria de incadrare
		@CategorieID int,
--pt perioada determinata
		@PerioadaDeterminata bit,
		@DataPanaLa datetime=NULL,
		@DataDeLa datetime,
--lichidat
		@Lichidat bit,
--pensionat
		@Pensionat bit,
--pt contract munca
       		@NrContractMunca varchar(50),
		@DataInregContractMunca datetime,
		@EchIndProtectie nvarchar(100),
		@EchIndLucru nvarchar(100),
		@MatIgiSan nvarchar(100),
		@AlimProtectie nvarchar(100),
		@AlteDrSiObl nvarchar(100),
		@AlteClauzeCIM nvarchar(100),
		@PerProba nvarchar(50),
-- pt invaliditate
		@Invaliditate smallint,
--pt salariu si indemnizatia de conducere
		@FunctieID int,
		@CentruCostID int,
		@DepartamentID int,
	             @SalariuBaza money,
		@IndemnizatieConducere money,
		@Sporuri money,
		@AlteAdaosuri money,
		@SumaMajorare money = null,
		@DataMajorare datetime = null,
		@NrZileCOAn int,  
		@NrZileCOSupl int,
----------------------------------------------------------------------------------------------
		@SefID int,
--Nationalitate
		--@Nationalitate nvarchar(50),
		@Nationalitate int,
		@DataNasterii datetime,
		@TaraNastereID int,
		@JudetNastereID int,
		@LocalitateNastere nvarchar(50),
		@PrenumeMama nvarchar(50),
		@PrenumeTata nvarchar(50),
--CarteIdentitate
		@CNP numeric,
		@CNPAnterior numeric,
		@SerieCI char(2)='',
		@NumarCI bigint=0,
		@EliberatDeCI nvarchar(50)='',
		@DataEliberariiCI datetime,
		@ValabilPanaLaCI datetime,
--Pasaport
		@SeriePas nvarchar(10)='',
		@NumarPas bigint=0,
		@EliberatDePas nvarchar(50)='',
		@DataEliberariiPas datetime,
		@ValabilPanaLaPas datetime,
		/*@PermMuncaEliberat datetime,
		@PermMuncaExpira datetime,
		@PermSedereEliberat datetime,
		@PermSedereExpira datetime,
		@NrPermisMunca bigint=0,*/

--Permis Munca
		@SeriePermisMunca nvarchar(10) = '',
		@NrPermisMunca bigint,
		@DataEliberarePermisMunca datetime,
		@DataExpirarePermisMunca datetime,
--Legitimatie sedere
		@SerieLegitimatieSedere nvarchar(10) = '',
		@NrLegitimatieSedere bigint,
		@DataEliberareLegitimatieSedere datetime,
		@DataExpirareLegitimatieSedere datetime,
--NIF
		@NIF numeric,
		--0 - cetatean cu domiciliul in tara de baza (Romania) si nationalitatea tarii de baza (romana)
		--1 - cetatea cu domiciliul in alta tara decat cea de baza (nu Romania) si nationalitate tarii de baza (romana)
		--2 - cetatea cu domiciliul in alta tara decat cea de baza (nu Romania) si nationalitate diferita de a tarii de baza (nu romana)

		@TipNationalitateDomiciliu smallint = 0,
--Domiciliul
		@TaraID int,
		@Localitate nvarchar(50),
		@JudetSectorID int,
		@Strada nvarchar(50),
		@NumarStr nvarchar(10),
		@CodPostal nvarchar(20) = NULL,
		@Bloc nvarchar(32) = NULL,
		@Scara nvarchar(5) = NULL,
		@Etaj nvarchar(5) = NULL,
		@Apartament nvarchar(5) = NULL,
--Resedinta
		@TaraIDRes int,
		@LocalitateRes nvarchar(50),
		@JudetSectorIDRes int,
		@StradaRes nvarchar(50),
		@NumarStrRes nvarchar(10),
		@CodPostalRes nvarchar(20) = NULL,
		@BlocRes nvarchar(32) = NULL,
		@ScaraRes nvarchar(5) = NULL,
		@EtajRes nvarchar(5) = NULL,
		@ApartamentRes nvarchar(5) = NULL,
--Carnet Munca
		@Serie nvarchar(5)='',
		@Numar nvarchar(10)='',
		@Emitent nvarchar(50)='',
		@DataEmiterii datetime,
		@NrInregITM nvarchar(25)='',

--Mail & Telefon
		@Email nvarchar(255) ,
		@TelMunca nvarchar(255),

--Alerte Speciale
		@AlerteSpeciale nvarchar(2056)='',

--Output
		@new_id int = 0 output
)
as

declare	@rc int
set @rc = 0

declare @tip_actiune int --0-insert, 1-update
set @tip_actiune = 0

/*declare @dateID int
set @dateID = -1*/


begin transaction InsertUpdateAngajat

select @rc = count(AngajatID) from Angajati where AngajatID = @AngajatID

if(@rc = 0)
begin	--Insert Angajat
	insert into Angajati with (xlock)
		(AngajatorID, Marca, NumeIntreg, Nume, Prenume, NumeAnterior, TitluID, Poza, PrenumeMama, PrenumeTata, StudiuID, AnAbsolvire, NrDiploma, 
		Descriere, ModIncadrare, ProgramLucru, Telefon, DataNasterii, TaraNastereID, JudetNastereID, LocalitateNastere, 
		StareCivila, NrCopii, Sex, Nationalitate/*, CNP, CNPAnterior*/, TipFisaFiscala, AniVechimeMunca, LuniVechimeMunca, 
		ZileVechimeMunca, AreCardBancar, PerioadaDeterminata,DataPanaLa,DataDeLa,SefID,NrContractMunca,DataInregContractMunca,EchIndProtectie, EchIndLucru, MatIgiSan, AlimProtectie,
		AlteDrSiObl, AlteClauzeCIM,PerProba,Invaliditate,SalariuBazaActual,IndemnizatieConducereActual,Sporuri,AlteAdaosuri,SumaMajorare,DataMajorare,NrZileCOAn,NrZileCOSupl,
		CategorieID,Email,TelMunca, Lichidat, Pensionar/*,PermMuncaEliberat,PermMuncaExpira,PermSedereEliberat,PermSedereExpira,NrPermisMunca */ )
		values
		(@AngajatorID, @Marca, @Nume+' '+@Prenume, @Nume, @Prenume, @NumeAnterior, @TitluID, @Poza, @PrenumeMama, @PrenumeTata, @StudiuID, @AnAbsolvire, 
		@NrDiploma, @Descriere, @ModIncadrare, @ProgramLucru, @Telefon, @DataNasterii, @TaraNastereID, @JudetNastereID, 
		@LocalitateNastere, @StareCivila, @NrCopii, @Sex, @Nationalitate/*, @CNP, @CNPAnterior*/, @TipFisaFiscala, @AniVechimeMunca, 
		@LuniVechimeMunca, @ZileVechimeMunca, @AreCardBancar,@PerioadaDeterminata,@DataPanaLa, @DataDeLa, @SefID,
		@NrContractMunca,@DataInregContractMunca,@EchIndProtectie,@EchIndLucru,@MatIgiSan, @AlimProtectie, @AlteDrSiObl, @AlteClauzeCIM, @PerProba,@Invaliditate,
		@SalariuBaza,@IndemnizatieConducere,@Sporuri, @AlteAdaosuri, @SumaMajorare,@DataMajorare,@NrZileCOAn, @NrZileCOSupl,@CategorieID,@Email,@TelMunca, @Lichidat, @Pensionat/*,
		@PermMuncaEliberat,@PermMuncaExpira,@PermSedereEliberat,@PermSedereExpira,@NrPermisMunca */ )
	if(@@ERROR <> 0)
		set @rc = @@ERROR
	else
	begin
		set @AngajatID = @@IDENTITY

		--inseram alertele
		exec @rc = insertAlerte  @AngajatID, @AlerteSpeciale
		set @new_id = @AngajatID

		set @rc = 0
	end
	
	set @tip_actiune = 0

	if(@rc = 0)		--Insert functie : Dovle
		exec @rc = InsertUpdateDeleteIstoricFunctie 0, @AngajatID, @FunctieID, @DataDeLa

end
else
begin	--Update Angajat
	update Angajati with (xlock) set AngajatorID = @AngajatorID, Marca = @Marca, NumeIntreg = @Nume+' ' + @Prenume,Nume = @Nume, Prenume = @Prenume, NumeAnterior=@NumeAnterior,
		TitluID = @TitluID, Poza = @Poza, PrenumeMama = @PrenumeMama, PrenumeTata = @PrenumeTata, StudiuID = @StudiuID, 
		AnAbsolvire = @AnAbsolvire, NrDiploma = @NrDiploma, Descriere = @Descriere, ModIncadrare = @ModIncadrare, 
		ProgramLucru = @ProgramLucru, Telefon = @Telefon, DataNasterii = @DataNasterii, TaraNastereID = @TaraNastereID, 
		JudetNastereID = @JudetNastereID, LocalitateNastere = @LocalitateNastere, StareCivila = @StareCivila, 
		NrCopii = @NrCopii, Sex = @Sex, Nationalitate = @Nationalitate/*, CNP = @CNP, CNPAnterior=@CNPAnterior*/, TipFisaFiscala = @TipFisaFiscala, 
		AniVechimeMunca = @AniVechimeMunca, LuniVechimeMunca = @LuniVechimeMunca, ZileVechimeMunca = @ZileVechimeMunca, 
		AreCardBancar = @AreCardBancar, PerioadaDeterminata=@PerioadaDeterminata,DataPanaLa=@DataPanaLa, DataDeLa=@DataDeLa, SefID = @SefID,
		NrContractMunca=@NrContractMunca, DataInregContractMunca=@DataInregContractMunca, EchIndProtectie=@EchIndProtectie,
		EchIndLucru=@EchIndLucru, MatIgiSan=@MatIgiSan, AlimProtectie=@AlimProtectie, AlteDrSiObl=@AlteDrSiObl, AlteClauzeCIM=@AlteClauzeCIM,
		PerProba=@PerProba,Invaliditate=@Invaliditate,SalariuBazaActual=@SalariuBaza,IndemnizatieConducereActual=@IndemnizatieConducere,Sporuri=@Sporuri, AlteAdaosuri=@AlteAdaosuri,
		SumaMajorare=@SumaMajorare,DataMajorare=@DataMajorare,NrZileCOAn=@NrZileCOAn, NrZileCOSupl=@NrZileCOSupl,CategorieID=@CategorieID,Email=@Email,TelMunca=@TelMunca, Lichidat = @Lichidat,
		Pensionar = @Pensionat/*,
		PermMuncaEliberat=@PermMuncaEliberat,PermMuncaExpira=@PermMuncaExpira,PermSedereEliberat=@PermSedereEliberat,PermSedereExpira=@PermSedereExpira,NrPermisMunca=@NrPermisMunca*/
		where AngajatID = @AngajatID
	if(@@ERROR <> 0)
		set @rc = @@ERROR
	else
	begin
		set @new_id = @AngajatID
		set @rc = 0
		--daca angajatul se delichideaza se sterge si linia din tabela lichidari asociata acestui angajat
		if ( @Lichidat = 0)
		begin
			delete from Lichidare where AngajatID = @AngajatID
		end
	end

	set @tip_actiune = 1
end

if( @tip_actiune = 0 )
begin
	--nationalitatea tarii de baza (romana) si domiciliu in tara de baza (Romania)
	if( @TipNationalitateDomiciliu=0 ) begin
		--Insert sau update carte de identitate
		if(@rc = 0 and @CNP != 0 and @SerieCI != '' and @NumarCI is not null and @NumarCI>0 and @EliberatDeCI!='' and @DataEliberariiCI is not null and @ValabilPanaLaCI is not null )
			exec @rc = InsertUpdateDeleteCarteIdentitate @tip_actiune, -1, @AngajatID, @CNP, @CNPAnterior, @SerieCI, @NumarCI, @EliberatDeCI, @DataEliberariiCI, @ValabilPanaLaCI
		--Insert sau update pasaport
		if(@rc = 0 and @SeriePas!='' and @NumarPas is not null and @NumarPas>0 and @EliberatDePas!='' and @DataEliberariiPas is not null and @ValabilPanaLaPas is not null)
			exec @rc = InsertUpdateDeletePasaport @tip_actiune, -1, @AngajatID, @SeriePas, @NumarPas, @EliberatDePas, @DataEliberariiPas, @ValabilPanaLaPas
		/*if( @tip_actiune = 1 ) begin
			exec @rc = SetActivAllPermiseMuncaAngajat @AngajatID, 0
			exec @rc = SetActivAllLegitimatiiSedereAngajat @AngajatID, 0
			exec @rc = SetActivAllNIFAngajat @AngajatID, 0
		end*/
	end
	
	--nationalitatea tarii de baza (romana) si domiciliu in alt tara decat tara de baza (nu Romania)
	if( @TipNationalitateDomiciliu=1 ) begin
		--Insert sau update carte de identitate
		if(@rc = 0 and @CNP != 0 and @SerieCI != '' and @NumarCI is not null and @NumarCI>0 and @EliberatDeCI!='' and @DataEliberariiCI is not null and @ValabilPanaLaCI is not null )
			exec @rc = InsertUpdateDeleteCarteIdentitate @tip_actiune, -1, @AngajatID, @CNP, @CNPAnterior, @SerieCI, @NumarCI, @EliberatDeCI, @DataEliberariiCI, @ValabilPanaLaCI
		--Insert sau update pasaport
		if(@rc = 0 and @SeriePas!='' and @NumarPas is not null and @NumarPas>0 and @EliberatDePas!='' and @DataEliberariiPas is not null and @ValabilPanaLaPas is not null)
			exec @rc = InsertUpdateDeletePasaport @tip_actiune, -1, @AngajatID, @SeriePas, @NumarPas, @EliberatDePas, @DataEliberariiPas, @ValabilPanaLaPas
		--Insert sau update legitimatie sedere
		if( @rc = 0 and @SerieLegitimatieSedere<>'' and @NrLegitimatieSedere is not null and @NrLegitimatieSedere>0 and @DataEliberareLegitimatieSedere is not null and @DataExpirareLegitimatieSedere is not null ) begin		
			/*if( @tip_actiune = 1 )
				Select @dateID = LegitimatieSedereID From LegitimatiiSedere Where AngajatID=@AngajatID and Activ=1
			exec @rc = InsertUpdateDeleteLegitimatieSedere @tip_actiune, @dateID, @AngajatID, @SerieLegitimatieSedere, @NrLegitimatieSedere, @DataEliberareLegitimatieSedere, @DataExpirareLegitimatieSedere*/
			exec @rc = InsertUpdateDeleteLegitimatieSedere @tip_actiune, -1, @AngajatID, @SerieLegitimatieSedere, @NrLegitimatieSedere, @DataEliberareLegitimatieSedere, @DataExpirareLegitimatieSedere
		end
	
		--Insert sau Update NIF
		if( @rc = 0 and @NIF is not null and @NIF>0) begin		--Insert sau update NIF
			/*if( @tip_actiune = 1 )
				Select @dateID = NIFID From NIF Where AngajatID=@AngajatID and Activ=1
			exec @rc = InsertUpdateDeleteNIF @tip_actiune, @dateID, @AngajatID, @NIF*/
			exec @rc = InsertUpdateDeleteNIF @tip_actiune, -1, @AngajatID, @NIF
		end
	
		/*if( @tip_actiune = 1 ) begin
			exec @rc = SetActivAllPermiseMuncaAngajat @AngajatID, 0
		end*/
	end
	
	--nationalitatea alta decat a tarii de baza (nu romana) si domiciliu in alta tara decat tara de baza (nu Romania)
	if( @TipNationalitateDomiciliu=2 ) begin
		--Insert sau update pasaport
		if(@rc = 0 and @SeriePas!='' and @NumarPas is not null and @NumarPas>0 and @EliberatDePas!='' and @DataEliberariiPas is not null and @ValabilPanaLaPas is not null)
			exec @rc = InsertUpdateDeletePasaport @tip_actiune, -1, @AngajatID, @SeriePas, @NumarPas, @EliberatDePas, @DataEliberariiPas, @ValabilPanaLaPas
		--Insert sau update permis munca
		if(@rc = 0 and @SeriePermisMunca !='' and @NrPermisMunca is not null and @NrPermisMunca>0 and @DataEliberarePermisMunca is not null and @DataExpirarePermisMunca is not null ) begin		
			/*if( @tip_actiune = 1 )
				Select @dateID = PermisMuncaID From PermiseMunca Where AngajatID=@AngajatID and Activ=1
			exec @rc = InsertUpdateDeletePermisMunca @tip_actiune, @dateID, @AngajatID, @NrPermisMunca, @SeriePermisMunca, @DataEliberarePermisMunca, @DataExpirarePermisMunca*/
			exec @rc = InsertUpdateDeletePermisMunca @tip_actiune, -1, @AngajatID, @NrPermisMunca, @SeriePermisMunca, @DataEliberarePermisMunca, @DataExpirarePermisMunca
		end
		--Insert sau update legitimatie sedere
		if( @rc = 0 and @SerieLegitimatieSedere<>'' and @NrLegitimatieSedere is not null and @NrLegitimatieSedere>0 and @DataEliberareLegitimatieSedere is not null and @DataExpirareLegitimatieSedere is not null ) begin		
			/*if( @tip_actiune = 1 )
				Select @dateID = LegitimatieSedereID From LegitimatiiSedere Where AngajatID=@AngajatID and Activ=1
			exec @rc = InsertUpdateDeleteLegitimatieSedere @tip_actiune, @dateID, @AngajatID, @SerieLegitimatieSedere, @NrLegitimatieSedere, @DataEliberareLegitimatieSedere, @DataExpirareLegitimatieSedere*/
			exec @rc = InsertUpdateDeleteLegitimatieSedere @tip_actiune, -1, @AngajatID, @SerieLegitimatieSedere, @NrLegitimatieSedere, @DataEliberareLegitimatieSedere, @DataExpirareLegitimatieSedere
		end
	
		--Insert sau Update NIF
		if( @rc = 0 and @NIF is not null and @NIF>0) begin		--Insert sau update NIF
			/*if( @tip_actiune = 1 )
				Select @dateID = NIFID From NIF Where AngajatID=@AngajatID and Activ=1
			exec @rc = InsertUpdateDeleteNIF @tip_actiune, @dateID, @AngajatID, @NIF*/
			exec @rc = InsertUpdateDeleteNIF @tip_actiune, -1, @AngajatID, @NIF
		end
	end
end
else begin
	if( @TipNationalitateDomiciliu=0 ) begin
		exec @rc = SetActivAllPermiseMuncaAngajat @AngajatID, 0
		exec @rc = SetActivAllLegitimatiiSedereAngajat @AngajatID, 0
		exec @rc = SetActivAllNIFAngajat @AngajatID, 0
	end
	else if( @TipNationalitateDomiciliu=1 ) begin
		exec @rc = SetActivAllPermiseMuncaAngajat @AngajatID, 0
	end
	else if( @TipNationalitateDomiciliu=2 ) begin
		exec @rc = SetActivAllCartiIdentitateAngajat @AngajatID, 0
	end
end
/*
--Insert sau update carte de identitate
if(@rc = 0 and @SerieCI != '' and @NumarCI is not null and @NumarCI>0 and @EliberatDeCI!='' and @DataEliberariiCI is not null and @ValabilPanaLaCI is not null )
	exec @rc = InsertUpdateCarteIdentitate @AngajatID, @SerieCI, @NumarCI, @EliberatDeCI, @DataEliberariiCI, @ValabilPanaLaCI

--Insert sau update pasaport
if(@rc = 0 and @SeriePas!='' and @NumarPas is not null and @NumarPas>0 and @EliberatDePas!='' and @DataEliberariiPas is not null and @ValabilPanaLaPas is not null)
	exec @rc = InsertUpdatePasaport @AngajatID, @SeriePas, @NumarPas, @EliberatDePas, @DataEliberariiPas, @ValabilPanaLaPas

--Insert sau update permis munca
if(@rc = 0 and @SeriePermisMunca !='' and @NrPermisMunca is not null and @NrPermisMunca>0 and @DataEliberarePermisMunca is not null and @DataExpirarePermisMunca is not null ) begin		
	if( @tip_actiune = 1 )
		Select @dateID = PermisMuncaID From PermiseMunca Where AngajatID=@AngajatID and Activ=1
	exec @rc = InsertUpdateDeletePermisMunca @tip_actiune, @dateID, @AngajatID, @NrPermisMunca, @SeriePermisMunca, @DataEliberarePermisMunca, @DataExpirarePermisMunca
end

--Insert sau update legitimatie sedere
if( @rc = 0 and @SerieLegitimatieSedere<>'' and @NrLegitimatieSedere is not null and @NrLegitimatieSedere>0 and @DataEliberareLegitimatieSedere is not null and @DataExpirareLegitimatieSedere is not null ) begin		
	if( @tip_actiune = 1 )
		Select @dateID = LegitimatieSedereID From LegitimatiiSedere Where AngajatID=@AngajatID and Activ=1
	exec @rc = InsertUpdateDeleteLegitimatieSedere @tip_actiune, @dateID, @AngajatID, @SerieLegitimatieSedere, @NrLegitimatieSedere, @DataEliberareLegitimatieSedere, @DataExpirareLegitimatieSedere
end

--Insert sau Update NIF
if( @rc = 0 and @NIF is not null and @NIF>0) begin		--Insert sau update NIF
	if( @tip_actiune = 1 )
		Select @dateID = NIFID From NIF Where AngajatID=@AngajatID and Activ=1
	exec @rc = InsertUpdateDeleteNIF @tip_actiune, @dateID, @AngajatID, @NIF
end
*/


if(@rc = 0)		--Insert sau update domiciliu
	exec @rc = InsertUpdateDomiciliu @AngajatID, @TaraID, @Localitate, @JudetSectorID, @Strada, 
				@NumarStr, @CodPostal, @Bloc, @Scara, @Etaj, @Apartament, 'd'

if(@rc = 0)		--Insert sau update resedinta
	exec @rc = InsertUpdateDomiciliu @AngajatID, @TaraIDRes, @LocalitateRes, @JudetSectorIDRes, @StradaRes, 
				@NumarStrRes, @CodPostalRes, @BlocRes, @ScaraRes, @EtajRes, @ApartamentRes, 'r'

if(@rc = 0)		--Insert sau update carte de munca
	exec @rc = InsertUpdateCarnetMunca @AngajatID, @Serie, @Numar, @Emitent, @DataEmiterii, @NrInregITM

if(@rc = 0)		--Insert sau update IstoricCentruCost
	exec @rc = InsertUpdateDeleteIstoricCentruCost @tip_actiune, @AngajatID, @CentruCostID, @DataDeLa

if(@rc = 0)		--Insert sau update IstoricDepartament
	exec @rc = InsertUpdateDeleteIstoricDepartament @tip_actiune, @AngajatID, @DepartamentID, @DataDeLa


if(@rc <> 0)
	rollback tran InsertUpdateAngajat
else
	commit tran InsertUpdateAngajat

return @rc