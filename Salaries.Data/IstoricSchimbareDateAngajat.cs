using System;
using System.Data;
using System.Data.SqlClient;

namespace Salaries.Data
{
	/// <summary>
	/// Summary description for IstoricSchimbareDateAngajat.
	/// </summary>
	public class IstoricSchimbareDateAngajat : Salaries.Data.DbObject
	{
		#region Constructor
		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="connectionString"> Stringul de conectare la baza de date.</param>
		public IstoricSchimbareDateAngajat(string connectionString): base (connectionString)
		{}
		#endregion

		#region LoadIstoricSchimbari
		/// <summary>
		/// Procedura selectaza schimbarile unui angajat
		/// </summary>
		/// <param name="angajatId">Id-ul angajatului</param>
		/// <returns>Returneaza un DataSet care contine aceste date</returns>
		public DataSet LoadIstoricSchimbari(long angajatId)
		{
			DataRow row;
			DateTime data = DateTime.Now;
			double salariuBaza = 0, indemnizatieConducere = 0;
			int invaliditate = 0, categorieID = 0, norma = 0, j = -1;
			string invaliditateText = "", categorieText = "";

			//se apeleaza procedura stocata pentru a determina schimbarile unui angajat
			SqlParameter[] parameters = 
				{
					new SqlParameter("@AngajatID", SqlDbType.BigInt, 10)
				};
			parameters[0].Value = angajatId;
			DataSet ds = RunProcedure("GetIstoricSchimbariAngajat", parameters, "GetIstoricSchimbariAngajat");

			//se creaza o noua tabela
			DataTable dt = new DataTable( "IntervaleSchimbari" );

			//se creaza coloanele tabelei create
			DataColumn dcDataSt = new DataColumn( "DataStart", Type.GetType( "System.DateTime" ));
			DataColumn dcDataEnd = new DataColumn( "DataEnd", Type.GetType( "System.DateTime" ));
			DataColumn dcProgramLucru = new DataColumn( "ProgramLucru", Type.GetType( "System.Int32" ));
			DataColumn dcSalariuBaza = new DataColumn( "SalariuBaza", Type.GetType( "System.Decimal" ));
			DataColumn dcIndemnizatieCond = new DataColumn( "IndemnizatieConducere", Type.GetType( "System.Decimal" ));
			DataColumn dcInvaliditate = new DataColumn( "Invaliditate", Type.GetType( "System.Int16" ));
			DataColumn dcInvaliditateText = new DataColumn( "InvaliditateText", Type.GetType( "System.String" ));
			DataColumn dcCategorieID = new DataColumn( "CategorieID", Type.GetType( "System.Int32" ));
			DataColumn dcCategorieText = new DataColumn( "CategorieText", Type.GetType( "System.String" ));

			//se adauga coloanele tabelei noi create
			dt.Columns.Add( dcDataSt ); 
			dt.Columns.Add( dcDataEnd ); 
			dt.Columns.Add( dcProgramLucru ); 
			dt.Columns.Add( dcSalariuBaza );
			dt.Columns.Add( dcIndemnizatieCond ); 
			dt.Columns.Add( dcInvaliditate ); 
			dt.Columns.Add( dcInvaliditateText ); 
			dt.Columns.Add( dcCategorieID ); 
			dt.Columns.Add( dcCategorieText );
		
			if (ds.Tables[ 0 ].Rows.Count > 0)
			{
				//se preiau datele primei inregistari din tabela
				//daca data de incepere a intervalului este o zi de sarbatoare, atunci se trece la ziua urmatoare
				data = (DateTime)ds.Tables[ 0 ].Rows[ 0 ][ "Data" ];
				while (DataEsteZiSarbatoare(data))
				{
					data = data.AddDays(1);
				}
				norma = int.Parse(ds.Tables[ 0 ].Rows[ 0 ][ "ProgramLucru" ].ToString());
				salariuBaza = double.Parse(ds.Tables[ 0 ].Rows[ 0 ][ "SalariuBaza" ].ToString());
				indemnizatieConducere = double.Parse(ds.Tables[ 0 ].Rows[ 0 ][ "IndemnizatieConducere" ].ToString());
				invaliditate = int.Parse(ds.Tables[ 0 ].Rows[ 0 ][ "Invaliditate" ].ToString());
				invaliditateText = ds.Tables[ 0 ].Rows[ 0 ][ "Nume" ].ToString();
				categorieID = int.Parse(ds.Tables[ 0 ].Rows[ 0 ][ "CategorieID" ].ToString());
				categorieText = ds.Tables[ 0 ].Rows[ 0 ][ "Denumire" ].ToString();

				row = dt.NewRow();
				row["DataStart"] = data;
				row["ProgramLucru"] = norma;
				row["SalariuBaza"] = salariuBaza;
				row["IndemnizatieConducere"] = indemnizatieConducere;
				row["Invaliditate"] = invaliditate;
				row["InvaliditateText"] = invaliditateText;
				row["CategorieID"] = categorieID;
				row["CategorieText"] = categorieText;

				dt.Rows.Add(row);

				j = 0;

				//se parcurg inregistrarile selectate din baza de date
				for( int i=1; i<ds.Tables[ 0 ].Rows.Count; i++ )
				{
					//se selecteaza inregistrarea curenta
					DataRow dr = ds.Tables[ 0 ].Rows[ i ];
					if	(int.Parse( dr[ "ProgramLucru" ].ToString()) != norma ||
						double.Parse( dr[ "SalariuBaza" ].ToString()) != salariuBaza ||
						double.Parse( dr[ "IndemnizatieConducere" ].ToString()) != indemnizatieConducere ||
						int.Parse( dr[ "Invaliditate" ].ToString()) != invaliditate ||
						dr[ "Denumire" ].ToString() != categorieText )
					{
						//se stabileste data de sfarsit a inregistrarii anterioare ca fiind data inregistrarii curente
						dt.Rows[ j ]["DataEnd"] = (DateTime)ds.Tables[ 0 ].Rows[ i-1 ][ "Data" ];

						//se trece la o noua inregistratre
						j++;

						row = dt.NewRow();

						//pentru aceasta se stabilesc datele
						row["DataStart"] = (DateTime)ds.Tables[ 0 ].Rows[ i ][ "Data" ];

						norma = int.Parse(ds.Tables[ 0 ].Rows[ i ][ "ProgramLucru" ].ToString());
						salariuBaza = double.Parse(ds.Tables[ 0 ].Rows[ i ][ "SalariuBaza" ].ToString());
						indemnizatieConducere = double.Parse(ds.Tables[ 0 ].Rows[ i ][ "IndemnizatieConducere" ].ToString());
						invaliditate = int.Parse(ds.Tables[ 0 ].Rows[ i ][ "Invaliditate" ].ToString());
						invaliditateText = ds.Tables[ 0 ].Rows[ i ][ "Nume" ].ToString();
						categorieID = int.Parse( ds.Tables[ 0 ].Rows[ i ][ "CategorieID" ].ToString());
						categorieText = ds.Tables[ 0 ].Rows[ i ][ "Denumire" ].ToString();

						row["ProgramLucru"] = norma;
						row["SalariuBaza"] = salariuBaza;
						row["IndemnizatieConducere"] = indemnizatieConducere;
						row["Invaliditate"] = invaliditate;
						row["InvaliditateText"] = invaliditateText;
						row["CategorieID"] = categorieID;
						row["CategorieText"] = categorieText;
					
						dt.Rows.Add(row);
					}
				}

				Angajat ang = new Angajat(ConnectionString);
				DataSet dsAngajat = ang.LoadAngajat(angajatId);
				dt.Rows[ j ]["DataEnd"] = dsAngajat.Tables[0].Rows[0]["DataPanaLa"];
				if(dt.Rows[ j ]["DataEnd"] == System.DBNull.Value)
				{
					dt.Rows[ j ]["DataEnd"] = DateTime.MaxValue;
				}

				/*DateTime dataStart = DateTime.Parse(dsAngajat.Tables[0].Rows[0]["DataDeLa"].ToString());
				while (DataEsteZiSarbatoare(dataStart))
				{
					dataStart = dataStart.AddDays(1);
				}
				dt.Rows[ j ]["DataStart"] = dataStart;*/			
			}
			
			if (ds != null)
			{
				ds.Tables.Clear();
			}
			ds.Tables.Add(dt);
			return ds;
		}
		#endregion

		#region GetAllInvaliditati
		/// <summary>
		/// Procedura selecteaza toate tipurile de invaliditati
		/// </summary>
		/// <returns>Returneaza un DataSet care contine aceste date</returns>
		public DataSet GetAllInvaliditati()
		{
			SqlParameter[] parameters = {};
			return RunProcedure("GetAllInvaliditati", parameters, "GetAllInvaliditati");
		}
		#endregion

		#region InsertSchimbareProgramLucru
		/// <summary>
		/// Procedura adauga o schimbare pentru programul de lucru
		/// </summary>
		/// <param name="angajatId">Id-ul angajatului</param>
		/// <param name="programLucru">Programul de lucru</param>
		/// <param name="dataStart">Data de inceput</param>
		/// <param name="dataEnd">Data se sfarsit</param>
		public void InsertSchimbareProgramLucru(long angajatId, int programLucru, DateTime dataStart, DateTime dataEnd)
		{
			SqlParameter[] parameters = 
				{
					new SqlParameter("@AngajatID", SqlDbType.BigInt, 10),
					new SqlParameter("@ProgramLucru", SqlDbType.Int, 4),
					new SqlParameter("@DataStart", SqlDbType.DateTime, 8),
					new SqlParameter("@DataEnd", SqlDbType.DateTime, 8)
				};
			parameters[0].Value = angajatId;
			parameters[1].Value = programLucru;
			parameters[2].Value = dataStart;
			parameters[3].Value = dataEnd;

			RunProcedure("tm_UpdatePerioadaZileNormaLucruAngajat", parameters);
		}
		#endregion

		#region InsertSchimbareSalariuBaza
		/// <summary>
		/// Procedura adauga o schimbare pentru salariul de baza
		/// </summary>
		/// <param name="angajatId">Id-ul angajatului</param>
		/// <param name="salariuBaza">Salariul de baza</param>
		/// <param name="dataStart">Data de inceput</param>
		/// <param name="dataEnd">Data de sfarsit</param>
		public void InsertSchimbareSalariuBaza(long angajatId, decimal salariuBaza, DateTime dataStart, DateTime dataEnd)
		{
			SqlParameter[] parameters = 
				{
					new SqlParameter("@AngajatID", SqlDbType.BigInt, 10),
					new SqlParameter("@SalariuBaza", SqlDbType.Money, 8),
					new SqlParameter("@DataStart", SqlDbType.DateTime, 8),
					new SqlParameter("@DataEnd", SqlDbType.DateTime, 8)
				};
			parameters[0].Value = angajatId;
			parameters[1].Value = salariuBaza;
			parameters[2].Value = dataStart;
			parameters[3].Value = dataEnd;

			RunProcedure("tm_UpdatePerioadaZileSalariuBazaActualAngajat", parameters);
		}
		#endregion

		#region InsertSchimbareIndemnizatieConducere
		/// <summary>
		/// Procedura adauga o schimbare pentru indemnizatia de conducere
		/// </summary>
		/// <param name="angajatId">Id-ul angajatului</param>
		/// <param name="indemnizatieConducere">Indemnizatia de conducere</param>
		/// <param name="dataStart">Data de inceput</param>
		/// <param name="dataEnd">Data de sfarsit</param>
		public void InsertSchimbareIndemnizatieConducere(long angajatId, decimal indemnizatieConducere, DateTime dataStart, DateTime dataEnd)
		{
			SqlParameter[] parameters = 
				{
					new SqlParameter("@AngajatID", SqlDbType.BigInt, 10),
					new SqlParameter("@IndemnizatieConducere", SqlDbType.Money, 8),
					new SqlParameter("@DataStart", SqlDbType.DateTime, 8),
					new SqlParameter("@DataEnd", SqlDbType.DateTime, 8)
				};
			parameters[0].Value = angajatId;
			parameters[1].Value = indemnizatieConducere;
			parameters[2].Value = dataStart;
			parameters[3].Value = dataEnd;

			RunProcedure("tm_UpdatePerioadaZileIndeminzatieConducereAngajat", parameters);
		}
		#endregion

		#region InsertSchimbareInvaliditate
		/// <summary>
		/// Procedura adauga o schimbare pentru indemnizatia de conducere
		/// </summary>
		/// <param name="angajatId">Id-ul angajatului</param>
		/// <param name="invaliditate">Invaliditatea</param>
		/// <param name="dataStart">Data de inceput</param>
		/// <param name="dataEnd">Data de sfarsit</param>
		public void InsertSchimbareInvaliditate(long angajatId, int invaliditate, DateTime dataStart, DateTime dataEnd)
		{
			SqlParameter[] parameters = 
				{
					new SqlParameter("@AngajatID", SqlDbType.BigInt, 10),
					new SqlParameter("@Invaliditate", SqlDbType.SmallInt, 2),
					new SqlParameter("@DataStart", SqlDbType.DateTime, 8),
					new SqlParameter("@DataEnd", SqlDbType.DateTime, 8)
				};
			parameters[0].Value = angajatId;
			parameters[1].Value = invaliditate;
			parameters[2].Value = dataStart;
			parameters[3].Value = dataEnd;

			RunProcedure("tm_UpdatePerioadaZileInvaliditateAngajat", parameters);
		}
		#endregion

		#region InsertSchimbareCategorie
		/// <summary>
		/// Procedura adauga o schimbare pentru indemnizatia de conducere
		/// </summary>
		/// <param name="angajatId">Id-ul angajatului</param>
		/// <param name="categorieId">Id-ul categoriei</param>
		/// <param name="dataStart">Data de inceput</param>
		/// <param name="dataEnd">Data de sfarsit</param>
		public void InsertSchimbareCategorie(long angajatId, int categorieId, DateTime dataStart, DateTime dataEnd)
		{
			SqlParameter[] parameters = 
				{
					new SqlParameter("@AngajatID", SqlDbType.BigInt, 10),
					new SqlParameter("@CategorieID", SqlDbType.Int, 4),
					new SqlParameter("@DataStart", SqlDbType.DateTime, 8),
					new SqlParameter("@DataEnd", SqlDbType.DateTime, 8)
				};
			parameters[0].Value = angajatId;
			parameters[1].Value = categorieId;
			parameters[2].Value = dataStart;
			parameters[3].Value = dataEnd;

			RunProcedure("tm_UpdatePerioadaZileCategorieIDAngajat", parameters);
		}
		#endregion

		#region InsertCapatIntervalSchimbareAngajat
		/// <summary>
		/// Procedura adauga un capat de interval
		/// </summary>
		/// <param name="dataStart">Data de inceput</param>
		/// <param name="dataEnd">Data de sfarsit</param>
		/// <param name="angajatId">Id-ul angajatului</param>
		/// <param name="programLucru">Programul de lucru</param>
		/// <param name="salariuBaza">Salariu de baza</param>
		/// <param name="indemnizatieConducere">Indemnizatia de conducere</param>
		/// <param name="invaliditate">Tipul de invaliditate</param>
		/// <param name="categorieId">Id-ul categoriei</param>
		public void InsertCapatIntervalSchimbareAngajat(DateTime dataStart, DateTime dataEnd, long angajatId, int programLucru, decimal salariuBaza, decimal indemnizatieConducere, int invaliditate, int categorieId)
		{
			DateTime oraStart = new DateTime( dataStart.Year, dataStart.Month, dataStart.Day, 0, 0, 0 );
			DateTime oraEnd = new DateTime( dataStart.Year, dataStart.Month, dataStart.Day, 0, 0, 0 );
			NomenclatorTipOreLucrate tipuri = new NomenclatorTipOreLucrate(this.ConnectionString);
			DataSet ds = tipuri.GetTipuriOreLucrate();
			
			if (ds != null && ds.Tables[ 0 ].Rows.Count > 0)
			{
				int tipIntervalId = int.Parse( ds.Tables[ 0 ].Rows[ 0 ][ "TipIntervalID" ].ToString());
				SqlParameter[] parameters = 
				{
					new SqlParameter("@IntervalAngajatID", SqlDbType.Int, 4),
					new SqlParameter("@Data", SqlDbType.DateTime, 8),
					new SqlParameter("@TipIntervalID", SqlDbType.Int, 4),
					new SqlParameter("@OraStart", SqlDbType.DateTime, 8),
					new SqlParameter("@OraEnd", SqlDbType.DateTime, 8),
					new SqlParameter("@AngajatID", SqlDbType.Int, 4),
					new SqlParameter("@ProgramLucru", SqlDbType.Int, 4),
					new SqlParameter("@SalariuBaza", SqlDbType.Money, 8),
					new SqlParameter("@IndemnizatieConducere", SqlDbType.Money, 8),
					new SqlParameter("@Invaliditate", SqlDbType.SmallInt, 2),
					new SqlParameter("@CategorieID", SqlDbType.Int, 4),
					new SqlParameter("@tip_actiune", SqlDbType.Int, 4)
				};
				parameters[0].Value = -1;
				parameters[1].Value = dataStart;
				parameters[2].Value = tipIntervalId;
				parameters[3].Value = oraStart;
				parameters[4].Value = oraEnd;
				parameters[5].Value = angajatId;
				parameters[6].Value = programLucru;
				parameters[7].Value = salariuBaza;
				parameters[8].Value = indemnizatieConducere;
				parameters[9].Value = invaliditate;
				parameters[10].Value = categorieId;
				parameters[11].Value = 0;

				RunProcedure("tm_InsertUpdateDeleteCapatIntervalAngajat", parameters);
			}
		}
		#endregion

		#region UpdateCapatIntervalSchimbareAngajat
		/// <summary>
		/// Procedura actualizeaza un capat de interval
		/// </summary>
		/// <param name="intervalId">Id-ul intervalului</param>
		/// <param name="dataStart">Data de inceput</param>
		/// <param name="dataEnd">Data de sfarsit</param>
		/// <param name="angajatId">Id-ul angajatului</param>
		/// <param name="programLucru">Programul de lucru</param>
		/// <param name="salariuBaza">Salariu de baza</param>
		/// <param name="indemnizatieConducere">Indemnizatia de conducere</param>
		/// <param name="invaliditate">Tipul de invaliditate</param>
		/// <param name="categorieId">Id-ul categoriei</param>
		public void UpdateCapatIntervalSchimbareAngajat(int intervalId, DateTime dataStart, DateTime dataEnd, long angajatId, int programLucru, decimal salariuBaza, decimal indemnizatieConducere, int invaliditate, int categorieId)
		{
			DateTime oraStart = new DateTime( dataStart.Year, dataStart.Month, dataStart.Day, 0, 0, 0 );
			DateTime oraEnd = new DateTime( dataStart.Year, dataStart.Month, dataStart.Day, 0, 0, 0 );
			NomenclatorTipOreLucrate tipuri = new NomenclatorTipOreLucrate(this.ConnectionString);
			DataSet ds = tipuri.GetTipuriOreLucrate();
			
			if (ds != null && ds.Tables[ 0 ].Rows.Count > 0)
			{
				int tipIntervalId = int.Parse( ds.Tables[ 0 ].Rows[ 0 ][ "TipIntervalID" ].ToString());
				SqlParameter[] parameters = 
				{
					new SqlParameter("@IntervalAngajatID", SqlDbType.Int, 4),
					new SqlParameter("@Data", SqlDbType.DateTime, 8),
					new SqlParameter("@TipIntervalID", SqlDbType.Int, 4),
					new SqlParameter("@OraStart", SqlDbType.DateTime, 8),
					new SqlParameter("@OraEnd", SqlDbType.DateTime, 8),
					new SqlParameter("@AngajatID", SqlDbType.Int, 4),
					new SqlParameter("@ProgramLucru", SqlDbType.Int, 4),
					new SqlParameter("@SalariuBaza", SqlDbType.Money, 8),
					new SqlParameter("@IndemnizatieConducere", SqlDbType.Money, 8),
					new SqlParameter("@Invaliditate", SqlDbType.SmallInt, 2),
					new SqlParameter("@CategorieID", SqlDbType.Int, 4),
					new SqlParameter("@tip_actiune", SqlDbType.Int, 4)
				};

				parameters[0].Value = intervalId;
				parameters[1].Value = dataStart;
				parameters[2].Value = tipIntervalId;
				parameters[3].Value = oraStart;
				parameters[4].Value = oraEnd;
				parameters[5].Value = angajatId;
				parameters[6].Value = programLucru;
				parameters[7].Value = salariuBaza;
				parameters[8].Value = indemnizatieConducere;
				parameters[9].Value = invaliditate;
				parameters[10].Value = categorieId;
				parameters[11].Value = 1;

				RunProcedure("tm_InsertUpdateDeleteCapatIntervalAngajat", parameters);
			}
		}
		#endregion

		#region GetCategorieCorspunzatoareDinLunaActiva
		/// <summary>
		/// Returneaza id-ul categoriei
		/// </summary>
		/// <param name="categorieId">Id-ul categoriei</param>
		/// <param name="angajatId">Id-ul angajatului</param>
		/// <returns>Returneaza id-ul categoriei</returns>
		public int GetCategorieCorspunzatoareDinLunaActiva(int categorieId, long angajatId)
		{
			SqlParameter[] parameters = 
				{
					new SqlParameter("@CategorieID", SqlDbType.Int, 4)
				};
			parameters[0].Value = categorieId;
			DataSet dsCategorie = RunProcedure("salarii_GetCategorie", parameters, "salarii_GetCategorie");

			AdminAngajator ang = new AdminAngajator(this.ConnectionString);
			int angajatorId = int.Parse(ang.LoadInfoAngajatori().Tables[0].Rows[0]["AngajatorId"].ToString());
			SqlParameter[] parameters1 = 
				{
					new SqlParameter("@AngajatorID", SqlDbType.Int, 4)
				};
			parameters1[0].Value = angajatorId;
			DataSet ds = RunProcedure("salarii_GetAngajatiCategoriiLunaActiva", parameters1, "salarii_GetAngajatiCategoriiLunaActiva");

			string categText = "";
			if (dsCategorie != null && dsCategorie.Tables[ 0 ].Rows.Count > 0)
			{
				categText = dsCategorie.Tables[ 0 ].Rows[ 0 ][ "Denumire" ].ToString();
			}
			if	(ds != null && ds.Tables[ 0 ].Rows.Count > 0)
			{
				foreach( DataRow dr in ds.Tables[ 0 ].Rows )
				{
					if ( dr[ "Denumire" ].ToString() == categText )
					{
						return int.Parse( dr[ "CategorieID" ].ToString());
					}
				}
			}
			return -1;
		}
		#endregion

		#region GetCapatIntervalAngajatZi
		/// <summary>
		/// Procedura selecteaza capatul de interval pentru o data a unui angajat
		/// </summary>
		/// <param name="data">Data pentru care se selecteaza capatul de interval</param>
		/// <param name="angajatId">Id-ul angajatului</param>
		/// <returns>Returneaza un DataSet care contine aceste date</returns>
		public DataSet GetCapatIntervalAngajatZi(DateTime data, long angajatId)
		{
			SqlParameter[] parameters = 
				{
					new SqlParameter("@Data", SqlDbType.DateTime, 8),
					new SqlParameter("@AngajatID", SqlDbType.Int, 4)
				};

			parameters[0].Value = data;
			parameters[1].Value = angajatId;

			return RunProcedure("tm_GetCapatIntervalAngajatZi", parameters, "tm_GetCapatIntervalAngajatZi");
		}
		#endregion

		#region DeleteSchimbare
		/// <summary>
		/// Procedura sterge o schimbare
		/// </summary>
		/// <param name="dataStart">Data de inceput a schimbarii</param>
		/// <param name="dataEnd">Data de sfarsit a schimbarii</param>
		/// <param name="angajatId">Id-ul angajatului</param>
		public void DeleteSchimbare(DateTime dataStart, DateTime dataEnd, long angajatId)
		{
			DataSet ds = LoadIstoricSchimbari(angajatId);
			if (ds.Tables[ 0 ].Rows.Count > 1)
			{
				DataRow ints = GetPrevIntervalSchimbareByDataStart(dataStart, angajatId);
				int categorieId = GetCategorieCorspunzatoareDinLunaActiva(int.Parse(ints["CategorieId"].ToString()), angajatId);
				if (/*int.Parse(ints["ProgramLucru"].ToString()) != -1*/ ints != null)
				{
					SqlParameter[] parameters = 
						{
							new SqlParameter("@AngajatID", SqlDbType.Int, 4),
							new SqlParameter("@DataStart", SqlDbType.DateTime, 8),
							new SqlParameter("@DataEnd", SqlDbType.DateTime, 8),
							new SqlParameter("@ProgramLucru", SqlDbType.Int, 4),
							new SqlParameter("@SalariuBaza", SqlDbType.Money, 8),
							new SqlParameter("@IndemnizatieConducere", SqlDbType.Money, 8),
							new SqlParameter("@Invaliditate", SqlDbType.SmallInt, 2),
							new SqlParameter("@CategorieID", SqlDbType.Int, 4)
						};

					parameters[0].Value = angajatId;
					parameters[1].Value = ints["DataStart"];
					parameters[2].Value = ints["DataEnd"];
					parameters[3].Value = ints["ProgramLucru"];
					parameters[4].Value = ints["SalariuBaza"];
					parameters[5].Value = ints["IndemnizatieConducere"];
					parameters[6].Value = ints["Invaliditate"];
					parameters[7].Value = categorieId;

					RunProcedure("tm_DeleteSchimbareAngajat", parameters);
				
					ds = LoadIstoricSchimbari(angajatId);
					DataRow intsPrevLast = GetLastIntervalSchimbare(angajatId);
					int categorieId1 = GetCategorieCorspunzatoareDinLunaActiva(int.Parse(intsPrevLast["CategorieId"].ToString()), angajatId);
					SqlParameter[] parameters1 = 
						{
							new SqlParameter("@AngajatID", SqlDbType.Int, 4),
							new SqlParameter("@ProgramLucru", SqlDbType.Int, 4),
							new SqlParameter("@SalariuBaza", SqlDbType.Money, 8),
							new SqlParameter("@IndemnizatieConducere", SqlDbType.Money, 8),
							new SqlParameter("@Invaliditate", SqlDbType.SmallInt, 2),
							new SqlParameter("@CategorieID", SqlDbType.Int, 4)
						};

					parameters1[0].Value = angajatId;
					parameters1[1].Value = intsPrevLast["ProgramLucru"];
					parameters1[2].Value = intsPrevLast["SalariuBaza"];
					parameters1[3].Value = intsPrevLast["IndemnizatieConducere"];
					parameters1[4].Value = intsPrevLast["Invaliditate"];
					parameters1[5].Value = categorieId1;

					RunProcedure("UpdateAngajatDateSchimbate", parameters1);
				}
			}
		}
		#endregion

		#region GetPrevIntervalSchimbareByDataStart
		/// <summary>
		/// Procedura determina un interval al angajatului dupa data de start
		/// </summary>
		/// <param name="dataStart">Data de start</param>
		/// <param name="angajatId">Id-ul angajatului</param>
		/// <returns>Returneaza un obiect DataRow care contine aceste date</returns>
		public DataRow GetPrevIntervalSchimbareByDataStart(DateTime dataStart, long angajatId)
		{
			DataSet ds = LoadIstoricSchimbari(angajatId);
			for (int i=0; i<ds.Tables[ 0 ].Rows.Count; i++)
			{
				DataRow dr = ds.Tables[ 0 ].Rows[ i ];
				if ((DateTime)dr[ "DataStart" ] == dataStart)
				{
					if( i == 0 )
					{
						ds.Tables[ 0 ].Rows[1]["DataStart"] = dataStart;
						ds.Tables[ 0 ].Rows[1]["DataEnd"] = (DateTime)ds.Tables[ 0 ].Rows[ 0 ][ "DataEnd" ];
						return ds.Tables[ 0 ].Rows[1];
					}
					else
					{
						ds.Tables[ 0 ].Rows[i-1]["DataStart"] = dataStart;
						ds.Tables[ 0 ].Rows[i-1]["DataEnd"] = (DateTime)ds.Tables[ 0 ].Rows[ i ][ "DataEnd" ];
						return ds.Tables[ 0 ].Rows[i-1];
					}
				}
			}
			return null;
		}
		#endregion

		#region GetIntervalSchimbareByDataInside
		/// <summary>
		/// Procedura determina un interval al angajatului dupa date din intrval
		/// </summary>
		/// <param name="data">Data din interval</param>
		/// <param name="angajatId">Id-ul angajatului</param>
		/// <returns>Returneaza un DataRow care contine aceste date</returns>
		public DataRow GetIntervalSchimbareByDataInside(DateTime data, long angajatId)
		{
			DataSet ds = LoadIstoricSchimbari(angajatId);
			for(int i=0; i<ds.Tables[ 0 ].Rows.Count; i++ )
			{
				DataRow dr = ds.Tables[ 0 ].Rows[ i ];
				if ( (DateTime.Parse(dr[ "DataStart" ].ToString()) <= data) && (data <= (DateTime.Parse(dr[ "DataEnd" ].ToString()))) )
				{
					dr["DataEnd"] = data;
					return dr;
				}
			}
			return null;
		}
		#endregion

		#region GetLastIntervalSchimbare
		/// <summary>
		/// Procedura selecteaza ultimul interval
		/// </summary>
		/// <param name="angajatId">Id-ul angajatului</param>
		/// <returns>Returneaza un DataRow care contine aceste date</returns>
		public DataRow GetLastIntervalSchimbare(long angajatId)
		{
			DataSet ds = LoadIstoricSchimbari(angajatId);
			if (ds.Tables[ 0 ].Rows.Count > 0)
			{
				return ds.Tables[ 0 ].Rows[ ds.Tables[ 0 ].Rows.Count-1 ];
			}
			else
			{
				return null;
			}
		}
		#endregion

		#region DataInLunaActiva
		/// <summary>
		/// Procedura verifica daca o data este in luna activa
		/// </summary>
		/// <param name="dt">Data care se verifica</param>
		/// <returns>Returneaza true daca e in interval si false altfel</returns>
		public bool DataInLunaActiva(DateTime dt)
		{
			AdminAngajator ang = new AdminAngajator(this.ConnectionString);
			int angajatorId = int.Parse(ang.LoadInfoAngajatori().Tables[0].Rows[0]["AngajatorId"].ToString());

			Luni l = new Luni(ConnectionString);
			LunaData ld = l.GetLunaActiva(angajatorId);

			return ( dt.Month==ld.Data.Month && dt.Year==ld.Data.Year ) ? true : false;
		}
		#endregion

		#region DataEsteZiSarbatoare
		/// <summary>
		/// Procedura verifica daca o anumita data este specificata ca si sarbatoare
		/// </summary>
		/// <param name="data">Data</param>
		/// <returns>Returneaza true daca este sarbatoare si false altfel</returns>
		public bool DataEsteZiSarbatoare(DateTime data)
		{
			SqlParameter[] parameters = 
						{
							new SqlParameter("@Data", SqlDbType.DateTime, 8)
						};

			parameters[0].Value = data;
			DataSet ds = RunProcedure("spCheckIfDataEsteSarbatoare", parameters, "CheckIfDataEsteSarbatoare");

			if (ds.Tables[0].Rows.Count > 0)
			{
				return bool.Parse(ds.Tables[0].Rows[0]["Sarbatoare"].ToString());
			}
			else
			{
				return false;
			}
		}
		#endregion
	}
}
