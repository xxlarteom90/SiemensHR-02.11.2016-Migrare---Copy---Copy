<%@ Register TagPrefix="uc1" TagName="PageHeader" Src="../PageHeader.ascx" %>
<%@ Page language="c#" Codebehind="AdminPrimulAngajator.aspx.cs" AutoEventWireup="false" Inherits="SiemensHR.Administrare.AdminPrimulAngajator" %>
<HEAD>
	<TITLE>HR Toolkit</TITLE>
</HEAD>
<LINK href="../StyleHR.css" type="text/css" rel="stylesheet">
<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
<meta content="C#" name="CODE_LANGUAGE">
<meta content="JavaScript" name="vs_defaultClientScript">
<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
<script language="javascript" src="../js/jsCode.js"></script>
<script>var images_path = "../images/";</script>
<script>
var arTabsAngajator = new Array('tableDateAngajator', 'tableConturi', 'tableAdresa', 'tableDomeniiDeActivitate', 'tablePunctLucru', 'tableReprezLegal');
var formObj;

function SelectTabAngajator(index)
	{
		for(i=0; i<arTabsAngajator.length; i++)
		{
			if (i==index)
			{
				eval(arTabsAngajator[i] + ".style.display=''");
				eval("tab"+ (i+1)+ ".className='tabActive'");
				Form1.btnNext.style.display = "";
				Form1.btnPrev.style.display = "";
				if (i==0)
					Form1.btnPrev.style.display = "none";
				if (i==(arTabsAngajator.length-1))
					Form1.btnNext.style.display = "none";
					
			}
			else
			{
				eval("tab"+ (i+1) + ".className='tab'");
				eval("tab"+ (i+1) + ".style.backgroundColor='#7b8fc2'");
				eval(arTabsAngajator[i] + ".style.display='none'");
			}
		}
	}
	
	function NextTabAngajator( dir )
	{
		for(var i=0; i<arTabsAngajator.length; i++)
		{
			eval("className = tab"+ (i+1) + ".className;");
			if (className=='tabActive')
			{
				if (dir=="next")
				{				
					eval("tab" + (i+2) + ".style.backgroundColor='#20b2aa'");				
					eval("tab" + (i+2) + ".click()");					
					if (i==(arTabsAngajator.length-2))
						Form1.btnNext.style.display = "none";
					Form1.btnPrev.style.display = "";
					
				}
				if (dir=="back")
				{
					eval("tab" + i + ".style.backgroundColor='#20b2aa'");				
					eval("tab" + i + ".click()");

					Form1.btnNext.style.display = "";
					if (i==1)
						Form1.btnPrev.style.display = "none";
				}				
				break;
			}
		}
	}

function sp3FormIDfix()
{
document.forms[0].id=ctrlID + "_Form1";
}

//Oprescu Claudia
//Functia goleste controalele validatorilor pentru a nu se afisa mesajele de validare
function GolesteValidatori()
{
	document.getElementById(requiredDenumire).innerText = '';
	document.getElementById(requiredFiliala).innerText = '';
	document.getElementById(requiredNrInreg).innerText = '';
	document.getElementById(requiredTelefon).innerText = '';
	document.getElementById(regularTelefon).innerText = '';
	document.getElementById(regularFax).innerText = '';
	document.getElementById(regularEmail).innerText = '';
	document.getElementById(vldZiuaLichidarii).innerText = '';
	document.getElementById(requiredConturi).innerText = '';
	document.getElementById(requiredDJudet).innerText = '';
	document.getElementById(requiredDLocalitate).innerText = '';
	document.getElementById(requiredDStrada).innerText = '';
	document.getElementById(requiredDNumar).innerText = '';
	document.getElementById(requiredDCodPostal).innerText = '';
	document.getElementById(regularDenumire).innerText = '';
	document.getElementById(regularCUI).innerText = '';
	document.getElementById(regularNrInreg).innerText = '';
	document.getElementById(regularAdresaWeb).innerText = '';
	document.getElementById(regularSector).innerText = '';
	document.getElementById(regularLocalitate).innerText = '';
	document.getElementById(regularStrada).innerText = '';
	document.getElementById(regularNumar).innerText = '';
	document.getElementById(regularDCodPostal).innerText = '';
	document.getElementById(regularDBloc).innerText = '';
	document.getElementById(regularDScara).innerText = '';
	document.getElementById(regularDEtaj).innerText = '';
	document.getElementById(regularDApartament).innerText = '';
	document.getElementById(requiredDomenii).innerText = '';
	document.getElementById(requiredPuncteLucru).innerText = '';
		//Lungu Andreea 08.04.2008
	document.getElementById(regularNrInregItm).innerText = '';
	document.getElementById(requiredNrInregItm).innerText = '';
}

//Cristina Muntean
function ChangeDomDeActPp(id)
{
	document.getElementById(txtHiddenDomDeActPpIDClient).innerText = id;
}
function ChangeDomDeActList()
{
	//lista de domenii de activitate ale angajatorului
	var domeniiAngajatorList = document.getElementById( lstBoxDomeniiAngajatorClient );
	document.getElementById(txtHiddenDomDeActListIDClient).innerText="";
	if(domeniiAngajatorList.length!=0)
	{
		var textDomeniiList="";
		for(i=0;i<domeniiAngajatorList.length-1;i++)
		{	
			textDomeniiList+=domeniiAngajatorList.options[i].value+",";
		}
		textDomeniiList+=domeniiAngajatorList.options[domeniiAngajatorList.length-1].value;
		document.getElementById(txtHiddenDomDeActListIDClient).innerText = textDomeniiList;
	}
	
}
//este repopulat dropdownlist-ul cu domeniile angajatorului
function FillDrpDomDeActPrincipal()
{
	//lista de domenii de activitate ale angajatorului
	var domeniiAngajatorList = document.getElementById( lstBoxDomeniiAngajatorClient );
	var domeniuPrincipalList = document.getElementById( drpDomDeActPrincipalClient );
	domeniuPrincipalList.options.length=0;
	//adauga toate domeniile din lista de domenii disponibile in lista de domenii ale angajatorului
	for(i=0;i<domeniiAngajatorList.options.length;i++)
	{
		var selText =  domeniiAngajatorList.options[i].text;
		var selValue = domeniiAngajatorList.options[i].value;
		var o = new Option();
		o.text = selText;
		o.value = selValue;
		domeniuPrincipalList.add( o );
	}
	//textbox-ul ascuns care retine id-ul domeniului de activitate principal primeste valoare primului item 
	//adaugat in dropdownlist->domeniuPrincipalList
	if(domeniuPrincipalList.options.length > 0)
		document.getElementById(txtHiddenDomDeActPpIDClient).innerText = domeniuPrincipalList.options[0].value;
	else
		document.getElementById(txtHiddenDomDeActPpIDClient).innerText = "";
	
}
//Cristina Muntean
//sterge domeniul de activitate al angajatorului selectat si in adauga in lista de domenii disponibile
function DeleteDomDeActSelectat()
{
	
	//lista de domenii de activitate
	var domeniiList = document.getElementById( lstBoxDomeniiClient );
	//lista de domenii de activitate ale angajatorului
	var domeniiAngajatorList = document.getElementById( lstBoxDomeniiAngajatorClient );
	if(domeniiAngajatorList.selectedIndex>=0)
	{
		//este adaugat domeniul selectat in lista de domenii de activitate disponibile
		var selText =  domeniiAngajatorList.options[domeniiAngajatorList.selectedIndex].text;
		var selValue = domeniiAngajatorList.options[domeniiAngajatorList.selectedIndex].value;
		var opt = new Option(selText, selValue);
		domeniiList.add( opt);
		//este sters domeniul de activitate din lista domeniilor de activitate ale angajatorului
		domeniiAngajatorList.remove( domeniiAngajatorList.selectedIndex );
		//adauga id-ul in textbox-ul ascuns in care retinem toate id-urile domeniilor din lista de domenii 
		//de activitate ale angajatorului
		ChangeDomDeActList();
		FillDrpDomDeActPrincipal();
	}
	else
		alert("Trebuie sa selectati un domeniu de activitate din lista de domenii ale angajatorului!");
}

//sterge toate domeniile din lista de domenii ale angajatorului si le adauga in lista de domenii disponibile
function DeleteAllDomDeAct()
{
	
	//lista de domenii de activitate
	var domeniiList = document.getElementById( lstBoxDomeniiClient );
	//lista de domenii de activitate ale angajatorului
	var domeniiAngajatorList = document.getElementById( lstBoxDomeniiAngajatorClient );
	if(domeniiAngajatorList.options.length!=0)
	{
		//sunt adaugate domeniile de activitate ale angajatorului la lista de domenii disponibile
		//adauga toate domeniile din lista de domenii disponibile in lista de domenii ale angajatorului
		for(i=0;i<domeniiAngajatorList.options.length;i++)
		{
			var selText =  domeniiAngajatorList.options[i].text;
			var selValue = domeniiAngajatorList.options[i].value;
			var opt = new Option(selText, selValue);
			domeniiList.add(opt);
		}
		//sterge toate domeniile de activitate ale angajatorului
		domeniiAngajatorList.options.length=0;
		//este facut refresh-ul dropdownlist-ului din care se alege domeniul de activitate principal
		FillDrpDomDeActPrincipal();
		//textbox-ul in care retinem lista id-urilor domniilor de act ale angajatorului este golit
		document.getElementById(txtHiddenDomDeActListIDClient).innerText ="";
	}
	else
		alert("Nu exista nici un domeniu in lista de domenii de activitate ale angajatorului!");
}

//Cristina Muntean
//adauga domeniul selectat din lista de domenii disponibile in lista de domenii ale angajatorului si apoi  il
//sterge din lista de domenii disponibile
function AddDomDeActSelectat()
{
	//lista de domenii de activitate
	var domeniiList = document.getElementById( lstBoxDomeniiClient );
	//lista de domenii de activitate ale angajatorului
	var domeniiAngajatorList = document.getElementById( lstBoxDomeniiAngajatorClient );
	if(domeniiList.selectedIndex>=0)
	{
		//este adaugat domeniul selectat din lista de domenii disponibile in lista de domenii ale angajatorului
		var selText =  domeniiList.options[domeniiList.selectedIndex].text;
		var selValue = domeniiList.options[domeniiList.selectedIndex].value;
		var opt = new Option(selText, selValue);
		domeniiAngajatorList.add(opt);
		//domeniiAngajatorList.add(opt,domeniiAngajatorList.options.length-1);
		//sau
		//domeniiAngajatorList.options[domeniiAngajatorList.options.length] = opt;
		//este sters domeniul selectat din lista de domenii disponibile
		domeniiList.remove(domeniiList.selectedIndex);
		FillDrpDomDeActPrincipal();
		ChangeDomDeActList();
	}
	else
		alert("Trebuie sa selectati un domeniu din lista de domenii disponibile!");
}
//adauga toate domeniile din lista de domenii disponibile in lista de domenii ale angajatorului si apoi
//sterge toate domeniile din lista de domenii disponibile
function AddAllDomDeAct()
{
	
	//lista de domenii de activitate
	var domeniiList = document.getElementById( lstBoxDomeniiClient );
	//lista de domenii de activitate ale angajatorului
	var domeniiAngajatorList = document.getElementById( lstBoxDomeniiAngajatorClient );
	if(domeniiList.options.length>0)
	{
		//adauga toate domeniile din lista de domenii disponibile in lista de domenii ale angajatorului
		for(i=0;i<domeniiList.options.length;i++)
		{
			var selText =  domeniiList.options[i].text;	
			var selValue = domeniiList.options[i].value;
			var opt = new Option(selText, selValue);
			domeniiAngajatorList.add(opt);
			//domeniiAngajatorList.add(opt,i);
			//sau
			//domeniiAngajatorList.options[i] = opt;
			//adauga id-ul in textbox-ul ascuns in care retinem toate id-urile domeniilor din lista de domenii 
			//de activitate ale angajatorului
		}
		//sterge toate domeniile din lista de domenii disponibile
		domeniiList.options.length=0;
		FillDrpDomDeActPrincipal();
		ChangeDomDeActList();
	}
	
	else
		alert("Nu exista nici un domeniu in lista de domenii de activitate disponibile!");
}
//este apelata in cazul in judetul selectat din dropdown-ul pentru judete a fost schimbat
function lstDJudetSectorOnChange( judetSector )
{
	document.getElementById( txtJudetSectorHiddenClient ).value = judetSector.value;
}
//in cazul in care este selectata o alta tara este apelata acesta functie
function lstDTaraOnChange( tara)
{
	document.getElementById( txtTaraHiddenClient ).value = tara.value;
	//sunt sterse toate judetele din dropdownlist-ul corespunzator judetelor
	DeleteAllLstDJudetSector();	
	//este completat dropdownlist-ul corespunzator judetelor cu judetele tarii trimise ca parametru(tara.value)
	FillLstDJudetSector(tara.value)
}
//este completat dropdownlist-ul corespunzator judetelor cu judetele tarii trimise ca parametru(tara)
function FillLstDJudetSector( tara)
{
	var i = 0;
	while( i<tari[ 1 ].length)
	{
		if( tara==tari[ 1 ][ i ] )
		{
			FillLstDJudet( i );
		}
		i++;
	}
}
//sterge toate judetele din dropdownlist-ul corespunzator judetelor
function DeleteAllLstDJudetSector()
{
	var judeteCombo = document.getElementById( lstDJudetClient );
	judeteCombo.length=0;
}
//este completat dropdownlist-ul corespunzator judetelor cu judetele corespunzatoare indexului
//tarii trimise ca parametru
function FillLstDJudet( index )
{
    //dropdownlist-ul corespunzator judetelor
	var judCombo = document.getElementById( lstDJudetClient );
	//este copletat dropdownlist-ul
	if ( judeteText[index][0] != null)
	{
		for( i=0; i<judeteText[ index ].length; i++ )
		{
			var o = new Option();
			o.text = judeteText[ index ][ i ];
			o.value = judeteValue[ index ][ i ];
			//este adaugat judetul
			judCombo.add( o, i );
		}
		document.getElementById( txtJudetSectorHiddenClient ).value = judeteValue[index][0];
	}
}



// Cristina Muntean
// Sterge contul bancar selectat selectat.
function DeleteContBancar()
{
	var lstConturiBancareClient = document.getElementById( lstConturiBancareClientID );
	var conturiBancareNew = "";
	var sirConturiBancare = new Array();
	
	sirConturiBancare = document.getElementById( txtListaConturiHiddenClientID ).value.split(";");
		
	if (lstConturiBancareClient.selectedIndex >= 0)
	{
		for (var i=0; i<sirConturiBancare.length; i++)
		{
			if ( i == lstConturiBancareClient.selectedIndex )
			{
				sirConturiBancare.splice(i,1);
			}
		}
		
		document.getElementById( txtListaConturiHiddenClientID ).value = sirConturiBancare.join(";");
				
		//este sters domeniul de activitate din lista domeniilor de activitate ale angajatorului
		lstConturiBancareClient.remove( lstConturiBancareClient.selectedIndex );
	}
	else
		alert("Trebuie sa selectati un cont bancar!");
}

//Oprescu Claudia
//sterge contul bancar selectat cu confirmarea utilizatorului
function DeleteContBancarConfirmare()
{
	if (CheckDelete('Doriti sa stergeti acest cont?'))
	{
		DeleteContBancar();
	}
}

// Cristina Muntean
// Verifica daca a fost introdus contul intr-un format IBAN corect. 
function ValidareContFormatIBAN()
{
	var returnValue = true; 
	var txtNumarContIBANClient = document.getElementById ( txtNumarContIBANClientID );
	
	if ( txtNumarContIBANClient.value == "" )
	{
		returnValue = false;
	}
		
	return returnValue;
}

// Cristina Muntean
// Verifica daca a fost introdus contul intr-un format vechi corect. 
function ValidareContFormatVechi()
{
	var returnValue = true; 
	var txtNumarContVechiClient = document.getElementById( txtNumarContVechiClientID );
	
	if (txtNumarContVechiClient.value == "") 
	{
		returnValue = false;
	}
		
	return returnValue;
}

/*	Autor:			Cristina Muntean
*	Descriere:		Se verifica daca au fost completate toate datele despre un cont.
*	
*	Modificat:		Lungu Andreea
*	Data:			27.07.2007
*	Descriere:		Se verifica datele introduse pentru un cont astfel incat sa nu se poata introduce caractere invalide.
*/
function VerificareDateContBancar()
{
	var returnValue = true;
	var checked = false;
	var drpBanciClient = document.getElementById( drpBanciClientID );
	var txtNumarContIBANClient = document.getElementById ( txtNumarContIBANClientID );	
	var txtNumarContVechiClient = document.getElementById( txtNumarContVechiClientID );
	var drpMonedaClient = document.getElementById( drpMonedaClientID );
	var chkActivClient = document.getElementById( chkActivClientID );
	var sirContBancar = new Array();
	var sirConturiBancare = new Array();
	var mesaj=""
	
	if ( ( drpBanciClient.length == 0 ) || ( !ValidareContFormatVechi() ) || (!ValidareContFormatIBAN()) )
	{
		mesaj += "Pentru a adauga un cont bancar trebuie completate corect toate datele!";
		returnValue = false;
	}
	
	if ( !Validare(txtNumarContIBANClient.value)||!Validare(txtNumarContVechiClient.value) )
	{
		mesaj += "\r\n" + "Numerele de cont nu pot contine caractere invalide : <>()';\"\\";
		returnValue = false;
	}

	if ( document.getElementById( txtListaConturiHiddenClientID ).value != "" )
	{
		sirConturiBancare = document.getElementById( txtListaConturiHiddenClientID ).value.split(";");
	
		for (var i=0; i<sirConturiBancare.length; i++)
		{
			sirContBancar = sirConturiBancare[i].split(",");
						
			if ( ( sirContBancar[3] == drpMonedaClient.options[drpMonedaClient.selectedIndex].value ) )
			{
				if ( ( sirContBancar[0] == drpBanciClient.options[drpBanciClient.selectedIndex].value ) &&
				     ( sirContBancar[1] == txtNumarContVechiClient.value) &&
				     ( sirContBancar[2] == txtNumarContIBANClient.value) )
				{
					mesaj += "\r\n" + "Acest cont bancar a fost deja introdus!";
					checked = true;
					returnValue = false;
					i = sirConturiBancare.length;
				}
				if (( sirContBancar[4] == "true" ) && ( chkActivClient.checked ) && (!checked) )
				{
					mesaj += "\r\n" + "Mai este un cont activ deschis in " + drpMonedaClient.options[drpMonedaClient.selectedIndex].value+"!";
					returnValue = false;
					i = sirConturiBancare.length;
				}
			}
		}	
	}
	
	if (!returnValue)
	{
		alert(mesaj);
	}
	
	return returnValue;
}

// Cristina Muntean
// Adauga in lista un cont bancar.
function AddContBancar()
{
	if ( VerificareDateContBancar() )
	{
	
		var drpBanciClient = document.getElementById( drpBanciClientID );
		var txtNumarContVechiClient = document.getElementById( txtNumarContVechiClientID );
		var txtNumarContIBANClient = document.getElementById ( txtNumarContIBANClientID );
		var drpMonedaClient = document.getElementById( drpMonedaClientID );
		var chkActivClient = document.getElementById( chkActivClientID );
		var lstConturiBancareClient = document.getElementById( lstConturiBancareClientID );
		
		// Valoarea care va fi adaugata in controlul ascuns.
		var contBancarValue = drpBanciClient.options[drpBanciClient.selectedIndex].value + 
			"," + txtNumarContVechiClient.value + "," + txtNumarContIBANClient.value +
			"," + drpMonedaClient.options[drpMonedaClient.selectedIndex].value +
			"," + chkActivClient.checked;
	
		// Valoarea care va fi adaugata in lista conturilor bancare.
		var contBancarText = drpBanciClient.options[drpBanciClient.selectedIndex].text + 
			", " + txtNumarContVechiClient.value + ", " + txtNumarContIBANClient.value +
			", " + drpMonedaClient.options[drpMonedaClient.selectedIndex].value;
	
		if ( chkActivClient.checked )
		{
			contBancarText = contBancarText + ", " + "DA";
		}
		else
		{ 
			contBancarText = contBancarText + ", " + "NU";
		}
			
		// Este adaugat contul bancar in lista.
		var selText =  contBancarText;
		var selValue = lstConturiBancareClient.options.length + 1;
		var optionConturi = new Option(selText, selValue);
		lstConturiBancareClient.add(optionConturi);	
		
		// Este setata valoarea controlului ascuns.
		if (document.getElementById( txtListaConturiHiddenClientID ).value == "")
		{
			document.getElementById( txtListaConturiHiddenClientID ).value = contBancarValue;
		}
		else
		{
			document.getElementById( txtListaConturiHiddenClientID ).value =
				document.getElementById( txtListaConturiHiddenClientID ).value + ";" + contBancarValue;
		}
	}	
}

/*	Autor:			Oprescu Claudia
*	Descriere:		Verifica daca se poate face actualizarea contului selectat
*					Un cont nu se poate actualiza daca mai exista un cont activ cu aceeasi moneda in afara de el
*	Modificat:		Lungu Andreea
*	Data:			27.07.2007
*	Descriere:		Se verifica datele introduse pentru un cont astfel incat sa nu se poata introduce caractere invalide.
*/
function VerificareDateContBancarUpdate(index)
{
	var returnValue = true;
	var checked = false;
	var drpBanciClient = document.getElementById( drpBanciClientID );
	var txtNumarContIBANClient = document.getElementById ( txtNumarContIBANClientID );	
	var txtNumarContVechiClient = document.getElementById( txtNumarContVechiClientID );
	var drpMonedaClient = document.getElementById( drpMonedaClientID );
	var chkActivClient = document.getElementById( chkActivClientID );
	var sirContBancar = new Array();
	var sirConturiBancare = new Array();
	var mesaj = "";
	
	if ( ( drpBanciClient.length == 0 ) || ( !ValidareContFormatVechi() ) || (!ValidareContFormatIBAN()) )
	{
		mesaj += "Pentru a modifica un cont bancar trebuie completate corect toate datele!";
		returnValue = false;
	}
	
	if ( !Validare(txtNumarContIBANClient.value)||!Validare(txtNumarContVechiClient.value) )
	{
		mesaj += "\r\n" + "Numerele de cont nu pot contine caractere invalide: <>()';\"\\";
		returnValue = false;
	}

	if ( document.getElementById( txtListaConturiHiddenClientID ).value != "" )
	{
		sirConturiBancare = document.getElementById( txtListaConturiHiddenClientID ).value.split(";");
		
		for (var i=0; i<sirConturiBancare.length; i++)
		{
			if (i != index)
			{
				sirContBancar = sirConturiBancare[i].split(",");
							
				if ( ( sirContBancar[3] == drpMonedaClient.options[drpMonedaClient.selectedIndex].value ) )
				{
					if ( ( sirContBancar[0] == drpBanciClient.options[drpBanciClient.selectedIndex].value ) &&
						( sirContBancar[1] == txtNumarContVechiClient.value) &&
						( sirContBancar[2] == txtNumarContIBANClient.value) )
					{
						mesaj += "\r\n" + "Acest cont bancar a fost deja introdus!";
						checked = true;
						returnValue = false;
						i = sirConturiBancare.length;
					}
					if (( sirContBancar[4] == "true" ) && ( chkActivClient.checked ) && (!checked) )
					{
						mesaj += "\r\n" + "Mai este un cont activ deschis in " + drpMonedaClient.options[drpMonedaClient.selectedIndex].value+"!";
						returnValue = false;
						i = sirConturiBancare.length;
					}
				}
			}
		}
	}
	
	if ( !returnValue )
	{
		alert(mesaj);
	}
	
	return returnValue;
}

// Cristina Muntean
// Se modifica datele despre contul bancar selectat.
function UpdateContBancar()
{
	var lstConturiBancareClient = document.getElementById( lstConturiBancareClientID );
	
	sirConturiBancare = document.getElementById( txtListaConturiHiddenClientID ).value.split(";");
	
	if (lstConturiBancareClient.selectedIndex >= 0)
	{
		//se verifica sa nu mai existe un alt cont activ cu aceeasi moneda in afara de cel selectat
		if ( VerificareDateContBancarUpdate(lstConturiBancareClient.selectedIndex) )
		{
			// Este sters contul bancar selectat.
			DeleteContBancar();
			// Este adaugat contul bancar cu noile date.
			AddContBancar();
		}
	}
	else
	{
		alert("Trebuie sa selectati un cont bancar!");
	}
}

// Cristina Muntean
// In cazul in care este selectat un cont bancar sunt completate controalele.
function FillContBancarControls()
{
	var drpBanciClient = document.getElementById( drpBanciClientID );
	var txtNumarContVechiClient = document.getElementById( txtNumarContVechiClientID );
	var txtNumarContIBANClient = document.getElementById ( txtNumarContIBANClientID );
	var drpMonedaClient = document.getElementById( drpMonedaClientID );
	var chkActivClient = document.getElementById( chkActivClientID );
	var lstConturiBancareClient = document.getElementById( lstConturiBancareClientID );
	var sirDateConturi = new Array();
	var sirDateCont = new Array();
	var index = lstConturiBancareClient.selectedIndex;
	
	sirDateConturi = document.getElementById( txtListaConturiHiddenClientID ).value.split(";")
	sirDateCont = sirDateConturi[index].split(",");
	
	for(index = 0; index < drpBanciClient.length; index++)
    {
		if (drpBanciClient[index].value == sirDateCont[0])
		{
               drpBanciClient.selectedIndex = index;
               index = drpBanciClient.length;
        }
    }    

	txtNumarContVechiClient.value = sirDateCont[1];
	txtNumarContIBANClient.value = sirDateCont[2];
	
	for(index = 0; index < drpMonedaClient.length; index++)
    {
		if (drpMonedaClient[index].value == sirDateCont[3])
		{
               drpMonedaClient.selectedIndex = index;
               index = drpMonedaClient.length;
        }
    }    
	
	if (sirDateCont[4] == "true")
	{
		chkActivClient.checked = true;
	}
	else
	{
		chkActivClient.checked = false;
	}
}

//Oprescu Claudia
//adauga punctul de lucru introdus in lista de centre de lucru ale angajatorului
function AddPunctLucru()
{
	var txtNumePunctLucruClient = document.getElementById( txtNumePunctLucru );
	var lstPunctLucruClient = document.getElementById( lstPunctLucru );
	var drpCaseAsig = document.getElementById(drpCaseDeAsigClientID);
	
	if(txtNumePunctLucruClient.value == '')
	{
		alert('Nu ati introdus nici o denumire pentru punctul de lucru!');
	}
	else
	{
		if (!Validare(txtNumePunctLucruClient.value))
		{
			alert("Denumirea punctului de lucru nu poate contine caractere invalide: <>()';\"\\");
		}
		else
		{
			for(i=0;i<lstPunctLucruClient.options.length;i++)
			{
				var sir = lstPunctLucruClient.options[i].text.split(',');
				//if (lstPunctLucruClient.options[i].text == txtNumePunctLucruClient.value + ',' + drpCaseAsig.options[drpCaseAsig.selectedIndex].text)
				if (sir[0] == txtNumePunctLucruClient.value)
				{
					alert('Acest punct de lucru a fost deja adaugat in lista!');	
					return;
				}
			}		
			var opt = new Option(txtNumePunctLucruClient.value + ',' + drpCaseAsig.options[drpCaseAsig.selectedIndex].text);
			txtNumePunctLucruClient.value = '';
			lstPunctLucruClient.add(opt);
			//ChangePunctLucruList();
			ChangePunctLucruListAdauga();
		}
	}
}

//Oprescu Claudia
//sterge un punct de lucru din lista cu campuri de lucru disponibile
function DeletePunctLucru()
{
	var lstPunctLucruClient = document.getElementById( lstPunctLucru );
	var txtNumePunctLucruClient = document.getElementById( txtNumePunctLucru );

	if (lstPunctLucruClient.selectedIndex < 0)
	{
		alert("Trebuie sa selectati un punct de lucru din lista!");
	}
	else
	{
		lstPunctLucruClient.remove( lstPunctLucruClient.selectedIndex );
		//ChangePunctLucruList();
		ChangePunctLucruListSterge();
	}
}

//Oprescu Claudia
//sterge toate punctele de lucru din lista cu Puncturi de lucru disponibile
function DeleteAllPunctLucru()
{
	var lstPunctLucruClient = document.getElementById( lstPunctLucru );
	var txtNumePunctLucruClient = document.getElementById( txtNumePunctLucru );

	if(lstPunctLucruClient.options.length == 0)
	{
		alert("Nu exista nici un punct de lucru in lista cu puncte de lucru disponibile!");
	}
	else
	{
		txtNumePunctLucruClient.value = '';
		lstPunctLucruClient.options.length=0;
		//ChangePunctLucruList();
		ChangePunctLucruListSterge();
	}		
}

//Oprescu Claudia
//se actualizeaza punct care retine lista cu Puncturi de lucru
function ChangePunctLucruList()
{
	var lstPunctLucruClient = document.getElementById( lstPunctLucru );
	document.getElementById(txtHiddenPunctLucru).innerText="";
	
	if(lstPunctLucruClient.length!=0)
	{
		var textPunctLucruList="";
		for(i=0;i<lstPunctLucruClient.length-1;i++)
		{	
			textPunctLucruList+=lstPunctLucruClient.options[i].text+",";
		}
		textPunctLucruList+=lstPunctLucruClient.options[lstPunctLucruClient.length-1].text;
		document.getElementById(txtHiddenPunctLucru).innerText = textPunctLucruList;
	}	
}

//Oprescu Claudia
//se actualizeaza campul care retine lista cu puncte de lucru
//Lungu Andreea 26.05.2008 - s-au facut modificari deoarece pentru un anumit punct de lucru s-a adaugat  o casa de asigurari implicita
function ChangePunctLucruListSterge()
{
	var lstPunctLucruClient = document.getElementById( lstPunctLucru );
	var textPunctLucruList="";
	
	if(lstPunctLucruClient.length!=0)
	{
		sirPunctLucru = document.getElementById( txtHiddenPunctLucru ).value.split(";");
		document.getElementById(txtHiddenPunctLucru).innerText="";
		for (i=0; i<sirPunctLucru.length-1; i++)
		{	
			PunctLucru = sirPunctLucru[i].split(",");
			for(j=0;j<lstPunctLucruClient.length-1;j++)
			{
				if (lstPunctLucruClient.options[j].text == PunctLucru[1]+","+PunctLucru[2])
				{
					//textPunctLucruList+=lstPunctLucruClient.options[j].value + "," + lstPunctLucruClient.options[j].text+"," + PunctLucru[2] + ";";
					textPunctLucruList += PunctLucru[0]+ "," + lstPunctLucruClient.options[j].text + ";";
				}
			}
			if (lstPunctLucruClient.options[lstPunctLucruClient.length-1].text == PunctLucru[1]+","+PunctLucru[2])
			{
				//textPunctLucruList+=lstPunctLucruClient.options[lstPunctLucruClient.length-1].value + "," + lstPunctLucruClient.options[lstPunctLucruClient.length-1].text+"," + PunctLucru[2] ;
				textPunctLucruList+=PunctLucru[0]+ "," + lstPunctLucruClient.options[lstPunctLucruClient.length-1].text;
			}
		}
		PunctLucru = sirPunctLucru[sirPunctLucru.length-1].split(",");
		for(j=0;j<lstPunctLucruClient.length-1;j++)
		{
			if (lstPunctLucruClient.options[j].text == PunctLucru[1]+","+PunctLucru[2])
			{
				//textPunctLucruList+=lstPunctLucruClient.options[j].value + "," + lstPunctLucruClient.options[j].text+"," + PunctLucru[2] + ";";
				textPunctLucruList += PunctLucru[0]+ "," + lstPunctLucruClient.options[j].text + ";";
			}
		}
		if (lstPunctLucruClient.options[lstPunctLucruClient.length-1].text == PunctLucru[1]+","+PunctLucru[2])
		{
			//textPunctLucruList+=lstPunctLucruClient.options[lstPunctLucruClient.length-1].value + "," + lstPunctLucruClient.options[lstPunctLucruClient.length-1].text+"," + PunctLucru[2];
			textPunctLucruList+=PunctLucru[0]+ "," + lstPunctLucruClient.options[lstPunctLucruClient.length-1].text;
		}
	}
	document.getElementById(txtHiddenPunctLucru).innerText = textPunctLucruList;	
}

//Oprescu Claudia
//se actualizeaza campul care retine lista cu puncte de lucru
//Lungu Andreea 28.05.2008 - s-au facut modificari deoarece pentru un anumit punct de lucru s-a adaugat  o casa de asigurari implicita
function ChangePunctLucruListAdauga()
{
	var lstPunctLucruClient = document.getElementById( lstPunctLucru );
	var drpCaseAsig = document.getElementById(drpCaseDeAsigClientID);
	
	if(lstPunctLucruClient.length!=0)
	{
		if (document.getElementById(txtHiddenPunctLucru).value == "")
			document.getElementById(txtHiddenPunctLucru).innerText = drpCaseAsig.options[drpCaseAsig.selectedIndex].value + "," + lstPunctLucruClient.options[lstPunctLucruClient.length-1].text;	
		else
			document.getElementById(txtHiddenPunctLucru).innerText = document.getElementById(txtHiddenPunctLucru).value + ";" + drpCaseAsig.options[drpCaseAsig.selectedIndex].value + ","  + lstPunctLucruClient.options[lstPunctLucruClient.length-1].text;	
	}
}

//Oprescu Claudia
//pentru butonul de stergere
function CheckDelete( text )
{
	if (confirm(text))
		return true;
	else
		return false;
}

function lstLunaOnChange()
{
	document.getElementById(txtHiddenLuna).value = document.getElementById(lstLuna).value;
}

function lstAnOnChange()
{
	document.getElementById(txtHiddenAn).value = document.getElementById(lstAn).value;
}

//Autor:		Lungu Andreea
//Data:			26.07.2007
//Descriere:	Verifica daca punctul de lucru pe care vrem sa-l introducem in lista de centre de lucru ale angajatorului contine caractere invalide
function Validare(cuv)
{
	var re = new RegExp("^[^>|(|)|<|'|\"|\\\\|\\n|;]*$");
	if (cuv.match(re)==null)
	{
		return false;
	}
	else
	{
		return true;
	} 
}

//Lungu Andreea - 19.08.2008
//adauga reprezentant legal in lista de reprezetanti legali ai angajatorului
function AddReprez()
{
	
	var txtNumeReprezClient = document.getElementById( txtNumeReprez );
	var txtPrenumeReprezClient = document.getElementById( txtPrenumeReprez );
	var lstReprezLegaliClient = document.getElementById( lstReprezLegali );
	var drpFunctiiReprezClient = document.getElementById(drpFunctiiReprez);
	
	if(txtNumeReprezClient.value == '' || txtPrenumeReprezClient.value == '')
	{
		alert('Nu ati introdus toate datele pentru reprezentantul legal!');
	}
	else
	{
		if ( !Validare(txtNumeReprezClient.value) || !Validare(txtPrenumeReprezClient.value) )
		{
			alert("Numele si prenumele reprezentantului nu pot contine caractere invalide: <>()';\"\\");
		}
		else
		{
			var opt = new Option(txtNumeReprezClient.value + ','+ txtPrenumeReprezClient.value + ',' + drpFunctiiReprezClient.options[drpFunctiiReprezClient.selectedIndex].text);
			txtNumeReprezClient.value = '';
			txtPrenumeReprezClient.value = '';
			
			/*var pozitie = lstReprezLegaliClient.options.length;
			for (j=0; j<lstReprezLegaliClient.options.length; j++)
			{
				var sir = lstReprezLegaliClient.options[j].text.split(",");
				alert('j='+j+':'+sir);
				alert(drpFunctiiReprezClient.options[drpFunctiiReprezClient.selectedIndex].text + ' < ' + sir[2]);
				if (drpFunctiiReprezClient.options[drpFunctiiReprezClient.selectedIndex].text < sir[2])
				{
					pozitie = j;
					break;
				}
			}
			
			lstReprezLegaliClient.add(opt, pozitie);*/
			lstReprezLegaliClient.add(opt);
			ChangeReprezListAdauga();
			//trebuie scoasa functia din dropdownlist-ul de functii
			ChangeListFunctiiReprezAdauga();
			ChangeTextNrFunctii();
		}
	}
}

//Lungu Andreea - 19.08.2008
//sterge un reprezentant
function DeleteReprez()
{
	var txtNumeReprezClient = document.getElementById( txtNumeReprez );
	var txtPrenumeReprezClient = document.getElementById( txtPrenumeReprez );
	var lstReprezLegaliClient = document.getElementById( lstReprezLegali );
	var drpFunctiiReprezClient = document.getElementById(drpFunctiiReprez);

	if (lstReprezLegaliClient.selectedIndex < 0)
	{
		alert("Trebuie sa selectati un reprezentant din lista!");
	}
	else
	{
		sirReprez = document.getElementById( txtHiddenReprez ).value.split(";");
		reprez = sirReprez[lstReprezLegaliClient.selectedIndex].split(",");
		ChangeListFunctiiReprezDelete(reprez[3], reprez[0]);
				
		lstReprezLegaliClient.remove( lstReprezLegaliClient.selectedIndex );
		ChangeReprezListSterge();
		
	}
}

//Lungu Andreea - 19.08.2008
//sterge toti reprezentantii legali
function DeleteAllReprez()
{
	var txtNumeReprezClient = document.getElementById( txtNumeReprez );
	var txtPrenumeReprezClient = document.getElementById( txtPrenumeReprez );
	var lstReprezLegaliClient = document.getElementById( lstReprezLegali );
	var drpFunctiiReprezClient = document.getElementById(drpFunctiiReprez);
	
	if(lstReprezLegaliClient.options.length == 0)
	{
		alert("Nu exista nici un reprezentant in lista cu reprezentanti legali!");
	}
	else
	{
		lstReprezLegalClient = document.getElementById( lstReprezLegali );
		sirReprez = document.getElementById( txtHiddenReprez ).value.split(";");
		for (i=0; i<sirReprez.length; i++)
		{
			reprez = sirReprez[i].split(",");
			ChangeListFunctiiReprezDelete(reprez[3], reprez[0]);
			
			j=0;
			while (j<lstReprezLegaliClient.length)
			{
				if (reprez[1]+","+reprez[2]+","+reprez[3] == lstReprezLegaliClient.options[j].text)
					lstReprezLegaliClient.remove(j);
				j++;
			}	
			
		}
		txtNumeReprezClient.value = '';
		txtPrenumeReprez.value = '';
		ChangeReprezListSterge();
	}		
}

function ChangeListFunctiiReprezDelete( textOpt, valOpt)
{
	var drpFunctiiReprezClient = document.getElementById(drpFunctiiReprez);
	
	var opt = new Option(textOpt, valOpt);
	var poz = drpFunctiiReprezClient.length;
	var k = 0;
	for (k=0; k<drpFunctiiReprezClient.length; k++)
	{
		if (drpFunctiiReprezClient.options[k].text>textOpt)
		{
			poz = k;
			break;
		}
	}
	drpFunctiiReprezClient.length = drpFunctiiReprezClient.length + 1;
	for (k=drpFunctiiReprezClient.length-2; k>=poz; k--)
	{
		drpFunctiiReprezClient.options[k+1].value = drpFunctiiReprezClient.options[k].value;
		drpFunctiiReprezClient.options[k+1].text = drpFunctiiReprezClient.options[k].text;
	}
	drpFunctiiReprezClient.options[poz].text = opt.text;
	drpFunctiiReprezClient.options[poz].value = opt.value;
	document.getElementById(txtHiddenNrFunctii).innerText = drpFunctiiReprezClient.length;	
	ChangeTextNrFunctii();
}

//Lungu Andreea - 20.08.2008
//se actualizeaza drop down list-ul ce contine functiile reprezentantilor
function ChangeListFunctiiReprezAdauga()
{
	var lstReprezLegaliClient = document.getElementById( lstReprezLegali );
	var drpFunctiiReprezClient = document.getElementById(drpFunctiiReprez);
	
	if(lstReprezLegaliClient.length!=0)
	{
		sirReprez = document.getElementById( txtHiddenReprez ).value.split(";");
		for (i=0; i<sirReprez.length; i++)
		{	
			reprez = sirReprez[i].split(",");
			for(j=0;j<drpFunctiiReprezClient.length;j++)
			{
				if (drpFunctiiReprezClient.options[j].text == reprez[3])
				{
					drpFunctiiReprezClient.remove(j);
				}
			}
		}
	}
	document.getElementById(txtHiddenNrFunctii).innerText = drpFunctiiReprezClient.length;		
}

function ChangeTextNrFunctii()
{
	var txtHiddenNrFunctiiClient = document.getElementById(txtHiddenNrFunctii);
	var txtNumeReprezClient = document.getElementById( txtNumeReprez );
	var txtPrenumeReprezClient = document.getElementById( txtPrenumeReprez );
	var lstReprezLegaliClient = document.getElementById( lstReprezLegali );
	var drpFunctiiReprezClient = document.getElementById(drpFunctiiReprez);
	
	if (txtHiddenNrFunctiiClient.value == "0")
	{
		document.getElementById('btnAddOneReprez').disabled = true;
		txtNumeReprezClient.disabled = true;
		txtPrenumeReprezClient.disabled = true;
		drpFunctiiReprezClient.disabled = true;
	}
	else
	{
		document.getElementById('btnAddOneReprez').disabled = false;
		txtNumeReprezClient.disabled = false;
		txtPrenumeReprezClient.disabled = false;
		drpFunctiiReprezClient.disabled = false;
	}
}

//Lungu Andreea - 19.08.2008
//se actualizeaza campul care retine lista cu reprezentantii legali
function ChangeReprezListSterge()
{
	var txtNumeReprezClient = document.getElementById( txtNumeReprez );
	var txtPrenumeReprezClient = document.getElementById( txtPrenumeReprez );
	var lstReprezLegaliClient = document.getElementById( lstReprezLegali );
	var drpFunctiiReprez = document.getElementById(drpFunctiiReprez);
	
	var textReprezList="";
	
	if(lstReprezLegaliClient.length!=0)
	{
		sirReprez = document.getElementById( txtHiddenReprez ).value.split(";");
		document.getElementById(txtHiddenReprez).innerText="";
		for (i=0; i<sirReprez.length-1; i++)
		{	
			reprez = sirReprez[i].split(",");
			for(j=0;j<lstReprezLegaliClient.length-1;j++)
			{
				if (lstReprezLegaliClient.options[j].text == reprez[1]+","+reprez[2]+","+reprez[3])
				{
					textReprezList += reprez[0]+ "," +reprez[1]+ "," + reprez[2] + "," + reprez[3] + ";";
				}
			}
			if (lstReprezLegaliClient.options[lstReprezLegaliClient.length-1].text == reprez[1]+","+reprez[2]+","+reprez[3])
			{
				textReprezList += reprez[0]+ "," +reprez[1]+ "," + reprez[2] + "," + reprez[3];
			}
		}
		reprez = sirReprez[sirReprez.length-1].split(",");
		for(j=0;j<lstReprezLegaliClient.length-1;j++)
		{
			if (lstReprezLegaliClient.options[j].text == reprez[1]+","+reprez[2]+","+reprez[3])
			{
				textReprezList += reprez[0]+ "," + reprez[1]+ "," + reprez[2] + "," + reprez[3] + ";";
			}
		}
		if (lstReprezLegaliClient.options[lstReprezLegaliClient.length-1].text == reprez[1] + "," +reprez[2] + "," + reprez[3])
		{
			textReprezList += reprez[0]+ "," + reprez[1]+ "," + reprez[2] + "," + reprez[3];
		}
	}
	document.getElementById(txtHiddenReprez).innerText = textReprezList;		
}

//Lungu Andreea - 19.08.2008
//se actualizeaza campul care retine lista cu reprezentantii legali
function ChangeReprezListAdauga()
{
	var txtNumeReprezClient = document.getElementById( txtNumeReprez );
	var txtPrenumeReprezClient = document.getElementById( txtPrenumeReprez );
	var lstReprezLegaliClient = document.getElementById( lstReprezLegali );
	var drpFunctiiReprezClient = document.getElementById(drpFunctiiReprez);
	
	if(lstReprezLegaliClient.length!=0)
	{
		if (document.getElementById(txtHiddenReprez).value == "")
			document.getElementById(txtHiddenReprez).innerText = drpFunctiiReprezClient.options[drpFunctiiReprezClient.selectedIndex].value + "," + lstReprezLegaliClient.options[lstReprezLegaliClient.length-1].text;	
		else
			document.getElementById(txtHiddenReprez).innerText = document.getElementById(txtHiddenReprez).value + ";" + drpFunctiiReprezClient.options[drpFunctiiReprezClient.selectedIndex].value + ","  + lstReprezLegaliClient.options[lstReprezLegaliClient.length-1].text;	
	}
}

</script>
<form id="Form1" name="Form1" method="post" runat="server">
	<table align="center">
		<tr>
			<td colspan="2" align="center">
				<uc1:pageheader id="PageHeader1" relativePath="../" runat="server"></uc1:pageheader></td>
		</tr>
	</table>
	<table class="tabBackground" cellSpacing="0" cellPadding="0" align="center" border="0">
		<TBODY>
			<tr>
				<td><asp:literal id="litError" runat="server"></asp:literal></td>
			</tr>
			<TR id="add_form">
				<TD align="center">
					<table cellSpacing="1" cellPadding="0" border="0">
						<TBODY>
							<tr>
								<td class="BigBlueBold" align="center" colSpan="4" height="50">Introduce angajator 
									nou</td>
							</tr>
							<tr>
								<td align="center" colSpan="5"><asp:table id="tableTabs" runat="server"></asp:table></td>
							</tr>
							<tr>
								<td class="NormalGreenBold" id="tableDateAngajator" vAlign="top" align="center">
									<table class="tabBackground" cellSpacing="1" cellPadding="0" width="735" border="0">
										<tr>
											<td class="NormalGreenBold">Denumire :</td>
											<td><asp:textbox id="txtDenumire" runat="server" size="50" CssClass="NormalEditBoxuri" MaxLength="100"></asp:textbox><SPAN class="CommentRedBold">*</SPAN>
												<asp:requiredfieldvalidator id="requiredDenumire" runat="server" CssClass="AlertRedBold" ErrorMessage="Completati denumirea angajatorului!"
													ControlToValidate="txtDenumire"><</asp:requiredfieldvalidator><asp:regularexpressionvalidator id="regularDenumire" runat="server" CssClass="AlertRedBold" ErrorMessage="Denumirea nu poate sa contina caractere invalide: <>()';&quot;\ "
													ControlToValidate="txtDenumire" ValidationExpression="^[^>|(|)|<|'|&quot;|;|\\]*$"><</asp:regularexpressionvalidator></td>
										</tr>
										<tr>
											<td class="GreenSeparator" colSpan="2"><IMG height="1" src="images/1x1.gif"></td>
										</tr>
										<tr>
											<td class="NormalGreenBold">Tip :</td>
											<td><asp:dropdownlist id="lstTipPersoana" runat="server" CssClass="SelectStyle" Width="200px">
													<asp:ListItem Value="1">Persoana juridica</asp:ListItem>
													<asp:ListItem Value="0">Persoana fizica</asp:ListItem>
												</asp:dropdownlist></td>
										</tr>
										<tr>
											<td class="GreenSeparator" colSpan="2"><IMG height="1" src="images/1x1.gif"></td>
										</tr>
										<tr>
											<td class="NormalGreenBold">CUI / CNP&nbsp;:</td>
											<td><asp:textbox id="txtCUI_CNP" runat="server" CssClass="NormalEditBoxuri" MaxLength="25" Width="200px"></asp:textbox><SPAN class="CommentRedBold">*</SPAN>
												<asp:requiredfieldvalidator id="requiredFiliala" runat="server" CssClass="AlertRedBold" ErrorMessage="Completati CUI / CNP !"
													ControlToValidate="txtCUI_CNP"><</asp:requiredfieldvalidator><asp:regularexpressionvalidator id="regularCUI" runat="server" CssClass="AlertRedBold" ErrorMessage="CUI nu poate sa contina caractere invalide: <>()';&quot;\ "
													ControlToValidate="txtCUI_CNP" ValidationExpression="^[^>|(|)|<|'|&quot;|;|\\]*$"><</asp:regularexpressionvalidator></td>
										</tr>
										<tr>
											<td class="GreenSeparator" colSpan="2"><IMG height="1" src="images/1x1.gif"></td>
										</tr>
										<TR>
											<TD class="NormalGreenBold">Nr. inregistrare ORC :</TD>
											<TD><asp:textbox id="txtNrInreg" runat="server" CssClass="NormalEditBoxuri" MaxLength="25" Width="200px"></asp:textbox><SPAN class="CommentRedBold">*</SPAN>
												<asp:requiredfieldvalidator id="requiredNrInreg" runat="server" CssClass="AlertRedBold" ErrorMessage="Completati numarul de inregistrare !"
													ControlToValidate="txtNrInreg"><</asp:requiredfieldvalidator><asp:regularexpressionvalidator id="regularNrInreg" runat="server" CssClass="AlertRedBold" ErrorMessage="Numarul de inregistrare nu poate sa contina caractere invalide: <>()';&quot;\ "
													ControlToValidate="txtNrInreg" ValidationExpression="^[^>|(|)|<|'|&quot;|;|\\]*$"><</asp:regularexpressionvalidator></TD>
										</TR>
										<tr>
											<td class="GreenSeparator" colSpan="2"><IMG height="1" src="images/1x1.gif"></td>
										</tr>
										<TR>
											<TD class="NormalGreenBold">Nr. inregistrare ITM</TD>
											<TD>
												<asp:textbox id="txtNrInregItm" runat="server" MaxLength="25" CssClass="NormalEditBoxuri" Width="200px"></asp:textbox><SPAN class="CommentRedBold">*</SPAN>
												<asp:requiredfieldvalidator id="requiredNrInregItm" runat="server" CssClass="AlertRedBold" ControlToValidate="txtNrInregItm"
													ErrorMessage="Completati numarul de inregistrare ITM!"><</asp:requiredfieldvalidator>
												<asp:RegularExpressionValidator id="regularNrInregItm" runat="server" CssClass="AlertRedBold" ControlToValidate="txtNrInregItm"
													ErrorMessage="Numarul de inregistrare ITM nu poate sa contina caractere invalide: <>()';&quot;\ " ValidationExpression="^[^>|(|)|<|'|&quot;|;|\\]*$"><</asp:RegularExpressionValidator>
											</TD>
										</TR>
										<tr>
											<td class="GreenSeparator" colSpan="2"><IMG height="1" src="images/1x1.gif"></td>
										</tr>
										<TR>
											<TD class="NormalGreenBold">Telefon :</TD>
											<TD><asp:textbox id="txtTelefon" runat="server" CssClass="NormalEditBoxuri" MaxLength="25" Width="200px"></asp:textbox><SPAN class="CommentRedBold">*</SPAN>
												<asp:requiredfieldvalidator id="requiredTelefon" runat="server" CssClass="AlertRedBold" ErrorMessage="Completati numarul de telefon !"
													ControlToValidate="txtTelefon"><</asp:requiredfieldvalidator><asp:regularexpressionvalidator id="regularTelefon" runat="server" CssClass="AlertRedBold" ErrorMessage="Numar de telefon incorect!"
													ControlToValidate="txtTelefon" ValidationExpression="\d{4}\s?\/?\d{6}"><</asp:regularexpressionvalidator></TD>
										</TR>
										<tr>
											<td class="GreenSeparator" colSpan="2"><IMG height="1" src="images/1x1.gif"></td>
										</tr>
										<TR>
											<TD class="NormalGreenBold">Fax :</TD>
											<TD><asp:textbox id="txtFax" runat="server" CssClass="NormalEditBoxuri" MaxLength="25" Width="200px"></asp:textbox><asp:regularexpressionvalidator id="regularFax" runat="server" CssClass="AlertRedBold" ErrorMessage="Numar de fax incorect!"
													ControlToValidate="txtFax" ValidationExpression="\d{4}\s?\/?\d{6}"><</asp:regularexpressionvalidator></TD>
										</TR>
										<tr>
											<td class="GreenSeparator" colSpan="2"><IMG height="1" src="images/1x1.gif"></td>
										</tr>
										<TR>
											<TD class="NormalGreenBold">Adresa&nbsp;web:</TD>
											<TD><asp:textbox id="txtAdresaWeb" runat="server" CssClass="NormalEditBoxuri" MaxLength="100" Width="200px"></asp:textbox><asp:regularexpressionvalidator id="regularAdresaWeb" runat="server" CssClass="AlertRedBold" ErrorMessage="Adresa de web nu poate sa contina caractere invalide: <>()';&quot;\ "
													ControlToValidate="txtAdresaWeb" ValidationExpression="^[^>|(|)|<|'|&quot;|;|\\]*$"><</asp:regularexpressionvalidator></TD>
										</TR>
										<tr>
											<td class="GreenSeparator" colSpan="2"><IMG height="1" src="images/1x1.gif"></td>
										</tr>
										<TR>
											<TD class="NormalGreenBold" style="HEIGHT: 21px">Email :</TD>
											<TD style="HEIGHT: 21px"><asp:textbox id="txtEmail" runat="server" CssClass="NormalEditBoxuri" MaxLength="100" Width="200px"></asp:textbox><asp:regularexpressionvalidator id="regularEmail" runat="server" CssClass="AlertRedBold" ErrorMessage="Adresa de email incorecta!"
													ControlToValidate="txtEmail" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"><</asp:regularexpressionvalidator></TD>
										</TR>
										<tr>
											<td class="GreenSeparator" colSpan="2" style="HEIGHT: 1px"><IMG height="1" src="images/1x1.gif"></td>
										</tr>
										<TR>
											<TD class="NormalGreenBold">Ziua lichidarii drepturilor salariale :</TD>
											<TD><asp:textbox id="txtZiLichidareSalariu" runat="server" CssClass="NormalEditBoxuri" MaxLength="2"
													Width="200px"></asp:textbox><asp:rangevalidator id="vldZiuaLichidarii" runat="server" CssClass="AlertRedBold" ErrorMessage="Completati corect ziua lichidarii drepturilor salariale (o valoare intre 1 si 31)!"
													ControlToValidate="txtZiLichidareSalariu" Type="Integer" MinimumValue="1" MaximumValue="31"><</asp:rangevalidator></TD>
										</TR>
										<tr>
											<td class="GreenSeparator" colSpan="2"><IMG height="1" src="images/1x1.gif"></td>
										</tr>
										<!--<TR>
											<TD class="NormalGreenBold">Tip completare carnete munca&nbsp;:</TD>
											<TD><asp:dropdownlist id="lstTipCompletare" runat="server" CssClass="SelectStyle" Width="400px"></asp:dropdownlist></TD>
										</TR>-->
										<TR>
											<TD class="NormalGreenBold">Luna activa:</TD>
											<TD><asp:dropdownlist id="lstLuna" runat="server" CssClass="SelectStyle" Width="200px" onchange="lstLunaOnChange()"></asp:dropdownlist><asp:dropdownlist id="lstAn" runat="server" Width="80px" onchange="lstAnOnChange()"></asp:dropdownlist></TD>
										</TR>
									</table>
								</td>
								<td id="tableConturi" vAlign="top" align="center">
									<table class="tabBackground" cellSpacing="1" cellPadding="0" width="735" border="0">
										<tr>
											<td class="NormalGreenBold">Banca:</td>
											<td><SPAN class="CommentRedBold"><asp:dropdownlist id="drpBanci" runat="server" Width="300px"></asp:dropdownlist></SPAN></td>
										</tr>
										<tr>
											<td class="GreenSeparator" colSpan="2"><IMG height="1" src="images/1x1.gif"></td>
										</tr>
										<tr>
											<td class="NormalGreenBold" style="WIDTH: 81px">Numar cont format vechi:</td>
											<td><asp:textbox id="txtNumarContVechi" runat="server" CssClass="NormalEditBoxuri" MaxLength="16"
													Width="210px"></asp:textbox><SPAN class="CommentRedBold"></SPAN></td>
										</tr>
										<tr>
											<td class="GreenSeparator" colSpan="2"><IMG height="1" src="images/1x1.gif"></td>
										</tr>
										<tr>
											<td class="NormalGreenBold">Numar cont IBAN:</td>
											<td><asp:textbox id="txtNumarContIBAN" runat="server" CssClass="NormalEditBoxuri" MaxLength="24"
													Width="210px"></asp:textbox><SPAN class="CommentRedBold"></SPAN></td>
										</tr>
										<tr>
											<td class="GreenSeparator" colSpan="2"><IMG height="1" src="images/1x1.gif"></td>
										</tr>
										<tr>
											<td class="NormalGreenBold">Moneda:</td>
											<td><asp:dropdownlist id="drpMoneda" runat="server" Width="88px">
													<asp:ListItem Value="RON">RON</asp:ListItem>
													<asp:ListItem Value="EURO">EURO</asp:ListItem>
													<asp:ListItem Value="USD">USD</asp:ListItem>
												</asp:dropdownlist></td>
										</tr>
										<tr>
											<td class="GreenSeparator" colSpan="2"><IMG height="1" src="images/1x1.gif"></td>
										</tr>
										<tr>
											<td class="NormalGreenBold">Activ:</td>
											<td><asp:checkbox id="chkActiv" runat="server" Checked="True"></asp:checkbox></td>
										</tr>
										<tr>
											<td class="GreenSeparator" colSpan="2"><IMG height="1" src="images/1x1.gif"></td>
										</tr>
										<tr>
											<td align="center" colSpan="2"><INPUT class="ButtonStyle" id="btnAddCont" onclick="javascript:AddContBancar()" type="button"
													value="Adauga cont"></td>
											<td></td>
										</tr>
										<tr>
											<td class="GreenSeparator" colSpan="2"><IMG height="1" src="images/1x1.gif"></td>
										</tr>
										<tr>
											<td class="NormalGreenBold" align="center" colSpan="2">Lista Conturi<br>
												(CodBanca - NumeBanca, Numar cont format vechi, Numar cont IBAN, Moneda, Activ)</td>
										</tr>
										<tr>
											<td class="GreenSeparator" colSpan="2"><IMG height="1" src="images/1x1.gif"></td>
										</tr>
										<tr>
											<td align="center" colSpan="2"><asp:listbox id="lstConturiBancare" runat="server" Width="554px" Height="154px" OnChange="javascript:FillContBancarControls();"></asp:listbox><asp:requiredfieldvalidator id="requiredConturi" runat="server" CssClass="AlertRedBold" ErrorMessage="Nu ati completat nici un cont pentru angajator!"
													ControlToValidate="txtListaConturiHidden"><</asp:requiredfieldvalidator></td>
										</tr>
										<tr>
											<td class="GreenSeparator" colSpan="2"><IMG height="1" src="images/1x1.gif"></td>
										</tr>
										<tr>
											<td align="center" colSpan="2"><INPUT class="ButtonStyle" id="btnDeleteCont" onclick="javascript:DeleteContBancarConfirmare()"
													type="button" value="Sterge cont"> <INPUT class="ButtonStyle" id="btnUpdateCont" onclick="javascript:UpdateContBancar()" type="button"
													value="Modifica date cont">
											</td>
											<td></td>
										</tr>
									</table>
									<INPUT id="txtListaConturiHidden" style="DISPLAY: none" type="text" name="txtListaConturiHidden"
										runat="server">
								</td>
								<td id="tableAdresa" vAlign="top" align="center">
									<table class="tabBackground" cellSpacing="1" cellPadding="0" width="735" border="0">
										<TR>
											<TD class="NormalGreenBold">Tara&nbsp;:</TD>
											<TD><asp:dropdownlist id="lstDTara" runat="server" CssClass="SelectStyle" Width="150px" onChange="lstDTaraOnChange(this);"></asp:dropdownlist></TD>
										</TR>
										<tr>
											<td class="GreenSeparator" colSpan="2"><IMG height="1" src="images/1x1.gif"></td>
										</tr>
										<TR>
											<TD class="NormalGreenBold">Judet :</TD>
											<TD><asp:dropdownlist id="lstDJudet" runat="server" CssClass="SelectStyle" Width="150px" onChange="lstDJudetSectorOnChange(this);"></asp:dropdownlist><SPAN class="CommentRedBold">*</SPAN>
												<asp:requiredfieldvalidator id="requiredDJudet" runat="server" CssClass="AlertRedBold" ErrorMessage="Completati judetul!"
													ControlToValidate="lstDJudet" Height="10px"><</asp:requiredfieldvalidator></TD>
										</TR>
										<TR>
											<td class="GreenSeparator" colSpan="2"><IMG height="1" src="images/1x1.gif"></td>
										<TR>
											<TD class="NormalGreenBold">Sector :</TD>
											<TD><asp:textbox id="txtDSector" runat="server" CssClass="NormalEditBoxuri" MaxLength="5" Width="130px"></asp:textbox><asp:regularexpressionvalidator id="regularSector" runat="server" CssClass="AlertRedBold" ErrorMessage="Sectorul nu poate sa contina caractere invalide: <>()';&quot;\ "
													ControlToValidate="txtDSector" ValidationExpression="^[^>|(|)|<|'|&quot;|;|\\]*$"><</asp:regularexpressionvalidator></TD>
										</TR>
										<tr>
											<td class="GreenSeparator" colSpan="2"><IMG height="1" src="images/1x1.gif"></td>
										</tr>
										<TR>
											<TD class="NormalGreenBold">Localitate :</TD>
											<TD><asp:textbox id="txtDLocalitate" runat="server" CssClass="NormalEditBoxuri" MaxLength="50" Width="130px"></asp:textbox><SPAN class="CommentRedBold">*
													<asp:requiredfieldvalidator id="requiredDLocalitate" runat="server" CssClass="AlertRedBold" ErrorMessage="Completati localitatea!"
														ControlToValidate="txtDLocalitate"><</asp:requiredfieldvalidator><asp:regularexpressionvalidator id="regularLocalitate" runat="server" CssClass="AlertRedBold" ErrorMessage="Localitatea nu poate sa contina caractere invalide: <>()';&quot;\ "
														ControlToValidate="txtDLocalitate" ValidationExpression="^[^>|(|)|<|'|&quot;|;|\\]*$"><</asp:regularexpressionvalidator></SPAN></TD>
										</TR>
										<tr>
											<td class="GreenSeparator" colSpan="2"><IMG height="1" src="images/1x1.gif"></td>
										</tr>
										<TR>
											<TD class="NormalGreenBold">Strada :</TD>
											<TD><asp:textbox id="txtDStrada" runat="server" CssClass="NormalEditBoxuri" MaxLength="50" Width="130px"></asp:textbox><SPAN class="CommentRedBold">*
													<asp:requiredfieldvalidator id="requiredDStrada" runat="server" CssClass="AlertRedBold" ErrorMessage="Completati strada!"
														ControlToValidate="txtDStrada"><</asp:requiredfieldvalidator><asp:regularexpressionvalidator id="regularStrada" runat="server" CssClass="AlertRedBold" ErrorMessage="Strada nu poate sa contina caractere invalide: <>()';&quot;\ "
														ControlToValidate="txtDStrada" ValidationExpression="^[^>|(|)|<|'|&quot;|;|\\]*$"><</asp:regularexpressionvalidator></SPAN></TD>
										</TR>
										<tr>
											<td class="GreenSeparator" colSpan="2"><IMG height="1" src="images/1x1.gif"></td>
										</tr>
										<TR>
											<TD class="NormalGreenBold">Numar :</TD>
											<TD><asp:textbox id="txtDNumar" runat="server" CssClass="NormalEditBoxuri" MaxLength="10" Width="130px"></asp:textbox><SPAN class="CommentRedBold">*
													<asp:requiredfieldvalidator id="requiredDNumar" runat="server" CssClass="AlertRedBold" ErrorMessage="Completati numar!"
														ControlToValidate="txtDNumar"><</asp:requiredfieldvalidator><asp:regularexpressionvalidator id="regularNumar" runat="server" CssClass="AlertRedBold" ErrorMessage="Numarul nu poate sa contina caractere invalide: <>()';&quot;\ "
														ControlToValidate="txtDNumar" ValidationExpression="^[^>|(|)|<|'|&quot;|;|\\]*$"><</asp:regularexpressionvalidator></SPAN></TD>
										</TR>
										<tr>
											<td class="GreenSeparator" colSpan="2"><IMG height="1" src="images/1x1.gif"></td>
										</tr>
										<TR>
											<TD class="NormalGreenBold">Cod postal :</TD>
											<TD><asp:textbox id="txtDCodPostal" runat="server" CssClass="NormalEditBoxuri" MaxLength="20" Width="130px"></asp:textbox><SPAN class="CommentRedBold">*
													<asp:requiredfieldvalidator id="requiredDCodPostal" runat="server" CssClass="AlertRedBold" ErrorMessage="Completati cod postal!"
														ControlToValidate="txtDCodPostal"><</asp:requiredfieldvalidator><asp:regularexpressionvalidator id="regularDCodPostal" runat="server" CssClass="AlertRedBold" ErrorMessage="Introduceti numai cifre pentru codul postal!"
														ControlToValidate="txtDCodPostal" ValidationExpression="[0-9]*"><</asp:regularexpressionvalidator></SPAN></TD>
										</TR>
										<tr>
											<td class="GreenSeparator" colSpan="2"><IMG height="1" src="images/1x1.gif"></td>
										</tr>
										<TR>
											<TD class="NormalGreenBold">Bloc :</TD>
											<TD><asp:textbox id="txtDBloc" runat="server" CssClass="NormalEditBoxuri" MaxLength="5" Width="50px"></asp:textbox><asp:regularexpressionvalidator id="regularDBloc" runat="server" CssClass="AlertRedBold" ErrorMessage="Introduceti numai litere si cifre pentru bloc!"
													ControlToValidate="txtDBloc" ValidationExpression="[a-zA-Z0-9]*"><</asp:regularexpressionvalidator></TD>
										</TR>
										<tr>
											<td class="GreenSeparator" colSpan="2"><IMG height="1" src="images/1x1.gif"></td>
										</tr>
										<TR>
											<TD class="NormalGreenBold">Scara :</TD>
											<TD><asp:textbox id="txtDScara" runat="server" CssClass="NormalEditBoxuri" MaxLength="5" Width="50px"></asp:textbox><asp:regularexpressionvalidator id="regularDScara" runat="server" CssClass="AlertRedBold" ErrorMessage="Introduceti numai litere si cifre pentru scara!"
													ControlToValidate="txtDScara" ValidationExpression="[a-zA-Z0-9]*"><</asp:regularexpressionvalidator></TD>
										</TR>
										<tr>
											<td class="GreenSeparator" colSpan="2"><IMG height="1" src="images/1x1.gif"></td>
										</tr>
										<TR>
											<TD class="NormalGreenBold">Etaj :</TD>
											<TD><asp:textbox id="txtDEtaj" runat="server" CssClass="NormalEditBoxuri" MaxLength="5" Width="50px"></asp:textbox><asp:regularexpressionvalidator id="regularDEtaj" runat="server" CssClass="AlertRedBold" ErrorMessage="Introduceti numai litere si cifre pentru etaj!"
													ControlToValidate="txtDEtaj" ValidationExpression="[a-zA-Z0-9]*"><</asp:regularexpressionvalidator></TD>
										</TR>
										<tr>
											<td class="GreenSeparator" colSpan="2"><IMG height="1" src="images/1x1.gif"></td>
										</tr>
										<TR>
											<TD class="NormalGreenBold">Apartament :</TD>
											<TD><asp:textbox id="txtDApartament" runat="server" CssClass="NormalEditBoxuri" MaxLength="5" Width="50px"></asp:textbox><asp:regularexpressionvalidator id="regularDApartament" runat="server" CssClass="AlertRedBold" ErrorMessage="Introduceti numai litere si cifre pentru apartament!"
													ControlToValidate="txtDApartament" ValidationExpression="[a-zA-Z0-9]*"><</asp:regularexpressionvalidator></TD>
										</TR>
										<tr>
											<td class="GreenSeparator" colSpan="2"><IMG height="1" src="images/1x1.gif"></td>
										</tr>
									</table>
								</td>
								<td id="tableDomeniiDeActivitate" vAlign="top" align="center">
									<table class="tabBackground" cellSpacing="1" cellPadding="0" width="735" border="0">
										<TBODY>
											<TR>
												<TD class="NormalGreenBold" style="WIDTH: 286px; HEIGHT: 18px" vAlign="middle" align="center">Domenii 
													de activitate</TD>
												<TD class="NormalGreenBold" style="HEIGHT: 18px" align="center"></TD>
												<TD class="NormalGreenBold" style="HEIGHT: 18px" vAlign="middle" align="center">
													<P>Domenii de activitate angajator</P>
												</TD>
											</TR>
											<TR>
												<TD class="NormalGreenBold" style="WIDTH: 286px; HEIGHT: 18px" vAlign="middle" align="center">(Cod 
													CAEN,Denumire,Descriere)</TD>
												<TD class="NormalGreenBold" style="HEIGHT: 18px" align="center"></TD>
												<TD class="NormalGreenBold" style="HEIGHT: 18px" vAlign="middle" align="center">(Cod 
													CAEN,Denumire,Descriere)</TD>
											</TR>
											<tr>
												<td class="GreenSeparator" colSpan="3"><IMG height="1" src="images/1x1.gif"></td>
											</tr>
											<tr>
												<td style="WIDTH: 286px" vAlign="middle" align="center"><asp:listbox id="lstBoxDomenii" runat="server" CssClass="SelectStyle" Width="250px" Height="150px"
														Rows="10"></asp:listbox>&nbsp;</td>
												<td align="center">
													<table>
														<tr>
															<td align="center"><input class="ButtonStyle" id="btnAddAllDomanins" style="WIDTH: 100%; HEIGHT: 100%" onclick="javascript:AddAllDomDeAct()"
																	type="button" value=">>">
															</td>
														</tr>
														<tr>
															<td align="center"><input class="ButtonStyle" id="btnAddOneDomanin" style="WIDTH: 100%; HEIGHT: 100%" onclick="javascript:AddDomDeActSelectat()"
																	type="button" value=">">
															</td>
														</tr>
														<tr>
															<td align="center"><input class="ButtonStyle" id="btnDeleteOneDomanin" style="WIDTH: 100%; HEIGHT: 100%" onclick="javascript:DeleteDomDeActSelectat()"
																	type="button" value="<">
															</td>
														</tr>
														<tr>
															<td align="center"><input class="ButtonStyle" id="btnDeleteAllDomanins" style="WIDTH: 100%; HEIGHT: 100%"
																	onclick="javascript:DeleteAllDomDeAct()" type="button" value="<<">
															</td>
														</tr>
													</table>
												</td>
												<td vAlign="middle" align="center"><asp:listbox id="lstBoxDomeniiAngajator" runat="server" CssClass="SelectStyle" Width="250px"
														Height="150px" Rows="10"></asp:listbox><asp:requiredfieldvalidator id="requiredDomenii" runat="server" CssClass="AlertRedBold" ErrorMessage="Nu ati completat nici un domeniu de activitate!"
														ControlToValidate="txtHiddenDomDeActPpID"><</asp:requiredfieldvalidator>&nbsp;</td>
											</tr>
											<tr>
												<td class="GreenSeparator" colSpan="3"><IMG height="1" src="images/1x1.gif"></td>
											</tr>
											<TR>
												<TD class="NormalGreenBold" style="WIDTH: 286px" vAlign="middle" align="center"><INPUT id="txtHiddenDomDeActListID" type="text" name="txtHiddenDomDeActListID" runat="server">
												</TD>
												<TD align="center"></TD>
												<TD class="NormalGreenBold" vAlign="middle" align="center">Selectati domeniul 
													principal al angajatorului:</TD>
											</TR>
											<TR>
												<TD class="NormalGreenBold" style="WIDTH: 286px" vAlign="middle" align="center"><INPUT id="txtHiddenDomDeActPpID" type="text" name="txtHiddenDomDeActPpID" runat="server">
												</TD>
												<TD align="center"></TD>
												<TD class="NormalGreenBold" vAlign="middle" align="center"><SELECT id="drpDomDeActPrincipal" style="WIDTH: 250px; HEIGHT: 20px" onchange="ChangeDomDeActPp(this.options[this.selectedIndex].value)"
														name="drpDomDeActPrincipal" runat="server"></SELECT>
												</TD>
											</TR>
										</TBODY>
									</table>
								</td>
								<td id="tablePunctLucru" vAlign="top" align="center">
									<TABLE class="tabBackground" cellSpacing="1" cellPadding="0" width="735" border="0">
										<TBODY>
											<TR>
												<TD class="NormalGreenBold" style="WIDTH: 286px; HEIGHT: 18px" vAlign="middle" align="center">Punct&nbsp;de 
													lucru</TD>
												<TD class="NormalGreenBold" style="HEIGHT: 18px" align="center"></TD>
												<TD class="NormalGreenBold" style="HEIGHT: 18px" vAlign="middle" align="center">
													<P>Puncte&nbsp;de lucru&nbsp;pentru angajator</P>
												</TD>
											</TR>
											<TR>
												<TD class="NormalGreenBold" style="WIDTH: 286px; HEIGHT: 18px" vAlign="middle" align="center">(Denumire)</TD>
												<TD class="NormalGreenBold" style="HEIGHT: 18px" align="center"></TD>
												<TD class="NormalGreenBold" style="HEIGHT: 18px" vAlign="middle" align="center">(Denumire)</TD>
											</TR>
											<TR>
												<TD class="GreenSeparator" colSpan="3"><IMG height="1" src="images/1x1.gif"></TD>
											</TR>
											<TR>
												<TD style="WIDTH: 286px; HEIGHT: 167px" vAlign="middle" align="center">&nbsp;
													<TABLE id="Table1" style="WIDTH: 240px; HEIGHT: 57px" cellSpacing="0" cellPadding="2" width="240"
														border="0">
														<TR>
															<TD><asp:textbox id="txtNumePunctLucru" runat="server" Width="242px"></asp:textbox></TD>
														</TR>
														<TR>
															<TD class="NormalGreenBold">Selectati casa de asigurari implicita:</TD>
														</TR>
														<TR>
															<TD>
																<asp:dropdownlist id="drpCaseDeAsigurari" runat="server" Width="241px"></asp:dropdownlist></TD>
														</TR>
													</TABLE>
												</TD>
												<TD style="HEIGHT: 167px" align="center">
													<TABLE>
														<TBODY>
															<TR>
																<TD align="center"><INPUT class="ButtonStyle" id="btnAddOnePunctLucru" style="WIDTH: 100%; HEIGHT: 100%" onclick="javascript:AddPunctLucru()"
																		type="button" value="Adauga">
																</TD>
															</TR>
														</TBODY>
													</TABLE>
												</TD>
												<TD style="HEIGHT: 151px" vAlign="middle" align="center">
													<table style="WIDTH: 282px; HEIGHT: 200px" align="center">
														<TBODY>
															<tr>
																<td style="HEIGHT: 106px" vAlign="middle" align="center" colSpan="2"><asp:listbox id="lstPunctLucru" runat="server" CssClass="SelectStyle" Width="256px" Rows="10"></asp:listbox><asp:requiredfieldvalidator id="requiredPuncteLucru" runat="server" CssClass="AlertRedBold" ControlToValidate="txtHiddenPunctLucru"
																		ErrorMessage="Nu ati completat nici un punct de lucru!"><</asp:requiredfieldvalidator></td>
															</tr>
															<tr>
																<TD align="center"><INPUT class="ButtonStyle" id="btnDeleteOnePunctLucru" onclick="javascript:DeletePunctLucru()"
																		type="button" value="Sterge">
																</TD>
																<TD align="center"><INPUT class="ButtonStyle" id="btnDeleteAllPunctLucru" onclick="javascript:DeleteAllPunctLucru()"
																		type="button" value="Sterge tot">
																</TD>
															</tr>
														</TBODY>
													</table>
												</TD>
											</TR>
											<tr>
												<td align="center" colSpan="3"><INPUT id="txtHiddenPunctLucru" type="text" runat="server" NAME="txtHiddenPunctLucru"></td>
											</tr>
										</TBODY>
									</TABLE>
								</td>
								<td id="tableReprezLegal" vAlign="top" align="center"><TABLE class="tabBackground" cellSpacing="1" cellPadding="0" width="735" border="0">
										<TBODY>
											<TR>
												<TD class="NormalGreenBold" style="WIDTH: 242px; HEIGHT: 18px" vAlign="middle" align="center">Reprezentant 
													legal</TD>
												<TD class="NormalGreenBold" style="WIDTH: 44px; HEIGHT: 18px" align="center"></TD>
												<TD class="NormalGreenBold" style="HEIGHT: 18px" vAlign="middle" align="center">
													<P>Reprezentanti legali&nbsp;pentru angajator</P>
												</TD>
											</TR>
											<TR>
												<TD class="NormalGreenBold" style="WIDTH: 242px; HEIGHT: 18px" vAlign="middle" align="center">(Nume, 
													Prenume, Functie)</TD>
												<TD class="NormalGreenBold" style="WIDTH: 44px; HEIGHT: 18px" align="center"></TD>
												<TD class="NormalGreenBold" style="HEIGHT: 18px" vAlign="middle" align="center">(Nume, 
													Prenume, Functie)</TD>
											</TR>
											<TR>
												<TD class="GreenSeparator" colSpan="3"><IMG height="1" src="images/1x1.gif"></TD>
											</TR>
											<TR>
												<TD style="WIDTH: 242px; HEIGHT: 167px" vAlign="top" align="center">&nbsp;
													<TABLE id="Table1" style="WIDTH: 240px; HEIGHT: 57px" cellSpacing="0" cellPadding="2" width="240"
														border="0">
														<TR>
															<TD class="NormalGreenBold">Nume reprezentant:</TD>
														</TR>
														<TR>
															<TD><asp:textbox id="txtNumeReprez" runat="server" Width="242px"></asp:textbox></TD>
														</TR>
														<TR>
															<TD class="NormalGreenBold">Prenume reprezentant:</TD>
														</TR>
														<TR>
															<TD><asp:textbox id="txtPrenumeReprez" runat="server" Width="242px"></asp:textbox></TD>
														</TR>
														<TR>
															<TD class="NormalGreenBold">Functie reprezentant:</TD>
														</TR>
														<TR>
															<TD><asp:dropdownlist id="drpFunctiiReprez" runat="server" Width="241px"></asp:dropdownlist></TD>
														</TR>
													</TABLE>
													<asp:CompareValidator id="compValFunctii" runat="server" ErrorMessage="Trebuie adaugate persoane pentru toate functiile reprezentantilor legali!"
														ControlToValidate="txtHiddenNrFunctii" ValueToCompare="0"><</asp:CompareValidator></TD>
												<TD style="WIDTH: 44px; HEIGHT: 167px" align="center">
													<TABLE>
														<TBODY>
															<TR>
																<TD align="center"><INPUT class="ButtonStyle" id="btnAddOneReprez" style="WIDTH: 100%; HEIGHT: 100%" onclick="javascript:AddReprez()"
																		type="button" value="Adauga" name="btnAddOneReprez">
																</TD>
															</TR>
														</TBODY>
													</TABLE>
												</TD>
												<TD style="HEIGHT: 151px" vAlign="middle" align="center">
													<table style="HEIGHT: 219px" width="100%" align="center">
														<TBODY>
															<tr>
																<td style="HEIGHT: 181px" vAlign="middle" align="center" colSpan="2"><asp:listbox id="lstReprezLegali" runat="server" CssClass="SelectStyle" Width="95%" Rows="10"></asp:listbox></td>
															</tr>
															<tr>
																<TD align="center"><INPUT class="ButtonStyle" id="btnDeleteReprez" onclick="javascript:DeleteReprez()" type="button"
																		value="Sterge">
																</TD>
																<TD align="center"><INPUT class="ButtonStyle" id="btnDeleteAllReprez" onclick="javascript:DeleteAllReprez()"
																		type="button" value="Sterge tot">
																</TD>
															</tr>
														</TBODY>
													</table>
												</TD>
											</TR>
											<tr>
												<td align="center" colSpan="3" style="DISPLAY: none"><INPUT id="txtHiddenNrFunctii" style="WIDTH: 157px; HEIGHT: 22px" type="text" size="20"
														name="txtHiddenNrFunctii" runat="server"><INPUT id="txtHiddenReprez" style="WIDTH: 207px; HEIGHT: 22px" type="text" size="29" name="txtHiddenReprez"
														runat="server"></td>
											</tr>
										</TBODY>
									</TABLE>
								</td>
							</tr>
							<TR>
								<td colSpan="4">
									<table width="100%">
										<tr>
											<td class="CommentRedBold" align="left" colSpan="1">* - Campuri obligatorii
											</td>
											<td align="right"><input class="ButtonStyle" id="btnPrev" onmouseover="MouseOverButton(this)" style="DISPLAY: none"
													onclick="NextTabAngajator('back')" onmouseout="MouseOutButton(this)" type="button" align="left" value="  << Back  "
													name="btnPrev">&nbsp; <input class="ButtonStyle" id="btnNext" onmouseover="MouseOverButton(this)" onclick="NextTabAngajator('next')"
													onmouseout="MouseOutButton(this)" type="button" align="left" value="  Next >>  " name="btnNext">
											</td>
										</tr>
									</table>
								</td>
							</TR>
							<tr>
								<td align="center" colSpan="2" height="50"><asp:button id="btnAddBanca" onmouseover="MouseOverButton(this)" onmouseout="MouseOutButton(this)"
										runat="server" CssClass="ButtonStyle" Text="Salveaza angajator"></asp:button>&nbsp;</td>
							</tr>
							<TR>
								<TD align="center" colSpan="2"><asp:validationsummary id="ValidationSummary1" runat="server" CssClass="AlertRedBold" ShowMessageBox="True"
										ShowSummary="False"></asp:validationsummary></TD>
							</TR>
						</TBODY>
					</table>
				</TD>
			</TR>
		</TBODY>
	</table>
	</TR></TABLE> <input id="txtTaraHidden" type="hidden" name="txtTaraHidden" runat="server">
	<input id="txtJudetSectorHidden" type="hidden" name="txtJudetSectorHidden" runat="server">
	<INPUT id="txtTipCompletareHidden" type="hidden" name="txtTipCompletareHidden" runat="server"><INPUT id="txtHiddenLuna" type="hidden" name="txtHiddenLuna" runat="server"><INPUT id="txtHiddenAn" type="hidden" name="txtHiddenAn" runat="server"></form>
<script>
     var arForms = document.getElementsByTagName("Form");
	 formObj = arForms[0];
	 GolesteValidatori();
	 tab1.click();
</script>
