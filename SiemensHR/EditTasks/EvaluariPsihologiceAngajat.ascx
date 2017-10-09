<%@ Control Language="c#" AutoEventWireup="false" Codebehind="EvaluariPsihologiceAngajat.ascx.cs" Inherits="SiemensHR.EvaluariPsihologiceAngajat" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>
<script language="javascript" src="../js/jsCode.js"></script>
<script>
var arTabs = new Array('tableEvaluarePsihologica', 'tableAdaugaEvaluarePsihologica');

	function SelectTab(index)
	{
		for(i=0; i<arTabs.length; i++)
		{
			if (i==index)
			{
				eval(arTabs[i] + ".style.display=''");
				eval(ctrlID + "_tab"+ (i+1)+ ".className='tabActive'");
					
			}
			else
			{
				eval(ctrlID + "_tab"+ (i+1) + ".className='tab'");
				eval(ctrlID + "_tab"+ (i+1) + ".style.backgroundColor='#7b8fc2'");
				eval(arTabs[i] + ".style.display='none'");
			}
		}
		eval(ctrlID + "_Form1." + ctrlID + "_EvaluarePsihologicaID.value = '';");
		eval(ctrlID + "_Form1." + ctrlID + "_txtData.value = '';");
		aux="<b>Nu exista fisier atasat acestei evaluari psihologice !</b>";
		document.getElementById(ctrlID + "_EvaluarePsihologicaFile").innerHTML =aux;
		
		editButtonsLine.style.display = "none";
		addButtonsLine.style.display = "";
		tdTextLine.innerText = "Adauga evaluare psihologica";
	}
	
	function SelectEvaluarePsihologica(AngajatID,EvaluarePsihologicaID,data,tipRaportID,evaluarePsihologicaFile)
	{	
		tableEvaluarePsihologica.style.display = "none";
		editButtonsLine.style.display = "";
		addButtonsLine.style.display = "none";
		tableAdaugaEvaluarePsihologica.style.display = "";
		
		eval(ctrlID + "_Form1." + ctrlID + "_EvaluarePsihologicaID.value = EvaluarePsihologicaID;");
		eval(ctrlID + "_Form1." + ctrlID + "_txtData.value = data;");
		eval(ctrlID + "_Form1." + ctrlID + "_lstTipRaportID.value = tipRaportID;");
		
		var aux ="";
		if (evaluarePsihologicaFile.length==0 || evaluarePsihologicaFile == null) 
			aux="<b>Nu exista fisier atasat acestei evaluari psihologice !</b>"; 
		else
		{
			if (TipUtilizator == 'Recrutor')
			{
				aux = '<a target=_blank href=\"../EvaluarePsihologica/'+AngajatID+'/EvaluarePsihologica_'+EvaluarePsihologicaID+'_'+evaluarePsihologicaFile+'\">'+'<img src=\"../utils/ShowIcon.aspx?AngajatID='+AngajatID+'&EvaluarePsihologicaID='+EvaluarePsihologicaID+'&file='+evaluarePsihologicaFile+'\" border=0>&nbsp;'+evaluarePsihologicaFile+'</a>';
			}
			else
			{
				aux = '<a target=_blank href=\"EvaluarePsihologica/'+AngajatID+'/EvaluarePsihologica_'+EvaluarePsihologicaID+'_'+evaluarePsihologicaFile+'\">'+'<img src=\"utils/ShowIcon.aspx?AngajatID='+AngajatID+'&EvaluarePsihologicaID='+EvaluarePsihologicaID+'&file='+evaluarePsihologicaFile+'\" border=0>&nbsp;'+evaluarePsihologicaFile+'</a>';
			}
		}
		document.getElementById(ctrlID + "_EvaluarePsihologicaFile").innerHTML =aux;
		tdTextLine.innerText = "Editeaza evaluare psihologica";
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

//Deschide o fereastra noua in care se va incarca fereastra de admin pt tipuri rapoarte
function OpenAdminWindow( typeOfAdminPage)
{
	
	switch (typeOfAdminPage)
	{
		case "tipuri_rapoarte":
			h = Calculate_y_coordinate( 300);
			w = Calculate_x_coordinate( 600);
			oNewWindow = window.open("Administrare/AdminTipuriRapoarteEvaluariPsihologiceAngajat.aspx",null,"height=300,width=600, top=" + h + ",left=" + w + " ,status=yes,toolbar=no,menubar=no,location=no,scrollbars=yes");
			oNewWindow.focus();
			break;
		default:
			break;
	}
}

//Sterge toate intrarile din combo-ul cu tipuri rapoarte
function DeleteTipuriRapoarteCombo()
{
	var rapoarteCombo = document.getElementById( ctrlID + '_lstTipRaportID' ); 
	while( rapoarteCombo.length > 0 )
	{
		rapoarteCombo.remove( rapoarteCombo.selectedIndex );
	}
}

//Adauga o intrare la la combo-ul cu tipuri rapoarte
function FillTipRaportCombo( raportText, raportValoare)
{
	var rapoarteCombo = document.getElementById( ctrlID + '_lstTipRaportID' );
	var o = new Option();
	o.text = raportText;
	o.value = raportValoare;
	rapoarteCombo.add( o, 0 ); 
}
	
</script>
<table cellSpacing="0" cellPadding="0" width="600" align="center" border="0">
	<tr>
		<td colSpan="2"><asp:literal id="litError" runat="server"></asp:literal></td>
	</tr>
	<tr>
		<td colSpan="2"><IMG height="10" src="../images/1x1.gif"></td>
	</tr>
	<tr>
		<td colSpan="2"><asp:table id="tableTabs" runat="server"></asp:table></td>
	</tr>
	<tr>
		<td class="tabBackground" id="tableEvaluarePsihologica" vAlign="top" align="center"
			colSpan="2" height="100%"><asp:table id="listTable" runat="server"></asp:table><br>
		</td>
		<td class="tabBackground" id="tableAdaugaEvaluarePsihologica" align="center" colSpan="2">
			<TABLE cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
				<tr>
					<td>
						<TABLE height="100%" cellSpacing="1" cellPadding="0" width="100%" align="center" border="0">
							<tr>
								<td class="HeaderGreenBold" id="tdTextLine" align="center" colSpan="2">Adauga 
									evaluare psihologica:</td>
							</tr>
							<TR>
								<TD class="NormalGreenBold">Data efectuarii:</TD>
								<TD class="NormalGreenBold"><asp:textbox id="txtData" style="CURSOR: hand; TEXT-ALIGN: center" onclick="if (TipUtilizator == 'Recrutor') { ShowCalendar(this,'../'); } else { ShowCalendar(this,''); }"
										runat="server" ReadOnly="True" size="10" CssClass="NormalEditBoxuri"></asp:textbox><asp:requiredfieldvalidator id="requiredDataStart" runat="server" ControlToValidate="txtData" ErrorMessage="Completati data de efectuare a evaluarii !"
										CssClass="AlertRedBold"><</asp:requiredfieldvalidator></TD>
							</TR>
							<tr>
								<td class="GreenSeparator" colSpan="2"><IMG height="1" src="../images/1x1.gif"></td>
							</tr>
							<TR>
								<TD class="NormalGreenBold">Tip Raport:</TD>
								<TD class="NormalGreenBold"><asp:dropdownlist id="lstTipRaportID" runat="server" CssClass="SelectStyle" Width="300px"></asp:dropdownlist><INPUT onclick="javascript:OpenAdminWindow('tipuri_rapoarte')" type="button" value="..."
										id="Button1" name="Button1" runat="server">
								</TD>
							</TR>
							<tr>
								<td class="GreenSeparator" colSpan="2"><IMG height="1" src="../images/1x1.gif"></td>
							</tr>
							<TR>
								<TD class="NormalGreenBold">Fisier EvaluarePsihologica Curent :</TD>
								<TD class="NormalGreenBold" id="EvaluarePsihologicaFile" vAlign="middle" runat="server"></TD>
							</TR>
							<tr>
								<td class="GreenSeparator" colSpan="2"><IMG height="1" src="../images/1x1.gif"></td>
							</tr>
							<TR>
								<TD class="NormalGreenBold">Fisier&nbsp;evaluare psihologica :</TD>
								<TD class="NormalGreenBold"><INPUT id="fileEvaluarePsihologica" style="WIDTH: 300px; HEIGHT: 22px" type="file" size="23"
										name="File1" runat="server">
									<asp:regularexpressionvalidator id="regularCaleEval" runat="server" CssClass="AlertRedBold" ErrorMessage="Specificati corect calea fisierului!"
										ControlToValidate="fileEvaluarePsihologica" ValidationExpression="^[^>|(|)|<|'|&quot;|;]*$"><</asp:regularexpressionvalidator></TD>
							</TR>
						</TABLE>
						<INPUT id="EvaluarePsihologicaID" type="hidden" name="Hidden1" runat="server"></td>
				</tr>
				<tr id="addButtonsLine">
					<td align="center" height="100%"><asp:button id="btnAdauga" onmouseover="MouseOverButton(this)" onmouseout="MouseOutButton(this)"
							runat="server" CssClass="ButtonStyle" Text="  Salveaza date   "></asp:button></td>
				<tr id="editButtonsLine">
					<td style="HEIGHT: 24px" align="center" height="24"><asp:button id="btnModifica" onmouseover="MouseOverButton(this)" onmouseout="MouseOutButton(this)"
							runat="server" CssClass="ButtonStyle" Text="  Modifica date  "></asp:button>&nbsp;
						<asp:button id="btnSterge" onmouseover="MouseOverButton(this)" onmouseout="MouseOutButton(this)"
							runat="server" CssClass="ButtonStyle" Text="  Sterge date  " CausesValidation="false"></asp:button>&nbsp;
						<input class="ButtonStyle" id="btnInapoi" onmouseover="MouseOverButton(this)" onclick="tableAdaugaEvaluarePsihologica.style.display='none';tableEvaluarePsihologica.style.display=''"
							onmouseout="MouseOutButton(this)" type="button" value="  Inapoi  ">
					</td>
				</tr>
				<tr>
					<td align="center"><asp:validationsummary id="ValidationSummary1" runat="server" CssClass="AlertRedBold" ShowSummary="False"
							ShowMessageBox="True"></asp:validationsummary></td>
				</tr>
			</TABLE>
		</td>
	</tr>
</table>
<script>
		sp3FormIDfix();
	eval(ctrlID + "_tab1.click()");

</script>
