var __callbackList = new Array();	//	Holds the asynchronous callback handler

//	Add the Callback Handler to array list
function addToCallbackList(cb) {
	__callbackList[__callbackList.length] = cb;
}

//	Is Microsoft Browser?
var __nonMSDOMBrowser = (window.navigator.appName.toLowerCase().indexOf('explorer') == -1);
var pageUrl = "";			//	Post Back URL
var __theFormPostData = "";	//	Form Data
function WebForm_InitClientCallback(cbUrl) {
	pageUrl = cbUrl;
	var theForm = document.forms[0];	//	ASP.NET currently support single form PostBack only
    count = theForm.elements.length;
    var element;
    re = new RegExp("\\x2B", "g");
    for (i = 0; i < count; i++) {
        element = theForm.elements[i];
         if (element.tagName.toLowerCase() == "input") {
            __theFormPostData += element.name + "=" + element.value.replace(re, "%2B") + "&";
         }
         else if (element.tagName.toLowerCase() == "select") {
            selectCount = element.children.length;
            for (j = 0; j < selectCount; j++) {
                selectChild = element.children[j];
                if ((selectChild.tagName.toLowerCase() == "option") && (selectChild.selected == true)) {
                    __theFormPostData += element.name + "=" + selectChild.value.replace(re, "%2B") + "&";                
                }                
            }
         }
    }
}


//	Callback asynchronously
function WebForm_DoAsyncCallback(eventTarget, eventArgument, eventCallback, context, errorCallback) {
    re = new RegExp("\\x2B", "g");
    if (__nonMSDOMBrowser) {
        var xmlRequest = new XMLHttpRequest();
        postData = __theFormPostData +
                   "__SCRIPTCALLBACKID=" + eventTarget +
                   "&__SCRIPTCALLBACKPARAM=" + escape(eventArgument).replace(re, "%2B");
        if (pageUrl.indexOf("?") != -1) {
            xmlRequest.open("GET", pageUrl + "&" + postData, false);
        }
        else {
            xmlRequest.open("GET", pageUrl + "?" + postData, false);
        }    
        xmlRequest.setRequestHeader("Content-Type", "application/x-www-form-urlencoded");
        xmlRequest.send(null);
        try
        {
			response = xmlRequest.responseText;
			status   = xmlRequest.getResponseHeader("__SCRIPTCALLBACKSTATUS");
			if (status == "200") 
			{			
				if (eventCallback != null)
					eventCallback(response, context);
			}
			else
			{
				if (errorCallback != null)
					errorCallback(response, context);
				else
				{
					//	For Testing Purposes
					//alert(response);
				}
			}
        }
        catch(e)
        {
            if (errorCallback != null)
                errorCallback(e.message, context);
			else
			{
				//	For Testing Purposes
				//alert(e.message);
			}
			
        }
    }
    else {
        var xmlRequest = new ActiveXObject("Microsoft.XMLHTTP");
        xmlRequest.onreadystatechange = WebForm_OnClientCallbackComplete;
        var __callbackObject = new Object();
        __callbackObject.xmlRequest = xmlRequest;
		__callbackObject.eventTarget = eventTarget;
		__callbackObject.eventArgument = eventArgument;
        __callbackObject.eventCallback = eventCallback;
        __callbackObject.context = context;
        __callbackObject.errorCallback = errorCallback;
        addToCallbackList(__callbackObject);
        
        postData = __theFormPostData +
                   "__SCRIPTCALLBACKID=" + eventTarget +
                   "&__SCRIPTCALLBACKPARAM=" + escape(eventArgument).replace(re, "%2B");
        usePost = false;
        if (pageUrl.length + postData.length + 1 > 2067) {
            usePost = true;
        }
        if (usePost) {
            xmlRequest.open("POST", pageUrl, true);
            xmlRequest.setRequestHeader("Content-Type", "application/x-www-form-urlencoded");
            xmlRequest.send(postData);
        }
        else {            
            if (pageUrl.indexOf("?") != -1) {
                xmlRequest.open("GET", pageUrl + "&" + postData, true);
            }
            else {
                xmlRequest.open("GET", pageUrl + "?" + postData, true);
            }
            xmlRequest.setRequestHeader("Content-Type", "application/x-www-form-urlencoded");
            xmlRequest.send();
        }
    }
}


//	Callback Synchronously
function WebForm_DoSyncCallback(eventTarget, eventArgument, eventCallback, context, errorCallback) {
    if (__nonMSDOMBrowser) 
    {
		re = new RegExp("\\x2B", "g");
		var xmlRequest = new XMLHttpRequest();
		postData = __theFormPostData +
					"__SCRIPTCALLBACKID=" + eventTarget +
					"&__SCRIPTCALLBACKPARAM=" + escape(eventArgument).replace(re, "%2B");
		if (pageUrl.indexOf("?") != -1) {
			xmlRequest.open("GET", pageUrl + "&" + postData, false);
		}
		else {
			xmlRequest.open("GET", pageUrl + "?" + postData, false);
		}    
		xmlRequest.setRequestHeader("Content-Type", "application/x-www-form-urlencoded");
		xmlRequest.send(null);
		try
		{
			response = xmlRequest.responseText;
			status   = xmlRequest.getResponseHeader("__SCRIPTCALLBACKSTATUS");
			if (status == "200") 
			{			
				if (eventCallback != null)
					eventCallback(response, context);
			}
			else
			{
				if (errorCallback != null)
					errorCallback(response, context);
				else
				{
					//	For Testing Purposes
					//alert(response);
				}
			}
		}
		catch(e)
		{
			if (errorCallback != null)
				errorCallback(e.message, context);
			else
			{
				//	For Testing Purposes
				//alert(e.message);
			}
		}
	}
	else
	{
        var xmlRequest = new ActiveXObject("Microsoft.XMLHTTP");
        postData = __theFormPostData +
                   "__SCRIPTCALLBACKID=" + eventTarget +
                   "&__SCRIPTCALLBACKPARAM=" + escape(eventArgument).replace(re, "%2B");
        usePost = false;
        if (pageUrl.length + postData.length + 1 > 2067) {
            usePost = true;
        }
        if (usePost) {
            xmlRequest.open("POST", pageUrl, false);
            xmlRequest.setRequestHeader("Content-Type", "application/x-www-form-urlencoded");
            xmlRequest.send(postData);
        }
        else 
        {            
            if (pageUrl.indexOf("?") != -1) {
                xmlRequest.open("GET", pageUrl + "&" + postData, false);
            }
            else {
                xmlRequest.open("GET", pageUrl + "?" + postData, false);
            }
            xmlRequest.setRequestHeader("Content-Type", "application/x-www-form-urlencoded");
            xmlRequest.send();
        }
        
        try
        {
			response = xmlRequest.responseText;
			status   = xmlRequest.getResponseHeader("__SCRIPTCALLBACKSTATUS");
			if (status == "200") 
			{			
				if (eventCallback != null)
					eventCallback(response, context);
			}
			else
			{
				if (errorCallback != null)
					errorCallback(response, context);
				else
				{
					//	For Testing Purposes
					//alert(response);
				}
			}
        }
        catch(e)
        {
            if (errorCallback != null)
                errorCallback(e.message, context);
			else
			{
				//	For Testing Purposes
				//alert(e.message);
			}
        }        
	}
}


//	Asynchronous Callback Completed
function WebForm_OnClientCallbackComplete() 
{
	for(var i = 0; i < __callbackList.length; i++)
	{
		var __cbObject = __callbackList[i];
		
		if (__cbObject != null && __cbObject.xmlRequest.readyState == 4) 
		{
			try
			{
				xmlText	 = __cbObject.xmlRequest.responseXML;
				response = __cbObject.xmlRequest.responseText;
				status   = __cbObject.xmlRequest.getResponseHeader("__SCRIPTCALLBACKSTATUS");
				if (status == "200") 
				{
					if (__cbObject.eventCallback != null)
						__cbObject.eventCallback(response, __cbObject.context);
				}
				else
				{
					if (__cbObject.errorCallback != null)
						__cbObject.errorCallback(response, __cbObject.context);
					else
					{
						//	For Testing Purposes
						//alert(response);
					}
				}
			}
			catch(e)
			{
				if (__cbObject.errorCallback != null)
					__cbObject.errorCallback(e.message, __cbObject.context);
				else
				{
					//	For Testing Purposes
					//alert(e.message);
				}
			}
			finally
			{
				__cbObject.xmlRequest = null;
				__cbObject = null;
				__callbackList[i] = null;
			}
		}
    }
}
