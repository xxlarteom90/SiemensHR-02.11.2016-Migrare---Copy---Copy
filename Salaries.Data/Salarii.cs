/*
 * Autor: Cristina Muntean
 * Data:  16.03.2005
 * Obs:   clasa a fost rescrisa in intregime, vechile metode ale clasei sunt comentate
 */
using System;
using System.Data;
using System.Data.SqlClient;

namespace Salaries.Data
{

	public class DetaliiSalarii
	{
		// intrari
		public int ID;
		public long AngajatID;
		public int LunaID;
	
		//iesiri
		public decimal SalariuIncadrare;
		public decimal IndemnizatieConducere;
		public decimal Prime;
		public decimal AlteDrepturi;
		public decimal IndemnizatieConcediuMedical;
		public decimal VenitBrut;
		public decimal DeduceriPersonale;
		public decimal BazaImpozitare;
		public decimal Impozit;
		public decimal VenitNet;
		public decimal SalariuNet;
		public decimal Avans;
		public decimal Retineri;
		public decimal TotalRetineri;
		public decimal RestDePlata;
		public decimal SalariuIncadrareRealizat;
		public decimal IndemnizatieConducereRealizata;
		public decimal DrepturiBanestiConcediuOdihna;
		public decimal DrepturiBanestiConcediuEvDeosebite;
		public decimal DrepturiBanestiOreSuplimentare;
		public decimal SumaConcediuBoalaFirma;
		public decimal SumaConcediuBoalaBASS;
		public decimal AjutorDeces;
		public decimal Regularizare;
	}
	/// <summary>
	/// Summary description for Salarii.
	/// </summary>
	public class Salarii : Salaries.Data.DbObject
	{

		#region Constructor
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="connectionString">String-ul de conexiune</param>
		public Salarii(string connectionString): base (connectionString)
		{}
		#endregion
		
		#region GetDetalii
		/// <summary>
		/// Returneaza detaliile pentru o inregistrare din tabela
		/// </summary>
		/// <param name="id">Id-ul inregistrarii</param>
		/// <returns>Returneaza un obiect care contine aceste date</returns>
		public DetaliiSalarii GetDetalii(int id)
		{
			SqlParameter[] parameters = 
				{
					new SqlParameter("@ID", SqlDbType.Int, 4)
				};
			parameters[0].Value = id;
			using (DataSet detaliiDS = RunProcedure("spGetStatDePlataInfo", parameters, "SalariuAngajat"))
			{
				DetaliiSalarii detalii = new DetaliiSalarii();
				if (detaliiDS.Tables[0].Rows.Count > 0)
				{
					DataRow rowDetalii = detaliiDS.Tables[0].Rows[0];
					detalii.ID = (int)rowDetalii["ID"];
					detalii.AngajatID = long.Parse(rowDetalii["AngajatID"].ToString());
					detalii.LunaID = (int) rowDetalii["LunaID"];
					detalii.Prime = (decimal)rowDetalii["Prime"];
					detalii.AlteDrepturi = (decimal) rowDetalii["AlteDrepturi"];
					detalii.IndemnizatieConcediuMedical = (decimal)rowDetalii["IndemnizatieConcediuMedical"];
					detalii.SalariuIncadrare = (decimal)rowDetalii["SalariuBaza"];
					detalii.IndemnizatieConducere = (decimal)rowDetalii["IndemnizatieConducere"];
					detalii.VenitBrut = (decimal) rowDetalii["VenitBrut"];
					detalii.VenitNet = (decimal) rowDetalii["VenitNet"];
					detalii.DeduceriPersonale = (decimal) rowDetalii["DeduceriPersonale"];
					detalii.BazaImpozitare = (decimal)rowDetalii["BazaImpozitare"];
					detalii.Impozit = (decimal) rowDetalii["Impozit"];
					detalii.SalariuNet = (decimal) rowDetalii["SalariuNet"];
					detalii.Avans = (decimal) rowDetalii["Avans"];
					detalii.Retineri = (decimal) rowDetalii["Retineri"];
					detalii.TotalRetineri = (decimal) rowDetalii["TotalRetineri"];
					detalii.RestDePlata = (decimal) rowDetalii["RestDePlata"];	
					detalii.SalariuIncadrareRealizat = (decimal) rowDetalii["SalariuIncadrareRealizat"];
					detalii.IndemnizatieConducereRealizata = (decimal) rowDetalii["IndemnizatieConducereRealizata"];
					detalii.DrepturiBanestiConcediuOdihna = (decimal) rowDetalii["DrepturiBanestiConcediuOdihna"];
					detalii.DrepturiBanestiConcediuEvDeosebite = (decimal) rowDetalii["DrepturiBanestiConcediuEvDeosebite"];
					detalii.DrepturiBanestiOreSuplimentare = (decimal) rowDetalii["DrepturiBanestiOreSuplimentare"];
					detalii.SumaConcediuBoalaFirma = (decimal) rowDetalii["SumaConcediuBoalaFirma"];
					detalii.SumaConcediuBoalaBASS = (decimal) rowDetalii["SumaConcediuBoalaBASS"];
					detalii.Regularizare = (decimal)rowDetalii["SumaConcediuBoalaBASS"];
				}
				else
					detalii.ID = -1;
				
				return detalii;
			}
		}
		#endregion
		
		#region Add
		/// <summary>
		/// Procedura adauga o inregistrare in tabela sal_StatDePlata
		/// </summary>
		/// <returns>Returneaza nr de inregistrari afectate de adaugare</returns>
		public int Add
			(long angajatId,
			 int lunaId,
			 decimal prime,
			 decimal alteDrepturi,
			 decimal indemnizatieConcediuMedical,
			 decimal venitBrut,
			 decimal venitNet,
			 decimal deduceriPersonale,
			 decimal bazaImpozitare,
			 decimal impozit, 
			 decimal salariuNet, 
			 decimal avans, 
			 decimal retineri,
			 decimal totalRetineri,
			 decimal restDePlata,
			 decimal salariuIncadrareRealizat,
		     decimal indemnizatieConducereRealizata,
			 decimal drepturiBanestiConcediuOdihna,
			 decimal drepturiBanestiConcediuEvDeosebite,
			 decimal drepturiBanestiOreSuplimentare,
			 decimal sumaConcediuBoalaFirma,
			 decimal sumaConcediuBoalaBASS,
			 decimal ajutorDeces,
			 decimal regularizare
			)
		{
			int numAffected;
			SqlParameter[] parameters = 
				{
					new SqlParameter("@AngajatID", SqlDbType.Int, 4),
					new SqlParameter("@LunaID", SqlDbType.Int, 4),
					new SqlParameter("@Prime", SqlDbType.Money, 8),
					new SqlParameter("@AlteDrepturi", SqlDbType.Money, 8),
					new SqlParameter("@IndemnizatieConcediuMedical", SqlDbType.Money, 8),
					new SqlParameter("@VenitBrut", SqlDbType.Money, 8),
					new SqlParameter("@VenitNet", SqlDbType.Money, 8),
					new SqlParameter("@DeduceriPersonale", SqlDbType.Money, 8),
					new SqlParameter("@BazaImpozitare", SqlDbType.Money, 8),
					new SqlParameter("@Impozit", SqlDbType.Money, 8),
					new SqlParameter("@SalariuNet", SqlDbType.Money, 8),
					new SqlParameter("@Avans", SqlDbType.Money, 8),
				    new SqlParameter("@Retineri", SqlDbType.Money, 8),
					new SqlParameter("@TotalRetineri", SqlDbType.Money, 8),
					new SqlParameter("@RestDePlata", SqlDbType.Money, 8),
					new SqlParameter("@SalariuIncadrareRealizat", SqlDbType.Money, 8),
					new SqlParameter("@IndemnizatieConducereRealizata", SqlDbType.Money, 8),
					new SqlParameter("@DrepturiBanestiConcediuOdihna", SqlDbType.Money, 8),
					new SqlParameter("@DrepturiBanestiConcediuEvDeosebite", SqlDbType.Money, 8),
					new SqlParameter("@DrepturiBanestiOreSuplimentare", SqlDbType.Money, 8),
					new SqlParameter("@SumaConcediuBoalaFirma", SqlDbType.Money, 8),
					new SqlParameter("@SumaConcediuBoalaBASS", SqlDbType.Money, 8),
					new SqlParameter("@AjutorDeces", SqlDbType.Money, 8),
					new SqlParameter("@Regularizare", SqlDbType.Money, 8),
					new SqlParameter("@ID", SqlDbType.Int, 4)
				};

			parameters[0].Value = angajatId;
			parameters[1].Value = lunaId;
			parameters[2].Value = prime;
			parameters[3].Value = alteDrepturi;
			parameters[4].Value = indemnizatieConcediuMedical;
			parameters[5].Value = venitBrut;
			parameters[6].Value = venitNet;
			parameters[7].Value = deduceriPersonale;
			parameters[8].Value = bazaImpozitare;
			parameters[9].Value = impozit;
			parameters[10].Value = salariuNet;
			parameters[11].Value = avans;
			parameters[12].Value = retineri;
			parameters[13].Value = totalRetineri;
			parameters[14].Value = restDePlata;
			parameters[15].Value = salariuIncadrareRealizat;
			parameters[16].Value = indemnizatieConducereRealizata;
			parameters[17].Value = drepturiBanestiConcediuOdihna;
			parameters[18].Value = drepturiBanestiConcediuEvDeosebite;
			parameters[19].Value = drepturiBanestiOreSuplimentare;
			parameters[20].Value = sumaConcediuBoalaFirma;
			parameters[21].Value = sumaConcediuBoalaBASS;
			parameters[22].Value = ajutorDeces;
			parameters[23].Value = regularizare;
			
			parameters[24].Direction = ParameterDirection.Output;

			RunProcedure("spInsertStatDePlata", parameters, out numAffected);

			return (int)parameters[24].Value;
		}
		#endregion

		#region Delete
		/// <summary>
		/// Procedura sterge o inregistrare din tabela sal_StatDePlata
		/// </summary>
		/// <param name="Id">Id-ul inregistrarii</param>
		/// <returns>Returneaza true daca s-a facut stergerea si false altfel</returns>
		public bool Delete (int Id)
		{
			int numAffected;
		
			SqlParameter[] parameters = { new SqlParameter("@ID", SqlDbType.Int, 4) };
			parameters[0].Value = Id;
			
			RunProcedure("spDeleteStatDePlata", parameters, out numAffected);
			return (numAffected == 1);
		}
		#endregion

		#region Update
		/// <summary>
		/// Procedura face update tabelei sal_StatDePlata
		/// </summary>
		/// <returns>Returneaza true daca s-a facut actualizarea si false altfel</returns>
		public bool Update
			(int id,
			 long angajatId,
			 int lunaId,
			 decimal prime,
			 decimal alteDrepturi,
			 decimal indemnizatieConcediuMedical,
			 decimal venitBrut,
			 decimal venitNet,
			 decimal deduceriPersonale,
			 decimal bazaImpozitare,
			 decimal impozit, 
			 decimal salariuNet, 
			 decimal avans, 
			 decimal retineri,
			 decimal totalRetineri,
			 decimal restDePlata,
			 decimal salariuIncadrareRealizat,
			 decimal indemnizatieConducereRealizata,
			 decimal drepturiBanestiConcediuOdihna,
			 decimal drepturiBanestiConcediuEvDeosebite,
			 decimal drepturiBanestiOreSuplimentare,
			 decimal sumaConcediuBoalaFirma,
			 decimal sumaConcediuBoalaBASS,
			 decimal ajutorDeces,
			 decimal regularizare
			)
		{
			int numAffected;
		
			SqlParameter[] parameters = 
			{
				new SqlParameter("@ID", SqlDbType.Int, 4),
				new SqlParameter("@AngajatID", SqlDbType.Int, 4),
				new SqlParameter("@LunaID", SqlDbType.Int, 4),
				new SqlParameter("@Prime", SqlDbType.Money, 8),
				new SqlParameter("@AlteDrepturi", SqlDbType.Money, 8),
				new SqlParameter("@IndemnizatieConcediuMedical", SqlDbType.Money, 8),
				new SqlParameter("@VenitBrut", SqlDbType.Money, 8),
				new SqlParameter("@VenitNet", SqlDbType.Money, 8),
				new SqlParameter("@DeduceriPersonale", SqlDbType.Money, 8),
				new SqlParameter("@BazaImpozitare", SqlDbType.Money, 8),
				new SqlParameter("@Impozit", SqlDbType.Money, 8),
				new SqlParameter("@SalariuNet", SqlDbType.Money, 8),
				new SqlParameter("@Avans", SqlDbType.Money, 8),
				new SqlParameter("@Retineri", SqlDbType.Money, 8),
				new SqlParameter("@TotalRetineri", SqlDbType.Money, 8),
				new SqlParameter("@RestDePlata", SqlDbType.Money, 8),
				new SqlParameter("@SalariuIncadrareRealizat", SqlDbType.Money, 8),
				new SqlParameter("@IndemnizatieConducereRealizata", SqlDbType.Money, 8),
				new SqlParameter("@DrepturiBanestiConcediuOdihna", SqlDbType.Money, 8),
				new SqlParameter("@DrepturiBanestiConcediuEvDeosebite", SqlDbType.Money, 8),
				new SqlParameter("@DrepturiBanestiOreSuplimentare", SqlDbType.Money, 8),
				new SqlParameter("@SumaConcediuBoalaFirma", SqlDbType.Money, 8),
				new SqlParameter("@SumaConcediuBoalaBASS", SqlDbType.Money, 8),
				new SqlParameter("@AjutorDeces", SqlDbType.Money, 8),
				new SqlParameter("@Regularizare", SqlDbType.Money, 8)
			};
			
			parameters[0].Value = id;
			parameters[1].Value = angajatId;
			parameters[2].Value = lunaId;
			parameters[3].Value = prime;
			parameters[4].Value = alteDrepturi;
			parameters[5].Value = indemnizatieConcediuMedical;
			parameters[6].Value = venitBrut;
			parameters[7].Value = venitNet;
			parameters[8].Value = deduceriPersonale;
			parameters[9].Value = bazaImpozitare;
			parameters[10].Value = impozit;
			parameters[11].Value = salariuNet;
			parameters[12].Value = avans;
			parameters[13].Value = retineri;
			parameters[14].Value = totalRetineri;
			parameters[15].Value = restDePlata;
			parameters[16].Value = salariuIncadrareRealizat;
			parameters[17].Value = indemnizatieConducereRealizata;
			parameters[18].Value = drepturiBanestiConcediuOdihna;
			parameters[19].Value = drepturiBanestiConcediuEvDeosebite;
			parameters[20].Value = drepturiBanestiOreSuplimentare;
			parameters[21].Value = sumaConcediuBoalaFirma;
			parameters[22].Value = sumaConcediuBoalaBASS;
			parameters[23].Value = ajutorDeces;
			parameters[24].Value = regularizare;
		
			//run stored procedure
			RunProcedure("spUpdateStatDePlata",parameters,out numAffected);

			return (numAffected == 1);
		}
		#endregion

		#region StatDePlata
		/// <summary>
		/// Procedura returneaza un DataSet cu toate datele legate de statul de plata pentru angajatorul trimis ca parametru pe luna cu id-ul trimis ca parametru
		/// </summary>
		/// <param name="AngajatorId">Id-ul angajatorului</param>
		/// <param name="LunaId">Id-ul lunii</param>
		/// <returns>Returneaza un DataSet care contine aceste date</returns>
		public DataSet StatPlata(int AngajatorId,int LunaId)
		{	
			SqlParameter[] parameters = {		
											new SqlParameter("@AngajatorID", SqlDbType.Int, 4),
											new SqlParameter("@LunaID", SqlDbType.Int, 4)
										};
			parameters[0].Value = AngajatorId;
			parameters[1].Value = LunaId;
			DataSet detaliiStatPlata = RunProcedure("spGetStatDePlata", parameters, "StatDePlata");
			
			return detaliiStatPlata;	
		}
		#endregion

		#region CalculSalariiIndexate
		/// <summary>
		/// Returneaza valorile salariilor indexate ale angajatilor
		/// </summary>
		/// <param name="angajatorId">Id-ul angajatorului</param>
		/// <returns>Returneaza un DataSet care contine aceste date</returns>
		/// <remarks>
		/// Autor: Cristina Raluca Muntean
		/// Data: 28.12.2005
		/// </remarks>
		public DataSet CalculSalariiIndexate(int angajatorId)
		{
			SqlParameter[] parameters = {
											new SqlParameter("@AngajatorID", SqlDbType.Int, 4)
										};
			parameters[0].Value = angajatorId;
			using(DataSet salariiIndexate = RunProcedure("spCalculSalariiIndexate", parameters , "SalariiIndexate"))
			{				
				return salariiIndexate;
			}	
		}
		#endregion
		
		#region CalculProcentIndexareAngajat
		/// <summary>
		/// Este calculat procentul cu care a fost(urmeaza sa fie) indexat salariul angajatului.
		/// </summary>
		/// <param name="angajatID"> ID-ul angajatului</param>
		/// <returns> Procentul cu care a fost(urmeaza sa fie) indexat salariul angajatului</returns>
		/// <remarks>
		/// Autor: Cristina Raluca Muntean
		/// Data:  5.05.2006
		/// </remarks>
		public float CalculProcentIndexareAngajat(long angajatId)
		{
			// Procentul de indexare.
			float procentIndexare = 0;

			// Sunt setati parametrii procedurii stocate.
			SqlParameter[] parameters = {
											new SqlParameter("@angajatID", SqlDbType.Int, 4)
											,new SqlParameter("@procentIndexareAngajat", SqlDbType.Float)
										};

			// ID-ul angajatului
			parameters[0].Value = angajatId;
			// Procentul de indexare 
			parameters[1].Direction = ParameterDirection.Output;
		
			RunProcedure("spProcentIndexareAngajat", parameters);

			procentIndexare = float.Parse(parameters[1].Value.ToString());

			return procentIndexare;
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
		public float CalculVenitBrutIndexat(long angajatId)
		{
			// Venitul brut al angajatului dupa indexare..
			float venitBrutIndexat = 0;

			// Sunt setati parametrii procedurii stocate.
			SqlParameter[] parameters = {
											new SqlParameter("@angajatID", SqlDbType.Int, 4)
											,new SqlParameter("@venitBrutIndexat", SqlDbType.Float, 8)
										};

			// ID-ul angajatului
			parameters[0].Value = angajatId;
			// Procentul de indexare 
			parameters[1].Direction = ParameterDirection.Output;
		
			RunProcedure("spCalculSalariuIndexatAngajat", parameters);

			venitBrutIndexat = float.Parse(parameters[1].Value.ToString());

			return venitBrutIndexat;
		}
		#endregion

		#region GetCodareStatDePlata
		/// <summary>
		/// Procedura returneaza codarea statului de plata
		/// </summary>
		/// <returns>Returneaza un DataSet care contine aceste date</returns>
		public DataSet GetCodareStatDePlata()
		{	
			SqlParameter[] parameters = {};
			return RunProcedure("spGetCodareStatDePlata", parameters, "GetCodareStatDePlata");
		}
		#endregion

		#region GetCodareColoaneStatDePlata
		/// <summary>
		/// Procedura returneaza codarea unei coloane a statului de plata
		/// </summary>
		/// <returns>Returneaza un DataSet care contine aceste date</returns>
		public DataSet GetCodareColoaneStatDePlata()
		{	
			SqlParameter[] parameters = {};
			return RunProcedure("spGetCodareColoaneStatDePlata", parameters, "GetCodareColoaneStatDePlata");
		}
		#endregion

		#region UpdateTemplate
		/// <summary>
		/// Procedura actualizeaza datele despre coloanele afisate pe statul de plata
		/// </summary>
		/// <param name="template">String-ul contine coloanele care se vor afisa pe statul de plata</param>
		public void UpdateTemplate(string template)
		{
			SqlParameter[] parameters = {
											new SqlParameter("@newTemplate", SqlDbType.NVarChar, 100)
										};
			parameters[0].Value = template;		
			RunProcedure("UpdateTemplate", parameters);
		}
		#endregion

		#region VerifyCalculSalarial
		//verifica daca pentru luna activa a fost sau nu facut calculul salarial
		public bool VerifyCalculSalarial(int angajatorID)
		{
			bool calcul ;
			// Sunt setati parametrii procedurii stocate.
			SqlParameter[] parameters = {
											new SqlParameter("@angajatorID", SqlDbType.Int, 4)
											,new SqlParameter("@calcul", SqlDbType.Bit)
										};

			// ID-ul angajatorului
			parameters[0].Value = angajatorID;
			// var booleana ce imi spune daca a fost sau nu facut calculu salarial
			parameters[1].Direction = ParameterDirection.Output;
			RunProcedure("VerifyCalculSalarial", parameters);
			calcul = (bool)parameters[1].Value;
			return calcul;
		}
		#endregion

		//------------------------pentru declaratie unica-------------------------------------
		#region CalculCreante
		/// <summary>
		/// Calculeaza valorile creantelor fiscale pentru angajator.
		/// </summary>
		/// <param name="angajatorId">Id-ul angajatorului</param>
		/// <param name="lunaId">Id-ul lunii</param>
		/// <remarks>
		/// Autor: Lungu Andreea
		/// Data: 18.02.2011
		/// </remarks>
		public void CalculCreante(int angajatorId, int lunaId)
		{
			SqlParameter[] parameters = {
											new SqlParameter("@AngajatorID", SqlDbType.Int, 4),
											new SqlParameter("@LunaID", SqlDbType.Int, 4)
										};
			parameters[0].Value = angajatorId;
			parameters[1].Value = lunaId;
			RunProcedure("spCalculCreante", parameters , "spCalculCreante");
		}
		#endregion

		#region GetCreante
		/// <summary>
		/// Returneaza valorile creantelor pentru angajator.
		/// </summary>
		/// <param name="angajatorId">Id-ul angajatorului</param>
		/// <param name="lunaId">Id-ul lunii</param>
		/// <returns>Returneaza un DataSet care contine aceste date</returns>
		/// <remarks>
		/// Autor: Lungu Andreea
		/// Data: 18.02.2011
		/// </remarks>
		public DataSet GetCreante(int angajatorId, int lunaId)
		{
			SqlParameter[] parameters = {
											new SqlParameter("@AngajatorID", SqlDbType.Int, 4),
											new SqlParameter("@LunaID", SqlDbType.Int, 4)
										};
			parameters[0].Value = angajatorId;
			parameters[1].Value = lunaId;
			using(DataSet creante = RunProcedure("spGetCreante", parameters , "spGetCreante"))
			{				
				return creante;
			}	
		}
		#endregion

		#region CalculNumarAsigurati
		/// <summary>
		/// Returneaza valorile creantelor pentru angajator.
		/// </summary>
		/// <param name="angajatorId">Id-ul angajatorului</param>
		/// <param name="lunaId">Id-ul lunii</param>
		/// <returns>Returneaza un DataSet care contine aceste date</returns>
		/// <remarks>
		/// Autor: Lungu Andreea
		/// Data: 18.02.2011
		/// </remarks>
		public DataSet CalculNumarAsigurati(int angajatorId, int lunaId)
		{
			SqlParameter[] parameters = {
											new SqlParameter("@AngajatorID", SqlDbType.Int, 4),
											new SqlParameter("@LunaID", SqlDbType.Int, 4)
										};
			parameters[0].Value = angajatorId;
			parameters[1].Value = lunaId;
			return RunProcedure("spCalculNumarAsigurati", parameters , "spCalculNumarAsigurati");
		}
		#endregion

		#region GetBazeCalculAngajator
		/// <summary>
		/// Returneaza bazele de calcul pentru angajator.
		/// </summary>
		/// <param name="angajatorId">Id-ul angajatorului</param>
		/// <param name="lunaId">Id-ul lunii</param>
		/// <returns>Returneaza un DataSet care contine aceste date</returns>
		/// <remarks>
		/// Autor: Lungu Andreea
		/// Data: 18.02.2011
		/// </remarks>
		public DataSet GetBazeCalculAngajator(int angajatorId, int lunaId)
		{
			SqlParameter[] parameters = {
											new SqlParameter("@AngajatorID", SqlDbType.Int, 4),
											new SqlParameter("@LunaID", SqlDbType.Int, 4)
										};
			parameters[0].Value = angajatorId;
			parameters[1].Value = lunaId;
			return RunProcedure("dbo.Rapoarte_GetBazeCalculAngajator", parameters , "dbo.Rapoarte_GetBazeCalculAngajator");
		}
		#endregion

		#region GetContributiiUnitateAngajator
		/// <summary>
		/// Returneaza contributiile pentru angajator.
		/// </summary>
		/// <param name="angajatorId">Id-ul angajatorului</param>
		/// <param name="lunaId">Id-ul lunii</param>
		/// <returns>Returneaza un DataSet care contine aceste date</returns>
		/// <remarks>
		/// Autor: Lungu Andreea
		/// Data: 18.02.2011
		/// </remarks>
		public DataSet GetContributiiUnitateAngajator(int angajatorId, int lunaId)
		{
			SqlParameter[] parameters = {
											new SqlParameter("@AngajatorID", SqlDbType.Int, 4),
											new SqlParameter("@LunaID", SqlDbType.Int, 4)
										};
			parameters[0].Value = angajatorId;
			parameters[1].Value = lunaId;
			return RunProcedure("dbo.Rapoarte_GetContributiiUnitateAngajator", parameters , "dbo.Rapoarte_GetContributiiUnitateAngajator");
		}
		#endregion

		#region GetBazeCalculAngajatiTotal
		/// <summary>
		/// Returneaza bazele de calcul pentru angajator.
		/// </summary>
		/// <param name="angajatorId">Id-ul angajatorului</param>
		/// <param name="lunaId">Id-ul lunii</param>
		/// <returns>Returneaza un DataSet care contine aceste date</returns>
		/// <remarks>
		/// Autor: Lungu Andreea
		/// Data: 18.02.2011
		/// </remarks>
		public DataSet GetBazeCalculAngajatiTotal(int angajatorId, int lunaId)
		{
			SqlParameter[] parameters = {
											new SqlParameter("@AngajatorID", SqlDbType.Int, 4),
											new SqlParameter("@LunaID", SqlDbType.Int, 4)
										};
			parameters[0].Value = angajatorId;
			parameters[1].Value = lunaId;
			return RunProcedure("dbo.Rapoarte_GetBazeCalculAngajatiTotal", parameters , "dbo.Rapoarte_GetBazeCalculAngajatiTotal");
		}
		#endregion

		#region GetContributiiAngajatiTotal
		/// <summary>
		/// Returneaza contributiile pentru angajator.
		/// </summary>
		/// <param name="angajatorId">Id-ul angajatorului</param>
		/// <param name="lunaId">Id-ul lunii</param>
		/// <returns>Returneaza un DataSet care contine aceste date</returns>
		/// <remarks>
		/// Autor: Lungu Andreea
		/// Data: 18.02.2011
		/// </remarks>
		public DataSet GetContributiiAngajatiTotal(int angajatorId, int lunaId)
		{
			SqlParameter[] parameters = {
											new SqlParameter("@AngajatorID", SqlDbType.Int, 4),
											new SqlParameter("@LunaID", SqlDbType.Int, 4)
										};
			parameters[0].Value = angajatorId;
			parameters[1].Value = lunaId;
			return RunProcedure("dbo.Rapoarte_GetContributiiAngajatiTotal", parameters , "dbo.Rapoarte_GetContributiiAngajatiTotal");
		}
		#endregion

		#region GetPuncteDeLucruTotal
		/// <summary>
		/// Returneaza total vb, suma cb cas, suma cb firma pe puncte de lucru.
		/// </summary>
		/// <param name="angajatorId">Id-ul angajatorului</param>
		/// <param name="lunaId">Id-ul lunii</param>
		/// <returns>Returneaza un DataSet care contine aceste date</returns>
		/// <remarks>
		/// Autor: Lungu Andreea
		/// Data: 18.02.2011
		/// </remarks>
		public DataSet GetPuncteDeLucruTotal(int angajatorId, int lunaId)
		{
			SqlParameter[] parameters = {
											new SqlParameter("@AngajatorID", SqlDbType.Int, 4),
											new SqlParameter("@LunaID", SqlDbType.Int, 4)
										};
			parameters[0].Value = angajatorId;
			parameters[1].Value = lunaId;
			return RunProcedure("dbo.Rapoarte_GetPuncteDeLucruTotal", parameters , "dbo.Rapoarte_GetPuncteDeLucruTotal");
		}
		#endregion

		#region GetFNUASS
		/// <summary>
		/// Returneaza suma fnuass.
		/// </summary>
		/// <param name="angajatorId">Id-ul angajatorului</param>
		/// <param name="lunaId">Id-ul lunii</param>
		/// <param name="punctLucruId">Id-ul punctului de lucru - poate fi si -1 - si atinci se iau toate punctele de lucru</param>
		/// <param name="modIncadrare">modul de incadrare - poate fi si -1 - si atinci se iau toate modurile de incadrare</param>
		/// <returns>Returneaza un DataSet care contine aceste date</returns>
		/// <remarks>
		/// Autor: Lungu Andreea
		/// Data: 18.02.2011
		/// </remarks>
		public DataSet GetFNUASS(int angajatorId, int lunaId, int punctLucruId, int modIncadrare)
		{
			SqlParameter[] parameters = {
											new SqlParameter("@AngajatorID", SqlDbType.Int, 4),
											new SqlParameter("@LunaID", SqlDbType.Int, 4),
											new SqlParameter("@PunctLucruID", SqlDbType.Int, 4),
											new SqlParameter("@ModIncadrare", SqlDbType.Int, 4)
										};
			parameters[0].Value = angajatorId;
			parameters[1].Value = lunaId;
			parameters[2].Value = punctLucruId;
			parameters[3].Value = modIncadrare;
			return RunProcedure("dbo.spCalculBazaCalculFNUASSRapoarte", parameters , "dbo.spCalculBazaCalculFNUASSRapoarte");
		}
		#endregion

		#region GetDiverseSume
		/// <summary>
		/// Returneaza diverse sume pentru angajator.
		/// </summary>
		/// <param name="angajatorId">Id-ul angajatorului</param>
		/// <param name="lunaId">Id-ul lunii</param>
		/// <returns>Returneaza un DataSet care contine aceste date</returns>
		/// <remarks>
		/// Autor: Lungu Andreea
		/// Data: 18.02.2011
		/// </remarks>
		public DataSet GetDiverseSume(int angajatorId, int lunaId)
		{
			SqlParameter[] parameters = {
											new SqlParameter("@AngajatorID", SqlDbType.Int, 4),
											new SqlParameter("@LunaID", SqlDbType.Int, 4)
										};
			parameters[0].Value = angajatorId;
			parameters[1].Value = lunaId;
			return RunProcedure("dbo.Rapoarte_DiverseSume", parameters , "dbo.Rapoarte_DiverseSume");
		}
		#endregion

		#region GetIndicatoriIndemnizatieSanatate
		/// <summary>
		/// Returneaza diverse sume pentru angajator.
		/// </summary>
		/// <param name="angajatorId">Id-ul angajatorului</param>
		/// <param name="lunaId">Id-ul lunii</param>
		/// <returns>Returneaza un DataSet care contine aceste date</returns>
		/// <remarks>
		/// Autor: Lungu Andreea
		/// Data: 18.02.2011
		/// </remarks>
		public DataSet GetIndicatoriIndemnizatieSanatate(int angajatorId, int lunaId)
		{
			SqlParameter[] parameters = {
											new SqlParameter("@AngajatorID", SqlDbType.Int, 4),
											new SqlParameter("@LunaID", SqlDbType.Int, 4)
										};
			parameters[0].Value = angajatorId;
			parameters[1].Value = lunaId;
			return RunProcedure("dbo.Rapoarte_IndicatoriIndemnizatiiSanatate", parameters , "dbo.Rapoarte_IndicatoriIndemnizatiiSanatate");
		}
		#endregion

		#region GetSumePunctLucru
		/// <summary>
		/// Returneaza diverse sume pentru angajator pe puncte de lucru.
		/// </summary>
		/// <param name="angajatorId">Id-ul angajatorului</param>
		/// <param name="lunaId">Id-ul lunii</param>
		/// <returns>Returneaza un DataSet care contine aceste date</returns>
		/// <remarks>
		/// Autor: Lungu Andreea
		/// Data: 21.02.2011
		/// </remarks>
		public DataSet GetSumePunctLucru(int angajatorId, int lunaId)
		{
			SqlParameter[] parameters = {
											new SqlParameter("@AngajatorID", SqlDbType.Int, 4),
											new SqlParameter("@LunaID", SqlDbType.Int, 4)
										};
			parameters[0].Value = angajatorId;
			parameters[1].Value = lunaId;
			return RunProcedure("dbo.Rapoarte_SumePunctLucru", parameters , "dbo.Rapoarte_SumePunctLucru");
		}
		#endregion

		#region GetDateAsigurati
		/// <summary>
		/// Returneaza date despre angajati.
		/// </summary>
		/// <param name="angajatorId">Id-ul angajatorului</param>
		/// <param name="lunaId">Id-ul lunii</param>
		/// <returns>Returneaza un DataSet care contine aceste date</returns>
		/// <remarks>
		/// Autor: Lungu Andreea
		/// Data: 21.02.2011
		/// </remarks>
		public DataSet GetDateAsigurati(int angajatorId, int lunaId)
		{
			SqlParameter[] parameters = {
											new SqlParameter("@AngajatorID", SqlDbType.Int, 4),
											new SqlParameter("@LunaID", SqlDbType.Int, 4)
										};
			parameters[0].Value = angajatorId;
			parameters[1].Value = lunaId;
			return RunProcedure("dbo.Rapoarte_GetDateAsigurati", parameters , "dbo.Rapoarte_GetDateAsigurati");
		}
		#endregion

		#region GetDateCoasigurati
		/// <summary>
		/// Returneaza datele coasiguratilor.
		/// </summary>
		/// <param name="angajatorId">Id-ul angajatorului</param>
		/// <param name="lunaId">Id-ul lunii</param>
		/// <returns>Returneaza un DataSet care contine aceste date</returns>
		/// <remarks>
		/// Autor: Lungu Andreea
		/// Data: 18.02.2011
		/// </remarks>
		public DataSet GetDateCoasigurati(int angajatorId, int lunaId)
		{
			SqlParameter[] parameters = {
											new SqlParameter("@AngajatorID", SqlDbType.Int, 4),
											new SqlParameter("@LunaID", SqlDbType.Int, 4)
										};
			parameters[0].Value = angajatorId;
			parameters[1].Value = lunaId;
			return RunProcedure("dbo.Rapoarte_GetDateCoasigurati", parameters , "dbo.Rapoarte_GetDateCoasigurati");
		}
		#endregion

		#region GetConcediiMedicale
		/// <summary>
		/// Returneaza concediile medicale.
		/// </summary>
		/// <param name="angajatorId">Id-ul angajatorului</param>
		/// <param name="lunaId">Id-ul lunii</param>
		/// <returns>Returneaza un DataSet care contine aceste date</returns>
		/// <remarks>
		/// Autor: Lungu Andreea
		/// Data: 22.02.2011
		/// </remarks>
		public DataSet GetConcediiMedicale(int angajatorId, int lunaId)
		{
			SqlParameter[] parameters = {
											new SqlParameter("@AngajatorID", SqlDbType.Int, 4),
											new SqlParameter("@LunaID", SqlDbType.Int, 4)
										};
			parameters[0].Value = angajatorId;
			parameters[1].Value = lunaId;
			return RunProcedure("dbo.Rapoarte_GetConcediiMedicale", parameters , "dbo.Rapoarte_GetConcediiMedicale");
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
			SqlParameter[] parameters = { new SqlParameter("@AngajatID", SqlDbType.Int,4 ) };
			parameters[0].Value = angajatId;
			
			return RunProcedure("GetAngajatPersoaneInIntretinere", parameters, "AngajatiPersoaneInIntretinere");
		}
		#endregion
	}
}

