<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WareInfo.aspx.cs" Inherits="WPSS.BaseInfo.WareInfo" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>品号信息维护</title>
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
          &gt;品号信息维护</div>
     <div class="c13101907" id ="Div10">
 </div>
     </div>
        </div>
<div class ="c13110501">
 <div class="c13110502" id ="Div4">
       </div>
       <div class="c13110510" id ="Div7">
   <span class="c13110511" id ="Span3">
         
          </span>
       </div>
       <div class="c13110504" id ="Div19">
<span id="i13052904"  class ="c13110505"  >
           搜索条件</span> </div>
          <div class="c13110506" id ="Div20">
          <div class ="c13110101">
                        <div class="c13110104" id ="Div5">
                                                        料号(物料编码)：</div>
     <div class="c13110103" id ="Div6">
            <input id="Text1" type="text"  runat ="server" class="c14062804" /></div>
                            <div class="c13110104" id ="Div1">
                                品名(类别)                         </div>
     <div class="c13110103" id ="Div14">
     <input id="Text2" type="text"  runat ="server" class="c14062804" />
                        </div>
           </div>
           <div class ="c13110105">
                        <div class="c13110104" id ="Div2">
                            
                            规格：</div>
     <div class="c13110103" id ="Div8">
     <span style =" margin-right :8px;">
     <input id="Text3" type="text" runat="server"   class="c14062804"  />
   </span> </div>
          <div class="c13110104" id ="Div11">
                              <asp:CheckBox ID="CheckBox1" runat="server" 
                              />  品牌                          </div>
     <div class="c13110103" id ="Div13">
  <input id="Text4" type="text"  runat ="server" class="c14062804" /></div>
     
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
    <div class ="c13112601">
       <div class="c14031301" id ="Div12">
           &nbsp;</div>

          <div class="c13112603" id ="Div15">
          <div class ="c13110101">
                        <div class="c13110104" id ="Div17">
                            客户(供应商)：</div>
     <div class="c13110103" id ="Div18">
            <input id="Text5" type="text"  runat ="server" class="c14062804" /></div>
                            <div class="c13110104" id ="Div22">
                                客户料号(原厂)：</div>
  <div class="c13110103" id ="Div28">
            <input id="Text6" type="text"  runat ="server" class="c14062804" /></div>
           </div>
           
</div>
    </div>
<div class ="c13112601">
       <div class="c14031301" id ="Div23">
           &nbsp;</div>

          <div class="c13112603" id ="Div24">
          <div class ="c13110101">
                        <div class="c13110104" id ="Div25">
                            状态：</div>
     <div class="c13110103" id ="Div26">
             <asp:DropDownList  ID="DropDownList1" runat="server"    Height ="25px"  CssClass ="c13111101 ">
      <asp:ListItem></asp:ListItem>
             <asp:ListItem  Selected="True">正常</asp:ListItem>
              <asp:ListItem >Hold</asp:ListItem>
               <asp:ListItem >作废</asp:ListItem>
                  <asp:ListItem>全部</asp:ListItem>
            </asp:DropDownList></div>
                            <div class="c13110104" id ="Div27">
                                ID：</div>
  <div class="c13110103" id ="Div29">
            <input id="Text7" type="text"  runat ="server" class="c14062804" /></div>
           </div>
           
</div>
    </div>
                     <div  id="i13102301" class ="c13102101">
<span  class ="c13102102"><asp:Label ID="prompt" runat="server"  ForeColor="#f80707"></asp:Label></span>
</div>

                <div  >
         
               <asp:GridView ID="GridView1" runat="server" 
                    AllowPaging="True" 
                    onpageindexchanging="GridView1_PageIndexChanging" 
                    onrowdeleting="GridView1_RowDeleting" 
                    AllowSorting="True"   
                    onrowdatabound="GridView1_RowDataBound" 
                        onselectedindexchanged="GridView1_SelectedIndexChanged" 
                        AutoGenerateColumns="False"  PageSize="15" 
                         CssClass ="c13122506"
                   
                   >
                   
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <Columns >
                    <asp:TemplateField HeaderText="选取">
                   <ItemTemplate>
         <a href ="javascript:f13100302('<%#Eval ("Wareid") %>','<%#Eval ("CO_WAREID") %>','<%#Eval ("WNAME") %>',
     '<%#Eval ("CWAREID") %>','<%#Eval ("CNAME") %>','<%#Eval ("SELLUNITPRICE") %>','<%#Eval ("SPEC") %>',
     '<%#Eval ("REMARK") %>','<%#Eval ("BOM_UNIT") %>','<%#Eval ("PURCHASEUNITPRICE") %>','<%#Eval ("MPA_UNIT") %>',
     '<%#Eval ("BRAND") %>','<%#Eval ("SKU") %>','<%#Eval ("CURRENCY") %>','<%#Eval ("STORAGENAME") %>',
     '<%#Eval ("STORAGE_LOCATION") %>','<%#Eval ("BATCHID") %>','<%#Eval ("MAX_STORAGE_COUNT") %>')">
                       选取</a>
                   </ItemTemplate>
                            <HeaderStyle Width="4%" HorizontalAlign="Center" />
                 <ItemStyle Width="4%"  />
                   </asp:TemplateField>
                  <asp:TemplateField HeaderText="删除" >
                <ItemTemplate >
                    <asp:LinkButton ID="LinkButton2" runat="server" 
                        OnClientClick="return confirm('您确认删除该记录吗?');" Text="删除"  CommandName ="delete" ></asp:LinkButton>                     
                </ItemTemplate>
                 <HeaderStyle Width="4%" />
                 <ItemStyle Width="4%"  />
            </asp:TemplateField>
             <asp:TemplateField HeaderText="ID">
                <ItemTemplate >
                    <asp:LinkButton ID="LinkButton1" runat="server" CommandName="Select" 
                        Text='<%# Bind("WAREID") %>'></asp:LinkButton>                     
                </ItemTemplate>
                 <HeaderStyle Width="4%" />
                 <ItemStyle Width="4%"/>
            </asp:TemplateField>   
             <asp:BoundField DataField="CO_WAREID" HeaderText="物料编码" >
                              <ItemStyle CssClass ="c14072705" />
                                    <HeaderStyle HorizontalAlign="Center" />
                          </asp:BoundField>
                          <asp:BoundField DataField="WNAME" HeaderText="类别名称" >
                              <ItemStyle  CssClass="c14072702"  />
                                    <HeaderStyle HorizontalAlign="Center" />
                          </asp:BoundField>
                         
                      
                    <asp:BoundField DataField="SPEC" HeaderText="规格" >
                              <ItemStyle CssClass="c14072901"  />
                                    <HeaderStyle HorizontalAlign="Center" />
                          </asp:BoundField>
                          <asp:BoundField DataField="BRAND" HeaderText="品牌" >
                              <ItemStyle  CssClass ="c14072902" />
                                    <HeaderStyle HorizontalAlign="Center"  />
                          </asp:BoundField>
                           <asp:BoundField DataField="CWAREID" HeaderText="物料料号" >
                              <ItemStyle CssClass="c14072704" />
                                    <HeaderStyle HorizontalAlign="Center"  />
                          </asp:BoundField>
                           <asp:BoundField DataField="ACTIVE" HeaderText="状态" >
                              <ItemStyle CssClass="c14072704"  />
                                    <HeaderStyle HorizontalAlign="Center"  />
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
          <span class="c13102304"> 转到<asp:TextBox ID="txtNum" runat="server"  Width="73px"></asp:TextBox></span><span class="c13102304">页</span>
          <span class="c13102304"> <asp:Button ID="btngo" runat="server"  Text="GO！"   style="width:45px" onclick="btngo_Click" /></span>
               
</div>
<script type="text/javascript" language="javascript">
    var arr1 = new Array();
    var arr2 = new Array();
    function f13100302(obj, obj1, obj2, obj3,obj4,obj5,obj6,obj7,obj8,obj9,obj10,obj11,obj12,obj13,obj14,obj15,obj16,obj17) {
        var objw = window.dialogArguments;
        onload1();
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
        arr1[15] = obj15;
        arr1[16] = obj16;
        arr1[17] =obj17;
        if (window.opener != undefined) {
            //for chrome
            window.opener.returnValue = arr1;
        }
        else {
            window.returnValue = arr1;
        }
        window.close();

    }
    function onSuccess(value, context) {
        arr2 = value;
    }
    function onFail(value) {
        alert(value);
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

        }
        else {
            document.getElementById("i14031701").style.display = "none";

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
