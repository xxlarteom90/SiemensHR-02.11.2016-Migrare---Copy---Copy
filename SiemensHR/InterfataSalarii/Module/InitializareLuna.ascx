<%@ Control Language="c#" AutoEventWireup="false" Codebehind="InitializareLuna.ascx.cs" Inherits="SiemensHR.InterfataSalarii.Module.InitializareLuna" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>
<table cellSpacing="0" cellPadding="0" width="600" align="center" border="0">
	<tr>
		<td colSpan="3"><asp:literal id="litError" runat="server"></asp:literal></td>
	</tr>
	<tr>
		<td colSpan="2"><IMG height="10" src="../images/1x1.gif"></td>
	</tr>
	<tr>
		<td colSpan="2"><asp:table id="tableTabs" runat="server"></asp:table></td>
	</tr>
	<tr>
		<td id="tableListSit" vAlign="top" align="center" colSpan="2" height="100%"><asp:table id="listTable" runat="server"></asp:table></td>
		<td id="tableAdaugaSit" align="center" colSpan="2">
			<TABLE height="200" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
				<tr>
					<td class="tabBackground">
						<TABLE height="100%" cellSpacing="1" cellPadding="0" width="100%" align="center" border="0">
							<tr>
								<td class="HeaderGreenBold" id="tdTextLine" align="center" colSpan="2">Initializare&nbsp;situatie 
									lunara</td>
							</tr>
							<TR>
								<TD class="NormalGreenBold" id="LunaContainer" style="HEIGHT: 18px" colSpan="2" runat="server"></TD>
								<TD class="NormalGreenBold" style="HEIGHT: 18px"></TD>
							</TR>
							<TR>
								<TD class="NormalGreenBold" style="HEIGHT: 18px">Categorie Angajat</TD>
								<TD class="NormalGreenBold" style="HEIGHT: 18px"><asp:dropdownlist id="lstCategorii" runat="server" Width="152px"></asp:dropdownlist></TD>
							</TR>
							<tr>
								<td class="GreenSeparator" colSpan="2"><IMG height="1" src="../images/1x1.gif"></td>
							</tr>
							<TR>
								<TD class="NormalGreenBold">Nr Zile Luna</TD>
								<TD class="NormalGreenBold"><asp:textbox id="txtNrZileLuna" runat="server" CssClass="NumericEditBoxuri">0</asp:textbox><SPAN class="CommentRedBold">*
										<asp:comparevalidator id="Comparevalidator11" runat="server" CssClass="AlertRedBold" ErrorMessage="Introduceti o valoare reala!"
											ControlToValidate="txtNrZileLuna" Operator="DataTypeCheck" Type="Double" Display="Dynamic"><</asp:comparevalidator></SPAN></TD>
							</TR>
							<TR id="trNrOreLucrate" runat="server">
								<TD class="NormalGreenBold">Nr Ore Lucrate</TD>
								<TD class="NormalGreenBold"><asp:textbox id="txtNrOreLucrate" runat="server" CssClass="NumericEditBoxuri">0</asp:textbox><span class="CommentRedBold">*
										<asp:comparevalidator id="CompareValidator1" runat="server" CssClass="AlertRedBold" ErrorMessage="Introduceti o valoare reala!"
											ControlToValidate="txtNrOreLucrate" Operator="DataTypeCheck" Type="Double" Display="Dynamic"><</asp:comparevalidator></span></TD>
							</TR>
							<tr>
								<td class="GreenSeparator" colSpan="2"><IMG height="1" src="../images/1x1.gif"></td>
							</tr>
							<TR>
								<TD class="NormalGreenBold">Nr Ore Sup 100%</TD>
								<TD class="NormalGreenBold"><asp:textbox id="txtNrOreSup50Proc" runat="server" CssClass="NumericEditBoxuri">0</asp:textbox><span class="CommentRedBold">*
										<asp:comparevalidator id="Comparevalidator2" runat="server" CssClass="AlertRedBold" ErrorMessage="Introduceti o valoare reala!"
											ControlToValidate="txtNrOreSup50Proc" Operator="DataTypeCheck" Type="Double"><</asp:comparevalidator></span></TD>
							</TR>
							<tr>
								<td class="GreenSeparator" colSpan="2"><IMG height="1" src="../images/1x1.gif"></td>
							</tr>
							<tr id="trActiv" runat="server">
								<TD class="NormalGreenBold">Nr Ore Sup 200%</TD>
								<TD class="NormalGreenBold"><asp:textbox id="txtNrOreSup100Proc" runat="server" CssClass="NumericEditBoxuri">0</asp:textbox><span class="CommentRedBold">*
										<asp:comparevalidator id="Comparevalidator3" runat="server" CssClass="AlertRedBold" ErrorMessage="Introduceti o valoare reala!"
											ControlToValidate="txtNrOreSup100Proc" Operator="DataTypeCheck" Type="Double"><</asp:comparevalidator></span></TD>
							</tr>
							<tr>
								<td class="GreenSeparator" colSpan="2"><IMG height="1" src="../images/1x1.gif"></td>
							</tr>
							<TR id="trNrOreEvenimenteDeosebite" runat="server">
								<TD class="NormalGreenBold">Nr Ore Evenim Deoseb</TD>
								<TD class="NormalGreenBold"><asp:textbox id="txtNrOreEvenimDeoseb" runat="server" CssClass="NumericEditBoxuri">0</asp:textbox><span class="CommentRedBold">*
										<asp:comparevalidator id="Comparevalidator4" runat="server" CssClass="AlertRedBold" ErrorMessage="Introduceti o valoare reala!"
											ControlToValidate="txtNrOreEvenimDeoseb" Operator="DataTypeCheck" Type="Double"><</asp:comparevalidator></span></TD>
							</TR>
							<TR id="trNrOreInvoire" runat="server">
								<TD class="NormalGreenBold">Nr Ore Invoire</TD>
								<TD class="NormalGreenBold"><asp:textbox id="txtNrOreInvoire" runat="server" CssClass="NumericEditBoxuri">0</asp:textbox><span class="CommentRedBold">*
										<asp:comparevalidator id="Comparevalidator5" runat="server" CssClass="AlertRedBold" ErrorMessage="Introduceti o valoare reala!"
											ControlToValidate="txtNrOreInvoire" Operator="DataTypeCheck" Type="Double"><</asp:comparevalidator></span></TD>
							</TR>
							<TR id="trNrOreConcediuOdihna" runat="server">
								<TD class="NormalGreenBold">Nr Ore Concediu Odihna</TD>
								<TD class="NormalGreenBold"><asp:textbox id="txtNrOreConcediuOdihna" runat="server" CssClass="NumericEditBoxuri">0</asp:textbox><span class="CommentRedBold">*
										<asp:comparevalidator id="Comparevalidator18" runat="server" CssClass="AlertRedBold" ErrorMessage="Introduceti o valoare reala!"
											ControlToValidate="txtNrOreConcediuOdihna" Operator="DataTypeCheck" Type="Double"><</asp:comparevalidator></span></TD>
							</TR>
							<TR id="trNrOreConcediuBoala" runat="server">
								<TD class="NormalGreenBold">Nr Ore Concediu Boala</TD>
								<TD class="NormalGreenBold"><asp:textbox id="txtNrOreConcediuBoala" runat="server" CssClass="NumericEditBoxuri">0</asp:textbox><span class="CommentRedBold">*
										<asp:comparevalidator id="Comparevalidator6" runat="server" CssClass="AlertRedBold" ErrorMessage="Introduceti o valoare reala!"
											ControlToValidate="txtNrOreConcediuBoala" Operator="DataTypeCheck" Type="Double"><</asp:comparevalidator></span></TD>
							</TR>
							<TR id="trNrOreObligatiiCetatenesti" runat="server">
								<TD class="NormalGreenBold">Nr Zile Obligatii Cetatenesti</TD>
								<TD class="NormalGreenBold"><asp:textbox id="txtNrOreObligatiiCetatenesti" runat="server" CssClass="NumericEditBoxuri">0</asp:textbox><span class="CommentRedBold">*
										<asp:comparevalidator id="Comparevalidator12" runat="server" CssClass="AlertRedBold" ErrorMessage="Introduceti o valoare reala!"
											ControlToValidate="txtNrOreObligatiiCetatenesti" Operator="DataTypeCheck" Type="Double"><</asp:comparevalidator></span></TD>
							</TR>
							<TR id="trNrOreAbsenteNemotivate" runat="server">
								<TD class="NormalGreenBold">Nr Zile Absente Nemotivate</TD>
								<TD class="NormalGreenBold"><asp:textbox id="txtNrOreAbsenteNemotivate" runat="server" CssClass="NumericEditBoxuri">0</asp:textbox><span class="CommentRedBold">*
										<asp:comparevalidator id="Comparevalidator13" runat="server" CssClass="AlertRedBold" ErrorMessage="Introduceti o valoare reala!"
											ControlToValidate="txtNrOreAbsenteNemotivate" Operator="DataTypeCheck" Type="Double"><</asp:comparevalidator></span></TD>
							</TR>
							<TR id="trNrOreConcediuFaraPlata" runat="server">
								<TD class="NormalGreenBold">Nr Zile Concediu Fara Plata</TD>
								<TD class="NormalGreenBold"><asp:textbox id="txtNrOreConcediuFaraPlata" runat="server" CssClass="NumericEditBoxuri">0</asp:textbox><span class="CommentRedBold">*
										<asp:comparevalidator id="Comparevalidator14" runat="server" CssClass="AlertRedBold" ErrorMessage="Introduceti o valoare reala!"
											ControlToValidate="txtNrOreConcediuFaraPlata" Operator="DataTypeCheck" Type="Double"><</asp:comparevalidator></span></TD>
							</TR>
							<TR>
								<TD class="NormalGreenBold">Alte Drepturi Brut</TD>
								<TD class="NormalGreenBold"><asp:textbox id="txtAlteDrepturi" runat="server" CssClass="NumericEditBoxuri">0</asp:textbox><span class="CommentRedBold">*
										<asp:comparevalidator id="Comparevalidator10" runat="server" CssClass="AlertRedBold" ErrorMessage="Introduceti o valoare reala!"
											ControlToValidate="txtAlteDrepturi" Operator="DataTypeCheck" Type="Currency"><</asp:comparevalidator></span></TD>
							</TR>
							<tr>
								<td class="GreenSeparator" colSpan="2"><IMG height="1" src="../images/1x1.gif"></td>
							</tr>
							<TR>
								<TD class="NormalGreenBold">Alte Drepturi Net</TD>
								<TD class="NormalGreenBold"><asp:textbox id="txtAlteDrepturiNet" runat="server" CssClass="NumericEditBoxuri">0</asp:textbox><span class="CommentRedBold">*
										<asp:comparevalidator id="Comparevalidator19" runat="server" CssClass="AlertRedBold" ErrorMessage="Introduceti o valoare reala!"
											ControlToValidate="txtAlteDrepturiNet" Operator="DataTypeCheck" Type="Double"><</asp:comparevalidator></span></TD>
							</TR>
							<tr>
								<td class="GreenSeparator" colSpan="2"><IMG height="1" src="../images/1x1.gif"></td>
							</tr>
							<TR>
								<TD class="NormalGreenBold">Avans</TD>
								<TD class="NormalGreenBold"><asp:textbox id="txtAvans" runat="server" CssClass="NumericEditBoxuri">0</asp:textbox><span class="CommentRedBold">*
										<asp:comparevalidator id="Comparevalidator15" runat="server" CssClass="AlertRedBold" ErrorMessage="Introduceti o valoare reala!"
											ControlToValidate="txtAvans" Operator="DataTypeCheck" Type="Double"><</asp:comparevalidator></span></TD>
							</TR>
							<tr>
								<td class="GreenSeparator" colSpan="2"><IMG height="1" src="../images/1x1.gif"></td>
							</tr>
							<TR>
								<TD class="NormalGreenBold">Emergency Service</TD>
								<TD class="NormalGreenBold"><asp:textbox id="txtEmergencyService" runat="server" CssClass="NumericEditBoxuri">0</asp:textbox><span class="CommentRedBold">*
										<asp:comparevalidator id="Comparevalidator8" runat="server" CssClass="AlertRedBold" ErrorMessage="Introduceti o valoare reala!"
											ControlToValidate="txtEmergencyService" Operator="DataTypeCheck" Type="Currency"><</asp:comparevalidator></span></TD>
							</TR>
							<tr>
								<td class="GreenSeparator" colSpan="2"><IMG height="1" src="../images/1x1.gif"></td>
							</tr>
							<TR>
								<TD class="NormalGreenBold">Prima Proiect</TD>
								<TD class="NormalGreenBold"><asp:textbox id="txtPrimaProiect" runat="server" CssClass="NumericEditBoxuri">0</asp:textbox><span class="CommentRedBold">*
										<asp:comparevalidator id="Comparevalidator17" runat="server" CssClass="AlertRedBold" ErrorMessage="Introduceti o valoare reala!"
											ControlToValidate="txtPrimaProiect" Operator="DataTypeCheck" Type="Double"><</asp:comparevalidator></span></TD>
							</TR>
							<tr>
								<td class="GreenSeparator" colSpan="2"><IMG height="1" src="../images/1x1.gif"></td>
							</tr>
							<TR>
								<TD class="NormalGreenBold">Prime Speciale</TD>
								<TD class="NormalGreenBold"><asp:textbox id="txtPrimeSpeciale" runat="server" CssClass="NumericEditBoxuri">0</asp:textbox><span class="CommentRedBold">*
										<asp:comparevalidator id="Comparevalidator9" runat="server" CssClass="AlertRedBold" ErrorMessage="Introduceti o valoare reala!"
											ControlToValidate="txtPrimeSpeciale" Operator="DataTypeCheck" Type="Currency"><</asp:comparevalidator></span></TD>
							</TR>
							<tr>
								<td class="GreenSeparator" colSpan="2"><IMG height="1" src="../images/1x1.gif"></td>
							</tr>
							<TR>
								<TD class="NormalGreenBold" style="HEIGHT: 28px">Spor Activitati Suplimentare</TD>
								<TD class="NormalGreenBold" style="HEIGHT: 28px"><asp:textbox id="txtSporActivitatiSup" runat="server" CssClass="NumericEditBoxuri">0</asp:textbox><span class="CommentRedBold">*
										<asp:comparevalidator id="Comparevalidator7" runat="server" CssClass="AlertRedBold" ErrorMessage="Introduceti o valoare reala!"
											ControlToValidate="txtSporActivitatiSup" Operator="DataTypeCheck" Type="Currency"><</asp:comparevalidator></span></TD>
							</TR>
							<tr>
								<td class="GreenSeparator" colSpan="2"><IMG height="1" src="../images/1x1.gif"></td>
							</tr>
							<TR id="tdIndexare" runat="server">
								<TD class="NormalGreenBold" runat="server">Indexare</TD>
								<TD class="NormalGreenBold"><asp:checkbox id="indexareCheckBox" runat="server"></asp:checkbox></TD>
							</TR>
						</TABLE>
					</td>
				</tr>
				<tr id="addButtonsLine">
					<td align="center" height="100%"><INPUT id="txtSituatieID" type="hidden" value="0" name="txtCoefID" runat="server"></td>
				<tr id="editButtonsLine">
					<td style="HEIGHT: 24px" align="center" height="24"><input class="ButtonStyle" id="btnModificaSituatia1" onmouseover="MouseOverButton(this)"
							onclick="InitializareLunaClick()" onmouseout="MouseOutButton(this)" type="button" value="Initializare luna" name="btnModificaSituatia1"
							runat="server">&nbsp;&nbsp;&nbsp;&nbsp;
					</td>
				</tr>
				<tr>
					<td align="center"><asp:validationsummary id="ValidationSummary1" runat="server"></asp:validationsummary></td>
				</tr>
			</TABLE>
		</td>
	</tr>
</table>
<script>
	


</script>
