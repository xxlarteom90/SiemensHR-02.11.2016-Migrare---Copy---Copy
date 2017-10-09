using System;
using System.Data;
using System.Data.SqlClient;

namespace Salaries.Data
{
	public class DetaliiImpozitar_anual
	{
		public int ID;
		public DateTime Data;
		public decimal Suma;
		public decimal ValMin;
		public decimal ValMax;
		public decimal Procent;
		public int CategorieID;
	}

	/// <summary>
	/// Summary description for Impozitar_anual.
	/// </summary>
	public class Impozitar_anual:Salaries.Data.DbObject
	{
		public Impozitar_anual(string newConnectionString)
			: base (newConnectionString)
		{
		}

		public DetaliiImpozitar_anual GetDetalii(DateTime data,decimal suma,int categorieId)
		{
			SqlParameter[] parameters = {new SqlParameter("@Data", SqlDbType.DateTime, 8),
											new SqlParameter("@Suma", SqlDbType.Money, 8),
											new SqlParameter("@CategorieID", SqlDbType.Int, 4)};

			parameters[0].Value = data;
			parameters[1].Value = suma;
			parameters[2].Value = categorieId;
			
			using(DataSet detaliiDS = RunProcedure("sal_GetImpozitarAnual", parameters, "Impozitar"))
			{
				DetaliiImpozitar_anual detalii = new DetaliiImpozitar_anual();
				if (detaliiDS.Tables[0].Rows.Count > 0)
				{
					DataRow rowDetalii = detaliiDS.Tables[0].Rows[0];
					detalii.ID = (int)rowDetalii["ImpozitarID"];
					detalii.Data = (DateTime)rowDetalii["Data"];
					detalii.ValMin = (decimal)rowDetalii["ValMin"];
					detalii.ValMax = (decimal)rowDetalii["ValMax"];					
					detalii.Suma=(decimal)rowDetalii["Suma"];
					detalii.Procent=(decimal)rowDetalii["Procent"];
					detalii.CategorieID=(int)rowDetalii["CategorieID"];
				}
				else
					detalii.ID = -1;

				return detalii;
			}
		}
		 
		public DetaliiImpozitar_anual GetDetalii(int setID)
		{
			SqlParameter[] parameters = { new SqlParameter("@ImpozitarID", SqlDbType.Int, 4) };
			parameters[0].Value = setID;
			
			using(DataSet detaliiDS = RunProcedure("sal_GetImpozitarAnualById", parameters, "Detalii"))
			{
				DetaliiImpozitar_anual detalii = new DetaliiImpozitar_anual();
				if (detaliiDS.Tables[0].Rows.Count > 0)
				{
					DataRow rowDetalii = detaliiDS.Tables[0].Rows[0];
					detalii.ID = (int)rowDetalii["ImpozitarID"];
					detalii.Data = (DateTime)rowDetalii["Data"];
					detalii.ValMin = (decimal)rowDetalii["ValMin"];
					detalii.ValMax = (decimal)rowDetalii["ValMax"];					
					detalii.Suma=(decimal)rowDetalii["Suma"];
					detalii.Procent=(decimal)rowDetalii["Procent"];	
					detalii.CategorieID=(int)rowDetalii["CategorieID"];
				}
				else
					detalii.ID = -1;

				return detalii;
			}
		}
		
		public bool Delete(int setID)
		{
			int numAffected;
		
			SqlParameter[] parameters = { new SqlParameter("@ImpozitarID", SqlDbType.Int, 4) };
			parameters[0].Value = setID;
			
			RunProcedure("sal_DeleteImpozitarAnual", parameters, out numAffected);

			return (numAffected == 1);
		}

		public bool Update(int id,DateTime data,decimal valMin,decimal valMax,decimal suma,decimal procent,int categorieId)
		{
			int numAffected;
		
			SqlParameter[] parameters = {		
											new SqlParameter("@ImpozitarID", SqlDbType.Int, 4),
											new SqlParameter("@Data", SqlDbType.DateTime, 8),
											new SqlParameter("@ValMin", SqlDbType.Money, 8),
											new SqlParameter("@ValMax", SqlDbType.Money,9),
											new SqlParameter("@Suma", SqlDbType.Money, 9),
											new SqlParameter("@Procent", SqlDbType.Decimal,4),
											new SqlParameter("@CategorieID", SqlDbType.Int,4)
										};
			
			parameters[0].Value=id;
			parameters[1].Value = data;
			parameters[2].Value = valMin;
			parameters[3].Value = valMax;
			parameters[4].Value = suma;
			parameters[5].Value = procent;
			parameters[6].Value = categorieId;
			
			RunProcedure("sal_UpdateImpozitarAnual", parameters, out numAffected);

			return (numAffected == 1);
		}

		public int Add(DateTime data,decimal valMin,decimal valMax,decimal suma,decimal procent,int categorieId)
		{
			int numAffected;
		
			SqlParameter[] parameters = {		
											new SqlParameter("@SetID", SqlDbType.Int, 4),
											new SqlParameter("@Data", SqlDbType.DateTime, 8),
											new SqlParameter("@ValMin", SqlDbType.Money, 8),
											new SqlParameter("@ValMax", SqlDbType.Money,9),
											new SqlParameter("@Suma", SqlDbType.Money, 9),
											new SqlParameter("@Procent", SqlDbType.Decimal,4),
											new SqlParameter("@CategorieID", SqlDbType.Int,4)};
			
			parameters[0].Direction =ParameterDirection.Output;
			parameters[1].Value = data;
			parameters[2].Value = valMin;
			parameters[3].Value = valMax;
			parameters[4].Value = suma;
			parameters[5].Value = procent;
			parameters[6].Value = categorieId;
			
			RunProcedure("sal_InsertImpozitarAnual", parameters, out numAffected);

			return (int)parameters[0].Value;
		}

		public DataSet GetImpozitar(int LunaID)
		{			
			
			SqlParameter[] parameters = {new SqlParameter("@LunaID", SqlDbType.Int, 4)};
			parameters[0].Value = LunaID;
			return RunProcedure("sal_GetAllImpozitarAnual", parameters, "Impozitar");
		}


	}
}
