<%@ Control Language="c#" AutoEventWireup="false" Codebehind="AdminTraininguri.ascx.cs" Inherits="SiemensHR.Administrare.AdminTraininguri" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>
<script>

var arTabsTraininguri = new Array('tableCursuriInterne', 'tableCursuriExterne', 'tableAdaugaCurs');

	function SelectTabTraining(index)
	{
		for(i=0; i<arTabsTraininguri.length; i++)
		{
			if (i==index)
			{
				eval(arTabsTraininguri[i] + ".style.display=''");
				eval(ctrlID + "_tab"+ (i+1)+ ".className='tabActive'");	
			}
			else
			{
				eval(ctrlID + "_tab"+ (i+1) + ".className='tab'");
				eval(ctrlID + "_tab"+ (i+1) + ".style.backgroundColor='#7b8fc2'");
				eval(arTabsTraininguri[i] + ".style.display='none'");
			}
		}
		if (index == 2)
		{
			ShowAddForm();
		}
	}
	
	
/*
*	Modificat:	Lungu Andreea
*	Data:		27.07.2007
*	Descriere:	S-au adaugat validatorii: regularDescriere si regularDiploma
*/
function sp3FormIDfix()
{
	document.forms[0].id=ctrlID + "_Form1";
	document.getElementById(requiredDenumire).innerText = '';
	document.getElementById(regularDenumire).innerText = '';
	document.getElementById(regularDescriere).innerText = '';
	document.getElementById(regularDiploma).innerText = '';
}

function ShowAddForm()
{
	td_editLine.style.display = "none";
	td_addLine.style.display = "";
	tableAdaugaCurs.style.display = "";
	tableCursuriInterne.style.display = "none";
	tableCursuriExterne.style.display = "none";
	tdTextLine.innerText = "Adauga training";
	
	eval(ctrlID + "_Form1." + ctrlID + "_txtDenumire.value = '';");	
	eval(ctrlID + "_Form1." + ctrlID + "_txtDescriere.value = '';");		
	eval(ctrlID + "_Form1." + ctrlID + "_txtDiploma.value = '';");
	eval(ctrlID + "_Form1." + ctrlID + "_checkIntern.checked = false;");
}

function ShowList()
{
	eval(ctrlID + "_Form1." + ctrlID + "_btnInapoi.click();");	
}

function SelectLine(id, nume, descriere, diploma, tipTraining)
{	
	tableCursuriInterne.style.display = "none";
	tableCursuriExterne.style.display = "none";
	tdTextLine.innerText = "Editeaza training";
	td_editLine.style.display = "";
	td_addLine.style.display = "none";
	tableAdaugaCurs.style.display = "";
	
	if (descriere == "&nbsp;")
		descriere = " ";
	if (diploma == "&nbsp;")
		diploma = " ";
				
	eval(ctrlID + "_Form1." + ctrlID + "_txtTrainingID.value = id;");
	eval(ctrlID + "_Form1." + ctrlID + "_txtDenumire.value = nume;");
	eval(ctrlID + "_Form1." + ctrlID + "_txtDescriere.value = descriere;");
	eval(ctrlID + "_Form1." + ctrlID + "_txtDiploma.value = diploma;");
	if (tipTraining == 0)
	{
		eval(ctrlID + "_Form1." + ctrlID + "_checkIntern.checked = true;");
	}
	else
	{
		eval(ctrlID + "_Form1." + ctrlID + "_checkIntern.checked = false;");
	}
}


</script>
<form id="Form1" name="Form1" method="post" runat="server">
	<table id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
		<TR id="add_form" runat="server">
			<TD align="center">
				<TABLE id="Table5" cellSpacing="0" cellPadding="0" width="600" align="center" border="0">
					<TR>
						<TD colSpan="2"><asp:literal id="litError" runat="server"></asp:literal></TD>
					</TR>
					<TR>
						<TD colSpan="2"><IMG height="10" src="../images/1x1.gif"></TD>
					</TR>
					<TR>
						<TD colSpan="2"><asp:table id="tableTabs" runat="server"></asp:table></TD>
					</TR>
					<TR>
						<TD id="tableCursuriInterne" vAlign="top" align="center" colSpan="2" height="100%"><asp:datagrid id="listDataGridInterne" runat="server" Width="700px" BorderWidth="1px" CellSpacing="1"
								BorderColor="LightSeaGreen" GridLines="None" AutoGenerateColumns="False" AllowPaging="True" PageSize="30">
								<ItemStyle CssClass="UnderlineNormalBlack"></ItemStyle>
								<HeaderStyle CssClass="HeaderBlueBold"></HeaderStyle>
								<Columns>
									<asp:BoundColumn DataField="TrainingID" HeaderText="TrainingID"></asp:BoundColumn>
									<asp:BoundColumn DataField="Nume" HeaderText="Nume"></asp:BoundColumn>
									<asp:BoundColumn DataField="Descriere" HeaderText="Descriere"></asp:BoundColumn>
									<asp:BoundColumn DataField="Diploma" HeaderText="Diploma"></asp:BoundColumn>
								</Columns>
								<PagerStyle Mode="NumericPages"></PagerStyle>
							</asp:datagrid></TD>
						<TD id="tableCursuriExterne" vAlign="top" align="center" colSpan="2" height="100%"><asp:datagrid id="listDataGridExterne" runat="server" Width="700px" BorderWidth="1px" CellSpacing="1"
								BorderColor="LightSeaGreen" GridLines="None" AutoGenerateColumns="False" AllowPaging="True" PageSize="30">
								<ItemStyle CssClass="UnderlineNormalBlack"></ItemStyle>
								<HeaderStyle CssClass="HeaderBlueBold"></HeaderStyle>
								<Columns>
									<asp:BoundColumn DataField="TrainingID" HeaderText="TrainingID"></asp:BoundColumn>
									<asp:BoundColumn DataField="Nume" HeaderText="Nume"></asp:BoundColumn>
									<asp:BoundColumn DataField="Descriere" HeaderText="Descriere"></asp:BoundColumn>
									<asp:BoundColumn DataField="Diploma" HeaderText="Diploma"></asp:BoundColumn>
								</Columns>
								<PagerStyle Mode="NumericPages"></PagerStyle>
							</asp:datagrid></TD>
						<TD class="tabBackgound" id="tableAdaugaCurs" align="center" width="600" colSpan="2">
							<TABLE class="tabBackground" cellSpacing="1" cellPadding="0" width="700" border="0">
								<TR>
									<TD class="HeaderGreenBold" id="tdTextLine" align="center" colSpan="2">Adauga curs</TD>
								</TR>
								<TR>
									<TD>
										<TABLE class="tabBackground" id="Table3" cellSpacing="1" cellPadding="0" width="100%" border="0">
											<TR>
												<TD class="NormalGreenBold">Denumire :</TD>
												<TD><asp:textbox id="txtDenumire" runat="server" CssClass="NormalEditBoxuri" MaxLength="100" Width="300px"></asp:textbox><SPAN class="CommentRedBold">*</SPAN>
													<asp:requiredfieldvalidator id="requiredDenumire" runat="server" CssClass="AlertRedBold" ErrorMessage="Completati denumirea Training - ului!"
														ControlToValidate="txtDenumire"><</asp:requiredfieldvalidator><asp:regularexpressionvalidator id="regularDenumire" runat="server" CssClass="AlertRedBold" ErrorMessage="Nu puteti adauga caractere invalide pentru denumire: <>()';&quot;\"
														ControlToValidate="txtDenumire" ValidationExpression="^[^>|(|)|<|'|&quot;|;|\\]*$"><</asp:regularexpressionvalidator></TD>
											</TR>
											<TR>
												<TD class="GreenSeparator" colSpan="2"><IMG height="1" src="images/1x1.gif"></TD>
											</TR>
											<TR>
												<TD class="NormalGreenBold" style="HEIGHT: 76px">Descriere:</TD>
												<TD style="HEIGHT: 76px"><asp:textbox id="txtDescriere" runat="server" CssClass="AreaStyle" MaxLength="100" Columns="40"
														Rows="4" TextMode="MultiLine" Width="300px"></asp:textbox><asp:regularexpressionvalidator id="regularDescriere" runat="server" CssClass="AlertRedBold" ErrorMessage="Nu puteti adauga caractere invalide pentru descriere: <>()';&quot;\"
														ControlToValidate="txtDescriere" ValidationExpression="^[^>|(|)|<|'|&quot;|;|\\]*$"><</asp:regularexpressionvalidator></TD>
											</TR>
											<TR>
												<TD class="GreenSeparator" colSpan="2"><IMG height="1" src="images/1x1.gif"></TD>
											</TR>
											<TR>
												<TD class="NormalGreenBold">Diploma:</TD>
												<TD><asp:textbox id="txtDiploma" runat="server" CssClass="NormalEditBoxuri" MaxLength="100" Width="300px"></asp:textbox><asp:regularexpressionvalidator id="regularDiploma" runat="server" CssClass="AlertRedBold" ErrorMessage="Nu puteti adauga caractere invalide pentru diploma: <>()';&quot;\"
														ControlToValidate="txtDiploma" ValidationExpression="^[^>|(|)|<|'|&quot;|;|\\]*$"><</asp:regularexpressionvalidator></TD>
											</TR>
											<TR>
												<TD class="GreenSeparator" colSpan="2"><IMG height="1" src="images/1x1.gif"></TD>
											</TR>
											<TR>
												<TD class="NormalGreenBold">Training intern: &nbsp;</TD>
												<TD><asp:checkbox id="checkIntern" runat="server"></asp:checkbox></TD>
											</TR>
										</TABLE>
										<asp:textbox id="txtTrainingID" runat="server"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="CommentRedBold" colSpan="2">* - Campuri obligatorii</TD>
								</TR>
								<TR id="td_addLine">
									<TD align="center" colSpan="2" height="50"><asp:button id="btnAdd" onmouseover="MouseOverButton(this)" onmouseout="MouseOutButton(this)"
											runat="server" CssClass="ButtonStyle" Text="Salveaza training"></asp:button>&nbsp;
										<INPUT class="ButtonStyle" onmouseover="MouseOverButton(this)" onclick="ShowList()" onmouseout="MouseOutButton(this)"
											type="button" value="  Inapoi  ">
										<asp:button id="btnEdit" runat="server" Text="Edit" CausesValidation="False"></asp:button></TD>
								</TR>
								<TR>
									<TD align="center" colSpan="2"><asp:label id="lblMessage" runat="server" CssClass="AlertRedBold"></asp:label>&nbsp;</TD>
								</TR>
								<TR id="td_editLine">
									<TD align="center" colSpan="2" height="50"><asp:button id="btnModify" onmouseover="MouseOverButton(this)" onmouseout="MouseOutButton(this)"
											runat="server" CssClass="ButtonStyle" Text="Modifica training"></asp:button>&nbsp;
										<asp:button id="btnDelete" onmouseover="MouseOverButton(this)" onmouseout="MouseOutButton(this)"
											runat="server" CssClass="ButtonStyle" Text="Sterge training" CausesValidation="False"></asp:button>&nbsp;
										<asp:button id="btnInapoi" onmouseover="MouseOverButton(this)" onmouseout="MouseOutButton(this)"
											runat="server" CssClass="ButtonStyle" Text="   Inapoi   " CausesValidation="False"></asp:button></TD>
								</TR>
								<TR>
									<TD align="center" width="600" colSpan="2"><asp:validationsummary id="ValidationSummary1" onmouseover="MouseOverButton(this)" onmouseout="MouseOutButton(this)"
											runat="server" CssClass="AlertRedBold" ShowSummary="False" ShowMessageBox="True"></asp:validationsummary></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
				</TABLE>
			</TD>
		</TR>
	</table>
</form>
<script>
sp3FormIDfix();

eval(ctrlID + "_tab1.click();");
</script>
