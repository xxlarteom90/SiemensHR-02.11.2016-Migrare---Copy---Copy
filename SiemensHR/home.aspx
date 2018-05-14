<%@ Register TagPrefix="uc1" TagName="HeaderMenu" Src="HeaderMenu.ascx" %>
<%@ Register TagPrefix="uc1" TagName="PageHeader" Src="PageHeader.ascx" %>
<%@ Register TagPrefix="uc1" TagName="AngAlerteSpeciale" Src="AlerteSpeciale/AngAlerteSpeciale.ascx" %>
<%@ Register TagPrefix="uc1" TagName="AngExpiraContractLunaCurenta" Src="AlerteSpeciale/AngExpiraContractLunaCurenta.ascx" %>
<%@ Register TagPrefix="uc1" TagName="AngExpiraPasaport" Src="AlerteSpeciale/AngExpiraPasaport.ascx" %>
<%@ Register TagPrefix="uc1" TagName="AngExpiraPermisSedere" Src="AlerteSpeciale/AngExpiraPermisSedere.ascx" %>
<%@ Register TagPrefix="uc1" TagName="AngExpiraPermisMunca" Src="AlerteSpeciale/AngExpiraPermisMunca.ascx" %>
<%@ Register TagPrefix="uc1" TagName="AngExpiraDataMajorareStabilita" Src="AlerteSpeciale/AngExpiraDataMajorareStabilita.ascx" %>
<%@ Page language="c#" Codebehind="Home.aspx.cs" AutoEventWireup="false" Inherits="SiemensHR.home" %>
<%@ Register TagPrefix="uc1" TagName="AngExpiraRetinere" Src="AlerteSpeciale/AngExpiraRetinere.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>HR Toolkit</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="StyleHR.css" type="text/css" rel="stylesheet">
		<script language="javascript" src="js/jsCode.js"></script>
		<script>
			function EditAngajat(obj)
			{

                //Artiom Modificat 03.04.2017  
			    //document.location = "EditAngajat.aspx?id=" + obj.childNodes(1).innerText;  
			    //var x = obj.childNodes[1];
			    var x = obj.children[1];
			    if (x.innerText !== undefined)
			    {
			        document.location = "EditAngajat.aspx?id=" + x.innerText;
			    }

			}	
		</script>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD><uc1:pageheader id="PageHeader1" runat="server"></uc1:pageheader></TD>
				</TR>
				<TR>
					<TD align="center"><uc1:headermenu id="HeaderMenu1" runat="server"></uc1:headermenu></TD>
				</TR>
			</TABLE>
			<table cellSpacing="0" cellPadding="0" width="450" align="center" border="0">
				<tr>
					<td><IMG height="20" src="images/1x1.gif">
					</td>
				</tr>
				<tr>
					<td align="center" colSpan="2" style="HEIGHT: 44px">
						<uc1:AngExpiraContractLunaCurenta id="AngExpiraContractLunaCurenta1" runat="server"></uc1:AngExpiraContractLunaCurenta>
					</td>
				</tr>
				<tr>
					<td></td>
				</tr>
			</table>
			<table cellSpacing="0" cellPadding="0" width="450" align="center" border="0">
				<tr>
					<td><IMG height="20" src="images/1x1.gif">
					</td>
				</tr>
				<tr>
					<td align="center" colSpan="2" style="HEIGHT: 44px">
						<uc1:AngExpiraPasaport id="AngExpiraPasaport1" runat="server"></uc1:AngExpiraPasaport>
					</td>
				</tr>
				<tr>
					<td></td>
				</tr>
			</table>
			<table cellSpacing="0" cellPadding="0" width="450" align="center" border="0">
				<tr>
					<td><IMG height="20" src="images/1x1.gif">
					</td>
				</tr>
				<tr>
					<td align="center" colSpan="2" style="HEIGHT: 44px">
						<uc1:AngExpiraPermisSedere id="AngExpiraPermisSedere1" runat="server"></uc1:AngExpiraPermisSedere>
					</td>
				</tr>
				<tr>
					<td></td>
				</tr>
			</table>
			<table cellSpacing="0" cellPadding="0" width="450" align="center" border="0">
				<tr>
					<td><IMG height="20" src="images/1x1.gif">
					</td>
				</tr>
				<tr>
					<td align="center" colSpan="2" style="HEIGHT: 44px">
						<uc1:AngExpiraPermisMunca id="AngExpiraPermisMunca1" runat="server"></uc1:AngExpiraPermisMunca>
					</td>
				</tr>
				<tr>
					<td></td>
				</tr>
			</table>
			<table cellSpacing="0" cellPadding="0" width="450" align="center" border="0">
				<tr>
					<td><IMG height="20" src="images/1x1.gif">
					</td>
				</tr>
				<tr>
					<td align="center" colSpan="2" style="HEIGHT: 44px">
						<uc1:AngExpiraDataMajorareStabilita id="AngExpiraDataMajorareStabilita1" runat="server"></uc1:AngExpiraDataMajorareStabilita>
					</td>
				</tr>
				<tr>
					<td></td>
				</tr>
			</table>
			<table cellSpacing="0" cellPadding="0" width="450" align="center" border="0">
				<tr>
					<td><IMG height="20" src="images/1x1.gif">
					</td>
				</tr>
				<tr>
					<td align="center" colSpan="2" style="HEIGHT: 44px">
						<uc1:AngAlerteSpeciale id="AngAlerteSpeciale" runat="server"></uc1:AngAlerteSpeciale>
					</td>
				</tr>
				<tr>
					<td></td>
				</tr>
			</table>
			<table cellSpacing="0" cellPadding="0" width="450" align="center" border="0">
				<tr>
					<td><IMG height="20" src="images/1x1.gif">
					</td>
				</tr>
				<tr>
					<td align="center" colSpan="2" style="HEIGHT: 44px">
						<P>
							<uc1:AngExpiraRetinere id="AngExpiraRetinere1" runat="server"></uc1:AngExpiraRetinere></P>
					</td>
				</tr>
				<tr>
					<td></td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
