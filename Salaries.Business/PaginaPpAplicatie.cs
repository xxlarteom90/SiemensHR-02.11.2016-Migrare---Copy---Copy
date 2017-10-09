using System;
using System.Data;
using System.Data.SqlClient;

namespace Salaries.Business
{
	/// <summary>
	/// Summary description for PaginaPpAplicatie.
	/// </summary>
	public class PaginaPpAplicatie
	{
		#region Atribute private
		//Setarile aplicatiei
		private Configuration.ModuleSettings settings;
		//Id-ul paginii
		public int paginaID;
		//Numele paginii
		public string numePagina;
		//Descrierea paginii
		public string descrierePagina;
		#endregion

		#region Proprietati
		public int PaginaID
		{
			get{return paginaID;}
			set{paginaID=value;}
		}

		public string NumePagina
		{
			get{return numePagina;}
			set{numePagina = value;}
		}

		public string DescrierePagina
		{
			get{return descrierePagina;}
			set{descrierePagina=value;}
		}
		#endregion

		#region Constructor
		/// <summary>
		/// Constructor
		/// </summary>
		public PaginaPpAplicatie()
		{
			settings = Configuration.ModuleConfig.GetSettings();
		}
		#endregion

		#region GetDetalii
		/// <summary>
		/// Returneaza toate detaliile despre o pagina pp a aplicatiei
		/// </summary>
		/// <param name="paginaID">Id-ul paginii selectate</param>
		/// <returns>Returneaza un obiecta care contine aceste date</returns>
		public Salaries.Data.PgPpAplicDetails GetDetalii(int paginaID)
		{
			Data.PaginiPpAplicatie pagina = new Salaries.Data.PaginiPpAplicatie(settings.ConnectionString);
			return pagina.GetDetalii(paginaID);
		}
		#endregion
		
		#region GetPaginiPpAplicatie
		/// <summary>
		/// Returneaza toate paginile principale ale aplicatiei
		/// </summary>
		/// <returns>Returneaza un DataSet care contine aceste date</returns>
		public DataSet GetPaginiPpAplicatie()
		{
			Data.PaginiPpAplicatie pagina = new Salaries.Data.PaginiPpAplicatie(settings.ConnectionString);
			return pagina.GetPaginiPpAplicatie();
		}
		#endregion

		#region Insert
		/// <summary>
		/// Insereaza o pagina pp a aplicatiei
		/// </summary>
		/// <param name="numePagina">Numele paginii</param>
		/// <param name="descrierePagina">Descrierea paginii</param>
		/// <returns>Returneaza rezultatul adaugarii</returns>
		public int Insert(string numePagina, string descrierePagina)
		{
			Data.PaginiPpAplicatie pagina = new Salaries.Data.PaginiPpAplicatie(settings.ConnectionString);
			return pagina.Insert(numePagina, descrierePagina);
		}
		#endregion

		#region Update
		/// <summary>
		/// Face update unuei pagini pp a apliatiei
		/// </summary>
		public void Update()
		{
			Data.PaginiPpAplicatie pagina = new Salaries.Data.PaginiPpAplicatie(settings.ConnectionString);
			pagina.Update(paginaID, numePagina, descrierePagina);
		}
		#endregion

		#region Delete
		/// <summary>
		/// Sterge o pagina pp a aplicatiei 
		/// </summary>
		public void Delete()
		{
			Data.PaginiPpAplicatie pagina = new Salaries.Data.PaginiPpAplicatie(settings.ConnectionString);
			pagina.Delete(paginaID);
		}	
		#endregion
	}
}
