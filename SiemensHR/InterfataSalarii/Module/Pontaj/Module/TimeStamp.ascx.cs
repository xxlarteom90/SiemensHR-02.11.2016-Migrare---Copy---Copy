using System;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

using SiemensTM.Classes;
using SiemensHR.Classes;

namespace SiemensTM.Module
{
	/// <summary>
	///		Summary description for TimeStamp.
	/// </summary>
	public class TimeStamp : ModuleLogin
	{
		#region Variabile
		protected System.Web.UI.HtmlControls.HtmlTableCell cell_container;
		private Salaries.Business.Angajat objectAngajat;
		public long AngajatID;
		public DateTime SelectedDate;
		#endregion

		#region Page_Load
		private void Page_Load(object sender, System.EventArgs e)
		{
			this.AngajatID = this.GetLoggedUserID();

			objectAngajat = new Salaries.Business.Angajat();
			objectAngajat.AngajatId = AngajatID;
			objectAngajat.LoadAngajat();
		}
		#endregion

		#region OnPreRender
		protected override void OnPreRender(EventArgs e)
		{
			base.OnPreRender (e);
		}
		#endregion

		#region Render
		protected override void Render(System.Web.UI.HtmlTextWriter writer)
		{
			this.CreateTimeStamp();
			base.Render(writer);
		}
		#endregion

		#region CreateChildControls
		protected override void CreateChildControls()
		{
			base.CreateChildControls ();
		}
		#endregion

		#region CreateTimeStamp
		protected void CreateTimeStamp()
		{
			Table t = new Table();
			TableRow r_days = new TableRow();
			TableRow r_stamps = new TableRow();

			Zile z = new Zile();

			DataSet ds = z.GetLuna( this.SelectedDate.Year ,this.SelectedDate.Month );
			
			SituatieAngajat sa = new SituatieAngajat(this.AngajatID);
			//Lungu Andreea - 08.09.2008
			//Se folosesc doua dataset-uri pentru a aduce datele necesare
			//Pentru a incerca sa optimizam timpul
			DateTime dataStart = DateTime.Parse(ds.Tables[0].Rows[0]["Data"].ToString());
			DateTime dataEnd = DateTime.Parse(ds.Tables[0].Rows[ds.Tables[0].Rows.Count-1]["Data"].ToString());
			DataSet ds_ore = sa.GetOreZiLuna(dataStart, dataEnd);
			DataSet ds_norma = sa.GetNormaZiLuna(dataStart, dataEnd);

			foreach (DataRow dr in ds.Tables[0].Rows)
			{
				TableCell tc = new TableCell();
				tc.CssClass="tabBackground";
				tc.Width=40;
				tc.Attributes["align"]="center";
				tc.Font.Size = FontUnit.Small;
				tc.Font.Name="arial";
		
				tc.Attributes["style"]="cursor:hand";
				tc.Attributes["onmouseover"]="Light(this)";
				tc.Attributes["onmouseout"]="Delight(this)";
				
				System.Drawing.Color back;	
				
				DateTime dt = DateTime.Parse(dr["Data"].ToString());

				if (dt.ToShortDateString()==this.SelectedDate.ToShortDateString()) 
					back = Definitions.Color_ZiSelected; 
				else
					back = z.IsSarbatoare( dt ) ? Definitions.Color_ZiSarbatoare : Definitions.Color_ZiLucru;
	
				tc.BackColor = back;
				tc.Text="<b>"+dt.Day+"</b>";
			
				tc.Attributes["onclick"]="SelectZiLuna("+dt.Day+")";

				r_days.Cells.Add(tc);
			
				tc = new TableCell();
				tc.CssClass="tabBackground";
				tc.Width=40;
				tc.Attributes["align"]="center";
				tc.Font.Size = FontUnit.Small;
				tc.Font.Name="arial";
				
				tc.Attributes["style"]="cursor:hand";
				tc.Attributes["onmouseover"]="Light(this)";
				tc.Attributes["onmouseout"]="Delight(this)";
				tc.Attributes["onclick"]="SelectZiLuna("+dt.Day+")";
				
				dt = DateTime.Parse(dr["Data"].ToString());
				back = Definitions.Color_StampNecompletat;

				//Lungu Andreea - 08.09.2008
				//sunt luate din dataset datele corespunzatoare unei anumite zile
				float oreZi = 0;
				if (ds_ore != null)
				{
					foreach (DataRow dr_ore in ds_ore.Tables[0].Rows)
						if (dr_ore["Data"].ToString().Equals(dr["Data"].ToString()))
							oreZi = (float) Double.Parse(dr_ore["OreZi"].ToString());
				}
				int normaZi = 0;
				if (ds_norma != null)
				{
					foreach (DataRow dr_norma in ds_norma.Tables[0].Rows)
						if (dr_norma["Data"].ToString().Equals(dr["Data"].ToString()))
							normaZi = (int) Double.Parse(dr_norma["ProgramLucru"].ToString());
				}

				//float oreZi = sa.GetOreZi(dt);
				//int normaZi = sa.GetNormaZi( dt );
				if (oreZi>0)
				{
					if( z.IsSarbatoare( dt ))
					{
						back = Definitions.Color_StampCompletat;
					}
					else
					{
						back = (oreZi<normaZi) ? Definitions.Color_StampCompletatPartial : Definitions.Color_StampCompletat;
					}	
				}
				
				tc.BackColor = back;
				
				tc.Text="&nbsp;"+oreZi;
			
				r_stamps.Cells.Add(tc);
			}

			DataSet myDs = GetZileLunaImposibile( z );
			if( myDs != null )
			{
				foreach( DataRow dr in myDs.Tables[ 0 ].Rows )
				{
					//completeaza zilele cu - 
					r_stamps.Cells[ ((DateTime)dr[ "Data" ]).Day-1 ].Text = Definitions.TextZileLunaImposibile;
					r_stamps.Cells[ ((DateTime)dr[ "Data" ]).Day-1 ].BackColor = Definitions.Color_StampZileLunaImposibile;
				}
			}

			myDs = GetZileLunaIntreruperi( z );
			if( myDs != null )
			{
				foreach( DataRow dr in myDs.Tables[ 0 ].Rows )
				{
					//completeaza zilele cu - 
					r_stamps.Cells[ ((DateTime)dr[ "Data" ]).Day-1 ].Text = Definitions.TextZileLunaImposibile;
					r_stamps.Cells[ ((DateTime)dr[ "Data" ]).Day-1 ].BackColor = Definitions.Color_StampZileLunaIntreruperi;
				}
			}

			myDs = sa.GetIntervaleAbsentaAngajatLunaByDataInside( this.SelectedDate );
			
			for( int i=0; i<r_stamps.Cells.Count; i++ )
			{
				DateTime time = new DateTime( this.SelectedDate.Year, this.SelectedDate.Month, i+1 );
				string cod = CompleteazaZiAbsentaLuna( myDs, i, sa );
				if( cod != "" )
				{
					r_stamps.Cells[ i ].Text = cod;
					if( cod==Salaries.Business.SituatieLunaraAngajat.codAbsente[ 8 ] || cod==Salaries.Business.SituatieLunaraAngajat.codAbsente[ 9 ] )
					{
						r_stamps.Cells[ i ].BackColor = Definitions.Color_StampDelegatie;
					}
					else 
					{
						float oreZi = 0;
						if (ds_ore != null)
						{
							foreach (DataRow dr_ore in ds_ore.Tables[0].Rows)
								if (dr_ore["Data"].ToString().Equals(time.ToString()))
									oreZi = (float) Double.Parse(dr_ore["OreZi"].ToString());
						}
						//if( cod==Salaries.Business.SituatieLunaraAngajat.codAbsente[ 10 ]+" "+sa.GetOreZi( time ).ToString())
						if( cod==Salaries.Business.SituatieLunaraAngajat.codAbsente[ 10 ]+" "+oreZi.ToString())
						{
							r_stamps.Cells[ i ].BackColor = Definitions.Color_StampEmergencyService;
						}
						else
						{
							 r_stamps.Cells[ i ].BackColor = Definitions.Color_StampAbsenta;
						 }
					}
				}
			}

			t.Rows.Add(r_days);
			t.Rows.Add(r_stamps);

			this.cell_container.Controls.Add(t);
		}
		#endregion

		#region GetZileLunaImposibile
		/// <summary>
		/// Procedura determina zilele imposibile din luna
		/// </summary>
		/// <param name="z"></param>
		/// <returns>Returneaza un DataSet care contine aceste date</returns>
		private DataSet GetZileLunaImposibile( Zile z )
		{
			try
			{
				Salaries.Business.Angajat ang = new Salaries.Business.Angajat();
				ang.AngajatId = GetAngajat();
				ang.LoadAngajat();
				//Modified: Ionel Popa
				//Description: Nu se ia in considerare DataPanaLa si DataLichidare
				if( ang.DataLichidare.Year==1 && ang.DataLichidare.Month==1 && ang.DataLichidare.Day==1 )
				{
					return null;
				}
				DataSet ds = z.GetZileLunaImposibile( SelectedDate.Year, SelectedDate.Month, ang.DataLichidare );
				return ds;
			}
			catch
			{
				return null;
			}
		}
		#endregion

		#region GetZileLunaIntreruperi
		/// <summary>
		/// Procedura determina zilele din luna cu intreruperi
		/// </summary>
		/// <param name="z"></param>
		/// <returns>Returneaza un DataSet care contine aceste date</returns>
		private DataSet GetZileLunaIntreruperi( Zile z )
		{
			try
			{
				DataSet ds = new IntervaleIntreruperiAngajat( this.GetAngajat()).GetIntervaleIntreruperiAngajatLuna( this.SelectedDate );
				DataSet dsZile = z.GetZileIntrerupereContract( this.SelectedDate.Year, this.SelectedDate.Month, (DateTime)ds.Tables[ 0 ].Rows[ 0 ][ "DataStart" ], (DateTime)ds.Tables[ 0 ].Rows[ 0 ][ "DataEnd" ] );
				
				for( int i=1; i<ds.Tables[ 0 ].Rows.Count; i++ )
				{
					DataRow dr = ds.Tables[ 0 ].Rows[ i ];
					dsZile.Merge( z.GetZileIntrerupereContract( this.SelectedDate.Year, this.SelectedDate.Month, (DateTime)dr[ "DataStart" ], (DateTime)dr[ "DataEnd" ] ));
				}
				return dsZile;
			}
			catch( Exception)
			{
				return null;
			}
		}
		#endregion

		#region CompleteazaZiAbsentaLuna
		/// <summary>
		/// Procedura completaza zilele de absenta pe luna
		/// </summary>
		/// <param name="ds"></param>
		/// <param name="ziDinLuna"></param>
		/// <param name="sa"></param>
		/// <returns></returns>
		private string CompleteazaZiAbsentaLuna( DataSet ds, int ziDinLuna, SituatieAngajat sa )
		{
			DateTime time;
			string retVal = "";
			foreach( DataRow dr in ds.Tables[ 0 ].Rows )
			{
				time = new DateTime( SelectedDate.Year, SelectedDate.Month, ziDinLuna+1 );
				if( (DateTime)dr[ "DataStart" ]<=time && time<=(DateTime)dr[ "DataEnd" ] )
				{
					if( dr[ "BoalaID" ].ToString() != "" )
					{
						string codBoala = sa.GetCodBoala( dr[ "BoalaID" ].ToString());
						
						retVal = dr[ "CodAbsenta" ].ToString()+" "+codBoala;
					}
					else
					{
						retVal = dr[ "CodAbsenta" ].ToString();
						if((bool)dr[ "Lucratoare" ] )
						{
							retVal += " "+sa.GetOreZi( time ).ToString();
						}
						
						return retVal;
					}
				}
			}
			return retVal;
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
