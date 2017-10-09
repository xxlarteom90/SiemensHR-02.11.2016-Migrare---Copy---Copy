using System;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Configuration;
using System.Data.SqlClient;

using SiemensHR.utils;
using SiemensHR.Classes;	
using Salaries.Business;

namespace SiemensHR.Administrare
{
	/// <summary>
	///		Summary description for AdminDepartamente.
	/// </summary>
	public class AdminDepartamente : SiemensHR.InterfataSalarii.Classes.BaseModule
	{
		#region Variabile
		protected System.Web.UI.WebControls.Literal litError;
		protected System.Web.UI.WebControls.Table mainTable;
		protected System.Web.UI.WebControls.Table headerTable;
		protected System.Web.UI.WebControls.TextBox txtDenumire;
		protected System.Web.UI.WebControls.RequiredFieldValidator requiredDenumire;
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
		protected System.Web.UI.WebControls.DropDownList lstSef;
		protected System.Web.UI.WebControls.DropDownList lstInlocSef;
		protected System.Web.UI.WebControls.DropDownList lstDeptParinte;
		protected System.Web.UI.HtmlControls.HtmlInputHidden txtDeptID;
		protected System.Web.UI.HtmlControls.HtmlInputHidden DeptParinteID;
		protected System.Web.UI.WebControls.Label labelExistentaDepartamente;
		protected System.Web.UI.HtmlControls.HtmlTableRow add_buttonLine;
		protected System.Web.UI.WebControls.DropDownList lstCentruCost;
		protected System.Web.UI.WebControls.RegularExpressionValidator regularDenumire;
		protected Salaries.Configuration.ModuleSettings settings;		
		protected string outStr;
		protected System.Web.UI.WebControls.RegularExpressionValidator Regularexpressionvalidator1;
		protected System.Web.UI.WebControls.TextBox txtSecretariat;
		protected string connString;
		#endregion

		#region Page_Load
		private void Page_Load(object sender, System.EventArgs e)
		{
			settings = Salaries.Configuration.ModuleConfig.GetSettings();
			string script_text = "<script>var ctrlID = \""+this.ClientID+"\"</script>";
			Response.Write(script_text);
			script_text = "<script>var DeptParinteIDClient = '"+this.DeptParinteID.ClientID+"';</script>";
			Response.Write(script_text);

			litError.Text = "";
			this.lstDeptParinte.Enabled=true;

			btnDelete.Attributes.Add("onclick", "return CheckDelete('Doriti sa stergeti acest departament?')");

			Utilities.CreateTableHeader(headerTable, "Date identificare departament", "../", "small");

			Response.Write("<script>var requiredDenumire = \"" + requiredDenumire.ClientID + "\"</script>");
			Response.Write("<script>var regularDenumire = \"" + regularDenumire.ClientID + "\"</script>");
								
			if (!IsPostBack)
			{
				this.ListareDepartamente();
			}
		}
		#endregion

		#region Render
		protected override void Render(System.Web.UI.HtmlTextWriter writer)
		{
			base.Render (writer);
			if (td_editLine.Visible != true)
			{
				this.BuildTree("TreeContainer");
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
		
		#region CreazaVarJSValoareDefault
		/// <summary>
		/// Scrie variabilele pe JAvaScript
		/// </summary>
		private void CreazaVarJSValoareDefault()
		{
			string script_text = "<script>var lstDeptParinteDefaultVal = '-1';</script>";
			if( lstDeptParinte.Items.Count > 0 )
			{
				script_text = "<script>var lstDeptParinteDefaultVal = '"+lstDeptParinte.SelectedValue+"';</script>";
			}
			Response.Write(script_text);

			script_text = "<script>var lstSefDefaultVal = '"+lstSef.SelectedValue+"';</script>";
			Response.Write(script_text);

			script_text = "<script>var lstInlocSefDefaultVal = '"+lstInlocSef.SelectedValue+"';</script>";
			Response.Write(script_text);

			//script_text = "<script>var lstSecretaraDefaultVal = '"+lstSecretara.SelectedValue+"';</script>";
			//Response.Write(script_text);
		}
		#endregion

		#region BuildTree
		/// <summary>
		/// Construieste arborele de departamente
		/// </summary>
		/// <param name="ad">Departamenentul</param>
		/// <param name="parentId">Departamentul parinte</param>
		/// <returns></returns>
		private string BuildTree(AdminDepartament ad, int parentId)
		{
			ad.DeptParinte = parentId;
			DataSet ds = ad.LoadInfoDepartamente();
			string aux="";
			foreach (DataRow dr in ds.Tables[0].Rows)
			{
				string ID = dr["DepartamentID"].ToString();
				string Text = dr["Cod"].ToString()+ " - "+dr["Denumire"].ToString();

				//In cazul in care se incearca editarea dept parinte cu numele angajtorului NU se intampla nimic ... pentru ca datele despre acest departament nu pot fi modificate
				//Pentru a identifica pe partea de client acest dept retinem id-ul acestuia
				if ( parentId == 0)
				{
					aux+="<script> var FirstDeptID = " + ID + ";</script> ";
				}
				aux += "<script> var Departament_"+ID+" = new CreateNodeElement('Dept_"+ID+"','"+Text+"','',false,null,'"+Text+"','#','','SelectLine( "+ID+")');getNode('Dept_"+parentId+"').AddSubNode('Dept_"+ID+"')</script>"+BuildTree(ad,int.Parse(ID));
			}

			return aux;
		}
		#endregion	

		#region BuildTree
		/// <summary>
		/// Construieste arborele de departamente
		/// </summary>
		/// <param name="ContainerID"></param>
		private void BuildTree(string ContainerID)
		{
			AdminDepartament ad = new AdminDepartament();
			string aux;
			int ID = 0;
			aux = "<script> var Departament_"+ID+" = new CreateNodeElement('Dept_"+ID+"','','',false,'"+ContainerID+"','','#','','');</script>"+BuildTree(ad,ID);		
			Response.Write(aux);
			Response.Write("<script>Departament_0.ExpandAll();Departament_0.Render()</script>");
		}
		#endregion

		#region CreateDepartamente
		/// <summary>
		/// Creaza un departamente din arbore
		/// </summary>
		/// <param name="parinte">Departamentul parinte</param>
		/// <param name="nivel">Nivelul departametnului</param>
		private void CreateDepartamente(int parinte, int nivel)
		{		
			AdminDepartament adminDept = new AdminDepartament();
			adminDept.DeptParinte = parinte;
			DataSet ds = adminDept.LoadInfoDepartamente();

			DataTable myTable = new DataTable();
			myTable = ds.Tables[0];
			string nivel_text = "";			
			
			for(int j=0; j<nivel; j++)
				nivel_text += ".  .  ";
			for (int i=0; i<myTable.Rows.Count; i++)
			{
				DataRow myRow = myTable.Rows[i];

				outStr +=	"window.opener.FillDepartamentCombo('" +
					nivel_text + myRow["nume"].ToString() + "'," +
					myRow["DepartamentID"].ToString() + ");";

				nivel ++;
				CreateDepartamente(Convert.ToInt32(myRow["DepartamentID"]), nivel);
				nivel--;			
			}
		}
		#endregion

		#region CreateRefreshFunction
		/// <summary>
		/// Daca pagina de administrare a fost deschisa din alta pagina cream functia care va face refresh la combo-ul cu departamente
		/// </summary>
		private void CreateRefreshFunction()
		{
			outStr = "";
			
			//cream scriptul care va contine functia de refresh
			//ne bazam pe faptul ca se cunoaste numele selectului care contine departamentele
			//initial se sterg toate intrarile din combo
			outStr +=	"<script> \r\n function RefreshParentPage() \r\n" +
				"{ \r\n" +
				"window.opener.DeleteDepartamenteCombo();  \r\n" +
				" FillDepartamenteCombo(); \r\n" +
				"} \r\n";

			outStr +=	" function FillDepartamenteCombo() \r\n" +
				"{ \r\n";
			//acum se creeaza functie care adauga departamentele din recordset
			//se foloseste o functie din parent page... FillDepartamentCombo
			
			connString = settings.ConnectionString;
			CreateDepartamente( 0, 0);
						
			outStr +=	"} \r\n" +
				"</script>";

			Response.Write( outStr);
		}
		#endregion

		#region CreateEmptyRefreshFunction
		/// <summary>
		/// Functia care face refresh pt combo cu departamente. Combo va fi gol.
		/// </summary>
		private void CreateEmptyRefreshFunction()
		{
			outStr = "";

			outStr += "<script>function RefreshParentPage() {}</script>";
			Response.Write( outStr);
		}
		#endregion

		#region ListareDepartamente
		/// <summary>
		/// Lista cu departamente
		/// </summary>
		protected void ListareDepartamente()
		{
			lblMessage.Text="";
			try
			{
				TableRow myRow = new TableRow();
				TableCell myCell = new TableCell();

				// lista de banci existente
				myRow = new TableRow();
				myCell = new TableCell();
				myCell.Attributes.Add("width", "100%");
				myCell.HorizontalAlign = HorizontalAlign.Center;
				myCell.VerticalAlign = VerticalAlign.Top;
				
				myRow.Cells.Add(myCell);
				mainTable.Rows.Add(myRow);

								
				td_editLine.Visible = false;
				add_form.Style.Add("display","none");
				btnEdit.Style.Add("display", "none");
				td_addLine.Visible = true;
				add_buttonLine.Visible = true;
				tdTitle.InnerText = "Adaugare Departament";				
				
				UtilitiesDb utilDb = new UtilitiesDb(settings.ConnectionString);
				
				lstDeptParinte.Items.Clear();
				lstCentruCost.Items.Clear();
				//lstSecretara.Items.Clear();
				utilDb.CreateDepartamenteSelectBox(0, 0, this.lstDeptParinte);
				utilDb.CreateDepartamentAngajatiSelectBox(this.lstSef,this.GetAngajator());
				utilDb.CreateCentruCostSelectBox(this.lstCentruCost);
				//Modificat:Muntean Raluca Cristina  - am adaugat ca parametru si id-ul angajatorului
				utilDb.CreateDepartamentAngajatiSelectBox(this.lstInlocSef, this.GetAngajator());
				//utilDb.CreateDepartamentAngajatiSelectBox(this.lstSecretara, this.GetAngajator());
				
				//Modificat: Ionel Popa - adaugam in combo-ul cu inlocuitor sefi si optiunea vida ( "Nu exista inlocuitor")
				ListItem myItem = new ListItem("NU EXISTA INLOCUITOR", "-1");
				myItem.Selected = true;
				this.lstInlocSef.Items.Add(myItem);
				
				//ListItem myItem1 = new ListItem("NU EXISTA SECRETARA", "-1");
				//myItem1.Selected = true;
				//this.lstSecretara.Items.Add(myItem1);

				CreazaVarJSValoareDefault();

				if( lstDeptParinte.Items.Count == 0 )
				{
					lstDeptParinte.Visible = false;
					labelExistentaDepartamente.Visible = true;
				}
				else
				{
					lstDeptParinte.Visible = true;
					labelExistentaDepartamente.Visible = false;
				}
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
		/// Adauga un departament
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnAdd_Click(object sender, System.EventArgs e)
		{
			try 
			{
				this.lstDeptParinte.Enabled=true;
				AdminDepartament newDepartament = new AdminDepartament();
			
				newDepartament.DepartamentId = -1;
				newDepartament.Denumire  = txtDenumire.Text;
				newDepartament.CentruCostId = int.Parse(lstCentruCost.SelectedValue);
				
				if (this.lstSef.Items.Count != 0)
				{
					newDepartament.SefId= int.Parse(this.lstSef.SelectedValue);
				}
				else
				{
					newDepartament.SefId = -1;
				}
				newDepartament.InlocSefId = int.Parse(this.lstInlocSef.SelectedValue);
				//newDepartament.SecretaraId = int.Parse(lstSecretara.SelectedValue);
				newDepartament.Secretariat = txtSecretariat.Text;

				if( lstDeptParinte.Items.Count > 0 )
				{
					newDepartament.DeptParinte = int.Parse(this.lstDeptParinte.SelectedValue);
				}
				else
				{
					newDepartament.DeptParinte = 0;
				}
			
				if (newDepartament.CheckIfAdminDepartamentCanBeAdded())
				{
					newDepartament.InsertDepartament();
				}
				else
				{
					Response.Write("<script> alert('Mai exista un departament cu aceste date!'); </script>");
				}
				UtilitiesDb utilDb = new UtilitiesDb(settings.ConnectionString);
				lstDeptParinte.Items.Clear();
				utilDb.CreateDepartamenteSelectBox(0, 0, this.lstDeptParinte);

				//Daca pagina de administrare a fost deschisa din alta pagina cream functia care va face refresh la combo-ul cu departamente
				CreateRefreshFunction();

				ListareDepartamente();
			}
			catch (Exception ex)
			{
				litError.Text = "The following error occurred: <br>";
				litError.Text += ex.Message;
			}

			//this.ListareDepartamente();
		}
		#endregion

		#region btnEdit_Click
		/// <summary>
		/// Completeaza campurile cu datele unui departament
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnEdit_Click(object sender, System.EventArgs e)
		{
			this.FillEditForm();
		}
		#endregion

		#region FillEditForm
		/// <summary>
		/// Completeaza campurile cu datele unui departament
		/// </summary>
		private void FillEditForm()
		{		
			try 
			{
				int DepartamentID = Convert.ToInt32(this.txtDeptID.Value);
				AdminDepartament infoDepartament = new AdminDepartament();
				infoDepartament.DepartamentId = DepartamentID;
				DataRow departament = infoDepartament.GetDepartamentInfo().Tables[0].Rows[0];

				txtDenumire.Text = departament["Denumire"].ToString();
				lstCentruCost.SelectedValue = departament["CentruCostId"].ToString();
				if ( (lstInlocSef.Items.Count > 0) && (departament["InlocSefId"].ToString() != "") )
				{
					lstInlocSef.SelectedValue = departament["InlocSefId"].ToString();
				}
				if ( (lstSef.Items.Count > 0) && (departament["SefId"].ToString() != "") )
				{
					lstSef.SelectedValue = departament["SefId"].ToString();
				}
				txtSecretariat.Text = departament["Secretariat"].ToString();
//				if ( (lstSecretara.Items.Count > 0) && (departament["SecretaraId"].ToString() != "") )
//				{
//					lstSecretara.SelectedValue = departament["SecretaraId"].ToString();
//				}
				if ( int.Parse(departament["DeptParinte"].ToString()) != 0 )
				{
					lstDeptParinte.SelectedValue = departament["DeptParinte"].ToString();
				}
				if ( (lstDeptParinte.Items.Count > 0) && (departament["DeptParinte"].ToString() != "0" ) )
				{
					DeptParinteID.Value = departament["DeptParinte"].ToString();
					lstDeptParinte.Visible = true;
					labelExistentaDepartamente.Visible = false;
				}
				else
				{
					DeptParinteID.Value = departament["DeptParinte"].ToString();
					lstDeptParinte.Visible = false;
					labelExistentaDepartamente.Visible = true;
				}
				td_addLine.Visible = false;
				td_editLine.Visible = true;
				add_form.Style.Add("display","");
				add_buttonLine.Visible = false;
				tdTitle.InnerText = "Editare Departament";

				//Daca pagina de administrare a fost deschisa din alta pagina cream functia care va face refresh la combo-ul cu departamente
				//In acest caz va fi goala ... 
				CreateEmptyRefreshFunction();
				
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
		/// Modifica un departament
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnModify_Click(object sender, System.EventArgs e)
		{
			try
			{
				int DepartamentID = Convert.ToInt32(txtDeptID.Value);
				AdminDepartament objDepartament = new AdminDepartament();

				objDepartament.DepartamentId = DepartamentID;
				objDepartament.Denumire  = txtDenumire.Text;
				objDepartament.CentruCostId = int.Parse(lstCentruCost.SelectedValue);
				if (lstSef.Items.Count != 0)
				{
					objDepartament.SefId = int.Parse(lstSef.SelectedValue);
				}
				else
				{
					objDepartament.SefId = -1;
				}
				objDepartament.InlocSefId = int.Parse(lstInlocSef.SelectedValue);
				//objDepartament.SecretaraId = int.Parse(lstSecretara.SelectedValue);
				objDepartament.Secretariat = txtSecretariat.Text;

				if( lstDeptParinte.Items.Count > 0 )
				{
					objDepartament.DeptParinte=int.Parse(DeptParinteID.Value);
				}
				else
				{
					objDepartament.DeptParinte = 0;
				}
		
				if (objDepartament.CheckIfAdminDepartamentCanBeAdded())
				{
					objDepartament.UpdateDepartament();
				}
				else
				{
					Response.Write("<script> alert('Mai exista un departament cu aceste date!'); </script>");
				}			

				UtilitiesDb utilDb = new UtilitiesDb(settings.ConnectionString);
				lstDeptParinte.Items.Clear();
				utilDb.CreateDepartamenteSelectBox(0, 0, this.lstDeptParinte);

				//Daca pagina de administrare a fost deschisa din alta pagina cream functia care va face refresh la combo-ul cu departamente
				CreateRefreshFunction();

				ListareDepartamente();
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
		/// Sterge un departament
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnDelete_Click(object sender, System.EventArgs e)
		{
			try
			{
				int departamentId = Convert.ToInt32(txtDeptID.Value);
				AdminDepartament departament = new AdminDepartament();
				departament.DepartamentId = departamentId;
				int sePoateSterge = departament.CheckIfDepartamentCanBeDeleted();
				
				if (sePoateSterge == 1)
				{
					Response.Write("<script> alert('Departamentul nu poate fi sters! Este inca asociat unor angajati!'); </script>");
					FillEditForm();
					//Daca pagina de administrare a fost deschisa din alta pagina cream functia care va face refresh la combo-ul cu departamente
					CreateRefreshFunction();
				}
				if (sePoateSterge == 2)
				{
					Response.Write("<script> alert('Departamentul nu poate fi sters! Contine alte departamente!'); </script>");
					FillEditForm();
					//Daca pagina de administrare a fost deschisa din alta pagina cream functia care va face refresh la combo-ul cu departamente
					CreateRefreshFunction();
				}
				if (sePoateSterge == 3)
				{
					Response.Write("<script> alert('Operatiunea nu a fost efectuata deoarece nomenclatoul trebuie sa contina cel putin un departament.'); </script>");
					FillEditForm();
					//Daca pagina de administrare a fost deschisa din alta pagina cream functia care va face refresh la combo-ul cu departamente
					CreateRefreshFunction();
				}
				if (sePoateSterge == 0)
				{
					departament.DeleteDepartament();
					
					UtilitiesDb utilDb = new UtilitiesDb(settings.ConnectionString);
					lstDeptParinte.Items.Clear();
					utilDb.CreateDepartamenteSelectBox(0, 0, this.lstDeptParinte);

					//Daca pagina de administrare a fost deschisa din alta pagina cream functia care va face refresh la combo-ul cu departamente
					CreateRefreshFunction();

					ListareDepartamente();

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
		/// Revine la lista cu departamente
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnInapoi_Click(object sender, System.EventArgs e)
		{
			//Modificat: Oprescu Claudia
			//Descriere: Pagina care se apeleaza depinde de tipul actiune adica daca este parte de administrare sau parte de vizualizare departamente
			//			 Alegerea actiunii se face in functie de variabila de sesiune care se modifica in functie de optiunea selectata
			if (Session["administrare_departamente"].Equals("administrare_departamente"))	
			{
				Response.Redirect("Administrare.aspx?cmd=admin_departamente");
			}
			else
			{
				Response.Redirect("AdminDepartamenteIstoricDepartamente.aspx");
			}
		}
		#endregion
	}
}
