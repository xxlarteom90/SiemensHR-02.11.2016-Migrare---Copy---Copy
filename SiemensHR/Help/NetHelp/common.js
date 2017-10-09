
// Global -----------------------
var popupState = -1; // -1 - unknown; 0 - loading; 1 - loaded;
var popupDocument = null;
var popClientPos = null;
var popUpShown = null;
var nstextHeight = -1;
var _d2hInlinePopup = null;
var _d2hIndex = new d2hIndexTable();
var _d2hPopupMenu = null;
// ------------------------------

function isOpera()
{
    var strUserAgent = navigator.userAgent.toLowerCase();
    var res = strUserAgent.indexOf("opera") == -1 ? false : true;
    return res;
}

function getOperaVersionNumber()
{
    var strUserAgent = navigator.userAgent.toLowerCase();
    var indx = strUserAgent.indexOf("opera");
    if (indx < 0)
    {
        return 0;
    }
    var end = strUserAgent.indexOf(" ", indx + 6);
    var ver = strUserAgent.substring(indx + 6, end);
    return parseFloat(ver);
}

function isIE()
{
    var appname = navigator.appName.toLowerCase();
    return (appname == "microsoft internet explorer");
}

function getIEVersion()
{
    var ua = navigator.userAgent;
    var MSIEOffset = ua.indexOf("MSIE ");
    if (MSIEOffset == -1)
        return "0";
    else
        return ua.substring(MSIEOffset + 5, ua.indexOf(";", MSIEOffset));
}

function getIEVersionNumber()
{
    return parseFloat(getIEVersion());
}

function isNN()
{
    var ua = navigator.userAgent.toLowerCase();
    var bGecko = (ua.indexOf("gecko") > -1);
    if (bGecko)
    {
        return ua.indexOf("netscape") > -1;
    }
    return false;
}
function getNNVersionNumber( )
{
    var ua = navigator.userAgent.toLowerCase();
    var indx = ua.indexOf("netscape");
    if (indx == -1)
    {
        return 0;
    }
    else
    {
        var indxN = ua.indexOf("/", indx);
        if (indxN > -1)
        {
            indx = indxN + 1;
        }
        else
        {
            indx += 10;
        }
        var end = ua.indexOf(" ", indx);
        if (end == -1)
        {
            end = ua.length;
        }
        var ver = ua.substring(indx, end);
        indx = ver.indexOf(".");
        if (indx > -1)
        {
            var val = ver.substring(0, indx + 1);
            while (ver.indexOf(".", indx) > -1)
            {
                ver = ver.replace(".", "");
            }
            ver = val + ver.substring(indx);
        }
        return parseFloat(ver);
    }
}

function isMozilla()
{
    var ua = navigator.userAgent.toLowerCase();
    var bGecko = (ua.indexOf("gecko") > -1);
    if (bGecko)
    {
        return ua.indexOf("netscape") < 0;
    }
    return false;
}
function getMozillaVersionNumber( )
{
    var ua = navigator.userAgent.toLowerCase();
    var indx = ua.indexOf("rv:");
    if (indx == -1)
    {
        return 0;
    }
    else
    {
        indx += 3;
        var end = ua.indexOf(")", indx);
        if (end > -1)
        {
            return parseFloat(ua.substring(indx, end));
        }
        else
        {
            return parseFloat(ua.substring(indx));
        }
    }
}

function verifyBrowser()
{
    if (isOpera())
    {
        if (getOperaVersionNumber() < 7.54)
        {
            browserNotSupported();
            return false;
        }
    }
    else if (isNN())
    {
        if (getNNVersionNumber() < 6.23)
        {
            browserNotSupported();
            return false;
        }
    }
    else if (isMozilla())
    {
        if (getMozillaVersionNumber() < 1.2)
        {
            browserNotSupported();
            return false;
        }
    }
    return true;
}

function getSearchVal(strS, offset)
{
    var endstr = strS.indexOf('&', offset);
    if (endstr == -1)
    {
        endstr = strS.length + 1;
    }
    var val = strS.substring(offset, endstr);
    var test = val.replace('+', ' ');
    while (val.indexOf(test) == -1)
    {
        val = test;
        test = val.replace('+', ' ');
    }
    return decodeURIComponent(test);
}

function getQueryVal(strS, name)
{
    var arg = name + "=";
    var alen = arg.length;
    var clen = strS.length;
    var i = 0;
    while (i < clen)
    {
        var j = i + alen;
        if (strS.substring(i, j) == arg)
        {
            return getSearchVal(strS, j);
        }
        i = strS.indexOf("&", i) + 1;
        if (i == 0) break; 
    }
    return "";
} 

function getElemById(doc, id)
{
    try
    {
        if (typeof doc.all != "undefined")
            return doc.all(id);
        else
            return doc.getElementById(id);
    }
    catch(e)
    {
    }
    return null;
}

function getFrameByName(strName, wnd)
{
    var frm = null;
    try
    {
        if (typeof wnd == "undefined" || wnd == null)
            wnd = window;
        if (typeof wnd.parent.document.frames != "undefined")
            frm = wnd.parent.document.frames[strName];
        else
        {
            var arrFrames = wnd.parent.document.getElementsByName(strName);
            if (arrFrames == null || arrFrames.length == 0)
                return null;
            frm = arrFrames[0];
        }
    }
    catch(e)
    {
    }
    return frm;
}

function getIFrameById(strId)
{
    var frm;
    if (typeof document.frames != "undefined")
        frm = document.frames[strId];
    else
        frm = getElemById(document, strId);
    return frm;
}

function getFrameDocument(frm)
{
    var doc = null;
    try
    {
        if (typeof frm.contentWindow != "undefined" && typeof frm.contentWindow.document != "undefined")
            doc = frm.contentWindow.document;
        else if (typeof frm.contentDocument != "undefined")
            doc = frm.contentDocument;
        else if (typeof frm.document != "undefined")
            doc = frm.document;
    }
    catch(e)
    {
    }
    return doc;
}


function getDoc(wnd)
{
    return getFrameDocument(wnd);
}

function getWindow(doc)
{
    var wnd = null;
    if (typeof doc.defaultView != "undefined")
        wnd = doc.defaultView;
    else if (typeof doc.contentWindow != "undefined")
        wnd = doc.contentWindow;
    else if (typeof doc.parentWindow != "undefined")
        wnd = doc.parentWindow;
    return wnd;
}

function d2hGetOwnerDocument(elem)
{
    var doc = null;
    if (typeof elem.document != "undefined")
        doc = elem.document;
    else if (typeof elem.ownerDocument != "undefined")
        doc = elem.ownerDocument;
    return doc;
}

function getNsTextHeight(doc)
{
    var text = getElemById(doc, "nstext");
    if (text == null)
        text = doc.body;
    var res = 16;
    var wnd = getWindow(doc);
    if (text.style.overflow == "auto")
    {
        if (typeof text.clientHeight != "undefined")
            res = text.clientHeight - 2;
        else
        {
            if (wnd != null && typeof wnd.getComputedStyle != "undefined")
                res = parseInt(wnd.getComputedStyle(text, '').getPropertyValue("height")) - 16;
            else
                res = parseInt(text.style.height) - 16;
        }
    }
    else
        res = typeof doc.body.clientHeight != "undefined" ? (doc.body.clientHeight - 2) : (wnd.innerHeight - 16);
   return res;
}

function getNsTextWidth(doc)
{
    var text = getElemById(doc, "nstext");
    if (text == null)
        text = doc.body;
    var res = 16;
    var wnd = getWindow(doc);
    if (text.style.overflow == "auto")
    {
        if (typeof text.clientWidth != "undefined")
            res = text.clientWidth - 2;
        else
        {
            if (wnd != null && typeof wnd.getComputedStyle != "undefined")
                res = parseInt(wnd.getComputedStyle(text, '').getPropertyValue("width")) - 16;
            else
                res = parseInt(text.style.width) - 16;
        }
    }
    else
        res = typeof doc.body.clientWidth != "undefined" ? (doc.body.clientWidth - 2) : (wnd.innerWidth - 16);
    return res;
}

function point(x, y)
{
    this.x = x;
    this.y = y;
}

function getNsTextLocation(doc)
{
    if (doc == null)
        doc = document;
    var text = getElemById(doc, "nstext");
    if (text == null)
        text = doc.body;
    if (text.style.overflow == "auto")
        return new point(text.offsetLeft, text.offsetTop);
    else
        return new point(0, 0);
}

function getMouseAtNsText(doc, pop, evt)
{
    if (doc == null)
        doc = document;
    var pt = getNsTextLocation(doc);
    var ptRes;
    if (pop != null)
    {
        if (typeof evt.pageX != "undefined")
            ptRes = new point(parseInt(evt.pageX) + parseInt(pop.offsetLeft), parseInt(evt.pageY) + parseInt(pop.offsetTop));
        else
            ptRes = new point(parseInt(evt.offsetX) + parseInt(pop.offsetLeft), parseInt(evt.offsetY) + parseInt(pop.offsetTop));
        
        if (typeof doc.body.scrollLeft != "undefined")
        {
            ptRes.x -= parseInt(doc.body.scrollLeft) + parseInt(document.body.scrollLeft);
            ptRes.y -= parseInt(doc.body.scrollTop) + parseInt(document.body.scrollTop);
        }
        else if (typeof window.pageXOffset != "undefined") 
        {
            var wnd = getWindow(doc);
            if (wnd != null)
            {
                ptRes.x -= parseInt(wnd.pageXOffset);
                ptRes.y -= parseInt(wnd.pageYOffset);
            }
            wnd = getWindow(document);
            if (wnd != null)
            {
                ptRes.x -= parseInt(wnd.pageXOffset);
                ptRes.y -= parseInt(wnd.pageYOffset);
            }
        }
    }
    else
        ptRes = new point(evt.x ? evt.x : evt.clientX, evt.y ? evt.y : evt.clientY);
    ptRes.x -= pt.x;
    ptRes.y -= pt.y;
    return ptRes;
}

function rectangle(x, y, width, height)
{
    this.x = x;
    this.y = y;
    this.height = height;
    this.width = width;    
}

function getPopup(doc, popDoc, frm, pt, clientPt, initialWidth)
{
    if (doc == null)
        doc = document;
    var w = getNsTextWidth(doc);
    if (initialWidth > w)
        initialWidth = w;
    var pop = getElemById(doc, "d2h_popupFrameWnd");
    var delta = 0;
    if (clientPt.x + initialWidth > w)
        delta = clientPt.x + initialWidth - w;
    if (pt.x < delta)
    {
        initialWidth += pt.x - delta;
        pt.x = 0;
    }
    else
        pt.x -= delta;
    if (pop != null)
        pop.style.width = initialWidth;
    var rect = new rectangle(pt.x, 0, initialWidth, 0);
    var h = getNsTextHeight(doc);
    var initialHeigth = getAvailableHeight(frm, popDoc);
    delta = (2*h)/3;
    var bDown = delta > clientPt.y;
    var popH;
    if (bDown)
        popH = h - clientPt.y;
    else
        popH = clientPt.y;
    if (initialHeigth > popH)
    {
        if (initialHeigth > h)
            initialHeigth = h > 20 ? h - 20 : h / 2;
        if (clientPt.y + initialHeigth >= h)
        {
            pt.y -= clientPt.y + initialHeigth - h;
            initialHeigth -= 20;
        }
        rect.y = pt.y;
        rect.height = initialHeigth;
    }
    else
    {
        rect.height = initialHeigth + 1;
        if (bDown)
            rect.y = pt.y + 15;
        else
        {
            rect.y = pt.y - 15;
            rect.y -= rect.height;
        }
    }
    return rect; 
}

function getPopCoords(bPopupOpen, doc, evt)
{
    if (doc == null)
        doc = document;
    var elem = (evt.target) ? evt.target : evt.srcElement;
    var nstx = getElemById(doc, "nstext");
    if (nstx == null)
        nstx = doc.body;
    var pt = new point(0, 0);
    var pop = getElemById(doc, "d2h_popupFrameWnd");
    var isOp = false;
    if (isOpera() && typeof nstx.offsetLeft != "undefined")
    {
        isOp = true;
        pt.x = evt.x;
        pt.y = evt.y;
        if (!bPopupOpen)
        {
            pt.x += doc.body.scrollLeft;
            pt.y += doc.body.scrollTop;
            if (nstx && nstx.style.overflow == "auto")
                pt.y += nstx.scrollTop;
        }
    }
    else if (typeof evt.layerY != "undefined")
    {
        pt.x = evt.pageX;
        pt.y = evt.pageY;
    }
    else
    {
        if (bPopupOpen)
        {
            pt.x = evt.offsetX;
            pt.y = evt.offsetY;
        }
        else
        {
            pt.x = evt.x + doc.body.scrollLeft;
            pt.y = evt.y + doc.body.scrollTop;
            if (nstx && doc.body.scroll == "no")
                pt.y -= nstx.offsetTop - nstx.scrollTop;
        }
    }
    if (bPopupOpen)
    {
        pt.x += pop.offsetLeft;
        pt.y += pop.offsetTop
        if (!isOp)
        {
            if (typeof document.body.scrollLeft != "undefined")
            {
                pt.x -= document.body.scrollLeft;
                pt.y -= document.body.scrollTop;
            }
            else if (typeof window.pageXOffset != "undefined") 
            {
                pt.x -= window.pageXOffset;
                pt.y -= window.pageYOffset;
            }
        }
    }
    return pt;
}

function getAvailableHeight(frm, popDoc)
{
    var hgt = 140;
    if (frm != null && typeof frm.self != "undefined" && typeof frm.self.document.body.scrollHeight != "undefined")
    {
        hgt = frm.self.document.body.scrollHeight;
        if (isOpera())
            hgt += 7;
    }
    else
    {
        if (typeof popDoc.body.scrollHeight != "undefined")
            hgt = popDoc.body.scrollHeight;    
        else if (typeof popDoc.body.offsetHeight != "undefined")
        {
            hgt = popDoc.body.offsetHeight;    
            hgt = hgt + 18;
        }
    }
    return hgt;
}

function d2hCreatePopupIFrame(doc)
{
    var frm = null;
    var nstx = getElemById(doc, "nstext");
    if (nstx == null)
        nstx = doc.body;
    if (!isOpera() && typeof doc.body.insertAdjacentHTML != "undefined")
    {
        nstx.insertAdjacentHTML("BeforeEnd", "<div id='popupDiv'></div>")
        var div = getElemById(document, "popupDiv");
        if (div == null)
	        return null;
        div.innerHTML = "<iframe id=\"d2h_popupFrameWnd\" name=\"d2h_popupFrameWnd\" frameborder=\"no\" height=\"0px\" width=\"0px\" style=\"VISIBILITY: hidden; position: absolute;\"></iframe>";
        frm = getElemById(doc, "d2h_popupFrameWnd");
        if (typeof div.removeNode != "undefined")
            div.removeNode(false);
    }
    else
    {
        frm = doc.createElement("iframe");
        frm.id = "d2h_popupFrameWnd";
        frm.name = "d2h_popupFrameWnd";
        frm.frameBorder = "no";
        frm.height = "0px"
        frm.width = "0px"
        frm.style.visibility = "hidden";
        frm.style.position = "absolute";
        nstx.appendChild(frm);
    }
    frm.style.margin = "0pt";
    frm.style.padding = "0pt";
    return frm;
} 


function dhtml_popup(evt, url)
{
	ANCHOR = "";
	var mainDoc, pop, main, body, x, y, pt;

	// no url? then hide the popup
	if (url == null || url.length == 0)
	{
		pop = getElemById(document, "d2h_popupFrameWnd");
		if (pop != null)
		{
			pop.style.display = "none";
			pop.left = 0;
			pop.top = 0;
			pop.width = 0;
			pop.height = 0; 
			pop.style.visibility = "hidden";
			pop.style.border = "";
		}
		return;
	}
    popUpShown = false;
	// if the popup frame is already open, close it first
	if (dhtml_popup_is_open())
	{
	    popUpShown = true;
		// the main window is the parent of the popup frame
		main = window.parent;
		mainDoc = getDoc(main);
		body = main.document.body;
		pop = getElemById(main.document, "d2h_popupFrameWnd");

		pt = getPopCoords(popUpShown, mainDoc, evt);
		x = pt.x;
		y = pt.y;
    	main.popClientPos = getMouseAtNsText(mainDoc, pop,  evt);

		// hide the popup frame
		if (!isNN())
		    pop.style.display = "none";
		pop.style.visibility = "hidden";
	}
	else
	{
		// the main window is the current window
		main = window;
		mainDoc = getDoc(main);
		body = document.body;
		pop = getElemById(document, "d2h_popupFrameWnd");

		// use the event coordinates for positioning the popup
		pt = getPopCoords(popUpShown, mainDoc, evt);
		x = pt.x;
		y = pt.y;
    	popClientPos = getMouseAtNsText(mainDoc, null,  evt);

		// get the popup frame, creating it if needed
		if (pop == null)
		    pop = d2hCreatePopupIFrame(document); 
	}
	if (pop == null)
	{
	    d2hwindow(url, "d2hPopup");
	    return;
	}

	// get frame style
	var sty = pop.style;

	// load url into frame
	var anchorIndex = url.indexOf("#", 0);
	setPopupState(-1, popUpShown);
	pop.setAttribute("src", "about:blank");
	pop.style.display = "block";
	setPopupState(0, popUpShown);
	var strUrl;
	if (anchorIndex >= 0)
	{
		ANCHOR = url.substr(anchorIndex + 1);
		//workaround to reset current src
		strUrl = url.substr(0, anchorIndex);
	}
	else
	    strUrl = url;
    if (popUpShown)
        open(strUrl, isOpera() ? "_self" : "d2h_popupFrameWnd");
    else
    {
        if (isOpera() && getOperaVersionNumber() >= 9.0)
            open(strUrl, "d2h_popupFrameWnd");
        else
            pop.src = strUrl;
    }
	// initialize frame size/position
	sty.border    = "1px solid #cccccc";
	sty.left = x - 30000;
	sty.top = y - 30000;
	var wid = getInsideWindowWidth(mainDoc) - 60;
	if (wid < 10)
	    wid += 60;
	sty.width  = (wid > 500)? wid * 0.6: wid;
	sty.height = 0;

	// wait until the document is loaded to finish positioning
	main.setTimeout("dhtml_popup_position()", 100);
}

function dhtml_popup_is_open()
{
	return window.name == "d2h_popupFrameWnd";
}

function popDocIsLoad()
{
    if (window.popupState == 1 || window.g_d2hIterationCount == 10)
    {
        // g_d2hIterationCount is used for Opera 8.0 and higher, where OnLoad is not fired if the window is invisible (Opera bug)
        window.g_d2hIterationCount = 0;
        return true;
    }
    if (typeof window.g_d2hIterationCount == "undefined")
        window.g_d2hIterationCount = 1;
    else
        window.g_d2hIterationCount++;
    return false;
}

function dhtml_popup_position()
{
    if (!popDocIsLoad())
    {
        window.setTimeout("dhtml_popup_position()", 100);
        return;
    }

    // get frame
    var pop = getElemById(document, "d2h_popupFrameWnd");
    var frm = getIFrameById("d2h_popupFrameWnd");
    var sty = pop.style;
    if (!popupDocument)
        popupDocument = getDoc(frm);
	    
    if (popupDocument)
    {
        if (getAllElements(popupDocument).length == 0)
            //if frame is empty, it contains its document, workaround must be applied
            d2h_set_popup_html(popupDocument);
        if (ANCHOR != "")
             //for non-splitting mode topics that are not needed must be hidden
             d2h_hide_unused_elements(popupDocument);

        // hide navigation/nonscrolling elements, if present
        dhtml_popup_elements(popupDocument);
        var popWnd = getWindow(popupDocument);
        if (popWnd)
        {
            popWnd.d2hPrepareAnchors4Popup();
            popWnd.g_bMainWnd = false;
        }
    }
    var popDoc = popupDocument;

	// get containing element (scrolling text region or document body)
    var body = getElemById(document, "nstext");
    var poptext = getElemById(popDoc, "nstext");
    var nsbanner = getElemById(popDoc, "_d2hTitleNavigator");
    d2hStandardizePopupMargin(popDoc.body, poptext, nsbanner);
    if (body == null)
        body = document.body;

    sty.visibility = "visible";
    setPopupState(-1, popUpShown);

    // make content visible
    var pt = new point(parseInt(sty.left) + 30000, parseInt(sty.top) + 30000);
    var rect = getPopup(document, popDoc, frm, pt, popClientPos, parseInt(sty.width));
    sty.left = rect.x;
    sty.top = rect.y;
    sty.width = rect.width;
    sty.height = rect.height;
}

function dhtml_popup_elements(doc)
{
    d2hShowTopicTitleInPopup(doc);

	// set popup background style
	doc.body.style.backgroundColor = POPUP_COLOR;
	doc.body.style.backgroundImage = "url('" + d2hGetRelativePath(doc, POPUP_IMAGE) + "')";
	doc.body.style.backgroundRepeat = POPUP_REPEAT;

	// reset background image/color of scrolling text region, if present
	var nstx = getElemById(doc, "nstext");
	if (nstx != null)
	{
		nstx.style.backgroundImage = "none";
		nstx.style.backgroundColor = "transparent";
	}
}

function dhtml_nonscrolling_resize()
{
    if (!document.body.clientWidth)
        return;

    var oBanner= getElemById(document, "nsbanner");
    var oText= getElemById(document, "nstext");

    if (oText == null)
        return;

    if (oBanner != null)
    {
        dhtml_scrollingStyle();
        oBanner.style.width = document.body.clientWidth;
        d2hSetTopicTextRightIndent(oText);
        oText.style.width = document.body.clientWidth;
        oText.style.top = 0;  

        if (document.body.offsetHeight > oBanner.offsetHeight + getTriPaneOffset())
            oText.style.height = document.body.offsetHeight - oBanner.offsetHeight - getTriPaneOffset();
        else
            oText.style.height = 0;
    }	
	d2hRegisterEventHandler(window, document.body, "onresize", "d2hnsresize(event);");
	d2hRegisterEventHandler(window, document.body, "onbeforeprint", "d2h_before_print();");
	d2hRegisterEventHandler(window, document.body, "onafterprint", "d2h_after_print();");
} 

////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
// d2h functions: browser-independent
//
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

function d2hie()
{
    if (isOpera() || isNN() || isMozilla())
        return false;
    else
        return isIE();
}

function d2hpopup(evt, url)
{
    evt = (evt) ? evt : ((window.event) ? event : null);
    if (_d2hInlinePopup != null)
    {
        var elem = (evt.target) ? evt.target : ((evt.srcElement) ? evt.srcElement : null);
        if (elem == null || !d2hElementInContainer(elem, _d2hInlinePopup))
        {
            d2hHideInline(_d2hInlinePopup);
            _d2hInlinePopup = null;
        }
    }

    d2hClosePopupMenu(evt);
    // use dhtml if we can
    dhtml_popup(evt, url);
    return false;
}

function d2hwindow(url, name)
{
    if (name != 'main')
    {
        var wnd = window.open(url, name, 'scrollbars=1,resizable=1,toolbar=0,directories=0,status=0,location=0,menubar=0,height=300,width=400');
        wnd.focus();
        return false;
    }
    return true;
}

function d2hcancel(msg, url, line)
{
	return true;
}

function d2hload()
{
    window.focus();
    window.onerror = d2hcancel;
    setPopupState(1, true);
    d2hPrepareAnchors4Popup();
}

function setPopupState(state, fromPop)
{
    if (fromPop)
    {
        if (window.parent)
        {
            if (state == 1)
                window.parent.popupDocument = document;
            else
                window.parent.popupDocument = null;
            window.parent.popupState = state;
        }
    }
    else
    {
        if (state == 1)
            popupDocument = document;
        else
            popupDocument = null;
        popupState = state;
    }
}

function d2hframeload()
{
	// for compatibility with HTML generated by earlier versions
}

function evalHideTocElem(elem)
{
    var id = elem.id;
    if (id == undefined || id == null)
        return;
    var id1 = id.substring(0, 1);
    var id2 = id.substring(0, 2);
    if (id1 == "c")
        elem.style.display = "none";
    else if (id1 == "a")
    {
        //fill book/topic properties
        elem.onmouseover = d2hItemOver;
        elem.onmouseout = d2hItemOut;
        elem.onfocus = d2hItemOver;
        elem.onblur = d2hItemOut;
        if (USE_SECTION_508 != "yes")
            elem.hideFocus = true;
        elem.title = getInnerText(elem);
        if (id2 == "am")
            elem.onkeypress = d2hclick; 
        else if (id2 == "at")
        {
            elem.href = "javascript:void(0)";
            elem.onkeypress = d2hclick; 
        }
        else
            elem.onclick = d2hLinkClick;
    }
    else if (id1 == "i")
    {
        //fill book/topic image properties
        elem.align="absMiddle";
        elem.border = "0"; 
        elem.hspace = "0";
        elem.vspace = "0";
        if (id2 == "im" || id2 == "it")
            d2himage(elem, IMAGE_CLOSE, USE_SECTION_508, false);
        else
            d2himage(elem, IMAGE_TOPIC, USE_SECTION_508);
    }
}

function reverseVisibileTocElem(elem, img, mode)
{
    if (elem.style.display == "none")
    {
        if (mode != 2)
        {
            elem.style.display = "";
            d2himage(img, IMAGE_OPEN, USE_SECTION_508, true);
        }
    }
    else
    {
        if (mode != 1)
        {
            elem.style.display = "none";
            d2himage(img, IMAGE_CLOSE, USE_SECTION_508, false);
        }
    }
}

function getAllElements(doc)
{
    if (typeof doc.all != "undefined")
        return doc.all;
    else
        return doc.getElementsByTagName("*");
}

function d2htocload()
{
    var listObj = getAllElements(document);
    if (typeof listObj == "undefined")
    {
        return;
    }
    var id, elt;
    var count = listObj.length;
    for (var i = 0; i < count; i++)
    {
        elt = listObj.item(i);
        evalHideTocElem(elt);
    }
}

function d2hclick(evt)
{
    evt = (evt) ? evt : ((typeof window.event != "undefined") ? event : null);
    if (evt)
    {
        var elem = (evt.target) ? evt.target : ((evt.srcElement) ? evt.srcElement : null);
        if (!elem)
        {
            return true;
        }
        if (elem.nodeType == 3)
            elem = elem.parentNode;
        if (elem.tagName.toLowerCase() == "span")
            elem = elem.parentNode;
        var id = elem.id;
        if (id == "D2HSyncToc")
        {
            return true;
        }
        var expand = false, shrink = false, needToRevert = false;
        var charCode = (evt.charCode) ? evt.charCode : ((evt.which) ? evt.which : evt.keyCode);
        if (evt.type == "keypress" && charCode < 13)
            return;
        expand = charCode == 43;
        shrink = charCode == 45;
        var isClick = evt.type == "click" || charCode == 13;
        needToRevert = expand || shrink || (id.substring(0, 2) == "at" && isClick);
        if (elem.tagName.toLowerCase() == "a" && !needToRevert)
        {
            showSelection(document, elem);
            return true;
        }
        if (id.substring(1, 2) != "m" && id.substring(1, 2) != "t")
            return true;
        var sub = id.substring(2);
        var elt = getElemById(document, "c" + sub);
        var img = getElemById(document, ((id.substring(1, 2) == "m") ? "im" : "it") + sub);
        if (elt != null)
        {
            reverseVisibileTocElem(elt, img, expand ? 1 : (shrink ? 2 : 0));
            cancelEvent(evt);
            return false;
        } 
    }
    return true;
}

function d2hItemSelect(evt)
{
    evt = (evt) ? evt : ((typeof window.event != "undefined") ? event : null);
    if (evt)
    {
        var elem = (evt.target) ? evt.target : ((evt.srcElement) ? evt.srcElement : null);
        if (!elem)
        {
            return;
        }
        if (elem.nodeType == 3)
            elem = elem.parentNode;
        var id = elem.id;
        if (elem.tagName.toLowerCase() == "a")
            showSelection(document, elem);
    }
}

function d2hSearchItemSelect(href, evt)
{
    d2hSetClickState("onresult");
    
    d2hItemSelect(evt);
    d2hInitSecondaryWindows();
    var lowhref = href.toLowerCase();
    var wnd = _d2hSecondaryWindowsByTopics[lowhref];
    if (typeof (wnd) == "undefined" || wnd == null || wnd == "")
        return true;
    else
    {
		var sWndFeatures = "";
		if (typeof d2hInitWindowParams != "undefined")
		{
			d2hInitWindowParams();
			if (_d2hWindowParamsByWindows[wnd])
				sWndFeatures = _d2hWindowParamsByWindows[wnd];
		}
        var hwnd = window.open(href, wnd, sWndFeatures);
        hwnd.focus();
    }
    return false;
}

function d2hItemOver(evt)
{
    evt = (evt) ? evt : ((window.event) ? event : null);
    if (evt)
    {
        var elem = (evt.target) ? evt.target : ((evt.srcElement) ? evt.srcElement : null);
        if (!elem)
        {
            return;
        }
        if (elem.nodeType == 3)
            elem = elem.parentNode;
        elem = findActualElementOver(elem);
        elem.className  = CLASS_ITEMOVER;
    }
}
function d2hItemOut(evt)
{
    evt = (evt) ? evt : ((window.event) ? event : null);
    if (evt)
    {
        var elem = (evt.target) ? evt.target : ((evt.srcElement) ? evt.srcElement : null);
        if (!elem)
        {
            return;
        }
        if (elem.nodeType == 3)
            elem = elem.parentNode;
        elem = findActualElementOver(elem); 
        var curSel = getElemById(document, "curSel");
        if (curSel != null && curSel.value == elem.id)
	    elem.className = CLASS_ITEMCURSEL;
        else
            hideSelection(elem);
     }
}
function hideSelection(elem)
{
    elem.className = CLASS_ITEMOUT;
}
function showSelection(doc, elem)
{
    var curSel = getElemById(doc, "curSel");
    if (!curSel)
    {
        return;
    }
    if (curSel.value != "")
    {
        var old = getElemById(doc, curSel.value);
        if (old)
            hideSelection(old);
    }
    curSel.value = elem.id;
    elem.className = CLASS_ITEMCURSEL;
}

//if element has special ID and special SPAN inside, this SPAN is returned
function findActualElementOver(element)
{
    var foundElem = null;
    var id = element.id.toLowerCase();
    if (id.substring(0, 1) == "i")
    {
        foundElem = d2hGetParentElement(element);
        id = foundElem.id.toLowerCase();
    }
    if (id.substring(0, 2) == "at")
    {
        var spanID = "st" + id.substring(2);
        foundElem = getElemById(document, spanID);
    }
    return foundElem == null ? element : foundElem;
}

// Sets a specified relative URL of image to specified HTML element
function d2himage(element, image, apply508, isOpen)
{
	if (element != null)
	{
		// Hide element if image is missing
		if (image == "")
			element.style.visibility = "hidden";

		// Sets the specified image to element and displays it
		else
		{
			element.src = d2hGetRelativePath(d2hGetOwnerDocument(element), image);
			element.style.visibility = "visible";
			if (apply508 == "yes")
            {
                var id = element.id.substring(0, 2);
                if (id == "im")
                    element.alt = isOpen ? ALT_OPEN_BOOK_TOPIC : ALT_CLOSED_BOOK_TOPIC;
                else if (id == "it") 
                    element.alt = isOpen ? ALT_OPEN_BOOK_NO_TOPIC : ALT_CLOSED_BOOK_NO_TOPIC;
                else
                    element.alt = ALT_TOPIC;
                element.title = element.alt;
            }
            if (apply508 == "no")
                element.alt = ""
			
		}	
	}
}

function d2hswitchpane(id, doc)
{
    if (!doc)
        doc = document;
    var arrSwitch = [["D2HContents", CONTENTS_SELECTED, CONTENTS_UNSELECTED],
        ["D2HIndex", INDEX_SELECTED, INDEX_UNSELECTED],
        ["D2HSearch", SEARCH_SELECTED, SEARCH_UNSELECTED]];
    var i, elem, img, sel;
    if (id == "D2HContents" || id == "D2HIndex" || id == "D2HSearch")
    {
        for(i = 0; i < arrSwitch.length; i++)
        {
            elem = getElemById(doc, arrSwitch[i][0]);
            if (elem != null)
            {
                img = getElemById(doc, elem.id + "Image");
                sel = false;
                if (id.indexOf(elem.id) == 0)
                {
                    elem.className = elem.id + "Selected";
                    sel = true;
                }
                else
                    elem.className = elem.id + "Unselected";
                if (img != null)
                    d2himage(img, sel ? arrSwitch[i][1] : arrSwitch[i][2]);
            }
        }
        return true;
     }
     else
        return false;
}

function d2hactivepane()
{
	var id = "D2HContents";
	try
	{
	    var frms = window.parent.frames;
	    if (frms.length < 2)
		    return id;
	    var frm = frms["left"];
	    if (frm == null)
		    return id;

	    var body = frm.document.body;
	    if (body != null)		
		    id = body.id;
    }
    catch(e)
    {
    }
	return id;				
}

function d2hnsresize(evt)
{
    var ps = false;
    try
    {
        if (typeof window.parent.popupState != "undefined" && window.parent.popupState == 0)
            ps = true;
    }
    catch(e)
    {
    }
    if (window.parent && ps)
        setPopupState(1, true);
    else
    {
        if (d2hie())
            dhtml_nonscrolling_resize();
        else
            dhtml_NNscrollingStyle();
        var id = d2hactivepane();
        d2hswitchpane(id);
    }
}

function d2h_before_print()
{
	document.body.scroll = "yes";
	var oText = getElemById(document, "nstext");
	if (oText != null)
	{
		oText.style.overflow = "visible";
		oText.style.width = "100%";
	}
	var nav = getElemById(document, "ienav");
	if (nav != null)
		nav.style.display = "none";
	var oBanner = getElemById(document, "nsbanner");
	if (oBanner != null)
	{
		oBanner.style.borderBottom = "0px";
		oBanner.style.margin = "0px 0px 0px 0px";
		oBanner.style.width = "100%";
	}
}

function d2h_after_print()
{
	document.location.reload();
}

function d2h_set_popup_html(doc)
{
	doc.body.innerHTML = document.body.innerHTML;
	var frame = getFrameById("d2h_popupFrameWnd");
	if (frame != null)
		frame.removeNode(true);
	var nst = getElemById(doc, "nstext");
	if (nst != null)
	{
		nst.style.paddingTop = "0px";
		nst.style.paddingLeft = "10px";
		nst.style.removeAttribute("top", false);
		nst.style.removeAttribute("width", false);
		nst.style.removeAttribute("height", false);
	}
	var elt, i;
	//need to reset onclick event to prevent script error
	//because scripts don't work when body is copied from document to frame
    var listObj = doc.getElementsByTagName("a");

	for (i = 0; i < listObj.lenght; i++)
	{
		elt = listObj.item(i);
		elt.onclick = "";
	}
}

function d2h_hide_unused_elements(doc)
{
	var title = getElemById(doc, "TitleRow");
	if (title != null)
		title.style.display = "none";
	var nsb = getElemById(doc, "nsbanner");
	if (nsb != null)
		nsb.style.display = "none";

    var listObj = getAllElements(doc);
	var count = listObj.length;
	var show = false, inTopic = false, id, elt, i;
	for (i = 0; i < count; i++)
	{
		elt = listObj.item(i);
		id = elt.id;
		if (!inTopic && (id.length > 10) && (id.substring(0, 10) == "_D2HTopic_"))
			inTopic = true;
		if (elt.className == "_D2HAnchor")
			show = (elt.name == ANCHOR);
               	if (inTopic && !show)
			elt.style.display = "none";
	}
}
function expandTreeNode(doc, elem)
{
    if (elem.id == "")
        return;
    var imgId = null;
    if (elem.id.substring(0, 1) == "a")
    {
        imgId = elem.id.substring(2);
    }
    expandNodes(doc, elem, imgId);
}
function expandNodes(doc, elem, selID)
{
    if (typeof elem.tagName == "undefined" || elem.tagName.toLowerCase == "body")
    {
        return;
    }
    if (elem.parentNode)
    {
        expandNodes(doc, elem.parentNode, selID);
    }
    elem.style.display = "";
    if (elem.id == "")
        return;
    var imgId = null;
    if (elem.id.substring(0, 1) == "c")
    {
        imgId = elem.id.substring(2);
    }
    else if (elem.id.substring(0, 1) == "a")
    {
        imgId = elem.id.substring(2);
    }
    if (imgId)
    {
        if (selID == imgId)
            return;
        var imgId1 = "im-" + imgId;
        var img = getElemById(doc, imgId1);
        if (!img)
        {
            imgId1 = "it-" + imgId;
            img = getElemById(doc, imgId1);
        }
        if (img)
            d2himage(img, IMAGE_OPEN, USE_SECTION_508, true);
    }
}

function getTocAnchorByhRef(doc, linkHref)
{
    var listObj = doc.getElementsByTagName("a");
	var strHref;
	var curLink = null;
	for (var i = 0; (i < listObj.length) && curLink == null; i++)
	{
	    if (listObj[i].href)
	    {
	        strHref = listObj[i].href.toLowerCase();
	        if (strHref == linkHref)
	            curLink = listObj[i];
	     }
	}
	return curLink;
}

function d2hSyncTocMouseDown(evt)
{
    var elem = getElemById(document, "D2HSyncToc");
    if (elem != null)
    {
        elem.className = "syncTocSelected";
        var img = getElemById(document, elem.id + "Image");
        if (img != null)
            d2himage(img, SYNCTOC_SELECTED);
    }
}

function d2hSyncTocMouseUp(evt)
{
    var elem = getElemById(document, "D2HSyncToc");
    if (elem != null)
    {
        elem.className = "syncToc";
        var img = getElemById(document, elem.id + "Image");
        if (img != null)
            d2himage(img, SYNCTOC_UNSELECTED);
    }
}

function d2hSyncTocMouseOut(evt)
{
    d2hSyncTocMouseUp(evt);
}

function d2hSyncTocMouseMove(evt)
{
    d2hSyncTocMouseUp(evt);
}

function syncDynamicToc(linkHref, first)
{
    var frm = getFrameByName("left");
    if (frm)
    {
        var doc = getFrameDocument(frm);
        if (doc != null)
    	{
            if (doc.forms && doc.forms.length == 0)
                return;
            linkHref = linkHref.toLowerCase();
           
   	        var anchorIndex = linkHref.indexOf("#", 0);
	        if (anchorIndex >= 0)
		        linkHref = linkHref.substr(0, anchorIndex);
	        var curLink = getTocAnchorByhRef(doc, linkHref);
	        if (curLink == null)
	            return;
	        expandTreeNode(doc, curLink);
	        showSelection(doc, curLink);
            if (USE_SECTION_508 == "yes")
                curLink.focus();

            var wnd = null;
            var ie = isIE();
            if ((isOpera() || ie) && (wnd = getWindow(doc)))
                wnd.scrollTo(first ? 0 : curLink.offsetLeft, curLink.offsetTop);
            else if (typeof(doc.location.hash) != "undefined")
	            doc.location.hash = curLink.id;
        }
    }
}

function d2hSyncDynamicToc(evt)
{
    var frm = getFrameByName("right");
    var first = (typeof arguments != "undefined") && (arguments.length == 0);
    if (frm)
    {
        var doc = getFrameDocument(frm);
        if (doc != null)
        {
            var loc = doc.location.href;
            syncDynamicToc(loc, first);
        }
    }
    return false;
}

function syncStaticToc(frm, linkHref, tocframe, first)
{
    var doc = document;
    if (tocframe)
    {
        var frm = getFrameByName(tocframe);
        if (frm)
            doc = getFrameDocument(frm);
    }
    if (doc.forms && doc.forms.length == 0)
        return;
    linkHref = linkHref.toLowerCase();
   
    var anchorIndex = linkHref.indexOf("#", 0);
    if (anchorIndex >= 0)
        linkHref = linkHref.substr(0, anchorIndex);
    var curLink = getTocAnchorByhRef(doc, linkHref);
    if (curLink == null)
        return;
    var wnd = null;
    var ie = isIE();
    if ((isOpera() || ie) && (wnd = getWindow(doc)))
        wnd.scrollTo(first ? 0 : curLink.offsetLeft, curLink.offsetTop);
    else if (typeof(doc.location.hash) != "undefined")
	    doc.location.hash = curLink.id;
	curLink.focus();    
}

function d2hSyncStaticToc(evt, tocframe)
{
    var frm = getFrameByName("right");
    var first = (typeof arguments != "undefined") && (arguments.length == 0);
    if (frm)
    {
        var doc = getFrameDocument(frm);
        if (doc != null)
        {
            var loc = doc.location.href;
            syncStaticToc(loc, loc, tocframe, first);
        }
    }
    return false;
}

function getInsideWindowWidth(doc)
{
    var wid = 0;
    if (doc == null)
        doc = document;
    if (typeof doc.body.clientWidth != "undefined")
	    wid = doc.body.clientWidth;
	else if (typeof doc.body.parentElement != "undefined" && typeof doc.body.parentElement.clientWidth != "undefined")
	    wid = doc.body.parentElement.clientWidth;
    else
    {
        var wnd = getWindow(doc);
        if (wnd != null && typeof wnd.innerWidth != "undefined")
	        wid = wnd.innerWidth;
	}
    return wid;
}

function getInsideWindowHeight(doc)
{
    var hgt = 0;
    if (doc == null)
        doc = document;
    if (typeof doc.body.clientHeight != "undefined")
	    hgt = doc.body.clientHeight;
	else if (typeof doc.body.parentElement != "undefined" && typeof doc.body.parentElement.clientHeight != "undefined")
	    hgt = doc.body.parentElement.clientHeight;
    else
    {
        var wnd = getWindow(doc);
        if (wnd != null && typeof window.innerHeight != "undefined")
	        hgt = wnd.innerHeight;
	}
    return hgt;
}

function isServerSide()
{
    var str = document.location.toString().toLowerCase();
    return !(str.length > 7 && str.substring(0, 7) == "file://");
}

function d2hOnSearchClick(evt)
{
    if (evt != null)
        d2hswitchpane('D2HSearch');
    return true;
}

function getDocHeight(doc)
{
    if (typeof doc.body.offsetHeight != "undefined")
        return doc.body.offsetHeight;
    else if (typeof doc.body.scrollHeight != "undefined")
        return doc.body.scrollHeight;
    return doc.body.style.height;
}

function d2hGetRelativePath(doc, path)
{
	if (path.length >= 0 && doc != null)
	{
		var relPart = d2hGetAttribute(doc.body, "relPart");
		if (relPart == null)
			relPart = "";
		return relPart  + path;
	}
	else
		return "";
}

function d2hHideInline(elem)
{
    if (elem != null)
    {
        elem.style.position = "absolute";
        elem.style.visibility = "hidden";
        if (typeof elem.style.display != "undefined")
            elem.style.display = "none";
    }
}

function d2hShowInline(elem)
{
    if (elem != null)
    {
        elem.style.position = "";
        elem.style.visibility = "visible";
        if (typeof elem.style.display != "undefined")
            elem.style.display = "";
    }
}

function d2hInitInlineDropdown(elemId)
{
    var elem = getElemById(document, elemId);
    d2hHideInline(elem);
}

function d2hInitInlineExpand(elemId)
{
    var elem = getElemById(document, elemId);
    d2hHideInline(elem);
}

function d2hInitInlinePopup(elemId)
{
    var elem = getElemById(document, elemId);
    if (elem != null)
    {
        d2hHideInline(elem);
        elem.style.backgroundColor = POPUP_COLOR;
        elem.style.backgroundImage = "url('" + d2hGetRelativePath(document, POPUP_IMAGE) + "')";
        elem.style.backgroundRepeat = POPUP_REPEAT;
        elem.style.border = "1px solid #cccccc";
    }
}

function d2hInlineExpand(evt, elemId)
{
    var elem = getElemById(document, elemId);
    if (elem != null)
    {
        if (elem.style.visibility == "hidden")
            d2hShowInline(elem);
        else
            d2hHideInline(elem);
    }
    return false;
}

function d2hInlineDropdown(evt, elemId)
{
    var elem = getElemById(document, elemId);
    if (elem != null)
    {
        if (elem.style.visibility == "hidden")
            d2hShowInline(elem);
        else
            d2hHideInline(elem);
    }
    return false;
}

function d2hInlinePopup(evt, elemId)
{
    var elem = getElemById(document, elemId);
    if (elem != null)
    {
        if (elem.style.visibility == "hidden")
        {
            if (d2hNeedSendToBody(elem))
                d2hSend2Body(elem);
            if (typeof elem.style.display != "undefined")
                elem.style.display = "";
            elem.style.width = "auto";
            elem.style.height = "auto";
            var pt = d2hGetInlinePosition(evt);
            elem.style.visibility = "visible";
            setInlinePopup2Pos(elem, pt.x, pt.y);
            _d2hInlinePopup = elem;
        }
        else
        {
            d2hHideInline(elem);
            elem.style.left = 0;
            elem.style.top = 0;
        }
    }
    return false;
}

function setInlinePopup2Pos(popupElem, x, y)
{
    var nstext = getElemById(document, "nstext");
    if (nstext == null)
        nstext = document.getElementsByTagName((document.compatMode && document.compatMode == "CSS1Compat") ? "HTML" : "BODY")[0];
    d2hStandardizePopupMargin(popupElem);
    var w_width = nstext.clientWidth ? nstext.clientWidth + nstext.scrollLeft : window.innerWidth + window.pageXOffset;
    var w_height = nstext.clientHeight ? nstext.clientHeight + nstext.scrollTop : window.innerHeight + window.pageYOffset;
    popupElem.style.width = "auto";
    popupElem.style.height = "auto";
    var textWidth = popupElem.offsetWidth;
    var w = (w_width > 300)? w_width * 0.6: w_width;
    if (textWidth > w)
        textWidth = w;
    popupElem.style.width = textWidth + "px";
    var t_width = popupElem.offsetWidth;
    var t_height = popupElem.offsetHeight;
    textWidth = Math.sqrt(16*t_width*t_height/9);
    popupElem.style.width = Math.round(textWidth) + "px";
    t_width = popupElem.offsetWidth;
    t_height = popupElem.offsetHeight;
    popupElem.style.left = x + 8 + "px";
    popupElem.style.top = y + 8 + "px";
    var x_body_bottom = (document.body.clientWidth ? document.body.clientWidth : window.innerWidth) + document.body.scrollLeft;
    var y_body_bottom = (document.body.clientHeight ? document.body.clientHeight : window.innerHeight) + document.body.scrollTop;
    if (x + t_width > x_body_bottom)
        popupElem.style.left = x_body_bottom - t_width + "px";
    if (y + t_height > y_body_bottom)
        popupElem.style.top = y_body_bottom - t_height + "px";
}

function getInnerText(elem)
{
    if (typeof elem.innerText != "undefined")
        return elem.innerText;
    else if (typeof elem.textContent != "undefined")
        return elem.textContent; 
    else
        return elem.text; 
}

function d2hIndex(val)
{
    this._key = getInnerText(val).toLowerCase();
    this._elem = val;
}

function d2hIndexArray()
{
    this._indexes = new Array();
    
    d2hIndexArray.prototype.Add = function(val)
    {
        this._indexes[this._indexes.length] = new d2hIndex(val);
    }
    
    d2hIndexArray.prototype.IndexKeyComparer = function(a, b)
    {
        if (a._key < b._key)
            return -1;
        if (a._key > b._key)
            return 1;
        return 0;
    }
    
    d2hIndexArray.prototype.sort = function()
    {
        this._indexes.sort(this.IndexKeyComparer);
    }

    d2hIndexArray.prototype.length = function()
    {
        return this._indexes.length;
    }

    d2hIndexArray.prototype.SearchStringComparer = function(a, b, prune)
    {
        var stra, strb;
        if ((prune & 7) != 0)
        {
            if (a.length > b.length)
            {
                if ((prune & 7) == 1)
                    return 1;
                stra = a.substring(0, b.length);
                strb = b;
            }
            else
            {
                if ((prune & 7) == 2)
                    return -1;
                stra = a;
                strb = b.substring(0, a.length);
            }
        }
        else
        {
            stra = a;
            strb = b;
        }
        
        if (stra < strb)
            return -1;
        if (stra > strb)
            return 1;
        return 0;
    }

    d2hIndexArray.prototype.find = function(findKey, prevIndex)
    {
        if (findKey == null || findKey.length == 0)
            return null;
        findKey = findKey.toLowerCase();
        var low, hight;
        if (prevIndex == null)
        {
            low = 0;
            high = this._indexes.length - 1;
        }
        else
        {
            var prevKey = this._indexes[prevIndex]._key;
            var cmp = this.SearchStringComparer(findKey, prevKey, 0);
            if (cmp < 0)
            {
                low = 0;
                high = prevIndex;
            }
            else if (cmp > 0)
            {
                low = prevIndex;
                high = this._indexes.length - 1;
            }
            else
                return prevIndex;
        }
        var Ki;
        var K = findKey;
        var c;
        var j = null;
        for (;(high > low);)
        {
            j = Math.floor((high+low)/2);
            Ki = this._indexes[j]._key;
            if (K < Ki)
                high = j - 1;
            else if (K > Ki)
                low = j + 1;
            else
                return j;
        }
        c = this.SearchStringComparer(K, this._indexes[low]._key, 3);
        if (c < 0)
            return low - 1;
        else if (high > -1)
        {
            c = this.SearchStringComparer(K, this._indexes[high]._key, 3);
            if (c == 0)
                return high;
            else if (c > 0)
                return high + 1;
        }
        return low;
    }
}

function d2hIndexTable()
{
    this._table = new Array();
    this._first = null;
    this._singleLetterIndex = null;
    this._timerID = null;
    this._textControl = null;
    this._onTextChanged = null;
    this._timeout = null;
    this._currText = "";
    this._prevIndex = null;
    this._capitalLetter = null;
    this._prevCapitalIndex = null;

    d2hIndexTable.prototype.LoadAllIndexCapitalLetter = function()
    {
        if (this._capitalLetter != null)
            return;
        this._capitalLetter = new d2hIndexArray();
        var arr = document.getElementsByName("_d2h_capitalletter");
        for (var i = arr.length - 1; i >= 0; i--)
            this._capitalLetter.Add(arr[i]);
        this._capitalLetter.sort();
    }
    
    d2hIndexTable.prototype.GetAllIndexesWithFirstLetter = function(firstLetter)
    {
        var indx;
        if (this._table[firstLetter] != null)
            indx = this._table[firstLetter];
        else
        {
            var name = "_d2h_" + firstLetter.toString();
            indx = new d2hIndexArray();
            var arr = document.getElementsByName(name);
            for (var i = arr.length - 1; i >= 0; i--)
                indx.Add(arr[i]);
            indx.sort();
            this._table[firstLetter] = indx;
        }
        return indx;
    }
    
    d2hIndexTable.prototype.GetIndex = function(key)
    {
        if (key == null || key.length == 0)
            return null;
        this.LoadAllIndexCapitalLetter();
        var code = key.substring(0, 1);
        var prevCapital = null;
        if (this._capitalLetter.length() == 0)
            return null;
        if (this._prevCapitalIndex != null)
            prevCapital = this._capitalLetter._indexes[this._prevCapitalIndex]._key;
        var indx;
        if (prevCapital != code)
        {
            indx = this._capitalLetter.find(code, this._prevCapitalIndex);
            if (indx == -1)
                indx = 0;
            else if (indx > this._capitalLetter.length() - 1)
                return null;
            this._prevCapitalIndex = indx;
        }
        else
            indx = this._prevCapitalIndex;
        
        code = this._capitalLetter._indexes[indx]._key;
        var ch = code.charCodeAt(0);
        var prevIndex = null;
        if (this._first == null || ch != this._first)
        {
            this._first = ch;
            this._singleLetterIndex = this.GetAllIndexesWithFirstLetter(ch);
        }
        else
            prevIndex = this._prevIndex;
        if (this._singleLetterIndex == null || this._singleLetterIndex.length() == 0)
            return null;
        indx = this._singleLetterIndex.find(key, prevIndex);
        if (indx < 0)
        {
            if (this._prevCapitalIndex == 0)
                return this._singleLetterIndex._indexes[0]._elem;
            else
            {
                code = this._capitalLetter._indexes[this._prevCapitalIndex - 1]._key;
                ch = code.charCodeAt(0);
                var arr = this.GetAllIndexesWithFirstLetter(ch)
                return arr._indexes[arr.length() - 1]._elem;
            }
        }
        else if (indx > this._singleLetterIndex.length() - 1)
            return this._singleLetterIndex._indexes[this._singleLetterIndex.length() - 1]._elem;
        else
        {
            this._prevIndex = indx;
            return this._singleLetterIndex._indexes[indx]._elem;
        }
    }
    
    d2hIndexTable.prototype.FindIfTextChanged = function()
    {
        if (this._textControl == null)
            return;
        var curr = this._textControl.value.toLowerCase();
        if (this._currText != curr)
        {
            this.SuspendIndexSearchListener();
            this._currText = curr
            var obj = this.GetIndex(curr);
            if (obj != null)
                this._onTextChanged(obj);
                
            this.ResumeIndexSearchListener();
        }
    }

    d2hIndexTable.prototype.Find = function(key)
    {
        if (this._textControl == null)
            return null;
        var curr = key.toLowerCase();
        this.SuspendIndexSearchListener();
        this._currText = curr
        var obj = this.GetIndex(curr);
        this.ResumeIndexSearchListener();
        return obj;
    }
        
    d2hIndexTable.prototype.StartIndexSearchListener = function(textControl, timeout, handler)
    {
        this._textControl = textControl;
        this._onTextChanged = handler;
        this._timeout = timeout;
        this.SuspendIndexSearchListener();
        this.ResumeIndexSearchListener();
    }
    d2hIndexTable.prototype.StopIndexSearchListener = function()
    {
        this.SuspendIndexSearchListener();
    }
    
    d2hIndexTable.prototype.SuspendIndexSearchListener = function()
    {
        if (this._timerID != null)
        {
            clearInterval(this._timerID);
            this._timerID = null;
        }
    }

    d2hIndexTable.prototype.ResumeIndexSearchListener = function()
    {
        if (this._timerID == null)
            this._timerID = setInterval("_d2hIndex.FindIfTextChanged()", this._timeout);
    }
}

function d2hAdjustFrameHeigth(framesetId)
{
    var layout = getElemById(window.parent.document, framesetId);
    var nn = isNN();
    if (layout != null && ((nn && getNNVersionNumber() >= 6.23) || !nn))
    {
        h = document.body.scrollHeight + 1;
        layout.rows = h.toString() + ", 100%";
    }
}

function d2hGetIndexTextProvider()
{
    var frm = getFrameByName("textprovider");
    if (frm != null)
    {
        var doc = getFrameDocument(frm);
        if (doc != null)
            return getElemById(doc, "incrsText");
    }
    return null;
}

function d2hAddIndexSearchHandler()
{
   var ctext = d2hGetIndexTextProvider();
   _d2hIndex.StartIndexSearchListener(ctext, 100, d2hOnIndexFind);
}

function d2hRemoveIndexSearchHandler()
{
    _d2hIndex.StopIndexSearchListener();
}

function d2hOnIndexFind(obj)
{
    scrollTo(0, obj.offsetTop);
    showSelection(document, obj);
}

function d2hGo2Index(key)
{
    var frm = getFrameByName("indexlist");
    if (frm != null)
    {
        var doc = getFrameDocument(frm);
        if (doc != null)
        {
            var wnd = getWindow(doc);
            var obj = wnd._d2hIndex.Find(key);
            if (obj != null)
            {
                d2hOnIndexFind(obj);
                var f = obj.onclick;
                var evt = new Object();
                evt.target = obj;
                obj.setAttribute("indx", "1");
                evt.pageX = evt.clientX = obj.offsetLeft;
                evt.pageY = evt.clientY = obj.offsetTop;
                f(evt);
            }
        }
    }
}

function d2hIncrsText_onkeyup(evt)
{
    if (evt.keyCode == 13)
    {
        var textElem = getElemById(document, "incrsText");
        if (textElem != null)
        {
            d2hGo2Index(textElem.value.toString());
            textElem.focus();
        }
    }
}

function d2hSetFocusTo(elemId)
{
    var elem = getElemById(document, elemId);
    if (elem != null)
    {
        if (typeof elem.focus != "undefined")
            elem.focus();
    }
}

function d2hAdjustFrameAndSetFocus(framesetid, setFocusTo)
{
    d2hAdjustFrameHeigth(framesetid);
    setTimeout("d2hSetFocusTo(\"" + setFocusTo + "\")", 40);
}

function d2hIndexLookup_onload()
{
    d2hAdjustFrameAndSetFocus('indexlayout', "incrsText");
}

function d2hSearchLookup_onload()
{
    d2hAdjustFrameAndSetFocus('searchlayout', "query");

    cUseHighlight = getElemById(document, "useHighlight" );
    if (cUseHighlight)
        d2hUpdateLastHighlightState(cUseHighlight);
}

function d2hUnselectButton(elem)
{
    if (elem != null && !d2hIsButtonPressed(elem))
        elem.style.border = document.body.bgColor + " 1px solid";
}

function d2hSelectButton(elem, up)
{
    if (elem != null && (!up || !d2hIsButtonPressed(elem)))
    {
        var colorTopLeft = up ? "white" : "gray";
        var colorBottomRight = up ? "gray" : "white";
        
        elem.style.borderLeft = colorTopLeft + " 1px solid";
        elem.style.borderTop = colorTopLeft + " 1px solid";
        elem.style.borderBottom = colorBottomRight + " 1px solid";
        elem.style.borderRight = colorBottomRight + " 1px solid";
        elem.pressed = !up;
    }
}

function d2hIsButtonPressed(elem)
{
    return elem.pressed;
}

function d2hswitchcell(id, doc)
{
    var cells = new Array("D2HContents", "D2HIndex", "D2HSearch");
    var cellId = id + "Cell";
    if (!doc)
        doc = document;
    var elem = getElemById(doc, cellId);
    if (elem != null)
    {
        var selected = BACKGROUND_BTN_COLOR_NAVIGATOR;
        if (!d2hIsButtonPressed(elem))
        {
            var i;
            for (i = 0; i < cells.length; i++)
            {
                elem = getElemById(doc, cells[i] + "Cell");
                if (elem != null)
                {
                    if (id == cells[i])
                    {
                        elem.style.backgroundColor = selected;
                        d2hSelectButton(elem, false);
                    }
                    else
                    {
                        elem.style.backgroundColor = "";
                        elem.pressed = false;
                        d2hUnselectButton(elem);
                    }
                }
            }
        }           
    }
}
function d2hCommand(id, doc, onload, flat, href)
{
    if (d2hswitchpane(id, doc) && !flat)
        d2hswitchcell(id, doc);
    var frm, wnd;
    frm = getFrameByName("right");
    doc = getFrameDocument(frm);
    if (!href)
    {
		var elem = null;
		if (doc && !href)
			elem = getElemById(doc, id);
		if (!elem || typeof elem.href == "undefined")
			return;
		href = elem.href;
    }
    else if (id == "D2HContents" || id == "D2HIndex" || id == "D2HSearch")
	{
		frm = getFrameByName("left");
		doc = getFrameDocument(frm);
	}
    wnd = getWindow(doc);
    if (wnd == null)
        return;
	if (href)
	{
		if (onload)
			href += "?onload=" + escape(onload);
		wnd.location.href = href;
	}
}

function d2hIsTopicTitle(elem)
{
    if (elem.nodeType != 1)
        return false;
    var tagName = elem.tagName;
    tagName = tagName.substring(0, 1).toLowerCase();
    if (tagName == "h" || tagName == "p")
        return true;
    return false;
}

function d2hTraverseElements(elem, func)
{
    func(elem);
    var c = elem.firstChild;
    while (c != null)
    {
        if (c.nodeType == 1)
        {
            func(c);
            d2hTraverseElements(c, func);
        }
        c = c.nextSibling;
    }
}

function d2hSetZeroMargin(elem)
{
    elem.style.margin = "0pt";
    elem.style.padding = "0pt";
}

function d2hGetFirstChildElement(parent)
{
    var c = parent.firstChild;
    while (c != null && c.nodeType != 1)
        c = c.nextSibling;
    if (c != null && c.nodeType == 1)
        return c;
    return null;
}

function d2hStandardizePopupMargin(elem, marginpading2zeroElem, ienav)
{   
    elem.style.margin = "0pt";
    elem.style.padding = "6pt";
    var h = null;
    var contents;
    if (typeof marginpading2zeroElem != "undefined" && marginpading2zeroElem != null)
    {
        d2hSetZeroMargin(marginpading2zeroElem);
        contents = marginpading2zeroElem;
        if (typeof ienav != "undefined" && ienav != null)
        {
            ienav.className = "";
            d2hTraverseElements(ienav, d2hSetZeroMargin);
        }
    }
    else
        contents = elem;
    if (contents != null)
        h = d2hGetFirstChildElement(contents);
    if (h != null)
    {
        var tagName = h.tagName.toLowerCase();
        if (tagName == "div")
        {
            d2hSetZeroMargin(h);
            h = d2hGetFirstChildElement(h);
        }
        if (h != null && d2hIsTopicTitle(h))
            d2hSetZeroMargin(h);
    }
}

function d2hInitNavState()
{
    var prev = getElemById(document, "D2HPreviousImage");
    var prevClose = getElemById(document, "D2HPreviousImageClose");
    var next = getElemById(document, "D2HNextImage");
    var nextClose = getElemById(document, "D2HNextImageClose");
    if (prev && prevClose && prev.style.display == "" && prev.style.display == prevClose.style.display)
        prevClose.style.display = "none";
    if (next && nextClose && next.style.display == "" && next.style.display == nextClose.style.display)
        nextClose.style.display = "none";
    
}

function d2hSetNavigatorState(prev, next)
{
    var frm = getFrameByName("nav_bottom");
    if (!frm)
        frm = getFrameByName("nav");
    if (frm)
    {
        var doc = getFrameDocument(frm);
        if (doc)
        {
            var wnd = getWindow(doc);
            if (wnd)
            {
                if (typeof wnd.d2hSetNavState != "undefined")
                    wnd.d2hSetNavState(prev,next);
                else
                {
                    wnd.g_showNavPrev = prev;
                    wnd.g_showNavNext = next;
                }
            }
        }
    }
}

function d2hGetCellButton(cell)
{
    if (cell && cell.nodeType == 1)
    {
        if (cell.tagName.toLowerCase() != "span")
        {
            var elem = cell.firstChild;
            while (elem != null)
    {
                var res = d2hGetCellButton(elem);
                if (res)
                    return res;
                elem = elem.nextSibling;
            }
            return null;
        }
        else
            return cell;
    }
    else
        return null;
}

function d2hSButtonMOver(elem, flat)	
{
    if (!flat)
        d2hSelectButton(elem, true);
    if (!d2hIsButtonPressed(elem))
    {
        elem.style.backgroundColor = HIGHLIGHT_COLOR_NAVIGATOR;
        var button = d2hGetCellButton(elem);
        d2hSetTextState(button, true);
    }
}

function d2hSButtonMOut(elem, flat)
{
    if (!flat)
        d2hUnselectButton(elem);
    if (!d2hIsButtonPressed(elem))
    {
        elem.style.backgroundColor = "";
        var button = d2hGetCellButton(elem);
        d2hSetTextState(button, false);
    }
}

function d2hSetTextState(elem, hover)
{
    if (elem)
        elem.className = elem.id + (hover ? "Rollover" : (d2hIsButtonSelected(elem) ? "Selected" : "Unselected"));
}

function d2hOnTopLoad(evt, frmsetId)
{
    var tblHeader = getElemById(document, "tblCustHeader");
    var tblFooter = getElemById(document, "tblCustFooter");
    var hght = 0;
    if (tblHeader)
        hght = tblHeader.offsetHeight;
    if (tblFooter)
        hght += tblFooter.offsetHeight;
    var nav = getElemById(document, "tblMiddle");
    if (nav == null)
	nav = getElemById(document, "tblNavigator");
    var wnd = getWindow(document);
    var heigth = -1;
    if (wnd != null && typeof wnd.frameElement != "undefined")
        heigth = wnd.frameElement.offsetHeight - hght - nav.offsetHeight;
    else if (isOpera())
    {
        var l = getElemById(window.parent.document, frmsetId);
        if (l != null)
        {
            var str = l.rows;
            var val = parseInt(str);
            if (isNaN(val))
            {
                str = str.substring(2, str.length);
                val = parseInt(str);
            }
            if (!isNaN(val))
                heigth = val - hght - nav.offsetHeight;
        }
    }
    var inarm = true;
    if (heigth < 0)
    {
        heigth = document.documentElement.offsetHeight - hght - nav.offsetHeight;
        inarm = false;
    }
    if (heigth > 0)
        nav.style.height = nav.offsetHeight + heigth - 1;
    if (!inarm)
        d2hAdjustFrameHeigth(frmsetId);
    if (USE_SECTION_508 == "yes" && nav != null)
    {
        var anchors = nav.getElementsByTagName("a");
        for (var i = 0; i < anchors.length; i++)
            anchors[i].hideFocus = false;
    }
}

function d2hMDown(elem, flat)
{
    var button = d2hGetCellButton(elem);
    if (d2hIsButtonEnabled(button))
    {
        if (!flat)
            d2hSelectButton(elem, false);
        var selected = BACKGROUND_BTN_COLOR_NAVIGATOR;
        elem.style.backgroundColor = selected;
    }
}

function d2hMUp(elem, flat)
{
    var button = d2hGetCellButton(elem);
    if (d2hIsButtonEnabled(button))
    {
        if (elem != null)
        {
            elem.style.backgroundColor  = document.body.bgColor;
            elem.pressed = false;
            d2hDButtonMOver(elem, flat);
        }
    }
}

function d2hIsButtonEnabled(button)
{
    return button && button.className.indexOf("Disabled") == -1;
}

function d2hIsButtonSelected(button)
{
    return d2hActivePaneID() == button.id;
}
function d2hActivePaneID()
{
    var pane = d2hactivepane();
    if (pane == "indexlayout")
        pane = "D2HIndex";
    else if (pane == "searchlayout")
        pane = "D2HSearch";
    return pane;
}

function d2hDButtonMOver(elem, flat)	
{
    if (!d2hIsButtonPressed(elem))
    {
        elem.style.backgroundColor = HIGHLIGHT_COLOR_NAVIGATOR;
        var button = d2hGetCellButton(elem);
        if (d2hIsButtonEnabled(button))
        {
            d2hSetTextStateEx(button.id, true, true);
            if (!flat)
                d2hSelectButton(elem, true);
            var cells = new Array('D2HPreviousCell', 'D2HNextCell');
            var i;
            for (i = 0; i < cells.length; i++)
                if (elem.id != cells[i])
                {
                    var cell = getElemById(document, cells[i]);
                    if (cell)
                    {
                        cell.style.backgroundColor  = document.body.bgColor;
                        cell.pressed = false;
                        d2hDButtonMOut(cell, flat);
                    }
                }                
        }
    }
}

function d2hDButtonMOut(elem, flat)
{
    if (!flat)
        d2hUnselectButton(elem);
    elem.style.backgroundColor = "";
    var button = d2hGetCellButton(elem);
    if (button)
        d2hSetTextStateEx(button.id, d2hIsButtonEnabled(button), false);
}

function d2hSetNavState(prev, next)
{
    d2hShowElement("D2HPreviousImage", prev);
    d2hShowElement("D2HPreviousImageClose", !prev);
    d2hShowElement("D2HNextImage", next);
    d2hShowElement("D2HNextImageClose", !next);
    
    d2hSetTextStateEx("D2HPrevious", prev);
    d2hSetTextStateEx("D2HNext", next);
}

function d2hSetTextStateEx(id, show, hover)
{
    var elem = getElemById(document, id);
    if (elem)
    {
        if (elem.id == "D2HSyncToc")
        {
            elem.className = "syncToc";
            if (hover)
                elem.className += "Unselected";
        }
        else
        {
            if (hover)
                elem.className = elem.id + "Unselected";
            else
                elem.className = elem.id + (show ? "Selected" : "Disabled");
        }
    }
}

function d2hShowElement(id, show)
{
    var elem = getElemById(document, id);
    if (elem)
        elem.style.display = show ? "" : "none";
}

function d2hGetParentElement(elem)
{
    var parent = null;
    if (typeof elem != "undefined" && elem != null)
    {
        if (typeof elem.parentElement != "undefined")
            parent = elem.parentElement;
        else
        {
            parent = elem.parentNode;
            if (parent != null && parent.nodeType != 1)
            {
                parent = parent.parentNode;
                if (parent != null && parent.nodeType != 1)
                    parent = null;
            }
        }
    }
    return parent;
}

function d2hShowTopicTitleInPopup(doc)
{
    var nav = getElemById(doc, "nsbanner");
    if (nav == null)
        return;
    var title = getElemById(doc, "_d2hTitleNavigator");
    if (title == null)
    {
        nav.style.display = "none";
        return;
    }
    var parent = d2hGetParentElement(nav);
    if (parent == null)
        return;
    var objTitle = null;
    if (typeof title.removeNode != "undefined")
        objTitle = title.removeNode(true);
    else
        objTitle = title.cloneNode(true);
    parent.replaceChild(objTitle, nav);
}

function d2hNeedSendToBody(elem)
{
    var p = d2hGetParentElement(elem);
    return !(p == null || p == document.body);
}

function d2hMoveToEnd(elem, newParent)
{
    var obj = null;
    if (typeof elem.removeNode != "undefined")
        obj = elem.removeNode(true);
    else
    {
        var parent = d2hGetParentElement(elem);
        obj = parent.removeChild(elem);
    }
    newParent.appendChild(obj);
}

function d2hSend2Body(elem)
{
    var body = document.body;
    d2hMoveToEnd(elem, body);
}

function d2hGetInlinePosition(evt)
{
	var pt;
	if (evt.pageX)
		pt = new point(evt.pageX, evt.pageY);
	else
		pt = new point(evt.clientX + document.body.scrollLeft, evt.clientY + document.body.scrollTop);
    return pt;
}

function d2hGetRoot(strPath)
{
    var i, ch;
    for (i = strPath.length - 1; i > 0; i--)
    {
        ch = strPath.substring(i - 1, i); 
        if (ch == '\\' || ch == '/')
            return strPath.substring(0, i - 1);
    }
    return "";
}

function d2hIsAscii(charCode)
{
    return (charCode > 7 && charCode < 127);
}

function d2hIsAsciiOnly(str)
{
    for (var i = 0; i < str.length; i++)
    {
        if (!d2hIsAscii(str.charCodeAt(i)))
            return false;
    }
    return true;
}

function d2hGetServerType()
{
	if (isServerSide())
	{
	    var def = "jsp";
	    var platform =  d2hServerPlatform ? d2hServerPlatform.toLowerCase() : def;
	    if (platform != "asp" && platform != "jsp")
	        platform = def;
	    return platform;
	}
	else
	    return "htm";
}

function d2hGetMainThemeWnd(wnd)
{
    if (!wnd)
        return null;
    var nm = wnd.name.toLowerCase();
    if (wnd.g_bMainWnd == true || nm == "" || nm == "right")
        return wnd;
    return d2hGetMainThemeWnd(wnd.parent);
}

function d2hGetHRefWithoutHash(href)
{
    var indx = href.indexOf("#");
    if (indx > -1)
        href = href.substring(0, indx);
    return href;
}

function IsScriptHref(href)
{
    var l = href.length;
    if (l >= 8)
    {
        var protocol = href.substring(0, 8);
        if (protocol == "jscript:")
            return true;
        if (l >= 9)
        {
            protocol = href.substring(0, 9);
            if (protocol == "vbscript:")
                return true;
            if (l >= 11)
            {
                protocol = href.substring(0, 11);
                if (protocol == "javascript:")
                    return true;
            }
        }
    }
    return false;
}

function d2hPrepareAnchors4Popup()
{
    var hRefCurWnd = d2hGetHRefWithoutHash(window.location.href).toLowerCase();
    var doc = getDoc(window)
    var listObj = doc.getElementsByTagName("a");
    var elem, hr;
    for (i = 0; i < listObj.length; i++)
    {
        elem = listObj.item(i);
        hr = d2hGetHRefWithoutHash(elem.href).toLowerCase();
        if (hr.length != 0 && !elem.onclick && elem.target.length == 0 && !IsScriptHref(hr) && hr != hRefCurWnd)
            elem.onclick = d2hOnClickAInPopupWnd;
    }    
}

function d2hOnClickAInPopupWnd(evt)
{
    var mainWnd = d2hGetMainThemeWnd(window);
    if (!mainWnd)
        return true;
    evt = (evt) ? evt : ((typeof window.event != "undefined") ? event : null);
    if (evt)
    {
        var elem = (evt.target) ? evt.target : ((evt.srcElement) ? evt.srcElement : null);
        if (elem)
        {
            if (elem.nodeType == 3)
                elem = elem.parentNode;
            if (elem.tagName.toLowerCase() == "a")
            {
                if (typeof evt.cancelBubble != "undefined")
                    evt.cancelBubble = true;
                if (typeof evt.preventDefault != "undefined" && typeof evt.stopPropagation != "undefined")
                {
                    evt.preventDefault();
                    evt.stopPropagation();
                }
                var h = elem.href;
                if (window.parent)
                    window.parent.dhtml_popup();
                mainWnd.location.href = h;
                return false;
            }
        }
    }
    return true;
}

function d2hProcessTopicLinksForCSH()
{
	if (window.g_bCSHTopic || (typeof window.g_bCSHTopic == "undefined" && d2hIsCSH()))
	{
		var wnd = d2hGetMainThemeWnd(window);
		var listObj = document.getElementsByTagName("a");
		for (i = 0; i < listObj.length; i++)
			d2hProcessLinkElemForCSH(listObj.item(i), wnd.name);
		listObj = document.getElementsByTagName("button");
		for (i = 0; i < listObj.length; i++)
			d2hProcessLinkElemForCSH(listObj.item(i), wnd.name);		
		listObj = document.getElementsByTagName("area");
		for (i = 0; i < listObj.length; i++)
			d2hProcessLinkElemForCSH(listObj.item(i), wnd.name);		
	}
}

function d2hProcessLinkElemForCSH(elem, mainWnd)
{
	var t = d2hGetAttribute(elem, "target");
	if (t == "right")
		elem.setAttribute("target", mainWnd);
	var elemTarget = d2hGetAttribute(elem, "href");
	if (!elemTarget)
		return;
	var hr = d2hGetHRefWithoutHash(elemTarget);
	if (hr.length > 0)
	{
		var hash = "";
		if (hr.length < elemTarget.length)
			hash = elemTarget.substring(hr.length, elemTarget.length);
		if (hr.indexOf("?") == -1)
			hr += "?csh=1";
		else
			hr += "&csh=1";
		hr += hash;
		elem.setAttribute("href", hr);
	}
}

function d2hGetAttribute(elem, name)
{
	if (elem == null)
		return null;
	var res = null;
	if (typeof elem.getAttribute != "undefined")
		res = elem.getAttribute(name);
	if (typeof res != "undefined" && res != "")
		return res;
	if (typeof elem.outerHTML != "undefined")
	{
		var elemBody = elem.outerHTML;
		elemBody = elemBody.substring(elem.tagName.length + 1, elemBody.length);
		var indx = elemBody.indexOf(">");
		if (indx > -1)
		{
			elemBody = elemBody.substring(0, indx);
			var eBodyLow = elemBody.toLowerCase()
			name = name.toLowerCase() + "=";
			indx = eBodyLow.indexOf(name);
			if (indx > -1)
			{
				elemBody = elemBody.substring(indx + name.length + 1, elemBody.length);
				indx = elemBody.indexOf('"');
				if (indx > -1)
					res = elemBody.substring(0, indx);
				else
					res = elemBody;
			}
		}
	}
	return res;
}

function d2hProcessTopicNavForCSH()
{
	if (d2hIsCSH())
	{
		d2hHideMainNav();
		window.g_bCSHTopic = true;
		window.self.g_bMainWnd = true;
	}
}

function d2hHideMainNav()
{
	var nav = getElemById(document, "_d2hNavigatorLinks");
	if (nav)
	{
		nav.style.visibility = "hidden";
		nav.style.display = "none";
	}
}

function d2hIsCSH()
{
	var strSearch = document.location.search;
	strSearch = strSearch.substring(1, strSearch.length);
	var cshVal = getQueryVal(strSearch, "csh");
	return cshVal == "1";
}

function d2hButtonClick(evt)
{
	d2hLinkClick(evt);
}

function d2hLinkClick(evt)
{
	evt = (evt) ? evt : ((typeof window.event != "undefined") ? event : null);
	if (evt)
	{
		var elem = (evt.target) ? evt.target : ((evt.srcElement) ? evt.srcElement : null);
		if (elem)
		{
			if (elem.nodeType == 3)
				elem = elem.parentNode;
			var tag = elem.tagName.toLowerCase();
			if (tag != "a" && tag != "button" && tag != "area")
				elem = elem.parentNode;
			var target = d2hGetAttribute(elem, "target");
			var sWndFeatures = "";
			var isMenuItem = elem.getAttribute("mnui") == "1";
			var isIndexItem = elem.getAttribute("indx") == "1";
			if (typeof d2hInitWindowParams != "undefined")
			{
				d2hInitWindowParams();
				if (_d2hWindowParamsByWindows[target])
					sWndFeatures = _d2hWindowParamsByWindows[target];
				else if (elem.tagName.toLowerCase() == "a" && !isMenuItem && !isIndexItem)
					return true;
			}
			var href = d2hGetAttribute(elem, "href");
			var wnd = null;
			var w = isMenuItem ? window.parent : window;
			if (href && target)
			{
				if (isOpera())
				{
					wnd = w.open("about:blank", target, sWndFeatures);
					wnd.location.href = href;
				}
				else
					wnd = w.open(href, target, sWndFeatures);
			}
			else if (href)
			    wnd = w.open(href, "_self");
			if (wnd && typeof wnd.focus != "undefined")
				wnd.focus();
			return wnd == null;
		}
	}
	return true;
}

function d2hRegisterEventHandler(obj, altObj, eventName, handler)
{
	var o = altObj;
	var oldHandler = o[eventName.toLowerCase()];
	if (typeof oldHandler == "undefined")
	{
		o = obj;
		oldHandler = o[eventName.toLowerCase()];
	}
	if (typeof oldHandler == "undefined")
	{
		if (typeof document.scripts != "undefined")
		{
			var objName = typeof obj.open != "undefined" ? "window" : obj.tagName.toLowerCase();
			var altName = typeof altObj.open != "undefined" ? "window" : altObj.tagName.toLowerCase();
			for (var i = 0; i < document.scripts.length; i++) 
			{
				var script = document.scripts[i];
				if ((script.htmlFor == obj.id || script.htmlFor == objName || script.htmlFor == altObj.id || script.htmlFor == altName) && script.event == eventName)
				{
					oldHandler = script.innerHTML;
					break;
				}
			}
		}
	}
	else
	{
		var defFunc = "";
		if (oldHandler)
			defFunc = oldHandler.toString();
		var beg = defFunc.indexOf('{');
		var end = defFunc.lastIndexOf('}');
		if (beg > 0 || end > beg)
			oldHandler = defFunc.substring(beg + 1, end - 1);
	}
	if (oldHandler && oldHandler.indexOf(handler) >= 0)
		return;
	var newHandler = oldHandler;
	if (oldHandler == null || newHandler.length == 0)
		newHandler = handler;
	else
		newHandler += "; " + handler;
	o[eventName.toLowerCase()] = new Function("event", newHandler);
}

function d2hInitMainThemeHandlers(prev, next)
{
	d2hRegisterEventHandler(window, document.body, "onload", "d2hnsresize(event);d2hSetNavigatorState(" + prev + "," + next + ");d2hProcessTopicLinksForCSH();d2hProcessHighlight();");
	d2hRegisterEventHandler(window, document.body, "onmousedown", "d2hpopup(event);");
}

function d2hInitSecThemeHandlers()
{
	d2hRegisterEventHandler(window, document.body, "onload", "d2hload();d2hProcessHighlight();");
	d2hRegisterEventHandler(window, document.body, "onmousedown", "d2hpopup(event);");
}

function d2hGetMenuPanel(doc)
{
	var mnuId = "_d2h_popup_menu"
	var mnu = _d2hPopupMenu ? _d2hPopupMenu : getElemById(doc, mnuId);
	if (mnu == null)
	{
        mnu = doc.createElement("div");
        mnu.id = mnuId;
        mnu.height = "0px"
        mnu.width = "0px"
        mnu.className = "d2hPopupMenu";
        mnu.style.zIndex = 1000;
        mnu.noWrap = true;
        d2hHidePopupMenu(mnu);
        doc.body.appendChild(mnu);
    }
    else
    {
		d2hHidePopupMenu(mnu);
		mnu.innerHTML = "";
        mnu.height = "0px"
        mnu.width = "0px"		
	}
    return mnu;
} 

function d2hSetPopupMenuPos(doc, popupElem, x, y)
{
	var nstext = getElemById(doc, "nstext");
	var wnd = getWindow(doc);
	if (nstext == null)
		nstext = doc.getElementsByTagName((doc.compatMode && doc.compatMode == "CSS1Compat") ? "HTML" : "BODY")[0];
	var w_width = nstext.clientWidth ? nstext.clientWidth + nstext.scrollLeft : wnd.innerWidth + wnd.pageXOffset;
	var w_height = nstext.clientHeight ? nstext.clientHeight + nstext.scrollTop : wnd.innerHeight + wnd.pageYOffset;
	popupElem.style.width = "auto";
	popupElem.style.height = "auto";
	var textWidth = popupElem.offsetWidth;
	if (textWidth < 100)
		textWidth += 30;
	popupElem.style.width = textWidth + "px";
	var t_width = popupElem.offsetWidth;
	var t_height = popupElem.offsetHeight;
	popupElem.style.left = x + "px";
	popupElem.style.top = y + "px";
	var x_body_bottom = (doc.body.clientWidth ? doc.body.clientWidth : wnd.innerWidth) + doc.body.scrollLeft;
	var y_body_bottom = (doc.body.clientHeight ? doc.body.clientHeight : wnd.innerHeight) + doc.body.scrollTop;
	if (x + t_width > x_body_bottom)
	{
		x_body_bottom = x_body_bottom - t_width;
		if (x_body_bottom < 0)
			x_body_bottom = 0;
		popupElem.style.left = x_body_bottom + "px";
	}
	if (y + t_height > y_body_bottom)
	{
		y_body_bottom = y_body_bottom - t_height;
		if (y_body_bottom < 0)
			y_body_bottom = 0;
		popupElem.style.top = y_body_bottom + "px";
	}
}

function d2hShowPopupMenu(evt, doc, menu, arrLinks)
{
	if (typeof menu.style.display != "undefined")
		menu.style.display = "";

	var pt = d2hGetInlinePosition(evt);
	menu.style.width = "auto";
	menu.style.height = "auto";
	d2hSetPopupMenuPos(doc, menu, pt.x, pt.y);
	var isPopupObj = typeof window.createPopup != "undefined";
	var ie = isIE();
	if (arrLinks != null)
	{
		for (var i = 0; i < arrLinks.length; i++)
		{
			if (ie)
			{
				arrLinks[i].style.width = "100%";
				arrLinks[i].tabIndex = -1;
			}
			arrLinks[i].setAttribute("mnui", "1");
			if (isPopupObj)
				arrLinks[i].onclick = "d2hMenuItemClick(event)";
			else
				arrLinks[i].onclick = d2hMenuItemClick;
		}
	}
	
	if (!isPopupObj)
	{
		menu.style.visibility = "visible";
		return;
	}
	
	var popDoc = null;
	if (typeof menu.g_popupLayer == "undefined")
	{
		menu.g_popupLayer = window.createPopup();
		popDoc = getDoc(menu.g_popupLayer);
		var relpath = d2hGetAttribute(doc.body, "relPart");
		if (!relpath)
			relpath = "";
		popDoc.createStyleSheet(relpath + "Theme/popupmenu.css");
		d2hLoadScript(popDoc, "", relpath + "linker.js");
		d2hLoadScript(popDoc, "", relpath + "special.js");
		d2hLoadScript(popDoc, "", relpath + "common.js");
		var wnd = getWindow(popDoc);
		if (typeof d2hInitWindowParams != "undefined")
		{
			d2hInitWindowParams();
			wnd.d2hInitWindowParams = new Function();
			wnd._d2hWindowParamsByWindows = _d2hWindowParamsByWindows;
		}
	}
	else
		popDoc = getDoc(menu.g_popupLayer);
	var popup = menu.g_popupLayer;
	if (popDoc)
	{
		var oPopBody = popDoc.body;
		oPopBody.innerHTML = "";
		oPopBody.innerHTML = menu.outerHTML;
		var popMenu = getElemById(popDoc, "_d2h_popup_menu");
		if (popMenu)
		{
			popMenu.style.position = "";
			popMenu.style.left = "0";
			popMenu.style.top = "0";
			popMenu.style.visibility = "visible";
			popup.show(evt.clientX, evt.clientY, menu.offsetWidth, menu.offsetHeight, doc.body);
			return;
		}
	}
	menu.style.visibility = "visible";
}

function d2hHidePopupMenu(menu)
{
	if (!menu)
		return;
	if (typeof menu.g_popupLayer != "undefined")
		menu.g_popupLayer.hide();
	d2hHideInline(menu);
}

function d2hClosePopupMenu(evt, force)
{
    if (_d2hPopupMenu != null)
    {
		if (!force)
		{
			var pt = d2hGetInlinePosition(evt);
			var l = parseInt(_d2hPopupMenu.style.left);
			var t = parseInt(_d2hPopupMenu.style.top);
			var isLeftButton = true;
			var w3DOM = !(isIE() || (isOpera() && getOperaVersionNumber() < 8.0 /* In Opera, before 8.0: event.button == 1 for left mouse button, in 8.0 and higher: event.button == 0 */));
			if (typeof evt.button != "undefined")
			{
				if (evt.button != 1 && !w3DOM)
					isLeftButton = false;
				else if (evt.button != 0 && w3DOM)
					isLeftButton = false;
			}
			if (isLeftButton && pt.x > l && pt.y > t && pt.x <= l + _d2hPopupMenu.offsetWidth && pt.y <= t + _d2hPopupMenu.offsetHeight)
				return; 
		}
        d2hHidePopupMenu(_d2hPopupMenu);
        _d2hPopupMenu = null;
    }
}

function d2hLoadKeywordList()
{
    var strSearch = document.location.search;
    if (strSearch == null || strSearch.length == 0)
        return;
    strSearch = strSearch.substring(1, strSearch.length);
    if (strSearch == null || strSearch.length == 0)
        return;
    var linkID = getQueryVal(strSearch, "id");
    if (linkID == null || linkID.length == 0)
        return;
    window.g_d2hMenuItemsLoaded = d2hShowKeywordList;
    d2hLoadMenuItems(linkID, "AKLinks/" + linkID + '.js', true);
}

function d2hShowKeywordList(items)
{
    var arr = items;
    if (arr == undefined)
        return true;
    var header = getElemById(document, 'd2hKeywordTitle');
    if (header == null)
        return true;
    var list = getElemById(document, 'd2hKeywordList');
    if (list == null)
        return true;
    header.innerHTML = MSG_MANY_TOPICS_FOUND.replace('%d', arr.length);
    for (var i = 0; i < arr.length; i++)
    {
        var text = '<a id="d2hKeywordLink_' + i + '" href="' + d2hGetRelativePath(document, arr[i][0]) + '" title="' + TITLE_HOT_SPOT_JUMP + '"' + ((arr[i][1] != null) ? ' target = "' + arr[i][1] + '"' : '') + '>' + 
        '<img border=0  align=absMiddle src=' + d2hGetRelativePath(document, IMAGE_TOPIC) + ' alt="">' + arr[i][2] + '</a>';
        var s = document.createElement("p");
        s.innerHTML = text;
        list.appendChild(s); 
    }
    var firstLink = getElemById(document, 'd2hKeywordLink_0');
    if (firstLink != null)
        firstLink.focus();
    else
        document.focus();
    return true;
}

function d2hMenuItemClick(evt)
{
	d2hHidePopupMenu(_d2hPopupMenu);
	return d2hLinkClick(evt);
}

function d2hPopulateMenu(doc, menu, arr)
{
	var mnuItem, a, arrLinks;
	arrLinks = new Array();
	var relpath = d2hGetAttribute(doc.body, "relPart");
	if (!relpath)
		relpath = "";
	for (var i = 0; i < arr.length; i++)
	{
		mnuItem = doc.createElement("div");
		a = doc.createElement("a");
		a.setAttribute("href", relpath + arr[i][0]);
		if (arr[i][1] != null)
			a.setAttribute("target", arr[i][1]);
		a.innerHTML = arr[i][2];
		mnuItem.appendChild(a);
		arrLinks[arrLinks.length] = a;
		menu.appendChild(mnuItem);
	}
	return arrLinks;
}

function d2hPopupMenu(evt, arg)
{
	evt = (evt) ? evt : ((typeof window.event != "undefined") ? event : null);
	if (!evt)
		return false;
	var arr = d2hGetMenuItems(arg);
	var elem = (evt.target) ? evt.target : ((evt.srcElement) ? evt.srcElement : null);
	var doc = d2hGetOwnerDocument(elem);
	if (arr == null || arr.length == 0)
		alert(MSG_ZERO_TOPICS_FOUND);
	else if (arr.length == 1 || USE_SECTION_508 == "yes")
	{
		if (elem)
		{
			if (elem.nodeType == 3)
				elem = elem.parentNode;
			var tag = elem.tagName.toLowerCase();
			if (tag != "a" && tag != "button" && tag != "area")
				elem = elem.parentNode;
			var relpath = d2hGetAttribute(doc.body, "relPart");
			if (!relpath)
				relpath = "";
    		if (USE_SECTION_508 == "yes" && arr.length > 1)
                {
    			elem.setAttribute("href", relpath + "_d2h_keyword_links.htm?id=" + arg);
    			if (getFrameByName("right", d2hGetMainWindow()) != null)
		    	    elem.setAttribute("target", "right");
                }
    		else	
    		{
    			elem.setAttribute("href", relpath + arr[0][0]);
	        	if (arr[0][1] != null)
			    	elem.setAttribute("target", arr[0][1]);
			}
			return d2hLinkClick(evt);
		}
	}
	else
	{
            _d2hPopupMenu = d2hGetMenuPanel(doc);
            arr = d2hPopulateMenu(doc, _d2hPopupMenu, arr);
            d2hShowPopupMenu(evt, doc, _d2hPopupMenu, arr);
	}
	return false;
}

function d2hLoadScript(doc, elemId, src)
{
	var elem = doc.createElement("script");
	elem.setAttribute("language", "javascript");
	if (elemId != "")
		elem.id = elemId;
    elem.src = src;
    var listObj = doc.getElementsByTagName("head");
    var head = null;
    if (listObj && listObj.length > 0)
        head = listObj[0];
    else
        head = doc.body;
	head.appendChild(elem);
}

function Load2MenuBag(bag, doc, key, src)
{
	bag._files[key] = src;
	d2hLoadScript(doc, "_d2hscr_" + key, src);
}

function d2hGetMenuStorageWindow(wnd)
{
	if (!wnd)
        wnd =  window;
    if (!wnd.parent || wnd == wnd.parent)
        return wnd;
    return d2hGetMenuStorageWindow(wnd.parent);
}

function d2hGetMenuItems(key)
{
	var wnd = d2hGetMenuStorageWindow();
	return wnd.g_d2hMenuBag._items[key];
}

function d2hStoreMenuItems(key, items)
{
	var wnd = d2hGetMenuStorageWindow();
	wnd.g_d2hMenuBag._items[key] = items;
	if (typeof window.g_d2hMenuItemsLoaded != "undefined")
	    if (window.g_d2hMenuItemsLoaded(items))
	        window.g_d2hMenuItemsLoaded = null;
}
	
function d2hLoadMenuItems(key, datafile, reload)
{
	var wnd = d2hGetMenuStorageWindow();
	if (wnd.g_d2hMenuBag == null)
	{
		wnd.g_d2hMenuBag = new Object();
		wnd.g_d2hMenuBag._files = new Array();
		wnd.g_d2hMenuBag._items = new Array();
	}
	if ((typeof reload == "undefined" || !reload) && wnd.g_d2hMenuBag._files[key] != null)
		return;
	Load2MenuBag(wnd.g_d2hMenuBag, document, key, datafile);
}

function d2hLoadWindows()
{
	var windows = d2hGetRelativePath(document, "windows.js");
	if (g_hubProject.length > 0 && windows[0] != '/')
		windows = '/' + windows;
	windows = g_hubProject + windows;
	d2hLoadScript(document, "", windows);
}

function d2hLoadNavUrls()
{
	var urls = d2hGetRelativePath(document, "urls.js");
	if (g_hubProject.length > 0 && urls[0] != '/')
		urls = '/' + urls;
	urls = g_hubProject + urls;
	d2hLoadScript(document, "", urls);
}

function d2hCoupleUrl(href, doc)
{
	var hubPrj = null;
	if (doc)
	{
		var wnd = getWindow(doc);
		if (typeof wnd.g_hubProject != "undefined")
			hubPrj = wnd.g_hubProject;
	}
	if (hubPrj == null && typeof g_hubProject != "undefined")
		hubPrj = g_hubProject;
	if (hubPrj == null)
		return href;
	if (hubPrj.length > 0 && href[0] != '/')
		href = '/' + href;
	href = hubPrj + href;
	return href;
}

function d2hCoupleINav(evt)
{
	var elem = (evt.target) ? evt.target : ((evt.srcElement) ? evt.srcElement : null);
	if (elem)
	{
		if (elem.nodeType == 3)
			elem = elem.parentNode;
		var tag = elem.tagName.toLowerCase();
		if (tag != "a")
			elem = elem.parentNode;
		if (d2hGetAttribute(elem, "joined") == "1")
			return;
		var href = null;
		if (elem.id == 'D2HContents')
			href = window.g_ContentsURL;
		else if (elem.id == 'D2HIndex')
			href = window.g_IndexURL;
		else if (elem.id == 'D2HSearch')
			href = window.g_SearchURL;
		if (href)
		{
			elem.setAttribute("joined", "1");
			elem.setAttribute("href", d2hCoupleUrl(d2hGetRelativePath(document, href)));
		}
	}
}

function d2hGetMainWindow()
{
    var wnd = window;
    while (wnd.parent && wnd.parent != wnd)
        wnd = wnd.parent;
    return wnd;
}

function d2hUpdateLastHighlightState(checkbox)
{
    var wndMain = d2hGetMainWindow();
    if (typeof wndMain.useHighlight == "undefined")
        d2hSetLastHighlightState(checkbox.checked);
    else
        checkbox.checked = wndMain.useHighlight;
}

function d2hSetLastHighlightState(state)
{
    d2hGetMainWindow().useHighlight = state;
}

function d2hGetSearchFrameDocument()
{
    var wndMain = window;
    if (window.name == "right")
        wndMain = window;
    else if (window.name == "searchlist")
        wndMain = window.parent.parent;
    else if (dhtml_popup_is_open())
        wndMain = window.parent;
    else if (window.opener)
        wndMain = window.opener.parent;
    else if (window.name == "textprovider")
        return document;

    var frame1 = getFrameByName("left", wndMain);
    if (!frame1)
        return null;
        
    var docFrame1 = getFrameDocument(frame1);
    if (!docFrame1)
        return null;

    var frame2 = getElemById(docFrame1, "textprovider");
    if (!frame2)
        return null;
        
    var docFrame2 = getFrameDocument(frame2);
    if (!docFrame2)
        return null;

    return docFrame2;
}

function d2hGetRightFrameDocument()
{
    var frame1 = getFrameByName("right", d2hGetMainWindow());
    if (!frame1)
        return null;

    var docFrame1 = getFrameDocument(frame1);
    if (!docFrame1)
        return null;

    return docFrame1;
}

function d2hSetClickState(state)
{
    var frmSearch = d2hGetSearchFrameDocument();
    if (!frmSearch)
        return;

    var hClickState = getElemById(frmSearch, "clickStatus");
    if (hClickState)
        hClickState.value = state;

}

function d2hGetClickState(state)
{
    var frmSearch = d2hGetSearchFrameDocument();
    if (!frmSearch)
        return;

    var hClickState = getElemById(frmSearch, "clickStatus");
    if (hClickState)
        return hClickState.value;

    return null;
}

function d2hIsUseHighlight()
{
    var frmSearch = d2hGetSearchFrameDocument();
    if (!frmSearch)
        return;

    var cUseHighlight = getElemById(frmSearch, "useHighlight");
    if (cUseHighlight)
        return cUseHighlight.checked;
        
    return true;
}

function d2hProcessHighlightRightFrame()
{
    try
    {
        var frmRight = d2hGetRightFrameDocument();
        if (!frmRight)
            return;
        d2hSetClickState("onresult");
        d2hProcessHighlight(frmRight);
    }
    catch(ex)
    {}
}

function d2hProcessHighlight(doc)
{
    try
    {
        if (typeof doc == "undefined" || doc == null)
            doc = document;
                
        var frmSearch = d2hGetSearchFrameDocument();
        if (!frmSearch)
            return;

        if (d2hGetClickState() != "onresult")
            return;
        d2hSetClickState("");

        if (!d2hIsUseHighlight())
            return;

        var eQuery = getElemById(frmSearch, "query");
        if (!eQuery)
            return;

        var strRequest = eQuery.value;

        var listSearch = d2hSplitRequest(strRequest);

        d2hHighlightNode(doc.body, listSearch, false, true);
    }
    catch(ex)
    {}
}

var style_name = "d2hHlt";

function d2hHighlightNode(node, request, caseSensitive, wholeWord)
{
    if (!request || node.childNodes.length == 0)
        return;

    for (var i = 0; i < request.length; i++)
    {
        if (!caseSensitive)
            request[i] = request[i].toLowerCase();

        if (wholeWord)
            request[i] = '\\b'+request[i]+'\\b';
            
    }

    var regexpRequest = new RegExp(request.join("|"), caseSensitive ? "" : "i");

    var nodeproc = function(node)
    {
        var match = regexpRequest.exec(node.data);
        if (match)
        {
            var val = match[0];
            var node2 = node.splitText(match.index);
            var node3 = node2.splitText(val.length);
            var span = node.ownerDocument.createElement('span');
            node.parentNode.replaceChild(span, node2);
            span.className = style_name;
            span.appendChild(node2);
            return span;
        }

        return node;
    };
    //Artiom Modificat 03.04.2017   walkNodes(node.childNodes[0], 1, nodeproc);
    walkNodes(node.childNodes[0], 1, nodeproc);
}

function d2hRemoveHighlightRightFrame()
{
    try
    {
        var frmRight = d2hGetRightFrameDocument();
        if (!frmRight)
            return;
        d2hRemoveHighlightNode(frmRight.body);
    }
    catch(ex)
    {}
}

function d2hRemoveHighlightNode(node)
{
    var nodeproc = function(node)
    {
        if(node.parentNode.className == style_name)
            node.parentNode.className = "";
        return node;
    };
    //Artiom Modificat 03.04.2017   walkNodes(node.childNodes[0], 1, nodeproc);
    walkNodes(node.childNodes[0], 1, nodeproc);
}

function d2hSplitRequest(request)
{
    request = request.replace(/\W/g, ' ');

    request = request.replace(/^ +/, '');
    request = request.replace(/ +$/, '');

    return request.split(/ +/);
}

function walkNodes(node, depth, nodeproc)
{
    var check_time_nodes = 1000;
    var replace_weight = 20;
    var max_highlight_time = 2000;

    var regSkipTag = /^(script|style|textarea)/i;
    var count = 0;
    var timeBegin = new Date();
    while (node && depth > 0)
    {
        count++;
        if (count > check_time_nodes)
        {
            count = 0;
            if (new Date() - timeBegin > max_highlight_time)
                return;
                
        }

        if (node.nodeType == 1)
        {
            if (!regSkipTag.test(node.tagName) && node.childNodes.length > 0)
            {
                //Artiom Modificat 03.04.2017  node = node.childNodes[0];
                node = node.childNodes[0];
                depth ++;
                continue;
            }
        }
        else if (node.nodeType == 3)
        {
            var new_node = nodeproc(node);
            
            if (node != new_node)
            {
                node = new_node;
                count += replace_weight;
            }
        }

        if (node.nextSibling)
        {
            node = node.nextSibling;
        }
        else
        {
            while (depth > 0)
            {
                node = node.parentNode;
                depth--;
                if (node.nextSibling)
                {
                    node = node.nextSibling;
                    break;
                }
            }
        }
    }
}

function d2hElementInContainer(elem, container)
{
    do
    {
        if (elem == container)
            return true;
    }
    while ((elem = d2hGetParentElement(elem)) != null)
    return false;
}
function cancelEvent(evt)
{
    if (evt.preventDefault)
        evt.preventDefault();
    else
        evt.returnValue = false;
}
