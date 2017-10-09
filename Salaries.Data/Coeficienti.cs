using System;
using System.Data;
using System.Data.SqlClient;

namespace Salaries.Data
{
	public class DetaliiCoeficienti
	{
		public int SetID;
		public DateTime DeLa;
		public decimal Deducere;
		public decimal CoefInvalidGrd1;
		public decimal CoefInvalidGrd2;
		public decimal CoefCopil12;
		public decimal CoefCopil3;
		public decimal CoefUrmCopil;
		public decimal CoefSot;
		public decimal CoefTotal;
		public decimal CoefSanatate;
		public decimal CoefPensie;
		public decimal CoefSomaj;
		public decimal CoefCheltProf;
		public decimal CASAngajator;
		public decimal SanatateAngajator;
		public decimal SomajAngajator;
		public decimal FondRiscAngajator;
		public bool CartiCameraMunca;
		public decimal CartiCamera;
		public decimal CartiAngajator;
	}

	/// <summary>
	/// Summary description for Coeficienti.
	/// </summary>
	public class Coeficienti : Salaries.Data.DbObject
	{	
		#region Constructor
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="connectionString">String-ul de conexiune la baza de date</param>
		public Coeficienti(string connectionString): base (connectionString){}
		#endregion

		#region GetCoeficientiCurenti
		/// <summary>
		/// Procdura selecteaza valorile curente ale coeficientilor
		/// </summary>
		/// <param name="data">Data curenta</param>
		/// <returns>Returneaza un DataSet care contine aceste date</returns>
		public DataSet GetCoeficientiCurenti(DateTime data)
		{
			SqlParameter[] parameters = { new SqlParameter("@Data", SqlDbType.DateTime, 8) };
			parameters[0].Value = data;
			
			return RunProcedure("sal_GetCoeficienti", parameters, "Options");
		}
		#endregion

		#region GetCoeficienti
		/// <summary>
		/// Procedura selecteaza toti coeficientii
		/// </summary>
		/// <returns>Returneaza un DataSet care contine aceste date</returns>
		public DataSet GetCoeficienti()
		{			
			SqlParameter[] parameters = {};
			return RunProcedure("sal_GetAllCoeficienti", parameters, "AllCoefs");
		}
		#endregion

		#region GetDetalii
		/// <summary>
		/// Procedura selecteaza valorile unor coeficienti
		/// </summary>
		/// <param name="data">Data pentru care se selecteaza valorile coeficientilor</param>
		/// <returns>Returneaza un obiect care contine aceste date</returns>
		public DetaliiCoeficienti GetDetalii(DateTime data)
		{
			SqlParameter[] parameters = { new SqlParameter("@Data", SqlDbType.DateTime, 8) };
			parameters[0].Value = data;
			
			using(DataSet detaliiDS = RunProcedure("sal_GetCoeficienti", parameters, "Coeficienti"))
			{
				DetaliiCoeficienti detalii = new DetaliiCoeficienti();
				if (detaliiDS.Tables[0].Rows.Count > 0)
				{
					DataRow rowDetalii = detaliiDS.Tables[0].Rows[0];
					detalii.SetID = (int)rowDetalii["SetID"];
					detalii.DeLa = (DateTime)rowDetalii["DeLa"];
					detalii.Deducere = (decimal)rowDetalii["Deducere"];
					detalii.CoefInvalidGrd1 = (decimal)rowDetalii["CoefInvalidGrd1"];
					detalii.CoefInvalidGrd2 = (decimal)rowDetalii["CoefInvalidGrd2"];
					detalii.CoefCopil12 = (decimal)rowDetalii["CoefCopil12"];
					detalii.CoefCopil3 =(decimal)rowDetalii["CoefCopil3"];
					detalii.CoefUrmCopil = (decimal)rowDetalii["CoefUrmCopil"];
					detalii.CoefSot = (decimal)rowDetalii["CoefSot"];
					detalii.CoefTotal = (decimal)rowDetalii["CoefTotal"];
					detalii.CoefSanatate = (decimal)rowDetalii["CoefSanatate"];
					detalii.CoefPensie = (decimal)rowDetalii["CoefPensie"];
					detalii.CoefSomaj = (decimal)rowDetalii["CoefSomaj"];
					detalii.CoefCheltProf = (decimal)rowDetalii["CoefCheltProf"];
					detalii.CASAngajator = (decimal)rowDetalii["CASAngajator"];
					detalii.SomajAngajator = (decimal)rowDetalii["SomajAngajator"];
					detalii.SanatateAngajator = (decimal)rowDetalii["SanatateAngajator"];
					detalii.FondRiscAngajator = (decimal)rowDetalii["FondRiscAngajator"];
					detalii.CartiCameraMunca = (bool)rowDetalii["CartiCameraMunca"];
					detalii.CartiCamera = (decimal)rowDetalii["CartiCamera"];
					detalii.CartiAngajator = (decimal)rowDetalii["CartiAngajator"];

				}
				else
					detalii.SetID = -1;

				return detalii;
			}
		}
		#endregion

		#region GetDetalii
		/// <summary>
		/// Procedura selecteaza un valorile unui anumit set de date
		/// </summary>
		/// <param name="setID">Id-ul setului de date selectat</param>
		/// <returns>Returneaza un obiect care contine aceste date</returns>
		public DetaliiCoeficienti GetDetalii(int setID)
		{
			SqlParameter[] parameters = { new SqlParameter("@SetID", SqlDbType.Int, 4) };
			parameters[0].Value = setID;
			
			using(DataSet detaliiDS = RunProcedure("sal_GetCoeficientiID", parameters, "Coeficienti"))
			{
				DetaliiCoeficienti detalii = new DetaliiCoeficienti();
				if (detaliiDS.Tables[0].Rows.Count > 0)
				{
					DataRow rowDetalii = detaliiDS.Tables[0].Rows[0];
					detalii.SetID = (int)rowDetalii["SetID"];
					detalii.DeLa = (DateTime)rowDetalii["DeLa"];
					detalii.Deducere = (decimal)rowDetalii["Deducere"];
					detalii.CoefInvalidGrd1 = (decimal)rowDetalii["CoefInvalidGrd1"];
					detalii.CoefInvalidGrd2 = (decimal)rowDetalii["CoefInvalidGrd2"];
					detalii.CoefCopil12 = (decimal)rowDetalii["CoefCopil12"];
					detalii.CoefCopil3 = (decimal)rowDetalii["CoefCopil3"];
					detalii.CoefUrmCopil = (decimal)rowDetalii["CoefUrmCopil"];
					detalii.CoefSot = (decimal)rowDetalii["CoefSot"];
					detalii.CoefTotal = (decimal)rowDetalii["CoefTotal"];
					detalii.CoefSanatate = (decimal)rowDetalii["CoefSanatate"];
					detalii.CoefPensie = (decimal)rowDetalii["CoefPensie"];
					detalii.CoefSomaj = (decimal)rowDetalii["CoefSomaj"];
					detalii.CoefCheltProf = (decimal)rowDetalii["CoefCheltProf"];
					detalii.CASAngajator = (decimal)rowDetalii["CASAngajator"];
					detalii.SanatateAngajator = (decimal)rowDetalii["SanatateAngajator"];
					detalii.FondRiscAngajator = (decimal)rowDetalii["FondRiscAngajator"];
					detalii.CartiCameraMunca = (bool)rowDetalii["CartiCameraMunca"];
					detalii.CartiCamera = (decimal)rowDetalii["CartiCamera"];
					detalii.CartiAngajator = (decimal)rowDetalii["CartiAngajator"];

				}
				else
					detalii.SetID = -1;

				return detalii;
			}
		}
		#endregion

		#region GetDetaliiRow
		/// <summary>
		/// Procedura selecteaza o anumita inregistrare din DataSet
		/// </summary>
		/// <param name="data">Data inregistrarii selectate</param>
		/// <returns>Returneaza un DataRow care contine aceste date</returns>
		public DataRow GetDetaliiRow(DateTime data)
		{
			SqlParameter[] parameters = { new SqlParameter("@Data", SqlDbType.DateTime, 8) };
			parameters[0].Value = data;
			
			using(DataSet detalii = RunProcedure("sal_GetCoeficienti", parameters, "Coeficienti"))
			{
				return detalii.Tables[0].Rows[0];
			}
		}
		#endregion

		#region Add
		/// <summary>
		/// Procedura adauga un set de date
		/// </summary>
		/// <returns>Returneaza true daca s-a facut adaugarea si false altfel</returns>
		public int Add(DateTime deLa, decimal deducere, decimal coefInvalidGrd1,
			decimal coefInvalidGrd2, decimal coefCopil12, decimal coefCopil3, decimal coefUrmCopil, 
			decimal coefSot, decimal coefTotal, decimal coefSanatate, decimal coefPensie,
			decimal coefSomaj, decimal coefCheltProf, decimal casAngajator,
			decimal sanatateAngajator, decimal somajAngajator, decimal fondRiscAngajator,
			bool cartiCameraMunca, decimal cartiCamera, decimal cartiAngajator)
		{
			int numAffected;
		
			SqlParameter[] parameters = 
				{
					new SqlParameter("@DeLa", SqlDbType.DateTime, 8),
					new SqlParameter("@Deducere", SqlDbType.Money, 8),
					new SqlParameter("@CoefInvalidGrd1", SqlDbType.Decimal, 9),
					new SqlParameter("@CoefInvalidGrd2", SqlDbType.Decimal, 9),
					new SqlParameter("@CoefCopil12", SqlDbType.Decimal, 9),
					new SqlParameter("@CoefCopil3", SqlDbType.Decimal, 9),
					new SqlParameter("@CoefUrmCopil", SqlDbType.Decimal, 9),
					new SqlParameter("@CoefSot", SqlDbType.Decimal, 9),
					new SqlParameter("@CoefTotal", SqlDbType.Decimal, 9),
					new SqlParameter("@CoefSanatate", SqlDbType.Decimal, 9),
					new SqlParameter("@CoefPensie", SqlDbType.Decimal, 9),
					new SqlParameter("@CoefSomaj", SqlDbType.Decimal, 9),
					new SqlParameter("@CoefCheltProf", SqlDbType.Decimal, 9),
					new SqlParameter("@CASAngajator", SqlDbType.Decimal, 9),
					new SqlParameter("@SanatateAngajator", SqlDbType.Decimal, 9),
					new SqlParameter("@SomajAngajator", SqlDbType.Decimal, 9),
					new SqlParameter("@FondRiscAngajator", SqlDbType.Decimal, 9),
					new SqlParameter("@CartiCameraMunca", SqlDbType.Bit, 1),
					new SqlParameter("@CartiCamera", SqlDbType.Decimal, 9),
					new SqlParameter("@CartiAngajator", SqlDbType.Decimal, 9),
					new SqlParameter("@SetID", SqlDbType.Int, 4)
				};
			
			parameters[0].Value = deLa;
			parameters[1].Value = deducere;
			parameters[2].Value = coefInvalidGrd1;
			parameters[3].Value = coefInvalidGrd2;
			parameters[4].Value = coefCopil12;
			parameters[5].Value = coefCopil3;
			parameters[6].Value = coefUrmCopil;
			parameters[7].Value = coefSot;
			parameters[8].Value = coefTotal;
			parameters[9].Value = coefSanatate;
			parameters[10].Value = coefPensie;
			parameters[11].Value = coefSomaj;
			parameters[12].Value = coefCheltProf;
			parameters[13].Value = casAngajator;
			parameters[14].Value = sanatateAngajator;
			parameters[15].Value = somajAngajator;
			parameters[16].Value = fondRiscAngajator;
			parameters[17].Value = cartiCameraMunca;
			parameters[18].Value = cartiCamera;
			parameters[19].Value = cartiAngajator;
			parameters[20].Direction = ParameterDirection.Output;

			RunProcedure("sal_InsertCoef", parameters, out numAffected);

			return (int)parameters[20].Value;
		}
		#endregion
		
		#region Update
		/// <summary>
		/// Procedura actualizeaza un set de date
		/// </summary>
		/// <returns>Returneaza true daca s-a facut actualizarea si false altfel</returns>
		public bool Update(int setID, DateTime deLa, decimal deducere, decimal coefInvalidGrd1,
			decimal coefInvalidGrd2, decimal coefCopil12, decimal coefCopil3, decimal coefUrmCopil, 
			decimal coefSot, decimal coefTotal, decimal coefSanatate, decimal coefPensie,
			decimal coefSomaj, decimal coefCheltProf, decimal casAngajator,
			decimal sanatateAngajator, decimal somajAngajator, decimal fondRiscAngajator,
			bool cartiCameraMunca, decimal cartiCamera, decimal cartiAngajator)
		{
			int numAffected;
		
			SqlParameter[] parameters = 
				{
					new SqlParameter("@SetID", SqlDbType.Int, 4),
					new SqlParameter("@DeLa", SqlDbType.DateTime, 8),
					new SqlParameter("@Deducere", SqlDbType.Money, 8),
					new SqlParameter("@CoefInvalidGrd1", SqlDbType.Decimal,9),
					new SqlParameter("@CoefInvalidGrd2", SqlDbType.Decimal, 9),
					new SqlParameter("@CoefCopil12", SqlDbType.Decimal, 9),
					new SqlParameter("@CoefCopil3", SqlDbType.Decimal, 9),
					new SqlParameter("@CoefUrmCopil", SqlDbType.Decimal, 9),
					new SqlParameter("@CoefSot", SqlDbType.Decimal, 9),
					new SqlParameter("@CoefTotal", SqlDbType.Decimal, 9),
					new SqlParameter("@CoefSanatate", SqlDbType.Decimal, 9),
					new SqlParameter("@CoefPensie", SqlDbType.Decimal, 9),
					new SqlParameter("@CoefSomaj", SqlDbType.Decimal, 9),
					new SqlParameter("@CoefCheltProf", SqlDbType.Decimal, 9),
					new SqlParameter("@CASAngajator", SqlDbType.Decimal, 9),
					new SqlParameter("@SanatateAngajator", SqlDbType.Decimal, 9),
					new SqlParameter("@SomajAngajator", SqlDbType.Decimal, 9),
					new SqlParameter("@FondRiscAngajator", SqlDbType.Decimal, 9),
					new SqlParameter("@CartiCameraMunca", SqlDbType.Bit, 1),
					new SqlParameter("@CartiCamera", SqlDbType.Decimal, 9),
					new SqlParameter("@CartiAngajator", SqlDbType.Decimal, 9)
				};
			
			parameters[0].Value = setID;
			parameters[1].Value = deLa;
			parameters[2].Value = deducere;
			parameters[3].Value = coefInvalidGrd1;
			parameters[4].Value = coefInvalidGrd2;
			parameters[5].Value = coefCopil12;
			parameters[6].Value = coefCopil3;
			parameters[7].Value = coefUrmCopil;
			parameters[8].Value = coefSot;
			parameters[9].Value = coefTotal;
			parameters[10].Value = coefSanatate;
			parameters[11].Value = coefPensie;
			parameters[12].Value = coefSomaj;
			parameters[13].Value = coefCheltProf;
			parameters[14].Value = casAngajator;
			parameters[15].Value = sanatateAngajator;
			parameters[16].Value = somajAngajator;
			parameters[17].Value = fondRiscAngajator;
			parameters[18].Value = cartiCameraMunca;
			parameters[19].Value = cartiCamera;
			parameters[20].Value = cartiAngajator;

			RunProcedure("sal_UpdateCoef", parameters, out numAffected);

			return (numAffected == 1);
		}
		#endregion
	}
}
