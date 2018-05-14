var MenuNodes=[];
var images_path = "";

var ROOT_class = "TaskStyle";
var LEAF_class = "TaskStyle";

function RegisterMenuNode(Node)
{
	MenuNodes[Node.NodeID]=Node;
}

function getMenuNode(NodeID)
{
    ///return MenuNodes[NodeID];
    return MenuNodes [NodeID];
    
}


function IsLeafNode(NodeID)
{
	return getMenuNode(NodeID).ChildNumber==-1;
}

function IsRootNode(NodeID)
{
	return getMenuNode(NodeID).ParentID==null;
}

function CreateNodeMeniu(NodeID,Text,Values,Expanded,ContainerID,LinkText,Link,Target,OnClick)
{
	this.Prefix="";
	this.Target=Target;
	this.NodeID = NodeID;
	this.ParentID = null;
	this.Text=Text;
	this.Values=Values;
	this.Checked = false;
	this.Expanded = Expanded;
	this.ContainerID=ContainerID;
	this.LinkText=LinkText;
	this.Link=Link;
	this.ChildNumber = -1;
	this.Children = [];
	this.ChildrenIndex=[];
	this.OnClick=OnClick;
	this.Render = RenderNode;
	this.AddSubNode =AddSubNodeMenu;
	this.Toggle=ToggleMenuNode;
	RegisterMenuNode(this);
	this.Collapse = CollapseChildrenMenuNodes;
	this.ExpandAllMenuNodes = ExpandAllMenuNodes;
}

function CollapseChildrenMenuNodes()
{
	for (var i=0;i<this.ChildNumber;i++) 
	{	
		var tmpNode = getMenuNode(this.ChildrenIndex[i]);
		tmpNode.Expanded = false;

		}
}

function ToggleMenuNode()
{
    //=!
	this.Expanded =! this.Expanded;
	var tmp = this.Expanded;
	if (this.ParentID!=null) 
	{
		getMenuNode(this.ParentID).Collapse();
	}
	this.Expanded = tmp;

	if (this.ParentID!=null) 
	{
		getMenuNode(this.ParentID).Render(); 
	}
	else 
	{
		this.Render();
	}
}

function ExpandAllMenuNodes()
{
	this.Expanded=true;
	for (var i=0;i<this.ChildNumber;i++) 
	{
		var tmpNode = getMenuNode(this.ChildrenIndex[i]);
		tmpNode.ExpandAllMenuNodes();
	}
}

function AddSubNodeMenu(NodeID)
{
	this.ChildrenIndex[this.ChildrenIndex.length]=NodeID;
	this.Children[NodeID]=NodeID;
	this.ChildNumber = this.ChildrenIndex.length;
	getMenuNode(NodeID).ParentID=this.NodeID;
	getMenuNode(NodeID).Prefix=this.Prefix+"&nbsp;&nbsp;&nbsp;&nbsp;";
	getMenuNode(NodeID).ContainerID=this.ContainerID+"_"+this.ChildNumber;
}

function ExpandToParent(NodeID)
{
	if (IsLeafNode(NodeID))
	{
		ExpandToParent(getMenuNode(NodeID).ParentID);
	}
	else
	{
		if (IsRootNode(NodeID))
		{
			getMenuNode(NodeID).Expanded=true;
		}
		else
		{
			getMenuNode(NodeID).Expanded=true;
			ExpandToParent(getMenuNode(NodeID).ParentID);
		}
	}
}

function HandleLastSelectedNode()
{
	if (LastSelectedNodeID.length>0)
	{
		ExpandToParent(LastSelectedNodeID);
	}
	else
	{
		if (DefaultSelectedNodeID.length>0)
		{
			ExpandToParent(DefaultSelectedNodeID);
		}
	}
}

function MarkSelectedNode (obj)
{
	obj.style.backgroundColor = "#ffffff";
	obj.style.borderLeft = "1px solid #20b2aa";
	obj.style.borderBottom = "1px solid #20b2aa";
	obj.style.borderTop = "1px solid #20b2aa";
	obj.style.borderRight = "1px solid #20b2aa"; 
	obj.style.cursor = "hand";
}

function RenderNode()
{
	var HeaderContainerID = this.ContainerID+"_Top";
	var ChildsContainerID = this.ContainerID+"_Children";
	var chld = "";
	var exp_pre="&nbsp;";
	var exp = "";
	var chld_aux="";
	var OnClickAux = "";
	var OnHrefAux = "";
	
	if (IsLeafNode(this.NodeID) || IsRootNode(this.NodeID))
	{
	    //OnHrefAux = "javascript:document.getElementById('LastSelectedNodeID').value='" + this.NodeID + "';getMenuNode('" + this.NodeID + "').Toggle();" + this.OnClick;
		OnClickAux="onclick=document.getElementById('LastSelectedNodeID').value='"+this.NodeID+"';getMenuNode('"+this.NodeID+"').Toggle();"+this.OnClick;
	}
	else
	{
	    //OnHrefAux = "javascript:getMenuNode('" + this.NodeID + "').Toggle();"
		OnClickAux="onclick=getMenuNode('"+this.NodeID+"').Toggle();"
	}

	if (!IsLeafNode(this.NodeID))
	{
		exp_pre="";
		if (!IsRootNode(this.NodeID))
		{
			if (this.Expanded)
			{	
				exp = "<img src='"+images_path+"/arrow_opened.gif' border=0 vallign=baseline>";
			}
			else
			{ 
				exp = "<img src='"+images_path+"arrow_closed.gif' border=0 vallign=baseline>";
			}
		}
		else
		{
			this.Expanded=true;
		}

		for (var i=0;i<this.ChildNumber;i++)
		{
			chld_aux+="<tr><td   id = '"+this.ContainerID+"_"+(i+1)+"'></td></tr>";
		}
	}

	chld = "<table cellpadding=0 cellspacing=0 width=100% bgcolor=#ededed border=0>"+chld_aux+"</table>";

	var linkClass=LEAF_class;
	if (IsRootNode(this.NodeID)) linkClass=ROOT_class;

	var toggle = exp_pre+"&nbsp;<a href=javascript:getMenuNode('"+this.NodeID+"').Toggle() class='"+linkClass+"'>"+exp+"</a>";
	var text = this.LinkText;

	if (this.Link!=null)
	{
	    text = "<a "+OnClickAux+" href='"+this.Link+"' class='"+linkClass+"' target="+this.Target+" >"+text+"</a>";

	    //text = "<a " + " href='" + OnHrefAux+ "' class='" + linkClass + "' target=" + this.Target + " >" + text + "</a>";
	    //text = "<a " + " href='" + this.Link + "' class='" + linkClass + "' target=" + this.Target + " >" + text + "</a>";
	}

	var theClass;
	var theClass_toggle;

	theClass="MenuStyle"; 
	color_aux="white";

	var RootAux = "";
	var auxActions = "onmouseover=MouseOverTasksNavigationTree(this) onmouseout=MouseOutTasksNavigationTree(this)";
	var idCellSelected = "";

	if (LastSelectedNodeID.length>0)
	{
		if (this.NodeID == LastSelectedNodeID) 
		{
			auxActions="";
			idCellSelected="id=selected_node_cell";
		} 
	}
	else
	if (DefaultSelectedNodeID.length>0)
	{
		if (this.NodeID == DefaultSelectedNodeID) 
		{
			auxActions="";
			idCellSelected="id=selected_node_cell";
		} 
	}

    //var aux = "<table width=100% cellspacing=0 cellpadding=1 bgcolor=#ededed border=0><tr><td onclick=getMenuNode('"+this.NodeID+"').Toggle() align=left id='"+this.NodeID+"_Button' id='"+HeaderContainerID+"'>"+toggle+"</td><td "+idCellSelected+" class="+theClass+" width=100%  align=left "+auxActions+" "+OnClickAux+" nowrap bgcolor=#ededed>"+text+"</td></tr>"+RootAux+"<tr><td></td><td align=left  id='"+ChildsContainerID+"' valign=top height=100%>"+chld+"</td></tr></table>";
	var aux = "<table width=100% cellspacing=0 cellpadding=1 bgcolor=#ededed border=0><tr><td onclick=getMenuNode('"+this.NodeID+"').Toggle() align=left id='"+this.NodeID+"_Button'>"+toggle+"</td><td "+idCellSelected+" class="+theClass+" width=100%  align=left "+auxActions+" "+OnClickAux+" nowrap bgcolor=#ededed>"+text+"</td></tr>"+RootAux+"<tr><td></td><td align=left  id='"+ChildsContainerID+"' valign=top height=100%>"+chld+"</td></tr></table>";

	document.getElementById(this.ContainerID).innerHTML = aux;

	if (LastSelectedNodeID.length>0)
	{
		if (this.NodeID == LastSelectedNodeID) 
		{
			MarkSelectedNode(document.getElementById("selected_node_cell"));
		} 
	}
	else
	{
		if (DefaultSelectedNodeID.length>0)
		{
			if (this.NodeID == DefaultSelectedNodeID) 
			{
				MarkSelectedNode(document.getElementById("selected_node_cell"));
			} 
		}
	}


	if (!IsLeafNode(this.NodeID))
	{
		if (this.Expanded)
		{
			for (var i=0;i<this.ChildNumber;i++) 
			{	
				getMenuNode(this.ChildrenIndex[i]).Render();
			}
		}
		else 
		{
			document.getElementById(ChildsContainerID).innerHTML = "";
		}
	} 
	else 
	{
		//delight(this.NodeID+"_Button");
		//delight(this.NodeID+"_Button_1");
	}
}