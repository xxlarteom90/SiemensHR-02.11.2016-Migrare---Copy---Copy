<%@ Control Language="c#" AutoEventWireup="false" Codebehind="AngExpiraContractLunaCurenta.ascx.cs" Inherits="SiemensHR.AngExpiraContractLunaCurenta" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>
<script language="javascript" src="js/jsCode.js"></script>
<script>
	function EditAngajatContract(obj)
	{
        //Artiom Modificat 03.04.2017
	    //document.location = "EditAngajat.aspx?id=" + obj.childNodes(1).innerText + "&alerta=contract";
	    var x = obj.childNodes[2];
	    if(x.innerText !== undefined)
	    {
	        document.location = "EditAngajat.aspx?id=" + x.innerText + "&alerta=contract";
	    }
	}	
</script>
<table cellSpacing="0" cellPadding="0" width="700" align="center" border="0">
	<tr>
		<td align="center" colSpan="2"><asp:table id="tableHeader" runat="server"></asp:table></td>
	</tr>
	<tr>
		<td><asp:datagrid id="listDataGrid" runat="server" BorderWidth="1px" CellSpacing="1" AllowSorting="True"
				BorderColor="LightSeaGreen" GridLines="None" Width="700px" AutoGenerateColumns="False" AllowPaging="True"
				PageSize="20">
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
					<asp:BoundColumn DataField="DataPanaLa" SortExpression="DataPanaLa" HeaderText="Data Expirarii">
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
