<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="xizheimg.aspx.cs" Inherits="WPSS.xizheimg" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
     <link href = "Css/SSBase.css" type  ="text/css" rel ="Stylesheet" />
 <link rel="Stylesheet" href="Css/120610.css" type ="text/css" />
  <link rel="Stylesheet" href="Css/c120807o.css" type ="text/css" />
  <link rel="Stylesheet" href="Css/c072701.css" type ="text/css" />
<link rel="Stylesheet" href="Css/S130424.css" type ="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div class ="centre "><div id="i13053001" class ="c14102902"><img src= "Image/loading.gif" alt =""  /></div></div> 
<div id="c14111201" style ="display:none ">

    <img src = "Image/788X788.png" alt="" />
    </div>
        <script type="text/javascript" language="javascript">

        window.onload = function onload1() {
            //document.getElementById("text1").focus();
       
        
        document.getElementById("i13053001").style.display = "none";
        document.getElementById("c14111201").style.display = "block";

        }

        function enter2tab(e) {
            if (window.event.keyCode == 13) window.event.keyCode = 9
        }
    
        document.onkeydown = enter2tab;
</script>
    </form>
</body>
</html>
