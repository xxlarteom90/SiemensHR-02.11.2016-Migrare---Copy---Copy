/*
 * Author:		Lungu Andreea
 * Date:		19.03.2010
 * Description:	Retinerile recurente pentru un angajat
 * 
 */ 

using System;
using System.Data;
using System.Data.SqlClient;

namespace Salaries.Data
{
	/// <summary>
	/// Summary description for RetinereRecurentaAngajat
	/// </summary>
	public class RetinereRecurentaAngajat
	{
		public int IdRetinere;
		public long AngajatID;
		public string TipRetinere;
		public string DenumireRetinere;
		public DateTime DataInceput;
		public DateTime DataSfarsit;
		public decimal Valoare;
		public bool Alerta;
	}
	/// <summary>
	/// Summary description for RetineriAngajat.
	/// </summary>
	public class RetineriRecurenteAngajat : Salaries.Data.DbObject
	{
		#region Constructor
		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="connectionString"> Stringul de conectare la baza de date.</param>
		public RetineriRecurenteAngajat(string connectionString): base (connectionString)
		{}
		#endregion

		#region LoadRetineriRecurente
		/// <summary>
		/// Procedura selecteaza retinerile recurente ale unui angajat
		/// </summary>
		/// <param name="angajatId">Id-ul angajatului</param>
		/// <returns>Returneaza un DataSet care contine aceste date</returns>
		public DataSet LoadRetineriAngajat(long angajatId)
		{
			SqlParameter[] parameters = 
				{
					new SqlParameter("@AngajatID", SqlDbType.BigInt, 10)
				};
			parameters[0].Value = angajatId;
			return RunProcedure("GetRetineriRecurenteAngajat", parameters, "GetRetineriRecurenteAngajat");
		}
		#endregion

		#region GetRetinere
		/// <summary>
		/// Procedura selecteaza o anumita retinere
		/// </summary>
		/// <param name="angajatId">Id-ul angajatului</param>
		/// <returns>Returneaza un DataSet care contine aceste date</returns>
		public RetinereRecurentaAngajat GetRetinere(int idRetinere)
		{
			SqlParameter[] parameters = 
				{
					new SqlParameter("@IdRetinere", SqlDbType.BigInt, 10)
				};
			parameters[0].Value = idRetinere;

			RetinereRecurentaAngajat ret = new RetinereRecurentaAngajat();
						
			using (DataSet ds = RunProcedure("GetRetinereRecurenta",parameters,"GetRetinereRecurenta"))
			{
				if (ds.Tables["GetRetinereRecurenta"].Rows.Count==1)
				{
					DataRow dr = ds.Tables["GetRetinereRecurenta"].Rows[0];
					
					ret.IdRetinere = int.Parse(dr["IdRetinere"].ToString());
					ret.AngajatID = int.Parse(dr["AngajatID"].ToString());
					ret.TipRetinere = dr["TipRetinere"].ToString();
					ret.DenumireRetinere = dr["DenumireRetinere"].ToString();
					ret.DataInceput = (DateTime) dr["DataInceput"];
					ret.DataSfarsit = (DateTime) dr["DataSfarsit"];
					ret.Valoare = decimal.Parse(dr["Valoare"].ToString());
					ret.Alerta = (bool) dr["Alerta"];
				} 
				else
					ret.IdRetinere = -1;
			}
			return ret;
		}
		#endregion

		#region VerificaIntersectieNrRetineri
		public int VerificaIntersectieNrRetineri(int angajatID, string tipRetinere, DateTime dataInceput, DateTime dataSfarsit)
		{
			SqlParameter[] parameters = 
				{
					new SqlParameter("@AngajatId", SqlDbType.Int, 4),
					new SqlParameter("@TipRetinere", SqlDbType.NVarChar, 50),
					new SqlParameter("@DataInceput", SqlDbType.DateTime, 8),
					new SqlParameter("@DataSfarsit", SqlDbType.DateTime, 8),
				    new SqlParameter("@Nr", SqlDbType.Int, 4)
				};
			//daca angajat id e 0 nu mai tine cont de parametrul angajatid
			parameters[0].Value = angajatID;
			parameters[1].Value = tipRetinere;
			parameters[2].Value = dataInceput;
		    parameters[3].Value = dataSfarsit;
			parameters[4].Direction = ParameterDirection.Output;

			RunProcedure("VerificaIntersectieNrRetineri",parameters,"VerificaIntersectieNrRetineri");
			return int.Parse(parameters[4].Value.ToString());
		}
		#endregion


		#region InsertRetinereRecurentaAngajat
		/// <summary>
		/// Inserarea unei retineri recurente oentru un angajat
		/// </summary>
		/// <param name="retAng"></param>
		public void InsertRetinereRecurentaAngajat(RetinereRecurentaAngajat retAng)
		{
			SqlParameter[] parameters = 
				{
					new SqlParameter("@tip_actiune", SqlDbType.Int, 4),
					new SqlParameter("@IdRetinere", SqlDbType.BigInt, 10),
					new SqlParameter("@AngajatID", SqlDbType.Int, 4),
					new SqlParameter("@TipRetinere", SqlDbType.NVarChar, 50),
					new SqlParameter("@DenumireRetinere", SqlDbType.NVarChar, 30),
					new SqlParameter("@DataInceput", SqlDbType.DateTime, 8),
				    new SqlParameter("@DataSfarsit", SqlDbType.DateTime, 8),
				    new SqlParameter("@Valoare", SqlDbType.Money, 8),
				    new SqlParameter("@Alerta", SqlDbType.Bit, 1)
				};
			
			parameters[0].Value = 0;
			parameters[1].Value = 0;
			parameters[2].Value = retAng.AngajatID;
			parameters[3].Value = retAng.TipRetinere;
			parameters[4].Value = retAng.DenumireRetinere;
			parameters[5].Value = retAng.DataInceput;
			parameters[6].Value = retAng.DataSfarsit;
			parameters[7].Value = retAng.Valoare;
			parameters[8].Value = retAng.Alerta;
			
			RunProcedure("InsertUpdateDeleteRetineriAngajat", parameters);
		}
		#endregion

		#region UpdateRetinereRecurentaAngajat
		/// <summary>
		/// Updatarea campurilor unei retineri recurente
		/// </summary>
		/// <param name="retAng"></param>
		public void UpdateRetinereRecurentaAngajat(RetinereRecurentaAngajat retAng)
		{
			SqlParameter[] parameters = 
				{
					new SqlParameter("@tip_actiune", SqlDbType.Int, 4),
					new SqlParameter("@IdRetinere", SqlDbType.BigInt, 10),
					new SqlParameter("@AngajatID", SqlDbType.Int, 4),
					new SqlParameter("@TipRetinere", SqlDbType.NVarChar, 50),
					new SqlParameter("@DenumireRetinere", SqlDbType.NVarChar, 30),
					new SqlParameter("@DataInceput", SqlDbType.DateTime, 8),
					new SqlParameter("@DataSfarsit", SqlDbType.DateTime, 8),
					new SqlParameter("@Valoare", SqlDbType.Float, 8),
					new SqlParameter("@Alerta", SqlDbType.Bit, 1)
				};
			
			parameters[0].Value = 1;
			parameters[1].Value = retAng.IdRetinere;
			parameters[2].Value = retAng.AngajatID;
			parameters[3].Value = retAng.TipRetinere;
			parameters[4].Value = retAng.DenumireRetinere;
			parameters[5].Value = retAng.DataInceput;
			parameters[6].Value = retAng.DataSfarsit;
			parameters[7].Value = retAng.Valoare;
			parameters[8].Value = retAng.Alerta;
			
			RunProcedure("InsertUpdateDeleteRetineriAngajat", parameters);
		}
		#endregion

		#region DeleteRetinereRecurenta
    	/// <summary>
		/// Stergerea unei retineri recurente
		/// </summary>
		/// <param name="retAng"></param>
		public void DeleteRetinereRecurentaAngajat(RetinereRecurentaAngajat retAng)
		{
			SqlParameter[] parameters = 
				{
					new SqlParameter("@tip_actiune", SqlDbType.Int, 4),
					new SqlParameter("@IdRetinere", SqlDbType.BigInt, 10),
					new SqlParameter("@AngajatID", SqlDbType.Int, 4),
					new SqlParameter("@TipRetinere", SqlDbType.NVarChar, 50),
					new SqlParameter("@DenumireRetinere", SqlDbType.NVarChar, 30),
					new SqlParameter("@DataInceput", SqlDbType.DateTime, 8),
					new SqlParameter("@DataSfarsit", SqlDbType.DateTime, 8),
					new SqlParameter("@Valoare", SqlDbType.Float, 8),
					new SqlParameter("@Alerta", SqlDbType.Bit, 1)
				};
			
			parameters[0].Value = 2;
			parameters[1].Value = retAng.IdRetinere;
			parameters[2].Value = retAng.AngajatID;
			parameters[3].Value = retAng.TipRetinere;
			parameters[4].Value = retAng.DenumireRetinere;
			parameters[5].Value = retAng.DataInceput;
			parameters[6].Value = retAng.DataSfarsit;
			parameters[7].Value = retAng.Valoare;
			parameters[8].Value = retAng.Alerta;
			
			RunProcedure("InsertUpdateDeleteRetineriAngajat", parameters);
		}
		#endregion

	}
}
