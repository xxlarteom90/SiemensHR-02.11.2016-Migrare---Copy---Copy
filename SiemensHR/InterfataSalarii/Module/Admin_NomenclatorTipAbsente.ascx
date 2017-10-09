<%@ Control Language="c#" AutoEventWireup="false" Codebehind="Admin_NomenclatorTipAbsente.ascx.cs" Inherits="SiemensHR.InterfataSalarii.Module.Admin_NomenclatorTipAbsente" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>
<script>
	function SelectTipAbsenta( TipAbsentaID )
	{
		eval("Form1." + ctrlID + "_txtTipAbsentaID.value = TipAbsentaID;");
		eval("Form1." + ctrlID + "_btnEdit.click();");
	}
	
</script>
<!-- <table cellSpacing="0" cellPadding="0" width="768" border="0" style="WIDTH: 768px; HEIGHT: 475px"> -->
<table cellSpacing="0" cellPadding="0" width="600" align="center" border="0">
	<tr>
		<td style="WIDTH: 521px"><IMG height="30" src="../images/1x1.gif"><asp:literal id="litError" runat="server"></asp:literal></td>
	</tr>
	<tr>
		<td class="tabBackground" style="WIDTH: 609px" align="center">
			<table id="list_form" cellSpacing="0" cellPadding="0" width="100%" border="0" runat="server">
				<tr>
					<td align="center"><asp:table id="mainTable" runat="server"></asp:table></td>
				</tr>
				<tr>
					<td align="center" height="50"><asp:button id="btnAdaugaTipAbsenta" onmouseover="MouseOverButton(this)" onmouseout="MouseOutButton(this)"
							runat="server" CssClass="ButtonStyle" Text="Adauga tip absenta" CausesValidation="False" Visible="False"></asp:button></td>
				</tr>
			</table>
		</td>
	</tr>
	<tr>
		<td style="WIDTH: 609px">
			<table id="add_form" cellSpacing="1" cellPadding="0" width="100%" border="0" runat="server">
				<tr>
					<td align="center"><asp:table id="add_header" runat="server"></asp:table></td>
				</tr>
				<tr>
					<td class="tabBackground">
						<table cellSpacing="0" cellPadding="0" width="100%" border="0">
							<tr>
								<td class="GreenSeparator" colSpan="2"><IMG height="1" src="images/1x1.gif"></td>
							</tr>
							<TR>
								<TD class="NormalGreenBold">Denumire :</TD>
								<TD><asp:textbox id="txtDenumireTipAbsenta" runat="server" CssClass="NumericEditBoxuri" MaxLength="255"
										Width="320px"></asp:textbox><asp:label id="labelDenumireTipAbsenta" Visible="False" CssClass="textStyle1" Width="320px"
										Runat="server"></asp:label><SPAN class="CommentRedBold"><asp:requiredfieldvalidator id="requiredDenumireTipAbsenta" runat="server" ErrorMessage="Trebuie sa completati denumirea tipului de absenta!"
											ControlToValidate="txtDenumireTipAbsenta" CssClass="AlertRedBold"><</asp:requiredfieldvalidator></SPAN></TD>
							</TR>
							<tr>
								<td class="GreenSeparator" colSpan="2"><IMG height="1" src="images/1x1.gif"></td>
							</tr>
							<TR>
								<TD class="NormalGreenBold">Cod :</TD>
								<TD><asp:textbox id="txtCodTipAbsenta" runat="server" CssClass="NumericEditBoxuri" MaxLength="5"
										Width="320px"></asp:textbox><asp:label id="labelCodTipAbsenta" Visible="False" CssClass="textStyle1" Width="320px" Runat="server"></asp:label><SPAN class="CommentRedBold"><asp:requiredfieldvalidator id="requiredCodTipAbsenta" runat="server" ErrorMessage="Trebuie sa completati codul absentei!"
											ControlToValidate="txtCodTipAbsenta" CssClass="AlertRedBold"><</asp:requiredfieldvalidator></SPAN></TD>
							</TR>
							<tr>
								<td class="GreenSeparator" colSpan="2"><IMG height="1" src="images/1x1.gif"></td>
							</tr>
							<TR>
								<TD class="NormalGreenBold">Procent :</TD>
								<TD><asp:textbox id="txtProcentTipAbsenta" runat="server" CssClass="NumericEditBoxuri" MaxLength="6"
										Width="320px"></asp:textbox><span><asp:requiredfieldvalidator id="requiredProcentTipAbsenta" runat="server" ErrorMessage="Trebuie sa completati procentul!"
											ControlToValidate="txtProcentTipAbsenta" CssClass="AlertRedBold"><</asp:requiredfieldvalidator><asp:rangevalidator id="rngVldProcent" runat="server" ErrorMessage="Trebuie sa completati corect procentul!"
											ControlToValidate="txtProcentTipAbsenta" MinimumValue="0" MaximumValue="100" Type="Double" CssClass="AlertRedBold"><</asp:rangevalidator></span></TD>
							</TR>
							<tr>
								<td class="GreenSeparator" colSpan="2"><IMG height="1" src="images/1x1.gif"></td>
							</tr>
							<TR>
								<TD class="NormalGreenBold">Descriere :</TD>
								<TD><asp:textbox id="txtDescriereTipAbsenta" runat="server" CssClass="NumericEditBoxuri" MaxLength="255"
										Width="320px" TextMode="MultiLine"></asp:textbox></TD>
							</TR>
							<tr>
								<td class="GreenSeparator" colSpan="2"><IMG height="1" src="images/1x1.gif"></td>
							</tr>
							<tr>
								<TD class="NormalGreenBold">Absenta medicala :</TD>
								<TD><asp:checkbox id="cbMedicalTipAbsenta" runat="server" CssClass="NumericEditBoxuri"></asp:checkbox></TD>
							</tr>
							<tr>
								<td class="GreenSeparator" colSpan="2"><IMG height="1" src="images/1x1.gif"></td>
							</tr>
							<tr>
								<TD class="NormalGreenBold">Poate fi redenumit:</TD>
								<TD><asp:checkbox id="cbModificabilaTipAbsenta" runat="server" CssClass="NumericEditBoxuri"></asp:checkbox></TD>
							</tr>
							<tr>
								<td class="GreenSeparator" colSpan="2"><IMG height="1" src="images/1x1.gif"></td>
							</tr>
							<tr>
								<TD class="NormalGreenBold">Folosire curenta :</TD>
								<TD><asp:checkbox id="cbFolosireTipAbsenta" runat="server" CssClass="NumericEditBoxuri"></asp:checkbox></TD>
							</tr>
							<tr>
								<td class="GreenSeparator" colSpan="2"><IMG height="1" src="images/1x1.gif"></td>
							</tr>
							<tr>
								<TD class="NormalGreenBold">Absenta lucratoare :</TD>
								<TD><asp:checkbox id="cbAbsentaLucratoare" runat="server"></asp:checkbox></TD>
							</tr>
						</table>
					</td>
				</tr>
				<TR>
					<td class="CommentRedBold" colSpan="2">* - Campuri obligatorii<asp:textbox id="txtTipAbsentaID" runat="server"></asp:textbox></td>
				</TR>
				<TR>
					<TD align="center" colSpan="2" height="50"><asp:button id="btnSalveaza" onmouseover="MouseOverButton(this)" onmouseout="MouseOutButton(this)"
							runat="server" CssClass="ButtonStyle" Text="Salveaza"></asp:button>&nbsp;&nbsp;&nbsp;
						<asp:button id="btnSterge" onmouseover="MouseOverButton(this)" onmouseout="MouseOutButton(this)"
							runat="server" CssClass="ButtonStyle" Text="  Sterge  " CausesValidation="False" Visible="False"></asp:button>&nbsp;
						<asp:button id="btnInapoi" onmouseover="MouseOverButton(this)" onmouseout="MouseOutButton(this)"
							runat="server" CssClass="ButtonStyle" Text="Inapoi" CausesValidation="False"></asp:button><asp:button id="btnEdit" runat="server" Text="Edit" CausesValidation="False"></asp:button></TD>
				</TR>
				<TR>
					<TD align="center" colSpan="2"><asp:validationsummary id="ValidationSummary1" runat="server" ShowMessageBox="True" ShowSummary="False"></asp:validationsummary></TD>
				</TR>
			</table>
		</td>
	</tr>
</table>
