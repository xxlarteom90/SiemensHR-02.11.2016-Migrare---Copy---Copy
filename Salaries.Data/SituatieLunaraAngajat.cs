using System;
using System.Data.SqlClient;
using System.Data;

namespace Salaries.Data
{
	/// <summary>
	/// Summary description for SituatieLunaraAngajat.
	/// </summary>
	public struct InfoSituatieLunara
	{
		public int SituatieID;
		public int LunaID;
		public long AngajatID;
		public float NrZileLuna;
		public float NrOreLucrate;
		public float NrOreSup50Proc;
		public float NrOreSup100Proc;

		public float NrOreEvenimDeoseb;
		public float NrOreInvoire;
		public float NrOreConcediuOdihna;
		public float NrZileConcediuOdihnaNeefectuat;
		public float NrZileConcediuOdihnaEfectuatInAvans;
		public float NrOreConcediuBoala;
		public float NrOreConcediuBoalaFirma;
		public float NrOreConcediuBoalaBASS;

		public float NrOreObligatiiCetatenesti;
		public float NrOreAbsenteNemotivate;
		public float NrOreConcediuFaraPlata;

		public float NrOreTotalDelegatieInterna;
		public float NrOreTotalDelegatieExterna;
		public float NrOreLucrateDelegatieInterna;
		public float NrOreLucrateDelegatieExterna;
		public decimal DiurnaImpozabila;

		public float NrOreEmergencyService;

		public decimal SporActivitatiSup;
		public decimal EmergencyService;
		public decimal PrimeSpeciale;
		public decimal AlteDrepturi;
		public decimal AlteDrepturiNet;
		public decimal AjutorDeces;

		public decimal Avans;
		public decimal Retineri1;
		public decimal Retineri2;
		public decimal Retineri3;
		public decimal Retineri4;
		public decimal Retineri5;
		public decimal Retineri6;
		public decimal Retineri7;
		public decimal Regularizare;
		public decimal PrimaProiect;
		public decimal RetinereSanatate;
		public decimal DrepturiInNatura;

		//Lungu Andreea
		public float NrTichete; //drepturi
		public float CorectiiTichete;
		public int NrTotalTichete;

		public int ProgramLucru;
		public float SalariuBaza;
		public float IndemnizatieConducere;
		public int Invaliditate;
		public int CategorieID;
	}

	public class SituatieLunaraAngajat : Salaries.Data.DbObject
	{
		private string conexiune;

		#region Constructor
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="connectionString">String-ul de conexiune</param>
		public SituatieLunaraAngajat(string connectionString): base (connectionString)
		{
			conexiune = connectionString;
		}
		#endregion

		#region getFloat
		/// <summary>
		/// Procedura returneaza valoarea unei coloanei a unei inregistrari
		/// </summary>
		/// <param name="dr">Inregistrarea</param>
		/// <param name="key">Coloana</param>
		/// <returns>Returneaza valoarea campului</returns>
		public float getFloat(DataRow dr,string key)
		{
			return float.Parse(dr[key].ToString());
		}
		#endregion

		#region getDecimal
		/// <summary>
		/// Procedura returneaza valoarea unei coloanei a unei inregistrari
		/// </summary>
		/// <param name="dr">Inregistrarea</param>
		/// <param name="key">Coloana</param>
		/// <returns>Returneaza valoarea campului</returns>
		public decimal getDecimal(DataRow dr,string key)
		{
			return decimal.Parse(dr[key].ToString());
		}
		#endregion

		#region getInt
		/// <summary>
		/// Procedura returneaza valoarea unei coloanei a unei inregistrari
		/// </summary>
		/// <param name="dr">Inregistrarea</param>
		/// <param name="key">Coloana</param>
		/// <returns>Returneaza valoarea campului</returns>
		public int getInt(DataRow dr,string key)
		{
			return int.Parse(dr[key].ToString());
		}
		#endregion

		#region InsertSituatieLunaraAngajat
		/// <summary>
		/// Prcedura adauga o situatie lunara a unui angajat
		/// </summary>
		/// <returns>Returneaza nr de inregistrari afectate</returns>
		public int InsertSituatieLunaraAngajat(
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
			bool ValidareStergere)
		{
			int numAffected;
		
			SqlParameter[] parameters = 
				{
					new SqlParameter("@SituatieID", SqlDbType.Int, 4),
					new SqlParameter("@LunaID", SqlDbType.Int, 4),
					new SqlParameter("@AngajatID", SqlDbType.Int, 4),
					new SqlParameter("@NrZileLuna", SqlDbType.Float, 8),
					new SqlParameter("@NrOreLucrate", SqlDbType.Float, 8),
					new SqlParameter("@NrOreSup50Proc", SqlDbType.Float, 8),
					new SqlParameter("@NrOreSup100Proc", SqlDbType.Float, 8),
					new SqlParameter("@NrOreEvenimDeoseb", SqlDbType.Float, 8),
					new SqlParameter("@NrOreInvoire", SqlDbType.Float, 8),
					new SqlParameter("@NrOreConcediuOdihna", SqlDbType.Float, 8),
					new SqlParameter("@NrOreConcediuBoala", SqlDbType.Float, 8),
					new SqlParameter("@NrOreConcediuBoalaFirma", SqlDbType.Float, 8),
					new SqlParameter("@NrOreConcediuBoalaBASS", SqlDbType.Float, 8),

					new SqlParameter("@NrOreObligatiiCetatenesti", SqlDbType.Float, 8),
					new SqlParameter("@NrOreAbsenteNemotivate", SqlDbType.Float, 8),
					new SqlParameter("@NrOreConcediuFaraPlata", SqlDbType.Float, 8),

					new SqlParameter("@NrOreTotalDelegatieInterna", SqlDbType.Float, 8),
					new SqlParameter("@NrOreTotalDelegatieExterna", SqlDbType.Float, 8),
					new SqlParameter("@NrOreLucrateDelegatieInterna", SqlDbType.Float, 8),
					new SqlParameter("@NrOreLucrateDelegatieExterna", SqlDbType.Float, 8),
					new SqlParameter("@DiurnaImpozabila", SqlDbType.Money, 8),

					new SqlParameter("@NrOreEmergencyService", SqlDbType.Float, 8),

					new SqlParameter("@SporActivitatiSup", SqlDbType.Money, 8),
					new SqlParameter("@EmergencyService", SqlDbType.Money, 8),
					new SqlParameter("@PrimeSpeciale", SqlDbType.Money, 8),
					new SqlParameter("@AlteDrepturi", SqlDbType.Money, 8),
					new SqlParameter("@AlteDrepturiNet", SqlDbType.Money, 8),
					new SqlParameter("@AjutorDeces", SqlDbType.Money, 8),

					new SqlParameter("@Avans", SqlDbType.Money, 8),
					new SqlParameter("@Retineri", SqlDbType.Money, 8),
					new SqlParameter("@Regularizare", SqlDbType.Money, 8),
					new SqlParameter("@PrimaProiect", SqlDbType.Money, 8),
					new SqlParameter("@RetinereSanatate", SqlDbType.Money, 8),
					
					new SqlParameter("@CategorieID", SqlDbType.Int, 4),
					new SqlParameter("@ProgramLucru", SqlDbType.Int, 4),
					new SqlParameter("@SalariuBaza", SqlDbType.Money, 8),
					new SqlParameter("@IndemnizatieConducere", SqlDbType.Money, 8),
					new SqlParameter("@Invaliditate", SqlDbType.SmallInt, 2),

					new SqlParameter("@tip_actiune", SqlDbType.Int, 4),
					new SqlParameter("@rc", SqlDbType.Int, 4),

					new SqlParameter("@ValideazaStergere", SqlDbType.Bit, 1),

					new SqlParameter("@NrZileLucrateLuna", SqlDbType.Float, 8),

					new SqlParameter("@NrZileConcediuOdihnaNeefectuat", SqlDbType.Float, 8),
					new SqlParameter("@NrZileConcediuOdihnaEfectuatInAvans", SqlDbType.Float, 8),
					new SqlParameter("@NrTichete", SqlDbType.Float, 8),
				    new SqlParameter("@CorectiiTichete", SqlDbType.Float, 8),
				    new SqlParameter("@NrTotalTichete", SqlDbType.Int, 4),
					new SqlParameter("@DrepturiInNatura", SqlDbType.Money, 8)
			};
			
			parameters[0].Value = -1;
			parameters[1].Value = LunaID;
			parameters[2].Value = AngajatID;
			parameters[3].Value = NrZileLuna;
			parameters[4].Value = NrOreLucrate+ProgramLucru*NrOreLucrateDelegatieInterna+ProgramLucru*NrOreLucrateDelegatieExterna;
			parameters[5].Value = NrOreSup50Proc;
			parameters[6].Value = NrOreSup100Proc;
			parameters[7].Value = NrOreEvenimDeoseb;

			parameters[8].Value = NrOreInvoire;
			parameters[9].Value = NrOreConcediuOdihna;
			parameters[10].Value = NrOreConcediuBoala;
			parameters[11].Value = NrOreConcediuBoalaFirma;
			parameters[12].Value = NrOreConcediuBoalaBASS;

			parameters[13].Value = NrOreObligatiiCetatenesti;
			parameters[14].Value = NrOreAbsenteNemotivate;
			parameters[15].Value = NrOreConcediuFaraPlata;

			parameters[16].Value = NrOreTotalDelegatieInterna;
			parameters[17].Value = NrOreTotalDelegatieExterna;
			parameters[18].Value = NrOreLucrateDelegatieInterna;
			parameters[19].Value = NrOreLucrateDelegatieExterna;
			parameters[20].Value = DiurnaImpozabila;
			parameters[21].Value = NrOreEmergencyService;

			parameters[22].Value = SporActivitatiSup;
			parameters[23].Value = EmergencyService;
			parameters[24].Value = PrimeSpeciale;
			parameters[25].Value = AlteDrepturi;
			parameters[26].Value = AlteDrepturiNet;
			parameters[27].Value = AjutorDeces;

			parameters[28].Value = Avans;
			parameters[29].Value = 0;
			parameters[30].Value = Regularizare;
			parameters[31].Value = PrimaProiect;
			parameters[32].Value = RetinereSanatate;

			parameters[33].Value = CategorieID;
			parameters[34].Value = ProgramLucru;
			parameters[35].Value = SalariuBaza;
			parameters[36].Value = IndemnizatieConducere;
			parameters[37].Value = Invaliditate;

			parameters[38].Value = 0;

			parameters[39].Direction = ParameterDirection.Output;

			parameters[ 40 ].Value = ValidareStergere;

			//Adaugat:		Oprescu Claudia
			//Descriere:	Se scad din numarul de zile lucrate si cele pentru intreruperile de contracte
			PontajAngajat pa = new PontajAngajat(conexiune);
			int NrZileIntervaleIntreruperi = pa.GetNrZileIntervaleIntreruperi(int.Parse(AngajatID+""), LunaID);
			parameters[ 41 ].Value = NrZileLuna-NrOreEvenimDeoseb-NrOreInvoire-NrOreConcediuOdihna-NrOreConcediuBoala-NrOreObligatiiCetatenesti-NrOreAbsenteNemotivate-NrOreConcediuFaraPlata;
			parameters[ 41 ].Value = int.Parse(parameters[ 41 ].Value.ToString()) - NrZileIntervaleIntreruperi;

			parameters[ 42 ].Value = NrZileConcediuOdihnaNeefectuat;
			parameters[ 43 ].Value = NrZileConcediuOdihnaEfectuatInAvans;
			parameters[44].Value = NrTichete;
			parameters[45].Value = CorectiiTichete;
			parameters[46].Value = NrTotalTichete;
			parameters[47].Value = DrepturiInNatura;

			RunProcedure("sal_InsertUpdateDeleteSituatieLunaraAngajat", parameters, out numAffected);
			return (int)parameters[39].Value;
		}
		#endregion

		#region InsertSituatieLunaraAngajat
		/// <summary>
		/// Prcedura adauga o situatie lunara a unui angajat
		/// </summary>
		/// <returns>Returneaza nr de inregistrari afectate</returns>
		public int InsertSituatieLunaraAngajat(
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
			int CategorieID)
		{
			int numAffected;
		
			SqlParameter[] parameters = 
				{
					new SqlParameter("@SituatieID", SqlDbType.Int, 4),
					new SqlParameter("@LunaID", SqlDbType.Int, 4),
					new SqlParameter("@AngajatID", SqlDbType.Int, 4),
					new SqlParameter("@NrZileLuna", SqlDbType.Float, 8),
					new SqlParameter("@NrOreLucrate", SqlDbType.Float, 8),
					new SqlParameter("@NrOreSup50Proc", SqlDbType.Float, 8),
					new SqlParameter("@NrOreSup100Proc", SqlDbType.Float, 8),
					new SqlParameter("@NrOreEvenimDeoseb", SqlDbType.Float, 8),
					new SqlParameter("@NrOreInvoire", SqlDbType.Float, 8),
					new SqlParameter("@NrOreConcediuOdihna", SqlDbType.Float, 8),
					new SqlParameter("@NrOreConcediuBoala", SqlDbType.Float, 8),
					new SqlParameter("@NrOreConcediuBoalaFirma", SqlDbType.Float, 8),
					new SqlParameter("@NrOreConcediuBoalaBASS", SqlDbType.Float, 8),

					new SqlParameter("@NrOreObligatiiCetatenesti", SqlDbType.Float, 8),
					new SqlParameter("@NrOreAbsenteNemotivate", SqlDbType.Float, 8),
					new SqlParameter("@NrOreConcediuFaraPlata", SqlDbType.Float, 8),

					new SqlParameter("@NrOreTotalDelegatieInterna", SqlDbType.Float, 8),
					new SqlParameter("@NrOreTotalDelegatieExterna", SqlDbType.Float, 8),
					new SqlParameter("@NrOreLucrateDelegatieInterna", SqlDbType.Float, 8),
					new SqlParameter("@NrOreLucrateDelegatieExterna", SqlDbType.Float, 8),
					new SqlParameter("@DiurnaImpozabila", SqlDbType.Money, 8),
					new SqlParameter("@NrOreEmergencyService", SqlDbType.Float, 8),

					new SqlParameter("@SporActivitatiSup", SqlDbType.Money, 8),
					new SqlParameter("@EmergencyService", SqlDbType.Money, 8),
					new SqlParameter("@PrimeSpeciale", SqlDbType.Money, 8),
					new SqlParameter("@AlteDrepturi", SqlDbType.Money, 8),
					new SqlParameter("@AlteDrepturiNet", SqlDbType.Money, 8),
					new SqlParameter("AjutorDeces",SqlDbType.Money,8),

					new SqlParameter("@Avans", SqlDbType.Money, 8),
					new SqlParameter("@Retineri", SqlDbType.Money, 8),
					new SqlParameter("@Regularizare", SqlDbType.Money, 8),
					new SqlParameter("@PrimaProiect", SqlDbType.Money, 8),
					new SqlParameter("@RetinereSanatate", SqlDbType.Money, 8),

					new SqlParameter("@CategorieID", SqlDbType.Int, 4),
					new SqlParameter("@ProgramLucru", SqlDbType.Int, 4),
					new SqlParameter("@SalariuBaza", SqlDbType.Money, 8),
					new SqlParameter("@IndemnizatieConducere", SqlDbType.Money, 8),
					new SqlParameter("@Invaliditate", SqlDbType.SmallInt, 2),

					new SqlParameter("@tip_actiune", SqlDbType.Int, 4),
					new SqlParameter("@rc", SqlDbType.Int, 4),

					new SqlParameter("@NrZileLucrateLuna", SqlDbType.Float, 8),

					new SqlParameter("@NrZileConcediuOdihnaNeefectuat", SqlDbType.Float, 8),
					new SqlParameter("@NrZileConcediuOdihnaEfectuatInAvans", SqlDbType.Float, 8),
					new SqlParameter("@NrTichete", SqlDbType.Float, 8),
					new SqlParameter("@CorectiiTichete", SqlDbType.Float, 8),
				    new SqlParameter("@NrTotalTichete", SqlDbType.Int, 4),
					new SqlParameter("@DrepturiInNatura", SqlDbType.Money, 8)

				};
			
			parameters[0].Value = -1;
			parameters[1].Value = LunaID;
			parameters[2].Value = AngajatID;
			parameters[3].Value = NrZileLuna;
			parameters[4].Value = NrOreLucrate+ProgramLucru*NrOreLucrateDelegatieInterna+ProgramLucru*NrOreLucrateDelegatieExterna;
			parameters[5].Value = NrOreSup50Proc;
			parameters[6].Value = NrOreSup100Proc;
			parameters[7].Value = NrOreEvenimDeoseb;

			parameters[8].Value = NrOreInvoire;
			parameters[9].Value = NrOreConcediuOdihna;
			parameters[10].Value = NrOreConcediuBoala;
			parameters[11].Value = NrOreConcediuBoalaFirma;
			parameters[12].Value = NrOreConcediuBoalaBASS;

			parameters[13].Value = NrOreObligatiiCetatenesti;
			parameters[14].Value = NrOreAbsenteNemotivate;
			parameters[15].Value = NrOreConcediuFaraPlata;

			parameters[16].Value = NrOreTotalDelegatieInterna;
			parameters[17].Value = NrOreTotalDelegatieExterna;
			parameters[18].Value = NrOreLucrateDelegatieInterna;
			parameters[19].Value = NrOreLucrateDelegatieExterna;
			parameters[20].Value = DiurnaImpozabila;
			parameters[21].Value = NrOreEmergencyService;

			parameters[22].Value = SporActivitatiSup;
			parameters[23].Value = EmergencyService;
			parameters[24].Value = PrimeSpeciale;
			parameters[25].Value = AlteDrepturi;
			parameters[26].Value = AlteDrepturiNet;
			parameters[27].Value = AjutorDeces;

			parameters[28].Value = Avans;
			parameters[29].Value = 0;
			parameters[30].Value = Regularizare;
			parameters[31].Value = PrimaProiect;
			parameters[32].Value = RetinereSanatate;

			parameters[33].Value = CategorieID;
			parameters[34].Value = ProgramLucru;
			parameters[35].Value = SalariuBaza;
			parameters[36].Value = IndemnizatieConducere;
			parameters[37].Value = Invaliditate;

			parameters[38].Value = 0;

			parameters[39].Direction = ParameterDirection.Output;

			//parameters[ 38 ].Value = NrZileLuna-NrOreEvenimDeoseb-NrOreInvoire-NrOreConcediuOdihna-NrOreConcediuBoala-NrOreObligatiiCetatenesti-NrOreAbsenteNemotivate-NrOreConcediuFaraPlata;
			//Adaugat:		Oprescu Claudia
			//Descriere:	Se scad din numarul de zile lucrate si cele pentru intreruperile de contracte
			PontajAngajat pa = new PontajAngajat(conexiune);
			int NrZileIntervaleIntreruperi = pa.GetNrZileIntervaleIntreruperi(int.Parse(AngajatID+""), LunaID);
			parameters[ 40 ].Value = NrZileLuna-NrOreEvenimDeoseb-NrOreInvoire-NrOreConcediuOdihna-NrOreConcediuBoala-NrOreObligatiiCetatenesti-NrOreAbsenteNemotivate-NrOreConcediuFaraPlata;
			parameters[ 40].Value = int.Parse(parameters[ 40 ].Value.ToString()) - NrZileIntervaleIntreruperi;

			parameters[ 41 ].Value = NrZileConcediuOdihnaNeefectuat;
			parameters[ 42 ].Value = NrZileConcediuOdihnaEfectuatInAvans;
			parameters[43].Value = NrTichete;
			parameters[44].Value = CorectiiTichete;
			parameters[45].Value = NrTotalTichete;
			parameters[46].Value = DrepturiInNatura;

			RunProcedure("sal_InsertUpdateDeleteSituatieLunaraAngajat", parameters, out numAffected);
			return (int)parameters[39].Value;
		}
		#endregion

		#region InsertSituatieLunaraAngajat
		/// <summary>
		/// Prcedura adauga o situatie lunara a unui angajat
		/// </summary>
		/// <param name="isl">Obiectul care contine date situatiei lunare</param>
		/// <param name="ValidareStergere">Validare stergere</param>
		/// <returns>Returneaza nr de inregistrari afectate</returns>
		public int InsertSituatieLunaraAngajat(InfoSituatieLunara isl, bool ValidareStergere )
		{
			return this.InsertSituatieLunaraAngajat(isl.LunaID,isl.AngajatID,isl.NrZileLuna,isl.NrOreLucrate,isl.NrOreSup50Proc,isl.NrOreSup100Proc,isl.NrOreEvenimDeoseb,isl.NrOreInvoire,isl.NrOreConcediuOdihna,isl.NrZileConcediuOdihnaNeefectuat,isl.NrZileConcediuOdihnaEfectuatInAvans,isl.NrOreConcediuBoala, isl.NrOreConcediuBoalaFirma, isl.NrOreConcediuBoalaBASS, isl.NrOreObligatiiCetatenesti, isl.NrOreAbsenteNemotivate, isl.NrOreConcediuFaraPlata, isl.NrOreTotalDelegatieInterna, isl.NrOreTotalDelegatieExterna, isl.NrOreLucrateDelegatieInterna, isl.NrOreLucrateDelegatieExterna, isl.DiurnaImpozabila, isl.NrOreEmergencyService, isl.NrTichete, isl.CorectiiTichete, isl.NrTotalTichete, isl.SporActivitatiSup,isl.EmergencyService,isl.PrimeSpeciale,isl.AlteDrepturi, isl.AlteDrepturiNet,isl.AjutorDeces, isl.Avans, /*isl.Retineri,*/ isl.Regularizare, isl.PrimaProiect, isl.RetinereSanatate, isl.DrepturiInNatura, isl.ProgramLucru, isl.SalariuBaza, isl.IndemnizatieConducere, isl.Invaliditate, isl.CategorieID, ValidareStergere);
		}
		#endregion

		#region InsertSituatieLunaraAngajat
		/// <summary>
		/// Prcedura adauga o situatie lunara a unui angajat
		/// </summary>
		/// <param name="isl">Obiectul care contine date situatiei lunare</param>
		/// <returns>Returneaza nr de inregistrari afectate</returns>
		public int InsertSituatieLunaraAngajat(InfoSituatieLunara isl )
		{
			return this.InsertSituatieLunaraAngajat(isl.LunaID,isl.AngajatID,isl.NrZileLuna,isl.NrOreLucrate,isl.NrOreSup50Proc,isl.NrOreSup100Proc,isl.NrOreEvenimDeoseb,isl.NrOreInvoire,isl.NrOreConcediuOdihna,isl.NrZileConcediuOdihnaNeefectuat,isl.NrZileConcediuOdihnaEfectuatInAvans,isl.NrOreConcediuBoala, isl.NrOreConcediuBoalaFirma, isl.NrOreConcediuBoalaBASS, isl.NrOreObligatiiCetatenesti, isl.NrOreAbsenteNemotivate, isl.NrOreConcediuFaraPlata, isl.NrOreTotalDelegatieInterna, isl.NrOreTotalDelegatieExterna, isl.NrOreLucrateDelegatieInterna, isl.NrOreLucrateDelegatieExterna, isl.DiurnaImpozabila, isl.NrOreEmergencyService, isl.NrTichete, isl.CorectiiTichete, isl.NrTotalTichete, isl.SporActivitatiSup,isl.EmergencyService,isl.PrimeSpeciale,isl.AlteDrepturi, isl.AlteDrepturiNet, isl.AjutorDeces, isl.Avans, /*isl.Retineri,*/ isl.Regularizare, isl.PrimaProiect, isl.RetinereSanatate, isl.DrepturiInNatura, isl.ProgramLucru, isl.SalariuBaza, isl.IndemnizatieConducere, isl.Invaliditate, isl.CategorieID );
		}
		#endregion

		#region UpdateSituatieLunaraAngajat
		/// <summary>
		/// Este realizat update-ul situatiei lunare a unui angajat.
		/// </summary>
		/// <param name="isl"> Datele aferente situatiei lunare.</param>
		/// <returns> 0 in cazul in care modificarea a fost realizata cu succes sau un 
		/// intreg diferit de 0, altfel.</returns>
		/// <remarks> 
		/// Modificari:
		/// Autor:    Cristina Raluca Muntean
		/// Data:     3.05.2006
		/// Descriere:In cadrul metodei se apela o alta metoda de update ce avea ca parametrii datele 
		/// situatiei lunare. Deoarece nu erau transmise si id-urile angajatului si al lunii aparea
		/// o eroare la rularea procedurii stocate.  
		/// </remarks>
		public int UpdateSituatieLunaraAngajat(InfoSituatieLunara isl)
		{
			int numAffected;
		
			SqlParameter[] parameters = 
				{
					new SqlParameter("@SituatieID", SqlDbType.Int, 4),
					new SqlParameter("@LunaID", SqlDbType.Int, 4),
					new SqlParameter("@AngajatID", SqlDbType.Int, 4),
					new SqlParameter("@NrZileLuna", SqlDbType.Float, 8),
					new SqlParameter("@NrOreLucrate", SqlDbType.Float, 8),
					new SqlParameter("@NrOreSup50Proc", SqlDbType.Float, 8),
					new SqlParameter("@NrOreSup100Proc", SqlDbType.Float, 8),
					new SqlParameter("@NrOreEvenimDeoseb", SqlDbType.Float, 8),
					new SqlParameter("@NrOreInvoire", SqlDbType.Float, 8),
					new SqlParameter("@NrOreConcediuOdihna", SqlDbType.Float, 8),
					new SqlParameter("@NrOreConcediuBoala", SqlDbType.Float, 8),
					new SqlParameter("@NrOreConcediuBoalaFirma", SqlDbType.Float, 8),
					new SqlParameter("@NrOreConcediuBoalaBASS", SqlDbType.Float, 8),

					new SqlParameter("@NrOreObligatiiCetatenesti", SqlDbType.Float, 8),
					new SqlParameter("@NrOreAbsenteNemotivate", SqlDbType.Float, 8),
					new SqlParameter("@NrOreConcediuFaraPlata", SqlDbType.Float, 8),

					new SqlParameter("@NrOreTotalDelegatieInterna", SqlDbType.Float, 8),
					new SqlParameter("@NrOreTotalDelegatieExterna", SqlDbType.Float, 8),
					new SqlParameter("@NrOreLucrateDelegatieInterna", SqlDbType.Float, 8),
					new SqlParameter("@NrOreLucrateDelegatieExterna", SqlDbType.Float, 8),
					new SqlParameter("@DiurnaImpozabila", SqlDbType.Money, 8),
					new SqlParameter("@NrOreEmergencyService", SqlDbType.Float, 8),

					new SqlParameter("@SporActivitatiSup", SqlDbType.Money, 8),
					new SqlParameter("@EmergencyService", SqlDbType.Money, 8),
					new SqlParameter("@PrimeSpeciale", SqlDbType.Money, 8),
					new SqlParameter("@AlteDrepturi", SqlDbType.Money, 8),
					new SqlParameter("@AlteDrepturiNet", SqlDbType.Money, 8),
					new SqlParameter("@AjutorDeces", SqlDbType.Money, 8),

					new SqlParameter("@Avans", SqlDbType.Money, 8),
					new SqlParameter("@Retineri", SqlDbType.Money, 8),
					new SqlParameter("@Regularizare", SqlDbType.Money, 8),
					new SqlParameter("@PrimaProiect", SqlDbType.Money, 8),
					new SqlParameter("@RetinereSanatate", SqlDbType.Money, 8),

					new SqlParameter("@CategorieID", SqlDbType.Int, 4),
					new SqlParameter("@ProgramLucru", SqlDbType.Int, 4),
					new SqlParameter("@SalariuBaza", SqlDbType.Money, 8),
					new SqlParameter("@IndemnizatieConducere", SqlDbType.Money, 8),
					new SqlParameter("@Invaliditate", SqlDbType.SmallInt, 2),

					new SqlParameter("@tip_actiune", SqlDbType.Int, 4),
					new SqlParameter("@rc", SqlDbType.Int, 4),

					new SqlParameter("@NrZileLucrateLuna", SqlDbType.Float, 8),

					new SqlParameter("@NrZileConcediuOdihnaNeefectuat", SqlDbType.Float, 8),
					new SqlParameter("@NrZileConcediuOdihnaEfectuatInAvans", SqlDbType.Float, 8),
					new SqlParameter("@NrTichete", SqlDbType.Float, 8),
					new SqlParameter("@CorectiiTichete", SqlDbType.Float, 8),
					new SqlParameter("@NrTotalTichete", SqlDbType.Int, 4),
				    new SqlParameter("@DrepturiInNatura", SqlDbType.Money, 8)
				};
			
			parameters[0].Value = isl.SituatieID;
			parameters[1].Value = isl.LunaID;
			parameters[2].Value = isl.AngajatID;
			parameters[3].Value = isl.NrZileLuna;
			parameters[4].Value = isl.NrOreLucrate + isl.ProgramLucru * isl.NrOreLucrateDelegatieInterna + 
								  isl.ProgramLucru * isl.NrOreLucrateDelegatieExterna;
			parameters[5].Value = isl.NrOreSup50Proc;
			parameters[6].Value = isl.NrOreSup100Proc;
			parameters[7].Value = isl.NrOreEvenimDeoseb;
			parameters[8].Value = isl.NrOreInvoire;
			parameters[9].Value = isl.NrOreConcediuOdihna;
			parameters[10].Value = isl.NrOreConcediuBoala;
			parameters[11].Value = isl.NrOreConcediuBoalaFirma;
			parameters[12].Value = isl.NrOreConcediuBoalaBASS;

			parameters[13].Value = isl.NrOreObligatiiCetatenesti;
			parameters[14].Value = isl.NrOreAbsenteNemotivate;
			parameters[15].Value = isl.NrOreConcediuFaraPlata;

			parameters[16].Value = isl.NrOreTotalDelegatieInterna;
			parameters[17].Value = isl.NrOreTotalDelegatieExterna;
			parameters[18].Value = isl.NrOreLucrateDelegatieInterna;
			parameters[19].Value = isl.NrOreLucrateDelegatieExterna;
			parameters[20].Value = isl.DiurnaImpozabila;
			parameters[21].Value = isl.NrOreEmergencyService;

			parameters[22].Value = isl.SporActivitatiSup;
			parameters[23].Value = isl.EmergencyService;
			parameters[24].Value = isl.PrimeSpeciale;
			parameters[25].Value = isl.AlteDrepturi;
			parameters[26].Value = isl.AlteDrepturiNet;
			parameters[27].Value = isl.AjutorDeces;

			parameters[28].Value = isl.Avans;
			parameters[29].Value = 0;
			parameters[30].Value = isl.Regularizare;
			parameters[31].Value = isl.PrimaProiect;
			parameters[32].Value = isl.RetinereSanatate;

			parameters[33].Value = isl.CategorieID;
			parameters[34].Value = isl.ProgramLucru;
			parameters[35].Value = isl.SalariuBaza;
			parameters[36].Value = isl.IndemnizatieConducere;
			parameters[37].Value = isl.Invaliditate;

			parameters[38].Value = 1;
			parameters[39].Direction = ParameterDirection.Output;

			//Adaugat:		Oprescu Claudia
			//Descriere:	Se scad din numarul de zile lucrate si cele pentru intreruperile de contracte
			PontajAngajat pa = new PontajAngajat(conexiune);
			int NrZileIntervaleIntreruperi = pa.GetNrZileIntervaleIntreruperi(int.Parse(isl.AngajatID+""), isl.LunaID);
			parameters[ 40 ].Value = isl.NrZileLuna - isl.NrOreEvenimDeoseb - isl.NrOreInvoire -
				isl.NrOreConcediuOdihna - isl.NrOreConcediuBoala - isl.NrOreObligatiiCetatenesti -
				isl.NrOreAbsenteNemotivate - isl.NrOreConcediuFaraPlata - NrZileIntervaleIntreruperi;

			parameters[ 41 ].Value = isl.NrZileConcediuOdihnaNeefectuat;
			parameters[ 42 ].Value = isl.NrZileConcediuOdihnaEfectuatInAvans;

			parameters[43].Value = isl.NrTichete;
			parameters[44].Value = isl.CorectiiTichete;
			parameters[45].Value = isl.NrTotalTichete;
			parameters[46].Value = isl.DrepturiInNatura;
			
			RunProcedure("sal_InsertUpdateDeleteSituatieLunaraAngajat", parameters, out numAffected);
			
			//actualizarea retinerilor
			new TipuriRetineriValori(conexiune).UpdateRetineriValori(isl.LunaID, isl.AngajatID, isl.Retineri1, isl.Retineri2, isl.Retineri3, isl.Retineri4, isl.Retineri5, isl.Retineri6, isl.Retineri7);
		
			return (int)parameters[39].Value;
		}
		#endregion

		#region DeleteSituatieLunaraAngajat
		/// <summary>
		///	Procedura sterge o stituatie lunare
		/// </summary>
		/// <param name="SituatieId">Id-ul situatiei lunare care se sterge</param>
		/// <returns>Returneaza rezultatul stergerii</returns>
		public int DeleteSituatieLunaraAngajat(int SituatieId)
		{
			int numAffected;
		
			SqlParameter[] parameters = 
				{
					new SqlParameter("@SituatieID", SqlDbType.Int, 4),
					new SqlParameter("@LunaID", SqlDbType.Int, 4),
					new SqlParameter("@AngajatID", SqlDbType.Int, 4),
					new SqlParameter("@NrZileLuna", SqlDbType.Float, 8),
					new SqlParameter("@NrOreLucrate", SqlDbType.Float, 8),
					new SqlParameter("@NrOreSup50Proc", SqlDbType.Float, 8),
					new SqlParameter("@NrOreSup100Proc", SqlDbType.Float, 8),
					new SqlParameter("@NrOreEvenimDeoseb", SqlDbType.Float, 8),
					new SqlParameter("@NrOreInvoire", SqlDbType.Float, 8),
					new SqlParameter("@NrOreConcediuOdihna", SqlDbType.Float, 8),
					new SqlParameter("@NrOreConcediuBoala", SqlDbType.Float, 8),
					new SqlParameter("@NrOreConcediuBoalaFirma", SqlDbType.Float, 8),
					new SqlParameter("@NrOreConcediuBoalaBASS", SqlDbType.Float, 8),

					new SqlParameter("@NrOreObligatiiCetatenesti", SqlDbType.Float, 8),
					new SqlParameter("@NrOreAbsenteNemotivate", SqlDbType.Float, 8),
					new SqlParameter("@NrOreConcediuFaraPlata", SqlDbType.Float, 8),

					new SqlParameter("@NrOreTotalDelegatieInterna", SqlDbType.Float, 8),
					new SqlParameter("@NrOreTotalDelegatieExterna", SqlDbType.Float, 8),
					new SqlParameter("@NrOreLucrateDelegatieInterna", SqlDbType.Float, 8),
					new SqlParameter("@NrOreLucrateDelegatieExterna", SqlDbType.Float, 8),
					new SqlParameter("@DiurnaImpozabila", SqlDbType.Money, 8),
					new SqlParameter("@NrOreEmergencyService", SqlDbType.Float, 8),

					new SqlParameter("@SporActivitatiSup", SqlDbType.Money, 8),
					new SqlParameter("@EmergencyService", SqlDbType.Money, 8),
					new SqlParameter("@PrimeSpeciale", SqlDbType.Money, 8),
					new SqlParameter("@AlteDrepturi", SqlDbType.Money, 8),
					new SqlParameter("@AlteDrepturiNet", SqlDbType.Money, 8),
					new SqlParameter("@AjutorDeces", SqlDbType.Money, 8),
					

					new SqlParameter("@Avans", SqlDbType.Money, 8),
					new SqlParameter("@Retineri", SqlDbType.Money, 8),
					new SqlParameter("@Regularizare", SqlDbType.Money, 8),
					new SqlParameter("@PrimaProiect", SqlDbType.Money, 8),
					new SqlParameter("@RetinereSanatate", SqlDbType.Money, 8),

					new SqlParameter("@CategorieID", SqlDbType.Int, 4),
					new SqlParameter("@ProgramLucru", SqlDbType.Int, 4),
					new SqlParameter("@SalariuBaza", SqlDbType.Money, 8),
					new SqlParameter("@IndemnizatieConducere", SqlDbType.Money, 8),
					new SqlParameter("@Invaliditate", SqlDbType.SmallInt, 2),

					new SqlParameter("@tip_actiune", SqlDbType.Int, 4),
					new SqlParameter("@rc", SqlDbType.Int, 4),

					new SqlParameter("@NrZileLucrateLuna", SqlDbType.Float, 8),

					new SqlParameter("@NrZileConcediuOdihnaNeefectuat", SqlDbType.Float, 8),
					new SqlParameter("@NrZileConcediuOdihnaEfectuatInAvans", SqlDbType.Float, 8),
					new SqlParameter("@NrTichete", SqlDbType.Float, 8),
					new SqlParameter("@CorectiiTichete", SqlDbType.Float, 8),
				    new SqlParameter("@NrTotalTichete", SqlDbType.Int, 4),
				    new SqlParameter("@DrepturiInNatura", SqlDbType.Money, 8)    

				};
			
			parameters[0].Value = SituatieId;
			parameters[1].Value = -1;
			parameters[2].Value = -1;
			parameters[3].Value = 0;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = 0;
			parameters[7].Value = 0;
			parameters[8].Value = 0;
			parameters[9].Value = 0;
			parameters[10].Value = 0;
			parameters[11].Value = 0;
			parameters[12].Value = 0;
			
			parameters[13].Value = 0;
			parameters[14].Value = 0;
			parameters[15].Value = 0;

			parameters[16].Value = 0;
			parameters[17].Value = 0;
			parameters[18].Value = 0;
			parameters[19].Value = 0;

			parameters[20].Value = 0;

			parameters[21].Value = 0;
			parameters[22].Value = 0;
			parameters[23].Value = 0;
			parameters[24].Value = 0;
			parameters[25].Value = 0;
			parameters[26].Value = 0;

			parameters[27].Value = 0;
			parameters[28].Value = 0;
			parameters[29].Value = 0;

			parameters[30].Value = 0;
			parameters[31].Value = 0;
			parameters[32].Value = 0;
			parameters[33].Value = 0;
			parameters[34].Value = 0;

			parameters[35].Value = 2;
			parameters[36].Direction = ParameterDirection.Output;

			parameters[ 37 ].Value = 0;
			
			parameters[ 38 ].Value = 0;
			parameters[ 39 ].Value = 0;

			parameters[40].Value = 0;
			parameters[41].Value = 0;
			parameters[42].Value = 0;
			parameters[43].Value = 0;

			RunProcedure("sal_InsertUpdateDeleteSituatieLunaraAngajat", parameters, out numAffected);
			return (int)parameters[36].Value;
		}
		#endregion

		#region DeleteSituatieAngajat
		/// <summary>
		/// Sterge situatia lunara a unui angajat dintr-o anumita luna.
		/// </summary>
		/// <param name="LunaID">Id-ul lunii</param>
		/// <param name="AngajatID">Id-ul angajatului</param>
		/// <returns>Returneaza rezultatul stergerii</returns>
		/// <remarks>
		/// Added:       Muntean Raluca Cristina
		/// Date:        13.09.2005
		/// </remarks>
		public int DeleteSituatieAngajat(int LunaID,int AngajatID)
		{
			int numAffected;
		
			SqlParameter[] parameters = 
				{
					new SqlParameter("@LunaID", SqlDbType.Int, 4),
					new SqlParameter("@AngajatID", SqlDbType.Int, 4),
					new SqlParameter("@rc", SqlDbType.Int, 4)
				};
			
			parameters[0].Value = LunaID;
			parameters[1].Value = AngajatID;
			
			parameters[2].Direction = ParameterDirection.Output;

			RunProcedure("sal_DeleteSituatieLunaraAngajat", parameters, out numAffected);
			return (int)parameters[2].Value;
		}
		#endregion

		#region DeleteSituatieLunaraAngajat
		/// <summary>
		/// Procedura sterge situatia lunara a unui angajat
		/// </summary>
		/// <param name="isl">Obiectul care contine situatia lunara a unui angajat</param>
		/// <returns>Returneaza rezultatul stergerii</returns>
		public int DeleteSituatieLunaraAngajat(InfoSituatieLunara isl)
		{
			return this.DeleteSituatieLunaraAngajat(isl.SituatieID);
		}
		#endregion

		#region GetSituatiiLunare
		/// <summary>
		/// Procedura selecteaza situatiile lunare
		/// </summary>
		/// <param name="AngajatID">Id-ul angajatului</param>
		/// <param name="LunaID">Id-ul lunii</param>
		/// <returns>Returneaza un DataSet care contine aceste date</returns>
		public DataSet GetSituatiiLunare(long AngajatID, long LunaID)
		{			
			DataSet dsSituatiiLunare = new DataSet();	
			SqlParameter[] parameters = 
				{
					new SqlParameter("@AngajatID", SqlDbType.Int, 4),
					new SqlParameter("@LunaID", SqlDbType.Int, 4)
				};
			
			parameters[0].Value = AngajatID;
			parameters[1].Value = LunaID;
			
			dsSituatiiLunare = RunProcedure("sal_GetAllSituatiiLunare", parameters, "SituatieLunara");
			return dsSituatiiLunare;
		}
		#endregion
		
		#region GetSituatieLunaraAngajatDataSet
		/// <summary>
		/// Procedura selecteaza situatia lunara a unui angajat
		/// </summary>
		/// <param name="AngajatID">Id-ul angajatului</param>
		/// <param name="LunaID">Id-ul lunii</param>
		/// <returns>Returneaza un DataSet aceste date</returns>
		public DataSet GetSituatieLunaraAngajatDataSet(long AngajatID,int LunaID)
		{
			SqlParameter[] parameters = 
				{
					new SqlParameter("@AngajatID", SqlDbType.Int, 4),
					new SqlParameter("@LunaID", SqlDbType.Int, 4)
				};
			
			parameters[0].Value = AngajatID;
			parameters[1].Value = LunaID;
						
			return RunProcedure("sal_GetSituatieLunaraAngajat",parameters,"InfoSituatieLunara");
		}
		#endregion

		#region GetSituatieLunaraAngajat
		/// <summary>
		/// Procedura selecteaza situatia lunara a unui angajat
		/// </summary>
		/// <param name="AngajatID">Id-ul angajatului</param>
		/// <param name="LunaID">Id-ul lunii</param>
		/// <returns>Returneaza un obiect care contine aceste date</returns>
		public InfoSituatieLunara GetSituatieLunaraAngajat(long AngajatID,int LunaID)
		{
			SqlParameter[] parameters = 
				{
					new SqlParameter("@AngajatID", SqlDbType.Int, 4),
					new SqlParameter("@LunaID", SqlDbType.Int, 4)
				};
			
			parameters[0].Value = AngajatID;
			parameters[1].Value = LunaID;
			
			InfoSituatieLunara isl = new InfoSituatieLunara();
						
			using (DataSet disl = RunProcedure("sal_GetSituatieLunaraAngajat",parameters,"InfoSituatieLunara"))
			{
			
				if (disl.Tables["InfoSituatieLunara"].Rows.Count==1)
				{
				
					DataRow dr = disl.Tables["InfoSituatieLunara"].Rows[0];
					
					isl.SituatieID = int.Parse(dr["SituatieID"].ToString());
					isl.AngajatID = AngajatID;
					isl.LunaID = LunaID;
					
					isl.NrZileLuna = getFloat(dr,"NrZileLuna");
					isl.NrOreLucrate = getFloat(dr,"NrOreLucrate");
					isl.NrOreSup50Proc = getFloat(dr,"NrOreSup50Proc");
					isl.NrOreSup100Proc = getFloat(dr,"NrOreSup100Proc");
					isl.NrOreEvenimDeoseb = getFloat(dr,"NrOreEvenimDeoseb");
					isl.NrOreInvoire = getFloat(dr,"NrOreInvoire");
					isl.NrOreConcediuOdihna = getFloat(dr,"NrOreConcediuOdihna");
					isl.NrZileConcediuOdihnaEfectuatInAvans = getFloat(dr,"NrZileConcediuOdihnaEfectuatInAvans");
					isl.NrZileConcediuOdihnaNeefectuat = getFloat(dr,"NrZileConcediuOdihnaNeefectuat");
					isl.NrOreConcediuBoala = getFloat(dr,"NrOreConcediuBoala");
					isl.NrOreConcediuBoalaFirma = getFloat(dr,"NrOreConcediuBoalaFirma");
					isl.NrOreConcediuBoalaBASS = getFloat(dr,"NrOreConcediuBoalaBASS");

					isl.NrOreObligatiiCetatenesti = getFloat(dr,"NrOreObligatiiCetatenesti");
					isl.NrOreAbsenteNemotivate = getFloat(dr,"NrOreAbsenteNemotivate");
					isl.NrOreConcediuFaraPlata = getFloat(dr,"NrOreConcediuFaraPlata");

					isl.NrOreLucrateDelegatieInterna = getFloat(dr,"NrOreLucrateDelegatieInterna");
					isl.NrOreLucrateDelegatieExterna = getFloat(dr,"NrOreLucrateDelegatieExterna");
					isl.DiurnaImpozabila = getDecimal(dr,"DiurnaImpozabila");
					isl.NrOreTotalDelegatieInterna = getFloat(dr,"NrOreTotalDelegatieInterna");
					isl.NrOreTotalDelegatieExterna = getFloat(dr,"NrOreTotalDelegatieExterna");

					isl.NrOreEmergencyService = getFloat(dr,"NrOreEmergencyService");

					isl.SporActivitatiSup = getDecimal(dr,"SporActivitatiSup");
					isl.PrimeSpeciale = getDecimal(dr,"PrimeSpeciale");
					isl.EmergencyService = getDecimal(dr,"EmergencyService");
					isl.AlteDrepturi = getDecimal(dr,"AlteDrepturi");
					isl.AlteDrepturiNet = getDecimal(dr,"AlteDrepturiNet");
					isl.AjutorDeces = getDecimal(dr,"AjutorDeces");

					isl.Avans = getDecimal(dr,"Avans");
					isl.Regularizare = getDecimal(dr,"Regularizare");
					isl.PrimaProiect = getDecimal(dr,"PrimeProiect");
					isl.RetinereSanatate = getDecimal(dr,"RetinereSanatate");
					isl.DrepturiInNatura = getDecimal(dr, "DrepturiInNatura");

					isl.NrTichete = getFloat(dr, "NrTichete");
					isl.CorectiiTichete = getFloat(dr, "CorectiiTichete");

					isl.ProgramLucru = int.Parse( dr[ "ProgramLucru" ].ToString());
					isl.SalariuBaza = float.Parse( dr[ "SalariuBaza" ].ToString());
					isl.IndemnizatieConducere = float.Parse( dr[ "IndemnizatieConducere" ].ToString());
					isl.Invaliditate = int.Parse( dr[ "Invaliditate" ].ToString());
					isl.CategorieID = int.Parse(dr["CategorieID"].ToString());
				
				} 
				else
					isl.SituatieID=-1;
						
			}

			//Adaugat:		Oprescu Claudia
			//Descriere:	Se obtin valorile pentru retineri corespunzatoare unui angajat intr-o anumita luna
			using (DataSet ds = new TipuriRetineriValori(conexiune).GetRetineriValori(LunaID, AngajatID))
			{
		
				if (ds.Tables["RetineriValori"].Rows.Count > 0)
				{
					//retinere1
					if (ds.Tables[0].Rows[0]["Valoare"] is System.DBNull)
						isl.Retineri1 = 0;
					else
						isl.Retineri1 = getDecimal(ds.Tables[0].Rows[0], "Valoare");
					//retinere2
					if (ds.Tables[0].Rows[1]["Valoare"] is System.DBNull)
						isl.Retineri2 = 0;
					else
						isl.Retineri2 = getDecimal(ds.Tables[0].Rows[1], "Valoare");
					//retinere3
					if (ds.Tables[0].Rows[2]["Valoare"] is System.DBNull)
						isl.Retineri3 = 0;
					else
						isl.Retineri3 = getDecimal(ds.Tables[0].Rows[2], "Valoare");
					//retinere4
					if (ds.Tables[0].Rows[3]["Valoare"] is System.DBNull)
						isl.Retineri4 = 0;
					else
						isl.Retineri4 = getDecimal(ds.Tables[0].Rows[3], "Valoare");
					//retinere5
					if (ds.Tables[0].Rows[4]["Valoare"] is System.DBNull)
						isl.Retineri5 = 0;
					else
						isl.Retineri5 = getDecimal(ds.Tables[0].Rows[4], "Valoare");
					//retinere6
					if (ds.Tables[0].Rows[5]["Valoare"] is System.DBNull)
						isl.Retineri6 = 0;
					else
						isl.Retineri6 = getDecimal(ds.Tables[0].Rows[5], "Valoare");
					//retinere7
					if (ds.Tables[0].Rows[6]["Valoare"] is System.DBNull)
						isl.Retineri7 = 0;
					else
						isl.Retineri7 = getDecimal(ds.Tables[0].Rows[6], "Valoare");
				}
			}
			return isl;
		}
		#endregion

		#region GetSituatieLunaraAngajatByID
		/// <summary>
		/// Procedura selecteaza situatia lunara a unui angajat
		/// </summary>
		/// <param name="SituatieID">Id-ul situatiei</param>
		/// <returns>Returneaza un obiect care contine aceste date</returns>
		public InfoSituatieLunara GetSituatieLunaraAngajatByID(int SituatieID)
		{
			SqlParameter[] parameters = 
				{
					new SqlParameter("@SituatieID", SqlDbType.Int, 4)
				};
			parameters[0].Value = SituatieID;
			InfoSituatieLunara isl = new InfoSituatieLunara();
						
			using (DataSet disl = RunProcedure("sal_GetSituatieLunaraAngajatByID",parameters,"InfoSituatieLunara"))
			{
				if (disl.Tables["InfoSituatieLunara"].Rows.Count==1)
				{
					DataRow dr = disl.Tables["InfoSituatieLunara"].Rows[0];
					
					isl.SituatieID = int.Parse(dr["SituatieID"].ToString());
					isl.AngajatID = long.Parse( dr[ "AngajatID" ].ToString());
					isl.LunaID = int.Parse( dr[ "LunaID" ].ToString());
					
					isl.NrZileLuna = getFloat(dr,"NrZileLuna");
					isl.NrOreLucrate = getFloat(dr,"NrOreLucrate");
					isl.NrOreSup50Proc = getFloat(dr,"NrOreSup50Proc");
					isl.NrOreSup100Proc = getFloat(dr,"NrOreSup100Proc");
					isl.NrOreEvenimDeoseb = getFloat(dr,"NrOreEvenimDeoseb");
					isl.NrOreInvoire = getFloat(dr,"NrOreInvoire");
					isl.NrOreConcediuOdihna = getFloat(dr,"NrOreConcediuOdihna");
					isl.NrZileConcediuOdihnaEfectuatInAvans = getFloat(dr,"NrZileConcediuOdihnaEfectuatInAvans");
					isl.NrZileConcediuOdihnaNeefectuat = getFloat(dr,"NrZileConcediuOdihnaNeefectuat");
					isl.NrOreConcediuBoala = getFloat(dr,"NrOreConcediuBoala");
					isl.NrOreConcediuBoalaFirma = getFloat(dr,"NrOreConcediuBoalaFirma");
					isl.NrOreConcediuBoalaBASS = getFloat(dr,"NrOreConcediuBoalaBASS");

					isl.NrOreObligatiiCetatenesti = getFloat(dr,"NrOreObligatiiCetatenesti");
					isl.NrOreAbsenteNemotivate = getFloat(dr,"NrOreAbsenteNemotivate");
					isl.NrOreConcediuFaraPlata = getFloat(dr,"NrOreConcediuFaraPlata");

					isl.NrOreLucrateDelegatieInterna = getFloat(dr,"NrOreLucrateDelegatieInterna");
					isl.NrOreLucrateDelegatieExterna = getFloat(dr,"NrOreLucrateDelegatieExterna");
					isl.DiurnaImpozabila = getDecimal(dr,"DiurnaImpozabila");
					isl.NrOreTotalDelegatieInterna = getFloat(dr,"NrOreTotalDelegatieInterna");
					isl.NrOreTotalDelegatieExterna = getFloat(dr,"NrOreTotalDelegatieExterna");

					isl.NrOreEmergencyService = getFloat(dr,"NrOreEmergencyService");

					isl.SporActivitatiSup = getDecimal(dr,"SporActivitatiSup");
					isl.PrimeSpeciale = getDecimal(dr,"PrimeSpeciale");
					isl.EmergencyService = getDecimal(dr,"EmergencyService");
					isl.AlteDrepturi = getDecimal(dr,"AlteDrepturi");
					isl.AlteDrepturiNet = getDecimal(dr,"AlteDrepturiNet");
					isl.AjutorDeces = getDecimal(dr,"AjutorDeces");

					isl.Avans = getDecimal(dr,"Avans");
					isl.Regularizare = getDecimal(dr,"Regularizare");
					isl.PrimaProiect = getDecimal(dr,"PrimeProiect");
					isl.RetinereSanatate = getDecimal(dr,"RetinereSanatate");
					isl.DrepturiInNatura = getDecimal(dr, "DrepturiInNatura");

					isl.NrTichete = getFloat(dr, "NrTichete");
					isl.CorectiiTichete = getFloat(dr, "CorectiiTichete");

					isl.ProgramLucru = int.Parse( dr[ "ProgramLucru" ].ToString());
					isl.SalariuBaza = float.Parse( dr[ "SalariuBaza" ].ToString());
					isl.IndemnizatieConducere = float.Parse( dr[ "IndemnizatieConducere" ].ToString());
					isl.Invaliditate = int.Parse( dr[ "Invaliditate" ].ToString());
					isl.CategorieID = int.Parse(dr["CategorieID"].ToString());
				
				} 
				else
					isl.SituatieID=-1;	
			}

			//Adaugat:		Oprescu Claudia
			//Descriere:	Se obtin valorile pentru retineri corespunzatoare unui angajat intr-o anumita luna
			using (DataSet ds = new TipuriRetineriValori(conexiune).GetRetineriValori(isl.LunaID, isl.AngajatID))
			{
		
				if (ds.Tables["RetineriValori"].Rows.Count > 0)
				{
					//retinere1
					if (ds.Tables[0].Rows[0]["Valoare"] is System.DBNull)
						isl.Retineri1 = 0;
					else
						isl.Retineri1 = getDecimal(ds.Tables[0].Rows[0], "Valoare");
					//retinere2
					if (ds.Tables[0].Rows[1]["Valoare"] is System.DBNull)
						isl.Retineri2 = 0;
					else
						isl.Retineri2 = getDecimal(ds.Tables[0].Rows[1], "Valoare");
					//retinere3
					if (ds.Tables[0].Rows[2]["Valoare"] is System.DBNull)
						isl.Retineri3 = 0;
					else
						isl.Retineri3 = getDecimal(ds.Tables[0].Rows[2], "Valoare");
					//retinere4
					if (ds.Tables[0].Rows[3]["Valoare"] is System.DBNull)
						isl.Retineri4 = 0;
					else
						isl.Retineri4 = getDecimal(ds.Tables[0].Rows[3], "Valoare");
					//retinere5
					if (ds.Tables[0].Rows[4]["Valoare"] is System.DBNull)
						isl.Retineri5 = 0;
					else
						isl.Retineri5 = getDecimal(ds.Tables[0].Rows[4], "Valoare");
					//retinere6
					if (ds.Tables[0].Rows[5]["Valoare"] is System.DBNull)
						isl.Retineri6 = 0;
					else
						isl.Retineri6 = getDecimal(ds.Tables[0].Rows[5], "Valoare");
					//retinere7
					if (ds.Tables[0].Rows[6]["Valoare"] is System.DBNull)
						isl.Retineri7 = 0;
					else
						isl.Retineri7 = getDecimal(ds.Tables[0].Rows[6], "Valoare");
				}
			}

			return isl;
		}
		#endregion

		#region GetCategorieAngajat
		/// <summary>
		/// Procedura selecteaza categoria salariala a angajatului
		/// </summary>
		/// <param name="angajatID">Id-ul angajatului</param>
		/// <returns>Returneaza id-ul categoriei salariale</returns>
		public int GetCategorieAngajat( long angajatID )
		{
			try
			{
				SqlParameter[] parameters = 
				{
					new SqlParameter("@AngajatID", SqlDbType.Int, 4)
				};
			
				parameters[0].Value = angajatID;

				DataSet ds = RunProcedure("GetAngajat", parameters, "CategorieAngajat");
				return int.Parse( ds.Tables[ "CategorieAngajat" ].Rows[ 0 ][ "CategorieID" ].ToString());
			}
			catch
			{
				return -1;
			}
		}
		#endregion

		#region GetNrMediuAngajatiFirma
		/// <summary>
		/// Prcedura calculeaza nr mediu de angajati ai firmei
		/// </summary>
		/// <param name="lunaID">Id-ul lunii</param>
		/// <param name="angajatorID">Id-ul angajatorului</param>
		/// <returns>Returneaza nr mediu de angajati</returns>
		public float GetNrMediuAngajatiFirma( int lunaID, int angajatorID )
		{
			try
			{
				SqlParameter[] parameters = 
				{
					new SqlParameter("@LunaID", SqlDbType.Int, 4),
					new SqlParameter("@AngajatorID", SqlDbType.Int, 4)
				};

				parameters[ 0 ].Value = lunaID;
				parameters[ 1 ].Value = angajatorID;

				DataSet ds = RunProcedure("GetA12_NRM", parameters, "NrMediuAng");
				long suma = 0;
				foreach( DataRow dr in ds.Tables[ "NrMediuAng" ].Rows )
				{
					suma += long.Parse( dr[ "suma" ].ToString());
				}

				return suma/( 8*(int.Parse( ds.Tables[ 0 ].Rows[ 0 ][ "NrZileLuna" ].ToString())));
			}
			catch
			{
				return -1;
			}
		}
		#endregion

		#region GetNrZileConcediuBoalaLunaFirma
		/// <summary>
		/// Procedura calculeaza nr de zile de CB oferite de firma
		/// </summary>
		/// <param name="lunaID">Id-ul lunii</param>
		/// <param name="angajatorID">Id-ul angajatorului</param>
		/// <returns>Returneaza un DataSet care contine aceste date</returns>
		public int GetNrZileConcediuBoalaLunaFirma( int lunaID, int angajatorID )
		{
			float nrMediuAngajati = GetNrMediuAngajatiFirma( lunaID, angajatorID );
			SqlParameter[] parameters = 
				{
					new SqlParameter( "@NrMediuAngajati", SqlDbType.Float, 8 ),
					new SqlParameter( "@ReturnValue", SqlDbType.Int, 4 )
				};
			

			parameters[ 0 ].Value = nrMediuAngajati;
			parameters[ 1 ].Direction = ParameterDirection.Output;

			int rowsAffected;
			return RunProcedure("GetNrZileConcediuBoalaLunaFirma", parameters, out rowsAffected);
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
			int nrZileCOneefectuat;

			SqlParameter[] parameters = 
				{
					new SqlParameter( "@lunaID", SqlDbType.Int, 4 ),
					new SqlParameter( "@angajatID", SqlDbType.Int, 4 ),
					new SqlParameter( "@nrZileCORamase", SqlDbType.Int, 4 )
				};
			

			parameters[ 0 ].Value = lunaID;
			parameters[ 1 ].Value = angajatID;
			parameters[ 2 ].Direction = ParameterDirection.Output;

			RunProcedure("spCalculNrZileConcediuOdihnaNeefectuate", parameters, "CO");

			nrZileCOneefectuat = int.Parse(parameters[2].Value.ToString());
			
			return nrZileCOneefectuat;
		}
		#endregion

		#region GetNrZileConcediuOdihnaEfectuatInAvans
		/// <summary>
		/// Returneaza numarul de zile de concediu de odihna efectuat in avans.
		/// </summary>
		/// <param name="lunaId"> ID-ul lunii.</param>
		/// <param name="angajatId"> ID-ul angajatului.</param>
		/// <returns> Numarul de zile de concediu de odihna efectuat in avans.</returns>
		public int GetNrZileConcediuOdihnaEfectuatInAvans( int lunaId, int angajatId )
		{
			int nrZileCOefectuatInAvans;

			SqlParameter[] parameters = 
				{
					new SqlParameter( "@lunaID", SqlDbType.Int, 4 ),
					new SqlParameter( "@angajatID", SqlDbType.Int, 4 ),
					new SqlParameter( "@nrZileCOLuateInAvans", SqlDbType.Int, 4 )
				};
			

			parameters[ 0 ].Value = lunaId;
			parameters[ 1 ].Value = angajatId;
			parameters[ 2 ].Direction = ParameterDirection.Output;

			RunProcedure("spCalculNrZileConcediuLuateInAvans", parameters, "CO");

			nrZileCOefectuatInAvans = int.Parse(parameters[2].Value.ToString());
			
			return nrZileCOefectuatInAvans;
		}
		#endregion

		#region ReporteazaDiferentaCorectiiTichete
		/// <summary>
		/// Reporteaza corectiile de tichete daca este nevoie.
		/// (daca pe luna anterioara nrTichete + corectii mai mic ca 0, atunci corectii pe noua luna devin NrTicheteAnt + corectiiAnt)
		/// </summary>
		/// <param name="lunaId"> ID-ul lunii.</param>
		/// <param name="angajatId"> ID-ul angajatului.</param>
		public void ReporteazaDiferentaCorectiiTichete( int lunaId, long angajatId )
		{
			SqlParameter[] parameters = 
				{
					new SqlParameter( "@LunaID", SqlDbType.Int, 4 ),
					new SqlParameter( "@AngajatID", SqlDbType.Int, 4 )
				};
			

			parameters[ 0 ].Value = lunaId;
			parameters[ 1 ].Value = angajatId;

			RunProcedure("ReporteazaCorectiiTichete", parameters);
		}
		#endregion

		#region GetAllSituatiiLunareAngajatDataSet
		/// <summary>
		/// Procedura selecteaza situatiile lunare ale unui angajat
		/// </summary>
		/// <param name="AngajatID">Id-ul angajatului</param>
		/// <returns>Returneaza un DataSet aceste date</returns>
		public DataSet GetAllSituatiiLunareAngajatDataSet(long AngajatID)
		{
			SqlParameter[] parameters = 
				{
					new SqlParameter("@AngajatID", SqlDbType.Int, 4)
				};
			
			parameters[0].Value = AngajatID;
						
			return RunProcedure("sal_GetAllSituatiiLunareAngajat",parameters,"InfoSituatiiLunare");
		}
		#endregion


	}
}
