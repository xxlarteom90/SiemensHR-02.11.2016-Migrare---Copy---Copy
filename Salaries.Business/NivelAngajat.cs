using System;
using System.Data;
using System.Data.SqlClient;

namespace Salaries.Business
{
	/// <summary>
	/// Summary description for NivelAngajat.
	/// </summary>
	public class NivelAngajat
	{
		#region Atribute private
		// Setarile aplicatiei.
		private Configuration.ModuleSettings settings;
		//Id-ul nivelului
		private int idNivelAngajat;
		//Id-ul angajatorului
		private int angajatorId;
		//Nivelul
		private string nivel;
		#endregion

		#region Constructor
		/// <summary>
		/// Constructorul vid
		/// </summary>
		public NivelAngajat()
		{
			settings = Configuration.ModuleConfig.GetSettings();
		}
		#endregion

		#region Proprietati
		/// <summary>
		/// Id-ul nivelului.
		/// </summary>
		public int IdNivelAngajat
		{
			get	{ return idNivelAngajat; }
			set { idNivelAngajat = value; }
		}
		/// <summary>
		/// Id-ul angajatorului.
		/// </summary>
		public int AngajatorId
		{
			get	{ return angajatorId; }
			set { angajatorId = value; }
		}
		/// <summary>
		/// Nivelul.
		/// </summary>
		public string Nivel
		{
			get	{ return nivel; }
			set { nivel = value; }
		}
		#endregion

		#region LoadNivele
		/// <summary>
		/// Procedura selecteaza toate nivelele
		/// </summary>
		/// <returns>Returneaza un DataSet care contine aceste nivelele</returns>
		public DataSet LoadNivele()
		{
			Salaries.Data.NivelAngajat nivelAng = new Salaries.Data.NivelAngajat(settings.ConnectionString);
			return nivelAng.LoadNivele(this.angajatorId);
		}
		#endregion

		#region LoadNivelePentruAngajat
		/// <summary>
		/// Procedura selecteaza toate nivelele pentru un angajat (specific true sau falsa daca face parte sau nu dintr-un nivel)
		/// </summary>
		/// <returns>Returneaza un DataSet care contine aceste nivelele</returns>
		public DataSet LoadNivelePentruAngajat(long idAngajat)
		{
			Salaries.Data.NivelAngajat nivelAng = new Salaries.Data.NivelAngajat(settings.ConnectionString);
			return nivelAng.LoadNivelePentruAngajat(this.angajatorId, idAngajat);
		}
		#endregion

		#region EsteAngajatInNivel
		/// <summary>
		/// Procedura verifica daca un angajat este sau nu intr-un anumit nivel
		/// </summary>
		/// <returns>daca este sau nu in nive</returns>
		public bool EsteAngajatInNivel(long idAngajat)
		{
			Salaries.Data.NivelAngajat nivelAng = new Salaries.Data.NivelAngajat(settings.ConnectionString);
			return nivelAng.EsteAngajatInNivel(idAngajat, this.idNivelAngajat);
		}
		#endregion

		#region RemoveAngajatFromNivel
		/// <summary>
		/// Procedura sterge legatura dintre un angajat si un nivel
		/// </summary>
		public void RemoveAngajatFromNivel(long idAngajat)
		{
			Salaries.Data.NivelAngajat nivelAng = new Salaries.Data.NivelAngajat(settings.ConnectionString);
			nivelAng.RemoveAngajatFromNivel(idAngajat, this.idNivelAngajat);
		}
		#endregion

		#region AddAngajatInNivel
		/// <summary>
		/// Procedura adauga legatura dintre un angajat si un nivel
		/// </summary>
		public void AddAngajatInNivel(long idAngajat)
		{
			Salaries.Data.NivelAngajat nivelAng = new Salaries.Data.NivelAngajat(settings.ConnectionString);
			nivelAng.AddAngajatInNivel(idAngajat, this.idNivelAngajat);
		}
		#endregion

		#region GetAngajatiPentruUtilizator
		/// <summary>
		/// Procedura aduce angajatii la care are acces un utilizator.
		/// </summary>
		public DataSet GetAngajatiPentruUtilizator(int idUtilizator)
		{
			Salaries.Data.NivelAngajat nivelAng = new Salaries.Data.NivelAngajat(settings.ConnectionString);
			return nivelAng.GetAngajatiPentruUtilizator(this.angajatorId, idUtilizator);
		}
		#endregion
	}
}
