using System;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Configuration;

using SiemensHR.utils;
using SiemensHR.Classes;
using Salaries.Business;

namespace SiemensHR.InterfataSalarii
{
	/// <summary>
	///		Summary description for Admin_CategoriiAngajati.
	/// </summary>
	public class Admin_CategoriiAngajati : SiemensHR.InterfataSalarii.Classes.BaseModule
	{
		#region Variabile
		protected System.Web.UI.WebControls.Literal litError;
		protected System.Web.UI.WebControls.Table mainTable;
		protected System.Web.UI.WebControls.Table add_header;
		protected System.Web.UI.WebControls.Button btnSalveaza;
		protected System.Web.UI.WebControls.Button btnSterge;
		protected System.Web.UI.WebControls.Button btnInapoi;
		protected System.Web.UI.WebControls.Button btnEdit;
		protected System.Web.UI.WebControls.ValidationSummary ValidationSummary1;
		protected System.Web.UI.HtmlControls.HtmlTable list_form;
		protected System.Web.UI.WebControls.Button btnAdaugaCategorie;
		protected System.Web.UI.WebControls.TextBox txtCategorieID;
		protected System.Web.UI.WebControls.Label lblError;
		protected System.Web.UI.WebControls.RequiredFieldValidator Requiredfieldvalidator1;
		protected System.Web.UI.WebControls.TextBox txtDPB;
		protected System.Web.UI.WebControls.CompareValidator Comparevalidator5;
		protected System.Web.UI.WebControls.TextBox txtDescriere;
		protected System.Web.UI.WebControls.CheckBox chkPrimesteDPB;
		protected System.Web.UI.HtmlControls.HtmlTable add_form;
		protected System.Web.UI.WebControls.CustomValidator CustomValidator1;
		protected System.Web.UI.WebControls.RegularExpressionValidator RegularExpressionValidator1;
		protected System.Web.UI.HtmlControls.HtmlTableRow DPBLine;
		protected System.Web.UI.WebControls.CheckBox chkScutireImpozit;
		protected System.Web.UI.WebControls.CheckBox chkScutireCASAngajat;
		protected System.Web.UI.WebControls.CheckBox chkScutireCASAngajator;
		protected System.Web.UI.WebControls.CheckBox chkScutireSomajAngajat;
		protected System.Web.UI.WebControls.CheckBox chkScutireSomajAngajator;
		protected System.Web.UI.WebControls.CheckBox chkScutireAsigSanAngajat;
		protected System.Web.UI.WebControls.CheckBox chkScutireAsigSanAngajator;
		protected System.Web.UI.WebControls.Label lblDenumire;

		/*
		Pentru a verifica de unde s-a facut submitul
		Daca variabila este setata pe true inseamna ca s-a facut submit chiar din aceasta pagina
		si nu trebuie incarcate categoriile in OnPreRender
		*/
		protected bool bSubmitModificare;
		#endregion

		#region Page_Load
		private void Page_Load(object sender, System.EventArgs e)
		{
			bSubmitModificare = false;

			string script_text = "<script>var ctrlID = \""+this.ClientID+"\";</script>";
			string ctrlIDDBPLine = "<script>var ctrlIDDBPLine = \""+this.DPBLine.ClientID+"\";</script>";
			string ctrlIDtxtDPB = "<script>var ctrlIDtxtDPB = \""+this.txtDPB.ClientID+"\";</script>";
			string ctrlIDchkPrimesteDPB = "<script>var ctrlIDchkPrimesteDPB = \""+this.chkPrimesteDPB.ClientID+"\";</script>";
			Response.Write(ctrlIDDBPLine);
			Response.Write(ctrlIDtxtDPB);
			Response.Write(ctrlIDchkPrimesteDPB);
			
			Response.Write(script_text);
			litError.Text = "";
			lblError.Text = "";

			btnSterge.Attributes.Add("onclick", "return CheckDelete('Doriti sa stergeti aceasta categorie?')");
			btnEdit.Style.Add("display","none");
			txtCategorieID.Style.Add("display","none");

			this.chkPrimesteDPB.Attributes["onclick"] = "PrimesteDPBChange()";

			if (!IsPostBack)
			{
				ListCategorii();
			}
		}
		#endregion
	
		#region OnPreRender
		protected override void OnPreRender(EventArgs e)
		{
			base.OnPreRender (e);
		
			/*Salaries.Business.Luni luni = new Salaries.Business.Luni(this.GetAngajator());
			Salaries.Data.LunaData lunaData = luni.GetLunaActiva();	
		
			if (lunaData.LunaId!=-1)
			{
				//bool enabled = this.GetCurrentMonth()==lunaData.LunaId;
				this.btnAdaugaCategorie.Enabled	 = enabled;
				this.btnSalveaza.Enabled = enabled;
				this.btnSterge.Enabled = enabled;
				this.add_form.Disabled = !enabled;
			}*/

			if (!bSubmitModificare)
			{
				this.ListCategorii();
			}
		}
		#endregion

		#region ListCategorii
		/// <summary>
		/// Listeaza categoriile salariale
		/// </summary>
		private void ListCategorii()
		{
			try
			{
				this.mainTable.Rows.Clear();
				
				list_form.Style.Add("display","");
				add_form.Style.Add("display","none");
				btnSalveaza.Visible = false;
				btnSterge.Visible = false;
				btnInapoi.Visible = false;
				txtCategorieID.Text = "0";

				TableRow myRow = new TableRow();
				TableCell myCell = new TableCell();
					
				//titlul de la listare
				myCell.CssClass = "BigBlueBold";
				myCell.HorizontalAlign = HorizontalAlign.Center;
				myCell.VerticalAlign = VerticalAlign.Middle;
				myCell.Text = "Lista categoriilor salariale existente";
				myCell.Height = new Unit(50);
				myRow.Cells.Add(myCell);
				mainTable.Rows.Add(myRow);

				// lista de impozite existente
				myRow = new TableRow();
				myCell = new TableCell();
				myCell.Attributes.Add("width", "100%");
				myCell.HorizontalAlign = HorizontalAlign.Center;
				myCell.VerticalAlign = VerticalAlign.Top;
				Table listTable = new Table();
			
				string[] tableHeader = {"Denumire","Descriere","DPB","Scutire Impozit","Primeste DPB"};
				string[] tableCols = {"Denumire","Descriere","DPB","ScutireImpozit","PrimesteDPB"};

				ListTable objListTable;
				if ( Session["AdminCategoriiAngajati_AddAngajat"].ToString() == "0")
				{
					objListTable = new ListTable(listTable, new Salaries.Business.CategoriiAngajat().GetCategoriiAngajat(Convert.ToInt32(Session["LunaCurenta"])), tableHeader, tableCols);
				}
				else
				{
					Salaries.Business.Luni luni = new Salaries.Business.Luni(Convert.ToInt32(Session["AngajatorID"]));
					Salaries.Data.LunaData lunaData = luni.GetLunaActiva();	
					objListTable = new ListTable(listTable, new Salaries.Business.CategoriiAngajat().GetCategoriiAngajat(lunaData.LunaId), tableHeader, tableCols);
				}

				objListTable.textForEmptyDataSet = "Nu exista nici o categorie ptr. luna selectata!";

				string[] ar_OnClickParam = {"CategorieID","Denumire","Descriere","DPB","ScutireImpozit","ScutireCASAngajat","ScutireCASAngajator","ScutireSomajAngajat","ScutireSomajAngajator","ScutireAsigSanAngajat","ScutireAsigSanAngajator","PrimesteDPB"};
				string[] ar_OnClickParamType = {"dataset","dataset","dataset","dataset","dataset","dataset","dataset","dataset","dataset","dataset","dataset","dataset"};

				objListTable.OnclickJSMethod = "SelectCategorie";
				objListTable.OnclickParams = ar_OnClickParam;
				objListTable.OnclickParamsType = ar_OnClickParamType;
				objListTable.DrawListTableWithoutDigits();                				

				myCell.Controls.Add(listTable);
				myRow.Cells.Add(myCell);
				mainTable.Rows.Add(myRow);
			}
			catch (Exception ex)
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
			this.btnAdaugaCategorie.Click += new System.EventHandler(this.btnAdaugaCategorie_Click);
			this.btnSalveaza.Click += new System.EventHandler(this.btnSalveaza_Click);
			this.btnSterge.Click += new System.EventHandler(this.btnSterge_Click);
			this.btnInapoi.Click += new System.EventHandler(this.btnInapoi_Click);
			this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region btnAdaugaCategorie_Click
		/// <summary>
		/// Adauga o categorie salarila
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnAdaugaCategorie_Click(object sender, System.EventArgs e)
		{
			bSubmitModificare = true;
		
			try
			{
				ShowAddForm();		
				CreateRefreshFunctionForAddAngajat();		
			}
			catch (Exception ex)
			{
				litError.Text = "The following error occurred: <br>";
				litError.Text += ex.Message;
			}
		}
		#endregion

		#region ShowAddForm
		/// <summary>
		/// Afiseaza controalele pentru adaugarea unei categorii salariale
		/// </summary>
		private void ShowAddForm()
		{
			list_form.Style.Add("display","none");
			add_form.Style.Add("display","");
			btnSalveaza.Visible = true;
			btnSterge.Visible = true;
			btnInapoi.Visible = true;
			btnSterge.Visible = false;
			txtDescriere.Text = "";
			chkPrimesteDPB.Checked = true;
			txtDPB.Text = "0";
			chkScutireImpozit.Checked = false;
			chkScutireCASAngajat.Checked = false;
			chkScutireCASAngajator.Checked = false;
			chkScutireSomajAngajat.Checked = false;
			chkScutireSomajAngajator.Checked = false;
			chkScutireAsigSanAngajat.Checked = false;
			chkScutireAsigSanAngajator.Checked = false;
			Utilities.CreateTableHeader(add_header, "Date identificare categorie", "../", "small");
		}
		#endregion

		#region btnInapoi_Click
		/// <summary>
		/// Revine la lista categoriilor salariale
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnInapoi_Click(object sender, System.EventArgs e)
		{
			ListCategorii();
			CreateEmptyRefreshFunctionForAddAngajat();
		}
		#endregion

		#region btnSalveaza_Click
		/// <summary>
		/// Salveaza datele unei categorii salariale
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnSalveaza_Click(object sender, System.EventArgs e)
		{
			try
			{
				Salaries.Data.CategorieData categorieData = new Salaries.Data.CategorieData();
				Salaries.Business.Luni luni = new Salaries.Business.Luni(Convert.ToInt32(Session["AngajatorID"]));
				Salaries.Data.LunaData lunaData = luni.GetLunaActiva();	
				
				categorieData.Denumire = this.lblDenumire.Text;
				categorieData.Descriere = this.txtDescriere.Text;
				categorieData.DPB =(chkPrimesteDPB.Checked) ? decimal.Parse(this.txtDPB.Text) : 0;					
				categorieData.ScturieAsigSanAngajator = this.chkScutireAsigSanAngajator.Checked;
				categorieData.ScutireAsigSanAngajat = this.chkScutireAsigSanAngajat.Checked;
				categorieData.ScutireCASAngajat = this.chkScutireCASAngajat.Checked;
				categorieData.ScutireCASAngajator = this.chkScutireCASAngajator.Checked;
				categorieData.ScutireImpozit = this.chkScutireImpozit.Checked;
				categorieData.ScutireSomajAngajat = this.chkScutireSomajAngajat.Checked;
				categorieData.ScutireSomajAngajator = this.chkScutireSomajAngajator.Checked;
				categorieData.LunaId = lunaData.LunaId;
				categorieData.CategorieId = int.Parse(txtCategorieID.Text);
				categorieData.PrimesteDPB = this.chkPrimesteDPB.Checked;

				if (new Salaries.Business.CategoriiAngajat().CheckIfCategoriiAngajatCanBeAdded(categorieData.CategorieId, categorieData.LunaId, 
					categorieData.Denumire, categorieData.Descriere, categorieData.DPB, categorieData.ScutireImpozit, categorieData.ScutireCASAngajat, 
					categorieData.ScutireCASAngajator, categorieData.ScutireSomajAngajat, categorieData.ScutireSomajAngajator, 
					categorieData.ScutireAsigSanAngajat, categorieData.ScturieAsigSanAngajator, categorieData.PrimesteDPB))
				{	
					if (txtCategorieID.Text == "0")
					{
						new Salaries.Business.CategoriiAngajat().InsertCategorie(categorieData);			
					} 
					else
					{
						new Salaries.Business.CategoriiAngajat().UpdateCategorie(categorieData);
					}
				}
				else
				{
					Response.Write("<script> alert('Mai exista o categorie cu aceste date!'); </script>");
				}
				
				ListCategorii();
				CreateRefreshFunctionForAddAngajat();
			}
			catch (Exception ex)
			{
				litError.Text = "The following error occurred x: <br>";
				litError.Text += ex.Message;
			}
		}
		#endregion

		#region btnEdit_Click
		/// <summary>
		/// Editeaza o categorie salariala
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnEdit_Click(object sender, System.EventArgs e)
		{
			bSubmitModificare = true;
			try
			{
				int CategorieID = Convert.ToInt32(txtCategorieID.Text);

				Salaries.Business.CategoriiAngajat ca = new CategoriiAngajat();
				lblDenumire.Text = ca.GetDetalii(CategorieID).Denumire;

				list_form.Style.Add("display","none");
				add_form.Style.Add("display","");
				btnSalveaza.Visible = true;
				btnSterge.Visible = false;
				btnInapoi.Visible = true;
		
				if (!this.chkPrimesteDPB.Checked)
					DPBLine.Style.Add( "display", "none" );
				else
					DPBLine.Style.Add( "display", "" );

				Utilities.CreateTableHeader(add_header, "Date identificare categorie", "../", "small");
				CreateRefreshFunctionForAddAngajat();
			}
			catch (Exception ex)
			{
				litError.Text = "The following error occurred: <br>";
				litError.Text += ex.Message;
			}
		}
		#endregion

		#region btnSterge_Click
		/// <summary>
		/// Sterge o categorie salariala
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnSterge_Click(object sender, System.EventArgs e)
		{
			try
			{
				int categorieId = Convert.ToInt32(txtCategorieID.Text);
				AdminSalariiCategoriiAngajati ca = new AdminSalariiCategoriiAngajati();
				ca.CategorieId = categorieId;

				if (ca.CheckIfCategorieAngajatiCanBeDeleted())
					ca.DeleteCategorie();
				else
				{
					lblError.Text = "Categorie nu poate fi stearsa! Este inca asociata la angajati!";
				}

			}
			catch (Exception ex)
			{
				litError.Text = "The following error occurred: <br>";
				litError.Text += ex.Message;
			}
			ListCategorii();
		}
		#endregion

		#region CreateRefreshFunctionForAddAngajat
		/// <summary>
		/// Daca pagina de administrare a fost deschisa din AddAngajat cream functia care va face refresh la combo-ul cu categorii
		/// </summary>
		private void CreateRefreshFunctionForAddAngajat()
		{
			string outStr = "";
			
			//cream scriptul care va contine functia de refresh
			//ne bazam pe faptul ca se cunoaste numele selectului care contine categorii
			//initial se sterg toate intrarile din combo
			outStr +=	"<script> \r\n function RefreshAddAngajatPage() \r\n" +
				"{ \r\n" +
				"window.opener.DeleteCategoriiCombo(); \r\n" +
				" FillCategoriiCombo(); \r\n" +
				"} \r\n";

			//acum se creeaza functie care adauga categoriile din recordset
			//se foloseste o functie din AddAngajat ... FillTitluCombo
			Salaries.Business.Luni luni = new Salaries.Business.Luni(Convert.ToInt32(Session["AngajatorID"]));
			Salaries.Data.LunaData lunaData = luni.GetLunaActiva();	
			DataSet objAdminCategoriiAngajati = new Salaries.Business.CategoriiAngajat().GetCategoriiAngajat(lunaData.LunaId);

			outStr +=	" function FillCategoriiCombo() \r\n" +
				"{ \r\n";
			foreach ( DataRow dataRow in objAdminCategoriiAngajati.Tables[0].Rows)
			{
				outStr +=	"window.opener.FillCategorieCombo('" +
					dataRow["Denumire"].ToString() + "'," +
					dataRow["CategorieID"].ToString() + ");";
			}
			
			outStr +=	"} \r\n" +
				"</script>";

			Response.Write( outStr);
		}
		#endregion

		#region CreateEmptyRefreshFunctionForAddAngajat
		/// <summary>
		/// Creeaza o functie de refresh goala pt cazul in care se incearca editare unei categorii
		/// </summary>
		private void CreateEmptyRefreshFunctionForAddAngajat()
		{
			string outStr = "";

			outStr += "<script> function RefreshAddAngajatPage() {}; </script>"
				;
			Response.Write( outStr);
		}
		#endregion
	}
}
