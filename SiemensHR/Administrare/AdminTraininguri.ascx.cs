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
	///		Summary description for AdminTraininguri.
	/// </summary>
	public class AdminTraininguri : System.Web.UI.UserControl
	{
		#region Variaible
		protected System.Web.UI.WebControls.Literal litError;
		protected System.Web.UI.WebControls.Table tableTabs;
		protected System.Web.UI.WebControls.Literal Literal1;
		protected System.Web.UI.WebControls.ValidationSummary ValidationSummary1;
		protected System.Web.UI.WebControls.Button btnInapoi;
		protected System.Web.UI.WebControls.Button btnDelete;
		protected System.Web.UI.WebControls.Button btnModify;
		protected System.Web.UI.WebControls.Label lblMessage;
		protected System.Web.UI.WebControls.Button btnEdit;
		protected System.Web.UI.WebControls.Button btnAdd;
		protected System.Web.UI.WebControls.TextBox txtTrainingID;
		protected System.Web.UI.WebControls.CheckBox checkIntern;
		protected System.Web.UI.WebControls.TextBox txtDiploma;
		protected System.Web.UI.WebControls.TextBox txtDescriere;
		protected System.Web.UI.WebControls.RegularExpressionValidator regularDenumire;
		protected System.Web.UI.WebControls.RequiredFieldValidator requiredDenumire;
		protected System.Web.UI.WebControls.TextBox txtDenumire;
		protected System.Web.UI.WebControls.Table listTableExterne;
		protected System.Web.UI.WebControls.DataGrid listDataGridInterne;
		private int IndexInterne = 1;
		protected System.Web.UI.WebControls.DataGrid listDataGridExterne;
		protected System.Web.UI.HtmlControls.HtmlTableRow add_form;
		protected System.Web.UI.HtmlControls.HtmlTableRow td_addLine;
		protected System.Web.UI.HtmlControls.HtmlTableRow td_editLine;
		protected System.Web.UI.WebControls.RegularExpressionValidator regularDescriere;
		protected System.Web.UI.WebControls.RegularExpressionValidator regularDiploma;
		private int IndexExterne = 1;
		#endregion

		#region Page_Load
		private void Page_Load(object sender, System.EventArgs e)
		{
			string script_text = "<script>var ctrlID = \""+this.UniqueID+"\"</script>";
			Response.Write(script_text);
			litError.Text = "";

			btnDelete.Attributes.Add("onclick", "return CheckDelete('Doriti sa stergeti acest training?')");

			string[] textTabs = {"Training intern", "Training extern", "Adauga training"};
			Utilities.CreateHeaderWithTabsForAdminTraininguri(tableTabs, textTabs, "../", true);

			txtTrainingID.Style.Add("display" ,"none");
			btnEdit.Style.Add("display", "none");

			//	Modificat:	Lungu Andreea
			//	Data:		27.07.2007
			//	Descriere:	S-au adaugat variabilele necesare in JavaScript, corespunzatoare validatorilor regularDescriere si regularDiploma
			Response.Write("<script>var requiredDenumire = \"" + requiredDenumire.ClientID + "\"</script>");
			Response.Write("<script>var regularDenumire = \"" + regularDenumire.ClientID + "\"</script>");
			Response.Write("<script>var regularDescriere = \"" + regularDescriere.ClientID + "\"</script>");
			Response.Write("<script>var regularDiploma = \"" + regularDiploma.ClientID + "\"</script>");
			
			/*if (!IsPostBack)
			{*/
				PopulareTabelaInterne();
				PopulareTabelaExterne();
			//}
		}
		#endregion

		#region PopulareTabelaInterne
		/// <summary>
		/// Populeaza lista cu cursuri interne
		/// </summary>
		public void PopulareTabelaInterne()
		{
			IndexInterne = listDataGridInterne.CurrentPageIndex * 30 + 1;
			Salaries.Business.AdminTraining training = new Salaries.Business.AdminTraining();
			training.Intern = true;
			listDataGridInterne.DataSource = training.LoadInfoTraininguri();
			listDataGridInterne.DataBind();
		}
		#endregion

		#region PopulareTabelaExterne
		/// <summary>
		/// Populeaza lista cu cursuri externe
		/// </summary>
		public void PopulareTabelaExterne()
		{
			IndexExterne = listDataGridExterne.CurrentPageIndex * 30 + 1;
			Salaries.Business.AdminTraining training = new Salaries.Business.AdminTraining();
			training.Intern = false;
			listDataGridExterne.DataSource = training.LoadInfoTraininguri();
			listDataGridExterne.DataBind();
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
			this.listDataGridInterne.ItemCreated += new System.Web.UI.WebControls.DataGridItemEventHandler(this.listDataGridInterne_ItemCreated);
			this.listDataGridInterne.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.listDataGridInterne_PageIndexChanged);
			this.listDataGridInterne.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.listDataGridInterne_ItemDataBound);
			this.listDataGridExterne.ItemCreated += new System.Web.UI.WebControls.DataGridItemEventHandler(this.listDataGridExterne_ItemCreated);
			this.listDataGridExterne.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.listDataGridExterne_PageIndexChanged);
			this.listDataGridExterne.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.listDataGridExterne_ItemDataBound);
			this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
			this.btnModify.Click += new System.EventHandler(this.btnModify_Click);
			this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
			this.btnInapoi.Click += new System.EventHandler(this.btnInapoi_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region btnAdd_Click
		/// <summary>
		/// Adaugarea unui training
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnAdd_Click(object sender, System.EventArgs e)
		{
			try 
			{
				Salaries.Business.AdminTraining newTraining = new Salaries.Business.AdminTraining();
				newTraining.TrainingId = 0;
				newTraining.Nume  = txtDenumire.Text;
				newTraining.Descriere = txtDescriere.Text;
				newTraining.Diploma= this.txtDiploma.Text;
				newTraining.Intern=this.checkIntern.Checked;

				if (newTraining.CheckIfTrainingCanBeAdded())
				{
					newTraining.InsertTraining();
				}
				else
				{
					Response.Write("<script> alert('Mai exista un training cu aceste date!'); </script>");
				}

				//Daca pagina de administrare a fost deschisa din AddAngajat cream functia care va face refresh la combo-ul cu traininguri
				CreateRefreshFunction();
			}
			catch (Exception ex)
			{
				litError.Text = "The following error occurred: <br>";
				litError.Text += ex.Message;
			}

			PopulareTabelaInterne();
			PopulareTabelaExterne();
		}
		#endregion

		#region btnModify_Click
		/// <summary>
		/// Modifica un training
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnModify_Click(object sender, System.EventArgs e)
		{
			try
			{
				int trainingId = Convert.ToInt32(txtTrainingID.Text);
				Salaries.Business.AdminTraining objTraining = new Salaries.Business.AdminTraining();

				objTraining.TrainingId = trainingId;
				objTraining.Nume = txtDenumire.Text;
				objTraining.Descriere = txtDescriere.Text;
                objTraining.Diploma = txtDiploma.Text;
				objTraining.Intern = checkIntern.Checked;

				if (objTraining.CheckIfTrainingCanBeAdded())
				{
					objTraining.UpdateTraining();
				}
				else
				{
					Response.Write("<script> alert('Mai exista un training cu aceste date!'); </script>");
				}
				

				//Daca pagina de administrare a fost deschisa din AddAngajat cream functia care va face refresh la combo-ul cu traininguri
				CreateRefreshFunction();
			}
			catch (Exception ex)
			{
				litError.Text = "The following error occurred: <br>";
				litError.Text += ex.Message;
			}
			PopulareTabelaInterne();
			PopulareTabelaExterne();
		}
		#endregion

		#region btnDelete_Click
		/// <summary>
		/// Sterge un training
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnDelete_Click(object sender, System.EventArgs e)
		{
			try
			{
				int trainingId = Convert.ToInt32(txtTrainingID.Text);
				Salaries.Business.AdminTraining training = new Salaries.Business.AdminTraining();
				training.TrainingId = trainingId;
				int sePoateSterge = training.CheckIfTrainingCanBeDeleted();
				
				if (sePoateSterge == 1)
				{
					Response.Write("<script> alert('Trainingul nu poate fi sters! Este inca asociat unor angajati!'); </script>");
				}
				if (sePoateSterge == 2)
				{
					Response.Write("<script> alert('Operatiunea nu a fost efectuata deoarece nomenclatoul trebuie sa contina cel putin un curs.'); </script>");
				}
				if (sePoateSterge == 0)
				{
					training.DeleteTraining();
					PopulareTabelaInterne();
					PopulareTabelaExterne();
				}

				//Daca pagina de administrare a fost deschisa din AddAngajat cream functia care va face refresh la combo-ul cu traininguri
				CreateRefreshFunction();
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
		/// Revine la lista cu training-uri
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnInapoi_Click(object sender, System.EventArgs e)
		{
			PopulareTabelaInterne();
			PopulareTabelaExterne();

			//Daca pagina de administrare a fost deschisa din AddAngajat cream functia care va face refresh la combo-ul cu traininguri
			//In acest caz va fi goala ... 
			CreateEmptyRefreshFunction();
		}
		#endregion

		#region CreateRefreshFunction
		/// <summary>
		/// Daca pagina de administrare a fost deschisa din IstoricTraininguri cream functia care va face refresh la combo-ul cu traininguri
		/// </summary>
		private void CreateRefreshFunction()
		{
			string outStr = "";
			
			//cream scriptul care va contine functia de refresh
			//ne bazam pe faptul ca se cunoaste numele selectului care contine traininguri-le
			//initial se sterg toate intrarile din combo
			outStr +=	"<script> \r\n function RefreshParentPage() \r\n" +
				"{ \r\n" +
				"window.opener.DeleteTraininguriCombo(); \r\n" +
				" FillTraininguriCOmbo(); \r\n" +
				"} \r\n";

			outStr +=	" function FillTraininguriCOmbo() \r\n" +
				"{ \r\n";
			//acum se creeaza functie care adauga traininguri-le din recordset
			//se foloseste o functie din parent page... FillTrainingCombo
			Salaries.Business.AdminTraining training = new Salaries.Business.AdminTraining();
			training.Intern = true;
			foreach ( DataRow dataRow in training.LoadInfoTraininguri().Tables[0].Rows)
			{
				outStr +=	"window.opener.FillTrainingCombo('" +
					dataRow["Nume"].ToString() + "'," +
					dataRow["TrainingID"].ToString() + ");";
			}

			//acum se creeaza functie care adauga traininguri-le din recordset
			//se foloseste o functie din parent page... FillTrainingCombo2
			training.Intern = false;	
			foreach ( DataRow dataRow in training.LoadInfoTraininguri().Tables[0].Rows)
			{
				outStr +=	"window.opener.FillTrainingCombo2('" +
					dataRow["Nume"].ToString() + "'," +
					dataRow["TrainingID"].ToString() + ");";
			}
						
			outStr +=	"} \r\n" +
				"</script>";

			Response.Write( outStr);
		}
		#endregion

		#region CreateEmptyRefreshFunction
		/// <summary>
		/// Creeaza o functie de refresh goala pt cazul in care se incearca editarea unui training
		/// </summary>
		private void CreateEmptyRefreshFunction()
		{
			string outStr = "";

			outStr += "<script> function RefreshParentPage() {}  </script>";
			Response.Write( outStr);
		}
		#endregion


		#region listDataGridInterne_ItemCreated
		/// <summary>
		/// Se creaza o inregistrare in lista
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		public void listDataGridInterne_ItemCreated(Object sender, DataGridItemEventArgs e)
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

		#region listDataGridInterne_ItemDataBound
		/// <summary>
		/// Creaza o inregistrare in lista
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		public void listDataGridInterne_ItemDataBound(object sender, DataGridItemEventArgs e)
		{
			if (e.Item.ItemIndex!=-1)  // daca e header nu pune evenimentele
			{
				TableCell myCell = new TableCell();
				myCell.Text = IndexInterne.ToString();
				myCell.Attributes.Add("align","center");
				e.Item.Cells.AddAt(0, myCell);
				for(int j=0; j<e.Item.Cells.Count; j++)
					e.Item.Cells[j].Attributes.Add("class","UnderlineNormalBlack");
				IndexInterne++;
				e.Item.Attributes.Add("onmouseover", "MouseOverTableLine(this)");
				e.Item.Attributes.Add("onmouseout", "MouseOutTableLine(this)");
				e.Item.Attributes.Add("onclick", "SelectLine(" + e.Item.Cells[1].Text  + ",'" + e.Item.Cells[2].Text + "','" + e.Item.Cells[3].Text + "','" + e.Item.Cells[4].Text + "',0" + ")");

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

		#region listDataGridInterne_PageIndexChanged
		/// <summary>
		/// Se trece la urmatoarea pagina in lista
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		public void listDataGridInterne_PageIndexChanged(Object sender, DataGridPageChangedEventArgs	e)
		{
			Salaries.Business.AdminTraining training = new Salaries.Business.AdminTraining();
			training.Intern = true;
			DataSet dt = training.LoadInfoTraininguri();

			listDataGridInterne.CurrentPageIndex = e.NewPageIndex;
			DataView dv = dt.Tables[0].DefaultView;

			listDataGridInterne.DataSource = dv;
			IndexInterne = (e.NewPageIndex * listDataGridInterne.PageSize) + 1;
			listDataGridInterne.DataBind();
		}
		#endregion


		#region listDataGridExterne_ItemCreated
		/// <summary>
		/// Se creaza o inregistrare in lista
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		public void listDataGridExterne_ItemCreated(Object sender, DataGridItemEventArgs e)
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

		#region listDataGridExterne_ItemDataBound
		/// <summary>
		/// Creaza o inregistrare in lista
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		public void listDataGridExterne_ItemDataBound(object sender, DataGridItemEventArgs e)
		{
			if (e.Item.ItemIndex!=-1)  // daca e header nu pune evenimentele
			{
				TableCell myCell = new TableCell();
				myCell.Text = IndexExterne.ToString();
				myCell.Attributes.Add("align","center");
				e.Item.Cells.AddAt(0, myCell);
				for(int j=0; j<e.Item.Cells.Count; j++)
					e.Item.Cells[j].Attributes.Add("class","UnderlineNormalBlack");
				IndexExterne++;
				e.Item.Attributes.Add("onmouseover", "MouseOverTableLine(this)");
				e.Item.Attributes.Add("onmouseout", "MouseOutTableLine(this)");
				e.Item.Attributes.Add("onclick", "SelectLine(" + e.Item.Cells[1].Text  + ",'" + e.Item.Cells[2].Text + "','" + e.Item.Cells[3].Text + "','" + e.Item.Cells[4].Text + "',1" + ")");

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

		#region listDataGridExterne_PageIndexChanged
		/// <summary>
		/// Se trece la urmatoarea pagina in lista
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		public void listDataGridExterne_PageIndexChanged(Object sender, DataGridPageChangedEventArgs	e)
		{
			Salaries.Business.AdminTraining training = new Salaries.Business.AdminTraining();
			training.Intern = false;
			DataSet dt = training.LoadInfoTraininguri();

			listDataGridExterne.CurrentPageIndex = e.NewPageIndex;
			DataView dv = dt.Tables[0].DefaultView;

			listDataGridExterne.DataSource = dv;
			IndexExterne = (e.NewPageIndex * listDataGridExterne.PageSize) + 1;
			listDataGridExterne.DataBind();
		}
		#endregion
	}
}
