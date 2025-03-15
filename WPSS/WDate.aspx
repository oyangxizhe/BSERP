<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WDate.aspx.cs" Inherits="WPSS.WDate" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>选择日期</title>
    <base target ="_self" />
</head>
<body>
    <form id="form1" runat="server">
    
    <div>
     <input id="hint" type="hidden"  runat="server" />
    </div>
    <asp:Calendar ID="Calendar1" runat="server" 
        onselectionchanged="Calendar1_SelectionChanged" Height="230px" 
        Width="240px"></asp:Calendar>
    <script type="text/javascript" language="javascript">
    window.onload = function onload1() {
        var Invocation = document.getElementById("hint").value;
        if (Invocation != "") {
            window.returnValue = Invocation;
            window.close();

        }
    }
</script>
    </form>
</body>
</html>
