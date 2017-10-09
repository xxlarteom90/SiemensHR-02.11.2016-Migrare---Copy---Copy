using System.Configuration;
using System;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

using SiemensTM.utils;
using SiemensTM.Classes;
using SiemensHR.Classes;

namespace SiemensTM.Module
{
	/// <summary>
	///		Summary description for IntervalIntreruperiContract.
	/// </summary>
	public class IntervalIntreruperiContract : System.Web.UI.UserControl
	{
		#region Variabile
		protected System.Web.UI.HtmlControls.HtmlInputText DateStart;
		protected System.Web.UI.HtmlControls.HtmlInputText DateEnd;
		protected System.Web.UI.HtmlControls.HtmlTextArea observatiiTA;
		protected System.Web.UI.HtmlControls.HtmlInputCheckBox CheckInterval;
		protected System.Web.UI.HtmlControls.HtmlInputHidden IntervalIntrerupereID;

		public bool LabelsVisible = true;
		public string textObservatii = "";
		public bool Selectable;
		protected System.Web.UI.WebControls.Label LabelDataEnd;
		protected System.Web.UI.WebControls.Label LabelDataStart;
		protected System.Web.UI.HtmlControls.HtmlTableRow linieLabel;
		public int AngajatID = -1;
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
				return IntervalIntrerupereID;
			}
			set
			{
				IntervalIntrerupereID = value;
			}
		}

		public System.Web.UI.HtmlControls.HtmlTextArea descriere
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

		#endregion

		#region Page_Load
		private void Page_Load(object sender, System.EventArgs e)
		{
			this.DateStart.Attributes["onblur"] = "getIntervalIntreruperi('"+this.ClientID+"').DataStartChanged()";
			this.DateEnd.Attributes["onblur"] = "getIntervalIntreruperi('"+this.ClientID+"').DataEndIntrerupereChanged()";
			this.DateStart.Attributes["onkeyup"] = "getIntervalIntreruperi('"+this.ClientID+"').DataStartKeyPressed()";
			this.DateEnd.Attributes["onkeyup"] = "getIntervalIntreruperi('"+this.ClientID+"').DataEndKeyPressed()";
			this.observatiiTA.Attributes[ "onblur" ] = "getIntervalIntreruperi('"+this.ClientID+"').ObservatiiIntreruperiChanged()";
		}
		#endregion

		#region OnPreRender
		protected override void OnPreRender(EventArgs e)
		{
			base.OnPreRender (e);

			LabelDataStart.Visible = LabelDataEnd.Visible = LabelsVisible;
			linieLabel.Visible = LabelsVisible;
			
			if( !this.Selectable )
			{
				this.CheckInterval.Visible=false;
			}
			observatiiTA.Value = textObservatii;
		}
		#endregion

		#region Render
		protected override void Render(System.Web.UI.HtmlTextWriter writer)
		{
			base.Render (writer);
			Response.Write( "<script>var DataStartIntrerupere = '"+this.DateStart.ClientID+"';</script>");
			Response.Write( "<script>var DataEndIntrerupere = '"+this.DateEnd.ClientID+"';</script>");
			Response.Write( "<script>var CheckIntreruperi = '"+this.CheckInterval.ClientID+"';</script>");
			Response.Write( "<script>var IntervIntreruperiID = '"+this.IntervalIntrerupereID.ClientID+"';</script>");
			Response.Write( "<script>var ObservatiiIDIntrerupere = '"+this.observatiiTA.ClientID+"';</script>");
			
			string valoare = "<script>var tmpIntreruperi = new CreateIntervalIntreruperiElement('"+this.ClientID+"','"+this.DateStart.ClientID+"','"+this.DateEnd.ClientID+"','"+this.IntervalIntrerupereID.ClientID+"','"+this.CheckInterval.ClientID+"','"+this.observatiiTA.ClientID+"');</script>";
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
