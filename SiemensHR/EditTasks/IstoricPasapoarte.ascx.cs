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
	///		Summary description for IstoricPasapoarte.
	/// </summary>
	public class IstoricPasapoarte : System.Web.UI.UserControl
	{
		#region Variabile
		protected System.Web.UI.WebControls.Literal litError;
		protected System.Web.UI.WebControls.Table tableTabs;
		protected System.Web.UI.WebControls.Table listTable;
		protected System.Web.UI.WebControls.TextBox txtPASSerie;
		protected System.Web.UI.WebControls.TextBox txtPASNumar;
		protected System.Web.UI.WebControls.TextBox txtPASEliberatDe;
		protected System.Web.UI.WebControls.TextBox txtPASDataEliberarii;
		protected System.Web.UI.WebControls.TextBox txtPASValabilPanaLa;
		protected System.Web.UI.WebControls.Button btnAdaugaDepartament;
		protected System.Web.UI.WebControls.Button btnModificaDate;
		protected System.Web.UI.WebControls.Button btnStergeDate;
		protected System.Web.UI.WebControls.ValidationSummary ValidationSummary1;
		protected System.Web.UI.HtmlControls.HtmlTableRow trActivSeparator;
		protected System.Web.UI.HtmlControls.HtmlTableRow trActiv;
		protected System.Web.UI.HtmlControls.HtmlInputCheckBox chkActiv;
		protected System.Web.UI.HtmlControls.HtmlInputHidden txtPasaportIDHidden;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator1;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator2;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator3;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator4;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator5;
		protected System.Web.UI.WebControls.RegularExpressionValidator RegularExpressionValidator1;
		protected System.Web.UI.WebControls.RegularExpressionValidator Regularexpressionvalidator2;
		protected System.Web.UI.WebControls.RegularExpressionValidator vldRegExprDescriere;

		public long AngajatID;
		#endregion

		#region Page_Load
		private void Page_Load(object sender, System.EventArgs e)
		{
			string script_text = "<script>var ctrlID = \""+this.UniqueID+"\"</script>";
			Response.Write(script_text);
		
			btnStergeDate.Attributes.Add("onclick", "return CheckDelete('Doriti sa stergeti aceasta inregistrare?')");

			string[] textTabs = {"Istoric pasapoarte", "Adauga pasaport"};
			Utilities.CreateHeaderWithTabs(tableTabs, textTabs, "", true);

			LoadIstoricPasapoarte();
		}
		#endregion

		#region LoadIstoricPasapoarte
		/// <summary>
		/// Listeaza pasapoartele unui angajat
		/// </summary>
		private void LoadIstoricPasapoarte()
		{
			try
			{
				listTable.Rows.Clear();
				listTable.Attributes.Add("width", "100%");
				listTable.Style.Add("border","1px solid #20b2aa");
				listTable.Attributes.Add("cellpadding", "0");
				listTable.Attributes.Add("cellspacing", "1");

				Salaries.Business.IstoricPasaport istPas = new Salaries.Business.IstoricPasaport();
				istPas.AngajatId = AngajatID;
				
				string[] arHeader = { "Serie", "Numar", "Emis de", "Data emiterii", "Valabil pana la", "Activ"};
				string[] arCols = { "Serie", "Numar", "EliberatDe", "DataEliberarii", "ValabilPanaLa", "Activ"};
				ListTable objListTable = new ListTable(listTable, istPas.LoadIstoricPasapoarte(), arHeader, arCols);
				objListTable.textForEmptyDataSet= "Nu exista nici un pasaport asociat acestui angajat!";

				string[] ar_OnClickParam = { AngajatID.ToString(), "PasaportID", "Serie", "Numar", "EliberatDe", "DataEliberarii", "ValabilPanaLa", "Activ" };
				string[] ar_OnClickParamType = { "const", "dataset", "dataset", "dataset", "dataset", "dataset", "dataset", "dataset" };
			
				objListTable.OnclickParams = ar_OnClickParam;
				objListTable.OnclickParamsType = ar_OnClickParamType;
				objListTable.OnclickJSMethod = "SelectPasaport";

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
			this.btnAdaugaDepartament.Click += new System.EventHandler(this.btnAdaugaPasaport_Click);
			this.btnModificaDate.Click += new System.EventHandler(this.btnModificaDate_Click);
			this.btnStergeDate.Click += new System.EventHandler(this.btnStergeDate_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region btnAdaugaPasaport_Click
		/// <summary>
		/// Adauga un pasaport
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnAdaugaPasaport_Click(object sender, System.EventArgs e)
		{
			try
			{
				Salaries.Business.IstoricPasaport istPas = new Salaries.Business.IstoricPasaport();
				istPas.PasaportId = 0;
				istPas.AngajatId = AngajatID;
				istPas.Serie = txtPASSerie.Text;
				istPas.Numar = txtPASNumar.Text;
				istPas.EliberatDe = txtPASEliberatDe.Text;
				istPas.DataEliberarii =  Utilities.ConvertText2DateTime( txtPASDataEliberarii.Text );
				istPas.ValabilPanaLa = Utilities.ConvertText2DateTime( txtPASValabilPanaLa.Text );
				istPas.Activ = chkActiv.Checked;

				if (istPas.CheckIfPasaportCanBeAdded())
				{
					istPas.InsertPasaport();
				}
				else
				{
					Response.Write("<script> alert('Pasaportul nu a fost adaugat deoarece mai exista un pasaport cu aceste date!'); </script>");
				}
			}
			catch(Exception ex)
			{
				litError.Text = "The following error occurred: <br>";
				litError.Text += ex.Message;
			}
			
			LoadIstoricPasapoarte();
		}
		#endregion

		#region btnModificaDate_Click
		/// <summary>
		/// Modifica un pasaport
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnModificaDate_Click(object sender, System.EventArgs e)
		{
			try
			{
				Salaries.Business.IstoricPasaport istPas = new Salaries.Business.IstoricPasaport();
				istPas.PasaportId = Convert.ToInt32(txtPasaportIDHidden.Value);
				istPas.AngajatId = AngajatID;
				istPas.Serie = txtPASSerie.Text;
				istPas.Numar = txtPASNumar.Text;
				istPas.EliberatDe = txtPASEliberatDe.Text;
				istPas.DataEliberarii =  Utilities.ConvertText2DateTime( txtPASDataEliberarii.Text );
				istPas.ValabilPanaLa = Utilities.ConvertText2DateTime( txtPASValabilPanaLa.Text );
				istPas.Activ = chkActiv.Checked;

				if (istPas.CheckIfPasaportCanBeAdded())
				{
					istPas.UpdatePasaport();
				}
				else
				{
					Response.Write("<script> alert('Pasaportul nu a fost modificat deoarece mai exista un pasaport cu aceste date!'); </script>");
				}
			}
			catch(Exception ex)
			{
				litError.Text = "The following error occurred: <br>";
				litError.Text += ex.Message;
			}
			
			LoadIstoricPasapoarte();
		}
		#endregion

		#region btnStergeDate_Click
		/// <summary>
		/// Sterge un pasaport
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnStergeDate_Click(object sender, System.EventArgs e)
		{
			try
			{
				Salaries.Business.IstoricPasaport istPas = new Salaries.Business.IstoricPasaport();
				istPas.PasaportId = Convert.ToInt32(txtPasaportIDHidden.Value);
				istPas.DeletePasaport();
			}
			catch(Exception ex)
			{
				litError.Text = "The following error occurred: <br>";
				litError.Text += ex.Message;
			}

			LoadIstoricPasapoarte();
		}
		#endregion
	}
}
