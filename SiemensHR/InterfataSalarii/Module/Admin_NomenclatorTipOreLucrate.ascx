<%@ Control Language="c#" AutoEventWireup="false" Codebehind="Admin_NomenclatorTipOreLucrate.ascx.cs" Inherits="SiemensHR.InterfataSalarii.Module.Admin_NomenclatorTipOreLucrate" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>
<script>
	function SelectTipOraLucrata( TipIntervalID )
	{
		eval("Form1." + ctrlID + "_txtTipIntervalID.value = TipIntervalID;");
		eval("Form1." + ctrlID + "_btnEdit.click();");
	}
	
	function StandardTipOre_Changed()
	{
		eval(" var cbStandardValue = Form1." + ctrlID + "_cbStandardTipOre.checked;");
		if( cbStandardValue == false )
		{
			document.getElementById( trWeekendNoapteClient ).style.display = '';
			document.getElementById( trWeekendNoapteSeparatorClient ).style.display = '';
		}
		else
		{
			document.getElementById( trWeekendNoapteClient ).style.display = 'none';
			document.getElementById( trWeekendNoapteSeparatorClient ).style.display = 'none';
		}
	}
	
</script>
<!--<table cellSpacing="0" cellPadding="0" width="768" border="0" style="WIDTH: 768px; HEIGHT: 475px">-->
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
							<TR>
								<TD class="NormalGreenBold">Denumire :</TD>
								<TD><asp:textbox id="txtDenumireTipOre" runat="server" MaxLength="255" Width="320px" CssClass="NumericEditBoxuri"></asp:textbox><asp:label id="labelDenumireTipOre" Width="320px" CssClass="textStyle1" Runat="server" Visible="False"></asp:label><SPAN class="CommentRedBold"><asp:requiredfieldvalidator id="requiredDenumireTipOre" runat="server" ErrorMessage="Completati denumirea orei!"
											ControlToValidate="txtDenumireTipOre" CssClass="AlertRedBold"><</asp:requiredfieldvalidator></SPAN></TD>
							</TR>
							<tr>
								<td class="GreenSeparator" colSpan="2"><IMG height="1" src="images/1x1.gif"></td>
							</tr>
							<TR>
								<TD class="NormalGreenBold">Descriere :</TD>
								<TD><asp:textbox id="txtDescriereTipOre" runat="server" MaxLength="255" Width="320px" CssClass="NumericEditBoxuri"
										TextMode="MultiLine"></asp:textbox></TD>
							</TR>
							<tr>
								<td class="GreenSeparator" colSpan="2"><IMG height="1" src="images/1x1.gif"></td>
							</tr>
							<TR>
								<TD class="NormalGreenBold">Procent :</TD>
								<TD><asp:textbox id="txtProcentTipOre" runat="server" MaxLength="4" Width="80px" CssClass="NumericEditBoxuri">0</asp:textbox><span><asp:requiredfieldvalidator id="requiredProcentTipOre" runat="server" ErrorMessage="Trebuie sa completati procentul!"
											ControlToValidate="txtProcentTipOre" CssClass="AlertRedBold"><</asp:requiredfieldvalidator><asp:rangevalidator id="rngVldProcent" runat="server" ErrorMessage="Introduceti o valoare corecta a procentului!"
											ControlToValidate="txtProcentTipOre" MinimumValue="0" MaximumValue="1000" Type="Double" CssClass="AlertRedBold">< </asp:rangevalidator></span></TD>
							</TR>
							<tr>
								<td class="GreenSeparator" colSpan="2"><IMG height="1" src="images/1x1.gif"></td>
							</tr>
							<TR>
								<TD class="NormalGreenBold">Nr maxim de ore pe saptamana:</TD>
								<TD><asp:textbox id="txtNrMaximOreSapt" runat="server" MaxLength="3" Width="80px" CssClass="NumericEditBoxuri">0</asp:textbox><asp:requiredfieldvalidator id="reqVldNrOreMaxim" runat="server" ErrorMessage="Trebuie sa completati numarul maxim de ore pe saptamana!"
										ControlToValidate="txtNrMaximOreSapt" CssClass="AlertRedBold"><</asp:requiredfieldvalidator><asp:rangevalidator id="rngVldNrOreMaxim" runat="server" ErrorMessage="Introduceti corect numarul de ore maxim pe saptamana!"
										ControlToValidate="txtNrMaximOreSapt" MinimumValue="0" MaximumValue="168" Type="Integer" CssClass="AlertRedBold"><</asp:rangevalidator></TD>
							</TR>
							<tr>
								<td class="GreenSeparator" colSpan="2"><IMG height="1" src="images/1x1.gif"></td>
							</tr>
							<tr>
								<TD class="NormalGreenBold">Ora standard (normala):</TD>
								<TD><asp:checkbox id="cbStandardTipOre" onclick="StandardTipOre_Changed()" runat="server" CssClass="NumericEditBoxuri"></asp:checkbox></TD>
							</tr>
							<tr>
								<td class="GreenSeparator" colSpan="2"><IMG height="1" src="images/1x1.gif"></td>
							</tr>
							<tr>
								<TD class="NormalGreenBold">Poate fi redenumit&nbsp;:</TD>
								<TD><asp:checkbox id="cbModificabilaTipOre" runat="server" CssClass="NumericEditBoxuri"></asp:checkbox></TD>
							</tr>
							<tr>
								<td class="GreenSeparator" colSpan="2"><IMG height="1" src="images/1x1.gif"></td>
							</tr>
							<tr>
								<TD class="NormalGreenBold">Folosire curenta :</TD>
								<TD><asp:checkbox id="cbFolosireTipOre" runat="server" CssClass="NumericEditBoxuri"></asp:checkbox></TD>
							</tr>
							<tr>
								<td class="GreenSeparator" colSpan="2"><IMG height="1" src="images/1x1.gif"></td>
							</tr>
							<tr>
								<TD class="NormalGreenBold">Bonuri de masa :</TD>
								<TD><asp:checkbox id="cbBonuriMasa" runat="server" CssClass="NumericEditBoxuri"></asp:checkbox></TD>
							</tr>
							<tr id="trWeekendNoapteSeparator" runat="server">
								<td class="GreenSeparator" colSpan="2"><IMG height="1" src="images/1x1.gif"></td>
							</tr>
							<tr id="trWeekendNoapte" runat="server">
								<TD class="NormalGreenBold">Aplicare speciala<br>
									(weekend si noapte) :</TD>
								<TD><asp:checkbox id="cbWeekendNoapte" runat="server" CssClass="NumericEditBoxuri"></asp:checkbox></TD>
							</tr>
						</table>
					</td>
				</tr>
				<TR>
					<td class="CommentRedBold" colSpan="2">* - Campuri obligatorii<asp:textbox id="txtTipIntervalID" runat="server"></asp:textbox></td>
				</TR>
				<TR>
					<TD align="center" colSpan="2" height="50"><asp:button id="btnSalveaza" onmouseover="MouseOverButton(this)" onmouseout="MouseOutButton(this)"
							runat="server" CssClass="ButtonStyle" Text="Salveaza"></asp:button>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
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
