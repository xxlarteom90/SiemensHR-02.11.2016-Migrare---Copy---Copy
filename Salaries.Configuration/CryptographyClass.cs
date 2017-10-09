using System;
using System.IO;
using System.Xml;
using System.Text;
using System.Configuration;
using System.Security.Cryptography;

namespace Salaries.Configuration
{
	/// <summary>
	/// Summary description for CryptographyClass.
	/// </summary>
	public class CryptographyClass
	{
		#region Constructor
		/// <summary>
		/// Constructor
		/// </summary>
		public CryptographyClass()
		{}
		#endregion

		#region Chei criptare
		//Cheia publica
		private static string privateKey = "XUenPktGV8KqWFr6RfE2r0Uljn/yV2i0";
		//Cheia privata
		private static string publicKey = "jtMkGqChCYw=";
		//Obiectul folosit pentru criptarea datelor
		private static TripleDESCryptoServiceProvider des = new TripleDESCryptoServiceProvider();          
		#endregion
	
		#region getConfigPath
		/// <summary>
		/// Returneaza calea catre wb.config
		/// </summary>
		private static string getConfigPath() 
		{
			string cfgPath = AppDomain.CurrentDomain.SetupInformation.ConfigurationFile;
			cfgPath = cfgPath.Replace("/", "\\");
			cfgPath = Path.GetDirectoryName(cfgPath);

			return Path.Combine(cfgPath, "web.config");
		}
		#endregion

		#region encodeSTR
		/// <summary>
		/// Procedura codifica un string
		/// </summary>
		/// <param name="thisEncode">Sting-ul care va fi codificat</param>
		/// <returns>Returneaza string-ul codificat</returns>
		public static string encodeSTR(string thisEncode)
		{
			string encrypted;
			byte[] Code = ASCIIEncoding.ASCII.GetBytes(thisEncode);
			des.Key = Convert.FromBase64String(privateKey);
			des.IV = Convert.FromBase64String(publicKey);
		
			encrypted = Convert.ToBase64String(
				des.CreateEncryptor().TransformFinalBlock(Code, 0, Code.Length)
				);
		
			return encrypted;
		}
		#endregion
	
		#region decodeSTR
		/// <summary>
		/// Procedura decodifica un string
		/// </summary>
		/// <param name="thisDecode">Stringul care va fi decodificat</param>
		/// <returns>Returneaza string-ul codificat</returns>
		public static string decodeSTR(string thisDecode)
		{
			string decrypted;
			byte[] Code = Convert.FromBase64String(thisDecode);
		
			decrypted = ASCIIEncoding.ASCII.GetString(
				des.CreateDecryptor().TransformFinalBlock(Code, 0, Code.Length)
				);

			return decrypted;
		}
		#endregion

		#region getSetting
		/// <summary>
		/// Returneaza setarile din cadrul unui nod de tipul <add key="..." value="..."> din web.config
		/// </summary>
		/// <param name="key">Numele nodului</param>
		/// <returns>Returneaza valoarea nodului</returns>
		public static string getSetting(string key) 
		{
			//este creea un nou document XML pentru a incarca fisierul XML de configurare
			XmlDocument xmlDoc = new XmlDocument();

			// este setata cheia
			des.Key = Convert.FromBase64String(privateKey);
			
			// este incarcat fisierul
			if (File.Exists(getConfigPath())) xmlDoc.Load(getConfigPath());

			// este cautata cheia
			XmlNode keyNode = xmlDoc.SelectSingleNode("//appSettings/add[@key='" + key + "']");

			//daca exista
			if ( keyNode != null ) 
			{
				//cheia publica
				des.IV = Convert.FromBase64String(publicKey);

				//este obtinuta valoarea nodului 
				string Value = keyNode.Attributes["value"].Value;
				
				//este decriptata valoarea
				Value = decodeSTR(keyNode.Attributes["value"].Value);
				
				return Value;
			}
			else
			{
				return "";
			}
		}
		#endregion

		#region getSettingsWithoutDecode
		/// <summary>
		/// In cazul in care valoarea corespunzatoare cheii nu este codata, acesta poate fi returnata cu ajutorul acestei metode
 		/// </summary>
		/// <param name="key">Numele nodului</param>
		/// <returns>Retunreaza valoarea nodului</returns>
		public static string getSettingsWithoutDecode(string key) 
		{
			//este creea un nou document XML pentru a incarca fisierul XML de configurare
			XmlDocument xmlDoc = new XmlDocument();
			
			// este incarcat fisierul
			if (File.Exists(getConfigPath())) xmlDoc.Load(getConfigPath());

			// este cautata cheia
			XmlNode keyNode = xmlDoc.SelectSingleNode("//appSettings/add[@key='" + key + "']");

			//daca exista
			if ( keyNode != null ) 
			{

				//este obtinuta valoarea nodului 
				string Value = keyNode.Attributes["value"].Value;
								
				return Value;
			}
			else
			{
				return "";
			}
		}
		#endregion

		#region writeSetting
		/// <summary>
		/// Sunt scrise setarile
		/// </summary>
		/// <param name="key">Numele nodului</param>
		/// <param name="keyValue">Valoarea nodului</param>
		/// <param name="encode">Nodul este codificat sau nu</param>
		public static void writeSetting(string key, string keyValue, bool encode) 
		{
			// este creeat un nou document XML pentru incarcarea fisierului de configurare
			XmlDocument xmlDoc = new XmlDocument();

			// este setata cheia privata
			des.Key = Convert.FromBase64String(privateKey);

			//este incarcat fisierul de configurare
			if (File.Exists(getConfigPath())) 
				xmlDoc.Load(getConfigPath());

			// este cautat nodul appSettings
			XmlNode appSettings = xmlDoc.SelectSingleNode("//appSettings");

			// daca nu exista nodul, acesta este adaugat
			if ( appSettings == null ) 
			{
				appSettings = xmlDoc.CreateElement("appSettings");
				xmlDoc.AppendChild(appSettings);
			}

			// este cautata cheia
			XmlNode keyNode = xmlDoc.SelectSingleNode("//appSettings/add[@key='" + key + "']");

			// daca exista
			if ( keyNode != null ) 
			{
				//este realizat updat-ul
				XmlNode myAttribute = keyNode.Attributes["value"];
				
				//daca trebuie codata
				if (encode) 
				{
					//este setata valoarea
					keyNode.Attributes["value"].Value = encodeSTR(keyValue);
				}
					//daca valoarea nu trebuie codata, atunci doar o setam
				else
				{
					keyNode.Attributes["value"].Value = keyValue;
				}
			}
				//daca nu este gasita cheia
			else
			{
				
				// este creeata
				keyNode = xmlDoc.CreateElement("add");

				//sunt setate atributele nodului
				XmlAttribute newKey = xmlDoc.CreateAttribute("key");
				XmlAttribute newValue = xmlDoc.CreateAttribute("value");
				
				//este setat numele cheii
				newKey.Value = key;

				if (encode)
				{
					//este setata valoarea 
					newValue.Value = encodeSTR(keyValue);

					//sunt adaugate atributele
					keyNode.Attributes.Append(newKey);
					keyNode.Attributes.Append(newValue);

					//este adaugata cheia
					appSettings.AppendChild(keyNode);
				}
				else
				{
					// daca nu trebuie codata valoarea aceasta este doar setata
					newValue.Value = keyValue;

					// Append the attributes
					keyNode.Attributes.Append(newKey);
					keyNode.Attributes.Append(newValue);
					
					// Add the key
					appSettings.AppendChild(keyNode);
				}
			}

			//este salvat fisierul XML
			xmlDoc.Save(getConfigPath());
		}
		#endregion
	}
}
