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
using System.Drawing.Imaging;

using SiemensTM.Classes;

namespace SiemensTM.utils
{
	/// <summary>
	/// Summary description for ShowPicture.
	/// </summary>
	public class ShowIcon : System.Web.UI.Page
	{
		#region Variabile
		private string CheckupPath = "/Checkup";
		private string EvaluarePsihologicaPath = "/EvaluarePsihologica";
		#endregion

		#region GetCheckupPath
		/// <summary>
		/// Procedura obtine calea unui checkup
		/// </summary>
		/// <returns>Returneaza calea checkup-ului</returns>
		private string GetCheckupPath()
		{
			return Server.MapPath(Request.ApplicationPath+this.CheckupPath);
		}
		#endregion

		#region GetEvaluarePsihologicaPath
		/// <summary>
		/// Procedura obtine calea unei evaluari psihologice
		/// </summary>
		/// <returns>Returneaza calea evaluarii psihologice</returns>
		private string GetEvaluarePsihologicaPath()
		{
			return Server.MapPath(Request.ApplicationPath+this.EvaluarePsihologicaPath);
		}
		#endregion

		#region Page_Load
		private void Page_Load(object sender, System.EventArgs e)
		{			
			string AngajatID = Request.Params["AngajatID"];
			string CheckupID = Request.Params["CheckupID"];
			string EvaluarePsihologicaID = Request.Params["EvaluarePsihologicaID"];
			string file = Request.Params["file"];			
			string path;

			if (CheckupID!=null)
			{
				path = this.GetCheckupPath()+"\\" + AngajatID+"\\Checkup_"+CheckupID+"_"+file;
			}
			else
			{
				path = this.GetEvaluarePsihologicaPath()+"\\" + AngajatID+"\\EvaluarePsihologica_"+EvaluarePsihologicaID+"_"+file;
			}
			
			System.Drawing.Image x = SiemensTM.utils.Shell.GetFileIcon(path);
			if (x!=null)
			{
				System.Drawing.Bitmap bitmap = new Bitmap(x);
				for(int i=0;i<bitmap.Width;i++)
				{
					for(int j=0;j<bitmap.Height;j++)
					{
						if ( bitmap.GetPixel(i,j).Name=="0") bitmap.SetPixel(i,j,System.Drawing.Color.White);
					}
				}
				bitmap.Save(Response.OutputStream, ImageFormat.Jpeg); 
				Response.End();
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
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    
			this.Load += new System.EventHandler(this.Page_Load);
		}
		#endregion
	}
}
