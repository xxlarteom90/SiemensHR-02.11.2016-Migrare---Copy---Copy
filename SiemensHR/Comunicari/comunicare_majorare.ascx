<%@ Control Language="c#" AutoEventWireup="false" Codebehind="comunicare_majorare.ascx.cs" Inherits="SiemensHR.Comunicari.comunicare_majorare" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>
<LINK href="StyleHR.css" type="text/css" rel="stylesheet">
<STRONG>
	<P align="center">
		<TABLE id="Table1" cellSpacing="1" cellPadding="0" width="500" border="0">
			<tr>
				<td align="center">
					<asp:Table id="Table2" runat="server"></asp:Table>
				</td>
			</tr>
			<tr>
				<td class="tabBackground" align="left">
					<table border="0" width="100%" cellpadding="0" cellspacing="0">
						<tr>
							<TD class="NormalGreenBold">Data inregistrarii:</TD>
							<TD>
								<asp:textbox id="txtDataInregistrarii" style="CURSOR: hand" onclick="ShowCalendar(this,'')" runat="server"
									CssClass="NormalEditBoxuri" ReadOnly="True"></asp:textbox>
								<asp:Label id="lblDataInteg" runat="server" Font-Size="Smaller" ForeColor="Red">*</asp:Label>
								<asp:requiredfieldvalidator id="vldDataInreg" runat="server" ErrorMessage="Trebuie sa completati data inregistrarii!"
									ControlToValidate="txtDataInregistrarii"><</asp:requiredfieldvalidator>
							</TD>
						</tr>
						<tr>
							<td class="GreenSeparator" colSpan="2"><IMG height="1" src="images/1x1.gif"></td>
						</tr>
						<TR>
							<TD class="NormalGreenBold">Introduceti numarul comunicarii:&nbsp;</TD>
							<TD>
								<asp:TextBox CssClass="NormalEditBoxuri" id="txtNrCom" runat="server" MaxLength="9"></asp:TextBox>
								<asp:Label id="lblNrCom" runat="server" Font-Size="Smaller" ForeColor="Red">*</asp:Label>
								<asp:requiredfieldvalidator id="vldCmpObl" runat="server" ErrorMessage="Trebuie sa completati numarul comunicarii!"
									ControlToValidate="txtNrCom"><</asp:requiredfieldvalidator>
								<asp:RegularExpressionValidator id="vldNrCom" runat="server" Font-Size="Smaller" ErrorMessage="Numar comunicare invalid!"
									ValidationExpression="[0-9]+" ControlToValidate="txtNrCom"><</asp:RegularExpressionValidator></TD>
						</TR>
						<tr>
							<td class="GreenSeparator" colSpan="2"><IMG height="1" src="images/1x1.gif"></td>
						</tr>
						<TR>
							<TD class="NormalGreenBold">Manager general:</TD>
							<TD>
								<asp:TextBox id="txtManagerGeneral" runat="server" ReadOnly="True" CssClass="NormalEditBoxuri"
									Enabled="False" Width="265px"></asp:TextBox></TD>
						</TR>
						<tr>
							<td class="GreenSeparator" colSpan="2"><IMG height="1" src="images/1x1.gif"></td>
						</tr>
						<TR>
							<TD class="NormalGreenBold">Director economic:</TD>
							<TD>
								<asp:TextBox id="txtDirectorEconomic" runat="server" ReadOnly="True" CssClass="NormalEditBoxuri"
									Enabled="False" Width="265px"></asp:TextBox></TD>
						</TR>
						<tr>
							<td class="GreenSeparator" colSpan="2"><IMG height="1" src="images/1x1.gif"></td>
						</tr>
						<TR>
							<td style="HEIGHT: 12px" colSpan="2">
								<asp:Label id="lblCmpObl" runat="server" Font-Size="Smaller" ForeColor="Red">* - Campuri obligatorii</asp:Label>
							</td>
						</TR>
					</table>
				</td>
			</tr>
			<tr>
				<td align="center" height="50"><asp:Button id="btnGenerati" onmouseover="MouseOverButton(this)" onmouseout="MouseOutButton(this)"
						CssClass="ButtonStyle" runat="server" Text="   Generati   "></asp:Button></td>
			</tr>
			<tr>
				<td align="left" height="50"><asp:Label cssclass="NormalGreenBold" id="lblEroare" runat="server"></asp:Label>
					<asp:ValidationSummary id="sumarValidare" runat="server" ShowMessageBox="True" ShowSummary="False"></asp:ValidationSummary></td>
			</tr>
		</TABLE>
	</P>
</STRONG>
