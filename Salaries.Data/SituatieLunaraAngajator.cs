using System;
using System.Data.SqlClient;
using System.Data;

namespace Salaries.Data
{
	/// <summary>
	/// Summary description for SituatieLunaraAngajator.
	/// </summary>
	public class SituatieLunaraAngajator: Salaries.Data.DbObject
	{
		//Id-ul angajatorului
		private long m_AngajatorID;

		#region Construcotr
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="AngajatorID">Id-ul angajatorului</param>
		/// <param name="newConnectionString">Stringul de conexiune la baza de date</param>
		public SituatieLunaraAngajator( long AngajatorID, string newConnectionString): base (newConnectionString)
		{
			m_AngajatorID = AngajatorID;
		}
		#endregion

		#region GenerareSituatieLunaraAngajator
		/// <summary>
		/// Procedura genereaza situatia lunara a angajatorului
		/// </summary>
		/// <param name="LunaID">Id-ul lunii</param>
		public void GenerareSituatieLunaraAngajator( long LunaID)
		{	
			SqlParameter[] parameters = 
				{
					new SqlParameter("@LunaID", SqlDbType.Int, 4),
					new SqlParameter("@AngajatorID", SqlDbType.Int, 4)
				};

			parameters[0].Value = LunaID;
			parameters[1].Value = m_AngajatorID;

			RunProcedure("spGenerareSituatieLunaraAngajator", parameters);
		}
		#endregion
	}
}
