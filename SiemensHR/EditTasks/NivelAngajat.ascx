<%@ Control Language="c#" AutoEventWireup="false" Codebehind="NivelAngajat.ascx.cs" Inherits="SiemensHR.EditTasks.NivelAngajat" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>
<script>
	function CreateId(id)
	{
		return "checkBoxNivel_" + id;
	}
</script>
<table cellSpacing="0" cellPadding="0" width="600" align="center" border="0">
	<tr>
	</tr>
	<TR>
	</TR>
	<tr>
	</tr>
	<tr>
		<td id="tableAdaugaCont" align="center" colSpan="2">
			<TABLE height="200" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
				<tr>
					<td class="tabBackground">
					</td>
				</tr>
				<TR>
					<TD align="left" height="100%">
						<asp:literal id="litError" runat="server"></asp:literal></TD>
				</TR>
				<TR>
					<TD align="center" height="100%"></TD>
				</TR>
				<TR>
					<TD class="HeaderGreenBold" align="center" height="100%">Nivel angajat:</TD>
				</TR>
				<TR>
					<TD align="center" height="100%" class="tabbackground">
						<asp:DataList id="listaNivele" runat="server" DataKeyField="IDNivelAngajat">
							<ItemTemplate>
								<asp:CheckBox id=checkBoxNivel runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"NivelAngajat")%>' CssClass="NormalBlackBold" Checked='<%#DataBinder.Eval(Container.DataItem,"EsteInNivel")%>'>
								</asp:CheckBox>
							</ItemTemplate>
						</asp:DataList></TD>
				</TR>
				<TR>
					<TD align="center" height="100%">
						<P>&nbsp;</P>
					</TD>
				</TR>
				<tr id="addButtonsLine">
					<td align="center" height="100%"><asp:button id="btnSalveaza" onmouseover="MouseOverButton(this)" onmouseout="MouseOutButton(this)"
							runat="server" CssClass="ButtonStyle" Text="  Salveaza"></asp:button></td>
				<tr id="editButtonsLine">
					<td align="center" height="100%">&nbsp;&nbsp;&nbsp;&nbsp;
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
<TABLE height="100%" cellSpacing="1" cellPadding="0" width="100%" align="center" border="0">
</TABLE>
