<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CO_ORDERT.aspx.cs" Inherits="WPSS.MRP_MANAGE.CO_ORDERT" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>编辑厂内订单信息</title>
<meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" /> 
<meta name ="Description" content ="ERP管理系统" />
<meta name ="keywords" content ="ERP管理系统,ERP管理软件,ERP,小微企业管理系统,希哲软件" />
       <link href ="../Css/SSBase.css"  type ="text/css" rel ="Stylesheet" />
       <link href ="../Css/S131017.css"  type ="text/css" rel ="Stylesheet" />
    </head>
<body >
   <form id="form1" runat="server">
   <input id="hint" type="hidden"  runat="server" />
      <input id="x" type="hidden"  runat="server" />
       <input id="x1" type="hidden"  runat="server" />
        <input id="x2" type="hidden"  runat="server" />
                <div class ="c13101905">
      <div class="c13101906" id ="Div9">
          &gt;编辑厂内订单信息 </div>
     <div class="c13101907" id ="Div10">
 </div>
    </div>
<div class ="c13110501">
      <div class="c13110502" id ="Div17">
   <span class="c13110508" id ="Span1">
       
          </span>
       </div>
              <div class="c13110510" id ="Div18">
   <span class="c13110511" id ="Span4">
               
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
        <div class="c14060904" id ="Div32">
                <span class="c14060903" id ="Span7">
    <asp:LinkButton ID="btnReconcile" runat="server" onclick="btnReconcile_Click" CssClass ="">产生MRP分析</asp:LinkButton>
    </span> 
   </div>
          

          
    </div>
<div  id="i13102301" class ="c13102101">
<span  class ="c13102102"><asp:Label ID="prompt" runat="server"  ForeColor="#f80707"></asp:Label></span>
</div> 
<div id="i14061508">
  <div class ="c13101902">
      <div class="c13101903" id ="Div24">
          厂内订单号</div>
     <div class="c14031403" id ="Div4"> <span style =" margin-right :8px;">
<input id="Text1" type="text"  runat="server"   readonly ="readonly" class="c14031401"/> 
         <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="Text1" Text="必填" runat="server" /></span></div>
         <div class="c13101903" id ="Div26">
             客户ID</div>
     <div class="c14031403" id ="Div27">
   <input id="Text2" type="text"  runat ="server" class="c14062901" readonly ="readonly"/>
   <span style =" margin-left :5px;display:none ;"><a  href="javascript:f13100202('Text2','');">
         选择 </a></span> 
   </div>
            <div class="c13101903" id ="Div2">
                客户代码</div>
 <div class="c14031403" id ="Div3">
   <input id="Text6" type="text"  runat ="server"  class="c14062901" /></div>
             <div class="c13101903" id ="Div5">
                 客户名称</div>
     <div class="c14120501" id ="Div6">
   <input id="Text5" type="text"  runat ="server"  class ="c14062902"  readonly ="readonly" /></div>
                 
       </div> 
           </div>
  
           <div class ="c13101902">
              <div class="c13101903" id ="Div28">
                        订单日期</div>
     <div class="c14031403" id ="Div29">
         <input id="Text3" type="text" runat="server" onclick ="f13100202('Text3')"  class="c14062901"  readonly ="readonly"/>
         <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="Text3" Text="必填" runat="server" />
         </div>
         <div class="c13101903" id ="Div15">
             客户订单号</div>
 <div class="c14031403" id ="Div1">
   <input id="Text4" type="text"  runat ="server"  class="c14062901"/>
   </div>
        <div class="c13101903" id ="Div42">
             订单号</div>
     <div class="c14031403" id ="Div43">
   <input id="Text14" type="text"  runat ="server"  class="c14062901" /></div>
            <div class="c13101903" id ="Div21">
                BOM编号</div>
 <div class="c14120501" id ="Div25">
   <input id="Text10" type="text"  runat ="server"  class="c14062901" />
   </div>
  
           </div>
           <div class ="c13101902">
               <div class="c13101903" id ="Div30">
                   BOM版本</div>
 <div class="c14031403" id ="Div31">
   <input id="Text11" type="text"  runat ="server"  class="c14062901"/>
   </div>
     
  
           </div>
<div id="i14061503" class ="c13111601">
       <div class="c13101903" id ="Div35">
           品号信息</div></div>
     
 
         
        
<div id="i14061504" class ="c13111602">
             
          <asp:GridView ID="GridView1" runat="server" 
                    AllowSorting="True"   
                    onrowdatabound="GridView1_RowDataBound" 
                        AutoGenerateColumns="False" PageSize="15" 
                        CssClass ="c14060801" 
                   >
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <Columns > 
           <asp:TemplateField HeaderText="ID" >
                <ItemTemplate >
                                <asp:TextBox ID="TextBox1" runat="server"  Text='<%#Eval ("ID") %>'  CssClass ="c13120501"  ></asp:TextBox>   
                                 <a  href="javascript:f13100202('TextBox1','<%#Eval ("项次") %>');"></a> 
                </ItemTemplate>
                 <HeaderStyle Width="6%" />
                 <ItemStyle Width="6%" />
            </asp:TemplateField> 
               <asp:TemplateField HeaderText="厂内成品料号">
                <ItemTemplate >
                 <asp:TextBox ID="TextBox2" runat="server"  Text='<%#Eval ("料号") %>'  CssClass ="c13120501" ></asp:TextBox>                     
                </ItemTemplate>
                  <HeaderStyle Width="8%" />
                 <ItemStyle Width="8%" />
            </asp:TemplateField>
                    <asp:TemplateField HeaderText="品名">
                <ItemTemplate >
                 <asp:TextBox ID="TextBox3" runat="server"  Text='<%#Eval ("品名") %>'   CssClass ="c13120501" ></asp:TextBox>                     
                </ItemTemplate>
                <HeaderStyle Width="8%" />
                 <ItemStyle Width="8%" />
            </asp:TemplateField> 
         
                          <asp:TemplateField HeaderText="客户料号">
                <ItemTemplate >
                 <asp:TextBox ID="TextBox4" runat="server"  Text='<%#Eval ("客户料号") %>'  CssClass ="c13120501"></asp:TextBox>                     
                </ItemTemplate>
                <HeaderStyle Width="8%" />
                 <ItemStyle Width="8%" />
            </asp:TemplateField>
                       <asp:TemplateField HeaderText="规格"  >
                <ItemTemplate >
                 <asp:TextBox ID="TextBox5" runat="server"   Text='<%#Eval ("规格") %>'  CssClass ="c13120501" ></asp:TextBox>                     
                </ItemTemplate>
                 <HeaderStyle Width="8%" />
                 <ItemStyle Width="8%" />
            </asp:TemplateField> 
                    <asp:TemplateField HeaderText="订单数量">
                <ItemTemplate >
                 <asp:TextBox ID="TextBox6" runat="server" Text='<%#Eval ("订单数量") %>' CssClass ="c14071615"  ReadOnly ="true"></asp:TextBox>                     
                </ItemTemplate>
                 <HeaderStyle Width="5%" />
                 <ItemStyle Width="5%" />
            </asp:TemplateField>
               <asp:TemplateField HeaderText="销售单价">
                <ItemTemplate >
                 <asp:TextBox ID="TextBox7" runat="server" Text='<%#Eval ("销售单价") %>' CssClass ="c14071615" ></asp:TextBox>                     
                </ItemTemplate>
            <HeaderStyle Width="5%" />
                 <ItemStyle Width="5%" />
            </asp:TemplateField> 
                     <asp:TemplateField HeaderText="税率">
                <ItemTemplate >
                 <asp:TextBox ID="TextBox8" runat="server" Text='<%#Eval ("税率") %>'   CssClass ="c14071615"></asp:TextBox>                     
                </ItemTemplate>
             <HeaderStyle Width="3%" />
                 <ItemStyle Width="3%" />
            </asp:TemplateField> 
   
                          <asp:TemplateField HeaderText="交货日期">
                <ItemTemplate >
                 <asp:TextBox ID="TextBox9" runat="server"  Text='<%#Eval ("交货日期") %>' CssClass ="c14071603 "  ></asp:TextBox>      
                    <a  href="javascript:f13100202('TextBox9','<%#Eval ("项次") %>');"> 选择</a>                
                </ItemTemplate>
                 <HeaderStyle Width="10%" />
                 <ItemStyle Width="10%" />
            </asp:TemplateField> 
       
                         <asp:TemplateField HeaderText="入库需求日期">
                <ItemTemplate >
                 <asp:TextBox ID="TextBox10" runat="server" Text='<%#Eval ("入库需求日期") %>' CssClass ="c14071603 "  ></asp:TextBox> 
                 <a  href="javascript:f13100202('TextBox10','<%#Eval ("项次") %>');"> 选择</a>                     
                </ItemTemplate>
                 <HeaderStyle Width="10%" />
                 <ItemStyle Width="10%" />
            </asp:TemplateField> 
         
    
                            <asp:TemplateField HeaderText="最晚下料日期">
                <ItemTemplate >
                 <asp:TextBox ID="TextBox11" runat="server"  Text='<%#Eval ("最晚下料日期") %>' CssClass ="c14071603 " ></asp:TextBox>      
                    <a  href="javascript:f13100202('TextBox11','<%#Eval ("项次") %>');"> 选择</a>                
                </ItemTemplate>
               <HeaderStyle Width="10%" />
                 <ItemStyle Width="10%" />
            </asp:TemplateField>
                                   <asp:TemplateField HeaderText="最晚齐套日期">
                <ItemTemplate >
                 <asp:TextBox ID="TextBox12" runat="server"  Text='<%#Eval ("最晚齐套日期") %>' CssClass ="c14071603 "  ></asp:TextBox>      
                    <a  href="javascript:f13100202('TextBox12','<%#Eval ("项次") %>');"> 选择</a>                
                </ItemTemplate>
               <HeaderStyle Width="10%" />
                 <ItemStyle Width="10%" />
            </asp:TemplateField>
                                 <asp:TemplateField HeaderText="建议客户交期">
                <ItemTemplate >
                 <asp:TextBox ID="TextBox13" runat="server"  Text='<%#Eval ("建议客户交期") %>' CssClass ="c14071603 "  ></asp:TextBox>      
                    <a  href="javascript:f13100202('TextBox13','<%#Eval ("项次") %>');"> 选择</a>                
                </ItemTemplate>
                 <HeaderStyle Width="10%" />
                 <ItemStyle Width="10%" />
            </asp:TemplateField>
       
                    </Columns>
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" Font-Bold="False" />   
                </asp:GridView>
                </div>
                                          
                                               <div  id ="i13111501" class ="c13101902">
                                 <div class="c13102907" id ="Div16">
                                 </div>
      <div class="c13101903" id ="Div7">
          合计未税金额</div>
     <div class="c13101904" id ="Div8">
        <input id="Text7" type="text"  runat="server"    class="c13102908"/></div>
          <div class="c13101903" id ="Div12">
              合计税额</div>
     <div class="c13101904" id ="Div13">
   <input id="Text8" type="text"  runat ="server" class="c13102908" /> 
         </div>
                  <div class="c13101903" id ="Div11">
                      合计含税金额</div>
     <div class="c13101904" id ="Div14">
   <input id="Text9" type="text"  runat ="server" class ="c13102908"  /> 
         </div>
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
        <asp:GridView ID="GridView2" runat="server" 
                    onrowdeleting="GridView2_RowDeleting" 
                    AllowSorting="True"   
                    onrowdatabound="GridView2_RowDataBound" 
                        AutoGenerateColumns="False" PageSize="15" 
                        CssClass ="c14060802"
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
                                     <asp:BoundField DataField="索引" HeaderText="索引"  Visible ="false"  >
                              <ItemStyle Width="40px"  ForeColor="#595d5a"/>
                                    <HeaderStyle Width="40px" HorizontalAlign="Center" />
                          </asp:BoundField>
                          <asp:BoundField DataField="项次" HeaderText="项次" >
                              <ItemStyle Width="40px"  ForeColor="#595d5a"/>
                                    <HeaderStyle Width="40px" HorizontalAlign="Center" />
                          </asp:BoundField>
          <asp:BoundField DataField="ID" HeaderText="ID" >
                              <ItemStyle Width="80px"  ForeColor="#595d5a"/>
                                    <HeaderStyle Width="80px" HorizontalAlign="Center" />
                          </asp:BoundField>
                               <asp:BoundField DataField="料号" HeaderText="厂内成品料号" >
                              <ItemStyle Width="120px"  ForeColor="#595d5a"/>
                                    <HeaderStyle Width="120px" HorizontalAlign="Center" />
                          </asp:BoundField>
            <asp:BoundField DataField="品名" HeaderText="品名" >
                              <ItemStyle Width="180px"  ForeColor="#595d5a"/>
                                    <HeaderStyle Width="180px" HorizontalAlign="Center" />
                          </asp:BoundField> 
       <asp:BoundField DataField="客户料号" HeaderText="客户料号" >
                              <ItemStyle Width="120px"  ForeColor="#595d5a"/>
                                    <HeaderStyle Width="120px" HorizontalAlign="Center" />
                          </asp:BoundField>
            <asp:BoundField DataField="订单数量" HeaderText="订单数量" >
                              <ItemStyle Width="80px"  ForeColor="#595d5a"  HorizontalAlign="Right" />
                                    <HeaderStyle Width="80px" HorizontalAlign="Center" />
                          </asp:BoundField>
                          
            <asp:BoundField DataField="销售单价" HeaderText="销售单价" >
                              <ItemStyle Width="80px"  ForeColor="#595d5a" HorizontalAlign="Right" />
                                    <HeaderStyle Width="80px" HorizontalAlign="Center" />
                          </asp:BoundField>
             <asp:BoundField DataField="税率" HeaderText="税率" >
                              <ItemStyle Width="40px"  ForeColor="#595d5a" HorizontalAlign="Right" />
                                    <HeaderStyle Width="40px" HorizontalAlign="Center" />
                          </asp:BoundField>
           <asp:BoundField DataField="未税金额" HeaderText="未税金额"    DataFormatString="{0:0.00}"  >
                              <ItemStyle Width="80px"  ForeColor="#595d5a" HorizontalAlign="Right" />
                                    <HeaderStyle Width="80px" HorizontalAlign="Center" />
                          </asp:BoundField>
             <asp:BoundField DataField="税额" HeaderText="税额"   DataFormatString="{0:0.00}">
                              <ItemStyle Width="80px"  ForeColor="#595d5a" HorizontalAlign="Right" />
                                    <HeaderStyle Width="80px" HorizontalAlign="Center" />
                          </asp:BoundField>
            <asp:BoundField DataField="含税金额" HeaderText="含税金额"   DataFormatString="{0:0.00}">
                              <ItemStyle Width="80px"  ForeColor="#595d5a" HorizontalAlign="Right" />
                                    <HeaderStyle Width="80px" HorizontalAlign="Center" />
                          </asp:BoundField>
                            <asp:BoundField DataField="交货日期" HeaderText="交货日期"   >
                              <ItemStyle Width="80px"  ForeColor="#595d5a" HorizontalAlign="Center" />
                                    <HeaderStyle Width="80px" HorizontalAlign="Center" />
                          </asp:BoundField>
                                <asp:BoundField DataField="前置天数" HeaderText="前置天数"  >
                              <ItemStyle Width="80px"  ForeColor="#595d5a" HorizontalAlign="Center" />
                                    <HeaderStyle Width="80px" HorizontalAlign="Center" />
                          </asp:BoundField>
                         
             <asp:BoundField DataField="备料前置" HeaderText="备料前置"   >
                              <ItemStyle Width="80px"  ForeColor="#595d5a" HorizontalAlign="Center" />
                                    <HeaderStyle Width="80px" HorizontalAlign="Center" />
                          </asp:BoundField>
                         <asp:BoundField DataField="入库需求日期" HeaderText="入库需求日期"   >
                              <ItemStyle Width="120px"  ForeColor="#595d5a" HorizontalAlign="Center" />
                                    <HeaderStyle Width="120px" HorizontalAlign="Center" />
                          </asp:BoundField>
                           <asp:BoundField DataField="最晚下料日期" HeaderText="最晚下料日期"   >
                              <ItemStyle Width="120px"  ForeColor="#595d5a" HorizontalAlign="Center" />
                                    <HeaderStyle Width="120px" HorizontalAlign="Center" />
                          </asp:BoundField>
                           <asp:BoundField DataField="最晚齐套日期" HeaderText="最晚齐套日期"   >
                              <ItemStyle Width="120px"  ForeColor="#595d5a" HorizontalAlign="Center" />
                                    <HeaderStyle Width="120px" HorizontalAlign="Center" />
                          </asp:BoundField>
                               <asp:BoundField DataField="建议客户交期" HeaderText="建议客户交期"   >
                              <ItemStyle Width="120px"  ForeColor="#595d5a" HorizontalAlign="Center" />
                                    <HeaderStyle Width="120px" HorizontalAlign="Center" />
                          </asp:BoundField>
                              <asp:BoundField DataField="备注" HeaderText="备注"   >
                              <ItemStyle Width="160px"  ForeColor="#595d5a" HorizontalAlign="Center" />
                                    <HeaderStyle Width="160px" HorizontalAlign="Center" />
                          </asp:BoundField>
                    </Columns>
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" Font-Bold="False" />   
                </asp:GridView>
                   
                </div>
      <script type ="text/javascript" >
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
                  document.getElementById("i13103001").style.display = "block";
                  document.getElementById("i14061503").style.display = "block";
                  document.getElementById("i14061504").style.display = "block";
                  document.getElementById("i13111501").style.display = "block";
                  document.getElementById("i13103002").style.display = "block";


              }
              else {
                  document.getElementById("i13103001").style.display = "none";
                  document.getElementById("i14061503").style.display = "none";
                  document.getElementById("i14061504").style.display = "none";
                  document.getElementById("i13111501").style.display = "none";
                  document.getElementById("i13103002").style.display = "none";

              }
              if (Invocation2 != "") {
                  document.getElementById("i13103002").style.display = "block";

              }
              else {
                  document.getElementById("i13103002").style.display = "none";
              }
          }

          function f13100202(obj, obj1) {
              var dlgResult;
              if (obj == "Text2") {
                  dlgResult = window.showModalDialog("../SellManage/Customerinfo.aspx", window, "dialogWidth:970px; dialogHeight:490px; status:0");
                  if (dlgResult != undefined) {

                      document.getElementById("Text2").value = dlgResult[0];
                      document.getElementById("Text5").value = dlgResult[1];
                      document.getElementById("Text6").value = dlgResult[5];
                  }
              }
              else if (obj == "TextBox1") {
                  dlgResult = window.showModalDialog("../BaseInfo/Wareinfo.aspx?CUID=" + document.getElementById("Text2").value + "", window, "dialogWidth:970px; dialogHeight:490px; status:0");

                  if (dlgResult != undefined) {

                      var table = document.getElementById('<%=GridView1.ClientID%>');
                      var tr = table.getElementsByTagName("tr");
                      for (i = 1; i < tr.length; i++) {
                          if (obj1 == i) {
                              var v1 = tr[i].getElementsByTagName("td")[0].getElementsByTagName("input")[0]; //获取girdview里第1列TextBox的值
                              var v2 = tr[i].getElementsByTagName("td")[1].getElementsByTagName("input")[0];
                              var v3 = tr[i].getElementsByTagName("td")[2].getElementsByTagName("input")[0];
                              var v4 = tr[i].getElementsByTagName("td")[3].getElementsByTagName("input")[0];
                              var v5 = tr[i].getElementsByTagName("td")[4].getElementsByTagName("input")[0];
                              var v7 = tr[i].getElementsByTagName("td")[6].getElementsByTagName("input")[0];
                              var v8 = tr[i].getElementsByTagName("td")[12].getElementsByTagName("input")[0];
                              v1.value = dlgResult[0];
                              v2.value = dlgResult[1];
                              v3.value = dlgResult[2];
                              v4.value = dlgResult[3];
                              v7.value = dlgResult[5];
                              v5.value = dlgResult[6];
                              v8.value = dlgResult[7];
                              break;
                          }
                      }


                  }

              }
              else if (obj == "TextBox9") {
                  dlgResult = window.showModalDialog("../WDate.aspx", window, "dialogWidth:160px; dialogHeight:240px; status:0;");
                  if (dlgResult != undefined) {

                      table = document.getElementById('<%=GridView1.ClientID%>');
                      tr = table.getElementsByTagName("tr");
                      v1 = tr[1].getElementsByTagName("td")[8].getElementsByTagName("input")[0]; //获取girdview里第1列TextBox的值
                      v1.value = dlgResult;
                  }

              }
              else if (obj == "TextBox10") {
                  dlgResult = window.showModalDialog("../WDate.aspx", window, "dialogWidth:160px; dialogHeight:240px; status:0;");
                  if (dlgResult != undefined) {

                      table = document.getElementById('<%=GridView1.ClientID%>');
                      tr = table.getElementsByTagName("tr");
                      v1 = tr[1].getElementsByTagName("td")[9].getElementsByTagName("input")[0]; //获取girdview里第1列TextBox的值
                      v1.value = dlgResult;
                  }

              }
              else if (obj == "TextBox11") {
                  dlgResult = window.showModalDialog("../WDate.aspx", window, "dialogWidth:160px; dialogHeight:240px; status:0;");
                  if (dlgResult != undefined) {

                      table = document.getElementById('<%=GridView1.ClientID%>');
                      tr = table.getElementsByTagName("tr");
                      v1 = tr[1].getElementsByTagName("td")[10].getElementsByTagName("input")[0]; //获取girdview里第1列TextBox的值
                      v1.value = dlgResult;
                  }

              }
              else if (obj == "TextBox12") {
                  dlgResult = window.showModalDialog("../WDate.aspx", window, "dialogWidth:160px; dialogHeight:240px; status:0;");
                  if (dlgResult != undefined) {

                      table = document.getElementById('<%=GridView1.ClientID%>');
                      tr = table.getElementsByTagName("tr");
                      v1 = tr[1].getElementsByTagName("td")[11].getElementsByTagName("input")[0]; //获取girdview里第1列TextBox的值
                      v1.value = dlgResult;
                  }

              }
              else if (obj == "TextBox13") {
                  dlgResult = window.showModalDialog("../WDate.aspx", window, "dialogWidth:160px; dialogHeight:240px; status:0;");
                  if (dlgResult != undefined) {

                      table = document.getElementById('<%=GridView1.ClientID%>');
                      tr = table.getElementsByTagName("tr");
                      v1 = tr[1].getElementsByTagName("td")[12].getElementsByTagName("input")[0]; //获取girdview里第1列TextBox的值
                      v1.value = dlgResult;
                  }

              }
              else if (obj == "TextBox14") {
                  dlgResult = window.showModalDialog("../WDate.aspx", window, "dialogWidth:160px; dialogHeight:240px; status:0;");
                  if (dlgResult != undefined) {

                      table = document.getElementById('<%=GridView1.ClientID%>');
                      tr = table.getElementsByTagName("tr");
                      v1 = tr[1].getElementsByTagName("td")[13].getElementsByTagName("input")[0]; //获取girdview里第1列TextBox的值
                      v1.value = dlgResult;
                  }

              }
              else if (obj == "Text3") {
                  dlgResult = window.showModalDialog("../WDate.aspx", window, "dialogWidth:160px; dialogHeight:240px; status:0;");
                  if (dlgResult != undefined) {


                      document.getElementById("Text3").value = dlgResult;
                  }

              }
              else if (obj == "Text4") {
                  dlgResult = window.showModalDialog("../WDate.aspx", window, "dialogWidth:160px; dialogHeight:240px; status:0;");
                  if (dlgResult != undefined) {


                      document.getElementById("Text4").value = dlgResult;
                  }


              }
              else {
                  dlgResult = window.showModalDialog("../BaseInfo/EMPLOYEEINFO.aspx", window, "dialogWidth:970px; dialogHeight:490px; status:0;");
                  if (dlgResult != undefined) {

                      document.getElementById("Text10").value = dlgResult[0];
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