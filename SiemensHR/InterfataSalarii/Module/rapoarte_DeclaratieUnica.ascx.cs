/*
 * Autor:     Lungu Andreea
 * Data:      17.02.2011
 * Descriere: Este generata declaratia unica 112.
 */

using System;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Xml;
using System.IO;
using System.Collections;
using System.Diagnostics;
using System.Threading;

namespace SiemensHR.InterfataSalarii.Module
{
	/// <summary>
	///	Este generata declaratia unica 112..
	/// </summary>
	public class rapoarte_DeclaratieUnica : SiemensHR.InterfataSalarii.Classes.BaseModule
	{
		#region Variabile
		protected System.Web.UI.WebControls.Label labelError;
		protected System.Web.UI.WebControls.ValidationSummary sumarValidare;
		protected System.Web.UI.WebControls.Button btnGenereaza;
		private int lunaID;
		private int angajatorID;
		protected Salaries.Configuration.ModuleSettings settings;
		#endregion
		
		#region Constrante
		// Numele cheii din web.config care contine calea catre serverul cu rapoartele.
		private const string STRING_URL = "rapoarteServerUrl";
		protected System.Web.UI.WebControls.HyperLink hyperLinkDeclaratie;
		protected System.Web.UI.WebControls.Button btnValideaza;
		protected System.Web.UI.WebControls.HyperLink hyperLinkFisierErori;
		protected System.Web.UI.WebControls.HyperLink hyperLinkFisierPdf;
		private const string importLogFolder = "importFolder";

		#endregion

		#region Page_Load
		private void Page_Load(object sender, System.EventArgs e)
		{
			lunaID = this.GetCurrentMonth();
			angajatorID = this.GetAngajator();

			if (!IsPostBack)
			{
				
				hyperLinkDeclaratie.Visible = false;
				btnValideaza.Visible = false;
				hyperLinkFisierErori.Visible = false;
				hyperLinkFisierPdf.Visible = false;
			}
		}
		#endregion

		#region OnPreRender
		protected override void OnPreRender(EventArgs e)
		{
			base.OnPreRender(e);
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
			this.btnGenereaza.Click += new System.EventHandler(this.btnGenereaza_Click);
			this.btnValideaza.Click += new System.EventHandler(this.btnValideaza_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region btnGenereaza_Click
		/// <summary>
		/// Genereaza raportul
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnGenereaza_Click(object sender, System.EventArgs e)
		{
			Salaries.Business.Luni l = new Salaries.Business.Luni(angajatorID);
			Salaries.Data.LunaData luna = l.GetDetalii(lunaID);

			string path = Salaries.Configuration.CryptographyClass.getSettingsWithoutDecode(importLogFolder) + "\\DecUnica.xml";
			
			//string path = this.Page.Request.Url.AbsoluteUri;
			//path = path.Substring(0, path.LastIndexOf("/"));
			//path = path + "/Templates/DecUnica.xml";
			//path = "C:\\Inetpub\\wwwroot\\hr\\InterfataSalarii\\Templates\\DecUnica.xml";
			
			XmlTextReader reader = new XmlTextReader(path);

			XmlDocument xmlDoc = new XmlDocument();
			xmlDoc.Load(reader);

			Salaries.Business.Salariu sal = new Salaries.Business.Salariu();
			DataSet dsAsig = sal.GetDateAsigurati(angajatorID, lunaID);
			int nrAngajati = 0;

			foreach (DataRow dr in dsAsig.Tables[0].Rows)
			{
			if (Convert.ToInt32(dr["TipAsiguratID"].ToString()) <= 2)
				nrAngajati += 1;
			}
			
			Salaries.Business.VariabileGlobaleValori val = new Salaries.Business.VariabileGlobaleValori();
			DataSet dsVarGlobale = val.GetAllVariabileGlobaleValoriPeLuna(lunaID);
			double procentPBCISAN = 0;
			double procentFNUASS = 0;
			double procentPBCICAS = 0;
			double procentPBCCUAS = 0;
			double procentPBCISOM = 0;
			double smbe = 0;
			double sminec = 0;
			
			foreach (DataRow dr in dsVarGlobale.Tables[0].Rows)
			{
				if (dr["Cod"].ToString().Equals("PBCISAN"))
					procentPBCISAN = Convert.ToDouble(dr["Valoare"].ToString());
				if (dr["Cod"].ToString().Equals("PBCICAS"))
					procentPBCICAS = Convert.ToDouble(dr["Valoare"].ToString());
				if (dr["Cod"].ToString().Equals("PBCISOM"))
					procentPBCISOM = Convert.ToDouble(dr["Valoare"].ToString());
				if (dr["Cod"].ToString().Equals("PFCB"))
					procentFNUASS = Convert.ToDouble(dr["Valoare"].ToString());
				if (dr["Cod"].ToString().Equals("PBCCUAS"))
					procentPBCCUAS = Convert.ToDouble(dr["Valoare"].ToString());
				if (dr["Cod"].ToString().Equals("SMBE"))
					smbe = Convert.ToDouble(dr["Valoare"].ToString());
				if (dr["Cod"].ToString().Equals("SMINEC"))
					sminec = Convert.ToDouble(dr["Valoare"].ToString());
			}
			

			#region declaratieUnica
			//<declaratieUnica luna_r="" an_r="" d_rec="" nume_declar="" prenume_declar="" functie_declar="" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns="mfp:anaf:dgti:declaratie_unica:declaratie:v1" >
			
			//aduc dataset-ul folosit la raportul pentru declaratie A12
			Salaries.Business.Declaratii declaratiaA12 = new Salaries.Business.Declaratii(lunaID, angajatorID);
			DataSet dsDateDeclA12  = declaratiaA12.GetDateDeclaratieCASa12(DateTime.Now, -1);
			DataTable dtDeclA12 = dsDateDeclA12.Tables[0];
			
			//duc datasetul cu reprezentantii legali - pentru declarant 
			Salaries.Business.AdminAngajator adminAng = new Salaries.Business.AdminAngajator();
			adminAng.AngajatorId = angajatorID;
			DataSet ds = adminAng.GetReprezLegali();
			string numeDeclarant = "", prenumeDeclarant = "", functieDeclarant = "";
			foreach(DataRow dr in ds.Tables[0].Rows)
			{
				// Numele si prenumele declarantului 
				if (dr["NumeFunctie"].ToString().Equals("Contabil sef"))
				{
					numeDeclarant = dr["NumeReprez"].ToString();
					prenumeDeclarant = dr["PrenumeReprez"].ToString();
					functieDeclarant = dr["NumeFunctie"].ToString();
				}
			}
			
			//completez atributele nodului;
			XmlNode node = xmlDoc.GetElementsByTagName("declaratieUnica")[0];
            node.Attributes["luna_r"].Value = dtDeclA12.Rows[0]["LN"].ToString();
			node.Attributes["an_r"].Value = dtDeclA12.Rows[0]["AN"].ToString();
			node.Attributes["d_rec"].Value = "0";
			node.Attributes["nume_declar"].Value = numeDeclarant;
			node.Attributes["prenume_declar"].Value = prenumeDeclarant;
			node.Attributes["functie_declar"].Value = functieDeclarant;  // ??? - todo
			//-------------------------------------------------------------------------	
			#endregion

			#region angajator
			//<angajator cif="" rgCom="" caen="" den="" adrSoc="" telSoc="" faxSoc="" mailSoc="" adrFisc="" telFisc="" faxFisc="" mailFisc="" casaAng="" tRisc="" dat="" totalPlata_A="">
			//aduc dataset-ul care aduce datele angajatului
			DataSet dsAngajator = adminAng.LoadInfoAngajator();
			Salaries.Business.AdminDomeniiDeActivitateAngajator adminDomAng = new Salaries.Business.AdminDomeniiDeActivitateAngajator();
			adminDomAng.AngajatorId = angajatorID;
			DataSet dsDomPrincActiv = adminDomAng.GetPrincipalDomeniuDeActivitateAngajatorInfo();
						
			//completez atributele nodului;
			XmlNode nodeAngajator = xmlDoc.GetElementsByTagName("angajator")[0];
			nodeAngajator.Attributes["cif"].Value = dtDeclA12.Rows[0]["CF"].ToString().Substring(1);
			nodeAngajator.Attributes["rgCom"].Value = dtDeclA12.Rows[0]["RJ"].ToString()+ "/" + dtDeclA12.Rows[0]["RN"].ToString() + "/" + dtDeclA12.Rows[0]["RA"].ToString();
			nodeAngajator.Attributes["caen"].Value = dtDeclA12.Rows[0]["CODCAEN"].ToString();
			nodeAngajator.Attributes["den"].Value = dtDeclA12.Rows[0]["DEN"].ToString();
			nodeAngajator.Attributes["adrSoc"].Value = dtDeclA12.Rows[0]["A_LOCA"].ToString() + ", str." + dtDeclA12.Rows[0]["A_STR"].ToString() + ", nr." + dtDeclA12.Rows[0]["A_NR"].ToString() + ", bl." + dtDeclA12.Rows[0]["A_BL"].ToString() + ", sc." + dtDeclA12.Rows[0]["A_SC"].ToString() + ", et." + dtDeclA12.Rows[0]["A_ET"].ToString() + ", ap." + dtDeclA12.Rows[0]["A_AP"].ToString();
			nodeAngajator.Attributes["telSoc"].Value = dtDeclA12.Rows[0]["TELEFON"].ToString();
			nodeAngajator.Attributes["faxSoc"].Value = dtDeclA12.Rows[0]["FAX"].ToString();
			nodeAngajator.Attributes["mailSoc"].Value = dtDeclA12.Rows[0]["E_MAIL"].ToString();
			nodeAngajator.Attributes["casaAng"].Value = "BV";
			double pcambp = Convert.ToDouble(dtDeclA12.Rows[0]["PCAMBP"].ToString());
			nodeAngajator.Attributes["tRisc"].Value = ((string)(Math.Round(pcambp, 3) + "")).Replace(",",".");
			if ((bool) dsDomPrincActiv.Tables[0].Rows[0]["RetinereAccidente"])
				nodeAngajator.Attributes["dat"].Value = "1";
			else
				nodeAngajator.Attributes["dat"].Value = "0";
			
			//-------------------------
			#endregion
			
			#region angajatorA
			//<angajatorA A_codOblig="" A_codBugetar="" A_datorat="" A_deductibil="" A_plata=""/>		
			sal.CalculCreante(angajatorID, lunaID);
			DataSet dsCreante = sal.getCreante(angajatorID, lunaID);
			double suma_total_plata = 0;

			XmlNode nodeAngajatorA = xmlDoc.GetElementsByTagName("angajatorA")[0];
			XmlNode parent = nodeAngajatorA.ParentNode;
			foreach(DataRow dr in dsCreante.Tables[0].Rows)
			{
				double datorat =  Convert.ToDouble(dr["Datorat"].ToString());
				double deductibil = Convert.ToDouble(dr["Deductibil"].ToString());
				double plata = Convert.ToDouble(dr["Plata"].ToString());
				if ((datorat != 0) || (deductibil != 0) || (plata != 0))
				{
					XmlNode nodeCreanta = nodeAngajatorA.CloneNode(true);
					nodeCreanta.Attributes["A_codOblig"].Value = dr["CodObligatie"].ToString();
					nodeCreanta.Attributes["A_codBugetar"].Value = dr["CodBugetar"].ToString();
					nodeCreanta.Attributes["A_datorat"].Value = Math.Round(datorat) + "";
					nodeCreanta.Attributes["A_deductibil"].Value = Math.Round(deductibil) + "";
					nodeCreanta.Attributes["A_plata"].Value = Math.Round(plata) +  "";
					parent.InsertAfter(nodeCreanta, nodeAngajatorA);
				}
				suma_total_plata += plata;
			}
			parent.RemoveChild(nodeAngajatorA);
			nodeAngajator.Attributes["totalPlata_A"].Value = Math.Round(suma_total_plata) + "";
			
			//------------------------------------------------------------------------------
			#endregion

			#region angajatorB
			//<angajatorB B_cnp="" B_sanatate="" B_pensie="" B_brutSalarii=""/>
			DataSet dsNrAsig = sal.CalculNumarAsigurati(angajatorID, lunaID);
			DataSet dsBcAngajator = sal.GetBazeCalculAngajator(angajatorID, lunaID);
			DataSet dsBcAngajatiTotal = sal.GetBazeCalculAngajatiTotal(angajatorID, lunaID);
			
			XmlNode nodeAngajatorB = xmlDoc.GetElementsByTagName("angajatorB")[0];
			nodeAngajatorB.Attributes["B_cnp"].Value = dsNrAsig.Tables[0].Rows[0]["NrAsiguratiSomaj"].ToString();
			nodeAngajatorB.Attributes["B_sanatate"].Value = dsNrAsig.Tables[0].Rows[0]["NrAsiguratiSanatate"].ToString();
			nodeAngajatorB.Attributes["B_sal"].Value = nrAngajati.ToString();
			nodeAngajatorB.Attributes["B_pensie"].Value = dsNrAsig.Tables[0].Rows[0]["NrAsiguratiCAS"].ToString();
			double bcusan = Convert.ToDouble(dsBcAngajator.Tables[0].Rows[0]["bcusan"].ToString());
			nodeAngajatorB.Attributes["B_brutSalarii"].Value = Math.Round(bcusan) +  "";
			double B_brutSalarii = Convert.ToDouble(nodeAngajatorB.Attributes["B_brutSalarii"].Value);
			double B_sanatate = Convert.ToDouble(nodeAngajatorB.Attributes["B_sanatate"].Value);
			double B_pensie= Convert.ToDouble(nodeAngajatorB.Attributes["B_pensie"].Value);
			//------------------------------------------------------------------------------
			#endregion

			#region angajatorC1
			//<angajatorC1 C1_11="" C1_12="" C1_13="" C1_21="" C1_22="" C1_23="" C1_31="" C1_32="" C1_33="" C1_T1="" C1_T2="" C1_T3="" C1_5="" C1_6="" C1_7=""/>
			DataSet dsPuncteLucruTotal = sal.GetPuncteDeLucruTotal(angajatorID, lunaID);
			DataSet dsFNUASS =  sal.GetFNUASS(angajatorID, lunaID, -1, -1);
			DataSet dsSume =  sal.GetDiverseSume(angajatorID, lunaID);
			DataSet dsContribAngajator = sal.GetContributiiUnitateAngajator(angajatorID, lunaID);
			DataSet dsContribAngajatiTotal = sal.GetContributiiAngajatiTotal(angajatorID, lunaID);
			
			node = xmlDoc.GetElementsByTagName("angajatorC1")[0];
			double totalVb = 0;
			double sumaConcediuBoalaBASS = 0;
			double sumaConcediuBoalaFirma = 0;
			foreach (DataRow dr in dsPuncteLucruTotal.Tables[0].Rows)
			{
				totalVb += Convert.ToDouble(dr["VenitBrut"].ToString());
				sumaConcediuBoalaBASS += Convert.ToDouble(dr["SumaConcediuBoalaBASS"].ToString());
				sumaConcediuBoalaFirma += Convert.ToDouble(dr["SumaConcediuBoalaFirma"].ToString());
			}
			//node.Attributes["C1_11"].Value = Math.Round(totalVb) + "";
			node.Attributes["C1_11"].Value = Math.Round(totalVb - sumaConcediuBoalaBASS - sumaConcediuBoalaFirma) + "";
			double bcFnuass = Convert.ToDouble(dsFNUASS.Tables[0].Rows[0]["bcFNUASS"].ToString());
			double bcFnuass_1 = Convert.ToDouble(dsFNUASS.Tables[0].Rows[0]["bcFNUASS_1"].ToString());
			node.Attributes["C1_12"].Value = Math.Round(bcFnuass_1) + "";
			double vbFaraRetinereCAS = Convert.ToDouble(dsSume.Tables[0].Rows[0]["VbFaraRetinereCAS"].ToString());
			node.Attributes["C1_13"].Value = Math.Round(vbFaraRetinereCAS) + "";
			node.Attributes["C1_21"].Value = "0";
			node.Attributes["C1_22"].Value = "0";
			node.Attributes["C1_23"].Value = "0";
			node.Attributes["C1_31"].Value = "0";
			node.Attributes["C1_32"].Value = "0";
			node.Attributes["C1_33"].Value = "0";
			double c1_11 = Convert.ToDouble(node.Attributes["C1_11"].Value);
			double c1_21 = Convert.ToDouble(node.Attributes["C1_21"].Value);
			double c1_31 = Convert.ToDouble(node.Attributes["C1_31"].Value);
			node.Attributes["C1_T1"].Value = Math.Round(c1_11 + c1_21 + c1_31) + "";
			double c1_12 = Convert.ToDouble(node.Attributes["C1_12"].Value);
			double c1_22 = Convert.ToDouble(node.Attributes["C1_22"].Value);
			double c1_32 = Convert.ToDouble(node.Attributes["C1_32"].Value);
			node.Attributes["C1_T2"].Value = Math.Round(c1_12 + c1_22 + c1_32) + "";
			double c1_13 = Convert.ToDouble(node.Attributes["C1_13"].Value);
			double c1_23 = Convert.ToDouble(node.Attributes["C1_23"].Value);
			double c1_33 = Convert.ToDouble(node.Attributes["C1_33"].Value);
			node.Attributes["C1_T"].Value = Math.Round(c1_13 + c1_23 + c1_33) + "";
		
			double cucas = Convert.ToDouble(dsContribAngajator.Tables[0].Rows[0]["cucas"].ToString());
			double c1_T1 = Convert.ToDouble(node.Attributes["C1_T1"].Value);
			double c1_T2 = Convert.ToDouble(node.Attributes["C1_T2"].Value);
			double c1_T = Convert.ToDouble(node.Attributes["C1_T"].Value);
			double c1_T3 = 0;
			double bazaCalculPlafonata = B_pensie * 5 * smbe ;
			double v1 = (c1_11 + c1_12 - c1_13) * procentPBCCUAS /100;
			double v2 = 0;
			if (c1_T1 + c1_T2 - c1_T > 0)
				v2 = bazaCalculPlafonata / (c1_T1 + c1_T2 - c1_T);
			if (v2 <= 1)
				c1_T3 = v1 * v2;
			else
				c1_T3 = v1;
			node.Attributes["C1_T3"].Value = Math.Round(c1_T3) + "";
			//node.Attributes["C1_T3"].Value = Math.Round(Minim(cucas, 5 * smbe * nrAngajati)) + "";
			
			node.Attributes["C1_5"].Value = "0";
			double ajutorDeces_ = Convert.ToDouble(dsSume.Tables[0].Rows[0]["AjutorDeces"].ToString());
			if (ajutorDeces_>cucas)
				node.Attributes["C1_6"].Value = Math.Round(ajutorDeces_ - cucas) + "";
			else
				node.Attributes["C1_6"].Value = "0";

			//node.Attributes["C1_6"].Value = "0";  // ??? - todo - nu stiu de unde sa o iau
			node.Attributes["C1_7"].Value = "0";
			//-------------------------------------------------------------------------------------------
			#endregion

			#region angajatorC2
			//<angajatorC2 C2_11="" C2_12="" C2_13="" C2_14="" C2_15="" C2_16="" C2_21="" C2_22="" C2_24="" C2_26="" C2_31="" C2_32="" C2_34="" C2_36="" C2_41="" C2_42="" C2_44="" C2_46="" C2_51="" C2_52="" C2_54="" C2_56="" C2_T6="" C2_7="" C2_9="" C2_10="" C2_110="" C2_120="" C2_130=""/>
			DataSet dsIndicatoriSanatate = sal.GetIndicatoriIndemnizatieSanatate(angajatorID, lunaID);
			XmlNode nodeAngajatorC2 = xmlDoc.GetElementsByTagName("angajatorC2")[0];
			nodeAngajatorC2.Attributes["C2_11"].Value = dsIndicatoriSanatate.Tables[0].Rows[0]["NrCazuri_anumiteBoli"].ToString();
			nodeAngajatorC2.Attributes["C2_12"].Value = dsIndicatoriSanatate.Tables[0].Rows[0]["TotalZileCBPlatite_anumiteBoli"].ToString();
			nodeAngajatorC2.Attributes["C2_13"].Value = dsIndicatoriSanatate.Tables[0].Rows[0]["TotalZileCBFirma_anumiteBoli"].ToString();
			nodeAngajatorC2.Attributes["C2_14"].Value = dsIndicatoriSanatate.Tables[0].Rows[0]["TotalZileCBBASS_anumiteBoli"].ToString();
			double sumaCBFirma_san = Convert.ToDouble(dsIndicatoriSanatate.Tables[0].Rows[0]["SumaCBFirma_anumiteBoli"].ToString());
			double sumaCBBASS_san = Convert.ToDouble(dsIndicatoriSanatate.Tables[0].Rows[0]["SumaCBBASS_anumiteBoli"].ToString());
			nodeAngajatorC2.Attributes["C2_15"].Value = Math.Round(sumaCBFirma_san) + "";
			nodeAngajatorC2.Attributes["C2_16"].Value = Math.Round(sumaCBBASS_san) + "";
			nodeAngajatorC2.Attributes["C2_21"].Value = "0";
			nodeAngajatorC2.Attributes["C2_22"].Value = "0";
			nodeAngajatorC2.Attributes["C2_24"].Value = "0";
			nodeAngajatorC2.Attributes["C2_26"].Value = "0";
			nodeAngajatorC2.Attributes["C2_31"].Value = dsIndicatoriSanatate.Tables[0].Rows[0]["NrCazuriCM08"].ToString();
			nodeAngajatorC2.Attributes["C2_32"].Value = dsIndicatoriSanatate.Tables[0].Rows[0]["TotalZileCM08"].ToString();
			nodeAngajatorC2.Attributes["C2_34"].Value = dsIndicatoriSanatate.Tables[0].Rows[0]["TotalZileCM08_FNUASS"].ToString();
			double sumaCM08_FNUASS = ROUNDUP(Convert.ToDouble(dsIndicatoriSanatate.Tables[0].Rows[0]["SumaCM08_FNUASS"].ToString()));
			nodeAngajatorC2.Attributes["C2_36"].Value = Math.Round(sumaCM08_FNUASS) + "";
			nodeAngajatorC2.Attributes["C2_41"].Value = dsIndicatoriSanatate.Tables[0].Rows[0]["NrCazuriCM09"].ToString();
			nodeAngajatorC2.Attributes["C2_42"].Value = dsIndicatoriSanatate.Tables[0].Rows[0]["TotalZileCM09"].ToString();
			nodeAngajatorC2.Attributes["C2_44"].Value = dsIndicatoriSanatate.Tables[0].Rows[0]["TotalZileCM09_FNUASS"].ToString();
			double sumaCM09_FNUASS = Convert.ToDouble(dsIndicatoriSanatate.Tables[0].Rows[0]["SumaCM09_FNUASS"].ToString());
			nodeAngajatorC2.Attributes["C2_46"].Value = Math.Round(sumaCM09_FNUASS) + "";
			nodeAngajatorC2.Attributes["C2_51"].Value = dsIndicatoriSanatate.Tables[0].Rows[0]["NrCazuriCM15"].ToString();
			nodeAngajatorC2.Attributes["C2_52"].Value = dsIndicatoriSanatate.Tables[0].Rows[0]["TotalZileCM15"].ToString();
			nodeAngajatorC2.Attributes["C2_54"].Value = dsIndicatoriSanatate.Tables[0].Rows[0]["TotalZileCM15_FNUASS"].ToString();
			double sumaCM15_FNUASS = Convert.ToDouble(dsIndicatoriSanatate.Tables[0].Rows[0]["SumaCM15_FNUASS"].ToString());
			nodeAngajatorC2.Attributes["C2_56"].Value = Math.Round(sumaCM15_FNUASS) + "";
			double c2_16 = Convert.ToDouble(nodeAngajatorC2.Attributes["C2_16"].Value);
			double c2_26 = Convert.ToDouble(nodeAngajatorC2.Attributes["C2_26"].Value);
			double c2_36 = Convert.ToDouble(nodeAngajatorC2.Attributes["C2_36"].Value);
			double c2_46 = Convert.ToDouble(nodeAngajatorC2.Attributes["C2_46"].Value);
			double c2_56 = Convert.ToDouble(nodeAngajatorC2.Attributes["C2_56"].Value);
			nodeAngajatorC2.Attributes["C2_T6"].Value = Math.Round(c2_16 + c2_26 + c2_36 + c2_46 + c2_56) + "";
			
			double c2_7 = Minim(B_brutSalarii, B_sanatate * 12 * sminec) * procentFNUASS / 100;
			nodeAngajatorC2.Attributes["C2_7"].Value = Math.Round(c2_7) + "";
			//node.Attributes["C2_7"].Value = Math.Round(bcFnuass * procentFNUASS / 100) + "";
			double sumaCM03 = Convert.ToDouble(dsIndicatoriSanatate.Tables[0].Rows[0]["SumaCM03"].ToString());
			nodeAngajatorC2.Attributes["C2_8"].Value = Math.Round(sumaCM03 * procentFNUASS / 100) + "";
			c2_7 = Convert.ToDouble(nodeAngajatorC2.Attributes["C2_7"].Value);
			double c2_8 = Convert.ToDouble(nodeAngajatorC2.Attributes["C2_8"].Value);
			nodeAngajatorC2.Attributes["C2_9"].Value = Math.Round(c2_7 + c2_8) + "";
			double totalSumeCBCas = 0;
			foreach (DataRow dr in dsPuncteLucruTotal.Tables[0].Rows)
			{
				totalSumeCBCas += Convert.ToDouble(dr["SumaConcediuBoalaBASS"].ToString());
			}
			//node.Attributes["C2_10"].Value = Math.Round(totalSumeCBCas) + "";
			nodeAngajatorC2.Attributes["C2_10"].Value = nodeAngajatorC2.Attributes["C2_T6"].Value;
			double c2_9 = Convert.ToDouble(nodeAngajatorC2.Attributes["C2_9"].Value);
			double c2_10 = Convert.ToDouble(nodeAngajatorC2.Attributes["C2_10"].Value);
			nodeAngajatorC2.Attributes["C2_9"].Value = Math.Round(c2_7 + c2_8) + "";
		
			nodeAngajatorC2.Attributes["C2_110"].Value = Math.Round(Minim(c2_10, c2_9)) + "";
			double c2_110 = Convert.ToDouble(nodeAngajatorC2.Attributes["C2_110"].Value);
			//node.Attributes["C2_120"].Value = Math.Round(Minim(c2_9 - c2_10, 0)) + "";
			nodeAngajatorC2.Attributes["C2_120"].Value = Math.Round(Maxim(c2_9 - c2_110, 0)) + "";
			nodeAngajatorC2.Attributes["C2_130"].Value = Math.Round(Maxim(c2_10 - c2_9, 0)) + "";
			#endregion 

			#region angajatorC3
			//<angajatorC3 C3_11="" C3_12="" C3_13="" C3_14="" C3_21="" C3_22="" C3_23="" C3_24="" C3_31="" C3_32="" C3_33="" C3_34="" C3_41="" C3_42="" C3_43="" C3_44="" C3_total="" C3_suma="" C3_aj_nr="" C3_aj_suma=""/>
			node = xmlDoc.GetElementsByTagName("angajatorC3")[0];
			node.Attributes["C3_11"].Value = dsIndicatoriSanatate.Tables[0].Rows[0]["NrCazuriCM03"].ToString();
			node.Attributes["C3_12"].Value = dsIndicatoriSanatate.Tables[0].Rows[0]["TotalZileCM03"].ToString();
			double sumaCM03_FAAMBP = Convert.ToDouble(dsIndicatoriSanatate.Tables[0].Rows[0]["SumaCM03_FAAMBP"].ToString());
			node.Attributes["C3_13"].Value = Math.Round(sumaCM03) + "";
			node.Attributes["C3_14"].Value = Math.Round(sumaCM03_FAAMBP) + "";
			node.Attributes["C3_21"].Value = dsIndicatoriSanatate.Tables[0].Rows[0]["NrCazuriCM11"].ToString();
			node.Attributes["C3_22"].Value = dsIndicatoriSanatate.Tables[0].Rows[0]["TotalZileCM11"].ToString();
			double sumaCM11 = Convert.ToDouble(dsIndicatoriSanatate.Tables[0].Rows[0]["SumaCM11"].ToString());
			double sumaCM11_FAAMBP = Convert.ToDouble(dsIndicatoriSanatate.Tables[0].Rows[0]["SumaCM11_FAAMBP"].ToString());
			node.Attributes["C3_23"].Value = Math.Round(sumaCM11) + "";
			node.Attributes["C3_24"].Value = Math.Round(sumaCM11_FAAMBP) + "";
			node.Attributes["C3_31"].Value = dsIndicatoriSanatate.Tables[0].Rows[0]["NrCazuriCM12"].ToString();
			node.Attributes["C3_32"].Value = dsIndicatoriSanatate.Tables[0].Rows[0]["TotalZileCM12"].ToString();
			double sumaCM12 = Convert.ToDouble(dsIndicatoriSanatate.Tables[0].Rows[0]["SumaCM12"].ToString());
			double sumaCM12_FAAMBP = Convert.ToDouble(dsIndicatoriSanatate.Tables[0].Rows[0]["SumaCM12_FAAMBP"].ToString());
			node.Attributes["C3_33"].Value = Math.Round(sumaCM12) + "";
			node.Attributes["C3_34"].Value = Math.Round(sumaCM12_FAAMBP) + "";
			node.Attributes["C3_41"].Value = "0";
			node.Attributes["C3_42"].Value = "0";
			node.Attributes["C3_43"].Value = "0";
			node.Attributes["C3_44"].Value = "0";
			node.Attributes["C3_total"].Value = "0";
			node.Attributes["C3_suma"].Value = "0";
			node.Attributes["C3_aj_nr"].Value = dsIndicatoriSanatate.Tables[0].Rows[0]["NrCazuriAjutorDeces"].ToString();
			double sumaAjutorDeces = Convert.ToDouble(dsIndicatoriSanatate.Tables[0].Rows[0]["SumaAjutorDeces"].ToString());
			node.Attributes["C3_aj_suma"].Value = Math.Round(sumaAjutorDeces) + "";
			//----------------------------------------------------------------------------
			#endregion

			#region angajatorC4
			//<angajatorC4 C4_scutitaSo=""/>
			node = xmlDoc.GetElementsByTagName("angajatorC4")[0];
			node.Attributes["C4_scutitaSo"].Value = "0"; // ??? - todo - suma scutita?
			#endregion

			#region angajatorC5
			//<angajatorC5 C5_subv="" C5_recuperat="" C5_restituit=""/>
			node = xmlDoc.GetElementsByTagName("angajatorC5")[0];
			node.Attributes["C5_subv"].Value = "0";
			node.Attributes["C5_recuperat"].Value = "0";
			node.Attributes["C5_restituit"].Value = "0";
			parent = node.ParentNode;
			parent.RemoveChild(node);
			#endregion

			#region angajatorC6
			//<angajatorC6 C6_baza="" C6_ct=""/>
			node = xmlDoc.GetElementsByTagName("angajatorC6")[0];
			double bcusom = Convert.ToDouble(dsBcAngajator.Tables[0].Rows[0]["bcusom"].ToString());
			double cusom = Convert.ToDouble(dsContribAngajator.Tables[0].Rows[0]["cusom"].ToString());
			double bcisomTotal = Convert.ToDouble(dsBcAngajatiTotal.Tables[0].Rows[0]["bcisom"].ToString());
			double cisomTotal = Convert.ToDouble(dsContribAngajatiTotal.Tables[0].Rows[0]["cisom"].ToString());
			
			node.Attributes["C6_baza"].Value = Math.Round(ROUNDUP(bcusom)) + "";
			//node.Attributes["C6_baza"].Value = Math.Round(ROUNDUP(bcisomTotal)) + "";
			node.Attributes["C6_ct"].Value = Math.Round(cusom) + "";
			//node.Attributes["C6_ct"].Value = Math.Round(cisomTotal) + "";
			#endregion

			#region angajatorC7
			//<angajatorC7 C7_baza="" C7_ct=""/>
			node = xmlDoc.GetElementsByTagName("angajatorC7")[0];
			double bcufgar = Convert.ToDouble(dsBcAngajator.Tables[0].Rows[0]["bcufgar"].ToString());
			string cufgar_ = dsContribAngajator.Tables[0].Rows[0]["cufgar"].ToString();
			double cufgar = cufgar_.Equals("") ? 0 : Convert.ToDouble(cufgar_);
			node.Attributes["C7_baza"].Value = Math.Round(bcufgar) + "";
			node.Attributes["C7_ct"].Value = Math.Round(cufgar) + "";
			#endregion

			#region angajatorD
			//<angajatorD D1="" D2="" D3="" D4=""/>
			node = xmlDoc.GetElementsByTagName("angajatorD")[0];
			node.Attributes["D1"].Value = "0";
			node.Attributes["D2"].Value = "0";
			node.Attributes["D3"].Value = "0";
			node.Attributes["D4"].Value = "0";
			#endregion

			#region angajatorE1
			//<angajatorE1 E1_venit="" E1_baza="" E1_ct=""/>
			node = xmlDoc.GetElementsByTagName("angajatorE1")[0];
			node.Attributes["E1_venit"].Value = "0";
			node.Attributes["E1_baza"].Value = "0";
			node.Attributes["E1_ct"].Value = "0";
			#endregion

			#region angajatorE2
			//<angajatorE2 E2_11="" E2_12="" E2_14="" E2_16="" E2_21="" E2_22="" E2_24="" E2_26="" E2_31="" E2_32="" E2_34="" E2_36="" E2_41="" E2_42="" E2_44="" E2_46="" E2_51="" E2_52="" E2_54="" E2_56="" E2_66="" E2_7="" E2_8="" E2_9="" E2_10="" E2_110="" E2_120="" E2_130=""/>
			node = xmlDoc.GetElementsByTagName("angajatorE2")[0];
			node.Attributes["E2_11"].Value = "0";
			node.Attributes["E2_12"].Value = "0";
			node.Attributes["E2_14"].Value = "0";
			node.Attributes["E2_16"].Value = "0";
			node.Attributes["E2_21"].Value = "0";
			node.Attributes["E2_22"].Value = "0";
			node.Attributes["E2_24"].Value = "0";
			node.Attributes["E2_26"].Value = "0";
			node.Attributes["E2_31"].Value = "0";
			node.Attributes["E2_32"].Value = "0";
			node.Attributes["E2_34"].Value = "0";
			node.Attributes["E2_36"].Value = "0";
			node.Attributes["E2_41"].Value = "0";
			node.Attributes["E2_42"].Value = "0";
			node.Attributes["E2_44"].Value = "0";
			node.Attributes["E2_46"].Value = "0";
			node.Attributes["E2_51"].Value = "0";
			node.Attributes["E2_52"].Value = "0";
			node.Attributes["E2_54"].Value = "0";
			node.Attributes["E2_56"].Value = "0";
			node.Attributes["E2_66"].Value = "0";
			node.Attributes["E2_7"].Value = "0";
			node.Attributes["E2_8"].Value = "0";
			node.Attributes["E2_9"].Value = "0";
			node.Attributes["E2_10"].Value = "0";
			node.Attributes["E2_110"].Value = "0";
			node.Attributes["E2_120"].Value = "0";
			node.Attributes["E2_130"].Value = "0";
			#endregion

			#region angajatorE3
			//<angajatorE3 E3_11="" E3_12="" E3_13="" E3_14="" E3_21="" E3_22="" E3_23="" E3_24="" E3_31="" E3_32="" E3_33="" E3_34="" E3_41="" E3_42="" E3_43="" E3_44="" E3_total="" E3_suma=""/>
			node = xmlDoc.GetElementsByTagName("angajatorE3")[0];
			node.Attributes["E3_11"].Value = "0";
			node.Attributes["E3_12"].Value = "0";
			node.Attributes["E3_13"].Value = "0";
			node.Attributes["E3_14"].Value = "0";
			node.Attributes["E3_21"].Value = "0";
			node.Attributes["E3_22"].Value = "0";
			node.Attributes["E3_23"].Value = "0";
			node.Attributes["E3_24"].Value = "0";
			node.Attributes["E3_31"].Value = "0";
			node.Attributes["E3_32"].Value = "0";
			node.Attributes["E3_33"].Value = "0";
			node.Attributes["E3_34"].Value = "0";
			node.Attributes["E3_41"].Value = "0";
			node.Attributes["E3_42"].Value = "0";
			node.Attributes["E3_43"].Value = "0";
			node.Attributes["E3_44"].Value = "0";
			node.Attributes["E3_total"].Value = "0";
			node.Attributes["E3_suma"].Value = "0";
			#endregion

			#region angajatorE4
			//<angajatorE4 E4_aj_nr="" E4_aj_suma=""/>
			node = xmlDoc.GetElementsByTagName("angajatorE4")[0];
			node.Attributes["E4_aj_nr"].Value = "0";
			node.Attributes["E4_aj_suma"].Value = "0";
			#endregion

			#region angajatorF1 si angajatorF2
			//<angajatorF1 F1_suma=""/>
			//<angajatorF2 F2_cif="" F2_id="" F2_suma=""/>
			DataSet dsSumePunctLucru = sal.GetSumePunctLucru(angajatorID, lunaID);
			XmlNode nodeF1 = xmlDoc.GetElementsByTagName("angajatorF1")[0];
			XmlNode nodeF2 = xmlDoc.GetElementsByTagName("angajatorF2")[0];
			parent = nodeF2.ParentNode;
			foreach(DataRow dr in dsSumePunctLucru.Tables[0].Rows)
			{
				double bazaImpozitareCumulDeFunctii = Convert.ToDouble(dr["BazaImpozitareCumulDeFunctii"].ToString());
				double impozitCumulDeFunctii = Convert.ToDouble(dr["ImpozitCumulDeFunctii"].ToString());
				double bazaImpozitareCIMCuFctBaza = Convert.ToDouble(dr["BazaImpozitareCIMCuFctBaza"].ToString());
				double impozitCIMCuFctBaza = Convert.ToDouble(dr["ImpozitCIMCuFctBaza"].ToString());
				if (dr["SediuPrincipal"].ToString().Equals("1"))
				{
					nodeF1.Attributes["F1_suma"].Value = Math.Round(impozitCIMCuFctBaza + impozitCumulDeFunctii) + "";
				}
				else
				{
					XmlNode nodeF2Nou = nodeF2.CloneNode(true);
					nodeF2Nou.Attributes["F2_cif"].Value = dr["CUI"].ToString();
					nodeF2Nou.Attributes["F2_id"].Value = dr["NrCrtSediuSecundar"].ToString();
					nodeF2Nou.Attributes["F2_suma"].Value = Math.Round(impozitCIMCuFctBaza + impozitCumulDeFunctii) + "";
					parent.InsertAfter(nodeF2Nou, nodeF2);
				}
			}
			parent.RemoveChild(nodeF2);
			//--------------------------------------------------------------------------------------
			#endregion

			//pentru angajati
			DataSet dsCoasig = sal.GetDateCoasigurati(angajatorID, lunaID);
			DataSet dsConcediiMedicale = sal.GetConcediiMedicale(angajatorID, lunaID);
			node = xmlDoc.GetElementsByTagName("asigurat")[0];
			XmlNode lastNode = node;
			parent = node.ParentNode;
			c2_16 = 0;
			
			int nr = 0;
			foreach(DataRow dr in dsAsig.Tables[0].Rows)
			{
				nr++;
				Salaries.Business.Angajat ang = new Salaries.Business.Angajat();
				ang.AngajatId = Int32.Parse(dr["AngajatID"].ToString());

				#region asigurat
				XmlNode nodeAsigurat = node.CloneNode(true);
				//<asigurat cnpAsig="" idAsig="" numeAsig="" prenAsig="" cnpAnt="" numeAnt="" prenAnt="" dataAng="" dataSf="" casaSn="" asigCI="" asigSO="">
				nodeAsigurat.Attributes["cnpAsig"].Value = dr["CNP"].ToString();
				nodeAsigurat.Attributes["idAsig"].Value = nr.ToString();
				nodeAsigurat.Attributes["numeAsig"].Value = dr["Nume"].ToString();
				nodeAsigurat.Attributes["prenAsig"].Value = dr["Prenume"].ToString();
				//nodeAsigurat.Attributes["cnpAnt"].Value = "";
				//nodeAsigurat.Attributes["numeAnt"].Value = "";
				//nodeAsigurat.Attributes["prenAnt"].Value = "";
				DateTime dataAngajare = (DateTime) dr["DataDeLa"];
				nodeAsigurat.Attributes["dataAng"].Value = TransformToTwoDigits(dataAngajare.Day) + "." + TransformToTwoDigits(dataAngajare.Month) + "." + dataAngajare.Year;
				string d = dr["DataPanaLa"].ToString();
				if (dr["DataPanaLa"] is DBNull || d.Equals(""))
				{
					//nodeAsigurat.Attributes["dataSf"].Value = "31.12.2099";
					nodeAsigurat.Attributes.Remove(nodeAsigurat.Attributes["dataSf"]);
				}
				else
				{
					DateTime dataPanaLa = (DateTime) dr["DataPanaLa"];
					//nodeAsigurat.Attributes["dataSf"].Value = TransformToTwoDigits(dataPanaLa.Day) + "." + TransformToTwoDigits(dataPanaLa.Month) + "." + dataPanaLa.Year;
					if (luna.Data>dataPanaLa && dataPanaLa.Month == luna.Data.Month && dataPanaLa.Year == luna.Data.Year)
						nodeAsigurat.Attributes["dataSf"].Value = TransformToTwoDigits(dataPanaLa.Day) + "." + TransformToTwoDigits(dataPanaLa.Month) + "." + dataPanaLa.Year;
					else
						nodeAsigurat.Attributes.Remove(nodeAsigurat.Attributes["dataSf"]);
				}
				nodeAsigurat.Attributes["casaSn"].Value = dr["CodificareCasaDeAsig"].ToString();
				if (!(bool)dr["RetinereSanatate"])
					nodeAsigurat.Attributes["asigCI"].Value = "1";
				else
					nodeAsigurat.Attributes["asigCI"].Value = "2";
				if (!(bool)dr["RetinereSomaj"]) //nescutit
					nodeAsigurat.Attributes["asigSO"].Value = "1";
				else
					nodeAsigurat.Attributes["asigSO"].Value = "2";
				if ((bool)dr["Pensionar"])
					nodeAsigurat.Attributes["asigSO"].Value = "2";

				#endregion		

				#region coasigurati
				//<coAsigurati tip="" cnp="" nume="" prenume=""/>
				XmlNode nodeCoasigInitial = null;
				foreach(XmlNode n in nodeAsigurat.ChildNodes)
					if (n.Name.Equals("coAsigurati"))
					{
						nodeCoasigInitial = n;
						break;
					}

				XmlNode parentCoasig = nodeCoasigInitial.ParentNode;
				foreach(DataRow drCoAsig in dsCoasig.Tables[0].Rows)
				{
					string idAng = dr["AngajatID"].ToString();
					string id = drCoAsig["AngajatID"].ToString();
					if (id.Equals(idAng))
					{
						XmlNode nodeCoAsigurat = nodeCoasigInitial.CloneNode(true);
						nodeCoAsigurat.Attributes["tip"].Value = drCoAsig["TIPC"].ToString();
						nodeCoAsigurat.Attributes["cnp"].Value = drCoAsig["CNPC"].ToString();
						nodeCoAsigurat.Attributes["nume"].Value = drCoAsig["NUMEC"].ToString();
						nodeCoAsigurat.Attributes["prenume"].Value = drCoAsig["PRENUMEC"].ToString();
						parentCoasig.InsertAfter(nodeCoAsigurat, nodeCoasigInitial);
					}
				}
				parentCoasig.RemoveChild(nodeCoasigInitial);
				#endregion
				
				#region variabile
				int nrZileCBSoc = Int32.Parse(dr["NrOreConcediuBoalaFirma"].ToString());
				int nrZileCBCas = Int32.Parse(dr["NrOreConcediuBoalaBASS"].ToString());
				int programLucru = Int32.Parse(dr["ProgramLucru"].ToString());
				int nrZileLucratoareLuna = Int32.Parse(dr["NrZileLuna"].ToString());
				int nrZileLucrateLuna = Int32.Parse(dr["NrZileLucrateLuna"].ToString());
				int nrZileConcediuDeOdihna = Int32.Parse(dr["NrOreConcediuOdihna"].ToString());
				int nrZileEvenimDeoseb = Int32.Parse(dr["NrOreEvenimDeoseb"].ToString());
				int nrZileConcediuFaraPlata = Int32.Parse(dr["NrOreConcediuFaraPlata"].ToString());
				int nrOreSuplim100 = Int32.Parse(dr["NrOreSup100Proc"].ToString());
				int nrOreSuplim50 = Int32.Parse(dr["NrOreSup50Proc"].ToString());
				
				double venitBrut = Convert.ToDouble(dr["VenitBrut"].ToString());
				double sumaCBFirma = Convert.ToDouble(dr["SumaConcediuBoalaFirma"].ToString());
				double sumaCBCas = Convert.ToDouble(dr["SumaConcediuBoalaBASS"].ToString());
				double ajutorDeces = Convert.ToDouble(dr["AjutorDeces"].ToString());
				
				/*double bcSomaj = 0;
				if (!(bool)dr["Pensionar"])
					bcSomaj = Minim(venitBrut - sumaCBCas, 5 * smbe);*/
				double bcSomaj = Convert.ToDouble(dr["BCContribIndivAsigSomaj"].ToString());
				
				/*double bcCas = 0;
				//'=min((Vb - S cb CAS - S cb soc + (SMBE * 35%) * (Z cb soc / Z lucratoare) ) ; 5*SMBE)
				if (!(bool)dr["Pensionar"])
					bcCas = Minim( venitBrut - sumaCBCas - sumaCBFirma + smbe * Convert.ToDouble("0.35") * nrZileCBSoc / nrZileLucratoareLuna, 5 * smbe);
				*/
				double bcCas = Convert.ToDouble(dr["BCContribIndivAsigSoc"].ToString());
				
				/*double bcSanatate = 0;
				//'=Vb - S cb CAS - suma ajutor de deces
				if (!(bool)dr["Pensionar"])
					bcSanatate = Minim(venitBrut - sumaCBCas - ajutorDeces, 5 * smbe);*/
				double bcSanatate = Convert.ToDouble(dr["BCContribIndivSanatate"].ToString());

				double contribSomaj = Convert.ToDouble(dr["ContributieIndivSomaj"].ToString());
				double contribCas = Convert.ToDouble(dr["ContributieIndivAsigurariSociale"].ToString());
				double contribSanatate = Convert.ToDouble(dr["ContributieIndivSanatate"].ToString());
				
				//pt reinisch
				if ((bool)dr["RetinereSomaj"] && (bool)dr["RetinereSanatate"] && (bool)dr["RetinereCAS"])
				{
					venitBrut = 0;
					sumaCBFirma = 0;
					sumaCBCas = 0;
					ajutorDeces = 0;
					bcSomaj = 0;
					bcCas = 0;
				    bcSanatate = 0;
					contribSomaj = 0;
					contribCas = 0;
					contribSanatate = 0;
				}

				XmlNode nodeAsiguratA = null;
				XmlNode nodeAsiguratB1 = null;
				XmlNode nodeAsiguratB11 = null;
				XmlNode nodeAsiguratB2 = null;
				XmlNode nodeAsiguratB3 = null;
				XmlNode nodeAsiguratB4 = null;
				XmlNode nodeAsiguratC = null;
				XmlNode nodeAsiguratD = null;
				XmlNode nodeAsiguratE1 = null;
				XmlNode nodeAsiguratE2 = null;
				XmlNode nodeAsiguratE3 = null;

				string programLucruNormal = "8";
				foreach(XmlNode n in nodeAsigurat.ChildNodes)
				{
					if (n.Name.Equals("asiguratA"))
						nodeAsiguratA = n;
					if (n.Name.Equals("asiguratB1"))
						nodeAsiguratB1 = n;
					if (n.Name.Equals("asiguratB2"))
						nodeAsiguratB2 = n;
					if (n.Name.Equals("asiguratB3"))
						nodeAsiguratB3 = n;
					if (n.Name.Equals("asiguratB4"))
						nodeAsiguratB4 = n;
					if (n.Name.Equals("asiguratC"))
						nodeAsiguratC = n;
					if (n.Name.Equals("asiguratD"))
						nodeAsiguratD = n;
					if (n.Name.Equals("asiguratE1"))
						nodeAsiguratE1 = n;
					if (n.Name.Equals("asiguratE2"))
						nodeAsiguratE2 = n;
					if (n.Name.Equals("asiguratE3"))
						nodeAsiguratE3 = n;
				}
				#endregion

				int nrZileSuspendateContract = ang.GetNrZileSuspendateContract(lunaID);
				double vbRealizat = venitBrut - sumaCBFirma - sumaCBCas - ajutorDeces;
				string sectiunea = "";
						
				if ((nrZileCBSoc + nrZileCBCas == 0) && (!(bool)dr["RetinereSomaj"] && !(bool)dr["RetinereSanatate"] && !(bool)dr["RetinereCAS"]))
				{
					sectiunea = "A";
					#region asiguratA
					//<asiguratA A_1="" A_2="" A_3="" A_4="" A_5="" A_6="" A_7="" A_8="" A_9="" A_10="" A_11="" A_12="" A_13="" A_14="" A_20=""/>
//					nodeAsiguratA.Attributes["A_1"].Value = "1";
					nodeAsiguratA.Attributes["A_1"].Value = dr["TipAsiguratID"].ToString();
					if ((bool)dr["Pensionar"])
						nodeAsiguratA.Attributes["A_2"].Value = "1";
					else
						nodeAsiguratA.Attributes["A_2"].Value = "0";
					if (dr["ProgramLucru"].ToString().Equals(programLucruNormal))
						nodeAsiguratA.Attributes["A_3"].Value = "N";
					else
						nodeAsiguratA.Attributes["A_3"].Value = "P" + dr["ProgramLucru"].ToString();
					nodeAsiguratA.Attributes["A_4"].Value = programLucruNormal;
					nodeAsiguratA.Attributes["A_5"].Value = Math.Round(venitBrut) + "";
					int oreLucrate = programLucru * ( nrZileLucrateLuna + nrZileConcediuDeOdihna + nrZileEvenimDeoseb); // + nrOreSuplim100 + nrOreSuplim50;
					int oreSuspendate = programLucru * ( nrZileConcediuFaraPlata + nrZileSuspendateContract);
					int totalZileLucrate = nrZileLucrateLuna + nrZileConcediuDeOdihna + nrZileEvenimDeoseb;
					if ((bcSomaj > 0) && (oreLucrate == 0))
					{
						oreLucrate = programLucru;
						oreSuspendate = oreSuspendate - programLucru;
						totalZileLucrate = 1;
					}
					nodeAsiguratA.Attributes["A_6"].Value = oreLucrate.ToString();
					nodeAsiguratA.Attributes["A_7"].Value = oreSuspendate.ToString();
					nodeAsiguratA.Attributes["A_8"].Value = totalZileLucrate.ToString();
					
                    //nodeAsiguratA.Attributes["A_9"].Value =  Math.Round(bcSomaj) + "";
					//nodeAsiguratA.Attributes["A_10"].Value = Math.Round(contribSomaj) + "";
					// Lungu Andreea - 25.04.2012
					if (nodeAsigurat.Attributes["asigSO"].Value.Equals("2"))
					{
						nodeAsiguratA.Attributes["A_9"].Value = "0";
						nodeAsiguratA.Attributes["A_10"].Value = "0";
						int nrAsigSomaj = Int32.Parse(nodeAngajatorB.Attributes["B_cnp"].Value) - 1;
						nodeAngajatorB.Attributes["B_cnp"].Value = nrAsigSomaj.ToString();
					}
					else
					{
						nodeAsiguratA.Attributes["A_9"].Value =  Math.Round(venitBrut - sumaCBCas) + "";
						nodeAsiguratA.Attributes["A_10"].Value = Math.Round(ROUNDUP((venitBrut - sumaCBCas) * procentPBCISOM / 100)) + "";
					}
					//nodeAsiguratA.Attributes["A_11"].Value = Math.Round(bcSanatate) + "";
					//nodeAsiguratA.Attributes["A_12"].Value = Math.Round(contribSanatate) + "";
					nodeAsiguratA.Attributes["A_11"].Value = Math.Round(vbRealizat) + "";
					nodeAsiguratA.Attributes["A_12"].Value = Math.Round(ROUNDUP(procentPBCISAN * vbRealizat / 100)) + "";
					
					/*if ((bool)dr["RetinereCAS"]) //scutit
					{
						if (vbRealizat < 5 * smbe)
						{
							nodeAsiguratA.Attributes["A_13"].Value = Math.Round(vbRealizat) + "";
							nodeAsiguratA.Attributes["A_14"].Value = Math.Round(procentPBCICAS * vbRealizat / 100) + "";
						}
						else
						{
							nodeAsiguratA.Attributes["A_13"].Value = Math.Round(5 * smbe) + "";
							nodeAsiguratA.Attributes["A_14"].Value = Math.Round(procentPBCICAS * 5 *smbe / 100) + "";
						}
					}
					else
					{*/
						nodeAsiguratA.Attributes["A_13"].Value = Math.Round(bcCas) + "";
						nodeAsiguratA.Attributes["A_14"].Value = Math.Round(contribCas) + "";
					//}
					
					//if (vbRealizat < 5 * smbe)
					//	nodeAsiguratA.Attributes["A_20"].Value = Math.Round(vbRealizat) + "";
					//else
					//	nodeAsiguratA.Attributes["A_20"].Value = Math.Round(5 * smbe) + "";
					nodeAsiguratA.Attributes["A_20"].Value = Math.Round(venitBrut) + "";

					nodeAsigurat.RemoveChild(nodeAsiguratB1);
					nodeAsigurat.RemoveChild(nodeAsiguratB2);
					nodeAsigurat.RemoveChild(nodeAsiguratB3);
					nodeAsigurat.RemoveChild(nodeAsiguratB4);
					nodeAsigurat.RemoveChild(nodeAsiguratC);
					nodeAsigurat.RemoveChild(nodeAsiguratD);

					#endregion
				}
				else
				{
					sectiunea = "B";
					nodeAsigurat.RemoveChild(nodeAsiguratA);
					foreach(XmlNode n in nodeAsiguratB1.ChildNodes)
					{
						if (n.Name.Equals("asiguratB11"))
							nodeAsiguratB11 = n;
					}				

					#region asiguratB11
					//<asiguratB11 B11_1="" B11_2="" B11_3="" B11_41="" B11_42="" B11_43="" B11_5="" B11_6="" B11_71="" B11_72="" B11_73=""/>	
					if (!(bool)dr["RetinereSomaj"] && !(bool)dr["RetinereSanatate"] && !(bool)dr["RetinereCAS"])
						nodeAsiguratB1.RemoveChild(nodeAsiguratB11);
					else
					{
						//pt reinisch
						if ((bool)dr["RetinereSomaj"] && (bool)dr["RetinereSanatate"] && (bool)dr["RetinereCAS"])
						{
							nodeAsiguratB1.RemoveChild(nodeAsiguratB11);
							nodeAsiguratB11.Attributes["B11_1"].Value = "3";
						}
						else
						{
							nodeAsiguratB11.Attributes["B11_1"].Value = "2";
							if ((bool)dr["Pensionar"])
								nodeAsiguratB11.Attributes["B11_2"].Value = venitBrut.ToString();
							else
							{
								if ((bool)dr["RetinereSomaj"]) //scutit
								{
									nodeAsiguratB11.Attributes["B11_2"].Value = Math.Round(venitBrut - bcSomaj) + "";
								}
								else
									nodeAsiguratB11.Attributes["B11_2"].Value = "0";
							}
							if ((bool)dr["RetinereSanatate"]) //scutit
							{
								nodeAsiguratB11.Attributes["B11_3"].Value = Math.Round(venitBrut - bcSanatate) + "";
							}
							else
								nodeAsiguratB11.Attributes["B11_3"].Value = "0";
							if ((bool)dr["RetinereCAS"]) //scutit
							{
								nodeAsiguratB11.Attributes["B11_41"].Value = Math.Round(venitBrut - bcCas) + "";
							}
							else
								nodeAsiguratB11.Attributes["B11_41"].Value = "0";
							nodeAsiguratB11.Attributes["B11_42"].Value = "0";
							nodeAsiguratB11.Attributes["B11_43"].Value = "0";

							nodeAsiguratB11.Attributes["B11_5"].Value = "0";
							//						if ((bool)dr["Pensionar"])
							//							nodeAsiguratB11.Attributes["B11_5"].Value = Math.Round(venitBrut) + "";
							//						else
							//						{
							//							if ((bool)dr["RetinereSomaj"]) //scutit
							//							{
							//								nodeAsiguratB11.Attributes["B11_5"].Value = Math.Round(venitBrut - bcSomaj) + "";
							//							}
							//							else
							//								nodeAsiguratB11.Attributes["B11_5"].Value = "0";
							//						}
							if ((bool)dr["RetinereSanatate"]) //scutit
							{
								nodeAsiguratB11.Attributes["B11_6"].Value = Math.Round(venitBrut - bcSanatate) + "";
							}
							else
								nodeAsiguratB11.Attributes["B11_6"].Value = "0";
							if ((bool)dr["RetinereCAS"]) //scutit
							{
								nodeAsiguratB11.Attributes["B11_71"].Value = Math.Round(venitBrut - bcCas) + "";
							}
							else
								nodeAsiguratB11.Attributes["B11_71"].Value = "0";
							//nodeAsiguratB11.Attributes["B11_71"].Value = "0";
							nodeAsiguratB11.Attributes["B11_72"].Value = "0";
							nodeAsiguratB11.Attributes["B11_73"].Value = "0";

							if (nodeAsiguratB11.Attributes["B11_1"].Value.Equals("2"))
								nodeAsiguratB11.Attributes["B11_71"].Value = "0";
						}
					}
					#endregion
	
					#region asiguratB1
					//B1 - 5 aparitii??
					//<asiguratB1 B1_1="" B1_2="" B1_3="" B1_4="" B1_5="" B1_6="" B1_7="" B1_8="" B1_9="" B1_10="" B1_15=""> </asiguratB1>
					//nodeAsiguratB1.Attributes["B1_1"].Value = "1";
					nodeAsiguratB1.Attributes["B1_1"].Value = dr["TipAsiguratID"].ToString();
					nodeAsiguratB1.Attributes["B1_2"].Value = dr["Pensionar"].ToString();
					if ((bool)dr["Pensionar"])
						nodeAsiguratB1.Attributes["B1_2"].Value = "1";
					else
						nodeAsiguratB1.Attributes["B1_2"].Value = "0";
					
					if (dr["ProgramLucru"].ToString().Equals(programLucruNormal))
						nodeAsiguratB1.Attributes["B1_3"].Value = "N";
					else
						nodeAsiguratB1.Attributes["B1_3"].Value = "P" + dr["ProgramLucru"].ToString();
					nodeAsiguratB1.Attributes["B1_4"].Value = programLucruNormal;
					nodeAsiguratB1.Attributes["B1_5"].Value = Math.Round(venitBrut) + "";
				
					int oreLucrate = programLucru * ( nrZileLucrateLuna + nrZileConcediuDeOdihna + nrZileEvenimDeoseb + nrZileCBSoc); // + nrOreSuplim100 + nrOreSuplim50;
					int oreSuspendate = programLucru * ( nrZileConcediuFaraPlata + nrZileCBCas + nrZileSuspendateContract);
					int totalZileLucrate = nrZileLucrateLuna + nrZileConcediuDeOdihna + nrZileEvenimDeoseb;
					if ((bcSomaj > 0) && (oreLucrate == 0))
					{
						oreLucrate = programLucru;
						oreSuspendate = oreSuspendate - programLucru;
						//totalZileLucrate = 1;
					}
					nodeAsiguratB1.Attributes["B1_6"].Value = oreLucrate.ToString();
					nodeAsiguratB1.Attributes["B1_7"].Value = oreSuspendate.ToString();
					
					nodeAsiguratB1.Attributes["B1_8"].Value = "0";
					nodeAsiguratB1.Attributes["B1_9"].Value = "0";
					//nodeAsiguratB1.Attributes["B1_10"].Value =  Math.Round(bcSomaj) + "";
					nodeAsiguratB1.Attributes["B1_10"].Value =  Math.Round(venitBrut - sumaCBCas)+ "";
					if (oreLucrate.ToString() == "0" && !(bool)dr["RetinereSomaj"])
					{
					nodeAsiguratB1.Attributes["B1_10"].Value =  "0";
					}
					
					//int totalZileLucrate = nrZileLucrateLuna + nrZileConcediuDeOdihna + nrZileEvenimDeoseb + nrZileCBCas + nrZileCBSoc;
					nodeAsiguratB1.Attributes["B1_15"].Value = totalZileLucrate.ToString();
					#endregion

					#region asiguratB2
					//<asiguratB2 B2_1="" B2_2="" B2_3="" B2_4="" B2_5="" B2_6="" B2_7="" />
					nodeAsiguratB2.Attributes["B2_1"].Value = "0";
					nodeAsiguratB2.Attributes["B2_2"].Value = totalZileLucrate.ToString();
					nodeAsiguratB2.Attributes["B2_3"].Value = "0";
					nodeAsiguratB2.Attributes["B2_4"].Value = "0";
					//nodeAsiguratB2.Attributes["B2_5"].Value = Math.Round(venitBrut) + "";
					nodeAsiguratB2.Attributes["B2_5"].Value = Math.Round(vbRealizat) + "";
//					if (totalZileLucrate.ToString() == "0")
//					{
//					nodeAsiguratB2.Attributes["B2_5"].Value = "0";
//					}
					nodeAsiguratB2.Attributes["B2_6"].Value = "0";
					nodeAsiguratB2.Attributes["B2_7"].Value = "0";
					#endregion
					
					#region asiguratB3
					//<asiguratB3 B3_1="" B3_2="" B3_3="" B3_4="" B3_5="" B3_6="" B3_7="" B3_8="" B3_9="" B3_10="" B3_11="" B3_12="" B3_13="" />
					nodeAsiguratB3.Attributes["B3_1"].Value = ((int)nrZileCBSoc + nrZileCBCas).ToString();
					nodeAsiguratB3.Attributes["B3_2"].Value = "0";
					nodeAsiguratB3.Attributes["B3_3"].Value = "0";
					nodeAsiguratB3.Attributes["B3_4"].Value = "0";
					nodeAsiguratB3.Attributes["B3_5"].Value = "0";
					nodeAsiguratB3.Attributes["B3_6"].Value = ((int)nrZileCBSoc + nrZileCBCas).ToString();
					int b3_6 = nrZileCBSoc + nrZileCBCas;
					double bcicas = (smbe * 35 * b3_6) / (nrZileLucratoareLuna * 100);
					nodeAsiguratB3.Attributes["B3_7"].Value = ROUNDUP(bcicas)+"";
					//double bcicas = smbe * Convert.ToDouble("0.35") * nrZileCBSoc / nrZileLucratoareLuna;
					//nodeAsiguratB3.Attributes["B3_7"].Value = Math.Round(bcicas) + "";
					nodeAsiguratB3.Attributes["B3_8"].Value = "0";
					nodeAsiguratB3.Attributes["B3_9"].Value = "0";
					//nodeAsiguratB3.Attributes["B3_10"].Value = Math.Round(sumaCBFirma) + "";
					nodeAsiguratB3.Attributes["B3_10"].Value = "0";
					int b3_7 = Int32.Parse(nodeAsiguratB3.Attributes["B3_7"].Value);
					int b3_9 = Int32.Parse(nodeAsiguratB3.Attributes["B3_9"].Value);
					int b3_10 = Int32.Parse(nodeAsiguratB3.Attributes["B3_10"].Value);
					//nodeAsiguratB3.Attributes["B3_11"].Value = Math.Round(sumaCBCas + sumaCBFirma) + "";
					nodeAsiguratB3.Attributes["B3_11"].Value = ((int)(b3_7 + b3_9 + b3_10)).ToString();
					nodeAsiguratB3.Attributes["B3_12"].Value = Math.Round(sumaCBFirma) + "";
					nodeAsiguratB3.Attributes["B3_13"].Value = Math.Round(ROUNDUP(sumaCBCas)) + "";
					#endregion

					#region asiguratB4
					//<asiguratB4 B4_1="" B4_2="" B4_3="" B4_4="" B4_5="" B4_6="" B4_7="" B4_8="" B4_14="" />
					//nodeAsiguratB4.Attributes["B4_1"].Value = totalZileLucrate.ToString();
					nodeAsiguratB4.Attributes["B4_1"].Value = totalZileLucrate.ToString();
					nodeAsiguratB4.Attributes["B4_2"].Value = "0";
					//nodeAsiguratB4.Attributes["B4_3"].Value = Math.Round(bcSomaj) + "";
					//nodeAsiguratB4.Attributes["B4_4"].Value = Math.Round(contribSomaj) + "";
					nodeAsiguratB4.Attributes["B4_3"].Value = Math.Round(venitBrut - sumaCBCas) + "";
					if (oreLucrate.ToString() == "0" && !(bool)dr["RetinereSomaj"])
					{
						nodeAsiguratB4.Attributes["B4_3"].Value =  "0";
					}
					if (dr["Pensionar"].ToString() == "False")
					{
						nodeAsiguratB4.Attributes["B4_4"].Value = Math.Round(ROUNDUP((venitBrut - sumaCBCas) * procentPBCISOM / 100)) + "";
					}
					else
					{
					nodeAsiguratB4.Attributes["B4_4"].Value = "0";
					}


					int b2_5 = Int32.Parse(nodeAsiguratB2.Attributes["B2_5"].Value);
					int b2_6 = Int32.Parse(nodeAsiguratB2.Attributes["B2_6"].Value);
					int b2_7 = Int32.Parse(nodeAsiguratB2.Attributes["B2_7"].Value);
					nodeAsiguratB4.Attributes["B4_5"].Value = ((int)(b2_5 + b2_6 + b2_7)).ToString();
										
					//nodeAsiguratB4.Attributes["B4_5"].Value = Math.Round(bcSanatate) + "";

						nodeAsiguratB4.Attributes["B4_6"].Value = Math.Round(ROUNDUP(procentPBCISAN * (b2_5 + b2_6 + b2_7) / 100)) + "";
					//nodeAsiguratB4.Attributes["B4_6"].Value = Math.Round(contribSanatate) + "";
					//nodeAsiguratB4.Attributes["B4_7"].Value = Math.Round(bcCas) + "";
					double b4_7 = Minim(b2_5 + b2_6 + b2_7 + b3_7, 5 * smbe);
					nodeAsiguratB4.Attributes["B4_7"].Value = Math.Round(b4_7) + "";
					
					//nodeAsiguratB4.Attributes["B4_8"].Value = Math.Round(contribCas) + "";
					nodeAsiguratB4.Attributes["B4_8"].Value = Math.Round(procentPBCICAS * b4_7 / 100) + "";
					nodeAsiguratB4.Attributes["B4_14"].Value = Math.Round(venitBrut - ajutorDeces) + "";
					#endregion
									
					#region asiguratC
                    //<asiguratC C_1="" C_2="" C_3="" C_4="" C_5="" C_6="" C_7="" C_8="" C_9="" C_10="" C_11="" C_12="" C_13="" C_14="" C_15="" C_16="" C_17="" C_18="" C_19="" />
					nodeAsiguratC.Attributes["C_1"].Value = "0";
					nodeAsiguratC.Attributes["C_2"].Value = "0";
					nodeAsiguratC.Attributes["C_3"].Value = "0";
					nodeAsiguratC.Attributes["C_4"].Value = "0";
					nodeAsiguratC.Attributes["C_5"].Value = "0";
					nodeAsiguratC.Attributes["C_6"].Value = "0";
					nodeAsiguratC.Attributes["C_7"].Value = "0";
					nodeAsiguratC.Attributes["C_8"].Value = "0";
					nodeAsiguratC.Attributes["C_9"].Value = "0";
					nodeAsiguratC.Attributes["C_10"].Value = "0";
					nodeAsiguratC.Attributes["C_11"].Value = "0";
					nodeAsiguratC.Attributes["C_12"].Value = "0";
					nodeAsiguratC.Attributes["C_13"].Value = "0";
					nodeAsiguratC.Attributes["C_14"].Value = "0";
					nodeAsiguratC.Attributes["C_15"].Value = "0";
					nodeAsiguratC.Attributes["C_16"].Value = "0";
					nodeAsiguratC.Attributes["C_17"].Value = "0";
					nodeAsiguratC.Attributes["C_18"].Value = "0";
					nodeAsiguratC.Attributes["C_19"].Value = "0";
					nodeAsigurat.RemoveChild(nodeAsiguratC);
					#endregion

					#region asiguratD
					//<asiguratD D_1="" D_2="" D_3="" D_4="" D_5="" D_6="" D_7="" D_8="" D_9="" D_10="" D_11="" D_12="" D_13="" D_14="" D_15="" D_16="" D_17="" D_18="" D_19="" D_20="" D_21="" />
					XmlNode parentConcMedical = nodeAsiguratD.ParentNode;
					foreach(DataRow drConcMedical in dsConcediiMedicale.Tables[0].Rows)
					{
						string idAng = dr["AngajatID"].ToString();
						string id = drConcMedical["AngajatID"].ToString();
						if (id.Equals(idAng))
						{
							XmlNode nodeConcMedical = nodeAsiguratD.CloneNode(true);
							nodeConcMedical.Attributes["D_1"].Value = drConcMedical["SerieCertificat"].ToString();
							nodeConcMedical.Attributes["D_2"].Value = drConcMedical["NumarCertificat"].ToString();
							nodeConcMedical.Attributes["D_3"].Value = drConcMedical["SerieCertificatInitial"].ToString();
							nodeConcMedical.Attributes["D_4"].Value = drConcMedical["NumarCertificatInitial"].ToString();
							
							//DateTime dataAcordariiCertif = (DateTime) drConcMedical["DataAcordariiCertificat"];
							//DateTime dataAcordariiCertif = DateTime.Now;
							DateTime dataStart = (DateTime) drConcMedical["DataStartConc"];
							DateTime dataEnd = (DateTime) drConcMedical["DataEndConc"];
							DateTime dataAcordariiCertif = dataStart;
							nodeConcMedical.Attributes["D_5"].Value = TransformToTwoDigits(dataAcordariiCertif.Day) + "." + TransformToTwoDigits(dataAcordariiCertif.Month) + "." + dataAcordariiCertif.Year;
							nodeConcMedical.Attributes["D_6"].Value = TransformToTwoDigits(dataStart.Day) + "." + TransformToTwoDigits(dataStart.Month) + "." + dataStart.Year;
							nodeConcMedical.Attributes["D_7"].Value = TransformToTwoDigits(dataEnd.Day) + "." + TransformToTwoDigits(dataEnd.Month) + "." + dataEnd.Year;
							string cnpCopil = drConcMedical["CnpCopil"].ToString();
							if (!cnpCopil.Equals(""))
								nodeConcMedical.Attributes["D_8"].Value = cnpCopil;
							else
								nodeConcMedical.Attributes.Remove(nodeConcMedical.Attributes["D_8"]);
							nodeConcMedical.Attributes["D_9"].Value = drConcMedical["Cod"].ToString();
							string d9 = nodeConcMedical.Attributes["D_9"].Value;

							//nodeConcMedical.Attributes["D_10"].Value = "1";
							string locPrescriere = drConcMedical["LocPrescriereCertificat"].ToString();
							if (!locPrescriere.Equals(""))
								locPrescriere = locPrescriere.Substring(0,locPrescriere.IndexOf("-")).Trim();
							else
								locPrescriere = "1";
							nodeConcMedical.Attributes["D_10"].Value = locPrescriere;
							
							//D_11 si D_12 nu pot fi completate simultan - pentru D_9 = 06 D_12=null
							//D_11 si D_12 nu pot fi completate simultan - pentru D_9 = 05 D_11= null
							if (!d9.Equals("05"))
							{
								nodeConcMedical.Attributes["D_11"].Value = drConcMedical["CodUrgenta"].ToString();
								nodeConcMedical.Attributes.Remove(nodeConcMedical.Attributes["D_12"]);
							}
							else
							{
								nodeConcMedical.Attributes["D_12"].Value = drConcMedical["CodUrgenta"].ToString();
								nodeConcMedical.Attributes.Remove(nodeConcMedical.Attributes["D_11"]);
							}
							nodeConcMedical.Attributes["D_13"].Value = drConcMedical["NrAvizMedicExpert"].ToString();

							nodeConcMedical.Attributes["D_14"].Value = drConcMedical["NrZileFirma"].ToString();
							nodeConcMedical.Attributes["D_15"].Value = drConcMedical["NrZileBASS"].ToString();
							int d_14 = Int32.Parse(nodeConcMedical.Attributes["D_14"].Value);
							int d_15 = Int32.Parse(nodeConcMedical.Attributes["D_15"].Value);
							nodeConcMedical.Attributes["D_16"].Value = ((int)(d_14 + d_15)).ToString();
							
							
							DataSet dsMz =  ang.GetMedieZilnicaConcediuDeBoalaDataSet(lunaID);
							double sumaMediaZilnica = Convert.ToDouble(drConcMedical["SumaMedieZilnica"].ToString());
							//double sumaMediaZilnica = Convert.ToDouble(dsMz.Tables[0].Rows[0]["SumaMediaZilnica"].ToString());
                            // todo - SumaMediaZilnica, NrZileMediaZilnica
							nodeConcMedical.Attributes["D_17"].Value = Math.Round(sumaMediaZilnica) + "";
							//nodeConcMedical.Attributes["D_18"].Value = dsMz.Tables[0].Rows[0]["NrZileMediaZilnica"].ToString();
							nodeConcMedical.Attributes["D_18"].Value = drConcMedical["NrZileMedieZilnica"].ToString();
							
							double mediaZilnica = Convert.ToDouble(drConcMedical["MedieZilnica"].ToString());
							//double mediaZilnica = Convert.ToDouble(dsMz.Tables[0].Rows[0]["MediaZilnica"].ToString());
							//nodeConcMedical.Attributes["D_19"].Value = ((string)(Math.Round(mediaZilnica, 4) + "")).Replace(",",".");
							nodeConcMedical.Attributes["D_19"].Value = ((string)(Math.Round(mediaZilnica, 2) + "")).Replace(",",".");
							
							double sumaCBSoc_concMedical = Convert.ToDouble(drConcMedical["SumaFirma"].ToString());
							double sumaCBBASS_concMedical = Convert.ToDouble(drConcMedical["SumaBASS"].ToString());
							nodeConcMedical.Attributes["D_20"].Value = Math.Round(sumaCBSoc_concMedical) + "";
							nodeConcMedical.Attributes["D_21"].Value = Math.Round(ROUNDUP(sumaCBBASS_concMedical)) + "";
							
							for (int i = 0; i< nodeConcMedical.Attributes.Count; i++)
							{
								XmlAttribute at = nodeConcMedical.Attributes[i];
								if (at.Value.Equals(""))
								{
									nodeConcMedical.Attributes.Remove(at);
									i--;
								}
							}
							
							parentConcMedical.InsertAfter(nodeConcMedical, nodeAsiguratD);

							/*string d_9 = nodeConcMedical.Attributes["D_9"].Value;
							if (d_9.Equals("01") || d_9.Equals("02") || d_9.Equals("03") || d_9.Equals("04") || d_9.Equals("05") || d_9.Equals("06") || d_9.Equals("12") || d_9.Equals("13") || d_9.Equals("14"))
								c2_16 += Convert.ToDouble(nodeConcMedical.Attributes["D_21"].Value);*/
						}
					}
					parentConcMedical.RemoveChild(nodeAsiguratD);
					#endregion

				}

				#region asiguratE3

				nodeAsiguratE3.Attributes["E3_1"].Value = sectiunea;
				nodeAsiguratE3.Attributes["E3_2"].Value = dr["TipAsiguratID"].ToString();
				if (dr["ModIncadrare"].ToString() == "False")
				{
					nodeAsiguratE3.Attributes["E3_3"].Value = "1";
				}
				else
				{
					nodeAsiguratE3.Attributes["E3_3"].Value = "2";
				}
				nodeAsiguratE3.Attributes["E3_4"].Value = "P";
				//nodeAsiguratE3.Attributes["E3_5"].Value = 
				//nodeAsiguratE3.Attributes["E3_6"].Value = 
				//nodeAsiguratE3.Attributes["E3_7"].Value = 
				
				nodeAsiguratE3.Attributes["E3_8"].Value = Math.Round(Convert.ToDouble(dr["VenitBrut"].ToString())).ToString();
				
				int E3_9 = 0;
				if (sectiunea == "A")
				{
					int A_10 = Int32.Parse(nodeAsiguratA.Attributes["A_10"].Value);
					int A_12 = Int32.Parse(nodeAsiguratA.Attributes["A_12"].Value);
					int A_14 = Int32.Parse(nodeAsiguratA.Attributes["A_14"].Value);
					E3_9 = A_10 + A_12 + A_14;
				}
				else
				{
					int B4_4 = Int32.Parse(nodeAsiguratB4.Attributes["B4_4"].Value);
					int B4_6 = Int32.Parse(nodeAsiguratB4.Attributes["B4_6"].Value);
					int B4_8 = Int32.Parse(nodeAsiguratB4.Attributes["B4_8"].Value);
					E3_9 = B4_4 + B4_6 + B4_8;
				}
				nodeAsiguratE3.Attributes["E3_9"].Value = E3_9.ToString();

				nodeAsiguratE3.Attributes["E3_10"].Value = Math.Round(Convert.ToDouble(dr["ValoareTichete"].ToString())).ToString();
				DataSet dsPersIntr = sal.GetPersoaneInIntretinere(Convert.ToInt64(dr["AngajatID"].ToString()));
				int nrPersInIntretinere = dsPersIntr.Tables[0].Rows.Count;
				nodeAsiguratE3.Attributes["E3_11"].Value = nrPersInIntretinere.ToString();
				nodeAsiguratE3.Attributes["E3_12"].Value = Math.Round(Convert.ToDouble(dr["DeduceriPersonale"].ToString())).ToString();
				nodeAsiguratE3.Attributes["E3_13"].Value = "0";
				nodeAsiguratE3.Attributes["E3_14"].Value = Math.Round(Convert.ToDouble(dr["BazaImpozitare"].ToString())).ToString();
				nodeAsiguratE3.Attributes["E3_15"].Value = Math.Round(Convert.ToDouble(dr["Impozit"].ToString())).ToString();
				nodeAsiguratE3.Attributes["E3_16"].Value = Math.Round(Convert.ToDouble(dr["RestDePlata"].ToString())).ToString();
				#endregion

				if (dr["ModIncadrare"].ToString() == "False")
				{
					#region asiguratE1

					nodeAsiguratE1.Attributes["E1_1"].Value = Math.Round(Convert.ToDouble(dr["VenitBrut"].ToString())).ToString();
					nodeAsiguratE1.Attributes["E1_2"].Value = E3_9.ToString();
					nodeAsiguratE1.Attributes["E1_3"].Value = nrPersInIntretinere.ToString();
					nodeAsiguratE1.Attributes["E1_4"].Value = Math.Round(Convert.ToDouble(dr["DeduceriPersonale"].ToString())).ToString();
					nodeAsiguratE1.Attributes["E1_5"].Value = "0";
					nodeAsiguratE1.Attributes["E1_6"].Value = Math.Round(Convert.ToDouble(dr["BazaImpozitare"].ToString())).ToString();
					nodeAsiguratE1.Attributes["E1_7"].Value = Math.Round(Convert.ToDouble(dr["Impozit"].ToString())).ToString();
					nodeAsigurat.RemoveChild(nodeAsiguratE2);
					#endregion
				}
				else
				{
					#region asiguratE2

					nodeAsiguratE2.Attributes["E2_1"].Value = Math.Round(Convert.ToDouble(dr["VenitBrut"].ToString())).ToString();
					nodeAsiguratE2.Attributes["E2_2"].Value = E3_9.ToString();
					nodeAsiguratE2.Attributes["E2_3"].Value = Math.Round(Convert.ToDouble(dr["BazaImpozitare"].ToString())).ToString();
					nodeAsiguratE2.Attributes["E2_4"].Value = Math.Round(Convert.ToDouble(dr["Impozit"].ToString())).ToString();
					nodeAsigurat.RemoveChild(nodeAsiguratE1);
					nodeAsiguratE3.Attributes.Remove(nodeAsiguratE3.Attributes["E3_11"]);
					nodeAsiguratE3.Attributes.Remove(nodeAsiguratE3.Attributes["E3_12"]);
					nodeAsiguratE3.Attributes.Remove(nodeAsiguratE3.Attributes["E3_13"]);
					#endregion
				}
				

				parent.InsertAfter(nodeAsigurat, lastNode);
				lastNode = nodeAsigurat;
			}
			parent.RemoveChild(node);

			//nodeAngajatorC2.Attributes["C2_16"].Value = Math.Round(c2_16) + "";

			path = Salaries.Configuration.CryptographyClass.getSettingsWithoutDecode(importLogFolder) + "\\DecUnicaOut.xml";
						
			//path = "C:\\Inetpub\\wwwroot\\hr\\InterfataSalarii\\Templates\\DecUnicaOut.xml";
			xmlDoc.Save(path);

			path = this.Page.Request.Url.AbsoluteUri;
			path = path.Substring(0, path.LastIndexOf("/"));
			hyperLinkDeclaratie.NavigateUrl = path + "/Templates/DecUnicaOut.xml";
			hyperLinkDeclaratie.Visible = true;

			//btnValideaza.Visible = true;

		}
		#endregion

		#region minim - maxim
		private double Minim(double x, double y)
		{
			if (x < y)
				return x;
			else
				return y;
		}
		private double Maxim(double x, double y)
		{
			if (x < y)
				return y;
			else
				return x;
		}
		#endregion

		#region transform to two digits
		private string TransformToTwoDigits(int x)
		{
			if (x < 10)
				return "0" + x;
			else
				return x.ToString();
		}
		#endregion

		private double ROUNDUP(double number)  
		{      
			//return Math.Ceiling(number * Math.Pow(10, digits)) / Math.Pow(10, digits); 
			double n1 = Math.Ceiling(number);
			if (n1 - number > 0.5)
				return n1-1;
			return n1;
		}

		private void btnValideaza_Click(object sender, System.EventArgs e)
		{
			string path = this.Page.Request.Url.AbsoluteUri;
			path = path.Substring(0, path.LastIndexOf("/"));
			hyperLinkFisierErori.NavigateUrl = path + "/Templates/DecUnicaOut.xml.err.txt";
			hyperLinkFisierErori.Visible = true;
			hyperLinkFisierPdf.NavigateUrl = path + "/Templates/DecUnicaOut.pdf";
			hyperLinkFisierPdf.Visible = false;

			//System.Diagnostics.Process.Start(@"C:\Program Files\Java\jre1.6.0_24\bin\java.exe -jar C:\Inetpub\wwwroot\hr\InterfataSalarii\Templates\DUKIntegrator.jar -v C:\Inetpub\wwwroot\hr\InterfataSalarii\Templates\DecUnicaOut.xml");

			RunBat();

			/*
			//string m_launchDir = System.Environment.CurrentDirectory;
			Process process = new Process();
			ProcessStartInfo psi = new ProcessStartInfo();
			psi.Arguments = @"-jar DUKIntegrator.jar -v DecUnicaOut.xml";   
			psi.FileName = @"C:\Program Files\Java\jre1.6.0_24\bin\java.exe"; 
			psi.WorkingDirectory = @"C:\Inetpub\wwwroot\hr\InterfataSalarii\Templates";
			psi.RedirectStandardOutput = true;
			psi.RedirectStandardError = true;
			psi.RedirectStandardInput = true;
			psi.CreateNoWindow = true;
			psi.UseShellExecute = false; // Must set "UseShellExecute" to false in order to use environment variables.

			process.StartInfo = psi;
			//process.Start();

			try
			{
				process.Start();
				Thread.Sleep(10000); 
			
				int exitCode = process.ExitCode; 
				process.Close(); 
			}
			catch (Exception ex)
			{
				// log errors
				labelError.Text = ex.Message + " - " + ex.InnerException;
			}

			//Thread thread = new Thread(new ThreadStart(WorkThreadFunction));
			//thread.Start();
			*/
		} 

		public void RunBat()
		{
			// Get the full file path
			string strFilePath = "c:\\Test\\GeneratePDF.bat";

			// Create the ProcessInfo object
			System.Diagnostics.ProcessStartInfo psi = new System.Diagnostics.ProcessStartInfo("cmd.exe");
			psi.UseShellExecute = false; 
			psi.RedirectStandardOutput = true;
			psi.RedirectStandardInput = true;
			psi.RedirectStandardError = true;
			psi.CreateNoWindow = true;
			psi.WorkingDirectory = "c:\\Test\\";

			// Start the process
			System.Diagnostics.Process proc = System.Diagnostics.Process.Start(psi);
			// Open the batch file for reading
			System.IO.StreamReader strm = System.IO.File.OpenText(strFilePath); 
			// Attach the output for reading
			System.IO.StreamReader sOut = proc.StandardOutput;
			// Attach the in for writing
			System.IO.StreamWriter sIn = proc.StandardInput;

			// Write each line of the batch file to standard input
			while(strm.Peek() != -1)
			{
				sIn.WriteLine(strm.ReadLine());
			}
			strm.Close();

			// Exit CMD.EXE
			string stEchoFmt = "# {0} run successfully. Exiting";

			sIn.WriteLine(String.Format(stEchoFmt, strFilePath));
			sIn.WriteLine("EXIT");

			// Close the process
			proc.Close();

			// Read the sOut to a string.
			string results = sOut.ReadToEnd().Trim();

			// Close the io Streams;
			sIn.Close(); 
			sOut.Close();

			// Write out the results.
			//string fmtStdOut = "<font face=courier size=0>{0}</font>";
			//this.Response.Write(String.Format(fmtStdOut,results.Replace(System.Environment.NewLine, "<br>")));

		}

		public void WorkThreadFunction()
		{
			try
			{
				//ProcessStartInfo processInfo = new ProcessStartInfo("java.exe", "-version:1.6 -jar DUKIntegrator.jar -v DecUnicaOut.xml DecUnicaOut.xml.err.txt");
				//processInfo.CreateNoWindow = true;
				//processInfo.UseShellExecute = false;

				Process proc = new Process();   
				ProcessStartInfo startInfo = new ProcessStartInfo();   
				startInfo.Arguments = @"-jar DUKIntegrator.jar -v Templates\DecUnicaOut.xml Templates\DecUnicaOut.xml.err.txt";   
				startInfo.FileName = "java"; 
				startInfo.CreateNoWindow = false;
				proc.StartInfo = startInfo; 
				
				bool x = proc.Start(); 
				labelError.Text = x.ToString();

				/*Process proc;  
				if ((proc = Process.Start(processInfo)) == null) 
				{     
					throw new InvalidOperationException("??"); 
				} */
				Thread.Sleep(10000); 
				//proc.WaitForExit(); 
				
				int exitCode = proc.ExitCode; 
				proc.Close(); 

			}
			catch (Exception ex)
			{
				// log errors
				labelError.Text = ex.Message + " - " + ex.InnerException;
			}
		}
	}
}
