<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StorageInfoT.aspx.cs" Inherits="WPSS.StockManage.StorageInfoT" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>编辑仓库信息</title>
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
          &gt;编辑仓库信息 </div>
     <div class="c13101907" id ="Div10">
 </div>
    </div>
  <div class ="c13110501">
      <div class="c13110502" id ="Div1">
   <span class="c13110508" id ="Span1">
       <asp:ImageButton ID="btnAdd" runat="server" ImageUrl="~/Image/btnAdd.png"    onclick="btnAdd_Click"  />
          </span>
       </div>
              <div class="c13110510" id ="Div3">
   <span class="c13110511" id ="Span4">
                  (新增)
          </span>
       </div>
             <div class="c13110502" id ="Div18">
   <span class="c13110508" id ="Span3">
       <asp:ImageButton ID="btnSave" runat="server" ImageUrl="~/Image/btnSave.png" 
                     onclick="btnSave_Click"  />
          </span>
       </div>
              <div class="c13110510" id ="Div19">
   <span class="c13110511" id ="Span5">
                  (保存)
          </span>
       </div>
          
         <div class="c13110507" id ="Div22">
                  <span class="c13110503" id ="Span2">
     <asp:ImageButton ID="btnExit" 
                 runat="server" ImageUrl="~/Image/btnExit.png" Width="60px" 
                      onclick="btnExit_Click" />
          </span>
   </div>
                 <div class="c13110510" id ="Div24">
   <span class="c13110511" id ="Span6">
                     (退出)
          </span>
       </div>
    </div>

<div  id="i13102301" class ="c13102101">
<span  class ="c13102102"><asp:Label ID="prompt" runat="server"  ForeColor="#f80707"></asp:Label></span>
</div> 
<div class ="c14060302">
                  (选择 "Y" 或者 "N" 来设置默认入库仓库)
           </div>
  <div class ="c13101902">
      <div class="c13101903"  id ="Div2">
          仓库代码</div>
     <div class="c14031403" id ="Div4"> <span style =" margin-right :8px;">
<input id="Text1" type="text"  runat="server"   readonly ="readonly" class="c14031401"/> 
         <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="Text1" Text="必填" runat="server" /></span></div>
         <div class="c13101903" id ="Div5">
             仓库名称</div>
     <div class="c14031403" id ="Div6">
     <input id="Text2" type="text"  runat ="server"  class="c14033101"  />
    </div>
                          <div class="c14120403"  id ="Div7" >
                              MRP有效否</div>
<div class="c14031403"  id ="Div8">
                      <span style =" margin-right :8px;">
                      <asp:DropDownList ID="DropDownList1" runat="server" CssClass="c14120402">
                        <asp:ListItem></asp:ListItem>
                         <asp:ListItem>Y</asp:ListItem>
                         <asp:ListItem>N</asp:ListItem>
                      </asp:DropDownList>
                       <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="DropDownList1" Text="必填" runat="server" />
                      </span>
                  </div>
                                            <div class="c13101903"  id ="Div11" >
                              采购入库</div>
<div class="c14071802" id ="Div12">
                      <span style =" margin-right :8px;">
                      <asp:DropDownList ID="DropDownList2" runat="server" CssClass="c14120402">
                        <asp:ListItem>N</asp:ListItem>
                         <asp:ListItem>Y</asp:ListItem>
                      </asp:DropDownList>
               
                      </span>
                  </div>
           </div>
            <div class ="c13101902">

                          <div class="c13101903" id ="Div17" >
                              工单入库</div>
<div class="c14031403" id ="Div20">
                      <span style =" margin-right :8px;">
                      <asp:DropDownList ID="DropDownList3" runat="server" CssClass="c14120402">
                        <asp:ListItem>N</asp:ListItem>
                         <asp:ListItem>Y</asp:ListItem>
                      </asp:DropDownList>
                       <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ControlToValidate="DropDownList3" Text="必填" runat="server" />
                      </span>
                  </div>
                                            <div class="c13101903" id ="Div21" >
                              工单报废</div>
<div class="c14031403" id ="Div23">
                      <span style =" margin-right :8px;">
                      <asp:DropDownList ID="DropDownList4" runat="server" CssClass="c14120402">
                        <asp:ListItem>N</asp:ListItem>
                         <asp:ListItem>Y</asp:ListItem>
                      </asp:DropDownList>
                       <asp:RequiredFieldValidator ID="RequiredFieldValidator6" ControlToValidate="DropDownList4" Text="必填" runat="server" />
                      </span>
                  </div>
                                                           <div class="c14120403"  id ="Div13" >
                              工单物料报废</div>
<div class="c14031403"  id ="Div14">
                      <span style =" margin-right :8px;">
                      <asp:DropDownList ID="DropDownList5" runat="server" CssClass="c14120402">
                        <asp:ListItem>N</asp:ListItem>
                         <asp:ListItem>Y</asp:ListItem>
                      </asp:DropDownList>
                       <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ControlToValidate="DropDownList5" Text="必填" runat="server" />
                      </span>
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
          function enter2tab(e) {
              if (window.event.keyCode == 13) window.event.keyCode = 9
          }
          document.onkeydown = enter2tab;
        </script>

    </form>
</body>
</html>