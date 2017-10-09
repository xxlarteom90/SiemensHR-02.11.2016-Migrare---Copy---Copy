using System;
using CAPICOM;
using System.Security.Cryptography.X509Certificates;

namespace Salaries.Configuration
{
	/// <summary>
	/// Summary description for UsingCapicom.
	/// </summary>
	public class UsingCapicom
	{
		static private String storeName = "My";
		static StoreClass oStore;
		static Certificates oCerts;
		static String filter = "yoursearchstring";

		public UsingCapicom()
		{

		}

		public X509Certificate FindCertificate()
		{
			oStore = new StoreClass();
			oStore.Open(
				CAPICOM_STORE_LOCATION.CAPICOM_CURRENT_USER_STORE,
				storeName,CAPICOM_STORE_OPEN_MODE.CAPICOM_STORE_OPEN_EXISTING_ONLY | 
				CAPICOM_STORE_OPEN_MODE.CAPICOM_STORE_OPEN_READ_ONLY 
				);

			oCerts = (Certificates)oStore.Certificates;
			oCerts = (Certificates) oCerts.Find(CAPICOM_CERTIFICATE_FIND_TYPE.CAPICOM_CERTIFICATE_FIND_SUBJECT_NAME, "", false);
			/*oCerts = (Certificates)oCerts.Find(
				CAPICOM_CERTIFICATE_FIND_TYPE.CAPICOM_CERTIFICATE_FIND_SUBJECT_NAME, filter, false);*/
			
//			foreach(Certificate ocert in oCerts)  //Certificates is IEnumerable
//			{
//				ocert.Display();
//			}

			//--- get first cert using indexer, retrieve ICertContext and use from managed code -----
			if (oCerts.Count>0)
			{
				Certificate firstcert = (Certificate)oCerts[1] ;
				//firstcert.Display() ;

				ICertContext iCertCntxt = (ICertContext) firstcert;
				int certcntxt = iCertCntxt.CertContext ;

				IntPtr hCertCntxt = new IntPtr(certcntxt);
				if(hCertCntxt != IntPtr.Zero)
				{     
					//use certcontext from managed code
					string s = "";
					s += " CertContext: " + hCertCntxt.ToInt32();
					X509Certificate foundcert = new X509Certificate(hCertCntxt);
					s += " subject name: " + foundcert.GetName();
					s += " serial no: " + foundcert.GetSerialNumberString();
					s += " hash string:" + foundcert.GetCertHashString();
					return foundcert;
				}
			}
			return null;
		}

		private string Encrypt_CAPICOM(string plainText, Certificate cert)
		{
			EnvelopedDataClass envelopedData = new EnvelopedDataClass();
			envelopedData.Content = plainText;
			envelopedData.Recipients.Add(cert);
			return envelopedData.Encrypt(CAPICOM_ENCODING_TYPE.CAPICOM_ENCODE_BASE64);
		}

		private string Decrypt_CAPICOM(string encryptedData)
		{
			EnvelopedDataClass envelopedData = new EnvelopedDataClass();
			envelopedData.Decrypt(encryptedData);
			return envelopedData.Content;
		}

		public void SendMailSigned()
		{
			X509Certificate cert = FindCertificate();

			//string str = Encrypt_CAPICOM("abcd1234", cert);


			//X509Certificate SignCert = X509Certificate.CreateFromCertFile(SigningCertPath);
			//X509Certificate EncryptCert = X509Certificate.CreateFromCertFile(EncryptingCertPath);

//			string message = "";
//			bool HTML = false;
//			string Body = "test";
//			message += "\nContent-Type: text/" + ((HTML) ? "html" : "plain") +
//				"; charset=\"iso-8859-1\"";
//			message += "\nContent-Transfer-Encoding: 7bit";
//			message += "\n";
//			message += "\n" + Body;
//
//			byte[] data = System.Text.Encoding.ASCII.GetBytes(message);
		}

		public void SendMail()
		{
			CDOEmailer email = new CDOEmailer();
			//
			email.To = "andreea.lungu@siemens.com";
			email.From = "andreea.lungu@siemens.com";
			email.CC = "andreea.lungu@siemens.com";
			email.Signature = "Lungu Andreea";
			email.Subject = "Digital Signing Test";
			email.TheStore = "My";
			email.SMTPServer = "smtp.bav.siemens.ro";
			email.Body = "This is the BODY of the message!!";
			email.HTMLBody = "This is the <b>BODY</b> of the message!!";
			//
			email.SMTPPort = 25; // Default Value
			email.Important = 2; // Default Value
			email.PlainText = false; // Default Value
			email.TimeOut = 120; // Default Value
			email.UseMachineStore = false; // Default Value
			email.Debug = true; // Default Value
			//
			if (email.SendTo())
			{ Console.WriteLine("\nSigned and sent...\n"); }
			else
			{ Console.WriteLine("\nError: Failed to send email?\n"); }
		}

		public void SignMessage()
		{
			CAPICOMWrapper capi = new CAPICOMWrapper();
			capi.LoadCliCertFromCerStore("MY", "Lungu", false);
			string newText = capi.SignFromText("andreea" ,true, System.Text.Encoding.UTF8);
		}
	}
}
