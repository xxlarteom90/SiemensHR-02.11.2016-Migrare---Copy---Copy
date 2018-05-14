<%@ Control Language="c#" AutoEventWireup="false" Codebehind="comunicare_prelungire_cim.ascx.cs" Inherits="SiemensHR.Comunicari.comunicare_prelungire_cim" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<LINK rel="stylesheet" type="text/css" href="StyleHR.css">
<body onload="eNedeterminata()">
	<script>
function sp3FormIDfix()
	{
	document.forms[0].id=ctrlID + "_Form1";
	}
function eNedeterminata()
	{
		if (document.getElementById(ctrlID+"_lstPerAngajarii").selectedIndex==0)
		{   
			eval(ctrlID+"_Form1."+ctrlID+"_txtDataPanaLa.style.display=''");
			eval("labPanaLa.style.display=''");
			eval("spanReq.style.display=''");   
			ValidatorEnable(document.getElementById(ctrlID+"_requiredDataPanaLa"),true);
		}
		else
		{
			eval(ctrlID+"_Form1."+ctrlID+"_txtDataPanaLa.style.display='none'");
			eval("labPanaLa.style.display='none'");
			eval("spanReq.style.display='none'");
			ValidatorEnable(document.getElementById(ctrlID+"_requiredDataPanaLa"),false);   
		}
	}
	</script>
	<STRONG>
		<P align="center">
			<TABLE id="Table1" border="0" cellSpacing="1" cellPadding="0" width="500">
				<tr>
					<td align="center"><asp:table id="Table2" runat="server"></asp:table></td>
				</tr>
				<tr>
					<td class="tabBackground" align="left">
						<table border="0" cellSpacing="0" cellPadding="0" width="100%">
							<tr>
								<TD class="NormalGreenBold">Numarul comunicarii:</TD>
								<TD><asp:textbox id="txtNumarComunicare" runat="server" CssClass="NormalEditBoxuri" MaxLength="9"></asp:textbox><SPAN class="CommentRedBold">*</SPAN>
									<asp:requiredfieldvalidator id="reqNumarComunicare" runat="server" CssClass="AlertRedBold" ErrorMessage="Completati numarul comunicarii!"
										ControlToValidate="txtNumarComunicare"><</asp:requiredfieldvalidator></TD>
							</tr>
							<tr>
								<td class="GreenSeparator" colSpan="2"><IMG src="../images/1x1.gif" height="1"></td>
							</tr>
							<tr>
								<TD class="NormalGreenBold">Data generarii:</TD>
								<TD><asp:textbox style="CURSOR: hand" id="txtDataGenerarii" onclick="ShowCalendar(this,'')" runat="server"
										CssClass="NormalEditBoxuri" MaxLength="10" ReadOnly="False"></asp:textbox><SPAN class="CommentRedBold">*</SPAN>
									<asp:requiredfieldvalidator id="reqDataGenerarii" runat="server" CssClass="AlertRedBold" ErrorMessage="Completati data generarii!"
										ControlToValidate="txtDataGenerarii"><</asp:requiredfieldvalidator></TD>
							</tr>
							<tr>
								<td class="GreenSeparator" colSpan="2"><IMG src="../images/1x1.gif" height="1"></td>
							</tr>
							<tr>
								<TD class="NormalGreenBold">Perioada angajarii:</TD>
								<TD><SELECT style="WIDTH: 300px" id="lstPerAngajarii" class="SelectStyle" onchange="eNedeterminata()"
										name="lstPerAngajarii" runat="server" disabled>
										<OPTION selected value="1">Determinata</OPTION>
										<OPTION value="0">Nedeterminata</OPTION>
									</SELECT>
								</TD>
							</tr>
							<tr>
								<td class="GreenSeparator" colSpan="2"><IMG src="../images/1x1.gif" height="1"></td>
							</tr>
							<tr>
								<td>
								<td><LABEL id="labDeLa">De la:</LABEL>
									<asp:textbox style="CURSOR: hand" id="txtDataDeLa" onclick="ShowCalendar(this,'')" runat="server"
										CssClass="NormalEditBoxuri" MaxLength="10" ReadOnly="False" Width="70px" Height="18px" Enabled="False"></asp:textbox><SPAN class="CommentRedBold">*</SPAN>
									<LABEL id="labPanaLa">Pana la:</LABEL>
									<asp:textbox style="CURSOR: hand" id="txtDataPanaLa" onclick="ShowCalendar(this,'')" runat="server"
										CssClass="NormalEditBoxuri" MaxLength="10" ReadOnly="False" Width="70px" Height="18px" Enabled="False"></asp:textbox><SPAN id="spanReq" class="CommentRedBold">*
										<asp:requiredfieldvalidator id="requiredDataPanaLa" runat="server" CssClass="AlertRedBold" ErrorMessage="Completati data expirarii contractului!"
											ControlToValidate="txtDataPanaLa"><</asp:requiredfieldvalidator></SPAN></SPAN><asp:requiredfieldvalidator id="requiredDataDeLa" runat="server" CssClass="AlertRedBold" ErrorMessage="Completati data inceperii contractului!"
										ControlToValidate="txtDataDeLa"><</asp:requiredfieldvalidator></td>
							</tr>
							<tr>
								<td class="GreenSeparator" colSpan="2"><IMG src="../images/1x1.gif" height="1"></td>
							</tr>
							<!--<tr>
							<td class="GreenSeparator" colSpan="2"></td>
						</tr>
						<tr>
							<td class="GreenSeparator" colSpan="2"></td>
						</tr>
						<tr>
							<td class="GreenSeparator" colSpan="2"></td>
						</tr>
						<tr>
							<td class="GreenSeparator" colSpan="2"></td>
						</tr>-->
							<TR>
								<td style="HEIGHT: 12px" colSpan="2"><asp:label id="lblCmpObl" runat="server" Font-Size="Smaller" ForeColor="Red">* - Campuri obligatorii</asp:label></td>
							</TR>
						</table>
					</td>
				</tr>
				<TR>
					<TD style="HEIGHT: 4px" height="4" align="left"></TD>
				</TR>
				<tr>
					<td height="50" align="center"><asp:button id="btnGenerati" onmouseover="MouseOverButton(this)" onmouseout="MouseOutButton(this)"
							runat="server" CssClass="ButtonStyle" Text="   Generati   "></asp:button></td>
				</tr>
				<tr>
					<td height="50" align="left"><asp:label style="Z-INDEX: 0" id="lblEroare" runat="server" cssclass="NormalGreenBold"></asp:label><asp:validationsummary style="Z-INDEX: 0" id="sumarValidare" runat="server"></asp:validationsummary></td>
				</tr>
			</TABLE>
		</P>
	</STRONG>
	<script>
		sp3FormIDfix();

		var arForms = document.getElementsByTagName("Form");
			formObj = arForms[0];
		
	</script>
</body>
