using System;
using System.Data;
using System.Data.SqlClient;

namespace Salaries.Business
{
	/// <summary>
	/// Summary description for SituatieLunaraAngajator.
	/// </summary>
	public class SituatieLunaraAngajator : Salaries.Business.BizObject
	{
		#region Atribute private
		//Setarile aplicatiei
		private Configuration.ModuleSettings m_settings;
		//Id-ul angajatorului
		private long m_AngajatorID;
		//String-ul de conexiune
		private string m_ConnectionString;
		#endregion

		#region SituatieLunaraAngajator
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="AngajatorID">Id-ul angajatorului</param>
		/// <param name="connectionString">String-ul de conexiune</param>
		public SituatieLunaraAngajator( long AngajatorID, string connectionString)
		{
			this.m_AngajatorID = AngajatorID;
			m_settings = Configuration.ModuleConfig.GetSettings();
			m_ConnectionString = connectionString;
		}
		#endregion

		#region SituatieLunaraAngajator
		/// <summary>
		/// Constructor
		/// Adaugat:	Alex Ciobanu
		/// Data:		14.09.2005
		/// </summary>
		/// <param name="AngajatorID">Id-ul angajatorului</param>
		/// <param name="st"></param>
		public SituatieLunaraAngajator(long AngajatorID, Salaries.Configuration.ModuleSettings st)
		{
			this.m_AngajatorID = AngajatorID;
			m_settings = st;
			m_ConnectionString = m_settings.ConnectionString;
		}
		#endregion

		#region GenerareSituatieLunaraAngajator
		/// <summary>
		/// Procedura genereaza situatia lunara a angajatorului
		/// </summary>
		/// <param name="LunaID">Id-ul lunii</param>
		public void GenerareSituatieLunaraAngajator( long LunaID)
		{
			try
			{
				new Salaries.Data.SituatieLunaraAngajator( this.m_AngajatorID,m_ConnectionString).GenerareSituatieLunaraAngajator(LunaID); 
			}
			catch{}
		}
		#endregion
	}
}
