<%@ Page language="c#" Codebehind="Recrutori.aspx.cs" AutoEventWireup="false" Inherits="SiemensHR.Recrutori.Recrutori" %>
<%@ Register TagPrefix="uc1" TagName="HeaderMenu" Src="HeaderMenu_Recrutori.ascx" %>
<%@ Register TagPrefix="uc1" TagName="PageHeader" Src="../PageHeader.ascx"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>HR Toolkit</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../StyleHR.css" type="text/css" rel="stylesheet">
		<script language="javascript" src="../js/jsCode.js"></script>
	</HEAD>
	<body>
		<script>

		function CautareAvansata_Click()
		{
			if( tableCautareAvansataVisible.style.display=="none" )
			{
				tableCautareAvansataVisible.style.display = "";
				document.getElementById( tableCautareRapidaClient ).cells[ 0, 1 ].innerText = "Cautare avansata";
				document.getElementById( txtTipCautareHiddenClient ).value = "cautare avansata";
				document.getElementById( "btnCautareAvansata" ).value = "Activeaza cautare rapida";
			}
			else
			{
				tableCautareAvansataVisible.style.display = "none";
				document.getElementById( tableCautareRapidaClient ).cells[ 0, 1 ].innerText = "Cautare rapida";
				document.getElementById( txtTipCautareHiddenClient ).value = "cautare rapida";
				document.getElementById( "btnCautareAvansata" ).value = "Activeaza cautare avansata";
			}
		}
				
		function lstTipDataAngajareChanged()
		{
			var tipDataCautare = document.getElementById( lstTipDataAngajareSearchClient ).value;
		
			tdDataFixaSearch.style.display = "none";
			tdLunaSearch.style.display = "none";
			tdIntervalSearch.style.display = "none";
			switch( tipDataCautare )
			{
				case '0':
					tdDataFixaSearch.style.display = "";
					break;
				case '1':
					tdLunaSearch.style.display = "";
					break;
				case '2':
					tdIntervalSearch.style.display = "";
					break;
				case '-1':
					break;
			}
		}
		
		/*function RadioButtonDataFixaChanged()
		{
			tdDataFixaSearch.style.display = "";
			tdLunaSearch.style.display = "none";
			tdIntervalSearch.style.display = "none";
		}
		
		function RadioButtonLunaChanged()
		{
			tdDataFixaSearch.style.display = "none";
			tdLunaSearch.style.display = "";
			tdIntervalSearch.style.display = "none";
		}
		
		function RadioButtonIntervalChanged()
		{
			tdDataFixaSearch.style.display = "none";
			tdLunaSearch.style.display = "none";
			tdIntervalSearch.style.display = "";
		}
		
		function RadioButtonToateContracteleChanged()
		{
			tdDataFixaSearch.style.display = "none";
			tdLunaSearch.style.display = "none";
			tdIntervalSearch.style.display = "none";
		}*/
		
		
		function lstScutireImpozitChanged( lstScutireImpozit )
		{
			//document.getElementById( DTaraHiddenClient ).value = dTara.value;
			
			GolesteLstCategoriiSearch();
			
			UmpleLstCategoriiSearch( lstScutireImpozit.value );
		}

		function GolesteLstCategoriiSearch()
		{
			var categ = document.getElementById( lstCategoriiSearchClient );
			//document.write( "#####"+document.getElementById( lstDJudeteClient )+"^^^^^^^" );
			while( categ.length > 0 )
			{
				categ.remove( categ.selectedIndex );
			}
		}
		//functia de umplere a categoriilor in functie de ce e selectat in comboul cu scutirea de impozit		
		function UmpleLstCategoriiSearch( valoare )
		{
			var categ = document.getElementById( lstCategoriiSearchClient );
			for( i=0; i<categorii[ 0 ].length; i++ )
			{
				if( categorii[ 1 ][ i ] == -1 || categorii[ 2 ][ i ] == valoare || valoare == -1 )
				{
					var o = new Option();
					o.text = categorii[ 0 ][ i ];
					o.value = categorii[ 1 ][ i ];
					categ.add( o, i );
				}
			}
			//document.getElementById( DJudetHiddenClient ).value = judCombo.value;
			//document.write( "%%%%%"+judCombo.length+"********" );
		}
		
		function lstContBancarExistentaChanged()
		{
			var contExistenta = document.getElementById( lstContBancarExistentaSearchClient ).value;
			switch( contExistenta )
			{
				case '0':
					document.getElementById( lblBancaClient ).style.display = "none";
					document.getElementById( lstBancaSearchClient ).style.display = "none";
					break;
				case '1':
					document.getElementById( lblBancaClient ).style.display = "";
					document.getElementById( lstBancaSearchClient ).style.display = "";
					break;
				case '-1':
					document.getElementById( lblBancaClient ).style.display = "none";
					document.getElementById( lstBancaSearchClient ).style.display = "none";
					break;
			}
		}
		
		function lstDeducereSearchChanged()
		{
			var deducere = document.getElementById( lstDeducereSearchClient ).value;
			switch( deducere )
			{
				case '0':
					document.getElementById( lblCopiiClient ).style.display = "none";
					document.getElementById( lstDeducereCopiiSearchClient ).style.display = "none";
					break;
				case '1':
					document.getElementById( lblCopiiClient ).style.display = "";
					document.getElementById( lstDeducereCopiiSearchClient ).style.display = "";
					break;
				case '-1':
					document.getElementById( lblCopiiClient ).style.display = "none";
					document.getElementById( lstDeducereCopiiSearchClient ).style.display = "none";
					break;
			}
		}
		
		</script>
		<form id="Form2" name="form_search" action="" runat="server">
			<table cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
				<tr>
					<td><uc1:pageheader id="PageHeader1" runat="server" relativePath="../"></uc1:pageheader></td>
				</tr>
				<tr>
					<td style="HEIGHT: 24px" align="center"><uc1:headermenu id="HeaderMenu1" runat="server" relativePath="../"></uc1:headermenu></td>
				</tr>
				<tr>
					<td align="center">
						<table cellSpacing="0" cellPadding="0" width="450" border="0">
							<tr>
								<td colSpan="2"><IMG height="20" src="../images/1x1.gif"></td>
							</tr>
							<tr>
								<td class="BigBlueBold" align="center" colSpan="2">Formular de cautare angajati</td>
							</tr>
							<tr>
								<td colSpan="2"><IMG height="20" src="../images/1x1.gif"></td>
							</tr>
							<tr>
								<td align="center" colSpan="2"><asp:table id="tableCautareRapida" runat="server"></asp:table></td>
							</tr>
							<tr>
								<td colSpan="2"><IMG height="1" src="../images/1x1.gif"></td>
							</tr>
							<tr>
								<td class="tabBackground" align="center" colSpan="2">
									<table cellSpacing="0" cellPadding="0" width="100%" border="0">
										<tr>
											<td class="NormalGreenBold" width="18%" height="25">Nume:</td>
											<td><asp:textbox id="txtNumeSearch" runat="server" MaxLength="50" CssClass="NormalEditBoxuri"></asp:textbox></td>
										</tr>
										<tr>
											<td class="GreenSeparator" colSpan="2"><IMG height="1" src="../images/1x1.gif"></td>
										</tr>
										<tr>
											<td class="NormalGreenBold" width="18%" height="25">Prenume:</td>
											<td><asp:textbox id="txtPrenumeSearch" runat="server" MaxLength="50" CssClass="NormalEditBoxuri"></asp:textbox></td>
										</tr>
										<tr>
											<td align="center" colSpan="2">
												<table id="tableCautareAvansataVisible" cellSpacing="0" cellPadding="0" width="100%" runat="server">
													<!-- inceput tabel cautare avansata -->
													<tr>
														<td class="GreenSeparator" colSpan="2"><IMG height="1" src="../images/1x1.gif"></td>
													</tr>
													<tr>
														<td class="tabBackgroundColor" align="center" colSpan="2">
															<table cellSpacing="0" cellPadding="0" width="100%">
																<TR>
																	<TD class="NormalGreenBold" width="18%" height="25">Nationalitate:</TD>
																	<td><asp:dropdownlist id="lstNationalitateSearch" CssClass="SelectStyle" Width="150px" Runat="server"></asp:dropdownlist></td>
																</TR>
																<tr>
																	<td class="GreenSeparator" colSpan="2"><IMG height="1" src="../images/1x1.gif"></td>
																</tr>
																<TR>
																	<TD class="NormalGreenBold" width="18%" height="25">Tara de orgine:</TD>
																	<td><asp:dropdownlist id="lstTaraOrigineSearch" runat="server" CssClass="SelectStyle" Width="250px"></asp:dropdownlist></td>
																</TR>
																<tr>
																	<td class="GreenSeparator" colSpan="2"><IMG height="1" src="../images/1x1.gif"></td>
																</tr>
																<TR>
																	<TD class="NormalGreenBold" width="18%" height="25">Stare civila:</TD>
																	<TD><asp:dropdownlist id="lstStareCivilaSearch" runat="server" CssClass="SelectStyle" Width="250px">
																			<asp:ListItem Value="-1">&#160;</asp:ListItem>
																			<asp:ListItem Value="0">Casatorit</asp:ListItem>
																			<asp:ListItem Value="1">Necasatorit</asp:ListItem>
																			<asp:ListItem Value="2">Divortat</asp:ListItem>
																			<asp:ListItem Value="3">Vaduv</asp:ListItem>
																		</asp:dropdownlist></TD>
																</TR>
																<tr>
																	<td class="GreenSeparator" colSpan="2"><IMG height="1" src="../images/1x1.gif"></td>
																</tr>
																<TR>
																	<TD class="NormalGreenBold" width="18%" height="25">Copii:</TD>
																	<TD><asp:dropdownlist id="lstCopiiSearch" runat="server" CssClass="SelectStyle" Width="50px">
																			<asp:ListItem Value="-1">&#160;</asp:ListItem>
																			<asp:ListItem Value="1">Da</asp:ListItem>
																			<asp:ListItem Value="0">Nu</asp:ListItem>
																		</asp:dropdownlist></TD>
																</TR>
																<tr>
																	<td class="GreenSeparator" colSpan="2"><IMG height="1" src="../images/1x1.gif"></td>
																</tr>
																<TR>
																	<TD class="NormalGreenBold" width="18%" height="25">Sex:</TD>
																	<TD><asp:dropdownlist id="lstSexSearch" runat="server" CssClass="SelectStyle" Width="250px">
																			<asp:ListItem Value="-1">&#160;</asp:ListItem>
																			<asp:ListItem Value="m">Masculin</asp:ListItem>
																			<asp:ListItem Value="f">Feminin</asp:ListItem>
																		</asp:dropdownlist></TD>
																</TR>
																<tr>
																	<td class="GreenSeparator" colSpan="2"><IMG height="1" src="../images/1x1.gif"></td>
																</tr>
																<TR>
																	<TD class="NormalGreenBold" width="18%" height="25" style="HEIGHT: 25px">Titlu:</TD>
																	<TD style="HEIGHT: 25px"><asp:dropdownlist id="lstTitulaturaSearch" runat="server" CssClass="SelectStyle" Width="250px"></asp:dropdownlist></TD>
																</TR>
																<tr>
																	<td class="GreenSeparator" colSpan="2"><IMG height="1" src="../images/1x1.gif"></td>
																</tr>
																<TR>
																	<TD class="NormalGreenBold" width="18%" height="25">Studii:</TD>
																	<TD><asp:dropdownlist id="lstStudiiSearch" runat="server" CssClass="SelectStyle" Width="250px"></asp:dropdownlist></TD>
																</TR>
																<tr>
																	<td class="GreenSeparator" colSpan="2"><IMG height="1" src="../images/1x1.gif"></td>
																</tr>
																<TR>
																	<TD class="NormalGreenBold" width="18%" height="25">Marca:</TD>
																	<TD><asp:textbox id="txtMarcaSearch" runat="server" CssClass="NormalEditBoxuri"></asp:textbox></TD>
																</TR>
																<tr>
																	<td class="GreenSeparator" colSpan="2"><IMG height="1" src="../images/1x1.gif"></td>
																</tr>
																<TR>
																	<TD class="NormalGreenBold" width="18%" height="25">Departament:</TD>
																	<TD><asp:dropdownlist id="lstDepartamentSearch" runat="server" CssClass="SelectStyle" Width="250px"></asp:dropdownlist></TD>
																</TR>
																<tr>
																	<td class="GreenSeparator" colSpan="2"><IMG height="1" src="../images/1x1.gif"></td>
																</tr>
																<TR>
																	<TD class="NormalGreenBold" width="18%" height="25">Functie:</TD>
																	<TD><asp:dropdownlist id="lstFunctieSearch" runat="server" CssClass="SelectStyle" Width="250px"></asp:dropdownlist></TD>
																</TR>
																<tr>
																	<td class="GreenSeparator" colSpan="2"><IMG height="1" src="../images/1x1.gif"></td>
																</tr>
																<TR>
																	<TD class="NormalGreenBold" width="18%" height="25">Mod incadrare:</TD>
																	<TD><asp:dropdownlist id="lstModIncadrareSearch" runat="server" CssClass="SelectStyle" Width="250px">
																			<asp:ListItem Value="-1">&#160;</asp:ListItem>
																			<asp:ListItem Value="0">Cu functia de baza</asp:ListItem>
																			<asp:ListItem Value="1">Cu functia de baza la alta societate</asp:ListItem>
																		</asp:dropdownlist></TD>
																</TR>
																<tr>
																	<td class="GreenSeparator" colSpan="2"><IMG height="1" src="../images/1x1.gif"></td>
																</tr>
																<TR>
																	<TD class="NormalGreenBold" width="18%" height="25">Indemnizatie de conducere:</TD>
																	<TD><asp:dropdownlist id="lstIndemnizatieConducereSearch" runat="server" CssClass="SelectStyle" Width="50px">
																			<asp:ListItem Value="-1">&#160;</asp:ListItem>
																			<asp:ListItem Value="1">Da</asp:ListItem>
																			<asp:ListItem Value="0">Nu</asp:ListItem>
																		</asp:dropdownlist></TD>
																</TR>
																<tr>
																	<td class="GreenSeparator" colSpan="2"><IMG height="1" src="../images/1x1.gif"></td>
																</tr>
																<TR>
																	<TD class="NormalGreenBold" width="18%" height="25">Categorie angajat:</TD>
																	<TD class="NormalGreenBold">Scutit impozit:<asp:dropdownlist id="lstScutitImpozitSearch" runat="server" CssClass="SelectStyle" Width="50px" onchange="lstScutireImpozitChanged( this );">
																			<asp:ListItem Value="-1">&#160;</asp:ListItem>
																			<asp:ListItem Value="1">Da</asp:ListItem>
																			<asp:ListItem Value="0">Nu</asp:ListItem>
																		</asp:dropdownlist>
																		Categorie:<asp:dropdownlist id="lstCategorieAngajatSearch" runat="server" CssClass="SelectStyle" Width="150px"></asp:dropdownlist>
																	</TD>
																</TR>
																<tr>
																	<td class="GreenSeparator" colSpan="2"><IMG height="1" src="../images/1x1.gif"></td>
																</tr>
																<TR>
																	<TD class="NormalGreenBold" width="18%" height="22" style="HEIGHT: 22px">Deducere:</TD>
																	<TD class="NormalGreenBold" style="HEIGHT: 42px"><asp:dropdownlist id="lstDeducereSearch" runat="server" CssClass="SelectStyle" Width="50px" onchange="lstDeducereSearchChanged();">
																			<asp:ListItem Value="-1">&#160;</asp:ListItem>
																			<asp:ListItem Value="1">Da</asp:ListItem>
																			<asp:ListItem Value="0">Nu</asp:ListItem>
																		</asp:dropdownlist><asp:label id="lblCopii" Runat="server">&nbsp;&nbsp;Copii:</asp:label><asp:dropdownlist id="lstDeducereCopiiSearch" runat="server" CssClass="SelectStyle" Width="50px">
																			<asp:ListItem Value="1">Da</asp:ListItem>
																			<asp:ListItem Value="0">Nu</asp:ListItem>
																		</asp:dropdownlist></TD>
																</TR>
																<tr>
																	<td class="GreenSeparator" colSpan="2"><IMG height="1" src="../images/1x1.gif"></td>
																</tr>
																<TR>
																	<TD class="NormalGreenBold" width="18%" height="25">Conturi bancare:</TD>
																	<TD class="NormalGreenBold"><asp:dropdownlist id="lstContBancarExistentaSearch" runat="server" CssClass="SelectStyle" Width="50px"
																			onchange="lstContBancarExistentaChanged();">
																			<asp:ListItem Value="-1">&#160;</asp:ListItem>
																			<asp:ListItem Value="1">Da</asp:ListItem>
																			<asp:ListItem Value="0">Nu</asp:ListItem>
																		</asp:dropdownlist><asp:label id="lblBanca" Runat="server">&nbsp;&nbsp;Banca:</asp:label><asp:dropdownlist id="lstBancaSearch" runat="server" CssClass="SelectStyle" Width="200px"></asp:dropdownlist></TD>
																</TR>
																<tr>
																	<td class="GreenSeparator" colSpan="2"><IMG height="1" src="../images/1x1.gif"></td>
																</tr>
																<TR>
																	<TD class="NormalGreenBold" vAlign="middle" width="18%" height="25" rowSpan="2">Data 
																		angajarii:</TD>
																	<td class="NormalGreenBold">Tip cautare:&nbsp;
																		<asp:dropdownlist id="lstTipDataAngajareSearch" CssClass="SelectStyle" Width="150px" Runat="server"
																			onchange="lstTipDataAngajareChanged();">
																			<asp:ListItem Value="-1" Selected="True">&#160;</asp:ListItem>
																			<asp:ListItem Value="0" Selected="False">Data fixa</asp:ListItem>
																			<asp:ListItem Value="1" Selected="False">Luna</asp:ListItem>
																			<asp:ListItem Value="2" Selected="False">Interval</asp:ListItem>
																		</asp:dropdownlist></td>
																</TR>
																<tr>
																	<td>
																		<table>
																			<tr>
																				<td id="tdDataFixaSearch" runat="server" class="NormalGreenBold">
																					<!-- Optiunea 1--> Data:&nbsp;<asp:textbox id="txtDataAngajatiSearch" style="CURSOR: hand" onclick="ShowCalendar(this,'../')"
																						runat="server" MaxLength="10" CssClass="NormalEditBoxuri" Width="70px" ReadOnly="True" Height="0px"></asp:textbox></td>
																				<td id="tdLunaSearch" runat="server" class="NormalGreenBold">
																					<!-- Optiunea 2--> Luna:&nbsp;<asp:dropdownlist id="lstLunaAngajatiSearch" CssClass="SelectStyle" Runat="server"></asp:dropdownlist>
																					&nbsp;&nbsp;&nbsp;Anul:&nbsp;<asp:dropdownlist id="lstAnAngajatiSearch" CssClass="SelectStyle" Runat="server"></asp:dropdownlist></td>
																				<td id="tdIntervalSearch" runat="server" class="NormalGreenBold">
																					<!-- Optiunea 3--> Interval:&nbsp;<asp:textbox id="txtDataStartAngajatiSearch" style="CURSOR: hand" onclick="ShowCalendar(this,'../')"
																						runat="server" MaxLength="10" CssClass="NormalEditBoxuri" Width="70px" ReadOnly="True" Height="0px"></asp:textbox>
																					&nbsp;-&nbsp;<asp:textbox id="txtDataEndAngajatiSearch" style="CURSOR: hand" onclick="ShowCalendar(this,'../')"
																						runat="server" MaxLength="10" CssClass="NormalEditBoxuri" Width="70px" ReadOnly="True" Height="0px"></asp:textbox>
																					<!-- Optiunea 4 --></td>
																			</tr>
																		</table>
																	</td>
																</tr>
																<tr>
																	<td class="GreenSeparator" colSpan="2"><IMG height="1" src="../images/1x1.gif"></td>
																</tr>
																<TR>
																	<TD class="NormalGreenBold" width="18%" height="25">Contract pe perioada 
																		determinata:</TD>
																	<TD><asp:dropdownlist id="lstPerioadaDeterminataSearch" runat="server" CssClass="SelectStyle" Width="50px">
																			<asp:ListItem Value="-1">&#160;</asp:ListItem>
																			<asp:ListItem Value="1">Da</asp:ListItem>
																			<asp:ListItem Value="0">Nu</asp:ListItem>
																		</asp:dropdownlist></TD>
																</TR>
															</table>
														</td>
													</tr>
													<!-- sfarsit  tabel cautare avansata--></table>
											</td>
										</tr>
									</table>
								</td>
							</tr>
							<!-- locul unde era inainte tabelul de cautare avansata -->
							<TR>
								<TD class="NormalGreenBold" align="center" colSpan="2" height="50"><input class="ButtonStyle" id="btnCautareAvansata" onclick="CautareAvansata_Click();" type="button"
										value="Activeaza cautare avansata" name="btnCautareAvansata" runat="server">
									&nbsp;&nbsp;
									<asp:button id="btnAdvancedSearch" onmouseover="MouseOverButton(this)" onmouseout="MouseOutButton(this)"
										runat="server" CssClass="ButtonStyle" Text=" Cauta "></asp:button></TD>
							</TR>
						</table>
					</td>
				</tr>
			</table>
			<input id="txtTipCautareHidden" type="hidden" name="txtTipCautareHidden" runat="server">
		</form>
	</body>
</HTML>
