<%@ Control Language="c#" AutoEventWireup="false" Codebehind="IstoricSchimbariDateAngajat.ascx.cs" Inherits="SiemensHR.EditTasks.IstoricSchimbariDateAngajat" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>
<script>
	
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
		tableEditDepartament.style.display = "none";
		
		if ( ascundeAdaugare )
		{
			tableAdaugaSchimbare.style.display = "none";
		}
	}
	
	//function SelectSchimbare( programLucru, dataProgramLucru, salariuBaza, dataSalariuBaza, indemnizatieConducere, dataIndemnizatieConducere, invaliditate, dataInvaliditate, categorieID, dataCategorieID, angajatID)
	function SelectSchimbare( dataStart, dataEnd, angajatID )
	{
		eval(ctrlID + "_Form1." + ctrlID + "_del_DataStart.value = dataStart;");
		eval(ctrlID + "_Form1." + ctrlID + "_del_DataEnd.value = dataEnd;");
		eval(ctrlID + "_Form1." + ctrlID + "_del_AngajatID.value = angajatID;");	
		eval(ctrlID + "_Form1." + ctrlID + "_btnStergeDate.click();");	
		//eval( "Form1." + ctrlID + "_btnStergeDate.click();");
			
	
		/*tableIstoricSchimbari.style.display = "none";
		tableEditSchimbari.style.display = "";
				
		eval(ctrlID + "_Form1." + ctrlID + "_txtEditProgramLucru.value = programLucru;");
		eval(ctrlID + "_Form1." + ctrlID + "_txtEditDataStartProgramLucru.value = dataProgramLucru;");
		
		eval(ctrlID + "_Form1." + ctrlID + "_txtEditSalariuBaza.value = salariuBaza;");
		eval(ctrlID + "_Form1." + ctrlID + "_txtEditDataStartSalariuBaza.value = dataSalariuBaza;");
		
		eval(ctrlID + "_Form1." + ctrlID + "_txtEditIndemnizatieConducere.value = dataIndemnizatieConducere;");
		eval(ctrlID + "_Form1." + ctrlID + "_txtEditDataStartIndemnizatieConducere.value = indemnizatieConducere;");
		
		eval(ctrlID + "_Form1." + ctrlID + "_txtEditInvaliditate.value = invaliditate;");
		eval(ctrlID + "_Form1." + ctrlID + "_txtEditDataStartInvaliditate.value = dataInvaliditate;");
		
		eval(ctrlID + "_Form1." + ctrlID + "_lstEditCategorie.value = categorieID;");
		eval(ctrlID + "_Form1." + ctrlID + "_lstEditDataStartCategorie.value = dataCategorieID;");
		
		eval(ctrlID + "_Form1.old_DataStartProgramLucru.value = dataProgramLucru;");
		eval(ctrlID + "_Form1.old_DataStartSalariuBaza.value = dataSalariuBaza;");
		eval(ctrlID + "_Form1.old_DataStartIndemnizatieConducere.value = dataIndemnizatieConducere;");
		eval(ctrlID + "_Form1.old_DataStartInvaliditate.value = dataInvaliditate;");
		eval(ctrlID + "_Form1.old_DataStartCategorieID.value = dataCategorieID;");*/
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

//Deschide o fereastra noua in care se va incarca fereastra de admin pt invaliditati, categorii de incadrare
function OpenAdminWindow( typeOfAdminPage)
{
	
	switch (typeOfAdminPage)
	{
		case "invaliditati":
			h = Calculate_y_coordinate( 300);
			w = Calculate_x_coordinate( 600);
			oNewWindow = window.open("Administrare/AdminInvaliditatiAddAngajat.aspx",null,"height=300,width=600, top=" + h + ",left=" + w + " ,status=yes,toolbar=no,menubar=no,location=no,scrollbars=yes");
			oNewWindow.focus();
			break;
		case "categorii_incadrare":
			h = Calculate_y_coordinate( 500);
			w = Calculate_x_coordinate( 800);
			oNewWindow = window.open("InterfataSalarii/AdminCategoriiAngajati_AddAngajat.aspx",null,"height=500,width=800, top=" + h + ",left=" + w + " ,status=yes,toolbar=no,menubar=no,location=no,scrollbars=yes");
			oNewWindow.focus();
			break;
		default:
			break;
	}
}

//Sterge toate intrarile din combo-ul cu invaliditati
function DeleteInvaliditatiCombo()
{
	var invaliditatiCombo = document.getElementById( ctrlID + '_chkLstInvalid' ); 
	while( invaliditatiCombo.length > 0 )
	{
		invaliditatiCombo.remove( invaliditatiCombo.selectedIndex );
	}
}

//Adauga o intrare la la combo-ul cu invaliditati
function FillInvaliditateCombo( invaliditateText, invaliditateValoare)
{
	var invaliditatiCombo = document.getElementById( ctrlID + '_chkLstInvalid' );
	var o = new Option();
	o.text = invaliditateText;
	o.value = invaliditateValoare;
	invaliditatiCombo.add( o, 0 ); 
}

//Sterge toate intrarile din combo-ul cu categorii de incadrare
function DeleteCategoriiCombo()
{
	var categoriiIncadrareCombo = document.getElementById( ctrlID + '_lstCategorie' ); 
	while( categoriiIncadrareCombo.length > 0 )
	{
		categoriiIncadrareCombo.remove( categoriiIncadrareCombo.selectedIndex );
	}
}

//Adauga o intrare la la combo-ul cu categorii de incadrare
function FillCategorieCombo( categorieIncadrareText, categorieIncadrareValoare)
{
	var categoriiIncadrareCombo = document.getElementById( ctrlID + '_lstCategorie' );
	var o = new Option();
	o.text = categorieIncadrareText;
	o.value = categorieIncadrareValoare;
	categoriiIncadrareCombo.add( o, 0 ); 
}

</script>
<table cellSpacing="0" cellPadding="0" width="600" align="center" border="0">
	<tr>
		<td colSpan="3"><asp:literal id="litError" runat="server"></asp:literal></td>
	</tr>
	<tr>
		<td colSpan="3"><IMG height="10" src="../images/1x1.gif"></td>
	</tr>
	<tr>
		<td colSpan="3"><asp:table id="tableTabs" runat="server"></asp:table></td>
	</tr>
	<tr>
		<td id="tableIstoricSchimbari" vAlign="top" align="center" colSpan="3" height="100%"><asp:table id="listTable" runat="server"></asp:table></td>
		<td id="tableAdaugaSchimbare" align="center" colSpan="3">
			<TABLE height="200" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
				<tr>
					<td class="tabBackground">
						<TABLE height="100%" cellSpacing="1" cellPadding="0" width="100%" align="center" border="0">
							<tr>
								<td class="HeaderGreenBold" align="center" colSpan="3">Adaugati schimbare:</td>
								<TD class="HeaderGreenBold" align="center"></TD>
							</tr>
							<TR>
								<TD class="NormalGreenBold">Norma lucru:</TD>
								<TD class="NormalGreenBold"><asp:textbox id="txtProgramLucru" runat="server" MaxLength="1" Width="300px" CssClass="NormalEditBoxuri"></asp:textbox><asp:requiredfieldvalidator id="RequiredFieldValidator1" runat="server" CssClass="AlertRedBold" ErrorMessage="Completati norma de lucru!"
										ControlToValidate="txtProgramLucru"><</asp:requiredfieldvalidator><asp:regularexpressionvalidator id="vldProgramLucru" runat="server" CssClass="AlertRedBold" ErrorMessage="Norma trebuie sa fie un intreg cuprins intre 2 si 8!"
										ControlToValidate="txtProgramLucru" ValidationExpression="[2-8]"><</asp:regularexpressionvalidator></TD>
								<td class="NormalGreenBold"><asp:textbox id="txtDataStartProgramLucru" style="TEXT-ALIGN: center; CURSOR: hand" runat="server"
										CssClass="NormalEditBoxuri" size="10" ReadOnly="True" Enabled="False"></asp:textbox></td>
								<TD class="NormalGreenBold"></TD>
							</TR>
							<tr>
								<td class="GreenSeparator" colSpan="3"><IMG height="1" src="../images/1x1.gif"></td>
								<TD class="GreenSeparator"></TD>
							</tr>
							<TR>
								<TD class="NormalGreenBold">Salariu de baza:</TD>
								<TD class="NormalGreenBold"><asp:textbox id="txtSalariuBaza" runat="server" MaxLength="9" Width="300px" CssClass="NormalEditBoxuri"></asp:textbox><asp:requiredfieldvalidator id="RequiredFieldValidator2" runat="server" CssClass="AlertRedBold" ErrorMessage="Completati salariul de baza!"
										ControlToValidate="txtSalariuBaza"><</asp:requiredfieldvalidator><asp:comparevalidator id="CompareValidator1" runat="server" CssClass="AlertRedBold" ErrorMessage="Completati corect suma pentru salariul de baza!"
										ControlToValidate="txtSalariuBaza" ValueToCompare="0" Operator="GreaterThanEqual" Type="Currency"><</asp:comparevalidator></TD>
								<td class="NormalGreenBold"><asp:textbox id="txtDataStartSalariuBaza" style="TEXT-ALIGN: center; CURSOR: hand" onclick="ShowCalendar(this,'')"
										runat="server" CssClass="NormalEditBoxuri" size="10" ReadOnly="True"></asp:textbox></td>
								<TD class="NormalGreenBold"></TD>
							</TR>
							<tr>
								<td class="GreenSeparator" colSpan="3"><IMG height="1" src="../images/1x1.gif"></td>
								<TD class="GreenSeparator"></TD>
							</tr>
							<TR>
								<TD class="NormalGreenBold">Indemnizatie de conducere:</TD>
								<TD class="NormalGreenBold"><asp:textbox id="txtIndemnizatieConducere" runat="server" MaxLength="9" Width="300px" CssClass="NormalEditBoxuri"></asp:textbox><asp:requiredfieldvalidator id="RequiredFieldValidator3" runat="server" CssClass="AlertRedBold" ErrorMessage="Completati indemnizatia de conducere!"
										ControlToValidate="txtIndemnizatieConducere"><</asp:requiredfieldvalidator><asp:comparevalidator id="CompareValidator2" runat="server" CssClass="AlertRedBold" ErrorMessage="Completati corect suma pentru indemnizatie de conducere!"
										ControlToValidate="txtIndemnizatieConducere" ValueToCompare="0" Operator="GreaterThanEqual" Type="Currency"><</asp:comparevalidator></TD>
								<td class="NormalGreenBold"><asp:textbox id="txtDataStartIndemnizatieConducere" style="TEXT-ALIGN: center; CURSOR: hand"
										onclick="ShowCalendar(this,'')" runat="server" CssClass="NormalEditBoxuri" size="10" ReadOnly="True"></asp:textbox></td>
								<TD class="NormalGreenBold"></TD>
							</TR>
							<tr>
								<td class="GreenSeparator" colSpan="3"><IMG height="1" src="../images/1x1.gif"></td>
								<TD class="GreenSeparator"></TD>
							</tr>
							<TR>
								<TD class="NormalGreenBold" style="HEIGHT: 8px">Invaliditate:</TD>
								<td style="HEIGHT: 8px"><asp:dropdownlist id="chkLstInvalid" runat="server" Width="150px" CssClass="SelectStyle"></asp:dropdownlist><INPUT onclick="javascript:OpenAdminWindow('invaliditati')" type="button" value="...">
								</td>
								<td class="NormalGreenBold" style="HEIGHT: 8px"><asp:textbox id="txtDataStartInvaliditate" style="TEXT-ALIGN: center; CURSOR: hand" runat="server"
										CssClass="NormalEditBoxuri" size="10" ReadOnly="True" Enabled="False"></asp:textbox></td>
								<TD class="NormalGreenBold" style="HEIGHT: 8px"></TD>
							</TR>
							<tr>
								<td class="GreenSeparator" colSpan="3"><IMG height="1" src="../images/1x1.gif"></td>
								<TD class="GreenSeparator"></TD>
							</tr>
							<TR>
								<TD class="NormalGreenBold">Categoria de incadrare:</TD>
								<td><asp:dropdownlist id="lstCategorie" runat="server" Width="300px" CssClass="SelectStyle"></asp:dropdownlist><INPUT onclick="javascript:OpenAdminWindow('categorii_incadrare')" type="button" value="...">
								</td>
								<td class="NormalGreenBold"><asp:textbox id="txtDataStartCategorie" style="TEXT-ALIGN: center; CURSOR: hand" runat="server"
										CssClass="NormalEditBoxuri" size="10" ReadOnly="True" Enabled="False"></asp:textbox></td>
								<TD class="NormalGreenBold"></TD>
							</TR>
							<tr>
								<td class="GreenSeparator" colSpan="3"><IMG height="1" src="../images/1x1.gif"></td>
							</tr>
							<TR>
								<TD class="NormalGreenBold"></TD>
								<TD class="CommentRedBold">*Categoria de incadrare se va alege corespunzator cu 
									functia angajatului</TD>
								<TD class="NormalGreenBold"></TD>
								<TD class="NormalGreenBold"></TD>
							</TR>
							<TR>
								<TD class="NormalGreenBold" align="center" colSpan="4"></TD>
								<TD></TD>
								<TD class="NormalGreenBold"></TD>
								<TD class="NormalGreenBold"></TD>
							</TR>
						</TABLE>
					</td>
				</tr>
				<tr>
					<td align="center"><asp:validationsummary id="ValidationSummary1" runat="server" CssClass="AlertRedBold" ShowSummary="False"
							ShowMessageBox="True"></asp:validationsummary></td>
				</tr>
				<tr>
					<td align="center" height="100%"><asp:button id="btnAdaugaSchimbare" onmouseover="MouseOverButton(this)" onmouseout="MouseOutButton(this)"
							runat="server" CssClass="ButtonStyle" Text="  Salveaza date  "></asp:button>&nbsp;&nbsp;&nbsp;
						<asp:button id="btnAnuleaza" onmouseover="MouseOverButton(this)" onmouseout="MouseOutButton(this)"
							runat="server" CssClass="ButtonStyle" Text="  Anuleaza  " CausesValidation="false"></asp:button><asp:button id="btnStergeDate" onmouseover="MouseOverButton(this)" onmouseout="MouseOutButton(this)"
							runat="server" CssClass="ButtonStyle" Text="Sterge" CausesValidation="false"></asp:button></td>
				</tr>
			</TABLE>
		</td>
		<td id="tableEditDepartament" align="center" colSpan="3">
			<TABLE height="200" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
				<tr>
					<td>
						<TABLE style="BORDER-BOTTOM: #20b2aa 1px solid; BORDER-LEFT: #20b2aa 1px solid; BORDER-TOP: #20b2aa 1px solid; BORDER-RIGHT: #20b2aa 1px solid"
							height="100%" cellSpacing="1" cellPadding="0" width="100%" align="center" border="0">
							<tr>
								<td class="HeaderGreenBold" align="center" colSpan="3">Editati schimbare:</td>
							</tr>
							<TR>
								<TD class="NormalGreenBold">Norma lucru:</TD>
								<TD class="NormalGreenBold"><asp:textbox id="txtEditProgramLucru" runat="server" MaxLength="1" Width="300px" CssClass="NormalEditBoxuri"></asp:textbox></TD>
								<td class="NormalGreenBold"><asp:textbox id="txtEditDataStartNormaLucru" style="TEXT-ALIGN: center; CURSOR: hand" runat="server"
										CssClass="NormalEditBoxuri" size="10" ReadOnly="True" Enabled="False"></asp:textbox></td>
							</TR>
							<tr>
								<td class="GreenSeparator" colSpan="3"><IMG height="1" src="../images/1x1.gif"></td>
							</tr>
							<TR>
								<TD class="NormalGreenBold">Salariu de baza:</TD>
								<TD class="NormalGreenBold"><asp:textbox id="txtEditSalariuBaza" runat="server" MaxLength="9" Width="300px" CssClass="NormalEditBoxuri"></asp:textbox></TD>
								<td class="NormalGreenBold"><asp:textbox id="txtEditDataStartSalariuBaza" style="TEXT-ALIGN: center; CURSOR: hand" runat="server"
										CssClass="NormalEditBoxuri" size="10" ReadOnly="True" Enabled="False"></asp:textbox></td>
							</TR>
							<tr>
								<td class="GreenSeparator" colSpan="3"><IMG height="1" src="../images/1x1.gif"></td>
							</tr>
							<TR>
								<TD class="NormalGreenBold">Indemnizatie de conducere:</TD>
								<TD class="NormalGreenBold"><asp:textbox id="txtEditIndemnizatieConducere" runat="server" MaxLength="9" Width="300px" CssClass="NormalEditBoxuri"></asp:textbox></TD>
								<td class="NormalGreenBold"><asp:textbox id="txtEditDataStartIndemnizatieConducere" style="TEXT-ALIGN: center; CURSOR: hand"
										runat="server" CssClass="NormalEditBoxuri" size="10" ReadOnly="True" Enabled="False"></asp:textbox></td>
							</TR>
							<tr>
								<td class="GreenSeparator" colSpan="3"><IMG height="1" src="../images/1x1.gif"></td>
							</tr>
							<TR>
								<td colSpan="3"><asp:radiobuttonlist id="chkEditLstInvalid" runat="server" Width="376px" CssClass="NormalGreenBold" RepeatDirection="Horizontal">
										<ASP:LISTITEM Selected="True" Value="0">Fara invaliditate</ASP:LISTITEM>
										<ASP:LISTITEM Value="2">Invaliditate gr.II</ASP:LISTITEM>
										<ASP:LISTITEM Value="1">Invaliditate gr.I</ASP:LISTITEM>
									</asp:radiobuttonlist></td>
								<td class="NormalGreenBold"><asp:textbox id="txtEditDataStartInvaliditate" style="TEXT-ALIGN: center; CURSOR: hand" runat="server"
										CssClass="NormalEditBoxuri" size="10" ReadOnly="True" Enabled="False"></asp:textbox></td>
							</TR>
							<tr>
								<td class="GreenSeparator" colSpan="3"><IMG height="1" src="../images/1x1.gif"></td>
							</tr>
							<TR>
								<TD class="NormalGreenBold">Categoria de incadrare:</TD>
								<td><asp:dropdownlist id="lstEditCategorie" runat="server" Width="300px" CssClass="SelectStyle"></asp:dropdownlist></td>
								<td class="NormalGreenBold"><asp:textbox id="txtEditDataStartCategori" style="TEXT-ALIGN: center; CURSOR: hand" runat="server"
										CssClass="NormalEditBoxuri" size="10" ReadOnly="True" Enabled="False"></asp:textbox></td>
							</TR>
						</TABLE>
					</td>
				</tr>
				<tr>
					<td align="center"><input type="hidden" name="old_DataStartProgramLucru"></td>
					<td align="center"><input type="hidden" name="old_DataStartSalariuBaza"></td>
					<td align="center"><input type="hidden" name="old_DataStartIndemnizatieConducere"></td>
					<td align="center"><input type="hidden" name="old_DataStartInvaliditate"></td>
					<td align="center"><input type="hidden" name="old_DataStartCategorieID"></td>
				</tr>
				<tr>
					<td align="center" height="100%"><asp:button id="btnModificaDate" onmouseover="MouseOverButton(this)" onmouseout="MouseOutButton(this)"
							runat="server" CssClass="ButtonStyle" Text="  Modifica date  " CausesValidation="false"></asp:button>&nbsp;
						<input class="ButtonStyle" id="btnInapoi" onmouseover="MouseOverButton(this)" onclick="tableEditSchimbari.style.display='none';tableIstoricSchimbari.style.display=''"
							onmouseout="MouseOutButton(this)" type="button" value="  Inapoi  "> &nbsp;
					</td>
				</tr>
			</TABLE>
		</td>
	</tr>
</table>
<input id="del_DataStart" type="hidden" name="del_DataStart" runat="server"> <input id="del_DataEnd" type="hidden" name="del_DataEnd" runat="server">
<input id="del_AngajatID" type="hidden" name="del_AngajatID" runat="server">
<script>
	sp3FormIDfix();
	eval(ctrlID + "_tab1.click()");
</script>
<INPUT id="txtPosibilitateScutireImpozit" type="hidden" runat="server">
