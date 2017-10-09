<%@ Register TagPrefix="uc1" TagName="PageHeader" Src="PageHeader.ascx" %>
<%@ Page language="c#" Codebehind="AddAngajat.aspx.cs" AutoEventWireup="false" Inherits="SiemensHR.WebForm1" %>
<%@ Register TagPrefix="uc1" TagName="HeaderMenu" Src="HeaderMenu.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>HR Toolkit</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK rel="stylesheet" type="text/css" href="StyleHR.css">
	</HEAD>
	<body>
		<script language="javascript" src="js/jsCode.js"></script>
		<script>
	var arTabs = new Array('tableDatePersonale', 'tableDomiciliu', 'tableBuletinPasaport', 'tableDateAngajator' , 'tableAlteDate', 'tableAlerteSpeciale');
	var oNewWindow = null;
		
	function SelectTab(index)
	{
		for(i=0; i<arTabs.length; i++)
		{
			if (i==index)
			{
				eval(arTabs[i] + ".style.display=''");
				eval("tab"+ (i+1)+ ".className='tabActive'");
				Form1.btnNext.style.display = "";
				Form1.btnPrev.style.display = "";
				if (i==0)
					Form1.btnPrev.style.display = "none";
				if (i==(arTabs.length-1))
					Form1.btnNext.style.display = "none";
					
			}
			else
			{
				eval("tab"+ (i+1) + ".className='tab'");
				eval("tab"+ (i+1) + ".style.backgroundColor='#7b8fc2'");
				eval(arTabs[i] + ".style.display='none'");
			}
		}
	}
	
	function NextTab( dir )
	{
		for(var i=0; i<arTabs.length; i++)
		{
			eval("className = tab"+ (i+1) + ".className;");
			if (className=='tabActive')
			{
				if (dir=="next")
				{				
					eval("tab" + (i+2) + ".style.backgroundColor='#20b2aa'");				
					eval("tab" + (i+2) + ".click()");					
					if (i==(arTabs.length-2))
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

function eNedeterminata()
{     
 if (Form1.lstPerAngajarii.selectedIndex==0)
 {   
   eval("Form1.txtDataPanaLa.style.display=''");
   eval("labPanaLa.style.display=''");
   eval("spanReq.style.display=''");   
   ValidatorEnable(document.getElementById("requiredDataPanaLa"),true);
 }
 else
 {
   eval("Form1.txtDataPanaLa.style.display='none'");
   eval("labPanaLa.style.display='none'");
   eval("spanReq.style.display='none'");
   ValidatorEnable(document.getElementById("requiredDataPanaLa"),false);   
 }
}

//Adaugat:		Oprescu Claudia
//Data:			07.02.2007
//Descriere:	In functie de data de la incepere a contracului, sunt selectate lunile care apar pe interfata
//				pentru cele sase venituri brute anterioare datei angajarii
function AscundeControaleVenituriBrute()
{	
	//se obtine de pe interfata data de incepere a angajarii 
	var dataDeLa = document.getElementById("txtDataDeLa").value;
	//se obtine luna specificata
	var luna = dataDeLa.split('.');
	//se obtine anul secificat
	var an = luna[2];
	//sirul cu textul pentru lunile anului
	var textLuni = new Array('Ianuarie', 'Februarie', 'Martie', 'Aprilie', 'Mai', 'Iunie', 'Iulie', 'August', 'Septembrie', 'Octombrie', 'Noiembrie', 'Decembrie');
	//sirul care va contine lunile ce apar pe interfata
	var textUltimeleLuni = new Array('', '', '', '', '', '');
	
	var j=0;
	var ramase=0;
	//se selecteaza descrescator lunile care apar pe interfata pana la terminarea anului
	for (i=luna[1]-2; i>=0; i--)
	{
		textUltimeleLuni[j] = textLuni[i] + " " + an;
		j++;
	}
	//daca s-a terminat anul, ar trebui selectate luni din anul anterior
	if (j<6)
	{
		//se determina numarul de luni care trebuie selecte din anul anterior
		ramase=6-j;
	}
	//se selecteaza denumirile lunilor ramanse din anul anterior
	for (i=11; (i>=0) && (ramase>0); i--)
	{
		textUltimeleLuni[j] = textLuni[i] + " " + (an - 1);
		j++;
		ramase--;
	}
	
	//sunt completate denumirile lunilor pe interfata
	document.getElementById('txtLuna1').innerText = textUltimeleLuni[5];
	document.getElementById('txtLuna2').innerText = textUltimeleLuni[4];
	document.getElementById('txtLuna3').innerText = textUltimeleLuni[3];
	document.getElementById('txtLuna4').innerText = textUltimeleLuni[2];
	document.getElementById('txtLuna5').innerText = textUltimeleLuni[1];
	document.getElementById('txtLuna6').innerText = textUltimeleLuni[0];
	
	liniaAscunsa.style.display='none';
	//daca a fost selectat butonul "Da" sunt ascunse controalele de pe interfata
	if(Form1.radioDa.checked)
	{
		document.getElementById("txtCAS1").value='';
		document.getElementById("txtCAS2").value='';
		document.getElementById("txtCAS3").value='';
		document.getElementById("txtCAS4").value='';
		document.getElementById("txtCAS5").value='';
		document.getElementById("txtCAS6").value='';
		luna1CAS.style.display='none';
		luna2CAS.style.display='none';
		luna3CAS.style.display='none';
		luna4CAS.style.display='none';
		luna5CAS.style.display='none';
		luna6CAS.style.display='none';
		separator1.style.display='none';
		separator2.style.display='none';
		separator3.style.display='none';
		separator4.style.display='none';
		separator5.style.display='none';
	}
	//altfel sunt afisate controalele pe interfata
	else
	{
		luna1CAS.style.display='';
		luna2CAS.style.display='';
		luna3CAS.style.display='';
		luna4CAS.style.display='';
		luna5CAS.style.display='';
		luna6CAS.style.display='';
		separator1.style.display='';
		separator2.style.display='';
		separator3.style.display='';
		separator4.style.display='';
		separator5.style.display='';
	}
}

function SelectLocMunca()
{
//daca nu a fost introdusa o data de incepere a perioadei de angajare
if ( document.getElementById("txtDataDeLa").value=='')
{
	//nu se pot specifica nici valori pentru cele sase venituri brute snterioare angajarii
	alert('Nu se pot specifica valorile veniturilor brute daca nu a fost completata data de angajare!');
	Form1.radioDa.checked = true;
}
//exista deja o data de incepere a perioadei de angajare
else
{	
	//sunt completate valorile lunilor de pe interfata si se stabileste stara controalelor pentru cele sase venituri brute
	AscundeControaleVenituriBrute();
}
}

//Lungu Andreea 26.05.2008
function PunctLucruChanged(punctLucru)
{
	document.getElementById( PunctLucruHiddenClient ).value = punctLucru.value;
	var i = 0;
	while( i<sirPuncteLucru.length )
	{
		if (punctLucru.value == sirPuncteLucru[i][0])
		{
			var drpCaseDeAsig = document.getElementById(drpCaseDeAsigClient);
			var c =0;
			for ( c = 0; c < drpCaseDeAsig.length; c++ ) 
			{
				if ( drpCaseDeAsig.options[c].value == sirPuncteLucru[i][2] )
				{
					drpCaseDeAsig.selectedIndex = c;
				}
			}
		}
		i++;
	}
	CaseDeAsigChanged(drpCaseDeAsig);
}

function CaseDeAsigChanged(casaDeAsig)
{
	document.getElementById( CaseDeAsigHiddenClient ).value = casaDeAsig.value;
	//alert(document.getElementById( CaseDeAsigHiddenClient ).value);
}

function FirstPunctLucru()
{
	var drpPuncteLucru = document.getElementById(drpPuncteLucruClient);
	var drpCaseDeAsig = document.getElementById(drpCaseDeAsigClient);
	PunctLucruChanged(drpPuncteLucru);
}

//Lungu Andreea - 28.07.2008
function FirstCategorie()
{
	var drpCategorii = document.getElementById(drpCategorieClient);
	var drpFunctii = document.getElementById(drpFunctieClient);
	lstCategoriiChanged(drpCategorii);
}

function lstCategoriiChanged(categ)
{
	document.getElementById( categorieIdHiddenClient ).value = categ.value;
	GolesteLstFunctii();
	UmpleLstFunctii(categ);
}

function UmpleLstFunctii(categorii)
{
	document.getElementById( categorieIdHiddenClient ).value = categorii.value;
	var i = 0;
	var functiiCombo = document.getElementById( drpFunctieClient );
	var scutireImpozit;
	//nu prea e ok :(
	if (categorii.options[categorii.selectedIndex].text == 'Angajat scutit de impozit')
		scutireImpozit = 'Da';
	else
		scutireImpozit = 'Nu';
	for( i=0; i<sirFunctii.length; i++ )
	{
		if (scutireImpozit == 'Nu')
		{
			var o = new Option();
			o.text = sirFunctii[i][1];
			o.value = sirFunctii[i][0];
			functiiCombo.add( o, i );
		}
		else
		{
			if (sirFunctii[i][2] == scutireImpozit)
			{
				var o = new Option();
				o.text = sirFunctii[i][1];
				o.value = sirFunctii[i][0];
				functiiCombo.add( o, i );
			}
		}
	}
	document.getElementById( functieIdHiddenClient ).value = functiiCombo.value;
}

function GolesteLstFunctii()
{
	var functiiCombo = document.getElementById( drpFunctieClient );
	while( functiiCombo.length > 0 )
	{
		functiiCombo.remove( functiiCombo.selectedIndex );
	}
}

function lstFunctiiChanged(functii)
{
	document.getElementById( functieIdHiddenClient ).value = functii.value;
}

//Lungu Andreea - 29.07.2008
//primeste ca parametru sirul de functii, dar ca string - reconstruieste sirFunctii
function CreazaSirFunctii(functii)
{
	sirFunctii = new Array();
	var elemente = functii.split(';');
	var i = 0;
	for (i = 0; i< elemente.length; i++)
	{
		var elem = elemente[i].split(',');
		sirFunctii[i] = new Array();
		sirFunctii[i][0] = elem[0].substring(1);
		sirFunctii[i][1] = elem[1];
		sirFunctii[i][2] = elem[2].substring(0, elem[2].length-1);
	}
	var categorii = document.getElementById(drpCategorieClient);
	lstCategoriiChanged(categorii);
}

function lstDTaraChanged( dTara)
{
	document.getElementById( DTaraHiddenClient ).value = dTara.value;
	NationalitateChanged();
		
	GolesteLstDJudet();
	UmpleLstDJudetEx( dTara.value);
}

function UmpleLstDJudetEx( tara_value)
{
	var i=0; 
	while( i<tari[ 1 ].length )
	{
		if( tara_value == tari[ 1 ][ i ] )
		{
			UmpleLstDJudet( i );
		}
		i++;
	}
}


function GolesteLstDJudet()
{
	var judCombo = document.getElementById( lstDJudeteClient );
	while( judCombo.length > 0 )
	{
		judCombo.remove( judCombo.selectedIndex );
	}
}

function UmpleLstDJudet( index )
{
	var judCombo = document.getElementById( lstDJudeteClient );
	
	if ( judeteText[index][0] != null)
	{	
		for( i=0; i<judeteText[ index ].length; i++ )
		{
			var o = new Option();
			o.text = judeteText[ index ][ i ];
			o.value = judeteValue[ index ][ i ];
			judCombo.add( o, i );
		}
	}
	
	document.getElementById( DJudetHiddenClient ).value = judCombo.value;
}


function lstRTaraChanged( rTara)
{
	document.getElementById( RTaraHiddenClient ).value = rTara.value;
	GolesteLstRJudet();
	UmpleLstRJudetEx( rTara.value);	

}

function UmpleLstRJudetEx( tara_value)
{
	var i = 0;
	while( i<tari[ 1 ].length)
	{
		if( tara_value==tari[ 1 ][ i ] )
		{
			UmpleLstRJudet( i );
		}
		i++;
	}
}

function GolesteLstRJudet()
{
	var judCombo = document.getElementById( lstRJudeteClient );
	while( judCombo.length > 0 )
	{
		judCombo.remove( judCombo.selectedIndex );
	}
}

function UmpleLstRJudet( index )
{
	var judCombo = document.getElementById( lstRJudeteClient );
	if ( judeteText[index][0] != null)
	{
		for( i=0; i<judeteText[ index ].length; i++ )
		{
			var o = new Option();
			o.text = judeteText[ index ][ i ];
			o.value = judeteValue[ index ][ i ];
			judCombo.add( o, i );
		}
	}
	document.getElementById( RJudetHiddenClient ).value = judCombo.value;
}

function lstDJudetSectorChanged( dJudet )
{
	document.getElementById( DJudetHiddenClient ).value = dJudet.value;
}

function lstRJudetSectorChanged( rJudet )
{
	document.getElementById( RJudetHiddenClient ).value = rJudet.value;
}

//pentru tara si judetul de nastere
function lstTaraNastereChanged( taraN )
{
	document.getElementById( TaraNastereHiddenClient ).value = taraN.value;
	
	GolesteLstJudetNastere();
	UmpleLstJudetNastereEx( taraN.value);
}

function UmpleLstJudetNastereEx( tara_value)
{
	for( i=0; i<tari[ 1 ].length; i++ )
	{
		if( tara_value==tari[ 1 ][ i ] )
		{
			UmpleLstJudetNastere( i );
			break;
		}
	}
}

function GolesteLstJudetNastere()
{
	var judCombo = document.getElementById( lstJudetNastereClient );
	while( judCombo.length > 0 )
	{
		judCombo.remove( judCombo.selectedIndex );
	}
}

function UmpleLstJudetNastere( index )
{
	var judCombo = document.getElementById( lstJudetNastereClient );
	if ( judeteText[index][0] != null)
	{
		for( i=0; i<judeteText[ index ].length; i++ )
		{
			var o = new Option();
			o.text = judeteText[ index ][ i ];
			o.value = judeteValue[ index ][ i ];
			judCombo.add( o, i );
		}
	}
	document.getElementById( JudetNastereHiddenClient ).value = judCombo.value;	
}

function lstJudetNastereChanged( judetN )
{
	document.getElementById( JudetNastereHiddenClient ).value = judetN.value;
}

//Calculeaza coordonata - x a coltului stanga sus a unei ferestre noi pt a fi pozitionata pe centru
function Calculate_x_coordinate( window_width)
{
	return (screen.width - window_width)/2;
}

//Calculeaza coordonata - y a coltului stanga sus a unei ferestre noi pt a fi pozitionata pe centru
function Calculate_y_coordinate( window_height)
{
	return (screen.height - window_height)/2;
}

//Deschide o fereastra noua in care se va incarca fereastra de admin pt invaliditati, titluri, studii sau categorii
function OpenAdminWindow( typeOfAdminPage)
{
	
	switch (typeOfAdminPage)
	{
		case "titluri":
			h = Calculate_y_coordinate( 250);
			w = Calculate_x_coordinate( 600);
			oNewWindow = window.open("Administrare/AdminTitluriAngajatiAddAngajat.aspx",null,"height=250,width=600, top=" + h + ",left=" + w + ",status=yes,toolbar=no,menubar=no,location=no,scrollbars=yes");
			oNewWindow.focus();
			break;
		case "studii":
			h = Calculate_y_coordinate( 250);
			w = Calculate_x_coordinate( 700);
			oNewWindow = window.open("Administrare/AdminStudiiAngajatiAddAngajat.aspx",null,"height=250,width=700, top=" + h + ",left=" + w + " ,status=yes,toolbar=no,menubar=no,location=no,scrollbars=yes");
			oNewWindow.focus();
			break;
		case "categorii":
			h = Calculate_y_coordinate( 400);
			w = Calculate_x_coordinate( 800);
			oNewWindow = window.open("InterfataSalarii/AdminCategoriiAngajati_AddAngajat.aspx",null,"height=400,width=800, top=" + h + ",left=" + w + " ,status=yes,toolbar=no,menubar=no,location=no,scrollbars=yes");
			oNewWindow.focus();
			break;
		case "invaliditati":
			h = Calculate_y_coordinate( 300);
			w = Calculate_x_coordinate( 600);
			oNewWindow = window.open("Administrare/AdminInvaliditatiAddAngajat.aspx",null,"height=300,width=600, top=" + h + ",left=" + w + " ,status=yes,toolbar=no,menubar=no,location=no,scrollbars=yes");
			oNewWindow.focus();
			break;
		case "tari":
			h = Calculate_y_coordinate( 300);
			w = Calculate_x_coordinate( 600);
			oNewWindow = window.open("Administrare/AdminTariAddAngajat.aspx",null,"height=300,width=600, top=" + h + ",left=" + w + " ,status=yes,toolbar=no,menubar=no,location=no,scrollbars=yes");
			oNewWindow.focus();
			break;
		case "judete":
			h = Calculate_y_coordinate( 300);
			w = Calculate_x_coordinate( 600);
			oNewWindow = window.open("Administrare/AdminJudeteAddAngajat.aspx",null,"height=300,width=600, top=" + h + ",left=" + w + " ,status=yes,toolbar=no,menubar=no,location=no,scrollbars=yes");
			oNewWindow.focus();
			break;
		case "functii":
			h = Calculate_y_coordinate( 700);
			w = Calculate_x_coordinate( 900);
			var oNewWindow = window.open("Administrare/AdminFunctiiAddAngajat.aspx",null,"height=700,width=900, top=" + h + ",left=" + w + " ,status=yes,toolbar=no,menubar=no,location=no,scrollbars=yes");
			oNewWindow.focus();
			break;
		case "departamente":
			h = Calculate_y_coordinate( 500);
			w = Calculate_x_coordinate( 800);
			oNewWindow = window.open("Administrare/AdminDepartamenteIstoricDepartamente.aspx",null,"height=500,width=800, top=" + h + ",left=" + w + " ,status=yes,toolbar=no,menubar=no,location=no,scrollbars=yes");
			oNewWindow.focus();
			break;
		/*case "centre_de_cost":
			h = Calculate_y_coordinate( 300);
			w = Calculate_x_coordinate( 600);
			oNewWindow = window.open("Administrare/AdminCentreCost_IstoricCentreCost.aspx",null,"height=300,width=600, top=" + h + ",left=" + w + " ,status=yes,toolbar=no,menubar=no,location=no,scrollbars=yes");
			oNewWindow.focus();
			break;*/
		default:
			break;
	}
}	

//Sterge toate intrarile din combo-ul cu departamente
function DeleteDepartamenteCombo()
{
	var departamenteCombo = document.getElementById( 'lstDepartament' ); 
	while( departamenteCombo.length > 0 )
	{
		departamenteCombo.remove( departamenteCombo.selectedIndex );
	}
}

//Adauga o intrare la la combo-ul cu departamente
function FillDepartamentCombo( departamentText, departamentValoare)
{
	var departamenteCombo = document.getElementById( 'lstDepartament' );
	var o = new Option();
	o.text = departamentText;
	o.value = departamentValoare;
	departamenteCombo.add( o, departamenteCombo.length ); 
}	

//Sterge toate intrarile din combo-ul cu centre de cost
function DeleteCentreCostCombo()
{
	var centreCost = document.getElementById( 'lstCentruDeCost' ); 
	while( centreCost.length > 0 )
	{
		centreCost.remove( centreCost.selectedIndex );
	}
}

//Adauga o intrare la la combo-ul cu centre de cost
function FillCentruCostCombo( centruCostText, centruCostValoare)
{
	var centreCost = document.getElementById( 'lstCentruDeCost' );
	var o = new Option();
	o.text = centruCostText;
	o.value = centruCostValoare;
	centreCost.add( o, 0 ); 
}	

//Sterge toate intrarile din combo-ul cu titluri
function DeleteTitluCombo()
{
	var titluriCombo = document.getElementById( 'lstTitlu' ); 
	while( titluriCombo.length > 0 )
	{
		titluriCombo.remove( titluriCombo.selectedIndex );
	}
}

//Adauga o intrare la la combo-ul cu titluri
function FillTitluCombo( titluText, titluValoare)
{
	var titluriCombo = document.getElementById( 'lstTitlu' );
	var o = new Option();
	o.text = titluText;
	o.value = titluValoare;
	titluriCombo.add( o, 0 ); 
}

//Sterge toate intrarile din combo-ul cu studii
function DeleteStudiiCombo()
{
	var studiiCombo = document.getElementById( 'lstStudiu' ); 
	while( studiiCombo.length > 0 )
	{
		studiiCombo.remove( studiiCombo.selectedIndex );
	}
}

//Adauga o intrare la combo-ul cu studii
function FillStudiuCombo( studiuText, studiuValoare)
{
	var studiiCombo = document.getElementById( 'lstStudiu' );
	var o = new Option();
	o.text = studiuText;
	o.value = studiuValoare;
	studiiCombo.add( o, 0 ); 
}

//Sterge toate intrarile din combo-ul cu categorii
function DeleteCategoriiCombo()
{
	var categoriiCombo = document.getElementById( 'lstCategorie' ); 
	while( categoriiCombo.length > 0 )
	{
		categoriiCombo.remove( categoriiCombo.selectedIndex );
	}
}

//Adauga o intrare la combo-ul cu categorii
function FillCategorieCombo( categorieText, categorieValoare)
{
	var categoriiCombo = document.getElementById( 'lstCategorie' );
	var o = new Option();
	o.text = categorieText;
	o.value = categorieValoare;
	categoriiCombo.add( o, 0 ); 
}

//Sterge toate intrarile din combo-ul cu invaliditati
function DeleteInvaliditatiCombo()
{
	var invaliditatiCombo = document.getElementById( 'chkLstInvalid' ); 
	while( invaliditatiCombo.length > 0 )
	{
		invaliditatiCombo.remove( invaliditatiCombo.selectedIndex );
	}
}

//Adauga o intrare la combo-ul cu invaliditati
function FillInvaliditateCombo( invaliditateText, invaliditateValoare)
{
	var invaliditatiCombo = document.getElementById( 'chkLstInvalid' );
	var o = new Option();
	o.text = invaliditateText;
	o.value = invaliditateValoare;
	invaliditatiCombo.add( o, 0 ); 
}

//Recreaza unul din sirurile necesare pt display-ul comboului cu judete
function RecreateArray_TariJudete ( _type, _len)
{
	switch ( _type)
	{
		case "tari":
			tari = new Array( _len);
			break;
		case "judeteText":
			judeteText = new Array( _len);		
			break;
		case "judeteValue":
			judeteValue = new Array( _len);
			break;
		default:
			break;
	}
}

//Recreaza o linie specifica din unul din sirurile necesate pt display-ul comboului cu judete
function RecreateLine_TariJudete( _type, number_of_line, len_line)
{
	switch ( _type)
	{
		case "tari":
			tari[number_of_line] = new Array( len_line);
			break;
		case "judeteText":
			judeteText[number_of_line] = new Array( len_line);
			break;
		case "judeteValue":
			judeteValue[number_of_line] = new Array( len_line);
			break;
		default:
			break;
	}
}

//Seteaza variabila tari cu noile valori
function SetTari( i, j, newTari)
{
	tari[i][j] = newTari;
}

//Seteaza variabila judeteText cu noile valori
function SetJudeteText( i, j, newJudeteText)
{
	judeteText[i][j] = newJudeteText;
}

//Seteaza variabila judeteValue cu noile valori
function SetJudeteValue( i, j, newJudeteValue)
{
	judeteValue[i][j] = newJudeteValue;
}

//Sterge toate intrarile din combo-ul cu tari
function DeleteTariCombo()
{
	//stergem continutul combo-ului cu tari din sectiunea ... Date domiciliu
	var tariCombo = document.getElementById( 'lstDTara' ); 
	while( tariCombo.length > 0 )
	{
		tariCombo.remove( tariCombo.selectedIndex );
	}
	
	//stergem continutul combo-ului cu tari din sectiunea ... Date resedinta
	var tariCombo = document.getElementById( 'lstRTara' ); 
	while( tariCombo.length > 0 )
	{
		tariCombo.remove( tariCombo.selectedIndex );
	}
	
	//stergem continutul combo-ului cu tari din sectiunea ... Buletin\Pasaport
	var tariCombo = document.getElementById( 'lstTaraNastere' ); 
	while( tariCombo.length > 0 )
	{
		tariCombo.remove( tariCombo.selectedIndex );
	}
}

//Adauga o intrare la combo-ul cu tari
function FillTaraCombo( taraText, taraValoare)
{
	//adaugam o optiune in combo-ul cu tari din sectiunea ... Date domiciliu
	var tariCombo = document.getElementById( 'lstDTara' );
	var o = new Option();
	o.text = taraText;
	o.value = taraValoare;
	tariCombo.add( o, 0 );
	
	//adaugam o optiune in combo-ul cu tari din sectiunea ... Date domiciliu
	var tariCombo = document.getElementById( 'lstRTara' );
	var o = new Option();
	o.text = taraText;
	o.value = taraValoare;
	tariCombo.add( o, 0 );
	
	//adaugam o optiune in combo-ul cu tari din sectiunea ... Buletin\Pasaport
	var tariCombo = document.getElementById( 'lstTaraNastere' );
	var o = new Option();
	o.text = taraText;
	o.value = taraValoare;
	tariCombo.add( o, 0 );
}

function SyncronizeTaraJudete()
{
	//Golim combo-urile cu judete
	GolesteLstDJudet();
	GolesteLstRJudet();
	GolesteLstJudetNastere();
	
	//pt fiecare combo cu tari sincronizam combo-ul atasat cu judete
	var tariDCombo = document.getElementById( 'lstDTara' );
	UmpleLstDJudetEx( tariDCombo.value);
	var tariRCombo = document.getElementById( 'lstRTara' );
	UmpleLstRJudetEx( tariRCombo.value);
	var taraNastereCombo = document.getElementById( 'lstTaraNastere' );
	UmpleLstJudetNastereEx( taraNastereCombo.value);
}

//Sterge toate intrarile din combo-ul cu judete
function DeleteJudeteCombo()
{
	//stergem continutul comboul-ui cu judete din sectiunea ... Date domiciliu
	var judeteCombo = document.getElementById( 'lstDJudetSector' ); 
	while( judeteCombo.length > 0 )
	{
		judeteCombo.remove( judeteCombo.selectedIndex );
	}
	
	//stergem continutul comboul-ui cu judete din sectiunea ... Date resedinta
	var judeteCombo = document.getElementById( 'lstRJudetSector' ); 
	while( judeteCombo.length > 0 )
	{
		judeteCombo.remove( judeteCombo.selectedIndex );
	}
	
	//stergem continutul comboul-ui cu judete din sectiunea ... Buletin - Pasaport
	var judeteCombo = document.getElementById( 'lstJudetNastere' ); 
	while( judeteCombo.length > 0 )
	{
		judeteCombo.remove( judeteCombo.selectedIndex );
	}
}

//Adauga o intrare la combo-ul cu judete
function FillJudetCombo( judetText, judetValoare)
{
	//adaugam o optiune in combo-ul cu judete din sectiunea ... Date domiciliu
	var judeteCombo = document.getElementById( 'lstDJudetSector' );
	var o = new Option();
	o.text = judetText;
	o.value = judetValoare;
	judeteCombo.add( o, 0 );
	
	//adaugam o optiune in combo-ul cu judete din sectiunea ... Date domiciliu
	var judeteCombo = document.getElementById( 'lstRJudetSector' );
	var o = new Option();
	o.text = judetText;
	o.value = judetValoare;
	judeteCombo.add( o, 0 );
	
	//adaugam o optiune in combo-ul cu judete din sectiunea ... Buletin - Pasaport
	var judeteCombo = document.getElementById( 'lstJudetNastere' );
	var o = new Option();
	o.text = judetText;
	o.value = judetValoare;
	judeteCombo.add( o, 0 );
}

//Sterge toate intrarile din combo-ul cu functii
function DeleteFunctiiCombo()
{
	var functiiCombo = document.getElementById( 'lstFunctie' ); 
	while( functiiCombo.length > 0 )
	{
		functiiCombo.remove( functiiCombo.selectedIndex );
	}
}

//Adauga o intrare la la combo-ul cu functii
//Modificat Lungu Andreea 28.07.2008
function FillFunctieCombo( functieText, functieValoare)
{
	var categorii = document.getElementById(drpCategorieClient);
	if (categorii.options[categorii.selectedIndex].text == 'Angajat scutit de impozit')
		scutireImpozit = 'Da';
	else
		scutireImpozit = 'Nu';
	var functiiCombo = document.getElementById( 'lstFunctie' );
	var i = 0;
	for ( i=0; i<sirFunctii.length; i++)
	{
		if (sirFunctii[i][0] == functieValoare)
		{
			if (scutireImpozit == 'Nu')
			{
				var o = new Option();
				o.text = sirFunctii[i][1];
				o.value = sirFunctii[i][0];
				functiiCombo.add( o, i );
			}
			else
			{
				if (sirFunctii[i][2] == scutireImpozit)
				{
					var o = new Option();
					o.text = sirFunctii[i][1];
					o.value = sirFunctii[i][0];
					functiiCombo.add( o, i );
				}
			}
		}
	} 
}
//Cristina Muntean
//daca in cadrul sectiunii alte date este selectata intr-un dropdownlist opriunea "DA" trebuie facut vizibil textbox-ul
//corespunzator dropdownlist-ului
function SetTextBoxVisible(opt)
{	
	switch (opt)
	{
		case 'Ep':
				var optiune = document.getElementById(drpEchIndProtectieClient).value;
				//var txt = document.getElementById(txtEchIndLucruClient).value;
				if(optiune=="DA")
					document.getElementById(txtEchIndProtectieClient).style.display = "";
				else
					document.getElementById(txtEchIndProtectieClient).style.display = "none";
				break;
		case 'El':
				var optiune = document.getElementById(drpEchIndLucruClient).value;
				//var txt = document.getElementById(txtEchIndLucruClient).value;
				if(optiune=="DA")
					document.getElementById(txtEchIndLucruClient).style.display = "";
				else
					document.getElementById(txtEchIndLucruClient).style.display = "none";
				break;
		case 'Mis':
				var optiune = document.getElementById(drpMatIgiSanClient).value;
				//var txt = document.getElementById(txtEchIndLucruClient).value;
				if(optiune=="DA")
					document.getElementById(txtMatIgiSanClient).style.display = "";
				else
					document.getElementById(txtMatIgiSanClient).style.display = "none";
				break;
		case 'Ap':
				var optiune = document.getElementById(drpAlimProtectieClient).value;
				//var txt = document.getElementById(txtEchIndLucruClient).value;
				if(optiune=="DA")
					document.getElementById(txtAlimProtectieClient).style.display = "";
				else
					document.getElementById(txtAlimProtectieClient).style.display = "none";
				break;
		case 'Ado':
				var optiune = document.getElementById(drpAlteDrSiOblClient).value;
				//var txt = document.getElementById(txtEchIndLucruClient).value;
				if(optiune=="DA")
					document.getElementById(txtAlteDrSiOblClient).style.display = "";
				else
					document.getElementById(txtAlteDrSiOblClient).style.display = "none";
				break;		
	}
}


	//vlad
	//Evenimentul de schimbare a nationalitatii sau a tarii de domiciliu
	function NationalitateChanged()
	{
		//DeleteOptiuneVidaTaraNastere();
		if( document.getElementById( NationalitateClinet ).value == taraBazaID )
		{
			if( document.getElementById( DTaraHiddenClient ).value == taraBazaID )
			{
				SpanBuletinVisible( true );
				SpanPasaportVisible( false );
				
				tableBuletin.style.display = "";
				tablePasaport.style.display = "";
				tablePermisMunca.style.display = "none";
				tableLegitimatieSedere.style.display = "none";
				tableNIF.style.display = "none";
				//DeleteOptiuneVidaTaraNastere();
			}
			else
			{
				SpanPasaportVisible( true );
				SpanLegitimatieSedereVisible( false );
				SpanNIFVisible( false );
				
				tableBuletin.style.display = "";
				tablePasaport.style.display = "";
				tablePermisMunca.style.display = "none";
				tableLegitimatieSedere.style.display = "";
				tableNIF.style.display = "";
				//adaugare de linie vida in DTaraNastere
				//AddOptiuneVidaTaraNastere();
			}
		}
		else
		{
			SpanPasaportVisible( true );
			SpanPermisMuncaVisible( false );
			SpanLegitimatieSedereVisible( false );
			SpanNIFVisible( false );
				
			//SpanBuletinVisible( false );
			tableBuletin.style.display = "none";
			tablePasaport.style.display = "";
			tablePermisMunca.style.display = "";
			tableLegitimatieSedere.style.display = "";
			tableNIF.style.display = "";
		}
	}
	
	/*function AddOptiuneVidaTaraNastere()
	{
		var taraNastereCombo = document.getElementById( 'lstTaraNastere' );
		var o = new Option();
		o.text = "";
		o.value = -1;
		taraNastereCombo.add( o, 0 );
		taraNastereCombo.value = -1;
		
		GolesteLstJudetNastere();
	}
	
	function DeleteOptiuneVidaTaraNastere()
	{
		var taraNastereCombo = document.getElementById( 'lstTaraNastere' );
		taraNastereCombo.selectedIndex = 0;
		if( taraNastereCombo.value == -1 )
			taraNastereCombo.remove( 0 );
	}*/
	
	function SpanBuletinVisible( visibility )
	{
		var val = '';
		if( !visibility )
			val = 'none';
		spanCNP.style.display = val;
		/*spanDataNasterii.style.display = val;
		spanTaraNastere.style.display = val;
		spanJudetNastere.style.display = val;
		spanLocalitateNastere.style.display = val;
		spanPrenumeMama.style.display = val;
		spanPrenumeTata.style.display = val;*/
		spanSerieBI.style.display = val;
		spanNumarBI.style.display = val;
		spanEliberatDeBI.style.display = val;
		spanDataEliberareBI.style.display = val;
		spanDataExpirareBI.style.display = val;
	}
	
	function SpanPasaportVisible( visibility )
	{
		var val = '';
		if( !visibility )
			val = 'none';
		spanSeriePasaport.style.display = val;
		spanNumarPasaport.style.display = val;
		spanPasaportEliberatDe.style.display = val;
		spanDataEliberarePasaport.style.display = val;
		spanDataExpirarePasaport.style.display = val;
	}
	
	function SpanPermisMuncaVisible( visibility )
	{
		var val = '';
		if( !visibility )
			val = 'none';
		spanSeriePermisMunca.style.display = val;
		spanNumarPermisMunca.style.display = val;
		spanDataEliberarePermisMunca.style.display = val;
		spanDataExpirarePermisMunca.style.display = val;
	}
	
	function SpanLegitimatieSedereVisible( visibility )
	{
		var val = '';
		if( !visibility )
			val = 'none';
		spanSerieLegitimatieSedere.style.display = val;
		spanNumarLegitimatieSedere.style.display = val;
		spanDataEliberareLegitimatieSedere.style.display = val;
		spanDataExpirareLegitimatieSedere.style.display = val;
	}
	
	function SpanNIFVisible( visibility )
	{
		var val = '';
		if( !visibility )
			val = 'none';
		spanNIF.style.display = val;
	}
	
	function AdaugaAlerteInHiddenText()
	{
		//cream un sir cu toate alertele si il stocam in controlul hidden txtAlerteHidden
		var txtHidden = document.getElementById( 'txtAlerteHidden' );
		var alerteList = document.getElementById( 'lstAlerteSpeciale' );
		var alerteSpeciale = '';
		if (alerteList.length != 0)
		{
			alerteSpeciale = alerteList.options[0].text;
		}
		for( i=1; i<alerteList.length; i++)
		{
			alerteSpeciale = alerteSpeciale + ',' + alerteList.options[i].text;
		}
		txtHidden.value = alerteSpeciale;
	}
	
	function ButSaveAngajatInput_Click()
	{
		var potSalva = true;
		if( document.getElementById( 'TaraBazaIDHidden' ).value == document.getElementById( 'lstNationalitate' ).value )
		{
			potSalva = VerificaDateBuletin();
			if( document.getElementById( 'TaraBazaIDHidden' ).value != document.getElementById( 'lstDTara' ).value )
			{
				potSalva = potSalva && VerificaDatePasaport();
			}
		}
		else
		{
			potSalva = VerificaDatePasaport();
		}
		
		if( potSalva )
		{
			AdaugaAlerteInHiddenText();	
			document.getElementById( 'butSaveAngajat' ).click();
		}
	}
	
	function VerificaDateBuletin()
	{
		var alertText = 'Nu ati completat la buletin:';
		if( document.getElementById( 'txtCNP' ).value == '' )
			alertText = alertText+'\n\t Cod numeric personal';
		if( document.getElementById( 'txtCISerie' ).value == '' )
			alertText = alertText+'\n\t Serie carte identitate';
		if( document.getElementById( 'txtCINumar' ).value == '' )
			alertText = alertText+'\n\t Numar carte identitate';
		if( document.getElementById( 'txtCIEliberatDe' ).value == '' )
			alertText = alertText+'\n\t Eliberat de';
		if( document.getElementById( 'txtCIDataEliberarii' ).value == '' )
			alertText = alertText+'\n\t Data eliberarii';
		if( document.getElementById( 'txtCIValabilPanaLa' ).value == '' )
			alertText = alertText+'\n\t Valabil pana la';
		if( alertText == 'Nu ati completat la buletin:' )
			return true;
		else
		{
			alert( alertText );
			return false;
		}
	}
	
	function VerificaDatePasaport()
	{
		var alertText = 'Nu ati completat la pasaport:';
		if( document.getElementById( 'txtPASSerie' ).value == '' )
			alertText = alertText+'\n\t Serie pasaport';
		if( document.getElementById( 'txtPASNumar' ).value == '' )
			alertText = alertText+'\n\t Numar pasaport';
		if( document.getElementById( 'txtPASEliberatDe' ).value == '' )
			alertText = alertText+'\n\t Eliberat de';
		if( document.getElementById( 'txtPASDataEliberarii' ).value == '' )
			alertText = alertText+'\n\t Data eliberarii';
		if( document.getElementById( 'txtPASValabilPanaLa' ).value == '' )
			alertText = alertText+'\n\t Valabil pana la';
		if( alertText == 'Nu ati completat la pasaport:' )
			return true;
		else
		{
			alert( alertText );
			return false;
		}
	}

//Popa Ionel
//Verifica daca o alerta este deja in lista cu alerte
function ExistaAlerta( textAlerta)
{
	var alerteList = document.getElementById( 'lstAlerteSpeciale' );
	for ( i=0; i<alerteList.length; i++)
	{
		if ( alerteList.options[i].text.toString() == textAlerta.toString())
			return true;
	}
	return false;
	
}

//Popa Ionel
//Insereaza o alerta in lista cu alerte
function InserareAlerta()
{
	var alerteList = document.getElementById( 'lstAlerteSpeciale' );
	var descriereAlerta = document.getElementById( 'txtDescriereAlerta' );
	var dataExpirare = document.getElementById( 'txtDataExpirare' );
	var perioadaCritica = document.getElementById( 'txtPerioadaCritica' );
	var checkActiv = document.getElementById( 'chkActiv');

	if ( descriereAlerta.value!='' && dataExpirare.value!='' &&  perioadaCritica.value!='' && !isNaN(perioadaCritica.value)  )
	{		
		var o = new Option();
		var textAlerta = descriereAlerta.value + ',' + dataExpirare.value + ',' + perioadaCritica.value;
		if ( checkActiv.checked)
			textAlerta = textAlerta + ',activa';
		else
			textAlerta = textAlerta + ',inactiva';
		
		if ( !ExistaAlerta(textAlerta))
		{
			o.text = textAlerta;
			o.value = alerteList.length+1;
			alerteList.add( o, 0 );
		}
		else
		{
			alert('Mai exista deja aceasta alerta!');
		}
	}
	else
	{
		alert("Introduceti valori corecte pentru campurile ''Descriere'', ''Data Expirare'' si ''Perioada Critica'' ");
	}
}


function StergeAlerte()
{
	var alerteList = document.getElementById( 'lstAlerteSpeciale' );
	if(alerteList.options.length!=0)
		if(alerteList.selectedIndex>=0)
			alerteList.remove( alerteList.selectedIndex );
		else
			alert("Trebuie sa selectati alerta pe care doriti sa o stergeti!");
	else
		alert("Nu exista nici o alerta in lista!");
}

//Oprescu Claudia
//selecteaza numele sefului in functie de departamentul selectat
function lstDepartamentChanged()
{
	var departament = document.getElementById('lstDepartament');
	for (i=0; i<sefDepartament[1].length; i++)
	{
		if (departament.options[ departament.selectedIndex ].value == sefDepartament[1][i])
		{
			document.getElementById( 'lstSef' ).value = sefDepartament[0][i];
		}
	}
}
		</script>
		<form id="Form1" encType="multipart/form-data" method="post" runat="server">
			<table border="0" cellSpacing="0" cellPadding="0" width="100%" align="center">
				<tr>
					<td style="WIDTH: 1990px"><uc1:pageheader id="PageHeader1" runat="server"></uc1:pageheader></td>
				</tr>
				<tr>
					<td style="WIDTH: 1990px" align="center"><uc1:headermenu id="HeaderMenu1" runat="server"></uc1:headermenu></td>
				</tr>
				<tr>
					<td style="WIDTH: 1990px">
						<table>
							<tr>
								<td class="NormalGreenBold">Luna activa :</td>
								<td class="NormalGreenBold"><asp:label id="labelLunaActiva" Runat="server"></asp:label></td>
							</tr>
						</table>
					</td>
				</tr>
				<tr>
					<td style="WIDTH: 1990px"><asp:literal id="litError" runat="server"></asp:literal></td>
				</tr>
				<tr>
					<td style="WIDTH: 1990px" align="center">
						<TABLE border="0" cellSpacing="0" cellPadding="0" width="730">
							<tr>
								<td colSpan="8"><IMG src="images/1x1.gif" height="20"></td>
							</tr>
							<tr>
								<td class="BigBlueBold" colSpan="8" align="center">Formular de introducere angajat 
									nou</td>
							</tr>
							<tr>
								<td colSpan="4"><IMG src="images/1x1.gif" height="20"></td>
							</tr>
							<tr>
								<td colSpan="4"><asp:table id="tableTabs" runat="server"></asp:table>
									<!-- 	<table cellpadding=0 cellspacing=0 border=0 height=24 width=100%>
			<tr>
				<td  width=40><img src="images/colt-tab.gif"></td>
				<td width=2><img height=100% src="images/separator-tab.gif"></td>
				<td class=tabActive  id=tab1 onmouseover=MouseOverTabs(this) onclick=SelectTab(0) onmouseout=MouseOutTabs(this) >Identificare</td>
				<td  width=2><img height=100% src="images/separator-tab.gif"></td>
				<td class=tab id=tab2  onmouseover=MouseOverTabs(this) onclick=SelectTab(1) onmouseout=MouseOutTabs(this)>Domiciliu - resedinta</td>			
				<td  width=2><img height=100% src="images/separator-tab.gif"></td>
				<td class=tab id=tab3  onmouseover=MouseOverTabs(this) onclick=SelectTab(2) onmouseout=MouseOutTabs(this)>Buletin - Pasaport</td>						
				<td  width=2><img height=100% src="images/separator-tab.gif"></td>
				<td class=tab id=tab4  onmouseover=MouseOverTabs(this) onclick=SelectTab(3) onmouseout=MouseOutTabs(this)>Date angajare</td>										
				<td  width=2><img height=100% src="images/separator-tab.gif"></td>
				<td  width=40><img src="images/colt-tab1.gif"></td>
			</tr>
			</table>--></td>
							<tr>
								<!--   DATE PERSONALE -->
								<td id="tableDatePersonale" class="tabBackground" colSpan="8">
									<TABLE border="0" cellSpacing="1" cellPadding="0" width="100%">
										<tr>
											<td class="HeaderGreenBold" colSpan="2" align="center">Date identificare persoana:</td>
										</tr>
										<TR>
											<TD style="HEIGHT: 21px" class="NormalGreenBold">Nume:</TD>
											<TD style="HEIGHT: 21px"><asp:textbox id="txtNume" runat="server" CssClass="NormalEditBoxuri" MaxLength="50" Width="150px"></asp:textbox><span class="CommentRedBold">*</span><asp:requiredfieldvalidator id="RequiredField_nume" runat="server" CssClass="AlertRedBold" ControlToValidate="txtNume"
													ErrorMessage="Completati numele angajatului!"><</asp:requiredfieldvalidator>
												<asp:regularexpressionvalidator id="regularNume" runat="server" CssClass="AlertRedBold" ControlToValidate="txtNume"
													ErrorMessage="Numele nu poate sa contina caractere invalide: <>()';&quot;\" ValidationExpression="^[^>|(|)|<|'|&quot;|;|\\]*$"><</asp:regularexpressionvalidator></TD>
										</TR>
										<tr>
											<td style="HEIGHT: 1px" class="GreenSeparator" colSpan="2"><IMG src="images/1x1.gif" height="1"></td>
										</tr>
										<TR>
											<TD class="NormalGreenBold">Prenume:</TD>
											<TD><asp:textbox id="txtPrenume" runat="server" CssClass="NormalEditBoxuri" MaxLength="50" Width="150px"></asp:textbox><span class="CommentRedBold">*</span><asp:requiredfieldvalidator id="RequiredField_prenume" runat="server" CssClass="AlertRedBold" ControlToValidate="txtPrenume"
													ErrorMessage="Completati prenumele angajatului!"><</asp:requiredfieldvalidator>
												<asp:regularexpressionvalidator id="regularPrenume" runat="server" CssClass="AlertRedBold" ControlToValidate="txtPrenume"
													ErrorMessage="Prenumele nu poate sa contina caractere invalide: <>()';&quot;\" ValidationExpression="^[^>|(|)|<|'|&quot;|;|\\]*$"><</asp:regularexpressionvalidator></TD>
										</TR>
										<tr>
											<td class="GreenSeparator" colSpan="2"><IMG src="images/1x1.gif" height="1"></td>
										</tr>
										<TR>
											<TD class="NormalGreenBold">Nume anterior:</TD>
											<TD class="NormalGreenBold"><asp:textbox id="txtNumeAnterior" runat="server" CssClass="NormalEditBoxuri" MaxLength="50" Width="150px"></asp:textbox><asp:regularexpressionvalidator id="regularNumeAnterior" runat="server" CssClass="AlertRedBold" ControlToValidate="txtNumeAnterior"
													ErrorMessage="Numele anterior nu poate sa contina caractere invalide: <>()';&quot;\" ValidationExpression="^[^>|(|)|<|'|&quot;|;|\\]*$"><</asp:regularexpressionvalidator>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
												Data schimbarii numelui:
												<asp:textbox style="Z-INDEX: 0; CURSOR: hand" id="txtDataSchimbariiNumelui" onclick="ShowCalendar(this,'')"
													runat="server" CssClass="NormalEditBoxuri" Width="70px" ReadOnly="True"></asp:textbox>&nbsp;&nbsp;&nbsp;</TD>
										</TR>
										<tr>
											<td class="GreenSeparator" colSpan="2"><IMG src="images/1x1.gif" height="1"></td>
										</tr>
										<TR>
											<TD class="NormalGreenBold">Stare civila:</TD>
											<TD class="NormalGreenBold"><asp:dropdownlist id="lstStareCivila" runat="server" CssClass="SelectStyle" Width="150px">
													<asp:ListItem Value="0">Casatorit</asp:ListItem>
													<asp:ListItem Value="2">Divortat</asp:ListItem>
													<asp:ListItem Value="1">Necasatorit</asp:ListItem>
													<asp:ListItem Value="3">Vaduv</asp:ListItem>
												</asp:dropdownlist>&nbsp;&nbsp;&nbsp;&nbsp;</TD>
										</TR>
										<tr>
											<td class="GreenSeparator" colSpan="2"><IMG src="images/1x1.gif" height="1"></td>
										</tr>
										<TR>
											<TD style="HEIGHT: 21px" class="NormalGreenBold">Nr. copii:</TD>
											<TD style="HEIGHT: 21px"><asp:textbox id="txtNrCopii" runat="server" CssClass="NumericEditBoxuri" Width="70px">0</asp:textbox><asp:regularexpressionvalidator id="regularNrCopii" runat="server" CssClass="AlertRedBold" ControlToValidate="txtNrCopii"
													ErrorMessage="Nr. copii trebuie sa fie numeric!" ValidationExpression="\d*"><</asp:regularexpressionvalidator></TD>
										</TR>
										<tr>
											<td style="HEIGHT: 1px" class="GreenSeparator" colSpan="2"><IMG src="images/1x1.gif" height="1"></td>
										</tr>
										<TR>
											<TD style="HEIGHT: 16px" class="NormalGreenBold">Sex:</TD>
											<TD style="HEIGHT: 16px"><asp:dropdownlist id="lstSex" runat="server" CssClass="SelectStyle" Width="150px">
													<asp:ListItem Value="f">Feminin</asp:ListItem>
													<asp:ListItem Value="m">Masculin</asp:ListItem>
												</asp:dropdownlist></TD>
										</TR>
										<tr>
											<td class="GreenSeparator" colSpan="2"><IMG src="images/1x1.gif" height="1"></td>
										</tr>
										<tr>
											<TD style="HEIGHT: 16px" class="NormalGreenBold">Invaliditate:</TD>
											<td><asp:dropdownlist id="chkLstInvalid" runat="server" CssClass="SelectStyle" Width="150px"></asp:dropdownlist><INPUT onclick="javascript:OpenAdminWindow('invaliditati')" value="..." type="button">
											</td>
										</tr>
										<tr>
											<td class="GreenSeparator" colSpan="2"><IMG src="images/1x1.gif" height="1"></td>
										</tr>
										<TR>
											<TD class="NormalGreenBold">Titlu:</TD>
											<TD><asp:dropdownlist id="lstTitlu" runat="server" CssClass="SelectStyle" Width="350px"></asp:dropdownlist><INPUT onclick="javascript:OpenAdminWindow('titluri');" value="..." type="button">
											</TD>
										</TR>
										<tr>
											<td class="GreenSeparator" colSpan="2"><IMG src="images/1x1.gif" height="1"></td>
										</tr>
										<TR>
											<TD class="NormalGreenBold">Studii:</TD>
											<TD><asp:dropdownlist id="lstStudiu" runat="server" CssClass="SelectStyle" Width="350px"></asp:dropdownlist><INPUT onclick="javascript:OpenAdminWindow('studii')" value="..." type="button">
											</TD>
										</TR>
										<tr>
											<td class="GreenSeparator" colSpan="2"><IMG src="images/1x1.gif" height="1"></td>
										</tr>
										<TR>
											<TD class="NormalGreenBold">An Absolvire:</TD>
											<TD><asp:textbox id="txtAnAbsolvire" runat="server" CssClass="NumericEditBoxuri" MaxLength="4" Width="75px"></asp:textbox><SPAN class="CommentRedBold">*</SPAN><asp:rangevalidator id="vldAnAbsolvire" runat="server" CssClass="AlertRedBold" ControlToValidate="txtAnAbsolvire"
													ErrorMessage="Trebuie sa completati corect anul absolvirii!" MinimumValue="1900" MaximumValue="2500" Type="Integer"><</asp:rangevalidator>
												<asp:requiredfieldvalidator id="RequiredFieldValidator6" runat="server" CssClass="AlertRedBold" ControlToValidate="txtAnAbsolvire"
													ErrorMessage="Introduceti anul absovlirii!"><</asp:requiredfieldvalidator><span class="CommentRedBold"></span></TD>
										</TR>
										<tr>
											<td class="GreenSeparator" colSpan="2"><IMG src="images/1x1.gif" height="1"></td>
										</tr>
										<TR>
											<TD class="NormalGreenBold">Nr Diploma:</TD>
											<TD><asp:textbox id="txtNrDiploma" runat="server" CssClass="NumericEditBoxuri" MaxLength="50" Width="75px"></asp:textbox><asp:regularexpressionvalidator id="regularNrDiploma" runat="server" CssClass="AlertRedBold" ControlToValidate="txtNrDiploma"
													ErrorMessage="Numarul diplomei nu poate sa contina caractere invalide: <>()';&quot;\" ValidationExpression="^[^>|(|)|<|'|&quot;|;|\\]*$"><</asp:regularexpressionvalidator><span class="CommentRedBold"></span></TD>
										</TR>
										<tr>
											<td class="GreenSeparator" colSpan="2"><IMG src="images/1x1.gif" height="1"></td>
										</tr>
										<TR>
											<TD class="NormalGreenBold">Telefon:</TD>
											<td><asp:textbox id="txtTelefon" runat="server" CssClass="NormalEditBoxuri" MaxLength="25" Width="75px"></asp:textbox><asp:regularexpressionvalidator id="Regularexpressionvalidator2" runat="server" CssClass="AlertRedBold" ControlToValidate="txtTelefon"
													ErrorMessage="Pentru telefon trebuie introduse numai cifre!" ValidationExpression="\d*"><</asp:regularexpressionvalidator></td>
										</TR>
										<tr>
											<td class="GreenSeparator" colSpan="2"><IMG src="images/1x1.gif" height="1"></td>
										</tr>
										<TR>
											<TD class="NormalGreenBold">Descriere:</TD>
											<TD><asp:textbox id="txtDescriere" runat="server" CssClass="AreaStyle" Width="350px" TextMode="MultiLine"
													Height="60px" Rows="4" Columns="50"></asp:textbox></TD>
										</TR>
										<tr>
											<td class="GreenSeparator" colSpan="2"><IMG src="images/1x1.gif" height="1"></td>
										</tr>
										<TR>
											<TD class="NormalGreenBold">Poza:</TD>
											<TD><INPUT style="WIDTH: 350px; HEIGHT: 19px" id="filePozaAngajat" class="NormalEditBoxuri"
													size="38" type="file" name="File1" runat="server">
												<asp:regularexpressionvalidator id="regularPoza" runat="server" CssClass="AlertRedBold" ErrorMessage="Specificati corect denumirea pozei!"
													ControlToValidate="filePozaAngajat" ValidationExpression="^[^>|(|)|<|'|&quot;|;]*$"><</asp:regularexpressionvalidator></TD>
										</TR>
									</TABLE>
								</td>
								<!--   DOMICILIU - RESEDINTA -->
								<td id="tableDomiciliu" class="tabBackground" colSpan="8">
									<TABLE border="0" cellSpacing="1" cellPadding="0" width="100%">
										<tr>
											<td class="HeaderGreenBold" colSpan="2" align="center">Date domiciliu:</td>
											<td class="HeaderGreenBold" colSpan="2" align="center">Date resedinta:</td>
										</tr>
										<TR>
											<TD class="NormalGreenBold">Tara:</TD>
											<TD><asp:dropdownlist id="lstDTara" runat="server" CssClass="SelectStyle" Width="150px" AutoPostBack="False"
													onChange="lstDTaraChanged(this);"></asp:dropdownlist><INPUT onclick="javascript:OpenAdminWindow('tari')" value="..." type="button">
											</TD>
											<TD class="NormalGreenBold">Tara:</TD>
											<td><asp:dropdownlist id="lstRTara" runat="server" CssClass="SelectStyle" Width="150px" onChange="lstRTaraChanged(this);"></asp:dropdownlist><INPUT onclick="javascript:OpenAdminWindow('tari')" value="..." type="button">
											</td>
										</TR>
										<tr>
											<td class="GreenSeparator" colSpan="4"><IMG src="images/1x1.gif" height="1"></td>
										</tr>
										<TR>
											<TD class="NormalGreenBold">Judet/Sector:</TD>
											<TD><asp:dropdownlist id="lstDJudetSector" runat="server" CssClass="SelectStyle" Width="150px" onChange="lstDJudetSectorChanged(this);"></asp:dropdownlist><INPUT onclick="javascript:OpenAdminWindow('judete')" value="..." type="button">
											</TD>
											<TD class="NormalGreenBold">Judet/Sector:</TD>
											<TD><asp:dropdownlist id="lstRJudetSector" runat="server" CssClass="SelectStyle" Width="150px" onChange="lstRJudetSectorChanged(this);"></asp:dropdownlist><INPUT onclick="javascript:OpenAdminWindow('judete')" value="..." type="button">
											</TD>
										</TR>
										<tr>
											<td class="GreenSeparator" colSpan="4"><IMG src="images/1x1.gif" height="1"></td>
										</tr>
										<tr>
										<TR>
											<TD class="NormalGreenBold">Localitate:</TD>
											<TD><asp:textbox id="txtDLocalitate" runat="server" CssClass="NormalEditBoxuri" MaxLength="50" Width="130px"
													onChange="Form1.txtRLocalitate.value = this.value"></asp:textbox><span class="CommentRedBold">*</span>
												<asp:requiredfieldvalidator id="requiredDLocalitate" runat="server" CssClass="AlertRedBold" ControlToValidate="txtDLocalitate"
													ErrorMessage="Completati localitatea - domiciliu!"><</asp:requiredfieldvalidator><asp:regularexpressionvalidator id="regularLocalitate" runat="server" CssClass="AlertRedBold" ControlToValidate="txtDLocalitate"
													ErrorMessage="Localitatea nu poate sa contina caractere invalide: <>()';&quot;\ " ValidationExpression="^[^>|(|)|<|'|&quot;|;|\\]*$"><</asp:regularexpressionvalidator></TD>
											<TD class="NormalGreenBold">Localitate:</TD>
											<TD><asp:textbox id="txtRLocalitate" runat="server" CssClass="NormalEditBoxuri" MaxLength="50" Width="130px"></asp:textbox><span class="CommentRedBold">*</span>
												<asp:requiredfieldvalidator id="requiredRLocalitate" runat="server" CssClass="AlertRedBold" ControlToValidate="txtRLocalitate"
													ErrorMessage="Completati localitatea - resedinta!"><</asp:requiredfieldvalidator><asp:regularexpressionvalidator id="Regularexpressionvalidator4" runat="server" CssClass="AlertRedBold" ControlToValidate="txtRLocalitate"
													ErrorMessage="Localitatea nu poate sa contina caractere invalide: <>()';&quot;\ " ValidationExpression="^[^>|(|)|<|'|&quot;|;|\\]*$"><</asp:regularexpressionvalidator></TD>
										</TR>
										<TR>
											<td class="GreenSeparator" colSpan="4"><IMG src="images/1x1.gif" height="1"></td>
										</TR>
										<TR>
											<TD class="NormalGreenBold">Strada:</TD>
											<TD><asp:textbox id="txtDStrada" runat="server" CssClass="NormalEditBoxuri" MaxLength="50" Width="130px"
													onChange="Form1.txtRStrada.value = this.value"></asp:textbox><span class="CommentRedBold">*</span>
												<asp:requiredfieldvalidator id="requiredDStrada" runat="server" CssClass="AlertRedBold" ControlToValidate="txtDStrada"
													ErrorMessage="Completati strada - domiciliu!"><</asp:requiredfieldvalidator><asp:regularexpressionvalidator id="regularStrada" runat="server" CssClass="AlertRedBold" ControlToValidate="txtDStrada"
													ErrorMessage="Strada nu poate sa contina caractere invalide: <>()';&quot;\ " ValidationExpression="^[^>|(|)|<|'|&quot;|;|\\]*$"><</asp:regularexpressionvalidator></TD>
											<TD class="NormalGreenBold">Strada:</TD>
											<TD><asp:textbox id="txtRStrada" runat="server" CssClass="NormalEditBoxuri" MaxLength="50" Width="130px"></asp:textbox><span class="CommentRedBold">*</span>
												<asp:requiredfieldvalidator id="requiredRStrada" runat="server" CssClass="AlertRedBold" ControlToValidate="txtRStrada"
													ErrorMessage="Completati strada - resedinta!"><</asp:requiredfieldvalidator><asp:regularexpressionvalidator id="Regularexpressionvalidator5" runat="server" CssClass="AlertRedBold" ControlToValidate="txtRStrada"
													ErrorMessage="Strada nu poate sa contina caractere invalide: <>()';&quot;\ " ValidationExpression="^[^>|(|)|<|'|&quot;|;|\\]*$"><</asp:regularexpressionvalidator></TD>
										</TR>
										<tr>
											<td class="GreenSeparator" colSpan="4"><IMG src="images/1x1.gif" height="1"></td>
										</tr>
										<TR>
											<TD class="NormalGreenBold">Numar:</TD>
											<TD><asp:textbox id="txtDNumar" runat="server" CssClass="NormalEditBoxuri" MaxLength="10" Width="130px"
													onChange="Form1.txtRNumar.value = this.value"></asp:textbox><SPAN class="CommentRedBold">*</SPAN>
												<asp:requiredfieldvalidator id="requiredDNumar" runat="server" CssClass="AlertRedBold" ControlToValidate="txtDNumar"
													ErrorMessage="Completati numar!"><</asp:requiredfieldvalidator><asp:regularexpressionvalidator id="regularNumar" runat="server" CssClass="AlertRedBold" ControlToValidate="txtDNumar"
													ErrorMessage="Numarul nu poate sa contina caractere invalide: <>()';&quot;\ " ValidationExpression="^[^>|(|)|<|'|&quot;|;|\\]*$"><</asp:regularexpressionvalidator><span class="CommentRedBold"></span></TD>
											<TD class="NormalGreenBold">Numar:</TD>
											<TD><asp:textbox id="txtRNumar" runat="server" CssClass="NormalEditBoxuri" MaxLength="10" Width="130px"></asp:textbox><SPAN class="CommentRedBold">*</SPAN>
												<asp:requiredfieldvalidator id="Requiredfieldvalidator1" runat="server" CssClass="AlertRedBold" ControlToValidate="txtRNumar"
													ErrorMessage="Completati numar!"><</asp:requiredfieldvalidator><asp:regularexpressionvalidator id="Regularexpressionvalidator6" runat="server" CssClass="AlertRedBold" ControlToValidate="txtRNumar"
													ErrorMessage="Numarul nu poate sa contina caractere invalide: <>()';&quot;\ " ValidationExpression="^[^>|(|)|<|'|&quot;|;|\\]*$"><</asp:regularexpressionvalidator><span class="CommentRedBold"></span></TD>
										</TR>
										<tr>
											<td class="GreenSeparator" colSpan="4"><IMG src="images/1x1.gif" height="1"></td>
										</tr>
										<TR>
											<TD class="NormalGreenBold">Cod postal:</TD>
											<TD><asp:textbox id="txtDCodPostal" runat="server" CssClass="NormalEditBoxuri" MaxLength="20" Width="130px"
													onChange="Form1.txtRCodPostal.value = this.value"></asp:textbox><SPAN class="CommentRedBold">*</SPAN>
												<asp:requiredfieldvalidator id="requiredDCodPostal" runat="server" CssClass="AlertRedBold" ControlToValidate="txtDCodPostal"
													ErrorMessage="Completati cod postal!"><</asp:requiredfieldvalidator><asp:regularexpressionvalidator id="regularDCodPostal" runat="server" CssClass="AlertRedBold" ControlToValidate="txtDCodPostal"
													ErrorMessage="Introduceti numai cifre pentru codul postal!" ValidationExpression="[0-9]*"><</asp:regularexpressionvalidator><span class="CommentRedBold"></span></TD>
											<TD class="NormalGreenBold">CodPostal:</TD>
											<TD><asp:textbox id="txtRCodPostal" runat="server" CssClass="NormalEditBoxuri" MaxLength="20" Width="130px"></asp:textbox><SPAN class="CommentRedBold">*</SPAN>
												<asp:requiredfieldvalidator id="Requiredfieldvalidator3" runat="server" CssClass="AlertRedBold" ControlToValidate="txtRCodPostal"
													ErrorMessage="Completati cod postal!"><</asp:requiredfieldvalidator><asp:regularexpressionvalidator id="Regularexpressionvalidator7" runat="server" CssClass="AlertRedBold" ControlToValidate="txtRCodPostal"
													ErrorMessage="Introduceti numai cifre pentru codul postal!" ValidationExpression="[0-9]*"><</asp:regularexpressionvalidator></TD>
										</TR>
										<tr>
											<td class="GreenSeparator" colSpan="4"><IMG src="images/1x1.gif" height="1"></td>
										</tr>
										<TR>
											<TD class="NormalGreenBold">Bloc:</TD>
											<TD><asp:textbox id="txtDBloc" runat="server" CssClass="NormalEditBoxuri" MaxLength="5" Width="50px"
													onChange="Form1.txtRBloc.value = this.value"></asp:textbox><asp:regularexpressionvalidator id="regularDBloc" runat="server" CssClass="AlertRedBold" ControlToValidate="txtDBloc"
													ErrorMessage="Introduceti numai litere si cifre pentru bloc!" ValidationExpression="[a-zA-Z0-9]*"><</asp:regularexpressionvalidator></TD>
											<TD class="NormalGreenBold">Bloc:</TD>
											<TD><asp:textbox id="txtRBloc" runat="server" CssClass="NormalEditBoxuri" MaxLength="5" Width="50px"></asp:textbox><asp:regularexpressionvalidator id="Regularexpressionvalidator8" runat="server" CssClass="AlertRedBold" ControlToValidate="txtRBloc"
													ErrorMessage="Introduceti numai litere si cifre pentru bloc!" ValidationExpression="[a-zA-Z0-9]*"><</asp:regularexpressionvalidator></TD>
										</TR>
										<tr>
											<td class="GreenSeparator" colSpan="4"><IMG src="images/1x1.gif" height="1"></td>
										</tr>
										<TR>
											<TD class="NormalGreenBold">Scara:</TD>
											<TD><asp:textbox id="txtDScara" runat="server" CssClass="NormalEditBoxuri" MaxLength="5" Width="50px"
													onChange="Form1.txtRScara.value = this.value"></asp:textbox><asp:regularexpressionvalidator id="regularDScara" runat="server" CssClass="AlertRedBold" ControlToValidate="txtDScara"
													ErrorMessage="Introduceti numai litere si cifre pentru scara!" ValidationExpression="[a-zA-Z0-9]*"><</asp:regularexpressionvalidator></TD>
											<TD class="NormalGreenBold">Scara:</TD>
											<TD><asp:textbox id="txtRScara" runat="server" CssClass="NormalEditBoxuri" MaxLength="5" Width="50px"></asp:textbox><asp:regularexpressionvalidator id="Regularexpressionvalidator9" runat="server" CssClass="AlertRedBold" ControlToValidate="txtRScara"
													ErrorMessage="Introduceti numai litere si cifre pentru scara!" ValidationExpression="[a-zA-Z0-9]*"><</asp:regularexpressionvalidator></TD>
										</TR>
										<tr>
											<td class="GreenSeparator" colSpan="4"><IMG src="images/1x1.gif" height="1"></td>
										</tr>
										<TR>
											<TD class="NormalGreenBold">Etaj:</TD>
											<TD><asp:textbox id="txtDEtaj" runat="server" CssClass="NormalEditBoxuri" MaxLength="5" Width="50px"
													onChange="Form1.txtREtaj.value = this.value"></asp:textbox><asp:regularexpressionvalidator id="regularDEtaj" runat="server" CssClass="AlertRedBold" ControlToValidate="txtDEtaj"
													ErrorMessage="Introduceti numai litere si cifre pentru etaj!" ValidationExpression="[a-zA-Z0-9]*">< </asp:regularexpressionvalidator></TD>
											<TD class="NormalGreenBold">Etaj:</TD>
											<TD><asp:textbox id="txtREtaj" runat="server" CssClass="NormalEditBoxuri" MaxLength="5" Width="50px"></asp:textbox><asp:regularexpressionvalidator id="Regularexpressionvalidator10" runat="server" CssClass="AlertRedBold" ControlToValidate="txtREtaj"
													ErrorMessage="Introduceti numai litere si cifre pentru etaj!" ValidationExpression="[a-zA-Z0-9]*">< </asp:regularexpressionvalidator></TD>
										</TR>
										<tr>
											<td class="GreenSeparator" colSpan="4"><IMG src="images/1x1.gif" height="1"></td>
										</tr>
										<TR>
											<td class="NormalGreenBold">Apartament:</td>
											<TD><asp:textbox id="txtDApartament" runat="server" CssClass="NormalEditBoxuri" MaxLength="5" Width="50px"
													onChange="Form1.txtRApartament.value = this.value"></asp:textbox><asp:regularexpressionvalidator id="regularDApartament" runat="server" CssClass="AlertRedBold" ControlToValidate="txtDApartament"
													ErrorMessage="Introduceti numai litere si cifre pentru apartament!" ValidationExpression="[a-zA-Z0-9]*">< </asp:regularexpressionvalidator></TD>
											<TD class="NormalGreenBold">Apartament:</TD>
											<TD><asp:textbox id="txtRApartament" runat="server" CssClass="NormalEditBoxuri" MaxLength="5" Width="50px"></asp:textbox><asp:regularexpressionvalidator id="Regularexpressionvalidator11" runat="server" CssClass="AlertRedBold" ErrorMessage="Introduceti numai litere si cifre pentru apartament!"
													ControlToValidate="txtRApartament" ValidationExpression="[a-zA-Z0-9]*">< </asp:regularexpressionvalidator></TD>
										</TR>
									</TABLE>
								</td>
								<!--   DATE ANGAJARE	 -->
								<td id="tableDateAngajator" class="tabBackground" colSpan="8">
									<TABLE border="0" cellSpacing="1" cellPadding="0" width="100%">
										<tr>
											<td class="NormalGreenBold">Angajator:</td>
											<td><asp:dropdownlist id="lstAngajator" runat="server" CssClass="SelectStyle" Width="300px"></asp:dropdownlist></td>
										</tr>
										<tr>
											<td class="GreenSeparator" colSpan="4"><IMG src="images/1x1.gif" height="1"></td>
										</tr>
										<tr>
											<td class="NormalGreenBold">Punct de lucru:</td>
											<td><asp:dropdownlist id="lstPunctLucru" runat="server" CssClass="SelectStyle" Width="300px" onChange="PunctLucruChanged(this);"></asp:dropdownlist></td>
										</tr>
										<tr>
											<td class="GreenSeparator" colSpan="4"><IMG src="images/1x1.gif" height="1"></td>
										</tr>
										<tr>
											<td class="NormalGreenBold">Casa de asigurari:</td>
											<td><asp:dropdownlist id="lstCasaDeAsigurari" runat="server" CssClass="SelectStyle" Width="300px" onChange="CaseDeAsigChanged(this)"></asp:dropdownlist></td>
										</tr>
										<tr>
											<td class="GreenSeparator" colSpan="4"><IMG src="images/1x1.gif" height="1"></td>
										</tr>
										<tr>
											<td class="NormalGreenBold">Tip asigurat:</td>
											<td><asp:dropdownlist id="lstTipAsigurat" runat="server" CssClass="SelectStyle" Width="300px"></asp:dropdownlist></td>
										</tr>
										<tr>
											<td class="GreenSeparator" colSpan="4"><IMG src="images/1x1.gif" height="1"></td>
										</tr>
										<TR>
											<TD class="NormalGreenBold">Marca:</TD>
											<TD><asp:textbox id="txtMarca" runat="server" CssClass="NormalEditBoxuri" MaxLength="8" Width="100px"></asp:textbox><span class="CommentRedBold">*</span>
												<asp:requiredfieldvalidator id="requiredMarca" runat="server" CssClass="AlertRedBold" ControlToValidate="txtMarca"
													ErrorMessage="Completati marca!"><</asp:requiredfieldvalidator><asp:regularexpressionvalidator id="Regularexpressionvalidator22" runat="server" CssClass="AlertRedBold" ControlToValidate="txtMarca"
													ErrorMessage="Marca nu poate sa contina caractere invalide: <>()';&quot;\ " ValidationExpression="^[^>|(|)|<|'|&quot;|;|\\]*$"><</asp:regularexpressionvalidator></TD>
										</TR>
										<tr>
											<td class="GreenSeparator" colSpan="4"><IMG src="../images/1x1.gif" height="1"></td>
										</tr>
										<TR>
											<TD class="NormalGreenBold">GID:</TD>
											<TD><asp:textbox id="txtGid" runat="server" CssClass="NormalEditBoxuri" MaxLength="8" Width="100px"></asp:textbox><span class="CommentRedBold">*</span>
												<asp:requiredfieldvalidator id="requiredGid" runat="server" CssClass="AlertRedBold" ControlToValidate="txtGid"
													ErrorMessage="Completati GID-ul!"><</asp:requiredfieldvalidator><asp:regularexpressionvalidator id="regularGid" runat="server" CssClass="AlertRedBold" ControlToValidate="txtGid"
													ErrorMessage="GID-ul nu poate sa contina caractere invalide: <>()';&quot;\ " ValidationExpression="^[^>|(|)|<|'|&quot;|;|\\]*$"><</asp:regularexpressionvalidator></TD>
										</TR>
										<tr>
											<td class="GreenSeparator" colSpan="4"><IMG src="../images/1x1.gif" height="1"></td>
										</tr>
										<tr>
											<td class="NormalGreenBold">Categorie de incadrare:</td>
											<td><asp:dropdownlist id="lstCategorie" runat="server" CssClass="SelectStyle" Width="300px" onChange="lstCategoriiChanged(this)"></asp:dropdownlist><INPUT style="WIDTH: 22px; HEIGHT: 24px" onclick="javascript:OpenAdminWindow('categorii');"
													value="..." type="button">
												<asp:requiredfieldvalidator id="requiredCategorie" runat="server" CssClass="AlertRedBold" ControlToValidate="lstCategorie"
													ErrorMessage="Completati categoria!"><</asp:requiredfieldvalidator></td>
										</tr>
										<tr>
											<td class="GreenSeparator" colSpan="4"><IMG src="images/1x1.gif" height="1"></td>
										</tr>
										<tr>
											<td class="NormalGreenBold">Angajat scutit contributie sanatate:</td>
											<TD vAlign="middle"><asp:radiobuttonlist id="rblRetinereSanatate" runat="server" CssClass="NormalGreenBold" RepeatDirection="Horizontal">
													<asp:ListItem Value="1">Da</asp:ListItem>
													<asp:ListItem Value="0" Selected="True">Nu</asp:ListItem>
												</asp:radiobuttonlist></TD>
										</tr>
										<tr>
											<td class="GreenSeparator" colSpan="4"><IMG src="images/1x1.gif" height="1"></td>
										</tr>
										<tr>
											<td class="NormalGreenBold">Angajat scutit contributie CAS:</td>
											<TD vAlign="middle"><asp:radiobuttonlist id="rblRetinereCAS" runat="server" CssClass="NormalGreenBold" RepeatDirection="Horizontal">
													<asp:ListItem Value="1">Da</asp:ListItem>
													<asp:ListItem Value="0" Selected="True">Nu</asp:ListItem>
												</asp:radiobuttonlist></TD>
										</tr>
										<tr>
											<td class="GreenSeparator" colSpan="4"><IMG src="images/1x1.gif" height="1"></td>
										</tr>
										<tr>
											<td class="NormalGreenBold">Angajat scutit contributie Somaj:</td>
											<TD vAlign="middle"><asp:radiobuttonlist id="rblRetinereSomaj" runat="server" CssClass="NormalGreenBold" RepeatDirection="Horizontal">
													<asp:ListItem Value="1">Da</asp:ListItem>
													<asp:ListItem Value="0" Selected="True">Nu</asp:ListItem>
												</asp:radiobuttonlist></TD>
										</tr>
										<tr>
											<td class="GreenSeparator" colSpan="4"><IMG src="images/1x1.gif" height="1"></td>
										</tr>
										<TR>
											<TD class="NormalGreenBold">Mod incadrare:</TD>
											<TD><asp:dropdownlist id="lstModIncadrare" runat="server" CssClass="SelectStyle" Width="300px">
													<asp:ListItem Value="0">Cu functia de baza aici</asp:ListItem>
													<asp:ListItem Value="1">Cu functia de baza la alta societate</asp:ListItem>
												</asp:dropdownlist></TD>
										</TR>
										<tr>
											<td class="GreenSeparator" colSpan="4"><IMG src="images/1x1.gif" height="1"></td>
										</tr>
										<TR>
											<TD class="NormalGreenBold">Motiv angajare:</TD>
											<TD><asp:dropdownlist id="lstMotivDeAngajare" runat="server" CssClass="SelectStyle" Width="300px"></asp:dropdownlist></TD>
										</TR>
										<tr>
											<td class="GreenSeparator" colSpan="4"><IMG src="images/1x1.gif" height="1"></td>
										</tr>
										<TR>
											<TD class="NormalGreenBold">Tip angajat:</TD>
											<TD><asp:dropdownlist id="lstTipDeAngajat" runat="server" CssClass="SelectStyle" Width="300px"></asp:dropdownlist></TD>
										</TR>
										<tr>
											<td class="GreenSeparator" colSpan="4"><IMG src="images/1x1.gif" height="1"></td>
										</tr>
										<TR>
											<TD class="NormalGreenBold">Program de lucru:</TD>
											<TD><asp:textbox id="txtProgramLucru" runat="server" CssClass="NormalEditBoxuri" MaxLength="2" Width="100px"></asp:textbox><span class="CommentRedBold">*</span>
												<asp:requiredfieldvalidator id="requiredProgramLucru" runat="server" CssClass="AlertRedBold" ControlToValidate="txtProgramLucru"
													ErrorMessage="Completati programul de lucru!"><</asp:requiredfieldvalidator><asp:regularexpressionvalidator id="regularProgramLucru" runat="server" CssClass="AlertRedBold" ControlToValidate="txtProgramLucru"
													ErrorMessage="Programul de lucru necesita valoare numerica!" ValidationExpression="\d*"><  </asp:regularexpressionvalidator></TD>
										</TR>
										<tr>
											<td class="GreenSeparator" colSpan="4"><IMG src="images/1x1.gif" height="1"></td>
										</tr>
										<tr>
											<td class="NormalGreenBold">Perioada angajarii:</td>
											<td><select style="WIDTH: 300px" id="lstPerAngajarii" class="SelectStyle" onchange="eNedeterminata()"
													runat="server">
													<option selected value="1">Determinata</option>
													<option value="0">Nedeterminata</option>
												</select>
												<br>
												<label id="labDeLa">De la:</label>
												<asp:textbox style="CURSOR: hand" id="txtDataDeLa" onclick="Form1.radioDa.checked = true; Form1.radioNu.checked = false; AscundeControaleVenituriBrute(); ShowCalendar(this,'');"
													runat="server" CssClass="NormalEditBoxuri" MaxLength="10" Width="70px" Height="0px" ReadOnly="true"></asp:textbox><span id="spanReqDeLa" class="CommentRedBold">*
												</span><label id="labPanaLa" runat="server">Pana la:</label>
												<asp:textbox style="CURSOR: hand" id="txtDataPanaLa" onclick="ShowCalendar(this,'')" runat="server"
													CssClass="NormalEditBoxuri" MaxLength="10" Width="70px" Height="0px" ReadOnly="True"></asp:textbox><span id="spanReq" class="CommentRedBold">*
													<asp:requiredfieldvalidator id="requiredDataPanaLa" runat="server" CssClass="AlertRedBold" ControlToValidate="txtDataPanaLa"
														ErrorMessage="Completati data expirarii contractului!"><</asp:requiredfieldvalidator><asp:requiredfieldvalidator id="requiredDataDeLa" runat="server" CssClass="AlertRedBold" ControlToValidate="txtDataDeLa"
														ErrorMessage="Completati data inceperii contractului!"><</asp:requiredfieldvalidator></span></td>
										</tr>
										<tr>
											<td class="GreenSeparator" colSpan="4"><IMG src="images/1x1.gif" height="1"></td>
										</tr>
										<TR>
											<TD class="NormalGreenBold">Perioada de proba:</TD>
											<TD><asp:textbox id="txtPerProba" runat="server" CssClass="NormalEditBoxuri" MaxLength="2" Width="100px"></asp:textbox></TD>
										</TR>
										<tr>
											<td class="GreenSeparator" colSpan="4"><IMG src="images/1x1.gif" height="1"></td>
										</tr>
										<TR>
											<TD class="NormalGreenBold">PM Professional:</TD>
											<TD vAlign="middle" align="left"><asp:radiobuttonlist id="rblPMP" runat="server" CssClass="NormalGreenBold" RepeatDirection="Horizontal">
													<asp:ListItem Value="1">Da</asp:ListItem>
													<asp:ListItem Value="0" Selected="True">Nu</asp:ListItem>
												</asp:radiobuttonlist></TD>
										</TR>
										<tr>
											<td class="GreenSeparator" colSpan="4"><IMG src="images/1x1.gif" height="1"></td>
										</tr>
										<TR>
											<TD class="NormalGreenBold">Cont AZM:</TD>
											<TD vAlign="middle"><asp:radiobuttonlist id="rblAZM" runat="server" CssClass="NormalGreenBold" RepeatDirection="Horizontal">
													<asp:ListItem Value="1" Selected="True">Da</asp:ListItem>
													<asp:ListItem Value="0">Nu</asp:ListItem>
												</asp:radiobuttonlist></TD>
										</TR>
										<TR>
											<TD class="HeaderGreenBold" colSpan="2">Date contact</TD>
											<TD></TD>
										</TR>
										<TR>
											<TD class="NormalGreenBold">Telefon:</TD>
											<TD><asp:textbox id="txtTelMunca" runat="server" CssClass="NormalEditBoxuri" MaxLength="255" Width="296px"></asp:textbox><asp:regularexpressionvalidator id="Regularexpressionvalidator3" runat="server" CssClass="AlertRedBold" ControlToValidate="txtTelMunca"
													ErrorMessage="Pentru telefon trebuie introduse numai cifre!" ValidationExpression="\d*"><  </asp:regularexpressionvalidator></TD>
										</TR>
										<tr>
											<td class="GreenSeparator" colSpan="2"><IMG src="images/1x1.gif" height="1"></td>
										</tr>
										<TR>
											<TD class="NormalGreenBold">Email:</TD>
											<TD><asp:textbox id="txtEmail" runat="server" CssClass="NormalEditBoxuri" MaxLength="255" Width="296px"></asp:textbox><asp:regularexpressionvalidator id="regularEmail" runat="server" CssClass="AlertRedBold" ControlToValidate="txtEmail"
													ErrorMessage="Adresa de email incorecta!" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"><  </asp:regularexpressionvalidator></TD>
										</TR>
										<tr>
											<td class="GreenSeparator" colSpan="4"><IMG src="../images/1x1.gif" height="1"></td>
										</tr>
										<tr>
											<TD class="HeaderGreenBold" colSpan="2">Date contract munca:</TD>
										</tr>
										<TR>
											<TD class="NormalGreenBold">Numar contract munca:</TD>
											<TD><asp:textbox id="txtNrContractMunca" runat="server" CssClass="NormalEditBoxuri" MaxLength="12"
													Width="100px"></asp:textbox><SPAN class="CommentRedBold">*</SPAN>
												<asp:requiredfieldvalidator style="Z-INDEX: 0" id="reqFieldValNrContractMunca" runat="server" CssClass="AlertRedBold"
													ErrorMessage="Completati Nr. Contract de munca!" ControlToValidate="txtNrContractMunca"><      </asp:requiredfieldvalidator><asp:regularexpressionvalidator id="Regularexpressionvalidator23" runat="server" CssClass="AlertRedBold" ControlToValidate="txtNrContractMunca"
													ErrorMessage="Numarul contractului de munca nu poate sa contina caractere invalide: <>()';&quot;\ " ValidationExpression="^[^>|(|)|<|'|&quot;|;|\\]*$" style="Z-INDEX: 0"><</asp:regularexpressionvalidator><span class="CommentRedBold"></span></TD>
										</TR>
										<tr>
											<td class="GreenSeparator" colSpan="4"><IMG src="../images/1x1.gif" height="1"></td>
										</tr>
										<tr>
											<TD class="NormalGreenBold">Data inregistrarii contractului:</TD>
											<TD><asp:textbox style="CURSOR: hand" id="txtDataInreg" onclick="ShowCalendar(this,'')" runat="server"
													CssClass="NormalEditBoxuri" MaxLength="2" Width="100px" ReadOnly="True"></asp:textbox><SPAN class="CommentRedBold">*</SPAN>
												<asp:requiredfieldvalidator style="Z-INDEX: 0" id="reqFieldValDataInregistrareContract" runat="server" CssClass="AlertRedBold"
													ErrorMessage="Completati o valoare pentru Data inregistrarii contractului!" ControlToValidate="txtDataInreg"><      </asp:requiredfieldvalidator><span class="CommentRedBold"></span></TD>
										</tr>
										<tr>
											<td class="GreenSeparator" colSpan="4"><IMG src="../images/1x1.gif" height="1"></td>
										</tr>
										<tr>
											<TD class="NormalGreenBold">Functia:</TD>
											<TD><asp:dropdownlist id="lstFunctie" runat="server" CssClass="SelectStyle" Width="296px" onChange="lstFunctiiChanged(this)"></asp:dropdownlist><INPUT onclick="javascript:OpenAdminWindow('functii')" value="..." type="button">
											</TD>
										</tr>
										<tr>
											<td class="GreenSeparator" colSpan="4"><IMG src="../images/1x1.gif" height="1"></td>
										</tr>
										<tr>
											<TD class="NormalGreenBold">Departament:</TD>
											<TD><asp:dropdownlist id="lstDepartament" runat="server" CssClass="SelectStyle" Width="296px" onchange="lstDepartamentChanged();"></asp:dropdownlist><INPUT onclick="javascript:OpenAdminWindow('departamente')" value="..." type="button">
											</TD>
										</tr>
										<tr>
											<td class="GreenSeparator" colSpan="4"><IMG src="../images/1x1.gif" height="1"></td>
										</tr>
										<tr>
											<TD class="NormalGreenBold">Sef:</TD>
											<TD><asp:dropdownlist id="lstSef" runat="server" CssClass="SelectStyle" Width="296px"></asp:dropdownlist></TD>
										</tr>
										<tr>
											<td class="GreenSeparator" colSpan="4"><IMG src="../images/1x1.gif" height="1"></td>
										</tr>
										<TR>
											<TD class="NormalGreenBold">Birou:</TD>
											<TD><asp:textbox id="txtBirou" runat="server" CssClass="NormalEditBoxuri" Width="100px"></asp:textbox></TD>
										</TR>
										<tr>
											<td class="GreenSeparator" colSpan="4"><IMG src="../images/1x1.gif" height="1"></td>
										</tr>
										<tr>
											<TD class="NormalGreenBold">Salariu de incadrare:</TD>
											<TD><asp:textbox id="txtSalariu" runat="server" CssClass="NormalEditBoxuri" Width="100px"></asp:textbox><span class="CommentRedBold">*
													<asp:requiredfieldvalidator id="RequiredFieldValidator2" runat="server" CssClass="AlertRedBold" ControlToValidate="txtSalariu"
														ErrorMessage="Introduceti o valoare pentru Salariu de incadrare!"><      </asp:requiredfieldvalidator><asp:comparevalidator id="CompareValidator2" runat="server" CssClass="AlertRedBold" ControlToValidate="txtSalariu"
														ErrorMessage="Salariu baza - Introduceti o suma corecta!" Type="Double" Operator="DataTypeCheck"><  </asp:comparevalidator></span></TD>
										</tr>
										<tr>
											<td class="GreenSeparator" colSpan="4"><IMG src="../images/1x1.gif" height="1"></td>
										</tr>
										<tr>
											<TD class="NormalGreenBold">Indemnizatia de conducere:</TD>
											<TD><asp:textbox id="txtIndemnizatie" runat="server" CssClass="NormalEditBoxuri" MaxLength="9" Width="100px">0</asp:textbox><span class="CommentRedBold"><asp:comparevalidator id="CompareValidator3" runat="server" CssClass="AlertRedBold" ControlToValidate="txtIndemnizatie"
														ErrorMessage="Indemnizatie conducere - Introduceti o suma corecta!" Type="Double" Operator="DataTypeCheck"><</asp:comparevalidator></span></TD>
										</tr>
										<tr>
											<td class="GreenSeparator" colSpan="4"><IMG src="../images/1x1.gif" height="1"></td>
										</tr>
										<tr>
											<TD class="NormalGreenBold">Sporuri:</TD>
											<TD><asp:textbox id="txtSporuri" runat="server" CssClass="NormalEditBoxuri" MaxLength="9" Width="100px">0</asp:textbox><span class="CommentRedBold"><asp:comparevalidator id="cmpVldSporuri" runat="server" CssClass="AlertRedBold" ControlToValidate="txtSporuri"
														ErrorMessage="Sporuri - Introduceti o suma corecta!" Type="Double" Operator="DataTypeCheck"><</asp:comparevalidator></span></TD>
										</tr>
										<tr>
											<td class="GreenSeparator" colSpan="4"><IMG src="../images/1x1.gif" height="1"></td>
										</tr>
										<tr>
											<TD class="NormalGreenBold">Alte adaosuri:</TD>
											<TD><asp:textbox id="txtAlteAdaosuri" runat="server" CssClass="NormalEditBoxuri" MaxLength="9" Width="100px">0</asp:textbox><span class="CommentRedBold"><asp:comparevalidator id="cmpAlteAdaosuri" runat="server" CssClass="AlertRedBold" ControlToValidate="txtAlteAdaosuri"
														ErrorMessage="Alte adaosuri - Introduceti o suma corecta!" Type="Double" Operator="DataTypeCheck"><</asp:comparevalidator></span></TD>
										</tr>
										<tr>
											<td class="GreenSeparator" colSpan="4"><IMG src="../images/1x1.gif" height="1"></td>
										</tr>
										<tr>
											<td class="NormalGreenBold">Date majorare:</td>
											<td>
												<table>
													<tr>
														<td>Suma:</td>
														<td><asp:textbox id="txtSumaMajorare" runat="server" CssClass="NormalEditBoxuri" MaxLength="9" Width="100px">0</asp:textbox></td>
														<td>Data:</td>
														<td><asp:textbox style="CURSOR: hand" id="txtDataPlanificareMajorare" onclick="ShowCalendar(this,'')"
																runat="server" CssClass="NormalEditBoxuri" MaxLength="2" Width="70px" ReadOnly="True"></asp:textbox><asp:comparevalidator id="Comparevalidator5" runat="server" CssClass="AlertRedBold" ControlToValidate="txtSumaMajorare"
																ErrorMessage="Suma majorare - Introduceti o suma corecta!" Type="Double" Operator="DataTypeCheck"><</asp:comparevalidator></td>
													</tr>
												</table>
											</td>
										</tr>
										<tr>
											<td class="GreenSeparator" colSpan="4"><IMG src="../images/1x1.gif" height="1"></td>
										</tr>
										<tr>
											<TD class="NormalGreenBold">Nr zile concediu odihna pe an:</TD>
											<TD><asp:textbox id="txtNrZileCOAn" runat="server" CssClass="NormalEditBoxuri" Width="100px">21</asp:textbox><span class="CommentRedBold">*
													<asp:requiredfieldvalidator id="Requiredfieldvalidator4" runat="server" CssClass="AlertRedBold" ControlToValidate="txtNrZileCOAn"
														ErrorMessage="Completai Nr. zile concediu odihna pe an!"><      </asp:requiredfieldvalidator><asp:comparevalidator id="Comparevalidator1" runat="server" CssClass="AlertRedBold" ControlToValidate="txtNrZileCOAn"
														ErrorMessage="Nr zile CO/an - Introduceti un nr de zile corect!" Type="Integer" Operator="GreaterThanEqual" ValueToCompare="0"><</asp:comparevalidator></span></TD>
										</tr>
										<tr>
											<td class="GreenSeparator" colSpan="4"><IMG src="../images/1x1.gif" height="1"></td>
										</tr>
										<tr>
											<TD class="NormalGreenBold">Nr zile concediu suplimentar pe an:</TD>
											<TD><asp:textbox id="txtNrZileCOSupl" runat="server" CssClass="NormalEditBoxuri" Width="100px">0</asp:textbox><span class="CommentRedBold">*
													<asp:requiredfieldvalidator id="Requiredfieldvalidator5" runat="server" CssClass="AlertRedBold" ControlToValidate="txtNrZileCOSupl"
														ErrorMessage="Completai Nr. zile concediu suplimentar pe an!"><      </asp:requiredfieldvalidator><asp:comparevalidator id="cmpVldNrZileCOSupl" runat="server" CssClass="AlertRedBold" ControlToValidate="txtNrZileCOSupl"
														ErrorMessage="Nr zile CO suplimentar/an - Introduceti un nr de zile corect!" Type="Integer" Operator="GreaterThanEqual" ValueToCompare="0"><</asp:comparevalidator></span></TD>
										</tr>
										<tr>
											<td class="GreenSeparator" colSpan="4"><IMG src="../images/1x1.gif" height="1"></td>
										</tr>
										<tr>
											<TD class="NormalGreenBold">Alte clauze ale contractului individual de munca:</TD>
											<TD><asp:textbox id="txtAlteClauzeCIM" runat="server" CssClass="NormalEditBoxuri" Width="300px" TextMode="MultiLine"></asp:textbox></TD>
										</tr>
										<TR>
											<TD class="HeaderGreenBold" colSpan="2">Date carnet de munca:</TD>
										</TR>
										<TR>
											<TD class="NormalGreenBold">Serie:</TD>
											<td><asp:textbox id="txtCMSerie" runat="server" CssClass="NormalEditBoxuri" MaxLength="5" Width="100px"></asp:textbox><asp:regularexpressionvalidator id="Regularexpressionvalidator24" runat="server" CssClass="AlertRedBold" ControlToValidate="txtCMSerie"
													ErrorMessage="Seria carnetului de munca nu poate sa contina caractere invalide: <>()';&quot;\ " ValidationExpression="^[^>|(|)|<|'|&quot;|;|\\]*$"><</asp:regularexpressionvalidator></td>
										</TR>
										<tr>
											<td class="GreenSeparator" colSpan="4"><IMG src="images/1x1.gif" height="1"></td>
										</tr>
										<TR>
											<TD class="NormalGreenBold">Numar:</TD>
											<TD><asp:textbox id="txtCMNumar" runat="server" CssClass="NormalEditBoxuri" MaxLength="10" Width="100px"></asp:textbox><asp:regularexpressionvalidator id="Regularexpressionvalidator25" runat="server" CssClass="AlertRedBold" ControlToValidate="txtCMNumar"
													ErrorMessage="Numarul carnetului de munca nu poate sa contina caractere invalide: <>()';&quot;\ " ValidationExpression="^[^>|(|)|<|'|&quot;|;|\\]*$"><</asp:regularexpressionvalidator></TD>
										</TR>
										<tr>
											<td class="GreenSeparator" colSpan="4"><IMG src="images/1x1.gif" height="1"></td>
										</tr>
										<TR>
											<TD class="NormalGreenBold">Emitent:</TD>
											<TD><asp:textbox id="txtCMEmitent" runat="server" CssClass="NormalEditBoxuri" MaxLength="50" Width="100px"></asp:textbox></TD>
										</TR>
										<tr>
											<td class="GreenSeparator" colSpan="4"><IMG src="images/1x1.gif" height="1"></td>
										</tr>
										<TR>
											<TD class="NormalGreenBold">Data emiterii:</TD>
											<TD><asp:textbox style="CURSOR: hand" id="txtCMDataEmiterii" onclick="ShowCalendar(this,'')" runat="server"
													CssClass="NormalEditBoxuri" Width="100px" ReadOnly="True"></asp:textbox></TD>
										</TR>
										<tr>
											<td class="GreenSeparator" colSpan="4"><IMG src="images/1x1.gif" height="1"></td>
										</tr>
										<TR>
											<TD class="NormalGreenBold">Nr. Inreg. ITM:</TD>
											<TD><asp:textbox id="txtCMNrInregITM" runat="server" CssClass="NormalEditBoxuri" MaxLength="25" Width="100px"></asp:textbox><asp:regularexpressionvalidator id="Regularexpressionvalidator26" runat="server" CssClass="AlertRedBold" ControlToValidate="txtCMNrInregITM"
													ErrorMessage="Numarul de inregistrare ITM pentru carnetul de munca nu poate sa contina caractere invalide: <>()';&quot;\ " ValidationExpression="^[^>|(|)|<|'|&quot;|;|\\]*$"><</asp:regularexpressionvalidator></TD>
										</TR>
										<tr>
											<td class="GreenSeparator" colSpan="4"><IMG src="images/1x1.gif" height="1"></td>
										</tr>
										<TR>
											<TD class="NormalGreenBold">Tip fisa fiscala:</TD>
											<TD><asp:dropdownlist id="lstTipFisaFiscala" runat="server" Width="300px" cssclass="SelectStyle">
													<asp:ListItem Value="0">Fisa Fiscala 1</asp:ListItem>
													<asp:ListItem Value="1">Fisa Fiscala 2</asp:ListItem>
												</asp:dropdownlist></TD>
										</TR>
										<tr>
											<td class="GreenSeparator" colSpan="4"><IMG src="images/1x1.gif" height="1"></td>
										</tr>
										<TR>
											<TD class="NormalGreenBold">Ani vechime munca:</TD>
											<TD><asp:textbox id="txtAniVechimeMunca" runat="server" CssClass="NormalEditBoxuri" MaxLength="2"
													Width="100px">0</asp:textbox><asp:regularexpressionvalidator id="regularAniVechime" runat="server" CssClass="AlertRedBold" ControlToValidate="txtAniVechimeMunca"
													ErrorMessage="Ani vechime trebuie sa fie numeric!" ValidationExpression="\d*"><  </asp:regularexpressionvalidator></TD>
										</TR>
										<tr>
											<td class="GreenSeparator" colSpan="4"><IMG src="images/1x1.gif" height="1"></td>
										</tr>
										<TR>
											<TD class="NormalGreenBold">Luni vechime munca:</TD>
											<TD><asp:textbox id="txtLuniVechimeMunca" runat="server" CssClass="NormalEditBoxuri" MaxLength="2"
													Width="100px">0</asp:textbox><asp:regularexpressionvalidator id="regularLuniVechime" runat="server" CssClass="AlertRedBold" ControlToValidate="txtLuniVechimeMunca"
													ErrorMessage="Luni vechime trebuie sa fie numeric!" ValidationExpression="\d*"><  </asp:regularexpressionvalidator><asp:rangevalidator id="rangeLuniVechime" runat="server" CssClass="AlertRedBold" ControlToValidate="txtLuniVechimeMunca"
													ErrorMessage="Numarul de luni vechime trebuie sa fie in intervalul 0-11!" MinimumValue="0" MaximumValue="11" Type="Integer"><</asp:rangevalidator></TD>
										</TR>
										<tr>
											<td class="GreenSeparator" colSpan="4"><IMG src="images/1x1.gif" height="1"></td>
										</tr>
										<TR>
											<TD class="NormalGreenBold">Zile vechime munca:</TD>
											<TD><asp:textbox id="txtZileVechimeMunca" runat="server" CssClass="NormalEditBoxuri" MaxLength="2"
													Width="100px">0</asp:textbox><asp:regularexpressionvalidator id="regularZileVechime" runat="server" CssClass="AlertRedBold" ControlToValidate="txtZileVechimeMunca"
													ErrorMessage="Zile vechime trebuie sa fie numeric!" ValidationExpression="\d*"><  </asp:regularexpressionvalidator><asp:rangevalidator id="rangeZileVechime" runat="server" CssClass="AlertRedBold" ControlToValidate="txtZileVechimeMunca"
													ErrorMessage="Numarul de zile vechime trebuie sa fie in intervalul 0-30!" MinimumValue="0" MaximumValue="31" Type="Integer"><</asp:rangevalidator></TD>
										</TR>
										<tr>
											<td class="GreenSeparator" colSpan="4"><IMG src="images/1x1.gif" height="1"></td>
										</tr>
										<TR>
											<TD class="NormalGreenBold">Card bancar:</TD>
											<TD><asp:dropdownlist id="lstAreCardBancar" runat="server" CssClass="SelectStyle" Width="300px">
													<asp:ListItem Value="1">Are card bancar</asp:ListItem>
													<asp:ListItem Value="0">NU are card bancar</asp:ListItem>
												</asp:dropdownlist></TD>
										</TR>
										<tr>
											<TD class="HeaderGreenBold" colSpan="2">Venituri Brute pe ultimele sase luni, 
												anterioare datei angajarii:</TD>
										</tr>
										<tr>
											<td class="NormalGreenBold">Primul loc de munca</td>
											<td class="NormalGreenBold"><asp:radiobutton id="radioDa" onclick="SelectLocMunca();" runat="server" Checked="True" GroupName="groupLocMunca"
													Text="Da"></asp:radiobutton><asp:radiobutton id="radioNu" onclick="SelectLocMunca();" runat="server" GroupName="groupLocMunca"
													Text="Nu"></asp:radiobutton>&nbsp;&nbsp;&nbsp;&nbsp;</td>
										</tr>
										<tr>
											<td class="GreenSeparator" colSpan="4"><IMG src="images/1x1.gif" height="1"></td>
										</tr>
										<tr id="luna1CAS">
											<td class="NormalGreenBold" colSpan="2">luna:&nbsp;&nbsp;&nbsp;&nbsp;
												<asp:label id="txtLuna1" runat="server" Width="100px"></asp:label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Venit 
												Brut&nbsp;
												<asp:textbox id="txtCAS1" runat="server" CssClass="NormalEditBoxuri"></asp:textbox><asp:comparevalidator id="Comparevalidator4" runat="server" CssClass="AlertRedBold" ControlToValidate="txtCAS1"
													ErrorMessage="Venit brut - Introduceti o suma corecta!" Type="Double" Operator="DataTypeCheck"><</asp:comparevalidator></td>
										</tr>
										<tr id="separator1">
											<td class="GreenSeparator" colSpan="4"><IMG src="images/1x1.gif" height="1"></td>
										</tr>
										<tr id="luna2CAS">
											<td class="NormalGreenBold" colSpan="2">luna:&nbsp;&nbsp;&nbsp;&nbsp;
												<asp:label id="txtLuna2" runat="server" Width="100px"></asp:label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Venit 
												Brut&nbsp;
												<asp:textbox id="txtCAS2" runat="server" CssClass="NormalEditBoxuri"></asp:textbox><asp:comparevalidator id="Comparevalidator6" runat="server" CssClass="AlertRedBold" ControlToValidate="txtCAS2"
													ErrorMessage="Venit brut - Introduceti o suma corecta!" Type="Double" Operator="DataTypeCheck"><</asp:comparevalidator></td>
										</tr>
										<tr id="separator2">
											<td class="GreenSeparator" colSpan="4"><IMG src="images/1x1.gif" height="1"></td>
										</tr>
										<tr id="luna3CAS">
											<td class="NormalGreenBold" colSpan="2">luna:&nbsp;&nbsp;&nbsp;&nbsp;
												<asp:label id="txtLuna3" runat="server" Width="100px"></asp:label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
												Venit Brut&nbsp;
												<asp:textbox id="txtCAS3" runat="server" CssClass="NormalEditBoxuri"></asp:textbox><asp:comparevalidator id="Comparevalidator7" runat="server" CssClass="AlertRedBold" ControlToValidate="txtCAS3"
													ErrorMessage="Venit brut - Introduceti o suma corecta!" Type="Double" Operator="DataTypeCheck"><</asp:comparevalidator></td>
										</tr>
										<tr id="separator3">
											<td class="GreenSeparator" colSpan="4"><IMG src="images/1x1.gif" height="1"></td>
										</tr>
										<tr id="luna4CAS">
											<td class="NormalGreenBold" colSpan="2">luna:&nbsp;&nbsp;&nbsp;&nbsp;
												<asp:label id="txtLuna4" runat="server" Width="100px"></asp:label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Venit 
												Brut&nbsp;
												<asp:textbox id="txtCAS4" runat="server" CssClass="NormalEditBoxuri"></asp:textbox><asp:comparevalidator id="Comparevalidator8" runat="server" CssClass="AlertRedBold" ControlToValidate="txtCAS4"
													ErrorMessage="Venit brut - Introduceti o suma corecta!" Type="Double" Operator="DataTypeCheck"><</asp:comparevalidator></td>
										</tr>
										<tr id="separator4">
											<td class="GreenSeparator" colSpan="4"><IMG src="images/1x1.gif" height="1"></td>
										</tr>
										<tr id="luna5CAS">
											<td class="NormalGreenBold" colSpan="2">luna:&nbsp;&nbsp;&nbsp;&nbsp;
												<asp:label id="txtLuna5" runat="server" Width="100px"></asp:label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Venit 
												Brut&nbsp;
												<asp:textbox id="txtCAS5" runat="server" CssClass="NormalEditBoxuri"></asp:textbox><asp:comparevalidator id="Comparevalidator9" runat="server" CssClass="AlertRedBold" ControlToValidate="txtCAS5"
													ErrorMessage="Venit brut - Introduceti o suma corecta!" Type="Double" Operator="DataTypeCheck"><</asp:comparevalidator></td>
										</tr>
										<tr id="separator5">
											<td class="GreenSeparator" colSpan="4"><IMG src="images/1x1.gif" height="1"></td>
										</tr>
										<tr id="luna6CAS">
											<td class="NormalGreenBold" colSpan="2">luna:&nbsp;&nbsp;&nbsp;&nbsp;
												<asp:label id="txtLuna6" runat="server" Width="100px"></asp:label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Venit 
												Brut&nbsp;
												<asp:textbox id="txtCAS6" runat="server" CssClass="NormalEditBoxuri"></asp:textbox><asp:comparevalidator id="Comparevalidator10" runat="server" CssClass="AlertRedBold" ErrorMessage="Venit brut - Introduceti o suma corecta!"
													ControlToValidate="txtCAS6" Type="Double" Operator="DataTypeCheck"><</asp:comparevalidator></td>
										</tr>
										<tr id="liniaAscunsa">
											<td><asp:dropdownlist id="dropLunaActiva" runat="server"></asp:dropdownlist><asp:dropdownlist id="dropLunileAnului" runat="server"></asp:dropdownlist></td>
										</tr>
									</TABLE>
								</td>
								<!--   BULETIN - PASAPORT - PERMIS MUNCA - LEGITIMATIE SEDERE - NIF	 -->
								<td id="tableBuletinPasaport" class="tabBackground" colSpan="8">
									<TABLE border="0" cellSpacing="1" cellPadding="0" width="100%">
										<!-- Date despre Nationalitate -->
										<tr>
											<td colSpan="2">
												<table id="tableNationalitate" cellSpacing="0" cellPadding="0" width="100%" runat="server">
													<tr>
														<td class="HeaderGreenBold" colSpan="2" align="center">Date Nationalitate:</td>
													</tr>
													<TR>
														<TD class="NormalGreenBold" width="30%">Nationalitate:</TD>
														<TD><asp:dropdownlist id="lstNationalitate" runat="server" CssClass="SelectStyle" Width="110px" onchange="NationalitateChanged();"></asp:dropdownlist></TD>
													</TR>
													<tr>
														<td class="GreenSeparator" colSpan="2"><IMG src="images/1x1.gif" height="1"></td>
													</tr>
													<TR>
														<TD class="NormalGreenBold">Data Nasterii:</TD>
														<TD><asp:textbox style="CURSOR: hand" id="txtDataNasterii" onclick="ShowCalendar(this,'')" runat="server"
																CssClass="NormalEditBoxuri" MaxLength="10" Width="70px" Height="0px" ReadOnly="True"></asp:textbox><span id="spanDataNasterii" class="CommentRedBold" runat="server">*</span>
															<asp:requiredfieldvalidator id="requiredDataNasterii" runat="server" CssClass="AlertRedBold" ControlToValidate="txtDataNasterii"
																ErrorMessage="Completati data nasterii!"><</asp:requiredfieldvalidator></TD>
													</TR>
													<tr>
														<td class="GreenSeparator" colSpan="2"><IMG src="images/1x1.gif" height="1"></td>
													</tr>
													<TR>
														<TD class="NormalGreenBold">Tara nastere:</TD>
														<TD><asp:dropdownlist id="lstTaraNastere" runat="server" CssClass="SelectStyle" Width="150px" onChange="lstTaraNastereChanged(this);"></asp:dropdownlist><INPUT onclick="javascript:OpenAdminWindow('tari')" value="..." type="button">
															<span id="spanTaraNastere" class="CommentRedBold" runat="server">*</span>
														</TD>
													</TR>
													<tr>
														<td class="GreenSeparator" colSpan="2"><IMG src="images/1x1.gif" height="1"></td>
													</tr>
													<TR>
														<TD class="NormalGreenBold">Judet nastere:</TD>
														<TD><asp:dropdownlist id="lstJudetNastere" runat="server" CssClass="SelectStyle" Width="150px" onChange="lstJudetNastereChanged(this);"></asp:dropdownlist><INPUT onclick="javascript:OpenAdminWindow('judete')" value="..." type="button">
															<span id="spanJudetNastere" class="CommentRedBold" runat="server">*</span>
														</TD>
													</TR>
													<tr>
														<td class="GreenSeparator" colSpan="2"><IMG src="images/1x1.gif" height="1"></td>
													</tr>
													<TR>
														<TD class="NormalGreenBold">Localitate nastere:</TD>
														<TD><asp:textbox id="txtLocalitateNastere" runat="server" CssClass="NormalEditBoxuri" MaxLength="50"
																Width="130px"></asp:textbox><span id="spanLocalitateNastere" class="CommentRedBold" runat="server">*</span>
															<asp:requiredfieldvalidator id="requiredLocalitateNastere" runat="server" CssClass="AlertRedBold" ControlToValidate="txtLocalitateNastere"
																ErrorMessage="Completati localitate nastere!"><</asp:requiredfieldvalidator></TD>
													</TR>
													<tr>
														<td class="GreenSeparator" colSpan="2"><IMG src="images/1x1.gif" height="1"></td>
													</tr>
													<TR>
														<TD class="NormalGreenBold">Prenume Mama:</TD>
														<TD><asp:textbox id="txtPrenumeMama" runat="server" CssClass="NormalEditBoxuri" MaxLength="50" Width="130px"></asp:textbox><span id="spanPrenumeMama" class="CommentRedBold" runat="server"></span></TD>
													</TR>
													<tr>
														<td class="GreenSeparator" colSpan="2"><IMG height="1" src="images/1x1.gif"></td>
													</tr>
													<TR>
														<TD class="NormalGreenBold">Prenume Tata:</TD>
														<TD><asp:textbox id="txtPrenumeTata" runat="server" CssClass="NormalEditBoxuri" MaxLength="50" Width="130px"></asp:textbox>
															<asp:regularexpressionvalidator id="Regularexpressionvalidator14" runat="server" CssClass="AlertRedBold" ControlToValidate="txtPrenumeTata"
																ErrorMessage="Prenumele tatalui nu poate sa contina caractere invalide: <>()';&quot;\ " ValidationExpression="^[^>|(|)|<|'|&quot;|;|\\]*$"><</asp:regularexpressionvalidator></TD>
													</TR>
												</table>
											</td>
										</tr>
										<!-- Date despre Buletin -->
										<tr>
											<td colSpan="2">
												<table id="tableBuletin" cellSpacing="0" cellPadding="0" width="100%" runat="server">
													<tr>
														<td class="HeaderGreenBold" colSpan="2" align="center">Date Buletin/C.I.:</td>
													</tr>
													<TR>
														<TD class="NormalGreenBold" width="30%">CNP:</TD>
														<TD><asp:textbox id="txtCNP" runat="server" CssClass="NormalEditBoxuri" MaxLength="13" Width="140px"></asp:textbox><span id="spanCNP" class="CommentRedBold" runat="server">*</span>
															<asp:customvalidator id="customCNP" runat="server" CssClass="AlertRedBold" ControlToValidate="txtCNP"
																ErrorMessage="CNP nu e valid!" ClientValidationFunction="CheckCNP"><</asp:customvalidator></TD>
													</TR>
													<tr>
														<td class="GreenSeparator" colSpan="2"><IMG src="images/1x1.gif" height="1"></td>
													</tr>
													<tr>
														<td class="NormalGreenBold">CNP anterior:</td>
														<TD><asp:textbox id="txtCNPAnterior" runat="server" CssClass="NormalEditBoxuri" MaxLength="13" Width="140px"></asp:textbox><asp:customvalidator id="Customvalidator1" runat="server" CssClass="AlertRedBold" ControlToValidate="txtCNPAnterior"
																ErrorMessage="CNP nu e valid!" ClientValidationFunction="CheckCNP"><</asp:customvalidator></TD>
													</tr>
													<tr>
														<td class="GreenSeparator" colSpan="2"><IMG src="images/1x1.gif" height="1"></td>
													</tr>
													<TR>
														<TD class="NormalGreenBold">Serie:</TD>
														<td><asp:textbox id="txtCISerie" runat="server" CssClass="NormalEditBoxuri" MaxLength="2" Width="150px"></asp:textbox><span id="spanSerieBI" class="CommentRedBold" runat="server">*</span>
															<asp:regularexpressionvalidator id="Regularexpressionvalidator15" runat="server" CssClass="AlertRedBold" ControlToValidate="txtCISerie"
																ErrorMessage="Serie CI - litere!" ValidationExpression="[a-zA-Z]*"><</asp:regularexpressionvalidator></td>
													</TR>
													<tr>
														<td class="GreenSeparator" colSpan="2"><IMG src="images/1x1.gif" height="1"></td>
													</tr>
													<TR>
														<TD class="NormalGreenBold">Numar:</TD>
														<TD><asp:textbox id="txtCINumar" runat="server" CssClass="NormalEditBoxuri" MaxLength="8" Width="150px"></asp:textbox><span id="spanNumarBI" class="CommentRedBold" runat="server">*</span>
															<asp:regularexpressionvalidator id="regularCINumar" runat="server" CssClass="AlertRedBold" ControlToValidate="txtCINumar"
																ErrorMessage="Numar CI - cifre!" ValidationExpression="[0-9]*"><</asp:regularexpressionvalidator></TD>
													</TR>
													<tr>
														<td class="GreenSeparator" colSpan="2"><IMG src="images/1x1.gif" height="1"></td>
													</tr>
													<TR>
														<TD class="NormalGreenBold">Eliberat de:</TD>
														<TD><asp:textbox id="txtCIEliberatDe" runat="server" CssClass="NormalEditBoxuri" MaxLength="50" Width="150px"></asp:textbox><span id="spanEliberatDeBI" class="CommentRedBold" runat="server">*
																<asp:regularexpressionvalidator id="Regularexpressionvalidator28" runat="server" CssClass="AlertRedBold" ControlToValidate="txtCIEliberatDe"
																	ErrorMessage="Campul Eliberat de nu poate contine caractere invalide: <>()';&quot;\" ValidationExpression="^[^>|(|)|<|'|&quot;|;|\\]*$"><</asp:regularexpressionvalidator></span></TD>
													</TR>
													<tr>
														<td class="GreenSeparator" colSpan="2"><IMG src="images/1x1.gif" height="1"></td>
													</tr>
													<TR>
														<TD class="NormalGreenBold">Data eliberarii:</TD>
														<TD><asp:textbox style="CURSOR: hand" id="txtCIDataEliberarii" onclick="ShowCalendar(this,'')" runat="server"
																CssClass="NormalEditBoxuri" Width="70px" ReadOnly="True"></asp:textbox><span id="spanDataEliberareBI" class="CommentRedBold" runat="server">*</span>
														</TD>
													</TR>
													<tr>
														<td class="GreenSeparator" colSpan="2"><IMG src="images/1x1.gif" height="1"></td>
													</tr>
													<TR>
														<TD class="NormalGreenBold">Valabil pana la:</TD>
														<TD><asp:textbox style="CURSOR: hand" id="txtCIValabilPanaLa" onclick="ShowCalendar(this,'')" runat="server"
																CssClass="NormalEditBoxuri" Width="70px" ReadOnly="True"></asp:textbox><span id="spanDataExpirareBI" class="CommentRedBold" runat="server">*</span>
														</TD>
													</TR>
												</table>
											</td>
										</tr>
										<!-- Date despre Pasaport -->
										<tr>
											<td colSpan="2">
												<table id="tablePasaport" cellSpacing="0" cellPadding="0" width="100%" runat="server">
													<tr>
														<td class="HeaderGreenBold" colSpan="2" align="center">Date Pasaport:</td>
													</tr>
													<tr>
														<TD class="NormalGreenBold" width="30%">Serie:</TD>
														<TD><asp:textbox id="txtPASSerie" runat="server" CssClass="NormalEditBoxuri" MaxLength="10" Width="120px"></asp:textbox><span id="spanSeriePasaport" class="CommentRedBold" runat="server">*</span>
															<asp:regularexpressionvalidator id="Regularexpressionvalidator16" runat="server" CssClass="AlertRedBold" ControlToValidate="txtPASSerie"
																ErrorMessage="Serie pasaport - litere!" ValidationExpression="[a-zA-Z]*"><</asp:regularexpressionvalidator></TD>
													</tr>
													<tr>
														<td class="GreenSeparator" colSpan="2"><IMG src="images/1x1.gif" height="1"></td>
													</tr>
													<tr>
														<TD class="NormalGreenBold">Numar:</TD>
														<TD><asp:textbox id="txtPASNumar" runat="server" CssClass="NormalEditBoxuri" MaxLength="9" Width="120px"></asp:textbox><span id="spanNumarPasaport" class="CommentRedBold" runat="server">*</span>
															<asp:regularexpressionvalidator id="RegularExpressionValidator1" runat="server" CssClass="AlertRedBold" ControlToValidate="txtPASNumar"
																ErrorMessage="Numar pasaport - cifre!" ValidationExpression="[0-9]*"><</asp:regularexpressionvalidator></TD>
													</tr>
													<tr>
														<td class="GreenSeparator" colSpan="2"><IMG src="images/1x1.gif" height="1"></td>
													</tr>
													<tr>
														<TD class="NormalGreenBold">Eliberat de:</TD>
														<TD><asp:textbox id="txtPASEliberatDe" runat="server" CssClass="NormalEditBoxuri" MaxLength="50"
																Width="120px"></asp:textbox><span id="spanPasaportEliberatDe" class="CommentRedBold" runat="server">*</span>
															<asp:regularexpressionvalidator id="Regularexpressionvalidator27" runat="server" CssClass="AlertRedBold" ControlToValidate="txtPASEliberatDe"
																ErrorMessage="Campul Eliberat de nu poate contine caractere invalide: <>()';&quot;\" ValidationExpression="^[^>|(|)|<|'|&quot;|;|\\]*$"><</asp:regularexpressionvalidator></TD>
													</tr>
													<tr>
														<td class="GreenSeparator" colSpan="2"><IMG src="images/1x1.gif" height="1"></td>
													</tr>
													<tr>
														<TD class="NormalGreenBold">Data eliberarii:</TD>
														<TD><asp:textbox style="CURSOR: hand" id="txtPASDataEliberarii" onclick="ShowCalendar(this,'')" runat="server"
																CssClass="NormalEditBoxuri" Width="70px" ReadOnly="True"></asp:textbox><span id="spanDataEliberarePasaport" class="CommentRedBold" runat="server">*</span>
														</TD>
													</tr>
													<tr>
														<td class="GreenSeparator" colSpan="2"><IMG src="images/1x1.gif" height="1"></td>
													</tr>
													<tr>
														<TD class="NormalGreenBold">Valabil pana la:</TD>
														<TD><asp:textbox style="CURSOR: hand" id="txtPASValabilPanaLa" onclick="ShowCalendar(this,'')" runat="server"
																CssClass="NormalEditBoxuri" Width="70px" ReadOnly="True"></asp:textbox><span id="spanDataExpirarePasaport" class="CommentRedBold" runat="server">*</span>
														</TD>
													</tr>
												</table>
											</td>
										</tr>
										<!-- Date Permis Munca -->
										<tr>
											<td colSpan="2">
												<table id="tablePermisMunca" cellSpacing="0" cellPadding="0" width="100%" runat="server">
													<tr>
														<td class="HeaderGreenBold" colSpan="2" align="center">Date Permis Munca:</td>
													</tr>
													<tr>
														<TD class="NormalGreenBold" width="30%">Serie:</TD>
														<TD><asp:textbox id="txtSeriePermisMunca" runat="server" CssClass="NormalEditBoxuri" MaxLength="10"
																Width="120px"></asp:textbox><span id="spanSeriePermisMunca" class="CommentRedBold" runat="server">*</span>
															<asp:regularexpressionvalidator id="Regularexpressionvalidator18" runat="server" CssClass="AlertRedBold" ControlToValidate="txtSeriePermisMunca"
																ErrorMessage="Serie permis munca - litere!" ValidationExpression="[a-zA-Z]*"><</asp:regularexpressionvalidator></TD>
													</tr>
													<tr>
														<td class="GreenSeparator" colSpan="2"><IMG src="images/1x1.gif" height="1"></td>
													</tr>
													<tr>
														<TD class="NormalGreenBold">Numar:</TD>
														<TD><asp:textbox id="txtNrPermisMunca" runat="server" CssClass="NormalEditBoxuri" MaxLength="10"
																Width="120px"></asp:textbox><span id="spanNumarPermisMunca" class="CommentRedBold" runat="server">*</span>
															<asp:regularexpressionvalidator id="RegularExpressionValidator17" runat="server" CssClass="AlertRedBold" ControlToValidate="txtNrPermisMunca"
																ErrorMessage="Numar permis munca - cifre!" ValidationExpression="[0-9]*"><</asp:regularexpressionvalidator></TD>
													</tr>
													<tr>
														<td class="GreenSeparator" colSpan="2"><IMG src="images/1x1.gif" height="1"></td>
													</tr>
													<tr>
														<TD class="NormalGreenBold">Data eliberarii:</TD>
														<TD><asp:textbox style="CURSOR: hand" id="txtPermisMuncaDataEliberare" onclick="ShowCalendar(this,'')"
																runat="server" CssClass="NormalEditBoxuri" Width="70px" ReadOnly="True"></asp:textbox><span id="spanDataEliberarePermisMunca" class="CommentRedBold" runat="server">*</span>
														</TD>
													</tr>
													<tr>
														<td class="GreenSeparator" colSpan="2"><IMG src="images/1x1.gif" height="1"></td>
													</tr>
													<tr>
														<TD class="NormalGreenBold">Valabil pana la:</TD>
														<TD><asp:textbox style="CURSOR: hand" id="txtPermisMuncaDataExpirare" onclick="ShowCalendar(this,'')"
																runat="server" CssClass="NormalEditBoxuri" Width="70px" ReadOnly="True"></asp:textbox><span id="spanDataExpirarePermisMunca" class="CommentRedBold" runat="server">*</span>
														</TD>
													</tr>
												</table>
											</td>
										</tr>
										<!-- Date Legitimatie Sedere -->
										<tr>
											<td colSpan="2">
												<table id="tableLegitimatieSedere" cellSpacing="0" cellPadding="0" width="100%" runat="server">
													<tr>
														<td class="HeaderGreenBold" colSpan="2" align="center">Date Legitimatie Sedere:</td>
													</tr>
													<tr>
														<TD class="NormalGreenBold" width="30%">Serie:</TD>
														<TD><asp:textbox id="txtSerieLegitimatieSedere" runat="server" CssClass="NormalEditBoxuri" MaxLength="10"
																Width="120px"></asp:textbox><span id="spanSerieLegitimatieSedere" class="CommentRedBold" runat="server">*</span>
															<asp:regularexpressionvalidator id="Regularexpressionvalidator19" runat="server" CssClass="AlertRedBold" ControlToValidate="txtSerieLegitimatieSedere"
																ErrorMessage="Serie legitimatie de sedere - litere!" ValidationExpression="[a-zA-Z]*"><</asp:regularexpressionvalidator></TD>
													</tr>
													<tr>
														<td class="GreenSeparator" colSpan="2"><IMG src="images/1x1.gif" height="1"></td>
													</tr>
													<tr>
														<TD class="NormalGreenBold">Numar:</TD>
														<TD><asp:textbox id="txtNrLegitimatieSedere" runat="server" CssClass="NormalEditBoxuri" MaxLength="10"
																Width="120px"></asp:textbox><span id="spanNumarLegitimatieSedere" class="CommentRedBold" runat="server">*</span>
															<asp:regularexpressionvalidator id="RegularExpressionValidator20" runat="server" CssClass="AlertRedBold" ControlToValidate="txtNrLegitimatieSedere"
																ErrorMessage="Numar legitimatie sedere - cifre!" ValidationExpression="[0-9]*"><</asp:regularexpressionvalidator></TD>
													</tr>
													<tr>
														<td class="GreenSeparator" colSpan="2"><IMG src="images/1x1.gif" height="1"></td>
													</tr>
													<tr>
														<TD class="NormalGreenBold">Data eliberarii:</TD>
														<TD><asp:textbox style="CURSOR: hand" id="txtLegitimatieSedereDataEliberare" onclick="ShowCalendar(this,'')"
																runat="server" CssClass="NormalEditBoxuri" Width="70px" ReadOnly="True"></asp:textbox><span id="spanDataEliberareLegitimatieSedere" class="CommentRedBold" runat="server">*</span>
														</TD>
													</tr>
													<tr>
														<td class="GreenSeparator" colSpan="2"><IMG src="images/1x1.gif" height="1"></td>
													</tr>
													<tr>
														<TD class="NormalGreenBold">Valabil pana la:</TD>
														<TD><asp:textbox style="CURSOR: hand" id="txtLegitimatieSedereDataExpirare" onclick="ShowCalendar(this,'')"
																runat="server" CssClass="NormalEditBoxuri" Width="70px" ReadOnly="True"></asp:textbox><span id="spanDataExpirareLegitimatieSedere" class="CommentRedBold" runat="server">*</span>
														</TD>
													</tr>
												</table>
											</td>
										</tr>
										<!-- Date NIF -->
										<tr>
											<td colSpan="2">
												<table id="tableNIF" cellSpacing="0" cellPadding="0" width="100%" runat="server">
													<tr>
														<td class="HeaderGreenBold" colSpan="2" align="center">Numarul de Inregistrare 
															Fiscal:</td>
													</tr>
													<tr>
														<TD class="NormalGreenBold" width="30%">NIF:</TD>
														<TD><asp:textbox id="txtNIF" runat="server" CssClass="NormalEditBoxuri" MaxLength="20" Width="120px"></asp:textbox><span id="spanNIF" class="CommentRedBold" runat="server">*</span>
															<asp:regularexpressionvalidator id="RegularExpressionValidator21" runat="server" CssClass="AlertRedBold" ControlToValidate="txtNIF"
																ErrorMessage="Numarul de Inregistrare fiscal trebuie sa aiba valoaare numerica!" ValidationExpression="[0-9]*"><</asp:regularexpressionvalidator></TD>
													</tr>
												</table>
											</td>
										</tr>
									</TABLE>
								</td>
								<!--   ALTE DATE -->
								<td id="tableAlteDate" class="tabBackground" colSpan="8">
									<TABLE border="0" cellSpacing="1" cellPadding="0" width="100%">
										<TBODY>
											<tr>
												<td class="HeaderGreenBold" colSpan="2" align="center">Drepturi si obligatii ale 
													partilor privind sanatatea si securiatea in munca</td>
											</tr>
											<TR>
												<TD class="NormalGreenBold">Echipament individual de protectie:</TD>
												<TD>
													<TABLE id="tblEchIndProtectie" border="0" cellSpacing="0" cellPadding="0" width="100%">
														<TR>
															<TD><asp:dropdownlist id="drpEchIndProtectie" runat="server" CssClass="SelectStyle" Width="150" onChange="SetTextBoxVisible('Ep');">
																	<asp:ListItem Value="NU">NU</asp:ListItem>
																	<asp:ListItem>DA</asp:ListItem>
																	<asp:ListItem Value="DA - specific meseriei">DA - specific meseriei</asp:ListItem>
																</asp:dropdownlist></TD>
														</TR>
														<TR>
															<TD><asp:textbox id="txtEchIndProtectie" runat="server" CssClass="NormalEditBoxuri" MaxLength="50"
																	Width="150px" TextMode="MultiLine"></asp:textbox></TD>
														</TR>
													</TABLE>
												</TD>
											</TR>
											<TR>
												<TD class="GreenSeparator" colSpan="2"><IMG src="images/1x1.gif" height="1"></TD>
											</TR>
											<TR>
												<TD class="NormalGreenBold">Echipament individual de lucru:</TD>
												<TD>
													<TABLE id="tblEchIndLucru" border="0" cellSpacing="0" cellPadding="0" width="100%">
														<TR>
															<TD><asp:dropdownlist id="drpEchIndLucru" runat="server" CssClass="SelectStyle" Width="150" onChange="SetTextBoxVisible('El');">
																	<asp:ListItem Value="NU">NU</asp:ListItem>
																	<asp:ListItem Value="DA">DA</asp:ListItem>
																	<asp:ListItem Value="DA - specific meseriei">DA - specific meseriei</asp:ListItem>
																</asp:dropdownlist></TD>
														</TR>
														<TR>
															<TD><asp:textbox id="txtEchIndLucru" runat="server" CssClass="NormalEditBoxuri" MaxLength="50" Width="150px"
																	TextMode="MultiLine"></asp:textbox></TD>
														</TR>
													</TABLE>
												</TD>
											</TR>
											<tr>
												<td class="GreenSeparator" colSpan="2"><IMG src="images/1x1.gif" height="1"></td>
											</tr>
											<TR>
												<TD class="NormalGreenBold">Materiale igienico sanitare:</TD>
												<TD>
													<TABLE id="tblMatIgiSan" border="0" cellSpacing="0" cellPadding="0" width="100%">
														<TR>
															<TD><asp:dropdownlist id="drpMatIgiSan" runat="server" CssClass="SelectStyle" Width="150" onChange="SetTextBoxVisible('Mis');">
																	<asp:ListItem Value="NU">NU</asp:ListItem>
																	<asp:ListItem Value="DA">DA</asp:ListItem>
																	<asp:ListItem Value="DA - specific meseriei">DA - specific meseriei</asp:ListItem>
																</asp:dropdownlist></TD>
														</TR>
														<tr>
															<td><asp:textbox id="txtMatIgiSan" runat="server" CssClass="NormalEditBoxuri" MaxLength="50" Width="150px"
																	TextMode="MultiLine"></asp:textbox></td>
														</tr>
													</TABLE>
												</TD>
											</TR>
											<tr>
												<td class="GreenSeparator" colSpan="2"><IMG src="images/1x1.gif" height="1"></td>
											</tr>
											<TR>
												<TD class="NormalGreenBold">Alimentatie de protectie:</TD>
												<TD>
													<TABLE id="tblAlimProtectie" border="0" cellSpacing="0" cellPadding="0" width="100%">
														<TR>
															<TD><asp:dropdownlist id="drpAlimProtectie" runat="server" CssClass="SelectStyle" Width="150" onChange="SetTextBoxVisible('Ap');">
																	<asp:ListItem Value="NU">NU</asp:ListItem>
																	<asp:ListItem Value="DA">DA</asp:ListItem>
																	<asp:ListItem Value="DA - specific meseriei">DA - specific meseriei</asp:ListItem>
																</asp:dropdownlist></TD>
														</TR>
														<tr>
															<td><asp:textbox id="txtAlimProtectie" runat="server" CssClass="NormalEditBoxuri" MaxLength="50"
																	Width="150px" TextMode="MultiLine"></asp:textbox></td>
														</tr>
													</TABLE>
												</TD>
											</TR>
											<tr>
												<td class="GreenSeparator" colSpan="2"><IMG src="images/1x1.gif" height="1"></td>
											</tr>
											<TR>
												<TD class="NormalGreenBold">Alte drepturi si obligatii privind sanatatea si 
													securitatea in munca:</TD>
												<TD>
													<TABLE id="tblAlteDrSiObl" border="0" cellSpacing="0" cellPadding="0" width="100%">
														<TR>
															<TD><asp:dropdownlist id="drpAlteDrSiObl" runat="server" CssClass="SelectStyle" Width="150" onChange="SetTextBoxVisible('Ado');">
																	<asp:ListItem Value="NU">NU</asp:ListItem>
																	<asp:ListItem Value="DA">DA</asp:ListItem>
																	<asp:ListItem Value="DA - specific meseriei">DA - specific meseriei</asp:ListItem>
																</asp:dropdownlist></TD>
														</TR>
														<tr>
															<TD><asp:textbox id="txtAlteDrSiObl" runat="server" CssClass="NormalEditBoxuri" Width="150px" TextMode="MultiLine"></asp:textbox></TD>
														</tr>
													</TABLE>
												</TD>
											</TR>
										</TBODY>
									</TABLE>
								</td>
								<!-- Alerte speciale -->
								<td id="tableAlerteSpeciale" class="tabBackground" colSpan="8">
									<TABLE border="0" cellSpacing="1" cellPadding="0" width="100%">
										<TBODY>
											<tr>
												<td class="HeaderGreenBold" colSpan="3" align="center">Alerte speciale atasate 
													angajatului</td>
											</tr>
											<tr>
												<td class="NormalGreenBold" colSpan="2" align="center"><br>
													Date despre alerta
												</td>
												<td class="NormalGreenBold" align="center"><br>
													Alerte (Descriere,Data Expirare,Numar zile,Activ)<br>
												</td>
											</tr>
											<tr>
												<td style="HEIGHT: 1px" class="GreenSeparator" colSpan="3"><IMG src="../images/1x1.gif" height="1"></td>
											</tr>
											<tr>
												<!-- Tabelul cu datele despre alerta -->
												<td align="center">
													<table>
														<tr>
															<TD class="NormalGreenBold">Descriere:</TD>
															<TD><asp:textbox id="txtDescriereAlerta" runat="server" CssClass="NormalEditBoxuri" Width="113px"
																	TextMode="MultiLine"></asp:textbox><span class="CommentRedBold">*</span>
															</TD>
														</tr>
														<tr>
															<TD class="NormalGreenBold">Data expirarii:</TD>
															<TD><asp:textbox style="CURSOR: hand" id="txtDataExpirare" onclick="ShowCalendar(this,'')" runat="server"
																	CssClass="NormalEditBoxuri" Width="113px" ReadOnly="True"></asp:textbox><span class="CommentRedBold">*</span>
															</TD>
														</tr>
														<tr>
															<TD class="NormalGreenBold">Nr.zile pentru declansare alerta:</TD>
															<TD><asp:textbox id="txtPerioadaCritica" runat="server" CssClass="NormalEditBoxuri" Width="113px"></asp:textbox><span class="CommentRedBold">*</span>
															</TD>
														</tr>
														<tr id="trActiv" runat="server">
															<TD class="NormalGreenBold">Activ:</TD>
															<TD class="NormalGreenBold"><input id="chkActiv" type="checkbox" name="chkActiv" runat="server"></TD>
														</tr>
													</table>
												</td>
												<!-- Butonul de inserarea a alertei in lista cu alerte -->
												<td align="center"><input id="butInserareAlerta" class="ButtonStyle" onclick="javascript:InserareAlerta()"
														value="Adauga" type="button">
												</td>
												<!-- Lista cu alertele speciale -->
												<td align="center"><br>
													<table>
														<tr>
															<td><SELECT style="WIDTH: 230px; HEIGHT: 130px" id="lstAlerteSpeciale" size="13"></SELECT>
															</td>
														</tr>
														<tr>
															<td align="center"><input id="butStergeAlerta" class="ButtonStyle" onclick="javascript:StergeAlerte()" value="Sterge Alerta"
																	type="button"><br>
																<br>
															</td>
														</tr>
													</table>
												</td>
											</tr>
										</TBODY>
									</TABLE>
								</td>
							</tr>
							<tr>
								<td colSpan="8" align="right">
									<table border="0" cellSpacing="0" cellPadding="0" width="100%">
										<tr>
											<td class="CommentRedBold">* - Campuri obligatorii</td>
											<td align="right"><input style="DISPLAY: none" id="btnPrev" class="ButtonStyle" onmouseover="MouseOverButton(this)"
													onmouseout="MouseOutButton(this)" onclick="NextTab('back')" value="  << Back  " type="button" name="btnPrev">&nbsp;
												<input id="btnNext" class="ButtonStyle" onmouseover="MouseOverButton(this)" onmouseout="MouseOutButton(this)"
													onclick="NextTab('next')" value="  Next >>  " type="button" name="btnNext">
											</td>
										</tr>
									</table>
								</td>
							<tr>
								<td height="50" colSpan="8" align="center"><input id="btnInapoi" class="ButtonStyle" onmouseover="MouseOverButton(this)" onmouseout="MouseOutButton(this)"
										onclick="document.location='SearchAngajati.aspx'" value="  Inapoi  " type="button">&nbsp;&nbsp;
									<asp:button id="butSaveAngajat" onmouseover="MouseOverButton(this)" onmouseout="MouseOutButton(this)"
										runat="server" cssclass="ButtonStyle" Text="Save date angajat" Visible="True"></asp:button><input id="butSaveAngajatInput" class="ButtonStyle" onmouseover="MouseOverButton(this)"
										onmouseout="MouseOutButton(this)" onclick="ButSaveAngajatInput_Click();" value="Salveaza date" type="button" runat="server">
								</td>
							</tr>
							<tr>
								<td colSpan="8" align="center"></td>
							</tr>
						</TABLE>
						<asp:validationsummary id="ValidationSummary1" runat="server" CssClass="AlertRedBold" Width="259px" ShowMessageBox="True"
							ShowSummary="False"></asp:validationsummary></td>
				</tr>
			</table>
			<input id="txtAlerteHidden" type="hidden" name="txtAlerteHidden" runat="server">
			<input id="DTaraHidden" type="hidden" name="DTaraHidden" runat="server"> <input id="RTaraHidden" type="hidden" name="RTaraHidden" runat="server">
			<input id="DJudetSectorHidden" type="hidden" name="DJudetSectorHidden" runat="server">
			<input id="RJudetSectorHidden" type="hidden" name="RJudetSectorHidden" runat="server">
			<input id="TaraNastereHidden" type="hidden" name="TaraNastere" runat="server"> <input id="JudetNastereHidden" type="hidden" name="JudetNastere" runat="server">
			<input id="TaraBazaIDHidden" type="hidden" name="TaraBazaIDHidden" runat="server" size="1">
			<INPUT id="PunctLucruHidden" type="hidden" name="TaraNastere" runat="server"><INPUT id="CaseDeAsigurareHidden" type="hidden" name="TaraNastere" runat="server">
			<INPUT id="categorieIdHidden" type="hidden" runat="server"><INPUT id="functieIdHidden" type="hidden" runat="server"></form>
		<SCRIPT>
			AscundeControaleVenituriBrute();
			tab1.click();
			FirstPunctLucru();
			FirstCategorie();
		</SCRIPT>
	</body>
</HTML>
