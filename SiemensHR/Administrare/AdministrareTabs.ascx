<%@ Control Language="c#" AutoEventWireup="false" Codebehind="AdministrareTabs.ascx.cs" Inherits="SiemensHR.Administrare.AdministrareTabs" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>

<script>

	function SelectTab(index)
	{		
		var lastSelectedNodeID = document.getElementById('LastSelectedNodeID').value;
		document.location = "Administrare.aspx?node="+lastSelectedNodeID+"&cmd="+arTabs[index];
	}

function SelectDefaultTab()
{
	eval("tab"+GetSelectedTabIndex()+".className='tabActive'");
}

function GetSelectedTabIndex()
{
	for(var i=0; i<arTabs.length; i++)
	{
		if (selectedTab == arTabs[i])
			return (i+1);
	}
	return 1;
}


</script>
<table border=0 cellpadding=0 cellspacing=0 >
<tr>
	<td ><IMG height=20 src="../images/1x1.gif" ></td>
</tr>
<tr>
	<td>
<asp:Table id=tabsTable runat="server"></asp:Table></td>
</tr>
</table>
<script>
SelectDefaultTab();
</script>

