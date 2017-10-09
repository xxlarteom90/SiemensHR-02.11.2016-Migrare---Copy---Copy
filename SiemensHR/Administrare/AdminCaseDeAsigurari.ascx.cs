/*
 * 
 * Autor:	  Anca Holostencu
 * Data:	  12.04.2006
 * Descriere: Aceasta clasa reprezinta nomenclatorul corespunzator entitatii "CasaDeAsigurari"
 * 
 */
using System;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

using Salaries.Business;
using SiemensHR.Classes;

namespace SiemensHR.Administrare
{
	/// <summary>
	///		Summary description for AdminCaseDeAsigurari.
	/// </summary>
	public class AdminCaseDeAsigurari : System.Web.UI.UserControl
	{
		#region Variabile
		protected System.Web.UI.WebControls.ValidationSummary ValidationSummary1;
		protected System.Web.UI.WebControls.Button btnInapoi;
		protected System.Web.UI.WebControls.Button btnDelete;
		protected System.Web.UI.WebControls.Button btnModify;
		protected System.Web.UI.WebControls.Label lblMessage;
		protected System.Web.UI.WebControls.Button btnEdit;
		protected System.Web.UI.WebControls.Button btnAdd;
		protected System.Web.UI.WebControls.TextBox txtDescriere;
		protected System.Web.UI.WebControls.RequiredFieldValidator requiredDenumire;
		protected System.Web.UI.WebControls.TextBox txtDenumire;
		protected System.Web.UI.WebControls.Table headerTable;
		protected System.Web.UI.WebControls.Table mainTable;
		protected System.Web.UI.WebControls.Literal litError;
		protected System.Web.UI.HtmlControls.HtmlTableRow add_form;
		protected System.Web.UI.HtmlControls.HtmlTableCell tdTitle;
		protected System.Web.UI.HtmlControls.HtmlTableRow td_addLine;
		protected System.Web.UI.HtmlControls.HtmlTableRow td_editLine;
		protected System.Web.UI.WebControls.TextBox txtCasaDeAsigurariID;
		protected System.Web.UI.WebControls.TextBox txtCod;
		protected System.Web.UI.WebControls.RequiredFieldValidator requiredCod;
		protected System.Web.UI.WebControls.RequiredFieldValidator requiredDescriere;
		protected System.Web.UI.WebControls.RegularExpressionValidator regularCod;
		protected System.Web.UI.WebControls.RegularExpressionValidator regularDescriere;
		protected System.Web.UI.WebControls.RegularExpressionValidator regularDenumire;
		protected System.Web.UI.WebControls.TextBox txtCodificare;
		protected System.Web.UI.WebControls.RequiredFieldValidator requiredCodificare;
		protected System.Web.UI.WebControls.RegularExpressionValidator regularCodificare;
		protected System.Web.UI.HtmlControls.HtmlTableRow add_buttonLine;
		#endregion

		#region Page_Load
		/// <summary>
		/// Metoda apelata la incarcarea paginii
		/// </summary>
		/// <param name="sender">obiectul apelant</param>
		/// <param name="e">arguemntele evenimentului de incarcare a paginii</param>
		private void Page_Load(object sender, System.EventArgs e)
		{
			string script_text = "<script>var ctrlID = \"" + this.UniqueID + "\"</script>";
			Response.Write( script_text );
			Response.Write( "<script>var requiredDenumireClientID = \"" + requiredDenumire.ClientID + "\"</script>" );
			Response.Write( "<script>var requiredCodClientID = \"" + requiredCod.ClientID + "\"</script>" );
			Response.Write( "<script>var requiredDescriereClientID = \"" + requiredDescriere.ClientID + "\"</script>" );
			Response.Write( "<script>var requiredCodificareClientID = \"" + requiredCodificare.ClientID + "\"</script>" );
			Response.Write( "<script>var regularDenumireClientID = \"" + regularDenumire.ClientID + "\"</script>" );
			Response.Write( "<script>var regularCodClientID = \"" + regularCod.ClientID + "\"</script>" );
			Response.Write( "<script>var regularDescriereClientID = \"" + regularDescriere.ClientID + "\"</script>" );
			Response.Write( "<script>var regularCodificareClientID = \"" + regularCodificare.ClientID + "\"</script>" );
			
			litError.Text = "";

			btnDelete.Attributes.Add( "onclick", "return CheckDelete(' Doriti sa stergeti aceasta casa de asigurari? ')");

			SiemensHR.Classes.Utilities.CreateTableHeader( headerTable, "Date identificare casa de asigurari", "../", "small" );
			
			txtCasaDeAsigurariID.Style.Add( "display" ,"none" );
			
			if ( !IsPostBack )
			{
				ListareCaseDeAsigurari();
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

		#region ListareCaseDeAsigurari
		/// <summary>
		/// Metoda realizeaza listarea caselor de asigurari existente in baza de date
		/// </summary>
		public void ListareCaseDeAsigurari()
		{
			TableRow row = new TableRow();
			TableCell cell = new TableCell();				

			// se initializeaza randul care afiseaza titlul de la listare
			cell.CssClass = "BigBlueBold";
			cell.HorizontalAlign = HorizontalAlign.Center;
			cell.VerticalAlign = VerticalAlign.Middle;
			cell.Text = "Lista caselor de asigurari existente";
			cell.Height = new Unit( 50 );

			row.Cells.Add( cell );
			mainTable.Rows.Add( row );

			// se creeaza randul ce va contine heading-urile coloanelor din tabel
			row = new TableRow();
			cell = new TableCell();
			cell.Attributes.Add( "width", "100%" );
			cell.HorizontalAlign = HorizontalAlign.Center;
			cell.VerticalAlign = VerticalAlign.Top;			

			string[] tableHeader = { "Denumire", "Cod", "Descriere", "Codificare" };
			string[] tableCols = { "Denumire", "Cod", "Descriere", "Codificare" };
			
			Table table = new Table();
			// se creeaza tabelul care va contine lista tuturor caselor de asigurari
			ListTable listTable = new ListTable( table, new CasaDeAsigurari().GetAllCasaDeAsigurari(), tableHeader, tableCols );
			
			// se construieste lista caselor de asigurari si se adauga la tabel
			AdaugaLista( listTable );               				

			// se adauga tabelul construit anterior la randul cu titlurile coloanelor din tabel
			cell.Controls.Add( table  );
			row.Cells.Add( cell );
			mainTable.Rows.Add( row );

			td_editLine.Visible = false;
			add_form.Style.Add("display","none");
			btnEdit.Style.Add("display", "none");
			td_addLine.Visible = true;
			add_buttonLine.Visible = true;
			tdTitle.InnerText = "Adaugare casa de asigurari";

			// in cazul in care era activat mesajul de avertizare, acesta trebuie dezactivat
			if( lblMessage.Visible == true )
				lblMessage.Visible = false;
		}

		/// <summary>
		/// Obtine lista caselor de asigurari si o afiseaza in tabelul primit ca prametru.
		/// </summary>
		/// <param name="tabel">Tabelul care va contine lista caselor de asigurari</param>
		private void AdaugaLista( ListTable listTable )
		{
			// numele campurilor din DataSet-ul asociat tabelului ale caror valori trebuie transmise atunci cand se selecteaza
			// o casa de asigurare (atunci cand se da click pe un rand din tabel) cu scopul de a afisa informatiile care o
			// caracterizeaza, in pagina de modificare casa de asigurari
			string[] cellOnClickParams = { "CasaDeAsigurariID" };
			string[] cellOnClickParamsType = { "dataset" };

			// metoda javascript apelata atunci cand se selecteaza un rand din tabel
			listTable.OnclickJSMethod = "SelectLine";
			listTable.OnclickParams = cellOnClickParams;
			listTable.OnclickParamsType = cellOnClickParamsType;

			// se incearca obtinerea datelor din DataSet-ul asociat tabelului si afisarea lor
			try 
			{
				
				// se construieste tabelul ce va contine lista caselor de asigurari
				listTable.DrawListTableWithoutDigits();
			}
			catch ( Exception ex )
			{
				litError.Text = "The following error occurred: <br>";
				litError.Text += ex.Message;
			}
		}
		#endregion

		#region btnAdd_Click
		/// <summary>
		/// Adauga o casa de asigurare in baza de date, pe baza datelor completate de utilizator
		/// </summary>
		/// <param name="sender">obiectul care a apelat metoda</param>
		/// <param name="e">argumentele evenimentului de "Click"</param>
		private void btnAdd_Click( object sender, System.EventArgs e )
		{
			
			// se construieste un obiect de tip CasaDeAsigurari
			CasaDeAsigurari casaDeAsigurari = new CasaDeAsigurari();

			// se seteaza proprietatile necesare adaugarii unei noi case de asigurari
			casaDeAsigurari.Denumire= txtDenumire.Text;
			casaDeAsigurari.Cod = txtCod.Text;
			casaDeAsigurari.Descriere = txtDescriere.Text;
			casaDeAsigurari.CasaDeAsigurariID = -1;
			casaDeAsigurari.Codificare = txtCodificare.Text;
				
			try 
			{
				if(!casaDeAsigurari.VerificaExistentaCasaDeAsigurari())
				{
					casaDeAsigurari.Insert();
				}
				else
				{
					Response.Write("<script>alert('Exista o casa de asigurari cu caracteristicile casei de asigurari pe care doriti sa o introduceti!');</script>;");
				}
			}
			catch ( Exception ex )
			{
				litError.Text = "The following error occurred: <br>";
				litError.Text += ex.Message;
			}

			// se afiseaza lista caselor de asigurare completata cu inregistrarea nou introdusa
			ListareCaseDeAsigurari();
		}
		#endregion

		#region btnModify_Click
		/// <summary>
		/// Modifica datele despre o casa de asigurare in baza de date, pe baza datelor completate de utilizator
		/// </summary>
		/// <param name="sender">obiectul care a apelat metoda</param>
		/// <param name="e">argumentele evenimentului de "Click"</param>
		private void btnModify_Click( object sender, System.EventArgs e )
		{
			// se obtine id-ul casei de asigurari selectate
			int casaDeAsigurariID = int.Parse( txtCasaDeAsigurariID.Text );
			
			// se construieste un obiect de tip CasaDeAsigurari
			CasaDeAsigurari casaDeAsigurari = new CasaDeAsigurari();

			// se seteaza proprietatile necesare modificarii casei de asigurari, conform datelor continute de
			// controalele de pe interfata
			casaDeAsigurari.CasaDeAsigurariID = casaDeAsigurariID;
			casaDeAsigurari.Denumire= txtDenumire.Text;
			casaDeAsigurari.Cod = txtCod.Text;
			casaDeAsigurari.Descriere = txtDescriere.Text;
			casaDeAsigurari.Codificare = txtCodificare.Text;
				
			try 
			{
				
				if(!casaDeAsigurari.VerificaExistentaCasaDeAsigurari())
				{
					casaDeAsigurari.Update();
				}
				else
				{
					Response.Write("<script>alert('Exista o casa de asigurari cu caracteristicile casei de asigurari pe care doriti sa o introduceti!');</script>;");
				}

			}
			catch ( Exception ex )
			{
				litError.Text = "The following error occurred: <br>";
				litError.Text += ex.Message;
			}

			// se afiseaza lista caselor de asigurare completata cu inregistrarea nou introdusa
			ListareCaseDeAsigurari();
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
			// se obtine id-ul casei de asigurari selectate
			int casaDeAsigurariID = int.Parse( txtCasaDeAsigurariID.Text );
			
			try 
			{
				// se preiau din baza de date informatiile despre casa de asigurari selectata (cea care are id-ul casaDeAsigurariID)
				DataRow casaDeAsigurariDataRow = new CasaDeAsigurari().GetCasaDeAsigurariInfo( casaDeAsigurariID ).Tables[ 0 ].Rows[ 0 ];
				
				// se incarca datele obtinute in controalele de pe pagina
				txtDenumire.Text = casaDeAsigurariDataRow["Denumire" ].ToString();
				txtCod.Text = casaDeAsigurariDataRow[ "Cod" ].ToString();
				txtDescriere.Text = casaDeAsigurariDataRow[ "Descriere" ].ToString();
				txtCodificare.Text = casaDeAsigurariDataRow["Codificare"].ToString();
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
			tdTitle.InnerText = "Editare casa de asigurari";
		}
		#endregion

		#region btnDelete_Click
		/// <summary>
		/// Trateaza stergerea unei case de asigurari.
		/// </summary>
		/// <param name="sender">obiectul care a lansat evenimentul</param>
		/// <param name="e">argumentele evenimentului</param>
		private void btnDelete_Click( object sender, System.EventArgs e )
		{	
			// se obtine id-ul casei de asigurari ce se doreste a fi stearsa
			int casaDeAsigurariID = int.Parse( txtCasaDeAsigurariID.Text );
				
			// se creeaza un obiect de tip Salaries.Business.CasaDeAsigurari si i se seteaza id-ul pe cel al casei selectate
			CasaDeAsigurari casaDeAsigurari = new CasaDeAsigurari();
			casaDeAsigurari.CasaDeAsigurariID = casaDeAsigurariID;

			try
			{
				// se verifica daca se poate sterge casa de asigurari: daca nu exista angajati care au drept casa de asigurari
				// cea selectata pentru a fi stearsa
				int raspuns = casaDeAsigurari.CheckIfCasaAsigurariCanBeDeleted();
				//exista date asociate casei de asigurari
				if (raspuns == 1)
				{
					Response.Write("<script> alert('Casa de asigurari nu poate fi stearsa deoarece exista angajati asociati acesteia!'); </script>");
				}
				//casa de asigurari este ultima din lista
				if (raspuns == 2)
				{
					Response.Write("<script> alert('Operatiunea nu a fost efectuata deoarece nomenclatoul trebuie sa contina cel putin o casa de asigurari.'); </script>");
				}
				//se poate efectua stergerea
				if( raspuns == 0)
				{
					// se sterge casa de asigurari
					casaDeAsigurari.Delete();

					//sunt listate casele de asigurari
					ListareCaseDeAsigurari();
				}
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
		/// Revine la lista care contine care se asigurari
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnInapoi_Click(object sender, System.EventArgs e)
		{
			// afisarea lista caselor de asigurari
			ListareCaseDeAsigurari();
		}
		#endregion
	}
}
