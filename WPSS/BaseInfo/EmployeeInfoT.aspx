<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EmployeeInfoT.aspx.cs" Inherits="WPSS.BaseInfo.EmployeeInfoT" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>编辑员工信息</title>
<meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" /> 
<meta name ="Description" content ="进销存管理系统" />
<meta name ="keywords" content ="进销存管理系统,进销存管理软件,ERP,小微企业管理系统,希哲软件" />
       <link href ="../Css/SSBase.css"  type ="text/css" rel ="Stylesheet" />
       <link href ="../Css/S131017.css"  type ="text/css" rel ="Stylesheet" />

    </head>
<body >
   <form id="form1" runat="server">
   <input id="hint" type="hidden"  runat="server" />
                  <div class ="c13101905">
      <div class="c13101906" id ="Div9">
          &gt;编辑员工信息维护 </div>
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
          
         <div class="c13110507" id ="Div21">
                  <span class="c13110503" id ="Span2">
     <asp:ImageButton ID="btnExit" 
                 runat="server" ImageUrl="~/Image/btnExit.png" Width="60px" 
                      onclick="btnExit_Click" />
          </span>
   </div>
                 <div class="c13110510" id ="Div15">
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
   员工编号 </div>
     <div class="c13101904" id ="Div4">
<input id="Text1" type="text"  runat="server"   readonly ="readonly" class="c13102103" /> 
         <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="Text1" Text="必填" runat="server" /></div>
         <div class="c13101903" id ="Div5">
             姓名</div>
     <div class="c13101904" id ="Div6">
   <input id="Text2" type="text"  runat ="server" class ="c13110901" /> 
         <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="Text2" Text="必填" runat="server" /></div>
                <div class="c13101903" id ="Div1">
                    部门</div>
     <div class="c13101904" id ="Div3">
                  <asp:DropDownList ID="DropDownList1" runat="server"  CssClass ="c13102104">
                          <asp:ListItem></asp:ListItem>
                          <asp:ListItem>经理室</asp:ListItem>
                         <asp:ListItem>业务部</asp:ListItem>
                         <asp:ListItem>财务部财务科</asp:ListItem>
                         <asp:ListItem>财务部信息科</asp:ListItem>
                         <asp:ListItem>物流部生管科</asp:ListItem>
                         <asp:ListItem>物流部采购科</asp:ListItem>
                         <asp:ListItem>物流部资材科</asp:ListItem>
                         <asp:ListItem>工程部</asp:ListItem>
                         <asp:ListItem>品保部</asp:ListItem>
                         <asp:ListItem>生技部设备科</asp:ListItem>
                         <asp:ListItem>生技部生技科</asp:ListItem>
                         <asp:ListItem>管理部人事科</asp:ListItem>
                         <asp:ListItem>管理部总务科</asp:ListItem>
                         <asp:ListItem>体系科</asp:ListItem>
                         <asp:ListItem>生产部</asp:ListItem>
                          <asp:ListItem>驾驭员</asp:ListItem>
                          <asp:ListItem>保安部</asp:ListItem>
                    </asp:DropDownList>
    </div>
        <div class="c13101903" id ="Div7">
   职务 </div>
     <div class="c14120501" id ="Div8">
     <span style =" margin-right :8px;">
   <asp:DropDownList ID="DropDownList2" runat="server" class="c13102104">
                                 <asp:ListItem ></asp:ListItem>
                    <asp:ListItem>职员</asp:ListItem>
                                    <asp:ListItem>主管(科长)</asp:ListItem>
                                    <asp:ListItem>课长(部长)</asp:ListItem>
                                    <asp:ListItem>经理</asp:ListItem>
                                    <asp:ListItem>副总经理</asp:ListItem>
                                    <asp:ListItem>总经理</asp:ListItem>
                                     <asp:ListItem>特助</asp:ListItem>
                                    <asp:ListItem>董事长</asp:ListItem>
                    </asp:DropDownList></span> </div>
           </div>
             <div class ="c13101902">
  
                     <div class="c13101903" id ="Div16">
            电话</div>
     <div class="c13101904" id ="Div17">
   <input id="Text3" type="text"  runat ="server" class ="c13110901" /> 
         <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="Text3" Text="必填" runat="server" /></div>
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
          }
          function enter2tab(e) {
              if (window.event.keyCode == 13) window.event.keyCode = 9
          }
          document.onkeydown = enter2tab;
          
        </script>

    </form>
</body>
</html>