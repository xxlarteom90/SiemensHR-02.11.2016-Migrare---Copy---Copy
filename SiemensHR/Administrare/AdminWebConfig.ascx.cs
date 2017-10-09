using System;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

using SiemensHR.Classes;

namespace SiemensHR.Administrare
{
	/// <summary>
	///		Summary description for AdminWebConfig.
	/// </summary>
	public class AdminWebConfig : System.Web.UI.UserControl
	{
		#region Variabile
		protected System.Web.UI.WebControls.Literal litError;
		protected System.Web.UI.WebControls.Table mainTable;
		protected System.Web.UI.WebControls.Button btnAdd;
		protected System.Web.UI.WebControls.Label lblMessage;
		protected System.Web.UI.WebControls.ValidationSummary ValidationSummary1;
		protected System.Web.UI.HtmlControls.HtmlTableRow add_form;
		protected System.Web.UI.HtmlControls.HtmlTableCell tdTitle;
		protected System.Web.UI.HtmlControls.HtmlTableRow td_addLine;
		protected System.Web.UI.WebControls.Table headerTable;
		protected System.Web.UI.WebControls.RequiredFieldValidator Requiredfieldvalidator1;
		protected System.Web.UI.WebControls.RequiredFieldValidator Requiredfieldvalidator2;
		protected System.Web.UI.WebControls.RequiredFieldValidator Requiredfieldvalidator3;
		protected System.Web.UI.WebControls.TextBox txtNumeServer;
		protected System.Web.UI.WebControls.TextBox txtNumeBazaDeDate;
		protected System.Web.UI.WebControls.TextBox txtNumeUtilizator;
		protected System.Web.UI.WebControls.RequiredFieldValidator requiredUtilizator;
		protected System.Web.UI.WebControls.TextBox txtVecheaParola;
		protected System.Web.UI.WebControls.TextBox txtNouaParola;
		protected System.Web.UI.WebControls.TextBox txtConfirmareParola;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator4;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator5;
		protected System.Web.UI.WebControls.CompareValidator CompareValidator1;
		protected System.Web.UI.HtmlControls.HtmlTableCell tdVecheaParola;
		protected System.Web.UI.HtmlControls.HtmlTableCell tdNouaParola;
		protected System.Web.UI.HtmlControls.HtmlTableCell tdConfirmareNouaParola;
		protected System.Web.UI.WebControls.RegularExpressionValidator regularCod;
		protected System.Web.UI.WebControls.RegularExpressionValidator RegularExpressionValidator1;
		protected System.Web.UI.WebControls.RegularExpressionValidator RegularExpressionValidator2;
		protected System.Web.UI.HtmlControls.HtmlTableRow add_buttonLine;
		#endregion 

		#region Page_Load
		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!IsPostBack)
			{
				try
				{
					//sunt preluate datele din web.config si decodate
					txtNumeServer.Text = Salaries.Configuration.CryptographyClass.getSetting("dataSource");
					txtNumeUtilizator.Text = Salaries.Configuration.CryptographyClass.getSetting("userID");
					txtNumeBazaDeDate.Text = Salaries.Configuration.CryptographyClass.getSetting("initialCatalog");
					lblMessage.Text = "";
				}
				catch(Exception ex)
				{
					lblMessage.Text = ex.Message;
				}
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
			this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region OnPreRender
		protected override void OnPreRender(EventArgs e)
		{
			base.OnPreRender (e);

			if(IsPostBack)
			{
				try
				{
					//este preluata vechea parola din web.config
					string vecheaParola = Salaries.Configuration.CryptographyClass.getSetting("pwd");
				
					//se verifica daca parolele coincid numai daca a existat o parola veche
					if (vecheaParola != "")
					{
						//daca parola introdusa coincide cu parola actuala se face update-ul, altel se condsidera ca 
						//utilizatorul nu are acest drept
						if (vecheaParola == txtVecheaParola.Text) 
						{
							//sunt adaugate datele in web.config, inainte de a fi adaugate acestea sunt criptate
							Salaries.Configuration.CryptographyClass.writeSetting("dataSource", txtNumeServer.Text, true);
							Salaries.Configuration.CryptographyClass.writeSetting("userID", txtNumeUtilizator.Text, true);
							Salaries.Configuration.CryptographyClass.writeSetting("initialCatalog", txtNumeBazaDeDate.Text, true);
							Salaries.Configuration.CryptographyClass.writeSetting("pwd", txtNouaParola.Text, true);
							Salaries.Configuration.CryptographyClass.writeSetting("oldPwd", vecheaParola, true);
				
							//se face redirectarea catre prima pagina a aplicatiei
							Response.Redirect("index.aspx");
						}
						else
						{
							lblMessage.Text = "Parola introdusa nu coincide cu parola actuala, deci nu aveti dreptul sa modificati aceste date!";
						}
					}
					else
					{
						//sunt adaugate datele in web.config, inainte de a fi adaugate acestea sunt criptate
						Salaries.Configuration.CryptographyClass.writeSetting("dataSource", txtNumeServer.Text, true);
						Salaries.Configuration.CryptographyClass.writeSetting("userID", txtNumeUtilizator.Text, true);
						Salaries.Configuration.CryptographyClass.writeSetting("initialCatalog", txtNumeBazaDeDate.Text, true);
						Salaries.Configuration.CryptographyClass.writeSetting("pwd", txtNouaParola.Text, true);
						Salaries.Configuration.CryptographyClass.writeSetting("oldPwd", vecheaParola, true);
				
						//se face redirectarea catre prima pagina a aplicatiei
						Response.Redirect("index.aspx");
					}
				}
				catch(Exception ex)
				{
					lblMessage.Text = ex.Message;
				}
			}
		}
		#endregion

		#region btnAdd_Click
		/// <summary>
		/// Salveaza setarile pentru baza de date
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnAdd_Click(object sender, System.EventArgs e)
		{}		
		#endregion
	}
}
