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

namespace SiemensHR.Administrare
{
	/// <summary>
	///		Summary description for AdminTari.
	/// </summary>
	public class AdminTari : System.Web.UI.UserControl
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
		protected System.Web.UI.WebControls.TextBox txtTaraID;
		protected System.Web.UI.WebControls.TextBox txtNume;
		protected System.Web.UI.WebControls.TextBox txtNationalitate;
		protected System.Web.UI.WebControls.CheckBox chkTaraBaza;

		protected Salaries.Configuration.ModuleSettings settings;
		protected System.Web.UI.WebControls.RegularExpressionValidator regularDenumire;
		protected System.Web.UI.WebControls.RequiredFieldValidator requiredSimbol;
		protected System.Web.UI.WebControls.RequiredFieldValidator requiredNationalitate;
		
		protected System.Web.UI.HtmlControls.HtmlTableRow add_buttonLine;
		protected System.Web.UI.WebControls.DataGrid listDataGrid;

		private int Index;
		#endregion

		#region Page_Load
		private void Page_Load(object sender, System.EventArgs e)
		{
			settings = Salaries.Configuration.ModuleConfig.GetSettings();	
			string script_text = "<script>var ctrlID = \""+this.UniqueID+"\"</script>";
			Response.Write(script_text);
			litError.Text = "";

			btnDelete.Attributes.Add("onclick", "return CheckDelete('Doriti sa stergeti aceasta tara?')");

			Utilities.CreateTableHeader(headerTable, "Date identificare tara", "../", "small");
			
			txtTaraID.Style.Add("display" ,"none");

			Response.Write("<script>var requiredDenumire = \"" + requiredDenumire.ClientID + "\"</script>");
			Response.Write("<script>var regularDenumire = \"" + regularDenumire.ClientID + "\"</script>");
			Response.Write("<script>var requiredSimbol = \"" + requiredSimbol.ClientID + "\"</script>");
			Response.Write("<script>var requiredNationalitate = \"" + requiredNationalitate.ClientID + "\"</script>");
			Response.Write("<script>var listDataGrid = \"" + listDataGrid.ClientID + "\"</script>");
			
			if (!IsPostBack)
			{
				//ListareTari();
				CompletareTitlu();
				PopulareTabela();
			}
		}
		#endregion

		#region CompletareTitlu
		/// <summary>
		/// Completeaza titlul listei cu tari
		/// </summary>
		public void CompletareTitlu()
		{
			TableRow myRow = new TableRow();
			TableCell myCell = new TableCell();

			//titlul de la listare
			myCell.CssClass = "BigBlueBold";
			myCell.HorizontalAlign = HorizontalAlign.Center;
			myCell.VerticalAlign = VerticalAlign.Middle;
			myCell.Text = "Lista tarilor existente";
			myCell.Height = new Unit(50);
			myRow.Cells.Add(myCell);
			mainTable.Rows.Add(myRow);

			td_editLine.Visible = false;
			add_form.Style.Add("display","none");
			btnEdit.Style.Add("display", "none");
			td_addLine.Visible = true;
			add_buttonLine.Visible = true;
			tdTitle.InnerText = "Adaugare tara";
			lblMessage.Text ="";
				
			listDataGrid.Visible = true;
		}
		#endregion

		#region PopulareTabela
		/// <summary>
		/// Populeaza lista cu tari
		/// </summary>
		public void PopulareTabela()
		{
			Index = listDataGrid.CurrentPageIndex * 30 + 1;
			Salaries.Business.AdminTari tari = new Salaries.Business.AdminTari();
			listDataGrid.DataSource = tari.LoadInfoTari();
			listDataGrid.DataBind();
		}
		#endregion

		#region ListareTari - COMENTATA
		/// <summary>
		/// Procedura listeaza tarile
		/// </summary>
		/*public void ListareTari()
		{
			try
			{			
				TableRow myRow = new TableRow();
				TableCell myCell = new TableCell();

				//titlul de la listare
				myCell.CssClass = "BigBlueBold";
				myCell.HorizontalAlign = HorizontalAlign.Center;
				myCell.VerticalAlign = VerticalAlign.Middle;
				myCell.Text = "Lista tarilor existente";
				myCell.Height = new Unit(50);
				myRow.Cells.Add(myCell);
				mainTable.Rows.Add(myRow);

				Index =1;
				AdminTari objAdminTari = new AdminTari();
				listDataGrid.DataSource = objAdminTari.getDataSet;
				listDataGrid.DataBind();

				// lista de banci existente
				/*myRow = new TableRow();
				myCell = new TableCell();
				myCell.Attributes.Add("width", "100%");
				myCell.HorizontalAlign = HorizontalAlign.Center;
				myCell.VerticalAlign = VerticalAlign.Top;
				Table listTable = new Table();

				string[] tableHeader = {"Denumire", "Simbol", "Nationalitate", "Tara de baza" };
				string[] tableCols = {"NumeTara", "Simbol", "Nationalitate", "TaraDeBaza" };

				AdminTari objAdminTari = new AdminTari();	
				ListTable objListTable = new ListTable(listTable, objAdminTari.getDataSet, tableHeader, tableCols);

				string[] ar_OnClickParam = {"TaraID"};
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
				tdTitle.InnerText = "Adaugare tara";
				lblMessage.Text ="";
				
				listDataGrid.Visible = true;
	
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
		/// Adauga o tara
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnAdd_Click(object sender, System.EventArgs e)
		{
			try 
			{
				Salaries.Business.AdminTari tara = new Salaries.Business.AdminTari();
				tara.TaraId = 0;
				tara.NumeTara  = txtNume.Text;
				tara.Simbol = txtSimbol.Text;
				tara.Nationalitate = txtNationalitate.Text;
				tara.TaraDeBaza = chkTaraBaza.Checked;

				if( !tara.TaraDeBaza || !ExistaTaraDeBaza(-1))
				{
					if (tara.CheckIfTaraCanBeAdded())
					{
						tara.InsertTara();
						//Daca pagina de administrare a fost deschisa din AddAngajat cream functia care va face refresh la combo-ul cu tari
						CreateRefreshFunctionForAddAngajat();
					}
					else
					{
						Response.Write("<script> alert('Mai exista o tara cu acest nume!'); </script>");
					}
				}
				else
				{
					Response.Write( "<script>alert( 'Tara nu a fost salvata, deoarece exista o alta tara de baza!' );</script>" );
				}
			}
			catch (Exception ex)
			{
				litError.Text = "The following error occurred: <br>";
				litError.Text += ex.Message;
			}

			//ListareTari();
			CompletareTitlu();
			PopulareTabela();
		}
		#endregion

		#region ExistaTaraDeBaza
		/// <summary>
		/// Daca TaraID = -1 atunci e insert; TaraID > 0 at e update si TaraID e id-ul tarii careia i se face update
		/// </summary>
		/// <param name="taraID">Id-ul tarii</param>
		/// <returns>Returneaza true daca exista si false altfel</returns>
		private bool ExistaTaraDeBaza( int taraID)
		{
			try
			{
				Salaries.Business.AdminTari tari = new Salaries.Business.AdminTari();
				DataSet dsTaraBaza = tari.GetTaraDeBaza();
				if(( taraID == -1 && dsTaraBaza.Tables[ 0 ].Rows.Count > 0 )||( taraID != -1 && taraID != int.Parse( dsTaraBaza.Tables[ 0 ].Rows[ 0 ][ "TaraID" ].ToString())))
					return true;
				else
					return false;
			}
			catch
			{
				return false;
			}
		}
		#endregion

		#region btnModify_Click
		/// <summary>
		/// Modifica o tara
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnModify_Click(object sender, System.EventArgs e)
		{
			try
			{
				int taraId = Convert.ToInt32(txtTaraID.Text);
				Salaries.Business.AdminTari tara = new Salaries.Business.AdminTari();
				tara.TaraId = taraId;
				tara.NumeTara  = txtNume.Text;
				tara.Simbol = txtSimbol.Text;
				tara.Nationalitate = txtNationalitate.Text;
				tara.TaraDeBaza = chkTaraBaza.Checked;
                
				if( !tara.TaraDeBaza || !ExistaTaraDeBaza(taraId))
				{
					if (tara.CheckIfTaraCanBeAdded())
					{
						tara.UpdateTara();

						//Daca pagina de administrare a fost deschisa din AddAngajat cream functia care va face refresh la combo-ul cu tari
						CreateRefreshFunctionForAddAngajat();
					}
					else
					{
						Response.Write("<script> alert('Mai exista o tara cu acest nume!'); </script>");
					}
				}
				else
				{
					Response.Write( "<script>alert( 'Tara nu a fost salvata, deoarece exista o alta tara de baza!' );</script>" );
				}
			}
			catch (Exception ex)
			{
				litError.Text = "The following error occurred: <br>";
				litError.Text += ex.Message;
			}
			//ListareTari();
			CompletareTitlu();
			PopulareTabela();
		}
		#endregion

		#region btnDelete_Click
		/// <summary>
		/// Sterge o tara
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnDelete_Click(object sender, System.EventArgs e)
		{
			try
			{
				int taraId = Convert.ToInt32(txtTaraID.Text);
				Salaries.Business.AdminTari tara = new Salaries.Business.AdminTari();
				tara.TaraId = taraId;
				
				if (tara.CheckIfTaraCanBeDeleted())
				{
					tara.DeleteTara();
					//ListareTari();
					CompletareTitlu();
					PopulareTabela();
				}
				else
				{
					lblMessage.Text = "Tara nu poate fi stearsa! Este inca asociata unor angajati!";
					lblMessage.Visible = true;
					FillEditForm();
				}

				//Daca pagina de administrare a fost deschisa din AddAngajat cream functia care va face refresh la combo-ul cu tari
				CreateRefreshFunctionForAddAngajat();
			}
			catch (Exception ex)
			{
				litError.Text = "The following error occurred: <br>";
				litError.Text += ex.Message;
			}
		}
		#endregion

		#region btnEdit_Click
		/// <summary>
		/// Editeaza o tara
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
		/// Completeaza campurile unei tari
		/// </summary>
		private void FillEditForm()
		{
			try 
			{
				int taraId = Convert.ToInt32(txtTaraID.Text);		
				Salaries.Business.AdminTari tara = new Salaries.Business.AdminTari();
				tara.TaraId = taraId;
				DataSet ds = tara.GetTaraInfo();
				DataRow rowTara = ds.Tables[0].Rows[0];

				txtNume.Text = rowTara["NumeTara"].ToString();
				txtSimbol.Text = rowTara["Simbol"].ToString();
				txtNationalitate.Text = rowTara["Nationalitate"].ToString();
				chkTaraBaza.Checked = bool.Parse(rowTara["TaraDeBaza"].ToString());
				txtTaraID.Text = rowTara["TaraId"].ToString();

				td_addLine.Visible = false;
				listDataGrid.Visible = false;
				td_editLine.Visible = true;
				add_form.Style.Add("display","");
				add_buttonLine.Visible = false;
				tdTitle.InnerText = "Editare tara";

				//Daca pagina de administrare a fost deschisa din AddAngajat cream functia care va face refresh la combo-ul cu tari
				//In acest caz va fi goala ... 
				CreateEmptyRefreshFunctionForAddAngajat();
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
		/// Revine la lista cu tari
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnInapoi_Click(object sender, System.EventArgs e)
		{
			//ListareTari();
			CompletareTitlu();
			PopulareTabela();

			//Daca pagina de administrare a fost deschisa din AddAngajat cream functia care va face refresh la combo-ul cu tari
			//In acest caz va fi goala ... 
			CreateEmptyRefreshFunctionForAddAngajat();
		}
		#endregion

		#region Creare siruri necesare pt functionarea combo-urilor cu tari si judete
		/// <summary>
		/// Tari
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
		/// Judete
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
		/// Daca pagina de administrare a fost deschisa din AddAngajat cream functia care va face refresh la combo-ul cu titluri
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
			//ne bazam pe faptul ca se cunoaste numele selectului care contine titlurile
			//initial se sterg toate intrarile din combo
			outStr +=	"<script> \r\n function RefreshAddAngajatPage() \r\n" +
				"{ \r\n" +
				
				"window.opener.RecreateArray_TariJudete( 'tari', tari1.length); \r\n" +
				"for(i=0;i<tari1.length;i++) \r\n" +
				"	window.opener.RecreateLine_TariJudete( 'tari', i, tari1[i].length); \r\n" +
				"for(i=0;i<tari1.length;i++) \r\n"+
				"for(j=0;j<tari1[i].length;j++) \r\n"+
				"window.opener.SetTari( i, j, tari1[i][j]); \r\n" +

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

				"window.opener.DeleteTariCombo(); \r\n" +
				" FillTariCOmbo(); \r\n" +
				"} \r\n";

			//acum se creeaza functie care adauga titlurile din recordset
			//se foloseste o functie din AddAngajat ... FillTaraCombo
			Salaries.Business.AdminTari tari = new Salaries.Business.AdminTari();			
			outStr +=	" function FillTariCOmbo() \r\n" +
				"{ \r\n";
			foreach ( DataRow dataRow in tari.LoadInfoTari().Tables[0].Rows)
			{
				outStr +=	"window.opener.FillTaraCombo('" +
					dataRow["NumeTara"].ToString() + "'," +
					dataRow["TaraID"].ToString() + ");";
			}

			outStr += " window.opener.SyncronizeTaraJudete(); \r\n";
			
			outStr +=	"} \r\n" +
				"</script>";

			Response.Write( outStr);
		}
		#endregion

		#region CreateEmptyRefreshFunctionForAddAngajat
		/// <summary>
		/// Creeaza o functie de refresh goala pt cazul in care se incearca editarea unei tari
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
		/// Creaza o inregistrare in lista
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
		/// Se trece la urmatoarea pagina in lista
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		public void listDataGrid_PageIndexChanged(Object sender, DataGridPageChangedEventArgs	e)
		{
			Salaries.Business.AdminTari tari = new Salaries.Business.AdminTari();
			DataSet dt = tari.LoadInfoTari();
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
		/// Se creaza o inregistrare in lista
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
