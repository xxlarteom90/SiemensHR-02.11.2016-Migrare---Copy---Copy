<%@ Register TagPrefix="uc1" TagName="UserInfo" Src="Module/UserInfo.ascx" %>
<%@ Register TagPrefix="uc1" TagName="HeaderMenu" Src="Module/HeaderMenu.ascx" %>
<%@ Register TagPrefix="uc1" TagName="PageHeader" Src="Module/PageHeader.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Intervale" Src="Module/Intervale.ascx" %>
<%@ Register TagPrefix="uc1" TagName="TimeStamp" Src="Module/TimeStamp.ascx" %>
<%@ Control Language="c#" AutoEventWireup="false" Codebehind="TimeStamp.ascx.cs" Inherits="SiemensHR.InterfataSalarii.Module.Pontaj.TimeStamp" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>
<form id="FormIntervale" method="post" runat="server">
	<table height="100%" width="100%">
		<tr>
			<td><uc1:pageheader id="PageHeader1" runat="server"></uc1:pageheader></td>
		</tr>
		<tr>
			<td id="TopMenuContainer" vAlign="top" runat="server">
				<table id="Table1" width="100%" runat="server">
					<tr>
						<td><uc1:headermenu id="HeaderMenu1" runat="server"></uc1:headermenu></td>
					</tr>
				</table>
			</td>
		<tr>
			<td height="100%">
				<table id="BottomTable" height="100%" width="100%">
					<tr>
					</tr>
					<TR>
						<td id="LeftContainer" height="100%">
							<table id="LeftTable" height="100%">
								<tr>
									<td id="Td1" vAlign="top" runat="server"><uc1:userinfo id="UserInfo1" runat="server"></uc1:userinfo></td>
								</tr>
							</table>
						</td>
						<td id="CenterContainer" vAlign="top" width="100%" runat="server">
							<table class="tabBackground" id="CenterTable" width="100%">
								<tr>
									<td id="date_container" runat="server" class="NormalGreenBold" style="HEIGHT: 16px">
										&nbsp;Luna :&nbsp;
										<asp:dropdownlist id="LunaCurenta" runat="server" AutoPostBack="True"></asp:dropdownlist></td>
								</tr>
								<tr>
									<td id="TimeStampContainer" runat="server">&nbsp;
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
	</TD></TR></TBODY></TABLE> <input type="hidden" id="ClientSelectedDate" runat="server" NAME="ClientSelectedDate">
</form>
