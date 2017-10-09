using System;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

using SiemensHR.utils;
using SiemensHR.Classes;

namespace SiemensHR.Administrare
{
	/// <summary>
	///		Summary description for AdminDomeniiDeActivitate.
	/// </summary>
	public class AdminDomeniiDeActivitate : System.Web.UI.UserControl
	{
		#region Variabile
		protected System.Web.UI.WebControls.RequiredFieldValidator requiredCod;
		protected System.Web.UI.WebControls.RegularExpressionValidator regularCod;
		protected System.Web.UI.WebControls.RequiredFieldValidator requiredDenumire;
		protected System.Web.UI.WebControls.ValidationSummary ValidationSummary1;
		protected System.Web.UI.WebControls.Literal litError;
		protected System.Web.UI.WebControls.Table mainTable;
		protected System.Web.UI.WebControls.Table headerTable;
		protected System.Web.UI.HtmlControls.HtmlTableRow add_form;
		protected System.Web.UI.HtmlControls.HtmlTableCell tdTitle;
		protected System.Web.UI.HtmlControls.HtmlTableRow td_addLine;
		protected System.Web.UI.HtmlControls.HtmlTableRow td_editLine;
		protected System.Web.UI.HtmlControls.HtmlTableRow add_buttonLine;
		protected System.Web.UI.WebControls.TextBox txtCod;
		protected System.Web.UI.WebControls.TextBox txtDenumire;
		protected System.Web.UI.WebControls.TextBox txtDescriere;
		protected System.Web.UI.WebControls.TextBox txtDomeniuID;
		protected System.Web.UI.WebControls.Button btnAdd;
		protected System.Web.UI.WebControls.Button btnEdit;
		protected System.Web.UI.WebControls.Button btnModify;
		protected System.Web.UI.WebControls.Button btnDelete;
		protected System.Web.UI.WebControls.Button btnInapoi;
		protected System.Web.UI.WebControls.RangeValidator vldProcent;
		protected System.Web.UI.WebControls.TextBox txtProcent;
		protected System.Web.UI.WebControls.RequiredFieldValidator requiredProcent;
		protected System.Web.UI.WebControls.DropDownList ddlNorma;
		protected System.Web.UI.WebControls.RegularExpressionValidator regularDenumire;
		protected System.Web.UI.WebControls.RequiredFieldValidator requiredNorma;
		protected System.Web.UI.WebControls.RadioButtonList rblContributieAccidente;
		protected System.Web.UI.WebControls.Label lblMessage;
		#endregion

		#region Page_Load
		private void Page_Load(object sender, System.EventArgs e)
		{
			string script_text = "<script>var ctrlID = \""+this.UniqueID+"\"</script>";
			Response.Write(script_text);
			litError.Text = "";

			btnDelete.Attributes.Add("onclick", "return CheckDelete('Doriti sa stergeti acest domeniu de activitate?')");

			Utilities.CreateTableHeader(headerTable, "Date identificare domeniu de activitate", "../", "small");
			
			txtDomeniuID.Style.Add("display" ,"none");

			Response.Write("<script>var requiredCod = \"" + requiredCod.ClientID + "\"</script>");
			Response.Write("<script>var regularCod = \"" + regularCod.ClientID + "\"</script>");
			Response.Write("<script>var requiredDenumire = \"" + requiredDenumire.ClientID + "\"</script>");
			Response.Write("<script>var regularDenumire = \"" + regularDenumire.ClientID + "\"</script>");
			Response.Write("<script>var requiredProcent = \"" + requiredProcent.ClientID + "\"</script>");
			Response.Write("<script>var vldProcent = \"" + vldProcent.ClientID + "\"</script>");
			Response.Write("<script>var requiredNorma = \"" + requiredNorma.ClientID + "\"</script>");

			if (!IsPostBack)
				ListareDomeniiDeActivitate();
		}
		#endregion

		#region ListareDomeniiDeActivitate
		/// <summary>
		/// Listare domenii de activitate
		/// </summary>
		public void ListareDomeniiDeActivitate()
		{
			try
			{
				TableRow myRow = new TableRow();
				TableCell myCell = new TableCell();
				
				//titlul de la listare
				myCell.CssClass = "BigBlueBold";
				myCell.HorizontalAlign = HorizontalAlign.Center;
				myCell.VerticalAlign = VerticalAlign.Middle;
				myCell.Text = "Lista domeniilor de activitate existente";
				myCell.Height = new Unit(50);
				myRow.Cells.Add(myCell);
				mainTable.Rows.Add(myRow);

				// lista de domenii de activitate existente
				myRow = new TableRow();
				myCell = new TableCell();
				myCell.Attributes.Add("width", "100%");
				myCell.HorizontalAlign = HorizontalAlign.Center;
				myCell.VerticalAlign = VerticalAlign.Top;
				Table listTable = new Table();

				string[] tableHeader = {"Cod CAEN", "Denumire","Procent", "Norma", "Descriere", "Contrib. acc. munca"};
				string[] tableCols = {"CodCAEN", "Denumire", "Procent", "Norma", "Descriere", "RetinereAccidente"};

				Salaries.Business.AdminDomeniiDeActivitate objAdminDomDeAct = new Salaries.Business.AdminDomeniiDeActivitate();	
				ListTable objListTable = new ListTable(listTable, objAdminDomDeAct.LoadInfoDomeniiDeActivitate(), tableHeader, tableCols);

				string[] ar_OnClickParam = {"DomDeActivitateID"};
				string[] ar_OnClickParamType = {"dataset"};

				objListTable.OnclickJSMethod = "SelectLine";
				objListTable.OnclickParams = ar_OnClickParam;
				objListTable.OnclickParamsType = ar_OnClickParamType;
				objListTable.DrawListTableWithDigits(4);                				

				myCell.Controls.Add(listTable);
				myRow.Cells.Add(myCell);
				mainTable.Rows.Add(myRow);

				td_editLine.Visible = false;
				add_form.Style.Add("display","none");
				btnEdit.Style.Add("display", "none");
				td_addLine.Visible = true;
				add_buttonLine.Visible = true;
				tdTitle.InnerText = "Adaugare domeniu de activitate nou";
	
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
			this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
			this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
			this.btnModify.Click += new System.EventHandler(this.btnModify_Click);
			this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
			this.btnInapoi.Click += new System.EventHandler(this.btnInapoi_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region btnAdd_Click
		/// <summary>
		/// Adauga domeniu de activitate
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnAdd_Click(object sender, System.EventArgs e)
		{
			try 
			{
				//este declarat un nou domeniu de activitate
				Salaries.Business.AdminDomeniiDeActivitate infoDomeniuDeActivitate = new Salaries.Business.AdminDomeniiDeActivitate();
				//id-ul nu este folosit efectiv
				//ii dam valoarea 0 pentruc a obiectul infoDomeniiDeActivitate sa fie complet definit
				//la inserare i se aloca domeniului un id unic 
				infoDomeniuDeActivitate.DomeniuDeActivitateId = 0;
				//denumirea domeniului
				infoDomeniuDeActivitate.Denumire = txtDenumire.Text;
				//codul CAEN al domeniului
				infoDomeniuDeActivitate.CodCAEN = Convert.ToInt32(txtCod.Text);
				//descrierea domeniului
				infoDomeniuDeActivitate.Descriere = txtDescriere.Text;
				//procentul domeniului de activitate
				infoDomeniuDeActivitate.Procent = float.Parse(txtProcent.Text);
				//norma domeniului de activitate
				infoDomeniuDeActivitate.Norma = int.Parse(ddlNorma.SelectedValue);
				//daca datoreaza sau nu contributie pt accidentele de munca
				if (rblContributieAccidente.SelectedValue == "1")
				{
					infoDomeniuDeActivitate.RetinereAccidente = true;
				}
				else
				{
					infoDomeniuDeActivitate.RetinereAccidente = false;
				}

				if (infoDomeniuDeActivitate.CheckIfDomeniuDeActivitateCanBeAdded())
				{																																												
					//este inserat in baza de date domeniul de activitate
					infoDomeniuDeActivitate.InsertDomeniuDeActivitate();
				}
				else
				{
					Response.Write("<script> alert('Mai exista un domeniu de activitate cu aceste date!'); </script>");
				}

				//afisarea domeniilor de activitate
				ListareDomeniiDeActivitate();
				
			}
			catch (Exception ex)
			{
				litError.Text = "The following error occurred: <br>";
				litError.Text += ex.Message;
			}
		}
		#endregion

		#region btnModify_Click
		/// <summary>
		/// Modifica domeniu de activitate
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnModify_Click(object sender, System.EventArgs e)
		{
			try
			{
				//id-ul domenilui de activitate care se doreste a fi modificat
				int domeniuDeActivitateId = Convert.ToInt32(txtDomeniuID.Text);

				Salaries.Business.AdminDomeniiDeActivitate infoDomeniuDeActivitate = new Salaries.Business.AdminDomeniiDeActivitate();
				//id-ul domeniului de activitate
				infoDomeniuDeActivitate.DomeniuDeActivitateId = domeniuDeActivitateId;
				//denumirea domeniului de activitate
				infoDomeniuDeActivitate.Denumire  = txtDenumire.Text;
				//codul CAEN al domeniului de activitate
				infoDomeniuDeActivitate.CodCAEN = Convert.ToInt32(txtCod.Text);
				//descrierea domeniului de activitate
				infoDomeniuDeActivitate.Descriere = txtDescriere.Text;
				//procentul aferent domeniului de activitate
				infoDomeniuDeActivitate.Procent = float.Parse(txtProcent.Text);
				//norma aferent domeniului de activitate
				infoDomeniuDeActivitate.Norma = int.Parse(ddlNorma.SelectedValue);
				//daca datoreaza sau nu contributie pt accidentele de munca
				if (rblContributieAccidente.SelectedValue == "1")
				{
					infoDomeniuDeActivitate.RetinereAccidente = true;
				}
				else
				{
					infoDomeniuDeActivitate.RetinereAccidente = false;
				}

				if (infoDomeniuDeActivitate.CheckIfDomeniuDeActivitateCanBeAdded())
				{																																												
					//se face update-ul domeniului dat ca parametru in baza de date
					infoDomeniuDeActivitate.UpdateDomeniuDeActivitate();
				}
				else
				{
					Response.Write("<script> alert('Mai exista un domeniu de activitate cu aceste date!'); </script>");
				}
			}
			catch (Exception ex)
			{
				litError.Text = "The following error occurred: <br>";
				litError.Text += ex.Message;
			}

			ListareDomeniiDeActivitate();
		}
		#endregion
		
		#region btnEdit_Click
		/// <summary>
		/// Editarea unui domeniu de activitate
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnEdit_Click(object sender, System.EventArgs e)
		{
			FillEditForm();
		}
		#endregion
		
		#region FillEditForm
		/// <summary>
		/// Sunt completate componentele in functie de id-ul domeniului	
		/// </summary>
		private void FillEditForm()
		{
			try 
			{
				//id-ul domeniului de activitate
				int domeniuDeActivitateId = Convert.ToInt32(txtDomeniuID.Text);
				
				//sunt preluate din baza de date toate detaliile legate de domeniul cu id-ul DomeniuDeActivitateID
				Salaries.Business.AdminDomeniiDeActivitate infoDomeniu = new Salaries.Business.AdminDomeniiDeActivitate();
				infoDomeniu.DomeniuDeActivitateId = domeniuDeActivitateId;
				DataRow rowDomeniu = infoDomeniu.GetDomeniuDeActivitateInfo().Tables[0].Rows[0];

				//denumirea domeniului de activitate
				txtDenumire.Text = rowDomeniu["Denumire"].ToString();
				//codul CAEN al domeniului de activitate
				txtCod.Text = rowDomeniu["CodCAEN"].ToString();
				//descrierea domeniului de activitate
				txtDescriere.Text = rowDomeniu["Descriere"].ToString();
				//id-ul domeniului de activitate
				txtDomeniuID.Text = domeniuDeActivitateId.ToString();
				//procentul aferent domeniului de activitate
				txtProcent.Text = rowDomeniu["Procent"].ToString();
				//norma domeniului de activitate
				ddlNorma.SelectedValue = int.Parse(rowDomeniu["Norma"].ToString(), System.Globalization.NumberStyles.Number).ToString();
				rblContributieAccidente.SelectedValue = ((bool) rowDomeniu["RetinereAccidente"]) ? "1" : "0";
			
				td_addLine.Visible = false;
				td_editLine.Visible = true;
				add_form.Style.Add("display","");
				add_buttonLine.Visible = false;
				tdTitle.InnerText = "Editare domeniu de activitate";			
			}
			catch (Exception ex)
			{
				litError.Text = "The following error occurred: <br>";
				litError.Text += ex.Message;
			
			}
		}
		#endregion
		
		#region btnDelete_Click
		/// <summary>
		/// Stergerea unui domeniu de activitate
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnDelete_Click(object sender, System.EventArgs e)
		{
			try
			{	
				//este preluat id-ul domeniului care se doreste a fi sters
				int domeniuDeActivitateId = Convert.ToInt32(txtDomeniuID.Text);
				Salaries.Business.AdminDomeniiDeActivitate domeniu = new Salaries.Business.AdminDomeniiDeActivitate();
				domeniu.DomeniuDeActivitateId = domeniuDeActivitateId;
				//se verifica daca domeniu de activitate poate fi sters
				int sePoateSterge = domeniu.CheckIfDomeniuDeActivitateCanBeDeleted();
				
				//exista date asociate domeniului
				if (sePoateSterge == 1)
				{
					Response.Write("<script> alert('Domeniul de activitate nu poate fi sters! Este asociat si altor angajatori!'); </script>");
					FillEditForm();
				}
				//domeniul este ultimul din lista
				if (sePoateSterge == 2)
				{
					Response.Write("<script> alert('Operatiunea nu a fost efectuata deoarece nomenclatoul trebuie sa contina cel putin un domeniu de activitate.'); </script>");
					FillEditForm();
				}
				//domeniul se poate sterge
				if (sePoateSterge == 0)
				{
					//este sters domeniul de activitate din baza de date
					domeniu.DeleteDomeniuDeActivitate();
					//sunt listate domeniile de activitate
					ListareDomeniiDeActivitate();
				}
			}
			catch (Exception ex)
			{
				litError.Text = "The following error occurred: <br>";
				litError.Text += ex.Message;
			}
		}
		#endregion
		
		#region btnInapoi_Click
		/// <summary>
		/// Revine la lista cu domenii de activitate
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnInapoi_Click(object sender, System.EventArgs e)
		{
			//afisarea domeniilor de activitate
			ListareDomeniiDeActivitate();
		}
		#endregion		
	}
}
