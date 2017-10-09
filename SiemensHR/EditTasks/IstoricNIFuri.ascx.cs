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
	///		Summary description for IstoricNIFuri.
	/// </summary>
	public class IstoricNIFuri : System.Web.UI.UserControl
	{
		#region Variabile
		protected System.Web.UI.WebControls.Literal litError;
		protected System.Web.UI.WebControls.Table tableTabs;
		protected System.Web.UI.WebControls.Table listTable;
		protected System.Web.UI.WebControls.TextBox txtNrNIF;
		protected System.Web.UI.WebControls.Button btnAdaugaDepartament;
		protected System.Web.UI.WebControls.Button btnModificaDate;
		protected System.Web.UI.WebControls.Button btnStergeDate;
		protected System.Web.UI.WebControls.ValidationSummary ValidationSummary1;
		protected System.Web.UI.HtmlControls.HtmlTableRow trActivSeparator;
		protected System.Web.UI.HtmlControls.HtmlTableRow trActiv;
		protected System.Web.UI.HtmlControls.HtmlInputCheckBox chkActiv;
		protected System.Web.UI.HtmlControls.HtmlInputHidden txtNIFIDHidden;
		protected System.Web.UI.WebControls.RegularExpressionValidator RegularExpressionValidator1;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator2;

		public long AngajatID;
		#endregion

		#region Page_Load
		private void Page_Load(object sender, System.EventArgs e)
		{
			string script_text = "<script>var ctrlID = \""+this.UniqueID+"\"</script>";
			Response.Write(script_text);
		
			btnStergeDate.Attributes.Add("onclick", "return CheckDelete('Doriti sa stergeti aceasta inregistrare?')");

			string[] textTabs = {"Istoric NIF-uri", "Adauga NIF"};
			Utilities.CreateHeaderWithTabs(tableTabs, textTabs, "", true);

			LoadIstoricNIFuri();
		}
		#endregion

		#region LoadIstoricNIFuri
		/// <summary>
		/// Listeaza NIF-urile unui angajat
		/// </summary>
		private void LoadIstoricNIFuri()
		{
			try
			{
				listTable.Rows.Clear();
				listTable.Attributes.Add("width", "100%");
				listTable.Style.Add("border","1px solid #20b2aa");
				listTable.Attributes.Add("cellpadding", "0");
				listTable.Attributes.Add("cellspacing", "1");

				Salaries.Business.IstoricNIF istNIF = new Salaries.Business.IstoricNIF();
				istNIF.AngajatId = AngajatID;
				
				string[] arHeader = { "Numar", "Activ"};
				string[] arCols = { "NIF", "Activ"};
				ListTable objListTable = new ListTable(listTable, istNIF.LoadIstoricNIFuri(), arHeader, arCols);
				objListTable.textForEmptyDataSet= "Nu exista nici un NIF asociat acestui angajat!";

				string[] ar_OnClickParam = { AngajatID.ToString(), "NIFID", "NIF", "Activ" };
				string[] ar_OnClickParamType = { "const", "dataset", "dataset", "dataset" };
			
				objListTable.OnclickParams = ar_OnClickParam;
				objListTable.OnclickParamsType = ar_OnClickParamType;
				objListTable.OnclickJSMethod = "SelectNIF";

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
			this.btnAdaugaDepartament.Click += new System.EventHandler(this.btnAdaugaNIF_Click);
			this.btnModificaDate.Click += new System.EventHandler(this.btnModificaDate_Click);
			this.btnStergeDate.Click += new System.EventHandler(this.btnStergeDate_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region btnAdaugaNIF_Click
		/// <summary>
		/// Adauga un NIF
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnAdaugaNIF_Click(object sender, System.EventArgs e)
		{
			try
			{
				Salaries.Business.IstoricNIF istNIF = new Salaries.Business.IstoricNIF();
				istNIF.NifId = 0;
				istNIF.AngajatId = AngajatID;
				istNIF.NIF = txtNrNIF.Text;
				istNIF.Activ = chkActiv.Checked;

				if( !istNIF.InsertNIF() )
				{
					Response.Write( "<script>alert( 'Adaugarea nu a fost facuta, deoarece acest NIF exista deja!' )</script>" );
				}
			}
			catch(Exception ex)
			{
				litError.Text = "The following error occurred: <br>";
				litError.Text += ex.Message;
			}
			
			LoadIstoricNIFuri();
		}
		#endregion

		#region btnModificaDate_Click
		/// <summary>
		/// Modifica un NIF
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnModificaDate_Click(object sender, System.EventArgs e)
		{
			try
			{
				Salaries.Business.IstoricNIF istNIF = new Salaries.Business.IstoricNIF();
				istNIF.NifId = Convert.ToInt32(txtNIFIDHidden.Value);
				istNIF.AngajatId = AngajatID;
				istNIF.NIF = txtNrNIF.Text;
				istNIF.Activ = chkActiv.Checked;

				if( !istNIF.UpdateNIF() )
				{
					Response.Write( "<script>alert( 'Modificarea nu a fost facuta, deoarece numarul introdus este asociat altui NIF!' )</script>" );
				}
			}
			catch(Exception ex)
			{
				litError.Text = "The following error occurred: <br>";
				litError.Text += ex.Message;
			}
			
			LoadIstoricNIFuri();
		}
		#endregion

		#region btnStergeDate_Click
		/// <summary>
		/// Sterge un NIF
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnStergeDate_Click(object sender, System.EventArgs e)
		{
			try
			{
				Salaries.Business.IstoricNIF istNIF = new Salaries.Business.IstoricNIF();
				istNIF.NifId = Convert.ToInt32(txtNIFIDHidden.Value);
				istNIF.DeleteNIF();
			}
			catch(Exception ex)
			{
				litError.Text = "The following error occurred: <br>";
				litError.Text += ex.Message;
			}

			LoadIstoricNIFuri();
		}
		#endregion
	}
}
