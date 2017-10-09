using System;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Configuration;

using SiemensHR.Classes;
using SiemensHR.utils;

namespace SiemensHR.EditTasks
{
	/// <summary>
	///		Summary description for ConturiBanca.
	/// </summary>
	/// 
	public class ConturiBanca : System.Web.UI.UserControl
	{
		#region Variabile
		protected System.Web.UI.WebControls.Literal litError;
		protected System.Web.UI.WebControls.Table listTable;
		protected System.Web.UI.WebControls.RequiredFieldValidator requiredDataStart;
		protected System.Web.UI.WebControls.ValidationSummary ValidationSummary1;
		protected System.Web.UI.WebControls.Button btnAdaugaDepartament;
		protected System.Web.UI.WebControls.Button btnModificaDate;
		protected System.Web.UI.WebControls.Button btnStergeDate;
		protected System.Web.UI.WebControls.Image imgSpace;
		protected System.Web.UI.WebControls.DropDownList lstMoneda;
		protected System.Web.UI.WebControls.DropDownList lstBanca;
		protected System.Web.UI.WebControls.TextBox txtNumarCont;
		protected System.Web.UI.WebControls.Table tableTabs;
		protected System.Web.UI.HtmlControls.HtmlInputCheckBox chkActiv;
		protected System.Web.UI.HtmlControls.HtmlTableRow trActiv;
		protected Salaries.Configuration.ModuleSettings settings;
		protected System.Web.UI.WebControls.RegularExpressionValidator regularDenumire;
		public long AngajatID;
		#endregion

		#region Page_Load
		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			string script_text = "<script>var ctrlID = \""+this.UniqueID+"\"</script>";
			Response.Write(script_text);
			LoadConturiList();

			Salaries.Business.AdminBanci banci = new Salaries.Business.AdminBanci();	
			lstBanca.DataSource = banci.GetBanci();
			lstBanca.DataValueField = "BancaID";
			lstBanca.DataTextField = "NumeBanca";
			lstBanca.DataBind();

			btnStergeDate.Attributes.Add("onclick", "return CheckDelete('Doriti sa stergeti acest cont?')");

			string[] textTabs = {"Lista conturi", "Adauga cont nou"};
			Utilities.CreateHeaderWithTabs(tableTabs, textTabs, "", true);
		}
		#endregion

		#region LoadConturiList
		/// <summary>
		/// Afiseaza lista conturilor la banci
		/// </summary>
		private void LoadConturiList()
		{
			try
			{
				listTable.Rows.Clear();
				listTable.Attributes.Add("width", "100%");
				listTable.Style.Add("border","1px solid #20b2aa");
				listTable.Attributes.Add("cellpadding", "0");
				listTable.Attributes.Add("cellspacing", "1");

				Salaries.Business.ConturiAngajat objListConturi = new Salaries.Business.ConturiAngajat();
				objListConturi.AngajatId = AngajatID;

				string[] arHeader = {"Activ","Banca","Filiala", "Cont", "Moneda"};
				string[] arCols = {"Activ","NumeBanca", "Filiala", "NumarCont", "Moneda"};
				ListTable objListTable = new ListTable(listTable, objListConturi.LoadConturiBanca(), arHeader, arCols);
				objListTable.textForEmptyDataSet= "Nu exista nici un cont asociat acestui angajat!";

				string[] ar_OnClickParam = {"Activ","ContID", "BancaID", "NumarCont", "Moneda"};
				string[] ar_OnClickParamType = {"dataset","dataset", "dataset", "dataset", "dataset"};
			
				objListTable.OnclickParams = ar_OnClickParam;
				objListTable.OnclickParamsType = ar_OnClickParamType;
				objListTable.OnclickJSMethod = "SelectCont";

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
			this.btnAdaugaDepartament.Click += new System.EventHandler(this.btnAdaugaDate_Click);
			this.btnModificaDate.Click += new System.EventHandler(this.btnModificaDate_Click);
			this.btnStergeDate.Click += new System.EventHandler(this.btnStergeDate_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region btnAdaugaDate_Click
		/// <summary>
		/// Adauga un cont
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnAdaugaDate_Click(object sender, System.EventArgs e)
		{
			try
			{
				Salaries.Business.ConturiAngajat cont = new Salaries.Business.ConturiAngajat();
				cont.AngajatId = AngajatID;
				cont.ContId = Convert.ToInt32(Request.Form["txtContID"]);
				cont.BancaId = Convert.ToInt32(lstBanca.SelectedValue);
				cont.NumarCont = txtNumarCont.Text;
				cont.Moneda = lstMoneda.SelectedValue;
				//Lungu Andreea
				if (listTable.Rows.Count>2)
					cont.Activ = chkActiv.Checked;
				else
					cont.Activ = true;

				//Lungu Andreea - 09.08.2011
				//se verifica validitatea contului IBAN
				Salaries.Business.AdminBanci banca = new Salaries.Business.AdminBanci();
				banca.LoadInfoBanca(cont.BancaId);
				string mesaj = Utilities.ValidareIBAN(cont.NumarCont, banca.Cod);
				if (mesaj.Equals(""))
				{
					if (cont.CheckIfContAngajatCanBeAdded())
					{
						cont.InsertCont();
					}
					else
					{
						Response.Write("<script> alert('Acest cont nu poate fi adaugat deoarece este deja asociat altui angajat al firmei.'); </script>");
					}
				}
				else
					Response.Write("<script> alert('" + mesaj + "'); </script>");
			}
			catch(Exception ex)
			{
				litError.Text = "The following error occurred: <br>";
				litError.Text += ex.Message;
			}
			LoadConturiList();
		}
		#endregion

		#region btnStergeDate_Click
		/// <summary>
		/// Sterge un cont
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnStergeDate_Click(object sender, System.EventArgs e)
		{
			try
			{
				Salaries.Business.ConturiAngajat cont = new Salaries.Business.ConturiAngajat();
				cont.ContId = Convert.ToInt32(Request.Form["txtContID"]);
				cont.DeleteCont();
			}
			catch(Exception ex)
			{
				litError.Text = "The following error occurred: <br>";
				litError.Text += ex.Message;
			}
			LoadConturiList();
		}
		#endregion

		#region btnModificaDate_Click
		/// <summary>
		/// Modifica un cont
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnModificaDate_Click(object sender, System.EventArgs e)
		{
			try
			{
				Salaries.Business.ConturiAngajat cont = new Salaries.Business.ConturiAngajat();
				cont.ContId = Convert.ToInt32(Request.Form["txtContID"]);
				cont.AngajatId = Convert.ToInt32(Request.Params["id"]);
				cont.BancaId = Convert.ToInt32(lstBanca.SelectedValue);
				cont.NumarCont = txtNumarCont.Text;
				cont.Moneda = lstMoneda.SelectedValue;
				cont.Activ = chkActiv.Checked;
  
				//Lungu Andreea - 09.08.2011
				//se verifica validitatea contului IBAN
				Salaries.Business.AdminBanci banca = new Salaries.Business.AdminBanci();
				banca.LoadInfoBanca(cont.BancaId);
				string mesaj = Utilities.ValidareIBAN(cont.NumarCont, banca.Cod);
				if (mesaj.Equals(""))
				{
					if (cont.CheckIfContAngajatCanBeAdded())
					{
						cont.UpdateCont();
					}
					else
					{
						Response.Write("<script> alert('Acest cont nu poate fi modificat deoarece este deja asociat unui angajat al firmei.'); </script>");
					}
				}
				else
					Response.Write("<script> alert('" + mesaj + "'); </script>");
			}
			catch(Exception ex)
			{
				litError.Text = "The following error occurred: <br>";
				litError.Text += ex.Message;
			}
			LoadConturiList();
		}
		#endregion

	}
}
