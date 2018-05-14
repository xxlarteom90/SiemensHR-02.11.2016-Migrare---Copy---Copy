<%@ Control Language="c#" AutoEventWireup="false" Codebehind="adeverintaMedicDeFamilie.ascx.cs" Inherits="SiemensHR.Comunicari.adeverintaMedicDeFamilie" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>
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
							<TD class="NormalGreenBold" style="WIDTH: 242px">Data inregistrarii:</TD>
							<TD>
								<asp:textbox id="txtDataInregistrarii" style="CURSOR: hand" onclick="ShowCalendar(this,'')" runat="server"
									CssClass="NormalEditBoxuri" ReadOnly="False"></asp:textbox>
								<asp:Label id="lblDataInteg" runat="server" Font-Size="Smaller" ForeColor="Red">*</asp:Label>
								<asp:RequiredFieldValidator id="vldDataInreg" runat="server" ControlToValidate="txtDataInregistrarii" ErrorMessage="Trebuie sa completati data inregistrarii!"><</asp:RequiredFieldValidator>
							</TD>
						</tr>
						<tr>
							<td class="GreenSeparator" colSpan="2"><IMG height="1" src="images/1x1.gif"></td>
						</tr>
						<TR>
							<TD class="NormalGreenBold" style="WIDTH: 242px">Introduceti numarul 
								adeverintei:&nbsp;</TD>
							<TD>
								<asp:TextBox CssClass="NormalEditBoxuri" id="txtNrCom" runat="server" MaxLength="9"></asp:TextBox>
								<asp:Label id="lblNrCom" runat="server" ForeColor="Red" Font-Size="Smaller">*</asp:Label>
								<asp:RequiredFieldValidator id="vldNrComunicare" runat="server" ErrorMessage="Trebuie sa completati numarul adeverintei!"
									ControlToValidate="txtNrCom"><</asp:RequiredFieldValidator>
								<asp:RegularExpressionValidator id="vldNrComRegExp" runat="server" ErrorMessage="Numar invalid!" ValidationExpression="[0-9]+"
									Font-Size="Smaller" ControlToValidate="txtNrCom"><</asp:RegularExpressionValidator>
							</TD>
						</TR>
						<tr>
							<td class="GreenSeparator" colSpan="2"><IMG height="1" src="images/1x1.gif"></td>
						</tr>
						<TR>
							<TD class="NormalGreenBold">Manager general:</TD>
							<TD>
								<asp:TextBox id="txtManagerGeneral" runat="server" ReadOnly="True" CssClass="NormalEditBoxuri"
									Width="264px" Enabled="False"></asp:TextBox></TD>
						</TR>
						<tr>
							<td class="GreenSeparator" colSpan="2"><IMG height="1" src="images/1x1.gif"></td>
						</tr>
						<TR>
							<TD class="NormalGreenBold">Director economic:</TD>
							<TD>
								<asp:TextBox id="txtDirectorEconomic" runat="server" ReadOnly="True" CssClass="NormalEditBoxuri"
									Width="265px" Enabled="False"></asp:TextBox></TD>
						</TR>
						<tr>
							<td class="GreenSeparator" colSpan="2"><IMG height="1" src="images/1x1.gif"></td>
						</tr>
						<TR>
							<TD class="NormalGreenBold">Inspector resurse umane:</TD>
							<TD><asp:dropdownlist id="drpInspectorResurseUmane" runat="server" Width="271px"></asp:dropdownlist></TD>
						</TR>
						<tr>
							<td class="GreenSeparator" colSpan="2"><IMG height="1" src="images/1x1.gif"></td>
						</tr>
					</table>
					<asp:Label id="lblCmpObl" runat="server" ForeColor="Red" Font-Size="Smaller">* - Campuri obligatorii</asp:Label>
				</td>
			</tr>
			<tr>
				<td align="center" height="50"><asp:Button id="btnGenerati" onmouseover="MouseOverButton(this)" onmouseout="MouseOutButton(this)"
						CssClass="ButtonStyle" runat="server" Text="   Generati   "></asp:Button></td>
			</tr>
			<tr>
				<td align="left" height="50"><asp:Label cssclass="NormalGreenBold" id="lblEroare" runat="server"></asp:Label>
					<asp:validationsummary id="sumarValidare" runat="server" ShowMessageBox="True" ShowSummary="False"></asp:validationsummary></td>
			</tr>
		</TABLE>
	</P>
</STRONG>
