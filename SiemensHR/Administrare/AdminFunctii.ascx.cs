/*
 * Modificat:	Oprescu Claudia
 * Data:		11.07.2007
 * Descriere:	Au fost adaugate campuri pentru Tipul functiei, Job family, Tipul segmentului de management si Pozitie.
 */	

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
	///		Summary description for AdminFunctii.
	/// </summary>
	public class AdminFunctii : System.Web.UI.UserControl
	{
		#region Variabile
		protected System.Web.UI.WebControls.Literal litError;
		protected System.Web.UI.WebControls.Table mainTable;
		protected System.Web.UI.WebControls.Table headerTable;
		protected System.Web.UI.WebControls.TextBox txtDenumire;
		protected System.Web.UI.WebControls.RequiredFieldValidator requiredDenumire;
		protected System.Web.UI.WebControls.TextBox txtFunctieID;
		protected System.Web.UI.WebControls.Button btnAdd;
		protected System.Web.UI.WebControls.Button btnEdit;
		protected System.Web.UI.WebControls.Label lblMessage;
		protected System.Web.UI.WebControls.Button btnModify;
		protected System.Web.UI.WebControls.Button btnDelete;
		protected System.Web.UI.WebControls.Button btnInapoi;
		protected System.Web.UI.WebControls.ValidationSummary ValidationSummary1;
		protected System.Web.UI.HtmlControls.HtmlTableRow add_form;
		protected System.Web.UI.HtmlControls.HtmlTableCell tdTitle;
		protected System.Web.UI.HtmlControls.HtmlTableRow td_addLine;
		protected System.Web.UI.HtmlControls.HtmlTableRow td_editLine;
		protected System.Web.UI.WebControls.TextBox txtCod;
		protected System.Web.UI.WebControls.TextBox txtNormaLucru;
		protected System.Web.UI.WebControls.TextBox txtDescriere;
		protected System.Web.UI.WebControls.RequiredFieldValidator requiredCod;
		protected System.Web.UI.WebControls.RequiredFieldValidator requiredNormaLucru;
		protected System.Web.UI.WebControls.RegularExpressionValidator regularCod;
		protected System.Web.UI.WebControls.RegularExpressionValidator regularNormaLucru;
		protected System.Web.UI.WebControls.TextBox txtCodSiemens;
		protected System.Web.UI.WebControls.RegularExpressionValidator regularDenumire;
		protected System.Web.UI.WebControls.RegularExpressionValidator regularCodSiemens;
		protected System.Web.UI.WebControls.RangeValidator rangeNormaLucru;
		protected System.Web.UI.WebControls.DropDownList lstJobFamily;
		protected System.Web.UI.WebControls.DropDownList lstTipDeFunctie;
		protected System.Web.UI.WebControls.DropDownList lstTipDeSegment;
		protected System.Web.UI.WebControls.DropDownList lstPozitie;
		protected System.Web.UI.HtmlControls.HtmlInputText txtHiddenJobFamily;
		protected System.Web.UI.HtmlControls.HtmlInputText txtHiddenTipDeFunctie;
		protected System.Web.UI.HtmlControls.HtmlInputText txtHiddenTipDeSegment;
		protected System.Web.UI.HtmlControls.HtmlInputText txtHiddenPozitie;
		protected System.Web.UI.WebControls.DataGrid listDataGrid;
		protected System.Web.UI.HtmlControls.HtmlTableRow add_buttonLine;
		protected System.Web.UI.HtmlControls.HtmlInputCheckBox chkPosibilaScutire;
		private int Index;
		#endregion

		#region Page_Load
		private void Page_Load(object sender, System.EventArgs e)
		{
			string script_text = "<script>var ctrlID = \""+this.UniqueID+"\"</script>";
			Response.Write(script_text);
			litError.Text = "";
			lblMessage.Visible = false;

			btnDelete.Attributes.Add("onclick", "return CheckDelete('Doriti sa stergeti aceasta functie?')");

			Utilities.CreateTableHeader(headerTable, "Date identificare functie", "../", "small");
			
			txtFunctieID.Style.Add("display" ,"none");
			
			if (!IsPostBack)
			{
				//ListareFunctii();
				BindJobFamily();
				BindTipuriDeFunctii();
				BindTipuriDeSegmente();
				BindPozitii();

				CompletareTitlu();
				PopulareTabela();
			}

			//pentru ca nu a aparut nici o eroare se poate afisa lista cu functii existnte
			Response.Write("<script> var eroare = '0' </script>");
			Response.Write("<script>var requiredCod = \"" + requiredCod.ClientID + "\"</script>");
			Response.Write("<script>var regularCod = \"" + regularCod.ClientID + "\"</script>");
			Response.Write("<script>var regularCodSiemens = \"" + regularCodSiemens.ClientID + "\"</script>");
			Response.Write("<script>var requiredDenumire = \"" + requiredDenumire.ClientID + "\"</script>");
			Response.Write("<script>var regularDenumire = \"" + regularDenumire.ClientID + "\"</script>");
			Response.Write("<script>var requiredNormaLucru = \"" + requiredNormaLucru.ClientID + "\"</script>");
			Response.Write("<script>var regularNormaLucru = \"" + regularNormaLucru.ClientID + "\"</script>");
			Response.Write("<script>var rangeNormaLucru = \"" + rangeNormaLucru.ClientID + "\"</script>");
			Response.Write("<script>var lblMessage = \"" + lblMessage.ClientID + "\"</script>");

			Response.Write("<script>var lstJobFamily = \"" + lstJobFamily.ClientID + "\"</script>");
			Response.Write("<script>var lstTipDeFunctie = \"" + lstTipDeFunctie.ClientID + "\"</script>");
			Response.Write("<script>var lstTipDeSegment = \"" + lstTipDeSegment.ClientID + "\"</script>");
			Response.Write("<script>var lstPozitie = \"" + lstPozitie.ClientID + "\"</script>");
			Response.Write("<script>var txtHiddenJobFamily = \"" + txtHiddenJobFamily.ClientID + "\"</script>");
			Response.Write("<script>var txtHiddenTipDeFunctie = \"" + txtHiddenTipDeFunctie.ClientID + "\"</script>");
			Response.Write("<script>var txtHiddenTipDeSegment = \"" + txtHiddenTipDeSegment.ClientID + "\"</script>");
			Response.Write("<script>var txtHiddenPozitie = \"" + txtHiddenPozitie.ClientID + "\"</script>");
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
			myCell.Text = "Lista functiilor existente";
			myCell.Height = new Unit(50);
			myRow.Cells.Add(myCell);
			mainTable.Rows.Add(myRow);

			td_editLine.Visible = false;
			add_form.Style.Add("display","none");
			btnEdit.Style.Add("display", "none");
			td_addLine.Visible = true;
			add_buttonLine.Visible = true;
			tdTitle.InnerText = "Adaugare functie";

			listDataGrid.Visible = true;
		}
		#endregion

		#region PopulareTabela
		/// <summary>
		/// Populeaza tabela cu judete
		/// </summary>
		public void PopulareTabela()
		{
			Index = listDataGrid.CurrentPageIndex * 30 + 1;
			Salaries.Business.AdminFunctii objAdminFunctii = new Salaries.Business.AdminFunctii();
			listDataGrid.DataSource = objAdminFunctii.LoadInfoFunctii();
			listDataGrid.DataBind();
		}
		#endregion

		#region Incarca date in controale
		/// <summary>
		/// Adaugat:	Oprescu Claudia
		/// Data:		11.07.2007
		/// Descriere:	Se incarca lista care contine familiile de functii
		/// </summary>
		private void BindJobFamily()
		{
			Salaries.Business.AdminJobFamily obj = new Salaries.Business.AdminJobFamily();
			lstJobFamily.DataSource = obj.LoadJobFamily();
			lstJobFamily.DataTextField = "DenumireIntreaga";
			lstJobFamily.DataValueField = "JobFamilyId";
			lstJobFamily.DataBind();
			if (lstJobFamily.Items.Count > 0)
			{
				lstJobFamily.SelectedIndex = 0;
				txtHiddenJobFamily.Value = lstJobFamily.Items[0].Value;
			}
		}

		/// <summary>
		/// Adaugat:	Oprescu Claudia
		/// Data:		11.07.2007
		/// Descriere:	Se incarca lista care contine tipurile de functii
		/// </summary>
		private void BindTipuriDeFunctii()
		{
			Salaries.Business.AdminTipuriDeFunctii obj = new Salaries.Business.AdminTipuriDeFunctii();
			lstTipDeFunctie.DataSource = obj.LoadTipuriDeFunctii();
			lstTipDeFunctie.DataTextField = "DenumireIntreaga";
			lstTipDeFunctie.DataValueField = "TipDeFunctieId";
			lstTipDeFunctie.DataBind();
			if (lstTipDeFunctie.Items.Count > 0)
			{
				lstTipDeFunctie.SelectedIndex = 0;
				txtHiddenTipDeFunctie.Value = lstTipDeFunctie.Items[0].Value;
			}
		}

		/// <summary>
		/// Adaugat:	Oprescu Claudia
		/// Data:		11.07.2007
		/// Descriere:	Se incarca lista care contine tipurile de segmente de management
		/// </summary>
		private void BindTipuriDeSegmente()
		{
			Salaries.Business.AdminTipuriDeSegmente obj = new Salaries.Business.AdminTipuriDeSegmente();
			lstTipDeSegment.DataSource = obj.LoadTipuriDeSegmente();
			lstTipDeSegment.DataTextField = "DenumireIntreaga";
			lstTipDeSegment.DataValueField = "TipDeSegmentId";
			lstTipDeSegment.DataBind();
			if (lstTipDeSegment.Items.Count > 0)
			{
				lstTipDeSegment.SelectedIndex = 0;
				txtHiddenTipDeSegment.Value = lstTipDeSegment.Items[0].Value;
			}
		}

		/// <summary>
		/// Adaugat:	Oprescu Claudia
		/// Data:		11.07.2007
		/// Descriere:	Se incarca lista care contine pozitiile unei functii
		/// </summary>
		private void BindPozitii()
		{
			lstPozitie.Items.Clear();
			for (int i=1; i<=6; i++)
			{
				ListItem item = new ListItem(i + "", i + "");
				lstPozitie.Items.Add(item);
			}
			lstPozitie.SelectedIndex = 0;
			txtHiddenPozitie.Value = "1";
		}
		#endregion

		#region ListareFunctii - COMENTATA
		/// <summary>
		/// Afiseaza lista cu functii
		/// </summary>
		/*public void ListareFunctii()
		{
			try
			{
				TableRow myRow = new TableRow();
				TableCell myCell = new TableCell();
		
				//titlul de la listare
				myCell.CssClass = "BigBlueBold";
				myCell.HorizontalAlign = HorizontalAlign.Center;
				myCell.VerticalAlign = VerticalAlign.Middle;
				myCell.Text = "Lista functiilor existente";
				myCell.Height = new Unit(50);
				myRow.Cells.Add(myCell);
				mainTable.Rows.Add(myRow);

				// lista de banci existente
				myRow = new TableRow();
				myCell = new TableCell();
				myCell.Attributes.Add("width", "100%");
				myCell.HorizontalAlign = HorizontalAlign.Center;
				myCell.VerticalAlign = VerticalAlign.Top;
				Table listTable = new Table();

				string[] tableHeader = {"Cod COR", "Cod Siemens", "Denumire", "Job Family", "Tip de functie", "Tip de segment", "Pozitie", "Norma lucru", "Descriere"};
				string[] tableCols = {"Cod", "CodSiemens", "Nume", "JobFamilyDenumire", "TipDeFunctieDenumire", "TipDeSegmentDenumire", "Pozitie", "NormaLucru", "Descriere"};

				Salaries.Business.AdminFunctii objAdminFunctii = new Salaries.Business.AdminFunctii();	
				ListTable objListTable = new ListTable(listTable, objAdminFunctii.LoadInfoFunctii(), tableHeader, tableCols);

				string[] ar_OnClickParam = {"FunctieID"};
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
				tdTitle.InnerText = "Adaugare functie noua";
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
		/// Adauga o functie
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnAdd_Click(object sender, System.EventArgs e)
		{
			try 
			{
				Salaries.Business.AdminFunctii newFunctie = new Salaries.Business.AdminFunctii();
				newFunctie.FunctieId = 0;
				newFunctie.Nume = txtDenumire.Text;
				newFunctie.Cod = Convert.ToInt64(txtCod.Text);
				newFunctie.CodSiemens = txtCodSiemens.Text;
				newFunctie.JobFamilyId = int.Parse(txtHiddenJobFamily.Value);
				newFunctie.TipDeFunctieId = int.Parse(txtHiddenTipDeFunctie.Value);
				newFunctie.TipDeSegmentId = int.Parse(txtHiddenTipDeSegment.Value);
				newFunctie.Pozitie = int.Parse(txtHiddenPozitie.Value);
				newFunctie.Descriere = txtDescriere.Text;
				newFunctie.NormaLucru = Convert.ToInt32(txtNormaLucru.Text);
				newFunctie.PosibilaScutireImpozit = chkPosibilaScutire.Checked;
			
				if (newFunctie.CheckIfFunctieCanBeAdded())
				{
					newFunctie.InsertFunctie();	
				}
				else
				{
					lblMessage.Text = "Mai exista o functie cu acelasi cod si nume!";
					lblMessage.Visible = true;

					//pentru ca nu se poate adauga o functie cu acest cod se ramane la formularul pentru adaugare si nu se afiseaza lista cu functii
					Response.Write("<script> var eroare = '1' </script>");
				}

				//Daca pagina de administrare a fost deschisa din AddAngajat cream functia care va face refresh la combo-ul cu functii
				CreateRefreshFunctionForAddAngajat();
			}
			catch (Exception ex)
			{
				litError.Text = "The following error occurred: <br>";
				litError.Text += ex.Message;
			}
			//ListareFunctii();
			CompletareTitlu();
			PopulareTabela();
		}
		#endregion

		#region btnEdit_Click
		/// <summary>
		/// Modifica o functie
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
		/// Completeaza campurile unei functii
		/// </summary>
		private void FillEditForm()
		{
			try 
			{
				int functieId = Convert.ToInt32(txtFunctieID.Text);
				Salaries.Business.AdminFunctii infoFunctie = new Salaries.Business.AdminFunctii();
				infoFunctie.FunctieId = functieId;
				DataRow rowFunctie = infoFunctie.GetFunctieInfo().Tables[0].Rows[0];

				txtDenumire.Text = rowFunctie["Nume"].ToString();
				txtCod.Text = rowFunctie["Cod"].ToString();
				txtCodSiemens.Text = rowFunctie["CodSiemens"].ToString();
				txtDescriere.Text = rowFunctie["Descriere"].ToString();
				lstJobFamily.SelectedValue = rowFunctie["JobFamilyId"].ToString();
				lstTipDeFunctie.SelectedValue = rowFunctie["TipDeFunctieId"].ToString();
				lstTipDeSegment.SelectedValue = rowFunctie["TipDeSegmentId"].ToString();
				lstPozitie.SelectedValue = rowFunctie["Pozitie"].ToString();
				txtHiddenJobFamily.Value = rowFunctie["JobFamilyId"].ToString();
				txtHiddenTipDeFunctie.Value = rowFunctie["TipDeFunctieId"].ToString();
				txtHiddenTipDeSegment.Value = rowFunctie["TipDeSegmentId"].ToString();
				txtHiddenPozitie.Value = rowFunctie["Pozitie"].ToString();
				txtNormaLucru.Text = rowFunctie["NormaLucru"].ToString();
				txtFunctieID.Text = functieId.ToString();
				chkPosibilaScutire.Checked = (bool) rowFunctie["PosibilaScutireImpozit"];

				td_addLine.Visible = false;
				td_editLine.Visible = true;
				add_form.Style.Add("display","");
				add_buttonLine.Visible = false;
				tdTitle.InnerText = "Editare functie";
				listDataGrid.Visible = false;

				//Daca pagina de administrare a fost deschisa din AddAngajat cream functia care va face refresh la combo-ul cu functii
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

		#region btnModify_Click
		/// <summary>
		/// Modifica o functie
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnModify_Click(object sender, System.EventArgs e)
		{
			try
			{
				int functieId = Convert.ToInt32(txtFunctieID.Text);
				Salaries.Business.AdminFunctii infoFunctie = new Salaries.Business.AdminFunctii();
				infoFunctie.FunctieId = functieId;
				infoFunctie.Nume  = txtDenumire.Text;
				infoFunctie.Cod = Convert.ToInt64(txtCod.Text);
				infoFunctie.CodSiemens = txtCodSiemens.Text;
				infoFunctie.JobFamilyId = int.Parse(txtHiddenJobFamily.Value);
				infoFunctie.TipDeFunctieId = int.Parse(txtHiddenTipDeFunctie.Value);
				infoFunctie.TipDeSegmentId = int.Parse(txtHiddenTipDeSegment.Value);
				infoFunctie.Pozitie = int.Parse(txtHiddenPozitie.Value);
				infoFunctie.Descriere = txtDescriere.Text;
				infoFunctie.NormaLucru = Convert.ToInt32(txtNormaLucru.Text);
				infoFunctie.PosibilaScutireImpozit = chkPosibilaScutire.Checked;
                
				if (infoFunctie.CheckIfFunctieCanBeAdded())
				{
					infoFunctie.UpdateFunctie();
					//ListareFunctii();
					CompletareTitlu();
					PopulareTabela();
				}
				else
				{
					lblMessage.Text = "Mai exista o functie cu acelasi cod si nume!";
					lblMessage.Visible = true;

					td_addLine.Visible = false;
					td_editLine.Visible = true;
					add_form.Style.Add("display","");
					add_buttonLine.Visible = false;
					tdTitle.InnerText = "Editare functie";
				}

				//Daca pagina de administrare a fost deschisa din AddAngajat cream functia care va face refresh la combo-ul cu functii
				CreateRefreshFunctionForAddAngajat();
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
		/// Sterge o functie
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnDelete_Click(object sender, System.EventArgs e)
		{
			try
			{
				int functieId = Convert.ToInt32(txtFunctieID.Text);
				Salaries.Business.AdminFunctii functie = new Salaries.Business.AdminFunctii();
				functie.FunctieId = functieId;
				int sePoateSterge = functie.CheckIfFunctieCanBeDeleted();
				
				if (sePoateSterge == 1)
				{
					Response.Write("<script> alert('Functia nu poate fi stearsa! Este inca asociata unor angajati!'); </script>");
					FillEditForm();
				}
				if (sePoateSterge == 2)
				{
					Response.Write("<script> alert('Operatiunea nu a fost efectuata deoarece nomenclatoul trebuie sa contina cel putin o functie.'); </script>");
					FillEditForm();
				}
				if (sePoateSterge == 0)
				{
					functie.DeleteFunctie();
					//ListareFunctii();
					CompletareTitlu();
					PopulareTabela();
				}

				//Daca pagina de administrare a fost deschisa din AddAngajat cream functia care va face refresh la combo-ul cu functii
				CreateRefreshFunctionForAddAngajat();

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
		/// Revine la lista cu functii
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnInapoi_Click(object sender, System.EventArgs e)
		{
			//ListareFunctii();
			CompletareTitlu();
			PopulareTabela();

			//Daca pagina de administrare a fost deschisa din AddAngajat cream functia care va face refresh la combo-ul cu functii
			//In acest caz va fi goala ... 
			CreateEmptyRefreshFunctionForAddAngajat();
		}
		#endregion

		#region CreateRefreshFunctionForAddAngajat
		/// <summary>
		/// Daca pagina de administrare a fost deschisa din AddAngajat cream functia care va face refresh la combo-ul cu functii
		/// </summary>
		private void CreateRefreshFunctionForAddAngajat()
		{
			string outStr = "";
			//Lungu Andreea - 28.07.2008
			string sirFunctii = GetSirFunctiiScutireImpozit();
			sirFunctii = sirFunctii.Substring(1);
			sirFunctii = sirFunctii.Substring(0,sirFunctii.Length-1);
			//Response.Write("<script>var window.opener.sirFunctii = "+sirFunctii+";</script>");
			Response.Write("<script>window.opener.CreazaSirFunctii('"+ sirFunctii +"');</script>");
			//cream scriptul care va contine functia de refresh
			//ne bazam pe faptul ca se cunoaste numele selectului care contine functiile
			//initial se sterg toate intrarile din combo
			outStr +=	"<script> \r\n function RefreshAddAngajatPage() \r\n" +
				"{ \r\n" +
				"window.opener.DeleteFunctiiCombo(); \r\n" +
				" FillFunctiiCOmbo(); \r\n" +
				"} \r\n";

			//acum se creeaza functie care adauga functiile din recordset
			//se foloseste o functie din AddAngajat ... FillFunctieCombo
			Salaries.Business.AdminFunctii objAdminFunctii = new Salaries.Business.AdminFunctii();	
			
			outStr +=	" function FillFunctiiCOmbo() \r\n" +
				"{ \r\n";
			for (int i=0; i<objAdminFunctii.LoadInfoFunctii().Tables[0].Rows.Count; i++)
			//for (int i=objAdminFunctii.LoadInfoFunctii().Tables[0].Rows.Count-1; i>=0; i--)
			{
				DataRow dataRow = objAdminFunctii.LoadInfoFunctii().Tables[0].Rows[i];
				outStr +=	"window.opener.FillFunctieCombo('" +
					dataRow["Cod"].ToString() + " - " + dataRow["Nume"].ToString() + "'," +
					dataRow["FunctieID"].ToString() + ");";
			}
			
			outStr +=	"} \r\n" +
				"</script>";

			Response.Write( outStr);
		}
		//Lungu Andreea - 28.07.2008
		private string GetSirFunctiiScutireImpozit()
		{
			Salaries.Business.AdminFunctii functii = new Salaries.Business.AdminFunctii();
			DataSet ds = functii.LoadInfoFunctii();

			string sirFunctii = "[";
			string sirFunctiiUnic = "";
			
			for( int i=0; i<ds.Tables[0].Rows.Count-1; i++ )
			{
				DataRow dr = ds.Tables[0].Rows[i];
				string suportaScutire = "";
				if ((bool) dr["PosibilaScutireImpozit"])
					suportaScutire = "Da";
				else
					suportaScutire = "Nu";
				sirFunctiiUnic = "[" + dr["FunctieId"].ToString() + "," + dr["Cod"].ToString() + " - " + dr["Nume"].ToString() + "," + suportaScutire + "]";
				sirFunctii += sirFunctiiUnic + ";"; //era cu ","
			}
			if( ds.Tables[0].Rows.Count > 0 )
			{
				DataRow dr = ds.Tables[0].Rows[ds.Tables[0].Rows.Count-1];
				string suportaScutire = "";
				if ((bool) dr["PosibilaScutireImpozit"])
					suportaScutire = "Da";
				else
					suportaScutire = "Nu";
				sirFunctiiUnic = "[" + dr["FunctieId"].ToString() + "," + dr["Cod"].ToString() + " - " + dr["Nume"].ToString() + "," + suportaScutire + "]";
				sirFunctii += sirFunctiiUnic + "]";
			}
			else
			{
				sirFunctii = "[]";
			}
			return sirFunctii;
		}
		#endregion

		#region CreateEmptyRefreshFunctionForAddAngajat
		/// <summary>
		/// Creeaza o functie de refresh goala pt cazul in care se incearca editare unei functii
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
				if (e.Item.Cells[11].Text.Equals("True"))
					e.Item.Cells[11].Text = "Da";
				else
					e.Item.Cells[11].Text = "Nu";
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
			Salaries.Business.AdminFunctii objAdminFunctii = new Salaries.Business.AdminFunctii();
			DataSet dt = objAdminFunctii.LoadInfoFunctii();
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
