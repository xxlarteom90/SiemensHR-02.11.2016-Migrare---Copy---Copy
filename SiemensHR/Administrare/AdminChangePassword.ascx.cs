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
	///		Summary description for AdminChangePassword.
	/// </summary>
	public class AdminChangePassword : System.Web.UI.UserControl
	{
		#region Variabile
		protected System.Web.UI.WebControls.Button btnModifyUtilizator;
		protected System.Web.UI.WebControls.ValidationSummary vldSummary;
		protected System.Web.UI.WebControls.CompareValidator compareValParolaConfirmare;
		protected System.Web.UI.WebControls.RequiredFieldValidator requiredConfirmare;
		protected System.Web.UI.WebControls.TextBox txtConfirmareParola;
		protected System.Web.UI.WebControls.RequiredFieldValidator requiredParola;
		protected System.Web.UI.WebControls.TextBox txtParolaNoua;
		protected System.Web.UI.WebControls.RegularExpressionValidator regExpUtilizator;
		protected System.Web.UI.WebControls.RequiredFieldValidator requiredUtilizator;
		protected System.Web.UI.WebControls.TextBox txtUtilizator;
		protected System.Web.UI.WebControls.Table headerTable;
		protected System.Web.UI.WebControls.Literal litError;
		protected System.Web.UI.WebControls.RequiredFieldValidator requiredParolaVeche;
		protected System.Web.UI.WebControls.TextBox txtParolaVeche;
		private int angajatorId;
		#endregion

		#region Page_Load
		private void Page_Load(object sender, System.EventArgs e)
		{
			string script_text = "<script>var ctrlID = \""+this.UniqueID+"\"</script>";
			Response.Write(script_text);
			Response.Write("<script>var requiredUtilizatorClientID = \""+requiredUtilizator.ClientID+"\"</script>");
			Response.Write("<script>var regExpUtilizatorClientID = \""+regExpUtilizator.ClientID+"\"</script>");
			Response.Write("<script>var requiredParolaVecheClientID = \""+requiredParolaVeche.ClientID+"\"</script>");
			Response.Write("<script>var requiredParolaClientID = \""+requiredParola.ClientID+"\"</script>");
			Response.Write("<script>var requiredConfirmareClientID = \""+requiredConfirmare.ClientID+"\"</script>");
			Response.Write("<script>var compareValParolaConfirmareClientID = \""+ compareValParolaConfirmare.ClientID+"\"</script>");
			
			litError.Text = "";

			Utilities.CreateTableHeader(headerTable, "Date utilizator", "../", "small");	
			try
			{
				txtUtilizator.Text = Session["Nume"].ToString();
				angajatorId = int.Parse(Session["AngajatorID"].ToString());
			}
			catch(Exception exc)
			{
				Response.Redirect("../index.aspx");
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
			this.btnModifyUtilizator.Click += new System.EventHandler(this.btnModifyUtilizator_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region btnModifyUtilizator_Click
		// Autor: Lungu Andreea
		// Data: 02.11.2007
		/// <summary>
		/// Modifica datele unui utilizator
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnModifyUtilizator_Click(object sender, System.EventArgs e)
		{
			try
			{
				Salaries.Business.AdminUtilizatori utilizator = new Salaries.Business.AdminUtilizatori();
				if (txtParolaVeche.Text.Equals(Session["Parola"].ToString()))
				{
					utilizator.Nume = Session["Nume"].ToString();
					utilizator.Parola = Salaries.Configuration.CryptographyClass.encodeSTR(txtParolaVeche.Text);
					utilizator.UtilizatorId = utilizator.GetUtilizatorId(angajatorId);
					
					utilizator.Nume = txtUtilizator.Text;
					utilizator.Parola = Salaries.Configuration.CryptographyClass.encodeSTR(txtParolaNoua.Text);
					if(!utilizator.VerificaExistentaUtilizator())
					{
						utilizator.UpdateUtilizator();
						Session["Nume"] = utilizator.Nume;
						Session["Parola"] = txtParolaNoua.Text;

						Response.Write("<script>alert('Datele contului au fost schimbate!');</script>");
					}
					else
					{
						txtUtilizator.Text = Session["Nume"].ToString();
						Response.Write("<script>alert('Exista in baza de date un utilizator ce are aceleasi caracteristici cu cel pe care doriti sa-l introduceti!');</script>");
					}
				}
				else
				{
					Response.Write("<script>alert('Parola introdusa nu este corecta!');</script>");
				}
			}
			catch(Exception ex)
			{
				litError.Text = "The following error occurred: <br>";
				litError.Text += ex.Message;
			}
		}
		#endregion
	}
}
