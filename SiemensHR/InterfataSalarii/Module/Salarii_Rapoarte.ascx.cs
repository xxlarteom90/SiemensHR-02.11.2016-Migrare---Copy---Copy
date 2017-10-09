using System;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

using SiemensHR.utils;

namespace SiemensHR.InterfataSalarii.Module
{
	/// <summary>
	///		Summary description for Salarii_Administrare.
	/// </summary>
	public class Salarii_Rapoarte : SiemensHR.InterfataSalarii.Classes.BaseModule
	{
		#region Variabile
		protected System.Web.UI.HtmlControls.HtmlTableCell Center;
		#endregion

		#region Page_Load
		private void Page_Load(object sender, System.EventArgs e)
		{
			string Option = this.Page.Request.Params["Option"];		
			if (Option==null) Option="stat_plata_detaliat";
			switch (Option)
			{
				case "stat_plata_pePuncteDeLucru":
					rapoarte_StatDePlataPePuncteDeLucru myStatPlataPePuncteDeLucru = (rapoarte_StatDePlataPePuncteDeLucru) LoadControl("rapoarte_StatDePlataPePuncteDeLucru.ascx");
					myStatPlataPePuncteDeLucru.Attributes.Add("width","100%");
					this.Center.Controls.Add(myStatPlataPePuncteDeLucru);
					break;
				case "stat_plata_detaliat":
					rapoarte_StatDePlata myStatPlataDetaliat = (rapoarte_StatDePlata) LoadControl("rapoarte_StatDePlata.ascx");
					myStatPlataDetaliat.Attributes.Add("width","100%");
					this.Center.Controls.Add(myStatPlataDetaliat);
					break;
				case "stat_plata_scutiti":
					rapoarte_StatDePlataScutitiDeImpozit myStatPlataScutiti = (rapoarte_StatDePlataScutitiDeImpozit) LoadControl("rapoarte_StatDePlataScutitiDeImpozit.ascx");
					this.Center.Controls.Add(myStatPlataScutiti);
					break;
				case "stat_plata_nescutiti":
					rapoarte_StatDePlataNescutitiDeImpozit myStatPlataNescutiti = (rapoarte_StatDePlataNescutitiDeImpozit) LoadControl("rapoarte_StatDePlataNescutitiDeImpozit.ascx");
					this.Center.Controls.Add(myStatPlataNescutiti);
					break;
				case "stat_plata_faraFctDeBaza":
					rapoarte_StatDePlataFaraFctDeBaza myStatPlataFaraFctDeBaza = (rapoarte_StatDePlataFaraFctDeBaza) LoadControl("rapoarte_StatDePlataFaraFctDeBaza.ascx");
					this.Center.Controls.Add(myStatPlataFaraFctDeBaza);
					break;
				case "contributii_angajator":
					rapoarte_ContributiiAngajator myContributiiAngajator = (rapoarte_ContributiiAngajator) LoadControl("rapoarte_ContributiiAngajator.ascx");
					this.Center.Controls.Add(myContributiiAngajator);
					break;
				case "fisier_multicache":
					rapoarte_FisierMulticache myFisierMulticache = (rapoarte_FisierMulticache) LoadControl("rapoarte_FisierMulticache.ascx");
					this.Center.Controls.Add(myFisierMulticache);
					break;
				case "declaratiaA11":
					rapoarte_DeclaratiaA11 myDeclaratiaA11 = (rapoarte_DeclaratiaA11) LoadControl("rapoarte_DeclaratiaA11.ascx");
					this.Center.Controls.Add(myDeclaratiaA11);
					break;
				case "declaratiaA12":
					rapoarte_DeclaratiaA12 myDeclaratiaA12 = (rapoarte_DeclaratiaA12) LoadControl("rapoarte_DeclaratiaA12.ascx");
					this.Center.Controls.Add(myDeclaratiaA12);
					break;
				case "declaratiaSanatateA3a":
					rapoarte_DeclaratieSanatateA3a myDeclaratieSanatateA3a = (rapoarte_DeclaratieSanatateA3a) LoadControl("rapoarte_DeclaratieSanatateA3a.ascx");
					this.Center.Controls.Add(myDeclaratieSanatateA3a);
					break;
				case "declaratiaSanatateA3b":
					rapoarte_DeclaratieSanatateA3b myDeclaratieSanatateA3b = (rapoarte_DeclaratieSanatateA3b) LoadControl("rapoarte_DeclaratieSanatateA3b.ascx");
					this.Center.Controls.Add(myDeclaratieSanatateA3b);
					break;
				case "declaratieSomajCap1":
					rapoarte_DeclaratieSomajCap1 myDeclaratieSomajCap1 = (rapoarte_DeclaratieSomajCap1) LoadControl("rapoarte_DeclaratieSomajCap1.ascx");
					this.Center.Controls.Add(myDeclaratieSomajCap1);
					break;
				case "declaratieSomajCap2":
					rapoarte_DeclaratieSomajCap2 myDeclaratieSomajCap2 = (rapoarte_DeclaratieSomajCap2) LoadControl("rapoarte_DeclaratieSomajCap2.ascx");
					this.Center.Controls.Add(myDeclaratieSomajCap2);
					break;
				case "ticheteDeMasa":
					/*rapoarte_TicheteDeMasa myTicheteDeMasa = (rapoarte_TicheteDeMasa) LoadControl("rapoarte_TicheteDeMasa.ascx");
					this.Center.Controls.Add(myTicheteDeMasa);
					break;*/
					rapoarte_TicheteMasa myTicheteMasa = (rapoarte_TicheteMasa) LoadControl("rapoarte_TicheteMasa.ascx");
					this.Center.Controls.Add(myTicheteMasa);
					break;
				case "raport_cursuri_angajati":
					rapoarte_CursuriAngajati myCursuriAngajati = (rapoarte_CursuriAngajati) LoadControl("rapoarte_CursuriAngajati.ascx");
					this.Center.Controls.Add(myCursuriAngajati);
					break;
				case "raport_cursuri_angajati_portal":
					rapoarte_CursuriAngajatiPortal myCursuriAngajatiPortal = (rapoarte_CursuriAngajatiPortal) LoadControl("rapoarte_CursuriAngajatiPortal.ascx");
					this.Center.Controls.Add(myCursuriAngajatiPortal);
					break;
				case "raport_cursuri":
					rapoarte_Cursuri myCursuri = (rapoarte_Cursuri) LoadControl("rapoarte_Cursuri.ascx");
					this.Center.Controls.Add(myCursuri);
					break;
				case "raport_chcm":
					rapoarte_CHCM myCHCM = (rapoarte_CHCM) LoadControl("rapoarte_CHCM.ascx");
					this.Center.Controls.Add(myCHCM);
					break;
				case "raport_acces":
					rapoarte_AccesCladire myAcces = (rapoarte_AccesCladire) LoadControl("rapoarte_AccesCladire.ascx");
					this.Center.Controls.Add(myAcces);
					break;
                //Modificat:	Lungu Andreea
				//Data:			02.04.2008
				//Descriere:	Au fost introduse doua noi rapoarte: stat_itm si contracte_itm
				case "stat_itm":
					rapoarte_StatItm myStatItm = (rapoarte_StatItm) LoadControl("rapoarte_StatItm.ascx");
					this.Center.Controls.Add(myStatItm);
					break;
				case "contracte_itm":
					rapoarte_ContracteItm myContracteItm = (rapoarte_ContracteItm) LoadControl("rapoarte_ContracteItm.ascx");
					this.Center.Controls.Add(myContracteItm);
					break;
				//Lungu Andreea - 09.10.2008
				case "Fluturasi":
					Fluturasi myFluturasi = (Fluturasi) LoadControl("Fluturasi.ascx");
					this.Center.Controls.Add(myFluturasi);
					break;
				case "date_lichidati":
					rapoarte_DateLichidare lichidare = (rapoarte_DateLichidare) LoadControl("rapoarte_DateLichidare.ascx");
					this.Center.Controls.Add(lichidare);
					break;
				//LUngu Andreea - 09.02.2009
				case "fisa_fiscala":
					rapoarte_FiseFiscaleXml fisaFiscalaXml = (rapoarte_FiseFiscaleXml) LoadControl("rapoarte_FiseFiscaleXml.ascx");
					this.Center.Controls.Add(fisaFiscalaXml);
					break;
				//Lungu Andreea - 17.02.2011
				case "declaratie_unica":
					rapoarte_DeclaratieUnica declUnica = (rapoarte_DeclaratieUnica) LoadControl("rapoarte_DeclaratieUnica.ascx");
					this.Center.Controls.Add(declUnica);
					break;
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
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
	}
}
