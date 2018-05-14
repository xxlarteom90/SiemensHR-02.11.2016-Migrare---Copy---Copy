<%@ Control Language="c#" AutoEventWireup="false" Codebehind="IstoricFunctii.ascx.cs" Inherits="SiemensHR.EditTasks.IstoricFunctii" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>
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
				eval(ctrlID + "_Form1." + ctrlID + "_txtDataStart.value = '';");
					
			}
			else
			{
				eval(ctrlID + "_tab"+ (i+1) + ".className='tab'");
				eval(ctrlID + "_tab"+ (i+1) + ".style.backgroundColor='#7b8fc2'");
				eval(arTabs[i] + ".style.display='none'");
			}
		}
		
		tdAdaugareEditare.innerHTML = "Adaugare functie";
	}
	
	function SelectFunctie( FunctieID, dataStart, angajatID)
	{
		tableIstoricFunctii.style.display = "none";
		tableAdaugaFunctie.style.display = "";
		edit_line.style.display = "";
		add_line.style.display = "none";
		tdAdaugareEditare.innerHTML = "Editare functie";
		
		eval(ctrlID + "_Form1." + ctrlID + "_lstFunctie.value = FunctieID;");
		eval(ctrlID + "_Form1." + ctrlID + "_txtDataStart.value = dataStart;");
		eval(ctrlID + "_Form1." + ctrlID + "_old_DataStart.value = dataStart;");		
		
	}
	
	function BackToList()
	{
		tableAdaugaFunctie.style.display='none';
		tableIstoricFunctii.style.display='';
		edit_line.style.display = "none";
		add_line.style.display = "";
		
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
function OpenAdminWindow( typeOfAdminPage)
{
	
	switch (typeOfAdminPage)
	{
		case "functii":
			h = Calculate_y_coordinate( 700);
			w = Calculate_x_coordinate( 900);
			oNewWindow = window.open("Administrare/AdminFunctiiAddAngajat.aspx",null,"height=700,width=900, top=" + h + ",left=" + w + " ,status=yes,toolbar=no,menubar=no,location=no,scrollbars=yes");
			oNewWindow.focus();
			break;
		default:
			break;
	}
}

//Sterge toate intrarile din combo-ul cu functii
function DeleteFunctiiCombo()
{
	var functiiCombo = document.getElementById( ctrlID + '_lstFunctie' ); 
	while( functiiCombo.length > 0 )
	{
		functiiCombo.remove( functiiCombo.selectedIndex );
	}
}

//Adauga o intrare la la combo-ul cu functii
function FillFunctieCombo( functieText, functieValoare)
{
	var functiiCombo = document.getElementById( ctrlID + '_lstFunctie' );
	var o = new Option();
	o.text = functieText;
	o.value = functieValoare;
	functiiCombo.add( o, 0 ); 
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
								<td class="HeaderGreenBold" align="center" colSpan="2" id="tdAdaugareEditare"></td>
							</tr>
							<TR>
								<TD class="NormalGreenBold">
									Categorie:</TD>
								<TD class="NormalGreenBold">
									<asp:dropdownlist id="lstFunctie" runat="server" Width="260px" CssClass="SelectStyle"></asp:dropdownlist>
									<INPUT onclick="javascript:OpenAdminWindow('functii')" type="button" value="..." id="Button1"
										name="Button1" runat="server">
								</TD>
							</TR>
							<tr>
								<td class="GreenSeparator" colSpan="2"><IMG height="1" src="../images/1x1.gif"></td>
							</tr>
							<TR>
								<TD class="NormalGreenBold">Data inceput activitate:</TD>
								<TD class="NormalGreenBold"><asp:textbox id="txtDataStart" style="CURSOR: hand; TEXT-ALIGN: center" onclick="if (TipUtilizator == 'Recrutor') { ShowCalendar(this,'../'); } else { ShowCalendar(this,''); }"
										runat="server" CssClass="NormalEditBoxuri" size="10"></asp:textbox><asp:requiredfieldvalidator id="requiredDataStart" runat="server" ErrorMessage="Completati data de incepere a activitati!"
										ControlToValidate="txtDataStart" CssClass="AlertRedBold"><</asp:requiredfieldvalidator></TD>
							</TR>
							<tr>
								<td class="GreenSeparator" colSpan="2"><IMG height="1" src="../images/1x1.gif"></td>
							</tr>
							<TR>
								<TD class="NormalGreenBold"></TD>
								<TD class="CommentRedBold">*Functia va determina categoria de incadrare atunci cand 
									se vor face schimbari</TD>
							</TR>
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
					<td align="center" style="HEIGHT: 80px"><asp:validationsummary id="ValidationSummary1" runat="server" CssClass="AlertRedBold" ShowMessageBox="True"
							ShowSummary="False"></asp:validationsummary>
						<asp:TextBox id="old_DataStart" runat="server"></asp:TextBox></td>
				</tr>
			</TABLE>
		</td>
	</tr>
</table>
<script>
	sp3FormIDfix();
	
	eval(ctrlID + "_tab1.click()");
</script>
