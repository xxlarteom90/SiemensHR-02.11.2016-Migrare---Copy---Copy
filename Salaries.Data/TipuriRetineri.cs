using System;
using System.Data;
using System.Data.SqlClient;

namespace Salaries.Data
{
	/// <summary>
	/// Summary description for TipuriRetineri.
	/// </summary>
	public class TypesOfRestraints : Salaries.Data.DbObject
	{
		#region Constructors
		public TypesOfRestraints(string newConnectionString ) : base( newConnectionString )
		{
		}
		#endregion

		#region InsertLabel
		/// <summary>
		/// Metoda este folosita pentru a adauga etichetele pentru o anumita luna
		/// </summary>
		/// <param name="LunaID">Luna pentru care se adauga etichete</param>
		public void InsertLabel(int LunaID)
		{
			SqlParameter[] parameters =
				{
					new SqlParameter("@LunaID", SqlDbType.Int, 4)
				};
			parameters[0].Value = LunaID;
			
			RunProcedure("spInsertTipuriRetineri", parameters);
		}
		#endregion

		#region UpdateLabel
		/// <summary>
		/// Updates a label, giving the name of restraint
		/// </summary>
		/// <param name="nameOfType">The name of restraint</param>
		/// <param name="labelOfType">The label of restraint</param>
		/// <param name="LunaID">The id of the active month</param>
		public void UpdateLabel(string nameOfType, string labelOfType, int LunaID)
		{
			SqlParameter[] parameters =
				{
					new SqlParameter("@nameOfType", SqlDbType.NVarChar, 32)
					, new SqlParameter("@labelOfType", SqlDbType.NVarChar, 32)
					, new SqlParameter("@LunaID", SqlDbType.Int, 4)
				};
			parameters[0].Value = nameOfType;
			parameters[1].Value = labelOfType;
			parameters[2].Value = LunaID;
			
			RunProcedure("spUpdateLabel", parameters);

		}
		#endregion

		#region CheckIfLabelCanBeDeleted
		/// <summary>
		/// Procedura verifica daca o retinere poate fi stearsa
		/// </summary>
		/// <param name="nume">Numele retinerii</param>
		/// <param name="lunaID">Luna de care apartine retinerea</param>
		/// <returns>Returneaza true daca se poate face stergerea si false altfel</returns>
		public bool CheckIfLabelCanBeDeleted(string nume, int lunaID)
		{
			SqlParameter[] parameters =
				{
					new SqlParameter("@Nume", SqlDbType.NVarChar, 32)
					, new SqlParameter("@LunaID", SqlDbType.Int, 4)
					, new SqlParameter("@NrValori", SqlDbType.Int, 4)
				};
			parameters[0].Value = nume;
			parameters[1].Value = lunaID;
			parameters[2].Direction = ParameterDirection.ReturnValue;
			
			RunProcedure("spCheckIfLabelCanBeDeleted", parameters);
			return (int.Parse(parameters[2].Value.ToString()) == 1);
		}

		#endregion

		#region GetTypesOfRestraints
		/// <summary>
		/// Gets a data set which contain a list with the types of restraint and labels associated with these
		/// </summary>
		/// <param name="LunaID">The id of the active month</param>
		/// <returns>Returns the data set</returns>
		public DataSet GetLabels( int LunaID)
		{
			SqlParameter[] parameters = { new SqlParameter("@LunaID", SqlDbType.Int, 4) };
			parameters[0].Value = LunaID;
			return RunProcedure("spGetTypesOfRetineri", parameters, "AllTypes");
		}
		#endregion

		#region GetCodRetinere
		/// <summary>
		/// Procedura returneaza codul unei retineri din tabela CodareStatDePlataDetaliat
		/// </summary>
		/// <param name="retinere">Numele retinerii pentru care se obtine codul</param>
		/// <returns>Returneaza numele retinerii sau stringul vid</returns>
		public string GetCodRetinere(string retinere)
		{
			SqlParameter[] parameters = { 
											new SqlParameter("@Retinere", SqlDbType.NVarChar, 255) 
										};
			parameters[0].Value = retinere;
			DataSet ds = RunProcedure("spGetCodRetinere", parameters, "GetCodRetinere");

			if (ds.Tables[0].Rows.Count > 0)
			{
				return ds.Tables[0].Rows[0]["Codare"].ToString();
			}
			else
			{
				return "";
			}
		}
		#endregion
	}
}
