using System;
using System.Text;
using System.Security.Cryptography;
using System.IO;
using System.Runtime.InteropServices;

namespace Salaries.Configuration
{
	public class CAPICOMWrapper
	{
		private CAPICOM.Certificate ClientCert; 
		private CAPICOM.Certificate SignerCert;
		private string _signedContent;
		private string _clearText;
		public string Content
		{
			get
			{
				return _clearText;
			}
		}
		public string SignedContent
		{
			get
			{
				return _signedContent;
			}
		}
		public string SignFromText(string plaintextMessage,bool bDetached, Encoding encodingType) 
		{
			CAPICOM.SignedData signedData = new CAPICOM.SignedDataClass();
			CAPICOM.Utilities u = new CAPICOM.UtilitiesClass();
			signedData.Content = (u.ByteArrayToBinaryString(encodingType.GetBytes(plaintextMessage)));
			CAPICOM.Signer signer = new CAPICOM.Signer();
			signer.Certificate = ClientCert;
			this._signedContent = signedData.Sign(signer, bDetached, CAPICOM.CAPICOM_ENCODING_TYPE.CAPICOM_ENCODE_BASE64);
			return _signedContent;		
		}
		public bool VerifyDetachedSignature(string plaintextMessage, string signedContent, Encoding encodingType) 
		{
			try
			{
				this._clearText = plaintextMessage;
				this._signedContent = signedContent;
				CAPICOM.SignedData signedData = new CAPICOM.SignedDataClass();
				CAPICOM.Utilities u = new CAPICOM.UtilitiesClass();
				signedData.Content = (u.ByteArrayToBinaryString(encodingType.GetBytes(plaintextMessage)));
				signedData.Verify(_signedContent,true, CAPICOM.CAPICOM_SIGNED_DATA_VERIFY_FLAG.CAPICOM_VERIFY_SIGNATURE_ONLY);
				SignerCert=null;
				CAPICOM.Signer s = (CAPICOM.Signer) signedData.Signers[1];
				SignerCert = (CAPICOM.Certificate)s.Certificate;				
				return true;					
			}
			catch(COMException e)
			{
				return false;
			}
			
			
		}
		public bool VerifyAttachedSignature(string signedContent,Encoding encodingType) 
		{
			try
			{
				this._signedContent = signedContent;
				CAPICOM.Utilities u = new CAPICOM.Utilities();
				CAPICOM.SignedData signedData = new CAPICOM.SignedData();
				signedData.Verify(_signedContent,false, CAPICOM.CAPICOM_SIGNED_DATA_VERIFY_FLAG.CAPICOM_VERIFY_SIGNATURE_ONLY);
				SignerCert=null;
				CAPICOM.Signer s = (CAPICOM.Signer) signedData.Signers[1];
				SignerCert = (CAPICOM.Certificate)s.Certificate;				
				this._clearText =  encodingType.GetString((byte[])u.BinaryStringToByteArray(signedData.Content));
				return true;					
			}
			catch(COMException e)
			{
				return false;
			}
			
			
		}
			
		public void LoadSignature(byte[] signedData)
		{
			this._signedContent = Convert.ToBase64String(signedData);

		}
		public void LoadSignature(string base64signedData)
		{
			this._signedContent = base64signedData;

		}
		public void LoadCliCertFromCerStore(string certStore,string subjectName, bool isMachineStore)
		{
			try
			{
				CAPICOM.Store store = new CAPICOM.Store();

//				store.Open(isMachineStore?CAPICOM.CAPICOM_STORE_LOCATION.CAPICOM_LOCAL_MACHINE_STORE:CAPICOM.CAPICOM_STORE_LOCATION.CAPICOM_CURRENT_USER_STORE, 
//					certStore, CAPICOM.CAPICOM_STORE_OPEN_MODE.CAPICOM_STORE_OPEN_READ_ONLY);

				store.Open(CAPICOM.CAPICOM_STORE_LOCATION.CAPICOM_CURRENT_USER_STORE,
					certStore, CAPICOM.CAPICOM_STORE_OPEN_MODE.CAPICOM_STORE_OPEN_READ_ONLY);
			
				foreach (CAPICOM.Certificate cert in store.Certificates) 
				{				
					if(cert.SubjectName.IndexOf(subjectName)>0)
					{
						ClientCert = cert;	
						return;		
					}
				}
			}
			catch(COMException e)
			{
				throw e;
			}
		}	
	}
}

