<%@ Control Language="c#" AutoEventWireup="false" Codebehind="IstoricTraininguri.ascx.cs" Inherits="SiemensHR.IstoricTraininguri" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>
<script language="javascript" src="../js/jsCode.js"></script>
<script>
var arTabs = new Array('tableIstoricTraining', 'tableAdaugaTraining');

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
		
		if (index == 1)
		{
			eval(ctrlID + "_Form1." + ctrlID + "_tipTraining.value = '';");
			eval(ctrlID + "_Form1." + ctrlID + "_IstoricTrainingID.value = '';");

			eval(ctrlID + "_Form1." + ctrlID + "_lstTraining.value = '';");
			eval(ctrlID + "_Form1." + ctrlID + "_lstTraining2.value = '';");
			
			eval(ctrlID + "_Form1." + ctrlID + "_txtDataStart.value = '';");
			eval(ctrlID + "_Form1." + ctrlID + "_txtDataEnd.value = '';");
			
			editButtonsLine.style.display = "none";
			addButtonsLine.style.display = "";
			tdTextLine.innerText = "Adauga training";
		}
		
		eval(ctrlID + "_Form1." + ctrlID + "_tipTraining.selectedIndex = '0'");
		eval(ctrlID + "_Form1." + ctrlID + "_lstTraining.selectedIndex = '0'");
		eval(ctrlID + "_Form1." + ctrlID + "_lstTraining2.selectedIndex = '0'");
	}
	
	function SelectTraining( istoricTrainingID,tipTrainingBoolean,trainingID, dataStart,dataEnd, angajatID)
	{
		var tipTraining = 0;
		if (tipTrainingBoolean=="True") tipTraining=1; 
		
		tableIstoricTraining.style.display = "none";
		editButtonsLine.style.display = "";
		addButtonsLine.style.display = "none";
		tableAdaugaTraining.style.display = "";
		
		SelectTipTraining(tipTraining,true);
		
		eval(ctrlID + "_Form1." + ctrlID + "_tipTraining.value = tipTraining;");
		eval(ctrlID + "_Form1." + ctrlID + "_IstoricTrainingID.value = istoricTrainingID;");
		
		
		if (tipTraining==1)
			eval(ctrlID + "_Form1." + ctrlID + "_lstTraining.value = trainingID;");
		else
			eval(ctrlID + "_Form1." + ctrlID + "_lstTraining2.value = trainingID;");
		
		eval(ctrlID + "_Form1." + ctrlID + "_txtDataStart.value = dataStart;");
		eval(ctrlID + "_Form1." + ctrlID + "_txtDataEnd.value = dataEnd;");
		tdTextLine.innerText = "Editeaza training";	
		
	}
	function SelectTipTraining (tip,is_edit)
	{
	
		if (!is_edit) 
		{
			if (tip==1)
			{
				eval(ctrlID + "_Form1." + ctrlID + "_lstTraining.style.display = ''");
				eval(ctrlID + "_Form1." + ctrlID + "_lstTraining2.style.display = 'none'");
			}
	
			else
			{
				eval(ctrlID + "_Form1." + ctrlID + "_lstTraining.style.display = 'none'");
				eval(ctrlID + "_Form1." + ctrlID + "_lstTraining2.style.display = ''");
			}
		} 
		else
		{
			if (tip==1)
	
			{
				eval(ctrlID + "_Form1." + ctrlID + "_lstTraining.style.display = ''");
				eval(ctrlID + "_Form1." + ctrlID + "_lstTraining2.style.display = 'none'");
			}
	
			else
			{
				eval(ctrlID + "_Form1." + ctrlID + "_lstTraining.style.display = 'none'");
				eval(ctrlID + "_Form1." + ctrlID + "_lstTraining2.style.display = ''");
			}
		}
		eval(ctrlID + "_Form1." + ctrlID + "_lstTraining.selectedIndex = '0'");
		eval(ctrlID + "_Form1." + ctrlID + "_lstTraining2.selectedIndex = '0'");
	}

//Calculeaza coordonata - x a coltului stanga sus a unei ferestre noi pt a fi pozitionata pe centru
function Calculate_x_coordinate( window_width)
{
	return (screen.width - window_width)/2;
}

//Calculeaza coordonata - y a coltului stanga sus a unei ferestre noi pt a fi pozitionata pe centru
function Calculate_y_coordinate( window_height)
{
	return (screen.height - window_height)/2;
}

//Deschide o fereastra noua in care se va incarca fereastra de admin pt invaliditati, titluri, studii sau categorii
function OpenAdminWindow( typeOfAdminPage, str)
{
	
	switch (typeOfAdminPage)
	{
		case "traininguri":
			h = Calculate_y_coordinate( 400);
			w = Calculate_x_coordinate( 600);
			oNewWindow = window.open(str+"Administrare/AdminTraininguriIstoricTraininguri.aspx",null,"height=600,width=800, top=" + h + ",left=" + w + " ,status=yes,toolbar=no,menubar=no,location=no,scrollbars=yes");
			oNewWindow.focus();
			break;
		default:
			break;
	}
}

//Sterge toate intrarile din combo-ul cu traininguri interne si cel cu traininguri externe
function DeleteTraininguriCombo()
{
	var traininguriCombo = document.getElementById( ctrlID + '_lstTraining' ); 
	while( traininguriCombo.length > 0 )
	{
		traininguriCombo.remove( traininguriCombo.selectedIndex );
	}
	
	var traininguriCombo2 = document.getElementById( ctrlID + '_lstTraining2' ); 
	while( traininguriCombo2.length > 0 )
	{
		traininguriCombo2.remove( traininguriCombo2.selectedIndex );
	}
}

//Adauga o intrare la la combo-ul cu traininguri interne
function FillTrainingCombo( trainingText, trainingValoare)
{
	var traininguriCombo = document.getElementById( ctrlID + '_lstTraining' );
	var o = new Option();
	o.text = trainingText;
	o.value = trainingValoare;
	traininguriCombo.add( o, 0 ); 
}	

//Adauga o intrare la la combo-ul cu traininguri externe
function FillTrainingCombo2( trainingText, trainingValoare)
{
	var traininguriCombo2 = document.getElementById( ctrlID + '_lstTraining2' );
	var o = new Option();
	o.text = trainingText;
	o.value = trainingValoare;
	traininguriCombo2.add( o, 0 ); 
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
		<td id="tableIstoricTraining" vAlign="top" align="center" colSpan="2" height="100%"
			class="tabBackground">
			<br>
			<font class="BigBlueBold"><b>Training intern </b></font>
			<br>
			<br>
			<asp:table id="listTable" runat="server"></asp:table><br>
			<br>
			<font class="BigBlueBold"><b>Training extern </b></font>
			<br>
			<br>
			<asp:table id="listTable2" runat="server"></asp:table>
		</td>
		<td id="tableAdaugaTraining" align="center" colSpan="2">
			<TABLE cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
				<tr>
					<td class="tabBackground">
						<TABLE height="100%" cellSpacing="1" cellPadding="0" width="100%" align="center" border="0">
							<tr>
								<td class="HeaderGreenBold" id="tdTextLine" align="center" colSpan="2">Adauga 
									training:</td>
							</tr>
							<TR>
								<TD class="NormalGreenBold">Tip training:</TD>
								<TD class="NormalGreenBold"><asp:dropdownlist id="tipTraining" runat="server" Width="300px" CssClass="SelectStyle">
										<asp:ListItem Value="1">Intern</asp:ListItem>
										<asp:ListItem Value="0">Extern</asp:ListItem>
									</asp:dropdownlist>
									<asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" ControlToValidate="tipTraining" ErrorMessage="Selectati tipul training-ului!"
										CssClass="AlertRedBold"><</asp:RequiredFieldValidator></TD>
							</TR>
							<tr>
								<td class="GreenSeparator" colSpan="2"><IMG height="1" src="../images/1x1.gif"></td>
							</tr>
							<TR>
								<TD class="NormalGreenBold">Training:</TD>
								<TD class="NormalGreenBold">
									<asp:dropdownlist id="lstTraining" runat="server" Width="300px" CssClass="SelectStyle"></asp:dropdownlist>
									<asp:dropdownlist id="lstTraining2" runat="server" Width="300px" CssClass="SelectStyle"></asp:dropdownlist>
									<INPUT onclick="javascript:if (TipUtilizator == 'Recrutor') { OpenAdminWindow('traininguri','../'); } else { OpenAdminWindow('traininguri',''); } " type="button" value="..." id="Button1"
										name="Button1" runat="server">
								</TD>
							</TR>
							<tr>
								<td class="GreenSeparator" colSpan="2"><IMG height="1" src="../images/1x1.gif"></td>
							</tr>
							<TR>
								<TD class="NormalGreenBold">Data inceput activitate:</TD>
								<TD class="NormalGreenBold"><asp:textbox id="txtDataStart" style="CURSOR: hand; TEXT-ALIGN: center" onclick="if (TipUtilizator == 'Recrutor') { ShowCalendar(this,'../'); } else { ShowCalendar(this,''); }"
										runat="server" CssClass="NormalEditBoxuri" size="10" ReadOnly="True"></asp:textbox><asp:requiredfieldvalidator id="requiredDataStart" runat="server" ErrorMessage="Completati data de incepere a activitati!"
										ControlToValidate="txtDataStart" CssClass="AlertRedBold"><</asp:requiredfieldvalidator></TD>
							</TR>
							<tr>
								<td class="GreenSeparator" colSpan="2"><IMG height="1" src="../images/1x1.gif"></td>
							</tr>
							<TR>
								<TD class="NormalGreenBold">Data&nbsp;sfarsit activitate:</TD>
								<TD class="NormalGreenBold"><asp:textbox id="txtDataEnd" style="CURSOR: hand; TEXT-ALIGN: center" onclick="if (TipUtilizator == 'Recrutor') { ShowCalendar(this,'../'); } else { ShowCalendar(this,''); }"
										runat="server" CssClass="NormalEditBoxuri" size="10" ReadOnly="True"></asp:textbox><INPUT id="IstoricTrainingID" type="hidden" name="Hidden1" runat="server"><asp:requiredfieldvalidator id="requiredDataEnd" runat="server" ErrorMessage="Completati data de sfarsit a activitati!"
										ControlToValidate="txtDataEnd" CssClass="AlertRedBold"><</asp:requiredfieldvalidator></TD>
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
						<input id="btnInapoi" type="button" onclick="tableAdaugaTraining.style.display='none';tableIstoricTraining.style.display=''"
							onmouseover="MouseOverButton(this)" onmouseout="MouseOutButton(this)" class="ButtonStyle"
							value="  Inapoi  ">
					</td>
				</tr>
				<tr>
					<td align="center"><asp:validationsummary id="Validationsummary2" runat="server" CssClass="AlertRedBold" ShowMessageBox="True"
							ShowSummary="False"></asp:validationsummary></td>
				</tr>
			</TABLE>
		</td>
	</tr>
</table>
<script>
	sp3FormIDfix();
	
	eval(ctrlID + "_tab1.click()");
	SelectTipTraining(1);
</script>
