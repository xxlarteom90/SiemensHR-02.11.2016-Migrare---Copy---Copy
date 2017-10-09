using System.Configuration;
using System;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;

using SiemensTM.utils;
using SiemensTM.Classes;

namespace SiemensTM.Module
{
	/// <summary>
	///		Summary description for Interval.
	/// </summary>
	public class Interval : System.Web.UI.UserControl
	{
		#region Variabile
		public System.Web.UI.HtmlControls.HtmlInputText OraStart;
		public System.Web.UI.WebControls.DropDownList TipInterval;
		public System.Web.UI.HtmlControls.HtmlInputText OraEnd;
		public System.Web.UI.HtmlControls.HtmlInputCheckBox CheckInterval;
		public int TipIntervalID = -1;
		public bool Selectable;
		public System.Web.UI.HtmlControls.HtmlInputHidden IntervalID;

		public bool tipuriNestandard = false;
		public bool tipuriOreAdaugare = false;//true daca e pt componentele de adaugare, False daca e pt componentele de modificare

		public long AngajatID = -1;
		public DateTime SelectedDate = DateTime.MinValue;
		protected Salaries.Configuration.ModuleSettings settings;
		#endregion

		#region Page_Load
		private void Page_Load(object sender, System.EventArgs e)
		{}
		#endregion

		#region OnPreRender
		protected override void OnPreRender(EventArgs e)
		{
			base.OnPreRender (e);
			settings = Salaries.Configuration.ModuleConfig.GetSettings();

			if( tipuriOreAdaugare )
			{
				new UtilitiesDb(settings.ConnectionString).CreateTipIntervaleSelectBox(this.TipInterval, this.AngajatID, this.SelectedDate, true );
				DeleteElementsUnusableFromTipIntervalAddCombo();
			}
			else
			{
				new UtilitiesDb(settings.ConnectionString).CreateTipIntervaleSelectBox(this.TipInterval, this.AngajatID, this.SelectedDate, false );
				DeleteElementsUnusableFromTipIntervalModifyCombo();
			}

			if (TipIntervalID!=-1) 
			{
				this.TipInterval.SelectedValue=TipIntervalID.ToString();
			}
			try
			{
				TipIntervalID = Convert.ToInt32( this.TipInterval.SelectedItem.Value );
			}
			catch{}
			((System.Web.UI.HtmlControls.HtmlInputHidden)Page.FindControl( "TipInterval1" )).Value = TipIntervalID.ToString();

			if (!this.Selectable) 
			{
				this.CheckInterval.Visible=false;
			}
		}
		#endregion

		#region Render
		protected override void Render(System.Web.UI.HtmlTextWriter writer)
		{
			base.Render (writer);
		
			Response.Write( "<script>var OraSt = '"+this.OraStart.ClientID+"';</script>");
			Response.Write( "<script>var OraSf = '"+this.OraEnd.ClientID+"';</script>");
			Response.Write( "<script>var TipInterv = '"+this.TipInterval.ClientID+"';</script>");
			Response.Write( "<script>var Check = '"+this.CheckInterval.ClientID+"';</script>");
			Response.Write( "<script>var IntervID = '"+this.IntervalID.ClientID+"';</script>");

			Response.Write("<script>var tmp = new CreateIntervalElement('"+this.ClientID+"','"+this.OraStart.ClientID+"','"+this.OraEnd.ClientID+"','"+this.TipInterval.ClientID+"','"+this.IntervalID.ClientID+"','"+this.CheckInterval.ClientID+"');</script>");
		}
		#endregion

		#region DeleteElementsUnusableFromTipIntervalAddCombo
		/// <summary>
		/// Sterge elementele
		/// </summary>
		private void DeleteElementsUnusableFromTipIntervalAddCombo()
		{
			IntervaleAngajat ia = new IntervaleAngajat(this.AngajatID);
			DataSet ds = ia.GetTipuriIntervaleFolosire();
			
			for( int i=0; i<ds.Tables[ 0 ].Rows.Count; i++ )
			{
				ListItem li = this.TipInterval.Items.FindByValue( ds.Tables[ 0 ].Rows[ i ][ "TipintervalID" ].ToString());
				this.TipInterval.Items.Remove( li );
			}
		}
		#endregion

		#region DeleteElementsUnusableFromTipIntervalModifyCombo
		/// <summary>
		/// Sterge elementele
		/// </summary>
		private void DeleteElementsUnusableFromTipIntervalModifyCombo()
		{
			IntervaleAngajat ia = new IntervaleAngajat(this.AngajatID);
			DataSet ds = ia.GetTipuriIntervaleFolosire();
			
			for( int i=0; i<ds.Tables[ 0 ].Rows.Count; i++ )
			{
				if( this.TipInterval.SelectedValue != ds.Tables[ 0 ].Rows[ i ][ "TipintervalID" ].ToString())
				{
					ListItem li = this.TipInterval.Items.FindByValue( ds.Tables[ 0 ].Rows[ i ][ "TipintervalID" ].ToString());
					this.TipInterval.Items.Remove( li );
				}
			}
		}
		#endregion

		#region BindTipIntervaleNestandardSelectBox
		/// <summary>
		/// Creata lista cu tipuri de intervale
		/// </summary>
		public void BindTipIntervaleNestandardSelectBox()
		{
			settings = Salaries.Configuration.ModuleConfig.GetSettings();
			new UtilitiesDb(settings.ConnectionString).CreateTipIntervaleNestandardSelectBox( this.TipInterval );
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
