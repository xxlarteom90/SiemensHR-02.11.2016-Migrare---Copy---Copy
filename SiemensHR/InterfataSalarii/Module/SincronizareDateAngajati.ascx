<%@ Control Language="c#" AutoEventWireup="false" Codebehind="SincronizareDateAngajati.ascx.cs" Inherits="SiemensHR.InterfataSalarii.Module.SincronizareDateAngajati" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>
<script language="javascript" src="../js/jsCode.js"></script>
<script>
function ImportClick()
{
	SincronizareClick();
}

function OnLoad()
{
	eval("Form1." + ctrlID + "_fileImportFisier.value = '';");
	document.getElementById(lblAtentieClient).innerHTML = 'Atentie! Angajatii vor fi identificati prin intermediul marcii. <br> Se vor lua in considerare doar intervalele din luna activa.';
	document.getElementById(tdTemp).innerHTML = "<a target=_blank href='Templates\\TemplateAngajati.xls'>template date angajati</a>";
	document.getElementById(reqImport).innerText = '';
}

</script>
<table cellSpacing="0" cellPadding="0" width="542" align="center" border="0">
	<tr>
		<td class="AlertRedBold" colSpan="3"><asp:literal id="litError" runat="server"></asp:literal></td>
	</tr>
	<tr>
		<td style="WIDTH: 542px" colSpan="2"><IMG height="10" src="../images/1x1.gif"></td>
	</tr>
	<tr>
		<td style="WIDTH: 542px" colSpan="2"></td>
	</tr>
	<TR>
		<TD id="tablePontaj" vAlign="top" align="center" colSpan="1" runat="server">
			<TABLE class="tabBackground" id="Table1" height="48" cellSpacing="0" cellPadding="0" width="100%"
				align="center" border="0">
				<TR>
					<TD class="HeaderGreenBold" id="tdTitlu" align="center" colSpan="2">Sincronizare 
						date angajati</TD>
				</TR>
				<TR>
					<TD class="GreenSeparator" colSpan="2"><IMG height="1" src="../images/1x1.gif"></TD>
				</TR>
				<TR>
					<TD class="NormalGreenBold" style="WIDTH: 108px" height="10"></TD>
					<TD class="NormalGreenBold" height="10"></TD>
				</TR>
				<TR>
					<TD class="NormalGreenBold" style="WIDTH: 108px" width="108">&nbsp;&nbsp;Fisier</TD>
					<TD class="NormalGreenBold" width="85%"><SPAN class="CommentRedBold"><INPUT class="NormalEditBoxuri" id="fileImportFisier" style="WIDTH: 360px; HEIGHT: 19px"
								type="file" size="40" name="File1" runat="server">
							<asp:requiredfieldvalidator id="reqFieldValImport" runat="server" ErrorMessage="Introduceti fisierul de import!"
								ControlToValidate="fileImportFisier"><</asp:requiredfieldvalidator></SPAN></TD>
				</TR>
				<TR>
					<TD class="NormalGreenBold" style="WIDTH: 108px" vAlign="middle" width="108">&nbsp; 
						Template</TD>
					<TD class="NormalGreenBold" id="tdTemplate" runat="server"></TD>
				</TR>
				<TR>
					<TD class="NormalGreenBold" style="WIDTH: 108px" width="108" height="10"></TD>
					<TD class="NormalGreenBold" height="10"></TD>
				</TR>
				<TR>
					<TD class="NormalGreenBold" style="WIDTH: 108px" width="108" height="10"></TD>
					<TD class="NormalGreenBold" height="10">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<INPUT class="ButtonStyle" id="ButtonImport" onmouseover="MouseOverButton(this)" style="WIDTH: 248px"
							onclick="ImportClick()" onmouseout="MouseOutButton(this)" type="button" value="Sincronizare" name="ButtonImport" runat="server"></TD>
				</TR>
				<TR id="Tr1" runat="server">
					<TD class="NormalGreenBold" style="WIDTH: 49px" colSpan="2">
						<P><asp:label id="lblAtentie" runat="server" Width="520px" CssClass="AlertRedBold"></asp:label></P>
					</TD>
				</TR>
				<TR>
					<TD class="NormalGreenBold" style="WIDTH: 200px" colSpan="2" height="7"></TD>
				</TR>
				<TR>
					<TD class="NormalGreenBold" style="WIDTH: 200px" colSpan="2"><asp:label id="lblMesajImport" runat="server" Width="528px" CssClass="AlertRedBold"></asp:label></TD>
				</TR>
				<TR>
					<TD class="NormalGreenBold" style="WIDTH: 200px" colSpan="2"><asp:label id="lblMesaj" runat="server" Width="528px" CssClass="MenuStyle"></asp:label></TD>
				</TR>
				<TR>
					<TD class="NormalGreenBold" style="WIDTH: 200px" colSpan="2"><asp:validationsummary id="Validationsummary2" runat="server" ShowSummary="False"></asp:validationsummary></TD>
				</TR>
			</TABLE>
		</TD>
	</TR>
</table>
<script>
	OnLoad();
</script>
