<%@ Control Language="c#" AutoEventWireup="false" Codebehind="HeaderMenu.ascx.cs" Inherits="SiemensTM.Module.HeaderMenu" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<script language="javascript" src="js/jsUpMenuCode.js"></script>
<table width="100%" cellpadding="0" cellspacing="0" border="0">
	<tr>
		<td style="BACKGROUND-IMAGE:url(images/fill-menu.gif)" width="60%">
			<table cellpadding="0" width="100%" cellspacing="0" border="0">
				<tr>
					<td align="center">
						<table cellpadding="0" cellspacing="0" border="0">
							<tr>
								<td class="MenuStyle" style="CURSOR:hand" onmouseover="MouseOverMenu(this)" onclick="SelectMenuOption(0)"
									onmouseout="MouseOutMenu(this)">Situatie timp</td>
								<td class="MenuStyle">&nbsp;|&nbsp;</td>
								<td class="MenuStyle" style="CURSOR:hand" onmouseover="MouseOverMenu(this)" onclick="SelectMenuOption(1)"
									onmouseout="MouseOutMenu(this)">Zile Absente</td>
								<td class="MenuStyle">&nbsp;|&nbsp;</td>
								<td class="MenuStyle" style="CURSOR:hand" onmouseover="MouseOverMenu(this)" onclick="SelectMenuOption(2)"
									onmouseout="MouseOutMenu(this)">
									Optiune
								</td>
								<td class="MenuStyle">&nbsp;|&nbsp;</td>
								<td class="MenuStyle" style="CURSOR:hand" onmouseover="MouseOverMenu(this)" onclick="SelectMenuOption(3)"
									onmouseout="MouseOutMenu(this)">
									Optiune
								</td>
								<td class="MenuStyle">&nbsp;|&nbsp;</td>
								<td class="MenuStyle" style="CURSOR:hand" onmouseover="MouseOverMenu(this)" onclick="SelectMenuOption(4)"
									onmouseout="MouseOutMenu(this)">Exit</td>
								<td class="MenuStyle" id=admin_separator runat=server></td>	
								<td id=admin_link runat=server  class="MenuStyle" style="CURSOR:hand" onmouseover="MouseOverMenu(this)" onclick="SelectMenuOption(5)"
									onmouseout="MouseOutMenu(this)"></td>
								
							</tr>
						</table>
					</td>
				</tr>
			</table>
		</td>
		<td valign="top" align="right" width="41"><img src="images/colt-header.gif"></td>
		<td align="right" width="100%" valign="bottom"><img width="100%" height="5" src="images/header-line.gif"></td>
	</tr>
</table>
