<%@ Control Language="c#" AutoEventWireup="false" Codebehind="IstoricTicheteDeMasa.ascx.cs" Inherits="SiemensHR.EditTasks.IstoricTicheteDeMasa" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>
<table border="0" cellSpacing="0" cellPadding="0" width="600" align="center">
	<tr>
		<td colSpan="3"><asp:literal id="litError" runat="server"></asp:literal></td>
	</tr>
	<tr>
		<td colSpan="3"><asp:table id="tableTabs" runat="server"></asp:table></td>
	</tr>
	<tr>
		<td id="tableIstoricCO" height="100%" vAlign="top" colSpan="3" align="center"><asp:table style="Z-INDEX: 0" id="mainTable" runat="server"></asp:table>
			<asp:datagrid style="Z-INDEX: 0" id="listDataGrid" runat="server" PageSize="20" AllowPaging="True"
				AutoGenerateColumns="False" GridLines="None" BorderColor="LightSeaGreen" CellSpacing="1" BorderWidth="1px"
				Width="390px">
				<ItemStyle CssClass="UnderlineNormalBlack"></ItemStyle>
				<HeaderStyle CssClass="HeaderBlueBold"></HeaderStyle>
				<Columns>
					<asp:BoundColumn DataField="LunaAn" HeaderText="Luna / An"></asp:BoundColumn>
					<asp:BoundColumn DataField="NrTotalTichete" HeaderText="Nr. tichete"></asp:BoundColumn>
				</Columns>
				<PagerStyle Mode="NumericPages"></PagerStyle>
			</asp:datagrid></td>
	</tr>
</table>
