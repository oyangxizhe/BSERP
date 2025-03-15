<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StorageCase.aspx.cs" Inherits="WPSS.StockManage.StorageCase" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>查询库存</title>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" /> 
<meta name ="Description" content ="进销存管理系统" />
<meta name ="keywords" content ="进销存管理系统,进销存管理软件,ERP,小微企业管理系统,希哲软件" />
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
          &gt;查询库存情况</div>
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
                                                        客户名称：</div>
     <div class="c14111903" id ="Div6">
            <input id="Text1" type="text"  runat ="server" class="c14111902" /></div>
                            <div class="c13110104" id ="Div1">
                                客户料号：
                                </div>
     <div class="c14111903" id ="Div14">
                         <input id="Text2" type="text"  runat ="server" class="c14111902" /></div>
           </div>
           <div class ="c13110105">
                        <div class="c13110104" id ="Div2">
                            品名(物料类别)：</div>
     <div class="c14111903" id ="Div8">
   <input id="Text3" type="text"  runat ="server" class="c14111902" /></div>
          <div class="c13110104" id ="Div12">
              仓库：</div>
     <div class="c14111903" id ="Div13">
       <input id="Text4" type="text"  runat ="server" class="c14111902" />
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
    <div class ="c13112601">
       <div class="c14031301" id ="Div25">
           &nbsp;</div>

          <div class="c13112603" id ="Div26">
          <div class ="c13110101">
                        <div class="c13110104" id ="Div27">
                              库位：</div>
     <div class="c14111903" id ="Div28">
          <input id="Text5" type="text"  runat ="server" class="c14111902" />

          </div>
                            <div class="c13110104" id ="Div29">
                                批号：</div>
     <div class="c14111903" id ="Div30">
<input id="Text6" type="text"  runat ="server" class="c14111902" />
                 
                            </div>
           </div>
           
</div>
    </div>
                      <div  id="i13102301" class ="c13102101">
<span  class ="c13102102"><asp:Label ID="prompt" runat="server"  ForeColor="#f80707"></asp:Label></span>
</div>

             <div id="i13103001" class ="c14070502">
          
                    
               <asp:GridView ID="GridView1" runat="server" Width="98%" 
                    AllowPaging="True" 
                    AllowSorting="True"   
                    onrowdatabound="GridView1_RowDataBound" 
               AutoGenerateColumns="False" style="margin-left: 0px" PageSize="15" 
                         CssClass ="c13111501" onpageindexchanging="GridView1_PageIndexChanging"
                   
                   >
                   
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <Columns >
                    <asp:TemplateField HeaderText="选取">
                   <ItemTemplate>
         <a href ="javascript:f13100302('<%#Eval ("仓库") %>','<%#Eval ("库位") %>','<%#Eval ("批号") %>','<%#Eval ("库存数量") %>')">
                       选取</a>
                   </ItemTemplate>
                            <HeaderStyle Width="40px" HorizontalAlign="Center" />
                 <ItemStyle Width="40px"  />
                   </asp:TemplateField>
                          <asp:BoundField DataField="品号" HeaderText="ID" >
                              <ItemStyle Width="80px" ForeColor="#595d5a" />
                                    <HeaderStyle HorizontalAlign="Center" Width="80px" />
                          </asp:BoundField>
                          <asp:BoundField DataField="料号" HeaderText="厂内成品料号" >
                              <ItemStyle Width="120px" ForeColor="#595d5a" />
                                    <HeaderStyle HorizontalAlign="Center" />
                          </asp:BoundField>
                         
                          <asp:BoundField DataField="品名" HeaderText="品名" >
                              <ItemStyle  CssClass ="c14071001"  />
                                    <HeaderStyle HorizontalAlign="Center" />
                          </asp:BoundField>
                    <asp:BoundField DataField="客户料号" HeaderText="客户料号" >
                              <ItemStyle Width="80px" ForeColor="#595d5a" />
                                    <HeaderStyle HorizontalAlign="Center" Width="80px" />
                          </asp:BoundField>
                          <asp:BoundField DataField="仓库" HeaderText="仓库" 
                           >
                               <HeaderStyle HorizontalAlign="Center" Width="80px" />
                              <ItemStyle Width="80px"  ForeColor="#595d5a"/>
                          </asp:BoundField> 
                               <asp:BoundField DataField="库位" HeaderText="库位" 
                           >
                               <HeaderStyle HorizontalAlign="Center" Width="60px" />
                              <ItemStyle Width="60px"  ForeColor="#595d5a"/>
                          </asp:BoundField> 
                                 <asp:BoundField DataField="批号" HeaderText="批号" >
                              <ItemStyle Width="80px"  ForeColor="#595d5a"/>
                                    <HeaderStyle HorizontalAlign="Center" Width="80px" />
                          </asp:BoundField>
                          <asp:BoundField DataField="库存数量" HeaderText="库存数量" 
                           >
                               <HeaderStyle HorizontalAlign="Right" Width="60px" />
                              <ItemStyle Width="60px"  ForeColor="#595d5a"  HorizontalAlign="Right"/>
                          </asp:BoundField> 
                                    <asp:BoundField DataField="库存单位" HeaderText="库存单位" >
                              <ItemStyle Width="80px"  ForeColor="#595d5a"/>
                                    <HeaderStyle HorizontalAlign="Center" Width="80px" />
                          </asp:BoundField>
                    <asp:BoundField DataField="库存金额" HeaderText="库存金额" >
                              <ItemStyle Width="80px"  ForeColor="#595d5a"/>
                                    <HeaderStyle HorizontalAlign="Center" Width="80px" />
                          </asp:BoundField>
                    </Columns>
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" Font-Bold="False" />   
                </asp:GridView>
              
                </div>
                <div id="i13111201" class ="c13101902">
                                      <div class="c13102907" id ="Div11">
                                 </div>
      <div class="c14112014" id ="Div15">
         </div>
     <div class="c13101904" id ="Div17">
      </div>
          <div class="c14112014" id ="Div18">
               合计库存金额</div>
     <div class="c13101904" id ="Div22">
   <input id="Text8" type="text"  runat ="server" class="c13102908" /> 
         </div>
                  <div class="c14112014" id ="Div23">
                    </div>
     <div class="c13101904" id ="Div24">

         </div>
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
    function f13100302(obj, obj1,obj2,obj3) {

        var arr1 = new Array();
        arr1[0] = obj;
        arr1[1] = obj1;
        arr1[2] = obj2;
        arr1[3] = obj3;
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
    var Invocation2 = document.getElementById("x1").value;
        if (Invocation != "") {
            document.getElementById("i13102301").style.display = "block";
            document.all("prompt").innerText = Invocation;
        }
        else {
            document.getElementById("i13102301").style.display = "none";
        }
  
        if (Invocation1 != "") {
            document.getElementById("i14031701").style.display = "block";
            document.getElementById("i13111201").style.display = "block";
        }
        else {
            document.getElementById("i14031701").style.display = "none";
            document.getElementById("i13111201").style.display = "none";
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
        else if(obj=="EndDate") {
            dlgResult = window.showModalDialog("../WDate.aspx", window, "dialogWidth:160px; dialogHeight:240px; status:0;");
            if (dlgResult != undefined) {


                document.getElementById("enddate").value = dlgResult;
            }
            }
            else if (obj == "Text1") {
         
                dlgResult = window.showModalDialog("../PurchaseManage/Supplierinfo.aspx", window, "dialogWidth:960px; dialogHeight:480px; status:0");
                if (dlgResult != undefined) {

                    //document.getElementById("Text2").value = dlgResult[0];
                    document.getElementById("Text1").value = dlgResult[1];
                    //document.getElementById("Text6").value = dlgResult[2];
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
