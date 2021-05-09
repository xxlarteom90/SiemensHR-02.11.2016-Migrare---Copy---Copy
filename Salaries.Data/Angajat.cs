/*
 * Modificat:	Oprescu Claudia
 * Data:		09.07.2007
 * Descriere:	Au fost adaugate campuri pentru Motivul de angajare si pentru Tipul de angajat.
 * 
 * Modificat:	Oprescu Claudia
 * Data:		12.07.2007
 * Descriere:	A fost adaugat camp pentru GID.
 * 
 * Modificat:	Oprescu Claudia
 * Data:		19.09.2007
 * Descriere:	Au fost adaugate campuri pentru PMP si AZM.
 * 
 *	Modificat:		Fratila Claudia
 *	Data:			29.11.2007
 *	Descriere:		A fost adaugat camp pentru Sanatate (specifica daca angajatul este scutit sau nu de contributia la sanatate).
 *					A fost adaugat camp pentru CAS (specifica daca angajatul este scutit sau nu de contributia la CAS).
 *  
 *	Modificat:		Andreea Lungu
 *	Data:			23.08.2010
 *	Descriere:		A fost adaugat camp pentru Birou 
 * 
 *  Modificat:		Andreea Lungu
 *	Data:			15.02.2011
 *	Descriere:		A fost adaugat camp pentru Somaj (specifica daca angajatul este scutit sau nu de contributia la sanatate).
 * 
 *  Modificat:		Manuel Neagoe
 *	Data:			29.01.2013
 *	Descriere:		A fost adaugat campul Tip Asigurat.
*/

using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections;

namespace Salaries.Data
{
	/// <summary>
	/// Summary description for Angajat.
	/// </summary>
	public class Angajat : Salaries.Data.DbObject
	{
		#region Angajat
		/// <summary>
		/// Constructorul cu string de conexiune
		/// </summary>
		/// <param name="connectionString">Stringul de conexiune la baza de date</param>
		public Angajat(string connectionString) : base (connectionString)
		{}
		#endregion

		#region LoadParametersIntoCommand
		private SqlParameter[] LoadParametersIntoCommand(
			long angajatId, int angajatorId, int punctLucruId, int casaDeAsigurariId,int motivDeAngajareId, int tipDeAngajatId,
			string marca, string gid,
			string nume, string prenume, string numeAnterior, DateTime dataSchimbariiNumelui,
			int titluId,
			string prenumeTata, string prenumeMama,
			int studiuId, int anAbsolvire, string nrDiploma,
			string descriere,
			byte modIncadrare,
			byte programLucru,
			string telefon,
			DateTime dataNasterii, int judetNastereId, int taraNastereId, string localitateNastere,
			byte stareCivila,
			byte nrCopii,
			string sex,
			int nationalitate,
			long cnp, string cnpAnterior,
			byte tipFisaFiscala,
			byte aniVechimeMunca, byte luniVechimeMunca, int zileVechimeMunca,
			byte areCardBancar,
			byte[] pozaAngajat,
			int functieCurentaId,
			int departamentCurentId,
			long sefId,
			string numeAngajator,
			bool perioadaDeterminata, DateTime dataPanaLa, DateTime dataDeLa,
			string nrContractMunca, DateTime dataInregContractMunca, 
			string echIndProtectie, string echIndLucru, string matIgiSan, string alimProtectie, string alteDrSiObl, string alteClauzeCIM,
			string perProba,
			short invaliditate,
			decimal salariuBaza, decimal indemnizatieConducere,
			decimal sporuri, decimal alteAdaosuri, decimal sumaMajorare, DateTime dataMajorare,
			int nrZileCOAn, int nrZileCOSupl,
			int categorieId,
			string email,string telMunca,
			bool isLichidat, bool isPensionat,
			string ciSerie, string ciNumar, string ciEliberatDe, DateTime ciDataEliberarii, DateTime ciValabilPanaLa,
			string pasSerie, string pasNumar, string pasEliberatDe, DateTime pasDataEliberarii, DateTime pasValabilPanaLa,
			DateTime permMuncaEliberat, DateTime permMuncaExpira, string seriePermisMunca, long nrPermisMunca,
			DateTime legitimatieSedereDataEliberare, DateTime legitimatieSedereDataExpirare, string serieLegitimatieSedere, string nrLegitimatieSedere,
			string nif,
			int tipNationalitateDomiciliu,
			int dTara, string dLocalitate, int dJudetSectorId, string dStrada, string dNumar, long dCodPostal, string dBloc, string dScara, string dEtaj, string dApartament,
			int rTara, string rLocalitate, int rJudetSectorId, string rStrada, string rNumar, long rCodPostal, string rBloc, string rScara, string rEtaj, string rApartament,
			string cmSerie, string cmNumar, string cmEmitent, DateTime cmDataEmiterii, string cmNrInregITM,
			string alerteSpeciale, 
			bool pmp, bool azm, bool retinereSanatate, bool retinereCAS, bool retinereSomaj,
			string birou,
			int tipAsiguratId
			)
		{ 
			SqlParameter[] parameters = 
							{
								new SqlParameter("@AngajatID", SqlDbType.Float, 4),
								new SqlParameter("@AngajatorID", SqlDbType.Int, 4),
								new SqlParameter("@PunctLucruID", SqlDbType.Int, 4),
								new SqlParameter("@CasaDeAsigurariID", SqlDbType.Int, 4),
								new SqlParameter("@MotivDeAngajareId", SqlDbType.Int, 4),
								new SqlParameter("@TipDeAngajatId", SqlDbType.Int, 4),
								new SqlParameter("@Marca", SqlDbType.NVarChar, 8),
								new SqlParameter("@Gid", SqlDbType.NVarChar, 8),
								new SqlParameter("@Nume", SqlDbType.NVarChar, 50),
								new SqlParameter("@Prenume", SqlDbType.NVarChar, 50),
								new SqlParameter("@NumeAnterior", SqlDbType.NVarChar, 50),
								new SqlParameter("@TitluID", SqlDbType.Int, 4),
								new SqlParameter("@Poza", SqlDbType.Image, 0),
								new SqlParameter("@PrenumeMama", SqlDbType.NVarChar, 50),
								new SqlParameter("@PrenumeTata", SqlDbType.NVarChar, 50),
								new SqlParameter("@StudiuID", SqlDbType.Int, 4),
								new SqlParameter("@AnAbsolvire", SqlDbType.Int, 4),
								new SqlParameter("@NrDiploma", SqlDbType.VarChar, 50),
								new SqlParameter("@Descriere", SqlDbType.NVarChar, 100),
								new SqlParameter("@ModIncadrare", SqlDbType.Bit, 1),
								new SqlParameter("@ProgramLucru", SqlDbType.TinyInt, 2),
								new SqlParameter("@Telefon", SqlDbType.NVarChar, 25),
								//data de pastere
								new SqlParameter("@DataNasterii", SqlDbType.DateTime, 8),
								new SqlParameter("@TaraNastereID", SqlDbType.Int, 4),
								new SqlParameter("@JudetNastereID", SqlDbType.Int, 4),
								new SqlParameter("@LocalitateNastere", SqlDbType.NVarChar, 50),
								new SqlParameter("@StareCivila", SqlDbType.TinyInt, 2),
								new SqlParameter("@NrCopii", SqlDbType.TinyInt, 2),
								new SqlParameter("@Sex", SqlDbType.Char, 1),
								new SqlParameter("@Nationalitate", SqlDbType.Int, 4),
								new SqlParameter("@TipFisaFiscala", SqlDbType.Bit, 1),
								//vechime in munca
								new SqlParameter("@AniVechimeMunca", SqlDbType.TinyInt, 4),
								new SqlParameter("@LuniVechimeMunca", SqlDbType.TinyInt, 4),
								new SqlParameter("@ZileVechimeMunca", SqlDbType.TinyInt, 4),
								new SqlParameter("@AreCardBancar", SqlDbType.Bit, 1),								
								//pentru perioada determinata
								new SqlParameter("@PerioadaDeterminata", SqlDbType.Bit, 1),
								new SqlParameter("@DataPanaLa", SqlDbType.DateTime, 8),
								new SqlParameter("@DataDeLa", SqlDbType.DateTime, 8),
								//pentru date despre lichidare
								new SqlParameter("@Lichidat", SqlDbType.Bit, 1),								
								//pentru date despre pensionare
								new SqlParameter("@Pensionat", SqlDbType.Bit, 1),			
								//pentru contract munca
								new SqlParameter("@NrContractMunca", SqlDbType.VarChar, 50),
								new SqlParameter("@DataInregContractMunca", SqlDbType.DateTime,8),
								new SqlParameter("@EchIndProtectie", SqlDbType.NVarChar,100),
								new SqlParameter("@EchIndLucru", SqlDbType.NVarChar,100),
								new SqlParameter("@MatIgiSan", SqlDbType.NVarChar,100),
								new SqlParameter("@AlimProtectie", SqlDbType.NVarChar,100),
								new SqlParameter("@AlteDrSiObl", SqlDbType.NVarChar,100),
								new SqlParameter("@AlteClauzeCIM", SqlDbType.NVarChar,100),
								new SqlParameter("@PerProba", SqlDbType.NVarChar,50),								
								//pt invaliditate
								new SqlParameter("@Invaliditate", SqlDbType.SmallInt,2),
								//pt salariu+indemnizatie de conducere
								new SqlParameter("@FunctieID", SqlDbType.Int,4),
								new SqlParameter("@DepartamentID", SqlDbType.Int,4),
								new SqlParameter("@SalariuBaza", SqlDbType.Money,8),
								new SqlParameter("@IndemnizatieConducere", SqlDbType.Money,8),
								new SqlParameter("@Sporuri", SqlDbType.Money,8),
								new SqlParameter("@AlteAdaosuri", SqlDbType.Money,8),
								//pentru majorare
								new SqlParameter("@SumaMajorare", SqlDbType.Money,8),
								new SqlParameter("@DataMajorare", SqlDbType.DateTime,8),			
								//pentru nr de zile de CO pe an
								new SqlParameter("@NrZileCOAn", SqlDbType.Int,4),
								new SqlParameter("@NrZileCOSupl", SqlDbType.Int,4),
								//pentru sef
								new SqlParameter("@SefID", SqlDbType.Int, 4),
								//pentru buletin
								new SqlParameter("@CNP", SqlDbType.BigInt, 9),
								new SqlParameter("@CNPAnterior", SqlDbType.NVarChar, 50),
								new SqlParameter("@SerieCI", SqlDbType.Char, 2),
								new SqlParameter("@NumarCI", SqlDbType.NVarChar, 20),
								new SqlParameter("@EliberatDeCI", SqlDbType.NVarChar, 50),
								new SqlParameter("@DataEliberariiCI", SqlDbType.DateTime, 8),
								new SqlParameter("@ValabilPanaLaCI", SqlDbType.DateTime, 8),								
								//pentru pasaport
								new SqlParameter("@SeriePas", SqlDbType.NVarChar, 10),
								new SqlParameter("@NumarPas", SqlDbType.NVarChar, 20),
								new SqlParameter("@EliberatDePas", SqlDbType.NVarChar, 50),
								new SqlParameter("@DataEliberariiPas", SqlDbType.DateTime, 8),
								new SqlParameter("@ValabilPanaLaPas", SqlDbType.DateTime, 8),
								//pentru permis munca
								new SqlParameter("@DataEliberarePermisMunca", SqlDbType.DateTime, 8),
								new SqlParameter("@DataExpirarePermisMunca", SqlDbType.DateTime, 8),
								new SqlParameter("@NrPermisMunca", SqlDbType.BigInt,10),
								new SqlParameter("@SeriePermisMunca", SqlDbType.NVarChar,10),
								//pentru legitimatie sedere
								new SqlParameter("@DataEliberareLegitimatieSedere", SqlDbType.DateTime, 8),
								new SqlParameter("@DataExpirareLegitimatieSedere", SqlDbType.DateTime, 8),
								new SqlParameter("@NrLegitimatieSedere", SqlDbType.NVarChar,50),
								new SqlParameter("@SerieLegitimatieSedere", SqlDbType.NVarChar,10),
								//pentru nif
								new SqlParameter("@NIF", SqlDbType.NVarChar, 50),
								new SqlParameter("@TipNationalitateDomiciliu", SqlDbType.SmallInt, 2),								
								//pentru domiciliu
								new SqlParameter("@TaraID", SqlDbType.Int, 4),
								new SqlParameter("@Localitate", SqlDbType.NVarChar, 50),
								new SqlParameter("@JudetSectorID", SqlDbType.Int, 4),
								new SqlParameter("@Strada", SqlDbType.NVarChar, 50),
								new SqlParameter("@NumarStr", SqlDbType.NVarChar, 10),
								new SqlParameter("@CodPostal", SqlDbType.BigInt, 9),
								new SqlParameter("@Bloc", SqlDbType.NVarChar, 32),
								new SqlParameter("@Scara", SqlDbType.NVarChar, 5),
								new SqlParameter("@Etaj", SqlDbType.NVarChar, 5),
								new SqlParameter("@Apartament", SqlDbType.NVarChar, 5),
								//pentru resedinta
								new SqlParameter("@TaraIDRes", SqlDbType.Int, 4),
								new SqlParameter("@LocalitateRes", SqlDbType.NVarChar, 50),
								new SqlParameter("@JudetSectorIDRes", SqlDbType.Int, 4),
								new SqlParameter("@StradaRes", SqlDbType.NVarChar, 50),
								new SqlParameter("@NumarStrRes", SqlDbType.NVarChar, 10),
								new SqlParameter("@CodPostalRes", SqlDbType.BigInt, 9),
								new SqlParameter("@BlocRes", SqlDbType.NVarChar, 32),
								new SqlParameter("@ScaraRes", SqlDbType.NVarChar, 5),
								new SqlParameter("@EtajRes", SqlDbType.NVarChar, 5),
								new SqlParameter("@ApartamentRes", SqlDbType.NVarChar, 5),
								new SqlParameter("@Serie", SqlDbType.NVarChar, 5),
								new SqlParameter("@Numar", SqlDbType.NVarChar, 10),
								new SqlParameter("@Emitent", SqlDbType.NVarChar, 50),
								new SqlParameter("@DataEmiterii", SqlDbType.DateTime, 8),
								new SqlParameter("@NrInregITM", SqlDbType.NVarChar, 25),
								new SqlParameter("@CategorieID",SqlDbType.Int,4),
								//date contact
								new SqlParameter("@Email", SqlDbType.NVarChar, 255),
								new SqlParameter("@TelMunca", SqlDbType.NVarChar, 255),
								//pentru alerte speciale
								new SqlParameter("@AlerteSpeciale", SqlDbType.NVarChar, 255),
								new SqlParameter("@PMP", SqlDbType.Bit, 1),
								new SqlParameter("@AZM", SqlDbType.Bit, 1),
								new SqlParameter("@RetinereSanatate", SqlDbType.Bit, 1),
								new SqlParameter("@RetinereCAS", SqlDbType.Bit, 1),
								new SqlParameter("@Birou", SqlDbType.NVarChar, 50),
								new SqlParameter("@DataSchimbariiNumelui", SqlDbType.DateTime, 8),
								new SqlParameter("@RetinereSomaj", SqlDbType.Bit, 1),
								new SqlParameter("@TipAsiguratID", SqlDbType.Int, 4),
								//id-ul noului angajat
								new SqlParameter("@new_id", SqlDbType.Int, 4)
							};

			//angajatId
			parameters[0].Value = angajatId;
			parameters[1].Value = angajatorId;
			parameters[2].Value = punctLucruId;
			parameters[3].Value = casaDeAsigurariId;
			parameters[4].Value = motivDeAngajareId;
			parameters[5].Value = tipDeAngajatId;
			parameters[6].Value = marca;
			parameters[7].Value = gid;
			//nume, prenume
			parameters[8].Value = nume;
			parameters[9].Value = prenume;
			parameters[10].Value = numeAnterior;
			//titlu
			parameters[11].Value = titluId;
			//poza angajat
			if (pozaAngajat!=null)
			{
				parameters[12].Size = pozaAngajat.Length;
				parameters[12].Value = pozaAngajat;
			}
			else
			{
				parameters[12].Value = System.DBNull.Value;
			}
			//parinti
			parameters[13].Value = prenumeMama;
			parameters[14].Value = prenumeTata;
			parameters[15].Value = studiuId;
			parameters[16].Value = anAbsolvire;
			parameters[17].Value = nrDiploma;
			parameters[18].Value = descriere;
			parameters[19].Value = modIncadrare;
			parameters[20].Value = programLucru;
			parameters[21].Value = telefon;
			//data nasterii
			parameters[22].Value = dataNasterii;
			parameters[23].Value = taraNastereId;
			parameters[24].Value = judetNastereId;
			parameters[25].Value = localitateNastere;
			parameters[26].Value = stareCivila;
			parameters[27].Value = nrCopii;
			parameters[28].Value = sex;
			parameters[29].Value = nationalitate;
			parameters[30].Value = tipFisaFiscala;		
			//vechime
			parameters[31].Value = aniVechimeMunca;
			parameters[32].Value = luniVechimeMunca;
			parameters[33].Value = zileVechimeMunca;
			parameters[34].Value = areCardBancar;
			//data angajare
			parameters[35].Value = perioadaDeterminata;
			if(dataPanaLa == DateTime.MinValue)
			{
				parameters[36].Value = System.DBNull.Value;
			}
			else
			{
				parameters[36].Value = dataPanaLa;
			}
			if(dataDeLa == DateTime.MinValue)
			{
				parameters[37].Value = System.DBNull.Value;
			}
			else
			{
				parameters[37].Value = dataDeLa;
			}
			//lichidat
			parameters[38].Value = isLichidat;
			//pensionat
			parameters[39].Value = isPensionat;
			//contract munca
			parameters[40].Value = nrContractMunca;
			if(dataInregContractMunca == DateTime.MinValue)
			{
				parameters[41].Value = System.DBNull.Value;
			}
			else
			{
				parameters[41].Value = dataInregContractMunca;
			}
			//echipamete
			parameters[42].Value = echIndProtectie;
			parameters[43].Value = echIndLucru;
			parameters[44].Value = matIgiSan;
			parameters[45].Value = alimProtectie;
			parameters[46].Value = alteDrSiObl;
			parameters[47].Value = alteClauzeCIM;
			parameters[48].Value = perProba;
			parameters[49].Value = invaliditate;
			parameters[50].Value = functieCurentaId;
			parameters[51].Value = departamentCurentId;
			//sume
			parameters[52].Value = salariuBaza;
			parameters[53].Value = indemnizatieConducere;
			parameters[54].Value = sporuri;
			parameters[55].Value = alteAdaosuri;
			if(dataMajorare == DateTime.MinValue)
			{
				parameters[56].Value = System.DBNull.Value;
				parameters[57].Value = System.DBNull.Value;
			}
			else
			{
				parameters[56].Value = sumaMajorare;
				parameters[57].Value = dataMajorare;
			}
			//zile CO
			parameters[58].Value = nrZileCOAn;
			parameters[59].Value = nrZileCOSupl;
			//sef
			parameters[60].Value = sefId;
			//CNP
			parameters[61].Value = cnp;
			parameters[62].Value = cnpAnterior;
			//CI
			parameters[63].Value = ciSerie;
			parameters[64].Value = ciNumar;
			parameters[65].Value = ciEliberatDe;
			if(ciDataEliberarii == DateTime.MinValue)
			{
				parameters[66].Value = System.DBNull.Value;
			}
			else
			{
				parameters[66].Value = ciDataEliberarii;
			}
			if(ciValabilPanaLa == DateTime.MinValue)
			{
				parameters[67].Value = System.DBNull.Value;
			}
			else
			{
				parameters[67].Value = ciValabilPanaLa;
			}
			//pasaport
			parameters[68].Value = pasSerie;
			parameters[69].Value = pasNumar;
			parameters[70].Value = pasEliberatDe;
			if(pasDataEliberarii == DateTime.MinValue)
			{
				parameters[71].Value = System.DBNull.Value;
			}
			else
			{
				parameters[71].Value = pasDataEliberarii;
			}
			if(pasValabilPanaLa == DateTime.MinValue)
			{
				parameters[72].Value = System.DBNull.Value;
			}
			else
			{
				parameters[72].Value = pasValabilPanaLa;
			}
			if(permMuncaEliberat == DateTime.MinValue)
			{
				parameters[73].Value = System.DBNull.Value;
			}
			else
			{
				parameters[73].Value =  permMuncaEliberat;
			}
			if(permMuncaExpira == DateTime.MinValue)
			{
				parameters[74].Value = System.DBNull.Value;
			}
			else
			{
				parameters[74].Value = permMuncaExpira;
			}
			parameters[75].Value = nrPermisMunca;
			parameters[76].Value = seriePermisMunca;
			//legitimatie sedere
			if(legitimatieSedereDataEliberare == DateTime.MinValue)
			{
				parameters[77].Value = System.DBNull.Value;
			}
			else
			{
				parameters[77].Value = legitimatieSedereDataEliberare;
			}
			if(legitimatieSedereDataExpirare == DateTime.MinValue)
			{
				parameters[78].Value = System.DBNull.Value;
			}
			else
			{
				parameters[78].Value = legitimatieSedereDataExpirare;
			}
			parameters[79].Value = nrLegitimatieSedere;
			parameters[80].Value = serieLegitimatieSedere;
			//nif
			parameters[81].Value = nif;
			parameters[82].Value = tipNationalitateDomiciliu;
			//domiciliu
			parameters[83].Value = dTara;
			parameters[84].Value = dLocalitate;
			parameters[85].Value = dJudetSectorId;
			parameters[86].Value = dStrada;
			parameters[87].Value = dNumar;
			parameters[88].Value = dCodPostal;
			parameters[89].Value = dBloc;
			parameters[90].Value = dScara;
			parameters[91].Value = dEtaj;
			parameters[92].Value = dApartament;
			//resedinta
			parameters[93].Value = rTara;
			parameters[94].Value = rLocalitate;
			parameters[95].Value = rJudetSectorId;
			parameters[96].Value = rStrada;
			parameters[97].Value = rNumar;
			parameters[98].Value = rCodPostal;
			parameters[99].Value = rBloc;
			parameters[100].Value = rScara;
			parameters[101].Value = rEtaj;
			parameters[102].Value = rApartament;
			//contract de munca
			parameters[103].Value = cmSerie;
			parameters[104].Value = cmNumar;
			parameters[105].Value = cmEmitent;
			if(cmDataEmiterii == DateTime.MinValue)
			{
				parameters[106].Value = System.DBNull.Value;
			}
			else
			{
				parameters[106].Value = cmDataEmiterii;
			}
			parameters[107].Value = cmNrInregITM;
			parameters[108].Value = categorieId;
			parameters[109].Value = email;
			parameters[110].Value = telMunca;				
			parameters[111].Value = alerteSpeciale;
			parameters[112].Value = pmp;
			parameters[113].Value = azm;
			parameters[114].Value = retinereSanatate;
			parameters[115].Value = retinereCAS;
			parameters[116].Value = birou;
			if(dataSchimbariiNumelui == DateTime.MinValue)
			{
				parameters[117].Value = System.DBNull.Value;
			}
			else
			{
				parameters[117].Value = dataSchimbariiNumelui;
			}
			parameters[118].Value = retinereSomaj;
			parameters[119].Value = tipAsiguratId;
			parameters[120].Direction = ParameterDirection.Output;

			return parameters;
		}
		#endregion

		#region InsertAngajat
		/// <summary>
		/// Procedura adauga un angajat
		/// </summary>
		public long InsertAngajat(
			long angajatId, int angajatorId, int punctLucruId, int casaDeAsigurariId, int motivDeAngajareId, int tipDeAngajatId,
			string marca, string gid,
			string nume, string prenume, string numeAnterior, DateTime dataSchimbariiNumelui,
			int titluId,
			string prenumeTata, string prenumeMama,
			int studiuId, int anAbsolvire, string nrDiploma,
			string descriere,
			byte modIncadrare,
			byte programLucru,
			string telefon,
			DateTime dataNasterii, int judetNastereId, int taraNastereId, string localitateNastere,
			byte stareCivila,
			byte nrCopii,
			string sex,
			int nationalitate,
			long cnp, string cnpAnterior,
			byte tipFisaFiscala,
			byte aniVechimeMunca, byte luniVechimeMunca, int zileVechimeMunca,
			byte areCardBancar,
			byte[] pozaAngajat,
			int functieCurentaId,
			int departamentCurentId,
			long sefId,
			string numeAngajator,
			bool perioadaDeterminata, DateTime dataPanaLa, DateTime dataDeLa,
			string nrContractMunca, DateTime dataInregContractMunca, 
			string echIndProtectie, string echIndLucru, string matIgiSan, string alimProtectie, string alteDrSiObl, string alteClauzeCIM,
			string perProba,
			short invaliditate,
			decimal salariuBaza, decimal indemnizatieConducere,
			decimal sporuri, decimal alteAdaosuri, decimal sumaMajorare, DateTime dataMajorare,
			int nrZileCOAn, int nrZileCOSupl,
			int categorieId,
			string email,string telMunca,
			bool isLichidat, bool isPensionat,
			string ciSerie, string ciNumar, string ciEliberatDe, DateTime ciDataEliberarii, DateTime ciValabilPanaLa,
			string pasSerie, string pasNumar, string pasEliberatDe, DateTime pasDataEliberarii, DateTime pasValabilPanaLa,
			DateTime permMuncaEliberat, DateTime permMuncaExpira, string seriePermisMunca, long nrPermisMunca,
			DateTime legitimatieSedereDataEliberare, DateTime legitimatieSedereDataExpirare, string serieLegitimatieSedere, string nrLegitimatieSedere,
			string nif,
			int tipNationalitateDomiciliu,
			int dTara, string dLocalitate, int dJudetSectorId, string dStrada, string dNumar, long dCodPostal, string dBloc, string dScara, string dEtaj, string dApartament,
			int rTara, string rLocalitate, int rJudetSectorId, string rStrada, string rNumar, long rCodPostal, string rBloc, string rScara, string rEtaj, string rApartament,
			string cmSerie, string cmNumar, string cmEmitent, DateTime cmDataEmiterii, string cmNrInregITM,
			string alerteSpeciale,
			bool pmp, bool azm, bool retinereSanatate, bool retinereCAS, bool retinereSomaj,
			string birou,
			int tipAsiguratId
			)
		{
			SqlParameter[] parameters = LoadParametersIntoCommand(
							angajatId,  angajatorId,  punctLucruId,  casaDeAsigurariId, motivDeAngajareId, tipDeAngajatId,
							marca, gid,
							nume,  prenume,  numeAnterior, dataSchimbariiNumelui,
							titluId,
							prenumeTata,  prenumeMama,
							studiuId,  anAbsolvire,  nrDiploma,
							descriere,
							modIncadrare,
							programLucru,
							telefon,
							dataNasterii,  judetNastereId,  taraNastereId,  localitateNastere,
							stareCivila,
							nrCopii,
							sex,
							nationalitate,
							cnp,  cnpAnterior,
							tipFisaFiscala,
							aniVechimeMunca,  luniVechimeMunca,  zileVechimeMunca,
							areCardBancar,
							pozaAngajat,
							functieCurentaId,
							departamentCurentId,
							sefId,
							numeAngajator,
							perioadaDeterminata,  dataPanaLa,  dataDeLa,
							nrContractMunca,  dataInregContractMunca, 
							echIndProtectie,  echIndLucru,  matIgiSan,  alimProtectie,  alteDrSiObl,  alteClauzeCIM,
							perProba,
							invaliditate,
							salariuBaza,  indemnizatieConducere,
							sporuri,  alteAdaosuri,  sumaMajorare,  dataMajorare,
							nrZileCOAn,  nrZileCOSupl,
							categorieId,
							email, telMunca,
							isLichidat,  isPensionat,
							ciSerie,  ciNumar,  ciEliberatDe,  ciDataEliberarii,  ciValabilPanaLa,
							pasSerie,  pasNumar,  pasEliberatDe,  pasDataEliberarii,  pasValabilPanaLa,
							permMuncaEliberat,  permMuncaExpira,  seriePermisMunca,  nrPermisMunca,
							legitimatieSedereDataEliberare,  legitimatieSedereDataExpirare,  serieLegitimatieSedere,  nrLegitimatieSedere,
							nif,
							tipNationalitateDomiciliu,
							dTara,  dLocalitate,  dJudetSectorId,  dStrada,  dNumar,  dCodPostal,  dBloc,  dScara,  dEtaj,  dApartament,
							rTara,  rLocalitate,  rJudetSectorId,  rStrada,  rNumar,  rCodPostal,  rBloc,  rScara,  rEtaj,  rApartament,
							cmSerie,  cmNumar,  cmEmitent,  cmDataEmiterii,  cmNrInregITM,
							alerteSpeciale, pmp, azm, retinereSanatate, retinereCAS, retinereSomaj,
							birou, tipAsiguratId
				);
			RunProcedure("tmp_InsertUpdateAngajat_010205", parameters);
			return Convert.ToInt64(parameters[120].Value.ToString());
		}

		#endregion

		#region UpdateAngajat
		/// <summary>
		/// Procedura actualizeaza un angajat
		/// </summary>
		public void UpdateAngajat(
			long angajatId, int angajatorId, int punctLucruId, int casaDeAsigurariId, int motivDeAngajareId, int tipDeAngajatId,
			string marca, string gid,
			string nume, string prenume, string numeAnterior, DateTime dataSchimbariiNumelui,
			int titluId,
			string prenumeTata, string prenumeMama,
			int studiuId, int anAbsolvire, string nrDiploma,
			string descriere,
			byte modIncadrare,
			byte programLucru,
			string telefon,
			DateTime dataNasterii, int judetNastereId, int taraNastereId, string localitateNastere,
			byte stareCivila,
			byte nrCopii,
			string sex,
			int nationalitate,
			long cnp, string cnpAnterior,
			byte tipFisaFiscala,
			byte aniVechimeMunca, byte luniVechimeMunca, int zileVechimeMunca,
			byte areCardBancar,
			byte[] pozaAngajat,
			int functieCurentaId,
			int departamentCurentId,
			long sefId,
			string numeAngajator,
			bool perioadaDeterminata, DateTime dataPanaLa, DateTime dataDeLa,
			string nrContractMunca, DateTime dataInregContractMunca, 
			string echIndProtectie, string echIndLucru, string matIgiSan, string alimProtectie, string alteDrSiObl, string alteClauzeCIM,
			string perProba,
			short invaliditate,
			decimal salariuBaza, decimal indemnizatieConducere,
			decimal sporuri, decimal alteAdaosuri, decimal sumaMajorare, DateTime dataMajorare,
			int nrZileCOAn, int nrZileCOSupl,
			int categorieId,
			string email,string telMunca,
			bool isLichidat, bool isPensionat,
			string ciSerie, string ciNumar, string ciEliberatDe, DateTime ciDataEliberarii, DateTime ciValabilPanaLa,
			string pasSerie, string pasNumar, string pasEliberatDe, DateTime pasDataEliberarii, DateTime pasValabilPanaLa,
			DateTime permMuncaEliberat, DateTime permMuncaExpira, string seriePermisMunca, long nrPermisMunca,
			DateTime legitimatieSedereDataEliberare, DateTime legitimatieSedereDataExpirare, string serieLegitimatieSedere, string nrLegitimatieSedere,
			string nif,
			int tipNationalitateDomiciliu,
			int dTara, string dLocalitate, int dJudetSectorId, string dStrada, string dNumar, long dCodPostal, string dBloc, string dScara, string dEtaj, string dApartament,
			int rTara, string rLocalitate, int rJudetSectorId, string rStrada, string rNumar, long rCodPostal, string rBloc, string rScara, string rEtaj, string rApartament,
			string cmSerie, string cmNumar, string cmEmitent, DateTime cmDataEmiterii, string cmNrInregITM,
			string alerteSpeciale,
			bool pmp, bool azm, bool retinereSanatate, bool retinereCAS, bool retinereSomaj,
			string birou, int tipAsiguratID
			)
		{
			SqlParameter[] parameters = LoadParametersIntoCommand(
				angajatId,  angajatorId,  punctLucruId,  casaDeAsigurariId, motivDeAngajareId, tipDeAngajatId,
				marca, gid,
				nume,  prenume,  numeAnterior, dataSchimbariiNumelui,
				titluId,
				prenumeTata,  prenumeMama,
				studiuId,  anAbsolvire,  nrDiploma,
				descriere,
				modIncadrare,
				programLucru,
				telefon,
				dataNasterii,  judetNastereId,  taraNastereId,  localitateNastere,
				stareCivila,
				nrCopii,
				sex,
				nationalitate,
				cnp,  cnpAnterior,
				tipFisaFiscala,
				aniVechimeMunca,  luniVechimeMunca,  zileVechimeMunca,
				areCardBancar,
				pozaAngajat,
				functieCurentaId,
				departamentCurentId,
				sefId,
				numeAngajator,
				perioadaDeterminata,  dataPanaLa,  dataDeLa,
				nrContractMunca,  dataInregContractMunca, 
				echIndProtectie,  echIndLucru,  matIgiSan,  alimProtectie,  alteDrSiObl,  alteClauzeCIM,
				perProba,
				invaliditate,
				salariuBaza,  indemnizatieConducere,
				sporuri,  alteAdaosuri,  sumaMajorare,  dataMajorare,
				nrZileCOAn,  nrZileCOSupl,
				categorieId,
				email, telMunca,
				isLichidat,  isPensionat,
				ciSerie,  ciNumar,  ciEliberatDe,  ciDataEliberarii,  ciValabilPanaLa,
				pasSerie,  pasNumar,  pasEliberatDe,  pasDataEliberarii,  pasValabilPanaLa,
				permMuncaEliberat,  permMuncaExpira,  seriePermisMunca,  nrPermisMunca,
				legitimatieSedereDataEliberare,  legitimatieSedereDataExpirare,  serieLegitimatieSedere,  nrLegitimatieSedere,
				nif,
				tipNationalitateDomiciliu,
				dTara,  dLocalitate,  dJudetSectorId,  dStrada,  dNumar,  dCodPostal,  dBloc,  dScara,  dEtaj,  dApartament,
				rTara,  rLocalitate,  rJudetSectorId,  rStrada,  rNumar,  rCodPostal,  rBloc,  rScara,  rEtaj,  rApartament,
				cmSerie,  cmNumar,  cmEmitent,  cmDataEmiterii,  cmNrInregITM,
				alerteSpeciale, pmp, azm, retinereSanatate, retinereCAS, retinereSomaj,
				birou, tipAsiguratID
			);
			RunProcedure("tmp_InsertUpdateAngajat_010205", parameters);
		}
		#endregion

		#region CheckDateAngajat
		/// <summary>
		///Cristina Muntean
		///de exp: daca sunt doi angajati cu aceeasi marca returneaza false, altfel returneaza true
		/// </summary>
		/// <param name="angajatorId">Id-ul angajatorului</param>
		/// <param name="marca">Marca angajatului</param>
		/// <param name="gid">Gid-ul angajatului</param>
		/// <returns>Returneaza rezultatul verificarii: 
		/// 1 daca marca mai exista
		/// 2 daca gid mai exista
		/// 0 daca datele sunt corecte
		/// </returns>
		/// Artiom Petrachi am adaugat verificare si dupa CNP daca exista in Db sa nu mai poata fi adaugat
		public int CheckDateAngajat(int angajatorId, string marca, string gid, long cnp)
		{
			SqlParameter[] parameters = 
							{
								new SqlParameter("@AngajatorID", SqlDbType.Int, 4),
								new SqlParameter("@Marca", SqlDbType.NVarChar, 8),
								new SqlParameter("@Gid", SqlDbType.NVarChar, 8),
								new SqlParameter("@Cnp", SqlDbType.Int, 16),
								new SqlParameter("@NuExista", SqlDbType.Int, 0)
							};
			
			parameters[0].Value = angajatorId;
			parameters[1].Value = marca;
			parameters[2].Value = gid;
			parameters[3].Value = Convert.ToInt64(cnp.ToString());
			parameters[4].Direction = ParameterDirection.Output;

			RunProcedure("CheckDateAngajat", parameters);
			return int.Parse(parameters[4].Value.ToString());
		}
		#endregion

		#region CheckDateAngajatForUpdate
		/// <summary>
		/// Cristina Muntean
		/// Daca sunt mai sunt si alti angajati cu aceasta marca in afara de cel in cauza returneaza false, altfel returneaza true
		/// </summary>
		/// <param name="angajatorId">Id-ul angajatorului</param>
		/// <param name="angajatId">Id-ul angajatului</param>
		/// <param name="marca">Marca angajatului</param>
		/// <param name="gid">Gid-ul angajatului</param>
		/// <returns>Returneaza rezultatul verificarii: 
		/// 1 daca marca mai exista
		/// 2 daca gid mai exista
		/// 0 daca datele sunt corecte
		/// </returns>
		public int CheckDateAngajatForUpdate(int angajatorId, long angajatId, string marca, string gid)
		{
			SqlParameter[] parameters = 
							{
								new SqlParameter("@AngajatorID", SqlDbType.Int, 4),
								new SqlParameter("@AngajatID", SqlDbType.Int, 4),
								new SqlParameter("@Marca", SqlDbType.NVarChar, 8),
								new SqlParameter("@Gid", SqlDbType.NVarChar, 8),
								new SqlParameter("@NuExista", SqlDbType.Int, 0)
							};
			
			parameters[0].Value = angajatorId;
			parameters[1].Value = angajatId;
			parameters[2].Value = marca;
			parameters[3].Value = gid;
			parameters[4].Direction = ParameterDirection.Output;

			RunProcedure("CheckDateAngajatForUpdate", parameters);
			return int.Parse(parameters[4].Value.ToString());
		}
		#endregion

		#region GetVechimeInMuncaAngajatorCurr
		/// <summary>
		/// Procedura determina vechimea in munca a unui angajat la angajatorul curent
		/// </summary>
		/// <param name="angajatId">Id-ul angajatului</param>
		/// <returns>Returneaza un DataSet care contine aceste date</returns>
		public DataSet GetVechimeInMuncaAngajatorCurr(long angajatId)
		{
			SqlParameter[] parameters = 
							{
								new SqlParameter("@AngajatID", SqlDbType.Int, 4),
								new SqlParameter("@Curr", SqlDbType.Bit, 4)
							};
			
			parameters[0].Value = angajatId;
			parameters[1].Value = 1;

			return RunProcedure("GetAngajatVechimeInMunca", parameters, "GetAngajatVechimeInMunca");
		}
		#endregion

		#region GetVechimeInMuncaPerTotal
		/// <summary>
		/// Procedura determina vechimea in munca a unui angajat
		/// </summary>
		/// <param name="angajatId">Id-ul angajatului</param>
		/// <returns>Returneaza un DataSet care contine aceste date</returns>
		public DataSet GetVechimeInMuncaPerTotal(long angajatId)
		{
			SqlParameter[] parameters = 
							{
								new SqlParameter("@AngajatID", SqlDbType.Int, 4),
								new SqlParameter("@Curr", SqlDbType.Bit, 4)
							};
			
			parameters[0].Value = angajatId;
			parameters[1].Value = 0;

			return RunProcedure("GetAngajatVechimeInMunca", parameters, "GetAngajatVechimeInMunca");
		}
		#endregion

		#region GetAllAngajati
		/// <summary>
		/// Procedura selecteaza toti angajatii care apartin unei anumite categorii
		/// </summary>
		/// <param name="categorieId">Id-ul categoriei de angajati</param>
		/// <param name="angajatorId">Id-ul angajatorului</param>
		/// <returns>Returneaza un DataSet care contine aceste date</returns>
		public DataSet GetAllAngajati(int categorieId, long angajatorId)
		{
			SqlParameter[] parameters = 
							{
								new SqlParameter("@CategorieID", SqlDbType.Int, 4),
								new SqlParameter("@AngajatorID", SqlDbType.Int, 4)
							};
			
			parameters[0].Value = categorieId;
			parameters[1].Value = angajatorId;

			return RunProcedure("GetAllAngajati", parameters, "GetAllAngajati");
		}
		#endregion

		#region GetAngajatIDAll
		/// <summary>
		/// Metoda este folosita pentru a obtine id-urile tuturor angajatilor
		/// </summary>
		/// <returns>Returneaza un DataSet care contine aceste valori</returns>
		public DataSet GetAngajatIDAll()
		{
			SqlParameter[] parameters = {};
			return RunProcedure("spGetAngajatIDAll", parameters, "GetAngajatIDAll");
		}
		#endregion

		#region GetAllAngajatiDinLuna
		/// <summary>
		/// Added:       Cristina Raluca Muntean
		/// Date:        13.09.2005
		/// Description: Returneaza toti angajatii care apartin de un angajator si care au avut contract in luna trimisa ca parametru
		/// </summary>
		/// <param name="lunaId">Id-ul lunii pentru care se selecteaza angajati</param>
		/// <param name="angajatorId">Id-ul angajatorului</param>
		/// <returns>Returneaza un DataSet care contine aceste date</returns>
		public DataSet GetAllAngajatiDinLuna(int lunaId, int angajatorId)
		{
			SqlParameter[] parameters = 
							{
								new SqlParameter("@LunaID", SqlDbType.Int, 4),
								new SqlParameter("@AngajatorID", SqlDbType.Int, 4)
							};
			
			parameters[0].Value = lunaId;
			parameters[1].Value = angajatorId;

			return RunProcedure("GetAllAngajatiDinLuna", parameters, "GetAllAngajatiDinLuna");
		}
		#endregion

		#region GetAllAngajatiLichidati
		/// <summary>
		/// Procedura selecteaza toti angajatii lichidati
		/// </summary>
		/// <param name="angajatorId">Id-ul angajatorului</param>
		/// <returns>Returneaza un DataSet care contine aceste date</returns>
		public DataSet GetAllAngajatiLichidati(long angajatorId, int lunaCurenta)
		{
			SqlParameter[] parameters = 
							{
								new SqlParameter("@angajatorID", SqlDbType.Int, 4),
								new SqlParameter("@lunaCurenta", SqlDbType.Int, 4)
							};
			
			parameters[0].Value = angajatorId;
			parameters[1].Value = lunaCurenta;

			return RunProcedure("GetAllAngajatiLichidati", parameters, "GetAllAngajatiLichidati");
		}
		#endregion

		#region GetNormaAngajat
		/// <summary>
		/// Procedura determina norma unui angajat
		/// </summary>
		/// <param name="angajatId">Id-ul angajatului</param>
		/// <returns>Returneaza valoarea normei</returns>
		public int GetNormaAngajat(long angajatId)
		{
			SqlParameter[] parameters = 
							{
								new SqlParameter("@AngajatID", SqlDbType.Int, 4)
							};
			parameters[0].Value = angajatId;
			DataSet ds = RunProcedure("GetAngajat", parameters, "GetAngajat");
			return int.Parse(ds.Tables[ 0 ].Rows[ 0 ][ "ProgramLucru" ].ToString());
		}
		#endregion

		#region LoadAngajat
		/// <summary>
		/// Procedura incarca datele unui angajat
		/// </summary>
		/// <param name="angajatId">Id-ul angajatului pentru care se selecteaza datele</param>
		/// <returns>Returneaza un DataSet care contine datele despre angajat</returns>
        //public DataSet LoadAngajat(long angajatId)
        //{
        //    SqlParameter[] parameters = { };

        //   // DataSet ds = RunProcedure("GetAngajatInfo", parameters, "GetAngajatInfo");
        //    parameters[0].Value = angajatId;
        //    return RunProcedure("GetAngajatInfo", parameters, "GetAngajatInfo");

        //}





        public DataSet LoadAngajat(long angajatId)
        {
            SqlParameter[] parameters = { new SqlParameter("@AngajatID", SqlDbType.BigInt, 8) };
            //angajatId = Convert.ToInt64(("AngajatID").ToString());
            parameters[0].Value = angajatId;
            
          
            return RunProcedure("GetAngajatInfo", parameters, "GetAngajatInfo");

        }
		
		#endregion

		#region LoadPozaAngajat
		/// <summary>
		/// Procedura selecteaza poza unui angajat
		/// </summary>
		/// <param name="angajatId">Id-ul angajatului pentru care se obtin datele</param>
		/// <returns>Returneaza un obiect care contine poza angajatului</returns>
		public object LoadPozaAngajat(long angajatId)
		{	
			SqlParameter[] parameters = 
							{
								new SqlParameter("@AngajatID", SqlDbType.Int, 4)
							};
			parameters[0].Value = angajatId;
			DataSet ds = RunProcedure("spGetPozaAngajat", parameters, "GetPozaAngajat");

			object obj = ds.Tables[0].Rows[0][0];

			if (obj!=System.DBNull.Value)
				return obj;
			else
				return null;
		}
		#endregion

		#region SetetazaAngajatiLunaInactivi
		/// <summary>
		/// Procedura seteaza angajatii din luna inactivi
		/// </summary>
		/// <param name="angajatorId">Id-ul angajatorului</param>
		/// <param name="data">Luna pentru case se modifica angajatii</param>
		public void SetetazaAngajatiLunaInactivi(int angajatorId, DateTime data)
		{
			SqlParameter[] parameters = 
							{
								new SqlParameter("@Data", SqlDbType.DateTime, 8),
								new SqlParameter("@AngajatorID", SqlDbType.Int, 4)
							};
			parameters[0].Value = data;
			parameters[1].Value = angajatorId;
			RunProcedure("SeteazaInactivAngajatiExpiraContractLunaCurenta", parameters);
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

		#region VerificaDateSalariuPtUltimele3Luni
		/// <summary>
		/// Verifica daca sunt date in statul de plata din baza de date pe ultimele trei luni pentru
		/// un anumit angajat.
		/// </summary>
		/// <param name="angajatId"> ID-ul angajatului.</param>
		/// <param name="lunaId"> ID-ul lunii</param>
		/// <returns> true in cazul in care sunt date in statul de plata pe ultimele trei luni, false altfel.</returns>
		/// <remarks> 
		/// Autor: Cristina Raluca Muntean
		/// Data:  14.03.2006
		/// </remarks>
		public bool VerificaDateSalariuPtUltimele3Luni(long angajatId, int lunaId)
		{
			bool suntDate;

			// Sunt declarati parametrii.
			SqlParameter[] parameters = { new SqlParameter("@AngajatID", SqlDbType.BigInt, 8),
											new SqlParameter("@LunaID", SqlDbType.Int, 4),
											new SqlParameter("@suntDate", SqlDbType.Bit, 1)
										};
			
			// Sunt setate valorile parametrilor.
			// ID-ul angajatului.
			parameters[0].Value = angajatId;
			// ID-ul lunii.
			parameters[1].Value = lunaId;
			// Este setat parametrul de iesire.
			parameters[2].Direction = ParameterDirection.Output;
			
			// Este rulata procedura stocata.
			RunProcedure("spVerificaDateSalariuPtUltimele3Luni", parameters);
			
			// Este preluata valoarea parametrului de iesire.
			suntDate = bool.Parse(parameters[2].Value.ToString());

			return suntDate;
		}
		#endregion

		#region GetMedieZilnicaConcediuDeOdihna
		/// <summary>
		/// Calculeaza media zilnica a unui angajat pentru concediul de odihna.
		/// </summary>
		/// <param name="angajatId"> ID-ul angajatului.</param>
		/// <param name="lunaId"> ID-ul lunii.</param>
		/// <returns> Media zilnica aferenta concediului de odihna.</returns>
		/// <remarks> 
		/// Autor: Cristina Raluca Muntean
		/// Data:  14.03.2006
		/// </remarks>
		public double GetMedieZilnicaConcediuDeOdihna(long angajatId, int lunaId)
		{
			double medieZilnica = 0;
			
			// Sunt declarati parametrii.
			SqlParameter[] parameters = { new SqlParameter("@AngajatID", SqlDbType.BigInt, 8),
											new SqlParameter("@LunaID", SqlDbType.Int, 4),
											new SqlParameter("@mediaZilnica", SqlDbType.Real)
										};
			
			// Sunt setate valorile parametrilor.
			// ID-ul angajatului.
			parameters[0].Value = angajatId;
			// ID-ul lunii.
			parameters[1].Value = lunaId;
			// Este setat parametrul de iesire.
			parameters[2].Direction = ParameterDirection.Output;
			
			// Este rulata procedura stocata.
			RunProcedure("spCalculMedieZilnicaConcediuOdihna", parameters);
			
			// Este preluata valoarea mediei zilnice pentru concediul de odihna al angajatului.
			//Modificat:	Oprescu Claudia
			//Descriere:	Se face conversie la double numai daca parametrul are o valoare diferita de stringul vid
			if (parameters[2].Value.ToString() != "")
			{
				medieZilnica = double.Parse(parameters[2].Value.ToString());
			}
			else
			{
				medieZilnica = 0;
			}

			return medieZilnica;
		}
		#endregion

		#region RecalculMedieZilnicaConcediuOdihna
		/// <summary>
		/// Procedura recalculeaza media zilnica a concediului de odihna a unui angajat in cazul in care a fost
		/// adaugata o modificare a salariului de baza al angajatului pe luna curenta.
		/// </summary>
		/// <param name="angajatId">Id-ul angajatului</param>
		/// <param name="dataStart">Data de incepul a lunii curente</param>
		/// <param name="dataEnd">Data de sfarsit a lunii curente</param>
		public void RecalculMedieZilnicaConcediuOdihna(long angajatId, DateTime dataStart, DateTime dataEnd)
		{			
			// Sunt declarati parametrii.
			SqlParameter[] parameters = { new SqlParameter("@AngajatID", SqlDbType.BigInt, 8),
											new SqlParameter("@DataStart", SqlDbType.DateTime, 8),
											new SqlParameter("@DataEnd", SqlDbType.DateTime, 8)
										};
			
			// Sunt setate valorile parametrilor.
			parameters[0].Value = angajatId;
			parameters[1].Value = dataStart;
			parameters[2].Value = dataEnd;
			
			// Este rulata procedura stocata.
			RunProcedure("spRecalculMediaZilnicaConcediuOdihna", parameters);
		}
		#endregion

		#region GetMedieZilnicaConcediuDeBoala
		/// <summary>
		/// Calculeaza media zilnica a unui angajat pentru concediul de boala.
		/// </summary>
		/// <param name="angajatId">Id-al angajatului pentru care se face media</param>
		/// <param name="lunaId">Id-ul lunii pentru care se face media</param>
		/// <returns>Returneaza valoarea mediei zilnice</returns>
		public double GetMedieZilnicaConcediuDeBoala(long angajatId, int lunaId)
		{
			double medieZilnica = 0;
			
			// Sunt declarati parametrii.
			SqlParameter[] parameters = { new SqlParameter("@AngajatID", SqlDbType.BigInt, 8),
											new SqlParameter("@LunaID", SqlDbType.Int, 4),
											new SqlParameter("@mediaZilnica", SqlDbType.Real)
										};
			
			// Sunt setate valorile parametrilor.
			// ID-ul angajatului.
			parameters[0].Value = angajatId;
			// ID-ul lunii.
			parameters[1].Value = lunaId;
			// Este setat parametrul de iesire.
			parameters[2].Direction = ParameterDirection.Output;
			
			// Este rulata procedura stocata.
			RunProcedure("spCalculMedieZilnicaConcediuBoala", parameters);
			
			if (parameters[2].Value.ToString() != "")
			{
				medieZilnica = double.Parse(parameters[2].Value.ToString());
			}
			else
			{
				medieZilnica = 0;
			}

			return medieZilnica;
		}
		/// <summary>
		/// Calculeaza media zilnica a unui angajat pentru concediul de boala.
		/// </summary>
		/// <param name="angajatId">Id-al angajatului pentru care se face media</param>
		/// <param name="lunaId">Id-ul lunii pentru care se face media</param>
		/// <returns>Returneaza un dataset ce contine media zilnica, suma veniurilor pe ult 6 luni, suma zileleor lucrate pe ultimele 6 luni</returns>
		public DataSet GetMedieZilnicaConcediuDeBoalaDataSet(long angajatId, int lunaId)
		{
			double medieZilnica = 0;
			
			// Sunt declarati parametrii.
			SqlParameter[] parameters = { new SqlParameter("@AngajatID", SqlDbType.BigInt, 8),
											new SqlParameter("@LunaID", SqlDbType.Int, 4)
										};
			
			// Sunt setate valorile parametrilor.
			// ID-ul angajatului.
			parameters[0].Value = angajatId;
			// ID-ul lunii.
			parameters[1].Value = lunaId;
			
			// Este rulata procedura stocata.
			return RunProcedure("spCalculMedieZilnicaConcediuBoalaDataSet", parameters, "spCalculMedieZilnicaConcediuBoalaDataSet");
		}
		#endregion

		#region GetMedieZilnicaContinuareConcediuDeBoala
		/// <summary>
		/// Calculeaza media zilnica a unui angajat pentru continuare concediul de boala.
		/// </summary>
		/// <param name="angajatId">Id-al angajatului pentru care se face media</param>
		/// <param name="lunaId">Id-ul lunii pentru care se face media</param>
		/// <returns>Returneaza valoarea mediei zilnice</returns>
		//	Lungu Andreea - 12.09.2008 
		public double GetMedieZilnicaContinuareConcediuDeBoala(long angajatId, int lunaId)
		{
			double medieZilnica = 0;
			
			// Sunt declarati parametrii.
			SqlParameter[] parameters = { new SqlParameter("@AngajatID", SqlDbType.BigInt, 8),
											new SqlParameter("@LunaID", SqlDbType.Int, 4),
											new SqlParameter("@mediaZilnica", SqlDbType.Real)
										};
			
			// Sunt setate valorile parametrilor.
			// ID-ul angajatului.
			parameters[0].Value = angajatId;
			// ID-ul lunii.
			parameters[1].Value = lunaId;
			// Este setat parametrul de iesire.
			parameters[2].Direction = ParameterDirection.Output;
			
			// Este rulata procedura stocata.
			RunProcedure("spCalculMedieZilnicaContinuareConcediuBoala", parameters);
			
			if (parameters[2].Value.ToString() != "")
			{
				medieZilnica = double.Parse(parameters[2].Value.ToString());
			}
			else
			{
				medieZilnica = 0;
			}

			return medieZilnica;
		}
		/// <summary>
		/// Calculeaza media zilnica a unui angajat pentru continuare concediul de boala.
		/// </summary>
		/// <param name="angajatId">Id-al angajatului pentru care se face media</param>
		/// <param name="lunaId">Id-ul lunii pentru care se face media</param>
		/// <returns>Returneaza un dataset ce contine media zilnica, suma veniurilor pe ult 6 luni, suma zileleor lucrate pe ultimele 6 luni</returns>
		public DataSet GetMedieZilnicaContinuareConcediuDeBoalaDataSet(long angajatId, int lunaId)
		{
			double medieZilnica = 0;
			
			// Sunt declarati parametrii.
			SqlParameter[] parameters = { new SqlParameter("@AngajatID", SqlDbType.BigInt, 8),
											new SqlParameter("@LunaID", SqlDbType.Int, 4)
										};
			
			// Sunt setate valorile parametrilor.
			// ID-ul angajatului.
			parameters[0].Value = angajatId;
			// ID-ul lunii.
			parameters[1].Value = lunaId;
			
			// Este rulata procedura stocata.
			return RunProcedure("spCalculMedieZilnicaContinuareConcediuBoalaDataSet", parameters, "spCalculMedieZilnicaContinuareConcediuBoalaDataSet");
		}
		#endregion

		#region GetDetaliiAngajat
		/// <summary>
		/// Procedura selecteaza un angajat
		/// </summary>
		/// <returns>Returneaza un DataSet care contine aceste date</returns>
		public DataSet GetDetaliiAngajat(long angajatId)
		{
			try
			{
				SqlParameter[] parameters = {new SqlParameter("@AngajatID", SqlDbType.Int, 4)};
				parameters[0].Value = angajatId;
				DataSet ds =  RunProcedure("GetAngajatInfo", parameters, "Angajati");
				return ds;
			}
			catch
			{
				return null;
			}
		}
		#endregion

		#region GetSal_SituatieLunaraAngajatiIDs
		/// <summary>
		/// Returneaza toate id-urile angajatilor unui angajator pentru o anumita luna.
		/// </summary>
		/// <param name="angajatorId"> ID-ul angajatorului.</param>
		/// <param name="lunaId"> ID-ul lunii.</param>
		/// <returns></returns>
		/// <remarks> Autor: Cristina Muntean</remarks>
		public ArrayList GetSal_SituatieLunaraAngajatiIDs(int angajatorId, int lunaId)
		{
			ArrayList alAng = new ArrayList();
			int AngajatID;

			SqlParameter[] parameters = 
							{
								new SqlParameter("@AngajatorID", SqlDbType.Int, 4),
								new SqlParameter("@LunaID", SqlDbType.Int, 4)
							};
			
			parameters[0].Value = angajatorId;
			parameters[1].Value = lunaId;
			
			DataSet ds =  RunProcedure("spGetAllAngajatiIDs", parameters, "AngajatiIDs");
			
			foreach( DataRow dr in ds.Tables["AngajatiIDs"].Rows)
			{
				AngajatID = int.Parse(dr["AngajatID"].ToString());
				alAng.Add(AngajatID);
			}
			return alAng;			
		}
		#endregion

		#region GetAngajatiExpiraContractLunaCurenta
		/// <summary>
		/// Procedura selecteaza angajatii carora le expira contractul de munca
		/// </summary>
		/// <param name="data">Data in functie de care se selecteaza angajatii</param>
		/// <returns>Returneaza un DataSet care contine aceste date</returns>
		public DataSet GetAngajatiExpiraContractLunaCurenta(DateTime data)
		{
			SqlParameter[] parameters = {
											new SqlParameter("@Data", SqlDbType.DateTime, 8)
										};
			parameters[0].Value = data;
			return RunProcedure("GetAngajatiExpiraContractLunaCurenta", parameters, "GetAngajatiExpiraContractLunaCurenta");
		}
		#endregion

		#region InsertCAS
		/// <summary>
		/// Procedura adauga datele CAS ale unui angajat pentru o anumita luna
		/// </summary>
		/// <param name="angajatId">Id-ul angajatului</param>
		/// <param name="lunaId">Id-ul lunii</param>
		/// <param name="valCAS">Valoarea CAS</param>
		public void InsertCAS(long angajatId, int lunaId, double valCAS)
		{
			SqlParameter[] parameters = 
							{
								new SqlParameter("@tip_actiune", SqlDbType.Int, 1),
								new SqlParameter("@ID_Angajat", SqlDbType.BigInt, 8),
								new SqlParameter("@ID_Luna", SqlDbType.Int,4),
								new SqlParameter("@ValCAS", SqlDbType.Float, 8)
							};
			
			parameters[0].Value = 0;
			parameters[1].Value = angajatId;
			parameters[2].Value = lunaId;
			parameters[3].Value = valCAS;

			RunProcedure("InsertUpdateBazaDateCAS", parameters);
		}
		#endregion

		#region UpdateCAS
		/// <summary>
		/// Procedura modifica datele CAS ale unui angajat pentru o anumita luna
		/// </summary>
		/// <param name="angajatId">Id-ul angajatului</param>
		/// <param name="lunaId">Id-ul lunii</param>
		/// <param name="valCAS">Valoarea CAS</param>
		public void UpdateCAS(long angajatId, int lunaId, double valCAS)
		{
			SqlParameter[] parameters = 
							{
								new SqlParameter("@tip_actiune", SqlDbType.Int, 1),
								new SqlParameter("@ID_Angajat", SqlDbType.BigInt, 8),
								new SqlParameter("@ID_Luna", SqlDbType.Int,4),
								new SqlParameter("@ValCAS", SqlDbType.Float, 8)
							};
			
			parameters[0].Value = 1;
			parameters[1].Value = angajatId;
			parameters[2].Value = lunaId;
			parameters[3].Value = valCAS;

			RunProcedure("InsertUpdateBazaDateCAS", parameters);
		}
		#endregion

		#region DeleteCAS
		/// <summary>
		/// Procedura sterge datele CAS ale unui angajat pentru o anumita luna
		/// </summary>
		/// <param name="angajatId">Id-ul angajatului</param>
		public void DeleteCAS(long angajatId)
		{
			SqlParameter[] parameters = 
							{
								new SqlParameter("@tip_actiune", SqlDbType.Int, 1),
								new SqlParameter("@ID_Angajat", SqlDbType.BigInt, 8),
								new SqlParameter("@ID_Luna", SqlDbType.Int,4),
								new SqlParameter("@ValCAS", SqlDbType.Float, 8)
							};
			
			parameters[0].Value = 2;
			parameters[1].Value = angajatId;
			parameters[2].Value = 0;
			parameters[3].Value = 0;

			RunProcedure("InsertUpdateBazaDateCAS", parameters);
		}
		#endregion

		#region GetValoriCAS
		/// <summary>
		/// Procedura determina valorile CAS ale unui angajat
		/// </summary>
		/// <param name="angajatId">Id-ul angajatului</param>
		/// <returns>Returneaza un DataSet care contine aceste date</returns>
		public DataSet GetValoriCAS(long angajatId)
		{
			SqlParameter[] parameters = 
							{
								new SqlParameter("@AngajatID",SqlDbType.Int, 4)
							};
			parameters[0].Value = angajatId;
			return RunProcedure("spGetAllValoriCAS", parameters, "GetAllValoriCAS");
		}
		#endregion

		#region UpdatePoza
		/// <summary>
		/// Procedura actualizeaza poza unui angajat
		/// </summary>
		/// <param name="angajatId">Id-ul angajatului</param>
		/// <param name="buffer">Poza angajatului</param>
		public void UpdatePoza(long angajatId, byte[] buffer)
		{
			SqlParameter[] parameters = 
							{
								new SqlParameter("@AngajatID", SqlDbType.BigInt, 10),
								new SqlParameter("@Poza", SqlDbType.Image, buffer.Length)
							};
			
			parameters[0].Value = angajatId;
			parameters[1].Value = buffer;

			RunProcedure("UpdatePozaAngajat", parameters);
		}
		#endregion

		#region GetAngajatiAlerteSpeciale
		/// <summary>
		/// Procedura este folosita pentru a selecta angajatii cu alerte speciale
		/// </summary>
		/// <returns>Returneaza un DataSet care contine aceste valori</returns>
		public DataSet GetAngajatiAlerteSpeciale()
		{
			SqlParameter[] parameters = {};
			return RunProcedure("GetAngajatiAlerteSpeciale", parameters, "GetAngajatiAlerteSpeciale");
		}
		#endregion

		#region GetAngajatiExpiraDataMajorare
		/// <summary>
		/// Procedura este folosita pentru a selecta angajatii pentru care trebuie sa se efectueaza o majorare
		/// </summary>
		/// <returns>Returneaza un DataSet care contine aceste valori</returns>
		public DataSet GetAngajatiExpiraDataMajorare()
		{
			SqlParameter[] parameters = {};
			return RunProcedure("GetAngajatiExpiraDataMajorare", parameters, "GetAngajatiExpiraDataMajorare");
		}
		#endregion

		#region GetAngajatiExpiraPasaport
		/// <summary>
		/// Procedura este folosita pentru a selecta angajatii carora le-a expirat pasaportul
		/// </summary>
		/// <returns>Returneaza un DataSet care contine aceste valori</returns>
		public DataSet GetAngajatiExpiraPasaport()
		{
			SqlParameter[] parameters = {};
			return RunProcedure("GetAngajatiExpiraPasaport", parameters, "GetAngajatiExpiraPasaport");
		}
		#endregion

		#region GetAngajatiExpiraPermisMunca
		/// <summary>
		/// Procedura este folosita pentru a selecta angajatii carora le-a expirat permisul de munca
		/// </summary>
		/// <returns>Returneaza un DataSet care contine aceste valori</returns>
		public DataSet GetAngajatiExpiraPermisMunca()
		{
			SqlParameter[] parameters = {};
			return RunProcedure("GetAngajatiExpiraPermisMunca", parameters, "GetAngajatiExpiraPermisMunca");
		}
		#endregion

		#region GetAngajatiExpiraPermisSedere
		/// <summary>
		/// Procedura este folosita pentru a selecta angajatii carora le-a expirat permisul de sedere
		/// </summary>
		/// <returns>Returneaza un DataSet care contine aceste valori</returns>
		public DataSet GetAngajatiExpiraPermisSedere()
		{
			SqlParameter[] parameters = {};
			return RunProcedure("GetAngajatiExpiraPermisSedere", parameters, "GetAngajatiExpiraPermisSedere");
		}
		#endregion

		#region GetAngajatiExpiraRetineri
		/// <summary>
		/// Procedura este folosita pentru a selecta angajatii carora le expira retineri in luna activa curenta
		/// </summary>
		/// <returns>Returneaza un DataSet care contine aceste valori</returns>
		public DataSet GetAngajatiExpiraRetineri(int lunaID)
		{
			SqlParameter[] parameters = {
							new SqlParameter("@LunaID", SqlDbType.Int, 4)
							};
			parameters[0].Value = lunaID;
			return RunProcedure("GetAngajatiExpiraRetineri", parameters, "GetAngajatiExpiraRetineri");
		}
		#endregion

		#region GetAllAngajatiNumeIntregUnion
		/// <summary>
		/// Procedura este folosita pentru a selecta angajatii
		/// </summary>
		/// <returns>Returneaza un DataSet care contine aceste valori</returns>
		public DataSet GetAllAngajatiNumeIntregUnion()
		{
			SqlParameter[] parameters = {};
			return RunProcedure("spGetAllAngajatiNumeIntregUnion", parameters, "GetAllAngajatiNumeIntregUnion");
		}
		#endregion

		#region GetAngajatIDByMarca
		// Lungu Andreea - 03.11.2009
		// aduce angajatId pe baza marcii
		public int GetAngajatIDByMarca(string marca)
		{
			int idAngajat = -1;
			// Sunt declarati parametrii.
			SqlParameter[] parameters = { 
											new SqlParameter("@Marca", SqlDbType.NVarChar, 8),
											new SqlParameter("@AngajatID", SqlDbType.Int, 4),
										};
			// Sunt setate valorile parametrilor.
			// marca angajatului.
			parameters[0].Value = marca;
			// Este setat parametrul de iesire.
			parameters[1].Direction = ParameterDirection.Output;
			// Este rulata procedura stocata.
			RunProcedure("spGetIdAngajatByMarca", parameters);
			
			if (parameters[1].Value.ToString() != "")
			{
				idAngajat = int.Parse(parameters[1].Value.ToString());
			}
			else
			{
				idAngajat = -1;
			}
			return idAngajat;
		}
		#endregion

		#region GetNrZileSuspendateContract
		/// <summary>
		/// Calculeaza nr de zile suspendate dintr-o luna.
		/// </summary>
		/// <param name="angajatId">Id-al angajatului pentru care se face media</param>
		/// <param name="lunaId">Id-ul lunii pentru care se face media</param>
		/// <returns>Returneaza valoarea mediei zilnice</returns>
		public int GetNrZileSuspendateContract(long angajatId, int lunaId)
		{
			int nrZileSuspendate = 0;
			
			// Sunt declarati parametrii.
			SqlParameter[] parameters = { new SqlParameter("@AngajatID", SqlDbType.BigInt, 8),
											new SqlParameter("@LunaID", SqlDbType.Int, 4),
											new SqlParameter("@nrZileSuspendareContract", SqlDbType.Real)
										};
			
			// Sunt setate valorile parametrilor.
			// ID-ul angajatului.
			parameters[0].Value = angajatId;
			// ID-ul lunii.
			parameters[1].Value = lunaId;
			// Este setat parametrul de iesire.
			parameters[2].Direction = ParameterDirection.Output;
			
			// Este rulata procedura stocata.
			RunProcedure("spCalculNrZileSuspendareContract", parameters);
			
			if (parameters[2].Value.ToString() != "")
			{
				nrZileSuspendate = int.Parse(parameters[2].Value.ToString());
			}
			else
			{
				nrZileSuspendate = 0;
			}

			return nrZileSuspendate;
		}
		#endregion
	}
}
