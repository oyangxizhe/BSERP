<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserInfoT.aspx.cs" Inherits="WPSS.UserManage.UserInfoT" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>编辑用户信息</title>
<meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" /> 
<meta name ="Description" content ="进销存管理系统" />
<meta name ="keywords" content ="进销存管理系统,进销存管理软件,ERP,小微企业管理系统,希哲软件" />
       <link href ="../Css/SSBase.css"  type ="text/css" rel ="Stylesheet" />
       <link href ="../Css/S131017.css"  type ="text/css" rel ="Stylesheet" />
    <style type="text/css">
        #Text2
        {
            width: 100px;
        }
        #Text1
        {
            width: 100px;
        }
        #Text3
        {
            width: 100px;
        }
        #Text4
        {
            width: 100px;
        }
    </style>
    </head>
<body >
   <form id="form1" runat="server">
   <input id="hint" type="hidden"  runat="server" />
                <div class ="c13101905">
      <div class="c13101906" id ="Div9">
>编辑用户信息</div>
     <div class="c13101907" id ="Div10">
 </div>
    </div>
    <div class ="c13110501">
      <div class="c13110502" id ="Div14">
   <span class="c13110508" id ="Span1">
       <asp:ImageButton ID="btnAdd" runat="server" ImageUrl="~/Image/btnAdd.png"    onclick="btnAdd_Click"  />
          </span>
       </div>
              <div class="c13110510" id ="Div12">
   <span class="c13110511" id ="Span4">
                  (新增)
          </span>
       </div>
             <div class="c13110502" id ="Div11">
   <span class="c13110508" id ="Span3">
       <asp:ImageButton ID="btnSave" runat="server" ImageUrl="~/Image/btnSave.png" 
                     onclick="btnSave_Click"  />
          </span>
       </div>
              <div class="c13110510" id ="Div13">
   <span class="c13110511" id ="Span5">
(保存)
          </span>
       </div>
          
         <div class="c13110507" id ="Div21" >
                  <span class="c13110503" id ="Span2">
     <asp:ImageButton ID="btnExit" 
                 runat="server" ImageUrl="~/Image/btnExit.png" Width="60px" 
                      onclick="btnExit_Click" />
          </span>
   </div>
                 <div class="c13110510" id ="Div15" >
   <span class="c13110511" id ="Span6">
                     (退出)
          </span>
       </div>
    </div>
<div  id="i13102301" class ="c13102101">
<span  class ="c13102102"><asp:Label ID="prompt" runat="server"  ForeColor="#f80707"></asp:Label></span>
</div> 
  <div class ="c13101902">
      <div class="c13101903" id ="Div2">
          用户编号 </div>
     <div class="c13101904" id ="Div4">
<input id="Text1" type="text"  runat="server"   readonly ="readonly" class="c13102103" /> 
         <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="Text1" Text="必填的！" runat="server" /></div>
         <div class="c13101903" id ="Div5">
             用户名</div>
     <div class="c13101904" id ="Div6">
   <input id="Text2" type="text"  runat ="server" class ="c13110901" /> 
         <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="Text2" Text="必填的！" runat="server" /></div>
                <div class="c13101903" id ="Div1">
                    员工工号</div>
       <div class="c13111106" id ="Div8">
 <input id="Text3" type="text"  runat ="server" class ="c13110901" /> 
        <span style =" margin-left :2px; margin-right :2px;"><a  href="javascript:f13100202('Text4','');">选择</a></span>
         <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="Text3" Text="必填的！" runat="server" />
       
         </div>
         <div class="c13111301" id ="Div34">
                        <span  style =" margin-left :30px"><asp:Label ID="Label1" runat="server" Text="" ></asp:Label></span>
                          </div>
           </div>
             <div class ="c13101902">
      <div class="c13101903" id ="Div7">
   密码</div>
     <div class="c13101904" id ="Div3">
   <input id="Text4" type="password" runat ="server"  class ="c13110901" /> 
</div>
           </div>
      <script type ="text/javascript" >
          window.onload = function onload1() {
              var Invocation = document.getElementById("hint").value;
              if (Invocation != "") {
                  document.getElementById("i13102301").style.display = "block";
                  document.all("prompt").innerText = Invocation;
              }
              else {
                  document.getElementById("i13102301").style.display = "none";
              }
              document.getElementById("Text2").focus();
          }
          function f13100202(obj, obj1) {
              dlgResult = window.showModalDialog("../BaseInfo/EMPLOYEEINFO.aspx", window, "dialogWidth:970px; dialogHeight:490px; status:0;");
              if (dlgResult != undefined) {

                  document.getElementById("Text3").value = dlgResult[0];
                  document.all("Label1").innerText = dlgResult[1];
              }


              }

          
          function enter2tab(e) {
              if (window.event.keyCode == 13) window.event.keyCode = 9
          }
          document.onkeydown = enter2tab;
          
        </script>

    </form>
</body>
</html>