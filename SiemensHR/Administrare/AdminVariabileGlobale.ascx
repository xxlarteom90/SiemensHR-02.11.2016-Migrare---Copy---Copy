<%@ Control Language="c#" AutoEventWireup="false" Codebehind="AdminVariabileGlobale.ascx.cs" Inherits="SiemensHR.Administrare.AdminVariabileGlobale" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>
<script>
	function sp3FormIDfix() {
		document.forms[0].id=ctrlID + "_Form1";
		
		document.getElementById(requiredCod).innerText = '';
		document.getElementById(requiredDenumire).innerText = '';
		document.getElementById(regularDenumire).innerText = '';
		document.getElementById(regularCod).innerText = '';
	}
	
	function ShowAddForm() {
		list_form.style.display = "none";
		eval(ctrlID + "_add_buttonLine.style.display = 'none'");
		eval(ctrlID + "_add_form.style.display = ''");		
		eval(ctrlID + "_Form1." + ctrlID + "_txtDenumire.value = '';");	
		eval(ctrlID + "_Form1." + ctrlID + "_txtCod.value = '';");	
		eval(ctrlID + "_Form1." + ctrlID + "_txtDescriere.value = '';");

	}

	function ShowList() {
		list_form.style.display = "";
		eval(ctrlID + "_add_buttonLine.style.display = ''");
		eval(ctrlID + "_add_form.style.display = 'none'");
	}

	function SelectLine( id, activ ) {
		eval(ctrlID + "_Form1." + ctrlID + "_txtTipVariabilaGlobalaID.value = id;");
		eval(ctrlID + "_Form1." + ctrlID + "_btnEdit.click();");		
	}
</script>
<form id="Form1" name="Form1" method="post" runat="server">
	<TABLE class="tabBackground" id="Table1" height="200" cellSpacing="0" cellPadding="0" width="100%"
		border="0">
		<TR>
			<TD><asp:literal id="litError" runat="server"></asp:literal></TD>
		</TR>
		<TR id="list_form">
			<TD align="center"><asp:table id="mainTable" runat="server"></asp:table></TD>
		</TR>
		<TR id="add_form" runat="server">
			<TD align="center">
				<TABLE id="Table2" cellSpacing="1" cellPadding="0" border="0">
					<TR>
						<TD class="BigBlueBold" id="tdTitle" align="center" colSpan="2" height="50" runat="server">Introducere&nbsp;tip 
							de variabila globala&nbsp;nou</TD>
					</TR>
					<TR>
						<TD align="center" colSpan="2"><asp:table id="headerTable" runat="server"></asp:table></TD>
					</TR>
					<TR>
						<TD>
							<TABLE class="tabBackground" id="Table3" cellSpacing="1" cellPadding="0" width="100%" border="0">
								<TBODY>
									<TR>
										<TD class="NormalGreenBold" style="WIDTH: 83px; HEIGHT: 23px">Cod:&nbsp;</TD>
										<TD style="HEIGHT: 23px">
											&nbsp;<asp:textbox id="txtCod" runat="server" size="50" CssClass="NormalEditBoxuri" MaxLength="32"
												Height="0px" Width="360px"></asp:textbox>
											<asp:Label id="labelCodTipVariabilaGlobala" Width="360px" CssClass="textStyle1" Runat="server"
												Visible="False"></asp:Label><SPAN class="CommentRedBold">*
												<asp:requiredfieldvalidator id="requiredCod" runat="server" CssClass="AlertRedBold" ErrorMessage="Completati codul!"
													ControlToValidate="txtCod"><</asp:requiredfieldvalidator>
												<asp:RegularExpressionValidator id="regularCod" runat="server" CssClass="AlertRedBold" ControlToValidate="txtCod"
													ErrorMessage="Codul nu poate sa contina caractere invalide: <>()';&quot;\ " ValidationExpression="^[^>|(|)|<|'|&quot;|;|\\]*$"><</asp:RegularExpressionValidator></SPAN></TD>
							</SPAN>
						</TD>
					</TR>
					<TR>
						<TD class="GreenSeparator" colSpan="2"><IMG height="1" src="images/1x1.gif"></TD>
					</TR>
					<TR>
						<TD class="NormalGreenBold" style="WIDTH: 83px">Denumire:&nbsp;</TD>
						<TD>&nbsp;<asp:textbox id="txtDenumire" runat="server" size="50" CssClass="NormalEditBoxuri" MaxLength="255"
								Width="360px"></asp:textbox><SPAN class="CommentRedBold">*</SPAN>
							<asp:requiredfieldvalidator id="requiredDenumire" runat="server" CssClass="AlertRedBold" ErrorMessage="Completati denumirea tipului de variabila!"
								ControlToValidate="txtDenumire"><</asp:requiredfieldvalidator>
							<asp:RegularExpressionValidator id="regularDenumire" runat="server" CssClass="AlertRedBold" ControlToValidate="txtDenumire"
								ErrorMessage="Denumirea nu poate sa contina caractere invalide: <>()';&quot;\ " ValidationExpression="^[^>|(|)|<|'|&quot;|;|\\]*$"><</asp:RegularExpressionValidator></TD>
					</TR>
					<TR>
						<TD class="GreenSeparator" colSpan="2"><IMG height="1" src="images/1x1.gif"></TD>
					</TR>
					<TR>
						<TD class="NormalGreenBold" style="WIDTH: 83px">Descriere:&nbsp;</TD>
						<TD>&nbsp;<asp:textbox id="txtDescriere" runat="server" CssClass="AreaStyle" MaxLength="512" Width="360px"
								Rows="3" TextMode="MultiLine" Columns="40"></asp:textbox></TD>
					</TR>
				</TABLE>
				<asp:textbox id="txtTipVariabilaGlobalaID" runat="server"></asp:textbox></TD>
		</TR>
		<TR>
			<TD class="CommentRedBold" colSpan="2">* - Campuri obligatorii</TD>
		</TR>
		<TR id="td_addLine" runat="server">
			<TD align="center" colSpan="2" height="50"><asp:button id="btnAdd" onmouseover="MouseOverButton(this)" onmouseout="MouseOutButton(this)"
					runat="server" CssClass="ButtonStyle" Text="Salveaza tip variabila globala"></asp:button>&nbsp;
				<INPUT class="ButtonStyle" onmouseover="MouseOverButton(this)" onclick="ShowList()" onmouseout="MouseOutButton(this)"
					type="button" value="  Inapoi  ">
				<asp:button id="btnEdit" runat="server" Text="Edit" CausesValidation="False"></asp:button></TD>
		</TR>
		<TR>
			<TD align="center" colSpan="2"><asp:label id="lblMessage" runat="server" CssClass="AlertRedBold"></asp:label>&nbsp;</TD>
		</TR>
		<TR id="td_editLine" runat="server">
			<TD align="center" colSpan="2" height="50"><asp:button id="btnModify" onmouseover="MouseOverButton(this)" onmouseout="MouseOutButton(this)"
					runat="server" CssClass="ButtonStyle" Text="Modifica tip variabila globala"></asp:button>&nbsp;
				<asp:button id="btnDelete" onmouseover="MouseOverButton(this)" onmouseout="MouseOutButton(this)"
					runat="server" CssClass="ButtonStyle" Text="Sterge tip variabila globala" CausesValidation="False"></asp:button>&nbsp;
				<asp:button id="btnInapoi" onmouseover="MouseOverButton(this)" onmouseout="MouseOutButton(this)"
					runat="server" CssClass="ButtonStyle" Text="   Inapoi   " CausesValidation="False"></asp:button></TD>
		</TR>
		<TR>
			<TD align="center" colSpan="2"><asp:validationsummary id="ValidationSummary1" onmouseover="MouseOverButton(this)" onmouseout="MouseOutButton(this)"
					runat="server" CssClass="AlertRedBold" ShowMessageBox="True" ShowSummary="False"></asp:validationsummary></TD>
		</TR>
	</TABLE>
	</TD></TR>
	<TR id="add_buttonLine" runat="server">
		<TD align="center" height="50">
			<TABLE id="Table4" cellSpacing="0" cellPadding="0" border="0">
				<TR>
					<TD class="UnderlineBlackBold">Pentru adaugarea unui&nbsp;tip de variabila 
						globala&nbsp;nou apasati pe acest buton:
					</TD>
					<TD>&nbsp;<INPUT class="ButtonStyle" onmouseover="MouseOverButton(this)" onclick="ShowAddForm()"
							onmouseout="MouseOutButton(this)" type="button" value="Tip variabila globala nou">&nbsp;</TD>
				</TR>
			</TABLE>
		</TD>
	</TR>
	</TBODY></TABLE>
</form>
<SCRIPT>
sp3FormIDfix();
</SCRIPT>
