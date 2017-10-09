using System.Configuration;
using System;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

using SiemensTM.utils;
using SiemensTM.Classes;
//using SiemensHR.Classes;

namespace SiemensTM.Module
{
	/// <summary>
	///		Summary description for IntervalAbsente.
	/// </summary>
	public class IntervalAbsente : System.Web.UI.UserControl
	{
		#region Variabile
		protected System.Web.UI.HtmlControls.HtmlInputText DateStart;
		protected System.Web.UI.HtmlControls.HtmlInputText DateEnd;
		protected System.Web.UI.WebControls.DropDownList TipAbsentaDDL;
		protected System.Web.UI.WebControls.DropDownList TipBoalaDDL;

		public bool EnableBoliDDL = false;
		protected System.Web.UI.WebControls.Label LabelDataEnd;
		protected System.Web.UI.WebControls.Label LabelDataStart;
		protected System.Web.UI.HtmlControls.HtmlTextArea observatiiTA;
		protected System.Web.UI.HtmlControls.HtmlInputCheckBox CheckInterval;
		protected System.Web.UI.HtmlControls.HtmlInputHidden IntervalAbsentaID;
		protected System.Web.UI.HtmlControls.HtmlTableCell AbsenteMedicaleContinuareExistente;
		protected System.Web.UI.HtmlControls.HtmlInputButton AdaugaAbsentaMedicalaContinuare;
		
		public bool LabelsVisible = true;
		public string textObservatii = "";
		public double medieZilnicaVal = 0;
		public int TipBoalaID = -1;
		public bool Selectable;
		public int TipIntervalID = -1;
		public bool ContinuareAbsentaVizibil = false;
		protected System.Web.UI.HtmlControls.HtmlTableRow trMedieZilnica;
		public int AngajatID = -1;
		protected System.Web.UI.HtmlControls.HtmlInputText txtSerie;
		protected System.Web.UI.HtmlControls.HtmlInputText Text1;
		protected System.Web.UI.WebControls.CompareValidator CompareValidator2;
		protected System.Web.UI.HtmlControls.HtmlInputText txtMedieZilnica;
		protected System.Web.UI.HtmlControls.HtmlTable tableCM;
		protected System.Web.UI.HtmlControls.HtmlInputText txtNumar;
		protected System.Web.UI.HtmlControls.HtmlTable tabelCertificat;
		protected System.Web.UI.HtmlControls.HtmlSelect txtCertificatInitial;
		protected System.Web.UI.HtmlControls.HtmlInputText txtSerieCertificat;
		protected System.Web.UI.HtmlControls.HtmlInputText txtNumarCertificat;
		protected System.Web.UI.HtmlControls.HtmlInputText txtDataAcordariiCertificat;
		protected System.Web.UI.HtmlControls.HtmlInputText txtCnpCopil;
		protected System.Web.UI.HtmlControls.HtmlSelect txtLocPrescriereCertificat;
		protected System.Web.UI.HtmlControls.HtmlInputText txtCodUrgenta;
		protected System.Web.UI.HtmlControls.HtmlInputText txtNrAvizMedicExpert;
		protected System.Web.UI.HtmlControls.HtmlTableRow cnpCopilTr;
		protected System.Web.UI.HtmlControls.HtmlTableRow codUrgentaTr;

		protected Salaries.Configuration.ModuleSettings settings;
		#endregion

		#region Proprietati

		public System.Web.UI.HtmlControls.HtmlInputText DataStart
		{
			get
			{
				return DateStart;
			}
			set
			{
				DateStart = value;
			}
		}

		public System.Web.UI.HtmlControls.HtmlInputText DataEnd
		{
			get
			{
				return DateEnd;
			}
			set
			{
				DateEnd = value;
			}
		}

		public System.Web.UI.HtmlControls.HtmlInputHidden IntervalID
		{
			get
			{
				return IntervalAbsentaID;
			}
			set
			{
				IntervalAbsentaID = value;
			}
		}

		public System.Web.UI.WebControls.DropDownList TipIntervalAbsenteDDL
		{
			get
			{
				return TipAbsentaDDL;
			}
			set
			{
				TipAbsentaDDL = value;
			}
		}

		public System.Web.UI.WebControls.DropDownList TipAbsentaBoalaDDL
		{
			get
			{
				return TipBoalaDDL;
			}
			set
			{
				TipBoalaDDL = value;
			}
		}

		public System.Web.UI.HtmlControls.HtmlTextArea observatii
		{
			get
			{
				return observatiiTA;
			}
			set
			{
				observatiiTA = value;
			}
		}

		public System.Web.UI.HtmlControls.HtmlInputText MedieZilnica
		{
			get
			{
				return txtMedieZilnica;
			}
			set
			{
				txtMedieZilnica = value;
			}
		}

		//Oprescu Claudia
		//S-au adaugat doua proprietati pentru a putea accesa cele doua campuri
		public System.Web.UI.HtmlControls.HtmlInputText Serie
		{
			get
			{
				return txtSerie;
			}
			set
			{
				txtSerie = value;
			}
		}
		public System.Web.UI.HtmlControls.HtmlInputText Numar
		{
			get
			{
				return txtNumar;
			}
			set
			{
				txtNumar = value;
			}
		}
//-------------------Chiperescu Daniela 22.02.2011--------------------------------------
		public System.Web.UI.HtmlControls.HtmlSelect CertificatInitial
		{
			get
			{
				return txtCertificatInitial;
			}
			set
			{
				txtCertificatInitial = value;
			}
		}
		public System.Web.UI.HtmlControls.HtmlInputText SerieCertificat
		{
			get
			{
				return txtSerieCertificat;
			}
			set
			{
				txtSerieCertificat = value;
			}
		}
		public System.Web.UI.HtmlControls.HtmlInputText NumarCertificat
		{
			get
			{
				return txtNumarCertificat;
			}
			set
			{
				txtNumarCertificat = value;
			}
		}
		public System.Web.UI.HtmlControls.HtmlInputText DataAcordariiCertificat
		{
			get
			{
				return txtDataAcordariiCertificat;
			}
			set
			{
				txtDataAcordariiCertificat = value;
			}
		}
		public System.Web.UI.HtmlControls.HtmlInputText CnpCopil
		{
			get
			{
				return txtCnpCopil;
			}
			set
			{
				txtCnpCopil = value;
			}
		}
		public System.Web.UI.HtmlControls.HtmlSelect LocPrescriereCertificat
		{
			get
			{
				return txtLocPrescriereCertificat;
			}
			set
			{
				txtLocPrescriereCertificat = value;
			}
		}
		public System.Web.UI.HtmlControls.HtmlInputText CodUrgenta
		{
			get
			{
				return txtCodUrgenta;
			}
			set
			{
				txtCodUrgenta = value;
			}
		}
		public System.Web.UI.HtmlControls.HtmlInputText NrAvizMedicExpert
		{
			get
			{
				return txtNrAvizMedicExpert;
			}
			set
			{
				txtNrAvizMedicExpert = value;
			}
		}
		#endregion
//-------------------Chiperescu Daniela 22.02.2011--------------------------------------
		#region Page_Load
		private void Page_Load(object sender, System.EventArgs e)
		{
			this.DateStart.Attributes["onblur"] = "getIntervalAbsente('"+this.ClientID+"').DataStartChanged()";
			this.DateEnd.Attributes["onblur"] = "getIntervalAbsente('"+this.ClientID+"').DataEndChanged()";
			this.DateStart.Attributes["onkeyup"] = "getIntervalAbsente('"+this.ClientID+"').DataStartKeyPressed()";
			this.DateEnd.Attributes["onkeyup"] = "getIntervalAbsente('"+this.ClientID+"').DataEndKeyPressed()";
			this.txtDataAcordariiCertificat.Attributes["onkeyup"] = "getIntervalAbsente('"+this.ClientID+"').DataStartKeyPressed()";

			this.TipAbsentaDDL.Attributes[ "onblur" ] = "getIntervalAbsente('"+this.ClientID+"').getTipIntervalAbsente()";
			this.TipBoalaDDL.Attributes[ "onblur" ] = "getIntervalAbsente('"+this.ClientID+"').getTipBoalaAbsente()";
			this.observatiiTA.Attributes[ "onblur" ] = "getIntervalAbsente('"+this.ClientID+"').ObservatiiChanged()";
			this.MedieZilnica.Attributes[ "onblur" ] = "getIntervalAbsente('"+this.ClientID+"').MedieZilnicaChanged()";
			
			//Oprescu Claudia
			//S-au adaugat pe interfata doua campuri noi pentru serie si numar. 
			//La aceste doua campuri se adauga doua evenimente pentru actualizari
			this.txtSerie.Attributes[ "onblur" ] = "getIntervalAbsente('"+this.ClientID+"').SerieChanged()";
			this.txtNumar.Attributes[ "onblur" ] = "getIntervalAbsente('"+this.ClientID+"').NumarChanged()";
			this.txtSerieCertificat.Attributes[ "onblur" ] = "getIntervalAbsente('"+this.ClientID+"').SerieCertificatChanged()";
			this.txtNumarCertificat.Attributes[ "onblur" ] = "getIntervalAbsente('"+this.ClientID+"').NumarCertificatChanged()";
			this.txtCertificatInitial.Attributes[ "onblur" ] = "getIntervalAbsente('"+this.ClientID+"').CertificatInitialChanged()";
			this.txtDataAcordariiCertificat.Attributes[ "onblur" ] = "getIntervalAbsente('"+this.ClientID+"').DataAcordariiChanged()";
			this.txtCnpCopil.Attributes[ "onblur" ] = "getIntervalAbsente('"+this.ClientID+"').CnpCopilChanged()";
			this.txtLocPrescriereCertificat.Attributes[ "onblur" ] = "getIntervalAbsente('"+this.ClientID+"').LocPrescriereChanged()";
			this.txtCodUrgenta.Attributes[ "onblur" ] = "getIntervalAbsente('"+this.ClientID+"').CodUrgentaChanged()";
			this.txtNrAvizMedicExpert.Attributes[ "onblur" ] = "getIntervalAbsente('"+this.ClientID+"').NrAvizMedicChanged()";
			this.TipAbsentaDDL.Attributes[ "onchange" ] = "TipAbsentaDDL_Changed( '"+this.TipAbsentaDDL.ClientID
									+"', '"+this.tableCM.ClientID
									+"', '"+this.trMedieZilnica.ClientID
									+"', '"+this.MedieZilnica.ClientID+"')";
			this.CertificatInitial.Attributes[ "onchange" ] = "CertificatInitial_Changed('"+this.tabelCertificat.ClientID+"','"+this.CertificatInitial.ClientID+"')";
			this.TipBoalaDDL.Attributes["onchange"]="TipBoalaDDL_Changed('"+this.TipBoalaDDL.ClientID+"','"+this.cnpCopilTr.ClientID+"','"+this.codUrgentaTr.ClientID+"')";
			this.DataAcordariiCertificat.Attributes["onkeyup"] = "getIntervalAbsente('"+this.ClientID+"').DataStartKeyPressed()";
			
		}
		#endregion

		#region OnPreRender
		protected override void OnPreRender(EventArgs e)
		{
			base.OnPreRender (e);
			
			settings = Salaries.Configuration.ModuleConfig.GetSettings();
			new UtilitiesDb(settings.ConnectionString).CreateTipAbsenteSelectBox( this.TipAbsentaDDL );
			new UtilitiesDb(settings.ConnectionString).CreateTipBoliSelectBox( this.TipBoalaDDL );
			int ConcediuOdihnaID = new UtilitiesDb(settings.ConnectionString).GetConcediuOdihnaID();
			int ConcediuOdihnaAnulPrecedentID = new UtilitiesDb(settings.ConnectionString).GetConcediuOdihnaAnulPrecedentID();

			LabelDataStart.Visible = LabelDataEnd.Visible = LabelsVisible;
			
			if(Selectable)
			{
				if ( TipIntervalID != -1 )
				{
					this.TipAbsentaDDL.SelectedValue=TipIntervalID.ToString();
					if ((this.TipAbsentaDDL.Items[this.TipAbsentaDDL.SelectedIndex].Text == "Concediu Medical") || (this.TipAbsentaDDL.Items[this.TipAbsentaDDL.SelectedIndex].Text == "Continuare Concediu Medical"))
						if (TipBoalaID == -1)
							TipBoalaID = int.Parse(this.TipBoalaDDL.Items[0].Value);
				}

				if ( TipBoalaID != -1)
				{
					this.TipBoalaDDL.SelectedValue = TipBoalaID.ToString();
					//devine vizibila tabela in functie de optiunea selectate
					this.tableCM.Style.Add("display", "" );
					trMedieZilnica.Style.Add( "display", "" );
				}
				else
				{
					this.tableCM.Style.Add("display", "none" );

					if ((TipIntervalID != ConcediuOdihnaID) && (TipIntervalID != ConcediuOdihnaAnulPrecedentID))
					{
						trMedieZilnica.Style.Add( "display", "none" );
					}
					else
					{
						trMedieZilnica.Style.Add( "display", "" );
					}
				}
			
				TipIntervalID = Convert.ToInt32( this.TipAbsentaDDL.SelectedItem.Value );
				((System.Web.UI.HtmlControls.HtmlInputHidden)Page.FindControl( "TipIntervalAbsente1" )).Value = TipIntervalID.ToString();

				TipBoalaID = Convert.ToInt32( this.TipBoalaDDL.SelectedItem.Value );
				((System.Web.UI.HtmlControls.HtmlInputHidden)Page.FindControl( "TipBoalaAbsente1" )).Value = TipBoalaID.ToString();
			}
			else
			{
				TipIntervalID = Convert.ToInt32( this.TipAbsentaDDL.Items[0].Value );
				((System.Web.UI.HtmlControls.HtmlInputHidden)Page.FindControl( "TipIntervalAbsente1" )).Value = TipIntervalID.ToString();

				TipBoalaID = Convert.ToInt32( this.TipBoalaDDL.Items[0].Value );
				((System.Web.UI.HtmlControls.HtmlInputHidden)Page.FindControl( "TipBoalaAbsente1" )).Value = TipBoalaID.ToString();

				trMedieZilnica.Style.Add( "display", "none" );
				this.tableCM.Style.Add("display", "none" );

				this.CheckInterval.Visible=false;
			}

			observatiiTA.Value = textObservatii;

			if ( TipIntervalID != -1)
			{
				if(this.CertificatInitial.Value!="Nu")
				{
					this.tabelCertificat.Style["display"]="none";
					this.tabelCertificat.Style["float"]="left";
				}
			}
			if(TipBoalaID!=7 && TipBoalaID!=5 )
			{
				codUrgentaTr.Style["display"]="none";
				codUrgentaTr.Style["float"]="left";
			}
			else
				codUrgentaTr.Style["display"]="";
			if(TipBoalaID!=10)
			{
				cnpCopilTr.Style["display"]="none";
				cnpCopilTr.Style["float"]="left";
			}
			else
				cnpCopilTr.Style["display"]="";
		}
		#endregion

		#region Render
		protected override void Render(System.Web.UI.HtmlTextWriter writer)
		{
			base.Render (writer);
		
			Response.Write( "<script>var DataSt = '"+this.DateStart.ClientID+"';</script>");
			Response.Write( "<script>var DataSf = '"+this.DateEnd.ClientID+"';</script>");
			Response.Write( "<script>var TipIntervAbsente = '"+this.TipAbsentaDDL.ClientID+"';</script>");
			Response.Write( "<script>var TipIntervBoala = '"+this.TipBoalaDDL.ClientID+"';</script>");
			Response.Write( "<script>var CheckAbsente = '"+this.CheckInterval.ClientID+"';</script>");
			Response.Write( "<script>var IntervAbsenteID = '"+this.IntervalAbsentaID.ClientID+"';</script>");
			Response.Write( "<script>var ObservatiiID1 = '"+this.observatiiTA.ClientID+"';</script>");
			Response.Write( "<script>var MedieZilnica1 = '"+this.MedieZilnica.ClientID+"';</script>");
			Response.Write( "<script>var txtSerie = '"+this.txtSerie.ClientID+"';</script>");
			Response.Write( "<script>var txtNumar = '"+this.txtNumar.ClientID+"';</script>");
			//-------------------Chiperescu Daniela 22.02.2011--------------------------------------
			Response.Write( "<script>var txtCertificatInitial = '"+this.txtCertificatInitial.ClientID+"';</script>");
			Response.Write( "<script>var txtSerieCertificat = '"+this.txtSerieCertificat.ClientID+"';</script>");
			Response.Write( "<script>var txtNumarCertificat = '"+this.txtNumarCertificat.ClientID+"';</script>");
			Response.Write( "<script>var txtDataAcordariiCertificat = '"+this.txtDataAcordariiCertificat.ClientID+"';</script>");
			Response.Write( "<script>var txtCnpCopil = '"+this.txtCnpCopil.ClientID+"';</script>");
			Response.Write( "<script>var txtLocPrescriereCertificat = '"+this.txtLocPrescriereCertificat.ClientID+"';</script>");
			Response.Write( "<script>var txtCodUrgenta = '"+this.txtCodUrgenta.ClientID+"';</script>");
			Response.Write( "<script>var txtNrAvizMedicExpert = '"+this.txtNrAvizMedicExpert.ClientID+"';</script>");
			//-------------------Chiperescu Daniela 22.02.2011--------------------------------------
			string valoare = "<script>var tmpAbsente = new CreateIntervalAbsenteElement('"+this.ClientID+"','"+this.DateStart.ClientID+"','"+this.DateEnd.ClientID+"','"+this.TipAbsentaDDL.ClientID+"','"+this.TipBoalaDDL.ClientID+"','"+this.IntervalAbsentaID.ClientID+"','"+this.CheckInterval.ClientID+"','"+this.observatiiTA.ClientID+"','"+this.MedieZilnica.ClientID+"','"+this.txtSerie.ClientID+"','"+this.txtNumar.ClientID+"','"+this.txtCertificatInitial.ClientID+"','"+this.txtSerieCertificat.ClientID+"','"+this.txtNumarCertificat.ClientID+"','"+this.txtDataAcordariiCertificat.ClientID+"','"+this.txtCnpCopil.ClientID+"','"+this.txtLocPrescriereCertificat.ClientID+"','"+this.txtCodUrgenta.ClientID+"','"+this.txtNrAvizMedicExpert.ClientID+"');</script>";
			Response.Write( valoare );		
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
