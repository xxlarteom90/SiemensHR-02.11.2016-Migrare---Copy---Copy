<%@ Register TagPrefix="uc1" TagName="UserInfo" Src="Module/UserInfo.ascx" %>
<%@ Register TagPrefix="uc1" TagName="HeaderMenu" Src="Module/HeaderMenu.ascx" %>
<%@ Register TagPrefix="uc1" TagName="PageHeader" Src="Module/PageHeader.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Intervale" Src="Module/Intervale.ascx" %>
<%@ Register TagPrefix="uc1" TagName="TimeStamp" Src="Module/TimeStamp.ascx" %>
<%@ Control Language="c#" AutoEventWireup="false" Codebehind="PontajModule.ascx.cs" Inherits="SiemensHR.InterfataSalarii.Module.Pontaj.PontajModule" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>
<script language="javascript" src="Module/Pontaj/js/jsCode.js"></script>
<script language="javascript" src="Module/Pontaj/js/Intervale.js"></script>
<table height="100%" width="100%">
	<tr>
		<td height="100%" width="100%">
			<table id="BottomTable" height="100%" width="100%">
				<tr>
				</tr>
				<TR>
					<td id="CenterContainer" vAlign="top" width="100%" runat="server">
						<table class="tabBackground" id="CenterTable" width="100%">
							<tr style="width:100%">
								<td id="TimeStampContainer" runat="server" style="width:100%">&nbsp;
									<uc1:timestamp id="TimeStamp1" runat="server"></uc1:timestamp></td>
							</tr>
							<tr>
								<td id="IntervaleContainer" runat="server">&nbsp;&nbsp;
									<uc1:intervale id="Intervale1" runat="server"></uc1:intervale></td>
							</tr>
						</table>
					</td>
				</TR>
			</table>
		</td>
	</tr>
</table>
</TD></TR></TBODY></TABLE>
