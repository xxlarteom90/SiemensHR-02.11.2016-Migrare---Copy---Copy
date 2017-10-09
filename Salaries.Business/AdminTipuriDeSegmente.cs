/*
 * Autor:		Oprescu Claudia
 * Data:		10.07.2007
 * Descriere:	Clasa se ocupa cu Tipurile de segmente de management.
 */	

using System;
using System.Data;
using System.Data.SqlClient;

namespace Salaries.Business
{
	/// <summary>
	/// Summary description for AdminTipuriDeSegmente.
	/// </summary>
	public class AdminTipuriDeSegmente
	{
		#region Atribute private
		// Setarile aplicatiei.
		private Configuration.ModuleSettings settings;
		//Id-ul tipului de segment de management
		private int tipDeSegmentId;
		//Codul tipului de segment de management
		private string cod;
		//Denumirea tipului de segment de management
		private string denumire;
		#endregion

		#region Proprietati
		/// <summary>
		/// ID-ul tipului de segment de management.
		/// </summary>
		public int TipDeSegmentId
		{
			get{ return tipDeSegmentId; }
			set{ tipDeSegmentId = value;}
		}
		/// <summary>
		/// Codul tipului de segment de management.
		/// </summary>
		public string Cod
		{
			get{ return cod; }
			set{ cod = value;}
		}
		/// <summary>
		/// Denumirea tipului de segment de management.
		/// </summary>
		public string Denumire
		{
			get{ return denumire; }
			set{ denumire = value;}
		}
		#endregion

		#region Constructor
		/// <summary>
		/// Constructorul vid
		/// </summary>
		public AdminTipuriDeSegmente()
		{
			settings = Configuration.ModuleConfig.GetSettings();
		}
		#endregion

		#region LoadTipuriDeSegmente
		/// <summary>
		/// Procedura selecteaza tipurile de segmente de management existente
		/// </summary>
		/// <returns>Returneaza un DataSet care contine tipurile de segmente de management</returns>
		public DataSet LoadTipuriDeSegmente()
		{
			Salaries.Data.AdminTipuriDeSegmente tipuriSegmente = new Salaries.Data.AdminTipuriDeSegmente(settings.ConnectionString);
			return tipuriSegmente.LoadTipuriDeSegmente();
		}
		#endregion
	}
}
