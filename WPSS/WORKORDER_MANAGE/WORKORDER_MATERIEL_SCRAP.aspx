<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WORKORDER_MATERIEL_SCRAP.aspx.cs" Inherits="WPSS.WORKORDER_MANAGE.WORKORDER_MATERIEL_SCRAP" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>工单物料报废单</title>
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
          &gt;工单物料报废单</div>
     <div class="c13101907" id ="Div10">
 </div>
     </div>
        </div>
<div class ="c13110501">
   <div class="c13110502" id ="Div4">
   <span class="c13110508" id ="Span1">
       <asp:ImageButton ID="btnAdd" runat="server" ImageUrl="~/Image/btnAdd.png"    onclick="btnAdd_Click"  />
          </span>
       </div>
              <div class="c13110510" id ="Div7">
   <span class="c13110511" id ="Span11">
                  (新增)
          </span>
       </div>
       <div class="c13110504" id ="Div19">
<span id="i13052904"  class ="c13110505"  >
           搜索条件</span> </div>
          <div class="c13110506" id ="Div20">
          <div class ="c13110101">
                        <div class="c13110104" id ="Div5">
                                                        客户：</div>
     <div class="c14111903" id ="Div6">
            <input id="Text1" type="text"  runat ="server" class="c14062804" /></div>
                            <div class="c13110104" id ="Div1">
                                工单号
                            </div>
     <div class="c14111903" id ="Div14">
     <input id="Text4" type="text"  runat ="server" class="c14062804" />
                        </div>
           </div>
           <div class ="c13110105">
                        <div class="c13110104" id ="Div2">
                            <asp:CheckBox ID="CheckBox1" runat="server" 
                           />
                            日期期间：</div>
     <div class="c14111903" id ="Div8">
     <span style =" margin-right :8px;">
     <input id="StartDate" type="text" runat="server"   onclick ="f13100202('StartDate')" class="c14062804" />
   </span> </div>
          <div class="c13110104" id ="Div12">
                 <span style=" margin-right :33px;">～</span></div>
     <div class="c14111903" id ="Div13">
  <input id="EndDate" type="text" runat="server"  onclick ="f13100202('EndDate')" class="c14062804" /></div>
     
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
                            品名：</div>
     <div class="c14111903" id ="Div28">
            <input id="Text2" type="text"  runat ="server" class="c14062804" /></div>
                            <div class="c13110104" id ="Div29">
                                客户料号：</div>
     <div class="c14111903" id ="Div30">
     <input id="Text3" type="text"  runat ="server" class="c14062804" />
                            </div>
           </div>
           
</div>
    </div>
    <div class ="c13112601">
       <div class="c14031301" id ="Div24">
           &nbsp;</div>

          <div class="c13112603" id ="Div31">
          <div class ="c13110101">
                        <div class="c13110104" id ="Div32">
                            状态：</div>
     <div class="c14111903" id ="Div33">
           <asp:DropDownList  ID="DropDownList1" runat="server"   Height ="25px"  CssClass ="c13111101">
           <asp:ListItem></asp:ListItem>
              <asp:ListItem Value="已结案"></asp:ListItem>
               <asp:ListItem Value="部分入库"></asp:ListItem>
                  <asp:ListItem Value="Delay"></asp:ListItem>
               <asp:ListItem Value="Open"></asp:ListItem>
                <asp:ListItem Value="已作废"></asp:ListItem>
            </asp:DropDownList>
                        </div>
                            <div class="c13110104" id ="Div34">
                                领料单号
                              </div>
     <div class="c14111903" id ="Div35">
 <input id="Text5" type="text"  runat ="server" class="c14062804" />
                            </div>
           </div>
           
</div>
    </div> 
                      <div  id="i13102301" class ="c13102101">
<span  class ="c13102102"><asp:Label ID="prompt" runat="server"  ForeColor="#f80707"></asp:Label></span>
</div>
                      <div id="i14061401">
         
               <asp:GridView ID="GridView1" runat="server" 
                    AllowPaging="True" 
                    onpageindexchanging="GridView1_PageIndexChanging" 
                    onrowdeleting="GridView1_RowDeleting" 
                    AllowSorting="True"   
                    onrowdatabound="GridView1_RowDataBound" 
                        onselectedindexchanged="GridView1_SelectedIndexChanged" 
                        AutoGenerateColumns="False" style="margin-left: 8px" PageSize="15" 
                         CssClass ="c14061201"
                   
                   >
                   
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <Columns >
           
                    <asp:TemplateField HeaderText="删除" >
                <ItemTemplate >
                    <asp:LinkButton ID="LinkButton2" runat="server" 
                        OnClientClick="return confirm('您确认删除该记录吗?');" Text="删除"  CommandName ="delete" ></asp:LinkButton>                     
                </ItemTemplate>
                 <HeaderStyle Width="40px" />
                 <ItemStyle Width="40px"  />
            </asp:TemplateField>
             <asp:TemplateField HeaderText="物料报废单号">
                <ItemTemplate >
                    <asp:LinkButton ID="LinkButton1" runat="server" CommandName="Select" 
                        Text='<%# Bind("MSID") %>'></asp:LinkButton>                     
                </ItemTemplate>
                 <HeaderStyle Width="100px" />
                 <ItemStyle Width="100px"  ForeColor="#595d5a"/>
            </asp:TemplateField> 
                 <asp:BoundField DataField="WOID" HeaderText="工单号" >
                              <ItemStyle Width="100px" ForeColor="#595d5a" />
                                    <HeaderStyle HorizontalAlign="Center" Width="100px" />
                          </asp:BoundField>  
                           <asp:BoundField DataField="ID" HeaderText="ID" >
                              <ItemStyle Width="80px" ForeColor="#595d5a" />
                                    <HeaderStyle HorizontalAlign="Center" Width="80px" />
                          </asp:BoundField>
               <asp:BoundField DataField="CO_WAREID" HeaderText="厂内成品料号" >
                              <ItemStyle Width="150px" ForeColor="#595d5a" />
                                    <HeaderStyle HorizontalAlign="Center" Width="150px" />
                          </asp:BoundField>  
                           <asp:BoundField DataField="CWAREID" HeaderText="客户料号" >
                              <ItemStyle Width="100px" ForeColor="#595d5a" />
                                    <HeaderStyle HorizontalAlign="Center" Width="100px" />
                          </asp:BoundField>
                             <asp:BoundField DataField="WNAME" HeaderText="品名" >
                              <ItemStyle Width="130px" ForeColor="#595d5a" />
                                    <HeaderStyle HorizontalAlign="Center" Width="130px" />
                          </asp:BoundField>
                            <asp:BoundField DataField="WORKORDER_STATUS_MST" HeaderText="状态" >
                              <ItemStyle Width="60px" ForeColor="#595d5a" />
                                    <HeaderStyle HorizontalAlign="Center" Width="60px" />
                          </asp:BoundField>
                               <asp:BoundField DataField="MAKER" HeaderText="制单人" >
                              <ItemStyle Width="100px" ForeColor="#595d5a" />
                                    <HeaderStyle HorizontalAlign="Center" Width="100px" />
                          </asp:BoundField>
                              <asp:BoundField DataField="DATE" HeaderText="制单日期" >
                              <ItemStyle Width="120px" ForeColor="#595d5a" />
                                    <HeaderStyle HorizontalAlign="Center" Width="120px" />
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
            document.getElementById("i14061401").style.display = "block";

        }
        else {
            document.getElementById("i14031701").style.display = "none";
            document.getElementById("i14061401").style.display = "none";
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
