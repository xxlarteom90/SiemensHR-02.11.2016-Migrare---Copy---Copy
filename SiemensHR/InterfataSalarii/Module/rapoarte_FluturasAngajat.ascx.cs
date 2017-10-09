using System;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;	
using System.Configuration;

using SiemensHR.utils;
using SiemensHR.Classes;

namespace SiemensHR.InterfataSalarii.Module
{
	/// <summary>
	///		Summary description for rapoarte_FluturasAngajat.
	/// </summary>
	public class rapoarte_FluturasAngajat : SiemensHR.InterfataSalarii.Classes.BaseModule
	{
		#region Variabile
		protected System.Web.UI.WebControls.DropDownList lstAngajati;
		protected ReportingServices.ReportViewer r;
		protected ReportingServices.ReportViewer rapFluturas;
		protected Salaries.Configuration.ModuleSettings settings;		
	
		protected string AllFluturasPath="/Rapoarte/FluturasAngajati";
		protected string SingleFluturasPath="/Rapoarte/Fluturas";
		#endregion

		#region Constrante
		// Numele cheii din web.config care contine calea catre serverul cu rapoartele.
		private const string STRING_URL = "rapoarteServerUrl";
		#endregion

		#region Page_Load
		private void Page_Load(object sender, System.EventArgs e)
		{}
		#endregion

		#region OnPreRender
		protected override void OnPreRender(EventArgs e)
		{
			base.OnPreRender (e);
			if (!IsPostBack)
			{
				settings = Salaries.Configuration.ModuleConfig.GetSettings();
				UtilitiesDb utilDb = new UtilitiesDb(settings.ConnectionString);
				//Modificat:Muntean Raluca Cristina  - am adaugat ca parametru si id-ul angajatorului
				utilDb.CreateAngajatiSelectBox(this.lstAngajati,this.GetAngajator());
				this.lstAngajati.Items.Insert(0,new ListItem("[listare completa]","[listare completa]"));
			}

			this.rapFluturas.ServerUrl = Salaries.Configuration.CryptographyClass.getSettingsWithoutDecode(STRING_URL);

			if (this.lstAngajati.SelectedIndex>0)
			{
				this.rapFluturas.ReportPath=this.SingleFluturasPath;
				this.rapFluturas.SetQueryParameter("AngajatorID",this.GetAngajator().ToString());
				this.rapFluturas.SetQueryParameter("AngajatID",this.lstAngajati.SelectedValue);
				this.rapFluturas.SetQueryParameter("LunaID",this.GetCurrentMonth().ToString());
			}
			else
			{	
				this.rapFluturas.ReportPath=this.AllFluturasPath;
				this.rapFluturas.SetQueryParameter("AngajatorID",this.GetAngajator().ToString());
				this.rapFluturas.SetQueryParameter("LunaID",this.GetCurrentMonth().ToString());	
			}
		}
		#endregion

		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		///		Required method for Designer support - do not modify
		///		the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.lstAngajati.SelectedIndexChanged += new System.EventHandler(this.lstAngajati_SelectedIndexChanged);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region lstAngajati_SelectedIndexChanged
		/// <summary>
		/// Se regenereaza raportul daca a fost selectat alt angajat
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void lstAngajati_SelectedIndexChanged(object sender, System.EventArgs e)
		{}
		#endregion
	}
}
