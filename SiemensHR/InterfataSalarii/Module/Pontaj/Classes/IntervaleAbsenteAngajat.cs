using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Data.SqlTypes;

using SiemensTM.utils;
using Salaries.Business;

namespace SiemensTM.Classes
{
	/// <summary>
	/// Summary description for IntervaleAbsenteAngajat.
	/// 
	/// Modificat: Oprescu Claudia
	/// Descriere: S-au adaugat si parametrii la procedurile stocate pentru adaugare si actualizare 
	///				pentru campurile serie si numar
	/// </summary>
	public class IntervaleAbsenteAngajat
	{
		#region Variabile
		private SqlConnection m_con;
		private long AngajatID;
		private Salaries.Configuration.ModuleSettings settings;
		#endregion
		
		#region Constructor
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="angajatID">Id-ul angajatului</param>
		public IntervaleAbsenteAngajat(long angajatID)
		{
			this.AngajatID = angajatID;
			settings = Salaries.Configuration.ModuleConfig.GetSettings();
			m_con = new SqlConnection(settings.ConnectionString);
		}
		#endregion
		
		#region InsertIntervalAbsenteAngajat
		/// <summary>
		/// Procedura adauga un interval de absenta pentru angajat
		/// </summary>
		/// <param name="TipAbsentaID">Id-ul tipului de absenta</param>
		/// <param name="DataStart">Data se inceput</param>
		/// <param name="DataEnd">Data de sfarsit</param>
		/// <param name="Observatii">Observatii</param>
		/// <param name="boalaID">Id-ul bolii</param>
		/// <param name="continuareAbsenta">Continuare absenta sau nu</param>
		/// <param name="medieZilnica">Media zilnica asociata</param>
		/// <param name="serie">Seriea</param>
		/// <param name="numar">Numarul</param>
		public void InsertIntervalAbsenteAngajat( int TipAbsentaID, DateTime DataStart, DateTime DataEnd, string Observatii, int boalaID, bool continuareAbsenta, double medieZilnica, string serie, string numar,bool certificatInitial, string serieCertificatInitial, string  numarCertificatInitial, DateTime dataAcordarii, string cnpCopil, string loculPrescrierii, string codUrgenta,string nrAvizMedicExpert)
		{
			//Oprescu Claudia
			//se verifica daca nu este continuare de concediu medical. Daca este atunci se copiaza seria si numarul de la concediu medical altfel se adauga null
			string SerieCertificatInitial = null, NumarCertificatInitial = null;

			UtilitiesDb ut = new UtilitiesDb(settings.ConnectionString);
			if (TipAbsentaID == ut.GetContinuareConcediuMedicalID())
			{
				//se apeleaza procedura stocata pentru a se afla seria si numarul pentru concediul medical asociat
				SqlCommand cmd = new SqlCommand("tm_IntervaleAbsentaContinuareConcediuMedical", m_con);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add(UtilitiesDb.AddInputParameter("@AngajatID", SqlDbType.Int, 4, this.AngajatID));
				cmd.Parameters.Add(UtilitiesDb.AddOutputParameter("@SerieCertificatInitial", SqlDbType.NVarChar, 10, ""));
				cmd.Parameters.Add(UtilitiesDb.AddOutputParameter("@NumarCertificatInitial", SqlDbType.NVarChar, 50, ""));
				
				m_con.Open();
				cmd.ExecuteNonQuery();
				m_con.Close();

				SerieCertificatInitial = cmd.Parameters[1].Value.ToString().TrimEnd();
				NumarCertificatInitial = cmd.Parameters[2].Value.ToString().TrimEnd();
			}

			SqlCommand myCommand = new SqlCommand("tm_InsertUpdateDeleteIntervalAbsenta", m_con);
			myCommand.CommandType = CommandType.StoredProcedure;
				
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@tip_actiune", SqlDbType.Int, 4, 0));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@IntervalAbsentaID", SqlDbType.Int, 4, -1));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@TipAbsentaID", SqlDbType.Int, 4, TipAbsentaID));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@DataStart", SqlDbType.DateTime, 8, DataStart));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@DataEnd", SqlDbType.DateTime, 8, DataEnd));				
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@AngajatID", SqlDbType.Int, 4, this.AngajatID));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Observatii", SqlDbType.NText, 16, Observatii));

			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@BoalaID", SqlDbType.Int, 4, boalaID ));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Serie", SqlDbType.NVarChar, 10, serie));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Numar", SqlDbType.NVarChar, 50, numar));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@SerieCertificatInitial", SqlDbType.NVarChar, 10, serieCertificatInitial));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@NumarCertificatInitial", SqlDbType.NVarChar, 50, numarCertificatInitial));

			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@ContinuareAbsenta", SqlDbType.Bit, 1, continuareAbsenta ));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@MedieZilnica", SqlDbType.Real, 4, medieZilnica ));

			//----------------------Chiperescu Daniela 22.02.2011------------------
			if (boalaID == -1)
			{
				myCommand.Parameters.Add("@EsteCertificat", SqlDbType.Bit, 1).Value = System.DBNull.Value;
				//myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@EsteCertificat", SqlDbType.Bit, 1, DBNull.Value.ToString()));
			}
			else
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@EsteCertificat", SqlDbType.Bit,1, certificatInitial));
			if (boalaID == -1)
			{
				myCommand.Parameters.Add("@DataAcordariiCertificat", SqlDbType.DateTime, 8).Value = System.DBNull.Value;
				//myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@DataAcordariiCertificat", SqlDbType.DateTime,8, DBNull.Value.ToString()));
			}
			else
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@DataAcordariiCertificat", SqlDbType.DateTime,8, dataAcordarii));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@CnpCopil", SqlDbType.NVarChar,13, cnpCopil));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@LocPrescriereCertificat", SqlDbType.NVarChar,50, loculPrescrierii));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@CodUrgenta", SqlDbType.NVarChar,50, codUrgenta));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@NrAvizMedicExpert", SqlDbType.NVarChar,50, nrAvizMedicExpert));
			//----------------------Chiperescu Daniela 22.02.2011------------------

			m_con.Open();
			myCommand.ExecuteNonQuery();
			m_con.Close();
		}
		#endregion
	
		#region UpdateIntervalAbsenteAngajat
		/// <summary>
		/// Procedura actualizeaza un interval de absenta
		/// </summary>
		/// <param name="IntervalAbsentaID">Id-ul intervalului de absenta</param>
		/// <param name="TipAbsentaID">Id-ul tipului de absenta</param>
		/// <param name="DataStart">Data se inceput</param>
		/// <param name="DataEnd">Data de sfarsit</param>
		/// <param name="Observatii">Observatii</param>
		/// <param name="boalaID">Id-ul bolii</param>
		/// <param name="continuareAbsenta">Continuare absenta sau nu</param>
		/// <param name="medieZilnica">Media zilnica asociata</param>
		/// <param name="serie">Seriea</param>
		/// <param name="numar">Numarul</param>
		public void UpdateIntervalAbsenteAngajat( int IntervalAbsentaID, int TipAbsentaID, DateTime DataStart, DateTime DataEnd, string Observatii, int BoalaID, bool continuareAbsenta, double medieZilnica, string serie, string numar , bool certificatInitial, string serieCertificat, string numarCertificat, DateTime dataAcordarii, string cnpCopil, string locPrescriere, string codUrgenta, string nrAvizMedical)
		{
			try
			{
				//Oprescu Claudia
				//se verifica daca nu este continuare de concediu medical. Daca este atunci se copiaza seria si numarul de la concediu medical altfel se adauga null
				string SerieCertificatInitial = null, NumarCertificatInitial = null;

				UtilitiesDb ut = new UtilitiesDb(settings.ConnectionString);
				if (TipAbsentaID == ut.GetContinuareConcediuMedicalID())
				{
					//se apeleaza procedura stocata pentru a se afla seria si numarul pentru concediul medical asociat
					SqlCommand cmd = new SqlCommand("tm_IntervaleAbsentaContinuareConcediuMedical", m_con);
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.Parameters.Add(UtilitiesDb.AddInputParameter("@AngajatID", SqlDbType.Int, 4, this.AngajatID));
					cmd.Parameters.Add(UtilitiesDb.AddOutputParameter("@SerieCertificatInitial", SqlDbType.NVarChar, 10, ""));
					cmd.Parameters.Add(UtilitiesDb.AddOutputParameter("@NumarCertificatInitial", SqlDbType.NVarChar, 50, ""));
				
					m_con.Open();
					cmd.ExecuteNonQuery();
					m_con.Close();

					SerieCertificatInitial = cmd.Parameters[1].Value.ToString().TrimEnd();
					NumarCertificatInitial = cmd.Parameters[2].Value.ToString().TrimEnd();
				}

				SqlCommand myCommand = new SqlCommand("tm_InsertUpdateDeleteIntervalAbsenta", m_con);
				myCommand.CommandType = CommandType.StoredProcedure;
				
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@tip_actiune", SqlDbType.Int, 4, 1));
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@IntervalAbsentaID", SqlDbType.Int, 4, IntervalAbsentaID));
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@TipAbsentaID", SqlDbType.Int, 4, TipAbsentaID));
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@DataStart", SqlDbType.DateTime, 8, DataStart));
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@DataEnd", SqlDbType.DateTime, 8, DataEnd));				
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@AngajatID", SqlDbType.Int, 4, this.AngajatID));
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Observatii", SqlDbType.NText, 16, Observatii));
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@BoalaID", SqlDbType.Int, 4, BoalaID ));
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Serie", SqlDbType.NVarChar, 10, serie));
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Numar", SqlDbType.NVarChar, 50, numar));
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@SerieCertificatInitial", SqlDbType.NVarChar, 10, serieCertificat));
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@NumarCertificatInitial", SqlDbType.NVarChar, 50, numarCertificat));
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@ContinuareAbsenta", SqlDbType.Bit, 1, continuareAbsenta ));
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@MedieZilnica", SqlDbType.Real, 4, medieZilnica ));
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@EsteCertificat", SqlDbType.Bit, 1, certificatInitial ));
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@DataAcordariiCertificat", SqlDbType.DateTime, 8, dataAcordarii ));
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@CnpCopil", SqlDbType.NVarChar, 13, cnpCopil));
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@LocPrescriereCertificat", SqlDbType.NVarChar, 50, locPrescriere ));
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@CodUrgenta", SqlDbType.NVarChar, 50, codUrgenta ));
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@NrAvizMedicExpert", SqlDbType.NVarChar, 50,nrAvizMedical ));

				m_con.Open();
				myCommand.ExecuteNonQuery();
				m_con.Close();
			}
			catch (Exception e)
			{
				string x = e.Message;
			}

		}
		#endregion
	
		#region DeleteIntervalAbsenteAngajat
		/// <summary>
		/// Prcoedura sterge un interval de absenta
		/// </summary>
		/// <param name="IntervalAbsenteAngajatID">Id-ul intervalului de absenta</param>
		public void DeleteIntervalAbsenteAngajat(int IntervalAbsenteAngajatID)
		{
			try
			{
				SqlCommand myCommand = new SqlCommand("tm_InsertUpdateDeleteIntervalAbsenta", m_con);
				myCommand.CommandType = CommandType.StoredProcedure;

				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@tip_actiune", SqlDbType.Int, 4, 2));
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@IntervalAbsentaID", SqlDbType.Int, 4, IntervalAbsenteAngajatID ));
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@TipAbsentaID", SqlDbType.Int, 4, 0));
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@DataStart", SqlDbType.DateTime, 8, DateTime.Now ));
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@DataEnd", SqlDbType.DateTime, 8, DateTime.Now ));				
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@AngajatID", SqlDbType.Int, 4, this.AngajatID));
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Observatii", SqlDbType.NText, 16, "" ));
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@BoalaID", SqlDbType.Int, 4, -1));
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Serie", SqlDbType.NVarChar, 10, ""));
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Numar", SqlDbType.NVarChar, 50, ""));
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@SerieCertificatInitial", SqlDbType.NVarChar, 10, ""));
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@NumarCertificatInitial", SqlDbType.NVarChar, 50, ""));
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@ContinuareAbsenta", SqlDbType.Bit, 1, 0 ));
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@MedieZilnica", SqlDbType.Real, 4, 0 ));
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@EsteCertificat", SqlDbType.Bit, 1, 0 ));
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@DataAcordariiCertificat", SqlDbType.DateTime, 8, DateTime.Now ));
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@CnpCopil", SqlDbType.NVarChar, 13, ""));
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@LocPrescriereCertificat", SqlDbType.NVarChar, 50, "" ));
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@CodUrgenta", SqlDbType.NVarChar, 50, "" ));
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@NrAvizMedicExpert", SqlDbType.NVarChar, 50,"" ));

				m_con.Open();
				myCommand.ExecuteNonQuery();
				m_con.Close();	
			}
			catch{}
		}
		#endregion

		#region GetIntervalAbsentaContinuari
		/// <summary>
		/// Procedura selecteaza continuarile intervalelor de absenta
		/// </summary>
		/// <param name="AbsentaID">Id-ul absentei</param>
		/// <returns>Returneaza un sir care contine aceste date</returns>
		public int[] GetIntervalAbsentaContinuari( int AbsentaID )
		{
			try
			{
				SqlCommand myCommand = new SqlCommand("tm_GetIntervalAbsentaContinuari", m_con);
				myCommand.CommandType = CommandType.StoredProcedure;
				
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@AbsentaID", SqlDbType.Int, 4, AbsentaID  ));
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@AngajatID", SqlDbType.Int, 4, this.AngajatID ));

				SqlDataAdapter dAdapt = new SqlDataAdapter(myCommand);
				
				DataSet ds = new DataSet();
				dAdapt.Fill(ds);

				int [] sirContinuariID = new int[ ds.Tables[ 0 ].Rows.Count ];

				int i = -1;
				foreach( DataRow dr in ds.Tables[ 0 ].Rows )
				{
					if((bool)dr[ "ContinuareAbsenta" ] )
					{
						sirContinuariID[ ++i ] = int.Parse( dr[ "IntervalAbsentaID" ].ToString());
					}
					else
					{
						break;
					}
				}
				return sirContinuariID;
			}
			catch
			{
				return null;
			}
		}
		#endregion
	
		#region GetIntervaleAbsenteAngajatLuna
		/// <summary>
		/// Procedura selecteaza intervalele de absenta ale unui angajat dintr-o luna
		/// </summary>
		/// <param name="Data">Data de inceput a lunii</param>
		/// <returns>Returneaza un DataSet care contine aceste date</returns>
		public DataSet GetIntervaleAbsenteAngajatLuna(DateTime Data)
		{
			try
			{
				SqlCommand myCommand = new SqlCommand("tm_GetIntervaleAbsentaLuna", m_con);
				myCommand.CommandType = CommandType.StoredProcedure;

				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@AngajatID", SqlDbType.Int, 4, this.AngajatID));
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@DataCurenta", SqlDbType.DateTime, 8, Data ));

				SqlDataAdapter dAdapt = new SqlDataAdapter(myCommand);
				
				DataSet ds = new DataSet();
				dAdapt.Fill(ds);
				
				return ds;
			}
			catch
			{
				return null;
			}	
		}
		#endregion

		#region GetIntervaleAbsenteSiEmergencyAngajatLuna
		/// <summary>
		/// Procedura selecteaza intervalele de absenta de tip Emergency
		/// </summary>
		/// <param name="Data">Data de inceput a lunii</param>
		/// <returns>Returneaza un DataSet care contine aceste date</returns>
		public DataSet GetIntervaleAbsenteSiEmergencyAngajatLuna(DateTime Data)
		{
			try
			{
				SqlCommand myCommand = new SqlCommand("tm_GetIntervaleAbsentaSiEmergencyLuna", m_con);
				myCommand.CommandType = CommandType.StoredProcedure;

				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@AngajatID", SqlDbType.Int, 4, this.AngajatID));
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@DataCurenta", SqlDbType.DateTime, 8, Data ));

				SqlDataAdapter dAdapt = new SqlDataAdapter(myCommand);
				
				DataSet ds = new DataSet();
				dAdapt.Fill(ds);
				return ds;
			}
			catch
			{
				return null;
			}
		}
		#endregion

		#region GetIntervaleAbsenteTipAngajatLuna
		/// <summary>
		/// Procedura selecteaza intervalele de absenta de un anumit tip ale unui angajat dintr-o luna
		/// </summary>
		/// <param name="Data">Data de inceput a lunii</param>
		/// <param name="TipIntervalID">Id-ul tipului de interval</param>
		/// <returns>Returneaza un DataSet care contine aceste date</returns>
		public DataSet GetIntervaleAbsenteTipAngajatLuna(DateTime Data,int TipIntervalID)
		{
			try
			{
				SqlCommand myCommand = new SqlCommand("tm_GetIntervaleZi", m_con);
				myCommand.CommandType = CommandType.StoredProcedure;
				SqlDataAdapter dAdapt = new SqlDataAdapter(myCommand);

				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Data", SqlDbType.DateTime, 8, Data));
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@AngajatID", SqlDbType.Int, 4, this.AngajatID));
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@TipIntervalID", SqlDbType.Int, 4, TipIntervalID));
				
				DataSet ds = new DataSet();
				dAdapt.Fill(ds);
				return ds;
			}
			catch
			{
				return null;
			}
		}
		#endregion

		#region GetIntervalAbsentaAngajatByDataEnd
		/// <summary>
		/// Procedura selecteaza intervalele de absenta ale unui angajat in functie de data de sfarsit
		/// </summary>
		/// <param name="DataEnd">Data de sfarsit</param>
		/// <returns>Returneaza un DataSet care contine aceste date</returns>
		public DataSet GetIntervalAbsentaAngajatByDataEnd( DateTime DataEnd )
		{
			try
			{
				SqlCommand myCommand = new SqlCommand("tm_GetIntervalAbsentaByDataEnd", m_con);
				myCommand.CommandType = CommandType.StoredProcedure;
				SqlDataAdapter dAdapt = new SqlDataAdapter(myCommand);

				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@DataEnd", SqlDbType.DateTime, 8, DataEnd ));
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@AngajatID", SqlDbType.Int, 4, this.AngajatID));
							
				DataSet ds = new DataSet();
				dAdapt.Fill(ds);
				return ds;
			}
			catch
			{
				return null;
			}
		}
		#endregion

		#region GetIntervalAbsentaAngajatByID
		/// <summary>
		/// Procedura selecteaza un interval de absenta cu un anumit id
		/// </summary>
		/// <param name="AbsentaID">Id-ul intervalului de absenta</param>
		/// <returns>Returneaza un DataSet care contine aceste date</returns>
		public DataSet GetIntervalAbsentaAngajatByID( int AbsentaID )
		{
			try
			{
				SqlCommand myCommand = new SqlCommand("tm_GetIntervalAbsentaByID", m_con);
				myCommand.CommandType = CommandType.StoredProcedure;
				SqlDataAdapter dAdapt = new SqlDataAdapter(myCommand);

				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@AbsentaID", SqlDbType.Int, 4, AbsentaID ));
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@AngajatID", SqlDbType.Int, 4, this.AngajatID));
								
				DataSet ds = new DataSet();
				dAdapt.Fill(ds);
				return ds;
			}
			catch
			{
				return null;
			}
		}
		#endregion

		#region GetTipIntervalAbsentaAngajat
		/// <summary>
		/// Procedura selecteaza un interval de absenta de un anumit tip
		/// </summary>
		/// <param name="TipAbsentaID">Id-ul tipului de absenta</param>
		/// <returns>Returneaza un DataSet care contine aceste date</returns>
		public DataSet GetTipIntervalAbsentaAngajat( int TipAbsentaID )
		{
			try
			{
				SqlCommand myCommand = new SqlCommand( "tm_GetTipIntervalAbsenta", m_con );
				myCommand.CommandType = CommandType.StoredProcedure;
				SqlDataAdapter dAdapt = new SqlDataAdapter(myCommand);

				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@TipAbsentaID", SqlDbType.Int, 4, TipAbsentaID ));
				
				DataSet ds = new DataSet();
				dAdapt.Fill(ds);
				return ds;
			}
			catch
			{
				return null;
			}
		}
		#endregion

		#region IntersectieCuAlteIntervaleAbsente
		/// <summary>
		/// 0 - Poate fi introdus; 
		/// 1 - DataStart e inclusa in alt interval; 
		/// 2 - DataEnd e inclusa in alt interval;
		/// 3 - DataStart si DataEnd sunt incluse in alte intervale; 
		/// 4 - Intervalul introdus contine un interval existent
		/// 5 - Intervalul introdus contine zile pontate ca fiind lucrate
		/// 6 - DataStart e inclusa in alt interval de intreruperi; 
		/// 7 - DataEnd e inclusa in alt interval de intreruperi;
		/// 8 - DataStart si DataEnd sunt incluse in alte intervale de intreruperi; 
		/// 9 - Intervalul introdus contine un interval de intreruperi existent
		/// </summary>
		/// <param name="DataStart">Data de inceput a intervalului</param>
		/// <param name="DataEnd">Data de sfarsit a intervalului</param>
		/// <param name="IntervalID">Id-ul intervalului</param>
		/// <returns>Returneaza rezultatul verificarii</returns>
		public int IntersectieCuAlteIntervaleAbsente( DateTime DataStart, DateTime DataEnd, int IntervalID )
		{
			try
			{
				SqlCommand myCommand = new SqlCommand("tm_GetIntervaleAbsenta", m_con);
				myCommand.CommandType = CommandType.StoredProcedure;
				SqlDataAdapter dAdapt = new SqlDataAdapter(myCommand);

				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@AngajatID", SqlDbType.Int, 4, this.AngajatID));
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@IntervalID", SqlDbType.Int, 4, IntervalID ));
				
				DataSet ds = new DataSet();
				dAdapt.Fill(ds);

				int poateStart = 0, poateEnd = 0;

				foreach( DataRow dr in ds.Tables[ 0 ].Rows )
				{
					if( DataStart <= (DateTime)dr[ "DataStart" ] && (DateTime)dr[ "DataEnd" ] <= DataEnd )
					{
						return 4;
					}
					if((DateTime)dr[ "DataStart" ] <= DataStart && DataStart <= (DateTime)dr[ "DataEnd" ] )
					{
						poateStart = 1;
					}
					if( (DateTime)dr[ "DataStart" ] <= DataEnd && DataEnd <= (DateTime)dr[ "DataEnd" ] )
					{
						poateEnd = 1;
					}
					if( poateStart == 1 && poateEnd == 1 )
					{
						return 3;
					}
				}
				if( poateStart == 1 )
				{
					return 1;
				}
				else if( poateEnd == 1 )
				{
					return 2;
				}

				myCommand = new SqlCommand("tm_GetIntervaleLucratePerioada", m_con);
				myCommand.CommandType = CommandType.StoredProcedure;
				dAdapt = new SqlDataAdapter(myCommand);

				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@AngajatID", SqlDbType.Int, 4, this.AngajatID ));
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@DataStart", SqlDbType.DateTime, 8, DataStart ));
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@DataEnd", SqlDbType.DateTime, 8, DataEnd ));
				
				ds = new DataSet();
				dAdapt.Fill(ds);

				if( ds.Tables[ 0 ].Rows.Count>0 )
				{
					return 5;
				}

				myCommand = new SqlCommand("GetIntervaleAngajatIntreruperi", m_con);
				myCommand.CommandType = CommandType.StoredProcedure;
				dAdapt = new SqlDataAdapter(myCommand);

				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@AngajatID", SqlDbType.Int, 4, this.AngajatID));
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@IntervalID", SqlDbType.Int, 4, -1 ));
				
				ds = new DataSet();
				dAdapt.Fill(ds);

				foreach( DataRow dr in ds.Tables[ 0 ].Rows )
				{
					if( DataStart <= (DateTime)dr[ "DataStart" ] && (DateTime)dr[ "DataEnd" ] <= DataEnd )
					{
						return 9;
					}
					if((DateTime)dr[ "DataStart" ] <= DataStart && DataStart <= (DateTime)dr[ "DataEnd" ] )
					{
						poateStart = 1;
					}
					if( (DateTime)dr[ "DataStart" ] <= DataEnd && DataEnd <= (DateTime)dr[ "DataEnd" ] )
					{
						poateEnd = 1;
					}
					if( poateStart == 1 && poateEnd == 1 )
					{
						return 8;
					}
				}
				if( poateStart == 1 )
				{
					return 6;
				}
				else if( poateEnd == 1 )
				{
					return 7;
				}
				return 0;
			}
			catch
			{
				return -1;
			}
		}
		#endregion

		#region check interval absenta
		//Lungu Andreea - 16.11.2009
		public bool CheckExistaIntervalAbsenta(DateTime dataInceput, DateTime dataSfarsit, int idTipAbs, int idBoala)
		{

			SqlCommand myCommand = new SqlCommand("tm_CheckIntervaleAbsenta", m_con);
			myCommand.CommandType = CommandType.StoredProcedure;
			SqlDataAdapter dAdapt = new SqlDataAdapter(myCommand);

			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@AngajatID", SqlDbType.Int, 4, this.AngajatID));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@DataInceput", SqlDbType.DateTime, 8, dataInceput ));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@DataSfarsit", SqlDbType.DateTime, 8, dataSfarsit ));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@IdTipAbs", SqlDbType.Int, 4, idTipAbs ));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@IdBoala", SqlDbType.Int, 4, idBoala ));

			DataSet ds = new DataSet();
			dAdapt.Fill(ds);

			if (ds.Tables[0].Rows.Count>0)
				return true;
			else
				return false;
		}
		#endregion

		#region VerificareDepasireZileCOAn
		/// <summary>
		/// 0 - nu a depasit nr de zile anuale; 
		/// 10 - a depasit nr de zile anuale
		/// </summary>
		/// <param name="DataStart">Data de inceput a intervalului</param>
		/// <param name="DataEnd">Data de sfarsit a intervalului</param>
		/// <param name="IntervalID">Id-ul intervalului</param>
		/// <returns>Returneaza rezultatul verificarii</returns>
		public int VerificareDepasireZileCOAn( DateTime dataStart, DateTime dataEnd, int intervalID )
		{
			Salaries.Business.Angajat ang = new Salaries.Business.Angajat();
			ang.AngajatId = AngajatID;
			ang.LoadAngajat();

			PontajAngajat pontajAngajat = new PontajAngajat( this.AngajatID );
			DateTime primaZiAn = new DateTime( dataStart.Year, 1, 1 );
			DateTime ultimaZiAn = new DateTime( dataStart.Year, 12, 31 );
			int nrZileDisponibile = pontajAngajat.GetAngajatNrZileCODisponibileAn( primaZiAn, ultimaZiAn, ang.AngajatorId );
			int nrZileLuateAn = pontajAngajat.GetAngajatNrZileCOLuateAn( primaZiAn, ultimaZiAn, intervalID );

			int nrZileConcediuNou = pontajAngajat.GetNrZileLucratoareInterval( dataStart, dataEnd );

			//Modificat:	Oprescu Claudia
			//Descriere:	S-a adaugat si numarul de zile de concediu suplimentar
			int retVal = nrZileDisponibile + ang.NrZileCOSupl < (nrZileLuateAn + nrZileConcediuNou) ? 10 : 0;
			return retVal;
		}
		#endregion

		#region VerificareDepasireZileCOAnPrecedent
		/// <summary>
		/// Verifica daca in cazul introducerii in luna ianiuarie a unui numar de zile de concediu de odihna
		/// de pe anul precedent se depasesc numaril de zile de concediu de odihna la care angajatul are
		/// dreptul
		/// </summary>
		/// <param name="dataStart"> Data de inceput a intervalului de absenta.</param>
		/// <param name="dataEnd"> Data de sfarsit a intervalului de absenta.</param>
		/// <param name="intervalID"> ID-ul intervalului - pentru cazul in care se realizeaza update-ul
		/// unuia deja introdus.</param>
		/// <returns> true in cazul in care a depasit numarul de zile permise, false altfel.</returns>
		/// <remarks>
		///  Autor: Cristina Raluca Muntean
		///  Data:  30.06.2006
		/// </remarks>
//		public bool VerificareDepasireZileCOAnPrecedent( DateTime dataStart, DateTime dataEnd, int intervalID )
//		{
//			SiemensHR.Classes.Angajat ang = new SiemensHR.Classes.Angajat();
//			ang.LoadAngajat( this.AngajatID );
//
//			PontajAngajat pa = new PontajAngajat( this.AngajatID );
//			DateTime primaZiAn = new DateTime( dataStart.Year-1, 1, 1 );
//			DateTime ultimaZiAn = new DateTime( dataStart.Year-1, 12, 31 );
//			// Este obtinuta valoarea numarului de zile de concediu de odihna
//			int nrZileDisponibile = pa.GetAngajatNrZileCODisponibileAn( primaZiAn, ultimaZiAn, ang.AngajatorID );
//			
//			int nrZileLuateAn = pa.GetAngajatNrZileCOLuateAnPrecedent( primaZiAn, ultimaZiAn, intervalID );
//
//			int nrZileConcediuNou = pa.GetNrZileLucratoareInterval( dataStart, dataEnd );
//
//			int retVal = nrZileDisponibile < (nrZileLuateAn+nrZileConcediuNou) ? 10 : 0;
//			return retVal;
//		}
		#endregion

		#region GetCodAbsenta
		/// <summary>
		/// Prcoedura determina codul unei anumite absente
		/// </summary>
		/// <param name="TipAbsentaID">Id-ul tipului de absenta</param>
		/// <returns>Returneaza codul absentei</returns>
		public string GetCodAbsenta( int TipAbsentaID )
		{
			try
			{
				NomenclatorTipAbsente abs = new NomenclatorTipAbsente();
				DataSet ds = abs.GetTipuriAbsente( TipAbsentaID );
				return ds.Tables[ 0 ].Rows[ 0 ][ "CodAbsenta" ].ToString();
			}
			catch
			{
				return "";
			}
		}
		#endregion
	}
}
