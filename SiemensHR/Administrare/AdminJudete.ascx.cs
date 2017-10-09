using System;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Configuration;

using SiemensHR.utils;
using SiemensHR.Classes;

namespace SiemensHR.Administrare
{
	/// <summary>
	///		Summary description for AdminJudete.
	/// </summary>
	public class AdminJudete : System.Web.UI.UserControl
	{
		#region Variabile
		protected System.Web.UI.WebControls.Literal litError;
		protected System.Web.UI.WebControls.Table mainTable;
		protected System.Web.UI.WebControls.Table headerTable;
		protected System.Web.UI.WebControls.RequiredFieldValidator requiredDenumire;
		protected System.Web.UI.WebControls.TextBox txtSimbol;
		protected System.Web.UI.WebControls.Button btnAdd;
		protected System.Web.UI.WebControls.Label lblMessage;
		protected System.Web.UI.WebControls.Button btnModify;
		protected System.Web.UI.WebControls.Button btnDelete;
		protected System.Web.UI.WebControls.Button btnInapoi;
		protected System.Web.UI.WebControls.ValidationSummary ValidationSummary1;
		protected System.Web.UI.HtmlControls.HtmlTableRow add_form;
		protected System.Web.UI.HtmlControls.HtmlTableCell tdTitle;
		protected System.Web.UI.HtmlControls.HtmlTableRow td_addLine;
		protected System.Web.UI.HtmlControls.HtmlTableRow td_editLine;
		protected System.Web.UI.WebControls.Button btnEdit;
		protected System.Web.UI.WebControls.TextBox txtJudetID;
		protected System.Web.UI.WebControls.TextBox txtNume;
		protected System.Web.UI.WebControls.DropDownList ddlTara;
		protected System.Web.UI.HtmlControls.HtmlTableRow add_buttonLine;
		protected System.Web.UI.WebControls.TextBox txtCod;
		protected System.Web.UI.WebControls.RequiredFieldValidator requiredSimbol;
		protected System.Web.UI.WebControls.RegularExpressionValidator regExprVldDenumire;
		protected System.Web.UI.WebControls.RegularExpressionValidator RegularExpressionValidator1;
		protected System.Web.UI.WebControls.DataGrid listDataGrid;
		protected Salaries.Configuration.ModuleSettings settings;

		private int Index;
		#endregion

		#region Page_Load
		private void Page_Load(object sender, System.EventArgs e)
		{
			settings = Salaries.Configuration.ModuleConfig.GetSettings();	
			string script_text = "<script>var ctrlID = \""+this.UniqueID+"\"</script>";
			Response.Write(script_text);
			litError.Text = "";

			btnDelete.Attributes.Add("onclick", "return CheckDelete('Doriti sa stergeti acest judet?')");

			Utilities.CreateTableHeader(headerTable, "Date identificare judet", "../", "small");
			
			txtJudetID.Style.Add("display" ,"none");
			
			Response.Write("<script>var requiredDenumire = \"" + requiredDenumire.ClientID + "\"</script>");
			Response.Write("<script>var requiredSimbol = \"" + requiredSimbol.ClientID + "\"</script>");
			
			if (!IsPostBack)
			{
				BindComboTara();				
				CompletareTitlu();
				PopulareTabela();
			}
		}
		#endregion

		#region BindComboTara
		/// <summary>
		/// Este populat combo care contine tarile
		/// </summary>
		private void BindComboTara()
		{
			Salaries.Business.AdminTari tari = new Salaries.Business.AdminTari();
			ddlTara.DataSource = tari.LoadInfoTari();
			ddlTara.DataTextField = "NumeTara";
			ddlTara.DataValueField = "TaraID";
			ddlTara.DataBind();
		}
		#endregion

		#region CompletareTitlu
		/// <summary>
		/// Completeaza titlul tabelului
		/// </summary>
		public void CompletareTitlu()
		{
			TableRow myRow = new TableRow();
			TableCell myCell = new TableCell();
				
			//titlul de la listare
			myCell.CssClass = "BigBlueBold";
			myCell.HorizontalAlign = HorizontalAlign.Center;
			myCell.VerticalAlign = VerticalAlign.Middle;
			myCell.Text = "Lista judetelor existente";
			myCell.Height = new Unit(50);
			myRow.Cells.Add(myCell);
			mainTable.Rows.Add(myRow);

			td_editLine.Visible = false;
			add_form.Style.Add("display","none");
			btnEdit.Style.Add("display", "none");
			td_addLine.Visible = true;
			add_buttonLine.Visible = true;
			tdTitle.InnerText = "Adaugare judet";

			listDataGrid.Visible = true;
			if(ddlTara.Items.Count >= 1)
			{
				ddlTara.SelectedIndex = 0;
			}
		}
		#endregion

		#region PopulareTabela
		/// <summary>
		/// Populeaza tabela cu judete
		/// </summary>
		public void PopulareTabela()
		{
			Index = listDataGrid.CurrentPageIndex * 30 + 1;
			Salaries.Business.AdminJudete objAdminJudete = new Salaries.Business.AdminJudete();
			listDataGrid.DataSource = objAdminJudete.LoadInfoJudete();
			listDataGrid.DataBind();
		}
		#endregion

		#region ListareJudete - COMENTATA
		/// <summary>
		/// Procedura listeaza judetele
		/// </summary>
		/*public void ListareJudete()
		{
			try
			{
				TableRow myRow = new TableRow();
				TableCell myCell = new TableCell();
				
				//titlul de la listare
				myCell.CssClass = "BigBlueBold";
				myCell.HorizontalAlign = HorizontalAlign.Center;
				myCell.VerticalAlign = VerticalAlign.Middle;
				myCell.Text = "Lista judetelor existente";
				myCell.Height = new Unit(50);
				myRow.Cells.Add(myCell);
				mainTable.Rows.Add(myRow);

				Index =1;
				AdminJudete objAdminJudete = new AdminJudete();
				listDataGrid.DataSource = objAdminJudete.getDataSet;
				listDataGrid.DataBind();

				// lista de banci existente
				/*myRow = new TableRow();
				myCell = new TableCell();
				myCell.Attributes.Add("width", "100%");
				myCell.HorizontalAlign = HorizontalAlign.Center;
				myCell.VerticalAlign = VerticalAlign.Top;
				Table listTable = new Table();

				string[] tableHeader = {"Denumire", "Simbol", "Cod", "Tara"};
				string[] tableCols = {"Nume", "Simbol", "Cod", "NumeTara"};

				AdminJudete objAdminJudete = new AdminJudete();	
				ListTable objListTable = new ListTable(listTable, objAdminJudete.getDataSet, tableHeader, tableCols);

				string[] ar_OnClickParam = {"JudetID"};
				string[] ar_OnClickParamType = {"dataset"};

				objListTable.OnclickJSMethod = "SelectLine";
				objListTable.OnclickParams = ar_OnClickParam;
				objListTable.OnclickParamsType = ar_OnClickParamType;
				objListTable.DrawListTableWithoutDigits();                				

				myCell.Controls.Add(listTable);
				myRow.Cells.Add(myCell);
				mainTable.Rows.Add(myRow);*/

				/*td_editLine.Visible = false;
				add_form.Style.Add("display","none");
				btnEdit.Style.Add("display", "none");
				td_addLine.Visible = true;
				add_buttonLine.Visible = true;
				tdTitle.InnerText = "Adaugare judet";

				listDataGrid.Visible = true;
				if(ddlTara.Items.Count >= 1)
				{
					ddlTara.SelectedIndex = 0;
				}
	
			}
			catch (Exception ex)
			{
				litError.Text = "The following error occurred: <br>";
				litError.Text += ex.Message;
			}
		}*/
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
			this.listDataGrid.ItemCreated += new System.Web.UI.WebControls.DataGridItemEventHandler(this.listDataGrid_ItemCreated);
			this.listDataGrid.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.listDataGrid_PageIndexChanged);
			this.listDataGrid.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.listDataGrid_ItemDataBound);
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
		/// Adauga un judet
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnAdd_Click(object sender, System.EventArgs e)
		{
			try 
			{
				Salaries.Business.AdminJudete newJudet = new Salaries.Business.AdminJudete();
				newJudet.TaraId = int.Parse( ddlTara.SelectedValue );
				newJudet.Nume  = txtNume.Text;
				newJudet.Simbol = txtSimbol.Text;
				newJudet.Cod = txtCod.Text;
				newJudet.JudetId = -1;
				
				if(!newJudet.VerificareExistentaJudet())
				{
					newJudet.InsertJudet();

					// Daca pagina de administrare a fost deschisa din AddAngajat cream 
					// functia care va face refresh la combo-ul cu judete
					CreateRefreshFunctionForAddAngajat();			
				}
				else
				{
					Response.Write("<script>alert('Exista in baza de date un judet cu acelesi date! Adaugarea nu a fost realizata!');</script>");
					//FillAddForm();
				}

				//ListareJudete();
				CompletareTitlu();
				PopulareTabela();
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
		/// Modifica un judet
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnModify_Click(object sender, System.EventArgs e)
		{
			try
			{
				int judetId = Convert.ToInt32(txtJudetID.Text);
				Salaries.Business.AdminJudete objJudet = new Salaries.Business.AdminJudete();

				objJudet.TaraId = int.Parse( ddlTara.SelectedValue );
				objJudet.Nume  = txtNume.Text;
				objJudet.Simbol = txtSimbol.Text;
				objJudet.Cod = txtCod.Text;
				objJudet.JudetId = judetId;
                
				if(!objJudet.VerificareExistentaJudet())
				{
					objJudet.UpdateJudet();

					// Daca pagina de administrare a fost deschisa din AddAngajat cream functia 
					// care va face refresh la combo-ul cu judete
					CreateRefreshFunctionForAddAngajat();
					
					
				}
				else
				{
					Response.Write("<script>alert('Exista in baza de date un judet cu acelesi date! Modificarea nu a fost realizata!');</script>");
					FillEditForm();
				}
			}
			catch (Exception ex)
			{
				litError.Text = "The following error occurred: <br>";
				litError.Text += ex.Message;
			}
			
			//ListareJudete();
			CompletareTitlu();
			PopulareTabela();
		}
		#endregion

		#region btnDelete_Click
		/// <summary>
		/// Sterge un judet
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnDelete_Click(object sender, System.EventArgs e)
		{
			try
			{
				int judetId = Convert.ToInt32(txtJudetID.Text);
				Salaries.Business.AdminJudete judet = new Salaries.Business.AdminJudete();
				judet.JudetId = judetId;
				int raspuns = judet.CheckIfJudetCanBeDeleted();

				if (raspuns == 2)
				{
					judet.DeleteJudet();

					// Daca pagina de administrare a fost deschisa din AddAngajat cream functia care va 
					// face refresh la combo-ul cu judete
					CreateRefreshFunctionForAddAngajat();
				}
				if (raspuns == 1)
				{
					Response.Write("<script>alert('Judetul nu poate fi sters deoarece sunt locatii asociate acestuia!');</script>");
					FillEditForm();
				}
				if (raspuns == 0)
				{
					Response.Write("<script>alert('Judetul nu poate fi sters deoarece este ultimul asociat acestei tari!');</script>");
					FillEditForm();
				}
			}
			catch (Exception ex)
			{
				litError.Text = "The following error occurred: <br>";
				litError.Text += ex.Message;
			}
			
			//ListareJudete();
			CompletareTitlu();
			PopulareTabela();
		}
		#endregion

		#region btnEdit_Click
		/// <summary>
		/// Editeaza un judet
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
		/// Completeaza campurile cu datele unui judet
		/// </summary>
		private void FillEditForm()
		{
			try 
			{
				int judetId = Convert.ToInt32(txtJudetID.Text);
				Salaries.Business.AdminJudete judet = new Salaries.Business.AdminJudete();
				judet.JudetId = judetId;
				DataRow rowJudet = judet.GetJudetInfo().Tables[0].Rows[0];

				ddlTara.SelectedValue = rowJudet["TaraId"].ToString();
				txtNume.Text = rowJudet["Nume"].ToString();
				txtSimbol.Text = rowJudet["Simbol"].ToString();
				txtCod.Text = rowJudet["Cod"].ToString();
				txtJudetID.Text = judetId.ToString();

				td_addLine.Visible = false;
				td_editLine.Visible = true;
				add_form.Style.Add("display","");
				add_buttonLine.Visible = false;
				tdTitle.InnerText = "Editare judet";
				listDataGrid.Visible = false;

				//Daca pagina de administrare a fost deschisa din AddAngajat cream functia 
				// care va face refresh la combo-ul cu judete In acest caz va fi goala ... 
				CreateEmptyRefreshFunctionForAddAngajat();
			}
			catch (Exception ex)
			{
				litError.Text = "The following error occurred: <br>";
				litError.Text += ex.Message;
			}
		}
		#endregion

		#region FillAddForm
		/// <summary>
		/// Goleste campurile pentru adaugare
		/// </summary>
		private void FillAddForm()
		{
			try 
			{
				td_addLine.Visible = false;
				td_editLine.Visible = true;
				add_form.Style.Add("display","");
				add_buttonLine.Visible = false;
				tdTitle.InnerText = "Adaugare judet";
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
		/// Revine la lista cu judete
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnInapoi_Click(object sender, System.EventArgs e)
		{
			//ListareJudete();
			CompletareTitlu();
			PopulareTabela();

			// Daca pagina de administrare a fost deschisa din AddAngajat cream functia care 
			// va face refresh la combo-ul cu judete. In acest caz va fi goala ... 
			CreateEmptyRefreshFunctionForAddAngajat();
		}
		#endregion

		#region Creare siruri necesare pt functionarea combo-urilor cu tari si judete
		/// <summary>
		/// Tarile
		/// </summary>
		/// <returns></returns>
		private string GetSirTari()
		{
			string sirTari = "";
			string sirTariText = "[";
			string sirTariValue = "[";

			Salaries.Business.AdminTari tari = new Salaries.Business.AdminTari();
			DataSet ds = tari.LoadInfoTari();
			for( int i=0; i<ds.Tables[ 0 ].Rows.Count-1; i++ )
			{
				DataRow dr = ds.Tables[ 0 ].Rows[ i ];
				sirTariText += "'"+dr[ "NumeTara" ].ToString()+"', ";
				sirTariValue += dr[ "TaraID" ].ToString()+", ";
			}
			if( ds.Tables[ 0 ].Rows.Count > 0 )
			{
				sirTariText += "'"+ds.Tables[ 0 ].Rows[ ds.Tables[ 0 ].Rows.Count-1 ][ "NumeTara" ].ToString()+"']";
				sirTariValue += ds.Tables[ 0 ].Rows[ ds.Tables[ 0 ].Rows.Count-1 ][ "TaraID" ].ToString()+"]";
			
				sirTari = "["+sirTariText+","+sirTariValue+"]";
			}
			else
			{
				sirTari = "[[],[]]";
			}

			return sirTari;
		}

		/// <summary>
		/// Judetele
		/// </summary>
		/// <returns></returns>
		private string GetSirJudeteText()
		{
			string sirJudText = "";
			string sirJudTextFinal = "";

			Salaries.Business.AdminTari tari = new Salaries.Business.AdminTari();
			DataSet dsTari = tari.LoadInfoTari();
			foreach( DataRow drTari in dsTari.Tables[ 0 ].Rows )
			{
				Salaries.Business.AdminJudete judete = new Salaries.Business.AdminJudete();
				judete.TaraId = int.Parse(drTari[ "TaraID" ].ToString());
				DataSet ds = judete.GetAllJudeteTara();
				if( ds.Tables[ 0 ].Rows. Count > 0 )
				{
					sirJudText = "[";

					for( int i=0; i<ds.Tables[ 0 ].Rows.Count-1; i++ )
					{
						DataRow dr = ds.Tables[ 0 ].Rows[ i ];
						sirJudText += "'"+dr[ "NumeCompus" ].ToString()+"', ";
					}
					sirJudText += "'"+ds.Tables[ 0 ].Rows[ ds.Tables[ 0 ].Rows.Count-1 ][ "NumeCompus" ].ToString()+"']";
				}
				else
				{
					sirJudText = "[]";
				}
				sirJudTextFinal += sirJudText+", ";
			}
			if( sirJudTextFinal == "" )
			{
				sirJudTextFinal += "[[]]";
			}
			else
			{
				sirJudTextFinal = sirJudTextFinal.Substring( 0, sirJudTextFinal.Length-2 );
				sirJudTextFinal = "["+sirJudTextFinal+"]";
			}

			return sirJudTextFinal;
		}

		/// <summary>
		/// Valorile judetelor
		/// </summary>
		/// <returns></returns>
		private string GetSirJudeteValue()
		{
			string sirJudVal = "";
			string sirJudValFinal = "";

			Salaries.Business.AdminTari tari = new Salaries.Business.AdminTari();
			DataSet dsTari = tari.LoadInfoTari();
			foreach( DataRow drTari in dsTari.Tables[ 0 ].Rows )
			{
				Salaries.Business.AdminJudete judete = new Salaries.Business.AdminJudete();
				judete.TaraId = int.Parse(drTari[ "TaraID" ].ToString());
				DataSet ds = judete.GetAllJudeteTara();
				if( ds.Tables[ 0 ].Rows.Count > 0 )
				{
					sirJudVal = "[";

					for( int i=0; i<ds.Tables[ 0 ].Rows.Count-1; i++ )
					{
						DataRow dr = ds.Tables[ 0 ].Rows[ i ];
						sirJudVal += dr[ "JudetID" ].ToString()+", ";
					}
					sirJudVal += ds.Tables[ 0 ].Rows[ ds.Tables[ 0 ].Rows.Count-1 ][ "JudetID" ].ToString()+"]";
				}
				else
				{
					sirJudVal = "[]";
				}
			
				//sirTari = "["+sirTariText+","+sirTariValue+"]";
				sirJudValFinal += sirJudVal+", ";
			}
			if( sirJudValFinal == "" )
			{
				sirJudValFinal += "[[]]";
			}
			else
			{
				sirJudValFinal = sirJudValFinal.Substring( 0, sirJudValFinal.Length-2 );
				sirJudValFinal = "["+sirJudValFinal+"]";
			}

			return sirJudValFinal;
		}

		#endregion

		#region CreateRefreshFunctionForAddAngajat
		/// <summary>
		/// Daca pagina de administrare a fost deschisa din AddAngajat cream functia 
		/// care va face refresh la combo-ul cu judete
		/// </summary>
		private void CreateRefreshFunctionForAddAngajat()
		{
			string outStr = "";
			
			//tb resetate sirurile cu tari si judete din AddAngajat din cauza actualizarii tarilor
			string sirTari = GetSirTari();
			string sirJudeteText = GetSirJudeteText();
			string sirJudeteValue = GetSirJudeteValue();
			Response.Write( "<script>var tari1 = "+sirTari+";</script>");
			Response.Write( "<script>var judeteText1 = "+sirJudeteText+";</script>" );
			Response.Write( "<script>var judeteValue1 = "+sirJudeteValue+";</script>" );

			//cream scriptul care va contine functia de refresh
			//ne bazam pe faptul ca se cunoaste numele selectului care contine judetele
			//initial se sterg toate intrarile din combo
			outStr +=	"<script> \r\n function RefreshAddAngajatPage() \r\n" +
				"{ \r\n" +

				"window.opener.RecreateArray_TariJudete('judeteText',judeteText1.length); \r\n" +
				"for(i=0;i<judeteText1.length;i++) \r\n" +
				"	window.opener.RecreateLine_TariJudete( 'judeteText' ,i, judeteText1[i].length); \r\n" +
				"for(i=0;i<judeteText1.length;i++) \r\n"+
				"{ \r\n" +
				"	if ( judeteText1[i].length == 0)  \r\n" +
				"		window.opener.SetJudeteText( i, 0, null); \r\n" +
				"	else \r\n" +
				"		for(j=0;j<judeteText1[i].length;j++) \r\n"+
				"			window.opener.SetJudeteText( i, j, judeteText1[i][j]); \r\n" +
				"} \r\n" +

				"window.opener.RecreateArray_TariJudete('judeteValue',judeteValue1.length); \r\n" +
				"for(i=0;i<judeteValue1.length;i++) \r\n" +
				"	window.opener.RecreateLine_TariJudete( 'judeteValue' ,i, judeteValue1[i].length); \r\n" +
				"for(i=0;i<judeteValue1.length;i++) \r\n"+
				"for(j=0;j<judeteValue1[i].length;j++) \r\n"+
				"window.opener.SetJudeteValue( i, j, judeteValue1[i][j]); \r\n" +

				"window.opener.DeleteJudeteCombo(); \r\n" +
				" FillJudeteCOmbo(); \r\n" +
				"} \r\n";

			//acum se creeaza functie care adauga judetele din recordset
			//se foloseste o functie din AddAngajat ... FillJudetCombo
			Salaries.Business.AdminJudete objAdminJudete = new Salaries.Business.AdminJudete();	
			
			outStr +=	" function FillJudeteCOmbo() \r\n" +
				"{ \r\n";
			foreach ( DataRow dataRow in objAdminJudete.LoadInfoJudete().Tables[0].Rows)
			{
				outStr +=	"window.opener.FillJudetCombo('" +
					dataRow["Nume"].ToString() + "'," +
					dataRow["JudetID"].ToString() + ");";
			}
			
			outStr += " window.opener.SyncronizeTaraJudete(); \r\n";

			outStr +=	"} \r\n" +
				"</script>";

			Response.Write( outStr);
		}
		#endregion

		#region CreateEmptyRefreshFunctionForAddAngajat
		/// <summary>
		/// Creeaza o functie de refresh goala pt cazul in care se incearca editare unui judet
		/// </summary>
		private void CreateEmptyRefreshFunctionForAddAngajat()
		{
			string outStr = "";

			outStr += "<script> function RefreshAddAngajatPage() {}; </script>";
			Response.Write( outStr);
		}
		#endregion

		#region listDataGrid_ItemDataBound
		/// <summary>
		/// Creaza lista cu judete
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		public void listDataGrid_ItemDataBound(object sender, DataGridItemEventArgs e)
		{
			if (e.Item.ItemIndex!=-1)  // daca e header nu pune evenimentele
			{
				TableCell myCell = new TableCell();
				myCell.Text = Index.ToString();
				myCell.Attributes.Add("align","center");
				e.Item.Cells.AddAt(0, myCell);
				for(int j=0; j<e.Item.Cells.Count; j++)
					e.Item.Cells[j].Attributes.Add("class","UnderlineNormalBlack");
				Index++;
				e.Item.Attributes.Add("onmouseover", "MouseOverTableLine(this)");
				e.Item.Attributes.Add("onmouseout", "MouseOutTableLine(this)");
				e.Item.Attributes.Add("onclick", "SelectLine(" + e.Item.Cells[1].Text  + ")");

				e.Item.Cells[1].Style.Add("display", "none");
			}
			else
			{
				TableCell myCellHeader = new TableCell();
				myCellHeader.Text = "Nr. crt";
				e.Item.Cells.AddAt(0, myCellHeader);
				for (int i=1; i<e.Item.Cells.Count ; i++)
				{
					// ascund prima coloana.. care este id angajat
					if (i==1)
						e.Item.Cells[i].Style.Add("display", "none");
					if(e.Item.Cells[i].Controls.Count>0)
					{
						// setez clasa de CSS ptr. header de table + evenimente client
						LinkButton linkbtn = (LinkButton) e.Item.Cells[i].Controls[0];
						linkbtn.CssClass = "SortStyle";
						linkbtn.Attributes.Add("onmouseover","MouseOverSortHeader(this)");
						linkbtn.Attributes.Add("onmouseout","MouseOutSortHeader(this)");
					}
				}
			}
		}
		#endregion

		#region listDataGrid_PageIndexChanged
		/// <summary>
		/// Se trece la pagina urmatoare in lista cu judete
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		public void listDataGrid_PageIndexChanged(Object sender, DataGridPageChangedEventArgs	e)
		{
			Salaries.Business.AdminJudete objAdminJudete = new Salaries.Business.AdminJudete();
			DataSet dt = objAdminJudete.LoadInfoJudete();
			CompletareTitlu();

			listDataGrid.CurrentPageIndex = e.NewPageIndex;
			DataView dv = dt.Tables[0].DefaultView;

			listDataGrid.DataSource = dv;
			Index = (e.NewPageIndex * listDataGrid.PageSize) + 1;
			listDataGrid.DataBind();
		}
		#endregion

		#region listDataGrid_ItemCreated
		/// <summary>
		/// Adaugarea unui judet in lista
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		public void listDataGrid_ItemCreated(Object sender, DataGridItemEventArgs e)
		{
			string szLnk = "System.Web.UI.WebControls.DataGridLinkButton";
			string szLbl = "System.Web.UI.WebControls.Label";

			if (e.Item.ItemType == ListItemType.Pager)
			{
				TableCell cellPager = (TableCell) e.Item.Controls[0];
				cellPager.CssClass = "PagingBackStyle";
				for(int i=0; i<cellPager.Controls.Count; i++)
				{
					if ( cellPager.Controls[i].GetType().ToString() == szLnk)
					{
						LinkButton ctrl = (LinkButton) cellPager.Controls[i];
						ctrl.CssClass = "PagingStyle";
						ctrl.Attributes.Add("onmouseover","MouseOverPageNumber(this)");
						ctrl.Attributes.Add("onmouseout","MouseOutPageNumber(this)");
					}
					if (cellPager.Controls[i].GetType().ToString()== szLbl)
					{
						WebControl webCtrl = (WebControl) cellPager.Controls[i];
						webCtrl.CssClass = "SelectPageNumberStyle";
					}
				}
			}		
		}
		#endregion
	}
}
