using System;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Configuration;

using SiemensHR.utils;
using SiemensHR.Classes;

namespace SiemensHR.EditTasks
{
	/// <summary>
	///		Summary description for IstoricLegitimatiiSedere.
	/// </summary>
	public class IstoricLegitimatiiSedere : System.Web.UI.UserControl
	{
		#region Variabile
		protected System.Web.UI.WebControls.Literal litError;
		protected System.Web.UI.WebControls.Table tableTabs;
		protected System.Web.UI.WebControls.Table listTable;
		protected System.Web.UI.WebControls.TextBox txtSerieLegitimatieSedere;
		protected System.Web.UI.WebControls.TextBox txtNrLegitimatieSedere;
		protected System.Web.UI.WebControls.TextBox txtLegitimatieSedereDataEliberare;
		protected System.Web.UI.WebControls.TextBox txtLegitimatieSedereDataExpirare;
		protected System.Web.UI.WebControls.Button btnAdaugaDepartament;
		protected System.Web.UI.WebControls.Button btnModificaDate;
		protected System.Web.UI.WebControls.Button btnStergeDate;
		protected System.Web.UI.WebControls.ValidationSummary ValidationSummary1;
		protected System.Web.UI.HtmlControls.HtmlTableRow trActivSeparator;
		protected System.Web.UI.HtmlControls.HtmlTableRow trActiv;
		protected System.Web.UI.HtmlControls.HtmlInputCheckBox chkActiv;
		protected System.Web.UI.HtmlControls.HtmlInputHidden txtLegitimatieSedereIDHidden;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator1;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator2;
		protected System.Web.UI.WebControls.RegularExpressionValidator RegularExpressionValidator1;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator4;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator5;
		protected System.Web.UI.WebControls.RegularExpressionValidator Regularexpressionvalidator2;

		public long AngajatID;
		#endregion

		#region Page_Load
		private void Page_Load(object sender, System.EventArgs e)
		{
			string script_text = "<script>var ctrlID = \""+this.UniqueID+"\"</script>";
			Response.Write(script_text);
		
			btnStergeDate.Attributes.Add("onclick", "return CheckDelete('Doriti sa stergeti aceasta inregistrare?')");

			string[] textTabs = {"Istoric legitimatii de sedere", "Adauga legitimatie de sedere"};
			Utilities.CreateHeaderWithTabs(tableTabs, textTabs, "", true);

			LoadIstoricLegitimatiiSedere();
		}
		#endregion

		#region LoadIstoricLegitimatiiSedere
		/// <summary>
		/// Listeaza legitimatiile de sedere ale unui angajat
		/// </summary>
		private void LoadIstoricLegitimatiiSedere()
		{
			try
			{
				listTable.Rows.Clear();
				listTable.Attributes.Add("width", "100%");
				listTable.Style.Add("border","1px solid #20b2aa");
				listTable.Attributes.Add("cellpadding", "0");
				listTable.Attributes.Add("cellspacing", "1");
			
				Salaries.Business.IstoricLegitimatieSedere istLegitimatieSedere = new Salaries.Business.IstoricLegitimatieSedere();
				istLegitimatieSedere.AngajatId = AngajatID;
				
				string[] arHeader = {"Serie", "Numar", "Data eliberare", "Valabil pana la", "Activ"};
				string[] arCols = {"SerieLegitimatieSedere", "NrLegitimatieSedere", "LegitimatieSedereDataEliberare", "LegitimatieSedereDataExpirare", "Activ"};
				ListTable objListTable = new ListTable(listTable, istLegitimatieSedere.LoadIstoricLegitimatiiSedere(), arHeader, arCols);
				objListTable.textForEmptyDataSet= "Nu exista nici o legitimatie de sedere asociata acestui angajat!";

				string[] ar_OnClickParam = { AngajatID.ToString(), "LegitimatieSedereID", "SerieLegitimatieSedere", "NrLegitimatieSedere", "LegitimatieSedereDataEliberare", "LegitimatieSedereDataExpirare", "Activ" };
				string[] ar_OnClickParamType = { "const", "dataset", "dataset", "dataset", "dataset", "dataset", "dataset" };
			
				objListTable.OnclickParams = ar_OnClickParam;
				objListTable.OnclickParamsType = ar_OnClickParamType;
				objListTable.OnclickJSMethod = "SelectLegitimatieSedere";

				objListTable.DrawListTableWithoutDigits();
			}
			catch(Exception ex)
			{
				litError.Text = "The following error occurred: <br>";
				litError.Text += ex.Message;
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
			this.btnAdaugaDepartament.Click += new System.EventHandler(this.btnAdaugaLegitimatieSedere_Click);
			this.btnModificaDate.Click += new System.EventHandler(this.btnModificaDate_Click);
			this.btnStergeDate.Click += new System.EventHandler(this.btnStergeDate_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region btnAdaugaLegitimatieSedere_Click
		/// <summary>
		/// Adauga o legitimatie de sedere
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnAdaugaLegitimatieSedere_Click(object sender, System.EventArgs e)
		{
			try
			{
				Salaries.Business.IstoricLegitimatieSedere istLegitimatie = new Salaries.Business.IstoricLegitimatieSedere();
				istLegitimatie.LegitimatieSedereId = 0;
				istLegitimatie.AngajatId = AngajatID;
				istLegitimatie.SerieLegitimatieSedere = txtSerieLegitimatieSedere.Text;
				istLegitimatie.NrLegitimatieSedere = txtNrLegitimatieSedere.Text;
				istLegitimatie.LegitimatieSedereDataEliberare = Utilities.ConvertText2DateTime( txtLegitimatieSedereDataEliberare.Text );
				istLegitimatie.LegitimatieSedereDataExpirare = Utilities.ConvertText2DateTime( txtLegitimatieSedereDataExpirare.Text );
				istLegitimatie.Activ = chkActiv.Checked;

				// Modificat: Anca Holostencu
				// Descriere: In cazul in care nu s-a facut adaugarea, este afisat un mesaj
				if( !istLegitimatie.InsertLegitimatieSedere())
				{
					Response.Write( "<script>alert( 'Adaugarea nu a fost facuta, deoarece exista deja o legitimatie cu acelasi numar si aceeasi serie pentru acest angajat!' )</script>" );
				}
			}
			catch(Exception ex)
			{
				litError.Text = "The following error occurred: <br>";
				litError.Text += ex.Message;
			}
			
			LoadIstoricLegitimatiiSedere();
		}
		#endregion

		#region btnModificaDate_Click
		/// <summary>
		/// Modifica o legitimatie de sedere
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnModificaDate_Click(object sender, System.EventArgs e)
		{
			try
			{
				Salaries.Business.IstoricLegitimatieSedere istLegitimatie = new Salaries.Business.IstoricLegitimatieSedere();
				istLegitimatie.LegitimatieSedereId = Convert.ToInt32(txtLegitimatieSedereIDHidden.Value);
				istLegitimatie.AngajatId = AngajatID;
				istLegitimatie.SerieLegitimatieSedere = txtSerieLegitimatieSedere.Text;
				istLegitimatie.NrLegitimatieSedere = txtNrLegitimatieSedere.Text;
				istLegitimatie.LegitimatieSedereDataEliberare = Utilities.ConvertText2DateTime( txtLegitimatieSedereDataEliberare.Text );
				istLegitimatie.LegitimatieSedereDataExpirare = Utilities.ConvertText2DateTime( txtLegitimatieSedereDataExpirare.Text );
				istLegitimatie.Activ = chkActiv.Checked;

				if (!istLegitimatie.UpdateLegitimatieSedere())
				{
					Response.Write( "<script>alert( 'Modificarea nu a fost facuta, deoarece mai exista o legitimatie cu acelasi numar si aceeasi serie pentru acest angajat!' )</script>" );
				}
			}
			catch(Exception ex)
			{
				litError.Text = "The following error occurred: <br>";
				litError.Text += ex.Message;
			}
			
			LoadIstoricLegitimatiiSedere();
		}
		#endregion

		#region btnStergeDate_Click
		/// <summary>
		/// Sterge o legitimatie de sedere
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnStergeDate_Click(object sender, System.EventArgs e)
		{
			try
			{
				Salaries.Business.IstoricLegitimatieSedere istLegitimatie = new Salaries.Business.IstoricLegitimatieSedere();
				istLegitimatie.LegitimatieSedereId = Convert.ToInt32(txtLegitimatieSedereIDHidden.Value);
				istLegitimatie.DeleteLegitimatieSedere();
			}
			catch(Exception ex)
			{
				litError.Text = "The following error occurred: <br>";
				litError.Text += ex.Message;
			}

			LoadIstoricLegitimatiiSedere();
		}
		#endregion
	}
}
