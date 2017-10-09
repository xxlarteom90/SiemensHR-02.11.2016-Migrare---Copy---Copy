<%@ Control Language="c#" AutoEventWireup="false" Codebehind="ManagersOptions.ascx.cs" Inherits="SiemensHR.ManagersOptions" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>
<script>
function SelectManagersOption( option )
{
	document.location = "Managers.aspx?cmd=" + option;
}

</script>
<asp:table id="OptionTable" runat="server"></asp:table>
