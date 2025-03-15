<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OFFERSEARCH.aspx.cs" Inherits="WPSS.SellManage.OFFERSEARCH" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>报价单查询</title>
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
          &gt;报价单查询</div>
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
     <div class="c13110103" id ="Div6">
            <input id="Text1" type="text"  runat ="server" class="c13102103" /></div>
                            <div class="c13110104" id ="Div1s">
                                报价单号
                            </div>
     <div class="c13110103" id ="Div14">
     <input id="Text4" type="text"  runat ="server" class="c13102103" />
                        </div>
           </div>
           <div class ="c13110105">
                        <div class="c13110104" id ="Div2">
                            <asp:CheckBox ID="CheckBox1" runat="server" 
                             />
                            日期期间：</div>
     <div class="c13110103" id ="Div8">
     <span style =" margin-right :8px;">
     <input id="StartDate" type="text" runat="server"   onclick ="f13100202('StartDate')" class ="c13102103" />
   </span> </div>
          <div class="c13110104" id ="Div12">
                 <span style=" margin-right :33px;">～</span></div>
     <div class="c13110103" id ="Div13">
  <input id="EndDate" type="text" runat="server"  onclick ="f13100202('EndDate')" class ="c13102103" /></div>
     
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
     <div class="c13110103" id ="Div28">
            <input id="Text2" type="text"  runat ="server" class="c13102103" /></div>
                            <div class="c13110104" id ="Div29">
                                客户料号：</div>
     <div class="c13110103" id ="Div30">
     <input id="Text3" type="text"  runat ="server" class="c13102103" />
                            </div>
           </div>
           
</div>
    </div>
    <div class ="c13112601">
       <div class="c14031301" id ="Div11">
           &nbsp;</div>

          <div class="c13112603" id ="Div112">
          <div class ="c13110101">
                        <div class="c13110104" id ="Div17">
                            </div>
     <div class="c13110103" id ="Div18">
                        </div>
                            <div class="c13110104" id ="Div22">
                              </div>
     <div class="c13110103" id ="Div23">

                            </div>
           </div>
           
</div>
    </div>
  
                      <div  id="i13102301" class ="c13102101">
<span  class ="c13102102"><asp:Label ID="prompt" runat="server"  ForeColor="#f80707"></asp:Label></span>
</div>
             <div id="i13103001" class ="c13111201">
          
                    <asp:GridView ID="GridView1" runat="server"  CssClass ="c14040801 " 
                       onrowdatabound="GridView1_RowDataBound"  >
                         <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    </asp:GridView>
                </div>
                      <div id="i13111201" class ="c13101902" style="display:none ">
                                 <div class="c13102907" id ="Div15">
                                 </div>
      <div class="c13101903" id ="Div31">
          合计未税金额</div>
     <div class="c13101904" id ="Div32">
        <input id="Text7" type="text"  runat="server"    class="c13102908"/></div>
          <div class="c13101903" id ="Div33">
              合计税额</div>
     <div class="c13101904" id ="Div34">
   <input id="Text8" type="text"  runat ="server" class="c13102908" /> 
         </div>
                  <div class="c13101903" id ="Div35">
                      合计含税金额</div>
     <div class="c13101904" id ="Div36">
   <input id="Text9" type="text"  runat ="server" class ="c13102908"  /> 
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
          <span class="c13102304"> 转到<asp:TextBox ID="txtNum" runat="server"  Width="73px"></asp:TextBox></span><span class="c13102304">页</span>
          <span class="c13102304"> <asp:Button ID="btngo" runat="server"  Text="GO！"   style="width:45px" onclick="btngo_Click" /></span>
               
</div>
<script type="text/javascript" language="javascript">
    function f13100302(result) {
        if (window.opener != undefined) {
            //for chrome
            window.opener.returnValue = result;
        }
        else {
            window.returnValue = result;
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
            document.getElementById("i13103001").style.display = "block";

        }
        else {
            document.getElementById("i14031701").style.display = "none";
            document.getElementById("i13103001").style.display = "none";
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
        else if (obj == "EndDate") {
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
