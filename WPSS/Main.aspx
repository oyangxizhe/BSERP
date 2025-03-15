<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Main.aspx.cs" Inherits="WPSS.Main" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>xxx电子科技有限公司ERP网络平台</title>
 <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" /> 
<meta name ="Description" content ="ERP管理系统" />
<meta name ="keywords" content ="ERP管理系统,ERP管理软件,ERP,小微企业管理系统,希哲软件" />
    <link rel="Stylesheet" href="Css/S130424.css" type ="text/css" />
        <link rel="Stylesheet" href="Css/S131017.css" type ="text/css" />
</head>
<body  class ="c131010701"  onload ="onload1()">
<form runat ="server"  >
  <div>
      
<div  class="c13042401">
             <div class ="c13051001">
      <div class="c13052503" id ="Div2">
   <span class="c13052504" id ="Span1"><img src ="Image/logo_index.png" alt ="" /></span>
       </div>
       <div class="c13052906" id ="Div1">

       </div>
          <div class="c13052908" id ="Div3">
<img id="i13052801" src=""  alt=""  style =" display :none ; float :left ; margin-top :16px;"/>
          <span style =" margin-right :0px;"><asp:Label ID="L1" runat="server" ></asp:Label></span>
         <span style =" margin-left :10px;"><asp:Label ID="L2" runat="server" ></asp:Label></span>
         <span style =" margin-left :10px;"><asp:Label ID="L3" runat="server" ></asp:Label></span>
         <span  style =" margin-left :25px;">  <a href ="Default.aspx" target ="_top">
              <asp:LinkButton
             ID="LinkButton1" runat="server" onclick="LinkButton1_Click">退出</asp:LinkButton></a></span>
              
             </div>
         <div class="c13053001" id ="Div4"><img src ="Image/top.jpg" alt ="" />
   </div>
    </div> 
  <div id="13102901" class="c13102901" />
      <div class="c13051201" id="i13053105">
   <span class="c13051005" >    <asp:TreeView ID="TreeView1" runat="server" 
              Width="150px" >
     <NodeStyle   ChildNodesPadding="1px" 
            Height="24px" NodeSpacing="2px" width="95%"/>
        <LeafNodeStyle ChildNodesPadding="1px"/>
   </asp:TreeView></span>
       </div>
        <div class="c13051202" id ="i13053106">
<iframe   id="wk" name="ContentP" frameborder="0"  
        style="height: 100%; width :100% "  ></iframe>
    </div>
      </div>

  </div>
   <div style ="height:300px;width:100%"></div>
      <script type ="text/javascript" >
          window.onload = function onload1() {
              var Invocation = document.getElementById("wk");
              Invocation.target = "ContentP";
              Invocation.src = "xizheimg.aspx";
          }
          window.onunload = function onunload1() {
              document.getElementById("LinkButton1").click();

          }
        </script>
          </form> 
</body>

</html>