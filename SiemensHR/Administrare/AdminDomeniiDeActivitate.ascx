<%@ Control Language="c#" AutoEventWireup="false" Codebehind="AdminDomeniiDeActivitate.ascx.cs" Inherits="SiemensHR.Administrare.AdminDomeniiDeActivitate" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<script>
function sp3FormIDfix()
{
document.forms[0].id=ctrlID + "_Form1";

document.getElementById(requiredCod).innerText = '';
document.getElementById(regularCod).innerText = '';
document.getElementById(requiredDenumire).innerText = '';
document.getElementById(regularDenumire).innerText = '';
document.getElementById(requiredProcent).innerText = '';
document.getElementById(vldProcent).innerText = '';
document.getElementById(requiredNorma).innerText = '';
}
function ShowAddForm()
{
	list_form.style.display = "none";
	eval(ctrlID + "_add_buttonLine.style.display = 'none'");
	eval(ctrlID + "_add_form.style.display = ''");		
	eval(ctrlID + "_Form1." + ctrlID + "_txtDenumire.value = '';");	
	eval(ctrlID + "_Form1." + ctrlID + "_txtCod.value = '';");	
	eval(ctrlID + "_Form1." + ctrlID + "_txtDescriere.value = '';");	
	eval(ctrlID + "_Form1." + ctrlID + "_txtProcent.value = '';");
	eval(ctrlID + "_Form1." + ctrlID + "_ddlNorma.value = 8;");
	eval(ctrlID + "_Form1." + ctrlID + "_rblContributieAccidente.value = 0;");
	//eval(ctrlID + "_Form1." + ctrlID + "_chkActiv.checked = false;");		

}

function ShowList()
{
	list_form.style.display = "";
	eval(ctrlID + "_add_buttonLine.style.display = ''");
	eval(ctrlID + "_add_form.style.display = 'none'");	

}

function SelectLine(id,activ)
{
	eval(ctrlID + "_Form1." + ctrlID + "_txtDomeniuID.value = id;");
	eval(ctrlID + "_Form1." + ctrlID + "_btnEdit.click();");
	
}


</script>
<form id="Form1" name="Form1" method="post" runat="server">
	<table class="tabBackground" id="Table1" height="200" cellSpacing="0" cellPadding="0" width="100%"
		border="0">
		<tr>
			<td><asp:literal id="litError" runat="server"></asp:literal></td>
		</tr>
		<tr id="list_form">
			<td align="center"><asp:table id="mainTable" runat="server"></asp:table></td>
		</tr>
		<TR id="add_form" runat="server">
			<TD align="center">
				<table id="Table2" cellSpacing="1" cellPadding="0" border="0">
					<tr>
						<td class="BigBlueBold" id="tdTitle" align="center" colSpan="2" height="50" runat="server">Introducere 
							domeniu de activitate nou</td>
					</tr>
					<tr>
						<td align="center" colSpan="2"><asp:table id="headerTable" runat="server"></asp:table></td>
					</tr>
					<tr>
						<td>
							<table class="tabBackground" id="Table3" cellSpacing="1" cellPadding="0" width="100%" border="0">
								<TR>
									<TD class="NormalGreenBold" style="WIDTH: 83px">Cod CAEN:&nbsp;</TD>
									<TD>&nbsp;<asp:textbox id="txtCod" runat="server" size="50" CssClass="NormalEditBoxuri" MaxLength="6" Height="0px"
											Width="278px"></asp:textbox><SPAN class="CommentRedBold">*
											<asp:requiredfieldvalidator id="requiredCod" runat="server" CssClass="AlertRedBold" ErrorMessage="Completati codul!"
												ControlToValidate="txtCod"><</asp:requiredfieldvalidator><asp:regularexpressionvalidator id="regularCod" runat="server" CssClass="AlertRedBold" ErrorMessage="Codul necesita valoare numerica!"
												ControlToValidate="txtCod" ValidationExpression="\d*">< Valoare numerica!</asp:regularexpressionvalidator></SPAN></TD>
								</TR>
								<tr>
									<td class="GreenSeparator" colSpan="2"><IMG height="1" src="images/1x1.gif"></td>
								</tr>
								<tr>
									<td class="NormalGreenBold" style="WIDTH: 83px">Denumire:&nbsp;</td>
									<td>&nbsp;<asp:textbox id="txtDenumire" runat="server" size="50" CssClass="NormalEditBoxuri" MaxLength="50"
											Width="278px"></asp:textbox><SPAN class="CommentRedBold">*</SPAN>
										<asp:requiredfieldvalidator id="requiredDenumire" runat="server" CssClass="AlertRedBold" ErrorMessage="Completati denumirea domeniului de activitate!"
											ControlToValidate="txtDenumire"><</asp:requiredfieldvalidator>
										<asp:RegularExpressionValidator id="regularDenumire" runat="server" CssClass="AlertRedBold" ControlToValidate="txtDenumire"
											ErrorMessage="Denumirea nu poate sa contina caractere invalide: <>()';&quot;\ " ValidationExpression="^[^>|(|)|<|'|&quot;|;|\\]*$"><</asp:RegularExpressionValidator></td>
								</tr>
								<tr>
									<td class="GreenSeparator" colSpan="2"><IMG height="1" src="images/1x1.gif"></td>
								</tr>
								<tr>
									<td class="NormalGreenBold" style="WIDTH: 83px">Procent:&nbsp;</td>
									<td>&nbsp;<asp:textbox id="txtProcent" runat="server" size="50" CssClass="NormalEditBoxuri" MaxLength="5"
											Width="278px"></asp:textbox><SPAN class="CommentRedBold">*</SPAN>
										<asp:requiredfieldvalidator id="requiredProcent" runat="server" CssClass="AlertRedBold" ControlToValidate="txtProcent"
											ErrorMessage="Completati procentul!"><</asp:requiredfieldvalidator>
										<asp:RangeValidator id="vldProcent" runat="server" ErrorMessage="Valoarea pentru procent trebuie sa fie intre 0 si 100!"
											ControlToValidate="txtProcent" MaximumValue="100" MinimumValue="0" Type="Double" CssClass="AlertRedBold"><</asp:RangeValidator></td>
								</tr>
								<tr>
									<td class="GreenSeparator" colSpan="2"><IMG height="1" src="images/1x1.gif"></td>
								</tr>
								<tr>
									<td class="NormalGreenBold" style="WIDTH: 83px; HEIGHT: 1px">Norma:&nbsp;</td>
									<td style="HEIGHT: 1px"><SPAN class="CommentRedBold">
											<asp:DropDownList id="ddlNorma" runat="server" Width="278px">
												<asp:ListItem Value="6">6</asp:ListItem>
												<asp:ListItem Value="7">7</asp:ListItem>
												<asp:ListItem Value="8">8</asp:ListItem>
											</asp:DropDownList>&nbsp;*</SPAN>
										<asp:requiredfieldvalidator id="requiredNorma" runat="server" CssClass="AlertRedBold" ControlToValidate="ddlNorma"
											ErrorMessage="Selectati norma!"><</asp:requiredfieldvalidator></td>
								</tr>
								<tr>
									<td class="GreenSeparator" colSpan="2"><IMG height="1" src="images/1x1.gif"></td>
								</tr>
								<TR>
									<TD class="NormalGreenBold" style="WIDTH: 83px">Descriere:&nbsp;</TD>
									<TD>&nbsp;<asp:textbox id="txtDescriere" runat="server" CssClass="AreaStyle" MaxLength="255" Rows="3" TextMode="MultiLine"
											Columns="40" Width="277px"></asp:textbox></TD>
								</TR>
								<tr>
									<td class="GreenSeparator" colSpan="2"><IMG height="1" src="images/1x1.gif"></td>
								</tr>
								<TR>
									<td class="NormalGreenBold">
										<DIV style="WIDTH: 142px; DISPLAY: inline; HEIGHT: 57px" ms_positioning="FlowLayout">Datoreaza 
											contributie de accidente de munca:</DIV>
									</td>
									<TD vAlign="middle"><asp:radiobuttonlist id="rblContributieAccidente" runat="server" CssClass="NormalGreenBold" RepeatDirection="Horizontal">
											<asp:ListItem Value="1">Da</asp:ListItem>
											<asp:ListItem Value="0" Selected="True">Nu</asp:ListItem>
										</asp:radiobuttonlist></TD>
								</TR>
							</table>
						</td>
					</tr>
					<TR>
						<TD class="CommentRedBold" colSpan="2">
							<asp:textbox style="Z-INDEX: 0" id="txtDomeniuID" runat="server"></asp:textbox></TD>
					</TR>
					<TR>
						<td class="CommentRedBold" colSpan="2">* - Campuri obligatorii</td>
					</TR>
					<tr id="td_addLine" runat="server">
						<td align="center" colSpan="2" height="50"><asp:button id="btnAdd" onmouseover="MouseOverButton(this)" onmouseout="MouseOutButton(this)"
								runat="server" CssClass="ButtonStyle" Text="Salveaza domeniu"></asp:button>&nbsp;
							<input class="ButtonStyle" onmouseover="MouseOverButton(this)" onclick="ShowList()" onmouseout="MouseOutButton(this)"
								type="button" value="  Inapoi  ">
							<asp:button id="btnEdit" runat="server" Text="Edit" CausesValidation="False"></asp:button></td>
					</tr>
					<TR>
						<TD align="center" colSpan="2"><asp:label id="lblMessage" runat="server" CssClass="AlertRedBold"></asp:label>&nbsp;</TD>
					</TR>
					<tr id="td_editLine" runat="server">
						<td align="center" colSpan="2" height="50"><asp:button id="btnModify" onmouseover="MouseOverButton(this)" onmouseout="MouseOutButton(this)"
								runat="server" CssClass="ButtonStyle" Text="Modifica domeniu"></asp:button>&nbsp;
							<asp:button id="btnDelete" onmouseover="MouseOverButton(this)" onmouseout="MouseOutButton(this)"
								runat="server" CssClass="ButtonStyle" Text="Sterge domeniu" CausesValidation="False"></asp:button>&nbsp;
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
						<td class="UnderlineBlackBold">Pentru adaugarea unui domeniu de activitate nou 
							apasati pe acest buton:
						</td>
						<td>&nbsp;<INPUT class="ButtonStyle" onmouseover="MouseOverButton(this)" onclick="ShowAddForm()"
								onmouseout="MouseOutButton(this)" type="button" value="Domeniu nou">&nbsp;</td>
					</tr>
				</table>
			</td>
		</tr>
	</table>
</form>
<script>
sp3FormIDfix();
</script>
