<%@ Control Language="c#" AutoEventWireup="false" CodeBehind="IstoricSuspendariCIM.ascx.cs" Inherits="SiemensHR.EditTasks.IstoricSuspendariCIM"%>

<script language="javascript" src="InterfataSalarii/Module/Pontaj/js/jsCode.js"></script>
<script language="javascript" src="InterfataSalarii/Module/Pontaj/js/Intervale.js"></script>
<script>
var arTabs = new Array('tableIstoricSuspendariCIM', 'tableAdaugaSuspendareCIM');

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
				//eval(ctrlID + "_Form1." + ctrlID + "_txtDataStart.value = '';");
					
			}
			else
			{
				eval(ctrlID + "_tab"+ (i+1) + ".className='tab'");
				eval(ctrlID + "_tab"+ (i+1) + ".style.backgroundColor='#7b8fc2'");
				eval(arTabs[i] + ".style.display='none'");
			}
		}
		eval( ctrlID+"_Form1."+ctrlID+"_txtDataStart.disabled = false;" );
		//document.getElementById("txtDataStart').disabled = false;
	
		eval( ctrlID+"_Form1."+ctrlID+"_txtDataStart.value = '';" );
		eval( ctrlID+"_Form1."+ctrlID+"_txtDataEnd.value = '';" );
		eval( ctrlID+"_Form1."+ctrlID+"_txtObservatii.value = '';" );
		eval( ctrlID+"_Form1."+ctrlID+"_txtIntrerupereID.value = -1;" );	
		titluTab.innerText = "Adaugare intrerupere CIM";
	}
	
	function SelectSuspendareCIM( angajatId, intervalID, dataStart, dataEnd, observatii)
	{
		var okDataStart = (CompareLunaAn(dataStart,LunaActivaDataStart));
		var okDataEnd = (CompareLunaAn(dataEnd,LunaActivaDataStart));
		
		if ((okDataEnd == 0) || (okDataEnd == 1)) //in aceeasi luna si an
		{
			tableIstoricSuspendariCIM.style.display = "none";
			tableAdaugaSuspendareCIM.style.display = "";
			edit_line.style.display = "";
			add_line.style.display = "none";
			titluTab.innerText = "Editare intrerupere CIM";
		
			eval( ctrlID+"_Form1."+ctrlID+"_txtDataStart.value = dataStart;" );
			eval( ctrlID+"_Form1."+ctrlID+"_txtDataEnd.value = dataEnd;" );
			eval( ctrlID+"_Form1."+ctrlID+"_txtObservatii.value = observatii;" );
			eval( ctrlID+"_Form1."+ctrlID+"_txtIntrerupereID.value = intervalID;" );	
			document.getElementById(DateStartID).value=document.getElementById(txtDataStartID).value;
			document.getElementById(DateEndID).value=document.getElementById(txtDataEndID).value;
			if (okDataStart == 2)
			{
				eval( ctrlID+"_Form1."+ctrlID+"_txtDataStart.disabled = true;" );
				//document.getElementById('txtDataStart').disabled = true;
			}
			else
				eval( ctrlID+"_Form1."+ctrlID+"_txtDataStart.disabled = false;" );	
				//document.getElementById('txtDataStart').disabled = false;
	
		}	
	}
	
	function BackToList()
	{
		tableAdaugaSuspendareCIM.style.display='none';
		tableIstoricSuspendariCIM.style.display='';
		edit_line.style.display = "none";
		add_line.style.display = "";
	}
	
	function isDate(dataVerif)   
	{		
		//alert(dataVerif);
		var sir = dataVerif.split('.');
		//alert(sir[0]); alert(sir[1]); alert(sir[2]);
		var d = parseInt(sir[0]);
		var m = parseInt(sir[1]);
		var y = parseInt(sir[2]);
		//alert(d); alert(m); alert(y);
		var date = new Date(y,m-1,d); 
		//alert(date.getFullYear());alert(date.getMonth()+1);alert(date.getDate());
		var convertedDate =  "" + date.getFullYear() + (date.getMonth()+1) + date.getDate();
		var givenDate = "" + y + m + d;
		//alert(convertedDate);
		//alert(givenDate);
		return (givenDate == convertedDate);   
	}
</script>
<table cellSpacing="0" cellPadding="0" width="600" align="center" border="0" valign="top">
	<tr>
		<td><asp:literal id="litError" runat="server"></asp:literal></td>
	</tr>
	<tr>
		<td><IMG height="10" src="../images/1x1.gif"></td>
	</tr>
	<tr>
		<td><asp:table id="tableTabs" runat="server"></asp:table></td>
	</tr>
	<tr>
		<td id="tableIstoricSuspendariCIM" vAlign="top" align="center" height="503"><asp:table id="listTable" runat="server"></asp:table></td>
		<td class="tabBackground" id="tableAdaugaSuspendareCIM" vAlign="top" align="center">
			<TABLE id="Table2" cellSpacing="1" cellPadding="0" width="100%" align="center" border="0">
				<TR>
					<TD class="HeaderGreenBold" id="titluTab" style="HEIGHT: 3px" align="center" colSpan="2"></TD>
				</TR>
				<TR>
					<TD class="NormalGreenBold" style="HEIGHT: 1px">Data de inceput:</TD>
					<TD style="HEIGHT: 1px"><asp:textbox id="txtDataStart" runat="server" CssClass="NormalEditBoxuri" Width="150px" style="CURSOR: hand"
							onclick="ShowCalendar(this,'')" ReadOnly="False"></asp:textbox><SPAN class="CommentRedBold">*
							<asp:requiredfieldvalidator id="Requiredfieldvalidator1" runat="server" CssClass="AlertRedBold" ControlToValidate="txtDataStart"
								ErrorMessage="Completati data de inceput!"><</asp:requiredfieldvalidator></SPAN></TD>
				</TR>
				<tr>
					<td class="GreenSeparator" colSpan="4"><IMG height="1" src="images/1x1.gif"></td>
				</tr>
				<TR>
					<TD class="NormalGreenBold" style="HEIGHT: 4px">Data de sfarsit:</TD>
					<TD style="HEIGHT: 4px"><asp:textbox id="txtDataEnd" runat="server" CssClass="NormalEditBoxuri" Width="150px" style="CURSOR: hand"
							onclick="ShowCalendar(this,'')" ReadOnly="False"></asp:textbox><SPAN class="CommentRedBold">*
							<asp:requiredfieldvalidator id="Requiredfieldvalidator2" runat="server" CssClass="AlertRedBold" ControlToValidate="txtDataEnd"
								ErrorMessage="Completati data de sfarsit!"><</asp:requiredfieldvalidator></SPAN></TD>
				</TR>
				<tr>
					<td class="GreenSeparator" colSpan="4"><IMG height="1" src="images/1x1.gif"></td>
				</tr>
				<TR>
					<TD class="NormalGreenBold" style="HEIGHT: 4px">Observatii:</TD>
					<TD style="HEIGHT: 4px"><asp:textbox id="txtObservatii" runat="server" CssClass="NormalEditBoxuri" Width="303px" MaxLength="50"
							TextMode="MultiLine" Height="75px"></asp:textbox><SPAN class="CommentRedBold"><asp:regularexpressionvalidator id="vldRegExprDescriere" runat="server" CssClass="AlertRedBold" ControlToValidate="txtObservatii"
								ErrorMessage="Eliberat de nu poate contine caractere invalide: : <>()';&quot;\" ValidationExpression="^[^>|(|)|<|'|&quot;|;|\\]*$"><</asp:regularexpressionvalidator></SPAN></TD>
				</TR>
			</TABLE>
			<TABLE cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
				<tr id="add_line">
					<td align="center"><asp:button id="btnAdaugaSuspendare" onmouseover="MouseOverButton(this)" onmouseout="MouseOutButton(this)"
							runat="server" CssClass="ButtonStyle" Text="  Salveaza date  "></asp:button></td>
				</tr>
				<TR style="DISPLAY: none">
					<TD align="center"></TD>
				</TR>
				<tr id="edit_line" style="DISPLAY: none">
					<td align="center">
						<P class="CommentRedBold"><asp:button id="btnModificaDate" onmouseover="MouseOverButton(this)" onmouseout="MouseOutButton(this)"
								runat="server" CssClass="ButtonStyle" Text="  Modifica date  "></asp:button>&nbsp;&nbsp;&nbsp;&nbsp;
							<asp:button id="btnStergeDate" onmouseover="MouseOverButton(this)" onmouseout="MouseOutButton(this)"
								runat="server" CssClass="ButtonStyle" Text="  Sterge date  " CausesValidation="false"></asp:button>&nbsp;&nbsp;&nbsp;
							<input class="ButtonStyle" id="btnInapoi" onmouseover="MouseOverButton(this)" onclick="BackToList()"
								onmouseout="MouseOutButton(this)" type="button" value="  Inapoi  ">
						</P>
						<P class="CommentRedBold">*In cazul unei stergeri, daca sunt intervale care pornesc 
							dintr-o luna anterioara, nu se va putea sterge decat acea perioada din interval 
							care incepe in luna activa.
						</P>
					</td>
				</tr>
				<tr style="DISPLAY: none">
					<td align="center"><INPUT id="DateStart" type="text" maxLength="10" name="DateStart" runat="server">
						<INPUT id="DateEnd" type="text" maxLength="10" name="DateEnd" runat="server"> <input id="txtIntrerupereID" type="hidden" value="-1" name="txtCarteIdentitateIDHidden"
							runat="server">
						<asp:validationsummary id="ValidationSummary1" runat="server" CssClass="AlertRedBold" ShowMessageBox="True"
							ShowSummary="False"></asp:validationsummary></td>
				</tr>
			</TABLE>
		</td>
	</tr>
</table>
<SCRIPT>
	
	sp3FormIDfix();
	eval(ctrlID + "_tab1.click()");
</SCRIPT>
