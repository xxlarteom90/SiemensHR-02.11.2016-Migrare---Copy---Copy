<%@ Control Language="c#" AutoEventWireup="false" Codebehind="HeaderMenu.ascx.cs" Inherits="SiemensHR.HeaderMenu" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>

	<script language="javascript" src="<%Response.Write(this.relativePath);%>js/jsUpMenuCode.js"></script>
	<table width="100%" cellpadding=0 cellspacing=0 border=0>
	<tr>
	<td style="BACKGROUND-IMAGE:url(<%Response.Write(this.relativePath);%>images/fill-menu.gif)" width="60%">
	<table cellpadding=0 width="100%" cellspacing=0 border=0>
	<tr>
		<td align=center >
		<table  valign=center cellpadding=0 cellspacing=0 border=0 >
		<tR>
			<td class=MenuStyle style="CURSOR:hand" onmouseover="MouseOverMenu(this)" onclick="SelectMenuOption(6)" onmouseout="MouseOutMenu(this)">Home</td>
			<td class=MenuStyle >&nbsp;|&nbsp;</td>
			
			<td class=MenuStyle style="CURSOR:hand" onmouseover="MouseOverMenu(this)" onclick="SelectMenuOption(0)" onmouseout="MouseOutMenu(this)">Angajati</td>
			<td class=MenuStyle >&nbsp;|&nbsp;</td>
			
			<td class=MenuStyle style="CURSOR:hand" onmouseover="MouseOverMenu(this)" onclick="SelectMenuOption(5)" onmouseout="MouseOutMenu(this)">Salarii</td>
			<td class=MenuStyle >&nbsp;|&nbsp;</td>
	
			
			<td class=MenuStyle style="CURSOR:hand" onmouseover="MouseOverMenu(this)" onclick="SelectMenuOption(3)" onmouseout="MouseOutMenu(this)">Administrare</td>
			<td class=MenuStyle>&nbsp;|&nbsp;</td>
			
			<td class=MenuStyle style="CURSOR:hand" onmouseover="MouseOverMenu(this)" onclick="OpenHelp()" onmouseout="MouseOutMenu(this)">Help</td>
			<td class=MenuStyle>&nbsp;|&nbsp;</td>
			
			<td class=MenuStyle style="CURSOR:hand" onmouseover="MouseOverMenu(this)" onclick="window.close();" onmouseout="MouseOutMenu(this)">Exit</td>			
		</tR>
		</table>
		</td>
	</tr>
	</table>
	</td>
	<td valign=top align=right width=41><img  src="<%Response.Write(this.relativePath);%>images/colt-header.gif"></td>	
	<td  align=right width="100%" valign=bottom ><div class=NormalBlueBold align=right>HR Toolkit v 
      1.0&nbsp;&nbsp;&nbsp;</div><img width="100%" height=5 src="<%Response.Write(this.relativePath);%>images/header-line.gif"></td>	
	</tr>
	</table>
	
	<script>
	function OpenHelp(cale)
	{
		oNewWindow = window.open("http://" + fullPath + "/Help/NetHelp/default.htm");
		oNewWindow.focus();
	}
	</script>

