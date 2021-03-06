<%@ Control Language="c#" AutoEventWireup="false" Codebehind="comunicare_indexare.ascx.cs" Inherits="SiemensHR.Comunicari.comunicare_indexare" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>
<LINK href="StyleHR.css" type="text/css" rel="stylesheet">
<STRONG>
	<P align="center">
		<TABLE id="Table1" cellSpacing="1" cellPadding="0" width="500" border="0">
			<tr>
				<td align="center"><asp:table id="Table2" runat="server"></asp:table></td>
			</tr>
			<tr>
				<td class="tabBackground" align="left">
					<table cellSpacing="0" cellPadding="0" width="100%" border="0">
						<tr>
							<TD class="NormalGreenBold">Data inregistrarii:</TD>
							<TD><asp:textbox id="txtDataInregistrarii" style="CURSOR: hand" onclick="ShowCalendar(this,'')" runat="server"
									ReadOnly="False" CssClass="NormalEditBoxuri"></asp:textbox><asp:label id="lblDataInteg" runat="server" ForeColor="Red" Font-Size="Smaller">*</asp:label><asp:requiredfieldvalidator id="vldDataInreg" runat="server" ErrorMessage="Trebuie sa completati data inregistrarii!"
									ControlToValidate="txtDataInregistrarii"><</asp:requiredfieldvalidator></TD>
						</tr>
						<tr>
							<td class="GreenSeparator" colSpan="2"><IMG height="1" src="images/1x1.gif"></td>
						</tr>
						<TR>
							<TD class="NormalGreenBold">Introduceti numarul comunicarii:&nbsp;</TD>
							<TD><asp:textbox id="txtNrCom" runat="server" CssClass="NormalEditBoxuri" MaxLength="9"></asp:textbox><asp:label id="lblCmpObl" runat="server" ForeColor="Red" Font-Size="Smaller">*</asp:label><asp:requiredfieldvalidator id="vldCmpObl" runat="server" ErrorMessage="Trebuie sa completati numarul comunicarii!"
									ControlToValidate="txtNrCom"><</asp:requiredfieldvalidator><asp:regularexpressionvalidator id="vldNrCom" runat="server" Font-Size="Smaller" ErrorMessage="Numar invalid!" ControlToValidate="txtNrCom"
									ValidationExpression="[0-9]+"><</asp:regularexpressionvalidator></TD>
						</TR>
						<tr>
							<td class="GreenSeparator" colSpan="2"><IMG height="1" src="images/1x1.gif"></td>
						</tr>
						<TR>
							<TD class="NormalGreenBold">Manager general:</TD>
							<TD>
								<asp:TextBox id="txtManagerGeneral" runat="server" CssClass="NormalEditBoxuri" ReadOnly="True"
									Enabled="False" Width="265px"></asp:TextBox></TD>
						</TR>
						<tr>
							<td class="GreenSeparator" colSpan="2"><IMG height="1" src="images/1x1.gif"></td>
						</tr>
						<TR>
							<TD class="NormalGreenBold">Director economic:</TD>
							<TD>
								<asp:TextBox id="txtDirectorEconomic" runat="server" CssClass="NormalEditBoxuri" ReadOnly="True"
									Enabled="False" Width="265px"></asp:TextBox></TD>
						</TR>
						<tr>
							<td class="GreenSeparator" colSpan="2"><IMG height="1" src="images/1x1.gif"></td>
						</tr>
					</table>
					<asp:label id="lblCmpOblig" runat="server" ForeColor="Red" Font-Size="Smaller">* - Camp obligatoriu</asp:label></td>
			</tr>
			<tr>
				<td align="center" height="50"><asp:button id="btnGenerati" onmouseover="MouseOverButton(this)" onmouseout="MouseOutButton(this)"
						runat="server" CssClass="ButtonStyle" Text="   Generati   "></asp:button></td>
			</tr>
			<tr>
				<td align="left" height="50">
					<P><asp:label id="lblEroare" runat="server" cssclass="NormalGreenBold"></asp:label></P>
					<P><asp:validationsummary id="sumarValidare" runat="server" ShowMessageBox="True" ShowSummary="False"></asp:validationsummary></P>
				</td>
			</tr>
		</TABLE>
	</P>
</STRONG>
