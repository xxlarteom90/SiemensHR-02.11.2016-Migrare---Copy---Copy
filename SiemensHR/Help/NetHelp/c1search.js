// global members
var _d2hSecondaryWindowsByTopics = null;
var _d2hAppletInitialized = 0;

function d2hInitSecondaryWindows()
{
    if (_d2hSecondaryWindowsByTopics == null)
    {
        _d2hSecondaryWindowsByTopics = new Array();
        _d2hSecondaryWindowsByTopics["worddocuments/cutarerapid.htm"] = "right";
_d2hSecondaryWindowsByTopics["worddocuments/cutareavansat.htm"] = "right";
_d2hSecondaryWindowsByTopics["worddocuments/altele.htm"] = "right";
_d2hSecondaryWindowsByTopics["worddocuments/alertespeciale.htm"] = "right";
_d2hSecondaryWindowsByTopics["worddocuments/comunicri.htm"] = "right";
_d2hSecondaryWindowsByTopics["worddocuments/comunicareindexare.htm"] = "right";
_d2hSecondaryWindowsByTopics["worddocuments/comunicareindexaremajorare.htm"] = "right";
_d2hSecondaryWindowsByTopics["worddocuments/comunicaremajorare.htm"] = "right";
_d2hSecondaryWindowsByTopics["worddocuments/comunicareprim.htm"] = "right";
_d2hSecondaryWindowsByTopics["worddocuments/dateangajat.htm"] = "right";
_d2hSecondaryWindowsByTopics["worddocuments/checkupuri.htm"] = "right";
_d2hSecondaryWindowsByTopics["worddocuments/conturibanc.htm"] = "right";
_d2hSecondaryWindowsByTopics["worddocuments/dateangajare.htm"] = "right";
_d2hSecondaryWindowsByTopics["worddocuments/datepersonale.htm"] = "right";
_d2hSecondaryWindowsByTopics["worddocuments/evaluripsihologice.htm"] = "right";
_d2hSecondaryWindowsByTopics["worddocuments/persoanenntreinere.htm"] = "right";
_d2hSecondaryWindowsByTopics["worddocuments/situaiemilitar.htm"] = "right";
_d2hSecondaryWindowsByTopics["worddocuments/documenteangajat.htm"] = "right";
_d2hSecondaryWindowsByTopics["worddocuments/adeverinmedicfamilie.htm"] = "right";
_d2hSecondaryWindowsByTopics["worddocuments/contractdemunc.htm"] = "right";
_d2hSecondaryWindowsByTopics["worddocuments/fiapostului.htm"] = "right";
_d2hSecondaryWindowsByTopics["worddocuments/istoriceangajat.htm"] = "right";
_d2hSecondaryWindowsByTopics["worddocuments/istoriccriidentitate.htm"] = "right";
_d2hSecondaryWindowsByTopics["worddocuments/istoricconcediimedicale.htm"] = "right";
_d2hSecondaryWindowsByTopics["worddocuments/istoricconcediiodihn.htm"] = "right";
_d2hSecondaryWindowsByTopics["worddocuments/istoricntrerupericim.htm"] = "right";
_d2hSecondaryWindowsByTopics["worddocuments/istoricdepartamente.htm"] = "right";
_d2hSecondaryWindowsByTopics["worddocuments/istoricfuncii.htm"] = "right";
_d2hSecondaryWindowsByTopics["worddocuments/istoriclegitimaiiedere.htm"] = "right";
_d2hSecondaryWindowsByTopics["worddocuments/istoricnif.htm"] = "right";
_d2hSecondaryWindowsByTopics["worddocuments/istoricpaapoarte.htm"] = "right";
_d2hSecondaryWindowsByTopics["worddocuments/istoricpermisemunc.htm"] = "right";
_d2hSecondaryWindowsByTopics["worddocuments/istoricreferine.htm"] = "right";
_d2hSecondaryWindowsByTopics["worddocuments/istoricschimbri.htm"] = "right";
_d2hSecondaryWindowsByTopics["worddocuments/istorictraining.htm"] = "right";
_d2hSecondaryWindowsByTopics["worddocuments/iniializarelun.htm"] = "right";
_d2hSecondaryWindowsByTopics["worddocuments/lichidareangajat.htm"] = "right";
_d2hSecondaryWindowsByTopics["worddocuments/pontajindividual.htm"] = "right";
_d2hSecondaryWindowsByTopics["worddocuments/situaielunarangajat.htm"] = "right";
_d2hSecondaryWindowsByTopics["worddocuments/importpontaj.htm"] = "right";
_d2hSecondaryWindowsByTopics["worddocuments/calculareasalariilornlunaactiv.htm"] = "right";
_d2hSecondaryWindowsByTopics["worddocuments/nchiderealuniiactive.htm"] = "right";
_d2hSecondaryWindowsByTopics["worddocuments/redeschiderealuniianterioare.htm"] = "right";
_d2hSecondaryWindowsByTopics["worddocuments/contribuiiangajator.htm"] = "right";
_d2hSecondaryWindowsByTopics["worddocuments/declaraiecasa11.htm"] = "right";
_d2hSecondaryWindowsByTopics["worddocuments/declaraiecasa12.htm"] = "right";
_d2hSecondaryWindowsByTopics["worddocuments/declaraiesntateanexa3a.htm"] = "right";
_d2hSecondaryWindowsByTopics["worddocuments/declaraiesntateanexa3b.htm"] = "right";
_d2hSecondaryWindowsByTopics["worddocuments/declaraiesomajcap1.htm"] = "right";
_d2hSecondaryWindowsByTopics["worddocuments/declaraiesomajcap2.htm"] = "right";
_d2hSecondaryWindowsByTopics["worddocuments/fiiermulticache.htm"] = "right";
_d2hSecondaryWindowsByTopics["worddocuments/raportaccescldire.htm"] = "right";
_d2hSecondaryWindowsByTopics["worddocuments/raportchcm.htm"] = "right";
_d2hSecondaryWindowsByTopics["worddocuments/raportcursuri.htm"] = "right";
_d2hSecondaryWindowsByTopics["worddocuments/raportcursuriangajai.htm"] = "right";
_d2hSecondaryWindowsByTopics["worddocuments/statdeplatdetaliat.htm"] = "right";
_d2hSecondaryWindowsByTopics["worddocuments/statdeplatcufunciadebaznaltparte.htm"] = "right";
_d2hSecondaryWindowsByTopics["worddocuments/statdeplatnescutiideimpozit.htm"] = "right";
_d2hSecondaryWindowsByTopics["worddocuments/statdeplatscutiideimpozit.htm"] = "right";
_d2hSecondaryWindowsByTopics["worddocuments/statdeplatpepunctedelucru.htm"] = "right";
_d2hSecondaryWindowsByTopics["worddocuments/tichetedemas.htm"] = "right";
_d2hSecondaryWindowsByTopics["worddocuments/statinspectoratteritorialdemunca.htm"] = "right";
_d2hSecondaryWindowsByTopics["worddocuments/contracteinspectoratteritorialdemunca.htm"] = "right";
_d2hSecondaryWindowsByTopics["worddocuments/anexalanl.htm"] = "right";
_d2hSecondaryWindowsByTopics["worddocuments/fisefiscale.htm"] = "right";
_d2hSecondaryWindowsByTopics["worddocuments/categoriisalariale.htm"] = "right";
_d2hSecondaryWindowsByTopics["worddocuments/concediimedicale.htm"] = "right";
_d2hSecondaryWindowsByTopics["worddocuments/inflaielunar.htm"] = "right";
_d2hSecondaryWindowsByTopics["worddocuments/nomenclatorboli.htm"] = "right";
_d2hSecondaryWindowsByTopics["worddocuments/nomenclatortipuriabsene.htm"] = "right";
_d2hSecondaryWindowsByTopics["worddocuments/nomenclatortipuriorelucrate.htm"] = "right";
_d2hSecondaryWindowsByTopics["worddocuments/srbtorilegale.htm"] = "right";
_d2hSecondaryWindowsByTopics["worddocuments/tipurireineri.htm"] = "right";
_d2hSecondaryWindowsByTopics["worddocuments/variabilesalarizare.htm"] = "right";
_d2hSecondaryWindowsByTopics["worddocuments/bnci.htm"] = "right";
_d2hSecondaryWindowsByTopics["worddocuments/casedeasigurri.htm"] = "right";
_d2hSecondaryWindowsByTopics["worddocuments/judee.htm"] = "right";
_d2hSecondaryWindowsByTopics["worddocuments/tipurirapoartepsihologice.htm"] = "right";
_d2hSecondaryWindowsByTopics["worddocuments/ri.htm"] = "right";
_d2hSecondaryWindowsByTopics["worddocuments/angajatori.htm"] = "right";
_d2hSecondaryWindowsByTopics["worddocuments/centrecost.htm"] = "right";
_d2hSecondaryWindowsByTopics["worddocuments/completarecarnetemunc.htm"] = "right";
_d2hSecondaryWindowsByTopics["worddocuments/departamente.htm"] = "right";
_d2hSecondaryWindowsByTopics["worddocuments/domeniideactivitate.htm"] = "right";
_d2hSecondaryWindowsByTopics["worddocuments/cursuri.htm"] = "right";
_d2hSecondaryWindowsByTopics["worddocuments/funcii.htm"] = "right";
_d2hSecondaryWindowsByTopics["worddocuments/invaliditi.htm"] = "right";
_d2hSecondaryWindowsByTopics["worddocuments/studii.htm"] = "right";
_d2hSecondaryWindowsByTopics["worddocuments/titluri.htm"] = "right";
_d2hSecondaryWindowsByTopics["worddocuments/variabilesalarizare1.htm"] = "right";
_d2hSecondaryWindowsByTopics["worddocuments/bazadedate.htm"] = "right";
_d2hSecondaryWindowsByTopics["worddocuments/primulangajator.htm"] = "right";
_d2hSecondaryWindowsByTopics["worddocuments/adugareutilizator.htm"] = "right";
_d2hSecondaryWindowsByTopics["worddocuments/schimbareparola.htm"] = "right";
_d2hSecondaryWindowsByTopics["worddocuments/cutarerapid1.htm"] = "right";
_d2hSecondaryWindowsByTopics["worddocuments/cutareavansat1.htm"] = "right";
_d2hSecondaryWindowsByTopics["worddocuments/dateangajat1.htm"] = "right";
_d2hSecondaryWindowsByTopics["worddocuments/checkupuri2.htm"] = "right";
_d2hSecondaryWindowsByTopics["worddocuments/datepersonale1.htm"] = "right";
_d2hSecondaryWindowsByTopics["worddocuments/evaluripsihologice1.htm"] = "right";
_d2hSecondaryWindowsByTopics["worddocuments/documenteangajat1.htm"] = "right";
_d2hSecondaryWindowsByTopics["worddocuments/fiapostului1.htm"] = "right";
_d2hSecondaryWindowsByTopics["worddocuments/istoriceangajat1.htm"] = "right";
_d2hSecondaryWindowsByTopics["worddocuments/istoriccriidentitate1.htm"] = "right";
_d2hSecondaryWindowsByTopics["worddocuments/istoricdepartamente1.htm"] = "right";
_d2hSecondaryWindowsByTopics["worddocuments/istoricfuncii1.htm"] = "right";
_d2hSecondaryWindowsByTopics["worddocuments/istoricreferine1.htm"] = "right";
_d2hSecondaryWindowsByTopics["worddocuments/istorictraining1.htm"] = "right";

    }
}

function newDocContext(strTitle, strData)
{
    var elem = "<html><head>"
    if (strTitle != "")
        elem += "<title>" + strTitle + "</title>";
    elem += "</head><body>";
    elem += strData;
    elem += "</body></html>";
    document.clear();
    document.write(elem);
}

function browserNotSupported()
{
    var strData = MSG_BROWSERNOTSUPPORTED;
    document.forms[1].innerHTML = strData;
}

function errorHandler(error)
{
    var strData = error == 0 ? MSG_SEARCHENGINENOTLOADED : MSG_SEARCHENGINENOTLOADED_PATHCONTAINSNONASCII;
    document.forms[1].innerHTML = strData;
    return true;
}

function d2hAppletInitialized()
{
    _d2hAppletInitialized = -1;
}

function accessibilityTest(win, app, func)
{
    if (_d2hAppletInitialized != -1 && _d2hAppletInitialized < 50)
    {
        _d2hAppletInitialized ++;
        setTimeout("processQuery()", 100);
    }
    else if (_d2hAppletInitialized == -1)
        return true;
    else
    {
        var root = d2hGetRoot(win.location.pathname);
        root = unescape(root);
        if (d2hIsAsciiOnly(root))
            func(0);
        else
            func(1);
    }
    return false;
}

function search(doc, app, strQuery)
{
    var elem = doc.forms[1];
    if (elem.parentNode)
        elem.parentNode.setAttribute("nowrap", true);
    waitCursor(doc, true);
    elem.innerHTML = app.execQuery(strQuery);
    waitCursor(doc, false);
}

function waitCursor(doc, isWait)
{
}
