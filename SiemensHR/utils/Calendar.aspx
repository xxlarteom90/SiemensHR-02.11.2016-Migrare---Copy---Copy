<%@ Page language="c#" Codebehind="Calendar.aspx.cs" AutoEventWireup="false" Inherits="SiemensHR.utils.Calendar" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Calendar</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../StyleHR.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<table cellSpacing="0" cellPadding="0" width="100%" border="0">
				<tr>
					<td class="NormalBlackBold" align="right">Luna: &nbsp;</td>
					<td><asp:dropdownlist onChange="Form1.submit()" id="lstMonth" runat="server">
							<asp:ListItem Value="1">Ianuarie</asp:ListItem>
							<asp:ListItem Value="2">Februarie</asp:ListItem>
							<asp:ListItem Value="3">Martie</asp:ListItem>
							<asp:ListItem Value="4">Aprilie</asp:ListItem>
							<asp:ListItem Value="5">Mai</asp:ListItem>
							<asp:ListItem Value="6">Iunie</asp:ListItem>
							<asp:ListItem Value="7">Iulie</asp:ListItem>
							<asp:ListItem Value="8">August</asp:ListItem>
							<asp:ListItem Value="9">Septembrie</asp:ListItem>
							<asp:ListItem Value="10">Octombrie</asp:ListItem>
							<asp:ListItem Value="11">Noiembrie</asp:ListItem>
							<asp:ListItem Value="12">Decembrie</asp:ListItem>
						</asp:dropdownlist></td>
					<td class="NormalBlackBold" align="center">Anul:&nbsp;</td>
					<td><asp:dropdownlist onChange="Form1.submit()" id="lstYear" runat="server"></asp:dropdownlist></td>
				</tr>
				<tr>
					<td colSpan="4"><asp:calendar id="Calendar1" runat="server" NextPrevFormat="ShortMonth">
							<DayStyle Font-Size="Smaller" Font-Names="Arial" BorderWidth="1px" BorderStyle="Solid" BackColor="White"></DayStyle>
							<NextPrevStyle Font-Size="Smaller" Font-Names="Arial" Font-Bold="True" ForeColor="White"></NextPrevStyle>
							<DayHeaderStyle Font-Size="Smaller" Font-Names="Arial" Font-Bold="True" BorderWidth="1px" ForeColor="White"
								BorderStyle="Solid" BackColor="LightSeaGreen"></DayHeaderStyle>
							<SelectedDayStyle BackColor="Silver"></SelectedDayStyle>
							<TodayDayStyle BackColor="Silver"></TodayDayStyle>
							<TitleStyle Font-Names="Arial" Font-Bold="True" ForeColor="White" BackColor="#7B8FC2"></TitleStyle>
							<WeekendDayStyle Font-Size="Smaller" Font-Names="Arial" BackColor="#E0E0E0"></WeekendDayStyle>
						</asp:calendar></td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
