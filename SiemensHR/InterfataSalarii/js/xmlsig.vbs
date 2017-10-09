'--------------------------------------------
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
'-----------------------------------------------------------
'initializari capicom
'----------------------------------
'functia ce realizeaza semnatura
Dim retNumeSigner
Dim retEmailSigner
function ComputeSignature(strData)
	MsgBox "compute signature"
	GetCert()
	'se creaza fisierul xml in care se creaza semnatura
    set xmlSign = CreateObject("Microsoft.XMLDOM")
    xmlSign.async = false
    xmlSign.load("xmlSign.xml")
    
    'se incarca fisirul xml in care sunt salvate datele
    set xmlInfo = CreateObject("Microsoft.XMLDOM")
    xmlInfo.async = false
    
    xmlInfo.loadXML(strData)
    
    Dim oldData
    Dim coSigner
    
    for each nod in xmlInfo.documentElement.childNodes           
        if (nod.nodename = "InformatiaVeche") then 
            
            oldData = nod.text
            if (oldData = "") then coSigner = false
                              else coSigner = true
        end if
    next
    
    for each nod in xmlSign.documentElement.childNodes
        if (nod.nodename = "ds:SignedInfo") then
            for each ref in nod.childNodes
                if (ref.nodename = "ds:Reference") then ref.lastChild.text = HashDataElement(xmlInfo.xml)
            next
        end if    
        if (nod.nodename = "ds:SignatureValue") then nod.text = SignElement(xmlInfo.xml)
        if (nod.nodename = "ds:KeyInfo") then
                if (coSigner = false) then
                    for each xdata in nod.firstChild.childNodes
                        if (xdata.nodename = "ds:X509SubjectName") then xdata.text = Certificat.GetInfo( CAPICOM_CERT_INFO_SUBJECT_SIMPLE_NAME )
                        if (xdata.nodename = "ds:X509Certificate") then xdata.text = getCertRawData(Certificat)
                    next
                else
                Verifica(oldData)
                    for each xdata in nod.firstChild.childNodes
                        if (xdata.nodename = "ds:X509SubjectName") then xdata.text = oldCertificat.GetInfo( CAPICOM_CERT_INFO_SUBJECT_SIMPLE_NAME )
                        if (xdata.nodename = "ds:X509Certificate") then xdata.text = getCertRawData(oldCertificat)
                    next
                    for each xdata in nod.lastChild.childNodes
                        if (xdata.nodename = "ds:X509SubjectName") then xdata.text = Certificat.GetInfo( CAPICOM_CERT_INFO_SUBJECT_SIMPLE_NAME )
                        if (xdata.nodename = "ds:X509Certificate") then xdata.text = getCertRawData(Certificat)
                    next
                end if
        end if
    next

    ComputeSignature = xmlSign.xml
    
end function
'-----------------------------------------
'Valoarea de digestie a elementului semnat
function HashDataElement(hashData)

    Dim getHashedData
    Set getHashedData = CreateObject("CAPICOM.HashedData")
    getHashedData.Algorithm = CAPICOM_HASH_ALGORITHM_SHA1
    getHashedData.Hash hashData
    
    HashDataElement = getHashedData.Value

end function
'---------------------------------------------
'Semnarea informatiei - data.Sign(<signinfo>)
function SignElement(theString)

    Set oSigner = CreateObject("CAPICOM.Signer")
    oSigner.Certificate = Certificat
    
    Set oSignedData = CreateObject("CAPICOM.SignedData")
    oSignedData.Content = theString
    'se returneaza valoarea semnata
    signData = oSignedData.Sign(oSigner)
    
    SignElement = signData

end function
'----------------------------------------
'verifica informatia
Dim oldCertificat
function Verifica(theString)

    Dim oSignedData
	Set oSignedData = CreateObject("CAPICOM.SignedData")
    oSignedData.Verify(theString)
    for each cert in oSignedData.Certificates
        Set oldCertificat = cert
    next

end function
'----------------------------------------
'sematura prin encryptie
function EnvelopedElement(theString)

    Set oEnevelopData = CreateObject("CAPICOM.EnvelopedData")
    oEnevelopData.Content = theString
    EnvelopedElement = oEnevelopData.Encrypt(CAPICOM_ENCODE_BASE64)

end function
'----------------------------------------
'export certificate
'-----------------------------------------
function getCertRawData(cert)

    getCertRawData = cert.Export(CAPICOM_ENCODE_BASE64)
    
end function
'---------------------------------------
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
'------------------------