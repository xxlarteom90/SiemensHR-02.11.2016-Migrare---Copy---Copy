using System;
using System.Data;
using System.Data.SqlClient;

namespace Salaries.Business
{
	/// <summary>
	/// Summary description for NivelUtilizator.
	/// </summary>
	public class NivelUtilizator
	{
		#region Atribute private
		// Setarile aplicatiei.
		private Configuration.ModuleSettings settings;
		//Id-ul nivelului
		private int idNivel;
		//Nivelul
		private string nivel;
		//angajator id
		private int angajatorId;
		#endregion

		#region Constructor
		/// <summary>
		/// Constructorul vid
		/// </summary>
		public NivelUtilizator()
		{
			settings = Configuration.ModuleConfig.GetSettings();
		}
		#endregion

		#region Proprietati
		/// <summary>
		/// Id-ul nivelului.
		/// </summary>
		public int IdNivel
		{
			get	{ return idNivel; }
			set { idNivel = value; }
		}
		/// <summary>
		/// Nivelul.
		/// </summary>
		public string Nivel
		{
			get	{ return nivel; }
			set { nivel = value; }
		}
		/// <summary>
		/// Id-ul angajatorului.
		/// </summary>
		public int AngajatorId
		{
			get	{ return angajatorId; }
			set { angajatorId = value; }
		}
		#endregion

		#region LoadNivele
		/// <summary>
		/// Procedura selecteaza toate nivelele
		/// </summary>
		/// <returns>Returneaza un DataSet care contine aceste nivelele</returns>
		public DataSet LoadNivele()
		{
			Salaries.Data.NivelUtilizator nivelUtiliz = new Salaries.Data.NivelUtilizator(settings.ConnectionString);
			return nivelUtiliz.LoadNivele(this.angajatorId);
		}
		#endregion

		#region LoadNivelePentruUtilizator
		/// <summary>
		/// Procedura selecteaza toate nivelele pentru un utilizator (specific true sau falsa daca face parte sau nu dintr-un nivel)
		/// </summary>
		/// <returns>Returneaza un DataSet care contine aceste nivelele</returns>
		public DataSet LoadNivelePentruUtilizator(long idUtilizator)
		{
			Salaries.Data.NivelUtilizator nivelUtiliz = new Salaries.Data.NivelUtilizator(settings.ConnectionString);
			return nivelUtiliz.LoadNivelePentruUtilizator(this.angajatorId, idUtilizator);
		}
		#endregion

		#region EsteUtilizatorInNivel
		/// <summary>
		/// Procedura verifica daca un utilizator are drepturi sau nu pe un anumit nivel
		/// </summary>
		/// <returns>daca are drepturi sau nu</returns>
		public bool EsteUtilizatorInNivel(long idUtilizator)
		{
			Salaries.Data.NivelUtilizator nivelUtiliz = new Salaries.Data.NivelUtilizator(settings.ConnectionString);
			return nivelUtiliz.EsteUtilizatorInNivel(idUtilizator, this.idNivel);
		}
		#endregion

		#region RemoveUtilizatorFromNivel
		/// <summary>
		/// Procedura sterge legatura dintre un utilizator si un nivel
		/// </summary>
		public void RemoveUtilizatorFromNivel(long idUtilizator)
		{
			Salaries.Data.NivelUtilizator nivelUtiliz = new Salaries.Data.NivelUtilizator(settings.ConnectionString);
			nivelUtiliz.RemoveUtilizatorFromNivel(idUtilizator, this.idNivel);
		}
		#endregion

		#region AddUtilizatorInNivel
		/// <summary>
		/// Procedura adauga legatura dintre un utilizator si un nivel
		/// </summary>
		public void AddUtilizatorInNivel(long idUtilizator)
		{
			Salaries.Data.NivelUtilizator nivelUtiliz = new Salaries.Data.NivelUtilizator(settings.ConnectionString);
			nivelUtiliz.AddUtilizatorInNivel(idUtilizator, this.idNivel);
		}
		#endregion
	}
}
