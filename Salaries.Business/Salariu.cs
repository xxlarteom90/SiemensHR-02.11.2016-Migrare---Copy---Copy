/*
 *	Autor:     Cristina Muntean
 *  Data:      16.03.2004
 *  Obs:	   Clasa a fost rescrisa in intregime, vechile metode ale clasei sunt comentate 
 */
using System;
using System.Data;

namespace Salaries.Business
{
	/// <summary>
	/// Summary description for Salariu.
	/// </summary>
	public sealed class Salariu : Salaries.Business.BizObject
	{
		#region Atribute private
		//Setari aplicatie
		private Configuration.ModuleSettings settings;
		//Atribute
		private int id;
		private long angajatID;
		private int lunaID;
		private decimal salariuIncadrare;
		private decimal indemnizatieConducere;
		private decimal prime;
		private decimal alteDrepturi;
		private decimal indemnizatieConcediuMedical;
		private decimal venitBrut;
		private decimal deduceriPersonale;
		private decimal bazaImpozitare;
		private decimal impozit;
		private decimal venitNet;
		private decimal salariuNet;
		private decimal avans;
		private decimal retineri;
		private decimal totalRetineri;
		private decimal restDePlata;
		private decimal salariuIncadrareRealizat;
		private decimal indemnizatieConducereRealizata;
		private decimal drepturiBanestiConcediuOdihna;
		private decimal drepturiBanestiConcediuEvDeosebite;
		private decimal drepturiBanestiOreSuplimentare;
		private decimal sumaConcediuBoalaFirma;
		private decimal sumaConcediuBoalaBASS;
		private decimal ajutorDeces;
		private decimal regularizare;
		#endregion

		#region Proprietati
		public int ID
		{
			get { return id; }
			set { id = value; }
		}

		public long AngajatID
		{
			get { return angajatID; }
			set { angajatID = value; }
		}

		public decimal SalariuIncadrare
		{
			get { return salariuIncadrare; }
			set { salariuIncadrare = value; }
		}
		
		public decimal IndemnizatieConducere
		{
			get { return indemnizatieConducere; }
			set { indemnizatieConducere = value; }
		}

		public decimal Prime
		{
			get { return prime; }
			set { prime = value; }
		}

		public decimal AlteDrepturi
		{
			get { return alteDrepturi; }
			set { alteDrepturi = value; }
		}

		public decimal VenitBrut
		{
			get { return venitBrut; }
			set { venitBrut = value; }
		}

		public decimal VenitNet
		{
			get { return venitNet; }
			set { venitNet = value; }
		}

		public decimal DeduceriPersonale
		{
			get { return deduceriPersonale; }
			set { deduceriPersonale = value; }
		}

		public decimal BazaImpozitare
		{
			get { return bazaImpozitare; }
			set { bazaImpozitare = value; }
		}

		public decimal Impozit
		{
			get { return impozit; }
			set { impozit = value; }
		}

		public decimal Avans
		{
			get { return avans; }
			set { avans = value; }
		}

		public decimal Retineri
		{
			get { return retineri; }
			set { retineri = value; }
		}
		
		public decimal TotalRetineri
		{
			get { return totalRetineri; }
			set { totalRetineri = value; }
		}

		public decimal SalariuNet
		{
			get { return salariuNet; }
			set { salariuNet = value; }
		}

		public decimal RestDePlata
		{
			get { return restDePlata; }
			set { restDePlata = value; }
		}

		public decimal SalariuIncadrareRealizat
		{
			get { return salariuIncadrareRealizat; }
			set { salariuIncadrareRealizat = value; }
		}

		public decimal IndemnizatieConducereRealizata
		{
			get { return indemnizatieConducereRealizata; }
			set { indemnizatieConducereRealizata = value; }
		}
		
		public decimal DrepturiBanestiConcediuOdihna
		{
			get { return drepturiBanestiConcediuOdihna; }
			set { drepturiBanestiConcediuOdihna = value; }
		}

		public decimal DrepturiBanestiConcediuEvDeosebite
		{
			get { return drepturiBanestiConcediuEvDeosebite; }
			set { drepturiBanestiConcediuEvDeosebite = value; }
		}

		public decimal DrepturiBanestiOreSuplimentare
		{
			get { return drepturiBanestiOreSuplimentare; }
			set { drepturiBanestiOreSuplimentare = value; }
		}

		public decimal SumaConcediuBoalaFirma
		{
			get { return sumaConcediuBoalaFirma; }
			set { sumaConcediuBoalaFirma = value; }
		}

		public decimal SumaConcediuBoalaBASS
		{
			get { return sumaConcediuBoalaBASS; }
			set { sumaConcediuBoalaBASS = value; }
		}

		public decimal AjutorDeces
		{
			get { return ajutorDeces; }
			set { ajutorDeces = value; }
		}

		public decimal Regularizare
		{
			get { return regularizare; }
			set { regularizare = value; }
		}
		#endregion

		#region Constructor
		/// <summary>
		/// Constructor
		/// </summary>
		public Salariu()
		{
			settings = Configuration.ModuleConfig.GetSettings();
			ResetProperties();
		}
		#endregion
		
		#region LoadSalariuID
		/// <summary>
		/// Returneaza detaliile pentru o inregistrare din tabela sal_StatDePlata
		/// </summary>
		private void LoadSalariuID()
		{
			Data.Salarii salarii = new Data.Salarii(settings.ConnectionString);
			Data.DetaliiSalarii detalii = salarii.GetDetalii(id);
			id = detalii.ID ;
			angajatID = detalii.AngajatID ;
			lunaID = detalii.LunaID ;
			prime = detalii.Prime ;
			alteDrepturi = detalii.AlteDrepturi ;
			indemnizatieConcediuMedical = detalii.IndemnizatieConcediuMedical ;
			salariuIncadrare = detalii.SalariuIncadrare ;
			indemnizatieConducere = detalii.IndemnizatieConducere ;
			venitBrut = detalii.VenitBrut ;
			venitNet = detalii.VenitNet ;
			deduceriPersonale = detalii.DeduceriPersonale ;
			bazaImpozitare = detalii.BazaImpozitare ;
			impozit = detalii.Impozit ;
			salariuNet = detalii.SalariuNet; 
			avans = detalii.Avans;
			retineri = detalii.Retineri;
			totalRetineri = detalii.TotalRetineri;
			restDePlata = detalii.RestDePlata; 			
		}
		#endregion	
		
		#region ResetProperties
		/// <summary>
		/// Sunt resetate proprietatile
		/// </summary>
		private void ResetProperties()
		{
			id = -1;
			angajatID = -1;
			lunaID = -1;
			salariuIncadrare = 0;
			indemnizatieConducere = 0;
			prime = 0;
			alteDrepturi = 0;
			indemnizatieConcediuMedical = 0;
			venitBrut = 0;
			impozit = 0;
			venitNet = 0;
			salariuNet = 0;
			avans = 0;
			retineri = 0;
			totalRetineri = 0;
			restDePlata = 0;
			salariuIncadrareRealizat=0;
			indemnizatieConducereRealizata=0;
			drepturiBanestiConcediuOdihna=0;
			drepturiBanestiConcediuEvDeosebite=0;
			drepturiBanestiOreSuplimentare=0;
			sumaConcediuBoalaFirma=0;
			sumaConcediuBoalaBASS=0;
		}
		#endregion
	
		#region Add
		/// <summary>
		/// Adauga o inregistrare in tabela sal_StatDePlata
		/// </summary>
		/// <returns>Returneaza true daca s-a facut adaugarea si false altfel</returns>
		public int Add()
		{
			Data.Salarii salarii = new Salaries.Data.Salarii(settings.ConnectionString);
				
			return salarii.Add(angajatID,lunaID, prime, alteDrepturi, indemnizatieConcediuMedical, 
				venitBrut, venitNet,deduceriPersonale,bazaImpozitare, impozit, salariuNet, avans, retineri,
				totalRetineri, restDePlata, salariuIncadrareRealizat,indemnizatieConducereRealizata,
				drepturiBanestiConcediuOdihna, drepturiBanestiConcediuEvDeosebite, drepturiBanestiOreSuplimentare,
			    sumaConcediuBoalaFirma, sumaConcediuBoalaBASS, ajutorDeces,regularizare);
		}
		#endregion		
		
		#region Update
		/// <summary>
		/// Face update unei inregistrari tabelei sal_StatDePlata 
		/// </summary>
		/// <returns>Returneaza true daca s-a facut actualizarea si false altfel</returns>
		public bool Update()
		{
			Data.Salarii salarii = new Data.Salarii(settings.ConnectionString);

			return salarii.Update(id, angajatID,lunaID,	prime, alteDrepturi, indemnizatieConcediuMedical,
				venitBrut, venitNet, deduceriPersonale,bazaImpozitare, impozit, salariuNet, avans, retineri,
				totalRetineri, restDePlata, salariuIncadrareRealizat,indemnizatieConducereRealizata,
				drepturiBanestiConcediuOdihna, drepturiBanestiConcediuEvDeosebite, drepturiBanestiOreSuplimentare,
				sumaConcediuBoalaFirma, sumaConcediuBoalaBASS, ajutorDeces, regularizare);
		}
		#endregion
	
		#region Delete
		/// <summary>
		/// Sterge o inregistrare din tabela sal_StatDePlata
		/// </summary>
		/// <returns>Returneaza true daca s-a facut actualizarea si false altfel</returns>
		public bool Delete()
		{
			Data.Salarii salarii = new Data.Salarii(settings.ConnectionString);
			bool ret =  salarii.Delete(id);
			ResetProperties();
			
			return ret;
		}
		#endregion
	
		#region StatDePlata
		/// <summary>
		/// Returneaza toate datele din statul de plata pentru un anumit angajator pentru o anumita luna
		/// </summary>
		/// <param name="LunaID">Id-ul lunii</param>
		/// <param name="AngajatorID">Id-ul angajatorului</param>
		/// <returns>Retureaza un DataSet care contine aceste date</returns>
		public DataSet StatPlata(int LunaID,int AngajatorID)
		{
			return new Salaries.Data.Salarii(settings.ConnectionString).StatPlata(AngajatorID,LunaID);
		}
		#endregion

		#region CalculSalariiIndexate
		/// <summary>
		/// Autor: Cristina Raluca Muntean
		/// Data: 28.12.2005
		/// Descriere: Returneaza valorile salariilor indexate ale angajatilor.
		/// </summary>
		/// <param name="angajatorID">Id-ul angajatorului</param>
		/// <returns>Returneaza un DataSet care contine aceste date</returns>
		public DataSet CalculSalariiIndexate(int angajatorID)
		{
			Data.Salarii salariiIndexate = new Salaries.Data.Salarii(settings.ConnectionString);
			return salariiIndexate.CalculSalariiIndexate(angajatorID);
		}
		#endregion

		#region CalculProcentIndexareAngajat()
		/// <summary>
		/// Este calculat procentul cu care a fost(urmeaza sa fie) indexat salariul angajatului.
		/// </summary>
		/// <returns> Procentul cu care a fost(urmeaza sa fie) indexat salariul angajatului</returns>
		/// <remarks>
		/// Autor: Cristina Raluca Muntean
		/// Data:  5.05.2006
		/// </remarks>
		public float CalculProcentIndexareAngajat()
		{
			Data.Salarii salarii = new Salaries.Data.Salarii(settings.ConnectionString);
			return salarii.CalculProcentIndexareAngajat(angajatID);
		}
		#endregion

		#region CalculVenitBrutIndexat
		/// <summary>
		/// Este calculat salariul angajatului dupa indexare.
		/// </summary>
		/// <param name="angajatID"> ID-ul angajatului</param>
		/// <returns> Valoarea salariului dupa indexare.</returns>
		/// <remarks>
		/// Autor: Cristina Raluca Muntean
		/// Data:  5.05.2006
		/// </remarks>
		public float CalculVenitBrutIndexat()
		{
			Data.Salarii salarii = new Salaries.Data.Salarii(settings.ConnectionString);
			return salarii.CalculVenitBrutIndexat(angajatID);
		}
		#endregion	

		#region GetCodareStatDePlata
		/// <summary>
		/// Procedura returneaza codarea statului de plata
		/// </summary>
		/// <returns>Returneaza un DataSet care contine aceste date</returns>
		public DataSet GetCodareStatDePlata()
		{	
			Data.Salarii salarii = new Salaries.Data.Salarii(settings.ConnectionString);
			return salarii.GetCodareStatDePlata();
		}
		#endregion

		#region GetCodareColoaneStatDePlata
		/// <summary>
		/// Procedura returneaza codarea unei coloane a statului de plata
		/// </summary>
		/// <returns>Returneaza un DataSet care contine aceste date</returns>
		public DataSet GetCodareColoaneStatDePlata()
		{	
			Data.Salarii salarii = new Salaries.Data.Salarii(settings.ConnectionString);
			return salarii.GetCodareColoaneStatDePlata();
		}
		#endregion

		#region UpdateTemplate
		/// <summary>
		/// Procedura actualizeaza datele despre coloanele afisate pe statul de plata
		/// </summary>
		/// <param name="template">String-ul contine coloanele care se vor afisa pe statul de plata</param>
		public void UpdateTemplate(string template)
		{
			Data.Salarii salarii = new Salaries.Data.Salarii(settings.ConnectionString);
			salarii.UpdateTemplate(template);
		}
		#endregion

		#region VerifyCalculSalarial
		//verifica daca pentru luna activa a fost sau nu facut calculul salarial
		public bool VerifyCalculSalarial(int angajatorID)
		{
			Data.Salarii salarii = new Salaries.Data.Salarii(settings.ConnectionString);
			return salarii.VerifyCalculSalarial(angajatorID);
		}
		#endregion

		//--------------------------------pentru declaratie unica----------------------------------
		#region CalculCreante
		/// <summary>
		/// Autor: Lungu Andreea
		/// Data: 18.02.2011
		/// Descriere: Se calculeaza creantele fiscale pentru angajator
		/// </summary>
		/// <param name="angajatorID">Id-ul angajatorului</param>
		/// <param name="lunaID">Id-ul lunii</param>
		public void CalculCreante(int angajatorID, int lunaID)
		{
			Data.Salarii creante = new Salaries.Data.Salarii(settings.ConnectionString);
			creante.CalculCreante(angajatorID, lunaID);
		}
		#endregion

		#region GetCreante
		/// <summary>
		/// Autor: Lungu Andreea
		/// Data: 18.02.2011
		/// Descriere: Returneaza valorile creantelor pentru angajator.
		/// </summary>
		/// <param name="angajatorID">Id-ul angajatorului</param>
		/// <param name="lunaID">Id-ul lunii</param>
		/// <returns>Returneaza un DataSet care contine aceste date</returns>
		public DataSet getCreante(int angajatorID, int lunaID)
		{
			Data.Salarii creante = new Salaries.Data.Salarii(settings.ConnectionString);
			return creante.GetCreante(angajatorID, lunaID);
		}
		#endregion

		#region CalculNumarAsigurati
		/// <summary>
		/// Autor: Lungu Andreea
		/// Data: 18.02.2011
		/// Descriere: Returneaza nr de asigurati pt somaj, sanatate si cas.
		/// </summary>
		/// <param name="angajatorID">Id-ul angajatorului</param>
		/// <param name="lunaID">Id-ul lunii</param>
		/// <returns>Returneaza un DataSet care contine aceste date</returns>
		public DataSet CalculNumarAsigurati(int angajatorID, int lunaID)
		{
			Data.Salarii sal = new Salaries.Data.Salarii(settings.ConnectionString);
			return sal.CalculNumarAsigurati(angajatorID, lunaID);
		}
		#endregion

		#region GetBazeCalculAngajator
		/// <summary>
		/// Autor: Lungu Andreea
		/// Data: 18.02.2011
		/// Descriere: Returneaza bazele de calcul pentru angajator.
		/// </summary>
		/// <param name="angajatorID">Id-ul angajatorului</param>
		/// <param name="lunaID">Id-ul lunii</param>
		/// <returns>Returneaza un DataSet care contine aceste date</returns>
		public DataSet GetBazeCalculAngajator(int angajatorID, int lunaID)
		{
			Data.Salarii sal = new Salaries.Data.Salarii(settings.ConnectionString);
			return sal.GetBazeCalculAngajator(angajatorID, lunaID);
		}
		#endregion

		#region GetContributiiUnitateAngajator
		/// <summary>
		/// Autor: Lungu Andreea
		/// Data: 18.02.2011
		/// Descriere: Returneaza contributiile pentru angajator.
		/// </summary>
		/// <param name="angajatorID">Id-ul angajatorului</param>
		/// <param name="lunaID">Id-ul lunii</param>
		/// <returns>Returneaza un DataSet care contine aceste date</returns>
		public DataSet GetContributiiUnitateAngajator(int angajatorID, int lunaID)
		{
			Data.Salarii sal = new Salaries.Data.Salarii(settings.ConnectionString);
			return sal.GetContributiiUnitateAngajator(angajatorID, lunaID);
		}
		#endregion

		#region GetBazeCalculAngajatiTotal
		/// <summary>
		/// Autor: Lungu Andreea
		/// Data: 18.02.2011
		/// Descriere: Returneaza bazele de calcul pentru angajator.
		/// </summary>
		/// <param name="angajatorID">Id-ul angajatorului</param>
		/// <param name="lunaID">Id-ul lunii</param>
		/// <returns>Returneaza un DataSet care contine aceste date</returns>
		public DataSet GetBazeCalculAngajatiTotal(int angajatorID, int lunaID)
		{
			Data.Salarii sal = new Salaries.Data.Salarii(settings.ConnectionString);
			return sal.GetBazeCalculAngajatiTotal(angajatorID, lunaID);
		}
		#endregion

		#region GetContributiiAngajatiTotal
		/// <summary>
		/// Autor: Lungu Andreea
		/// Data: 18.02.2011
		/// Descriere: Returneaza contributiile pentru angajator.
		/// </summary>
		/// <param name="angajatorID">Id-ul angajatorului</param>
		/// <param name="lunaID">Id-ul lunii</param>
		/// <returns>Returneaza un DataSet care contine aceste date</returns>
		public DataSet GetContributiiAngajatiTotal(int angajatorID, int lunaID)
		{
			Data.Salarii sal = new Salaries.Data.Salarii(settings.ConnectionString);
			return sal.GetContributiiAngajatiTotal(angajatorID, lunaID);
		}
		#endregion

		#region GetPuncteDeLucruTotal
		/// <summary>
		/// Autor: Lungu Andreea
		/// Data: 18.02.2011
		/// Descriere: Returneaza suma pt vb, suma cb firma, suma cb bass pe puncte de lucru
		/// </summary>
		/// <param name="angajatorID">Id-ul angajatorului</param>
		/// <param name="lunaID">Id-ul lunii</param>
		/// <returns>Returneaza un DataSet care contine aceste date</returns>
		public DataSet GetPuncteDeLucruTotal(int angajatorID, int lunaID)
		{
			Data.Salarii sal = new Salaries.Data.Salarii(settings.ConnectionString);
			return sal.GetPuncteDeLucruTotal(angajatorID, lunaID);
		}
		#endregion

		#region GetFNUASS
		/// <summary>
		/// Autor: Lungu Andreea
		/// Data: 18.02.2011
		/// Descriere: Returneaza suma FNUASS
		/// </summary>
		/// <param name="angajatorID">Id-ul angajatorului</param>
		/// <param name="lunaID">Id-ul lunii</param>
		/// <param name="punctLucruId">Id-ul punctului de lucru - poate fi si -1 - si atinci se iau toate punctele de lucru</param>
		/// <param name="modIncadrare">modul de incadrare - poate fi si -1 - si atinci se iau toate modurile de incadrare</param>
		/// <returns>Returneaza un DataSet care contine aceste date</returns>
		public DataSet GetFNUASS(int angajatorID, int lunaID, int punctLucruId, int modIncadrare)
		{
			Data.Salarii sal = new Salaries.Data.Salarii(settings.ConnectionString);
			return sal.GetFNUASS(angajatorID, lunaID, punctLucruId, modIncadrare);
		}
		#endregion

		#region GetDiverseSume
		/// <summary>
		/// Autor: Lungu Andreea
		/// Data: 18.02.2011
		/// Descriere: Returneaza diverse sume pentru angajator
		/// </summary>
		/// <param name="angajatorID">Id-ul angajatorului</param>
		/// <param name="lunaID">Id-ul lunii</param>
		/// <returns>Returneaza un DataSet care contine aceste date</returns>
		public DataSet GetDiverseSume(int angajatorID, int lunaID)
		{
			Data.Salarii sal = new Salaries.Data.Salarii(settings.ConnectionString);
			return sal.GetDiverseSume(angajatorID, lunaID);
		}
		#endregion

		#region GetIndicatoriIndemnizatieSanatate
		/// <summary>
		/// Autor: Lungu Andreea
		/// Data: 18.02.2011
		/// Descriere: Returneaza indicatorii pentru indemnizatia de sanatate pentru angajator
		/// </summary>
		/// <param name="angajatorID">Id-ul angajatorului</param>
		/// <param name="lunaID">Id-ul lunii</param>
		/// <returns>Returneaza un DataSet care contine aceste date</returns>
		public DataSet GetIndicatoriIndemnizatieSanatate(int angajatorID, int lunaID)
		{
			Data.Salarii sal = new Salaries.Data.Salarii(settings.ConnectionString);
			return sal.GetIndicatoriIndemnizatieSanatate(angajatorID, lunaID);
		}
		#endregion

		#region GetSumePunctLucru
		/// <summary>
		/// Autor: Lungu Andreea
		/// Data: 21.02.2011
		/// Descriere: Returneaza diverse sume pentru angajator pe puncte de lucru
		/// </summary>
		/// <param name="angajatorID">Id-ul angajatorului</param>
		/// <param name="lunaID">Id-ul lunii</param>
		/// <returns>Returneaza un DataSet care contine aceste date</returns>
		public DataSet GetSumePunctLucru(int angajatorID, int lunaID)
		{
			Data.Salarii sal = new Salaries.Data.Salarii(settings.ConnectionString);
			return sal.GetSumePunctLucru(angajatorID, lunaID);
		}
		#endregion

		#region GetDateAsigurati
		/// <summary>
		/// Autor: Lungu Andreea
		/// Data: 21.02.2011
		/// Descriere: Returneaza date despre angajati
		/// </summary>
		/// <param name="angajatorID">Id-ul angajatorului</param>
		/// <param name="lunaID">Id-ul lunii</param>
		/// <returns>Returneaza un DataSet care contine aceste date</returns>
		public DataSet GetDateAsigurati(int angajatorID, int lunaID)
		{
			Data.Salarii sal = new Salaries.Data.Salarii(settings.ConnectionString);
			return sal.GetDateAsigurati(angajatorID, lunaID);
		}
		#endregion

		#region GetDateCoasigurati
		/// <summary>
		/// Autor: Lungu Andreea
		/// Data: 21.02.2011
		/// Descriere: Returneaza datele despre coasiguratii unui angajat
		/// </summary>
		/// <param name="angajatorID">Id-ul angajatorului</param>
		/// <param name="lunaID">Id-ul lunii</param>
		/// <returns>Returneaza un DataSet care contine aceste date</returns>
		public DataSet GetDateCoasigurati(int angajatorID, int lunaID)
		{
			Data.Salarii sal = new Salaries.Data.Salarii(settings.ConnectionString);
			return sal.GetDateCoasigurati(angajatorID, lunaID);
		}
		#endregion

		#region GetConcediiMedicale
		/// <summary>
		/// Autor: Lungu Andreea
		/// Data: 21.02.2011
		/// Descriere: Returneaza datele despre concediile medicale ale angajatilor.
		/// </summary>
		/// <param name="angajatorID">Id-ul angajatorului</param>
		/// <param name="lunaID">Id-ul lunii</param>
		/// <returns>Returneaza un DataSet care contine aceste date</returns>
		public DataSet GetConcediiMedicale(int angajatorID, int lunaID)
		{
			Data.Salarii sal = new Salaries.Data.Salarii(settings.ConnectionString);
			return sal.GetConcediiMedicale(angajatorID, lunaID);
		}
		#endregion

		#region GetPersoaneInIntretinere
		/// <summary>
		/// Procedura selecteaza persoanele in intretinere ale unui angajat
		/// </summary>
		/// <param name="angajatId">Id-ul angajatului</param>
		/// <returns>Returneaza un DataSet care contine datele selectate</returns>
		public DataSet GetPersoaneInIntretinere(long angajatId)
		{
			Data.Salarii sal = new Salaries.Data.Salarii(settings.ConnectionString);
			return sal.GetPersoaneInIntretinere(angajatId);
		}
		#endregion
	}
}

