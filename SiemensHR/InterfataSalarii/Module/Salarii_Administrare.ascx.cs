using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Security.Principal;

namespace SiemensHR.InterfataSalarii.Module
{
	/// <summary>
	///		Summary description for Salarii_Administrare.
	/// </summary>
	public class Salarii_Administrare : SiemensHR.InterfataSalarii.Classes.BaseModule
	{
		#region Variabile
		protected System.Web.UI.HtmlControls.HtmlTableCell Center;
		#endregion

		#region Page_Load
		private void Page_Load(object sender, System.EventArgs e)
		{	
			string Option = this.Page.Request.Params["Option"];
			if (Option==null) Option="admin_categorii";
			switch (Option)
			{
				case "admin_categorii":
					Admin_CategoriiAngajati myAdminCategorii = (Admin_CategoriiAngajati) LoadControl("Admin_CategoriiAngajati.ascx");
					Center.Controls.Add( myAdminCategorii );
					break;	
				case "nomenclator_boli" :
					Admin_NomenclatorBoli myNomencBoli = (Admin_NomenclatorBoli) LoadControl("Admin_NomenclatorBoli.ascx");
					Center.Controls.Add( myNomencBoli );
					break;
				case "nomenclator_tipuri_ore_lucrate" :
					Admin_NomenclatorTipOreLucrate myNomencTipOreLucrate = (Admin_NomenclatorTipOreLucrate)LoadControl("Admin_NomenclatorTipOreLucrate.ascx");
					Center.Controls.Add( myNomencTipOreLucrate );
					break;
				case "nomenclator_tipuri_absente" :
					Admin_NomenclatorTipAbsente myNomencTipAbsente = (Admin_NomenclatorTipAbsente)LoadControl("Admin_NomenclatorTipAbsente.ascx");
					Center.Controls.Add( myNomencTipAbsente );
					break;
				case "sarbatori_legale" :
					Admin_NomenclatorSarbatoriLegale myNomenclatorSarbatoriLegale = (Admin_NomenclatorSarbatoriLegale)LoadControl("Admin_NomenclatorSarbatoriLegale.ascx");
					Center.Controls.Add( myNomenclatorSarbatoriLegale );
					break;
				case "concedii_medicale" :
					Admin_NomenclatorConcediiMed myAdmin_NomenclatorConcediiMed = (Admin_NomenclatorConcediiMed)LoadControl("Admin_NomenclatorConcediiMed.ascx");
					Center.Controls.Add( myAdmin_NomenclatorConcediiMed );
					break;
				case "inflatie_lunara" :
					Admin_InflatieLunara myInflatieLunara = (Admin_InflatieLunara)LoadControl("Admin_InflatieLunara.ascx");
					Center.Controls.Add( myInflatieLunara );
					break;
				//Adaugat:		Oprescu Claudia
				//Descriere:	S-a adaugat optiunea pentru constante de salarizare
				case "constanta_salarizare" :
					Admin_VariabileGlobale myVariabileGlobale = (Admin_VariabileGlobale)LoadControl("Admin_VariabileGlobale.ascx");
					Center.Controls.Add( myVariabileGlobale );
					break;
				case "tipuri_retineri" :
					Admin_TipuriRetineri myTipuriRetineri = (Admin_TipuriRetineri)LoadControl("Admin_TipuriRetineri.ascx");
					Center.Controls.Add( myTipuriRetineri );
					break;	
				case "serii_tichete" :
					Admin_NomenclatorSeriiTichete myNomencSerii = (Admin_NomenclatorSeriiTichete) LoadControl("Admin_NomenclatorSeriiTichete.ascx");
					Center.Controls.Add( myNomencSerii );
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
