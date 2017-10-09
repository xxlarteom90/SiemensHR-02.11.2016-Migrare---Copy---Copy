<%@ Register TagPrefix="uc1" TagName="AdminTari" Src="AdminTari.ascx" %>
<%@ Page language="c#" Codebehind="AdminTariAddAngajat.aspx.cs" AutoEventWireup="false" Inherits="SiemensHR.Administrare.AdminTariAddAngajat" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Administrare tari</title>
		<LINK href="../StyleHR.css" type="text/css" rel="stylesheet">
		<script language="javascript" src="../js/jsCode.js"></script>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<table align="center" width="100%">
			<tr align="center">
				<td align="center">
					<uc1:AdminTari id="AdminTari" runat="server"></uc1:AdminTari>
				</td>
			</tr>
		</table>
		<script>
 		RefreshAddAngajatPage();
		</script>
	</body>
</HTML>
