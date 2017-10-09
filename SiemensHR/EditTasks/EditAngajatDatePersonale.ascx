<%@ Control Language="c#" AutoEventWireup="false" Codebehind="EditAngajatDatePersonale.ascx.cs" Inherits="SiemensHR.EditAngajatDatePersonale" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>HR Toolkit</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="StyleHR.css" type="text/css" rel="stylesheet">
        <script language="javascript" src="../js/jsCode.js"></script>
	</HEAD>
	<body>
		<script>
	var arTabs = new Array('tableDatePersonale', 'tableDomiciliu', 'tableBuletinPasaport' );
	var formObj;
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
	
	
	
//pt legatura dintre judete si tari	
function lstDTaraChanged( dTara)
{
	document.getElementById( DTaraHiddenClient ).value = dTara.value;
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
			h = Calculate_y_coordinate( 300);
			w = Calculate_x_coordinate( 600);
			oNewWindow = window.open("Administrare/AdminFunctiiAddAngajat.aspx",null,"height=300,width=600, top=" + h + ",left=" + w + " ,status=yes,toolbar=no,menubar=no,location=no,scrollbars=yes");
			oNewWindow.focus();
			break;
		default:
			break;
	}
}	

//Sterge toate intrarile din combo-ul cu titluri
function DeleteTitluCombo()
{
	var titluriCombo = document.getElementById( ctrlID + '_lstTitlu' ); 
	while( titluriCombo.length > 0 )
	{
		titluriCombo.remove( titluriCombo.selectedIndex );
	}
}

//Adauga o intrare la la combo-ul cu titluri
function FillTitluCombo( titluText, titluValoare)
{
	var titluriCombo = document.getElementById( ctrlID + '_lstTitlu' );
	var o = new Option();
	o.text = titluText;
	o.value = titluValoare;
	titluriCombo.add( o, 0 ); 
}

//Sterge toate intrarile din combo-ul cu studii
function DeleteStudiiCombo()
{
	var studiiCombo = document.getElementById( ctrlID + '_lstStudiu' ); 
	while( studiiCombo.length > 0 )
	{
		studiiCombo.remove( studiiCombo.selectedIndex );
	}
}

//Adauga o intrare la combo-ul cu studii
function FillStudiuCombo( studiuText, studiuValoare)
{
	var studiiCombo = document.getElementById( ctrlID + '_lstStudiu' );
	var o = new Option();
	o.text = studiuText;
	o.value = studiuValoare;
	studiiCombo.add( o, 0 ); 
}

//Sterge toate intrarile din combo-ul cu invaliditati
function DeleteInvaliditatiCombo()
{
	var invaliditatiCombo = document.getElementById( ctrlID + '_chkLstInvalid' ); 
	while( invaliditatiCombo.length > 0 )
	{
		invaliditatiCombo.remove( invaliditatiCombo.selectedIndex );
	}
}

//Adauga o intrare la combo-ul cu invaliditati
function FillInvaliditateCombo( invaliditateText, invaliditateValoare)
{
	var invaliditatiCombo = document.getElementById( ctrlID + '_chkLstInvalid' );
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
	var tariCombo = document.getElementById( ctrlID + '_lstDTara' ); 
	while( tariCombo.length > 0 )
	{
		tariCombo.remove( tariCombo.selectedIndex );
	}
	
	//stergem continutul combo-ului cu tari din sectiunea ... Date resedinta
	var tariCombo = document.getElementById( ctrlID + '_lstRTara' ); 
	while( tariCombo.length > 0 )
	{
		tariCombo.remove( tariCombo.selectedIndex );
	}
	
	//stergem continutul combo-ului cu tari din sectiunea ... Buletin\Pasaport
	var tariCombo = document.getElementById( ctrlID + '_lstTaraNastere' ); 
	while( tariCombo.length > 0 )
	{
		tariCombo.remove( tariCombo.selectedIndex );
	}
}

//Adauga o intrare la combo-ul cu tari
function FillTaraCombo( taraText, taraValoare)
{
	//adaugam o optiune in combo-ul cu tari din sectiunea ... Date domiciliu
	var tariCombo = document.getElementById( ctrlID + '_lstDTara' );
	var o = new Option();
	o.text = taraText;
	o.value = taraValoare;
	tariCombo.add( o, 0 );
	
	//adaugam o optiune in combo-ul cu tari din sectiunea ... Date domiciliu
	var tariCombo = document.getElementById( ctrlID + '_lstRTara' );
	var o = new Option();
	o.text = taraText;
	o.value = taraValoare;
	tariCombo.add( o, 0 );
	
	//adaugam o optiune in combo-ul cu tari din sectiunea ... Buletin\Pasaport
	var tariCombo = document.getElementById( ctrlID + '_lstTaraNastere' );
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
	var tariDCombo = document.getElementById( ctrlID + '_lstDTara' );
	UmpleLstDJudetEx( tariDCombo.value);
	var tariRCombo = document.getElementById( ctrlID + '_lstRTara' );
	UmpleLstRJudetEx( tariRCombo.value);
	var taraNastereCombo = document.getElementById( ctrlID + '_lstTaraNastere' );
	UmpleLstJudetNastereEx( taraNastereCombo.value);
}

//Sterge toate intrarile din combo-ul cu judete
function DeleteJudeteCombo()
{
	//stergem continutul comboul-ui cu judete din sectiunea ... Date domiciliu
	var judeteCombo = document.getElementById( ctrlID + '_lstDJudetSector' ); 
	while( judeteCombo.length > 0 )
	{
		judeteCombo.remove( judeteCombo.selectedIndex );
	}
	
	//stergem continutul comboul-ui cu judete din sectiunea ... Date resedinta
	var judeteCombo = document.getElementById( ctrlID + '_lstRJudetSector' ); 
	while( judeteCombo.length > 0 )
	{
		judeteCombo.remove( judeteCombo.selectedIndex );
	}
	
	//stergem continutul comboul-ui cu judete din sectiunea ... Buletin - Pasaport
	var judeteCombo = document.getElementById( ctrlID + '_lstJudetNastere' ); 
	while( judeteCombo.length > 0 )
	{
		judeteCombo.remove( judeteCombo.selectedIndex );
	}
}

//Adauga o intrare la combo-ul cu judete
function FillJudetCombo( judetText, judetValoare)
{
	//adaugam o optiune in combo-ul cu judete din sectiunea ... Date domiciliu
	var judeteCombo = document.getElementById( ctrlID + '_lstDJudetSector' );
	var o = new Option();
	o.text = judetText;
	o.value = judetValoare;
	judeteCombo.add( o, 0 );
	
	//adaugam o optiune in combo-ul cu judete din sectiunea ... Date domiciliu
	var judeteCombo = document.getElementById( ctrlID + '_lstRJudetSector' );
	var o = new Option();
	o.text = judetText;
	o.value = judetValoare;
	judeteCombo.add( o, 0 );
	
	//adaugam o optiune in combo-ul cu judete din sectiunea ... Buletin - Pasaport
	var judeteCombo = document.getElementById( ctrlID + '_lstJudetNastere' );
	var o = new Option();
	o.text = judetText;
	o.value = judetValoare;
	judeteCombo.add( o, 0 );
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
								<td colSpan="4"><IMG height="10" src="../images/1x1.gif"></td>
							</tr>
							<tr>
								<td colspan="4">
									<asp:Table id="tableTabs" runat="server"></asp:Table></td>
							</tr>
							<tr>
								<!--   DATE PERSONALE -->
								<td class="tabBackground" id="tableDatePersonale" colSpan="4">
									<TABLE cellSpacing="1" cellPadding="0" width="100%" border="0">
										<tr>
											<td class="HeaderGreenBold" align="center" colSpan="2">Date identificare persoana:</td>
										</tr>
										<TR>
											<TD class="NormalGreenBold">Nume:</TD>
											<TD><asp:textbox id="txtNume" runat="server" Width="150px" MaxLength="50" CssClass="NormalEditBoxuri"></asp:textbox><span class="CommentRedBold">*</span><asp:requiredfieldvalidator id="RequiredField_nume" runat="server" ErrorMessage="Completati numele angajatului!"
													ControlToValidate="txtNume" CssClass="AlertRedBold"><</asp:requiredfieldvalidator>
												<asp:regularexpressionvalidator id="regularNume" runat="server" CssClass="AlertRedBold" ControlToValidate="txtNume"
													ErrorMessage="Numele nu poate sa contina caractere invalide: <>()';&quot;\" ValidationExpression="^[^>|(|)|<|'|&quot;|;|\\]*$"><</asp:regularexpressionvalidator></TD>
										</TR>
										<tr>
											<td class="GreenSeparator" colSpan="2"><IMG height="1" src="../images/1x1.gif"></td>
										</tr>
										<TR>
											<TD class="NormalGreenBold">Prenume:</TD>
											<TD><asp:textbox id="txtPrenume" runat="server" Width="150px" MaxLength="50" CssClass="NormalEditBoxuri"></asp:textbox><span class="CommentRedBold">*</span><asp:requiredfieldvalidator id="RequiredField_prenume" runat="server" ErrorMessage="Completati prenumele angajatului!"
													ControlToValidate="txtPrenume" CssClass="AlertRedBold"><</asp:requiredfieldvalidator>
												<asp:regularexpressionvalidator id="regularPrenume" runat="server" CssClass="AlertRedBold" ControlToValidate="txtPrenume"
													ErrorMessage="Prenumele nu poate sa contina caractere invalide: <>()';&quot;\" ValidationExpression="^[^>|(|)|<|'|&quot;|;|\\]*$"><</asp:regularexpressionvalidator></TD>
										</TR>
										<tr>
											<td class="GreenSeparator" colSpan="2"><IMG height="1" src="images/1x1.gif"></td>
										</tr>
										<TR>
											<TD class="NormalGreenBold">Nume anterior:</TD>
											<TD class="NormalGreenBold"><asp:textbox id="txtNumeAnterior" runat="server" Width="150px" MaxLength="50" CssClass="NormalEditBoxuri"></asp:textbox>
												<asp:regularexpressionvalidator id="regularNumeAnterior" runat="server" CssClass="AlertRedBold" ControlToValidate="txtNumeAnterior"
													ErrorMessage="Numele anterior nu poate sa contina caractere invalide: <>()';&quot;\" ValidationExpression="^[^>|(|)|<|'|&quot;|;|\\]*$"><</asp:regularexpressionvalidator>&nbsp;&nbsp;&nbsp;&nbsp;Data 
												schimbarii numelui: &nbsp;
												<asp:textbox style="Z-INDEX: 0; CURSOR: hand" id="txtDataSchimbariiNumelui" onclick="ShowCalendar(this,'')"
													runat="server" CssClass="NormalEditBoxuri" Width="70px" ReadOnly="True"></asp:textbox></TD>
										</TR>
										<tr>
											<td class="GreenSeparator" colSpan="2"><IMG height="1" src="../images/1x1.gif"></td>
										</tr>
										<TR>
											<TD class="NormalGreenBold">Stare civila:</TD>
											<TD><asp:dropdownlist id="lstStareCivila" runat="server" Width="150px" CssClass="SelectStyle">
													<asp:ListItem Value="0">Casatorit</asp:ListItem>
													<asp:ListItem Value="1">Necasatorit</asp:ListItem>
													<asp:ListItem Value="2">Divortat</asp:ListItem>
													<asp:ListItem Value="3">Vaduv</asp:ListItem>
												</asp:dropdownlist></TD>
										</TR>
										<tr>
											<td class="GreenSeparator" colSpan="2"><IMG height="1" src="../images/1x1.gif"></td>
										</tr>
										<TR>
											<TD class="NormalGreenBold">Nr. copii:</TD>
											<TD><asp:textbox id="txtNrCopii" runat="server" Width="70px" CssClass="NumericEditBoxuri">0</asp:textbox>
												<asp:RequiredFieldValidator id="reqVldNrCopii" runat="server" ControlToValidate="txtNrCopii" ErrorMessage="Trebuie sa completati corect numarul de copii!"
													CssClass="AlertRedBold"><</asp:RequiredFieldValidator>
												<asp:RangeValidator id="vldNrCopii" runat="server" ControlToValidate="txtNrCopii" ErrorMessage="Trebuie sa completati corect numarul de copii!"
													Type="Integer" MaximumValue="20" MinimumValue="0" CssClass="AlertRedBold"><  </asp:RangeValidator></TD>
										</TR>
										<tr>
											<td class="GreenSeparator" colSpan="2"><IMG height="1" src="../images/1x1.gif"></td>
										</tr>
										<TR>
											<TD class="NormalGreenBold">Sex:</TD>
											<TD><asp:dropdownlist id="lstSex" runat="server" Width="150px" CssClass="SelectStyle">
													<asp:ListItem Value="f">Feminin</asp:ListItem>
													<asp:ListItem Value="m">Masculin</asp:ListItem>
												</asp:dropdownlist></TD>
										</TR>
										<tr>
											<td class="GreenSeparator" colSpan="2"><IMG height="1" src="../images/1x1.gif"></td>
										</tr>
										<tr>
											<TD class="NormalGreenBold">Invaliditate :</TD>
											<td>
												<asp:DropDownList runat="server" ID="chkLstInvalid" Width="150px" CssClass="SelectStyle" Enabled="False"></asp:DropDownList>
												<INPUT onclick="javascript:OpenAdminWindow('invaliditati')" type="button" value="..." style="DISPLAY: none">
											</td>
										</tr>
										<tr>
											<td class="GreenSeparator" colSpan="2"><IMG height="1" src="../images/1x1.gif"></td>
										</tr>
										<TR>
											<TD class="NormalGreenBold">Titlu:</TD>
											<TD>
												<asp:dropdownlist id="lstTitlu" runat="server" Width="350px" CssClass="SelectStyle"></asp:dropdownlist>
												<INPUT onclick="javascript:OpenAdminWindow('titluri')" type="button" value="..." id="Button1"
													name="Button1" runat="server">
											</TD>
										</TR>
										<tr>
											<td class="GreenSeparator" colSpan="2"><IMG height="1" src="../images/1x1.gif"></td>
										</tr>
										<TR>
											<TD class="NormalGreenBold">Studii:</TD>
											<TD>
												<asp:dropdownlist id="lstStudiu" runat="server" Width="350px" CssClass="SelectStyle"></asp:dropdownlist>
												<INPUT onclick="javascript:OpenAdminWindow('studii')" type="button" value="..." id="Button2"
													name="Button2" runat="server">
											</TD>
										</TR>
										<tr>
											<td class="GreenSeparator" colSpan="2"><IMG height="1" src="../images/1x1.gif"></td>
										</tr>
										<TR>
											<TD class="NormalGreenBold">An Absolvire:</TD>
											<TD><asp:textbox id="txtAnAbsolvire" runat="server" Width="75px" MaxLength="4" CssClass="NumericEditBoxuri"></asp:textbox><SPAN class="CommentRedBold">*</SPAN>
												<asp:RangeValidator id="vldAnAbsolvire" runat="server" ControlToValidate="txtAnAbsolvire" ErrorMessage="Trebuie sa completati corect anul absolvirii!"
													Type="Integer" MaximumValue="2500" MinimumValue="1900" CssClass="AlertRedBold"><  </asp:RangeValidator>
												<asp:RequiredFieldValidator id="requiredFieldValAnAbsolvire" runat="server" CssClass="AlertRedBold" ControlToValidate="txtAnAbsolvire"
													ErrorMessage="Introduceti anul absolvirii!"><</asp:RequiredFieldValidator><span class="CommentRedBold"></span></TD>
										</TR>
										<tr>
											<td class="GreenSeparator" colSpan="2"><IMG height="1" src="../images/1x1.gif"></td>
										</tr>
										<TR>
											<TD class="NormalGreenBold">Nr Diploma:</TD>
											<TD><asp:textbox id="txtNrDiploma" runat="server" Width="75px" MaxLength="50" CssClass="NumericEditBoxuri"></asp:textbox>
												<asp:regularexpressionvalidator id="regularNrDiploma" runat="server" CssClass="AlertRedBold" ControlToValidate="txtNrDiploma"
													ErrorMessage="Numarul diplomei nu poate sa contina caractere invalide: <>()';&quot;\" ValidationExpression="^[^>|(|)|<|'|&quot;|;|\\]*$"><</asp:regularexpressionvalidator><span class="CommentRedBold"></span></TD>
										</TR>
										<tr>
											<td class="GreenSeparator" colSpan="2"><IMG height="1" src="../images/1x1.gif"></td>
										</tr>
										<TR>
											<TD class="NormalGreenBold">Telefon:</TD>
											<td><asp:textbox id="txtTelefon" runat="server" Width="75px" MaxLength="25" CssClass="NormalEditBoxuri"></asp:textbox>
												<asp:regularexpressionvalidator id="regularProgramLucru" runat="server" CssClass="AlertRedBold" ControlToValidate="txtTelefon"
													ErrorMessage="Pentru telefon trebuie introduse numai cifre!" ValidationExpression="\d*"><  </asp:regularexpressionvalidator></td>
										</TR>
										<tr>
											<td class="GreenSeparator" colSpan="2"><IMG height="1" src="../images/1x1.gif"></td>
										</tr>
										<TR>
											<TD class="NormalGreenBold">Descriere:</TD>
											<TD><asp:textbox id="txtDescriere" runat="server" Width="350px" CssClass="AreaStyle" Columns="50"
													Rows="4" Height="60px" TextMode="MultiLine"></asp:textbox></TD>
										</TR>
										<tr>
											<td class="GreenSeparator" colSpan="2"><IMG height="1" src="../images/1x1.gif"></td>
										</tr>
										<TR>
											<TD class="NormalGreenBold">Poza:</TD>
											<TD><INPUT class="NormalEditBoxuri" id="filePozaAngajat" type="file" name="File1" runat="server"
													style="WIDTH: 350px; HEIGHT: 22px" size="31">
												<asp:regularexpressionvalidator id="regularPoza" runat="server" CssClass="AlertRedBold" ControlToValidate="filePozaAngajat"
													ErrorMessage="Specificati corect denumirea pozei!" ValidationExpression="^[^>|(|)|<|'|&quot;|;]*$"><</asp:regularexpressionvalidator></TD>
										</TR>
									</TABLE>
								</td>
								<!--   DOMICILIU - RESEDINTA -->
								<td class="tabBackground" id="tableDomiciliu" colSpan="4">
									<TABLE cellSpacing="1" cellPadding="0" width="100%" border="0">
										<tr>
											<td class="HeaderGreenBold" align="center" colSpan="2">Date domiciliu:</td>
											<td class="HeaderGreenBold" align="center" colSpan="2">Date resedinta:</td>
										</tr>
										<TR>
											<TD class="NormalGreenBold">Tara:</TD>
											<TD>
												<asp:dropdownlist id="lstDTara" runat="server" Width="150px" CssClass="SelectStyle" onChange="lstDTaraChanged(this);"></asp:dropdownlist>
												<INPUT onclick="javascript:OpenAdminWindow('tari')" type="button" value="..." id="btnTara"
													runat="server">
											</TD>
											<TD class="NormalGreenBold">Tara:</TD>
											<td>
												<asp:dropdownlist id="lstRTara" runat="server" Width="150px" CssClass="SelectStyle" onChange="lstRTaraChanged(this);"></asp:dropdownlist>
												<INPUT onclick="javascript:OpenAdminWindow('tari')" type="button" value="..." id="btnTara1"
													runat="server">
											</td>
										</TR>
										<tr>
											<td class="GreenSeparator" colSpan="4"><IMG height="1" src="../images/1x1.gif"></td>
										</tr>
										<TR>
											<TD class="NormalGreenBold">Judet/Sector:</TD>
											<TD>
												<asp:dropdownlist id="lstDJudetSector" runat="server" Width="150px" CssClass="SelectStyle" onChange="lstDJudetSectorChanged(this);"></asp:dropdownlist>
												<INPUT onclick="javascript:OpenAdminWindow('judete')" type="button" value="..." id="btnJudet"
													runat="server">
											</TD>
											<TD class="NormalGreenBold">Judet/Sector:</TD>
											<TD>
												<asp:dropdownlist id="lstRJudetSector" runat="server" Width="150px" CssClass="SelectStyle" onChange="lstRJudetSectorChanged(this);"></asp:dropdownlist>
												<INPUT onclick="javascript:OpenAdminWindow('judete')" type="button" value="..." id="btnJudet1"
													runat="server">
											</TD>
										</TR>
										<tr>
											<td class="GreenSeparator" colSpan="4"><IMG height="1" src="../images/1x1.gif"></td>
										</tr>
										<tr>
										<TR>
											<TD class="NormalGreenBold">Localitate:</TD>
											<TD><asp:textbox id="txtDLocalitate" runat="server" Width="140px" MaxLength="50" CssClass="NormalEditBoxuri"
													onChange="eval(ctrlID + '_Form1.' + ctrlID + '_txtRLocalitate.value = this.value;')"></asp:textbox><span class="CommentRedBold">*
													<asp:requiredfieldvalidator id="requiredDLocalitate" runat="server" ErrorMessage="Completati localitatea - domiciliu!"
														ControlToValidate="txtDLocalitate" CssClass="AlertRedBold"><</asp:requiredfieldvalidator>
													<asp:regularexpressionvalidator id="regularLocalitate" runat="server" CssClass="AlertRedBold" ControlToValidate="txtDLocalitate"
														ErrorMessage="Localitatea nu poate sa contina caractere invalide: <>()';&quot;\ " ValidationExpression="^[^>|(|)|<|'|&quot;|;|\\]*$"><</asp:regularexpressionvalidator></span></TD>
											<TD class="NormalGreenBold">Localitate:</TD>
											<TD><asp:textbox id="txtRLocalitate" runat="server" Width="140px" MaxLength="50" CssClass="NormalEditBoxuri"></asp:textbox><span class="CommentRedBold">*
													<asp:requiredfieldvalidator id="requiredRLocalitate" runat="server" ErrorMessage="Completati localitatea - resedinta!"
														ControlToValidate="txtRLocalitate" CssClass="AlertRedBold"><</asp:requiredfieldvalidator>
													<asp:regularexpressionvalidator id="Regularexpressionvalidator4" runat="server" CssClass="AlertRedBold" ControlToValidate="txtRLocalitate"
														ErrorMessage="Localitatea nu poate sa contina caractere invalide: <>()';&quot;\ " ValidationExpression="^[^>|(|)|<|'|&quot;|;|\\]*$"><</asp:regularexpressionvalidator></span></TD>
										</TR>
										<TR>
											<td class="GreenSeparator" colSpan="4"><IMG height="1" src="../images/1x1.gif"></td>
										</TR>
										<TR>
											<TD class="NormalGreenBold">Strada:</TD>
											<TD><asp:textbox id="txtDStrada" runat="server" Width="140px" MaxLength="50" CssClass="NormalEditBoxuri"
													onChange="eval(ctrlID + '_Form1.' + ctrlID + '_txtRStrada.value = this.value');"></asp:textbox><span class="CommentRedBold">*
													<asp:requiredfieldvalidator id="requiredDStrada" runat="server" ErrorMessage="Completati strada - domiciliu!"
														ControlToValidate="txtDStrada" CssClass="AlertRedBold"><</asp:requiredfieldvalidator>
													<asp:regularexpressionvalidator id="regularStrada" runat="server" CssClass="AlertRedBold" ControlToValidate="txtDStrada"
														ErrorMessage="Strada nu poate sa contina caractere invalide: <>()';&quot;\ " ValidationExpression="^[^>|(|)|<|'|&quot;|;|\\]*$"><</asp:regularexpressionvalidator></span></TD>
											<TD class="NormalGreenBold">Strada:</TD>
											<TD><asp:textbox id="txtRStrada" runat="server" Width="140px" MaxLength="50" CssClass="NormalEditBoxuri"></asp:textbox><span class="CommentRedBold">*
													<asp:requiredfieldvalidator id="requiredRStrada" runat="server" ErrorMessage="Completati strada - resedinta!"
														ControlToValidate="txtRStrada" CssClass="AlertRedBold"><</asp:requiredfieldvalidator>
													<asp:regularexpressionvalidator id="Regularexpressionvalidator5" runat="server" CssClass="AlertRedBold" ControlToValidate="txtRStrada"
														ErrorMessage="Strada nu poate sa contina caractere invalide: <>()';&quot;\ " ValidationExpression="^[^>|(|)|<|'|&quot;|;|\\]*$"><</asp:regularexpressionvalidator></span></TD>
										</TR>
										<tr>
											<td class="GreenSeparator" colSpan="4"><IMG height="1" src="../images/1x1.gif"></td>
										</tr>
										<TR>
											<TD class="NormalGreenBold">Numar:</TD>
											<TD><asp:textbox id="txtDNumar" runat="server" Width="140px" MaxLength="10" CssClass="NormalEditBoxuri"
													onChange="eval(ctrlID + '_Form1.' + ctrlID + '_txtRNumar.value = this.value')"></asp:textbox>
												<asp:requiredfieldvalidator id="requiredDNumar" runat="server" CssClass="AlertRedBold" ControlToValidate="txtDNumar"
													ErrorMessage="Completati numar!"><</asp:requiredfieldvalidator>
												<asp:regularexpressionvalidator id="regularNumar" runat="server" CssClass="AlertRedBold" ControlToValidate="txtDNumar"
													ErrorMessage="Numarul nu poate sa contina caractere invalide: <>()';&quot;\ " ValidationExpression="^[^>|(|)|<|'|&quot;|;|\\]*$"><</asp:regularexpressionvalidator><span class="CommentRedBold"></span></TD>
											<TD class="NormalGreenBold">Numar:</TD>
											<TD><asp:textbox id="txtRNumar" runat="server" Width="140px" MaxLength="10" CssClass="NormalEditBoxuri"></asp:textbox>
												<asp:requiredfieldvalidator id="Requiredfieldvalidator1" runat="server" CssClass="AlertRedBold" ControlToValidate="txtRNumar"
													ErrorMessage="Completati numar!"><</asp:requiredfieldvalidator>
												<asp:regularexpressionvalidator id="Regularexpressionvalidator6" runat="server" CssClass="AlertRedBold" ControlToValidate="txtRNumar"
													ErrorMessage="Numarul nu poate sa contina caractere invalide: <>()';&quot;\ " ValidationExpression="^[^>|(|)|<|'|&quot;|;|\\]*$"><</asp:regularexpressionvalidator><span class="CommentRedBold"></span></TD>
										</TR>
										<tr>
											<td class="GreenSeparator" colSpan="4"><IMG height="1" src="../images/1x1.gif"></td>
										</tr>
										<TR>
											<TD class="NormalGreenBold">Cod postal:</TD>
											<TD><asp:textbox id="txtDCodPostal" runat="server" Width="140px" MaxLength="20" CssClass="NormalEditBoxuri"
													onChange="eval(ctrlID + '_Form1.' + ctrlID + '_txtRCodPostal.value = this.value')"></asp:textbox>
												<asp:requiredfieldvalidator id="requiredDCodPostal" runat="server" CssClass="AlertRedBold" ControlToValidate="txtDCodPostal"
													ErrorMessage="Completati cod postal!"><</asp:requiredfieldvalidator>
												<asp:regularexpressionvalidator id="regularDCodPostal" runat="server" CssClass="AlertRedBold" ControlToValidate="txtDCodPostal"
													ErrorMessage="Introduceti numai cifre pentru codul postal!" ValidationExpression="[0-9]*"><</asp:regularexpressionvalidator><span class="CommentRedBold"></span></TD>
											<TD class="NormalGreenBold">CodPostal:</TD>
											<TD><asp:textbox id="txtRCodPostal" runat="server" Width="140px" MaxLength="20" CssClass="NormalEditBoxuri"></asp:textbox>
												<asp:requiredfieldvalidator id="Requiredfieldvalidator3" runat="server" CssClass="AlertRedBold" ControlToValidate="txtRCodPostal"
													ErrorMessage="Completati cod postal!"><</asp:requiredfieldvalidator>
												<asp:regularexpressionvalidator id="Regularexpressionvalidator7" runat="server" CssClass="AlertRedBold" ControlToValidate="txtRCodPostal"
													ErrorMessage="Introduceti numai cifre pentru codul postal!" ValidationExpression="[0-9]*"><</asp:regularexpressionvalidator><span class="CommentRedBold"></span></TD>
										</TR>
										<tr>
											<td class="GreenSeparator" colSpan="4"><IMG height="1" src="../images/1x1.gif"></td>
										</tr>
										<TR>
											<TD class="NormalGreenBold">Bloc:</TD>
											<TD><asp:textbox id="txtDBloc" runat="server" Width="50px" MaxLength="5" CssClass="NormalEditBoxuri"
													onChange="eval(ctrlID + '_Form1.' + ctrlID + '_txtRBloc.value = this.value')"></asp:textbox>
												<asp:regularexpressionvalidator id="regularDBloc" runat="server" CssClass="AlertRedBold" ControlToValidate="txtDBloc"
													ErrorMessage="Introduceti numai litere si cifre pentru bloc!" ValidationExpression="[a-zA-Z0-9]*"><</asp:regularexpressionvalidator></TD>
											<TD class="NormalGreenBold">Bloc:</TD>
											<TD><asp:textbox id="txtRBloc" runat="server" Width="50px" MaxLength="5" CssClass="NormalEditBoxuri"></asp:textbox>
												<asp:regularexpressionvalidator id="Regularexpressionvalidator8" runat="server" CssClass="AlertRedBold" ControlToValidate="txtRBloc"
													ErrorMessage="Introduceti numai litere si cifre pentru bloc!" ValidationExpression="[a-zA-Z0-9]*"><</asp:regularexpressionvalidator></TD>
										</TR>
										<tr>
											<td class="GreenSeparator" colSpan="4"><IMG height="1" src="../images/1x1.gif"></td>
										</tr>
										<TR>
											<TD class="NormalGreenBold">Scara:</TD>
											<TD><asp:textbox id="txtDScara" runat="server" Width="50px" MaxLength="5" CssClass="NormalEditBoxuri"
													onChange="eval(ctrlID + '_Form1.' + ctrlID + '_txtRScara.value = this.value')"></asp:textbox>
												<asp:regularexpressionvalidator id="regularDScara" runat="server" CssClass="AlertRedBold" ControlToValidate="txtDScara"
													ErrorMessage="Introduceti numai litere si cifre pentru scara!" ValidationExpression="[a-zA-Z0-9]*"><</asp:regularexpressionvalidator></TD>
											<TD class="NormalGreenBold">Scara:</TD>
											<TD><asp:textbox id="txtRScara" runat="server" Width="50px" MaxLength="5" CssClass="NormalEditBoxuri"></asp:textbox>
												<asp:regularexpressionvalidator id="Regularexpressionvalidator9" runat="server" CssClass="AlertRedBold" ControlToValidate="txtRScara"
													ErrorMessage="Introduceti numai litere si cifre pentru scara!" ValidationExpression="[a-zA-Z0-9]*"><</asp:regularexpressionvalidator></TD>
										</TR>
										<tr>
											<td class="GreenSeparator" colSpan="4"><IMG height="1" src="../images/1x1.gif"></td>
										</tr>
										<TR>
											<TD class="NormalGreenBold">Etaj:</TD>
											<TD><asp:textbox id="txtDEtaj" runat="server" Width="50px" MaxLength="5" CssClass="NormalEditBoxuri"
													onChange="eval(ctrlID + '_Form1.' + ctrlID + '_txtREtaj.value = this.value')"></asp:textbox>
												<asp:regularexpressionvalidator id="regularDEtaj" runat="server" CssClass="AlertRedBold" ControlToValidate="txtDEtaj"
													ErrorMessage="Introduceti numai litere si cifre pentru etaj!" ValidationExpression="[a-zA-Z0-9]*">< </asp:regularexpressionvalidator></TD>
											<TD class="NormalGreenBold">Etaj:</TD>
											<TD><asp:textbox id="txtREtaj" runat="server" Width="50px" MaxLength="5" CssClass="NormalEditBoxuri"></asp:textbox>
												<asp:regularexpressionvalidator id="Regularexpressionvalidator10" runat="server" CssClass="AlertRedBold" ControlToValidate="txtREtaj"
													ErrorMessage="Introduceti numai litere si cifre pentru etaj!" ValidationExpression="[a-zA-Z0-9]*">< </asp:regularexpressionvalidator></TD>
										</TR>
										<tr>
											<td class="GreenSeparator" colSpan="4"><IMG height="1" src="../images/1x1.gif"></td>
										</tr>
										<TR>
											<td class="NormalGreenBold">Apartament:</td>
											<TD><asp:textbox id="txtDApartament" runat="server" Width="50px" MaxLength="5" CssClass="NormalEditBoxuri"
													onChange="eval(ctrlID + '_Form1.' + ctrlID + '_txtRApartament.value = this.value')"></asp:textbox>
												<asp:regularexpressionvalidator id="regularDApartament" runat="server" CssClass="AlertRedBold" ControlToValidate="txtDApartament"
													ErrorMessage="Introduceti numai litere si cifre pentru apartament!" ValidationExpression="[a-zA-Z0-9]*">< </asp:regularexpressionvalidator></TD>
											<TD class="NormalGreenBold">Apartament:</TD>
											<TD><asp:textbox id="txtRApartament" runat="server" Width="50px" MaxLength="5" CssClass="NormalEditBoxuri"></asp:textbox>
												<asp:regularexpressionvalidator id="Regularexpressionvalidator11" runat="server" CssClass="AlertRedBold" ControlToValidate="txtRApartament"
													ErrorMessage="Introduceti numai litere si cifre pentru apartament!" ValidationExpression="[a-zA-Z0-9]*">< </asp:regularexpressionvalidator></TD>
										</TR>
									</TABLE>
								</td>
								<!--   BULETIN - PASAPORT	 -->
								<td class="tabBackground" id="tableBuletinPasaport" colSpan="4">
									<TABLE cellSpacing="1" cellPadding="0" width="100%" border="0">
										<!-- Date despre Nationalitate -->
										<tr>
											<td class="HeaderGreenBold" align="center" colSpan="2">Date personale:</td>
										</tr>
										<TR>
											<TD class="NormalGreenBold" width="30%">Nationalitate:</TD>
											<TD>
												<asp:dropdownlist id="lstNationalitate" runat="server" CssClass="SelectStyle" Width="150px"></asp:dropdownlist>
											</TD>
										</TR>
										<tr>
											<td class="GreenSeparator" colSpan="4"><IMG height="1" src="images/1x1.gif"></td>
										</tr>
										<TR>
											<TD class="NormalGreenBold">Data Nasterii:</TD>
											<TD><asp:textbox id="txtDataNasterii" style="CURSOR: hand" onclick="if (TipUtilizator == 'Recrutor') { ShowCalendar(this,'../'); } else { ShowCalendar(this,''); }"
													runat="server" CssClass="NormalEditBoxuri" MaxLength="10" Width="70px" Height="0px" ReadOnly="True"></asp:textbox><span class="CommentRedBold">*</span>
												<asp:requiredfieldvalidator id="requiredDataNasterii" runat="server" CssClass="AlertRedBold" ControlToValidate="txtDataNasterii"
													ErrorMessage="Completati data nasterii!"><</asp:requiredfieldvalidator></TD>
										</TR>
										<tr>
											<td class="GreenSeparator" colSpan="4"><IMG height="1" src="images/1x1.gif"></td>
										</tr>
										<TR>
											<TD class="NormalGreenBold">Tara nastere:</TD>
											<TD><asp:dropdownlist id="lstTaraNastere" runat="server" CssClass="SelectStyle" Width="150px" onChange="lstTaraNastereChanged(this);"></asp:dropdownlist><INPUT onclick="javascript:OpenAdminWindow('tari')" type="button" value="..." id="btnTara2"
													runat="server"></TD>
										</TR>
										<tr>
											<td class="GreenSeparator" colSpan="4"><IMG height="1" src="images/1x1.gif"></td>
										</tr>
										<TR>
											<TD class="NormalGreenBold">Judet nastere:</TD>
											<TD><asp:dropdownlist id="lstJudetNastere" runat="server" CssClass="SelectStyle" Width="150px" onChange="lstJudetNastereChanged(this);"></asp:dropdownlist><INPUT onclick="javascript:OpenAdminWindow('judete')" type="button" value="..." id="btnJudet2"
													runat="server"></TD>
										</TR>
										<tr>
											<td class="GreenSeparator" colSpan="4"><IMG height="1" src="images/1x1.gif"></td>
										</tr>
										<TR>
											<TD class="NormalGreenBold">Localitate nastere:</TD>
											<TD><asp:textbox id="txtLocalitateNastere" runat="server" CssClass="NormalEditBoxuri" MaxLength="50"
													Width="150px"></asp:textbox><span class="CommentRedBold">*</span>
												<asp:requiredfieldvalidator id="requiredLocalitateNastere" runat="server" CssClass="AlertRedBold" ControlToValidate="txtLocalitateNastere"
													ErrorMessage="Completati localitate nastere!"><</asp:requiredfieldvalidator>
												<asp:regularexpressionvalidator id="Regularexpressionvalidator12" runat="server" CssClass="AlertRedBold" ControlToValidate="txtLocalitateNastere"
													ErrorMessage="Localitatea de nastere nu poate sa contina caractere invalide: <>()';&quot;\ " ValidationExpression="^[^>|(|)|<|'|&quot;|;|\\]*$"><</asp:regularexpressionvalidator></TD>
										</TR>
										<tr>
											<td class="GreenSeparator" colSpan="4"><IMG height="1" src="images/1x1.gif"></td>
										</tr>
										<TR>
											<TD class="NormalGreenBold">Prenume Mama:</TD>
											<TD><asp:textbox id="txtPrenumeMama" runat="server" CssClass="NormalEditBoxuri" MaxLength="50" Width="150px"></asp:textbox><span class="CommentRedBold"></span>
												<asp:regularexpressionvalidator id="Regularexpressionvalidator13" runat="server" CssClass="AlertRedBold" ControlToValidate="txtPrenumeMama"
													ErrorMessage="Prenumele mamei nu poate sa contina caractere invalide: <>()';&quot;\ " ValidationExpression="^[^>|(|)|<|'|&quot;|;|\\]*$"><</asp:regularexpressionvalidator></TD>
										</TR>
										<tr>
											<td class="GreenSeparator" colSpan="2"><IMG height="1" src="images/1x1.gif"></td>
										</tr>
										<TR>
											<TD class="NormalGreenBold">Prenume Tata:</TD>
											<TD><asp:textbox id="txtPrenumeTata" runat="server" CssClass="NormalEditBoxuri" MaxLength="50" Width="150px"></asp:textbox><span class="CommentRedBold"></span>
												<asp:regularexpressionvalidator id="Regularexpressionvalidator14" runat="server" CssClass="AlertRedBold" ControlToValidate="txtPrenumeTata"
													ErrorMessage="Prenumele tatalui nu poate sa contina caractere invalide: <>()';&quot;\ " ValidationExpression="^[^>|(|)|<|'|&quot;|;|\\]*$"><</asp:regularexpressionvalidator></TD>
										</TR>
										<!-- Date despre Buletin -->
										<tr id="trBuletin" runat="server">
											<td colspan="2">
												<table width="100%" cellpadding="0" cellspacing="0">
													<tr>
														<td class="HeaderGreenBold" align="center" colSpan="2">Date Buletin/C.I.:</td>
													</tr>
													<TR>
														<TD class="NormalGreenBold" width="30%">CNP:</TD>
														<TD><asp:textbox id="txtCNP" runat="server" CssClass="NormalEditBoxuri" MaxLength="13" Width="140px"></asp:textbox><span class="CommentRedBold">*</span>
															<asp:requiredfieldvalidator id="requiredCNP" runat="server" ControlToValidate="txtCNP" ErrorMessage="Completati CNP!"
																CssClass="AlertRedBold"><</asp:requiredfieldvalidator><asp:customvalidator id="customCNP" runat="server" CssClass="AlertRedBold" ControlToValidate="txtCNP"
																ErrorMessage="CNP nu e valid!" ClientValidationFunction="CheckCNP"><    </asp:customvalidator></TD>
													</TR>
													<tr>
														<td class="GreenSeparator" colSpan="4"><IMG height="1" src="images/1x1.gif"></td>
													</tr>
													<tr>
														<td class="NormalGreenBold">CNP anterior:</td>
														<TD><asp:textbox id="txtCNPAnterior" runat="server" CssClass="NormalEditBoxuri" MaxLength="13" Width="140px"></asp:textbox><asp:customvalidator id="Customvalidator1" runat="server" CssClass="AlertRedBold" ControlToValidate="txtCNPAnterior"
																ErrorMessage="CNP nu e valid!" ClientValidationFunction="CheckCNP"><    </asp:customvalidator></TD>
													</tr>
													<!-- locul anterior -->
													<tr>
														<td class="GreenSeparator" colSpan="2"><IMG height="1" src="images/1x1.gif"></td>
													</tr>
													<TR>
														<TD class="NormalGreenBold">Serie:</TD>
														<td><asp:textbox id="txtCISerie" runat="server" CssClass="NormalEditBoxuri" MaxLength="2" Width="150px"></asp:textbox></td>
													</TR>
													<tr>
														<td class="GreenSeparator" colSpan="2"><IMG height="1" src="images/1x1.gif"></td>
													</tr>
													<TR>
														<TD class="NormalGreenBold" style="HEIGHT: 43px">Numar:</TD>
														<TD style="HEIGHT: 43px"><asp:textbox id="txtCINumar" runat="server" CssClass="NormalEditBoxuri" MaxLength="8" Width="150px"></asp:textbox><asp:regularexpressionvalidator id="regularCINumar" runat="server" CssClass="AlertRedBold" ControlToValidate="txtCINumar"
																ErrorMessage="Numar CI - numeric!" ValidationExpression="\d*"><  </asp:regularexpressionvalidator></TD>
													</TR>
													<tr>
														<td class="GreenSeparator" colSpan="2" style="HEIGHT: 1px"><IMG height="1" src="images/1x1.gif"></td>
													</tr>
													<TR>
														<TD class="NormalGreenBold">Eliberat de:</TD>
														<TD><asp:textbox id="txtCIEliberatDe" runat="server" CssClass="NormalEditBoxuri" MaxLength="50" Width="150px"></asp:textbox></TD>
													</TR>
													<tr>
														<td class="GreenSeparator" colSpan="2"><IMG height="1" src="images/1x1.gif"></td>
													</tr>
													<TR>
														<TD class="NormalGreenBold">Data eliberarii:</TD>
														<TD><asp:textbox id="txtCIDataEliberarii" style="CURSOR: hand" onclick="ShowCalendar(this,'')" runat="server"
																CssClass="NormalEditBoxuri" Width="70px" ReadOnly="True"></asp:textbox></TD>
													</TR>
													<tr>
														<td class="GreenSeparator" colSpan="2"><IMG height="1" src="images/1x1.gif"></td>
													</tr>
													<TR>
														<TD class="NormalGreenBold">Valabil pana la:</TD>
														<TD><asp:textbox id="txtCIValabilPanaLa" style="CURSOR: hand" onclick="ShowCalendar(this,'')" runat="server"
																CssClass="NormalEditBoxuri" Width="70px" ReadOnly="True"></asp:textbox></TD>
													</TR>
												</table>
											</td>
										</tr>
										<!-- Date despre Pasaport -->
										<tr id="trPasaport" runat="server">
											<td colspan="2">
												<table width="100%" cellpadding="0" cellspacing="0">
													<tr>
														<td class="HeaderGreenBold" align="center" colSpan="2">Date Pasaport:</td>
													</tr>
													<tr>
														<TD class="NormalGreenBold" width="30%">Serie:</TD>
														<TD><asp:textbox id="txtPASSerie" runat="server" CssClass="NormalEditBoxuri" MaxLength="10" Width="120px"></asp:textbox></TD>
													</tr>
													<tr>
														<td class="GreenSeparator" colSpan="2"><IMG height="1" src="images/1x1.gif"></td>
													</tr>
													<tr>
														<TD class="NormalGreenBold">Numar:</TD>
														<TD><asp:textbox id="txtPASNumar" runat="server" CssClass="NormalEditBoxuri" MaxLength="9" Width="120px"></asp:textbox></TD>
													</tr>
													<tr>
														<td class="GreenSeparator" colSpan="2"><IMG height="1" src="images/1x1.gif"></td>
													</tr>
													<tr>
														<TD class="NormalGreenBold">Eliberat de:</TD>
														<TD><asp:textbox id="txtPASEliberatDe" runat="server" CssClass="NormalEditBoxuri" MaxLength="50"
																Width="120px"></asp:textbox></TD>
													</tr>
													<tr>
														<td class="GreenSeparator" colSpan="2"><IMG height="1" src="images/1x1.gif"></td>
													</tr>
													<tr>
														<TD class="NormalGreenBold">Data eliberarii:</TD>
														<TD><asp:textbox id="txtPASDataEliberarii" style="CURSOR: hand" onclick="ShowCalendar(this,'')" runat="server"
																CssClass="NormalEditBoxuri" Width="70px" ReadOnly="True"></asp:textbox></TD>
													</tr>
													<tr>
														<td class="GreenSeparator" colSpan="2"><IMG height="1" src="images/1x1.gif"></td>
													</tr>
													<tr>
														<TD class="NormalGreenBold">Valabil pana la:</TD>
														<TD><asp:textbox id="txtPASValabilPanaLa" style="CURSOR: hand" onclick="ShowCalendar(this,'')" runat="server"
																CssClass="NormalEditBoxuri" Width="70px" ReadOnly="True"></asp:textbox></TD>
													</tr>
												</table>
											</td>
										</tr>
									</TABLE>
								</td>
							</tr>
							<tr>
								<td align="right" colSpan="4">
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
								<td align="center" colSpan="4" height="50">&nbsp;
									<asp:button id="butSaveAngajat" onmouseover="MouseOverButton(this)" onmouseout="MouseOutButton(this)"
										runat="server" Text="Salveaza date" cssclass="ButtonStyle"></asp:button></td>
							</tr>
							<tr>
								<td align="center" colSpan="4"><asp:validationsummary id="ValidationSummary1" runat="server" ShowSummary="False" ShowMessageBox="True"></asp:validationsummary></td>
							</tr>
						</TABLE>
						<input type="hidden" id="DTaraHidden" runat="server" name="DTaraHidden"> <input type="hidden" id="RTaraHidden" runat="server" NAME="RTaraHidden">
						<input type="hidden" id="DJudetSectorHidden" runat="server" NAME="DJudetSectorHidden">
						<input type="hidden" id="RJudetSectorHidden" runat="server" NAME="RJudetSectorHidden">
						<input type="hidden" id="TaraNastereHidden" runat="server" NAME="TaraNastere"> <input type="hidden" id="JudetNastereHidden" runat="server" NAME="JudetNastere">
						<script>
			
		
			sp3FormIDfix();
		
			var arForms = document.getElementsByTagName("Form");
			formObj = arForms[0];
		
			eval(ctrlID+"_tab1.click()");
						</script>
					</td>
				</tr>
			</TBODY>
		</table>
	</body>
</HTML>
