<%@ Control Language="c#" AutoEventWireup="false" Codebehind="AngAlerteSpeciale.ascx.cs" Inherits="SiemensHR.AngAlerteSpeciale" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>
<script language="javascript" src="js/jsCode.js"></script>
<script>
	function EditAngajatAlertaSpeciala(obj)
	{
        //Artiom Modificat 03.04.2017
	    //document.location = "editangajat.aspx?id=" + obj.childnodes(1).innertext + "&alerta=speciala";
	    var x = obj.childnodes[2];
	    if(x.innertext !== undefined)
	    {
	        document.location = "editangajat.aspx?id=" + x.innertext + "&alerta=speciala";
	    }
	}	
</script>
<table cellSpacing="0" cellPadding="0" width="700" align="center" border="0">
	<tr>
		<td align="center" colSpan="2"><asp:table id="tableHeader" runat="server"></asp:table></td>
	</tr>
	<tr>
		<td><asp:datagrid id="listDataGrid" runat="server" PageSize="20" AllowPaging="True" AutoGenerateColumns="False"
				Width="700px" GridLines="None" BorderColor="LightSeaGreen" AllowSorting="True" CellSpacing="1"
				BorderWidth="1px">
				<ItemStyle CssClass="UnderlineNormalBlack"></ItemStyle>
				<HeaderStyle CssClass="HeaderBlueBold"></HeaderStyle>
				<Columns>
					<asp:BoundColumn DataField="AngajatID" HeaderText="AngajatID"></asp:BoundColumn>
					<asp:BoundColumn DataField="Marca" SortExpression="Marca" HeaderText="Marca">
						<HeaderStyle Width="20%"></HeaderStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="NumeIntreg" SortExpression="NumeIntreg" HeaderText="Nume Intreg">
						<HeaderStyle Width="20%"></HeaderStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="Descriere" SortExpression="Descriere" HeaderText="Descriere alerta"></asp:BoundColumn>
					<asp:BoundColumn DataField="Data" SortExpression="Data" HeaderText="Data expirare"></asp:BoundColumn>
				</Columns>
				<PagerStyle Mode="NumericPages"></PagerStyle>
			</asp:datagrid></td>
	</tr>
	<tr>
		<td><asp:table id="ResultTable" runat="server" Width="100%"></asp:table></td>
	</tr>
</table>
