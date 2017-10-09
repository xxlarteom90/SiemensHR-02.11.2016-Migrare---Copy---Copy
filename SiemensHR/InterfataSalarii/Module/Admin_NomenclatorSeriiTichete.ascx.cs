using System;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Configuration;

using SiemensHR.utils;
using SiemensHR.Classes;

namespace SiemensHR.InterfataSalarii.Module
{
	/// <summary>
	///		Aceasta clasa se mapeaza pe tabela "SeriiTichete". Cu ajutorul ei se realizeaza 
	///		managementul seriilor tichetelor.
	/// </summary>
	public class Admin_NomenclatorSeriiTichete : SiemensHR.InterfataSalarii.Classes.BaseModule
	{
		#region Variabile
		protected System.Web.UI.WebControls.Literal litError;
		protected System.Web.UI.WebControls.Table mainTable;
		protected System.Web.UI.WebControls.Table add_header;
		protected System.Web.UI.WebControls.Button btnSalveaza;
		protected System.Web.UI.WebControls.Button btnInapoi;
		protected System.Web.UI.WebControls.Button btnEdit;
		protected System.Web.UI.WebControls.ValidationSummary ValidationSummary1;
		protected System.Web.UI.HtmlControls.HtmlTable list_form;
		protected System.Web.UI.WebControls.RegularExpressionValidator regularCodBoala;
		protected System.Web.UI.WebControls.RequiredFieldValidator requiredCodBoala;
		protected System.Web.UI.WebControls.RequiredFieldValidator requiredCategorieBoala;
		protected System.Web.UI.HtmlControls.HtmlTable add_form;
		protected System.Web.UI.WebControls.Button btnSterge;

		protected Salaries.Configuration.ModuleSettings settings;

		protected bool VarExists = false;
		protected System.Web.UI.WebControls.Button btnAdauga;
		protected System.Web.UI.WebControls.TextBox txtInceputSerie;
		protected System.Web.UI.WebControls.TextBox txtSfarsitSerie;
		protected System.Web.UI.WebControls.TextBox txtSerieID;
		protected System.Web.UI.WebControls.RegularExpressionValidator Regularexpressionvalidator1;
		protected System.Web.UI.WebControls.DropDownList lstLunaSerie;
		protected bool EditMode = false;
		protected System.Web.UI.WebControls.DropDownList lstPunctLucru;
		Salaries.Data.LunaData lunaActiva;
		#endregion

		#region Page_Load
		/// <summary>
		///	Se initializeaza datele specifice paginii
		/// </summary>
		private void Page_Load( object sender, System.EventArgs e )
		{
			string script_text = "<script>var ctrlID = \""+this.ClientID+"\"</script>";
			Response.Write( script_text );
			litError.Text = "";
			
			btnEdit.Style.Add( "display", "none" );
			txtSerieID.Style.Add( "display", "none" );

			settings = Salaries.Configuration.ModuleConfig.GetSettings();
			UtilitiesDb utilDb = new UtilitiesDb( settings.ConnectionString );
					
			Salaries.Business.Luni luni = new Salaries.Business.Luni(this.GetAngajator());
			lunaActiva = luni.GetLunaActiva();
			BindComboLstLunaSerie(luni);
			BindPunctLucru();
	
			if( !IsPostBack )
			{
				this.btnSalveaza.Enabled = true;
			}
		}
		#endregion

		#region OnPreRender
		/// <summary>
		///	Aceasta metoda are ca scop setarea continutului paginii
		/// </summary>
		protected override void OnPreRender(EventArgs e)
		{
			base.OnPreRender (e);
			
			if (!this.EditMode )		
			{
				ListSerii();
			}
		}
		#endregion

		#region BindComboLstLunaSerie
		/// <summary>
		/// Este completat combobox-ul care contine lunile existente
		/// </summary>
		/// <param name="luni">Obiectul care contine lunile</param>
		private void BindComboLstLunaSerie( Salaries.Business.Luni luni )
		{
			this.lstLunaSerie.DataSource = luni.GetLuni();
			this.lstLunaSerie.DataValueField = "LunaID";
			this.lstLunaSerie.DataTextField = "Denumire";
			this.lstLunaSerie.DataBind();
		}
		#endregion

		#region bind punct lucru
		//Oprescu Claudia
		//se selecteaza punctele de lucru ale unui angajator
		private void BindPunctLucru()
		{
			Salaries.Business.AdminPunctLucru objAdminPunctLucru = new Salaries.Business.AdminPunctLucru();
			objAdminPunctLucru.AngajatorId = this.GetAngajator();
			lstPunctLucru.DataSource = objAdminPunctLucru.LoadInfoPunctLucruAngajator();
			lstPunctLucru.DataTextField = "Nume";
			lstPunctLucru.DataValueField = "PunctLucruID";
			lstPunctLucru.DataBind();
		}
		#endregion

		#region ListSerii
		/// <summary>
		///		Cu ajutorul metodei ListSerii se genereaza tabelul ce va fi afisat. 
		///		Acest tabel contine toate seriile existente in baza de date.
		/// </summary>
		private void ListSerii()
		{
			try
			{
				list_form.Style.Add("display","");
				add_form.Style.Add("display","none");
				btnSalveaza.Visible = false;
				btnInapoi.Visible = false;
				txtSerieID.Text = "0";

				TableRow myRow = new TableRow();
				TableCell myCell = new TableCell();
				
				//titlul de la listare
				myCell.CssClass = "BigBlueBold";
				myCell.HorizontalAlign = HorizontalAlign.Center;
				myCell.VerticalAlign = VerticalAlign.Middle;
				myCell.Text = "Nomenclator intervale serii tichete";
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

				string[] tableHeader = { "Inceput serie", "Sfarsit serie", "Luna", "Punct de lucru"};
				string[] tableCols = { "SerieInceput", "SerieSfarsit", "DenumireLuna", "PunctLucru"};
				ListTable objListTable = new ListTable(listTable, new Salaries.Business.NomenclatorSeriiTichete().GetSeriiTichete(), tableHeader, tableCols);

				objListTable.textForEmptyDataSet = "Nu exista date in nomenclatorul de serii tichete!";

				string[] ar_OnClickParam = { "SerieID" };
				string[] ar_OnClickParamType = { "dataset" };

				objListTable.OnclickJSMethod = "SelectSerie";
				objListTable.OnclickParams = ar_OnClickParam;
				objListTable.OnclickParamsType = ar_OnClickParamType;
				objListTable.DrawListTableWithoutDigits();                				

				myCell.Controls.Add(listTable);
				myRow.Cells.Add(myCell);
				mainTable.Rows.Add(myRow);
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
			this.btnAdauga.Click += new System.EventHandler(this.btnAdaugaCategorie_Click);
			this.btnSalveaza.Click += new System.EventHandler(this.btnSalveaza_Click);
			this.btnSterge.Click += new System.EventHandler(this.btnSterge_Click);
			this.btnInapoi.Click += new System.EventHandler(this.btnInapoi_Click);
			this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region btnInapoi_Click
		/// <summary>
		///		Eveniment specific apasarii butonului de "Inapoi" din fereastra de editare.
		/// </summary>
		private void btnInapoi_Click(object sender, System.EventArgs e)
		{
			this.EditMode=false;
		}
		#endregion

		#region btnSalveaza_Click
		/// <summary>
		///		Metoda care se apeleaza la apasarea butonului de salvare din fereastra de editare.
		///		Se selecteaza optiunea de Update sau Insert cu datele aferente.
		/// </summary>
		private void btnSalveaza_Click(object sender, System.EventArgs e)
		{
			try
			{
				this.VarExists = new Salaries.Business.NomenclatorSeriiTichete().GetSeriiTichete( int.Parse(this.txtSerieID.Text) ).Tables[0].Rows.Count>0;
				Salaries.Data.SeriiTichete serii = new Salaries.Data.SeriiTichete();

				serii.SerieInceput = long.Parse(this.txtInceputSerie.Text);
				serii.SerieSfarsit = long.Parse(this.txtSfarsitSerie.Text);
				serii.LunaID = int.Parse(this.lstLunaSerie.SelectedValue);
				serii.PunctLucruID = int.Parse(this.lstPunctLucru.SelectedValue);
			    serii.SerieId = (this.VarExists) ? int.Parse( this.txtSerieID.Text ) : -1;
				
				//se verifica mai intai daca nu exista o boala cu aceleasi date
				bool adauga = new Salaries.Business.NomenclatorSeriiTichete().CheckIfSeriiTicheteCanBeAdded(serii.SerieId, serii.SerieInceput, serii.SerieSfarsit, serii.LunaID, serii.PunctLucruID);
				if (adauga)
				{
					if( this.VarExists )
					{
						new Salaries.Business.NomenclatorSeriiTichete().UpdateSeriiTichete( serii );
					}
					else 
					{
						new Salaries.Business.NomenclatorSeriiTichete().AddSeriiTichete( serii );
					}
				}
				else
				{
					//daca exista se va afisa un mesaj de avertizare
					Response.Write("<script> alert('Mai exista un interval de serii cu aceste date!'); </script>");
				}
				this.EditMode = false;//adaugat de vlad
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
		///		Metoda care se apeleaza cand se doreste adaugarea unei noi boli sau 
		///		editarea uneia existente.
		/// </summary>
		private void btnEdit_Click(object sender, System.EventArgs e)
		{
			this.EditMode=true;
			this.VarExists = new Salaries.Business.NomenclatorSeriiTichete().GetSeriiTichete( int.Parse(this.txtSerieID.Text) ).Tables[0].Rows.Count>0;
			try
			{
				if( this.VarExists )
				{
					int serieId = Convert.ToInt32( txtSerieID.Text );
					Salaries.Data.SeriiTichete serii  = new Salaries.Business.NomenclatorSeriiTichete().GetDetalii( int.Parse(this.txtSerieID.Text) );
			
					this.txtInceputSerie.Text = serii.SerieInceput.ToString();
					this.txtSfarsitSerie.Text = serii.SerieSfarsit.ToString();
					this.lstLunaSerie.SelectedValue = serii.LunaID.ToString();
					this.lstPunctLucru.SelectedValue = serii.PunctLucruID.ToString();
					if (lunaActiva.LunaId == serii.LunaID)
					{
						this.btnSterge.Visible = true;
						this.btnSalveaza.Visible = true;
						this.txtInceputSerie.Enabled = true;
						this.txtSfarsitSerie.Enabled = true;
						this.lstPunctLucru.Enabled = true;
						this.lstLunaSerie.Enabled = false;
					}
					else
					{
						this.btnSterge.Visible = false;
						this.btnSalveaza.Visible = false;
						this.lstLunaSerie.Enabled = false;
						this.lstPunctLucru.Enabled = false;
						this.txtInceputSerie.Enabled = false;
						this.txtSfarsitSerie.Enabled = false;
					}
				}
				else
				{
					this.txtInceputSerie.Text = "";
					this.txtSfarsitSerie.Text = "";
					this.lstLunaSerie.SelectedIndex = 0;
					this.btnSterge.Visible = false;
					this.btnSalveaza.Visible = true;
					this.lstLunaSerie.SelectedIndex = 0;
					this.lstLunaSerie.Enabled = false;
					this.lstPunctLucru.SelectedIndex = 0;
					this.lstPunctLucru.Enabled = true;
					this.txtInceputSerie.Enabled = true;
					this.txtSfarsitSerie.Enabled = true;
				}
				list_form.Style.Add("display","none");
				add_form.Style.Add("display","");
				//btnSalveaza.Visible = true;
				btnInapoi.Visible = true;
			
				this.btnSalveaza.Enabled = true;
				
				Utilities.CreateTableHeader(add_header, "Nomenclator intervale serii tichete", "../", "small");
			}
			catch (Exception ex)
			{
				litError.Text = "The following error occurred: <br>";
				litError.Text += ex.Message;
			}
		}
		#endregion

		#region btnAdaugaCategorie_Click
		/// <summary>
		///		Metoda specifica pt apasarea butonului de adaugare.
		/// </summary>
		private void btnAdaugaCategorie_Click(object sender, System.EventArgs e)
		{
			try
			{			
				btnEdit_Click( sender, e );
			}
			catch (Exception ex)
			{
				litError.Text = "The following error occurred: <br>";
				litError.Text += ex.Message;
			}
		}
		#endregion

		#region btnSterge_Click
		/// <summary>
		///		Metoda specifica pt apasarea butonului de stergere.
		/// </summary>
		private void btnSterge_Click(object sender, System.EventArgs e)
		{
			try
			{
				int serieId = Convert.ToInt32( txtSerieID.Text );
				int sePoateSterge = new Salaries.Business.NomenclatorSeriiTichete().CheckIfSeriiTicheteCanBeDeleted(serieId);

				if (sePoateSterge == 0)
				{
					new Salaries.Business.NomenclatorSeriiTichete().DeleteSeriiTichete(serieId);
				}
				if (sePoateSterge == 1)
				{
					Response.Write("<script> alert('Aceast interval de serii nu poate fi stears pentru ca el este dintr-o luna anterioara!'); </script>");
				}
//				if (sePoateSterge == 2)
//				{
//					Response.Write("<script>alert('Operatiunea nu a fost efectuata deoarece nomenclatoul trebuie sa contina cel putin o boala.');</script>");
//				}
			}
			catch (Exception ex)
			{
				litError.Text = "The following error occurred: <br>";
				litError.Text += ex.Message;
			}
		}
		#endregion
	}
}
