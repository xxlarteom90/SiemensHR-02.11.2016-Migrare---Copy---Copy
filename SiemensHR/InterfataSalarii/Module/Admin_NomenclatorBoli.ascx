<%@ Control Language="c#" AutoEventWireup="false" Codebehind="Admin_NomenclatorBoli.ascx.cs" Inherits="SiemensHR.InterfataSalarii.Module.Admin_NomenclatorBoli" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>
<script>
	function SelectBoala( BoalaID )
	{
		eval("Form1." + ctrlID + "_txtBoalaID.value = BoalaID;");
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
					<td align="center" height="50"><asp:button id="btnAdaugaCategorie" onmouseover="MouseOverButton(this)" onmouseout="MouseOutButton(this)"
							runat="server" CausesValidation="False" Text="Adauga boala" CssClass="ButtonStyle"></asp:button></td>
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
								<TD class="NormalGreenBold">Cod boala :</TD>
								<TD><asp:textbox id="txtCodBoala" runat="server" CssClass="NumericEditBoxuri" Width="320px" MaxLength="2"
										size="50"></asp:textbox><SPAN class="CommentRedBold"><asp:requiredfieldvalidator id="requiredCodBoala" runat="server" CssClass="AlertRedBold" ControlToValidate="txtCodBoala"
											ErrorMessage="Completati codul bolii!"><</asp:requiredfieldvalidator><asp:regularexpressionvalidator id="regularCodBoala" runat="server" CssClass="AlertRedBold" ControlToValidate="txtCodBoala"
											ErrorMessage="Codul necesita valoare numerica pozitiva!" ValidationExpression="\d+"><   </asp:regularexpressionvalidator></SPAN></TD>
							</TR>
							<tr>
								<td class="GreenSeparator" colSpan="2"><IMG height="1" src="images/1x1.gif"></td>
							</tr>
							<TR>
								<td class="NormalGreenBold">Denumire boala :</td>
								<td><asp:textbox id="txtCategorieBoala" runat="server" CssClass="NumericEditBoxuri" Width="320px"
										MaxLength="150" size="150"></asp:textbox><asp:requiredfieldvalidator id="requiredCategorieBoala" runat="server" CssClass="AlertRedBold" ControlToValidate="txtCategorieBoala"
										ErrorMessage="Completati categoria de boala!"><</asp:requiredfieldvalidator>
									<asp:regularexpressionvalidator id="Regularexpressionvalidator2" runat="server" CssClass="AlertRedBold" ErrorMessage="Denumirea nu poate sa contina caractere invalide: <>()';&quot;\"
										ControlToValidate="txtCategorieBoala" ValidationExpression="^[^>|(|)|<|'|&quot;|;|\\]*$"><</asp:regularexpressionvalidator></td>
							</TR>
							<tr>
								<td class="GreenSeparator" colSpan="2"><IMG height="1" src="images/1x1.gif"></td>
							</tr>
							<TR>
								<TD class="NormalGreenBold">Procent :</TD>
								<TD><asp:textbox id="txtProcent" runat="server" CssClass="NumericEditBoxuri" Width="320px" MaxLength="5"
										size="50"></asp:textbox><asp:requiredfieldvalidator id="requiredProcent" runat="server" CssClass="AlertRedBold" ControlToValidate="txtProcent"
										ErrorMessage="Completati procentul!"><</asp:requiredfieldvalidator><asp:comparevalidator id="CompareValidator1" runat="server" CssClass="AlertRedBold" ControlToValidate="txtProcent"
										ErrorMessage="Valoare numerica pozitiva <=100!" Type="Integer" ValueToCompare="100" Operator="LessThanEqual"><</asp:comparevalidator><asp:comparevalidator id="CompareValidator2" runat="server" CssClass="AlertRedBold" ControlToValidate="txtProcent"
										ErrorMessage="Valoare numerica pozitiva!" Type="Integer" ValueToCompare="0" Operator="GreaterThanEqual"><</asp:comparevalidator></TD>
							</TR>
							<tr>
								<td class="GreenSeparator" colSpan="2"><IMG height="1" src="images/1x1.gif"></td>
							</tr>
							<tr>
								<TD class="NormalGreenBold">Necesita stagiu :</TD>
								<TD><asp:checkbox id="cbStagiu" runat="server" CssClass="NumericEditBoxuri"></asp:checkbox></TD>
							</tr>
						</table>
					</td>
				</tr>
				<TR>
					<td class="CommentRedBold" colSpan="2">* - Campuri obligatorii<asp:textbox id="txtBoalaID" runat="server"></asp:textbox></td>
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
