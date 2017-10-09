<%@ Control Language="c#" AutoEventWireup="false" Codebehind="AdminJudete.ascx.cs" Inherits="SiemensHR.Administrare.AdminJudete" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>
<script>
function sp3FormIDfix()
{
document.forms[0].id=ctrlID + "_Form1";

document.getElementById(requiredDenumire).innerText = '';
document.getElementById(requiredSimbol).innerText = '';
}
function ShowAddForm()
{
	list_form.style.display = "none";
	eval(ctrlID + "_add_buttonLine.style.display = 'none'");
	eval(ctrlID + "_add_form.style.display = ''");		
	eval(ctrlID + "_Form1." + ctrlID + "_txtNume.value = '';");	
	eval(ctrlID + "_Form1." + ctrlID + "_txtSimbol.value = '';");
	eval(ctrlID + "_Form1." + ctrlID + "_txtCod.value = '';");

}

function ShowList()
{
	list_form.style.display = "";
	eval(ctrlID + "_add_buttonLine.style.display = ''");
	eval(ctrlID + "_add_form.style.display = 'none'");	

}

function SelectLine( id )
{
	eval(ctrlID + "_Form1." + ctrlID + "_txtJudetID.value = id;");
	eval(ctrlID + "_Form1." + ctrlID + "_btnEdit.click();");
	
}
</script>
<form id="Form1" name="Form1" method="post" runat="server">
	<table class="tabBackground" id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
		<tr>
			<td><asp:literal id="litError" runat="server"></asp:literal></td>
		</tr>
		<tr id="list_form">
			<td align="center"><asp:table id="mainTable" runat="server"></asp:table>
				<asp:datagrid id="listDataGrid" runat="server" Width="400px" PageSize="30" AllowPaging="True"
					AutoGenerateColumns="False" GridLines="None" BorderColor="LightSeaGreen" CellSpacing="1" BorderWidth="1px">
					<ItemStyle CssClass="UnderlineNormalBlack"></ItemStyle>
					<HeaderStyle CssClass="HeaderBlueBold"></HeaderStyle>
					<Columns>
						<asp:BoundColumn DataField="JudetID" HeaderText="JudetID"></asp:BoundColumn>
						<asp:BoundColumn DataField="Nume" HeaderText="Denumire"></asp:BoundColumn>
						<asp:BoundColumn DataField="Simbol" HeaderText="Simbol"></asp:BoundColumn>
						<asp:BoundColumn DataField="Cod" HeaderText="Cod"></asp:BoundColumn>
						<asp:BoundColumn DataField="NumeTara" HeaderText="Tara"></asp:BoundColumn>
					</Columns>
					<PagerStyle Mode="NumericPages"></PagerStyle>
				</asp:datagrid></td>
		</tr>
		<TR id="add_form" runat="server">
			<TD align="center">
				<table id="Table2" cellSpacing="1" cellPadding="0" border="0">
					<tr>
						<td class="BigBlueBold" id="tdTitle" align="center" colSpan="2" height="50" runat="server">
							Adaugare judet</td>
					</tr>
					<tr>
						<td align="center" colSpan="2"><asp:table id="headerTable" runat="server"></asp:table></td>
					</tr>
					<tr>
						<td>
							<table class="tabBackground" id="Table3" cellSpacing="1" cellPadding="0" width="100%" border="0">
								<tr>
									<td class="NormalGreenBold" style="WIDTH: 99px; HEIGHT: 18px">Tara :</td>
									<td style="HEIGHT: 18px"><asp:dropdownlist id="ddlTara" runat="server" Width="240px" CssClass="NormalEditBoxuri"></asp:dropdownlist><SPAN class="CommentRedBold">*</SPAN>
									</td>
								</tr>
								<tr>
									<td class="GreenSeparator" colSpan="2"><IMG height="1" src="images/1x1.gif"></td>
								</tr>
								<tr>
									<td class="NormalGreenBold" style="WIDTH: 100px">Denumire :</td>
									<td style="HEIGHT: 18px"><asp:textbox id="txtNume" runat="server" Width="240px" size="50" CssClass="AreaStyle" MaxLength="50"></asp:textbox><SPAN class="CommentRedBold">*</SPAN>
										<asp:requiredfieldvalidator id="requiredDenumire" runat="server" ErrorMessage="Completati denumirea judetului !"
											ControlToValidate="txtNume" CssClass="AlertRedBold"><</asp:requiredfieldvalidator>
										<asp:RegularExpressionValidator id="regExprVldDenumire" runat="server" CssClass="AlertRedBold" ControlToValidate="txtNume"
											ErrorMessage="Denumirea nu poate sa contina caractere invalide: <>()';&quot;\ " ValidationExpression="^[^>|(|)|<|'|&quot;|;|\\]*$"><</asp:RegularExpressionValidator></td>
								</tr>
								<tr>
									<td class="GreenSeparator" colSpan="2"><IMG height="1" src="images/1x1.gif"></td>
								</tr>
								<tr>
									<td class="NormalGreenBold" style="WIDTH: 100px">Simbol:</td>
									<td style="HEIGHT: 18px"><asp:textbox id="txtSimbol" runat="server" Width="240px" CssClass="AreaStyle" MaxLength="2" Columns="40"
											Rows="4"></asp:textbox><SPAN class="CommentRedBold">*</SPAN>
										<asp:requiredfieldvalidator id="requiredSimbol" runat="server" ErrorMessage="Completati simbolul judetului !"
											ControlToValidate="txtSimbol" CssClass="AlertRedBold"><</asp:requiredfieldvalidator>
										<asp:RegularExpressionValidator id="RegularExpressionValidator1" runat="server" CssClass="AlertRedBold" ControlToValidate="txtSimbol"
											ErrorMessage="Simbolul nu poate sa contina caractere invalide: <>()';&quot;\ " ValidationExpression="^[^>|(|)|<|'|&quot;|;|\\]*$"><</asp:RegularExpressionValidator><SPAN class="CommentRedBold"></SPAN></td>
								</tr>
								<tr>
									<td class="GreenSeparator" colSpan="2"><IMG height="1" src="images/1x1.gif"></td>
								</tr>
								<tr>
									<td class="NormalGreenBold" style="WIDTH: 100px">Cod (A12):</td>
									<td style="HEIGHT: 18px"><asp:textbox id="txtCod" runat="server" Width="240px" CssClass="AreaStyle" MaxLength="5" Columns="40"
											Rows="4"></asp:textbox><SPAN class="CommentRedBold"></SPAN></td>
								</tr>
							</table>
							<asp:textbox id="txtJudetID" runat="server"></asp:textbox></td>
					</tr>
					<TR>
						<td class="CommentRedBold" colSpan="2">* - Campuri obligatorii</td>
					</TR>
					<tr id="td_addLine" runat="server">
						<td align="center" colSpan="2" height="50"><asp:button id="btnAdd" onmouseover="MouseOverButton(this)" onmouseout="MouseOutButton(this)"
								runat="server" CssClass="ButtonStyle" Text="Salveaza judet"></asp:button>&nbsp;
							<input class="ButtonStyle" onmouseover="MouseOverButton(this)" onclick="ShowList()" onmouseout="MouseOutButton(this)"
								type="button" value="  Inapoi  ">
							<asp:button id="btnEdit" runat="server" Text="Edit" CausesValidation="False"></asp:button></td>
					</tr>
					<TR>
						<TD align="center" colSpan="2"><asp:label id="lblMessage" runat="server" CssClass="AlertRedBold"></asp:label>&nbsp;</TD>
					</TR>
					<tr id="td_editLine" runat="server">
						<td align="center" colSpan="2" height="50"><asp:button id="btnModify" onmouseover="MouseOverButton(this)" onmouseout="MouseOutButton(this)"
								runat="server" CssClass="ButtonStyle" Text="Modifica judet"></asp:button>&nbsp;
							<asp:button id="btnDelete" onmouseover="MouseOverButton(this)" onmouseout="MouseOutButton(this)"
								runat="server" CssClass="ButtonStyle" Text="Sterge judet" CausesValidation="False"></asp:button>&nbsp;
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
						<td class="UnderlineBlackBold">Pentru adaugarea unui nou judet &nbsp;apasati pe 
							acest buton:
						</td>
						<td>&nbsp;<INPUT class="ButtonStyle" onmouseover="MouseOverButton(this)" onclick="ShowAddForm()"
								onmouseout="MouseOutButton(this)" type="button" value="Judet nou">&nbsp;</td>
					</tr>
				</table>
			</td>
		</tr>
	</table>
</form>
<script>

sp3FormIDfix();
</script>
