<%@ Control Language="c#" AutoEventWireup="false" Codebehind="SalariiHeaderMenu.ascx.cs" Inherits="SiemensHR.InterfataSalarii.Module.SalariiHeaderMenu" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>
<table cellpadding="0" width="100%" cellspacing="0" border="0" bgcolor="#b4dbf7">
	<tr>
		<td align="center">
			<table valign="center" cellpadding="0" cellspacing="0" border="0">
				<tR>
					<td class="MenuStyle" style="CURSOR:hand" onmouseover="Salaries_MouseOverMenu(this)"
						onclick="Salaries_SelectMenuOption(0)" onmouseout="MouseOutMenu(this)">Administrare</td>
					<td class="MenuStyle">&nbsp;|&nbsp;</td>
					<%
						if ( IsPontajAvailable())
						{
					%>
					<td class="MenuStyle" style="CURSOR:hand" onmouseover="Salaries_MouseOverMenu(this)"
						onclick="Salaries_SelectMenuOption(1)" onmouseout="MouseOutMenu(this)">Pontaj</td>
					<%
						}
						else
						{
					%>
						<td>Pontaj</td>
					<%
						}
					%>
					<td class="MenuStyle">&nbsp;|&nbsp;</td>
					<td class="MenuStyle" style="CURSOR:hand" onmouseover="Salaries_MouseOverMenu(this)"
						onclick="Salaries_SelectMenuOption(3)" onmouseout="MouseOutMenu(this)">Rapoarte</td>
					<td class="MenuStyle">&nbsp;|&nbsp;</td>
					<!--
					<td class="MenuStyle" style="CURSOR:hand" onmouseover="Salaries_MouseOverMenu(this)"
						onclick="Salaries_SelectMenuOption(4)" onmouseout="MouseOutMenu(this)">Comunicari</td>
					-->
				</tR>
			</table>
		</td>
	</tr>
</table>
