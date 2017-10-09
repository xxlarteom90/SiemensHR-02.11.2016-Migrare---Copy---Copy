<%@ Control Language="c#" AutoEventWireup="false" Codebehind="rapoarte_StatDePlata.ascx.cs" Inherits="SiemensHR.InterfataSalarii.Module.rapoarte_StatDePlata" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<%@ Register TagPrefix="cc1" Namespace="ReportingServices" Assembly="ReportViewer" %>
<meta content="False" name="vs_showGrid">
<script>
	
	function AddRemoveAll(sursa,destinatie,dir)
	{
		var Sirul = document.getElementById(SirID);
		if (sursa.options.length > 0)
		{
			for(i = 0; i < sursa.options.length; i++ )
			{
				var selText = sursa.options[i].text;	
				var selValue = sursa.options[i].value;
				var opt = new Option(selText, selValue);
				destinatie.add(opt);
				if(dir==0)
					Sirul.value+=opt.value;
			}
			sursa.options.length = 0;
			if(dir==1) Sirul.value=" ";
		}
		//alert(Sirul.value);
	}
	
	
	function AddRemoveItem(sursa, destinatie,dir)
	{
		var Sirul = document.getElementById(SirID);
		if(sursa.selectedIndex >= 0)
		{
			while (sursa.selectedIndex >=0)
				{
					var selText =  sursa.options[sursa.selectedIndex].text;
					var selValue = sursa.options[sursa.selectedIndex].value;
					var opt = new Option(selText, selValue);
					destinatie.add(opt);
					if (dir ==0 ) Sirul.value += opt.value;
					sursa.remove(sursa.selectedIndex);
				}
				if(dir==1) {
					Sirul.value=" ";
					var i
					for(i=0; i<sursa.length;i++)
					Sirul.value+= sursa.options[i].value;		
				}
		}
		else
			alert("Trebuie sa selectati o coloana din lista diponibila!");
			//alert(Sirul.value);
	}
	
	
function Outline()
{

	window.event.returnValue=0	

	//Expand or collapse if a list item is clicked.
	var open = event.srcElement;

	//Verify that the tag which was clicked was either the 
	//trigger tag or nested within a trigger tag.
	var el = checkParent(open,"A");
	if(null != el)
	{	
		var incr=0;
		var elmPos = 0;
		var parentSpan;
		var fBreak

		//Get the position of the element which was clicked
		elemPos = window.event.srcElement.sourceIndex;

		//Search for a SPAN tag
		for (parentSpan = window.event.srcElement.parentElement;
			parentSpan!=null;
			parentSpan = parentSpan.parentElement) 
		{
			//test if already at a span tag 
		    if (parentSpan.tagName=="DIV") 
			{
				//alert("Parent Element is a SPAN");
				incr=1;
				break;
			}
			
			//Test if the tag clicked was in a body tag or in any of the possible kinds of lists
			//we perform this test because nested lists require special handling
			if (parentSpan.tagName=="BODY" || parentSpan.tagName=="UL" || parentSpan.tagName=="OL"|| parentSpan.tagName=="P") 
			{
				//Determine where the span to be expanded is.  
				for (incr=1; (elemPos+incr) < document.all.length; incr++)
				{	
					//verify we are at an expandable Div tag
					if(document.all(elemPos+incr).tagName=="DIV" && 
					(document.all(elemPos+incr).className=="expanded" ||
					 document.all(elemPos+incr).className=="collapsed"))
					{
						fBreak=1;
						break;
					}
					//If the next tag following the list item (li) is another 
					//list item(li) return in order to prevent accidentally opening
					//the next span in the list
					else if(document.all(elemPos+incr).tagName=="LI")
					{
						return;
					}
				}
			}
			//determine if we need to break out of the while loop (kind of a kludge since theres no goto in javascript)
			if(fBreak==1)
			{
				break;
			}
		}

	}
	else
	{
		//Alert("Return!");
		return;
	}

	//Now that we've identified the span, expand or collapse it
	if(document.all(elemPos+incr).className=="collapsed")
	{
		
		document.all(elemPos+incr).className="expanded"
		document.all(elemPos+1).src="bluedrop.gif";
		//if(open.tagName=="IMG"){open.src="bluedrop.gif";}
		if(open.tagName=="B")
			{
			//if(open.parentElement.all.tags("IMG").length != 0)
				//{open.parentElement.all.tags("IMG").item(0).src="bluedrop.gif";}
			}
	}
	else if(document.all(elemPos+incr).className=="expanded")
	{
		document.all(elemPos+incr).className="collapsed"
		//document.all(elemPos+1).src="blueup.gif";
		//if(open.tagName=="IMG"){open.src="blueup.gif";}
		if(open.tagName=="B")
			{
			//if(open.parentElement.all.tags("IMG").length != 0)
				//{open.parentElement.all.tags("IMG").item(0).src="blueup.gif";}
			}
	}
	else
	{
		return;
	}
	event.cancelBubble = true;
//	open.scrollIntoView(true);
}

function checkParent(src,dest)
{
	//Search for a specific parent of the current element.
	while(src !=null)
	{
		if(src.tagName == dest)
		{
			return src;
		}
		src = src.parentElement;
	}
	return null;
}
	
</script>
<table id="main" style="HEIGHT: 1020px" height="1020" width="100%">
	<tr>
		<td>&nbsp; <A class="NormalGreenBold" onkeypress="Outline()" onclick="Outline()" href="#">
				Optiuni</A>
			<div class="collapsed" id="ExpCol">
				<TABLE id="Table1" style="WIDTH: 745px; HEIGHT: 166px" cellSpacing="1" cellPadding="1"
					width="745" align="center" border="0">
					<TBODY>
						<TR>
							<TD style="WIDTH: 194px; HEIGHT: 21px" align="center"></TD>
							<TD style="WIDTH: 51px; HEIGHT: 21px" align="center"></TD>
							<TD style="WIDTH: 188px; HEIGHT: 21px" align="center"></TD>
							<TD style="WIDTH: 179px; HEIGHT: 21px" align="center"></TD>
						</TR>
						<TR>
							<TD style="WIDTH: 194px" align="center" rowSpan="4"><asp:listbox id="lstMasuri" SelectionMode="Multiple" BorderStyle="Outset" runat="server" Width="217px"
									Height="140"></asp:listbox></TD>
							<TD style="WIDTH: 51px" align="center"><INPUT class="ButtonStyle" id="buttonAddAll" style="WIDTH: 28px; HEIGHT: 28px" onclick="javascript:AddRemoveAll(document.getElementById(listaMasuriID),document.getElementById(listaMasuriSelectateID),0)"
									type="button" size="20" value=">>">
							</TD>
							<TD style="WIDTH: 188px" align="center" rowSpan="4"><asp:listbox id="lstSelectedMasuri" SelectionMode="Multiple" Width="217px" Height="140" Runat="server"></asp:listbox></TD>
							<TD style="WIDTH: 179px" align="center" rowSpan="4"><asp:button id="btnAfiseaza" runat="server" Text="Afiseaza" CssClass="ButtonStyle" CausesValidation="False"></asp:button></TD>
						</TR>
						<TR>
							<TD style="WIDTH: 51px" align="center">
								<P><INPUT class="ButtonStyle" id="buttonAdd" style="WIDTH: 28px; HEIGHT: 28px" onclick="javascript:AddRemoveItem(document.getElementById(listaMasuriID),document.getElementById(listaMasuriSelectateID),0)"
										type="button" size="20" value=">"></P>
							</TD>
						</TR>
						<TR>
							<TD style="WIDTH: 51px" align="center">
								<P><INPUT class="ButtonStyle" id="buttonRemove" style="WIDTH: 28px; HEIGHT: 28px" onclick="javascript:AddRemoveItem(document.getElementById(listaMasuriSelectateID),document.getElementById(listaMasuriID),1)"
										type="button" size="20" value="<"></P>
							</TD>
						</TR>
						<TR>
							<TD style="WIDTH: 51px" align="center">
								<P><INPUT class="ButtonStyle" id="buttonRemoveAll" style="WIDTH: 28px; HEIGHT: 28px" onclick="javascript:AddRemoveAll(document.getElementById(listaMasuriSelectateID),document.getElementById(listaMasuriID),1)"
										type="button" value="<<"></P>
							</TD>
						</TR>
					</TBODY>
				</TABLE>
				<INPUT id="HiddenMask" type="hidden" runat="server">
			</div>
		</td>
	</tr>
	<TR>
		<TD style="HEIGHT: 22px" align="center"><asp:label id="labelError" runat="server" CssClass="AlertRedBold"></asp:label></TD>
	</TR>
	<TR>
		<TD vAlign="top"><cc1:reportviewer id="rapStatPlata" runat="server" Width="100%" Height="500px"
				BackColor="White" BorderColor="Transparent" Parameters="False" Toolbar="True" ForeColor="White" Zoom="100%"
				ReportPath="/Rapoarte/StatDePlata"></cc1:reportviewer></TD>
	</TR>
</table>
