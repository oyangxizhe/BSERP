<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Date.aspx.cs" Inherits="WPSS.Date" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
    
 <base target ="_self" /> 
</head>
<body>
    <form id="form1" runat="server">
    <div>
      <input id="hint" type="hidden"  runat="server" />
    </div>
             <a href ="javascript:a()">选取</a>
    <asp:Calendar ID="Calendar1" runat="server"  
        onselectionchanged="Calendar1_SelectionChanged"></asp:Calendar>
    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
<script type="text/javascript" language="javascript">
 
    window.onload = function onload1() {
        var Invocation = document.getElementById("hint").value;
        if (Invocation != "") {
            window.returnValue = Invocation;

            window.close();
        }
        else {
            
        }
    }
</script>
    </form>
</body>
</html>
