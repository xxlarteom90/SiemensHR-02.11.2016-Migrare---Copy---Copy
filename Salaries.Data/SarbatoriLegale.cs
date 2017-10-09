using System;
using System.Data;
using System.Data.SqlClient;

namespace Salaries.Data
{
	/// <summary>
	/// Summary description for SarbatoriLegale.
	/// </summary>
	public class SarbatoriLegale : Salaries.Data.DbObject
	{
		#region Constructor
		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="connectionString"> Stringul de conectare la baza de date.</param>
		public SarbatoriLegale(string connectionString): base (connectionString)
		{}
		#endregion

		#region LoadSarbatoriLegale
		/// <summary>
		/// Procedura selecteaza sarbatorile legale
		/// </summary>
		/// <returns>Returneaza un DataSet care contine sarbatorile</returns>
		public DataSet LoadSarbatoriLegale()
		{
			SqlParameter[] parameters = {};
			return RunProcedure("GetSarbatoriLegale", parameters, "GetSarbatoriLegale");
		}
		#endregion

		#region InsertSarbatoareLegala
		/// <summary>
		/// Procedura adauga o sarbatoare legala
		/// </summary>
		/// <param name="denumire">Denumirea sarbatorii legale</param>
		/// <param name="descriere">Descrierea sarbatorii legale</param>
		/// <param name="dataSarbatoare">Data sarbatorii legale</param>
		public void InsertSarbatoareLegala(string denumire, string descriere, DateTime dataSarbatoare)
		{
			SqlParameter[] parameters = 
				{
					new SqlParameter("@tip_actiune", SqlDbType.Int, 1),
					new SqlParameter("@Denumirea", SqlDbType.NChar, 50),
					new SqlParameter("@Descrierea", SqlDbType.NText,500),
					new SqlParameter("@Data", SqlDbType.DateTime, 8),
					new SqlParameter("@Old_Data", SqlDbType.DateTime, 8)
				};
			
			parameters[0].Value = 0;
			parameters[1].Value = denumire;
			parameters[2].Value = descriere;
			parameters[3].Value = dataSarbatoare;
			parameters[4].Value = System.DBNull.Value;
			
			RunProcedure("InsertUpdateSarbatoriLegale", parameters);
		}
		#endregion

		#region UpdateSarbatoareLegala
		/// <summary>
		/// Procedura actualizeaza o sarbatoare legala
		/// </summary>
		/// <param name="denumire">Denumirea sarbatorii legale</param>
		/// <param name="descriere">Descrierea sarbatorii legale</param>
		/// <param name="dataSarbatoare">Data sarbatorii legale</param>
		/// <param name="oldData">Data veche a sarbatorii legale</param>
		public void UpdateSarbatoareLegala(string denumire, string descriere, DateTime dataSarbatoare, DateTime oldData)
		{
			SqlParameter[] parameters = 
				{
					new SqlParameter("@tip_actiune", SqlDbType.Int, 1),
					new SqlParameter("@Denumirea", SqlDbType.NChar, 50),
					new SqlParameter("@Descrierea", SqlDbType.NText,500),
					new SqlParameter("@Data", SqlDbType.DateTime, 8),
					new SqlParameter("@Old_Data", SqlDbType.DateTime, 8)
				};
			
			parameters[0].Value = 1;
			parameters[1].Value = denumire;
			parameters[2].Value = descriere;
			parameters[3].Value = dataSarbatoare;
			parameters[4].Value = oldData;
			
			RunProcedure("InsertUpdateSarbatoriLegale", parameters);
		}
		#endregion

		#region DeleteSarbatoareLegala
		/// <summary>
		/// Procedura sterge o sarbatoare legala
		/// </summary>
		/// <param name="dataSarbatoare">Data sarbatorii legale</param>
		public void DeleteSarbatoareLegala(DateTime dataSarbatoare)
		{
			SqlParameter[] parameters = 
				{
					new SqlParameter("@tip_actiune", SqlDbType.Int, 1),
					new SqlParameter("@Denumirea", SqlDbType.NChar, 50),
					new SqlParameter("@Descrierea", SqlDbType.NText,500),
					new SqlParameter("@Data", SqlDbType.DateTime, 8),
					new SqlParameter("@Old_Data", SqlDbType.DateTime, 8)
				};
			
			parameters[0].Value = 2;
			parameters[1].Value = "";
			parameters[2].Value = "";
			parameters[3].Value = dataSarbatoare;
			parameters[4].Value = System.DBNull.Value;
			
			RunProcedure("InsertUpdateSarbatoriLegale", parameters);
		}
		#endregion

		#region CheckInsertSarbatoareLegala
		/// <summary>
		/// Procedura verifica daca o sarbatoare legala exista deja pentru o anumita data
		/// </summary>
		/// <param name="dataSarbatoare">Data sarbatorii legale</param>
		/// <returns>Returneaza true daca nu apare si false altfel</returns>
		public bool CheckInsertSarbatoareLegala(DateTime dataSarbatoare)
		{
			SqlParameter[] parameters = 
				{
					new SqlParameter("@Data", SqlDbType.DateTime, 8),
					new SqlParameter("@NrAparitii", SqlDbType.Int,4)
				};
			
			parameters[0].Value = dataSarbatoare;
			parameters[1].Direction = ParameterDirection.Output;
			
			RunProcedure("CheckInsertSarbatoareLegala", parameters);
			return int.Parse(parameters[1].Value.ToString()) == 0;
		}
		#endregion

		#region SetDataTipSarbatoare
		/// <summary>
		/// Procedura seteaza o data ca fiind sarbatoare
		/// </summary>
		/// <param name="dataSarbatoare">Data specificata</param>
		/// <param name="sarbatoare">Este sarbatoare sau nu</param>
		public void SetDataTipSarbatoare(DateTime dataSarbatoare, bool sarbatoare)
		{
			SqlParameter[] parameters = 
				{
					new SqlParameter("@Data", SqlDbType.DateTime, 8),
					new SqlParameter("@Sarbatoare", SqlDbType.Bit, 1)
				};
			
			parameters[0].Value = dataSarbatoare;
			parameters[1].Value = sarbatoare;
			
			RunProcedure("tm_SetZiTipSarbatoare", parameters);
		}
		#endregion

		#region GetSarbatoriLegaleLuna
		/// <summary>
		/// Procedura returneaza un dataseteaza cu sarbatorile legale din luna respectiva
		/// </summary>
		/// <param name="dataInceputLuna">Data inceput luna</param>
		/// <param name="dataSfarsitLuna">Data sfarsit luna</param>
		/// Lungu Andreea - 22.06.2009
		public DataSet GetSarbatoriLegaleLuna(DateTime dataStart, DateTime dataEnd)
		{
			SqlParameter[] parameters = 
				{
					new SqlParameter("@DataStart", SqlDbType.DateTime, 8),
					new SqlParameter("@DataEnd", SqlDbType.DateTime, 8)
				};
			
			parameters[0].Value = dataStart;
			parameters[1].Value = dataEnd;

			return RunProcedure("GetSarbatoriLegaleLuna", parameters, "GetSarbatoriLegaleLuna");
		}
		#endregion
	}
}
