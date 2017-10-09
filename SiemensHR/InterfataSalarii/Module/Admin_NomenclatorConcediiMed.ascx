<%@ Control Language="c#" AutoEventWireup="false" Codebehind="Admin_NomenclatorConcediiMed.ascx.cs" Inherits="SiemensHR.InterfataSalarii.Module.Admin_NomenclatorConcediiMed" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>
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
				eval("Form1." + ctrlID + "_txtValMinimAngajati.value = '';");
				eval("Form1." + ctrlID + "_txtValMaximAngajati.value = '';");
				eval("Form1." + ctrlID + "_txtNrZilePlatite.value = '';");		
				document.getElementById(regExprVldNrMinAngajatiClientID).innerText = '';
				document.getElementById(reqVldNrMinAngajatiClientID).innerText = '';
				document.getElementById(regExprVldNrMaxAngajatiClientID).innerText = '';
				document.getElementById(reqVldNrMaxAngajatiClientID).innerText = '';
				document.getElementById(regExprVldNrMinAngajatiClientID).innerText = '';
				document.getElementById(regExprVldNrZilePlatiteClientID).innerText = '';
				document.getElementById(reqVldNrZilePlatiteClientID).innerText = '';
			}
			else
			{
				eval(ctrlID + "_tab"+ (i+1) + ".className='tab'");
				eval(ctrlID + "_tab"+ (i+1) + ".style.backgroundColor='#7b8fc2'");
				eval(arTabs[i] + ".style.display='none'");		
			}
		}
	}
	
	function SelectFunctie( id_Criteriu, ValMinimAngajati, ValMaximAngajati,NrZilePlatite)
	{
		tableIstoricFunctii.style.display = "none";
		tableAdaugaFunctie.style.display = '';
		edit_line.style.display = "";
		add_line.style.display = "none";
		
		eval("Form1." + ctrlID + "_txtValMinimAngajati.value = ValMinimAngajati;");
		eval("Form1." + ctrlID + "_txtValMaximAngajati.value = ValMaximAngajati;");
		eval("Form1." + ctrlID + "_txtNrZilePlatite.value = NrZilePlatite;");
		eval("Form1." + ctrlID + "_txtIdCriteriu.value = id_Criteriu;");		
		
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
								<td class="HeaderGreenBold" align="center" colSpan="2">Datele concediului medical</td>
							</tr>
							<TR>
								<TD class="NormalGreenBold">Nr. minim angajati:</TD>
								<TD class="NormalGreenBold">
									<asp:textbox id="txtValMinimAngajati" runat="server" MaxLength="6" CssClass="NormalEditBoxuri"></asp:textbox>
									<asp:label id="lblCmpObligatoriu1" runat="server" ForeColor="Red" Font-Size="Smaller">*</asp:label>
									<asp:requiredfieldvalidator id="reqVldNrMinAngajati" runat="server" ControlToValidate="txtValMinimAngajati"
										ErrorMessage="Trebuie sa completati numarul minim de angajati!" CssClass="AlertRedBold"><</asp:requiredfieldvalidator>
									<asp:regularexpressionvalidator id="regExprVldNrMinAngajati" runat="server" ControlToValidate="txtValMinimAngajati"
										ErrorMessage="Trebuie sa introduceti corect numarul  minim de angajati!" ValidationExpression="\d*" CssClass="AlertRedBold"><</asp:regularexpressionvalidator></TD>
							</TR>
							<tr>
								<td class="GreenSeparator" colSpan="2"><IMG height="1" src="../images/1x1.gif"></td>
							</tr>
							<TR>
								<TD class="NormalGreenBold">Nr. maxim angajati:</TD>
								<TD class="NormalGreenBold">
									<asp:textbox id="txtValMaximAngajati" runat="server" MaxLength="6" CssClass="NormalEditBoxuri"
										size="20"></asp:textbox>
									<asp:label id="lblCmpObligatoriu2" runat="server" ForeColor="Red" Font-Size="Smaller">*</asp:label>
									<asp:requiredfieldvalidator id="reqVldNrMaxAngajati" runat="server" ControlToValidate="txtValMaximAngajati"
										ErrorMessage="Trebuie sa completati numarul maxim de angajati!" CssClass="AlertRedBold"><</asp:requiredfieldvalidator>
									<asp:regularexpressionvalidator id="regExprVldNrMaxAngajati" runat="server" ControlToValidate="txtValMaximAngajati"
										ErrorMessage="Trebuie sa introduceti corect numarul maxim de angajati!" ValidationExpression="\d*" CssClass="AlertRedBold"><</asp:regularexpressionvalidator></TD>
							</TR>
							<tr>
								<td class="GreenSeparator" colSpan="2"><IMG height="1" src="../images/1x1.gif"></td>
							</tr>
							<TR>
								<TD class="NormalGreenBold">Nr. zile platite:</TD>
								<TD class="NormalGreenBold">
									<asp:textbox id="txtNrZilePlatite" runat="server" MaxLength="6" CssClass="NormalEditBoxuri"></asp:textbox>
									<asp:label id="lblCmpObligatoriu3" runat="server" ForeColor="Red" Font-Size="Smaller">*</asp:label>
									<asp:requiredfieldvalidator id="reqVldNrZilePlatite" runat="server" ControlToValidate="txtNrZilePlatite" ErrorMessage="Trebuie sa completati numarul de zile platite!"
										CssClass="AlertRedBold"><</asp:requiredfieldvalidator>
									<asp:regularexpressionvalidator id="regExprVldNrZilePlatite" runat="server" ControlToValidate="txtNrZilePlatite"
										ErrorMessage="Trebuie sa introduceti corect numarul de zile platite!" ValidationExpression="\d*" CssClass="AlertRedBold"><</asp:regularexpressionvalidator></TD>
							</TR>
							<tr>
								<td class="GreenSeparator" colSpan="2"><IMG height="1" src="../images/1x1.gif"></td>
							</tr>
							<tr>
								<td align="left"><asp:label id="lblCmpObl" runat="server" ForeColor="Red" Font-Size="Smaller">* - Camp obligatoriu</asp:label></td>
							</tr>
						</TABLE>
					</td>
				</tr>
				<tr id="add_line">
					<td align="center" height="100%"><asp:button id="btnAdauga" onmouseover="MouseOverButton(this)" onmouseout="MouseOutButton(this)"
							runat="server" CssClass="ButtonStyle" Text="  Salveaza date  "></asp:button></td>
				</tr>
				<tr id="edit_line" style="DISPLAY: none">
					<td align="center" height="100%"><asp:button id="btnModificaDate" onmouseover="MouseOverButton(this)" onmouseout="MouseOutButton(this)"
							runat="server" CssClass="ButtonStyle" Text="  Modifica date  "></asp:button>&nbsp;
						<asp:button id="btnStergeDate" onmouseover="MouseOverButton(this)" onmouseout="MouseOutButton(this)"
							runat="server" CssClass="ButtonStyle" Text="  Sterge date  " CausesValidation="false"></asp:button>&nbsp;
						<input class="ButtonStyle" id="btnInapoi" onmouseover="MouseOverButton(this)" onclick="BackToList()"
							onmouseout="MouseOutButton(this)" type="button" value="  Inapoi  ">
					</td>
				</tr>
				<tr>
					<td style="HEIGHT: 80px" align="center"><asp:validationsummary id="vldSummary" runat="server" ShowMessageBox="True" ShowSummary="False"></asp:validationsummary><asp:textbox id="txtIdCriteriu" runat="server"></asp:textbox></td>
				</tr>
			</TABLE>
			<asp:literal id="errorLit" runat="server"></asp:literal></td>
	</tr>
</table>
<script>

	eval(ctrlID + "_tab1.click()");
</script>
