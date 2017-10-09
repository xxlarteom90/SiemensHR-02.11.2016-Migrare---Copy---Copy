/*
 * Autor:     Cristina Raluca Muntean
 * Data:      17.04.2006
 * Descriere: Este generata declaratia A11 pentru casa de asigurari sociale.
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
	/// Este generata declaratia A11 pentru casa de asigurari sociale.
	/// </summary>
	public class rapoarte_DeclaratiaA11 : SiemensHR.InterfataSalarii.Classes.BaseModule
	{
		#region Variabile
		protected System.Web.UI.WebControls.Button btnDownloadA11;
		protected ReportingServices.ReportViewer raportDeclaratiaA11;
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
			
			this.raportDeclaratiaA11.ServerUrl = Salaries.Configuration.CryptographyClass.getSettingsWithoutDecode(STRING_URL);
			// Sunt setati parametrii raportului.
			// ID-ul angajatorului pentru care se genereaza declaratia.
			this.raportDeclaratiaA11.SetQueryParameter("AngajatorID",this.GetAngajator().ToString());
			// Id-ul lunii pentru care se genereaza declaratia.
			this.raportDeclaratiaA11.SetQueryParameter("LunaID",this.GetCurrentMonth().ToString());
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
			this.btnDownloadA11.Click += new System.EventHandler(this.btnDownloadA11_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region btnDownloadA11_Click
		/// <summary>
		/// Realizeaza download-ul fisieruluice contine toate datele aferente declaratiei A11,
		/// necesare importului in aplicatia pentru CAS.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnDownloadA11_Click(object sender, System.EventArgs e)
		{
			// Calea catre fisierul text in care trebuie scrise informatiile.
			string caleFisierDeclaratie = Server.MapPath( "" )+"\\..\\DeclaratiiCAS\\a11.txt";
			// Calea catre fisierul XML ce contine descrierea declaratiilor.
			string caleFisierXML = Server.MapPath( "" )+@"\..\Declaratii\Declaratii.xml";

			Salaries.Business.Declaratii declaratiaA11 = new Salaries.Business.Declaratii(this.GetCurrentMonth(), this.GetAngajator(), caleFisierDeclaratie, caleFisierXML);
			
			if ( !Directory.Exists(Server.MapPath( "" )+"\\..\\DeclaratiiCAS"))
			{
				Directory.CreateDirectory(Server.MapPath( "" )+"\\..\\DeclaratiiCAS");
			}

			if ( File.Exists(caleFisierDeclaratie))
			{
				File.Delete(caleFisierDeclaratie);
			}
		
			// Este generata declaratia a11 pentru CAS.
			declaratiaA11.GenerareDeclaratieCASa11();

			// Se downloadeaza fisierul
			// Se sterge continutul variabile Response inainte de a fi scrise datele din raport
			Response.Clear();
			Response.ContentType = "text/plain";
			string FilePath = Server.MapPath( "" )+"\\..\\DeclaratiiCAS\\a11.txt";
			Response.AppendHeader( "content-disposition","attachment; filename="+FilePath );
			Response.WriteFile(FilePath);
			Response.End();		
		}
		#endregion
	}
}
