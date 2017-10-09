using System;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

using SiemensHR.utils;
using SiemensHR.Classes;
using Salaries.Business;

namespace SiemensHR.Administrare
{
	/// <summary>
	///		Summary description for AdminVariabileGlobale.
	/// </summary>
	public class AdminVariabileGlobale : System.Web.UI.UserControl
	{
		#region Variabile
		protected System.Web.UI.WebControls.ValidationSummary ValidationSummary1;
		protected System.Web.UI.WebControls.Button btnInapoi;
		protected System.Web.UI.WebControls.Button btnDelete;
		protected System.Web.UI.WebControls.Button btnModify;
		protected System.Web.UI.WebControls.Label lblMessage;
		protected System.Web.UI.WebControls.Button btnEdit;
		protected System.Web.UI.WebControls.Button btnAdd;
		protected System.Web.UI.WebControls.TextBox txtDomeniuID;
		protected System.Web.UI.WebControls.TextBox txtDescriere;
		protected System.Web.UI.WebControls.RangeValidator Rangevalidator1;
		protected System.Web.UI.WebControls.TextBox txtDenumire;
		protected System.Web.UI.WebControls.RequiredFieldValidator requiredCod;
		protected System.Web.UI.WebControls.Table headerTable;
		protected System.Web.UI.WebControls.Table mainTable;
		protected System.Web.UI.WebControls.Literal litError;
		protected System.Web.UI.HtmlControls.HtmlTableRow add_form;
		protected System.Web.UI.HtmlControls.HtmlTableCell tdTitle;
		protected System.Web.UI.HtmlControls.HtmlTableRow td_addLine;
		protected System.Web.UI.HtmlControls.HtmlTableRow td_editLine;
		protected System.Web.UI.WebControls.TextBox txtTipVariabilaGlobalaID;
		protected System.Web.UI.WebControls.TextBox txtCod;
		protected System.Web.UI.WebControls.Label labelCodTipVariabilaGlobala;
		protected System.Web.UI.WebControls.RequiredFieldValidator requiredDenumire;
		protected System.Web.UI.WebControls.RegularExpressionValidator regularCod;
		protected System.Web.UI.WebControls.RegularExpressionValidator regularDenumire;
		protected System.Web.UI.HtmlControls.HtmlTableRow add_buttonLine;
		#endregion

		#region Page_Load
		private void Page_Load(object sender, System.EventArgs e)
		{
			string script_text = "<script>var ctrlID = \""+this.UniqueID+"\"</script>";
			Response.Write(script_text);
			litError.Text = "";

			btnDelete.Attributes.Add("onclick", "return CheckDelete('Doriti sa stergeti acest tip de variabila globala?')");

			Utilities.CreateTableHeader(headerTable, "Date identificare tip variabile globale", "../", "small");
			
			txtTipVariabilaGlobalaID.Style.Add("display" ,"none");

			Response.Write("<script>var requiredCod = \"" + requiredCod.ClientID + "\"</script>");
			Response.Write("<script>var requiredDenumire = \"" + requiredDenumire.ClientID + "\"</script>");
			Response.Write("<script>var regularDenumire = \"" + regularDenumire.ClientID + "\"</script>");
			Response.Write("<script>var regularCod = \"" + regularCod.ClientID + "\"</script>");
			
			if (!IsPostBack)
			{
				ListareTipuriVariabileGlobale();
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

		#region EnableSomeControls
		/// <summary>
		/// Devin vizibile anumite controale in functie de operatia executata
		/// </summary>
		/// <param name="adaugare">Tipul operatiei executate</param>
		private void EnableSomeControls( bool adaugare )
		{
			//in functie de operatia executata se anuleaza textbox-ul pentru cod si se vede numai label-ul care contine valoarea codului
			if( !adaugare )
			{
				txtCod.Visible = false;
				labelCodTipVariabilaGlobala.Visible = true;
			}
			else
			{
				txtCod.Visible = true;
				labelCodTipVariabilaGlobala.Visible = false;
			}
		}
		#endregion

		#region ListareTipuriVariabileGlobale
		/// <summary>
		/// Listare tipuri de variabile globale
		/// </summary>
		public void ListareTipuriVariabileGlobale()
		{
			try
			{
				TableRow myRow = new TableRow();
				TableCell myCell = new TableCell();
				
				//titlul de la listare
				myCell.CssClass = "BigBlueBold";
				myCell.HorizontalAlign = HorizontalAlign.Center;
				myCell.VerticalAlign = VerticalAlign.Middle;
				myCell.Text = "Lista tipurilor de variabile globale existente";
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

				string[] tableHeader = {"Cod", "Denumire", "Descriere"};
				string[] tableCols = {"Cod", "Denumire", "Descriere"};

				VariabileGlobale objVariabileGlobale = new VariabileGlobale();	
				ListTable objListTable = new ListTable(listTable, objVariabileGlobale.GetAllVariabileGloale(), tableHeader, tableCols);

				string[] ar_OnClickParam = {"VariabilaGlobalaID"};
				string[] ar_OnClickParamType = {"dataset"};

				objListTable.OnclickJSMethod = "SelectLine";
				objListTable.OnclickParams = ar_OnClickParam;
				objListTable.OnclickParamsType = ar_OnClickParamType;
				objListTable.DrawListTableWithoutDigits();                				

				myCell.Controls.Add(listTable);
				myRow.Cells.Add(myCell);
				mainTable.Rows.Add(myRow);

				td_editLine.Visible = false;
				add_form.Style.Add("display","none");
				btnEdit.Style.Add("display", "none");
				td_addLine.Visible = true;
				add_buttonLine.Visible = true;
				tdTitle.InnerText = "Adaugare tip de variabila globala nou";

				// in cazul in care era activat mesajul de avertizare, acesta trebuie dezactivat
				if( lblMessage.Visible == true )
					lblMessage.Visible = false;
	
			}
			catch (Exception ex)
			{
				litError.Text = "The following error occurred: <br>";
				litError.Text += ex.Message;
			}
		}
		#endregion

		#region btnAdd_Click
		/// <summary>
		/// Adauga un tip de variabila globala in baza de date, pe baza datelor completate de utilizator
		/// </summary>
		/// <param name="sender">obiectul care a apelat metoda</param>
		/// <param name="e">argumentele evenimentului de "Click"</param>
		private void btnAdd_Click( object sender, System.EventArgs e )
		{
			// se construieste un obiect de tip VariabileGlobale
			VariabileGlobale objVariabilaGlobala = new VariabileGlobale();

			// se seteaza proprietatile necesare adaugarii unui tip de variabila globala
			objVariabilaGlobala.Denumire= txtDenumire.Text;
			objVariabilaGlobala.Cod = txtCod.Text;
			objVariabilaGlobala.Descriere = txtDescriere.Text;
			objVariabilaGlobala.VariabilaGlobalaID = 0;
				
			try 
			{
				if (objVariabilaGlobala.CheckIfTipVariabilaGlobalaCanBeAdded())
				{
					// se incearca inserarea unui tip de variabila globala in baza de date
					objVariabilaGlobala.Insert();
				}
				else
				{
					Response.Write("<script> alert('Mai exista un tip de variabila cu aceste date!'); </script>");
				}
			}
			catch ( Exception ex )
			{
				litError.Text = "The following error occurred: <br>";
				litError.Text += ex.Message;
			}

			// se afiseaza lista tipurilor de variabila globale completata cu inregistrarea nou introdusa
			ListareTipuriVariabileGlobale();
		}
		#endregion

		#region btnModify_Click
		/// <summary>
		/// Modifica datele despre un tip de variabila globala in baza de date, pe baza datelor completate de utilizator
		/// </summary>
		/// <param name="sender">obiectul care a apelat metoda</param>
		/// <param name="e">argumentele evenimentului de "Click"</param>
		private void btnModify_Click( object sender, System.EventArgs e )
		{
			// se obtine id-ul tipului de variabila globala selectate
			int variabilaGlobalaID = int.Parse( txtTipVariabilaGlobalaID.Text );
			
			// se construieste un obiect de tip VariabileGlobale
			VariabileGlobale objVariabilaGlobala = new VariabileGlobale();

			// se seteaza proprietatile necesare modificarii casei de asigurari, conform datelor continute de
			// controalele de pe interfata
			objVariabilaGlobala.VariabilaGlobalaID = variabilaGlobalaID;
			objVariabilaGlobala.Denumire= txtDenumire.Text;
			objVariabilaGlobala.Cod = txtCod.Text;
			objVariabilaGlobala.Descriere = txtDescriere.Text;
				
			try 
			{
				if (objVariabilaGlobala.CheckIfTipVariabilaGlobalaCanBeAdded())
				{
					// se incearca modificarea tipului de variabila globala in baza de date
					objVariabilaGlobala.Update();
				}
				else
				{
					Response.Write("<script> alert('Mai exista un tip de variabila cu aceste date!'); </script>");
				}
			}
			catch ( Exception ex )
			{
				litError.Text = "The following error occurred: <br>";
				litError.Text += ex.Message;
			}

			EnableSomeControls(true);
			// se afiseaza lista tipurilor de variabile globale completata cu inregistrarea nou introdusa
			ListareTipuriVariabileGlobale();
		}
		#endregion

		#region btnEdit_Click
		/// <summary>
		/// Tratarea evenimentului de "Click" pe butonul de Edit. Se incarca in controalele de pe forma informatiile
		/// corespunzatoare casei de asigurari selectate.
		/// </summary>
		/// <param name="sender">obiectul care a apelat metoda</param>
		/// <param name="e">argumentele evenimentului</param>
		private void btnEdit_Click( object sender, System.EventArgs e )
		{           
			EnableSomeControls( false );

			// se obtine id-ul tipului de variabila globala selectate
			int variabilaGlobalaID = int.Parse( txtTipVariabilaGlobalaID.Text );
			
			try 
			{
				// se preiau din baza de date informatiile despre tipul de variabila globala selectat (cel care are id-ul variabilaGlobalaID)
				DataRow variabilaGlobalaDataRow = new VariabileGlobale().GetVariabilaGlobalaInfo( variabilaGlobalaID ).Tables[ 0 ].Rows[ 0 ];
				
				// se incarca datele obtinute in controalele de pe pagina
				txtDenumire.Text = variabilaGlobalaDataRow["Denumire" ].ToString();
				txtCod.Text = variabilaGlobalaDataRow[ "Cod" ].ToString();
				labelCodTipVariabilaGlobala.Text = variabilaGlobalaDataRow[ "Cod" ].ToString();
				txtDescriere.Text = variabilaGlobalaDataRow[ "Descriere" ].ToString();
			}
			catch ( Exception ex )
			{
				litError.Text = "The following error occurred: <br>";
				litError.Text += ex.Message;
			
			}

			td_addLine.Visible = false;
			td_editLine.Visible = true;
			add_form.Style.Add( "display", "" );
			add_buttonLine.Visible = false;
			tdTitle.InnerText = "Editare tip de variabila globala";
		}
		#endregion

		#region btnDelete_Click
		/// <summary>
		/// Trateaza stergerea unui tip de variabila globala.
		/// </summary>
		/// <param name="sender">obiectul care a lansat evenimentul</param>
		/// <param name="e">argumentele evenimentului</param>
		private void btnDelete_Click( object sender, System.EventArgs e )
		{	
			// se obtine id-ul tipului de variabila globala ce se doreste a fi stearsa
			int variabilaGlobalaID = int.Parse( txtTipVariabilaGlobalaID.Text );
							
			// se creeaza un obiect de tip Salaries.Business.VariabileGlobale si i se seteaza id-ul pe cel al tipului selectate
			VariabileGlobale objVariabilaGlobala = new VariabileGlobale();
			objVariabilaGlobala.VariabilaGlobalaID = variabilaGlobalaID;

			//se verifica daca tipul de variabila globala poate fi sters
			int sePoateSterge = objVariabilaGlobala.CheckIfTipVariabilaGlobalaCanBeDeleted();

			try
			{
				//exista valori asociate tiului de variabila
				if	(sePoateSterge == 1)
				{
					Response.Write("<script> alert('Tipul de variabila globala nu poate fi sters pentru ca exista variabile asociate acestuia!'); </script>");

				}
				//tipul de variabila este ultimul din lista
				if	(sePoateSterge == 2)
				{
					Response.Write("<script> alert('Operatiunea nu a fost efectuata deoarece nomenclatoul trebuie sa contina cel putin un tip de variabila globala.'); </script>");

				}
				// se verifica daca se poate sterge tipul de variabila globala: daca nu exista variabile de acest tip
				if	(sePoateSterge == 0)
				{
					// se sterge tipul de variabila globala
					objVariabilaGlobala.Delete();

					//sunt listate tipurile de variabile globale
					ListareTipuriVariabileGlobale();
				}
				EnableSomeControls( true );
			}
			catch( Exception ex )
			{
				litError.Text = "The following error occurred: <br>";
				litError.Text += ex.Message;
			}
		}
		#endregion

		#region btnInapoi_Click
		/// <summary>
		/// Revine la lista cu tipuri de variabile globale
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnInapoi_Click(object sender, System.EventArgs e)
		{
			EnableSomeControls(true);
			// afisarea lista tipurilor de variabile globale
			ListareTipuriVariabileGlobale();
		}
		#endregion
	}
}
