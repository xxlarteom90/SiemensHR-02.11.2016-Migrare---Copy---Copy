<%@ Control Language="c#" AutoEventWireup="false" Codebehind="TrimitereFluturasi.ascx.cs" Inherits="SiemensHR.InterfataSalarii.Module.TrimitereFluturasi" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>
<script language="vbscript" type="text/vbscript" src="../js/xmlsig.vbs"></script>
<script language="vbscript" type="text/vbscript">
 'Initierea variabilelor capicom
Const CAPICOM_CURRENT_USER_STORE = 2
Const CAPICOM_MY_STORE = "My"
Const CAPICOM_STORE_OPEN_READ_ONLY = 0
Const CAPICOM_STORE_OPEN_EXISTING_ONLY = 128
Const CAPICOM_CERTIFICATE_FIND_KEY_USAGE = 12
Const CAPICOM_DIGITAL_SIGNATURE_KEY_USAGE = 128
Const CAPICOM_CERT_INFO_SUBJECT_EMAIL_NAME = 2
Const CAPICOM_OID_CLIENT_AUTH_EKU = 101
Const CAPICOM_ACTIVE_DIRECTORY_USER_STORE = 3
Const CAPICOM_SMART_CARD_USER_STORE = 4
Const CAPICOM_LOCAL_MACHINE_STORE = 1
Const CAPICOM_CERTIFICATE_FIND_SUBJECT_NAME = 1
Const CAPICOM_HASH_ALGORITHM_SHA1 = 0
Const CAPICOM_CERT_INFO_SUBJECT_SIMPLE_NAME = 0
 
 function TrimiteMail()
	GetCert()
	MsgBox SignElement("andreea")
	'MsgBox EnvelopedElement("andreea")
	document.getElementById( mailFluturasiValue ).value = EnvelopedElement("andreea")
	document.getElementById( ActionTrimiteMailFluturasiValue ).value = "trimiteMailFluturasi"
	document.getElementById( FormClientID ).submit()
 end function
 
'Semnarea informatiei - data.Sign(<signinfo>)
function SignElement(theString)

	MsgBox "sign element"
    Set oSigner = CreateObject("CAPICOM.Signer")
    oSigner.Certificate = Certificat
    
    Set oSignedData = CreateObject("CAPICOM.SignedData")
    oSignedData.Content = theString
    'se returneaza valoarea semnata
    signData = oSignedData.Sign(oSigner)
    
    SignElement = signData

end function

'sematura prin encryptie
function EnvelopedElement(theString)

	MsgBox "enveloped element"
    Set oEnevelopData = CreateObject("CAPICOM.EnvelopedData")
    oEnevelopData.Recipients.Add(Certificat)
    oEnevelopData.Content = theString
    'EnvelopedElement = oEnevelopData.Encrypt(CAPICOM_ENCODE_BASE64)
    EnvelopedElement = oEnevelopData.Encrypt(CAPICOM_ENCODE_BASE64)

end function

'Se extrage certificatul prezent pe card
Dim Certificat
function GetCert()

	MsgBox "get cert"
	
    On Error Resume Next

    Dim xmlDoc
    Dim xmlInfo
    Dim oStore
    Dim oCerts
    Dim oCert
    Dim oSelectedCerts
    Dim key
    Dim oEncryptData
    
    Set oEncryptData = CreateObject("CAPICOM.EncryptData")
    Set oStore = CreateObject("CAPICOM.Store")
    Set oCerts = CreateObject("CAPICOM.Certificates")
    Set oStoreCerts = CreateObject("CAPICOM.Certificates")
    Set key = CreateObject("CAPICOM.PrivateKey")
    Set iCertCntxt = CreateObject("CAPICOM.ICertContext")
    
     'extragem certificatele disponibile pe card
    oStore.Open  CAPICOM_SMART_CARD_USER_STORE, CAPICOM_MY_STORE, CAPICOM_STORE_OPEN_READ_ONLY Or CAPICOM_STORE_OPEN_EXISTING_ONLY
    Set oStoreCerts = oStore.Certificates.Find(CAPICOM_CERTIFICATE_FIND_KEY_USAGE, CAPICOM_DIGITAL_SIGNATURE_KEY_USAGE, True)
    
    For each oCert in oStoreCerts
        If Len (oCert.GetInfo ( CAPICOM_CERT_INFO_SUBJECT_EMAIL_NAME )) > 0 Then
	    	oCerts.Add(oCert)
	    End If
    Next

    if oCerts.Count = 0 Then
	    oStore.Open  
        Set oStoreCerts1 = oStore.Certificates.Find(CAPICOM_CERTIFICATE_FIND_KEY_USAGE, CAPICOM_DIGITAL_SIGNATURE_KEY_USAGE, True)
        'msgbox oStoreCerts1.Count
         For each oCert in oStoreCerts1
            If Len (oCert.GetInfo ( CAPICOM_CERT_INFO_SUBJECT_EMAIL_NAME )) > 0 Then
	    	    oCerts.Add(oCert)
	        End If
         Next
    end if

    If oCerts.Count = 0 Then
        'in cazul in care nu a fost gasit nici un certificat
	    msgbox "Nu au fost gasite certificate valide."
    Else

	    if oCerts.Count = 1 Then
		    Set Certificat = oCerts(1)
	    Else
		    set oSelectedCerts = oCerts.Select()

'		    in cazul in care a fost apasat cancel

		    if oSelectedCerts.Count > 0  Then 'if err.number = 0 then
			    Set Certificat = oSelectedCerts (1)
				'Set Certificat = oCerts(1)
		    else
			    msgbox "Trebuie selectat un certificat pentru a putea continua."
			    exit function
		    end if

	    End If 
	    
	    GetCert = Certificat
	    
	end if
end function
</script>
<P>
	<TABLE id="Table1" border="0" cellSpacing="0" cellPadding="0" width="300">
		<TR>
			<TD></TD>
		</TR>
		<TR>
			<TD><INPUT id="txtBody" runat="server"></TD>
		</TR>
		<TR>
			<TD><INPUT style="WIDTH: 248px" id="btnTrimiteMail" class="ButtonStyle" onmouseover="MouseOverButton(this)"
					onmouseout="MouseOutButton(this)" onclick="TrimiteMail()" value="Trimite fluturasi"
					type="button" name="btnTrimiteMail" runat="server"></TD>
		<TR>
			<TD><asp:label style="Z-INDEX: 0" id="lblMesaj" runat="server" CssClass="AlertRedBold" Width="528px"></asp:label></TD>
		</TR>
	</TABLE>
	<script language="javascript" src="../js/jsCode.js"></script>
</P>
