<%@ Control Language="c#" AutoEventWireup="false" Codebehind="ReferinteAngajat.ascx.cs" Inherits="SiemensHR.ReferinteAngajat" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>
<script language="javascript" src="../js/jsCode.js"></script>
<script>
var arTabs = new Array('tableReferinta', 'tableAdaugaReferinta');

	function SelectTab(index)
	{
		for(i=0; i<arTabs.length; i++)
		{
			if (i==index)
			{
				eval(arTabs[i] + ".style.display=''");
				eval(ctrlID + "_tab"+ (i+1)+ ".className='tabActive'");
					
			}
			else
			{
				eval(ctrlID + "_tab"+ (i+1) + ".className='tab'");
				eval(ctrlID + "_tab"+ (i+1) + ".style.backgroundColor='#7b8fc2'");
				eval(arTabs[i] + ".style.display='none'");
			}
		}
		
		if( index == 1 )
			ClearFields();
			
		editButtonsLine.style.display = "none";
		addButtonsLine.style.display = "";
		tdTextLine.innerText = "Adauga referinta";
	}
	
	function SelectReferinta(ReferintaID,Titlu,Data,Descriere)
	{
		tableReferinta.style.display = "none";
		editButtonsLine.style.display = "";
		addButtonsLine.style.display = "none";
		tableAdaugaReferinta.style.display = "";
		
		eval(ctrlID + "_Form1." + ctrlID + "_ReferintaID.value = ReferintaID;");
		eval(ctrlID + "_Form1." + ctrlID + "_txtTitlu.value = Titlu;");
		eval(ctrlID + "_Form1." + ctrlID + "_txtData.value = Data;");
		eval(ctrlID + "_Form1." + ctrlID + "_txtDescriere.value = Descriere;");
		tdTextLine.innerText = "Editeaza referinta";		
	}
	
	// Autor:		Anca Holostencu
	// Descriere:	Curata campurile din partea de adaugare
	function ClearFields()
	{
		eval(ctrlID + "_Form1." + ctrlID + "_txtTitlu.value = '';");
		eval(ctrlID + "_Form1." + ctrlID + "_txtData.value = '';");
		eval(ctrlID + "_Form1." + ctrlID + "_txtDescriere.value = '';");
	}
</script>
<table cellSpacing="0" cellPadding="0" width="600" align="center" border="0">
	<tr>
		<td colSpan="2"><asp:literal id="litError" runat="server"></asp:literal></td>
	</tr>
	<tr>
		<td colSpan="2"><IMG height="10" src="../images/1x1.gif"></td>
	</tr>
	<tr>
		<td colSpan="2"><asp:table id="tableTabs" runat="server"></asp:table></td>
	</tr>
	<tr>
		<td class="tabBackground" id="tableReferinta" vAlign="top" align="center" colSpan="2"
			height="100%"><asp:table id="listTable" runat="server"></asp:table><br>
		</td>
		<td class="tabBackground" id="tableAdaugaReferinta" align="center" colSpan="2">
			<TABLE height="200" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
				<tr>
					<td>
						<TABLE height="100%" cellSpacing="1" cellPadding="0" width="100%" align="center" border="0">
							<tr>
								<td class="HeaderGreenBold" id="tdTextLine" align="center" colSpan="2">Adauga 
									referinta:</td>
							</tr>
							<TR>
								<TD class="NormalGreenBold">Titlu:</TD>
								<TD class="NormalGreenBold">
									<asp:TextBox id="txtTitlu" runat="server" Width="300px"></asp:TextBox><asp:requiredfieldvalidator id="NecesarInstruireValidator" runat="server" ControlToValidate="txtTitlu" ErrorMessage="Completati campul titlu !"
										CssClass="AlertRedBold"><</asp:requiredfieldvalidator>
									<asp:regularexpressionvalidator id="Regularexpressionvalidator2" runat="server" ErrorMessage="Titlul nu poate sa contina caractere invalide: <>()';&quot;\"
										ControlToValidate="txtTitlu" ValidationExpression="^[^>|(|)|<|'|&quot;|;|\\]*$" CssClass="AlertRedBold"><</asp:regularexpressionvalidator></TD>
							</TR>
							<tr>
								<td class="GreenSeparator" colSpan="2"><IMG height="1" src="../images/1x1.gif"></td>
							</tr>
							<TR>
								<TD class="NormalGreenBold">Data</TD>
								<TD class="NormalGreenBold"><asp:textbox id="txtData" style="CURSOR: hand; TEXT-ALIGN: center" onclick="if (TipUtilizator == 'Recrutor') { ShowCalendar(this,'../'); } else { ShowCalendar(this,''); }"
										runat="server" CssClass="NormalEditBoxuri" size="10"></asp:textbox><asp:requiredfieldvalidator id="requiredDataStart" runat="server" ControlToValidate="txtData" ErrorMessage="Completati campul data !"
										CssClass="AlertRedBold"><</asp:requiredfieldvalidator></TD>
							</TR>
							<tr>
								<td class="GreenSeparator" colSpan="2"><IMG height="1" src="../images/1x1.gif"></td>
							</tr>
							<TR>
								<TD class="NormalGreenBold">Descriere:</TD>
								<TD class="NormalGreenBold">
									<asp:TextBox id="txtDescriere" runat="server" TextMode="MultiLine" Width="300px" Rows="8"></asp:TextBox>
									<asp:regularexpressionvalidator id="RegularExpressionValidator1" runat="server" ErrorMessage="Descrierea nu poate sa contina caractere invalide: <>()';&quot;\"
										ControlToValidate="txtDescriere" ValidationExpression="^[^>|(|)|<|'|&quot;|;|\\]*$" CssClass="AlertRedBold"><</asp:regularexpressionvalidator></TD>
							</TR>
							<TR>
								<TD class="NormalGreenBold">
									<input id="ReferintaID" type="hidden" runat="server" NAME="ReferintaID"></TD>
							</TR>
						</TABLE>
					</td>
				</tr>
				<tr id="addButtonsLine">
					<td align="center" height="100%"><asp:button id="btnAdauga" onmouseover="MouseOverButton(this)" onmouseout="MouseOutButton(this)"
							runat="server" CssClass="ButtonStyle" Text="  Salveaza date   "></asp:button></td>
				<tr id="editButtonsLine">
					<td align="center" height="24" style="HEIGHT: 24px"><asp:button id="btnModifica" onmouseover="MouseOverButton(this)" onmouseout="MouseOutButton(this)"
							runat="server" CssClass="ButtonStyle" Text="  Modifica date  "></asp:button>&nbsp;
						<asp:button id="btnSterge" onmouseover="MouseOverButton(this)" onmouseout="MouseOutButton(this)"
							runat="server" CssClass="ButtonStyle" Text="  Sterge date  " CausesValidation="false"></asp:button>&nbsp;
						<input id="btnInapoi" type="button" onclick="tableAdaugaReferinta.style.display='none';tableReferinta.style.display=''"
							onmouseover="MouseOverButton(this)" onmouseout="MouseOutButton(this)" class="ButtonStyle"
							value="  Inapoi  ">
					</td>
				</tr>
				<tr>
					<td align="center"><asp:validationsummary id="ValidationSummary1" runat="server" CssClass="AlertRedBold" ShowMessageBox="True"
							ShowSummary="False"></asp:validationsummary></td>
				</tr>
			</TABLE>
		</td>
	</tr>
</table>
<script>
	sp3FormIDfix();
	eval(ctrlID + "_tab1.click()");

</script>
