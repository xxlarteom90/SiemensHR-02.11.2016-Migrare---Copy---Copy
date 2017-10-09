<%@ Control Language="c#" AutoEventWireup="false" Codebehind="fisa_postului.ascx.cs" Inherits="SiemensHR.Comunicari.fisa_postului" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>
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
							<TD class="NormalGreenBold">Data intocmirii:</TD>
							<TD>
								<asp:textbox id="txtDataInregistrarii" style="CURSOR: hand" onclick="if (TipUtilizator == 'Recrutor') { ShowCalendar(this,'../'); } else { ShowCalendar(this,''); }"
									runat="server" CssClass="NormalEditBoxuri" ReadOnly="True"></asp:textbox>
								<asp:Label id="lblDataInteg" runat="server" Font-Size="Smaller" ForeColor="Red">*</asp:Label>
								<asp:RequiredFieldValidator id="vldDataInreg" runat="server" ControlToValidate="txtDataInregistrarii" ErrorMessage="Trebuie sa completati data intocmirii!"><</asp:RequiredFieldValidator>
							</TD>
						</tr>
						<tr>
							<td class="GreenSeparator" colSpan="2"><IMG height="1" src="images/1x1.gif"></td>
						</tr>
						<TR>
							<TD class="NormalGreenBold">Manager general:</TD>
							<TD>
								<asp:TextBox id="txtManagerGeneral" runat="server" ReadOnly="True" CssClass="NormalEditBoxuri"
									Width="293px" Enabled="False"></asp:TextBox></TD>
						</TR>
						<tr>
							<td class="GreenSeparator" colSpan="2"><IMG height="1" src="images/1x1.gif"></td>
						</tr>
						<TR>
							<TD class="NormalGreenBold">Manager HR:</TD>
							<TD>
								<asp:TextBox id="txtManagerHR" runat="server" ReadOnly="True" CssClass="NormalEditBoxuri" Width="292px"
									Enabled="False"></asp:TextBox></TD>
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
					<asp:validationsummary id="sumarValidare" runat="server" ShowMessageBox="True" ShowSummary="False"></asp:validationsummary></td>
			</tr>
		</TABLE>
	</P>
</STRONG>
