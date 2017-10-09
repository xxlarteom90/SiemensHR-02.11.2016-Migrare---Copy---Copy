<%@ Control Language="c#" AutoEventWireup="false" Codebehind="Admin_VariabileGlobale.ascx.cs" Inherits="SiemensHR.InterfataSalarii.Admin_VariabileGlobale" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<script>
	function SelectVariabilaGlobala( VariabilaGlobalaID )
	{
		eval("Form1." + ctrlID + "_txtVariabilaGlobalaID.value = VariabilaGlobalaID;");
		eval("Form1." + ctrlID + "_btnEdit.click();");
	}
	
</script>
<table cellSpacing="0" cellPadding="0" width="500" align="center" border="0">
	<tr>
		<td><IMG height="30" src="../images/1x1.gif"><asp:literal id="litError" runat="server"></asp:literal></td>
	</tr>
	<tr>
		<td class="NormalBlueBold" colSpan="2">Selectati&nbsp;perioada :
			<asp:dropdownlist id="drpPerioada" runat="server" Width="150px" AutoPostBack="True"></asp:dropdownlist></td>
	</tr>
	<tr>
		<td height="4"></td>
	</tr>
	<tr>
		<td class="tabBackground" align="center">
			<table id="list_form" cellSpacing="0" cellPadding="0" width="100%" border="0" runat="server">
				<tr>
					<td align="center"><asp:table id="mainTable" runat="server"></asp:table></td>
				</tr>
				<tr>
					<td align="center" height="50"><asp:button id="btnAdaugaVariabilaGlobala" onmouseover="MouseOverButton(this)" onmouseout="MouseOutButton(this)"
							runat="server" CssClass="ButtonStyle" Text="Adauga variabila" CausesValidation="False"></asp:button></td>
				</tr>
			</table>
		</td>
	</tr>
	<tr>
		<td>
			<table id="add_form" cellSpacing="1" cellPadding="0" width="760" border="0" runat="server">
				<tr>
					<td align="center"><asp:table id="add_header" runat="server"></asp:table></td>
				</tr>
				<tr>
					<td class="tabBackground">
						<table id="valoriTable" cellSpacing="0" cellPadding="0" width="100%" border="0" runat="server">
							<tr>
								<td class="GreenSeparator" colSpan="2"><IMG height="1" src="images/1x1.gif"></td>
							</tr>
							<TR>
								<TD class="NormalGreenBold">Tip variabila&nbsp;:</TD>
								<TD><SPAN class="CommentRedBold"><asp:dropdownlist id="drpTipVariabila" runat="server" Width="648px"></asp:dropdownlist><asp:requiredfieldvalidator id="requiredTipVariabila" runat="server" ErrorMessage="Completati tipul pentru variabila!"
											ControlToValidate="drpTipVariabila" CssClass="AlertRedBold"><</asp:requiredfieldvalidator></SPAN></TD>
							</TR>
							<tr>
									<td class="GreenSeparator" colSpan="2"><IMG height="1" src="images/1x1.gif"></td>
								</tr>
							<TR>
								<TD class="NormalGreenBold">Valoare&nbsp;:</TD>
								<TD><asp:textbox id="txtValoare" runat="server" Width="100px" CssClass="NumericEditBoxuri" MaxLength="7"
										size="50"></asp:textbox><asp:requiredfieldvalidator id="requiredValoare" runat="server" ErrorMessage="Trebuie sa completati valoarea variabilei!"
										ControlToValidate="txtValoare" CssClass="AlertRedBold"><</asp:requiredfieldvalidator><asp:rangevalidator id="rngVldValoare" runat="server" ErrorMessage="Trebuie sa completati corect valoarea variabilei!"
										ControlToValidate="txtValoare" Type="Double" MaximumValue="99999" MinimumValue="-99999" CssClass="AlertRedBold"><</asp:rangevalidator></TD>
							</TR>
						</table>
					</td>
				</tr>
				<TR>
					<td class="CommentRedBold" colSpan="2">* - Campuri obligatorii<asp:textbox id="txtVariabilaGlobalaID" runat="server"></asp:textbox></td>
				</TR>
				<TR>
					<TD align="center" colSpan="2" height="50"><asp:button id="btnSalveaza" onmouseover="MouseOverButton(this)" onmouseout="MouseOutButton(this)"
							runat="server" CssClass="ButtonStyle" Text="Salveaza"></asp:button>&nbsp;&nbsp;&nbsp;
						<asp:button id="btnInapoi" onmouseover="MouseOverButton(this)" onmouseout="MouseOutButton(this)"
							runat="server" CssClass="ButtonStyle" Text="Inapoi" CausesValidation="false"></asp:button>&nbsp;&nbsp;&nbsp;
						<asp:button id="btnEdit" runat="server" Text="Edit" CausesValidation="False"></asp:button></TD>
				</TR>
				<TR>
					<TD align="center" colSpan="2"><asp:validationsummary id="ValidationSummary1" runat="server" ShowSummary="False" ShowMessageBox="True"></asp:validationsummary></TD>
				</TR>
			</table>
		</td>
	</tr>
</table>
