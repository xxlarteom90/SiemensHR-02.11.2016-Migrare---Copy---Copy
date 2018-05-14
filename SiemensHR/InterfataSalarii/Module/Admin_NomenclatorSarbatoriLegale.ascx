<%@ Control Language="c#" AutoEventWireup="false" Codebehind="Admin_NomenclatorSarbatoriLegale.ascx.cs" Inherits="SiemensHR.InterfataSalarii.Module.Admin_NomenclatorSarbatoriLegale" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<script language="javascript" src="../js/jsCode.js"></script>
<script>
var arTabs = new Array('tableIstoricFunctii', 'tableAdaugaFunctie');

	function SelectTab(index)
	{
		for(i=0; i<arTabs.length; i++)
		{
			if (i==index)
			{
				eval(arTabs[i] + ".style.display=''");
				eval(ctrlID + "_tab"+ (i+1)+ ".className='tabActive'");
				add_line.style.display = "";
				edit_line.style.display = "none";
				eval("Form1." + ctrlID + "_txtAddDateSarbatoriLegale.value = '';");
				eval("Form1." + ctrlID + "_txtSarbatoriLegaleDenum.value = '';");
				eval("Form1." + ctrlID + "_txtSarbatoriLegaleDescr.value = '';");
					
			}
			else
			{
				eval(ctrlID + "_tab"+ (i+1) + ".className='tab'");
				eval(ctrlID + "_tab"+ (i+1) + ".style.backgroundColor='#7b8fc2'");
				eval(arTabs[i] + ".style.display='none'");
			}
		}
		document.getElementById(requiredDenumire).innerText = '';
		document.getElementById(requiredData).innerText = '';
		document.getElementById(regularDescriere).innerText = '';
		document.getElementById(Regularexpressionvalidator2).innerText = '';
	}
	
	function SelectFunctie( Data, Denumirea, Descrierea)
	{
		tableIstoricFunctii.style.display = "none";
		tableAdaugaFunctie.style.display = '';
		edit_line.style.display = "";
		add_line.style.display = "none";
		
		eval("Form1." + ctrlID + "_txtSarbatoriLegaleDenum.value = Denumirea;");
		eval("Form1." + ctrlID + "_txtAddDateSarbatoriLegale.value = Data;");
		eval("Form1." + ctrlID + "_txtSarbatoriLegaleDescr.value = Descrierea;");
		eval("Form1." + ctrlID + "_old_DataStart.value = Data;");		
		
	}
	
	function BackToList()
	{
		tableAdaugaFunctie.style.display='none';
		tableIstoricFunctii.style.display='';
		edit_line.style.display = "none";
		add_line.style.display = "";
		
	}

</script>
<table cellSpacing="0" cellPadding="0" width="600" align="center" border="0">
	<tr>
		<td><asp:literal id="litError" runat="server"></asp:literal></td>
	</tr>
	<tr>
		<td><IMG height="10" src="../images/1x1.gif"></td>
	</tr>
	<tr>
		<td><asp:table id="tableTabs" runat="server" Width="100%"></asp:table></td>
	</tr>
	<tr>
		<td id="tableIstoricFunctii" vAlign="top" align="center" height="100%"><asp:table id="listTable" runat="server"></asp:table></td>
		<td id="tableAdaugaFunctie" align="center">
			<TABLE height="200" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
				<tr>
					<td class="tabBackground">
						<TABLE height="100%" cellSpacing="1" cellPadding="0" width="100%" align="center" border="0">
							<tr>
								<td class="HeaderGreenBold" align="center" colSpan="2">Datele sarbatorii</td>
							</tr>
							<TR>
								<TD class="NormalGreenBold">Denumirea:</TD>
								<TD class="NormalGreenBold"><asp:textbox id="txtSarbatoriLegaleDenum" runat="server" CssClass="NormalEditBoxuri"></asp:textbox><asp:dropdownlist id="lstFunctie" runat="server" Visible="False"></asp:dropdownlist><SPAN class="CommentRedBold">*</SPAN><asp:requiredfieldvalidator id="requiredDenumire" runat="server" CssClass="AlertRedBold" ControlToValidate="txtSarbatoriLegaleDenum"
										ErrorMessage="Trebuie sa completati denumirea sarbatorii!"><</asp:requiredfieldvalidator>
									<asp:regularexpressionvalidator id="Regularexpressionvalidator2" runat="server" CssClass="AlertRedBold" ControlToValidate="txtSarbatoriLegaleDenum"
										ErrorMessage="Nu puteti adauga caractere invalide pentru denumire: <>()';&quot;\" ValidationExpression="^[^>|(|)|<|'|&quot;|;|\\]*$"><</asp:regularexpressionvalidator></TD>
							</TR>
							<tr>
								<td class="GreenSeparator" colSpan="2"><IMG height="1" src="../images/1x1.gif"></td>
							</tr>
							<TR>
								<TD class="NormalGreenBold">Data:</TD>
								<TD class="NormalGreenBold"><asp:textbox id="txtAddDateSarbatoriLegale" style="CURSOR: hand; TEXT-ALIGN: center" onclick="ShowCalendar(this,'..//')"
										runat="server" CssClass="NormalEditBoxuri" size="10"></asp:textbox><SPAN class="CommentRedBold">*</SPAN><asp:requiredfieldvalidator id="requiredData" runat="server" CssClass="AlertRedBold" ControlToValidate="txtAddDateSarbatoriLegale"
										ErrorMessage="Trebuie sa selectati data sarbatorii!"><</asp:requiredfieldvalidator></TD>
							</TR>
							<tr>
								<td class="GreenSeparator" colSpan="2"><IMG height="1" src="../images/1x1.gif"></td>
							</tr>
							<TR>
								<TD class="NormalGreenBold">Descrierea:</TD>
								<TD class="NormalGreenBold"><asp:textbox id="txtSarbatoriLegaleDescr" runat="server" CssClass="NormalEditBoxuri" TextMode="MultiLine"></asp:textbox><asp:regularexpressionvalidator id="regularDescriere" runat="server" CssClass="AlertRedBold" ControlToValidate="txtSarbatoriLegaleDescr"
										ErrorMessage="Nu puteti adauga caractere invalide pentru descriere: <>()';&quot;\" ValidationExpression="^[^>|(|)|<|'|&quot;|;|\\]*$"><</asp:regularexpressionvalidator></TD>
							</TR>
						</TABLE>
					</td>
				</tr>
				<tr id="add_line">
					<td align="center" height="100%">
						<P class="CommentRedBold">* Adaugarea unei&nbsp;sarbatori in luna activa va avea ca 
							si efect recalcularea situatiei lunare a angajatilor.</P>
						<P><asp:button id="btnAdauga" onmouseover="MouseOverButton(this)" onmouseout="MouseOutButton(this)"
								runat="server" CssClass="ButtonStyle" Text="  Salveaza date  "></asp:button></P>
					</td>
				</tr>
				<tr id="edit_line" style="DISPLAY: none">
					<td align="center" height="100%">
						<P class="CommentRedBold">*&nbsp;Modificarea unei&nbsp;sarbatori din luna activa va 
							avea ca si efect recalcularea situatiei lunare a angajatilor.</P>
						<P><asp:button id="btnModificaDate" onmouseover="MouseOverButton(this)" onmouseout="MouseOutButton(this)"
								runat="server" CssClass="ButtonStyle" Text="  Modifica date  " CausesValidation="true"></asp:button>&nbsp;
							<asp:button id="btnStergeDate" onmouseover="MouseOverButton(this)" onmouseout="MouseOutButton(this)"
								runat="server" CssClass="ButtonStyle" Text="  Sterge date  " CausesValidation="false"></asp:button>&nbsp;
							<input class="ButtonStyle" id="btnInapoi" onmouseover="MouseOverButton(this)" onclick="BackToList()"
								onmouseout="MouseOutButton(this)" type="button" value="  Inapoi  " CausesValidation="false">
						</P>
					</td>
				</tr>
				<tr>
					<td style="HEIGHT: 80px" align="center"><asp:textbox id="old_DataStart" runat="server"></asp:textbox><asp:validationsummary id="vldSummary" runat="server" ShowMessageBox="True" ShowSummary="False"></asp:validationsummary></td>
				</tr>
			</TABLE>
			<asp:literal id="errorLit" runat="server"></asp:literal></td>
	</tr>
</table>
&nbsp;
<script>

	eval(ctrlID + "_tab1.click()");
</script>
