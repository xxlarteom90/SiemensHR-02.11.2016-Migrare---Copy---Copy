using System;
using System.Text;
using System.Security.Cryptography;
using System.IO;
using System.Runtime.InteropServices;
using System.Collections;
using CAPICOM;
using System.Security.Cryptography.X509Certificates;
//
using DigSigner = Salaries.Configuration.CAPIWrap;
using CDO;
using ADODB;
//
namespace Salaries.Configuration
{
	/// <summary>
	/// 
	/// </summary>
	public class CAPIWrap
	{
		/// <summary>
		/// 
		/// </summary>
		private Certificate ClientCert = null;
		private X509Certificate ClientCertX509 = null;
		/// <summary>
		/// 
		/// </summary>
		private Certificate SignerCert = null;
		private X509Certificate SignerCertX509 = null;
		/// <summary>
		/// 
		/// </summary>
		private string _signedContent = "";
		/// <summary>
		/// 
		/// </summary>
		private string _Content = "";
		/// <summary>
		/// 
		/// </summary>
		private bool _bDetached = false;
		/// <summary>
		/// 
		/// </summary>
		public bool Detached
		{
			get { return this._bDetached; }
			set { this._bDetached = value; }
		}
		/// <summary>
		/// 
		/// </summary>
		public string Content
		{
			get { return this._Content; }
			set { this._Content = value; }
		}
		/// <summary>
		/// 
		/// </summary>
		public string SignedContent
		{
			get { return this._signedContent; }
			set { this._signedContent = value; }
		}
		/// <summary>
		/// Used for putting a TimeStamp on the Signed Email message
		/// </summary>
		/// <param name="signer"></param>
		private void DateTimeSigned(ref Signer signer)
		{
			CAPICOM.Attribute attr = new CAPICOM.AttributeClass();
			attr.Name = CAPICOM_ATTRIBUTE.CAPICOM_AUTHENTICATED_ATTRIBUTE_SIGNING_TIME;
			attr.Value = DateTime.Now;
			signer.AuthenticatedAttributes.Add(attr);
		}
		/// <summary>
		/// Signs the Data using a Digital Signature
		/// </summary>
		/// <param name="encodingType"></param>
		/// <returns></returns>
		public string SignData(Encoding encodingType)
		{
			//
			SignedData signedData = new SignedDataClass();
			Utilities u = new UtilitiesClass();
			//signedData.set_Content(u.ByteArrayToBinaryString(encodingType.GetBytes(Content)));
			signedData.Content = u.ByteArrayToBinaryString(encodingType.GetBytes(Content));
			//
			Signer signer = new CAPICOM.Signer();
			signer.Certificate = ClientCert;
			//
			DateTimeSigned(ref signer);
			//
			SignedContent = signedData.Sign(signer, Detached, CAPICOM_ENCODING_TYPE.CAPICOM_ENCODE_BASE64);
			//
			return SignedContent;
		}
		/// <summary>
		/// Verifies a Digital Signature based on the encoding type
		/// </summary>
		/// <param name="encodingType"></param>
		/// <returns></returns>
		public bool VerifySignature(Encoding encodingType)
		{
			try
			{
				SignedData signedData = new SignedDataClass();
				Utilities u = new UtilitiesClass();
				if (_bDetached)
				{
					signedData.Content = u.ByteArrayToBinaryString(encodingType.GetBytes(Content));
					//signedData.set_Content(u.ByteArrayToBinaryString(encodingType.GetBytes(Content)));
				}
				signedData.Verify(SignedContent, Detached, CAPICOM_SIGNED_DATA_VERIFY_FLAG.CAPICOM_VERIFY_SIGNATURE_ONLY);
				SignerCert = null;
				Signer s = (Signer)signedData.Signers[1];
				SignerCert = (Certificate)s.Certificate;
				if (!_bDetached)
				{
					//Content = encodingType.GetString((byte[])u.BinaryStringToByteArray(signedData.get_Content()));
					Content = encodingType.GetString((byte[])u.BinaryStringToByteArray(signedData.Content));
				}
				return true;
			}
			catch (COMException e)
			{
				Console.WriteLine("{0}: {1}", e.Source, e.Message);
				return false;
			}
		}
		/// <summary>
		/// Loads the Client Certificate from the Certificate Store
		/// </summary>
		/// <param name="subjectsName"></param>
		public void LoadCliCertFromCerStore(string subjectsName)
		{
			LoadCliCertFromCerStore("My", false, subjectsName);
		}
		/// <summary>
		/// Loads the Client Certificate from the Certificate Store
		/// </summary>
		/// <param name="isMachineStore"></param>
		/// <param name="subjectsName"></param>
		public void LoadCliCertFromCerStore(bool isMachineStore, string subjectsName)
		{
			LoadCliCertFromCerStore("My", isMachineStore, subjectsName);
		}
		/// <summary>
		/// Loads the Client Certificate from the Certificate Store
		/// </summary>
		/// <param name="certStore"></param>
		/// <param name="isMachineStore"></param>
		/// <param name="subjectsName"></param>
		public void LoadCliCertFromCerStore(string certStore, bool isMachineStore, string subjectsName)
		{
			try
			{
//				Store store = new Store();
//
//				store.Open(isMachineStore ? CAPICOM_STORE_LOCATION.CAPICOM_LOCAL_MACHINE_STORE : CAPICOM_STORE_LOCATION.CAPICOM_CURRENT_USER_STORE,
//					certStore, CAPICOM_STORE_OPEN_MODE.CAPICOM_STORE_OPEN_READ_ONLY);
//				
//				int nr = 0;
//				foreach (Certificate cert in store.Certificates)
//				{
//					nr++;
//					if (cert.SubjectName.IndexOf(subjectsName) > 0)
//					{
//						ClientCert = cert;
//						store.Close();
//						return;
//					}
//				}
//				store.Close();

				StoreClass oStore = new StoreClass();
				oStore.Open(
					CAPICOM_STORE_LOCATION.CAPICOM_CURRENT_USER_STORE,
					certStore,CAPICOM_STORE_OPEN_MODE.CAPICOM_STORE_OPEN_EXISTING_ONLY | 
					CAPICOM_STORE_OPEN_MODE.CAPICOM_STORE_OPEN_READ_ONLY 
					);

				Certificates oCerts = (Certificates) oStore.Certificates;
				oCerts = (Certificates) oCerts.Find(CAPICOM_CERTIFICATE_FIND_TYPE.CAPICOM_CERTIFICATE_FIND_SUBJECT_NAME, "", false);
			
				if (oCerts.Count>0)
				{
					ClientCert = (Certificate)oCerts[1] ;
				}
			}
			catch (COMException e)
			{
				throw e;
			}
		}
	}
	/// <summary>
	/// 
	/// </summary>
	public class CDOEmailer
	{
		// Private variables with default values
		private string _sFrom = "";
		private string _sTo = "";
		private string _sCC = "";
		private string _sBCC = "";
		private string _sSubject = "";
		private string _sBody = "";
		private string _sHTMLBody = "";
		private string _sServer = "";//"relay.cpqcorp.net";
		private string _sSignature = "";
		private string _sResult = "";
		private string _sStore = "My";
		private int _iPort = 25;
		private int _iTimeOut = 120;
		private int _iImportant = 2;
		private bool _bPlainText = true;
		private bool _bUseMachineStore = false;
		private bool _bDebug = false;
		private bool _bDetached = true;
		//public bool mailSent = false;
		//public bool Detached
		//{
		//    get { return this._bDetached; }
		//    set { this._bDetached = value; }
		//}
		/// <summary>
		/// 
		/// </summary>
		public string From
		{
			get { return this._sFrom; }
			set { this._sFrom = value; }
		}
		/// <summary>
		/// 
		/// </summary>
		public string To
		{
			get { return this._sTo; }
			set { this._sTo = value; }
		}
		/// <summary>
		/// 
		/// </summary>
		public string CC
		{
			get { return this._sCC; }
			set { this._sCC = value; }
		}
		/// <summary>
		/// 
		/// </summary>
		public string Body
		{
			get { return this._sBody; }
			set { this._sBody = value; }
		}
		/// <summary>
		/// 
		/// </summary>
		public string HTMLBody
		{
			get { return this._sHTMLBody; }
			set { this._sHTMLBody = value; }
		}
		/// <summary>
		/// 
		/// </summary>
		public string BCC
		{
			get { return this._sBCC; }
			set { this._sBCC = value; }
		}
		/// <summary>
		/// 
		/// </summary>
		public string Subject
		{
			get { return this._sSubject; }
			set { this._sSubject = value; }
		}
		/// <summary>
		/// 
		/// </summary>
		public string SMTPServer
		{
			get { return this._sServer; }
			set { this._sServer = value; }
		}
		/// <summary>
		/// 
		/// </summary>
		public string Signature
		{
			get { return this._sSignature; }
			set { this._sSignature = value; }
		}
		/// <summary>
		/// 
		/// </summary>
		public string TheStore
		{
			get { return this._sStore; }
			set { this._sStore = value; }
		}
		/// <summary>
		/// 
		/// </summary>
		public string Result
		{
			get { return this._sResult; }
			set { this._sResult = value; }
		}
		/// <summary>
		/// 
		/// </summary>
		public int SMTPPort
		{
			get { return this._iPort; }
			set { this._iPort = value; }
		}
		/// <summary>
		/// 
		/// </summary>
		public int TimeOut
		{
			get { return this._iTimeOut; }
			set { this._iTimeOut = value; }
		}
		/// <summary>
		/// 
		/// </summary>
		public int Important
		{
			get { return this._iImportant; }
			set { this._iImportant = value; }
		}
		/// <summary>
		/// 
		/// </summary>
		public bool PlainText
		{
			get { return this._bPlainText; }
			set { this._bPlainText = value; }
		}
		/// <summary>
		/// 
		/// </summary>
		public bool UseMachineStore
		{
			get { return this._bUseMachineStore; }
			set { this._bUseMachineStore = value; }
		}
		/// <summary>
		/// 
		/// </summary>
		public bool Debug
		{
			get { return this._bDebug; }
			set { this._bDebug = value; }
		}
		/// <summary>
		/// This uses CAPICOM with Plaintext Data as input and returns "Signed" Data as output.
		/// </summary>
		/// <param name="sMsg"></param>
		/// <param name="encodingType"></param>
		/// <returns></returns>
		public string SignEMail(string sMsg, System.Text.Encoding encodingType)
		{
			DigSigner capiDS = new DigSigner();
			if (Signature.Length == 0)
			{ Console.WriteLine("Error: Must have a \"Signature\"!\n"); return String.Empty; }
			//
			capiDS.LoadCliCertFromCerStore(TheStore, UseMachineStore, Signature);
			capiDS.Content = sMsg;
			capiDS.Detached = _bDetached;
			Result = capiDS.SignData(encodingType);
			//
			// Now verify we have good data in return...
			if (!capiDS.VerifySignature(encodingType)) { Result = "error"; }
			return Result;
		}
		//***************************************************************************
		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public bool SendTo()
		{
			CDO.MessageClass a = new CDO.MessageClass();
			CDO.IBodyPart ibp;
			CDO.IBodyPart ibp2;
			ADODB.Fields flds;
			ADODB.Fields flds1;
			ADODB.Fields flds2;

			if (To.Length == 0)
			{ Console.WriteLine("Error: Must have a \"To\"!\n"); return false; }
			//
			if (From.Length == 0)
			{ Console.WriteLine("Error: Must have a \"From\"!\n"); return false; }
			//
			if (SMTPServer.Length == 0)
			{ Console.WriteLine("Error: Must have a \"SMTPServer\"!\n"); return false; }
			//
			a.To = To;
			a.From = From;
			a.CC = CC;
			a.BCC = BCC;
			a.Subject = Subject;
			//
			ibp = a;
			//
			flds = ibp.Fields;
			flds["urn:schemas:mailheader:Content-Type"].Value = "multipart/signed; protocol=application/pkcs7-signature; micalg=SHA1";
			flds["urn:schemas:mailheader:thread-index"].Value = "";
			flds["urn:schemas:mailheader:thread-topic"].Value = "";
			flds["urn:schemas:mailheader:priority"].Value = "";
			flds["urn:schemas:mailheader:importance"].Value = "";
			flds["urn:schemas:mailheader:content-class"].Value = "";
			flds["urn:schemas:mailheader:X-Priority"].Value = 1;
			flds.Update();

			// Setup the first body part; this is the header
			// plus the file contents.
			ibp2 = ibp.AddBodyPart(1);
			flds1 = ibp2.Fields;
			flds1["urn:schemas:mailheader:content-class"].Value = "urn:content-classes:message";
			if (PlainText)
			{
				flds1["urn:schemas:mailheader:importance"].Value = Important;
				flds1["urn:schemas:mailheader:content-type"].Value = "text/plain";
			}
			else
			{
				flds1["urn:schemas:mailheader:content-type"].Value = "text/html; charset=UTF-8";
				flds1["urn:schemas:httpmail:content-media-type"].Value = "text/html";
				flds1["urn:schemas:httpmail:importance"].Value = Important;
			}
			flds1["urn:schemas:mailheader:content-transfer-encoding"].Value = "7bit";
			flds1.Update();

			a.MimeFormatted = true;
			//
			// If HTML, put the HTML body in ...
			if (!PlainText) { Body = HTMLBody; }
			//
			string messageToSign = Body;
			//
			ADODB.Stream stm;
			stm = ibp2.GetDecodedContentStream();
			stm.Type = ADODB.StreamTypeEnum.adTypeText;
			stm.WriteText(messageToSign, ADODB.StreamWriteEnum.adWriteChar);
			stm.Flush();
			//
			// Pass in the full stream (header and content) and sign it.
			string strbase64 = SignEMail(ibp2.GetStream().ReadText(ibp2.GetStream().Size), Encoding.UTF8);
			//string strbase64 = this.Body; // SignEMail(ibp2.GetStream().ReadText(ibp2.GetStream().Size), Encoding.UTF8);
			//
			if (strbase64 == "error")
			{
				Result = "Error: Could not Sign it?";
				return false;
			}
			//
			// Can add an attachment here, but it then shows the "Digital Signature" as an attachment
			//a.AddAttachment("C:\\Test.txt", "", "");
			//
			ibp2 = a.AddBodyPart(2);
			flds2 = ibp2.Fields;
			flds2["urn:schemas:mailheader:content-Disposition"].Value = "attachment; FileName=smime.p7s";
			flds2["urn:schemas:mailheader:content-Description"].Value = "S/MIME Cryptographic Signature";
			flds2["urn:schemas:mailheader:Content-Type"].Value = "application/x-pkcs7-signature; Name=smime.p7s";
			flds2["urn:schemas:mailheader:Content-Transfer-Encoding"].Value = "base64";
			flds2.Update();
			//
			stm = ibp2.GetEncodedContentStream();
			stm.Type = ADODB.StreamTypeEnum.adTypeText;
			stm.WriteText(strbase64, ADODB.StreamWriteEnum.adWriteLine);
			stm.Flush();
			stm.Close();
			//
			a.Configuration.Fields["http://schemas.microsoft.com/cdo/configuration/sendusing"].Value = CdoSendUsing.cdoSendUsingPort;
			a.Configuration.Fields["http://schemas.microsoft.com/cdo/configuration/smtpserver"].Value = SMTPServer;
			a.Configuration.Fields["http://schemas.microsoft.com/cdo/configuration/smtpserverport"].Value = SMTPPort;
			a.Configuration.Fields["http://schemas.microsoft.com/cdo/configuration/smtpconnectiontimeout"].Value = TimeOut;
			a.Configuration.Fields.Update();
			//
			a.Send();
			//
			// Get the whole SMIME message.
			Result = a.GetStream().ReadText(a.GetStream().Size);
			//
			if (Debug) { Console.WriteLine("\n{0}\n", Result); }
			//
			return true;
		}
	}
}
