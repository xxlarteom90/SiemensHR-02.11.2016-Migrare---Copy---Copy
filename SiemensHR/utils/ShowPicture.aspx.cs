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
using SiemensHR.Classes;

namespace SiemensHR.utils
{
	/// <summary>
	/// Summary description for ShowPicture.
	/// </summary>
	public class ShowPicture : System.Web.UI.Page
	{
		
		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			Salaries.Business.Angajat objAngajat = new Salaries.Business.Angajat();
			objAngajat.AngajatId = Convert.ToInt32(Request.QueryString["id"]);;

			object obj = objAngajat.LoadPozaAngajat();
			if (obj!=null)
			{
				byte[] img = (byte[]) obj;

				Response.Clear();
				Response.ContentType = "Image/"; 

				System.IO.MemoryStream stream = new System.IO.MemoryStream(img, true);
				stream.Write(img, 0, img.Length);

				Bitmap bitmap = new Bitmap(stream);

				bitmap.Save(Response.OutputStream, ImageFormat.Jpeg); 
			
				Response.End();
			}
			else  // no picture available
			{
				Bitmap bitmap = new Bitmap(150, 150);
				Graphics gr = Graphics.FromImage(bitmap);
				gr.Clear(Color.White);
				gr.DrawString("NO",new Font("Arial",12, FontStyle.Bold),System.Drawing.Brushes.Red,60,20); 
				gr.DrawString("PICTURE",new Font("Arial",12, FontStyle.Bold),System.Drawing.Brushes.Red,40,70); 
				gr.DrawString("AVAILABLE",new Font("Arial",12, FontStyle.Bold),System.Drawing.Brushes.Red,30,120); 

				Response.Clear();
				Response.ContentType = "Image/"; 
				bitmap.Save(Response.OutputStream, ImageFormat.Jpeg); 
				Response.End();

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
			this.Load += new System.EventHandler(this.Page_Load);
		}
		#endregion
	}
}
