<%@ Control Language="c#" AutoEventWireup="false" Codebehind="AdminStudii.ascx.cs" Inherits="SiemensHR.Administrare.AdminStudii" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>
<script>
function sp3FormIDfix()
{
document.forms[0].id=ctrlID + "_Form1";

document.getElementById(requiredDenumire).innerText = '';
document.getElementById(regularDenumire).innerText = '';
}
function ShowAddForm()
{
	list_form.style.display = "none";
	eval(ctrlID + "_add_buttonLine.style.display = 'none'");
	eval(ctrlID + "_add_form.style.display = ''");		
	eval(ctrlID + "_Form1." + ctrlID + "_txtDenumire.value = '';");	
}

function ShowList()
{
	list_form.style.display = "";
	eval(ctrlID + "_add_buttonLine.style.display = ''");
	eval(ctrlID + "_add_form.style.display = 'none'");	

}

function SelectLine( id )
{
	eval(ctrlID + "_Form1." + ctrlID + "_txtStudiuID.value = id;");
	eval(ctrlID + "_Form1." + ctrlID + "_btnEdit.click();");
	
}


</script>
<form id="Form1" name="Form1" method="post" runat="server">
	<table class="tabBackground" cellSpacing="0" cellPadding="0" width="100%" border="0" id="Table1"
		height="200">
		<tr>
			<td><asp:literal id="litError" runat="server"></asp:literal></td>
		</tr>
		<tr id="list_form">
			<td align="center"><asp:table id="mainTable" runat="server"></asp:table></td>
		</tr>
		<TR id="add_form" runat="server">
			<TD align="center">
				<table cellSpacing="1" cellPadding="0" border="0" id="Table2">
					<tr>
						<td class="BigBlueBold" id="tdTitle" runat="server" align="center" colSpan="2" height="50">
							Introducere categorie studii</td>
					</tr>
					<tr>
						<td align="center" colSpan="2"><asp:table id="headerTable" runat="server"></asp:table></td>
					</tr>
					<tr>
						<td>
							<table class="tabBackground" cellSpacing="1" cellPadding="0" border="0" width="100%" id="Table3">
								<tr>
									<td class="NormalGreenBold">Denumire :&nbsp;</td>
									<td><asp:textbox id="txtDenumire" runat="server" MaxLength="100" CssClass="NormalEditBoxuri" size="50"></asp:textbox><SPAN class="CommentRedBold">*</SPAN>
										<asp:requiredfieldvalidator id="requiredDenumire" runat="server" ControlToValidate="txtDenumire" ErrorMessage="Completati denumirea categoriei de studii!"
											CssClass="AlertRedBold"><</asp:requiredfieldvalidator>
										<asp:regularexpressionvalidator id="regularDenumire" runat="server" CssClass="AlertRedBold" ErrorMessage="Nu puteti adauga caractere invalide pentru denumire: <>()';&quot;\"
											ControlToValidate="txtDenumire" ValidationExpression="^[^>|(|)|<|'|&quot;|;|\\]*$"><</asp:regularexpressionvalidator></td>
								</tr>
							</table>
							<asp:TextBox id="txtStudiuID" runat="server"></asp:TextBox></td>
					</tr>
					<TR>
						<td class="CommentRedBold" colSpan="2">* - Campuri obligatorii</td>
					</TR>
					<tr id="td_addLine" runat="server">
						<td align="center" colSpan="2" height="50"><asp:button id="btnAdd" onmouseover="MouseOverButton(this)" onmouseout="MouseOutButton(this)"
								runat="server" CssClass="ButtonStyle" Text="Salveaza studiu"></asp:button>&nbsp;
							<input class="ButtonStyle" onmouseover="MouseOverButton(this)" onclick="ShowList()" onmouseout="MouseOutButton(this)"
								type="button" value="  Inapoi  ">
							<asp:button id="btnEdit" runat="server" Text="Edit" CausesValidation="False"></asp:button></td>
					</tr>
					<TR>
						<TD align="center" colSpan="2"><asp:Label id="lblMessage" runat="server" CssClass="AlertRedBold"></asp:Label>&nbsp;</TD>
					</TR>
					<tr id="td_editLine" runat="server">
						<td align="center" colSpan="2" height="50"><asp:button id="btnModify" onmouseover="MouseOverButton(this)" onmouseout="MouseOutButton(this)"
								runat="server" CssClass="ButtonStyle" Text="Modifica studiu"></asp:button>&nbsp;
							<asp:button id="btnDelete" onmouseover="MouseOverButton(this)" onmouseout="MouseOutButton(this)"
								runat="server" CssClass="ButtonStyle" Text="Sterge studiu" CausesValidation="False"></asp:button>&nbsp;
							<asp:Button id="btnInapoi" onmouseover="MouseOverButton(this)" onmouseout="MouseOutButton(this)"
								runat="server" CssClass="ButtonStyle" Text="   Inapoi   " CausesValidation="False"></asp:Button></td>
					</tr>
					<TR>
						<TD align="center" colSpan="2"><asp:validationsummary id="ValidationSummary1" onmouseover="MouseOverButton(this)" onmouseout="MouseOutButton(this)"
								runat="server" CssClass="AlertRedBold" ShowMessageBox="True" ShowSummary="False"></asp:validationsummary>
						</TD>
					</TR>
				</table>
			</TD>
		</TR>
		<tr id="add_buttonLine" runat="server">
			<td align="center" height="50">
				<table cellSpacing="0" cellPadding="0" border="0" id="Table4">
					<tr>
						<td class="UnderlineBlackBold">Pentru adaugarea unei categorii de studii noi 
							apasati pe acest buton:
						</td>
						<td>&nbsp;<INPUT class="ButtonStyle" onmouseover="MouseOverButton(this)" onclick="ShowAddForm()"
								onmouseout="MouseOutButton(this)" type="button" value="Categorie studiu noua">&nbsp;</td>
					</tr>
				</table>
			</td>
		</tr>
	</table>
</form>
<script>
sp3FormIDfix();
</script>
