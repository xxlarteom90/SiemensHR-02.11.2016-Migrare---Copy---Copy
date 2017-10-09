using System;
using System.Data;
using System.Data.SqlClient;

namespace Salaries.Data
{
	/// <summary>
	/// Summary description for CarteDeMunca.
	/// </summary>
	public class CarteDeMunca : Salaries.Data.DbObject
	{
		#region CarteDeMunca
		/// <summary>
		/// Constructorul cu string de conexiune
		/// </summary>
		/// <param name="connectionString">Stringul de conexiune la baza de date</param>
		public CarteDeMunca(string connectionString) : base (connectionString)
		{}
		#endregion

		#region LoadCarteDeMuncaAngajat
		/// <summary>
		/// Procedura selecteaza toate perioadele de lucru ale unul angajat
		/// </summary>
		/// <returns>Returneaza un DataSet care contine aceste inregistrari</returns>
		public DataSet LoadCarteDeMuncaAngajat(long idAngajat)
		{
			SqlParameter[] parameters = {	
											new SqlParameter("@AngajatID", SqlDbType.Int, 4)
										};	
			parameters[0].Value = idAngajat;
			return RunProcedure("GetPerioadeCarteDeMuncaForAngajat", parameters, "GetPerioadeCarteDeMuncaForAngajat");
		}
		#endregion

		#region InsertPerioadaCarteDeMunca
		/// <summary>
		/// Adauga o periada pentru un angajat in cartea de munca
		/// </summary>
		/// <param name="id">id perioada</param>
		/// <param name="idAngajat">id angajat</param>
		/// <param name="dataDeLa">data inceput</param>
		/// <param name="dataPanaLa">data sfarsit</param>
		public void InsertPerioadaCarteDeMunca(long idAngajat, DateTime dataDeLa, DateTime dataPanaLa, bool laSiemens)
		{
			SqlParameter[] parameters = 
							{
								new SqlParameter("@tip_actiune", SqlDbType.Int, 4),
								new SqlParameter("@ID", SqlDbType.Int, 50),
								new SqlParameter("@AngajatID", SqlDbType.Int, 50),
								new SqlParameter("@DataDeLa", SqlDbType.DateTime, 8),
								new SqlParameter("@DataPanaLa", SqlDbType.DateTime, 8),
								new SqlParameter("@LaSiemens", SqlDbType.Bit, 1)
							};
			
			parameters[0].Value = 0;
			parameters[1].Value = 0;
			parameters[2].Value = idAngajat;
			parameters[3].Value = dataDeLa;
			parameters[4].Value = dataPanaLa;
			parameters[5].Value = laSiemens;

			RunProcedure("InsertUpdateDeleteCarteDeMunca", parameters);
		}
		#endregion

		#region UpdatePerioadaCarteDeMunca
		/// <summary>
		/// Modifica o periada pentru un angajat in cartea de munca
		/// </summary>
		/// <param name="id">id perioada</param>
		/// <param name="idAngajat">id angajat</param>
		/// <param name="dataDeLa">data inceput</param>
		/// <param name="dataPanaLa">data sfarsit</param>
		public void UpdatePerioadaCarteDeMunca(long idPerioada, long idAngajat, DateTime dataDeLa, DateTime dataPanaLa, bool laSiemens)
		{
			SqlParameter[] parameters = 
							{
								new SqlParameter("@tip_actiune", SqlDbType.Int, 4),
								new SqlParameter("@ID", SqlDbType.Int, 50),
								new SqlParameter("@AngajatID", SqlDbType.Int, 50),
								new SqlParameter("@DataDeLa", SqlDbType.DateTime, 8),
								new SqlParameter("@DataPanaLa", SqlDbType.DateTime, 8),
								new SqlParameter("@LaSiemens", SqlDbType.Bit, 1)
							};
			
			parameters[0].Value = 1;
			parameters[1].Value = idPerioada;
			parameters[2].Value = idAngajat;
			parameters[3].Value = dataDeLa;
			parameters[4].Value = dataPanaLa;
			parameters[5].Value = laSiemens;

			RunProcedure("InsertUpdateDeleteCarteDeMunca", parameters);
		}
		#endregion

		#region DeletePerioadaCarteDeMunca
		/// <summary>
		/// Sterge o periada pentru un angajat in cartea de munca
		/// </summary>
		/// <param name="id">id perioada</param>
		/// <param name="idAngajat">id angajat</param>
		/// <param name="dataDeLa">data inceput</param>
		/// <param name="dataPanaLa">data sfarsit</param>
		public void DeletePerioadaCarteDeMunca(long idPerioada, long idAngajat, DateTime dataDeLa, DateTime dataPanaLa, bool laSiemens)
		{
			SqlParameter[] parameters = 
							{
								new SqlParameter("@tip_actiune", SqlDbType.Int, 4),
								new SqlParameter("@ID", SqlDbType.Int, 50),
								new SqlParameter("@AngajatID", SqlDbType.Int, 50),
								new SqlParameter("@DataDeLa", SqlDbType.DateTime, 8),
								new SqlParameter("@DataPanaLa", SqlDbType.DateTime, 8),
								new SqlParameter("@LaSiemens", SqlDbType.Bit, 1)
							};
			
			parameters[0].Value = 2;
			parameters[1].Value = idPerioada;
			parameters[2].Value = idAngajat;
			parameters[3].Value = dataDeLa;
			parameters[4].Value = dataPanaLa;
			parameters[5].Value = laSiemens;

			RunProcedure("InsertUpdateDeleteCarteDeMunca", parameters);
		}
		#endregion

		#region DeleteToatePerioadeleAngajat
		/// <summary>
		/// Procedura sterge toate perioadele din cartea de munca ale unui angajat
		/// </summary>
		public void DeleteToatePerioadeleAngajat(long idAngajat)
		{
			SqlParameter[] parameters = {	
											new SqlParameter("@AngajatID", SqlDbType.Int, 4)
										};	
			parameters[0].Value = idAngajat;
			RunProcedure("DeleteAllPerioadeCarteDeMuncaForAngajat", parameters, "DeleteAllPerioadeCarteDeMuncaForAngajat");
		}
		#endregion
	}
}
