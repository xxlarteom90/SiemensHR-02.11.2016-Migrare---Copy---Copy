<%@ Control Language="c#" AutoEventWireup="false" Codebehind="AngExpiraDataMajorareStabilita.ascx.cs" Inherits="SiemensHR.AngExpiraDataMajorareStabilita" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>
<script language="javascript" src="js/jsCode.js"></script>
<script>
	function EditAngajatAlertaMajorare(obj)
	{
        //Artiom Modificat 03.04.2017
	    //document.location = "EditAngajat.aspx?id=" + obj.childNodes(1).innerText+"&alerta=majorare";
	    var x = obj.childNodes[2];
	    if(x.innerText !== undefined)
	    {
	        document.location = "EditAngajat.aspx?id=" + x.innerText+"&alerta=majorare";
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
					<asp:BoundColumn DataField="DataMajorare" SortExpression="DataMajorare" HeaderText="Data majorare">
						<HeaderStyle Width="45%"></HeaderStyle>
					</asp:BoundColumn>
				</Columns>
				<PagerStyle Mode="NumericPages"></PagerStyle>
			</asp:datagrid></td>
	</tr>
	<tr>
		<td><asp:table id="ResultTable" runat="server" Width="100%"></asp:table></td>
	</tr>
</table>
