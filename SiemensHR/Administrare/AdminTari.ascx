<%@ Control Language="c#" AutoEventWireup="false" Codebehind="AdminTari.ascx.cs" Inherits="SiemensHR.Administrare.AdminTari" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>
<script>
function sp3FormIDfix()
{
document.forms[0].id=ctrlID + "_Form1";

document.getElementById(requiredDenumire).innerText = '';
document.getElementById(regularDenumire).innerText = '';
document.getElementById(requiredSimbol).innerText = '';
document.getElementById(requiredNationalitate).innerText = '';
}
function ShowAddForm()
{
	list_form.style.display = "none";
	eval(ctrlID + "_add_buttonLine.style.display = 'none'");
	eval(ctrlID + "_add_form.style.display = ''");		
	eval(ctrlID + "_Form1." + ctrlID + "_txtNume.value = '';");	
	eval(ctrlID + "_Form1." + ctrlID + "_txtSimbol.value = '';");		
	eval(ctrlID + "_Form1." + ctrlID + "_txtNationalitate.value = '';");	
	eval(ctrlID + "_Form1." + ctrlID + "_chkTaraBaza.checked = false;");
}

function ShowList()
{
	list_form.style.display = "";
	eval(ctrlID + "_add_buttonLine.style.display = ''");
	eval(ctrlID + "_add_form.style.display = 'none'");	
}

function SelectLine( id )
{
	eval(ctrlID + "_Form1." + ctrlID + "_txtTaraID.value = id;");
	eval(ctrlID + "_Form1." + ctrlID + "_btnEdit.click();");	
}

</script>
<form id="Form1" name="Form1" method="post" runat="server">
	<table class="tabBackground" id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
		<tr>
			<td><asp:literal id="litError" runat="server"></asp:literal></td>
		</tr>
		<tr id="list_form">
			<td align="center">
				<P><asp:table id="mainTable" runat="server"></asp:table><asp:datagrid id="listDataGrid" runat="server" BorderWidth="1px" CellSpacing="1" BorderColor="LightSeaGreen"
						GridLines="None" AutoGenerateColumns="False" AllowPaging="True" PageSize="30" Width="390px">
						<ItemStyle CssClass="UnderlineNormalBlack"></ItemStyle>
						<HeaderStyle CssClass="HeaderBlueBold"></HeaderStyle>
						<Columns>
							<asp:BoundColumn DataField="TaraID" HeaderText="TaraID"></asp:BoundColumn>
							<asp:BoundColumn DataField="NumeTara" HeaderText="Denumire"></asp:BoundColumn>
							<asp:BoundColumn DataField="Simbol" HeaderText="Simbol"></asp:BoundColumn>
							<asp:BoundColumn DataField="Nationalitate" HeaderText="Nationalitate"></asp:BoundColumn>
						</Columns>
						<PagerStyle Mode="NumericPages"></PagerStyle>
					</asp:datagrid></P>
			</td>
		</tr>
		<TR id="add_form" runat="server">
			<TD align="center">
				<table id="Table2" cellSpacing="1" cellPadding="0" border="0">
					<tr>
						<td class="BigBlueBold" id="tdTitle" align="center" colSpan="2" height="50" runat="server">Adaugare 
							tara</td>
					</tr>
					<tr>
						<td align="center" colSpan="2"><asp:table id="headerTable" runat="server"></asp:table></td>
					</tr>
					<TR>
						<td>
							<table class="tabBackground" id="Table3" cellSpacing="1" cellPadding="0" width="100%" border="0">
								<TBODY>
									<tr>
										<td class="NormalGreenBold">Denumire :</td>
										<td><asp:textbox id="txtNume" runat="server" Width="300px" MaxLength="100" CssClass="NormalEditBoxuri"
												size="50"></asp:textbox><SPAN class="CommentRedBold">*</SPAN>
											<asp:requiredfieldvalidator id="requiredDenumire" runat="server" CssClass="AlertRedBold" ControlToValidate="txtNume"
												ErrorMessage="Completati denumirea tarii !"><</asp:requiredfieldvalidator><asp:regularexpressionvalidator id="regularDenumire" runat="server" CssClass="AlertRedBold" ControlToValidate="txtNume"
												ErrorMessage="Nu puteti adauga caractere invalide pentru denumire: <>()';&quot;\" ValidationExpression="^[^>|(|)|<|'|&quot;|;|\\]*$"><</asp:regularexpressionvalidator></td>
									</tr>
									<tr>
										<td class="GreenSeparator" colSpan="2"><IMG height="1" src="images/1x1.gif"></td>
									</tr>
									<tr>
										<td class="NormalGreenBold">Simbol:</td>
										<td><asp:textbox id="txtSimbol" runat="server" Width="48px" MaxLength="2" CssClass="AreaStyle" Rows="4"
												Columns="40"></asp:textbox><SPAN class="CommentRedBold">*</SPAN>
											<asp:requiredfieldvalidator id="requiredSimbol" runat="server" CssClass="AlertRedBold" ControlToValidate="txtSimbol"
												ErrorMessage="Completati simbolul tarii !"><</asp:requiredfieldvalidator><SPAN class="CommentRedBold"></SPAN></td>
									</tr>
									<tr>
										<td class="GreenSeparator" colSpan="2"><IMG height="1" src="images/1x1.gif"></td>
									</tr>
									<tr>
										<td class="NormalGreenBold">Nationalitate:</td>
										<td><asp:textbox id="txtNationalitate" runat="server" Width="300px" CssClass="AreaStyle"></asp:textbox><SPAN class="CommentRedBold">*</SPAN>
											<asp:requiredfieldvalidator id="requiredNationalitate" runat="server" CssClass="AlertRedBold" ControlToValidate="txtNationalitate"
												ErrorMessage="Completati campul nationalitate!"><</asp:requiredfieldvalidator></td>
									</tr>
									<tr>
										<td class="GreenSeparator" colSpan="2"><IMG height="1" src="images/1x1.gif"></td>
									</tr>
									<tr>
										<td class="NormalGreenBold">Tara de baza:</td>
										<td><asp:checkbox id="chkTaraBaza" Runat="server" Checked="False"></asp:checkbox></td>
									</tr>
					</TR>
				</table>
				<asp:textbox id="txtTaraID" runat="server"></asp:textbox></TD>
		</TR>
		<TR>
			<td class="CommentRedBold" colSpan="2">* - Campuri obligatorii</td>
		</TR>
		<tr id="td_addLine" runat="server">
			<td align="center" colSpan="2" height="50"><asp:button id="btnAdd" onmouseover="MouseOverButton(this)" onmouseout="MouseOutButton(this)"
					runat="server" CssClass="ButtonStyle" Text="Salveaza tara"></asp:button>&nbsp;
				<input class="ButtonStyle" onmouseover="MouseOverButton(this)" onclick="ShowList()" onmouseout="MouseOutButton(this)"
					type="button" value="  Inapoi  ">
				<asp:button id="btnEdit" runat="server" Text="Edit" CausesValidation="False"></asp:button></td>
		</tr>
		<TR>
			<TD align="center" colSpan="2"><asp:label id="lblMessage" runat="server" CssClass="AlertRedBold"></asp:label>&nbsp;</TD>
		</TR>
		<tr id="td_editLine" runat="server">
			<td align="center" colSpan="2" height="50"><asp:button id="btnModify" onmouseover="MouseOverButton(this)" onmouseout="MouseOutButton(this)"
					runat="server" CssClass="ButtonStyle" Text="Modifica tara"></asp:button>&nbsp;
				<asp:button id="btnDelete" onmouseover="MouseOverButton(this)" onmouseout="MouseOutButton(this)"
					runat="server" CssClass="ButtonStyle" Text="Sterge tara" CausesValidation="False"></asp:button>&nbsp;
				<asp:button id="btnInapoi" onmouseover="MouseOverButton(this)" onmouseout="MouseOutButton(this)"
					runat="server" CssClass="ButtonStyle" Text="   Inapoi   " CausesValidation="False"></asp:button></td>
		</tr>
		<TR>
			<TD align="center" colSpan="2"><asp:validationsummary id="ValidationSummary1" onmouseover="MouseOverButton(this)" onmouseout="MouseOutButton(this)"
					runat="server" CssClass="AlertRedBold" ShowMessageBox="True" ShowSummary="False"></asp:validationsummary></TD>
		</TR>
	</table>
	</TD></TR>
	<tr id="add_buttonLine" height="50" runat="server">
		<td align="center">
			<table id="Table4" cellSpacing="0" cellPadding="0" border="0">
				<tr>
					<td class="UnderlineBlackBold">Pentru adaugarea unei noi tari &nbsp;apasati pe 
						acest buton:
					</td>
					<td>&nbsp;<INPUT class="ButtonStyle" onmouseover="MouseOverButton(this)" onclick="ShowAddForm()"
							onmouseout="MouseOutButton(this)" type="button" value="Tara noua">&nbsp;</td>
				</tr>
			</table>
		</td>
	</tr>
	</TBODY></TABLE></form>
<script>
sp3FormIDfix();
</script>
