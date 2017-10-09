using System;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;

namespace SiemensHR.EditTasks
{
	/// <summary>
	///		Summary description for EditComboAngajatiDinCautare.
	/// </summary>
	public class EditComboAngajatiDinCautare : System.Web.UI.UserControl
	{
		#region Variabile
		protected System.Web.UI.WebControls.Label lblErr;
		protected System.Web.UI.WebControls.DropDownList drpNumeAngajat;
		protected System.Web.UI.WebControls.Label labelAngajatCurent;
		protected Salaries.Configuration.ModuleSettings settings;
		protected string tipAlerta;
		#endregion

		#region Page_Load
		private void Page_Load(object sender, System.EventArgs e)
		{
			tipAlerta = Request.QueryString["alerta"];

			if(!IsPostBack)
			{
				//daca expira variabilele de sesiune apar erori cand se preiau dataset-urile din variabile
				DataSet dsAngajati = new DataSet();
				
				try
				{
					drpNumeAngajat.Items.Clear();

					bool mode;
					switch(tipAlerta)
					{
						//Daca s-a ajuns in pagina de editare a unui angajat dand click pe numele angajatului in tabelul cu angajatii carora le expira 
						//contractul in luna curenta, atunci in dropdownlist se vor "incarca" numele angajatilor care corespund acestui criteriu.
						case "contract":
										dsAngajati = (DataSet)Session["DataSource_Contract"];
										mode=false;
										break;
						//Daca s-a ajuns in pagina de editare a unui angajat dand click pe numele angajatului in tabelul cu angajatii pentru care exista
						//alerte speciale, atunci in dropdownlist se vor "incarca" numele angajatilor care corespund acestui criteriu.
						case "speciala":
									dsAngajati = (DataSet)Session["DataSource_AlerteSpeciale"];
									mode=false;
									break;
						//Daca s-a ajuns in pagina de editare a unui angajat dand click pe numele angajatului in tabelul cu angajatii pentru care este 
						//planificata o majorare, atunci in dropdownlist se vor "incarca" numele angajatilor care corespund acestui criteriu.
						case "majorare":
									dsAngajati = (DataSet)Session["DataSource_Majorare"];
									mode=false;
									break;
						//Daca s-a ajuns in pagina de editare a unui angajat dand click pe numele angajatului in tabelul cu angajatii carora le expira 
						//pasaportul, atunci in dropdownlist se vor "incarca" numele angajatilor care corespund acestui criteriu.
						case "pasaport":
									dsAngajati = (DataSet)Session["DataSource_Pasaport"];
									mode=false;
									break;
						//Daca s-a ajuns in pagina de editare a unui angajat dand click pe numele angajatului in tabelul cu angajatii carora le expira 
						//permisul de munca, atunci in dropdownlist se vor "incarca" numele angajatilor care corespund acestui criteriu.
						case "permis_munca":
									dsAngajati = (DataSet)Session["DataSource_PermisMunca"];
									mode=false;
									break;
						//Daca s-a ajuns in pagina de editare a unui angajat dand click pe numele angajatului in tabelul cu angajatii carora le expira
						//permisul de sedere, atunci in dropdownlist se vor "incarca" numele angajatilor care corespund acestui criteriu.
						case "permis_sedere":
									dsAngajati = (DataSet)Session["DataSource_PermisSedere"];
									mode=false;
									break;
						//Daca se editeaza un angajat imediat ce acesta a fost introdus
						case "edit_angajat":
									dsAngajati = (DataSet)Session["DataSource_EditAngajat"];
									mode=false;	
									break;
						//Daca parametrul nu are nici o valoare, inseamna ca s-a ajuns in partea de editare prin cautare. In acest caz se "incarca" in 
						//dropdownlist numele obtinute in urma cautarii.
						default:
										dsAngajati = (DataSet)Session["DataSource_searchList"];
										mode=true;
										break;
					}
					foreach(DataRow dr in dsAngajati.Tables[0].Rows)
					{
						ListItem angajatItem;

						if(mode)
							angajatItem = new ListItem(dr["Nume"].ToString()+" "+dr["Prenume"].ToString(), dr["AngajatID"].ToString());
						else
							angajatItem = new ListItem(dr["NumeIntreg"].ToString(), dr["AngajatID"].ToString());

						drpNumeAngajat.Items.Add(angajatItem);
					}
					
					drpNumeAngajat.SelectedValue = Request.QueryString["id"].ToString();
					
				}
				catch(Exception ex)
				{
					lblErr.Text = ex.Message;
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
			this.drpNumeAngajat.SelectedIndexChanged += new System.EventHandler(this.drpNumeAngajat_SelectedIndexChanged);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region drpNumeAngajat_SelectedIndexChanged
		/// <summary>
		/// Procedura afiseaza datele angajatului selectat
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void drpNumeAngajat_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			try
			{
				//daca este selectat un alt angajat, utilizatorul este redirectat catre pagina de editare corespunzatoare angajatului selectat
				if (Session["Recrutori"].ToString() == "Recrutori")
				{
					if(tipAlerta==null)
						Response.Redirect("EditAngajat_Recrutori.aspx?id=" + drpNumeAngajat.SelectedItem.Value.ToString());
					else
						Response.Redirect("EditAngajat_Recrutori.aspx?id=" + drpNumeAngajat.SelectedItem.Value.ToString()+"&alerta="+tipAlerta);
				}
				else
				{
					if(tipAlerta==null)
						Response.Redirect("EditAngajat.aspx?id=" + drpNumeAngajat.SelectedItem.Value.ToString());
					else
						Response.Redirect("EditAngajat.aspx?id=" + drpNumeAngajat.SelectedItem.Value.ToString()+"&alerta="+tipAlerta);
				}
			}
			catch(Exception ex)
			{
				lblErr.Text = ex.Message+" 2";
			}
		}
		#endregion
	}
}
