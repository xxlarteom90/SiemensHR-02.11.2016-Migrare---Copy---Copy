<%@ Control Language="c#" AutoEventWireup="false" Codebehind="PageHeader.ascx.cs" Inherits="SiemensHR.PageHeader" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>
<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0" height="80">
	<tr>
		<td>
			<table cellSpacing="0" height="100%" cellPadding="0" width="100%" border="0">
				<tr>
					<td width="100%" align="left" class="BigPageHeader">&nbsp;&nbsp;&nbsp;&nbsp; <span class="BigPageHeader1">
							HR Toolkit</span> </td>
				</tr>
				<tr>
					<td class="NormalBlueBold"><%Response.Write(Session["AngajatorDenumire"]);%></td>
				</tr>
			</table>
		</td>
		<td align="right">
			<table>
				<tr>
					<td colspan="3" height=3></td>
				</tr>
				<tr>
					<td width="3"></td>
					<td align="right" width="455"><img src="<%Response.Write(this.relativePath);%>images/header1.gif"></td>
					<td width="3"></td>
				</tr>
				<tr>
					<td colspan="3" height=3></td>
				</tr>
			</table>
		</td>
	</tr>
</TABLE>
