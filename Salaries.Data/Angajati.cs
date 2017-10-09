using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections;

namespace Salaries.Data
{
	public class DetaliiAngajati
	{
		/*public long AngajatID;
		public decimal SalariuBaza;
		public decimal IndemnizatieConducere;
		public decimal Sporuri;
		public decimal AlteAdaosuri;
		public int CategorieID;
		public int ProgramLucru;
		public int InvaliditateID;
		// Begin --  Pt impozitul anual
		public bool AreAlteVenituri;
		public bool SolicitaDeduceri;
		public string NumeIntreg;
		public string Marca;*/
		// End
	}

	public class DetaliiAngajatImpozitAnual
	{
		/*public long AngajatID;
		public string Marca;
		public string NumeIntreg;
		public double ImpozitAnual;
		public double SumaRestituit;
		public double SumaRecuperat;*/														
	}

	public class VenituriDeduceri
	{
		/*public long AngajatID;
		public bool areAlteVenituri;
		public bool solicitaDeduceri;*/
	}


	/// <summary>
	/// Administrarea angajatilor.
	/// </summary>
	public class Angajati : Salaries.Data.DbObject
	{
		#region AngajatiSalarii
		/// <summary>
		/// Constructorul cu parametru
		/// </summary>
		/// <param name="connectionString">Stringul de conexiune la baza de date</param>
		public Angajati(string connectionString) : base (connectionString)
		{}
		#endregion
		
		/*#region GetAllAngajatiIDs
		/// <summary>
		/// Returneaza un ArrayList cu toate ID-urile angajatilor ce apartin de un angajator.
		/// </summary>
		/// <param name="angajatorId"></param>
		/// <returns> Un ArrayList cu ID-urile angajatilor.</returns>
		public ArrayList GetAllAngajatiIDs(int angajatorId)
		{
			ArrayList alAng = new ArrayList();
			long angajatId;
			SqlParameter[] parameters = {new SqlParameter("@AngajatorID", SqlDbType.Int, 4)};
			parameters[0].Value = angajatorId;
			DataSet ds =  RunProcedure("sal_GetAllAngForSal", parameters, "Angajati");
			foreach( DataRow dr in ds.Tables["Angajati"].Rows)
			{
				angajatId = long.Parse(dr["AngajatID"].ToString());
				alAng.Add(angajatId);
			}
			return alAng;			
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

		#region GetSal_SituatieLunaraAngajatiIDs_Names
		/// <summary>
		/// Returneaza numele si ID-urile angajatilor ce apartin de un angajator.
		/// </summary>
		/// <param name="angajatorId"> ID-ul angajatorului.</param>
		/// <param name="lunaId"> ID-ul lunii.</param>
		/// <returns> Un ArrayList cu ID-urile si numele angajatilor.</returns>
		/// <remarks>Alex Ciobanu</remarks>
		public SortedList GetSal_SituatieLunaraAngajatiIDs_Names(int angajatorId, int lunaId)
		{
			SortedList alAng = new SortedList();
			int AngajatID;
			SqlParameter[] parameters = 
							{
								new SqlParameter("@AngajatorID", SqlDbType.Int, 4),
								new SqlParameter("@LunaID", SqlDbType.Int, 4)
							};
			
			parameters[0].Value = angajatorId;
			parameters[1].Value = lunaId;
			
			DataSet ds =  RunProcedure("spGetAllAngajatiIDs_Names", parameters, "AngajatiIDsNames");
			
			foreach( DataRow dr in ds.Tables["AngajatiIDsNames"].Rows)
			{
				AngajatID = int.Parse(dr["AngajatID"].ToString());
				alAng.Add(AngajatID,dr["NumeIntreg"].ToString());
			}
			
			return alAng;			
		}
		#endregion

		#region GetAllAngajati
		/// <summary>
		/// Procedura selecteaza toti angajatii
		/// </summary>
		/// <param name="angajatorId">Id-ul angajatorului</param>
		/// <returns>Returneaza lista cu angajati</returns>
		public ArrayList GetAllAngajati(int angajatorId)
		{
			ArrayList alAng = new ArrayList();
			SqlParameter[] parameters = {new SqlParameter("@AngajatorID", SqlDbType.Int, 4)};
			parameters[0].Value = angajatorId;
			DataSet ds =  RunProcedure("sal_GetAllAngForSal", parameters, "Angajati");
			foreach( DataRow dr in ds.Tables["Angajati"].Rows)
			{
				DetaliiAngajati detAng= new DetaliiAngajati();
				detAng.AngajatID = long.Parse(dr["AngajatID"].ToString());
				detAng.SalariuBaza = decimal.Parse(dr["SalariuBazaActual"].ToString());
				detAng.IndemnizatieConducere = decimal.Parse(dr["IndemnizatieConducereActual"].ToString());
				if(!Convert.IsDBNull(dr["Sporuri"]))
					detAng.Sporuri = decimal.Parse(dr["Sporuri"].ToString());
				else
					detAng.Sporuri = decimal.Parse("0");
				if(!Convert.IsDBNull(dr["AlteAdaosuri"]))
					detAng.AlteAdaosuri = decimal.Parse(dr["AlteAdaosuri"].ToString());
				else
					detAng.AlteAdaosuri = decimal.Parse("0");
				detAng.CategorieID = int.Parse(dr["CategorieID"].ToString());
				detAng.ProgramLucru = int.Parse(dr["ProgramLucru"].ToString());
				detAng.InvaliditateID = int.Parse( dr[ "InvaliditateID" ].ToString());
				detAng.AreAlteVenituri = bool.Parse(dr["AreVenituri"].ToString());
				detAng.SolicitaDeduceri = bool.Parse(dr["AreDeduceri"].ToString());
				detAng.NumeIntreg = dr["NumeIntreg"].ToString();
				detAng.Marca = dr["Marca"].ToString();

				alAng.Add(detAng);

			}
			return alAng;			
		}
		#endregion

		#region GetDetaliiAngajat
		/// <summary>
		/// Procedura selecteaza un angajat
		/// </summary>
		/// <param name="angajatId">Id-ul angajatului</param>
		/// <returns>Returneaza un DataSet care contine aceste date</returns>
		public DataSet GetDetaliiAngajat(long angajatId)
		{
			try
			{
				SqlParameter[] parameters = {new SqlParameter("@AngajatID", SqlDbType.Int, 4)};
				parameters[0].Value = angajatID;
				DataSet ds =  RunProcedure("GetAngajatInfo", parameters, "Angajati");
				return ds;
			}
			catch
			{
				return null;
			}
		}
		#endregion

		#region GetAllAngajatiCuImpozitAnual
		/// <summary>
		/// Procedura selecteaza angajatii cu impozit anual
		/// </summary>
		/// <param name="angajatorId">Id-ul angajatorului</param>
		/// <param name="year">Anul din care se selecteaza angajatii</param>
		/// <returns>Returneaza lista cu angajati</returns>
		public ArrayList GetAllAngajatiCuImpozitAnual(int angajatorId, int year)
		{
			ArrayList alAng = new ArrayList();
			SqlParameter[] parameters = {
											new SqlParameter("@AngajatorID", SqlDbType.Int, 4),
											new SqlParameter("@year", SqlDbType.Int, 4)
										};
			parameters[0].Value = angajatorId;
			parameters[1].Value = year;

			DataSet ds =  RunProcedure("sal_GetAllAngImpozitAnual", parameters, "Angajati");
			foreach( DataRow dr in ds.Tables["Angajati"].Rows)
			{
				DetaliiAngajatImpozitAnual detAng= new DetaliiAngajatImpozitAnual();
				detAng.AngajatID = long.Parse(dr["AngajatID"].ToString());
				detAng.NumeIntreg = dr["NumeIntreg"].ToString();
				detAng.Marca = dr["Marca"].ToString();
				detAng.ImpozitAnual = double.Parse(dr["ImpozitAnual"].ToString());
				detAng.SumaRecuperat = double.Parse(dr["SumaRecuperat"].ToString());
				detAng.SumaRestituit = double.Parse(dr["SumaRestituit"].ToString());

				alAng.Add(detAng);
			}
			return alAng;
		}
		#endregion

		#region GetPersoaneInIntretinere
		/// <summary>
		/// Procedura selecteaza persoanele in intretinere ale unui angajat
		/// </summary>
		/// <param name="angajatId">Id-ul angajatului</param>
		/// <returns>Returneaza un DataSet care contine datele selectate</returns>
		public DataSet GetPersoaneInIntretinere(int angajatId)
		{
			SqlParameter[] parameters = { new SqlParameter("@AngajatID", SqlDbType.Int,4 ) };
			parameters[0].Value = angajatId;
			
			return RunProcedure("GetAngajatPersoaneInIntretinere", parameters, "AngajatiPersoaneInIntretinere");
		}
		#endregion

		#region SetCheltuieliDeduceri
		/// <summary>
		/// Procedura seteaza cheltuieli
		/// </summary>
		/// <param name="cheltuieli"></param>
		/// <param name="deduceri"></param>
		/// <param name="year"></param>
		public void SetCheltuieliDeduceri(string cheltuieli, int deduceri, int year)
		{
			SqlParameter[] parameters = {
											new SqlParameter("@CheltuieliProfesionale", SqlDbType.NVarChar, 15),
											new SqlParameter("@DeduceriPersonale", SqlDbType.Int, 4),
											new SqlParameter("@An", SqlDbType.Int, 4)
										};
			parameters[0].Value = cheltuieli;
			parameters[1].Value = deduceri;
			parameters[2].Value = year;
			DataSet ds =  RunProcedure("sal_InsertCheltuileiDeduceri", parameters, "Angajati");
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
		public bool VerificaDateSalariuPtUltimele3Luni(int angajatId, int lunaId)
		{
			bool suntDate;

			// Sunt declarati parametrii.
			SqlParameter[] parameters = { new SqlParameter("@AngajatID", SqlDbType.Int, 4 ),
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
		public double GetMedieZilnicaConcediuDeOdihna(int angajatId, int lunaId)
		{
			double medieZilnica = 0;
			
			// Sunt declarati parametrii.
			SqlParameter[] parameters = { new SqlParameter("@AngajatID", SqlDbType.Int, 4 ),
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

		#region GetMedieZilnicaConcediuDeBoala
		/// <summary>
		/// Calculeaza media zilnica a unui angajat pentru concediul de boala.
		/// </summary>
		/// <param name="angajatId">Id-al angajatului pentru care se face media</param>
		/// <param name="lunaId">Id-ul lunii pentru care se face media</param>
		/// <returns>Returneaza valoarea mediei zilnice</returns>
		public double GetMedieZilnicaConcediuDeBoala(int angajatId, int lunaId)
		{
			double medieZilnica = 0;
			
			// Sunt declarati parametrii.
			SqlParameter[] parameters = { new SqlParameter("@AngajatID", SqlDbType.Int, 4 ),
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
		#endregion*/
	}
}
