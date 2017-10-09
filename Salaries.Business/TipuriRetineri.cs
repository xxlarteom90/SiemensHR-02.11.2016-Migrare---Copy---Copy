using System;
using System.Data.SqlClient;
using System.Data;

namespace Salaries.Business
{
	/// <summary>
	/// Summary description for TipuriRetineri.
	/// </summary>
	public class TypesOfRestraints
	{
		#region Constructors
		/// <summary>
		/// Initializes the settings
		/// </summary>
		public TypesOfRestraints()
		{
			settings = Configuration.ModuleConfig.GetSettings();
		}
		#endregion

		#region Fields
		private Configuration.ModuleSettings settings;
		#endregion

		#region InsertLabel
		/// <summary>
		/// Metoda este folosita pentru a adauga etichetele pentru o anumita luna
		/// </summary>
		/// <param name="LunaID">Luna pentru care se adauga etichete</param>
		public void InsertLabel(int LunaID)
		{
			new Salaries.Data.TypesOfRestraints(settings.ConnectionString).InsertLabel(LunaID);
		}
		#endregion

		#region UpdateLabel
		/// <summary>
		/// Updates a label, giving the name of restraint
		/// </summary>
		/// <param name="NameOfType">The name of restraint</param>
		/// <param name="LabelOfType">The label of restraint</param>
		/// <param name="LunaID">The month's id</param>
		public void UpdateLabel(string nameOfType, string labelOfType, int LunaID)
		{
			new Salaries.Data.TypesOfRestraints(settings.ConnectionString).UpdateLabel( nameOfType, labelOfType, LunaID);
		}
		#endregion

		#region CheckIfLabelCanBeDeleted
		/// <summary>
		/// Procedura verifica daca o retinere poate fi stearsa
		/// </summary>
		/// <param name="nume">Numele retinerii</param>
		/// <param name="lunaID">Luna de care apartine retinerea</param>
		/// <returns>Returneaza true daca se poate face stergerea si false altfel</returns>
		public bool CheckIfLabelCanBeDeleted(string nume, int LunaID)
		{
			return new Salaries.Data.TypesOfRestraints(settings.ConnectionString).CheckIfLabelCanBeDeleted(nume, LunaID);
		}
		#endregion

		#region GetTypesOfRestraints
		/// <summary>
		/// Returns a data set which contain a list with the types of restraint and labels associated with these
		/// </summary>
		/// <param name="LunaID">The month's id</param>
		/// <returns>Returns the data set</returns>
		public DataSet GetLabels( int LunaID)
		{
			return new Salaries.Data.TypesOfRestraints(settings.ConnectionString).GetLabels( LunaID);		
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
			return new Salaries.Data.TypesOfRestraints(settings.ConnectionString).GetCodRetinere(retinere);		
		}
		#endregion
	}
}
