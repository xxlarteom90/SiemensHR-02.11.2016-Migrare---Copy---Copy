<%@ Control Language="c#" AutoEventWireup="false" Codebehind="ManagersOptions_EvSalAngDept.ascx.cs" Inherits="SiemensHR.ManagersOptions_EvSalAngDept" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<FORM id="Form1" name="Form1" method="post" runat="server">
	<TABLE id="Table1" height="100%" cellSpacing="0" cellPadding="0" width="100%" border="0">
		<TR>
			<TD class="GreenSeparator" colSpan="3" height="1"><IMG height="1" src="images/1x1.gif"></TD>
		</TR>
		<TR style="FONT-WEIGHT: bold; TEXT-TRANSFORM: none; COLOR: #20b2aa; FONT-FAMILY: Arial">
			<TD align="center" colSpan="3" height="35">Salariile angajatilor&nbsp;din 
				departamentul&nbsp;
				<asp:label id="numeDept" runat="server"></asp:label></TD>
		</TR>
		<TR>
			<TD class="GreenSeparator" colSpan="3" height="1"><IMG height="1" src="images/1x1.gif"></TD>
		</TR>
		<TR class="NormalGreenBold">
			<TD style="HEIGHT: 36px" align="left">
				<DIV id="DataStart" style="DISPLAY: inline; WIDTH: 192px; HEIGHT: 22px" ms_positioning="FlowLayout">Data 
					de inceput a perioadei&nbsp;&nbsp;</DIV>
				<asp:textbox id="txtDataStart" style="CURSOR: hand" onclick="ShowCalendar(this,'../')" runat="server"
					CssClass="NormalEditBoxuri" Width="100px" ReadOnly="True" Height="20px" MaxLength="10"></asp:textbox></TD>
			<TD style="HEIGHT: 36px" align="left">
				<DIV id="DataStop" style="DISPLAY: inline; WIDTH: 177px; HEIGHT: 22px" align="left" ms_positioning="FlowLayout">Data 
					de sfarsit a perioadei&nbsp;</DIV>
				<asp:textbox id="txtDataStop" style="CURSOR: hand" onclick="ShowCalendar(this,'../')" runat="server"
					CssClass="NormalEditBoxuri" Width="100px" ReadOnly="True" Height="20px" MaxLength="10"></asp:textbox></TD>
			<TD><asp:button id="btnAfiseaza" runat="server" CssClass="ButtonStyle" Width="95px" Text="Afiseaza"></asp:button></TD>
		</TR>
		<TR>
			<TD style="HEIGHT: 10px" align="left"><asp:requiredfieldvalidator id="RequiredFieldValidator1" runat="server" CssClass="AlertRedBold" ControlToValidate="txtDataStart"
					ErrorMessage="Data de start nu a fost introdusa"></asp:requiredfieldvalidator></TD>
			<TD><asp:requiredfieldvalidator id="RequiredFieldValidator2" runat="server" CssClass="AlertRedBold" ControlToValidate="txtDataStop"
					ErrorMessage="Data de stop nu a fost introdusa"></asp:requiredfieldvalidator></TD>
			<TD><INPUT id="Hidden1" type="hidden" name="Hidden1" runat="server"></TD>
		</TR>
		<TR>
			<TD vAlign="top" colSpan="3">
				<center><div id="div1" class="Collapsed">
						<OBJECT id="SpSheet" style="WIDTH: 512px; HEIGHT: 408px" align="middle" classid="clsid:0002E559-0000-0000-C000-000000000046">
							<PARAM NAME="DataType" VALUE="XMLDATA">
							<PARAM NAME="XMLData" VALUE='<?xml version="1.0"?>&#13;&#10;<ss:Workbook xmlns:x="urn:schemas-microsoft-com:office:excel"&#13;&#10; xmlns:ss="urn:schemas-microsoft-com:office:spreadsheet"&#13;&#10; xmlns:c="urn:schemas-microsoft-com:office:component:spreadsheet">&#13;&#10; <x:ExcelWorkbook>&#13;&#10;  <x:ProtectStructure>False</x:ProtectStructure>&#13;&#10;  <x:ActiveSheet>0</x:ActiveSheet>&#13;&#10; </x:ExcelWorkbook>&#13;&#10; <ss:Styles>&#13;&#10;  <ss:Style ss:ID="Default">&#13;&#10;   <ss:Alignment ss:Horizontal="Automatic" ss:Rotate="0.0" ss:Vertical="Bottom"&#13;&#10;    ss:ReadingOrder="Context"/>&#13;&#10;   <ss:Borders>&#13;&#10;   </ss:Borders>&#13;&#10;   <ss:Font ss:FontName="Arial" ss:Size="10" ss:Color="Automatic" ss:Bold="0"&#13;&#10;    ss:Italic="0" ss:Underline="None"/>&#13;&#10;   <ss:Interior ss:Color="Automatic" ss:Pattern="None"/>&#13;&#10;   <ss:NumberFormat ss:Format="General"/>&#13;&#10;   <ss:Protection ss:Protected="1"/>&#13;&#10;  </ss:Style>&#13;&#10; </ss:Styles>&#13;&#10; <c:ComponentOptions>&#13;&#10;  <c:Label>&#13;&#10;   <c:Caption>Microsoft Office Spreadsheet</c:Caption>&#13;&#10;  </c:Label>&#13;&#10;  <c:MaxHeight>80%</c:MaxHeight>&#13;&#10;  <c:MaxWidth>80%</c:MaxWidth>&#13;&#10;  <c:NextSheetNumber>4</c:NextSheetNumber>&#13;&#10; </c:ComponentOptions>&#13;&#10; <x:WorkbookOptions>&#13;&#10;  <c:OWCVersion>11.0.0.6555         </c:OWCVersion>&#13;&#10;  <x:Height>10795</x:Height>&#13;&#10;  <x:Width>13547</x:Width>&#13;&#10; </x:WorkbookOptions>&#13;&#10; <ss:Worksheet ss:Name="Sheet1">&#13;&#10;  <x:WorksheetOptions>&#13;&#10;   <x:Selected/>&#13;&#10;   <x:ViewableRange>R1:R262144</x:ViewableRange>&#13;&#10;   <x:Selection>R1C1</x:Selection>&#13;&#10;   <x:TopRowVisible>0</x:TopRowVisible>&#13;&#10;   <x:LeftColumnVisible>0</x:LeftColumnVisible>&#13;&#10;   <x:ProtectContents>False</x:ProtectContents>&#13;&#10;  </x:WorksheetOptions>&#13;&#10;  <c:WorksheetOptions>&#13;&#10;  </c:WorksheetOptions>&#13;&#10; </ss:Worksheet>&#13;&#10; <ss:Worksheet ss:Name="Sheet2">&#13;&#10;  <x:WorksheetOptions>&#13;&#10;   <x:ViewableRange>R1:R262144</x:ViewableRange>&#13;&#10;   <x:Selection>R1C1</x:Selection>&#13;&#10;   <x:TopRowVisible>0</x:TopRowVisible>&#13;&#10;   <x:LeftColumnVisible>0</x:LeftColumnVisible>&#13;&#10;   <x:ProtectContents>False</x:ProtectContents>&#13;&#10;  </x:WorksheetOptions>&#13;&#10;  <c:WorksheetOptions>&#13;&#10;  </c:WorksheetOptions>&#13;&#10; </ss:Worksheet>&#13;&#10; <ss:Worksheet ss:Name="Sheet3">&#13;&#10;  <x:WorksheetOptions>&#13;&#10;   <x:ViewableRange>R1:R262144</x:ViewableRange>&#13;&#10;   <x:Selection>R1C1</x:Selection>&#13;&#10;   <x:TopRowVisible>0</x:TopRowVisible>&#13;&#10;   <x:LeftColumnVisible>0</x:LeftColumnVisible>&#13;&#10;   <x:ProtectContents>False</x:ProtectContents>&#13;&#10;  </x:WorksheetOptions>&#13;&#10;  <c:WorksheetOptions>&#13;&#10;  </c:WorksheetOptions>&#13;&#10; </ss:Worksheet>&#13;&#10;</ss:Workbook>&#13;&#10;'>
							<PARAM NAME="AllowPropertyToolbox" VALUE="-1">
							<PARAM NAME="AutoFit" VALUE="0">
							<PARAM NAME="Calculation" VALUE="-4105">
							<PARAM NAME="Caption" VALUE="Microsoft Office Spreadsheet">
							<PARAM NAME="DisplayColumnHeadings" VALUE="-1">
							<PARAM NAME="DisplayGridlines" VALUE="-1">
							<PARAM NAME="DisplayHorizontalScrollBar" VALUE="-1">
							<PARAM NAME="DisplayOfficeLogo" VALUE="-1">
							<PARAM NAME="DisplayPropertyToolbox" VALUE="0">
							<PARAM NAME="DisplayRowHeadings" VALUE="-1">
							<PARAM NAME="DisplayTitleBar" VALUE="0">
							<PARAM NAME="DisplayToolbar" VALUE="-1">
							<PARAM NAME="DisplayVerticalScrollBar" VALUE="-1">
							<PARAM NAME="DisplayWorkbookTabs" VALUE="-1">
							<PARAM NAME="EnableEvents" VALUE="-1">
							<PARAM NAME="MaxHeight" VALUE="80%">
							<PARAM NAME="MaxWidth" VALUE="80%">
							<PARAM NAME="MoveAfterReturn" VALUE="-1">
							<PARAM NAME="MoveAfterReturnDirection" VALUE="-4121">
							<PARAM NAME="RightToLeft" VALUE="0">
							<PARAM NAME="ScreenUpdating" VALUE="-1">
							<PARAM NAME="LockedDown" VALUE="0">
							<PARAM NAME="ConnectedToChart" VALUE="0">
							<PARAM NAME="DefaultQueryOnLoad" VALUE="-1">
							<PARAM NAME="EnableUndo" VALUE="-1">
						</OBJECT>
					</div>
				</center>
				<div id="div2" align="center" runat="server">
					<table cellSpacing="6" class="tabBackground" cellPadding="0" ID="Table3" style="WIDTH: 344px; HEIGHT: 56px"
						borderColor="green">
						<TR>
							<TD class="NormalBlackBold" align="center"><font size="3"> Nu a fost selectata nici o 
									inregistrare. </font>
							</TD>
						</TR>
						<tr>
							<td class="NormalBlackBold" align="center"><font size="3"> Va rugam definiti o alta 
									perioada de timp.</font></td>
						</tr>
					</table>
				</div>
			</TD>
		</TR>
	</TABLE>
	<script>
		//Modificat:	Oprescu Claudia
		//Data:			22.09.2006
		//Descriere:	Aparea eroare ca nu exista forma __aspnetForm. 
		//				S-a renuntat la utilizarea acestei functii si acceseaza controalele folosind getElementById
		//				Data raportului sunt continute in campul _ctl2_Hidden
		function DoBind()
		{
			var str='';
			/*eval('str=__aspnetForm.'+ctrlID+'_Hidden1.value');
			if(str!=''){
				eval("__aspnetForm.SpSheet.DataType='CSVDATA'");
				eval("__aspnetForm.SpSheet.CSVData=str");
				eval("__aspnetForm.SpSheet.Columns.AutoFit()");
				eval("__aspnetForm.SpSheet.Toolbar.Buttons.Remove(3)");
				eval("__aspnetForm.SpSheet.Toolbar.Buttons.Remove(2)");
				eval("__aspnetForm.SpSheet.Toolbar.Buttons.Remove(16)");
				eval("__aspnetForm.SpSheet.Toolbar.Buttons.Remove(16)");
				eval("__aspnetForm.SpSheet.Cells(2,1).EntireRow.Font.Bold=true");
				eval("div1.className='Expanded'")
			}*/
			str = document.getElementById('_ctl2_Hidden1').value;
			if(str!=''){
				document.getElementById('SpSheet').DataType='CSVDATA';
				document.getElementById('SpSheet').CSVData=str;
				document.getElementById('SpSheet').Columns.AutoFit();
				document.getElementById('SpSheet').Toolbar.Buttons.Remove(3);
				document.getElementById('SpSheet').Toolbar.Buttons.Remove(2);
				document.getElementById('SpSheet').Toolbar.Buttons.Remove(16);
				document.getElementById('SpSheet').Toolbar.Buttons.Remove(16);
				document.getElementById('SpSheet').Cells(2,1).EntireRow.Font.Bold=true;
				document.getElementById('div1').className = 'Expanded';
			}
		}
		DoBind();
	</script>
</FORM>
