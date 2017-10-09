<%@ Control Language="c#" AutoEventWireup="false" Codebehind="PersoaneIntretinere.ascx.cs" Inherits="SiemensHR.EditTasks.PersoaneIntretinere" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<script>
var arTabs = new Array('tableListPers', 'tableAdaugaPers');

/*
	Modificat:	Lungu Andreea
	Data:		18.03.2008
	Descriere:	A fost adaugat checkbox0ul activ
*/
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
		editButtonsLine.style.display = "none";
		addButtonsLine.style.display = "";
		tdTextLine.innerText = "Adaugare persoana aflata in inretinere";
		eval(ctrlID + "_Form1." + ctrlID + "_txtNume.value = '';");
		eval(ctrlID + "_Form1." + ctrlID + "_txtPrenume.value = '';");
		eval(ctrlID + "_Form1." + ctrlID + "_txtCNP.value = '';");
		eval(ctrlID + "_Form1." + ctrlID + "_ddlTipPersoana.SelectedIndex = 0;");
		eval(ctrlID + "_Form1." + ctrlID + "_ddlInvaliditate.SelectedIndex = 0;");
		eval(ctrlID + "_Form1."+ ctrlID + "_chkActiv.checked = true;");
			
		//eval(ctrlID + "_lCoefTotal.innerText ='';");
	}
	
	function SelectPersoana(ID, Nume, Prenume, CNP, TipID, InvaliditateID, Activ)
	{
		tableListPers.style.display = "none";
		editButtonsLine.style.display = "";
		addButtonsLine.style.display = "none";
		tableAdaugaPers.style.display = "";
		
		eval(ctrlID + "_Form1." + ctrlID + "_persID.value =ID;");
		eval(ctrlID + "_Form1." + ctrlID + "_txtNume.value = Nume;");
		eval(ctrlID + "_Form1." + ctrlID + "_txtPrenume.value = Prenume;");
		eval(ctrlID + "_Form1." + ctrlID + "_txtCNP.value = CNP;");		
		eval(ctrlID + "_Form1." + ctrlID + "_ddlTipPersoana.value = TipID;");
		eval(ctrlID + "_Form1." + ctrlID + "_ddlInvaliditate.value = InvaliditateID;");
		if (Activ == "True")
			eval(ctrlID + "_Form1."+ ctrlID + "_chkActiv.checked = true;");
		else
			eval(ctrlID + "_Form1."+ ctrlID + "_chkActiv.checked = false;");
		
		//eval(ctrlID + "_lCoefTotal.innerText = Coeficient;");
								
		tdTextLine.innerText = "Editare persoana aflata in intretinere:";
		
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

//Deschide o fereastra noua in care se va incarca fereastra de admin pt invaliditati
function OpenAdminWindow( typeOfAdminPage)
{
	
	switch (typeOfAdminPage)
	{
		case "invaliditati":
			h = Calculate_y_coordinate( 300);
			w = Calculate_x_coordinate( 600);
			oNewWindow = window.open("Administrare/AdminInvaliditatiAddAngajat.aspx",null,"height=300,width=600, top=" + h + ",left=" + w + " ,status=yes,toolbar=no,menubar=no,location=no,scrollbars=yes");
			oNewWindow.focus();
			break;
		default:
			break;
	}
}

//Sterge toate intrarile din combo-ul cu invaliditati
function DeleteInvaliditatiCombo()
{
	var invaliditatiCombo = document.getElementById( ctrlID + '_ddlInvaliditate' ); 
	while( invaliditatiCombo.length > 0 )
	{
		invaliditatiCombo.remove( invaliditatiCombo.selectedIndex );
	}
}

//Adauga o intrare la la combo-ul cu invaliditati
function FillInvaliditateCombo( invaliditateText, invaliditateValoare)
{
	var invaliditatiCombo = document.getElementById( ctrlID + '_ddlInvaliditate' );
	var o = new Option();
	o.text = invaliditateText;
	o.value = invaliditateValoare;
	invaliditatiCombo.add( o, 0 ); 
}

</script>
<table cellSpacing="0" cellPadding="0" width="600" align="center" border="0">
	<tr>
		<td colSpan="3"><asp:literal id="litError" runat="server"></asp:literal></td>
	</tr>
	<tr>
		<td colSpan="2"><IMG height="10" src="../images/1x1.gif"></td>
	</tr>
	<tr>
		<td colSpan="2"><asp:table id="tableTabs" runat="server"></asp:table></td>
	</tr>
	<tr>
		<td id="tableListPers" vAlign="top" align="center" colSpan="2" height="100%"><asp:table id="listTable" runat="server"></asp:table></td>
		<td id="tableAdaugaPers" align="center" colSpan="2" style="WIDTH: 618px">
			<TABLE height="200" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
				<tr>
					<td class="tabBackground">
						<TABLE height="100%" cellSpacing="1" cellPadding="0" width="100%" align="center" border="0">
							<tr>
								<td class="HeaderGreenBold" id="tdTextLine" align="center" colSpan="2">Adaugati 
									persoana in intretinere:</td>
							</tr>
							<TR>
								<TD class="NormalGreenBold">Nume:<INPUT id="persID" type="hidden" runat="server"></TD>
								<TD><asp:textbox id="txtNume" runat="server" CssClass="NormalEditBoxuri" MaxLength="50" Width="180px"></asp:textbox>
									<asp:regularexpressionvalidator id="RegularExpressionValidator1" runat="server" ControlToValidate="txtNume" ValidationExpression="^[^>|(|)|<|'|&quot;|;|\\]*$"
										ErrorMessage="Nu puteti adauga caractere invalide pentru nume: <>()';&quot;\" CssClass="AlertRedBold"><</asp:regularexpressionvalidator><span class="CommentRedBold"></span><asp:requiredfieldvalidator id="RequiredField_nume" runat="server" ControlToValidate="txtNume" CssClass="AlertRedBold"
										ErrorMessage="Completati numele!"><  </asp:requiredfieldvalidator></TD>
							</TR>
							<tr>
								<td class="GreenSeparator" colSpan="2"><IMG height="1" src="../images/1x1.gif"></td>
							</tr>
							<TR>
								<TD class="NormalGreenBold" style="HEIGHT: 12px">Prenume:</TD>
								<TD style="HEIGHT: 12px"><asp:textbox id="txtPrenume" runat="server" CssClass="NormalEditBoxuri" MaxLength="50" Width="180px"></asp:textbox>
									<asp:regularexpressionvalidator id="Regularexpressionvalidator2" runat="server" ControlToValidate="txtPrenume" ValidationExpression="^[^>|(|)|<|'|&quot;|;|\\]*$"
										ErrorMessage="Nu puteti adauga caractere invalide pentru prenume: <>()';&quot;\" CssClass="AlertRedBold"><</asp:regularexpressionvalidator><span class="CommentRedBold"><asp:requiredfieldvalidator id="RequiredField_prenume" runat="server" ControlToValidate="txtPrenume" CssClass="AlertRedBold"
											ErrorMessage="Completati prenumele!"><  </asp:requiredfieldvalidator></span></TD>
							</TR>
							<tr>
								<td class="GreenSeparator" colSpan="2"><IMG height="1" src="../images/1x1.gif"></td>
							</tr>
							<TR>
								<TD class="NormalGreenBold">CNP:</TD>
								<TD><asp:textbox id="txtCNP" runat="server" CssClass="NormalEditBoxuri" MaxLength="13" Width="180px"></asp:textbox><SPAN class="CommentRedBold">
										<asp:customvalidator id="customCNP" runat="server" CssClass="AlertRedBold" ErrorMessage="CNP nu e valid!"
											ControlToValidate="txtCNP" ClientValidationFunction="CheckCNP"> <    </asp:customvalidator>
										<asp:requiredfieldvalidator id="Requiredfieldvalidator1" runat="server" CssClass="AlertRedBold" ErrorMessage="Completati CNP!"
											ControlToValidate="txtCNP">< </asp:requiredfieldvalidator></SPAN></TD>
							</TR>
							<tr>
								<td class="GreenSeparator" colSpan="2"><IMG height="1" src="../images/1x1.gif"></td>
							</tr>
							<!-- 
									Calitatea, invaliditatea si coeficientul persoanelor in intretinere nu mai sunt valabile in legea curenta
							-->
							<tr id="trActiv" runat="server">
								<TD class="NormalGreenBold" style="HEIGHT: 9px">Tip persoana:</TD>
								<TD class="NormalGreenBold" style="HEIGHT: 9px"><asp:dropdownlist id="ddlTipPersoana" runat="server" Width="178px"></asp:dropdownlist></TD>
							</tr>
							<tr>
								<td class="GreenSeparator" style="HEIGHT: 1px" colSpan="2"><IMG height="1" src="../images/1x1.gif"></td>
							</tr>
							<tr>
								<TD class="NormalGreenBold" style="HEIGHT: 2px">Invaliditate:</TD>
								<TD class="NormalGreenBold" style="HEIGHT: 3px"><asp:dropdownlist id="ddlInvaliditate" runat="server" Width="178px"></asp:dropdownlist><INPUT onclick="javascript:OpenAdminWindow('invaliditati')" type="button" value="...">
								</TD>
							</tr>
							<tr>
								<td class="GreenSeparator" style="HEIGHT: 1px" colSpan="2"><IMG height="1" src="../images/1x1.gif"></td>
							</tr>
							<TR>
								<TD class="NormalGreenBold" style="HEIGHT: 2px">Activ</TD>
								<TD class="NormalGreenBold" style="HEIGHT: 3px"><INPUT id="chkActiv" style="PADDING-LEFT: 0px; MARGIN-LEFT: 0px; BORDER-TOP-STYLE: none; BORDER-RIGHT-STYLE: none; BORDER-LEFT-STYLE: none; BORDER-BOTTOM-STYLE: none"
										type="checkbox" size="20" name="chkActiv" runat="server" CHECKED></TD>
							</TR>
						</TABLE>
					</td>
				</tr>
				<tr id="addButtonsLine">
					<td align="center" height="100%"><asp:button id="btnAdaugaPersInIntretinere" onmouseover="MouseOverButton(this)" onmouseout="MouseOutButton(this)"
							runat="server" CssClass="ButtonStyle" Text="  Salveaza persoana"></asp:button></td>
				<tr id="editButtonsLine">
					<td align="center" height="100%"><asp:button id="btnModificaPersoana" onmouseover="MouseOverButton(this)" onmouseout="MouseOutButton(this)"
							runat="server" CssClass="ButtonStyle" Text="  Modifica persoana"></asp:button>&nbsp;
						<asp:button id="btnStergePersoana" onmouseover="MouseOverButton(this)" onmouseout="MouseOutButton(this)"
							runat="server" CssClass="ButtonStyle" Text="  Sterge persoana" CausesValidation="false"></asp:button>&nbsp;
						<input class="ButtonStyle" id="btnInapoi" onmouseover="MouseOverButton(this)" onclick="tableAdaugaPers.style.display='none';tableListPers.style.display=''"
							onmouseout="MouseOutButton(this)" type="button" value="  Inapoi  ">
					</td>
				</tr>
				<tr>
					<td align="center"></td>
				</tr>
			</TABLE>
			<asp:validationsummary id="ValidationSummary1" runat="server" ShowMessageBox="True" ShowSummary="False"></asp:validationsummary></td>
	</TD>
	<tr>
		<td colSpan="3"></td>
	</tr>
	<tr class="HeaderGreenBold" style="VISIBILITY: hidden">
		<td colSpan="3"><asp:label id="lCoefTotalPersIntret" Runat="server"></asp:label></td>
	</tr>
</table>
<script>
	sp3FormIDfix();		
	eval(ctrlID + "_tab1.click()");
</script>
