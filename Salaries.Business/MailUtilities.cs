using System;
using System.Configuration;
using System.Web.Mail;

namespace Salaries.Business
{
	/// <summary>
	/// Implements mail operations
	/// </summary>
	public class MailUtilities
	{
		public MailUtilities()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		public void SendPasswordEmail()
		{
			MailMessage mailMsg = new MailMessage();
			mailMsg.From = ConfigurationSettings.AppSettings["CantinaEmail"];
			mailMsg.To = "ionel.popa@siemens.com";
			//mailMsg.Subject = ConfigurationSettings.AppSettings["CantinaEmailSubject"];
			mailMsg.Body = "T1 \t\t T2 \t\t T3 \r\n TT1 \t\t TT2 \t\t TT3";
			SmtpMail.SmtpServer = "bavc001a";
			SmtpMail.Send(mailMsg);	
		}
	}
}
