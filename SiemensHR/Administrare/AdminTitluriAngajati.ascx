<%@ Control Language="c#" AutoEventWireup="false" Codebehind="AdminTitluriAngajati.ascx.cs" Inherits="SiemensHR.Administrare.AdminTitluriAngajati" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>
<script>
function sp3FormIDfix()
{
document.forms[0].id=ctrlID + "_Form1";

document.getElementById(requiredDenumire).innerText = '';
document.getElementById(regularDenumire).innerText = '';
document.getElementById(requiredSimbol).innerText = '';
document.getElementById(regularSimbol).innerText = '';
}
function ShowAddForm()
{
	list_form.style.display = "none";
	eval(ctrlID + "_add_buttonLine.style.display = 'none'");
	eval(ctrlID + "_add_form.style.display = ''");		
	eval(ctrlID + "_Form1." + ctrlID + "_txtDenumire.value = '';");	
	eval(ctrlID + "_Form1." + ctrlID + "_txtSimbol.value = '';");		

}

function ShowList()
{
	list_form.style.display = "";
	eval(ctrlID + "_add_buttonLine.style.display = ''");
	eval(ctrlID + "_add_form.style.display = 'none'");	

}

function SelectLine( id )
{
	eval(ctrlID + "_Form1." + ctrlID + "_txtTitluAngajatID.value = id;");
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
							un nou titlu</td>
					</tr>
					<tr>
						<td align="center" colSpan="2"><asp:table id="headerTable" runat="server"></asp:table></td>
					</tr>
					<tr>
						<td>
							<table class="tabBackground" id="Table3" cellSpacing="1" cellPadding="0" width="100%" border="0">
								<tr>
									<td class="NormalGreenBold">Denumire :</td>
									<td><asp:textbox id="txtDenumire" runat="server" size="50" CssClass="NormalEditBoxuri" MaxLength="100"
											Width="300px"></asp:textbox><SPAN class="CommentRedBold">*</SPAN>
										<asp:requiredfieldvalidator id="requiredDenumire" runat="server" ErrorMessage="Completati denumirea titlului !"
											ControlToValidate="txtDenumire" CssClass="AlertRedBold"><</asp:requiredfieldvalidator>
										<asp:regularexpressionvalidator id="regularDenumire" runat="server" CssClass="AlertRedBold" ControlToValidate="txtDenumire"
											ErrorMessage="Nu puteti adauga caractere invalide pentru denumire: <>()';&quot;\" ValidationExpression="^[^>|(|)|<|'|&quot;|;|\\]*$"><</asp:regularexpressionvalidator></td>
								</tr>
								<tr>
									<td class="GreenSeparator" colSpan="2"><IMG height="1" src="images/1x1.gif"></td>
								</tr>
								<tr>
									<td class="NormalGreenBold">Simbol :</td>
									<td><asp:textbox id="txtSimbol" runat="server" CssClass="AreaStyle" MaxLength="10" Columns="40" Rows="4"
											Width="300px"></asp:textbox><SPAN class="CommentRedBold">*</SPAN>
										<asp:requiredfieldvalidator id="requiredSimbol" runat="server" ErrorMessage="Completati simbolul titlului !"
											ControlToValidate="txtSimbol" CssClass="AlertRedBold"><</asp:requiredfieldvalidator>
										<asp:regularexpressionvalidator id="regularSimbol" runat="server" CssClass="AlertRedBold" ControlToValidate="txtSimbol"
											ErrorMessage="Nu puteti adauga caractere invalide pentru simbol: <>()';&quot;\" ValidationExpression="^[^>|(|)|<|'|&quot;|;|\\]*$"><</asp:regularexpressionvalidator><SPAN class="CommentRedBold"></SPAN></td>
								</tr>
							</table>
							<asp:textbox id="txtTitluAngajatID" runat="server"></asp:textbox></td>
					</tr>
					<TR>
						<td class="CommentRedBold" colSpan="2">* - Campuri obligatorii</td>
					</TR>
					<tr id="td_addLine" runat="server">
						<td align="center" colSpan="2" height="50"><asp:button id="btnAdd" onmouseover="MouseOverButton(this)" onmouseout="MouseOutButton(this)"
								runat="server" CssClass="ButtonStyle" Text="Salveaza titlu"></asp:button>&nbsp;
							<input class="ButtonStyle" onmouseover="MouseOverButton(this)" onclick="ShowList()" onmouseout="MouseOutButton(this)"
								type="button" value="  Inapoi  ">
							<asp:button id="btnEdit" runat="server" Text="Edit" CausesValidation="False"></asp:button></td>
					</tr>
					<TR>
						<TD align="center" colSpan="2"><asp:label id="lblMessage" runat="server" CssClass="AlertRedBold"></asp:label>&nbsp;</TD>
					</TR>
					<tr id="td_editLine" runat="server">
						<td align="center" colSpan="2" height="50"><asp:button id="btnModify" onmouseover="MouseOverButton(this)" onmouseout="MouseOutButton(this)"
								runat="server" CssClass="ButtonStyle" Text="Modifica titlu"></asp:button>&nbsp;
							<asp:button id="btnDelete" onmouseover="MouseOverButton(this)" onmouseout="MouseOutButton(this)"
								runat="server" CssClass="ButtonStyle" Text="Sterge titlu" CausesValidation="False"></asp:button>&nbsp;
							<asp:button id="btnInapoi" onmouseover="MouseOverButton(this)" onmouseout="MouseOutButton(this)"
								runat="server" CssClass="ButtonStyle" Text="   Inapoi   " CausesValidation="False"></asp:button></td>
					</tr>
					<TR>
						<TD align="center" colSpan="2"><asp:validationsummary id="ValidationSummary1" onmouseover="MouseOverButton(this)" onmouseout="MouseOutButton(this)"
								runat="server" CssClass="AlertRedBold" ShowSummary="False" ShowMessageBox="True"></asp:validationsummary></TD>
					</TR>
				</table>
			</TD>
		</TR>
		<tr id="add_buttonLine" height="50" runat="server">
			<td align="center">
				<table id="Table4" cellSpacing="0" cellPadding="0" border="0">
					<tr>
						<td class="UnderlineBlackBold">Pentru adaugarea unui nou titlu angajat apasati pe 
							acest buton:
						</td>
						<td>&nbsp;<INPUT class="ButtonStyle" onmouseover="MouseOverButton(this)" onclick="ShowAddForm()"
								onmouseout="MouseOutButton(this)" type="button" value="Titlu angajat nou">&nbsp;</td>
					</tr>
				</table>
			</td>
		</tr>
	</table>
</form>
<script>
sp3FormIDfix();
</script>
