using System;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Configuration;

using Salaries.Business;
using SiemensHR.utils;
using SiemensHR.Classes;

namespace SiemensHR.EditTasks
{
	/// <summary>
	///		Summary description for PersoaneIntretinere.
	/// </summary>
	public class PersoaneIntretinere : System.Web.UI.UserControl
	{
		#region Variabile
		protected System.Web.UI.WebControls.Literal litError;
		protected System.Web.UI.WebControls.Table tableTabs;
		protected System.Web.UI.WebControls.Table listTable;
		protected System.Web.UI.WebControls.Button btnAdaugaPersInIntretinere;
		protected System.Web.UI.WebControls.Button btnModificaPersoana;
		protected System.Web.UI.WebControls.Button btnStergePersoana;
		protected System.Web.UI.HtmlControls.HtmlTableRow trActiv;
		protected System.Web.UI.WebControls.DropDownList ddlInvaliditate;
		protected System.Web.UI.WebControls.TextBox txtNume;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredField_nume;
		protected System.Web.UI.WebControls.TextBox txtPrenume;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredField_prenume;
		protected System.Web.UI.HtmlControls.HtmlInputHidden persID;
		protected System.Web.UI.WebControls.Label lCoefTotalPersIntret;
		protected Salaries.Configuration.ModuleSettings settings;
		protected System.Web.UI.WebControls.DropDownList ddlTipPersoana;
		protected System.Web.UI.WebControls.CustomValidator customCNP;
		protected System.Web.UI.WebControls.TextBox txtCNP;
		protected System.Web.UI.WebControls.RequiredFieldValidator Requiredfieldvalidator1;
		protected System.Web.UI.WebControls.ValidationSummary ValidationSummary1;
		protected System.Web.UI.WebControls.RegularExpressionValidator RegularExpressionValidator1;
		protected System.Web.UI.WebControls.RegularExpressionValidator Regularexpressionvalidator2;
		protected System.Web.UI.HtmlControls.HtmlInputCheckBox chkActiv;
		
		public long AngajatID;
		#endregion

		#region Page_Load
		private void Page_Load(object sender, System.EventArgs e)
		{	
			string script_text = "<script>var ctrlID = \""+this.UniqueID+"\"</script>";
			Response.Write(script_text);
			LoadPersoaneList();
			
			btnStergePersoana.Attributes.Add("onclick", "return CheckDelete('Doriti sa stergeti acest cont?')");

			string[] textTabs = {"Lista persoanelor aflate in intretinere ", "Adauga persoana"};
			Utilities.CreateHeaderWithTabs(tableTabs, textTabs, "", true);		
		}
		#endregion

		#region LoadPersoaneList
		/// <summary>
		/// Listeaza persoanele in intretinere ale unui angajat
		/// </summary>
		private void LoadPersoaneList()
		{
			try
			{
				listTable.Rows.Clear();
				
				Salaries.Business.AdminInvaliditati adminInvaliditati = new Salaries.Business.AdminInvaliditati();
				ddlInvaliditate.DataSource = adminInvaliditati.LoadInfoInvaliditati();
				ddlInvaliditate.DataValueField = "InvaliditateID";
				ddlInvaliditate.DataTextField = "Nume";
				ddlInvaliditate.DataBind();

				// Adaugat: Anca Holostencu
				Salaries.Business.PersoanaInIntretinere tipuri = new PersoanaInIntretinere();
				ddlTipPersoana.DataSource = tipuri.GetAllTipuriPersoaneInIntretinere();
				ddlTipPersoana.DataValueField = "TipID";
				ddlTipPersoana.DataTextField = "TipPersoana";
				ddlTipPersoana.DataBind();

				listTable.Attributes.Add("width", "100%");
				listTable.Style.Add("border","1px solid #20b2aa");
				listTable.Attributes.Add("cellpadding", "0");
				listTable.Attributes.Add("cellspacing", "1");

				//	Modificat:	Lungu Andreea 18.03.2008 - s-a adaugat campul activ
				string[] arHeader = {"Nume","Prenume","CNP", "Tip persoana", "Invaliditate", "Activ"};
				string[] arCols = {"Nume","Prenume","CNP", "TipPersoana", "InvaliditateNume","Activ"};
			
				// Modificat: Anca Holostencu
				Salaries.Business.Angajat angajat = new Salaries.Business.Angajat();
				angajat.AngajatId = AngajatID;
				DataSet ds = angajat.GetPersoaneInIntretinere();
				
				ListTable objListTable = new ListTable(listTable, ds, arHeader, arCols);
				objListTable.textForEmptyDataSet = "Nu exista nici o persoana in intretinerea angajatului!";

				string[] ar_OnClickParam =  {"ID","Nume","Prenume","CNP", "TipID", "InvaliditateID", "Activ"};
				
				string[] ar_OnClickParamType =new string[ ar_OnClickParam.Length];
				for (int i=0;i< ar_OnClickParamType.Length;i++)
					ar_OnClickParamType[i]="dataset";
			
				objListTable.OnclickParams = ar_OnClickParam;
				objListTable.OnclickParamsType = ar_OnClickParamType;
				objListTable.OnclickJSMethod = "SelectPersoana";

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
			this.btnAdaugaPersInIntretinere.Click += new System.EventHandler(this.btnAdaugaPersInIntretinere_Click);
			this.btnModificaPersoana.Click += new System.EventHandler(this.btnModificaPersoana_Click);
			this.btnStergePersoana.Click += new System.EventHandler(this.btnStergePersoana_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region btnAdaugaPersInIntretinere_Click
		/// <summary>
		/// Adauga o persoana in intretinere
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnAdaugaPersInIntretinere_Click(object sender, System.EventArgs e)
		{
			try
			{		
				Salaries.Business.PersoanaInIntretinere pers = new Salaries.Business.PersoanaInIntretinere();
                string Nume = this.txtNume.Text;   
				string Prenume = this.txtPrenume.Text;
                long CNP = long.Parse(this.txtCNP.Text);
				// Modifcat: Anca Holostencu
				int TipID = int.Parse(ddlTipPersoana.SelectedValue);
				int InvaliditateID = int.Parse( ddlInvaliditate.SelectedValue );
				bool activ = chkActiv.Checked;

				if (pers.CheckIfPersoanaIntretinereCanBeAdded(-1, CNP))
				{
					pers.Create((int)AngajatID, Nume, Prenume, CNP, TipID, InvaliditateID, activ );
				}
				else
				{
					Response.Write( "<script>alert( 'Exista deja o persoana cu acest CNP in baza de date!' );</script>" );
				}
			}
			catch(Exception ex)
			{
				litError.Text = "The following error occurred: <br>";
				litError.Text += ex.Message;
			}
			LoadPersoaneList();
		}
		#endregion

		#region btnModificaPersoana_Click
		/// <summary>
		/// Modifica o persoana in intretinere
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnModificaPersoana_Click(object sender, System.EventArgs e)
		{
			try
			{	
				int id=int.Parse(persID.Value);
				Salaries.Business.PersoanaInIntretinere pers = new Salaries.Business.PersoanaInIntretinere(id);
				pers.Nume = this.txtNume.Text;   
				pers.Prenume = this.txtPrenume.Text;
				pers.CNP = long.Parse(this.txtCNP.Text);
				// Modificat: Anca Holostencu
				pers.TipID = short.Parse(ddlTipPersoana.SelectedValue);
				pers.InvaliditateID = int.Parse( ddlInvaliditate.SelectedValue );
				pers.Activ = chkActiv.Checked;

				if (pers.CheckIfPersoanaIntretinereCanBeAdded(id, pers.CNP))
				{
					pers.Update();	
				}
				else
				{
					Response.Write( "<script>alert( 'Exista deja o persoana cu acest CNP in baza de date!' );</script>" );
				}		
			}
			catch(Exception ex)
			{
				litError.Text = "The following error occurred: <br>";
				litError.Text += ex.Message;
			}
			LoadPersoaneList();
		}
		#endregion

		#region btnStergePersoana_Click
		/// <summary>
		/// Sterge o persoana in intretinere
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnStergePersoana_Click(object sender, System.EventArgs e)
		{
			try
			{
				int id = int.Parse(persID.Value);
				Salaries.Business.PersoanaInIntretinere pers = new Salaries.Business.PersoanaInIntretinere(id);	
				pers.Delete();			
			}
			catch(Exception ex)
			{
				litError.Text = "The following error occurred: <br>";
				litError.Text += ex.Message;
			}
			LoadPersoaneList();
		}
		#endregion
	}
}
