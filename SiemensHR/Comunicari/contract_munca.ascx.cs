//Autor: Muntean Raluca Cristina
//Data: 7.01.2005
//Descriere: Este generat contractul individual de munca al unui angajat

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
	///		Summary description for contract_munca.
	/// </summary>
	public class contract_munca : System.Web.UI.UserControl
	{
		#region Variabile
		protected System.Web.UI.WebControls.Table Table2;
		protected System.Web.UI.WebControls.Button btnGenerati;
		protected System.Web.UI.WebControls.Label lblEroare;

		//angajat
		public Salaries.Business.Angajat objAngajat;
		protected System.Web.UI.WebControls.TextBox txtManagerGeneral;
		protected System.Web.UI.WebControls.TextBox txtManagerHR;
		protected System.Web.UI.WebControls.TextBox txtDirectorEconomic;
		// In acest string sunt retinute toate datele campurile necesare generarii contractului care nu au fost completate
		string dateNecesare="";
		#endregion

		#region Page_Load
		private void Page_Load(object sender, System.EventArgs e)
		{
			Salaries.Business.Luni luni;
			Salaries.Data.LunaData lunaData;

			if (objAngajat.IsLichidat)
			{
				btnGenerati.Enabled = false;
				txtManagerGeneral.Enabled = false;
				txtManagerHR.Enabled = false;
				
				lblEroare.Text = "Angajatul selectat este lichidat!";
			}
			
			// Este aflata luna activa
			luni = new Salaries.Business.Luni(objAngajat.AngajatorId);
			lunaData= luni.GetLunaActiva();

			// DataSet-ul cu numele tuturor angajatilor.
			objAngajat.CategorieId = -1;

			Salaries.Business.AdminAngajator adminAng = new Salaries.Business.AdminAngajator();
			adminAng.AngajatorId = Int32.Parse(Session["AngajatorId"].ToString());
			DataSet ds = adminAng.GetReprezLegali();
			foreach(DataRow dr in ds.Tables[0].Rows)
			{
				// Numele managerului general. 
				if (dr["NumeFunctie"].ToString().Equals("Manager general"))
					txtManagerGeneral.Text = dr["NumeReprez"].ToString() + " " + dr["PrenumeReprez"].ToString();
				// Numele directorului economic.
				if (dr["NumeFunctie"].ToString().Equals("Director economic"))
					txtDirectorEconomic.Text = dr["NumeReprez"].ToString() + " " + dr["PrenumeReprez"].ToString();
				// Numele managerului HR.
				if (dr["NumeFunctie"].ToString().Equals("Manager HR"))
					txtManagerHR.Text = dr["NumeReprez"].ToString() + " " + dr["PrenumeReprez"].ToString();
			}
			// header de tabel
			Utilities.CreateTableHeader(Table2, "Contract individual de munca ","", "normal");	
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

		#region butonul de generare a contractului
		private void btnGenerati_Click(object sender, System.EventArgs e)
		{
			if(ExistaToateDatele())
			{
				//sunt introduse in sesiune data inregistrarii contractului, numarul contractului precum si restul 
				//datelor cerute de la utilizator
				if(objAngajat.Sex=="m")
					Session["TipComunicare"] = "contractMunca_b.xml";
				else
					Session["TipComunicare"] = "contractMunca_f.xml";
				
				// Numele managerului general. 
				Session["ManagerGeneral"] = txtManagerGeneral.Text;
				// Numele managerului general. 
				Session["ManagerHR"] = txtManagerHR.Text;
				// Numele director economic. 
				Session["DirectorEconomic"] = txtDirectorEconomic.Text; //andreea - 19.07.2012
				
				Response.Redirect("Comunicari/comunicare.aspx?id=" + objAngajat.AngajatId);

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

				lblEroare.Text= "Pentru generarea contractului individual de munca "+
							"pentru acest angajat mai aveti nevoie de urmatoarele date:"+dateNecesareF;
			}
		}
		#endregion

		#region se verifica daca au fost completate toate datele necesare generarii contractului
		public bool ExistaToateDatele()
		{
			bool verificare=true;;
			if(objAngajat.NrContractMunca.ToString()=="")
			{
				verificare=false;
				dateNecesare+=" numar contract de munca:";
			}

			//se verifica nationalitatea angajatului
			//in cazul in care angajatul este cetatean strain se mai verifica niste campuri daca sunt completate
			int nationalitate = objAngajat.Nationalitate;
			
			int idTaraDeBaza=0;
			//practic DataSet-ul returneaza un singur rand
			Salaries.Business.AdminTari tari = new Salaries.Business.AdminTari();
			DataSet dsTaraDeBaza = tari.GetTaraDeBaza();
			foreach(DataRow row in dsTaraDeBaza.Tables[0].Rows)
			{
				idTaraDeBaza=int.Parse(row["TaraID"].ToString());
			}
			//daca este cetatean strain
			if(nationalitate!=idTaraDeBaza)
			{
				/*if(objAngajat.NrPermisMunca.ToString() == "0")
				{
					verificare=false;
					dateNecesare+=" numar permis de munca:";
				}
				if ( (objAngajat.SeriePermisMunca == null) ||
					 ((objAngajat.SeriePermisMunca != null) && (objAngajat.SeriePermisMunca.ToString() == "")) )
				{
					verificare=false;
					dateNecesare+=" serie permis de munca:";
				}
				if(objAngajat.PermMuncaExpira.ToShortDateString()==DateTime.MinValue.ToShortDateString())
				{
					verificare=false;
					dateNecesare+=" data expirarii permisului de munca:";
				}
				
				if ( (objAngajat.NIF == null) ||
					 ((objAngajat.NIF != null) && (objAngajat.NIF.ToString() == "")) )
				{
					verificare=false;
					dateNecesare+=" numarul de inregistrare fiscala al angajatului:";
				}	*/
				if (objAngajat.NIF == null)
					objAngajat.NIF = "";
				if (objAngajat.SeriePermisMunca == null)
					objAngajat.SeriePermisMunca = "";
			}
			// in cazul in care angajatul este cetatean roman 
			else
			{
				//cu domiciliul in strainatate 
				if(objAngajat.DTara!=nationalitate)
				{
					if (objAngajat.NIF == null)
					{
						verificare=false;
						dateNecesare+=" numarul de inregistrare fiscala:";
					}
					else
					{
						//trebuie verificat si numarul de inregistreare fiscala sau CNP-ul
						if((objAngajat.NIF.ToString()=="0")&&(objAngajat.CNP.ToString()=="0"))
						{
							verificare=false;
							dateNecesare+=" numarul de inregistrare fiscala sau CNP-ul angajatului:";
						}
					}
				}
			}		
			return verificare;
		}
		#endregion
	}
}
