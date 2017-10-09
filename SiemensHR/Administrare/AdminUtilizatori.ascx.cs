using System;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using SiemensHR.Classes;

namespace SiemensHR.Administrare
{
	/// <summary>
	///		Summary description for AdminUtilizatori.
	/// </summary>
	public class AdminUtilizatori : System.Web.UI.UserControl
	{
		#region Variabile
		protected System.Web.UI.WebControls.Table mainTable;
		protected System.Web.UI.WebControls.Literal litError;
		protected System.Web.UI.WebControls.ValidationSummary vldSummary;
		protected System.Web.UI.WebControls.DataGrid listDataGrid;
		protected System.Web.UI.WebControls.DropDownList dropDownListGrupuri;
		protected System.Web.UI.WebControls.Button btnDeleteUtilizator;
		protected System.Web.UI.WebControls.Button btnAddUtilizator;
		protected System.Web.UI.WebControls.RequiredFieldValidator requiredUtilizator;
		protected System.Web.UI.WebControls.TextBox txtUtilizator;
		protected System.Web.UI.WebControls.TextBox txtParola;
		protected System.Web.UI.WebControls.TextBox txtConfirmareParola;
		protected System.Web.UI.WebControls.RegularExpressionValidator regExpUtilizator;
		protected System.Web.UI.WebControls.RequiredFieldValidator requiredParola;
		protected System.Web.UI.WebControls.CompareValidator compareValParolaConfirmare;
		protected System.Web.UI.WebControls.RequiredFieldValidator requiredConfirmare;
		protected System.Web.UI.WebControls.Table headerTable;
		private int Index;
		protected System.Web.UI.HtmlControls.HtmlInputHidden txtUtilizatorID;
		protected System.Web.UI.HtmlControls.HtmlInputHidden txtGrupID;
		protected System.Web.UI.WebControls.TextBox txtEmail;
		protected System.Web.UI.WebControls.RequiredFieldValidator Requiredfieldvalidator1;
		protected System.Web.UI.WebControls.RegularExpressionValidator regularEmail;
		private int angajatorId;
		#endregion

		#region Page_Load
		//Autor: Lungu Andreea
		//Data:  31.10.2007 - 01.11.2007
		private void Page_Load(object sender, System.EventArgs e)
		{			
			string script_text = "<script>var ctrlID = \""+this.UniqueID+"\"</script>";
			Response.Write(script_text);
			Response.Write("<script>var requiredUtilizatorClientID = \""+requiredUtilizator.ClientID+"\"</script>");
			Response.Write("<script>var requiredParolaClientID = \""+requiredParola.ClientID+"\"</script>");
			Response.Write("<script>var requiredConfirmareClientID = \""+requiredConfirmare.ClientID+"\"</script>");
			Response.Write("<script>var regExpUtilizatorClientID = \""+regExpUtilizator.ClientID+"\"</script>");
			Response.Write("<script>var compareValParolaConfirmareClientID = \""+ compareValParolaConfirmare.ClientID+"\"</script>");
			Response.Write("<script> var txtGrupIdClient = '" + this.txtGrupID.ClientID + "';</script>");
			Response.Write("<script> var txtUtilizatorIDClient = '" + this.txtUtilizatorID.ClientID + "';</script>");
			
			litError.Text = "";
				
			btnDeleteUtilizator.Attributes.Add("onclick", "return CheckDeleteUtilizator('Doriti sa stergeti acest utilizator?')");
			Utilities.CreateTableHeader(headerTable, "Date utilizator", "../", "small");	

			angajatorId = int.Parse(Session["AngajatorID"].ToString());
			if (!IsPostBack)
			{
				BindComboGrup();
				CompletareTitlu();
				PopulareTabela();
			}
		}

		#endregion

		#region BindComboGrup
		//Autor: Lungu Andreea
		//Data:  31.10.2007
		/// <summary>
		/// Este populat combo care contine grupurile
		/// </summary>
		private void BindComboGrup()
		{
			Salaries.Business.GrupUtilizatori grupuri = new Salaries.Business.GrupUtilizatori();
			dropDownListGrupuri.DataSource = grupuri.GetGrupuriUtilizatori();
			dropDownListGrupuri.DataTextField = "NumeGrup";
			dropDownListGrupuri.DataValueField = "GrupID";
			dropDownListGrupuri.DataBind();
		}
		#endregion

		#region CompletareTitlu
		//Autor: Lungu Andreea
		//Data:  31.10.2007
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
			myCell.Text = "Lista utilizatorilor existenti";
			myCell.Height = new Unit(50);
			myRow.Cells.Add(myCell);
			mainTable.Rows.Add(myRow);
		
			listDataGrid.Visible = true;
		}
		#endregion

		#region PopulareTabela
		//Autor: Lungu Andreea
		//Data:  31.10.2007
		/// <summary>
		/// Populeaza lista cu tari
		/// </summary>
		public void PopulareTabela()
		{
			Index = listDataGrid.CurrentPageIndex * 30 + 1;
			Salaries.Business.AdminUtilizatori objAdminUtilizatori = new Salaries.Business.AdminUtilizatori();	
			listDataGrid.DataSource = objAdminUtilizatori.LoadInfoUtilizatori(angajatorId);
			listDataGrid.DataBind();
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
			this.listDataGrid.ItemCreated += new System.Web.UI.WebControls.DataGridItemEventHandler(this.listDataGrid_ItemCreated);
			this.listDataGrid.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.listDataGrid_PageIndexChanged);
			this.listDataGrid.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.listDataGrid_ItemDataBound);
			this.btnAddUtilizator.Click += new System.EventHandler(this.btnAddUtilizator_Click);
			this.btnDeleteUtilizator.Click += new System.EventHandler(this.btnDeleteUtilizator_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region listDataGrid_ItemCreated
		//Autor: Lungu Andreea
		//Data:  31.10.2007
		/// <summary>
		/// Se creaza o inregistrare in lista.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void listDataGrid_ItemCreated(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
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

		#region listDataGrid_ItemDataBound
		//Autor: Lungu Andreea
		//Data:  31.10.2007
		/// <summary>
		/// creaza o inregistrare in lista
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void listDataGrid_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
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
				e.Item.Attributes.Add("onclick", "SelectUtilizator(" + e.Item.Cells[1].Text  + ",'" + e.Item.Cells[2].Text + "','" + e.Item.Cells[3].Text + "','" + Salaries.Configuration.CryptographyClass.decodeSTR(e.Item.Cells[4].Text)+ "','" + e.Item.Cells[5].Text + "')");

				e.Item.Cells[1].Style.Add("display", "none");
			}
			else
			{
				TableCell myCellHeader = new TableCell();
				myCellHeader.Text = "Nr. crt";
				e.Item.Cells.AddAt(0, myCellHeader);
				for (int i=1; i<e.Item.Cells.Count ; i++)
				{
					// ascund prima coloana.. care este id utilizator
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
			e.Item.Cells[e.Item.Cells.Count-2].Visible = false;
			e.Item.Cells[e.Item.Cells.Count-1].Visible = false;
		}
		#endregion

		#region listDataGrid_PageIndexChanged
		//Autor: Lungu Andreea
		//Data:  31.10.2007
		/// <summary>
		/// Se trece la o alta pagina.
		/// </summary>
		/// <param name="source"></param>
		/// <param name="e"></param>
		private void listDataGrid_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			Salaries.Business.AdminUtilizatori utilizator = new Salaries.Business.AdminUtilizatori();
			DataSet dt = utilizator.LoadInfoUtilizatori(angajatorId);
			CompletareTitlu();

			listDataGrid.CurrentPageIndex = e.NewPageIndex;
			DataView dv = dt.Tables[0].DefaultView;

			listDataGrid.DataSource = dv;
			Index = (e.NewPageIndex * listDataGrid.PageSize) + 1;
			listDataGrid.DataBind();
		}
		#endregion

		#region btnAddUtilizator_Click
		//Autor: Lungu Andreea
		//Data:  01.11.2007
		/// <summary>
		/// Evenimentul butonului de click asupra butonului. Se adauga un utilizator
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnAddUtilizator_Click(object sender, System.EventArgs e)
		{
			try
			{
				Salaries.Business.AdminUtilizatori utilizator = new Salaries.Business.AdminUtilizatori();
				utilizator.UtilizatorId = -1;
				utilizator.Nume = txtUtilizator.Text;

				if ( (!dropDownListGrupuri.SelectedItem.Text.Equals("Managers")) || IsManagerDepartament(utilizator.Nume))
				{
					utilizator.Parola = Salaries.Configuration.CryptographyClass.encodeSTR(txtParola.Text);
					utilizator.GrupUtilizatorAngajatorId = utilizator.GetGrupAngajatorUtilizatorId(angajatorId,Convert.ToInt32(txtGrupID.Value));
					utilizator.Email = txtEmail.Text;
					if(!utilizator.VerificaExistentaUtilizator())
					{
						utilizator.InsertUtilizator();
					}
					else
					{
						Response.Write("<script>alert('Exista in baza de date un utilizator ce are aceleasi caracteristici cu cel pe care doriti sa-l introduceti!');</script>");
					}
					CompletareTitlu();
					PopulareTabela();
				}
				else
				{
					Response.Write("<script>alert('Numele utilizatorului din grupul Managers trebuie sa fie de tipul nume_denumire departament');</script>");
					CompletareTitlu();
					PopulareTabela();
				}
			}
			catch(Exception ex)
			{
				litError.Text = "The following error occurred: <br>";
				litError.Text += ex.Message;
			}
		}
		#endregion

		#region IsManagerDepartament
		/// <summary>
		/// Autor:		Lungu Andreea
		/// Data:		02.11.2007
		/// Descriere:	Procedura verifica daca numele specificat pentru un utilizator din grupul Managers
		///				este de forma string_numeDepartament
		/// </summary>
		/// <param name="numeManager">Numele utilizatorului</param>
		/// <returns>Returneaza true daca numele este corect si false altfel</returns>
		public static bool IsManagerDepartament(string numeManager)
		{
			if (numeManager.LastIndexOf("_")>=0)
			{
				string dep = numeManager.Substring(numeManager.LastIndexOf("_")+1);
				Salaries.Business.AdminDepartament departamente = new Salaries.Business.AdminDepartament();
				DataSet ds = departamente.GetAllDepartamente();
				for (int i=0; i<ds.Tables[0].Rows.Count; i++)
				{
					string n = ds.Tables[0].Rows[i]["Denumire"].ToString();
					if (n == dep)  
					{
						return true;
					}
				}
				return false;
			}
			return false;
		}
		#endregion

		#region btnDeleteUtilizator
		//Autor: Lungu Andreea
		//Data:  01.11.2007
		/// <summary>
		/// Se sterge un utilizator.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnDeleteUtilizator_Click(object sender, System.EventArgs e)
		{
			try
			{
				Salaries.Business.AdminUtilizatori utilizator = new Salaries.Business.AdminUtilizatori();
				utilizator.UtilizatorId = Convert.ToInt32(txtUtilizatorID.Value);
				if (!EsteUtilizatorCurent(txtUtilizator.Text,txtParola.Text))
				{
					int sePoateSterge = utilizator.VerificaStergereUtilizator();
				
					if (sePoateSterge == 0)
					{
						utilizator.DeleteUtilizator();
					}
					if (sePoateSterge == 1)
					{
						Response.Write("<script>alert('Operatiunea nu a fost efectuata deoarece nomenclatoul trebuie sa contina cel putin un utilizator.');</script>");
					}
				}
				else
				{
					Response.Write("<script>alert('Operatiunea nu a fost efectuata deoarece nu poate fi sters utilizatorul curent.');</script>");
				}
			}
			catch(Exception ex)
			{
				litError.Text = "The following error occurred: <br>";
				litError.Text += ex.Message;
			}
			
			CompletareTitlu();
			PopulareTabela();
		}
		#endregion

		#region EsteUtilizatorCurent
		// Autor: Lungu Andreea
		// Data: 01.11.2007
		/// <summary>
		/// Se verifica daca  parametrii nume si parola corespund utilizatorului curent
		/// </summary>
		/// <param name="nume">nume utilizator</param>
		/// <param name="parola">parola utilizator</param>
		/// <returns> true - da este utilizator curent; false - nu, nu este utilizator curent</returns>
		public bool EsteUtilizatorCurent(string nume, string parola)
		{
			try
			{
				if ( nume.Equals(Session["Nume"].ToString()) && parola.Equals(Session["Parola"].ToString()) )
				{
					return true;
				}	
			}
			catch(Exception exc)
			{
				Response.Redirect("index.aspx");
			}
			return false;
		}
		#endregion
	}
}
