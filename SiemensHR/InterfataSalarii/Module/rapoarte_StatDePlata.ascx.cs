using System;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Data.SqlTypes;

using SiemensHR.utils;
using SiemensHR.Classes;

namespace SiemensHR.InterfataSalarii.Module
{
	/// <summary>
	///		Summary description for rapoarte_StatDePlata.
	/// </summary>
	public class rapoarte_StatDePlata : SiemensHR.InterfataSalarii.Classes.BaseModule
	{
		#region Variabile
		protected System.Web.UI.WebControls.ListBox lstMasuri;
		protected System.Web.UI.WebControls.Button btnAfiseaza;
		protected System.Web.UI.WebControls.ListBox lstSelectedMasuri;
		protected ReportingServices.ReportViewer rapStatPlata;
		protected Salaries.Configuration.ModuleSettings settings;
		protected SqlConnection conexiune;
		protected System.Web.UI.WebControls.TextBox TextBox1;
		protected System.Web.UI.WebControls.Label labelError;
		protected System.Web.UI.HtmlControls.HtmlInputHidden HiddenMask;
		#endregion

		#region Constrante
		// Numele cheii din web.config care contine calea catre serverul cu rapoartele.
		private const string STRING_URL = "rapoarteServerUrl";
		#endregion		

		#region Page_Load
		private void Page_Load(object sender, System.EventArgs e)
		{}
		#endregion

		#region OnPreRender
		protected override void OnPreRender(EventArgs e)
		{
			base.OnPreRender (e);
			try
			{
				Response.Write("<script> var listaMasuriID = '"+ this.lstMasuri.ClientID +"'</script>");
				Response.Write("<script> var listaMasuriSelectateID = '"+ this.lstSelectedMasuri.ClientID +"'</script>");
				Response.Write("<script> var SirID = '"+ this.HiddenMask.ClientID +"'</script>");
				settings = Salaries.Configuration.ModuleConfig.GetSettings();
				UtilitiesDb utilDb = new UtilitiesDb(settings.ConnectionString);	
				
				Salaries.Business.Salariu salarii = new Salaries.Business.Salariu();
				DataSet ds = salarii.GetCodareStatDePlata();
				this.HiddenMask.Value = ds.Tables[0].Rows[0][0].ToString();
			
				DataSet ds1 = salarii.GetCodareColoaneStatDePlata();
				
				//se obtin etichetele pentru retinerile din luna curenta
				Salaries.Business.TypesOfRestraints tr = new Salaries.Business.TypesOfRestraints();
				DataSet etichete = tr.GetLabels(int.Parse(this.GetCurrentMonth().ToString()));

				this.lstMasuri.Items.Clear();
				this.lstSelectedMasuri.Items.Clear();
				foreach (DataRow dc in ds1.Tables[0].Rows)
				{	
					string numeColoana = "";
					string cod = "";

					//daca coloana care se afiseaza nu este o retinere atunci se preiau datele din tabelul CodareStatDePlataDetaliat 
					if ( dc["NumeColoana"].ToString().IndexOf("Retinere_") == -1)
					{
						numeColoana = dc["NumeColoana"].ToString();
						cod = dc["Codare"].ToString();
					}
					else
					{
						//daca coloana este o retinere atunci codul este preluat din CodareStatDePlataDetaliat
						//iar numele coloanei este luat din tabela sal_RetineriEtichete
						cod = tr.GetCodRetinere(dc["NumeColoana"].ToString());
						for (int i=0; i<etichete.Tables[0].Rows.Count; i++)
						{	
							//numele retinerii trebuie sa coincida cu numele coloanei din tabela cu codificari
							if (dc["NumeColoana"].ToString() == etichete.Tables[0].Rows[i]["Nume"].ToString())
							{
								numeColoana = etichete.Tables[0].Rows[i]["Eticheta"].ToString();
							}
						}
					}

					//o retinere se adauga in lista numai daca este etichetata
					if (numeColoana != "")
					{
						if( this.HiddenMask.Value.IndexOf(cod) == -1 )
						{
							ListItem listItem = new ListItem(numeColoana, cod);
							this.lstMasuri.Items.Add(listItem);
						}

						if( this.HiddenMask.Value.IndexOf(cod) != -1 )
						{
							ListItem listItem = new ListItem(numeColoana, cod);
							this.lstSelectedMasuri.Items.Add(listItem);
						}
					}
				}
				this.rapStatPlata.ServerUrl = Salaries.Configuration.CryptographyClass.getSettingsWithoutDecode(STRING_URL);
				this.rapStatPlata.SetQueryParameter("AngajatorID",this.GetAngajator().ToString());
				this.rapStatPlata.SetQueryParameter("LunaID",this.GetCurrentMonth().ToString());
				this.rapStatPlata.SetQueryParameter("FieldMask",this.HiddenMask.Value);
			}
			catch(Exception ex)
			{
				this.labelError.Text = ex.Message;
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
			this.btnAfiseaza.Click += new System.EventHandler(this.btnAfiseaza_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region btnAfiseaza_Click
		/// <summary>
		/// Afiseaza raportul
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnAfiseaza_Click(object sender, System.EventArgs e)
		{
			try
			{
				Salaries.Business.Salariu salarii = new Salaries.Business.Salariu();
				salarii.UpdateTemplate(this.HiddenMask.Value);
			}
			catch(Exception ex)
			{
				this.labelError.Text = ex.Message;
			}
		}
		#endregion


	}
}
