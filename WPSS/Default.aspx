<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WPSS._Default" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>xxx电子科技有限公司ERP网络平台</title>
 <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" /> 
<meta name ="Description" content ="ERP管理系统" />
<meta name ="keywords" content ="ERP管理系统,ERP管理软件,ERP,小微企业管理系统,希哲软件" />
  <link href ="Css/SSBase.css"  type ="text/css" rel ="Stylesheet" />
 
</head>
<body style="border-top:0px;margin-top:0px;">
    <form id=form1 runat=server>
    <input id="hint" type="hidden"  runat="server" />
        <div class=Default_top>
            <div style="display:inline;"><img src="Image/login.png" /></div>
        </div>
        <div style="height:360px;margin-top:40px; margin-bottom:0px;">
            <div style="width:45%; float:left; border-right:solid 1px #ccc; height:100%; text-align:right; padding-right:30px;">
                <br />
                <br />
                <img id="Img1" src="Image/logo.png" runat=server alt="xxx电子科技有限公司ERP网络平台" /><br />
          <div></div>
                      <div style=" color :#990033 "></div>
                <div style="height:36px; line-height:36px; display:none ;"><a href="" target=_blank>帮助</a></div>
            </div>
            <div style=" width:49%; float:right; ">
                
             
      
      
        <div style =" float :left ; width:97%; height :7%; margin-bottom :2%;  margin-left :3%;">登陆ERP MS管理系统</div>
      <div  class ="c14112101">
                       <div class="c14112102">用户名</div>
                       <div class="c14112103"> 
                           <input id="Text1" type="text" runat ="server" class ="c1312050201" /></div>
                       
                      <div id="i13102301" style =" color :Red ;  width:61%; height :7%"> <asp:Label ID="prompt" runat="server" ></asp:Label></div>
                     
                          </div>  
                            
                            
                            
                            
                            <div style =" float :left ; width:100%;margin-top :2%;">
                              <div class="c14112102">密码</div>
                      
                       <div class="c14112103">  
                           <input id="Text2" type="password"  runat ="server" class ="c1312050201"   onkeydown ="javascript:if(event.keyCode==13) login();"/></div>
                       
                      <div id="Div1" style =" color :Red ; margin-left :8.8%; width:61%; height :7%"> </div>
                      </div>
                      
                      
                       <div id="Div2" style =" float :left ;color :Red ; margin-left :11%; width:89%; margin-top :5%; height :7%"> 
                        <asp:ImageButton ID="btnLogin" runat="server" ImageUrl="~/Image/btnlogin4.png" 
                            onclick="btnLogin_Click" /></div>
                     
            </div>
     
        </div>
        <div class ="c1312050202" >
            软件支持 希哲软件  </div>
              <script type ="text/javascript" >
                  function login() {

                      document.getElementById("btnLogin").click();

                  }
                  function enter2tab(e) {
                      if (window.event.keyCode == 13) window.event.keyCode = 9
                  }
                  document.onkeydown = enter2tab;

                  window.onload = function onlaod1() {
                     
                      var Invocation = document.getElementById("hint").value;
                      if (Invocation != "") {
                          document.getElementById("i13102301").style.display = "block";
                          document.all("prompt").innerText = Invocation;
                      }
                      else {
                          document.getElementById("i13102301").style.display = "none";
                          document.getElementById("Text1").focus();
                      }

                  }
              </script>
    </form>
</body>
</html>
