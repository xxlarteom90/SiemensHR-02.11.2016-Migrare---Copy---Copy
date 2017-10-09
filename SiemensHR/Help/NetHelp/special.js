var POPUP_COLOR = "LightYellow";
var POPUP_REPEAT = "no-repeat";
var POPUP_IMAGE = "";
var IMAGE_OPEN = "Images/Theme/Buttons%20and%20Icons/open_xp.gif";
var IMAGE_CLOSE = "Images/Theme/Buttons%20and%20Icons/closed_xp.gif";
var IMAGE_TOPIC = "Images/Theme/Buttons%20and%20Icons/topic_xp.gif";
var INDEX_SELECTED = "Images/Theme/Buttons%20and%20Icons/nav_idx_sel.gif";
var INDEX_UNSELECTED = "Images/Theme/Buttons%20and%20Icons/nav_idx.gif";
var CONTENTS_SELECTED = "Images/Theme/Buttons%20and%20Icons/nav_toc_sel.gif";
var CONTENTS_UNSELECTED = "Images/Theme/Buttons%20and%20Icons/nav_toc.gif";
var SEARCH_SELECTED = "Images/Theme/Buttons%20and%20Icons/nav_search_sel.gif";
var SEARCH_UNSELECTED = "Images/Theme/Buttons%20and%20Icons/nav_search.gif";
var SYNCTOC_SELECTED = "Images/Theme/Buttons%20and%20Icons/nav_sync.gif";
var SYNCTOC_UNSELECTED = "Images/Theme/Buttons%20and%20Icons/nav_sync_sel.gif";
var ANCHOR = "";
var CLASS_ITEMOVER = "clsMouseOver";
var CLASS_ITEMOUT = "";
var CLASS_ITEMCURSEL = "clsCurrentTocItem";
var MSG_BROWSERNOTSUPPORTED = "<h2>Search engine does not support this browser</h2><hr />Search engine requires one of the following browsers:<ul><li>Internet Explorer 6.0 or higher</li><li>Netscape 6.2.3 or higher</li><li>Firefox</li><li>Mozilla 1.2 or higher</li><li>Opera 1.54 or higher</li></ul>";
var MSG_SEARCHENGINENOTLOADED = "<h2>Search engine failed to initialize</h2><hr /> Error: Java is disabled or not installed, or Java applet cannot initialize for other reasons.<br />Client-side search requires a Java-enabled browser.</p><p>If Java is not installed on your computer and you can't switch to using server-side search, we recommend installing JRE from the Sun Microsystems web site.<br /><a href=\"http://java.sun.com/products/plugin/index.jsp\">Download JRE</a></p>";
var MSG_SEARCHENGINENOTLOADED_PATHCONTAINSNONASCII = "<h2>Search engine failed to initialize</h2><hr noshadow />Error: Path to NetHelp contains non-ASCII characters.<br />Move NetHelp to a folder with only ASCII characters in directory names.";
var HIGHLIGHT_COLOR_NAVIGATOR = "#DAEAFC"
var BACKGROUND_BTN_COLOR_NAVIGATOR = "#A2C6DD";
var MSG_ZERO_TOPICS_FOUND = "No topics found.";
var MSG_MANY_TOPICS_FOUND = "%d topics found.";
var ALT_CLOSED_BOOK_NO_TOPIC = "Closed book without topic";
var ALT_CLOSED_BOOK_TOPIC = "Closed book with topic";
var ALT_OPEN_BOOK_NO_TOPIC = "Open book without topic";
var ALT_OPEN_BOOK_TOPIC = "Open book with topic";
var ALT_TOPIC = "Topic";
var TITLE_HOT_SPOT_JUMP = "link";
var USE_SECTION_508 = "no";


function dhtml_NNscrollingStyle()
{
    d2hHideBodyScrollBar();

    var oBanner= document.getElementById("nsbanner");
    var oText= document.getElementById("nstext");

    if (oText == null)
        return;

    if (oBanner != null)
    {
        oText.style.overflow = "auto";
        oText.style.top = 0;
        var frm = getFrameByName("right");
        var h;
        if (frm)
        {
            var doc = getFrameDocument(frm);
            var wnd = getWindow(doc);
            h = wnd.innerHeight - oBanner.offsetHeight - (isOpera() ? 0 : 6);
        }
        else
            h = window.innerHeight - oBanner.offsetHeight - (isOpera() ? 0 : 6);
        if (h < 0)
            h = 0;
        oText.style.height = h;
    }
    try
    {	
        d2hRegisterEventHandler(window, document.body, "onresize", "d2hnsresize();");
        d2hRegisterEventHandler(window, document.body, "onbeforeprint", "d2h_before_print();");
        d2hRegisterEventHandler(window, document.body, "onafterprint", "d2h_after_print();");
    }
    catch(e)
    {
    }
}

function dhtml_scrollingStyle()
{
    d2hHideBodyScrollBar();
    var oT= document.getElementById("nstext");
    if (oT == null)
        return;
    if (typeof oT.style.overflow != "undefined")
        oT.style.overflow = "auto";
}

function d2hHideBodyScrollBar()
{
    if (typeof document.body.scroll != "undefined")
        document.body.scroll = "no";
    document.body.style.overflow = "hidden";
}


function getTriPaneOffset()
{
    return 2;
}

function d2hSetTopicTextRightIndent(elem)
{
    if (_needIndentation)
        elem.style.paddingRight = "20px";
}
function d2hSyncTOC()
{
	var frm = getFrameByName("right");
	var next = true;
	if (frm)
	{
		var doc = getFrameDocument(frm);
		if (doc && doc.location.href != "about:blank")
			next = false;
	}
	if (next)
	{
		setTimeout("d2hSyncTOC()", 100);
		return;
	}

d2hSyncDynamicToc();

}
