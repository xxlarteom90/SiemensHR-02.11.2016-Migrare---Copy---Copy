<%@ Control Language="c#" AutoEventWireup="false" Codebehind="AdminFunctii.ascx.cs" Inherits="SiemensHR.Administrare.AdminFunctii" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>
<script>
function sp3FormIDfix()
{
	document.forms[0].id=ctrlID + "_Form1";
	//daca a aparut o eroare la adaugare pentru ca mai exista o functie cu acelasi cod se ramane la formularul pentru adaugare
	if (eroare == 1)
	{
		list_form.style.display = "none";
		eval(ctrlID + "_add_buttonLine.style.display = 'none'");
		eval(ctrlID + "_add_form.style.display = ''");	
	}
	
	document.getElementById(requiredCod).innerText = '';
	document.getElementById(regularCod).innerText = '';
	document.getElementById(regularCodSiemens).innerText = '';
	document.getElementById(requiredDenumire).innerText = '';
	document.getElementById(regularDenumire).innerText = '';
	document.getElementById(requiredNormaLucru).innerText = '';
	document.getElementById(regularNormaLucru).innerText = '';
	document.getElementById(rangeNormaLucru).innerText = '';	
}
function ShowAddForm()
{
	list_form.style.display = "none";
	eval(ctrlID + "_add_buttonLine.style.display = 'none'");
	eval(ctrlID + "_add_form.style.display = ''");		
	eval(ctrlID + "_Form1." + ctrlID + "_txtDenumire.value = '';");	
	eval(ctrlID + "_Form1." + ctrlID + "_txtCod.value = '';");	
	eval(ctrlID + "_Form1." + ctrlID + "_txtCodSiemens.value = '';");	
	eval(ctrlID + "_Form1." + ctrlID + "_txtDescriere.value = '';");		
	eval(ctrlID + "_Form1." + ctrlID + "_txtNormaLucru.value = '';");
	eval(ctrlID + "_Form1."+ ctrlID + "_chkPosibilaScutire.checked = true;");
}

function ShowList()
{
	list_form.style.display = "";
	eval(ctrlID + "_add_buttonLine.style.display = ''");
	eval(ctrlID + "_add_form.style.display = 'none'");
}

function SelectLine( id )
{
	eval(ctrlID + "_Form1." + ctrlID + "_txtFunctieID.value = id;");
	eval(ctrlID + "_Form1." + ctrlID + "_btnEdit.click();");
}

//Oprescu Claudia
function ChangeJobFamily()
{
	var lstJobFamilyClient = document.getElementById( lstJobFamily );
	document.getElementById(txtHiddenJobFamily).value=lstJobFamilyClient.options[lstJobFamilyClient.selectedIndex ].value;
}

//Oprescu Claudia
function ChangeTipDeFunctie()
{
	var lstTipDeFunctieClient = document.getElementById( lstTipDeFunctie );
	document.getElementById(txtHiddenTipDeFunctie).value=lstTipDeFunctieClient.options[lstTipDeFunctieClient.selectedIndex ].value;
}

//Oprescu Claudia
function ChangeTipDeSegment()
{
	var lstTipDeSegmentClient = document.getElementById( lstTipDeSegment );
	document.getElementById(txtHiddenTipDeSegment).value=lstTipDeSegmentClient.options[lstTipDeSegmentClient.selectedIndex ].value;
}

//Oprescu Claudia
function ChangePozitie()
{
	var lstPozitieClient = document.getElementById( lstPozitie );
	document.getElementById(txtHiddenPozitie).value=lstPozitieClient.options[lstPozitieClient.selectedIndex ].value;
}

</script>
<form id="Form1" name="Form1" method="post" runat="server">
	<table class="tabBackground" id="Table1" height="200" cellSpacing="0" cellPadding="0" width="100%"
		border="0">
		<tr>
			<td><asp:literal id="litError" runat="server"></asp:literal></td>
		</tr>
		<tr id="list_form">
			<td align="center"><asp:table id="mainTable" runat="server"></asp:table>
				<asp:datagrid id="listDataGrid" runat="server" Width="1098px" PageSize="20" AllowPaging="True"
					AutoGenerateColumns="False" GridLines="None" BorderColor="LightSeaGreen" CellSpacing="1" BorderWidth="1px">
					<ItemStyle CssClass="UnderlineNormalBlack"></ItemStyle>
					<HeaderStyle CssClass="HeaderBlueBold"></HeaderStyle>
					<Columns>
						<asp:BoundColumn DataField="FunctieId" HeaderText="FunctieId"></asp:BoundColumn>
						<asp:BoundColumn DataField="Cod" HeaderText="Cod COR"></asp:BoundColumn>
						<asp:BoundColumn DataField="CodSiemens" HeaderText="Cod Siemens"></asp:BoundColumn>
						<asp:BoundColumn DataField="Nume" HeaderText="Denumire"></asp:BoundColumn>
						<asp:BoundColumn DataField="JobFamilyDenumire" HeaderText="Job Family"></asp:BoundColumn>
						<asp:BoundColumn DataField="TipDeFunctieDenumire" HeaderText="Tip de functie"></asp:BoundColumn>
						<asp:BoundColumn DataField="TipDeSegmentDenumire" HeaderText="Tip de segment de management"></asp:BoundColumn>
						<asp:BoundColumn DataField="Pozitie" HeaderText="Pozitie"></asp:BoundColumn>
						<asp:BoundColumn DataField="NormaLucru" HeaderText="Norma"></asp:BoundColumn>
						<asp:BoundColumn DataField="Descriere" HeaderText="Descriere"></asp:BoundColumn>
						<asp:BoundColumn DataField="POsibilaScutireImpozit" HeaderText="Posibila scutire impozit"></asp:BoundColumn>
					</Columns>
					<PagerStyle Mode="NumericPages"></PagerStyle>
				</asp:datagrid></td>
		</tr>
		<TR id="add_form" runat="server">
			<TD align="center">
				<table id="Table2" cellSpacing="1" cellPadding="0" border="0">
					<tr>
						<td class="BigBlueBold" id="tdTitle" align="center" colSpan="2" height="50" runat="server">Introducere 
							functie noua</td>
					</tr>
					<tr>
						<td align="center" colSpan="2"><asp:table id="headerTable" runat="server"></asp:table></td>
					</tr>
					<tr>
						<td>
							<table class="tabBackground" id="Table3" cellSpacing="1" cellPadding="0" width="100%" border="0">
								<TR>
									<TD class="NormalGreenBold">Cod COR:&nbsp;</TD>
									<TD><asp:textbox id="txtCod" runat="server" size="50" CssClass="NormalEditBoxuri" MaxLength="6" Height="0px"
											Width="150px"></asp:textbox><SPAN class="CommentRedBold">*
											<asp:requiredfieldvalidator id="requiredCod" runat="server" CssClass="AlertRedBold" ErrorMessage="Completati codul!"
												ControlToValidate="txtCod"><</asp:requiredfieldvalidator><asp:regularexpressionvalidator id="regularCod" runat="server" CssClass="AlertRedBold" ErrorMessage="Codul necesita valoare numerica!"
												ControlToValidate="txtCod" ValidationExpression="\d*">< Valoare numerica!</asp:regularexpressionvalidator></SPAN></TD>
								</TR>
								<tr>
									<td class="GreenSeparator" colSpan="2"><IMG height="1" src="images/1x1.gif"></td>
								</tr>
								<TR>
									<TD class="NormalGreenBold">Cod Siemens:&nbsp;</TD>
									<TD><asp:textbox id="txtCodSiemens" runat="server" size="50" CssClass="NormalEditBoxuri" MaxLength="20"
											Height="0px" Width="150px"></asp:textbox><asp:regularexpressionvalidator id="regularCodSiemens" runat="server" CssClass="AlertRedBold" ErrorMessage="Cod Siemens - litere si cifre!"
											ControlToValidate="txtCodSiemens" ValidationExpression="[a-zA-Z0-9]*">< Numai litere si cifre!</asp:regularexpressionvalidator><SPAN class="CommentRedBold"></SPAN></TD>
								</TR>
								<tr>
									<td class="GreenSeparator" colSpan="2"><IMG height="1" src="images/1x1.gif"></td>
								</tr>
								<tr>
									<td class="NormalGreenBold">Denumire:&nbsp;</td>
									<td><asp:textbox id="txtDenumire" runat="server" size="50" CssClass="NormalEditBoxuri" MaxLength="50"
											Width="300px"></asp:textbox><SPAN class="CommentRedBold">*</SPAN>
										<asp:requiredfieldvalidator id="requiredDenumire" runat="server" CssClass="AlertRedBold" ErrorMessage="Completati denumirea functiei!"
											ControlToValidate="txtDenumire"><</asp:requiredfieldvalidator><asp:regularexpressionvalidator id="regularDenumire" runat="server" CssClass="AlertRedBold" ErrorMessage="Denumirea nu poate sa contina caractere invalide: <>()';&quot;\"
											ControlToValidate="txtDenumire" ValidationExpression="^[^>|(|)|<|'|&quot;|;|\\]*$"><</asp:regularexpressionvalidator></td>
								</tr>
								<tr>
									<td class="GreenSeparator" colSpan="2"><IMG height="1" src="images/1x1.gif"></td>
								</tr>
								<TR>
									<TD class="NormalGreenBold" style="HEIGHT: 16px">Job Family:&nbsp;</TD>
									<TD style="HEIGHT: 16px"><SPAN class="CommentRedBold"><asp:dropdownlist id="lstJobFamily" runat="server" Width="300px" onchange="ChangeJobFamily()"></asp:dropdownlist></SPAN></TD>
								</TR>
								<tr>
									<td class="GreenSeparator" colSpan="2"><IMG height="1" src="images/1x1.gif"></td>
								</tr>
								<TR>
									<TD class="NormalGreenBold">Tip de functie:&nbsp;</TD>
									<TD><SPAN class="CommentRedBold"><asp:dropdownlist id="lstTipDeFunctie" runat="server" Width="300px" onchange="ChangeTipDeFunctie()"></asp:dropdownlist></SPAN></TD>
								</TR>
								<tr>
									<td class="GreenSeparator" colSpan="2"><IMG height="1" src="images/1x1.gif"></td>
								</tr>
								<TR>
									<TD class="NormalGreenBold" style="HEIGHT: 13px">Tip de segment de 
										management:&nbsp;</TD>
									<TD style="HEIGHT: 13px"><SPAN class="CommentRedBold"><asp:dropdownlist id="lstTipDeSegment" runat="server" Width="300px" onchange="ChangeTipDeSegment()"></asp:dropdownlist></SPAN></TD>
								</TR>
								<tr>
									<td class="GreenSeparator" colSpan="2"><IMG height="1" src="images/1x1.gif"></td>
								</tr>
								<TR>
									<TD class="NormalGreenBold">Pozitie:&nbsp;</TD>
									<TD><SPAN class="CommentRedBold"><asp:dropdownlist id="lstPozitie" runat="server" Width="300px" onchange="ChangePozitie()"></asp:dropdownlist></SPAN></TD>
								</TR>
								<tr>
									<td class="GreenSeparator" colSpan="2"><IMG height="1" src="images/1x1.gif"></td>
								</tr>
								<TR>
									<TD class="NormalGreenBold">Norma lucru (ore):&nbsp;</TD>
									<TD><asp:textbox id="txtNormaLucru" runat="server" CssClass="NormalEditBoxuri" MaxLength="2" Width="150px"></asp:textbox><SPAN class="CommentRedBold">*
											<asp:requiredfieldvalidator id="requiredNormaLucru" runat="server" CssClass="AlertRedBold" ErrorMessage="Completati norma de lucru!"
												ControlToValidate="txtNormaLucru"><</asp:requiredfieldvalidator><asp:rangevalidator id="rangeNormaLucru" runat="server" CssClass="AlertRedBold" ErrorMessage="Norma trebuie sa aiba valoare intre 1 si 24!"
												ControlToValidate="txtNormaLucru" Type="Integer" MaximumValue="24" MinimumValue="1"><</asp:rangevalidator><asp:regularexpressionvalidator id="regularNormaLucru" runat="server" CssClass="AlertRedBold" ErrorMessage="Norma de lucru necesita valoare numerica!"
												ControlToValidate="txtNormaLucru" ValidationExpression="\d*">< Valoare numerica!</asp:regularexpressionvalidator></SPAN></TD>
								</TR>
								<tr>
									<td class="GreenSeparator" colSpan="2"><IMG height="1" src="images/1x1.gif"></td>
								</tr>
								<TR>
									<TD class="NormalGreenBold">Descriere:&nbsp;</TD>
									<TD><asp:textbox id="txtDescriere" runat="server" CssClass="AreaStyle" MaxLength="255" Width="300px"
											Rows="3" TextMode="MultiLine" Columns="40"></asp:textbox></TD>
								</TR>
								<tr>
									<td class="GreenSeparator" colSpan="2"><IMG height="1" src="images/1x1.gif"></td>
								</tr>
								<TR>
									<TD class="NormalGreenBold">Suporta scutire impozit:</TD>
									<TD><INPUT id="chkPosibilaScutire" style="PADDING-LEFT: 0px; MARGIN-LEFT: 0px; BORDER-TOP-STYLE: none; BORDER-RIGHT-STYLE: none; BORDER-LEFT-STYLE: none; BORDER-BOTTOM-STYLE: none"
											type="checkbox" CHECKED size="20" name="chkActiv" runat="server"></TD>
								</TR>
							</table>
							<asp:textbox id="txtFunctieID" runat="server" Width="51px"></asp:textbox>
							<INPUT style="DISPLAY: none; WIDTH: 56px; HEIGHT: 22px" type="text" runat="server" id="txtHiddenJobFamily"
								size="4"><INPUT style="DISPLAY: none; WIDTH: 48px; HEIGHT: 22px" type="text" runat="server" id="txtHiddenTipDeFunctie"
								size="2"><INPUT style="DISPLAY: none; WIDTH: 48px; HEIGHT: 22px" type="text" runat="server" id="txtHiddenTipDeSegment"
								size="2"><INPUT style="DISPLAY: none; WIDTH: 48px; HEIGHT: 22px" type="text" runat="server" id="txtHiddenPozitie"
								size="2"></td>
					</tr>
					<TR>
						<td class="CommentRedBold" colSpan="2">* - Campuri obligatorii</td>
					</TR>
					<tr id="td_addLine" runat="server">
						<td align="center" colSpan="2" height="50"><asp:button id="btnAdd" onmouseover="MouseOverButton(this)" onmouseout="MouseOutButton(this)"
								runat="server" CssClass="ButtonStyle" Text="Salveaza functie"></asp:button>&nbsp;
							<input class="ButtonStyle" onmouseover="MouseOverButton(this)" onclick="ShowList()" onmouseout="MouseOutButton(this)"
								type="button" value="  Inapoi  ">
							<asp:button id="btnEdit" runat="server" Text="Edit" CausesValidation="False"></asp:button></td>
					</tr>
					<TR>
						<TD align="center" colSpan="2"><asp:label id="lblMessage" runat="server" CssClass="AlertRedBold"></asp:label>&nbsp;</TD>
					</TR>
					<tr id="td_editLine" runat="server">
						<td align="center" colSpan="2" height="50"><asp:button id="btnModify" onmouseover="MouseOverButton(this)" onmouseout="MouseOutButton(this)"
								runat="server" CssClass="ButtonStyle" Text="Modifica functie"></asp:button>&nbsp;
							<asp:button id="btnDelete" onmouseover="MouseOverButton(this)" onmouseout="MouseOutButton(this)"
								runat="server" CssClass="ButtonStyle" Text="Sterge functie" CausesValidation="False"></asp:button>&nbsp;
							<asp:button id="btnInapoi" onmouseover="MouseOverButton(this)" onmouseout="MouseOutButton(this)"
								runat="server" CssClass="ButtonStyle" Text="   Inapoi   " CausesValidation="False"></asp:button></td>
					</tr>
					<TR>
						<TD align="center" colSpan="2"><asp:validationsummary id="ValidationSummary1" onmouseover="MouseOverButton(this)" onmouseout="MouseOutButton(this)"
								runat="server" CssClass="AlertRedBold" ShowMessageBox="True" ShowSummary="False"></asp:validationsummary></TD>
					</TR>
				</table>
			</TD>
		</TR>
		<tr id="add_buttonLine" runat="server">
			<td align="center" height="50">
				<table id="Table4" cellSpacing="0" cellPadding="0" border="0">
					<tr>
						<td class="UnderlineBlackBold">Pentru adaugarea unei&nbsp;functii noi apasati pe 
							acest buton:
						</td>
						<td>&nbsp;<INPUT class="ButtonStyle" onmouseover="MouseOverButton(this)" onclick="ShowAddForm()"
								onmouseout="MouseOutButton(this)" type="button" value="Functie noua">&nbsp;</td>
					</tr>
				</table>
			</td>
		</tr>
	</table>
</form>
<script>
sp3FormIDfix();
</script>
