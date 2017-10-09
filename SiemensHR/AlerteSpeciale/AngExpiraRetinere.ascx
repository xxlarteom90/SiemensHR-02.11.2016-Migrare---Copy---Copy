<%@ Control Language="c#" AutoEventWireup="false" Codebehind="AngExpiraRetinere.ascx.cs" Inherits="SiemensHR.AngExpiraRetinere" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>
<script language="javascript" src="js/jsCode.js"></script>
<script>
	var FormClientID = 'Form1';
	function EditRetinereAngajatAlerta(obj)
	{

        //Artiom Modificat 03.04.2017
	    //document.location = "InterfataSalarii/Salarii.aspx?Tab=Pontaj&Option=retineri_recurente_angajat&node=Element_025&idAng=" + obj.childNodes(1).innerText;
	    var x = obj.childNodes[1];
	    if(x.innerText !== undefined)
	    {
	        document.location = "InterfataSalarii/Salarii.aspx?Tab=Pontaj&Option=retineri_recurente_angajat&node=Element_025&idAng=" + x.innerText;
	    }

	}	
</script>
<table cellSpacing="0" cellPadding="0" width="700" align="center" border="0">
	<tr>
		<td align="center" colSpan="2"><asp:table id="tableRetineriHeader" runat="server"></asp:table></td>
	</tr>
	<tr>
		<td><asp:datagrid id="listDataGridAngajati" runat="server" PageSize="20" AllowPaging="True" AutoGenerateColumns="False"
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
					<asp:BoundColumn DataField="TipRetinere" SortExpression="TipRetinere" HeaderText="Tip Retinere">
						<HeaderStyle Width="45%"></HeaderStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="DenumireRetinere" SortExpression="DenumireRetinere" HeaderText="Retinere"></asp:BoundColumn>
					<asp:BoundColumn DataField="Valoare" SortExpression="Valoare" HeaderText="Valoare"></asp:BoundColumn>
				</Columns>
				<PagerStyle Mode="NumericPages"></PagerStyle>
			</asp:datagrid></td>
	</tr>
	<tr>
		<td><asp:table id="ResultTable" runat="server" Width="100%"></asp:table></td>
	</tr>
</table>
