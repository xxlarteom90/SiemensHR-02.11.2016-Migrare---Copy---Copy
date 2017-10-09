using System;
using System.Data;
using System.Data.SqlClient;

/*
 * Modificat:	Lungu Andreea
 * Data:		08.04.2008
 * Descriere:	A fost adaugat campul nrInregITM pentru angajator
 * */

namespace Salaries.Data
{
	/// <summary>
	/// Summary description for AdminAngajator.
	/// </summary>
	public class AdminAngajator : Salaries.Data.DbObject
	{
		#region AdminAngajator
		/// <summary>
		/// Constructorul cu string de conexiune
		/// </summary>
		/// <param name="connectionString">Stringul de conexiune la baza de date</param>
		public AdminAngajator(string connectionString) : base (connectionString)
		{}
		#endregion

		#region GetJSArrays
		/// <summary>
		/// Returneaza array-uri cu AngajatorID si Numnarul de angajati asignati la fiecare 
		/// </summary>
		/// <returns></returns>
		public string GetJSArrays()
		{
			SqlParameter[] parameters = {};
			DataSet ds = RunProcedure("CountAngajatiPerAngajator", parameters, "CountAngajatiPerAngajator");

			string arAngajatorID = "";
			string arNoAngajati = "";
			for(int i=0 ;i < ds.Tables[0].Rows.Count; i++)
			{
				DataRow row = ds.Tables[0].Rows[i];
				if (arAngajatorID!="")
					arAngajatorID += ",";
				arAngajatorID += "'" + row["AngajatorID"] + "'";
				if (arNoAngajati!="")
					arNoAngajati += ",";
				arNoAngajati += "'" + row["noangajati"] + "'";
			}
			return "var arAngajatorID = new Array("+ arAngajatorID + "); var arNoAngajati = new Array(" + arNoAngajati + ")";
		}
		#endregion

		#region LoadParameters
		/// <summary>
		/// Procedura creaza un sir de parametrii de tip sql cu datele unui angajator
		/// </summary>
		/// <returns>Returneaza acest sir de parametrii</returns>
		private SqlParameter[] LoadParameters(int tipActiune, int angajatorId, string denumire, int tipPersoana, string CUI_CNP, string nrInregORC,string nrInregITM,
											string telefon, string fax, string paginaWeb, string email, int taraId, int judetSectorId, 
											int tipCompletareId, string localitate, string strada, string numar, string codPostal, 
											string bloc, string scara, string etaj, string apartament, string ziLichidareSalar, string sector)
		{
			SqlParameter[] parameters = 
							{
								new SqlParameter("@tip_actiune", SqlDbType.Int, 4),
								new SqlParameter("@AngajatorID", SqlDbType.Int, 4),
								new SqlParameter("@Denumire", SqlDbType.NVarChar, 100),
								new SqlParameter("@TipPersoana", SqlDbType.Bit, 1),
								new SqlParameter("@CUI_CNP", SqlDbType.NVarChar, 25),
								new SqlParameter("@NrInregORC", SqlDbType.NVarChar, 25),
								new SqlParameter("@NrInregITM", SqlDbType.NVarChar, 25),
								new SqlParameter("@Telefon", SqlDbType.NVarChar, 25),
								new SqlParameter("@Fax", SqlDbType.NVarChar, 25, fax),
								new SqlParameter("@PaginaWeb", SqlDbType.NVarChar, 100),
								new SqlParameter("@Email", SqlDbType.NVarChar, 100),
								new SqlParameter("@TaraID", SqlDbType.Int, 4),
								new SqlParameter("@JudetSectorID", SqlDbType.Int, 4),
								new SqlParameter("@TipCompletareID", SqlDbType.Int, 4),
								new SqlParameter("@Localitate", SqlDbType.NVarChar, 50, localitate),
								new SqlParameter("@Strada", SqlDbType.NVarChar, 50),
								new SqlParameter("@Numar", SqlDbType.NVarChar, 10),
								new SqlParameter("@CodPostal", SqlDbType.NVarChar, 20),
								new SqlParameter("@Bloc", SqlDbType.NVarChar, 5),
								new SqlParameter("@Scara", SqlDbType.NVarChar, 5),
								new SqlParameter("@Etaj", SqlDbType.NVarChar, 5),
								new SqlParameter("@Apartament", SqlDbType.NVarChar, 5),
								new SqlParameter("@ZiLichidareSalar", SqlDbType.NVarChar, 2),
								new SqlParameter("@Sector", SqlDbType.NVarChar, 5)
							};
			
			parameters[0].Value = tipActiune;
			parameters[1].Value = angajatorId;
			parameters[2].Value = denumire;
			parameters[3].Value = tipPersoana;
			parameters[4].Value = CUI_CNP;
			parameters[5].Value = nrInregORC;
			parameters[6].Value = nrInregITM;
			parameters[7].Value = telefon;
			parameters[8].Value = fax;
			parameters[9].Value = paginaWeb;
			parameters[10].Value = email;
			parameters[11].Value = taraId;
			parameters[12].Value = judetSectorId;
			parameters[13].Value = tipCompletareId;
			parameters[14].Value = localitate;
			parameters[15].Value = strada;
			parameters[16].Value = numar;
			parameters[17].Value = codPostal;
			parameters[18].Value = bloc;
			parameters[19].Value = scara;
			parameters[20].Value = etaj;
			parameters[21].Value = apartament;
			parameters[22].Value = ziLichidareSalar;
			parameters[23].Value = sector;

			return parameters;
		}
		#endregion

		#region LoadInfoAngajator
		/// <summary>
		/// Procedura selecteaza datele despre un angajator
		/// </summary>
		/// <param name="idAngajator">Id-ul angajatorului selectat</param>
		/// <returns>Returneaza un DataSet care contine datele despre angajator</returns>
		public DataSet LoadInfoAngajator(int idAngajator)
		{
			SqlParameter[] parameters = 
							{
								new SqlParameter("@AngajatorID", SqlDbType.Int, 4)
							};
			
			parameters[0].Value = idAngajator;
			return RunProcedure("GetAngajatorInfo", parameters, "GetAngajatorInfo");
		}
		#endregion

		#region LoadInfoAngajatori
		/// <summary>
		/// Angajatorii din sistem.
		/// </summary>
		/// <returns>Un DataSet ce cuprinde toti angajatorii din sistem.</returns>
		/// <remarks>
		/// Modificari:
		/// Autor: Cristina Raluca Muntean
		/// Data: 2.06.2006
		/// Descriere: Am inlocuit rularea unei instructiuni sql, cu rularea procedurii stocate.
		/// </remarks>
		public DataSet LoadInfoAngajatori()
		{
			SqlParameter[] parameters = {};
			return RunProcedure("GetAngajatori", parameters, "GetAngajatori");
		}
		#endregion

		#region InsertAngajator
		/// <summary>
		/// Procedura actualizeaza un angajator
		/// </summary>
		public void InsertAngajator(int angajatorId, string denumire, int tipPersoana, string CUI_CNP, string nrInregORC, string nrInregITM,
									string telefon, string fax, string paginaWeb, string email, int taraId, int judetSectorId, 
									int tipCompletareId, string localitate, string strada, string numar, string codPostal, 
									string bloc, string scara, string etaj, string apartament, string ziLichidareSalar, string sector)
		{
			SqlParameter[] parameters = LoadParameters(0, angajatorId, denumire, tipPersoana, CUI_CNP, nrInregORC, nrInregITM, telefon, fax, paginaWeb, email, taraId, judetSectorId, tipCompletareId, localitate, strada, numar, codPostal, bloc, scara, etaj, apartament, ziLichidareSalar, sector);
			RunProcedure("InsertUpdateDeleteAngajator", parameters);
		}
		#endregion

		#region InsertAngajatorWithIDReturn
		/// <summary>
		/// insereaza un angajator si returneaza id-ul angajatorului tocmai inserat
		/// </summary>
		public int InsertAngajatorWithIDReturn(string denumire, int tipPersoana, string CUI_CNP, string nrInregORC, string nrInregITM,
												string telefon, string fax, string paginaWeb, string email, int taraId, int judetSectorId, 
												int tipCompletareId, string localitate, string strada, string numar, string codPostal, 
												string bloc, string scara, string etaj, string apartament, string ziLichidareSalar, string sector)		
		{
			SqlParameter[] parameters = 
							{
								new SqlParameter("@AngajatorID", SqlDbType.Int, 4),
								new SqlParameter("@Denumire", SqlDbType.NVarChar, 100),
								new SqlParameter("@TipPersoana", SqlDbType.Bit, 1),
								new SqlParameter("@CUI_CNP", SqlDbType.NVarChar, 25),
								new SqlParameter("@NrInregORC", SqlDbType.NVarChar, 25),
								new SqlParameter("@NrInregITM", SqlDbType.NVarChar, 25),
								new SqlParameter("@Telefon", SqlDbType.NVarChar, 25),
								new SqlParameter("@Fax", SqlDbType.NVarChar, 25, fax),
								new SqlParameter("@PaginaWeb", SqlDbType.NVarChar, 25),
								new SqlParameter("@Email", SqlDbType.NVarChar, 25),
								new SqlParameter("@TaraID", SqlDbType.Int, 4),
								new SqlParameter("@JudetSectorID", SqlDbType.Int, 4),
								new SqlParameter("@TipCompletareID", SqlDbType.Int, 4),
								new SqlParameter("@Localitate", SqlDbType.NVarChar, 50, localitate),
								new SqlParameter("@Strada", SqlDbType.NVarChar, 50),
								new SqlParameter("@Numar", SqlDbType.NVarChar, 10),
								new SqlParameter("@CodPostal", SqlDbType.NVarChar, 20),
								new SqlParameter("@Bloc", SqlDbType.NVarChar, 5),
								new SqlParameter("@Scara", SqlDbType.NVarChar, 5),
								new SqlParameter("@Etaj", SqlDbType.NVarChar, 5),
								new SqlParameter("@Apartament", SqlDbType.NVarChar, 5),
								new SqlParameter("@ZiLichidareSalar", SqlDbType.NVarChar, 2),
								new SqlParameter("@Sector", SqlDbType.NVarChar, 5)
							};
			
			parameters[0].Direction = ParameterDirection.Output;
			parameters[1].Value = denumire;
			parameters[2].Value = tipPersoana;
			parameters[3].Value = CUI_CNP;
			parameters[4].Value = nrInregORC;
			parameters[5].Value = nrInregITM;
			parameters[6].Value = telefon;
			parameters[7].Value = fax;
			parameters[8].Value = paginaWeb;
			parameters[9].Value = email;
			parameters[10].Value = taraId;
			parameters[11].Value = judetSectorId;
			parameters[12].Value = tipCompletareId;
			parameters[13].Value = localitate;
			parameters[14].Value = strada;
			parameters[15].Value = numar;
			parameters[16].Value = codPostal;
			parameters[17].Value = bloc;
			parameters[18].Value = scara;
			parameters[19].Value = etaj;
			parameters[20].Value = apartament;
			parameters[21].Value = ziLichidareSalar;
			parameters[22].Value = sector;

			RunProcedure("InsertAngajatorWithIDReturn", parameters);
			return int.Parse(parameters[0].Value.ToString());
		}
		#endregion

		#region InsertFirstAngajator
		/// <summary>
		/// Procedura insereaza primul angajator la rularea aplicatiei
		/// </summary>
		/// <param name="data">Luna activa pentru care se porneste aplicatia</param>
		/// <returns>Returneaza id-ul angajatorului adaugat</returns>
		public int InsertFirstAngajator(DateTime data ,string denumire, int tipPersoana, string CUI_CNP, string nrInregORC, string nrInregITM,
										string telefon, string fax, string paginaWeb, string email, int taraId, int judetSectorId, 
										int tipCompletareId, string localitate, string strada, string numar, string codPostal, 
										string bloc, string scara, string etaj, string apartament, string ziLichidareSalar, string sector)
		{	
			SqlParameter[] parameters = 
							{
								new SqlParameter("@AngajatorID", SqlDbType.Int, 4),
								new SqlParameter("@Denumire", SqlDbType.NVarChar, 100),
								new SqlParameter("@TipPersoana", SqlDbType.Bit, 1),
								new SqlParameter("@CUI_CNP", SqlDbType.NVarChar, 25),
								new SqlParameter("@NrInregORC", SqlDbType.NVarChar, 25),
								new SqlParameter("@NrInregITM", SqlDbType.NVarChar, 25),
								new SqlParameter("@Telefon", SqlDbType.NVarChar, 25),
								new SqlParameter("@Fax", SqlDbType.NVarChar, 25, fax),
								new SqlParameter("@PaginaWeb", SqlDbType.NVarChar, 25),
								new SqlParameter("@Email", SqlDbType.NVarChar, 25),
								new SqlParameter("@TaraID", SqlDbType.Int, 4),
								new SqlParameter("@JudetSectorID", SqlDbType.Int, 4),
								new SqlParameter("@Localitate", SqlDbType.NVarChar, 50, localitate),
								new SqlParameter("@Strada", SqlDbType.NVarChar, 50),
								new SqlParameter("@Numar", SqlDbType.NVarChar, 10),
								new SqlParameter("@CodPostal", SqlDbType.NVarChar, 20),
								new SqlParameter("@Bloc", SqlDbType.NVarChar, 5),
								new SqlParameter("@Scara", SqlDbType.NVarChar, 5),
								new SqlParameter("@Etaj", SqlDbType.NVarChar, 5),
								new SqlParameter("@Apartament", SqlDbType.NVarChar, 5),
								new SqlParameter("@ZiLichidareSalar", SqlDbType.NVarChar, 2),
								new SqlParameter("@Sector", SqlDbType.NVarChar, 5),
								new SqlParameter("@Data", SqlDbType.DateTime),
							};
			
			parameters[0].Direction = ParameterDirection.Output;
			parameters[1].Value = denumire;
			parameters[2].Value = tipPersoana;
			parameters[3].Value = CUI_CNP;
			parameters[4].Value = nrInregORC;
			parameters[5].Value = nrInregITM;
			parameters[6].Value = telefon;
			parameters[7].Value = fax;
			parameters[8].Value = paginaWeb;
			parameters[9].Value = email;
			parameters[10].Value = taraId;
			parameters[11].Value = judetSectorId;
			parameters[12].Value = localitate;
			parameters[13].Value = strada;
			parameters[14].Value = numar;
			parameters[15].Value = codPostal;
			parameters[16].Value = bloc;
			parameters[17].Value = scara;
			parameters[18].Value = etaj;
			parameters[19].Value = apartament;
			parameters[20].Value = ziLichidareSalar;
			parameters[21].Value = sector;
			parameters[22].Value = data;

			RunProcedure("spSetFirstAngajator", parameters);
			int angajatorId = int.Parse(parameters[0].Value.ToString());

			//Inseram in tm_zile zilele pentru luna activa ... daca aceastea nu exista deja
			Luni l = new Luni(base.ConnectionString);
			l.FillZileLuna(int.Parse(data.Month.ToString()), int.Parse(data.Year.ToString()));
			return angajatorId;
		}
		#endregion

		#region UpdateAngajator
		/// <summary>
		/// Procedura actualizeaza un angajator
		/// </summary>
		public void UpdateAngajator(int angajatorId, string denumire, int tipPersoana, string CUI_CNP, string nrInregORC, string nrInregITM,
									string telefon, string fax, string paginaWeb, string email, int taraId, int judetSectorId, 
									int tipCompletareId, string localitate, string strada, string numar, string codPostal, 
									string bloc, string scara, string etaj, string apartament, string ziLichidareSalar, string sector)
		{
			SqlParameter[] parameters = LoadParameters(1, angajatorId, denumire, tipPersoana, CUI_CNP, nrInregORC, nrInregITM, telefon, fax, paginaWeb, email, taraId, judetSectorId, tipCompletareId, localitate, strada, numar, codPostal, bloc, scara, etaj, apartament, ziLichidareSalar, sector);
			RunProcedure("InsertUpdateDeleteAngajator", parameters);
		}
		#endregion

		#region DeleteAngajator
		/// <summary>
		/// Procedura actualizeaza un angajator
		/// </summary>
		public void DeleteAngajator(int angajatorId)
		{
			SqlParameter[] parameters = LoadParameters(2, angajatorId, "", 0, "", "", "", "", "", "", "", 0, 0, 0, "", "", "", "", "", "", "", "", "", "");
			RunProcedure("InsertUpdateDeleteAngajator", parameters);
		}
		#endregion

		#region CheckIfAngajatorCanBeAdded
		/// <summary>
		/// Procedura verifica sa nu se creeze duplicate in tablea Angajatori prin adaugare/modificare
		/// </summary>
		/// <param name="angajatorId">Id-ul angajatorului care nu trebuie sa coincida</param>
		/// <param name="denumire">Denumirea angajatorului</param>
		/// <param name="CUI_CNP">CUI_CNP pentru angajator</param>
		/// <param name="nrInregORC">Nr inreg pentru angajator</param>
		/// <returns>Returneaza true daca se poate face adaugarea/modificarea si false altfel</returns>
		public bool CheckIfAngajatorCanBeAdded(int angajatorId, string denumire, string CUI_CNP, string nrInregORC)
		{
			SqlParameter[] parameters = 
							{
								new SqlParameter("@AngajatorID", SqlDbType.Int, 4),
								new SqlParameter("@Denumire", SqlDbType.NVarChar, 100),
								new SqlParameter("@CUI_CNP", SqlDbType.NVarChar, 25),
								new SqlParameter("@NrInregORC", SqlDbType.NVarChar, 25),
								new SqlParameter("@NrAngajatori", SqlDbType.Int, 4)
							};

			parameters[0].Value = angajatorId;
			parameters[1].Value = denumire;
			parameters[2].Value = CUI_CNP;
			parameters[3].Value = nrInregORC;
			parameters[4].Direction = ParameterDirection.Output;
			RunProcedure("spCheckIfAngajatorCanBeAdded", parameters);

			return byte.Parse(parameters[4].Value.ToString()) == 0;
		}
		#endregion

		#region GetPuncteLucru
		/// <summary>
		/// Procedura selecteaza punctele de lucru ale unui angajator
		/// </summary>
		/// <param name="angajatorID">Id-ul angajatorului</param>
		/// <returns>Returneaza un DataSet care contine punctele de lucru</returns>
		public DataSet GetPuncteLucru(int angajatorId)
		{
			SqlParameter[] parameters = 
							{
								new SqlParameter("@AngajatorID", SqlDbType.Int, 4)
							};
			parameters[0].Value = angajatorId;
			return RunProcedure("GetPuncteLucru", parameters, "GetPuncteLucru");
		}
		#endregion

		#region GetCaseDeAsig
		/// <summary>
		/// Procedura selecteaza casele de asigurari ale unui angajator
		/// </summary>
		/// <returns>Returneaza un DataSet care contine casele de asigurari</returns>
		public DataSet GetCaseDeAsig()
		{
			/*SqlParameter[] parameters = 
							{
								new SqlParameter("@AngajatorID", SqlDbType.Int, 4)
							};*/
			SqlParameter[] parameters = {};
			return RunProcedure("GetCaseAsig", parameters, "GetCaseAsig");
		}
		#endregion

		#region GetFunctiiReprez
		//Lungu Andreea - 02.09.2008
		//Este adus un dataset ce contine functiile pentru reprezentantii legali care nu au atasate persoane.
		public DataSet GetFunctiiReprez(int angajatorId)
		{
			SqlParameter[] parameters = 
							{
								new SqlParameter("@AngajatorID", SqlDbType.Int, 4)
							};
			parameters[0].Value = angajatorId;
			return RunProcedure("GetFunctiiReprez", parameters, "GetFunctiiReprez");
		}
		#endregion

		#region GetAllFunctiiReprez
		//Lungu Andreea - 02.09.2008
		//Este adus un dataset ce contine toate functiile pentru reprezentantii legali.
		public DataSet GetAllFunctiiReprez()
		{
			SqlParameter[] parameters = 
							{	};
			return RunProcedure("GetAllFunctiiReprez", parameters, "GetAllFunctiiReprez");
		}
		#endregion

		#region GetReprezLegali
		//Lungu Andreea - 20.08.2008
		//Este adus un dataset ce contine toti reprez legali stabiliti ai angajatorului.
		public DataSet GetReprezLegali(int angajatorId)
		{
			SqlParameter[] parameters = 
							{
								new SqlParameter("@AngajatorID", SqlDbType.Int, 4)
							};
			parameters[0].Value = angajatorId;
			return RunProcedure("GetReprezLegali", parameters, "GetReprezLegali");
		}
		#endregion

		#region SetReprezLegal
		//Lungu Andreea - 19.08.2008
		//Este setat un reprezentant legal pentru angajator
		public void SetReprezLegal(int angajatorId, int functieReprezId, string numeReprez, string prenumeReprez)
		{
			SqlParameter[] parameters = 
							{
								new SqlParameter("@AngajatorID", SqlDbType.Int,4),
								new SqlParameter("@FunctieReprezID", SqlDbType.Int, 4),
								new SqlParameter("@NumeReprez", SqlDbType.NVarChar, 50),
								new SqlParameter("@PrenumeReprez", SqlDbType.NVarChar, 50)
							};
			parameters[0].Value = angajatorId;
			parameters[1].Value = functieReprezId;
			parameters[2].Value = numeReprez;
			parameters[3].Value = prenumeReprez;
			RunProcedure("SetReprezLegal", parameters, "SetReprezLegal");
		}
		#endregion

		#region GetAngajatorInfoFiseFiscale
		//Manuel Neagoe - 01.03.2013
		//Este adus un dataset ce contine toti reprez legali stabiliti ai angajatorului.
		public DataSet GetAngajatorInfoFiseFiscale(int angajatorId)
		{
			SqlParameter[] parameters = 
							{
								new SqlParameter("@AngajatorID", SqlDbType.Int, 4)
							};
			parameters[0].Value = angajatorId;
			return RunProcedure("GetAngajatorInfoFiseFiscale", parameters, "GetAngajatorInfoFiseFiscale");
		}
		#endregion
	}
}
