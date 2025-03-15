<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="REPLACE_MATERIEL.aspx.cs" Inherits="WPSS.BOM_MANAGE.REPLACE_MATERIEL" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>BOM替代料</title>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" /> 
<meta name ="Description" content ="ERP管理系统" />
<meta name ="keywords" content ="ERP管理系统,ERP管理软件,ERP,小微企业管理系统,希哲软件" />
   <link href ="../Css/SSBase.css"  type ="text/css" rel ="Stylesheet" />
      <link href ="../Css/S131017.css"  type ="text/css" rel ="Stylesheet" />
 <base target ="_self" /> 
    </head>
<body>  

    <form id="form1" runat="server">
           <input id="hint" type="hidden"  runat="server" />
        <input id="x" type="hidden"  runat="server" />
          <input id="x1" type="hidden"  runat="server" />
       <div >
                  <div class ="c13101905">
      <div class="c13101906" id ="Div9">
          &gt;BOM替代料</div>
     <div class="c13101907" id ="Div10">
 </div>
     </div>
        </div>
<div class ="c13110501">
 <div class="c13110502" id ="Div4">
   <span class="c13110508" id ="Span1">
       <asp:ImageButton ID="btnAdd" runat="server" ImageUrl="~/Image/btnAdd.png" 
              onclick="btnAdd_Click"  />
          </span>
       </div>
       <div class="c13110510" id ="Div7">
   <span class="c13110511" id ="Span3">
           (新增)           </span>
       </div>
       <div class="c13110504" id ="Div19">
<span id="i13052904"  class ="c13110505"  >
           搜索条件</span> </div>
          <div class="c13110506" id ="Div20">
          <div class ="c13110101">
                        <div class="c13110104" id ="Div5">
                                                       <asp:CheckBox ID="CheckBox1" runat="server" /> 客户：</div>
     <div class="c14111903" id ="Div6">
            <input id="Text1" type="text"  runat ="server" class="c14062804" /></div>
                            <div class="c13110104" id ="Div1">
                                替代编号
                            </div>
     <div class="c14111903" id ="Div14">
     <input id="Text2" type="text"  runat ="server" class="c13102103" />
                        </div>
           </div>
<div class ="c13110101">
                        <div class="c13110104" id ="Div2">
                                                        类别名称：</div>
     <div class="c14111903" id ="Div8">
            <input id="Text3" type="text"  runat ="server" class="c14062804" /></div>
                            <div class="c13110104" id ="Div11">
                                物料编码
                            </div>
     <div class="c14111903" id ="Div12">
     <input id="Text4" type="text"  runat ="server" class="c13102103" />
                        </div>
           </div>
</div>
         <div class="c13110507" id ="Div21">
                  <span class="c13110503" id ="Span2">
     <asp:ImageButton ID="btnSearch" 
                 runat="server" ImageUrl="~/Image/btnSearch.png" Width="60px" 
                      onclick="btnSearch_Click" />
          </span>
   </div>
          <div class="c13110510" id ="Div3">
   <span class="c13110505" id ="Span4">
              (搜索)
              </span>
       </div>
       <div class="c13110507" id ="Div16">
   </div>
    </div>
    
    
  
                      <div  id="i13102301" class ="c13102101">
<span  class ="c13102102"><asp:Label ID="prompt" runat="server"  ForeColor="#f80707"></asp:Label></span>
</div>

                      <div  id="i14072501">
         
               <asp:GridView ID="GridView1" runat="server" 
                    AllowPaging="True" 
                    onpageindexchanging="GridView1_PageIndexChanging" 
                    onrowdeleting="GridView1_RowDeleting" 
                    AllowSorting="True"   
                    onrowdatabound="GridView1_RowDataBound" 
                        onselectedindexchanged="GridView1_SelectedIndexChanged" 
                        AutoGenerateColumns="False" PageSize="15" 
                        CssClass ="c13122506"
                   
                   >
                   
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <Columns >
                    <asp:TemplateField HeaderText="选取">
                   <ItemTemplate>
         <a href ="javascript:f13100302('<%#Eval ("子ID") %>','<%#Eval ("子料号") %>','<%#Eval ("子品名") %>',
         '<%#Eval ("子客户料号") %>','<%#Eval ("子规格") %>','<%#Eval ("品牌") %>','<%#Eval ("组成用量") %>',
         '<%#Eval ("损耗量") %>','<%#Eval ("需求量") %>','<%#Eval ("MPA_TO_STOCK") %>','<%#Eval ("STOCK_TO_BOM") %>',
         '<%#Eval ("BOM单位") %>','<%#Eval ("库存单位") %>','<%#Eval ("客供否") %>',
         '<%#Eval ("发料阶段") %>')">
                       选取</a>
                   </ItemTemplate>
                            <HeaderStyle Width="40px" HorizontalAlign="Center" />
                 <ItemStyle Width="40px"  />
                   </asp:TemplateField>
                    <asp:TemplateField HeaderText="删除" >
                <ItemTemplate >
                    <asp:LinkButton ID="LinkButton2" runat="server" 
                        OnClientClick="return confirm('您确认删除该记录吗?');" Text="删除"  CommandName ="delete" ></asp:LinkButton>                     
                </ItemTemplate>
                 <HeaderStyle Width="40px" />
                 <ItemStyle Width="40px"  />
            </asp:TemplateField>
             <asp:TemplateField HeaderText="替代编号">
                <ItemTemplate >
                    <asp:LinkButton ID="LinkButton1" runat="server" CommandName="Select" 
                        Text='<%# Bind("替代编号") %>'></asp:LinkButton>                     
                </ItemTemplate>
                 <HeaderStyle Width="60px" />
                 <ItemStyle Width="60px"  ForeColor="#595d5a"/>
            </asp:TemplateField>
            <asp:BoundField DataField="ID" HeaderText="ID" >
                              <ItemStyle Width="80px" ForeColor="#595d5a" />
                                    <HeaderStyle HorizontalAlign="Center" Width="80px" />
                          </asp:BoundField>   
                          <asp:BoundField DataField="料号" HeaderText="原物料(半成品)编码" >
                              <ItemStyle Width="150px" ForeColor="#595d5a" />
                                    <HeaderStyle HorizontalAlign="Center" Width="150px" />
                          </asp:BoundField>
                             <asp:BoundField DataField="品名" HeaderText="物料类别(半成品)" >
                              <ItemStyle Width="150px" ForeColor="#595d5a" />
                                    <HeaderStyle HorizontalAlign="Center" Width="150px" />
                          </asp:BoundField>
                                <asp:BoundField DataField="规格" HeaderText="规格" >
                              <ItemStyle Width="200px" ForeColor="#595d5a" />
                                    <HeaderStyle HorizontalAlign="Center" Width="200px" />
                          </asp:BoundField>
                    <asp:BoundField DataField="子ID" HeaderText="替代料ID" >
                              <ItemStyle Width="80px" ForeColor="#595d5a" />
                                    <HeaderStyle HorizontalAlign="Center" Width="80px" />
                          </asp:BoundField> 
                           <asp:BoundField DataField="子料号" HeaderText="替代料物料编码" >
                              <ItemStyle Width="150px" ForeColor="#595d5a" />
                                    <HeaderStyle HorizontalAlign="Center" Width="150px" />
                          </asp:BoundField>
                         
                    </Columns>
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" Font-Bold="False" />   
                </asp:GridView>
                </div> 
<div id="i14031701" class ="c13102303">
          <span class="c13102304"><asp:Label ID="lblRecordCount" runat="server"></asp:Label></span>
          <span class="c13102304"><asp:Label ID="lblPageCount" runat="server"></asp:Label></span>
          <span class="c13102304"><asp:Label ID="lblCurrentIndex" runat="server"></asp:Label></span>
          <span class="c13102304"><asp:LinkButton ID="btnFirst" runat="server" CommandArgument="First" onclick="PageButton_Click">首页</asp:LinkButton></span>
          <span class="c13102304"><asp:LinkButton ID="btnPrev" runat="server" CommandArgument="Prev" onclick="PageButton_Click">上一页</asp:LinkButton></span>  
          <span class="c13102304"><asp:LinkButton ID="btnNext" runat="server" CommandArgument="Next" onclick="PageButton_Click">下一页</asp:LinkButton></span>
          <span class="c13102304"><asp:LinkButton ID="btnLast" runat="server" CommandArgument="Last" onclick="PageButton_Click">尾页</asp:LinkButton></span>
          <span class="c13102304"> 转到</span>
          <span class="c13102304"><asp:TextBox ID="txtNum" runat="server"  Width="73px"></asp:TextBox></span>
          <span class="c13102304"> 页</span>
          <span class="c13102304"> <asp:Button ID="btngo" runat="server"  Text="GO！"   style="width:45px" onclick="btngo_Click" /></span>
               
</div>
<script type="text/javascript" language="javascript">
    function f13100302(obj, obj1,obj2,obj3,obj4,obj5,obj6,obj7,obj8,obj9,obj10,obj11,obj12,obj13,obj14) {
        var arr1 = new Array();
        arr1[0] = obj;
        arr1[1] = obj1;
        arr1[2] = obj2;
        arr1[3] = obj3;
        arr1[4] = obj4;
        arr1[5] = obj5;
        arr1[6] = obj6;
        arr1[7] = obj7;
        arr1[8] = obj8;
        arr1[9] = obj9;
        arr1[10] = obj10;
        arr1[11] = obj11;
        arr1[12] = obj12;
        arr1[13] = obj13;
        arr1[14] = obj14;
        
        if (window.opener != undefined) {
            //for chrome
            window.opener.returnValue = arr1;
        }
        else {
            window.returnValue = arr1;
        }
        window.close();
    }
    window.onload = function onload1() {
    var Invocation = document.getElementById("hint").value;
    var Invocation1 = document.getElementById("x").value;
        if (Invocation != "") {
            document.getElementById("i13102301").style.display = "block";
            document.all("prompt").innerText = Invocation;
        }
        else {
            document.getElementById("i13102301").style.display = "none";
        }
        if (Invocation1 != "") {
            document.getElementById("i14031701").style.display = "block";
            document.getElementById("i14072501").style.display = "block";
        }
        else {
            document.getElementById("i14031701").style.display = "none";
            document.getElementById("i14072501").style.display = "none";

        }
    }
    function f13100202(obj) {
        var dlgResult;
        if (obj == "StartDate") {
            dlgResult = window.showModalDialog("../WDate.aspx", window, "dialogWidth:160px; dialogHeight:240px; status:0;");
            if (dlgResult != undefined) {


                document.getElementById("startdate").value = dlgResult;
            }

        }
        else {
            dlgResult = window.showModalDialog("../WDate.aspx", window, "dialogWidth:160px; dialogHeight:240px; status:0;");
            if (dlgResult != undefined) {


                document.getElementById("enddate").value = dlgResult;
            }


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
