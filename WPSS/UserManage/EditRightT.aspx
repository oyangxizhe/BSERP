<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditRightT.aspx.cs" Inherits="WPSS.UserManage.EditRightT" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>编辑用户权限</title>
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
>编辑用户权限</div>
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
                <div class="c13101903" id ="Div1">
                    用户名</div>
       <div class="c13111106" id ="Div8">
 <input id="Text1" type="text"  runat ="server" class ="c13110901" /> 
        <span style =" margin-left :2px; margin-right :2px;"><a  href="javascript:f13100202('Text1','');">选择</a></span>
         <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="Text1" Text="必填的！" runat="server" />
       
         </div>
         <div class="c13111301" id ="Div34">
                        <span  style =" margin-left :30px"><asp:Label ID="Label1" runat="server" Text="" ></asp:Label></span>
                          </div>
           </div>
           <div id="i13103001" class ="c13111401">
               <div class="c13111402" id ="Div2">
  <asp:CheckBoxList ID="CheckBoxList1" runat="server" CssClass ="c14120314">
              <asp:ListItem>基础资料</asp:ListItem>
<asp:ListItem>员工信息维护</asp:ListItem>
<asp:ListItem>成品信息维护</asp:ListItem>
<asp:ListItem>半成品信息维护</asp:ListItem>
<asp:ListItem>原材料信息维护</asp:ListItem>
<asp:ListItem>单位信息维护</asp:ListItem>
<asp:ListItem>公司信息维护</asp:ListItem>
<asp:ListItem>收送地址维护</asp:ListItem>
<asp:ListItem>币别维护作业</asp:ListItem>
<asp:ListItem>BOM管理</asp:ListItem>
<asp:ListItem>BOM表建立</asp:ListItem>
<asp:ListItem>BOM替代料作业</asp:ListItem>
<asp:ListItem>发料阶段维护</asp:ListItem>

               </asp:CheckBoxList>
       </div>               <div class="c13111402" id ="Div3">
  <asp:CheckBoxList ID="CheckBoxList2" runat="server" CssClass ="c14120314">
<asp:ListItem>MRP管理</asp:ListItem>
<asp:ListItem>厂内订单作业</asp:ListItem>
<asp:ListItem>MRP分析</asp:ListItem>
<asp:ListItem>批次采购计划</asp:ListItem>

<asp:ListItem>工单管理</asp:ListItem>
<asp:ListItem>工单维护作业</asp:ListItem>
<asp:ListItem>工单成套领料作业</asp:ListItem>
<asp:ListItem>工单成套退料作业</asp:ListItem>
<asp:ListItem>工单完工入库作业</asp:ListItem>
<asp:ListItem>工单报废入库作业</asp:ListItem>
<asp:ListItem>工单物料报废入库</asp:ListItem>

<asp:ListItem>采购管理</asp:ListItem>
<asp:ListItem>供应商信息维护</asp:ListItem>

               </asp:CheckBoxList>
       </div>
                               <div class="c13111402" id ="Div4">
  <asp:CheckBoxList ID="CheckBoxList3" runat="server" CssClass ="c14120314">
               <asp:ListItem>录入采购核价单</asp:ListItem>
<asp:ListItem>录入采购单</asp:ListItem>
<asp:ListItem>录入采购入库单</asp:ListItem>
<asp:ListItem>录入退货单</asp:ListItem>
<asp:ListItem>采购查询</asp:ListItem>
<asp:ListItem>查询采购对帐单</asp:ListItem>
<asp:ListItem>销售管理</asp:ListItem>
<asp:ListItem>客户信息维护</asp:ListItem>
<asp:ListItem>录入销售核价单</asp:ListItem>
<asp:ListItem>录入客户订单</asp:ListItem>

<asp:ListItem>录入销货单</asp:ListItem>

               </asp:CheckBoxList>
       </div>
                       <div class="c13111402" id ="Div5">
  <asp:CheckBoxList ID="CheckBoxList4" runat="server" CssClass ="c14120314">
<asp:ListItem>录入销退单</asp:ListItem>
<asp:ListItem>订单查询</asp:ListItem>
<asp:ListItem>查询客户对帐单</asp:ListItem>
<asp:ListItem>库存管理</asp:ListItem>
<asp:ListItem>仓库信息维护</asp:ListItem>
<asp:ListItem>库位信息维护</asp:ListItem>
<asp:ListItem>杂项领料作业</asp:ListItem>
<asp:ListItem>杂项入库作业</asp:ListItem>
<asp:ListItem>库存状况查询</asp:ListItem>


<asp:ListItem>用户管理</asp:ListItem>
<asp:ListItem>用户帐户</asp:ListItem>
<asp:ListItem>更改密码</asp:ListItem>
<asp:ListItem>权限管理</asp:ListItem>
<asp:ListItem>审核权限设置</asp:ListItem>


               </asp:CheckBoxList>
       </div>
 <div class="c13111402" id ="Div18">
  <asp:CheckBoxList ID="CheckBoxList5" runat="server" CssClass ="c14120314">
<asp:ListItem>属性管理</asp:ListItem>
<asp:ListItem>原物料类别信息维护</asp:ListItem>
<asp:ListItem>品牌信息维护</asp:ListItem>


               </asp:CheckBoxList>
       </div>
    <div class="c13111402" id ="Div6">
  
                    <div class="c13111404" id ="Div7">
                    <asp:CheckBox ID="SelectAll" runat="server" oncheckedchanged="SelectAll_CheckedChanged" 
                    AutoPostBack="True" Text="全选"  CssClass ="c13111403" Width="44px" /></div>
                    <div class="c13111404" id ="Div16">
                    <asp:CheckBox ID="Inverse" runat="server" oncheckedchanged="Inverse_CheckedChanged"
                     AutoPostBack="True" Text="反选" CssClass ="c13111403" Width="44px" /></div>
   
       </div>
                                               <div class="c13111402" id ="Div17">

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
          }
          function f13100202(obj, obj1) {
              dlgResult = window.showModalDialog("../USERMANAGE/USERINFO.aspx", window, "dialogWidth:970px; dialogHeight:490px; status:0;");
              if (dlgResult != undefined) {

                  document.getElementById("Text1").value = dlgResult[0];
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