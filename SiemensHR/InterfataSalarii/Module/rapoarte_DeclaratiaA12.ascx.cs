/*
 * Autor:     Cristina Raluca Muntean
 * Data:      17.04.2006
 * Descriere: Este generata declaratia A12 pentru casa de asigurari sociale.
 */

using System;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.IO;

namespace SiemensHR.InterfataSalarii.Module
{
	/// <summary>
	///	Este generata declaratia A12 pentru casa de asigurari sociale.
	/// </summary>
	public class rapoarte_DeclaratiaA12 : SiemensHR.InterfataSalarii.Classes.BaseModule
	{
		#region Variabile
		protected System.Web.UI.WebControls.TextBox txtDataPlatii;
		protected System.Web.UI.WebControls.RegularExpressionValidator vldData;
		protected System.Web.UI.WebControls.Label labelError;
		protected System.Web.UI.WebControls.Button btnAfiseaza;
		protected System.Web.UI.WebControls.ValidationSummary sumarValidare;
		protected ReportingServices.ReportViewer raportDeclaratiaA12;
		protected System.Web.UI.WebControls.RangeValidator vldNrFileAnexa11;
		protected System.Web.UI.WebControls.RequiredFieldValidator requiredData;
		protected System.Web.UI.WebControls.RequiredFieldValidator Requiredfieldvalidator1;
		protected System.Web.UI.WebControls.Button btnDownloadA12;
		protected System.Web.UI.WebControls.TextBox txtNrFileAnexa11;
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
			try
			{
				// Luna curenta.
				Salaries.Business.Luni luna = new Salaries.Business.Luni( this.GetAngajator() );
				Salaries.Data.LunaData lunaCurenta = luna.GetLunaActiva();
            
				if (!IsPostBack)
				{
					// Este setata data la care se face plata drepturilor salariale.
					txtDataPlatii.Text = lunaCurenta.Data.ToShortDateString();
				}
				this.raportDeclaratiaA12.ServerUrl = Salaries.Configuration.CryptographyClass.getSettingsWithoutDecode(STRING_URL);
				// Sunt setati parametrii raportului.
				// ID-ul angajatorului pentru care se genereaza declaratia.
				this.raportDeclaratiaA12.SetQueryParameter("AngajatorID",this.GetAngajator().ToString());
				// Id-ul lunii pentru care se genereaza declaratia.
				this.raportDeclaratiaA12.SetQueryParameter("LunaID",this.GetCurrentMonth().ToString());
				// Data platii drepturilor salariale.
				this.raportDeclaratiaA12.SetQueryParameter("DataPlataSalariu",txtDataPlatii.Text);
				// Numarul de pagini ale declaratiei A11.
				this.raportDeclaratiaA12.SetQueryParameter("NumarFileAnexa11",txtNrFileAnexa11.Text);
			}
			catch ( Exception )
			{
				labelError.Text = "Pentru a putea genera declaratia trebuie sa fie disponibile toate datele necesare!";
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
			this.btnDownloadA12.Click += new System.EventHandler(this.btnDownloadA12_Click);

		}
		#endregion

		#region btnAfiseaza_Click
		private void btnAfiseaza_Click(object sender, System.EventArgs e)
		{}
		#endregion

		#region btnDownloadA12_Click
		/// <summary>
		/// Realizeaza download-ul fisieruluice contine toate datele aferente declaratiei A12,
		/// necesare importului in aplicatia pentru CAS.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnDownloadA12_Click(object sender, System.EventArgs e)
		{
			// Calea catre fisierul text in care trebuie scrise informatiile.
			string caleFisierDeclaratie = Server.MapPath( "" )+"\\..\\DeclaratiiCAS\\a12.txt";
			// Calea catre fisierul XML ce contine descrierea declaratiilor.
			string caleFisierXML = Server.MapPath( "" )+@"\..\Declaratii\Declaratii.xml";

			Salaries.Business.Declaratii declaratiaA12 = new Salaries.Business.Declaratii(this.GetCurrentMonth(), this.GetAngajator(), caleFisierDeclaratie, caleFisierXML);
			
			if ( !Directory.Exists(Server.MapPath( "" )+"\\..\\DeclaratiiCAS"))
			{
				Directory.CreateDirectory(Server.MapPath( "" )+"\\..\\DeclaratiiCAS");
			}

			if ( File.Exists(caleFisierDeclaratie))
			{
				File.Delete(caleFisierDeclaratie);
			}
		
			// Este generata declaratia a11 pentru CAS.
			declaratiaA12.GenerareDeclaratieCASa12(DateTime.Parse(txtDataPlatii.Text), int.Parse(txtNrFileAnexa11.Text));

			// Se downloadeaza fisierul
			// Se sterge continutul variabile Response inainte de a fi scrise datele din raport
			Response.Clear();
			Response.ContentType = "text/plain";
			string FilePath = Server.MapPath( "" )+"\\..\\DeclaratiiCAS\\a12.txt";
			Response.AppendHeader( "content-disposition","attachment; filename="+FilePath );
			Response.WriteFile(FilePath);
			Response.End();	
		}
		#endregion
	}
}
