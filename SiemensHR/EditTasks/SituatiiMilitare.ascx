<%@ Control Language="c#" AutoEventWireup="false" Codebehind="SituatiiMilitare.ascx.cs" Inherits="SiemensHR.EditTasks.SituatiiMilitare" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>
<table cellSpacing="1" cellPadding="0" align="center" border="0">
	<tr>
		<td><asp:literal id="litError" runat="server"></asp:literal></td>
	</tr>
	<tr>
		<td><IMG height="10" src="../images/1x1.gif"></td>
	</tr>
	<tr>
		<td>
			<asp:Table id="tableTabs" runat="server"></asp:Table></td>
	<tr>
		<td align="center" class="tabBackground">
			<TABLE cellSpacing="1" cellPadding="0" width="600" align="center" border="0">
				<TR>
					<TD class="NormalGreenBold">In evidenta CMJ:</TD>
					<TD>
						<asp:textbox id="txtEvidentaCMJ" runat="server" Width="200px" MaxLength="100" CssClass="NormalEditBoxuri"></asp:textbox><span class="CommentRedBold">*</span>
						<asp:requiredfieldvalidator id="requiredCMJ" runat="server" ControlToValidate="txtEvidentaCMJ" ErrorMessage="Completati evidenta CMJ!"
							CssClass="AlertRedBold"><</asp:requiredfieldvalidator>
						<asp:RegularExpressionValidator id="regularEvidenta" runat="server" CssClass="AlertRedBold" ErrorMessage="Evidenta CMJ nu poate sa contina caractere invalide: <>()';&quot;\ "
							ControlToValidate="txtEvidentaCMJ" ValidationExpression="^[^>|(|)|<|'|&quot;|;|\\]*$"><</asp:RegularExpressionValidator></TD>
				</TR>
				<tr>
					<td class="GreenSeparator" colSpan="4"><IMG height="1" src="../images/1x1.gif"></td>
				</tr>
				<TR>
					<TD class="NormalGreenBold">Data intrarii in evidenta:</TD>
					<TD><asp:textbox id="txtDataIntrareEvidenta" style="CURSOR: hand; TEXT-ALIGN: center" onclick="ShowCalendar(this,'')"
							runat="server" CssClass="NormalEditBoxuri" Width="100px" ReadOnly="False"></asp:textbox><span class="CommentRedBold">*</span>
						<asp:RequiredFieldValidator id="requiredProgramLucru" runat="server" ErrorMessage="Completati data intrari in evidenta!"
							ControlToValidate="txtDataIntrareEvidenta" CssClass="AlertRedBold"><</asp:RequiredFieldValidator></TD>
				</TR>
				<tr>
					<td class="GreenSeparator" colSpan="4"><IMG height="1" src="../images/1x1.gif"></td>
				</tr>
				<TR>
					<TD class="NormalGreenBold">Gradul:</TD>
					<TD><asp:textbox id="txtGradul" runat="server" Width="200px" MaxLength="50" CssClass="NormalEditBoxuri"></asp:textbox>
						<asp:RegularExpressionValidator id="regularGrad" runat="server" CssClass="AlertRedBold" ErrorMessage="Gradul nu poate sa contina caractere invalide: <>()';&quot;\ "
							ControlToValidate="txtGradul" ValidationExpression="^[^>|(|)|<|'|&quot;|;|\\]*$"><</asp:RegularExpressionValidator></TD>
				</TR>
				<tr>
					<td class="GreenSeparator" colSpan="4"><IMG height="1" src="../images/1x1.gif"></td>
				</tr>
				<TR>
					<TD class="NormalGreenBold">Serie livret:</TD>
					<TD><asp:textbox id="txtSerieLivret" runat="server" Width="100px" MaxLength="5" CssClass="NormalEditBoxuri"></asp:textbox>
						<asp:RegularExpressionValidator id="regularSerie" runat="server" CssClass="AlertRedBold" ErrorMessage="Seria livretului nu poate sa contina caractere invalide: <>()';&quot;\ "
							ControlToValidate="txtSerieLivret" ValidationExpression="^[^>|(|)|<|'|&quot;|;|\\]*$"><</asp:RegularExpressionValidator></TD>
				</TR>
				<tr>
					<td class="GreenSeparator" colSpan="4"><IMG height="1" src="../images/1x1.gif"></td>
				</tr>
				<TR>
					<TD class="NormalGreenBold">Numar livret:</TD>
					<TD><asp:textbox id="txtNumarLivret" runat="server" Width="100px" CssClass="NormalEditBoxuri" MaxLength="10"></asp:textbox>
						<asp:RegularExpressionValidator id="regularNumar" runat="server" CssClass="AlertRedBold" ErrorMessage="Numarul livretului nu poate sa contina caractere invalide: <>()';&quot;\ "
							ControlToValidate="txtNumarLivret" ValidationExpression="^[^>|(|)|<|'|&quot;|;|\\]*$"><</asp:RegularExpressionValidator></TD>
				</TR>
				<tr>
					<td class="GreenSeparator" colSpan="4"><IMG height="1" src="../images/1x1.gif"></td>
				</tr>
				<TR>
					<TD class="NormalGreenBold">Specialitati militare:</TD>
					<TD><asp:textbox id="txtSpecialitatiMilitare" runat="server" Width="200px" MaxLength="100" CssClass="NormalEditBoxuri"></asp:textbox>
						<asp:RegularExpressionValidator id="regularSpecialitati" runat="server" CssClass="AlertRedBold" ErrorMessage="Specialitatile militare nu pot sa contina caractere invalide: <>()';&quot;\ "
							ControlToValidate="txtSpecialitatiMilitare" ValidationExpression="^[^>|(|)|<|'|&quot;|;|\\]*$"><</asp:RegularExpressionValidator></TD>
				</TR>
			</TABLE>
		</td>
	</tr>
	<tr>
		<td class="CommentRedBold">* - Campuri obligatorii</td>
	</tr>
	<tr>
		<td align="center" height="50"><asp:button id="butSaveAngajat" onmouseover="MouseOverButton(this)" onmouseout="MouseOutButton(this)"
				runat="server" cssclass="ButtonStyle" Text="Salveaza date"></asp:button></td>
	</tr>
	<TR>
		<TD align="center" height="50"><asp:validationsummary id="ValidationSummary1" runat="server" ShowSummary="False" ShowMessageBox="True"
				CssClass="AlertRedBold"></asp:validationsummary></TD>
	</TR>
</table>
