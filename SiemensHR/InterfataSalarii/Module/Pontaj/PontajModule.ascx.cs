using System;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Configuration;

using SiemensTM.Classes;
using SiemensTM.Module;
using SiemensHR.utils;

namespace SiemensHR.InterfataSalarii.Module.Pontaj
{
	/// <summary>
	///		Summary description for TimeStamp.
	/// </summary>
	public class PontajModule : SiemensTM.Classes.ModuleLogin
	{
		#region Variabile
		protected System.Web.UI.HtmlControls.HtmlTableCell CenterContainer;
		protected System.Web.UI.HtmlControls.HtmlTableCell TimeStampContainer;
		protected System.Web.UI.HtmlControls.HtmlTableCell IntervaleContainer;
		protected System.Web.UI.HtmlControls.HtmlInputHidden ClientSelectedDate1;
		protected Salaries.Configuration.ModuleSettings settings;	
		protected SiemensTM.Module.TimeStamp TimeStamp1;
		protected Intervale Intervale1;
		public int CurrentMonthID;
		public int AngajatorID;
		#endregion
		
		#region Page_Load
		private void Page_Load(object sender, System.EventArgs e)
		{
			//Modificat: Cristina Muntean ... se permite modificarea pontajului numai daca luna selectata de
			//utilizator este luna activa a angajatorului sau daca exista situatie lunara pentru angajatul selectat
			
			//luna selectata de utilizator
			int lunaCurentaID = int.Parse(this.Session[SiemensHR.InterfataSalarii.Classes.Definitions.LunaCurentaKey].ToString());
			//id-ul angajatului selectat in dropdownlist
			int angajatID = this.GetAngajat();

			Salaries.Business.Angajat objAngajat = new Salaries.Business.Angajat();
			objAngajat.AngajatId = angajatID;
			objAngajat.LoadAngajat();

			//luna activa a angajatorului
			Salaries.Business.Luni luna = new Salaries.Business.Luni(objAngajat.AngajatorId);
			Salaries.Data.LunaData lunaData = luna.GetLunaActiva();	

			//se obtine situatie lunara a angajatului
			Salaries.Business.SituatieLunaraAngajat situatieLunaraAng = new Salaries.Business.SituatieLunaraAngajat(objAngajat.AngajatId);
			Salaries.Data.InfoSituatieLunara infoSituatieLunara = situatieLunaraAng.GetSituatieLunaraAngajat( objAngajat.AngajatId, lunaData.LunaId );
			
			//daca luna selectata de utilizator nu este luna activa sau daca nu exista o situatie lunara pentru angajatul selectat
			//atunci se permite doar vizualizarea pontajului,altfel se permite si modificarea acestuia
			if(( lunaCurentaID != lunaData.LunaId) || (infoSituatieLunara.SituatieID == -1))
			{
				//HtmlTableCell IntervaleContainer este ascunsa 
				IntervaleContainer.Style.Add("display","none");
			}
			else
			{
				//HtmlTableCell IntervaleContainer este facuta vizibila
				IntervaleContainer.Style.Add("display","");
			}
			
			ClientSelectedDate1 = (System.Web.UI.HtmlControls.HtmlInputHidden)Page.FindControl( "ClientSelectedDate" );
			this.DoQuickLogin( this.GetAngajat()); 
		}
		#endregion

		#region OnPreRender
		protected override void OnPreRender(EventArgs e)
		{
			base.OnPreRender (e);
			this.HandleActions();
		}
		#endregion

		#region Render
		protected override void Render(System.Web.UI.HtmlTextWriter writer)
		{
			base.Render (writer);
		}
		#endregion

		#region GetLunaSelectata
		/// <summary>
		/// Procedura determina luna selectata
		/// </summary>
		/// <returns>Returneaza un DataSet care contine aceste date</returns>
		private DataSet GetLunaSelectata()
		{
			settings = Salaries.Configuration.ModuleConfig.GetSettings();
			System.Data.SqlClient.SqlConnection myConn = new System.Data.SqlClient.SqlConnection(settings.ConnectionString);
			System.Data.SqlClient.SqlCommand searchCommand = new System.Data.SqlClient.SqlCommand("sal_GetLunaInflById ", myConn );
			searchCommand.CommandType = System.Data.CommandType.StoredProcedure;

			searchCommand.Parameters.Add( "@LunaID", Convert.ToInt32( Session[ "LunaCurenta" ].ToString()));				
			
			System.Data.SqlClient.SqlDataAdapter myDa = new System.Data.SqlClient.SqlDataAdapter(searchCommand);
			DataSet myDs = new DataSet();
			myDa.Fill( myDs );
			return myDs;
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
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region HandleActions
		/// <summary>
		/// Executa o actiune
		/// </summary>
		private void HandleActions()
		{
			if (!IsPostBack)
			{
				Salaries.Business.Luni l = new Salaries.Business.Luni(this.AngajatorID,this.CurrentMonthID);
				this.TimeStamp1.SelectedDate = l.Data;
				this.Intervale1.SelectedDate = l.Data;
				
				this.SaveSessionKey(Definitions.SelectedDateKEY,TimeStamp1.SelectedDate);
			}
			else
			{
				DateTime SelectedDate;
				DataSet ds = GetLunaSelectata();
				int zi;
				
				DateTime dt = (DateTime)ds.Tables[ 0 ].Rows[ 0 ][ "Data" ];
				int an = dt.Year;
				int luna = dt.Month;

				if (this.ClientSelectedDate1.Value!="")
				{
					int Zi = int.Parse(this.ClientSelectedDate1.Value);
					Salaries.Business.Luni l = new Salaries.Business.Luni(this.AngajatorID,this.CurrentMonthID);
			
					int An = l.Data.Year;
					int Luna = l.Data.Month;

					SelectedDate=new DateTime(An,Luna,Zi);
					this.SaveSessionKey(Definitions.SelectedDateKEY,SelectedDate);
					
					this.ClientSelectedDate1.Value="";
				}
				else
				{
					DateTime dtSes = (DateTime)this.GetSessionKey(Definitions.SelectedDateKEY);
					
					if( dtSes.Month == luna && dtSes.Year == an )
					{
						SelectedDate = dtSes;
					}
					else
					{
						zi = 1;
						SelectedDate = new DateTime( an, luna, zi );
						this.SaveSessionKey( Definitions.SelectedDateKEY, SelectedDate );
					}
				}
	
				this.TimeStamp1.SelectedDate = SelectedDate;
				this.Intervale1.SelectedDate = SelectedDate;
			}
		}
		#endregion
	}
}
