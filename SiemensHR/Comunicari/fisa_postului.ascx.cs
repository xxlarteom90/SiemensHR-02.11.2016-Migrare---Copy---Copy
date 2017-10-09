//Autor:Muntean Raluca Cristina
//Data: 18.11.2004
//Descriere: genereaza fisa postului pentru un anumit angajat

//	Modificat:	Lungu Andreea
//	Data:		21.08.2008
//	Descriere:	Datele reprezentantilor legali (manager general, director economic, manager hr) 
//              sunt aduse din baza de date la page_load si nu pot fi modificate decat de la angajator.


using System;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Text;

using Salaries.Data;
using SiemensHR.Classes;
using SiemensHR.utils;

namespace SiemensHR.Comunicari
{
	/// <summary>
	///		Summary description for fisa_postului.
	/// </summary>
	public class fisa_postului : System.Web.UI.UserControl
	{
		#region Variabile
		protected System.Web.UI.WebControls.Table Table2;
		protected System.Web.UI.WebControls.Button btnGenerati;
		
		protected Salaries.Business.Luni luni;
		protected Salaries.Data.LunaData lunaData;
		protected System.Web.UI.WebControls.TextBox txtDataInregistrarii;
		protected System.Web.UI.WebControls.Label lblDataInteg;
		protected System.Web.UI.WebControls.RequiredFieldValidator vldDataInreg;
		public Salaries.Business.Angajat objAngajat;
		protected System.Web.UI.WebControls.Label lblEroare;
		protected System.Web.UI.WebControls.ValidationSummary sumarValidare;
		protected System.Web.UI.WebControls.TextBox txtManagerGeneral;
		protected System.Web.UI.WebControls.TextBox txtManagerHR;
		//in cazul in care lipsesc date necesare generarii comunicarii sunt retinute in acest string 
		protected string dateNecesare="";
		#endregion

		#region Page_Load
		private void Page_Load(object sender, System.EventArgs e)
		{
			Salaries.Business.Luni luni;
			Salaries.Data.LunaData lunaData;

			if (objAngajat.IsLichidat)
			{
				btnGenerati.Enabled = false;
					
				lblEroare.Text = "Angajatul selectat este lichidat!";
			}
			
			// Este aflata luna activa
			luni = new Salaries.Business.Luni(objAngajat.AngajatorId);
			lunaData= luni.GetLunaActiva();

			// DataSet-ul cu numele tuturor angajatilor.
			objAngajat.CategorieId = -1;
			

			//header de tabel
			if (Session["Recrutori"].ToString() == "Recrutori")
			{
				Utilities.CreateTableHeader(Table2, "Fisa postului "+" "+lunaData.Data.Month.ToString()+" / "+lunaData.Data.Year.ToString(), "../", "normal");	
				Response.Write("<script> var TipUtilizator = 'Recrutor'; </script>");
			}
			else
			{
				Utilities.CreateTableHeader(Table2, "Fisa postului "+" "+lunaData.Data.Month.ToString()+" / "+lunaData.Data.Year.ToString(), "", "normal");	
				Response.Write("<script> var TipUtilizator = ''; </script>");
			}

			Salaries.Business.AdminAngajator adminAng = new Salaries.Business.AdminAngajator();
			adminAng.AngajatorId = Int32.Parse(Session["AngajatorId"].ToString());
			DataSet ds = adminAng.GetReprezLegali();
			foreach(DataRow dr in ds.Tables[0].Rows)
			{
				// Numele managerului general. 
				if (dr["NumeFunctie"].ToString().Equals("Manager general"))
					txtManagerGeneral.Text = dr["NumeReprez"].ToString() + " " + dr["PrenumeReprez"].ToString();
				// Numele directorului economic.
				if (dr["NumeFunctie"].ToString().Equals("Manager HR"))
					txtManagerHR.Text = dr["NumeReprez"].ToString() + " " + dr["PrenumeReprez"].ToString();
			}
			//Utilities.CreateTableHeader(Table2, "Fisa postului "+" "+lunaData.Data.Month.ToString()+" / "+lunaData.Data.Year.ToString(), "", "normal");	
		}
		#endregion
		
		#region generare comunicare
		private void btnGenerati_Click(object sender, System.EventArgs e)
		{
			//daca seGenereaza este true atunci angajatul este fie programator, fie manager de proiect 
			//si se va genera comunicarea,altfel nu se genereaza
			bool seGenereaza=false;

			//este introdus in sesiune tipul comunicarii
			//codul standard pentru functia de programator conform COR este 213202
			//codul standard pentru functia de manager de proiect informatic conform COR este 1 ??
			switch (objAngajat.FunctieCurentaCod.ToString())
			{
				case "213102":
					Session["TipComunicare"] = "fisa postului.xml";
					seGenereaza=true;
					break;
				case "1":
					Session["TipComunicare"] = "fisa manager pr.xml";
					seGenereaza=true;
					break;
			}
			if(seGenereaza)
			{
				if(ExistaToateDatele())
				{
					// Numele managerului general. 
					Session["ManagerGeneral"] = txtManagerGeneral.Text;
					// Numele managerului HR.
					Session["ManagerHR"] = txtManagerHR.Text;
					//data inregistrarii
					Session["DataInregistrarii"] = txtDataInregistrarii.Text;
				
					if (Session["Recrutori"].ToString() == "Recrutori")
					{
						Response.Redirect("../Comunicari/comunicare.aspx?id=" + objAngajat.AngajatId);
					}
					else
					{
						Response.Redirect("Comunicari/comunicare.aspx?id=" + objAngajat.AngajatId);
					}

					//este generata comunicarea
					lblEroare.Text = "Comunicarea a fost generata.";
				}
				else
				{
					char[] sep = {':'};//se stabileste separatorul
					Array aDate = dateNecesare.Split(sep);//se face impartirea in functie de separator
					string dateNecesareF="";
					for(int i=0;i<aDate.Length-2;i++)
						dateNecesareF+=aDate.GetValue(i).ToString()+", ";
					dateNecesareF+=aDate.GetValue(aDate.Length-2).ToString();

					lblEroare.Text="Pentru a genera fisa postului pentru acestui angajat trebuie sa mai completati urmatoarele campuri: "+dateNecesareF;
				}

			}
			else
				lblEroare.Text="Fisa postului se genereaza numai pentru angajatii"+
				" care au fie functia de programator, fie de manager de proiect informatic.";
		}
		#endregion
	
		#region se verifica daca exista toate datele necesare generarii comunicarii
		public bool ExistaToateDatele()
		{
			bool verificare=true;

			/*
			//se verifica daca exista vreun angajat cu functia de general manager
			GeneralManager gm = new GeneralManager();
			if(gm.Nume=="")
			{
				verificare=false;
				dateNecesare+=" un angajat in functia de general manager:";
			}
			*/
			//daca angajatul e programator
			if(objAngajat.FunctieCurentaCod=="213102")
			{
				//se verifica daca angajatul are sef
				if((objAngajat.SefId.ToString()=="0")||(objAngajat.SefId.ToString()==""))
				{
					verificare=false;
					dateNecesare+=" seful acestui angajat:";
				}
				/*
				//se verifica daca exista vreun angajat cu functia de inspector resurse umane
				InspectorResurseUmane iru = new InspectorResurseUmane();
				if(iru.Nume=="")
				{
					verificare=false;
					dateNecesare+=" un angajat in functia de inspector resurse umane:";
				}
				*/
			}
				//daca angajatul este manager de proiect informatic
			else
			{
				//se verifica daca angajatul are sef
				if(objAngajat.DepartamentCurentDenumire.ToString()=="")
				{
					verificare=false;
					dateNecesare+=" departamentul:";
				}
				/*
				//se verifica daca exista vreun angajat cu functia de manager HR
				ManagerHR mhr = new ManagerHR();
				if(mhr.Nume=="")
				{
					verificare=false;
					dateNecesare+=" un angajat in functia de manager HR:";
				}
				*/
			}
			return verificare;
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
			this.btnGenerati.Click += new System.EventHandler(this.btnGenerati_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion	
	}
}
