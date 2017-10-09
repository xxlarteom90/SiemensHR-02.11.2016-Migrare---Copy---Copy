using System;
using System.Data;
using System.Data.SqlClient;
using Salaries.Data;

namespace Salaries.Business
{
	/// <summary>
	/// Summary description for AdminUtilizatori.
	/// </summary>
	public class AdminUtilizatori
	{
		#region Atribute private
		// Setarile aplicatiei.
		private Configuration.ModuleSettings settings;
		//Id-ul utilizatorului
		private int utilizatorId;
		//Id-ul grupului din care face parte
		private int grupUtilizatorAngajatorId;
		//Numele utilizatorului
		private string nume;
		//Parola utilizatorului
		private string parola;
		//email
		private string email;
		#endregion

		#region Constructor
		/// <summary>
		/// Constructorul vid
		/// </summary>
		public AdminUtilizatori()
		{
			settings = Configuration.ModuleConfig.GetSettings();
		}
		#endregion

		#region Proprietati
		/// <summary>
		/// Id-ul utilizatorului.
		/// </summary>
		public int UtilizatorId
		{
			get	{ return utilizatorId; }
			set { utilizatorId = value; }
		}
		/// <summary>
		/// Id-ul grupului din care face parte.
		/// </summary>
		public int GrupUtilizatorAngajatorId
		{
			get	{ return grupUtilizatorAngajatorId; }
			set { grupUtilizatorAngajatorId = value; }
		}
		/// <summary>
		/// Numele utilizatorului.
		/// </summary>
		public string Nume
		{
			get	{ return nume; }
			set { nume = value; }
		}
		/// <summary>
		/// Parola utilizatorului.
		/// </summary>
		public string Parola
		{
			get	{ return parola; }
			set { parola = value; }
		}
		/// <summary>
		/// Emailul utilizatorului.
		/// </summary>
		public string Email
		{
			get	{ return email; }
			set { email = value; }
		}
		#endregion

		#region LoadInfoUtilizatori
		/// <summary>
		/// Procedura selecteaza utilizatorii unui angajator
		/// </summary>
		/// <param name="angajatorId">Id-ul angajatorului pentru care sunt selectati utilizatorii</param>
		public DataSet LoadInfoUtilizatori(int angajatorId)
		{
			Salaries.Data.AdminUtilizatori utilizatori = new Salaries.Data.AdminUtilizatori(settings.ConnectionString);
			return utilizatori.LoadInfoUtilizatori(angajatorId);
		}
		#endregion

		#region InsertUtilizator
		/// <summary>
		/// Procedura adauga un utilizator
		/// </summary>
		public void InsertUtilizator()
		{
			Salaries.Data.AdminUtilizatori utilizator = new Salaries.Data.AdminUtilizatori(settings.ConnectionString);
			utilizator.InsertUtilizator(grupUtilizatorAngajatorId, nume, parola, email);
		}
		#endregion

		#region UpdateUtilizator
		/// <summary>
		/// Procedura modifica datele unui utilizator
		/// </summary>
		public void UpdateUtilizator()
		{
			Salaries.Data.AdminUtilizatori utilizator = new Salaries.Data.AdminUtilizatori(settings.ConnectionString);
			utilizator.UpdateUtilizator(nume, parola, utilizatorId, email);
		}
		#endregion

		#region DeleteUtilizator
		/// <summary>
		/// Procedura sterge un utilizator
		/// </summary>
		public void DeleteUtilizator()
		{
			Salaries.Data.AdminUtilizatori utilizator= new Salaries.Data.AdminUtilizatori(settings.ConnectionString);
			utilizator.DeleteUtilizator(utilizatorId);
		}
		#endregion

		#region VerificaExistentaUtilizator
		/// <summary>
		/// Verifica daca mai exista inca un utilizator care are acelasi grup, nume si parola cu utilizatorul ce se doreste a fi
		/// adaugat
		/// </summary>
		/// <returns> true in cazul in care mai exista un utilizator ce are aceleasi caracteristici, false altfel.</returns>
		/// <remarks>
		/// Autor:  Lungu Andreea
		/// Data:   01.11.2007
		/// </remarks>
		public bool VerificaExistentaUtilizator()
		{
			Salaries.Data.AdminUtilizatori utilizator = new Salaries.Data.AdminUtilizatori(settings.ConnectionString);
			return utilizator.VerificaExistentaUtilizator(utilizatorId, grupUtilizatorAngajatorId, nume, parola);
		}
		#endregion

		#region VerificaStergereUtilizator
		/// <summary>
		/// Verifica daca se poate sterge utilizatorul.
		/// </summary>
		/// <returns> true in cazul in care se poate sterge utilizatorul, false altfel.</returns>
		/// <remarks>
		/// Autor:  Lungu Andreea
		/// Data:   01.11.2007
		/// </remarks>
		public int VerificaStergereUtilizator()
		{
			Salaries.Data.AdminUtilizatori utilizator = new Salaries.Data.AdminUtilizatori(settings.ConnectionString);
			return utilizator.VerificaStergereUtilizator(utilizatorId);
		}
		#endregion

		#region GetGrupAngajatorUtilizatorId
		/// <summary>
		/// Aduce id-ul dat de legatura dintre grup si angajator
		/// </summary>
		/// <param name="angajatorId">id-ul angajatorului</param>
		/// <param name="grupId">id-ul grupului</param>
		/// <returns>returneaza id-ul legaturii dintre grup si angajator</returns>
		public int GetGrupAngajatorUtilizatorId(int angajatorId,int grupId)
		{
			Salaries.Data.AdminUtilizatori utilizator = new Salaries.Data.AdminUtilizatori(settings.ConnectionString);
			return utilizator.GetGrupUtilizatorAngajatorId(angajatorId, grupId);
		}
		#endregion

		#region GetUtilizatorId
		//Autor: Lungu Andreea
		//Data: 02.11.2007
		/// <summary>
		/// Procedura aduce id-ul utilizatorului care are numele, parola si angajatorul prezizate.
		/// </summary>
		/// <param name="nume">nume utilizator</param>
		/// <param name="parola">parola utilizator</param>
		/// <param name="angajatorId">id angajator</param>
		/// <returns>id-ul utilizatorului</returns>
		public int GetUtilizatorId(int angajatorId)
		{
			Salaries.Data.AdminUtilizatori utilizator = new Salaries.Data.AdminUtilizatori(settings.ConnectionString);
			return utilizator.GetUtilizatorId(nume, Salaries.Configuration.CryptographyClass.encodeSTR(parola), angajatorId);
		}
		#endregion

		#region LoadInfoUtilizator
		/// <summary>
		/// Procedura aduce detaliile unui utilizator selecteaza utilizatorii unui angajator
		/// </summary>
		public void LoadInfoUtilizator()
		{
			Salaries.Data.AdminUtilizatori utilizatori = new Salaries.Data.AdminUtilizatori(settings.ConnectionString);
			DataSet ds = utilizatori.LoadInfoUtilizator(utilizatorId);
			if (ds!=null && ds.Tables[0].Rows.Count > 0)
			{
				DataRow dr = ds.Tables[0].Rows[0];
				this.grupUtilizatorAngajatorId = Int32.Parse(dr["GrupUtilizatorAngajatorId"].ToString());
				this.nume = dr["Nume"].ToString();
				this.utilizatorId = utilizatorId;
				this.email = dr["Email"].ToString();
				this.parola = dr["Parola"].ToString();
			}
		}
		#endregion
	
	}

}
