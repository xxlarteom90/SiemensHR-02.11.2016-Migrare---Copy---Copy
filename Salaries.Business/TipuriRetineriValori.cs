using System;
using System.Data.SqlClient;
using System.Data;

namespace Salaries.Business
{
	/// <summary>
	/// Summary description for TipuriRetineriValori.
	/// </summary>
	public class TipuriRetineriValori
	{
		#region Variabile
		private Configuration.ModuleSettings settings;
		#endregion

		#region Constructor
		/// <summary>
		/// Initializes the settings
		/// </summary>
		public TipuriRetineriValori()
		{
			settings = Configuration.ModuleConfig.GetSettings();
		}
		#endregion

		#region InsertRetineriValori
		/// <summary>
		/// Metoda este folosita pentru a adauga valorile retinerilor pentru un angajat
		/// </summary>
		/// <param name="lunaID">Luna pentru care se adauga retinerile</param>
		/// <param name="angajatID">Angajatul pentru care se adauga retinerile</param>
		public void InsertRetineriValori(int LunaID, long AngajatID)
		{
			new Salaries.Data.TipuriRetineriValori(this.settings.ConnectionString).InsertRetineriValori(LunaID, AngajatID);
		}
		#endregion

		#region UpdateRetineriValori
		/// <summary>
		/// Metoda este folosita pentru a actualiza valorile etichetelor pentru un angajat intr-o luna
		/// </summary>
		/// <param name="lunaID">Luna pentru care se actualizeaza etichetele</param>
		/// <param name="angajatID">Angajatul pentru care se actualizeaza etichetele</param>
		/// <param name="retinere1">Valorile retinerilor</param>
		/// <param name="retinere2"></param>
		/// <param name="retinere3"></param>
		/// <param name="retinere4"></param>
		/// <param name="retinere5"></param>
		/// <param name="retinere6"></param>
		/// <param name="retinere7"></param>
		public void UpdateRetineriValori(int lunaID, long angajatID, decimal retinere1, decimal retinere2, decimal retinere3, decimal retinere4, decimal retinere5, decimal retinere6, decimal retinere7)
		{
			new Salaries.Data.TipuriRetineriValori(settings.ConnectionString).UpdateRetineriValori(lunaID, angajatID, retinere1, retinere2, retinere3, retinere4, retinere5, retinere6, retinere7);
		}
		#endregion

		#region UpdateValoareRetinere
		/// <summary>
		/// Metoda este folosita pentru a actualiza valorile etichetelor pentru un angajat intr-o luna
		/// </summary>
		/// <param name="lunaID">Luna pentru care se actualizeaza etichetele</param>
		/// <param name="angajatID">Angajatul pentru care se actualizeaza etichetele</param>
		/// <param name="numeRetinere">numele retinerii</param>
		/// <param name="valoreRetinere">valoarea retinerii</param>
		public void UpdateValoareRetinere(int lunaID, long angajatID, string numeRetinere, decimal valoareRetinere)
		{
			new Salaries.Data.TipuriRetineriValori(settings.ConnectionString).UpdateValoareRetinere(lunaID, angajatID, numeRetinere, valoareRetinere);
		}
		#endregion
			
		#region GetRetineriValori
		/// <summary>
		/// Metoda returneaza tipurile de retineri impreuna cu valorile acestora pentru un angajat intr-o anumita luna
		/// </summary>
		/// <param name="LunaID">Luna pentru care se obtin retineri</param>
		/// <param name="AngajatID">Angajatul pentru care se obtine retinerile</param>
		/// <returns>Returneaza un DataSet care contine aceste valori</returns>
		public DataSet GetRetineriValori(int LunaID, int AngajatID)
		{
			return new Salaries.Data.TipuriRetineriValori(settings.ConnectionString).GetRetineriValori(LunaID, AngajatID);		
		}
		#endregion
	}
}
