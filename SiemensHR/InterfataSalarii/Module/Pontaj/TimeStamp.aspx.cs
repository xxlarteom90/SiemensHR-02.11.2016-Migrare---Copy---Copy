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
using SiemensTM.Classes;
using SiemensTM.Module;

namespace SiemensTM
{
	/// <summary>
	/// Summary description for TimeStamp.
	/// </summary>
	public class TimeStampPage : Login
	{
		protected System.Web.UI.HtmlControls.HtmlTableCell TopMenuContainer;
		protected System.Web.UI.HtmlControls.HtmlTableCell CenterContainer;
		protected System.Web.UI.HtmlControls.HtmlTableCell TimeStampContainer;
		protected System.Web.UI.HtmlControls.HtmlTableCell Td1;
		protected System.Web.UI.HtmlControls.HtmlTableCell date_container;
		protected System.Web.UI.HtmlControls.HtmlTable Table1;
		protected System.Web.UI.WebControls.DropDownList LunaCurenta;
		protected System.Web.UI.HtmlControls.HtmlTableCell IntervaleContainer;
		

		

		protected TimeStamp TimeStamp1;
		protected System.Web.UI.HtmlControls.HtmlInputHidden ClientSelectedDate;
		protected Intervale Intervale1;

		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here


			this.DoQuickLogin(1017);

			if (!IsPostBack)
			{
				this.TimeStamp1.SelectedDate = DateTime.Now;
				this.Intervale1.SelectedDate = DateTime.Now;
				this.LunaCurenta.Items.Add("07.2004");
				this.LunaCurenta.Items.Add("08.2004");
				this.LunaCurenta.Items.Add("09.2004");
				this.SaveSessionKey(Definitions.SelectedDateKEY,DateTime.Now);
						
			}
			else

			
			{
				DateTime SelectedDate;
			
				
				
				
				
				if (this.ClientSelectedDate.Value!="")
				{
				
				
					string [] tmp = this.LunaCurenta.SelectedValue.Split(".".ToCharArray());
					int Zi = int.Parse(this.ClientSelectedDate.Value);
					int An = int.Parse(tmp[1]);
					int Luna = int.Parse(tmp[0]);
					SelectedDate=new DateTime(An,Luna,Zi);
					this.ClientSelectedDate.Value="";
					this.SaveSessionKey(Definitions.SelectedDateKEY,SelectedDate);

				}
				else SelectedDate = (DateTime)this.GetSessionKey(Definitions.SelectedDateKEY);	
	
				this.TimeStamp1.SelectedDate = SelectedDate;
				this.Intervale1.SelectedDate = SelectedDate;
			
			}



		}

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
			this.LunaCurenta.SelectedIndexChanged += new System.EventHandler(this.LunaCurenta_SelectedIndexChanged);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion


		private void LunaCurenta_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			
			string [] tmp = this.LunaCurenta.SelectedValue.Split(".".ToCharArray());
			int zi;
			int An = int.Parse(tmp[1]);
			int Luna = int.Parse(tmp[0]);

            if (DateTime.Now.Year==An && DateTime.Now.Month==Luna) zi = DateTime.Now.Day; else zi=1;
			this.TimeStamp1.SelectedDate = new DateTime(int.Parse(tmp[1]),int.Parse(tmp[0]),zi);
			this.Intervale1.SelectedDate = TimeStamp1.SelectedDate;

			this.SaveSessionKey(Definitions.SelectedDateKEY,TimeStamp1.SelectedDate);

		}
		protected override void Render(HtmlTextWriter writer)
		{
			base.Render (writer);
				Response.Write("<script>var ClientSelectedDateID = '"+this.ClientSelectedDate.ClientID+"';</script>");
		}

	}
}
