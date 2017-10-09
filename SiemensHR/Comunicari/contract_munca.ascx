<%@ Control Language="c#" AutoEventWireup="false" Codebehind="contract_munca.ascx.cs" Inherits="SiemensHR.Comunicari.contract_munca" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>
<HTML>
	<HEAD>
		<title>HR Toolkit</title>
		<meta content="True" name="vs_showGrid">
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="StyleHR.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body>
		<STRONG>
			<P align="center">
				<TABLE id="Table1" cellSpacing="1" cellPadding="0" width="500" border="0">
					<tr>
						<td align="center"><asp:table id="Table2" runat="server"></asp:table></td>
					</tr>
					<tr>
						<td class="tabBackground" align="left">
							<table border="0" width="100%" cellpadding="0" cellspacing="0">
								<TR>
									<TD class="NormalGreenBold" style="HEIGHT: 22px">Manager general:</TD>
									<TD>
										<asp:TextBox id="txtManagerGeneral" runat="server" Width="293px" CssClass="NormalEditBoxuri"
											Enabled="False" ReadOnly="True"></asp:TextBox></TD>
								</TR>
								<tr>
									<td class="GreenSeparator" colSpan="2"><IMG height="1" src="images/1x1.gif"></td>
								</tr>
								<TR>
									<TD class="NormalGreenBold" style="HEIGHT: 14px">Director economic:</TD>
									<TD>
										<asp:TextBox id="txtDirectorEconomic" runat="server" Width="292px" CssClass="NormalEditBoxuri"
											Enabled="False" ReadOnly="True"></asp:TextBox></TD>
								</TR>
								<tr>
									<td class="GreenSeparator" colSpan="2"><IMG height="1" src="images/1x1.gif"></td>
								</tr>
								<TR>
									<TD class="NormalGreenBold" style="HEIGHT: 14px">Manager HR:</TD>
									<TD>
										<asp:TextBox id="txtManagerHR" runat="server" Width="292px" CssClass="NormalEditBoxuri" Enabled="False"
											ReadOnly="True"></asp:TextBox></TD>
								</TR>
							</table>
						</td>
					</tr>
					<tr>
						<td align="center" height="50"><asp:button id="btnGenerati" onmouseover="MouseOverButton(this)" onmouseout="MouseOutButton(this)"
								runat="server" CssClass="ButtonStyle" Text="   Generati   "></asp:button></td>
					</tr>
					<tr>
						<td align="left" height="50"><asp:label id="lblEroare" runat="server" cssclass="NormalGreenBold"></asp:label></td>
					</tr>
				</TABLE>
			</P>
		</STRONG>
	</body>
</HTML>
