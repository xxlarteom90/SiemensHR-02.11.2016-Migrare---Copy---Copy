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
	///		Summary description for IstoricPermiseMunca.
	/// </summary>
	public class IstoricPermiseMunca : System.Web.UI.UserControl
	{
		#region Variabile
		protected System.Web.UI.WebControls.Literal litError;
		protected System.Web.UI.WebControls.Table tableTabs;
		protected System.Web.UI.WebControls.Table listTable;
		protected System.Web.UI.WebControls.Button btnAdaugaDepartament;
		protected System.Web.UI.WebControls.Button btnModificaDate;
		protected System.Web.UI.WebControls.Button btnStergeDate;
		protected System.Web.UI.WebControls.ValidationSummary ValidationSummary1;
		protected System.Web.UI.WebControls.TextBox txtSeriePermisMunca;
		protected System.Web.UI.WebControls.TextBox txtNrPermisMunca;
		protected System.Web.UI.WebControls.TextBox txtPermisMuncaDataEliberare;
		protected System.Web.UI.WebControls.TextBox txtPermisMuncaDataExpirare;
		protected System.Web.UI.HtmlControls.HtmlTableRow trActiv;
		protected System.Web.UI.HtmlControls.HtmlInputCheckBox chkActiv;
		protected System.Web.UI.HtmlControls.HtmlInputHidden txtPermisMuncaIDHidden;
		protected System.Web.UI.HtmlControls.HtmlTableRow trActivSeparator;
		protected System.Web.UI.WebControls.RequiredFieldValidator requiredSerie;
		protected System.Web.UI.WebControls.RequiredFieldValidator requiredNumar;
		protected System.Web.UI.WebControls.RequiredFieldValidator requiredDataEliberarii;
		protected System.Web.UI.WebControls.RequiredFieldValidator requiredDataExpirare;
		protected System.Web.UI.WebControls.CompareValidator vldNumar;
		protected System.Web.UI.WebControls.RegularExpressionValidator Regularexpressionvalidator2;

		public long AngajatID;
		#endregion

		#region Page_Load
		private void Page_Load(object sender, System.EventArgs e)
		{
			string script_text = "<script>var ctrlID = \""+this.UniqueID+"\"</script>";
			Response.Write(script_text);
		
			btnStergeDate.Attributes.Add("onclick", "return CheckDelete('Doriti sa stergeti aceasta inregistrare?')");

			string[] textTabs = {"Istoric permise de munca", "Adauga permis de munca"};
			Utilities.CreateHeaderWithTabs(tableTabs, textTabs, "", true);

			LoadIstoricPermiseMunca();
		}
		#endregion

		#region LoadIstoricPermiseMunca
		/// <summary>
		/// Listeaza permisele de munca
		/// </summary>
		private void LoadIstoricPermiseMunca()
		{
			try
			{
				listTable.Rows.Clear();
				listTable.Attributes.Add("width", "100%");
				listTable.Style.Add("border","1px solid #20b2aa");
				listTable.Attributes.Add("cellpadding", "0");
				listTable.Attributes.Add("cellspacing", "1");
				
				Salaries.Business.IstoricPermisMunca istPermisMunca = new Salaries.Business.IstoricPermisMunca();
				istPermisMunca.AngajatId = AngajatID;
				
				string[] arHeader = {"Serie", "Numar", "Data eliberare", "Valabil pana la", "Activ"};
				string[] arCols = {"SeriePermisMunca", "NrPermisMunca", "PermMuncaDataEliberare", "PermMuncaDataExpirare", "Activ"};
				ListTable objListTable = new ListTable(listTable, istPermisMunca.LoadIstoricPermiseMunca(), arHeader, arCols);
				objListTable.textForEmptyDataSet= "Nu exista nici un permis de munca asociat acestui angajat!";

				string[] ar_OnClickParam = { AngajatID.ToString(), "PermisMuncaID", "SeriePermisMunca", "NrPermisMunca", "PermMuncaDataEliberare", "PermMuncaDataExpirare", "Activ" };
				string[] ar_OnClickParamType = { "const", "dataset", "dataset", "dataset", "dataset", "dataset", "dataset" };
			
				objListTable.OnclickParams = ar_OnClickParam;
				objListTable.OnclickParamsType = ar_OnClickParamType;
				objListTable.OnclickJSMethod = "SelectPermisMunca";

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
			this.btnAdaugaDepartament.Click += new System.EventHandler(this.btnAdaugaPermisMunca_Click);
			this.btnModificaDate.Click += new System.EventHandler(this.btnModificaDate_Click);
			this.btnStergeDate.Click += new System.EventHandler(this.btnStergeDate_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region btnAdaugaPermisMunca_Click
		/// <summary>
		/// Adauga un permis de munca
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnAdaugaPermisMunca_Click(object sender, System.EventArgs e)
		{
			try
			{
				Salaries.Business.IstoricPermisMunca istPermis = new Salaries.Business.IstoricPermisMunca();
				istPermis.PermisMuncaId = 0;
				istPermis.AngajatId = AngajatID;
				istPermis.Serie = txtSeriePermisMunca.Text;
				istPermis.Numar = Convert.ToInt64(txtNrPermisMunca.Text);
				istPermis.DataEliberare = Utilities.ConvertText2DateTime( txtPermisMuncaDataEliberare.Text );
				istPermis.DataExpirare = Utilities.ConvertText2DateTime( txtPermisMuncaDataExpirare.Text );
				istPermis.Activ = chkActiv.Checked;

				if (istPermis.CheckIfPermisMuncaCanBeAdded())
				{
					istPermis.InsertPermisMunca();
				}
				else
				{
					Response.Write("<script> alert('Permisul de munca nu a fost adaugat deoarece mai exista un permis cu aceste date!'); </script>");
				}
			}
			catch(Exception ex)
			{
				litError.Text = "The following error occurred: <br>";
				litError.Text += ex.Message;
			}
			
			LoadIstoricPermiseMunca();
		}
		#endregion

		#region btnModificaDate_Click
		/// <summary>
		/// Modifica un permis de munca
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnModificaDate_Click(object sender, System.EventArgs e)
		{
			try
			{
				Salaries.Business.IstoricPermisMunca istPermis = new Salaries.Business.IstoricPermisMunca();
				istPermis.PermisMuncaId = Convert.ToInt32(txtPermisMuncaIDHidden.Value);
				istPermis.AngajatId = AngajatID;
				istPermis.Serie = txtSeriePermisMunca.Text;
				istPermis.Numar = Convert.ToInt64(txtNrPermisMunca.Text);
				istPermis.DataEliberare = Utilities.ConvertText2DateTime( txtPermisMuncaDataEliberare.Text );
				istPermis.DataExpirare = Utilities.ConvertText2DateTime( txtPermisMuncaDataExpirare.Text );
				istPermis.Activ = chkActiv.Checked;

				if (istPermis.CheckIfPermisMuncaCanBeAdded())
				{
					istPermis.UpdatePermisMunca();
				}
				else
				{
					Response.Write("<script> alert('Permisul de munca nu a fost modificat deoarece mai exista un permis cu aceste date!'); </script>");
				}
			}
			catch(Exception ex)
			{
				litError.Text = "The following error occurred: <br>";
				litError.Text += ex.Message;
			}
			
			LoadIstoricPermiseMunca();
		}
		#endregion

		#region btnStergeDate_Click
		/// <summary>
		/// Sterge un permis de munca
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnStergeDate_Click(object sender, System.EventArgs e)
		{
			try
			{
				Salaries.Business.IstoricPermisMunca istPermis = new Salaries.Business.IstoricPermisMunca();
				istPermis.PermisMuncaId = Convert.ToInt32(txtPermisMuncaIDHidden.Value);
				istPermis.DeletePermisMunca();
			}
			catch(Exception ex)
			{
				litError.Text = "The following error occurred: <br>";
				litError.Text += ex.Message;
			}

			LoadIstoricPermiseMunca();
		}
		#endregion
	}
}
