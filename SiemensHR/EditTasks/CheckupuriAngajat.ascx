<%@ Control Language="c#" AutoEventWireup="false" Codebehind="CheckupuriAngajat.ascx.cs" Inherits="SiemensHR.CheckupuriAngajat" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>
<script>var arTabs = new Array('tableCheckup', 'tableAdaugaCheckup');

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
		eval(ctrlID + "_Form1." + ctrlID + "_CheckupID.value = '';");
		eval(ctrlID + "_Form1." + ctrlID + "_txtNecesarInstruire.value = '';");
		eval(ctrlID + "_Form1." + ctrlID + "_lstResponsabil.value = '';");		
		eval(ctrlID + "_Form1." + ctrlID + "_txtDataEfectuarii.value = '';");
		eval(ctrlID + "_Form1." + ctrlID + "_txtDataUrmatorului.value = '';");
		aux="<b>Nu exista fisier atasat acestui checkup !</b>";
		document.getElementById(ctrlID + "_CheckupFile").innerHTML =aux; 
			
		editButtonsLine.style.display = "none";
		addButtonsLine.style.display = "";
		tdTextLine.innerText = "Adauga checkup";
	}
	
	function SelectCheckup(AngajatID,CheckupID,necesarInstruire,dataEfectuarii,responsabilID,dataUrmatorului,checkupFile)
	{
		tableCheckup.style.display = "none";
		editButtonsLine.style.display = "";
		addButtonsLine.style.display = "none";
		tableAdaugaCheckup.style.display = "";
		
		eval(ctrlID + "_Form1." + ctrlID + "_CheckupID.value = CheckupID;");
		eval(ctrlID + "_Form1." + ctrlID + "_txtNecesarInstruire.value = necesarInstruire;");
		eval(ctrlID + "_Form1." + ctrlID + "_lstResponsabil.value = responsabilID;");		
		eval(ctrlID + "_Form1." + ctrlID + "_txtDataEfectuarii.value = dataEfectuarii;");
		eval(ctrlID + "_Form1." + ctrlID + "_txtDataUrmatorului.value = dataUrmatorului;");
		
		//daca nu mai exista angajatul in lista atunci este selectata optiunea "Nu este angajat al firmei"
		if (eval(ctrlID + "_Form1." + ctrlID + "_lstResponsabil.value == '';"))
		{
			eval(ctrlID + "_Form1." + ctrlID + "_lstResponsabil.value = -1;")
		}
		
		var aux ="";
		
		if (checkupFile.length==0 || checkupFile == null) 
			aux="<b>Nu exista fisier atasat acestui checkup !</b>"; 
		else
		{
			if (TipUtilizator == 'Recrutor')
			{
				aux = '<a target=_blank href=\"../Checkup/'+AngajatID+'/Checkup_'+CheckupID+'_'+checkupFile+'\">'+'<img src=\"../utils/ShowIcon.aspx?AngajatID='+AngajatID+'&CheckupID='+CheckupID+'&file='+checkupFile+'\" border=0>&nbsp;'+checkupFile+'</a>';
			}
			else
			{
				aux = '<a target=_blank href=\"Checkup/'+AngajatID+'/Checkup_'+CheckupID+'_'+checkupFile+'\">'+'<img src=\"utils/ShowIcon.aspx?AngajatID='+AngajatID+'&CheckupID='+CheckupID+'&file='+checkupFile+'\" border=0>&nbsp;'+checkupFile+'</a>';
			}
		}
		document.getElementById(ctrlID + "_CheckupFile").innerHTML =aux;
		tdTextLine.innerText = "Editeaza checkup";
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
		<td class="tabBackground" id="tableCheckup" vAlign="top" align="center" colSpan="2"
			height="100%"><asp:table id="listTable" runat="server"></asp:table><br>
		</td>
		<td class="tabBackground" id="tableAdaugaCheckup" align="center" colSpan="2">
			<TABLE height="200" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
				<tr>
					<td>
						<TABLE height="100%" cellSpacing="1" cellPadding="0" width="100%" align="center" border="0">
							<tr>
								<td class="HeaderGreenBold" id="tdTextLine" align="center" colSpan="2">Adauga 
									checkup:</td>
							</tr>
							<TR>
								<TD class="NormalGreenBold" style="HEIGHT: 40px">Descriere:</TD>
								<TD class="NormalGreenBold" style="HEIGHT: 40px"><asp:textbox id="txtNecesarInstruire" runat="server" Width="300px" TextMode="MultiLine" Height="48px"></asp:textbox><asp:regularexpressionvalidator id="RegularExpressionValidator1" runat="server" ErrorMessage="Descrierea nu poate sa contina caractere invalide: <>()';&quot;\enter"
										ControlToValidate="txtNecesarInstruire" ValidationExpression="^[^>|(|)|<|'|&quot;|;|\\|\\\n]*$" CssClass="AlertRedBold"><</asp:regularexpressionvalidator><span class="CommentRedBold"></span></TD>
							</TR>
							<tr>
								<td class="GreenSeparator" colSpan="2"><IMG height="1" src="../images/1x1.gif"></td>
							</tr>
							<TR>
								<TD class="NormalGreenBold">Responsabil:</TD>
								<TD class="NormalGreenBold"><asp:dropdownlist id="lstResponsabil" runat="server" Width="280px" CssClass="SelectStyle"></asp:dropdownlist><SPAN class="CommentRedBold">*</SPAN>
									<asp:requiredfieldvalidator id="Requiredfieldvalidator1" runat="server" ErrorMessage="Completati responsabilul!"
										ControlToValidate="lstResponsabil" CssClass="AlertRedBold"><</asp:requiredfieldvalidator></TD>
							</TR>
							<tr>
								<td class="GreenSeparator" colSpan="2"><IMG height="1" src="../images/1x1.gif"></td>
							</tr>
							<TR>
								<TD class="NormalGreenBold">Data efectuarii:</TD>
								<TD class="NormalGreenBold"><asp:textbox id="txtDataEfectuarii" style="CURSOR: hand; TEXT-ALIGN: center" onclick="if (TipUtilizator == 'Recrutor') { ShowCalendar(this,'../'); } else { ShowCalendar(this,''); }"
										runat="server" CssClass="NormalEditBoxuri" size="10"></asp:textbox></TD>
							</TR>
							<tr>
								<td class="GreenSeparator" colSpan="2"><IMG height="1" src="../images/1x1.gif"></td>
							</tr>
							<TR>
								<TD class="NormalGreenBold">Data&nbsp;urmatorului:</TD>
								<TD class="NormalGreenBold"><asp:textbox id="txtDataUrmatorului" style="CURSOR: hand; TEXT-ALIGN: center" onclick="if (TipUtilizator == 'Recrutor') { ShowCalendar(this,'../'); } else { ShowCalendar(this,''); }"
										runat="server" CssClass="NormalEditBoxuri" size="10"></asp:textbox><INPUT id="CheckupID" type="hidden" name="Hidden1" runat="server">
									<span class="CommentRedBold">*</span><asp:requiredfieldvalidator id="requiredDataEnd" runat="server" ErrorMessage="Completati data de sfarsit a activitati!"
										ControlToValidate="txtDataUrmatorului" CssClass="AlertRedBold"><</asp:requiredfieldvalidator></TD>
							</TR>
							<tr>
								<td class="GreenSeparator" colSpan="2"><IMG height="1" src="../images/1x1.gif"></td>
							</tr>
							<TR>
								<TD class="NormalGreenBold" style="WIDTH: 150px">Fisier Checkup Curent :</TD>
								<TD class="NormalGreenBold" id="CheckupFile" vAlign="middle" runat="server"></TD>
							</TR>
							<tr>
								<td class="GreenSeparator" colSpan="2"><IMG height="1" src="../images/1x1.gif"></td>
							</tr>
							<TR>
								<TD class="NormalGreenBold">Check - up (.xsl)&nbsp;</TD>
								<TD class="NormalGreenBold"><INPUT id="fileCheckup" style="WIDTH: 300px; HEIGHT: 22px" type="file" size="23" name="File1"
										runat="server">
									<asp:regularexpressionvalidator id="regularCaleFisier" runat="server" CssClass="AlertRedBold" ValidationExpression="^[^>|(|)|<|'|&quot;|;]*$"
										ControlToValidate="fileCheckup" ErrorMessage="Specificati corect calea fisierului!"><</asp:regularexpressionvalidator></TD>
							</TR>
						</TABLE>
					</td>
				</tr>
				<tr id="addButtonsLine">
					<td align="center" height="100%">
                        <asp:Button ID="btnAdauga" onmouseover="MouseOverButton(this)" onmouseout="MouseOutButton(this)"
                            runat="server" CssClass="ButtonStyle" Text="  Salveaza date   "></asp:Button></td>
				<tr id="editButtonsLine">
					<td align="center" height="24" style="HEIGHT: 24px"><asp:button id="btnModifica" onmouseover="MouseOverButton(this)" onmouseout="MouseOutButton(this)"
							runat="server" CssClass="ButtonStyle" Text="  Modifica date  "></asp:button>&nbsp;
						<asp:button id="btnSterge" onmouseover="MouseOverButton(this)" onmouseout="MouseOutButton(this)"
							runat="server" CssClass="ButtonStyle" Text="  Sterge date  " CausesValidation="false"></asp:button>&nbsp;
						<input class="ButtonStyle" id="btnInapoi" onmouseover="MouseOverButton(this)" onclick="tableAdaugaCheckup.style.display='none';tableCheckup.style.display=''"
							onmouseout="MouseOutButton(this)" type="button" value="  Inapoi  ">
					</td>
				</tr>
				<tr>
					<td align="center"><asp:validationsummary id="ValidationSummary1" runat="server" CssClass="AlertRedBold" ShowSummary="False"
							ShowMessageBox="True"></asp:validationsummary></td>
				</tr>
				<tr>
					<td class="CommentRedBold">* - Campuri obligatorii</td>
				</tr>
			</TABLE>
		</td>
	</tr>
</table>
<script>
	sp3FormIDfix();
	eval(ctrlID + "_tab1.click()");

</script>
