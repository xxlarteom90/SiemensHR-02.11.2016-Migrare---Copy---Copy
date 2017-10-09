<%@ Register TagPrefix="uc1" TagName="SituatieLunaraAngajat" Src="SituatieLunaraAngajat.ascx" %>
<%@ Control Language="c#" AutoEventWireup="false" Codebehind="SituatieLunaraAngajati.ascx.cs" Inherits="SiemensHR.InterfataSalarii.Module.SituatieLunaraAngajati" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>
<table width="100%" cellpadding="0" cellspacing="0" height="100%">
	<TR>
		<TD class="NormalGreenBold" vAlign="top" align="left" bgColor="#f3f6f9"></TD>
	</TR>
	<TR>
		<TD class="NormalGreenBold" vAlign="top" align="left" bgColor="#f3f6f9">
		</TD>
	</TR>
	<tr>
		<td align="left" class="TaskStyle" valign="top" bgColor="#f3f6f9"><!--Angajat curent : 
			&nbsp;-->
			<asp:DropDownList id="lstAngajati" runat="server" Width="392px" AutoPostBack="True"></asp:DropDownList>
		</td>
	</tr>
	<tr>
		<td class="BlueSeparator" colSpan="2"><IMG height="1" src="../../images/1x1.gif"></td>
	</tr>
	<tr>
		<td colspan="2" id="Container" height="100%" runat="server" valign="top">
			<uc1:SituatieLunaraAngajat id="SituatieLunaraAngajat1" runat="server"></uc1:SituatieLunaraAngajat>
		</td>
	</tr>
</table>
