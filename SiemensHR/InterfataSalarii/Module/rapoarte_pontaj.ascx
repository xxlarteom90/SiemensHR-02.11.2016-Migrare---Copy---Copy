<%@ Register TagPrefix="cc1" Namespace="ReportingServices" Assembly="ReportViewer" %>
<%@ Control Language="c#" AutoEventWireup="false" Codebehind="rapoarte_pontaj.ascx.cs" Inherits="SiemensHR.InterfataSalarii.Module.rapoarte_Pontaj" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>
<table id="main" height="100%" width="100%">
	<tr height="20%" width="100%">
		<td align="center" colSpan="2" style="HEIGHT: 20.08%">
			<table>
				<tr>
					<td class="NormalGreenBold">Data platii:
					</td>
					<td><asp:textbox id="txtDataPlatii" runat="server" Width="210px" CssClass="NormalEditBoxuri" MaxLength="10"></asp:textbox><SPAN class="CommentRedBold">*
							<asp:requiredfieldvalidator id="requiredData" CssClass="AlertRedBold" runat="server" ControlToValidate="txtDataPlatii"
								ErrorMessage="Completati data platii!"><</asp:requiredfieldvalidator></SPAN>
						<asp:regularexpressionvalidator id="vldData" runat="server" ErrorMessage="Trebuie sa completati corect data platii!"
							ValidationExpression="(0[1-9]|[12][0-9]|3[01])[/.](0[1-9]|1[012])[/.](19|20)\d\d" ControlToValidate="txtDataPlatii"
							CssClass="AlertRedBold"><</asp:regularexpressionvalidator></td>
				</tr>
				<tr>
					<td class="NormalGreenBold">Cont angajator:
					</td>
					<td><asp:dropdownlist id="drpContAngajator" runat="server" Width="210px" CssClass="NormalEditBoxuri"></asp:dropdownlist><SPAN class="CommentRedBold">*</SPAN>
					</td>
				</tr>
				<tr>
					<td class="NormalGreenBold">Moneda conturi angajati:
					</td>
					<td><asp:dropdownlist id="drpMonedaCont" runat="server" Width="210px" CssClass="NormalEditBoxuri"></asp:dropdownlist><SPAN class="CommentRedBold">*</SPAN>
					</td>
				</tr>
				<tr>
					<td class="NormalGreenBold">Tipul platii:
					</td>
					<td><asp:textbox id="txtTipulPlatii" runat="server" Width="210px" CssClass="NormalEditBoxuri">salariu</asp:textbox><SPAN class="CommentRedBold">*
							<asp:requiredfieldvalidator id="Requiredfieldvalidator2" CssClass="AlertRedBold" runat="server" ControlToValidate="txtTipulPlatii"
								ErrorMessage="Completati tipul platii!"><</asp:requiredfieldvalidator></SPAN>
						<asp:regularexpressionvalidator id="Regularexpressionvalidator2" CssClass="AlertRedBold" runat="server" ControlToValidate="txtTipulPlatii"
							ValidationExpression="^[^>|(|)|<|'|&quot;|;|\\]*$" ErrorMessage="Tipul platii nu poate contine caractere invalide: <>()';&quot;\"><</asp:regularexpressionvalidator></td>
				</tr>
				<tr>
					<td class="NormalGreenBold">Luna pentru care se face plata:
						<br>
						(exp: dec. 2005)
					</td>
					<td><asp:textbox id="txtLunaAn" runat="server" Width="210px" CssClass="NormalEditBoxuri"></asp:textbox><SPAN class="CommentRedBold">*</SPAN>
						<asp:requiredfieldvalidator id="Requiredfieldvalidator3" CssClass="AlertRedBold" runat="server" ControlToValidate="txtLunaAn"
							ErrorMessage="Completati luna platii!"><</asp:requiredfieldvalidator>
						<asp:regularexpressionvalidator id="Regularexpressionvalidator1" CssClass="AlertRedBold" runat="server" ControlToValidate="txtLunaAn"
							ValidationExpression="^[^>|(|)|<|'|&quot;|;|\\]*$" ErrorMessage="Luna pentru care se face plata nu poate contine caractere invalide: <>()';&quot;\"><</asp:regularexpressionvalidator></td>
				</tr>
				<tr>
					<td class="CommentRedBold" align="left" colspan="2">* - Campuri obligatorii
					</td>
				</tr>
				<tr>
					<td align="center" colspan="2">
						<asp:button id="btnAfiseaza" runat="server" Text="Afiseaza" CssClass="ButtonStyle"></asp:button>
					</td>
				</tr>
			</table>
		</td>
	</tr>
	<TR height="5%" width="100%">
		<TD style="HEIGHT: 22px" align="left" colspan="2">
			<asp:label id="labelError" runat="server" CssClass="AlertRedBold"></asp:label>
		</TD>
	</TR>
	<tr height="1%" width="100%">
		<td align="center" colSpan="2">
			<asp:ValidationSummary id="sumarValidare" runat="server" ShowMessageBox="True" Width="159px" ShowSummary="False"></asp:ValidationSummary>
		</td>
	</tr>
	<TR height="74%" width="100%">
		<TD vAlign="top" colSpan="2"><cc1:reportviewer id="raportFisierMulticache" runat="server" Width="100%" Height="400px" BackColor="White"
				BorderColor="Transparent" Parameters="False" Toolbar="True" ForeColor="White" Zoom="100%" ReportPath="/Rapoarte/salarii"></cc1:reportviewer></TD>
	</TR>
</table>
