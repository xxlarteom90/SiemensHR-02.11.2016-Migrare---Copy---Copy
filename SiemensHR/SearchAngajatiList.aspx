<%@ Register TagPrefix="uc1" TagName="HeaderMenu" Src="HeaderMenu.ascx" %>
<%@ Register TagPrefix="uc1" TagName="PageHeader" Src="PageHeader.ascx" %>
<%@ Page language="c#" Codebehind="SearchAngajatiList.aspx.cs" AutoEventWireup="false" Inherits="SiemensHR.SearchAngajatiList" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>HR Toolkit</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="StyleHR.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<script language="javascript" src="js/jsCode.js"></script>
		<script>
	function EditAngajat(obj)
	{

	    //var obj = document.location("EditAngajat.aspx?id=");
	    //var values = obj.childNodes[1].innerText;

	    //document.location = "EditAngajat.aspx?id=" + obj.childNodes(1).innerText;
	    //var x = obj.childNodes[1];
	    var x = obj.children[1];
	    if (x.innerText !== undefined) {
	        document.location= "EditAngajat.aspx?id=" + x.innerText;
	    }



	}	
		</script>
		<form id="Form1" method="post" runat="server">
			<table cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
				<tr>
					<td><uc1:pageheader id="PageHeader1" runat="server"></uc1:pageheader></td>
				</tr>
				<tr>
					<td align="center"><uc1:headermenu id="HeaderMenu1" runat="server"></uc1:headermenu></td>
				</tr>
				<tr>
					<td align="center">
						<table cellSpacing="0" cellPadding="0" width="450" border="0">
							<tr>
								<td><IMG height="20" src="images/1x1.gif"></td>
							</tr>
							<tr>
								<td class="BigBlueBold" style="HEIGHT: 19px" align="center">Cautare angajati</td>
							</tr>
							<tr>
								<td><IMG height="20" src="images/1x1.gif"></td>
							</tr>
							<tr>
								<td><asp:datagrid id="listDataGrid" runat="server" PageSize="50" AllowPaging="True" AutoGenerateColumns="False"
										Width="700px" GridLines="None" BorderColor="LightSeaGreen" AllowSorting="True" CellSpacing="1"
										BorderWidth="1px">
										<ItemStyle CssClass="UnderlineNormalBlack"></ItemStyle>
										<HeaderStyle CssClass="HeaderBlueBold"></HeaderStyle>
										<Columns>
											<asp:BoundColumn DataField="AngajatID" HeaderText="AngajatID"></asp:BoundColumn>
											<asp:BoundColumn DataField="Marca" SortExpression="Marca" HeaderText="Marca"></asp:BoundColumn>
											<asp:BoundColumn DataField="Nume" SortExpression="Nume" HeaderText="Nume"></asp:BoundColumn>
											<asp:BoundColumn DataField="Prenume" SortExpression="Prenume" HeaderText="Prenume"></asp:BoundColumn>
											<asp:BoundColumn DataField="Telefon" SortExpression="Telefon" HeaderText="Telefon"></asp:BoundColumn>
											<asp:BoundColumn DataField="DepartamentDenumire" SortExpression="DepartamentDenumire" HeaderText="Departament"></asp:BoundColumn>
										</Columns>
										<PagerStyle Mode="NumericPages"></PagerStyle>
									</asp:datagrid></td>
							</tr>
						</table>
					</td>
				</tr>
				<TR>
					<TD align="center" height="50"><input class="ButtonStyle" id="btnInapoi" onmouseover="MouseOverButton(this)" onclick="document.location='SearchAngajati.aspx'"
							onmouseout="MouseOutButton(this)" type="button" value="  Inapoi  "></TD>
				</TR>
			</table>
		</form>
	</body>
</HTML>
