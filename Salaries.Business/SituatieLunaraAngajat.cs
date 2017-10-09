
using System;
using System.Data;
using System.Data.SqlClient;

namespace Salaries.Business
{
	/// <summary>
	/// Summary description for SituatieLunaraAngajat.
	/// </summary>
	public class SituatieLunaraAngajat : Salaries.Business.BizObject
	{
		#region Atribute private
		//Setarile aplicatiei
		private Configuration.ModuleSettings settings;
		//Id-ul angajatului
		private long AngajatID;
		#endregion

		#region Coloane tabele
		public static string []codAbsente = {"ES", "I", "CO", "CM", "CCM", "OC", "AN", "CFP", "DI", "DE", "EmS", "COA"};
		public static string []denumireOreLucrate = {"Ore normale", "Ore suplimentare 100%", "Ore suplimentare 200%"};
		#endregion

		#region Constructor
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="_AngajatID">Id-ul angajatului</param>
		public SituatieLunaraAngajat(long _AngajatID)
		{		
			settings = Configuration.ModuleConfig.GetSettings();
			this.AngajatID = _AngajatID;
		}
		#endregion

		#region Constructor
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="_AngajatID">Id-ul angajatului</param>
		/// <param name="st"></param>
		public SituatieLunaraAngajat(long _AngajatID,Salaries.Configuration.ModuleSettings st)
		{
			settings =st;
			this.AngajatID = _AngajatID;
		}
		#endregion

		#region GenerareSituatieLunaraAngajat
		/// <summary>
		/// Procedura genereaza situatia lunara a unui angajat
		/// </summary>
		/// <param name="lunaID">Id-ul lunii pentru care se genereaza</param>
		/// <param name="angajatorID">Id-ul angajatorului</param>
		public void GenerareSituatieLunaraAngajat( int lunaID, int angajatorID )
		{
			//try
			//{
				Angajat angajat = new Angajat();
				angajat.AngajatId = AngajatID;
				angajat.LoadAngajat();

				PontajAngajat pa = new PontajAngajat( this.AngajatID, settings );

				Salaries.Data.InfoSituatieLunara isl = this.GetSituatieLunaraAngajat( this.AngajatID, lunaID );

				int nrZileLucratoareLunaTotal = pa.GetNrZileLuna( lunaID );
			
				TimeSpan nrOreTotaleLucrateLuna = pa.GetAngajatNrOreLucrateLuna( lunaID );
			
				int nrZileTotaleAbsentateLuna = pa.GetAngajatNrZileAbsenteTotalLuna( lunaID );

				Data.IntervaleSchimbariLuna []intervSL = pa.GetIntervaleSchimbariLuna( lunaID );

				bool validareStergere = true;
				/*
				 * Modified:    Cristina Raluca Muntean
				 * Date:        1.09.2005
				 * Description: Initial salariul si indemnizatia de conducere nu se puteau schimba decat pe data de 1 a lunii.
				 * S-a revenit asupra acestei decizii si se doreste sa existe posibilitatea modificarii salariului de baza si 
				 * a indemnizatiei de conducere in orice zi a lunii. Va exista in continuare tot o singura situatie lunara, iar
				 * salariul de baza si indemnizatia de conducere se vor calcula conform formulelei:
				 * sumaRezultatat = suma perioada I/nr zile lucratoare*nr zile lucrate in perioada + suma perioada II/nr zile lucratoare*nr zile lucrate in perioada +...
				 * 
				 */
				int [] nrZileLucratoareLuna = new int[intervSL.Length];
				int nrZileEvenimenteDeosebiteLuna = 0;
				int nrZileInvoireLuna = 0;
				int nrZileConcediuOdihnaLuna = 0;
				
				float nrZileCOneefectuat = 0;
				float nrZileCOefectInAvans = 0;

				int nrZileConcediuBoalaLuna = 0;
				int nrZileConcediuBoalaLunaFirma = 0;
				int nrZileConcediuBoalaLunaBASS = 0;

				int nrZileObligatiiCetatenesti = 0;
				int nrZileAbsenteNemotivate = 0;
				int nrZileConcediuFaraPlata = 0;

				int nrZileLucratoareDelegatieInterna = 0;
				int nrZileLucratoareDelegatieExterna = 0;
				decimal diurnaImpozabila = 0;
				int nrZileTotalDelegatieInterna = 0;
				int nrZileTotalDelegatieExterna = 0;

				float nrOreLucrate = 0;
				float nrOreSuplimentare50 = 0;
				float nrOreSuplimentare100 = 0;

				float [] salariuBaza  = new float[intervSL.Length];
				float [] indemnizatieConducere = new float[intervSL.Length] ;

				int nrZileEmergencyService = 0;

     			int programLucru = 0;
				int invaliditate = 0;
				int categorieID = 0;

				decimal angajatSporActivitateSupLuna = 0;
				decimal angajatEmergencyServiceLuna = 0;
				decimal angajatPrimeSpecialeLuna = 0;
				decimal angajatAlteDrepturiLuna = 0;
				decimal angajatAlteDrepturiNetLuna = 0;
				decimal angajatAjutorDeces = 0;

				//S-au adaugat retinerile pentru un angajt
				decimal angajatAvansLuna = 0;
				decimal angajatRetinere1 = 0;
				decimal angajatRetinere2 = 0;
				decimal angajatRetinere3 = 0;
				decimal angajatRetinere4 = 0;
				decimal angajatRetinere5 = 0;
				decimal angajatRetinere6 = 0;
				decimal angajatRetinere7 = 0;
				decimal angajatRegularizareLuna = 0;
				decimal angajatPrimaProiectLuna = 0;
				decimal angajatRetinereSanatateLuna = 0;
				decimal angajatDrepturiInNaturaLuna = 0;
				
				//Lungu Andreea
				float corectiiTicheteLuna = 0;

				int i = -1;	

				foreach( Data.IntervaleSchimbariLuna interv in intervSL )
				{
					i++;

					nrZileLucratoareLuna[i] = pa.GetNrZileLucratoarePerioada( interv.DataStart, interv.DataEnd );

					TimeSpan nrOreLucrateLuna = pa.GetAngajatNrOreTipLucrate( interv.DataStart, interv.DataEnd, denumireOreLucrate[ 0 ] );
					
					TimeSpan nrOreSuplimentare50Luna = pa.GetAngajatNrOreTipLucrate( interv.DataStart, interv.DataEnd, denumireOreLucrate[ 1 ] );
					TimeSpan nrOreSuplimentare100Luna = pa.GetAngajatNrOreTipLucrate( interv.DataStart, interv.DataEnd, denumireOreLucrate[ 2 ] );

					//tre facut pe intervale de timp si pt absente
					nrZileEvenimenteDeosebiteLuna += pa.GetAngajatNrZileAbsenteTipLuna( interv.DataStart, interv.DataEnd, codAbsente[ 0 ] );
					nrZileInvoireLuna += pa.GetAngajatNrZileAbsenteTipLuna( interv.DataStart, interv.DataEnd, codAbsente[ 1 ] );
					nrZileConcediuOdihnaLuna += pa.GetAngajatNrZileAbsenteTipLuna( interv.DataStart, interv.DataEnd, codAbsente[ 2 ] ) +
												pa.GetAngajatNrZileAbsenteTipLuna( interv.DataStart, interv.DataEnd, codAbsente[ 11 ] );
					
					nrZileCOneefectuat = isl.NrZileConcediuOdihnaNeefectuat;
					nrZileCOefectInAvans = isl.NrZileConcediuOdihnaEfectuatInAvans;

					nrZileConcediuBoalaLuna += pa.GetAngajatNrZileAbsenteTipLuna( interv.DataStart, interv.DataEnd,codAbsente[ 3 ] )+pa.GetAngajatNrZileAbsenteTipLuna( interv.DataStart, interv.DataEnd, codAbsente[ 4 ] );
					nrZileConcediuBoalaLunaFirma += pa.GetNrZileConcediuBoalaFirma(lunaID);
					nrZileConcediuBoalaLunaBASS += pa.GetNrZileConcediuBoalaBASS(lunaID);
					
					nrZileObligatiiCetatenesti += pa.GetAngajatNrZileAbsenteTipLuna( interv.DataStart, interv.DataEnd, codAbsente[ 5 ] );
					nrZileAbsenteNemotivate += pa.GetAngajatNrZileAbsenteTipLuna( interv.DataStart, interv.DataEnd, codAbsente[ 6 ] );
					nrZileConcediuFaraPlata += pa.GetAngajatNrZileAbsenteTipLuna( interv.DataStart, interv.DataEnd, codAbsente[ 7 ] );

					nrZileLucratoareDelegatieInterna += pa.GetAngajatNrZileAbsenteTipLuna( interv.DataStart, interv.DataEnd, codAbsente[ 8 ] );
					nrZileLucratoareDelegatieExterna += pa.GetAngajatNrZileAbsenteTipLuna( interv.DataStart, interv.DataEnd, codAbsente[ 9 ] );
					diurnaImpozabila = isl.DiurnaImpozabila;
					nrZileTotalDelegatieInterna += pa.GetAngajatNrZileCuSarbatoriAbsenteTipLuna( interv.DataStart, interv.DataEnd, codAbsente[ 8 ] );
					nrZileTotalDelegatieExterna += pa.GetAngajatNrZileCuSarbatoriAbsenteTipLuna( interv.DataStart, interv.DataEnd, codAbsente[ 9 ] );

					nrZileEmergencyService += pa.GetAngajatNrZileCuSarbatoriAbsenteTipLuna( interv.DataStart, interv.DataEnd, codAbsente[ 10 ] );

					angajatSporActivitateSupLuna = isl.SporActivitatiSup;
					angajatEmergencyServiceLuna = isl.EmergencyService;
					angajatPrimeSpecialeLuna = isl.PrimeSpeciale;
					angajatAlteDrepturiLuna = isl.AlteDrepturi;
					angajatAlteDrepturiNetLuna = isl.AlteDrepturiNet;
					angajatAjutorDeces = isl.AjutorDeces;

					angajatAvansLuna = isl.Avans;
					angajatRetinere1 = isl.Retineri1;
					angajatRetinere2 = isl.Retineri2;
					angajatRetinere3 = isl.Retineri3;
					angajatRetinere4 = isl.Retineri4;
					angajatRetinere5 = isl.Retineri5;
					angajatRetinere6 = isl.Retineri6;
					angajatRetinere7 = isl.Retineri7;
					angajatRegularizareLuna = isl.Regularizare;
					angajatPrimaProiectLuna = isl.PrimaProiect;
					angajatRetinereSanatateLuna = isl.RetinereSanatate;
					angajatDrepturiInNaturaLuna = isl.DrepturiInNatura;
										
					nrOreLucrate += nrOreLucrateLuna.Days*24+nrOreLucrateLuna.Hours+(float)nrOreLucrateLuna.Minutes/60;
					nrOreSuplimentare50 += nrOreSuplimentare50Luna.Days*24+nrOreSuplimentare50Luna.Hours+(float)nrOreSuplimentare50Luna.Minutes/60;
					nrOreSuplimentare100 += nrOreSuplimentare100Luna.Days*24+nrOreSuplimentare100Luna.Hours+(float)nrOreSuplimentare100Luna.Minutes/60;

					//Lungu Andreea
					//nrTicheteLuna = isl.NrTichete;
					//daca angajatul e cu functia de baza aici si proportional cu programul de lucru
					//nrTicheteLuna = angajat.ProgramLucru * (nrOreLucrate - nrZileLucratoareDelegatieExterna - nrZileLucratoareDelegatieInterna) / 8;
					corectiiTicheteLuna = isl.CorectiiTichete;

					programLucru = interv.ProgramLucru;
					salariuBaza[i] = interv.SalariuBaza;
					indemnizatieConducere[i] = interv.IndemnizatieConducere;
					invaliditate = interv.Invaliditate;
					categorieID = interv.CategorieID;
				}
				

				//este adaugata situatia lunara a angajatului in cauza
				Salaries.Data.InfoSituatieLunara x = new Salaries.Data.InfoSituatieLunara();

				x.SituatieID = -1;
				x.AngajatID = this.AngajatID;
				x.LunaID = lunaID;
				
				x.CategorieID = categorieID;
				x.ProgramLucru = programLucru;
				//este calculat salariul de baza
				x.SalariuBaza = CalculSumaFinala(salariuBaza,nrZileLucratoareLuna,nrZileLucratoareLunaTotal);
				//este calculata indemnizatia de conducere
				x.IndemnizatieConducere = CalculSumaFinala(indemnizatieConducere,nrZileLucratoareLuna,nrZileLucratoareLunaTotal);
				x.Invaliditate = invaliditate;
			
				x.NrZileLuna = CalculNrZileLucrate(nrZileLucratoareLuna);

				x.NrOreLucrate = nrOreLucrate;
				x.NrOreSup50Proc = nrOreSuplimentare50;
				x.NrOreSup100Proc = nrOreSuplimentare100;

				x.NrOreEvenimDeoseb = nrZileEvenimenteDeosebiteLuna;
				x.NrOreInvoire = nrZileInvoireLuna;
				x.NrOreConcediuOdihna = nrZileConcediuOdihnaLuna;

				x.NrZileConcediuOdihnaNeefectuat = nrZileCOneefectuat;
				x.NrZileConcediuOdihnaEfectuatInAvans = nrZileCOefectInAvans;

				x.NrOreConcediuBoala = nrZileConcediuBoalaLuna ;
				x.NrOreConcediuBoalaFirma = nrZileConcediuBoalaLunaFirma ;
				x.NrOreConcediuBoalaBASS = nrZileConcediuBoalaLunaBASS ;

				x.NrOreObligatiiCetatenesti = nrZileObligatiiCetatenesti;
				x.NrOreAbsenteNemotivate = nrZileAbsenteNemotivate;
				x.NrOreConcediuFaraPlata = nrZileConcediuFaraPlata;

				x.NrOreLucrateDelegatieInterna = nrZileLucratoareDelegatieInterna;
				x.NrOreLucrateDelegatieExterna = nrZileLucratoareDelegatieExterna;
				x.DiurnaImpozabila = diurnaImpozabila;
				x.NrOreTotalDelegatieInterna = nrZileTotalDelegatieInterna;
				x.NrOreTotalDelegatieExterna = nrZileTotalDelegatieExterna;

				x.NrOreEmergencyService = nrZileEmergencyService;

				//Lungu Andreea - 31.08.2010
				//daca angajatul e cu functia de baza aici si proportional cu programul de lucru
				float nrOreLucrateFinal = x.NrOreLucrate + angajat.ProgramLucru * x.NrOreLucrateDelegatieInterna + angajat.ProgramLucru * x.NrOreLucrateDelegatieExterna;
				if (angajat.ModIncadrare == 0)
                    x.NrTichete = angajat.ProgramLucru * (nrOreLucrateFinal / angajat.ProgramLucru - x.NrOreLucrateDelegatieExterna - x.NrOreLucrateDelegatieInterna) / 8;
				else
					x.NrTichete = 0;
				x.CorectiiTichete = corectiiTicheteLuna;
				//nr total tichete
				x.NrTotalTichete = (int) Math.Ceiling(x.NrTichete + x.CorectiiTichete);
				if (x.NrTotalTichete < 0)
					//x.NrTotalTichete = (int) Math.Ceiling(x.NrTichete);
					x.NrTotalTichete = 0;

				x.SporActivitatiSup = Convert.ToDecimal( angajatSporActivitateSupLuna );
				x.EmergencyService = Convert.ToDecimal( angajatEmergencyServiceLuna );
				x.PrimeSpeciale = Convert.ToDecimal( angajatPrimeSpecialeLuna );
				x.AlteDrepturi = Convert.ToDecimal( angajatAlteDrepturiLuna );
				x.AlteDrepturiNet = Convert.ToDecimal( angajatAlteDrepturiNetLuna );
				x.AjutorDeces = Convert.ToDecimal( angajatAjutorDeces );

				x.Avans = Convert.ToDecimal( angajatAvansLuna );
				x.Retineri1 = Convert.ToDecimal( angajatRetinere1 );
				x.Retineri2 = Convert.ToDecimal( angajatRetinere2 );
				x.Retineri3 = Convert.ToDecimal( angajatRetinere3 );
				x.Retineri4 = Convert.ToDecimal( angajatRetinere4 );
				x.Retineri5 = Convert.ToDecimal( angajatRetinere5 );
				x.Retineri6 = Convert.ToDecimal( angajatRetinere6 );
				x.Retineri7 = Convert.ToDecimal( angajatRetinere7 );
				x.Regularizare = Convert.ToDecimal( angajatRegularizareLuna );
				x.PrimaProiect = Convert.ToDecimal( angajatPrimaProiectLuna );
				x.RetinereSanatate = Convert.ToDecimal( angajatRetinereSanatateLuna );
				x.DrepturiInNatura = Convert.ToDecimal( angajatDrepturiInNaturaLuna );
				
				/*
				 * Modified: Cristina Raluca Muntean
				 * Date:     13.09.2005
				 * A fost facuta aceasta modificare deoarece daca se lichida angajatul din prima zi, deci
				  nu se mai putea genera situatia lunara pe baza pontajului, atunci la adaugare era aruncata 
				  o exceptie si ramanea vechea situatie.
				 */

				//In cazul in care nu exista date pentru situatia lunara, aceasta se 
				//sterge(aceasta se poate intampla daca a fost lichidat angajatul din prima zi a lunii).
				if((x.NrZileLuna ==0)&&(x.CategorieID == 0)&&(x.ProgramLucru == 0))
				{
					this.DeleteSituatieAngajat(int.Parse(x.LunaID.ToString()),int.Parse(x.AngajatID.ToString()));
				}
				else
				{
					//Daca exista date pentru situatia lunara, atunci se sterge vechea situatie
					//lunara si se adauga situatia cu noile date.
					this.AddSituatieLunaraAngajat( x, validareStergere );
					validareStergere = false;
				}
			//}
			//catch
			//{}
		}
		#endregion

		#region GenerareSituatieLunaraAngajatLichidat
		/// <summary>
		/// Procedura genereaza situatia lunara a unui angajat care a fost lichidat
		/// </summary>
		/// <param name="lunaID">Luna pentru care se genereaza situatia</param>
		/// <param name="angajatorID">Angajatorul de care apartine angajatul</param>
		public void GenerareSituatieLunaraAngajatLichidat( int lunaID, int angajatorID )
		{
			try
			{
				PontajAngajat pa = new PontajAngajat( this.AngajatID, settings );

				Salaries.Data.InfoSituatieLunara isl = this.GetSituatieLunaraAngajat( this.AngajatID, lunaID );

				int nrZileLucratoareLunaTotal = pa.GetNrZileLuna( lunaID );
			
				TimeSpan nrOreTotaleLucrateLuna = pa.GetAngajatNrOreLucrateLuna( lunaID );
			
				int nrZileTotaleAbsentateLuna = pa.GetAngajatNrZileAbsenteTotalLuna( lunaID );

				Data.IntervaleSchimbariLuna []intervSL = pa.GetIntervaleSchimbariLuna( lunaID );

				bool validareStergere = true;
				int [] nrZileLucratoareLuna = new int[intervSL.Length];
				int nrZileEvenimenteDeosebiteLuna = 0;
				int nrZileInvoireLuna = 0;
				int nrZileConcediuOdihnaLuna = 0;
				
				float nrZileCOneefectuat = 0;
				float nrZileCOefectInAvans = 0;

				int nrZileConcediuBoalaLuna = 0;
				int nrZileConcediuBoalaLunaFirma = 0;
				int nrZileConcediuBoalaLunaBASS = 0;

				int nrZileObligatiiCetatenesti = 0;
				int nrZileAbsenteNemotivate = 0;
				int nrZileConcediuFaraPlata = 0;

				int nrZileLucratoareDelegatieInterna = 0;
				int nrZileLucratoareDelegatieExterna = 0;
				decimal diurnaImpozabila = 0;
				int nrZileTotalDelegatieInterna = 0;
				int nrZileTotalDelegatieExterna = 0;

				float nrOreLucrate = 0;
				float nrOreSuplimentare50 = 0;
				float nrOreSuplimentare100 = 0;

				float [] salariuBaza  = new float[intervSL.Length];
				float [] indemnizatieConducere = new float[intervSL.Length] ;

				int nrZileEmergencyService = 0;
				
				int programLucru = 0;
				int invaliditate = 0;
				int categorieID = 0;

				decimal angajatSporActivitateSupLuna = 0;
				decimal angajatEmergencyServiceLuna = 0;
				decimal angajatPrimeSpecialeLuna = 0;
				decimal angajatAlteDrepturiLuna = 0;
				decimal angajatAlteDrepturiNetLuna = 0;
				decimal angajatAjutorDeces = 0;

				//S-au adaugat retinerile pentru un angajt
				decimal angajatAvansLuna = 0;
				decimal angajatRetinere1 = 0;
				decimal angajatRetinere2 = 0;
				decimal angajatRetinere3 = 0;
				decimal angajatRetinere4 = 0;
				decimal angajatRetinere5 = 0;
				decimal angajatRetinere6 = 0;
				decimal angajatRetinere7 = 0;
				decimal angajatRegularizareLuna = 0;
				decimal angajatPrimaProiectLuna = 0;
				decimal angajatRetinereSanatateLuna = 0;
				decimal angajatDrepturiInNaturaLuna = 0;

				//Lungu Andreea
				float nrTicheteLuna = 0;
				float corectiiTichete = 0;

				int i = -1;	

				foreach( Data.IntervaleSchimbariLuna interv in intervSL )
				{
					i++;

					nrZileLucratoareLuna[i] = pa.GetNrZileLucratoarePerioada( interv.DataStart, interv.DataEnd );

					TimeSpan nrOreLucrateLuna = pa.GetAngajatNrOreTipLucrate( interv.DataStart, interv.DataEnd, denumireOreLucrate[ 0 ] );
					TimeSpan nrOreSuplimentare50Luna = pa.GetAngajatNrOreTipLucrate( interv.DataStart, interv.DataEnd, denumireOreLucrate[ 1 ] );
					TimeSpan nrOreSuplimentare100Luna = pa.GetAngajatNrOreTipLucrate( interv.DataStart, interv.DataEnd, denumireOreLucrate[ 2 ] );

					//tre facut pe intervale de timp si pt absente
					nrZileEvenimenteDeosebiteLuna += pa.GetAngajatNrZileAbsenteTipLuna( interv.DataStart, interv.DataEnd, codAbsente[ 0 ] );
					nrZileInvoireLuna += pa.GetAngajatNrZileAbsenteTipLuna( interv.DataStart, interv.DataEnd, codAbsente[ 1 ] );
					nrZileConcediuOdihnaLuna += pa.GetAngajatNrZileAbsenteTipLuna( interv.DataStart, interv.DataEnd, codAbsente[ 2 ] ) +
						pa.GetAngajatNrZileAbsenteTipLuna( interv.DataStart, interv.DataEnd, codAbsente[ 11 ] );
					
					//Modificat:	Oprescu Claudia
					//Descriere:	Se calculeaza numarul de zile de concediu de odihna neefectuat si efectuat in avans
					nrZileCOneefectuat = this.GetNrZileConcediuOdihnaNeefectuat(lunaID, int.Parse(AngajatID + ""));
					nrZileCOefectInAvans = this.GetNrZileConcediuOdihnaEfectuatInAvans(lunaID, int.Parse(AngajatID + ""));

					nrZileConcediuBoalaLuna += pa.GetAngajatNrZileAbsenteTipLuna( interv.DataStart, interv.DataEnd,codAbsente[ 3 ] )+pa.GetAngajatNrZileAbsenteTipLuna( interv.DataStart, interv.DataEnd, codAbsente[ 4 ] );
					nrZileConcediuBoalaLunaFirma += pa.GetNrZileConcediuBoalaFirma(lunaID);
					nrZileConcediuBoalaLunaBASS += pa.GetNrZileConcediuBoalaBASS(lunaID);
					
					nrZileObligatiiCetatenesti += pa.GetAngajatNrZileAbsenteTipLuna( interv.DataStart, interv.DataEnd, codAbsente[ 5 ] );
					nrZileAbsenteNemotivate += pa.GetAngajatNrZileAbsenteTipLuna( interv.DataStart, interv.DataEnd, codAbsente[ 6 ] );
					nrZileConcediuFaraPlata += pa.GetAngajatNrZileAbsenteTipLuna( interv.DataStart, interv.DataEnd, codAbsente[ 7 ] );

					nrZileLucratoareDelegatieInterna += pa.GetAngajatNrZileAbsenteTipLuna( interv.DataStart, interv.DataEnd, codAbsente[ 8 ] );
					nrZileLucratoareDelegatieExterna += pa.GetAngajatNrZileAbsenteTipLuna( interv.DataStart, interv.DataEnd, codAbsente[ 9 ] );
					diurnaImpozabila = isl.DiurnaImpozabila;
					nrZileTotalDelegatieInterna += pa.GetAngajatNrZileCuSarbatoriAbsenteTipLuna( interv.DataStart, interv.DataEnd, codAbsente[ 8 ] );
					nrZileTotalDelegatieExterna += pa.GetAngajatNrZileCuSarbatoriAbsenteTipLuna( interv.DataStart, interv.DataEnd, codAbsente[ 9 ] );

					nrZileEmergencyService += pa.GetAngajatNrZileCuSarbatoriAbsenteTipLuna( interv.DataStart, interv.DataEnd, codAbsente[ 10 ] );

					angajatSporActivitateSupLuna = isl.SporActivitatiSup;
					angajatEmergencyServiceLuna = isl.EmergencyService;
					angajatPrimeSpecialeLuna = isl.PrimeSpeciale;
					angajatAlteDrepturiLuna = isl.AlteDrepturi;
					angajatAlteDrepturiNetLuna = isl.AlteDrepturiNet;
					angajatAjutorDeces = isl.AjutorDeces;

					angajatAvansLuna = isl.Avans;
					angajatRetinere1 = isl.Retineri1;
					angajatRetinere2 = isl.Retineri2;
					angajatRetinere3 = isl.Retineri3;
					angajatRetinere4 = isl.Retineri4;
					angajatRetinere5 = isl.Retineri5;
					angajatRetinere6 = isl.Retineri6;
					angajatRetinere7 = isl.Retineri7;
					angajatRegularizareLuna = isl.Regularizare;
					angajatPrimaProiectLuna = isl.PrimaProiect;
					angajatRetinereSanatateLuna = isl.RetinereSanatate;
					angajatDrepturiInNaturaLuna = isl.DrepturiInNatura;

					//Lungu Andreea
					nrTicheteLuna = isl.NrTichete;
					corectiiTichete = isl.CorectiiTichete;

					nrOreLucrate += nrOreLucrateLuna.Days*24+nrOreLucrateLuna.Hours+(float)nrOreLucrateLuna.Minutes/60;
					nrOreSuplimentare50 += nrOreSuplimentare50Luna.Days*24+nrOreSuplimentare50Luna.Hours+(float)nrOreSuplimentare50Luna.Minutes/60;
					nrOreSuplimentare100 += nrOreSuplimentare100Luna.Days*24+nrOreSuplimentare100Luna.Hours+(float)nrOreSuplimentare100Luna.Minutes/60;

					programLucru = interv.ProgramLucru;
					salariuBaza[i] = interv.SalariuBaza;
					indemnizatieConducere[i] = interv.IndemnizatieConducere;
					invaliditate = interv.Invaliditate;
					categorieID = interv.CategorieID;
				}
				

				//este adaugata situatia lunara a angajatului in cauza
				Salaries.Data.InfoSituatieLunara x = new Salaries.Data.InfoSituatieLunara();

				x.SituatieID = -1;
				x.AngajatID = this.AngajatID;
				x.LunaID = lunaID;
				
				x.CategorieID = categorieID;
				x.ProgramLucru = programLucru;
				//este calculat salariul de baza
				x.SalariuBaza = CalculSumaFinala(salariuBaza,nrZileLucratoareLuna,nrZileLucratoareLunaTotal);
				//este calculata indemnizatia de conducere
				x.IndemnizatieConducere = CalculSumaFinala(indemnizatieConducere,nrZileLucratoareLuna,nrZileLucratoareLunaTotal);
				x.Invaliditate = invaliditate;
			
				x.NrZileLuna = CalculNrZileLucrate(nrZileLucratoareLuna);

				x.NrOreLucrate = nrOreLucrate;
				x.NrOreSup50Proc = nrOreSuplimentare50;
				x.NrOreSup100Proc = nrOreSuplimentare100;

				x.NrOreEvenimDeoseb = nrZileEvenimenteDeosebiteLuna;
				x.NrOreInvoire = nrZileInvoireLuna;
				x.NrOreConcediuOdihna = nrZileConcediuOdihnaLuna;

				x.NrZileConcediuOdihnaNeefectuat = nrZileCOneefectuat;
				x.NrZileConcediuOdihnaEfectuatInAvans = nrZileCOefectInAvans;

				x.NrOreConcediuBoala = nrZileConcediuBoalaLuna ;
				x.NrOreConcediuBoalaFirma = nrZileConcediuBoalaLunaFirma ;
				x.NrOreConcediuBoalaBASS = nrZileConcediuBoalaLunaBASS ;

				x.NrOreObligatiiCetatenesti = nrZileObligatiiCetatenesti;
				x.NrOreAbsenteNemotivate = nrZileAbsenteNemotivate;
				x.NrOreConcediuFaraPlata = nrZileConcediuFaraPlata;

				x.NrOreLucrateDelegatieInterna = nrZileLucratoareDelegatieInterna;
				x.NrOreLucrateDelegatieExterna = nrZileLucratoareDelegatieExterna;
				x.DiurnaImpozabila = diurnaImpozabila;
				x.NrOreTotalDelegatieInterna = nrZileTotalDelegatieInterna;
				x.NrOreTotalDelegatieExterna = nrZileTotalDelegatieExterna;

				x.NrOreEmergencyService = nrZileEmergencyService;

				x.SporActivitatiSup = Convert.ToDecimal( angajatSporActivitateSupLuna );
				x.EmergencyService = Convert.ToDecimal( angajatEmergencyServiceLuna );
				x.PrimeSpeciale = Convert.ToDecimal( angajatPrimeSpecialeLuna );
				x.AlteDrepturi = Convert.ToDecimal( angajatAlteDrepturiLuna );
				x.AlteDrepturiNet = Convert.ToDecimal( angajatAlteDrepturiNetLuna );
				x.AjutorDeces = Convert.ToDecimal( angajatAjutorDeces );

				x.Avans = Convert.ToDecimal( angajatAvansLuna );
				x.Retineri1 = Convert.ToDecimal( angajatRetinere1 );
				x.Retineri2 = Convert.ToDecimal( angajatRetinere2 );
				x.Retineri3 = Convert.ToDecimal( angajatRetinere3 );
				x.Retineri4 = Convert.ToDecimal( angajatRetinere4 );
				x.Retineri5 = Convert.ToDecimal( angajatRetinere5 );
				x.Retineri6 = Convert.ToDecimal( angajatRetinere6 );
				x.Retineri7 = Convert.ToDecimal( angajatRetinere7 );
				x.Regularizare = Convert.ToDecimal( angajatRegularizareLuna );
				x.PrimaProiect = Convert.ToDecimal( angajatPrimaProiectLuna );
				x.RetinereSanatate = Convert.ToDecimal( angajatRetinereSanatateLuna );
				x.DrepturiInNatura = Convert.ToDecimal( angajatDrepturiInNaturaLuna );
				
				//Lungu Andreea
				x.NrTichete = nrTicheteLuna;
				x.CorectiiTichete = corectiiTichete;
				//nr total tichete
				x.NrTotalTichete = (int) Math.Ceiling(x.NrTichete + x.CorectiiTichete);
				if (x.NrTotalTichete < 0)
					//x.NrTotalTichete = (int) Math.Ceiling(x.NrTichete);
					x.NrTotalTichete = 0;

				/*
				 * Modified: Cristina Raluca Muntean
				 * Date:     13.09.2005
				 * A fost facuta aceasta modificare deoarece daca se lichida angajatul din prima zi, deci
				  nu se mai putea genera situatia lunara pe baza pontajului, atunci la adaugare era aruncata 
				  o exceptie si ramanea vechea situatie.
				 */

				//In cazul in care nu exista date pentru situatia lunara, aceasta se 
				//sterge(aceasta se poate intampla daca a fost lichidat angajatul din prima zi a lunii).
				if((x.NrZileLuna ==0)&&(x.CategorieID == 0)&&(x.ProgramLucru == 0))
				{
					this.DeleteSituatieAngajat(int.Parse(x.LunaID.ToString()),int.Parse(x.AngajatID.ToString()));
				}
				else
				{
					//Daca exista date pentru situatia lunara, atunci se sterge vechea situatie
					//lunara si se adauga situatia cu noile date.
					this.AddSituatieLunaraAngajat( x, validareStergere );
					validareStergere = false;
				}
			}
			catch
			{}
		}
		#endregion

		#region CalculNrZileLucrate
		/// <summary>
		/// Added: Muntean Raluca Cristina
		/// Calculeaza numarul total de zile lucratoare lucrate in luna curenta 
		/// </summary>
		/// <param name="nrZileLucratoareLuna">Nr de zile lucratoare din luna</param>
		/// <returns>Returneaza nr de zile lucrate</returns>
		private int CalculNrZileLucrate(int[] nrZileLucratoareLuna)
		{
			int nrZileLucratoare = 0;
			for(int i=0;i<nrZileLucratoareLuna.Length;i++)
				nrZileLucratoare += nrZileLucratoareLuna[i];
			
			return nrZileLucratoare;
		}
		#endregion

		#region CalculSumaFinala
		/// <summary>
		/// Added: Muntean Raluca Cristina  
		/// Calculeaza salariul de baza final sau indemnizatia de conducere, dupa caz, dupa formula:
		/// sumaRezultatat = salariul perioada I/nr zile lucratoare*nr zile lucrate in perioada + salariul perioada II/nr zile lucratoare*nr zile lucrate in perioada +...
		/// Changed: Ionel Popa
		/// 		- in cazul in care luna nu este in totalitate lucrata se considera sumaRezultat = salariu perioada I
		/// </summary>
		/// <param name="sume">Sirul de sume</param>
		/// <param name="nrZileLucratoarePerioada">Nr de zile lucratoare pe o perioada</param>
		/// <param name="nrZileLucratoareLunaTotal">Nr de zile lucratoare pe luna</param>
		/// <returns>Returneaza suma finala</returns>
		private float CalculSumaFinala(float []sume,int []nrZileLucratoarePerioada, int nrZileLucratoareLunaTotal)
		{
			decimal sumaRezultat = 0;
			//insumeaza numarul de zile lucrate
			long nrZileLucrate = 0;

			for(int i=0; i<sume.Length; i++)
			{
				sumaRezultat += (decimal)sume[i]/nrZileLucratoareLunaTotal * nrZileLucratoarePerioada[i];
				nrZileLucrate += nrZileLucratoarePerioada[i];
			}

			decimal sumaDecimal;
			if (nrZileLucrate == nrZileLucratoareLunaTotal)
			{
				sumaDecimal = Math.Round(sumaRezultat);
			}
			else
			{
				//Din cauza ca este proaspat angajat se considera ca exista o singura situatie a angajatului si suma rezultata este egala cu prima (si singura) suma din vector
				//In cazul in care chiar daca este proaspat angajat si exista mai multe situatii atunci aceasta formula NU este buna.
				sumaDecimal = Math.Round((decimal)sume[0]);
			}
			
			return (float)sumaDecimal;
		}
		#endregion

		#region GetSituatiiLunare
		/// <summary>
		/// Procedura selecteaza situatiile lunare
		/// </summary>
		/// <param name="LunaID">Luna pentru care se selecteaza</param>
		/// <returns>Returneaza un DataSet care contine aceste date</returns>
		public DataSet GetSituatiiLunare(long LunaID)
		{
			Data.SituatieLunaraAngajat situatii=new Data.SituatieLunaraAngajat(settings.ConnectionString);
			DataSet dsSituatiiLunare = situatii.GetSituatiiLunare(this.AngajatID, LunaID);
			return dsSituatiiLunare;
		}
		#endregion

		#region AddSituatieLunaraAngajat
		/// <summary>
		/// Procedura adauga situatia lunara a unui angajat
		/// </summary>
		/// <param name="isl">Obiectul care contine situatia lunara</param>
		/// <param name="ValidareStergere">Se face validare la stergere sau nu</param>
		/// <returns>Returneaza rezultatul rfectuarii adaugarii</returns>
		public int AddSituatieLunaraAngajat(Salaries.Data.InfoSituatieLunara isl, bool ValidareStergere)
		{
//			try
//			{
				return this.AddSituatieLunaraAngajat(isl.LunaID,isl.AngajatID,isl.NrZileLuna,isl.NrOreLucrate,isl.NrOreSup50Proc,isl.NrOreSup100Proc,isl.NrOreEvenimDeoseb,isl.NrOreInvoire,isl.NrOreConcediuOdihna, isl.NrZileConcediuOdihnaNeefectuat,isl.NrZileConcediuOdihnaEfectuatInAvans,isl.NrOreConcediuBoala, isl.NrOreConcediuBoalaFirma, isl.NrOreConcediuBoalaBASS, isl.NrOreObligatiiCetatenesti, isl.NrOreAbsenteNemotivate, isl.NrOreConcediuFaraPlata, isl.NrOreTotalDelegatieInterna, isl.NrOreTotalDelegatieExterna, isl.NrOreLucrateDelegatieInterna, isl.NrOreLucrateDelegatieExterna, isl.DiurnaImpozabila, isl.NrOreEmergencyService, isl.NrTichete, isl.CorectiiTichete, isl.NrTotalTichete, isl.SporActivitatiSup,isl.EmergencyService,isl.PrimeSpeciale,isl.AlteDrepturi, isl.AlteDrepturiNet, isl.AjutorDeces, isl.Avans, /*isl.Retineri,*/ isl.Regularizare, isl.PrimaProiect, isl.RetinereSanatate, isl.DrepturiInNatura, isl.ProgramLucru, isl.SalariuBaza, isl.IndemnizatieConducere, isl.Invaliditate, isl.CategorieID, ValidareStergere);
//			}
//			catch( Exception exc)
//			{
//				string aaa = exc.Message;
//				return -1;
//			}
		}
		#endregion
		
		#region ModifSituatieLunaraAngajat
		/// <summary>
		/// Procedura modifica situatia lunara a unui angajat
		/// </summary>
		/// <param name="isl">Obiect care contine noile date</param>
		/// <returns>Returneaza rezultatul modificarii</returns>
		public int ModifSituatieLunaraAngajat(Salaries.Data.InfoSituatieLunara isl)
		{
			return new Salaries.Data.SituatieLunaraAngajat(this.settings.ConnectionString).UpdateSituatieLunaraAngajat(isl);
		}
		#endregion

		#region DeleteSituatieLunaraAngajat
		/// <summary>
		/// Procedura sterge situatia lunara a unui angajat
		/// </summary>
		/// <param name="isl">Obiectul care contine situatia lunara</param>
		/// <returns>Returneaza rezultatul stergerii</returns>
		public int DeleteSituatieLunaraAngajat(Salaries.Data.InfoSituatieLunara isl)
		{
			//Adaugat:		Oprescu Claudia
			//Descriere:	Daca se sterge situatia lunara a unui angajat, valorile pentru retineri sunt setate pe 0 pentru angajatul respectiv
			TipuriRetineriValori trv = new TipuriRetineriValori();
			trv.UpdateRetineriValori(isl.LunaID, isl.AngajatID, 0, 0, 0, 0, 0, 0, 0);

			return new Salaries.Data.SituatieLunaraAngajat(this.settings.ConnectionString).DeleteSituatieLunaraAngajat(isl);
		}
		#endregion

		#region DeleteSituatieAngajat
		/// <summary>
		/// Procedura sterge situatia lunara a unui angajat
		/// </summary>
		/// <param name="LunaID">Id-ul lunii</param>
		/// <param name="AngajatID">Id-ul angajatului</param>
		/// <returns>Returneaza rezultatul stergerii</returns>
		public int DeleteSituatieAngajat(int LunaID, int AngajatID)
		{
			//Adaugat:		Oprescu Claudia
			//Descriere:	Daca se sterge situatia lunara a unui angajat, valorile pentru retineri sunt setate pe 0 pentru angajatul respectiv
			TipuriRetineriValori trv = new TipuriRetineriValori();
			trv.UpdateRetineriValori(LunaID, AngajatID, 0, 0, 0, 0, 0, 0, 0);

            return new Salaries.Data.SituatieLunaraAngajat(this.settings.ConnectionString).DeleteSituatieAngajat(LunaID, AngajatID); 		
		}
		#endregion

		#region AddSituatieLunaraAngajat
		/// <summary>
		/// Procedura adauga situatia lunata a unui angajat
		/// </summary>
		/// <returns>Returneaza rezultatul adaugarii</returns>
		public int AddSituatieLunaraAngajat
			(
			int LunaID,
			long AngajatID,
			float NrZileLuna,
			float NrOreLucrate,
			float NrOreSup50Proc,
			float NrOreSup100Proc,
			float NrOreEvenimDeoseb,
			float NrOreInvoire,
			float NrOreConcediuOdihna,
			float NrZileConcediuOdihnaNeefectuat, 
			float NrZileConcediuOdihnaEfectuatInAvans,
			float NrOreConcediuBoala,
			float NrOreConcediuBoalaFirma,
			float NrOreConcediuBoalaBASS,
			float NrOreObligatiiCetatenesti,
			float NrOreAbsenteNemotivate,
			float NrOreConcediuFaraPlata,
			float NrOreTotalDelegatieInterna,
			float NrOreTotalDelegatieExterna,
			float NrOreLucrateDelegatieInterna,
			float NrOreLucrateDelegatieExterna,
			decimal DiurnaImpozabila,
			float NrOreEmergencyService,
			float NrTichete,
			float CorectiiTichete,
			int NrTotalTichete,
			decimal SporActivitatiSup,
			decimal EmergencyService,
			decimal PrimeSpeciale,
			decimal AlteDrepturi,
			decimal AlteDrepturiNet,
			decimal AjutorDeces,
			decimal Avans,
			decimal Regularizare,
			decimal PrimaProiect,
			decimal RetinereSanatate,
			decimal DrepturiInNatura,
			int ProgramLucru,
			float SalariuBaza,
			float IndemnizatieConducere,
			int Invaliditate,
			int CategorieID,
			bool ValidareStergere
			)
		{
			return new Salaries.Data.SituatieLunaraAngajat(this.settings.ConnectionString).InsertSituatieLunaraAngajat(LunaID,this.AngajatID,NrZileLuna,NrOreLucrate,NrOreSup50Proc,NrOreSup100Proc,NrOreEvenimDeoseb,NrOreInvoire,NrOreConcediuOdihna,NrZileConcediuOdihnaNeefectuat, NrZileConcediuOdihnaEfectuatInAvans,NrOreConcediuBoala, NrOreConcediuBoalaFirma, NrOreConcediuBoalaBASS, NrOreObligatiiCetatenesti, NrOreAbsenteNemotivate, NrOreConcediuFaraPlata, NrOreTotalDelegatieInterna, NrOreTotalDelegatieExterna, NrOreLucrateDelegatieInterna, NrOreLucrateDelegatieExterna, DiurnaImpozabila, NrOreEmergencyService, NrTichete, CorectiiTichete, NrTotalTichete, SporActivitatiSup,EmergencyService,PrimeSpeciale,AlteDrepturi, AlteDrepturiNet, AjutorDeces, Avans, Regularizare, PrimaProiect, RetinereSanatate, DrepturiInNatura, ProgramLucru, SalariuBaza, IndemnizatieConducere, Invaliditate, CategorieID, ValidareStergere);
		}
		#endregion

		#region AddSituatieLunaraAngajat
		/// <summary>
		/// Procedura adauga situatia lunata a unui angajat
		/// </summary>
		/// <returns>Returneaza rezultatul adaugarii</returns>
		public int AddSituatieLunaraAngajat
			(
			int LunaID,
			long AngajatID,
			float NrZileLuna,
			float NrOreLucrate,
			float NrOreSup50Proc,
			float NrOreSup100Proc,
			float NrOreEvenimDeoseb,
			float NrOreInvoire,
			float NrOreConcediuOdihna,
			float NrZileConcediuOdihnaNeefectuat,
			float NrZileConcediuOdihnaEfectuatInAvans,
			float NrOreConcediuBoala,
			float NrOreConcediuBoalaFirma,
			float NrOreConcediuBoalaBASS,
			float NrOreObligatiiCetatenesti,
			float NrOreAbsenteNemotivate,
			float NrOreConcediuFaraPlata,
			float NrOreTotalDelegatieInterna,
			float NrOreTotalDelegatieExterna,
			float NrOreLucrateDelegatieInterna,
			float NrOreLucrateDelegatieExterna,
			decimal DiurnaImpozabila,
			float NrOreEmergencyService,
			float NrTichete,
			float CorectiiTichete,
			int NrTotalTichete,
			decimal SporActivitatiSup,
			decimal EmergencyService,
			decimal PrimeSpeciale,
			decimal AlteDrepturi,
			decimal AlteDrepturiNet,
			decimal AjutorDeces,
			decimal Avans,
			decimal Regularizare,
			decimal PrimaProiect,
			decimal RetinereSanatate,
			decimal DrepturiInNatura,
			int ProgramLucru,
			float SalariuBaza,
			float IndemnizatieConducere,
			int Invaliditate,
			int CategorieID
			)
		{
			return new Salaries.Data.SituatieLunaraAngajat(this.settings.ConnectionString).InsertSituatieLunaraAngajat(LunaID,this.AngajatID,NrZileLuna,NrOreLucrate,NrOreSup50Proc,NrOreSup100Proc,NrOreEvenimDeoseb,NrOreInvoire,NrOreConcediuOdihna,NrZileConcediuOdihnaNeefectuat, NrZileConcediuOdihnaEfectuatInAvans,NrOreConcediuBoala, NrOreConcediuBoalaFirma, NrOreConcediuBoalaBASS, NrOreObligatiiCetatenesti, NrOreAbsenteNemotivate, NrOreConcediuFaraPlata, NrOreTotalDelegatieInterna, NrOreTotalDelegatieExterna, NrOreLucrateDelegatieInterna, NrOreLucrateDelegatieExterna, DiurnaImpozabila, NrOreEmergencyService, NrTichete, CorectiiTichete, NrTotalTichete, SporActivitatiSup,EmergencyService,PrimeSpeciale,AlteDrepturi, AlteDrepturiNet, AjutorDeces, Avans, Regularizare, PrimaProiect, RetinereSanatate, DrepturiInNatura, ProgramLucru, SalariuBaza, IndemnizatieConducere, Invaliditate, CategorieID );
		}
		#endregion

		#region GetSituatieLunaraAngajat
		/// <summary>
		/// Procedura selecteaza situatia lunara a unui angajat
		/// </summary>
		/// <param name="AngajatID">Id-ul angajatului</param>
		/// <param name="LunaID">Id-ul lunii</param>
		/// <returns>Returneaza un obiect care contine situatia lunara</returns>
		public Salaries.Data.InfoSituatieLunara GetSituatieLunaraAngajat(long AngajatID, int LunaID)
		{
			return new Salaries.Data.SituatieLunaraAngajat(this.settings.ConnectionString).GetSituatieLunaraAngajat(AngajatID,LunaID);
		}
		#endregion

		#region GetSituatiiLunareAngajat
		/// <summary>
		/// Procedura selecteaza situatia lunara a unui angajat pentru o anumita luna
		/// </summary>
		/// <param name="LunaID">Id-ul lunii</param>
		/// <returns>Returneaza un DataSet care contine aceste date</returns>
		public DataSet GetSituatiiLunareAngajat( int LunaID )
		{
			return new Salaries.Data.SituatieLunaraAngajat(this.settings.ConnectionString).GetSituatieLunaraAngajatDataSet(this.AngajatID,LunaID);
		}
		#endregion

		#region GetSituatieLunaraAngajat
		/// <summary>
		/// Procedura selecteaza o situatie lunara a unui angajat
		/// </summary>
		/// <param name="SituatieID">Id-ul situatiei selectate</param>
		/// <returns>Returneaza un obiect care contine situatia lunara</returns>
		public Salaries.Data.InfoSituatieLunara GetSituatieLunaraAngajat( int SituatieID )
		{
			return new Salaries.Data.SituatieLunaraAngajat(this.settings.ConnectionString).GetSituatieLunaraAngajatByID(SituatieID);
		}
		#endregion

		#region GetCategorieAngajat
		/// <summary>
		/// Procedura selecteaza cateoria salariala a unui angajat
		/// </summary>
		/// <returns>Returneaza id-ul categoriei salariale</returns>
		private int GetCategorieAngajat()
		{
			Salaries.Data.SituatieLunaraAngajat sla = new Salaries.Data.SituatieLunaraAngajat( this.settings.ConnectionString );
			return sla.GetCategorieAngajat( this.AngajatID );
		}
		#endregion

		#region GetNrZileConcediuBoalaLunaFirma
		/// <summary>
		/// Procedura calculeaza nr de zile de CB pe luna oferite de firma
		/// </summary>
		/// <param name="lunaID">Id-ul lunii</param>
		/// <param name="angajatorID">Id-ul angajatorului</param>
		/// <returns>Returneaza nr de zile de CB</returns>
		private int GetNrZileConcediuBoalaLunaFirma( int lunaID, int angajatorID )
		{
			Salaries.Data.SituatieLunaraAngajat sla = new Salaries.Data.SituatieLunaraAngajat( this.settings.ConnectionString );
			int LunaID = new Luni( angajatorID ).GetLunaPrecedenta( lunaID );
			return LunaID==0 ? sla.GetNrZileConcediuBoalaLunaFirma( lunaID, angajatorID ) : sla.GetNrZileConcediuBoalaLunaFirma( LunaID, angajatorID );
		}
		#endregion

		#region GetNrZileConcediuOdihnaNeefectuat
		/// <summary>
		/// Returneaza numarul de zile de concediu de odihna neefectuat.
		/// </summary>
		/// <param name="lunaID"> ID-ul lunii.</param>
		/// <param name="angajatID"> ID-ul angajatului.</param>
		/// <returns> Numarul de zile de concediu de odihna neefectuat.</returns>
		public int GetNrZileConcediuOdihnaNeefectuat( int lunaID, int angajatID )
		{
			Salaries.Data.SituatieLunaraAngajat situatieLunaraAngajat = new Salaries.Data.SituatieLunaraAngajat( this.settings.ConnectionString );
			return situatieLunaraAngajat.GetNrZileConcediuOdihnaNeefectuat(lunaID,angajatID);
		}
		#endregion

		#region GetNrZileConcediuOdihnaEfectuatInAvans
		/// <summary>
		/// Returneaza numarul de zile de concediu de odihna efectuat in avans.
		/// </summary>
		/// <param name="lunaID"> ID-ul lunii.</param>
		/// <param name="angajatID"> ID-ul angajatului.</param>
		/// <returns> Numarul de zile de concediu de odihna efectuat in avans.</returns>
		public int GetNrZileConcediuOdihnaEfectuatInAvans( int lunaID, int angajatID )
		{
			Salaries.Data.SituatieLunaraAngajat situatieLunaraAngajat = new Salaries.Data.SituatieLunaraAngajat( this.settings.ConnectionString );
			return situatieLunaraAngajat.GetNrZileConcediuOdihnaEfectuatInAvans(lunaID,angajatID);
		}
		#endregion

		#region reporteaza corectii tichete
		public void ReporteazaDiferentaCorectiTichete(int lunaID)
		{
			Salaries.Data.SituatieLunaraAngajat situatieLunaraAngajat = new Salaries.Data.SituatieLunaraAngajat( this.settings.ConnectionString );
			situatieLunaraAngajat.ReporteazaDiferentaCorectiiTichete(lunaID,AngajatID);
		}
		#endregion

		#region GetAllSituatiiLunareAngajatDataSet
		/// <summary>
		/// Procedura selecteaza situatiile lunare ale unui angajat
		/// </summary>
		/// <returns>Returneaza un DataSet care contine aceste date</returns>
		public DataSet GetAllSituatiiLunareAngajatDataSet()
		{
			return new Salaries.Data.SituatieLunaraAngajat(this.settings.ConnectionString).GetAllSituatiiLunareAngajatDataSet(this.AngajatID);
		}
		#endregion

	}
}


