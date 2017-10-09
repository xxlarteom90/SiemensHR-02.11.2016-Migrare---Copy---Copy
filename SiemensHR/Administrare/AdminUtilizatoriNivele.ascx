<%@ Control Language="c#" AutoEventWireup="false" Codebehind="AdminUtilizatoriNivele.ascx.cs" Inherits="SiemensHR.Administrare.AdminUtilizatoriNivele" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>
<script>
	function EditUtilizator(obj)
	{
		document.location = "Administrare.aspx?cmd=edit_utilizator&id=" + obj;
	}	
</script>
<FORM id="Form1" runat="server">
	<TABLE class="tabBackground" id="Table6" cellSpacing="0" cellPadding="0" width="100%" border="0">
		<TR>
			<TD>
				<asp:literal id="litError" runat="server"></asp:literal></TD>
		</TR>
		<TR id="listUtilizatori_form">
			<TD align="center">
				<asp:table id="mainTable" runat="server"></asp:table>
				<asp:datagrid id="listDataGrid" runat="server" BorderWidth="1px" CellSpacing="1" BorderColor="LightSeaGreen"
					GridLines="None" AutoGenerateColumns="False" AllowPaging="True" PageSize="30" Width="390px">
					<ItemStyle CssClass="UnderlineNormalBlack"></ItemStyle>
					<HeaderStyle CssClass="HeaderBlueBold"></HeaderStyle>
					<Columns>
						<asp:BoundColumn DataField="UtilizatorID" HeaderText="UtilizatorID"></asp:BoundColumn>
						<asp:BoundColumn DataField="NumeGrup" HeaderText="Grup"></asp:BoundColumn>
						<asp:BoundColumn DataField="Nume" HeaderText="Utilizator"></asp:BoundColumn>
					</Columns>
					<PagerStyle Mode="NumericPages"></PagerStyle>
				</asp:datagrid></TD>
		</TR>
		<TR id="addUtilizator_form" style="DISPLAY: none">
			<TD align="center"></TD>
		</TR>
		<TR id="addUtilizator_button" height="50">
			<TD align="center">
				<TABLE id="Table9" cellSpacing="0" cellPadding="0" border="0">
					<TR>
						<TD class="UnderlineBlackBold">Pentru adaugarea unui utilizator&nbsp;nou apasati pe 
							acest buton:
						</TD>
						<TD>&nbsp;<INPUT class="ButtonStyle" onmouseover="MouseOverButton(this)" onclick="ShowAddUtilizator()"
								onmouseout="MouseOutButton(this)" type="button" value="Utilizator nou">&nbsp;</TD>
					</TR>
				</TABLE>
			</TD>
		</TR>
	</TABLE>
	&nbsp;
</FORM>
<SCRIPT>
	//sp3FormIDfix();
	document.forms[0].id=ctrlID + "_Form1";
</SCRIPT>

