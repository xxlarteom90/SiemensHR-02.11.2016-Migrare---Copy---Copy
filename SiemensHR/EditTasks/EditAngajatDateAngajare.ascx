<%@ Control Language="c#" AutoEventWireup="false" Codebehind="EditAngajatDateAngajare.ascx.cs" Inherits ="SiemensHR.EditAngajatDateAngajare" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>


<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>HR Toolkit</title>
		<!--<meta content="True" name="vs_showGrid">-->
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="StyleHR.css" type="text/css" rel="stylesheet">
		<script language="javascript" src="../js/jsCode.js"></script>
	</HEAD>
	<body onload="eNedeterminata()">
		<script>
	var arTabs = new Array('tableEditDateAngajat', 'tableEditAlteDate');
	var formObj;
	var oNewWindow = null;	


	function SelectTab(index)
	{
		for(i=0; i<arTabs.length; i++)
		{
			if (i==index)
			{
				eval(arTabs[i] + ".style.display=''");
				eval(ctrlID+"_tab"+ (i+1)+ ".className='tabActive'");
				formObj.btnNext.style.display = "";
				formObj.btnPrev.style.display = "";
				if (i==0)
					formObj.btnPrev.style.display = "none";
				if (i==(arTabs.length-1))
					formObj.btnNext.style.display = "none";
					
			}
			else
			{
				eval(ctrlID+"_tab"+ (i+1) + ".className='tab'");
				eval(ctrlID+"_tab"+ (i+1) + ".style.backgroundColor='#7b8fc2'");
				eval(arTabs[i] + ".style.display='none'");
			}
		}
		lstAngajatorChanged();
		//var lstPunctLucruClient = document.getElementById( lstPunctLucru );
		//alert("select tab: pct lucru vechi"+document.getElementById(txtHiddenPunctLucruVechi).value);
		//lstPunctLucruClient.value = document.getElementById(txtHiddenPunctLucruVechi).value;
	}
	
	function NextTab( dir )
	{
		for(var i=0; i<arTabs.length; i++)
		{
			eval("className = " + ctrlID + "_tab"+ (i+1) + ".className;");
			if (className=='tabActive')
			{
				if (dir=="next")
				{				
					eval(ctrlID + "_tab" + (i+2) + ".style.backgroundColor='#20b2aa'");				
					eval(ctrlID + "_tab" + (i+2) + ".click()");					
					if (i==(arTabs.length-2))
						formObj.btnNext.style.display = "none";
					formObj.btnPrev.style.display = "";
					
				}
				if (dir=="back")
				{
					eval(ctrlID + "_tab" + i + ".style.backgroundColor='#20b2aa'");				
					eval(ctrlID + "_tab" + i + ".click()");

					formObj.btnNext.style.display = "";
					if (i==1)
						formObj.btnPrev.style.display = "none";
				}				
				break;
			}
		}
	}
	function eNedeterminata()
	{     
		if (document.getElementById(ctrlID+"_lstPerAngajarii").selectedIndex==0)
		{   
			eval(ctrlID+"_Form1."+ctrlID+"_txtDataPanaLa.style.display=''");
			eval("labPanaLa.style.display=''");
			eval("spanReq.style.display=''");   
   
			ValidatorEnable(document.getElementById(ctrlID+"_requiredDataPanaLa"),true);
		}
		else
		{
			eval(ctrlID+"_Form1."+ctrlID+"_txtDataPanaLa.style.display='none'");
			eval("labPanaLa.style.display='none'");
			eval("spanReq.style.display='none'");
   
			ValidatorEnable(document.getElementById(ctrlID+"_requiredDataPanaLa"),false);   
		}
	}

	function Sincronizare1()
	{
		if(document.getElementById(ctrlID + "_lstModIncadrare").selectedIndex==0)
		{
			eval("document.getElementById(ctrlID + '_lstTipFisaFiscala').selectedIndex=0");
		}
		else
		{
			eval("document.getElementById(ctrlID + '_lstTipFisaFiscala').selectedIndex=1");
		}
	}

	function Sincronizare2()
	{	
		if (document.getElementById(ctrlID + '_lstTipFisaFiscala').selectedIndex==0)
		{
			eval("document.getElementById(ctrlID + '_lstModIncadrare').selectedIndex=0");
		}
		else
		{
			eval("document.getElementById(ctrlID + '_lstModIncadrare').selectedIndex=1");
		}
	
	}

	//Adaugat:		Oprescu Claudia
	//Data:			07.02.2007
	//Descriere:	In functie de data de la incepere a contracului, sunt selectate lunile care apar pe interfata
	//				pentru cele sase venituri brute anterioare datei angajarii
	function AscundeControaleVenituriBrute()
	{	
		//se obtine de pe interfata data de incepere a angajarii 
		var dataDeLa = document.getElementById(ctrlID + "_txtDataDeLa").value;
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
		document.getElementById(ctrlID + "_txtLuna1").innerText = textUltimeleLuni[5];
		document.getElementById(ctrlID + "_txtLuna2").innerText = textUltimeleLuni[4];
		document.getElementById(ctrlID + "_txtLuna3").innerText = textUltimeleLuni[3];
		document.getElementById(ctrlID + "_txtLuna4").innerText = textUltimeleLuni[2];
		document.getElementById(ctrlID + "_txtLuna5").innerText = textUltimeleLuni[1];
		document.getElementById(ctrlID + "_txtLuna6").innerText = textUltimeleLuni[0];
			
		hiddenLine.style.display='none';
		//daca a fost selectat butonul "Da" sunt ascunse controalele de pe interfata
		if(document.getElementById(ctrlID + "_radioDa").checked)
		{
			document.getElementById(ctrlID + "_txtCAS1").value = "";
			document.getElementById(ctrlID + "_txtCAS2").value = "";
			document.getElementById(ctrlID + "_txtCAS3").value = "";
			document.getElementById(ctrlID + "_txtCAS4").value = "";
			document.getElementById(ctrlID + "_txtCAS5").value = "";
			document.getElementById(ctrlID + "_txtCAS6").value = "";
			ln1.style.display='none';
			ln2.style.display='none';
			ln3.style.display='none';
			ln4.style.display='none';
			ln5.style.display='none';
			ln6.style.display='none';
			sep0.style.display='none';
			sep1.style.display='none';
			sep2.style.display='none';
			sep3.style.display='none';
			sep4.style.display='none';
			sep5.style.display='none';
			sep6.style.display='';
			hiddenLine.style.display='none';
		}
		//altfel sunt afisate controalele pe interfata
		else
		{
			ln1.style.display='';
			ln2.style.display='';
			ln3.style.display='';
			ln4.style.display='';
			ln5.style.display='';
			ln6.style.display='';
			sep0.style.display='';
			sep1.style.display='';
			sep2.style.display='';
			sep3.style.display='';
			sep4.style.display='';
			sep5.style.display='';
			sep6.style.display='';
		}
	}

	function SelectLoc()
	{
		//daca nu a fost introdusa o data de incepere a perioadei de angajare
		if ( document.getElementById(ctrlID + "_txtDataDeLa").value=='')
		{
			//nu se pot specifica nici valori pentru cele sase venituri brute snterioare angajarii
			alert('Nu se pot specifica valorile veniturilor brute daca nu a fost completata data de angajare!');
			document.getElementById(ctrlID + "_radioDa").checked = true;
		}
		//exista deja o data de incepere a perioadei de angajare
		else
		{	
			//sunt completate valorile lunilor de pe interfata si se stabileste stara controalelor pentru cele sase venituri brute
			AscundeControaleVenituriBrute();
		}
	
		if(document.getElementById(ctrlID + "_radioDa").checked)
		{
			document.getElementById(txtHiddenExistaDateCAS).value = 1;
		}
		else
		{
			document.getElementById(txtHiddenExistaDateCAS).value = 0;
		}
	}
	
	function onClickDataDeLa()
	{
		document.getElementById(ctrlID + "_radioDa").checked = true; 
		document.getElementById(ctrlID + "_radioNu").checked = false; 
		AscundeControaleVenituriBrute();
	}
	
	/*function SelectLoc()
	{
		if(document.getElementById(ctrlID + "_radioDa").checked)
		{
			ln1.style.display='none';
			ln2.style.display='none';
			ln3.style.display='none';
			ln4.style.display='none';
			ln5.style.display='none';
			ln6.style.display='none';
			sep0.style.display='none';
			sep1.style.display='none';
			sep2.style.display='none';
			sep3.style.display='none';
			sep4.style.display='none';
			sep5.style.display='none';
			sep6.style.display='';
			hiddenLine.style.display='none';
		}
		else 
		{
			ln1.style.display='';
			ln2.style.display='';
			ln3.style.display='';
			ln4.style.display='';
			ln5.style.display='';
			ln6.style.display='';
			sep0.style.display='';
			sep1.style.display='';
			sep2.style.display='';
			sep3.style.display='';
			sep4.style.display='';
			sep5.style.display='';
			sep6.style.display='';
			hiddenLine.style.display='none';
		}
	}*/
	
	//Cristina Muntean
	//daca in cadrul sectiunii alte date este selectata intr-un dropdownlist opriunea "DA" trebuie facut vizibil textbox-ul
	//corespunzator dropdownlist-ului
	function SetTextBoxVisible(opt)
	{	
		switch (opt)
		{
			case 'Ep':
					var optiune = document.getElementById(drpEchIndProtectieClient).value;
					if(optiune=="DA")
						document.getElementById(txtEchIndProtectieClient).style.display = "";
					else
						document.getElementById(txtEchIndProtectieClient).style.display = "none";
					break;
			case 'El':
					var optiune = document.getElementById(drpEchIndLucruClient).value;
					if(optiune=="DA")
						document.getElementById(txtEchIndLucruClient).style.display = "";
					else
						document.getElementById(txtEchIndLucruClient).style.display = "none";
					break;
			case 'Mis':
					var optiune = document.getElementById(drpMatIgiSanClient).value;
					if(optiune=="DA")
						document.getElementById(txtMatIgiSanClient).style.display = "";
					else
						document.getElementById(txtMatIgiSanClient).style.display = "none";
					break;
			case 'Ap':
					var optiune = document.getElementById(drpAlimProtectieClient).value;
					if(optiune=="DA")
						document.getElementById(txtAlimProtectieClient).style.display = "";
					else
						document.getElementById(txtAlimProtectieClient).style.display = "none";
					break;
			case 'Ado':
					var optiune = document.getElementById(drpAlteDrSiOblClient).value;
					if(optiune=="DA")
						document.getElementById(txtAlteDrSiOblClient).style.display = "";
					else
						document.getElementById(txtAlteDrSiOblClient).style.display = "none";
					break;		
		}
	}


//Ionel Popa ... administrare nomenclatoare
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
		case "categorii":
			h = Calculate_y_coordinate( 400);
			w = Calculate_x_coordinate( 800);
			oNewWindow = window.open("Salarii/AdminCategoriiAngajati_AddAngajat.aspx",null,"height=400,width=800, top=" + h + ",left=" + w + " ,status=yes,toolbar=no,menubar=no,location=no,scrollbars=yes");
			oNewWindow.focus();
			break;
		default:
			break;
	}
}

//Sterge toate intrarile din combo-ul cu categorii
function DeleteCategoriiCombo()
{
	var categoriiCombo = document.getElementById( ctrlID + '_lstCategorie' ); 
	while( categoriiCombo.length > 0 )
	{
		categoriiCombo.remove( categoriiCombo.selectedIndex );
	}
}

//Adauga o intrare la combo-ul cu categorii
function FillCategorieCombo( categorieText, categorieValoare)
{
	var categoriiCombo = document.getElementById( ctrlID + '_lstCategorie' );
	var o = new Option();
	o.text = categorieText;
	o.value = categorieValoare;
	categoriiCombo.add( o, 0 ); 
}

//Oprescu Claudia
//se incarca punctele de lucru ale unui angajator
function lstAngajatorChanged()
{
	var angajator = document.getElementById(lstAngajator);
	var PunctLucru = document.getElementById(lstPunctLucru);
	
	PunctLucru.options.length = 0;
	for (i=0; i<angajatorPunctLucru[0].length; i++)
	{
		if (angajator.options[ angajator.selectedIndex ].value == angajatorPunctLucru[0][i])
		{
			var selText =  angajatorPunctLucru[2][i];
			var selValue = angajatorPunctLucru[1][i];
			var o = new Option();
			o.text = selText;
			o.value = selValue;
			PunctLucru.add(o);
		}
	}
	if (PunctLucru.length > 0)
	{
		//Lungu Andreea
		if (document.getElementById(txtHiddenPunctLucru).value.length==0)
		{
			document.getElementById(txtHiddenPunctLucru).value = PunctLucru.options[0].value;
		}	
		var i = 0;	
		while( i<sirPuncteLucru.length )
		{
			if (document.getElementById(txtHiddenPunctLucru).value == sirPuncteLucru[i][0])
			{
				var drpPuncteLucruClient = document.getElementById(lstPunctLucru);
				var c =0;
				for ( c = 0; c < drpPuncteLucruClient.length; c++ ) 
				{
					if ( drpPuncteLucruClient.options[c].value == sirPuncteLucru[i][0] )
					{
						drpPuncteLucruClient.selectedIndex = c;
					}
				}
			}
			i++;
		}
	}
}

//Oprescu Claudia
//se actualizeaza punctele care retine lista cu Puncte de lucru
/*function ChangePunctLucru()
{
	var lstPunctLucruClient = document.getElementById( lstPunctLucru );
	document.getElementById(txtHiddenPunctLucru).innerText=lstPunctLucruClient.options[lstPunctLucruClient.selectedIndex ].value;
}

//Oprescu Claudia
function ChangeCasaDeAsigurari()
{
	var lstCasaDeAsigurariClient = document.getElementById( lstCasaDeAsigurari );
	document.getElementById(txtHiddenCasaDeAsigurari).innerText=lstCasaDeAsigurariClient.options[lstCasaDeAsigurariClient.selectedIndex ].value;
}*/

//Lungu Andreea 28.05.2008
function PunctLucruChanged(punctLucru)
{
	document.getElementById( txtHiddenPunctLucru ).value = punctLucru.value;
	var i = 0;
	while( i<sirPuncteLucru.length )
	{
		if (punctLucru.value == sirPuncteLucru[i][0])
		{
			var drpCaseDeAsig = document.getElementById(lstCasaDeAsigurari);
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
//Lungu Andreea 28.05.2008
function CaseDeAsigChanged(casaDeAsig)
{
	document.getElementById( txtHiddenCasaDeAsigurari ).value = casaDeAsig.value;
	//alert(document.getElementById( txtHiddenCasaDeAsigurari ).value);
}

//Oprescu Claudia
function ChangeMotivDeAngajare()
{
	var lstMotivDeAngajareClient = document.getElementById( lstMotivDeAngajare );
	document.getElementById(txtHiddenMotivDeAngajare).innerText=lstMotivDeAngajareClient.options[lstMotivDeAngajareClient.selectedIndex ].value;
}

//Oprescu Claudia
function ChangeTipDeAngajat()
{
	var lstTipDeAngajatClient = document.getElementById( lstTipDeAngajat );
	document.getElementById(txtHiddenTipDeAngajat).innerText=lstTipDeAngajatClient.options[lstTipDeAngajatClient.selectedIndex ].value;
}

//pentru vechime - Lungu Andreea - 02.01.2010
function AdaugaPerioadaNoua()
{
	nrCrt++;
	var tblBody = document.getElementById(tabelPerioadeClient).tBodies[0];
	var newRow = tblBody.insertRow(-1);
	var newCell0 = newRow.insertCell(0);
	newCell0.width = '30px';
	newCell0.innerHTML = nrCrt + ".&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;";
	newCell0.className = 'TdBorderBottom';
	newCell0.align = 'right'
	var newCell1 = newRow.insertCell(1);
	newCell1.width = '40px';
	newCell1.className = 'TdBorderBottom';
	newCell1.innerHTML = 'De la:';
	var newCell2 = newRow.insertCell(2);
	newCell2.width = '70px';
	newCell2.className = 'TdBorderBottom';
	newCell2.innerHTML = '<input type="input" type="text" class="NormalEditBoxuri" maxLength="10" size="16" onchange="RefaSiruri()" onkeypress="DataKeyPressed(this)"/>';
	var newCell3 = newRow.insertCell(3);
	newCell3.width = '40px';
	newCell3.className = 'TdBorderBottom';
	newCell3.innerHTML = 'Pana la:';
	var newCell4 = newRow.insertCell(4);
	newCell4.width = '70px'
	newCell4.className = 'TdBorderBottom';
	newCell4.innerHTML = '<input type="input" type="text" class="NormalEditBoxuri" maxLength="10" size="16" onchange="RefaSiruri()" onkeypress="DataKeyPressed(this)"/>';		
	var newCell5 = newRow.insertCell(5);
	newCell5.className = 'TdBorderBottom';
	newCell5.width = '60px';
	newCell5.innerHTML = 'La Siemens: ';
	var newCell6 = newRow.insertCell(6);
	newCell6.className = 'TdBorderBottom';
	newCell6.width = '20px';
	newCell6.innerHTML = '<input type="radio" name="LaSiemens' + nrCrt + '" value="1" onchange="RefaSiruri()">Da';
	var newCell7 = newRow.insertCell(7);
	newCell7.className = 'TdBorderBottom';
	newCell7.width = '20px';
	newCell7.innerHTML = '<input type="radio" name="LaSiemens' + nrCrt + '" value="0" onchange="RefaSiruri()">Nu';
	var newCell8 = newRow.insertCell(8);
	newCell8.className = 'TdBorderBottom';
	newCell8.width = '1px';
	newCell8.innerHTML = '<input type="input" type="text" style="DISPLAY: none" maxLength="10" size="16" />';
}
//pentru vechime - Lungu Andreea - 02.01.2010
function LoadPerioadeExistente()
{
	if (sirIdPerioadaClient.length > 0)
	{
		document.getElementById(rbDaID).checked = false;
		document.getElementById(rbNuID).checked = true;
		for(var i=0; i<sirIdPerioadaClient.length;i++ )
		{        
			nrCrt++;
			var tblBody = document.getElementById(tabelPerioadeClient).tBodies[0];
			var newRow = tblBody.insertRow(-1);
			var newCell0 = newRow.insertCell(0);
			newCell0.width = '30px';
			newCell0.innerHTML = nrCrt + ".&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;";
			newCell0.className = 'TdBorderBottom';
			newCell0.align = 'right'
			var newCell1 = newRow.insertCell(1);
			newCell1.width = '40px';
			newCell1.innerHTML = 'De la:';
			newCell1.className = 'TdBorderBottom';
			var newCell2 = newRow.insertCell(2);
			newCell2.className = 'TdBorderBottom';
			newCell2.width = '70px';
			newCell2.innerHTML = '<input type="input" type="text"  class="NormalEditBoxuri"  maxLength="10" size="16" value="' + sirDataDeLaClient[i] + '" onchange="RefaSiruri()" onkeypress="DataKeyPressed(this)"/>';
			var newCell3 = newRow.insertCell(3);
			newCell3.width = '40px';
			newCell3.innerHTML = 'Pana la:';
			newCell3.className = 'TdBorderBottom';
			var newCell4 = newRow.insertCell(4);
			newCell4.width = '70px'
			newCell4.className = 'TdBorderBottom';
			newCell4.innerHTML = '<input type="input" type="text" class="NormalEditBoxuri" maxLength="10" size="16" value="' + sirDataPanaLaClient[i] + '" onchange="RefaSiruri()" onkeypress="DataKeyPressed(this)"/>';		
			var newCell5 = newRow.insertCell(5);
			newCell5.className = 'TdBorderBottom';
			newCell5.width = '60px';
			newCell5.innerHTML = 'La Siemens: ';
			var newCell6 = newRow.insertCell(6);
			newCell6.className = 'TdBorderBottom';
			newCell6.width = '20px';
			if (sirLaSiemensClient[i] == 1)
				newCell6.innerHTML = '<input type="radio" name="LaSiemens' + nrCrt + '" value="1" onchange="RefaSiruri()" checked>Da';
			else
				newCell6.innerHTML = '<input type="radio" name="LaSiemens' + nrCrt + '" value="1" onchange="RefaSiruri()" >Da';
			var newCell7 = newRow.insertCell(7);
			newCell7.className = 'TdBorderBottom';
			newCell7.width = '20px';
			if (sirLaSiemensClient[i] == 1)
				newCell7.innerHTML = '<input type="radio" name="LaSiemens' + nrCrt + '" value="0" onchange="RefaSiruri()" >Nu';
			else
				newCell7.innerHTML = '<input type="radio" name="LaSiemens' + nrCrt + '" value="0" onchange="RefaSiruri()" checked>Nu';
			var newCell8 = newRow.insertCell(8);
			newCell8.className = 'TdBorderBottom';
			newCell8.width = '1px';
			newCell8.innerHTML = '<input type="input" type="text" style="DISPLAY: none" maxLength="10" size="16" value="' + sirIdPerioadaClient[i] + '"/>';
		}
	}	
	else
	{
		document.getElementById(rbDaID).checked = true;
		document.getElementById(rbNuID).checked = false;
	}
	PrimaAngajare();
}

//pentru vechime - Lungu Andreea - 02.01.2010	
//am adaugat radio button - la siemens Da, nu - 23.11.2011
function RefaSiruri()
{
	var sirDataDeLaClientInitial = sirDataDeLaClient;
	var sirDataPanaLaClientInitial = sirDataPanaLaClient;
	var sirIdPerioadaClientInitial = sirIdPerioadaClient;
	var sirLaSiemensClientInitial = sirLaSiemensClient;
	
	sirDataDeLaClient = "[";
	sirDataPanaLaClient = "[";
	sirIdPerioadaClient = "[";
	sirLaSiemensClient = "[";
	var tabel = document.getElementById(tabelPerioadeClient);
	if (tabel.rows.length > 0)
	{
		for (i=1; i<tabel.rows.length-1; i++) 
		{
		    //Artiom Modificat 03.04.2017  var dataDeLa = tabel.rows[i].cells[2].childNodes[0].value; 
			var dataDeLa = tabel.rows[i].cells[2].childNodes[0].value; 
			var dataPanaLa = tabel.rows[i].cells[4].childNodes[0].value; 
			if (!ValideazaData(dataDeLa) || !ValideazaData(dataPanaLa))
			{
				document.getElementById(txtSirDataDeLaClient).value = sirDataDeLaClientInitial;
				document.getElementById(txtSirDataPanaLaClient).value = sirDataPanaLaClientInitial;
				document.getElementById(txtSirIdPerioadaClient).value = sirIdPerioadaClientInitial;
				document.getElementById(txtSirLaSiemensClient).value = sirLaSiemensClientInitial;
				alert("Datele introduse nu sunt in formatul corect!");
			}
		    //Artiom Modificat 03.04.2017 var idPer = tabel.rows[i].cells[8].childNodes[0].value; 
			var idPer = tabel.rows[i].cells[8].childNodes[0].value; 
			var LaSiemensDa = tabel.rows[i].cells[6].childNodes[0].value;
			var LaSiemensNu = tabel.rows[i].cells[7].childNodes[0].value;
			sirDataDeLaClient += "'" + dataDeLa + "',";
			sirDataPanaLaClient += "'" + dataPanaLa + "',";
			if (idPer == "")
				sirIdPerioadaClient += 0 + ",";
			else
			    sirIdPerioadaClient += idPer + ",";
		    //Artiom Modificat 03.04.2017 if (tabel.rows[i].cells[6].childNodes[0].checked)
			if (tabel.rows[i].cells[6].childNodes[0].checked)
				sirLaSiemensClient += "1,";
			else
				sirLaSiemensClient += "0,";
		} 
	}
	if (tabel.rows.length > 1)
	{
	    //Artiom Modificat 03.04.2017 var dataDeLa = tabel.rows[tabel.rows.length-1].cells[2].childNodes[0].value; 
		var dataDeLa = tabel.rows[tabel.rows.length-1].cells[2].childNodes[0].value; 
		var dataPanaLa = tabel.rows[tabel.rows.length-1].cells[4].childNodes[0].value; 
		if (!ValideazaData(dataDeLa) || !ValideazaData(dataPanaLa))
		{
			document.getElementById(txtSirDataDeLaClient).value = sirDataDeLaClientInitial;
			document.getElementById(txtSirDataPanaLaClient).value = sirDataPanaLaClientInitial;
			document.getElementById(txtSirIdPerioadaClient).value = sirIdPerioadaClientInitial;
			document.getElementById(txtSirLaSiemensClient).value = sirLaSiemensClientInitial;
			alert("Datele introduse nu sunt in formatul corect!");
		}
	    //Artiom Modificat 03.04.2017 var idPer = tabel.rows[tabel.rows.length-1].cells[8].childNodes[0].value;
		var idPer = tabel.rows[tabel.rows.length-1].cells[8].childNodes[0].value; 
		sirDataDeLaClient += "'" + dataDeLa + "']";
		sirDataPanaLaClient += "'" + dataPanaLa + "']";
		if (idPer == "")
			sirIdPerioadaClient += 0 + "]";
		else
		    sirIdPerioadaClient += idPer + "]";
	    //Artiom Modificat 03.04.2017 if (tabel.rows[tabel.rows.length-1].cells[6].childNodes[0].checked)
		if (tabel.rows[tabel.rows.length-1].cells[6].childNodes[0].checked)
				sirLaSiemensClient += "1]";
			else
				sirLaSiemensClient += "0]";
	}
	else
	{
		sirDataDeLaClient = "[]";
		sirDataPanaLaClient = "[]";
		sirIdPerioadaClient = "[]";
		sirLaSiemensClient = "[]";
	}
	document.getElementById(txtSirDataDeLaClient).value = sirDataDeLaClient;
	document.getElementById(txtSirDataPanaLaClient).value = sirDataPanaLaClient;
	document.getElementById(txtSirIdPerioadaClient).value = sirIdPerioadaClient;
	document.getElementById(txtSirLaSiemensClient).value = sirLaSiemensClient;
}
	
//pentru vechime
function ValideazaData(elem) //format zz.ll.aaaa
{
	if (elem!="")
	{
		var sir = elem.split('.');
	
		var zi = parseInt(sir[0],10);
		var luna = parseInt(sir[1],10);
		var an = parseInt(sir[2],10);
		//alert(zi + "," + luna + "," + an);
		if (an > 1900)
		{
			if  ((luna==1 || luna==3 || luna==5 || luna==7 || luna==8 || luna==10 || luna==12) && (zi<=31))
				return true;
			if  ((luna==4 || luna==6 || luna==9 || luna==11) && (zi<=30))
				return true;
			if ((luna==2) && ((an%4==0) && ((an%100!=0) || (an%400==0))) && (zi<=29))
				return true;
			if ((luna==2) && ((an%4!=0) || ((an%100==0) && (an%400!=0))) && (zi<=28))
				return true;
		}
		return false;
	}
	return true;
}

//pt vechime
function PrimaAngajare()
{
	if (document.getElementById(rbDaID).checked)
	{
		document.getElementById(tdPerioadeID).style.display = "none";
		sirDataDeLaClient = "[]";
		sirDataPanaLaClient = "[]";
		sirIdPerioadaClient = "[]";
		document.getElementById(txtSirDataDeLaClient).value = sirDataDeLaClient;
		document.getElementById(txtSirDataPanaLaClient).value = sirDataPanaLaClient;
		document.getElementById(txtSirIdPerioadaClient).value = sirIdPerioadaClient;
	}
	else
	{
		document.getElementById(tdPerioadeID).style.display = "";
		
		//trebuie sa adaug doar daca nu am deja o perioada goala adaugata 
		RefaSiruri();
		var sirData1 = sirDataDeLaClient.split(',');
		var sirData2 = sirDataPanaLaClient.split(',');
		var sirId = sirIdPerioadaClient.split(',');
		var k = true;
		var tabel = document.getElementById(tabelPerioadeClient);
		if (sirId == "[]" && tabel.rows.length==1)
			k = false;
		else
		{
			for (var i=0; i<sirId.length; i++)
				if ((sirId[i] == 0) && (sirData1 == "''") && (sirData2 == "''"))
					k = false;
		}
		if (!k)
			AdaugaPerioadaNoua();
	}
}

function DataKeyPressed(elem)
{
	var value = elem.value;

	if (value.length == 1)
	{
		if (value.charAt(value.length - 1) == ".") elem.value = "";
	}
	else if (value.length == 2)
	{
		if (value.charAt(value.length - 1) == ".")
			 elem.value = "0" + value.charAt(0) + ".";
	}
	else if (value.length == 3)
	{
		if (value.indexOf(".") == -1)
			elem.value = value.substr(0, value.length - 1) + "." + value.charAt(2);
	}
	else if (value.length == 5)
	{
		if (value.charAt(value.length - 1) == ".")
			elem.value = value.charAt(0) + value.charAt(1) + value.charAt(2) + "0" + value.charAt(3) + ".";
	}
	else if (value.length == 6)
	{
		if (value.charAt(value.length - 1) != ".")
			//obj.value = value.substr( 0, value.length-2 )+"."+value.charAt( 6 );
			elem.value = value.substr(0, value.length - 1) + "." + value.charAt(5);

	}
	//elem.value = value;
}
		</script>
		<table cellSpacing="0" cellPadding="0" align="center" border="0">
			<TBODY>
				<tr>
					<td><asp:literal id="litError" runat="server"></asp:literal></td>
				</tr>
				<tr>
					<td align="center">
						<TABLE cellSpacing="0" cellPadding="0" width="600" border="0">
							<tr>
								<td colSpan="2"><IMG height="10" src="../images/1x1.gif"></td>
							</tr>
							<tr>
								<td colSpan="2"><asp:table id="tableTabs" runat="server"></asp:table></td>
							</tr>
							<tr>
								<!--   DATE ANGAJAT -->
								<td class="tabBackground" id="tableEditDateAngajat" colSpan="2">
									<TABLE cellSpacing="1" cellPadding="0" width="620" align="center" border="0">
										<TR>
											<TD class="NormalGreenBold">Marca:</TD>
											<TD><asp:textbox id="txtMarca" runat="server" CssClass="NormalEditBoxuri" MaxLength="8" Width="100px"></asp:textbox><span class="CommentRedBold">*</span>
												<asp:requiredfieldvalidator id="requiredMarca" runat="server" CssClass="AlertRedBold" ErrorMessage="Completati marca!"
													ControlToValidate="txtMarca"><</asp:requiredfieldvalidator><asp:regularexpressionvalidator id="regularMarca" runat="server" CssClass="AlertRedBold" ErrorMessage="Marca nu poate sa contina caractere invalide: <>()';&quot;\ "
													ControlToValidate="txtMarca" ValidationExpression="^[^>|(|)|<|'|&quot;|;|\\]*$"><</asp:regularexpressionvalidator></TD>
										</TR>
										<tr>
											<td class="GreenSeparator" colSpan="2"><IMG height="1" src="../images/1x1.gif"></td>
										</tr>
										<TR>
											<TD class="NormalGreenBold">GID:</TD>
											<TD><asp:textbox id="txtGid" runat="server" CssClass="NormalEditBoxuri" MaxLength="8" Width="100px"></asp:textbox><span class="CommentRedBold">*</span>
												<asp:requiredfieldvalidator id="requiredGid" runat="server" CssClass="AlertRedBold" ErrorMessage="Completati GID-ul!"
													ControlToValidate="txtGid"><</asp:requiredfieldvalidator><asp:regularexpressionvalidator id="regularGid" runat="server" CssClass="AlertRedBold" ErrorMessage="GID-ul nu poate sa contina caractere invalide: <>()';&quot;\ "
													ControlToValidate="txtGid" ValidationExpression="^[^>|(|)|<|'|&quot;|;|\\]*$"><</asp:regularexpressionvalidator></TD>
										</TR>
										<tr>
											<td class="GreenSeparator" colSpan="2"><IMG height="1" src="../images/1x1.gif"></td>
										</tr>
										<TR>
											<TD class="NormalGreenBold">Program de lucru:</TD>
											<TD><asp:textbox id="txtProgramLucru" runat="server" CssClass="NormalEditBoxuri" MaxLength="2" Width="100px"
													Enabled="False"></asp:textbox><span class="CommentRedBold">*
													<asp:requiredfieldvalidator id="requiredProgramLucru" runat="server" CssClass="AlertRedBold" ErrorMessage="Completati program de lucru!"
														ControlToValidate="txtProgramLucru"><</asp:requiredfieldvalidator></span><asp:regularexpressionvalidator id="regularProgramLucru" runat="server" CssClass="AlertRedBold" ErrorMessage="Programul de lucru necesita valoare numerica!"
													ControlToValidate="txtProgramLucru" ValidationExpression="\d*"><  </asp:regularexpressionvalidator></TD>
										</TR>
										<tr>
											<td class="GreenSeparator" colSpan="2"><IMG height="1" src="../images/1x1.gif"></td>
										</tr>
										<tr>
											<td class="NormalGreenBold">Angajator:</td>
											<td><asp:dropdownlist id="lstAngajator" runat="server" CssClass="SelectStyle" Width="300px" onchange="lstAngajatorChanged();"></asp:dropdownlist></td>
										</tr>
										<tr>
											<td class="GreenSeparator" colSpan="2"><IMG height="1" src="../images/1x1.gif"></td>
										</tr>
										<tr>
											<td class="NormalGreenBold" style="HEIGHT: 12px">Punct de lucru:</td>
											<td><asp:dropdownlist id="lstPunctLucru" runat="server" CssClass="SelectStyle" Width="300px" onchange="PunctLucruChanged(this);"></asp:dropdownlist></td>
										</tr>
										<tr>
											<td class="GreenSeparator" style="HEIGHT: 1px" colSpan="2"><IMG height="1" src="../images/1x1.gif"></td>
										</tr>
										<tr>
											<td class="NormalGreenBold" style="HEIGHT: 12px">Casa de asigurari:</td>
											<td><asp:dropdownlist id="lstCasaDeAsigurari" runat="server" CssClass="SelectStyle" Width="300px" onchange="CaseDeAsigChanged(this);"></asp:dropdownlist></td>
										</tr>
										<tr>
											<td class="GreenSeparator" style="HEIGHT: 1px" colSpan="2"><IMG height="1" src="../images/1x1.gif"></td>
										</tr>
										<tr>
											<td class="NormalGreenBold" style="HEIGHT: 12px">Tip asigurat:</td>
											<td><asp:dropdownlist id="lstTipAsigurat" runat="server" CssClass="SelectStyle" Width="300px" onchange="TipuriAsigChanged(this);"></asp:dropdownlist></td>
										</tr>
										<tr>
											<td class="GreenSeparator" style="HEIGHT: 1px" colSpan="2"><IMG height="1" src="../images/1x1.gif"></td>
										</tr>
										<tr>
											<td class="NormalGreenBold">Categorie de incadrare:</td>
											<td><asp:dropdownlist id="lstCategorie" runat="server" CssClass="SelectStyle" Width="300px" Enabled="False"></asp:dropdownlist><INPUT style="DISPLAY: none" onclick="javascript:OpenAdminWindow('categorii')" type="button"
													value="...">
												<asp:requiredfieldvalidator id="requiredCategorie" runat="server" CssClass="AlertRedBold" ErrorMessage="Completati categoria!"
													ControlToValidate="lstCategorie"><</asp:requiredfieldvalidator></td>
										</tr>
										<tr>
											<td class="GreenSeparator" colSpan="2"><IMG height="1" src="../images/1x1.gif"></td>
										</tr>
										<tr>
											<td class="NormalGreenBold">Angajat scutit contributie sanatate:</td>
											<TD vAlign="middle"><asp:radiobuttonlist id="rblRetinereSanatate" runat="server" CssClass="NormalGreenBold" RepeatDirection="Horizontal">
													<asp:ListItem Value="1">Da</asp:ListItem>
													<asp:ListItem Value="0" Selected="True">Nu</asp:ListItem>
												</asp:radiobuttonlist></TD>
										</tr>
										<tr>
											<td class="GreenSeparator" colSpan="4"><IMG height="1" src="images/1x1.gif"></td>
										</tr>
										<tr>
											<td class="NormalGreenBold">Angajat scutit contributie CAS:</td>
											<TD vAlign="middle"><asp:radiobuttonlist id="rblRetinereCAS" runat="server" CssClass="NormalGreenBold" RepeatDirection="Horizontal">
													<asp:ListItem Value="1">Da</asp:ListItem>
													<asp:ListItem Value="0" Selected="True">Nu</asp:ListItem>
												</asp:radiobuttonlist></TD>
										</tr>
										<tr>
											<td class="GreenSeparator" colSpan="4"><IMG height="1" src="images/1x1.gif"></td>
										</tr>
										<tr>
											<td class="NormalGreenBold">Angajat scutit contributie somaj:</td>
											<TD vAlign="middle"><asp:radiobuttonlist id="rblRetinereSomaj" runat="server" CssClass="NormalGreenBold" RepeatDirection="Horizontal">
													<asp:ListItem Value="1">Da</asp:ListItem>
													<asp:ListItem Value="0" Selected="True">Nu</asp:ListItem>
												</asp:radiobuttonlist></TD>
										</tr>
										<tr>
											<td class="GreenSeparator" colSpan="4"><IMG height="1" src="images/1x1.gif"></td>
										</tr>
										<TR>
											<TD class="NormalGreenBold">Mod incadrare:</TD>
											<TD><asp:dropdownlist id="lstModIncadrare" runat="server" CssClass="SelectStyle" Width="300px" onchange="Sincronizare1()">
													<asp:ListItem Value="0">Cu functia de baza</asp:ListItem>
													<asp:ListItem Value="1">Cu functia de baza la alta societate</asp:ListItem>
												</asp:dropdownlist></TD>
										</TR>
										<tr>
											<td class="GreenSeparator" colSpan="2"><IMG height="1" src="../images/1x1.gif"></td>
										</tr>
										<TR>
											<TD class="NormalGreenBold">Motiv angajare:</TD>
											<TD><asp:dropdownlist id="lstMotivDeAngajare" runat="server" CssClass="SelectStyle" Width="300px" onchange="ChangeMotivDeAngajare()"></asp:dropdownlist></TD>
										</TR>
										<tr>
											<td class="GreenSeparator" colSpan="2"><IMG height="1" src="images/1x1.gif"></td>
										</tr>
										<TR>
											<TD class="NormalGreenBold">Tip angajat:</TD>
											<TD><asp:dropdownlist id="lstTipDeAngajat" runat="server" CssClass="SelectStyle" Width="300px" onchange="ChangeTipDeAngajat()"></asp:dropdownlist></TD>
										</TR>
										<tr>
											<td class="GreenSeparator" colSpan="2"><IMG height="1" src="images/1x1.gif"></td>
										</tr>
										<TR>
											<TD class="NormalGreenBold">Tip fisa fiscala:</TD>
											<TD><asp:dropdownlist id="lstTipFisaFiscala" runat="server" Width="300px" onchange="Sincronizare2()" cssclass="SelectStyle">
													<asp:ListItem Value="0">Fisa Fiscala 1</asp:ListItem>
													<asp:ListItem Value="1">Fisa Fiscala 2</asp:ListItem>
												</asp:dropdownlist></TD>
										</TR>
										<tr>
											<td class="GreenSeparator" colSpan="2"><IMG height="1" src="../images/1x1.gif"></td>
										</tr>
										<TR>
											<TD class="NormalGreenBold">Card bancar:</TD>
											<TD><asp:dropdownlist id="lstAreCardBancar" runat="server" CssClass="SelectStyle" Width="300px">
													<asp:ListItem Value="1">Are card bancar</asp:ListItem>
													<asp:ListItem Value="0">NU are card bancar</asp:ListItem>
												</asp:dropdownlist></TD>
										</TR>
										<tr>
											<td class="GreenSeparator" colSpan="2"><IMG height="1" src="../images/1x1.gif"></td>
										</tr>
										<tr>
											<td class="NormalGreenBold">Perioada angajarii:</td>
											<td><select class="SelectStyle" id="lstPerAngajarii" style="WIDTH: 300px" onchange="eNedeterminata()"
													name="lstPerAngajarii" runat="server">
													<option value="1" selected>Determinata</option>
													<option value="0">Nedeterminata</option>
												</select>
												<br>
												<label id="labDeLa">De la:</label>
												<asp:textbox id="txtDataDeLa" style="CURSOR: hand" onclick="onClickDataDeLa(); ShowCalendar(this,'')"
													runat="server" CssClass="NormalEditBoxuri" MaxLength="10" Width="70px" ReadOnly="True" Height="15px"></asp:textbox><span class="CommentRedBold">*</span>
												<label id="labPanaLa">Pana la:</label>
												<asp:textbox id="txtDataPanaLa" style="CURSOR: hand" onclick="ShowCalendar(this,'')" runat="server"
													CssClass="NormalEditBoxuri" MaxLength="10" Width="70px" ReadOnly="True" Height="15px"></asp:textbox><span class="CommentRedBold" id="spanReq">*
													<asp:requiredfieldvalidator id="requiredDataPanaLa" runat="server" CssClass="AlertRedBold" ErrorMessage="Completati data expirarii contractului!"
														ControlToValidate="txtDataPanaLa"><</asp:requiredfieldvalidator></span></SPAN><asp:requiredfieldvalidator id="requiredDataDeLa" runat="server" CssClass="AlertRedBold" ErrorMessage="Completati data inceperii contractului!"
													ControlToValidate="txtDataDeLa"><</asp:requiredfieldvalidator><asp:label id="lblLichidat" runat="server" CssClass="CommentRedBold"></asp:label></td>
											</SPAN></tr>
										<tr>
											<td class="GreenSeparator" colSpan="2"><IMG height="1" src="../images/1x1.gif"></td>
										</tr>
										<TR>
											<TD class="NormalGreenBold">Perioada de proba:</TD>
											<TD><asp:textbox id="txtPerProba" runat="server" CssClass="NormalEditBoxuri" Width="100px"></asp:textbox><asp:regularexpressionvalidator id="regularPerioadaProba" runat="server" CssClass="AlertRedBold" ErrorMessage="Perioada de proba nu poate sa contina caractere invalide: <>()';&quot;\ "
													ControlToValidate="txtPerProba" ValidationExpression="^[^>|(|)|<|'|&quot;|;|\\]*$"><</asp:regularexpressionvalidator><span class="CommentRedBold"></span></TD>
										</TR>
										<tr>
											<td class="GreenSeparator" colSpan="4"><IMG height="1" src="images/1x1.gif"></td>
										</tr>
										<TR>
											<TD class="NormalGreenBold">PM Professional:</TD>
											<TD vAlign="middle" align="left"><asp:radiobuttonlist id="rblPMP" runat="server" CssClass="NormalGreenBold" RepeatDirection="Horizontal">
													<asp:ListItem Value="1">Da</asp:ListItem>
													<asp:ListItem Value="0" Selected="True">Nu</asp:ListItem>
												</asp:radiobuttonlist></TD>
										</TR>
										<tr>
											<td class="GreenSeparator" colSpan="4"><IMG height="1" src="images/1x1.gif"></td>
										</tr>
										<TR>
											<TD class="NormalGreenBold">Cont AZM:</TD>
											<TD vAlign="middle"><asp:radiobuttonlist id="rblAZM" runat="server" CssClass="NormalGreenBold" RepeatDirection="Horizontal">
													<asp:ListItem Value="1" Selected="True">Da</asp:ListItem>
													<asp:ListItem Value="0">Nu</asp:ListItem>
												</asp:radiobuttonlist></TD>
										</TR>
										<TR>
											<TD class="HeaderGreenBold" colSpan="2">Date&nbsp;despre lichidare:</TD>
										</TR>
										<TR>
											<TD class="NormalGreenBold">Lichidat:</TD>
											<td><asp:checkbox id="lichidatCheck" runat="server"></asp:checkbox></td>
										</TR>
										<TR>
										<TR>
											<TD class="HeaderGreenBold" colSpan="2">Date contact</TD>
											<TD></TD>
										</TR>
										<TR>
											<TD class="NormalGreenBold">Telefon</TD>
											<TD><asp:textbox id="txtTelMunca" runat="server" CssClass="NormalEditBoxuri" MaxLength="25" Width="180px"></asp:textbox><asp:regularexpressionvalidator id="Regularexpressionvalidator1" runat="server" CssClass="AlertRedBold" ErrorMessage="Pentru telefon trebuie introduse numai cifre!"
													ControlToValidate="txtTelMunca" ValidationExpression="\d*"><  </asp:regularexpressionvalidator></TD>
										</TR>
										<tr>
											<td class="GreenSeparator" colSpan="2"><IMG height="1" src="../images/1x1.gif"></td>
										</tr>
										<TR>
											<TD class="NormalGreenBold">Email</TD>
											<TD><asp:textbox id="txtEmail" runat="server" CssClass="NormalEditBoxuri" MaxLength="255" Width="180px"></asp:textbox><asp:regularexpressionvalidator id="regularEmail" runat="server" CssClass="AlertRedBold" ErrorMessage="Adresa de email incorecta!"
													ControlToValidate="txtEmail" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"><  </asp:regularexpressionvalidator></TD>
										</TR>
										<tr>
											<td class="GreenSeparator" colSpan="4"><IMG height="1" src="../images/1x1.gif"></td>
										</tr>
										<tr>
											<TD class="HeaderGreenBold" colSpan="2">Date contract munca:</TD>
										</tr>
										<tr>
											<TD class="NormalGreenBold">Sef:</TD>
											<TD><asp:dropdownlist id="lstSef" runat="server" CssClass="SelectStyle" Width="296px"></asp:dropdownlist></TD>
										</tr>
										<tr>
											<td class="GreenSeparator" colSpan="4"><IMG height="1" src="../images/1x1.gif"></td>
										</tr>
										<TR>
											<TD class="NormalGreenBold">Birou</TD>
											<TD><asp:textbox id="txtBirou" runat="server" CssClass="NormalEditBoxuri" MaxLength="12" Width="100px"></asp:textbox></TD>
										</TR>
										<tr>
											<td class="GreenSeparator" colSpan="4"><IMG height="1" src="../images/1x1.gif"></td>
										</tr>
										<TR>
											<TD class="NormalGreenBold">Numar contract munca:</TD>
											<TD><asp:textbox id="txtNrContractMunca" runat="server" CssClass="NormalEditBoxuri" MaxLength="12"
													Width="100px"></asp:textbox><SPAN class="CommentRedBold">*</SPAN>
												<asp:requiredfieldvalidator style="Z-INDEX: 0" id="reqFieldValNrContractMunca" runat="server" CssClass="AlertRedBold"
													ControlToValidate="txtNrContractMunca" ErrorMessage="Completati Nr. contract munca!"><</asp:requiredfieldvalidator><asp:regularexpressionvalidator id="regularNrContract" runat="server" CssClass="AlertRedBold" ErrorMessage="Numarul contractului de munca nu poate sa contina caractere invalide: <>()';&quot;\ "
													ControlToValidate="txtNrContractMunca" ValidationExpression="^[^>|(|)|<|'|&quot;|;|\\]*$" style="Z-INDEX: 0"><</asp:regularexpressionvalidator><span class="CommentRedBold"></span></TD>
										</TR>
										<tr>
											<td class="GreenSeparator" colSpan="2"><IMG height="1" src="../images/1x1.gif"></td>
										</tr>
										<tr>
											<TD class="NormalGreenBold">Data inregistrarii contractului:</TD>
											<TD><asp:textbox id="txtDataInreg" style="CURSOR: hand" onclick="ShowCalendar(this,'')" runat="server"
													CssClass="NormalEditBoxuri" MaxLength="2" Width="100px" ReadOnly="True"></asp:textbox><SPAN class="CommentRedBold">*</SPAN>
												<asp:requiredfieldvalidator style="Z-INDEX: 0" id="reqFieldValDataInregistrareContract" runat="server" CssClass="AlertRedBold"
													ControlToValidate="txtDataInreg" ErrorMessage="Completati Data inregistrarii contractului!"><</asp:requiredfieldvalidator><span class="CommentRedBold"></span></TD>
										</tr>
										<tr>
											<td class="GreenSeparator" colSpan="2"><IMG height="1" src="../images/1x1.gif"></td>
										</tr>
										<tr>
											<TD class="NormalGreenBold">Salariu de incadrare:</TD>
											<TD><asp:textbox id="txtSalariu" runat="server" CssClass="NormalEditBoxuri" Width="100px" Enabled="False"></asp:textbox><span class="CommentRedBold">*
													<asp:comparevalidator id="CompareValidator2" runat="server" CssClass="AlertRedBold" ErrorMessage="Introduceti o suma corecta!"
														ControlToValidate="txtSalariu" Type="Double" Operator="DataTypeCheck"><</asp:comparevalidator></span></TD>
										</tr>
										<tr>
											<td class="GreenSeparator" colSpan="2"><IMG height="1" src="../images/1x1.gif"></td>
										</tr>
										<tr>
											<TD class="NormalGreenBold">Indemnizatia de conducere:</TD>
											<TD><asp:textbox id="txtIndemnizatie" runat="server" CssClass="NormalEditBoxuri" Width="100px" Enabled="False"></asp:textbox><span class="CommentRedBold"><asp:comparevalidator id="CompareValidator3" runat="server" CssClass="AlertRedBold" ErrorMessage="Introduceti o suma corecta!"
														ControlToValidate="txtIndemnizatie" Type="Double" Operator="DataTypeCheck"><</asp:comparevalidator></span></TD>
										</tr>
										<tr>
											<td class="GreenSeparator" colSpan="4"><IMG height="1" src="../images/1x1.gif"></td>
										</tr>
										<tr>
											<TD class="NormalGreenBold">Sporuri:</TD>
											<TD><asp:textbox id="txtSporuri" runat="server" CssClass="NormalEditBoxuri" Width="100px"></asp:textbox><span class="CommentRedBold"><asp:comparevalidator id="vldSporuri" runat="server" CssClass="AlertRedBold" ErrorMessage="Introduceti o suma corecta!"
														ControlToValidate="txtSporuri" Type="Double" Operator="DataTypeCheck"><</asp:comparevalidator></span></TD>
										</tr>
										<tr>
											<td class="GreenSeparator" colSpan="2"><IMG height="1" src="../images/1x1.gif"></td>
										</tr>
										<tr>
											<TD class="NormalGreenBold">Alte adaosuri:</TD>
											<TD><asp:textbox id="txtAlteAdaosuri" runat="server" CssClass="NormalEditBoxuri" Width="100px"></asp:textbox><span class="CommentRedBold"><asp:comparevalidator id="vldAlteAdaosuri" runat="server" CssClass="AlertRedBold" ErrorMessage="Introduceti o suma corecta!"
														ControlToValidate="txtAlteAdaosuri" Type="Double" Operator="DataTypeCheck"><</asp:comparevalidator></span></TD>
										</tr>
										<tr>
											<td class="GreenSeparator" colSpan="2"><IMG height="1" src="../images/1x1.gif"></td>
										</tr>
										<tr>
											<td class="NormalGreenBold">Date majorare:</td>
											<td>
												<table>
													<tr>
														<td>Suma:</td>
														<td><asp:textbox id="txtSumaMajorare" runat="server" CssClass="NormalEditBoxuri" MaxLength="11" Width="100px">0</asp:textbox></td>
														<td>Data:</td>
														<td><asp:textbox id="txtDataPlanificareMajorare" style="CURSOR: hand" onclick="ShowCalendar(this,'')"
																runat="server" CssClass="NormalEditBoxuri" MaxLength="2" Width="70px" ReadOnly="True"></asp:textbox><asp:comparevalidator id="Comparevalidator5" runat="server" CssClass="AlertRedBold" ErrorMessage="Suma majorare - Introduceti o suma corecta!"
																ControlToValidate="txtSumaMajorare" Type="Double" Operator="DataTypeCheck"><</asp:comparevalidator></td>
													</tr>
												</table>
											</td>
										</tr>
										<tr>
											<td class="GreenSeparator" colSpan="2"><IMG height="1" src="../images/1x1.gif"></td>
										</tr>
										<tr>
											<TD class="NormalGreenBold">Nr zile concediu odihna pe an:</TD>
											<TD><asp:textbox id="txtNrZileCOAn" runat="server" CssClass="NormalEditBoxuri" Width="100px"></asp:textbox><span class="CommentRedBold">*
													<asp:comparevalidator id="Comparevalidator1" runat="server" CssClass="AlertRedBold" ErrorMessage="Nr zile CO/an - Introduceti un nr de zile corect!"
														ControlToValidate="txtNrZileCOAn" Type="Integer" Operator="GreaterThanEqual" ValueToCompare="0"><</asp:comparevalidator><asp:requiredfieldvalidator id="requiredNrZileCOAn" runat="server" CssClass="AlertRedBold" ErrorMessage="Completati Nr. zile concediu odihna pe an!"
														ControlToValidate="txtNrZileCOAn"><</asp:requiredfieldvalidator></span></TD>
										</tr>
										<tr>
											<td class="GreenSeparator" colSpan="2"><IMG height="1" src="../images/1x1.gif"></td>
										</tr>
										<tr>
											<TD class="NormalGreenBold">Nr zile concediu suplimentar pe an:</TD>
											<TD><asp:textbox id="txtNrZileCOSupl" runat="server" CssClass="NormalEditBoxuri" Width="100px"></asp:textbox><span class="CommentRedBold">*
													<asp:comparevalidator id="cmpNrZileCoSupl" runat="server" CssClass="AlertRedBold" ErrorMessage="Nr zile CO suplimentar/an - Introduceti un nr de zile corect!"
														ControlToValidate="txtNrZileCOSupl" Type="Integer" Operator="GreaterThanEqual" ValueToCompare="0"><</asp:comparevalidator><asp:requiredfieldvalidator id="requiredNrZileCOSupl" runat="server" CssClass="AlertRedBold" ErrorMessage="Completati Nr. zile concediu suplimentar pe an"
														ControlToValidate="txtNrZileCOSupl"><</asp:requiredfieldvalidator></span></TD>
										</tr>
										<tr>
											<td class="GreenSeparator" colSpan="2"><IMG height="1" src="../images/1x1.gif"></td>
										</tr>
										<tr>
											<TD class="NormalGreenBold">Alte clauze ale contractului individual de munca:</TD>
											<TD><asp:textbox id="txtAlteClauzeCIM" runat="server" CssClass="NormalEditBoxuri" Width="296px" TextMode="MultiLine"></asp:textbox></TD>
										</tr>
										<TR>
											<TD class="HeaderGreenBold" colSpan="2">Vechime in munca:</TD>
										</TR>
										<TR>
											<TD colSpan="2">
												<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
													<TR>
														<TD>
															<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0">
																<TR>
																	<TD class="NormalGreenBold" width="50%">Acest angajat se afla la prima sa 
																		angajare:&nbsp;</TD>
																	<TD class="NormalGreenBold" width="50%">&nbsp;<INPUT id="radioButtonDa" onclick="PrimaAngajare()" type="radio" value="radioButtonDa"
																			name="groupRBPrimaAngajare" runat="server">&nbsp;Da <INPUT id="radioButtonNu" onclick="PrimaAngajare()" type="radio" value="radioButtonNu"
																			name="groupRBPrimaAngajare" runat="server">&nbsp;Nu</TD>
																</TR>
																<TR>
																	<TD class="GreenSeparator" width="50%" colSpan="5"><IMG height="1" src="../images/1x1.gif"></TD>
																</TR>
															</TABLE>
														</TD>
													</TR>
													<TR>
														<TD id="tdPerioade" runat="server">
															<TABLE id="tabelPerioade" cellSpacing="1" cellPadding="1" width="100%" border="0" runat="server">
																<TR>
																	<TD></TD>
																</TR>
															</TABLE>
															<TABLE id="Table4" cellSpacing="1" cellPadding="1" width="100%" border="0">
																<TR>
																	<td class="CommentRedBold">Va rugam introduceti data in formatul zz.ll.aaaa sau 
																		zzllaaaa.</td>
																</TR>
																<TR>
																	<TD align="center"><INPUT class="ButtonStyle" id="btnAdaugaPerioadaNoua" onclick="AdaugaPerioadaNoua()" type="button"
																			value="Adauga o noua perioada" name="btnAdaugaPerioadaNoua"></TD>
																</TR>
															</TABLE>
														</TD>
													</TR>
													<TR>
														<TD>
															<P><INPUT id="txtSirDeLa" type="hidden" name="txtSirDeLa" runat="server"><INPUT id="txtSirPanaLa" type="hidden" name="txtSirPanaLa" runat="server"><INPUT id="txtSirIdPerioada" type="hidden" name="txtSirIdPerioada" runat="server"><INPUT style="Z-INDEX: 0" id="txtSirLaSiemens" type="hidden" name="txtSirIdPerioada" runat="server"></P>
														</TD>
													</TR>
													<TR>
														<TD>
															<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="100%" border="0">
																<TR>
																	<TD class="NormalBlackBold" width="41%">Vechime la angajatorul anterior:</TD>
																	<TD align="right" width="10%"><asp:label id="lAniAngAnterior" CssClass="NormalBlackBold" Runat="server"></asp:label></TD>
																	<TD align="right" width="10%"><asp:label id="lLuniAngAnterior" CssClass="NormalBlackBold" Runat="server"></asp:label></TD>
																	<TD align="right" width="10%"><asp:label id="lZileAngAnterior" CssClass="NormalBlackBold" Runat="server"></asp:label></TD>
																	<TD align="right" width="17%"><asp:label id="lTotalAngAnterior" CssClass="NormalBlackBold" Runat="server"></asp:label></TD>
																	<td width="2%">&nbsp;</td>
																</TR>
																<TR>
																	<TD class="GreenSeparator" align="right" width="19%" colSpan="6"><IMG height="1" src="../images/1x1.gif"></TD>
																</TR>
																<TR>
																	<TD class="NormalBlackBold" width="41%">Intrerupere fata de angajatorul curent:</TD>
																	<TD align="right" width="10%"><asp:label id="lAniIntrerupere" CssClass="NormalBlackBold" Runat="server"></asp:label></TD>
																	<TD align="right" width="10%"><asp:label id="lLuniIntrerupere" CssClass="NormalBlackBold" Runat="server"></asp:label></TD>
																	<TD align="right" width="10%"><asp:label id="lZileIntrerupere" CssClass="NormalBlackBold" Runat="server"></asp:label></TD>
																	<TD align="right" width="19%"><asp:label id="lTotalIntrerupere" CssClass="NormalBlackBold" Runat="server"></asp:label></TD>
																	<td width="2%">&nbsp;</td>
																</TR>
																<TR>
																	<TD class="GreenSeparator" align="right" width="19%" colSpan="6"><IMG height="1" src="../images/1x1.gif"></TD>
																</TR>
																<TR>
																	<TD class="NormalBlackBold" width="41%">Vechime totala anterioara:</TD>
																	<TD align="right" width="10%"><asp:label id="lAniAnterior" CssClass="NormalBlackBold" Runat="server"></asp:label></TD>
																	<TD align="right" width="10%"><asp:label id="lLuniAnterior" CssClass="NormalBlackBold" Runat="server"></asp:label></TD>
																	<TD align="right" width="10%"><asp:label id="lZileAnterior" CssClass="NormalBlackBold" Runat="server"></asp:label></TD>
																	<TD align="right" width="19%"><asp:label id="lTotalAnterior" CssClass="NormalBlackBold" Runat="server"></asp:label></TD>
																	<td width="2%">&nbsp;</td>
																</TR>
																<TR>
																	<TD class="GreenSeparator" align="right" width="19%" colSpan="6"><IMG height="1" src="../images/1x1.gif"></TD>
																</TR>
																<TR>
																	<TD class="NormalBlackBold" width="41%">Vechime la angajatorul curent:</TD>
																	<TD align="right" width="10%"><asp:label id="lAniAngCurent" CssClass="NormalBlackBold" Runat="server"></asp:label></TD>
																	<TD align="right" width="10%"><asp:label id="lLuniAngCurent" CssClass="NormalBlackBold" Runat="server"></asp:label></TD>
																	<TD align="right" width="10%"><asp:label id="lZileAngCurent" CssClass="NormalBlackBold" Runat="server"></asp:label></TD>
																	<TD align="right" width="19%"><asp:label id="lTotalAngCurent" CssClass="NormalBlackBold" Runat="server"></asp:label></TD>
																	<td width="2%">&nbsp;</td>
																</TR>
																<TR>
																	<TD class="GreenSeparator" align="right" width="19%" colSpan="6"><IMG height="1" src="../images/1x1.gif"></TD>
																</TR>
																<TR>
																	<TD class="NormalBlackBold" width="41%">Vechime totala in munca:</TD>
																	<TD align="right" width="10%"><asp:label id="lAniTotal" CssClass="NormalBlackBold" Runat="server"></asp:label></TD>
																	<TD align="right" width="10%"><asp:label id="lLuniTotal" CssClass="NormalBlackBold" Runat="server"></asp:label></TD>
																	<TD align="right" width="10%"><asp:label id="lZileTotal" CssClass="NormalBlackBold" Runat="server"></asp:label></TD>
																	<TD align="right" width="19%"><asp:label id="lTotal" CssClass="NormalBlackBold" Runat="server"></asp:label></TD>
																	<td width="2%">&nbsp;</td>
																</TR>
															</TABLE>
														</TD>
													</TR>
												</TABLE>
											</TD>
										</TR>
										<TR>
											<TD class="HeaderGreenBold" colSpan="2">Date carnet de munca:</TD>
										</TR>
										<TR>
											<TD class="NormalGreenBold">Serie:</TD>
											<td><asp:textbox id="txtCMSerie" runat="server" CssClass="NormalEditBoxuri" MaxLength="5" Width="100px"></asp:textbox><asp:regularexpressionvalidator id="regularSerie" runat="server" CssClass="AlertRedBold" ErrorMessage="Seria carnetului de munca nu poate sa contina caractere invalide: <>()';&quot;\ "
													ControlToValidate="txtCMSerie" ValidationExpression="^[^>|(|)|<|'|&quot;|;|\\]*$"><</asp:regularexpressionvalidator></td>
										</TR>
										<tr>
											<td class="GreenSeparator" colSpan="2"><IMG height="1" src="../images/1x1.gif"></td>
										</tr>
										<TR>
											<TD class="NormalGreenBold">Numar:</TD>
											<TD><asp:textbox id="txtCMNumar" runat="server" CssClass="NormalEditBoxuri" MaxLength="10" Width="100px"></asp:textbox><asp:regularexpressionvalidator id="regularNumar" runat="server" CssClass="AlertRedBold" ErrorMessage="Numarul carnetului de munca nu poate sa contina caractere invalide: <>()';&quot;\ "
													ControlToValidate="txtCMNumar" ValidationExpression="^[^>|(|)|<|'|&quot;|;|\\]*$"><</asp:regularexpressionvalidator></TD>
										</TR>
										<tr>
											<td class="GreenSeparator" colSpan="2"><IMG height="1" src="../images/1x1.gif"></td>
										</tr>
										<TR>
											<TD class="NormalGreenBold">Emitent:</TD>
											<TD><asp:textbox id="txtCMEmitent" runat="server" CssClass="NormalEditBoxuri" MaxLength="50" Width="100px"></asp:textbox><asp:regularexpressionvalidator id="regularEmitent" runat="server" CssClass="AlertRedBold" ErrorMessage="Emitentul carnetului de munca nu poate sa contina caractere invalide: <>()';&quot;\ "
													ControlToValidate="txtCMEmitent" ValidationExpression="^[^>|(|)|<|'|&quot;|;|\\]*$"><</asp:regularexpressionvalidator></TD>
										</TR>
										<tr>
											<td class="GreenSeparator" colSpan="2"><IMG height="1" src="../images/1x1.gif"></td>
										</tr>
										<TR>
											<TD class="NormalGreenBold">Data emiterii:</TD>
											<TD><asp:textbox id="txtCMDataEmiterii" style="TEXT-ALIGN: center; CURSOR: hand" onclick="ShowCalendar(this,'')"
													runat="server" CssClass="NormalEditBoxuri" Width="100px" ReadOnly="True"></asp:textbox></TD>
										</TR>
										<tr>
											<td class="GreenSeparator" colSpan="2"><IMG height="1" src="../images/1x1.gif"></td>
										</tr>
										<TR>
											<TD class="NormalGreenBold">Nr. Inreg. ITM:</TD>
											<TD><asp:textbox id="txtCMNrInregITM" runat="server" CssClass="NormalEditBoxuri" MaxLength="25" Width="100px"></asp:textbox><asp:regularexpressionvalidator id="regularNrInreg" runat="server" CssClass="AlertRedBold" ErrorMessage="Nr de inregistrare pentru carnetul de munca nu poate sa contina caractere invalide: <>()';&quot;\ "
													ControlToValidate="txtCMNrInregITM" ValidationExpression="^[^>|(|)|<|'|&quot;|;|\\]*$"><</asp:regularexpressionvalidator></TD>
										</TR>
										<TR>
											<TD class="HeaderGreenBold" colSpan="2">Date despre pensionare:</TD>
										</TR>
										<TR>
											<TD class="NormalGreenBold">Pensionat:</TD>
											<td><asp:checkbox id="pensionatCheck" runat="server"></asp:checkbox></td>
										</TR>
										<TR>
											<TD class="HeaderGreenBold" colSpan="2">Venituri Brute pe ultimele sase luni, 
												anterioare datei angajarii:</TD>
										</TR>
										<tr>
											<td class="NormalGreenBold">Primul loc de munca</td>
											<td class="NormalGreenBold"><asp:radiobutton id="radioDa" onclick="SelectLoc();" runat="server" Text="Da" Checked="True" GroupName="GrupRadio"></asp:radiobutton><asp:radiobutton id="radioNu" onclick="SelectLoc();" runat="server" Text="Nu" GroupName="GrupRadio"></asp:radiobutton></td>
										</tr>
										<tr id="sep0">
											<td class="GreenSeparator" colSpan="2"><IMG height="1" src="../images/1x1.gif"></td>
										</tr>
										<tr>
											<TD class="NormalGreenBold" id="ln1" colSpan="2">luna:&nbsp;&nbsp;<asp:label id="txtLuna1" runat="server" Width="100px"></asp:label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Venit 
												Brut&nbsp;
												<asp:textbox id="txtCAS1" runat="server" CssClass="NormalEditBoxuri" Width="90px"></asp:textbox><asp:comparevalidator id="Comparevalidator10" runat="server" CssClass="AlertRedBold" ErrorMessage="Venit brut - Introduceti o suma corecta!"
													ControlToValidate="txtCAS1" Type="Double" Operator="DataTypeCheck"><</asp:comparevalidator></TD>
										</tr>
										<tr id="sep1">
											<td class="GreenSeparator" colSpan="2"><IMG height="1" src="../images/1x1.gif"></td>
										</tr>
										<tr>
											<TD class="NormalGreenBold" id="ln2" colSpan="2">luna:&nbsp;&nbsp;<asp:label id="txtLuna2" runat="server" Width="100px"></asp:label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Venit 
												Brut&nbsp;
												<asp:textbox id="txtCAS2" runat="server" CssClass="NormalEditBoxuri" Width="90px"></asp:textbox><asp:comparevalidator id="Comparevalidator9" runat="server" CssClass="AlertRedBold" ErrorMessage="Venit brut - Introduceti o suma corecta!"
													ControlToValidate="txtCAS2" Type="Double" Operator="DataTypeCheck"><</asp:comparevalidator></TD>
										</tr>
										<tr id="sep2">
											<td class="GreenSeparator" colSpan="2"><IMG height="1" src="../images/1x1.gif"></td>
										</tr>
										<tr>
											<TD class="NormalGreenBold" id="ln3" colSpan="2">luna:&nbsp;&nbsp;<asp:label id="txtLuna3" runat="server" Width="100px"></asp:label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Venit 
												Brut&nbsp;
												<asp:textbox id="txtCAS3" runat="server" CssClass="NormalEditBoxuri" Width="90px"></asp:textbox><asp:comparevalidator id="Comparevalidator8" runat="server" CssClass="AlertRedBold" ErrorMessage="Venit brut - Introduceti o suma corecta!"
													ControlToValidate="txtCAS3" Type="Double" Operator="DataTypeCheck"><</asp:comparevalidator></TD>
										</tr>
										<tr id="sep3">
											<td class="GreenSeparator" colSpan="2"><IMG height="1" src="../images/1x1.gif"></td>
										</tr>
										<tr>
											<TD class="NormalGreenBold" id="ln4" colSpan="2">luna:&nbsp;&nbsp;<asp:label id="txtLuna4" runat="server" Width="100px"></asp:label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Venit 
												Brut&nbsp;
												<asp:textbox id="txtCAS4" runat="server" CssClass="NormalEditBoxuri" Width="90px"></asp:textbox><asp:comparevalidator id="Comparevalidator7" runat="server" CssClass="AlertRedBold" ErrorMessage="Venit brut - Introduceti o suma corecta!"
													ControlToValidate="txtCAS4" Type="Double" Operator="DataTypeCheck"><</asp:comparevalidator></TD>
										</tr>
										<tr id="sep4">
											<td class="GreenSeparator" colSpan="2"><IMG height="1" src="../images/1x1.gif"></td>
										</tr>
										<tr>
											<TD class="NormalGreenBold" id="ln5" colSpan="2">luna:&nbsp;&nbsp;<asp:label id="txtLuna5" runat="server" Width="100px"></asp:label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Venit 
												Brut&nbsp;
												<asp:textbox id="txtCAS5" runat="server" CssClass="NormalEditBoxuri" Width="90px"></asp:textbox><asp:comparevalidator id="Comparevalidator6" runat="server" CssClass="AlertRedBold" ErrorMessage="Venit brut - Introduceti o suma corecta!"
													ControlToValidate="txtCAS5" Type="Double" Operator="DataTypeCheck"><</asp:comparevalidator></TD>
										</tr>
										<tr id="sep5">
											<td class="GreenSeparator" colSpan="2"><IMG height="1" src="../images/1x1.gif"></td>
										</tr>
										<tr>
											<TD class="NormalGreenBold" id="ln6" colSpan="2">luna:&nbsp;&nbsp;<asp:label id="txtLuna6" runat="server" Width="100px"></asp:label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Venit 
												Brut&nbsp;
												<asp:textbox id="txtCAS6" runat="server" CssClass="NormalEditBoxuri" Width="90px"></asp:textbox><asp:comparevalidator id="Comparevalidator4" runat="server" CssClass="AlertRedBold" ErrorMessage="Venit brut - Introduceti o suma corecta!"
													ControlToValidate="txtCAS6" Type="Double" Operator="DataTypeCheck"><</asp:comparevalidator></TD>
										</tr>
										<tr id="sep6">
											<td class="GreenSeparator" colSpan="2"><IMG height="1" src="../images/1x1.gif"></td>
										</tr>
										<tr id="hiddenLine">
											<td><asp:dropdownlist id="dropDataCAS" runat="server"></asp:dropdownlist><asp:dropdownlist id="dropLunileId" runat="server"></asp:dropdownlist><asp:dropdownlist id="dropLunileAnului" runat="server"></asp:dropdownlist></td>
										</tr>
									</TABLE>
								</td>
								<!--   ALTE DATE	 -->
								<td class="tabBackground" id="tableEditAlteDate" colSpan="2">
									<TABLE cellSpacing="1" cellPadding="0" width="100%" border="0">
										<TBODY>
											<tr>
												<td class="HeaderGreenBold" align="center" colSpan="2">Drepturi si obligatii ale 
													partilor privind sanatatea si securiatea in munca</td>
											</tr>
											<TR>
												<TD class="NormalGreenBold">Echipament individual de protectie:</TD>
												<TD>
													<TABLE id="tblEchIndProtectie" cellSpacing="0" cellPadding="0" width="100%" border="0">
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
												<TD class="GreenSeparator" colSpan="2"><IMG height="1" src="images/1x1.gif"></TD>
											</TR>
											<TR>
												<TD class="NormalGreenBold">Echipament individual de lucru:</TD>
												<TD>
													<TABLE id="tblEchIndLucru" cellSpacing="0" cellPadding="0" width="100%" border="0">
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
												<td class="GreenSeparator" colSpan="2"><IMG height="1" src="images/1x1.gif"></td>
											</tr>
											<TR>
												<TD class="NormalGreenBold">Materiale igienico sanitare:</TD>
												<TD>
													<TABLE id="tblMatIgiSan" cellSpacing="0" cellPadding="0" width="100%" border="0">
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
												<td class="GreenSeparator" colSpan="2"><IMG height="1" src="images/1x1.gif"></td>
											</tr>
											<TR>
												<TD class="NormalGreenBold">Alimentatie de protectie:</TD>
												<TD>
													<TABLE id="tblAlimProtectie" cellSpacing="0" cellPadding="0" width="100%" border="0">
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
												<td class="GreenSeparator" colSpan="2"><IMG height="1" src="images/1x1.gif"></td>
											</tr>
											<TR>
												<TD class="NormalGreenBold">Alte drepturi si obligatii privind sanatatea si 
													securitatea in munca:</TD>
												<TD>
													<TABLE id="tblAlteDrSiObl" cellSpacing="0" cellPadding="0" width="100%" border="0">
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
							</tr>
							<tr>
								<td align="right" colSpan="2">
									<table cellSpacing="0" cellPadding="0" width="100%" border="0">
										<tr>
											<td class="CommentRedBold">* - Campuri obligatorii</td>
											<td align="right"><input class="ButtonStyle" id="btnPrev" onmouseover="MouseOverButton(this)" style="DISPLAY: none"
													onclick="NextTab('back')" onmouseout="MouseOutButton(this)" type="button" value="  << Back  " name="btnPrev">&nbsp;
												<input class="ButtonStyle" id="btnNext" onmouseover="MouseOverButton(this)" onclick="NextTab('next')"
													onmouseout="MouseOutButton(this)" type="button" value="  Next >>  " name="btnNext">
											</td>
										</tr>
									</table>
								</td>
							</tr>
							<tr>
								<td align="center" colSpan="2" height="50">&nbsp;
									<asp:button id="butSaveAngajat" onmouseover="MouseOverButton(this)" onmouseout="MouseOutButton(this)"
										runat="server" cssclass="ButtonStyle" Text="Salveaza date"></asp:button><asp:validationsummary id="ValidationSummary2" runat="server" ShowMessageBox="True" ShowSummary="False"></asp:validationsummary></td>
							</tr>
						</TABLE>
						<INPUT id="txtHiddenPunctLucru" runat="server"> <INPUT id="txtHiddenPunctLucruVechi" name="txtHiddenPunctLucruVechi" runat="server">
						<INPUT id="txtHiddenCasaDeAsigurari" name="txtHiddenCasaDeAsigurari" runat="server">
						<INPUT id="txtHiddenExistaDateCAS" style="DISPLAY: none" name="txtHiddenExistaDateCAS"
							runat="server"> <INPUT id="txtHiddenMotivDeAngajare" name="txtHiddenMotivDeAngajare" runat="server"><INPUT id="txtHiddenTipDeAngajat" name="txtHiddenTipDeAngajat" runat="server">&nbsp;</td>
				</tr>
			</TBODY>
		</table>
		<script>
		sp3FormIDfix();
		SelectLoc();


		var arForms = document.getElementsByTagName("Form");
			formObj = arForms[0];
		
		eval(ctrlID+"_tab1.click()");
		var nrCrt = 0;
		LoadPerioadeExistente();
		</script>
	</body>
</HTML>
