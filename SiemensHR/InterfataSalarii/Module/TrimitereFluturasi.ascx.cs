using System;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Configuration;
using System.Data.SqlClient;

using Salaries.Business;
using SiemensHR.utils;
using SiemensHR.Classes;
using Salaries.Configuration;

using System.Web.Mail;
using System.Security.Cryptography.X509Certificates;

namespace SiemensHR.InterfataSalarii.Module
{
	/// <summary>
	///		Summary description for TrimitereFluturasi.
	/// </summary>
	public class TrimitereFluturasi :  SiemensHR.InterfataSalarii.Classes.BaseModule
	{
		#region Variabile
		protected Salaries.Configuration.ModuleSettings settings;
		protected System.Web.UI.WebControls.Button btnTrimitereMail;
		public long lunaID;
		public long lunaActiva;
		public int angajatorID;
		protected System.Web.UI.WebControls.Label lblMesaj;
		protected System.Web.UI.HtmlControls.HtmlInputButton btnTrimiteMail;
		protected System.Web.UI.HtmlControls.HtmlInputText txtBody;
		private string actionTrimiteMailFluturasiLuna = "";
		private string mailFluturasiLuna = "";
		#endregion

		#region Page_Load
		private void Page_Load(object sender, System.EventArgs e)
		{
			string script_text = "<script>var ctrlID = \""+this.ClientID+"\"</script>";
			Response.Write(script_text);
			Response.Write("<script>var txtBodyClient = \"" + this.txtBody.ClientID + "\"</script>");
			lunaID = this.GetCurrentMonth();
			angajatorID = this.GetAngajator();

			actionTrimiteMailFluturasiLuna = ((System.Web.UI.HtmlControls.HtmlInputHidden)Page.FindControl( "ActionTrimiteMailFluturasiLunaValue" )).Value;
			mailFluturasiLuna = ((System.Web.UI.HtmlControls.HtmlInputHidden)Page.FindControl( "mailFluturasiLunaValue" )).Value;
			
			Salaries.Business.Luni salLuni = new Salaries.Business.Luni(angajatorID);
			lunaActiva = salLuni.GetLunaActiva().LunaId;

			HandleActions();
		}
		#endregion

		#region HandleActions
		/// <summary>
		/// Executa operatia
		/// </summary>
		private void HandleActions()
		{
			//aici trebuie sa verific daca e luna activa sau nu
			if (lunaID!=lunaActiva)
			{
				lblMesaj.Text = "Nu se pot trimite fluturasii decat pentru luna activa!";
			}
			else
			{
				switch( actionTrimiteMailFluturasiLuna )
				{
					case "trimiteMailFluturasi":
						lblMesaj.Text = "";
						btnTrimitereMail_Click();
						((System.Web.UI.HtmlControls.HtmlInputHidden)Page.FindControl( "ActionTrimiteMailFluturasiLunaValue" )).Value = "";
						break;
					default:
						break;
				}
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

		private void btnTrimitereMail_Click()
		{
			//UsingCapicom cap = new UsingCapicom();
			//cap.FindCertificate();
			//cap.SendMail();
			//cap.SignMessage();
			MailMessage mail = new MailMessage();
			mail.To = "andreea.lungu@siemens.com";
			mail.From = "andreea.lungu@siemens.com";
			mail.Body = mailFluturasiLuna;
			mail.Subject = "test";
			
			SmtpMail.SmtpServer = "smtp.bav.siemens.ro";//your real server goes here
			SmtpMail.Send( mail );

			UsingCapicom cap = new UsingCapicom();
			cap.SignMessage();
			cap.SendMail();
		}

		static void SendEncryptedEmail(
			string SigningCertPath, string EncryptingCertPath,
			string To, string From, string Subject, string Body,
			string SmtpServer, int SmtpPort, bool HTML)
		{
			
			/*X509Certificate SignCert = X509Certificate.CreateFromCertFile(SigningCertPath);
			X509Certificate EncryptCert = X509Certificate.CreateFromCertFile(EncryptingCertPath);

			string message = "";
			message += "\nContent-Type: text/" + ((HTML) ? "html" : "plain") +
				"; charset=\"iso-8859-1\"";
			message += "\nContent-Transfer-Encoding: 7bit";
			message += "\n";
			message += "\n" + Body;

			byte[] BodyBytes = System.Text.Encoding.ASCII.GetBytes(message);

			EnvelopedDataClass ECms = new EnvelopedDataClass(new ContentInfo(BodyBytes));
			
			
			EnvelopedCms ECms = new EnvelopedCms(new ContentInfo(BodyBytes));
			CmsRecipient Recipient = new CmsRecipient(
				SubjectIdentifierType.IssuerAndSerialNumber, EncryptCert);
			ECms.Encrypt(Recipient);
			byte[] EncryptedBytes = ECms.Encode();

			SignedCms Cms = new SignedCms(new ContentInfo(EncryptedBytes));
			CmsSigner Signer = new CmsSigner
				(SubjectIdentifierType.IssuerAndSerialNumber, SignCert);

			Cms.ComputeSignature(Signer);
			byte[] SignedBytes = Cms.Encode();

			MailMessage Msg = new MailMessage();
			Msg.To.Add(new MailAddress(To));
			Msg.From = new MailAddress(From);
			Msg.Subject = Subject;

			MemoryStream ms = new MemoryStream(EncryptedBytes);
			AlternateView av = new AlternateView(ms,
				"application/pkcs7-mime; smime-type=signed-data;name=smime.p7m");
			Msg.AlternateViews.Add(av);

			SmtpClient smtp = new SmtpClient(SmtpServer, SmtpPort);
			smtp.UseDefaultCredentials = true;
			smtp.Send(Msg);*/
		}

	}
}

