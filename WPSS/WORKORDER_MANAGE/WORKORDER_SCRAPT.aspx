<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WORKORDER_SCRAPT.aspx.cs" Inherits="WPSS.WORKORDER_MANAGE.WORKORDER_SCRAPT" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>编辑工单报废入库信息</title>
<meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" /> 
<meta name ="Description" content ="ERP管理系统" />
<meta name ="keywords" content ="ERP管理系统,ERP管理软件,ERP,小微企业管理系统,希哲软件" />
       <link href ="../Css/SSBase.css"  type ="text/css" rel ="Stylesheet" />
       <link href ="../Css/S131017.css"  type ="text/css" rel ="Stylesheet" />

    </head>
<body >
   <form id="form1" runat="server">
   <input id="cuid" type="hidden"  runat="server" />
   <input id="suid" type="hidden"  runat="server" />
   <input id="hint" type="hidden"  runat="server" />
      <input id="x" type="hidden"  runat="server" />
       <input id="ControlFileDisplay" type="hidden"  runat="server" />
        <input id="x2" type="hidden"  runat="server" />
                <div class ="c13101905">
      <div class="c13101906" id ="Div9">
          &gt;编辑工单报废入库单 </div>
     <div class="c13101907" id ="Div10">
 </div>
    </div>
<div class ="c13110501">
      <div class="c13110502" id ="Div17">
   <span class="c13110508" id ="Span1">
       <asp:ImageButton ID="btnAdd" runat="server" ImageUrl="~/Image/btnAdd.png"    onclick="btnAdd_Click"  />
          </span>
       </div>
              <div class="c13110510" id ="Div18">
   <span class="c13110511" id ="Span4">
                  (新增)
          </span>
       </div>
             <div class="c13110502" id ="Div19">
   <span class="c13110508" id ="Span3">
       <asp:ImageButton ID="btnSave" runat="server" ImageUrl="~/Image/btnSave.png" 
                     onclick="btnSave_Click"  />
          </span>
       </div>
              <div class="c13110510" id ="Div20">
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
                 <div class="c13110510" id ="Div23">
   <span class="c13110511" id ="Span6">
                     (退出)
          </span>
       </div>
    </div>
<div  id="i13102301" class ="c13102101">
<span  class ="c13102102"><asp:Label ID="prompt" runat="server"  ForeColor="#f80707"></asp:Label></span>
</div> 
 <div class ="c13101902">
      <div class="c13101903" id ="Div24">
          报废入库单号</div>
     <div class="c14031403" id ="Div25">
<input id="Text1" type="text"  runat="server"   readonly ="readonly"   class="c14031401" /> 
         <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="Text1" Text="必填" runat="server" /></div>
       <div class="c13101903" id ="Div5">
             客户名称</div>
     <div class="c14031403" id ="Div14">
   <input id="Text5" type="text"  runat ="server" class="c14031401" /> 
      <span style =" margin-left :5px"><a  href="javascript:f13100202('Text5','');">选择 </a></span> 
         </div>
         <div class="c13101903" id ="Div26">
             工单号</div>
     <div class="c14120110"  id ="Div27">
<input id="Text2" type="text"  runat="server"   readonly ="readonly"   class ="c14120107" /> 
  <a  href="javascript:f13100202('Text2','');">
         选择 </a>
   <asp:LinkButton ID="btnSure" runat="server" onclick="btnSure_Click"   ForeColor ="Blue">确定</asp:LinkButton>
   </div>                      <div class="c13101903" id ="Div7">
                       ID</div>
     <div class="c14120504" id ="Div8">
         <input id="Text6" type="text" runat="server" class="c14060901"/>
         
          </div>
   
           </div>
           <div class ="c13101902">
      
                   <div class="c13101903" id ="Div15">
                       厂内成品料号</div>
    <div class="c14031403" id ="Div12">
         <input id="Text7" type="text" runat="server" class="c14060901"/>
         
          </div>
                      <div class="c13101903" id ="Div30">
                          品名</div>
                          
     <div class="c14031403" id ="Div31">
         <input id="Text8" type="text" runat="server"  class ="c14060902"/>
        
   </div>
    <div class="c13101903" id ="Div32">
                         客户料号</div>
     <div class="c14120110"  id ="Div33">
         <input id="Text9" type="text" runat="server"  class="c14060901"/> 
         </div>
                   <div class="c13101903" id ="Div28">
                        入库日期</div>
       <div class="c14120504" id ="Div11">
         <input id="Text3" type="text" runat="server" onclick ="f13100202('Text3')" class ="c13110901"/> 
       <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ControlToValidate="Text3" Text="必填" runat="server" />
         </div>
           </div>
  <div class ="c13101902">

                      <div class="c13101903" id ="Div2">
                          入库员工号</div>                        
<div class="c14070101" id ="Div4">
<input id="Text4" type="text" runat="server" class ="c14120105" />
<span style =" margin-left :0px;"><a  href="javascript:f13100202('Text4','');">选择 </a></span> 
 <span  style =" margin-left :5px"><asp:Label ID="Label1" runat="server" Text="" ></asp:Label></span>
</div>

           </div>
  <div class ="c14060302">
   (可报废量 = 累计领用套数-累计退料套数-累计物料报废套数-累计工单入库数量-累计工单报废数量)
           </div>
<div class ="c14060302">
   (默认报(默认报废数量 =工单数量 - 累计工单入库数量-累计工单报废数量)
           </div>
<div id="i13111001" class ="c13102201">
              
           <asp:GridView ID="GridView1" runat="server" 
                    AllowSorting="True"   
                    onrowdatabound="GridView1_RowDataBound" 
                        AutoGenerateColumns="False"
                        CssClass ="c14072202"  onrowdeleting="GridView1_RowDeleting"
                   >
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <Columns > 
                       <asp:TemplateField HeaderText="删除" >
                <ItemTemplate >
                    <asp:LinkButton ID="LinkButton2" runat="server" 
                        OnClientClick="return confirm('您确认删除该记录吗?');" Text="删除"  CommandName ="delete" ></asp:LinkButton>                     
                </ItemTemplate>
                 <HeaderStyle Width="3%" />
                 <ItemStyle Width="3%"  />
            </asp:TemplateField>
             <asp:TemplateField HeaderText="成品料号">
                <ItemTemplate >
                 <asp:TextBox ID="TextBox3" runat="server" Text='<%#Eval ("料号") %>'   CssClass="c14071609" ></asp:TextBox>                     
                </ItemTemplate>
                <HeaderStyle Width="6%" />
                 <ItemStyle Width="6%"  />
            </asp:TemplateField>
                    <asp:TemplateField HeaderText="品名">
                <ItemTemplate >
                 <asp:TextBox ID="TextBox4" runat="server"  Text='<%#Eval ("品名") %>'  CssClass="c14071610"></asp:TextBox>                     
                </ItemTemplate>
               <HeaderStyle Width="5%" />
                 <ItemStyle Width="5%"  />
            </asp:TemplateField> 
               <asp:TemplateField HeaderText="可报废量">
                <ItemTemplate >
                 <asp:TextBox ID="TextBox7" runat="server" Text='<%#Eval ("可报废量") %>' CssClass ="c14071701"></asp:TextBox>                     
                </ItemTemplate>
               <HeaderStyle Width="4%" />
                 <ItemStyle Width="4%"  />
            </asp:TemplateField> 
              
                     <asp:TemplateField HeaderText="报废数量">
                <ItemTemplate >
                 <asp:TextBox ID="TextBox9" runat="server" Text='<%#Eval ("报废数量") %>'   CssClass ="c13112302"></asp:TextBox>                     
                </ItemTemplate>
          <HeaderStyle Width="4%" />
                 <ItemStyle Width="4%"/>
            </asp:TemplateField> 
                        <asp:TemplateField HeaderText="报废单位">
                <ItemTemplate >
                 <asp:TextBox ID="TextBox15" runat="server" Text='<%#Eval ("报废单位") %>' CssClass ="c14071616"></asp:TextBox>                     
                </ItemTemplate>
              <HeaderStyle Width="2%" />
                 <ItemStyle Width="2%"  />
            </asp:TemplateField>
                <asp:TemplateField HeaderText="仓库">
                <ItemTemplate >
                 <asp:TextBox ID="TextBox10" runat="server" Text='<%#Eval ("仓库") %>'  CssClass="c14071617"></asp:TextBox>
                 <a  href="javascript:f13100202('TextBox10','<%#Eval ("项次") %>');"> 选择</a>                     
                </ItemTemplate>
                <HeaderStyle Width="9%" />
                 <ItemStyle Width="9%"  />
            </asp:TemplateField> 
                            <asp:TemplateField HeaderText="库位">
                <ItemTemplate >
                 <asp:TextBox ID="TextBox11" runat="server" Text='<%#Eval ("库位") %>'  CssClass="c14071617"></asp:TextBox>
                  <a  href="javascript:f13100202('TextBox11','<%#Eval ("项次") %>');"> 选择</a>                           
                </ItemTemplate>
                 <HeaderStyle Width="9%" />
                 <ItemStyle Width="9%"  />
            </asp:TemplateField> 
                              <asp:TemplateField HeaderText="批号">
                <ItemTemplate >
                 <asp:TextBox ID="TextBox12" runat="server" Text='<%#Eval ("批号") %>' CssClass ="c14120203"></asp:TextBox>                     
                </ItemTemplate>
            <HeaderStyle Width="6%" />
                 <ItemStyle Width="6%"  />
            </asp:TemplateField> 
                <asp:TemplateField HeaderText="ID" >
                <ItemTemplate >
               <asp:TextBox ID="TextBox2" runat="server"  Text='<%#Eval ("品号") %>' CssClass="c14071609" ></asp:TextBox>         
                </ItemTemplate>
                <HeaderStyle Width="6%" />
                 <ItemStyle Width="6%"  />
            </asp:TemplateField> 
                   <asp:TemplateField HeaderText="客户料号">
                <ItemTemplate >
                 <asp:TextBox ID="TextBox5" runat="server" Text='<%#Eval ("客户料号") %>'  CssClass="c14071609"></asp:TextBox>                     
                </ItemTemplate>
                <HeaderStyle Width="6%" />
                 <ItemStyle Width="6%"  />
            </asp:TemplateField>
      
                    <asp:TemplateField HeaderText="工单数量">
                <ItemTemplate >
                 <asp:TextBox ID="TextBox6" runat="server" Text='<%#Eval ("工单数量") %>' ReadOnly ="true" Width ="60px" CssClass ="c13112503"></asp:TextBox>                     
                </ItemTemplate>
             <HeaderStyle Width="6%" />
                 <ItemStyle Width="6%"  />
            </asp:TemplateField>
                   
                         <asp:TemplateField HeaderText="累计领料套数">
                <ItemTemplate >
                 <asp:TextBox ID="TextBox18" runat="server" Text='<%#Eval ("累计领料套数") %>' ReadOnly ="true" Width ="80px" CssClass ="c13112503"></asp:TextBox>                     
                </ItemTemplate>
                 <HeaderStyle Width="8%" />
                 <ItemStyle Width="8%"  />
            </asp:TemplateField>
                    <asp:TemplateField HeaderText="累计退料套数">
                <ItemTemplate >
                 <asp:TextBox ID="TextBox19" runat="server" Text='<%#Eval ("累计退料套数") %>' ReadOnly ="true" Width ="80px" CssClass ="c13112503"></asp:TextBox>                     
                </ItemTemplate>
                <HeaderStyle Width="8%" />
                 <ItemStyle Width="8%"  />
            </asp:TemplateField>
                   <asp:TemplateField HeaderText="累计报废套数">
                <ItemTemplate >
                 <asp:TextBox ID="TextBox20" runat="server" Text='<%#Eval ("累计报废套数") %>' ReadOnly ="true" Width ="80px" CssClass ="c13112503"></asp:TextBox>                     
                </ItemTemplate>
                 <HeaderStyle Width="8%" />
                 <ItemStyle Width="8%"  />
            </asp:TemplateField>
              <asp:TemplateField HeaderText="累计入库数量">
                <ItemTemplate >
                 <asp:TextBox ID="TextBox16" runat="server" Text='<%#Eval ("工单累计入库数量") %>' ReadOnly ="true" Width ="80px" CssClass ="c13112503"></asp:TextBox>                     
                </ItemTemplate>
                 <HeaderStyle Width="8%" />
                 <ItemStyle Width="8%"  />
            </asp:TemplateField>
                     <asp:TemplateField HeaderText="累计报废数量">
                <ItemTemplate >
                 <asp:TextBox ID="TextBox8" runat="server" Text='<%#Eval ("工单累计报废数量") %>' ReadOnly ="true" Width ="80px" CssClass ="c13112503"></asp:TextBox>                     
                </ItemTemplate>
                  <HeaderStyle Width="8%" />
                 <ItemStyle Width="8%"  />
            </asp:TemplateField>
                        <asp:TemplateField HeaderText="本报废单累计报废数量">
                <ItemTemplate >
                 <asp:TextBox ID="TextBox14" runat="server" Text='<%#Eval ("本报废单累计报废数量") %>'  ReadOnly ="true" Width ="130px" CssClass ="c13112503"></asp:TextBox>                     
                </ItemTemplate>
                 <HeaderStyle Width="8%" />
                 <ItemStyle Width="8%"  />
            </asp:TemplateField> 
                          <asp:TemplateField HeaderText="备注">
                <ItemTemplate >
                 <asp:TextBox ID="TextBox13" runat="server"  ></asp:TextBox>                     
                </ItemTemplate>
                   <HeaderStyle Width="8%" />
                 <ItemStyle Width="8%"  />
            </asp:TemplateField>
      
                    </Columns>
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" Font-Bold="False" />   
                </asp:GridView>
         
                </div>
                            
            <div id="i13103002" class ="c13102201">
        <asp:GridView ID="GridView3" runat="server" Width="65%" 
                    AllowSorting="True"   
                    onrowdatabound="GridView3_RowDataBound" 
                        onselectedindexchanged="GridView3_SelectedIndexChanged" 
                        AutoGenerateColumns="False" style="margin-left: 8px" PageSize="15" 
                        CssClass ="c13102001"
                   >
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <Columns > 
              
                                     <asp:BoundField DataField="FLKEY" HeaderText="索引"  Visible ="false"  >
                              <ItemStyle Width="40px"  ForeColor="#595d5a"/>
                                    <HeaderStyle Width="40px" HorizontalAlign="Center" />
                          </asp:BoundField>

          <asp:BoundField DataField="WAREID" HeaderText="ID" >
                              <ItemStyle Width="80px"  ForeColor="#595d5a"/>
                                    <HeaderStyle Width="80px" HorizontalAlign="Center" />
                          </asp:BoundField>
                <asp:TemplateField HeaderText="附件">
                <ItemTemplate >
                    <asp:LinkButton ID="LinkButton1" runat="server" CommandName="Select" 
                        Text='<%# Bind("OLDFILENAME") %>'></asp:LinkButton>                     
                </ItemTemplate>
                 <HeaderStyle Width="500px" />
                 <ItemStyle Width="500px"  ForeColor="#595d5a"/>
            </asp:TemplateField>  
                      
         
           
                    </Columns>
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" Font-Bold="False" />   
                </asp:GridView>
                   
                </div>
                <div id="i13103001" class ="c13102201">
          
                    <asp:GridView ID="GridView2" runat="server"  CssClass ="c14070201"   >
                          <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    </asp:GridView>
                </div>
        <script type ="text/javascript" >
            window.onload = function onload1() {
                var Invocation = document.getElementById("hint").value;
                var Invocation1 = document.getElementById("x").value;
                var Invocation2 = document.getElementById("ControlFileDisplay").value;
                var Invocation3 = document.getElementById("x2").value;
                if (Invocation != "") {
                    document.getElementById("i13102301").style.display = "block";
                    document.all("prompt").innerText = Invocation;

                }
                else {

                    document.getElementById("i13102301").style.display = "none";
                }
                if (Invocation1 != "") {
                    document.getElementById("i13103001").style.display = "block";

                }
                else {
                    document.getElementById("i13103001").style.display = "none";

                }
                if (Invocation2 != "") {
                    document.getElementById("i13103002").style.display = "block";

                }
                else {
                    document.getElementById("i13103002").style.display = "none";
                }
                if (Invocation3 != "") {

                    document.getElementById("i13111001").style.display = "block";


                }
                else {

                    document.getElementById("i13111001").style.display = "none";


                }
               
            }

            function f13100202(obj, obj1) {
                var dlgResult;
                if (obj == "Text5") {
                    dlgResult = window.showModalDialog("../sellmanage/customerinfo.aspx", window, "dialogWidth:970px; dialogHeight:490px; status:0");
                    if (dlgResult != undefined) {

                        document.getElementById("cuid").value = dlgResult[0];
                        document.getElementById("Text5").value = dlgResult[1];

                    }
                }
                else if (obj == "Text2") {
                    dlgResult = window.showModalDialog("../workorder_manage/workorder.aspx?cuid=" + document.getElementById("cuid").value + "", window, "dialogWidth:970px; dialogHeight:490px; status:0");
                    if (dlgResult != undefined) {

                        document.getElementById("Text2").value = dlgResult[0]; /*woid*/
                        document.getElementById("Text5").value = dlgResult[1]; /*cname*/
                        document.getElementById("Text6").value = dlgResult[2]; /*id*/
                        document.getElementById("Text7").value = dlgResult[3]; /*co_wareid*/
                        document.getElementById("Text8").value = dlgResult[4]; /*wname*/
                        document.getElementById("Text9").value = dlgResult[5]; /*cwareid*/
                        
                    }

                }
                else if (obj == "TextBox10") {
                    dlgResult = window.showModalDialog("../StockManage/StorageInfo.aspx", window, "dialogWidth:970px; dialogHeight:490px; status:0");
                    if (dlgResult != undefined) {

                        var table = document.getElementById('<%=GridView1.ClientID%>');
                        var tr = table.getElementsByTagName("tr");
                        for (i = 1; i < tr.length; i++) {
                            if (obj1 == i) {
                                var v5 = tr[i].getElementsByTagName("td")[6].getElementsByTagName("input")[0];

                                v5.value = dlgResult[1];
                                break;
                            }
                        }
                    }
                }
                else if (obj == "TextBox11") {
                    dlgResult = window.showModalDialog("../StockManage/Storage_location.aspx", window, "dialogWidth:970px; dialogHeight:490px; status:0");
                    if (dlgResult != undefined) {
                        var table1 = document.getElementById('<%=GridView1.ClientID%>');
                        var tr1 = table1.getElementsByTagName("tr");
                        for (j = 1; j < tr1.length; j++) {
                            if (obj1 == j) {
                                var v6 = tr1[j].getElementsByTagName("td")[7].getElementsByTagName("input")[0];
                                v6.value = dlgResult[1];
                                break;
                            }
                        }
                    }
                }
                else if (obj == "Text3") {
                    dlgResult = window.showModalDialog("../WDate.aspx", window, "dialogWidth:160px; dialogHeight:240px; status:0;");
                    if (dlgResult != undefined) {
                        document.getElementById("Text3").value = dlgResult;
                    }


                }
                else if (obj == "Text11") {
                    dlgResult = window.showModalDialog("../BASEINFO/CompanyInfoPS.aspx", window, "dialogWidth:970px; dialogHeight:490px; status:0");
                    if (dlgResult != undefined) {

                        document.getElementById("CUKEY").value = dlgResult[0];
                        document.getElementById("Text6").value = dlgResult[1];
                        document.getElementById("Text10").value = dlgResult[2];
                        document.getElementById("Text11").value = dlgResult[3];

                    }
                }
                else {
                    dlgResult = window.showModalDialog("../BaseInfo/EMPLOYEEINFO.aspx", window, "dialogWidth:970px; dialogHeight:490px; status:0;");
                    if (dlgResult != undefined) {

                        document.getElementById("Text4").value = dlgResult[0];
                        document.all("Label1").innerText = dlgResult[1];
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