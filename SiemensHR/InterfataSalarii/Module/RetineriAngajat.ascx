<%@ Control Language="c#" AutoEventWireup="false" Codebehind="RetineriAngajat.ascx.cs" Inherits="SiemensHR.InterfataSalarii.Module.RetineriAngajat" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>
<script type="text/javascript" lang="javascript" src="InterfataSalarii/Module/Pontaj/js/jsCode.js"></script>
<script type="text/javascript" lang="javascript" src="InterfataSalarii/Module/Pontaj/js/Intervale.js"></script>
<script>
var arTabs = new Array('tableIstoricSuspendariCIM', 'tableAdaugaSuspendareCIM');

	function sp3FormIDfix()
	{
		document.forms[0].id=ctrlID + "_Form1";
	}
	
	function SelectTab(index)
	{
		for(i=0; i<arTabs.length; i++)
		{
			if (i==index)
			{
				eval(arTabs[i] + ".style.display=''");
				eval(ctrlID + "_tab"+ (i+1)+ ".className='tabActive'");
				add_line.style.display = "";
				edit_line.style.display = "none";
			}
			else
			{
				eval(ctrlID + "_tab"+ (i+1) + ".className='tab'");
				eval(ctrlID + "_tab"+ (i+1) + ".style.backgroundColor='#7b8fc2'");
				eval(arTabs[i] + ".style.display='none'");
			}
		}
		eval( ctrlID+"_Form1."+ctrlID+"_txtDataStart.disabled = false;" );
		eval( ctrlID+"_Form1."+ctrlID+"_txtRetinere.disabled = true;" );
		eval( ctrlID+"_Form1."+ctrlID+"_ddlTipuriRetineri.disabled = false");
		eval( ctrlID+"_Form1."+ctrlID+"_ddlTipuriRetineri.selectedIndex = '0'");
		eval( ctrlID+"_Form1."+ctrlID+"_txtDataStart.value = '';" );
		eval( ctrlID+"_Form1."+ctrlID+"_txtDataEnd.value = '';" );
		eval( ctrlID+"_Form1."+ctrlID+"_txtRetinere.value = '';" );
		eval( ctrlID+"_Form1."+ctrlID+"_txtValoare.value = '';" );
		eval( ctrlID+"_Form1."+ctrlID+"_txtRetinereID.value = -1;" );	
		eval( ctrlID+"_Form1."+ctrlID+"_chkAlerta.checked = true;");
		titluTab.innerText = "Adaugare retinere angajat";
		ChangeTipRetinere();
	}
	
	function SelectSuspendareCIM( idRetinere, angajatId, tipRetinere, retinere, dataStart, dataEnd, valoare, alerta)
	{
		//alert(eval( ctrlID+"_Form1."+ctrlID+"_ddlTipuriRetineri.options[0].value"));
		//alert(eval( ctrlID+"_Form1."+ctrlID+"_ddlTipuriRetineri.options[1].value"));
		//alert(eval( ctrlID+"_Form1."+ctrlID+"_ddlTipuriRetineri.options[2].value"));
		var okDataStart = (CompareLunaAn(dataStart,LunaActivaDataStart));
		var okDataEnd = (CompareLunaAn(dataEnd,LunaActivaDataStart));
		
		if ((okDataEnd == 0) || (okDataEnd == 1)) //in aceeasi luna si an
		{
			tableIstoricSuspendariCIM.style.display = "none";
			tableAdaugaSuspendareCIM.style.display = "";
			edit_line.style.display = "";
			add_line.style.display = "none";
			titluTab.innerText = "Editare retinere angajat";
		
		   	eval( ctrlID+"_Form1."+ctrlID+"_txtDataStart.value = dataStart;" );
			eval( ctrlID+"_Form1."+ctrlID+"_txtDataEnd.value = dataEnd;" );
			var index = tipRetinere.substring(9,10);
			eval( ctrlID+"_Form1."+ctrlID+"_ddlTipuriRetineri.selectedIndex = '" +  parseInt(index-1,10) + "'");
			eval( ctrlID+"_Form1."+ctrlID+"_ddlTipuriRetineri.disabled = true");
			eval( ctrlID+"_Form1."+ctrlID+"_txtRetinere.value = retinere;" );
			eval( ctrlID+"_Form1."+ctrlID+"_txtValoare.value = valoare;" );
			eval( ctrlID+"_Form1."+ctrlID+"_txtRetinereID.value = idRetinere;" );	
			
			// nu stiu la ce fol cele 2
			document.getElementById(DateStartID).value=document.getElementById(txtDataStartClient).value;
			document.getElementById(DateEndID).value=document.getElementById(txtDataEndClient).value;
			if (alerta == "True")
			{
				eval(ctrlID + "_Form1."+ ctrlID + "_chkAlerta.checked = true;");
				document.getElementById(chkAlertaClient).checked = true;
			}
			else
			{
				eval(ctrlID + "_Form1."+ ctrlID + "_chkAlerta.checked = false;");
				document.getElementById(chkAlertaClient).checked = false;
			}
			if (okDataStart == 2)
			{
				eval( ctrlID+"_Form1."+ctrlID+"_txtDataStart.disabled = true;" );
			}
			else
				eval( ctrlID+"_Form1."+ctrlID+"_txtDataStart.disabled = false;" );	
		}	
	}
	
	function TransferDateRetinere()
	{
		document.getElementById( DataStartRetinereMain ).value = document.getElementById( txtDataStartClient ).value;
		document.getElementById( DataEndRetinereMain ).value = document.getElementById( txtDataEndClient ).value;
		
		document.getElementById( DenumireRetinereMain ).value = document.getElementById( txtDenumireRetinereClient ).value;
		document.getElementById( ValoareRetinereMain ).value = document.getElementById( txtValoareClient ).value;
		document.getElementById( RetinereIdMain ).value = document.getElementById( txtRetinereIdClient ).value;
		document.getElementById( AlertaRetinereMain ).checked = document.getElementById( chkAlertaClient ).checked;
		var lstTipRetinereClient = document.getElementById( ddlTipuriRetineriClient );
		document.getElementById(TipRetinereMain).value = lstTipRetinereClient.options[lstTipRetinereClient.selectedIndex].value;
	}
	
	function BackToList()
	{
		tableAdaugaSuspendareCIM.style.display='none';
		tableIstoricSuspendariCIM.style.display='';
		edit_line.style.display = "none";
		add_line.style.display = "";
	}
	
	function isDate(dataVerif)   
	{		
		var sir = dataVerif.split('.');
		var d = parseInt(sir[0]);
		var m = parseInt(sir[1]);
		var y = parseInt(sir[2]);
		var date = new Date(y,m-1,d); 
		var convertedDate =  "" + date.getFullYear() + (date.getMonth()+1) + date.getDate();
		var givenDate = "" + y + m + d;
		return (givenDate == convertedDate);   
	}
	
	//Lungu Andreea
	function ChangeTipRetinere()
	{
		var lstTipRetinereClient = document.getElementById( ddlTipuriRetineriClient );
		//document.getElementById(TipRetinereMain).value = lstTipRetinereClient.options[lstTipRetinereClient.selectedIndex].value;
		var tipRetinere = lstTipRetinereClient.options[lstTipRetinereClient.selectedIndex].text;
		var denumireRetinere = tipRetinere.substring(13);
		document.getElementById( txtDenumireRetinereClient ).value = denumireRetinere;
		//document.getElementById(DenumireRetinereMain).value = document.getElementById( txtDenumireRetinereClient ).value;
	}
	

//Lungu Andreea - 26.03.2010
function AdaugaRetinereClick()
{
	document.getElementById( ActionRetinereValue ).value = "adaugaRetinere";
	TransferDateRetinere();
	document.getElementById( ctrlID + "_" + FormClientID ).submit();
}

//Lungu Andreea - 26.03.2010
function ModificaRetinereClick()
{
	document.getElementById( ActionRetinereValue ).value = "modificaRetinere";
	TransferDateRetinere();
	document.getElementById(ctrlID + "_" + FormClientID).submit();
}

//Lungu Andreea
function StergeRetinereClick()
{
	if (CheckDelete('Sunteti sigur ca vreti sa stergeti retinerea?'))
	{
		TransferDateRetinere();
		document.getElementById( ActionRetinereValue ).value = "stergeRetinere";
		document.getElementById(ctrlID + "_" + FormClientID).submit();
	}
}
</script>
<!-- Artiom a modificat si nu sa schimbat nimic-->
<table style="border-spacing:0;"  cellPadding="0" width="600" align="center" border="0" valign="top">
	<tr>
		<td><asp:literal id="litError" runat="server"></asp:literal></td>
	</tr>
	<tr>
		<td><IMG height="10" src="../images/1x1.gif"></td>
	</tr>
	<tr>
		<td><asp:table id="tableTabs" runat="server"></asp:table></td>
	</tr>
	<tr>
		<td id="tableIstoricSuspendariCIM" style="vertical-align:top; text-align:center;line-height:503"><asp:table id="listTable" runat="server"></asp:table></td>
		<td class="tabBackground" id="tableAdaugaSuspendareCIM" style="vertical-align:top; text-align:center;">
			<TABLE id="Table2" style="border-spacing:1px; padding:0; width:100%; text-align:center" border="0">
				<TR>
					<TD class="HeaderGreenBold" id="titluTab" style="HEIGHT: 3px;text-align:center" colSpan="2"></TD>
				</TR>
				<TR>
					<TD class="NormalGreenBold" style="WIDTH: 196px; HEIGHT: 22px">Retinere:</TD>
					<TD style="HEIGHT: 22px"><SPAN class="CommentRedBold"><SPAN class="CommentRedBold"><asp:dropdownlist id="ddlTipuriRetineri" runat="server" Width="296px" onchange="ChangeTipRetinere()"></asp:dropdownlist></SPAN></SPAN></TD>
				</TR>
				<tr>
					<td class="GreenSeparator" colSpan="4" style="HEIGHT: 1px"><IMG height="1" src="images/1x1.gif"></td>
				</tr>
				<TR>
					<TD class="NormalGreenBold" style="WIDTH: 196px; HEIGHT: 1px">Denumire&nbsp;retinere:</TD>
					<TD style="HEIGHT: 1px"><SPAN class="CommentRedBold">
							<asp:TextBox id="txtRetinere" runat="server" Width="297px" CssClass="NormalEditBoxuri" ReadOnly="True"></asp:TextBox><SPAN class="CommentRedBold"><SPAN class="CommentRedBold"><SPAN class="CommentRedBold">
										<asp:regularexpressionvalidator id="vldRegExprDescriere" runat="server" CssClass="AlertRedBold" ErrorMessage="Denumirea retinerii nu poate contine caractere invalide: : <>()';&quot;\"
											ControlToValidate="txtRetinere" ValidationExpression="^[^>|(|)|<|'|&quot;|;|\\]*$"><</asp:regularexpressionvalidator></SPAN></SPAN></SPAN></SPAN></TD>
				</TR>
				<tr>
					<td class="GreenSeparator" colSpan="4"><IMG height="1" src="images/1x1.gif"></td>
				</tr>
				<TR>
					<TD class="NormalGreenBold" style="WIDTH: 196px; HEIGHT: 1px">
						<P>Luna&nbsp;inceput: (prima zi a lunii)</P>
					</TD>
					<TD style="HEIGHT: 1px">&nbsp;<asp:textbox id="txtDataStart" style="CURSOR: hand" onclick="ShowCalendar(this,'../')" runat="server"
							CssClass="NormalEditBoxuri" Width="150px"></asp:textbox><SPAN class="CommentRedBold">*
							<asp:requiredfieldvalidator id="Requiredfieldvalidator1" runat="server" CssClass="AlertRedBold" ControlToValidate="txtDataStart"
								ErrorMessage="Completati data de inceput!"><</asp:requiredfieldvalidator></SPAN></TD>
				</TR>
				<tr>
					<td class="GreenSeparator" colSpan="4"><IMG height="1" src="images/1x1.gif"></td>
				</tr>
				<TR>
					<TD class="NormalGreenBold" style="WIDTH: 196px; HEIGHT: 4px">Luna sfarsit: (ultima 
						zi a lunii)</TD>
					<TD style="HEIGHT: 4px">&nbsp;<asp:textbox id="txtDataEnd" style="CURSOR: hand" onclick="ShowCalendar(this,'../')" runat="server"
							CssClass="NormalEditBoxuri" Width="150px"></asp:textbox><SPAN class="CommentRedBold">*
							<asp:requiredfieldvalidator id="Requiredfieldvalidator2" runat="server" CssClass="AlertRedBold" ControlToValidate="txtDataEnd"
								ErrorMessage="Completati data de sfarsit!"><</asp:requiredfieldvalidator></SPAN></TD>
				</TR>
				<tr>
					<td class="GreenSeparator" colSpan="4"><IMG height="1" src="images/1x1.gif"></td>
				</tr>
				<TR>
					<TD class="NormalGreenBold" style="WIDTH: 196px; HEIGHT: 4px">Valoare:</TD>
					<TD class="CommentRedBold" style="HEIGHT: 4px">&nbsp;<asp:textbox id="txtValoare" runat="server" MaxLength="50" CssClass="NormalEditBoxuri" Width="152px"></asp:textbox>*
						<asp:requiredfieldvalidator id="Requiredfieldvalidator4" runat="server" CssClass="AlertRedBold" ControlToValidate="txtValoare"
							ErrorMessage="Completati valoarea!"><</asp:requiredfieldvalidator><asp:comparevalidator id="Comparevalidator7" runat="server" CssClass="AlertRedBold" ControlToValidate="txtValoare"
							ErrorMessage="Introduceti o valoare reala!" Type="Double" Operator="DataTypeCheck"><</asp:comparevalidator></TD>
				</TR>
				<tr>
					<td class="GreenSeparator" colSpan="4"><IMG height="1" src="images/1x1.gif"></td>
				</tr>
				<TR>
					<TD class="NormalGreenBold" style="WIDTH: 196px; HEIGHT: 4px">Alerta in ultima luna 
						de retinere:</TD>
					<TD style="HEIGHT: 4px"><INPUT id="chkAlerta" style="PADDING-LEFT: 0px; MARGIN-LEFT: 0px; BORDER-TOP-STYLE: none; BORDER-RIGHT-STYLE: none; BORDER-LEFT-STYLE: none; BORDER-BOTTOM-STYLE: none"
							type="checkbox" CHECKED size="20" name="chkActiv" runat="server"></TD>
				</TR>
			</TABLE>
			<TABLE cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
                <tr id="add_line">
                    <td align="center">&nbsp;<input class="ButtonStyle" id="btnAdaugaRetinere" onmouseover="MouseOverButton(this)" onclick="AdaugaRetinereClick()"
                        onmouseout="MouseOutButton(this)" type="button" value="Adauga retinere" name="btnAdaugaRetinere" runat="server" size="20" tabindex="0"></td>
                </tr>
				<TR style="DISPLAY: none">
					<TD align="center"></TD>
				</TR>
				<tr id="edit_line" style="DISPLAY: none">
					<td style="HEIGHT: 81px" align="center">
						<P class="CommentRedBold">
                            <input class="ButtonStyle" id="btnModificaRetinere" onmouseover="MouseOverButton(this)"
                                onclick="ModificaRetinereClick()" onmouseout="MouseOutButton(this)" type="button" value="Modifica retinere"
                                name="btnModificaRetinere" runat="server" size="20" tabindex="0">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<INPUT class="ButtonStyle" id="btnStergeRetinere" onmouseover="MouseOverButton(this)" onclick="StergeRetinereClick()"
								onmouseout="MouseOutButton(this)" type="button" value="Sterge retinere" name="btnStergeRetinere" runat="server" size="20" tabindex="0">&nbsp; 
							&nbsp;&nbsp; <input class="ButtonStyle" id="btnInapoi" onmouseover="MouseOverButton(this)" onclick="BackToList()"
								onmouseout="MouseOutButton(this)" type="button" value="  Inapoi  " size="20" tabindex="0">
						</P>
						<P class="CommentRedBold">*In cazul unei stergeri/modificari, daca sunt intervale 
							care pornesc dintr-o luna anterioara, nu se va putea sterge/modifica decat acea 
							perioada din interval care incepe in luna activa.
						</P>
					</td>
				</tr>
				<TR style="DISPLAY: none">
					<TD align="center">
						<P class="CommentRedBold">*Aceste retineri se initializeaza la inceputul fiecarei 
							luni in situatia lunara a angajatului.
						</P>
					</TD>
				</TR>
				<tr style="DISPLAY: none">
					<td align="center"><INPUT id="DateStart" type="text" maxLength="10" name="DateStart" runat="server">
						<INPUT id="DateEnd" type="text" maxLength="10" name="DateEnd" runat="server"> <input id="txtRetinereID" type="hidden" value="-1" name="txtRetinereIDHidden" runat="server">
						<asp:validationsummary id="ValidationSummary1" runat="server" CssClass="AlertRedBold" ShowSummary="False"
							ShowMessageBox="True"></asp:validationsummary></td>
				</tr>
			</TABLE>
			<P class="CommentRedBold">
			</P>
		</td>
	</tr>
</table>
<SCRIPT>
	<!-- Modificat de Andreea si Artiom  replace-->
    ctrlID = ctrlID.replace(":", "_");
    ctrlID = ctrlID.replace(":", "_");
    ctrlID = ctrlID.replace("$", "_");
    ctrlID = ctrlID.replace("$", "_");
	sp3FormIDfix();
	//alert(ctrlID + "_tab1.click()");
	eval(ctrlID + "_tab1.click()");
</SCRIPT>
