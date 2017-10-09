//Autor: Cristina Muntean
//Descriere: permite lucrul cu alertele speciale legate de angajat

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
	///		Summary description for EditIstoricAlerte.
	/// </summary>
	public class EditIstoricAlerte : System.Web.UI.UserControl
	{
		#region Variabile
		protected System.Web.UI.WebControls.Literal litError;
		protected System.Web.UI.WebControls.Table tableTabs;
		protected System.Web.UI.WebControls.Table listTable;
		protected System.Web.UI.WebControls.TextBox txtDescriere;
		protected System.Web.UI.WebControls.Button btnAdaugaAlerta;
		protected System.Web.UI.WebControls.Button btnModificaDate;
		protected System.Web.UI.WebControls.Button btnStergeDate;
		protected System.Web.UI.WebControls.ValidationSummary ValidationSummary1;
		protected System.Web.UI.HtmlControls.HtmlTableRow trActivSeparator;
		protected System.Web.UI.HtmlControls.HtmlTableRow trActiv;
		protected System.Web.UI.HtmlControls.HtmlInputCheckBox chkActiv;
		protected System.Web.UI.WebControls.TextBox txtDataExpirare;
		protected System.Web.UI.WebControls.TextBox txtPerioadaCritica;
		protected System.Web.UI.HtmlControls.HtmlInputHidden txtAlertaIDHidden;
		protected System.Web.UI.WebControls.RequiredFieldValidator vldDataExpirarii;
		protected System.Web.UI.WebControls.RequiredFieldValidator vldReqNrZileDeclansare;
		protected System.Web.UI.WebControls.RangeValidator rangeVldNrZileDeclansare;
		protected System.Web.UI.WebControls.RequiredFieldValidator vldDescriere;
		protected System.Web.UI.WebControls.RegularExpressionValidator vldRegExprDescriere;

		public int AngajatID;
		#endregion

		#region Page_Load
		private void Page_Load(object sender, System.EventArgs e)
		{
			string script_text = "<script>var ctrlID = \""+this.UniqueID+"\"</script>";
			Response.Write(script_text);
					
			btnStergeDate.Attributes.Add("onclick", "return CheckDelete('Doriti sa stergeti aceasta inregistrare?')");

			string[] textTabs = {"Istoric alerte", "Adauga alerta"};
			Utilities.CreateHeaderWithTabs(tableTabs, textTabs, "", true);
		
			LoadIstoricAlerte();
		}
		#endregion
		
		#region LoadIstoricAlerte
		/// <summary>
		/// Procedura afiseaza alertele pentru un angajat
		/// </summary>
		private void LoadIstoricAlerte()
		{
			try
			{
				listTable.Rows.Clear();

				listTable.Attributes.Add("width", "100%");
				listTable.Style.Add("border","1px solid #20b2aa");
				listTable.Attributes.Add("cellpadding", "0");
				listTable.Attributes.Add("cellspacing", "1");

				Salaries.Business.IstoricAlerte istAlerte = new Salaries.Business.IstoricAlerte();
				istAlerte.AngajatId = AngajatID;
				
				string[] arHeader = { "Descriere", "Data expirare", "Interval alerta", "Activ"};
				string[] arCols = { "Descriere", "DataExpirare","PerioadaCritica", "Activ"};
				ListTable objListTable = new ListTable(listTable, istAlerte.LoadInfoAlerta(), arHeader, arCols);
				objListTable.textForEmptyDataSet= "Nu exista nici o alerta speciala asociata acestui angajat!";

				string[] ar_OnClickParam = { AngajatID.ToString(), "AlertaID", "Descriere", "DataExpirare","PerioadaCritica", "Activ" };
				string[] ar_OnClickParamType = { "const", "dataset", "dataset", "dataset", "dataset", "dataset"};
			
				objListTable.OnclickParams = ar_OnClickParam;
				objListTable.OnclickParamsType = ar_OnClickParamType;
				objListTable.OnclickJSMethod = "SelectAlerta";

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
			this.btnAdaugaAlerta.Click += new System.EventHandler(this.btnAdaugaAlerta_Click);
			this.btnModificaDate.Click += new System.EventHandler(this.btnModificaDate_Click);
			this.btnStergeDate.Click += new System.EventHandler(this.btnStergeDate_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region btnAdaugaAlerta_Click
		/// <summary>
		/// Adauga o alerta
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnAdaugaAlerta_Click(object sender, System.EventArgs e)
		{
			try
			{
				Salaries.Business.IstoricAlerte newAlerta = new Salaries.Business.IstoricAlerte();
				newAlerta.AlertaId = 0;
				newAlerta.AngajatId = AngajatID;
				newAlerta.DataExpirare = Utilities.ConvertText2DateTime(txtDataExpirare.Text);
				newAlerta.Descriere = txtDescriere.Text;
				newAlerta.PerioadaCritica = int.Parse(txtPerioadaCritica.Text);
				newAlerta.Activ = chkActiv.Checked;

				newAlerta.InsertAlerta();
			}
			catch(Exception ex)
			{
				litError.Text = "The following error occurred: <br>";
				litError.Text += ex.Message;
			}
			
			LoadIstoricAlerte();
		}
		#endregion

		#region btnModificaDate_Click
		/// <summary>
		/// Modifica o alerta
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnModificaDate_Click(object sender, System.EventArgs e)
		{
			try
			{
				Salaries.Business.IstoricAlerte newAlerta = new Salaries.Business.IstoricAlerte();
				newAlerta.AlertaId = Convert.ToInt32(txtAlertaIDHidden.Value);
				newAlerta.AngajatId = AngajatID;
				newAlerta.DataExpirare = Utilities.ConvertText2DateTime(txtDataExpirare.Text);
				newAlerta.Descriere = txtDescriere.Text;
				newAlerta.PerioadaCritica = int.Parse(txtPerioadaCritica.Text);
				newAlerta.Activ = chkActiv.Checked;

				newAlerta.UpdateAlerta();
			}
			catch(Exception ex)
			{
				litError.Text = "The following error occurred: <br>";
				litError.Text += ex.Message;
			}
			
			LoadIstoricAlerte();
		}
		#endregion

		#region btnStergeDate_Click
		/// <summary>
		/// Sterge o alerta
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnStergeDate_Click(object sender, System.EventArgs e)
		{
			try
			{
				Salaries.Business.IstoricAlerte alerta = new Salaries.Business.IstoricAlerte();
				alerta.AlertaId = Convert.ToInt32(txtAlertaIDHidden.Value);
				alerta.DeleteAlerta();
			}
			catch(Exception ex)
			{
				litError.Text = "The following error occurred: <br>";
				litError.Text += ex.Message;
			}

			LoadIstoricAlerte();
		}
		#endregion
	}
}
