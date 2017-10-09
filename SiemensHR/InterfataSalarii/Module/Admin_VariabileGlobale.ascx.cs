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
	/// Clasa se ocupa cu gestiunea variabilelor globale.Cu ajutorul ei se realizeaza 
	///		managementul nomenclatorului de variabile globale.
	/// </summary>
	public class Admin_VariabileGlobale : SiemensHR.InterfataSalarii.Classes.BaseModule
	{
		#region Variabile
		public int AngajatorID;
		public int lunaId;
		protected Salaries.Configuration.ModuleSettings settings;
		protected System.Web.UI.WebControls.Table add_header;
		protected System.Web.UI.WebControls.RequiredFieldValidator requiredProcent;
		protected System.Web.UI.WebControls.Button btnSalveaza;
		protected System.Web.UI.WebControls.Button btnInapoi;
		protected System.Web.UI.WebControls.Button btnEdit;
		protected System.Web.UI.WebControls.ValidationSummary ValidationSummary1;
		protected System.Web.UI.HtmlControls.HtmlTable list_form;
		protected System.Web.UI.HtmlControls.HtmlTable add_form;
		protected System.Web.UI.WebControls.Button btnAdaugaVariabilaGlobala;
		protected System.Web.UI.WebControls.DropDownList drpPerioada;
		protected System.Web.UI.WebControls.Literal litError;

		protected bool VarExists = false;
		protected System.Web.UI.WebControls.TextBox txtValoare;
		protected System.Web.UI.WebControls.Table mainTable;
		protected System.Web.UI.WebControls.TextBox txtVariabilaGlobalaID;
		protected System.Web.UI.WebControls.DropDownList drpTipVariabila;
		protected System.Web.UI.WebControls.RequiredFieldValidator requiredTipVariabila;
		protected System.Web.UI.WebControls.RequiredFieldValidator requiredValoare;
		protected System.Web.UI.HtmlControls.HtmlTable valoriTable;
		protected System.Web.UI.WebControls.Label lblToateTipurile;
		protected System.Web.UI.WebControls.RangeValidator rngVldValoare;
		protected bool EditMode = false;
		#endregion

		#region Page_Load
		private void Page_Load(object sender, System.EventArgs e)
		{
			//se populeaza combobox cu toate perioadele existente din care utilizatorul selecteaza
			Salaries.Business.VariabileGlobaleValori objVariabilaGlobala = new Salaries.Business.VariabileGlobaleValori();
			DataSet ds = objVariabilaGlobala.GetLuniVariabileGlobale();
			if (drpPerioada.Items.Count == 0)
			{
				foreach(DataRow row in ds.Tables["GetLuniVariabileGlobale"].Rows)
				{
					ListItem NewItem = new ListItem();
					NewItem.Text = row["Luna"].ToString();
					NewItem.Value = row["LunaID"].ToString();
					drpPerioada.Items.Add(NewItem);
					//se selecteaza ultima valoare pentru ca aceasta este luna curenta si se vor incarca implicit valorile
					//variabilelor globale din luna curenta
					drpPerioada.SelectedIndex = drpPerioada.Items.Count-1;
				}
			}

			string script_text = "<script>var ctrlID = \""+this.ClientID+"\"</script>";
			Response.Write( script_text );
			litError.Text = "";
			
			btnEdit.Style.Add( "display", "none" );
			txtVariabilaGlobalaID.Style.Add( "display", "none" );

			settings = Salaries.Configuration.ModuleConfig.GetSettings();
			UtilitiesDb utilDb = new UtilitiesDb( settings.ConnectionString );			
						
			if( !IsPostBack )
			{
				this.btnSalveaza.Enabled = true;
				//daca nu este modul editabil, se selecteaza toate tipurile da variabile globale care nu au fost inca adaugate pentru luna curenta
				if (!EditMode)
				{
					//se populeaza combobox-ul
					LoadTipVariabile();
					drpPerioada.Enabled = true;
					//daca exista cel putin un tip de variabila care nu a fost adaugat apare butonul pentru adaugare
					if (drpTipVariabila.Items.Count > 0)
					{
						drpTipVariabila.SelectedIndex = 0;
						btnAdaugaVariabilaGlobala.Visible = true;
					}
					//altfel butonul pentru adaugare nu apare si deci nu se pot adauga valori pentru variabile
					else
					{
						btnAdaugaVariabilaGlobala.Visible = false;
					}
				}
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
			this.drpPerioada.SelectedIndexChanged += new System.EventHandler(this.drpPerioada_SelectedIndexChanged);
			this.btnAdaugaVariabilaGlobala.Click += new System.EventHandler(this.btnAdauga_Click);
			this.btnSalveaza.Click += new System.EventHandler(this.btnSalveaza_Click);
			this.btnInapoi.Click += new System.EventHandler(this.btnInapoi_Click);
			this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region OnPreRender
		protected override void OnPreRender(EventArgs e)
		{
			base.OnPreRender (e);
			
			//daca nu este in modul de editare se listeaza variabilele deja introduse
			if (!this.EditMode )		
			{
				LoadVariabileGlobaleList();
			}
		}
		#endregion

		#region LoadTipVariabile
		/// <summary>
		/// Listarea tipurilor de variabile pentru care nu au fost inca adaugate valori
		/// </summary>
		private void LoadTipVariabile()
		{
			//se goleste combobox cu tipuri
			drpTipVariabila.Items.Clear();
			Salaries.Business.VariabileGlobale objVariabilaGlobala = new Salaries.Business.VariabileGlobale();
			//se selecteaza din baza de date acele tipuri pentru care nu au fost adaugate valori
			DataSet dset = objVariabilaGlobala.GetAllVariabileGlobaleNeadaugate(int.Parse(drpPerioada.SelectedValue));
			foreach(DataRow row in dset.Tables["AllVariabileGlobaleNeadaugate"].Rows)
			{
				//se adauga in lista tipurile de variabile
				ListItem NewItem = new ListItem();
				NewItem.Text = row["Denumire"].ToString();
				NewItem.Value = row["VariabilaGlobalaID"].ToString();
				drpTipVariabila.Items.Add(NewItem);
			}
		}
		#endregion

		#region LoadVariabileGlobaleList
		/// <summary>
		/// Listarea valorilor pentru variabilele globale
		/// </summary>
		private void LoadVariabileGlobaleList()
		{
			try
			{
				list_form.Style.Add("display","");
				add_form.Style.Add("display","none");
				btnSalveaza.Visible = false;
				btnInapoi.Visible = false;
				txtVariabilaGlobalaID.Text = "0";

				TableRow myRow = new TableRow();
				TableCell myCell = new TableCell();
				
				//titlul de la listare
				myCell.CssClass = "BigBlueBold";
				myCell.HorizontalAlign = HorizontalAlign.Center;
				myCell.VerticalAlign = VerticalAlign.Middle;
				myCell.Text = "Lista variabile salarizare";
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
			
				string[] arHeader = {"Tip constanta", "Valoare"};
				string[] arCols = {"Denumire", "Valoare"};
			
				//id-ul lunii curente
				lunaId = this.GetCurrentMonth();

				Salaries.Business.Luni luni=new Salaries.Business.Luni(this.AngajatorID,lunaId);
				
				//anul selectat de utilizator
				int luna=int.Parse(drpPerioada.SelectedItem.Value);
				
				//returneaza lunile din anul dat ca parametru pentru care sunt calculate salariile 
				Salaries.Business.VariabileGlobaleValori objVariabilaGlobala = new Salaries.Business.VariabileGlobaleValori();
				DataSet ds = objVariabilaGlobala.GetAllVariabileGlobaleValoriPeLuna(luna);

				ListTable objListTable = new ListTable(listTable, ds, arHeader, arCols);
				objListTable.textForEmptyDataSet= "Nu exista date!";
	
				string[] ar_OnClickParam = { "ID" };
				string[] ar_OnClickParamType = { "dataset" };

				objListTable.OnclickJSMethod = "SelectVariabilaGlobala";
				objListTable.OnclickParams = ar_OnClickParam;
				objListTable.OnclickParamsType = ar_OnClickParamType;
				objListTable.DrawListTableWithDigits();                				

				myCell.Controls.Add(listTable);
				myRow.Cells.Add(myCell);
				mainTable.Rows.Add(myRow);
			}
			catch(Exception ex)
			{
				litError.Text = "The following error occurred: <br>";
				litError.Text += ex.Message;
			}	
		}
		#endregion

		#region btnInapoi_Click
		/// <summary>
		/// Revine la lista cu variabile globale
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnInapoi_Click(object sender, System.EventArgs e)
		{
			this.EditMode=false;
			drpPerioada.Enabled = true;
			//daca nu s-a selectat ultima valoare din lista atunci ea nu este luna curenta
			if (drpPerioada.SelectedIndex != drpPerioada.Items.Count-1)
			{
				//butonul pentru adaugare de valori dispare pentru ca nu se mai pot adauga valori pentru luni precedente
				this.btnAdaugaVariabilaGlobala.Visible = false;
			}
				//daca s-a selectat luna curenta
			else
			{
				//sunt listate tipurile de variabile care se mai pot adauga
				LoadTipVariabile();
				if (drpTipVariabila.Items.Count > 0)
				{
					//se selecteaza primul tip de variabila din lista
					//apare butonul pentru adaugare
					drpTipVariabila.SelectedIndex = 0;
					btnAdaugaVariabilaGlobala.Visible = true;
				}
					//daca nu se mai pot adauga variabile atunci dispare butonul pentru adaugare
				else
				{
					btnAdaugaVariabilaGlobala.Visible = false;
				}
			}
		}
		#endregion

		#region btnSalveaza_Click
		/// <summary>
		/// Salvarea unei valori pentru o variabile globala
		/// </summary>									
		private void btnSalveaza_Click(object sender, System.EventArgs e)
		{
			try
			{
				//se selecteaza din baza de date informatiile despre variabila selectata
				VariabileGlobaleValori objVariabileGlobaleValori = new  VariabileGlobaleValori();
				this.VarExists = objVariabileGlobaleValori.GetVariabileGlobaleValoriInfo(int.Parse(this.txtVariabilaGlobalaID.Text));
				//se determina luna curenta
				Luni luni = new Luni(this.GetAngajator());
				lunaId = luni.GetLunaActiva().LunaId;

				//se completeaza controalele cu valorile existente
				objVariabileGlobaleValori.VariabilaGlobalaID = int.Parse(this.drpTipVariabila.SelectedValue);
				objVariabileGlobaleValori.Valoare = float.Parse(this.txtValoare.Text);
				objVariabileGlobaleValori.LunaID = lunaId;
				objVariabileGlobaleValori.ID = (this.VarExists) ? int.Parse( this.txtVariabilaGlobalaID.Text ) : -1;

				//daca variabila exista deja atunci se actiualizeaza cu noile valori
				if( this.VarExists )
				{
					objVariabileGlobaleValori.Update();
				}
				//daca variabila nu exista se adauga
				else 
				{
					objVariabileGlobaleValori.Insert();
				}
				this.EditMode = false;
				drpPerioada.Enabled = true;
				drpTipVariabila.Enabled = true;

				if (!EditMode)
				{
					//se determina lista cu tipuri de variabile care mai trebuie adaugate
					LoadTipVariabile();
					//daca mai exista atunci ramane butonul pentru adaugare si se selecteaza primul tip de variabila
					if (drpTipVariabila.Items.Count > 0)
					{
						drpTipVariabila.SelectedIndex = 0;
						btnAdaugaVariabilaGlobala.Visible = true;
					}
					//daca nu mai exista variabile dispare butonul pentru adaugare
					else
					{
						btnAdaugaVariabilaGlobala.Visible = false;
					}
				}
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
		/// Editarea unei valori pentru o variabila globala
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnEdit_Click(object sender, System.EventArgs e)
		{
			//se stabileste modul de editare
			this.EditMode=true;
			//se selecteaza variabila care se editeaza
			VariabileGlobaleValori objVariabileGlobaleValori = new  VariabileGlobaleValori();
			this.VarExists = objVariabileGlobaleValori.GetVariabileGlobaleValoriInfo(int.Parse(this.txtVariabilaGlobalaID.Text));
			try
			{
				//daca exista aceasta variabila
				if( this.VarExists )
				{
					//se completeaza controalele cu valorile existente
					int VariabilaGlobalaID = Convert.ToInt32( txtVariabilaGlobalaID.Text );
					objVariabileGlobaleValori.GetVariabileGlobaleValoriInfo(int.Parse(this.txtVariabilaGlobalaID.Text));
					
					this.drpTipVariabila.Items.Clear();
					this.drpTipVariabila.Items.Add(new ListItem(objVariabileGlobaleValori.Denumire, objVariabileGlobaleValori.VariabilaGlobalaID.ToString() ));
					this.drpTipVariabila.SelectedIndex = 0;
					this.drpTipVariabila.Enabled = false;
					this.txtValoare.Text = objVariabileGlobaleValori.Valoare.ToString("N",Salaries.Business.VariabileGlobale.numberInfoFormatWithDigits);
				}
				//daca variabila nu exista controalele raman goale
				else
				{
					this.drpTipVariabila.Items.Clear();
					this.txtValoare.Text = "";
				}
				//perioada pentru care se vizualizeaza valorile nu mai poate fi schimbata
				this.drpPerioada.Enabled = false;
				//daca nu s-a selectat luna curenta
				if (drpPerioada.SelectedIndex != drpPerioada.Items.Count-1)
				{
					//cvalorile nu pot fi modificate
					this.txtValoare.ReadOnly = true;
					this.btnSalveaza.Visible = false;
				}
				//daca s-a selectat luna curenta
				else
				{
					//se pot modifica valorile pentru variabila
					this.txtValoare.ReadOnly = false;
					this.btnSalveaza.Visible = true;
				}
				list_form.Style.Add("display","none");
				add_form.Style.Add("display","");
				btnInapoi.Visible = true;
				
				Utilities.CreateTableHeader(add_header, "Variabile salarizare", "../", "small");

			}
			catch (Exception ex)
			{
				litError.Text = "The following error occurred: <br>";
				litError.Text += ex.Message;
			}
		}
		#endregion

		#region btnAdauga_Click
		/// <summary>
		/// Adaugarea unei valori pentru variabila globala
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnAdauga_Click(object sender, System.EventArgs e)
		{
			try
			{			
				btnEdit_Click( sender, e );
				//se obtin tipurile de variabile pentru care mai trebuie sa se adauge valori
				LoadTipVariabile();
				//daca exista cel putin un tip
				if (drpTipVariabila.Items.Count > 0)
				{
					//se selecteaza primul tip de variabila
					//apare butonul pentru adaugare
					drpTipVariabila.SelectedIndex = 0;
					btnAdaugaVariabilaGlobala.Visible = true;
				}
				//daca nu exista tipuri pentru care sa se adauge valori
				else
				{
					//nu mai apare butonul pentru adaugare
					btnAdaugaVariabilaGlobala.Visible = false;
				}
				//perioada de vizualizare nu poate fi modificata
				drpPerioada.Enabled = false;
				//tipul variabilei se poate modifica
				drpTipVariabila.Enabled = true;
			}
			catch (Exception ex)
			{
				litError.Text = "The following error occurred: <br>";
				litError.Text += ex.Message;
			}
		}
		#endregion

		#region drpPerioada_SelectedIndexChanged
		/// <summary>
		/// Selectarea unei perioade de vizualizare a variabilelor
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void drpPerioada_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			//daca nu s-a selectat ultima valoare din lista atunci ea nu este luna curenta
			if (drpPerioada.SelectedIndex != drpPerioada.Items.Count-1)
			{
				//butonul pentru adaugare de valori dispare pentru ca nu se mai pot adauga valori pentru luni precedente
				this.btnAdaugaVariabilaGlobala.Visible = false;
			}
			//daca s-a selectat luna curenta
			else
			{
				//sunt listate tipurile de variabile care se mai pot adauga
				LoadTipVariabile();
				if (drpTipVariabila.Items.Count > 0)
				{
					//se selecteaza primul tip de variabila din lista
					//apare butonul pentru adaugare
					drpTipVariabila.SelectedIndex = 0;
					btnAdaugaVariabilaGlobala.Visible = true;
				}
				//daca nu se mai pot adauga variabile atunci dispare butonul pentru adaugare
				else
				{
					btnAdaugaVariabilaGlobala.Visible = false;
				}
			}
		}
		#endregion
	}
}
