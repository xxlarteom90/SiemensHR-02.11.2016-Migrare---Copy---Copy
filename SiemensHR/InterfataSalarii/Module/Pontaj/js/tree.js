var Nodes=[];

function RegisterNode(Node)
{
	Nodes[Node.NodeID]=Node;
}

function getNode(NodeID)
{
	return Nodes[NodeID];
}

function IsLeaf(NodeID)
{
	return getNode(NodeID).ChildNumber==-1;
}

function IsRoot(NodeID)
{
	return getNode(NodeID).ParentID==null;
}

function CreateNodeElement(NodeID,Text,Values,Expanded,ContainerID,LinkText,Link,Target,OnClick)
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
	this.Render = RenderNodeElement;
	this.AddSubNode =AddSubNode;
	this.Toggle=ToggleNode;
	RegisterNode(this);
	this.Collapse = CollapseChildren;
	this.ExpandAll = ExpandAll;
}

function CollapseChildren()
{
	for (var i=0;i<this.ChildNumber;i++) 
	{	
		var tmpNode = getNode(this.ChildrenIndex[i]);
		tmpNode.Expanded=false;
	}
}

function ToggleNode()
{
	this.Expanded = ! this.Expanded;
	var tmp = this.Expanded;
	(this.ParentID!=null) getNode(this.ParentID).Collapse();
	this.Expanded = tmp;
	if (this.ParentID!=null) getNode(this.ParentID).Render(); else this.Render();
}

function ExpandAll()
{
	this.Expanded=true;
	for (var i=0;i<this.ChildNumber;i++) 
	{	
		var tmpNode = getNode(this.ChildrenIndex[i]);
		tmpNode.ExpandAll();
	}
}

function AddSubNode(NodeID)
{
	this.ChildrenIndex[this.ChildrenIndex.length]=NodeID;
	this.Children[NodeID]=NodeID;
	this.ChildNumber = this.ChildrenIndex.length;
	getNode(NodeID).ParentID=this.NodeID;
	getNode(NodeID).Prefix=this.Prefix+"&nbsp;&nbsp;&nbsp;&nbsp;";
	getNode(NodeID).ContainerID=this.ContainerID+"_"+this.ChildNumber;
}

function RenderNodeElement()
{
	var HeaderContainerID = this.ContainerID+"_Top";
	var ChildsContainerID = this.ContainerID+"_Children";
	var chld = "";
	var exp = "";
	var chld_aux="";

	if (!IsLeaf(this.NodeID))
	{
		if (!IsRoot(this.NodeID))
		{
			if (this.Expanded) exp = "<img src='../images/arrow_opened.gif' border=0 vallign=baseline>"; else exp = "<img src='../images/arrow_closed.gif' border=0 vallign=baseline>";
		} 
		else this.Expanded=true;

		for (var i=0;i<this.ChildNumber;i++)
		{
			chld_aux+="<tr><td  id = '"+this.ContainerID+"_"+(i+1)+"'></td></tr>";
		}
	}

	chld = "<table cellpadding=0 cellspacing=0 width=100% >"+chld_aux+"</table>";

	var linkClass="MenuStyle";
	if (IsRoot(this.NodeID)) linkClass="linktext3";

	var toggle = "&nbsp;&nbsp;&nbsp;&nbsp;<a href=# onclick=getNode('"+this.NodeID+"').Toggle() class='"+linkClass+"'>"+exp+"</a>";
	var text = this.LinkText;

	if (this.Link!=null)
	{
		text = "<a onclick='"+this.OnClick+"' href='"+this.Link+"' class='"+linkClass+"' target="+this.Target+">"+text+"</a>";
	}

	var theClass;
	var theClass_toggle;

	theClass="MenuStyle"; 
	color_aux="white";

	var RootAux = "";
	var aux = "<table width=100% cellspacing=0 cellpadding=2 class=MenuStyle><tr><td align=left id='"+this.NodeID+"_Button' id='"+HeaderContainerID+"'>"+toggle+"</td><td class="+theClass+" width=100%  align=left>"+text+"</td></tr>"+RootAux+"<tr><td></td><td align=left  id='"+ChildsContainerID+"' valign=top height=100%>"+chld+"</td></tr></table>";
	document.getElementById(this.ContainerID).innerHTML = aux; 
	
	if (!IsLeaf(this.NodeID))
	{
		if (this.Expanded)
		{
			for (var i=0;i<this.ChildNumber;i++) 
			{	
				getNode(this.ChildrenIndex[i]).Render();
			}
		}
		else document.getElementById(ChildsContainerID).innerHTML = "";
	}
}