<%@ Control Language="c#" AutoEventWireup="false" Codebehind="AdminTipuriCompletareCarnete.ascx.cs" Inherits="SiemensHR.Administrare.AdminTipuriCompletareCarnete" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>
<script>

function sp3FormIDfix()
{
document.forms[0].id=ctrlID + "_Form1";

document.getElementById(requiredDenumire).innerText = '';
document.getElementById(requiredCod).innerText = '';
document.getElementById(requiredProcent).innerText = '';
document.getElementById(regularProcent).innerText = '';
document.getElementById(rangeProcent).innerText = '';
document.getElementById(regularDenumire).innerText = '';
document.getElementById(regularCod).innerText = '';
}

function ShowAddForm()
{
	list_form.style.display = "none";
	eval(ctrlID + "_add_buttonLine.style.display = 'none'");
	eval(ctrlID + "_add_form.style.display = ''");		
	eval(ctrlID + "_Form1." + ctrlID + "_txtDenumire.value = '';");	
	eval(ctrlID + "_Form1." + ctrlID + "_txtCod.value = '';");
	eval(ctrlID + "_Form1." + ctrlID + "_txtProcent.value = '';");		
}

function ShowList()
{
	list_form.style.display = "";
	eval(ctrlID + "_add_buttonLine.style.display = ''");
	eval(ctrlID + "_add_form.style.display = 'none'");	
}

function SelectLine( id )
{
	eval(ctrlID + "_Form1." + ctrlID + "_txtTipCompletareID.value = id;");
	eval(ctrlID + "_Form1." + ctrlID + "_btnEdit.click();");
}


</script>
<form id="Form1" name="Form1" method="post" runat="server">
	<table class="tabBackground" id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
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
						<td class="BigBlueBold" id="tdTitle" align="center" colSpan="2" height="50" runat="server">Introduce 
							un tip nou de completare al carnetelor de munca</td>
					</tr>
					<tr>
						<td align="center" colSpan="2"><asp:table id="headerTable" runat="server"></asp:table></td>
					</tr>
					<tr>
						<td>
							<table class="tabBackground" id="Table3" cellSpacing="1" cellPadding="0" width="100%" border="0">
								<tr>
									<td class="NormalGreenBold">Descriere :</td>
									<td><asp:textbox id="txtDenumire" runat="server" MaxLength="100" CssClass="NormalEditBoxuri" size="50"></asp:textbox><SPAN class="CommentRedBold">*</SPAN>
										<asp:requiredfieldvalidator id="requiredDenumire" runat="server" ControlToValidate="txtDenumire" ErrorMessage="Completati denumirea tipului !"
											CssClass="AlertRedBold"><</asp:requiredfieldvalidator>
										<asp:RegularExpressionValidator id="regularDenumire" runat="server" CssClass="AlertRedBold" ErrorMessage="Descrierea nu poate sa contina caractere invalide: <>()';&quot;\ "
											ControlToValidate="txtDenumire" ValidationExpression="^[^>|(|)|<|'|&quot;|;|\\]*$"><</asp:RegularExpressionValidator></td>
								</tr>
								<tr>
									<td class="GreenSeparator" colSpan="2"><IMG height="1" src="images/1x1.gif"></td>
								</tr>
								<tr>
									<td class="NormalGreenBold">Cod:</td>
									<td><asp:textbox id="txtCod" runat="server" MaxLength="100" CssClass="NormalEditBoxuri" size="50"></asp:textbox><SPAN class="CommentRedBold">*</SPAN>
										<asp:requiredfieldvalidator id="requiredCod" runat="server" ControlToValidate="txtCod" ErrorMessage="Completati codul tipului!"
											CssClass="AlertRedBold"><</asp:requiredfieldvalidator>
										<asp:RegularExpressionValidator id="regularCod" runat="server" CssClass="AlertRedBold" ErrorMessage="Codul nu poate sa contina caractere invalide: <>()';&quot;\ "
											ControlToValidate="txtCod" ValidationExpression="^[^>|(|)|<|'|&quot;|;|\\]*$"><</asp:RegularExpressionValidator><SPAN class="CommentRedBold"></SPAN></td>
								</tr>
								<tr>
									<td class="GreenSeparator" colSpan="2"><IMG height="1" src="images/1x1.gif"></td>
								</tr>
								<tr>
									<td class="NormalGreenBold">Procent:</td>
									<td><asp:textbox id="txtProcent" runat="server" MaxLength="100" CssClass="NormalEditBoxuri" size="50"></asp:textbox><SPAN class="CommentRedBold">*</SPAN>
										<asp:requiredfieldvalidator id="requiredProcent" runat="server" ControlToValidate="txtProcent" ErrorMessage="Completati procentul tipului!"
											CssClass="AlertRedBold"><</asp:requiredfieldvalidator><asp:regularexpressionvalidator id="regularProcent" runat="server" CssClass="AlertRedBold" ControlToValidate="txtProcent"
											ErrorMessage="Campul procent necesita valoare numerica!" ValidationExpression="\d*(.)\d*"><</asp:regularexpressionvalidator><asp:rangevalidator id="rangeProcent" runat="server" ControlToValidate="txtProcent" ErrorMessage="Introduceti corect procentul (o valoare intre 0 si 100)!"
											MinimumValue="0" MaximumValue="100" Type="Double" CssClass="AlertRedBold"><</asp:rangevalidator><SPAN class="CommentRedBold"></SPAN></td>
								</tr>
							</table>
							<asp:textbox id="txtTipCompletareID" runat="server"></asp:textbox></td>
					</tr>
					<TR>
						<td class="CommentRedBold" colSpan="2">* - Campuri obligatorii</td>
					</TR>
					<tr id="td_addLine" runat="server">
						<td align="center" colSpan="2" height="50"><asp:button id="btnAdd" onmouseover="MouseOverButton(this)" onmouseout="MouseOutButton(this)"
								runat="server" CssClass="ButtonStyle" Text="Salveaza tip completare"></asp:button>&nbsp;
							<input class="ButtonStyle" onmouseover="MouseOverButton(this)" onclick="ShowList()" onmouseout="MouseOutButton(this)"
								type="button" value="  Inapoi  ">
							<asp:button id="btnEdit" runat="server" Text="Edit" CausesValidation="False"></asp:button></td>
					</tr>
					<TR>
						<TD align="center" colSpan="2"><asp:label id="lblMessage" runat="server" CssClass="AlertRedBold"></asp:label>&nbsp;</TD>
					</TR>
					<tr id="td_editLine" runat="server">
						<td align="center" colSpan="2" height="50"><asp:button id="btnModify" onmouseover="MouseOverButton(this)" onmouseout="MouseOutButton(this)"
								runat="server" CssClass="ButtonStyle" Text="Modifica tip completare"></asp:button>&nbsp;
							<asp:button id="btnDelete" onmouseover="MouseOverButton(this)" onmouseout="MouseOutButton(this)"
								runat="server" CssClass="ButtonStyle" Text="Sterge tip completare" CausesValidation="False"></asp:button>&nbsp;
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
		<tr id="add_buttonLine" height="50" runat="server">
			<td align="center">
				<table id="Table4" cellSpacing="0" cellPadding="0" border="0">
					<tr>
						<td class="UnderlineBlackBold">Pentru adaugarea unui nou tip de completare a 
							carnetelor de munca apasati acest buton:
						</td>
						<td>&nbsp;<INPUT class="ButtonStyle" onmouseover="MouseOverButton(this)" onclick="ShowAddForm()"
								onmouseout="MouseOutButton(this)" type="button" value="Tip nou">&nbsp;</td>
					</tr>
				</table>
			</td>
		</tr>
	</table>
</form>
<script>

sp3FormIDfix();
</script>
