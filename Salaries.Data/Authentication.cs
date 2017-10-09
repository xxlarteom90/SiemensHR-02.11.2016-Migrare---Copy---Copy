using System;
using System.Data.SqlClient;
using System.Data;

namespace Salaries.Data
{
	/// <summary>
	/// Summary description for Authentication.
	/// </summary>
	public class Authentication: Salaries.Data.DbObject
	{
		#region Constructor
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="newConnectionString">String de conexiune la baza de date</param>
		public Authentication(string newConnectionString): base (newConnectionString)
		{}	
		#endregion

		#region HasUserRightsOnPage
		/// <summary>
		/// Verifica daca grupul din care face parte user-ul are dreptul asupra paginii primite ca parametru
		/// </summary>
		/// <param name="numeGrup">Numele grupului</param>
		/// <param name="numePagina">Numele paginii</param>
		/// <returns>Returneaza true daca utilizatorul are acces si false altfel</returns>
		public bool HasUserRightsOnPage( string numeGrup, string numePagina)
		{
			int numAffected;
		
			SqlParameter[] parameters = 
				{
					new SqlParameter("@NumeGrup", SqlDbType.NVarChar, 50),
					new SqlParameter("@NumePagina", SqlDbType.NVarChar, 50),
					new SqlParameter("@Apartine", SqlDbType.Bit, 1)
				};
			
			parameters[0].Value = numeGrup;
			parameters[1].Value = numePagina;
			parameters[2].Direction = ParameterDirection.Output;
			
			RunProcedure("CheckIfPaginaApDeGrup", parameters, out numAffected);
			return (bool)parameters[2].Value;
		}
		#endregion
	}
}
