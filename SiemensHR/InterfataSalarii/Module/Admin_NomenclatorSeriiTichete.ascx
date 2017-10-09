<%@ Control Language="c#" AutoEventWireup="false" Codebehind="Admin_NomenclatorSeriiTichete.ascx.cs" Inherits="SiemensHR.InterfataSalarii.Module.Admin_NomenclatorSeriiTichete" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>
<script>
	function SelectSerie( SerieID )
	{
		eval("Form1." + ctrlID + "_txtSerieID.value = SerieID;");
		eval("Form1." + ctrlID + "_btnEdit.click();");
	}
	
</script>
<!--<table cellSpacing="0" cellPadding="0" width="768" border="0" style="WIDTH: 768px; HEIGHT: 475px">-->
<table cellSpacing="0" cellPadding="0" width="500" align="center" border="0">
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
					<td align="center" height="50"><asp:button id="btnAdauga" onmouseover="MouseOverButton(this)" onmouseout="MouseOutButton(this)"
							runat="server" CausesValidation="False" Text="Adauga interval serii" CssClass="ButtonStyle"></asp:button></td>
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
								<TD class="NormalGreenBold">Inceput serie&nbsp;:</TD>
								<TD><asp:textbox id="txtInceputSerie" runat="server" CssClass="NumericEditBoxuri" Width="320px" MaxLength="150"
										size="50"></asp:textbox><SPAN class="CommentRedBold">*<asp:requiredfieldvalidator id="requiredCodBoala" runat="server" CssClass="AlertRedBold" ControlToValidate="txtInceputSerie"
											ErrorMessage="Completati seria de inceput!"><</asp:requiredfieldvalidator><asp:regularexpressionvalidator id="regularCodBoala" runat="server" CssClass="AlertRedBold" ControlToValidate="txtInceputSerie"
											ErrorMessage="Seria necesita valoare numerica pozitiva!" ValidationExpression="\d+"><   </asp:regularexpressionvalidator></SPAN></TD>
							</TR>
							<tr>
								<td class="GreenSeparator" colSpan="2"><IMG height="1" src="images/1x1.gif"></td>
							</tr>
							<TR>
								<td class="NormalGreenBold">Sfarsit serie&nbsp;:</td>
								<td><asp:textbox id="txtSfarsitSerie" runat="server" CssClass="NumericEditBoxuri" Width="320px" MaxLength="150"
										size="150"></asp:textbox><SPAN class="CommentRedBold">*<asp:requiredfieldvalidator id="requiredCategorieBoala" runat="server" CssClass="AlertRedBold" ControlToValidate="txtSfarsitSerie"
											ErrorMessage="Completati numarul de sfarsit!"><</asp:requiredfieldvalidator>
										<asp:regularexpressionvalidator id="Regularexpressionvalidator1" runat="server" CssClass="AlertRedBold" ErrorMessage="Seria necesita valoare numerica pozitiva!"
											ControlToValidate="txtSfarsitSerie" ValidationExpression="\d+"><   </asp:regularexpressionvalidator></SPAN></td>
							</TR>
							<tr>
								<td class="GreenSeparator" colSpan="2"><IMG height="1" src="images/1x1.gif"></td>
							</tr>
							<TR>
								<TD class="NormalGreenBold">Luna:</TD>
								<TD>
									<asp:dropdownlist id="lstLunaSerie" runat="server" Width="320px"></asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD class="NormalGreenBold">Punct de lucru:</TD>
								<TD>
									<asp:dropdownlist id="lstPunctLucru" runat="server" Width="320px"></asp:dropdownlist></TD>
							</TR>
						</table>
					</td>
				</tr>
				<TR>
					<TD class="CommentRedBold" colSpan="2">Seriile introduse sunt pentru luna activa</TD>
				</TR>
				<TR>
					<td class="CommentRedBold" colSpan="2">
						<P>* - Campuri obligatorii<asp:textbox id="txtSerieID" runat="server"></asp:textbox></P>
					</td>
				</TR>
				<TR>
					<TD align="center" colSpan="2" height="50"><asp:button id="btnSalveaza" onmouseover="MouseOverButton(this)" onmouseout="MouseOutButton(this)"
							runat="server" Text="Salveaza" CssClass="ButtonStyle"></asp:button>&nbsp;&nbsp;&nbsp;
						<asp:button id="btnSterge" onmouseover="MouseOverButton(this)" onmouseout="MouseOutButton(this)"
							runat="server" CausesValidation="False" Text="  Sterge  " CssClass="ButtonStyle"></asp:button>&nbsp;
						<asp:button id="btnInapoi" onmouseover="MouseOverButton(this)" onmouseout="MouseOutButton(this)"
							runat="server" CausesValidation="False" Text="Inapoi" CssClass="ButtonStyle"></asp:button><asp:button id="btnEdit" runat="server" CausesValidation="False" Text="Edit"></asp:button></TD>
				</TR>
				<TR>
					<TD align="center" colSpan="2"><asp:validationsummary id="ValidationSummary1" runat="server" ShowSummary="False" ShowMessageBox="True"></asp:validationsummary></TD>
				</TR>
			</table>
		</td>
	</tr>
</table>
