<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PurchaseT.aspx.cs" Inherits="WPSS.PurchaseManage.PurchaseT" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>编辑采购单</title>
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
      <input id="x" type="hidden"  runat="server" />
       <input id="x1" type="hidden"  runat="server" />
       <input id="pur" type="hidden"  runat="server" />
         <input id="RDID" type="hidden"  runat="server" />
            <input id="COKEY" type="hidden"  runat="server" />
               <input id="wareid" type="hidden"  runat="server" />
                <div class ="c13101905">
      <div class="c13101906" id ="Div9">
          编辑采购单 </div>
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
              <div class="c13110507" id ="Div50">
                <span class="c13110503" id ="Span13">
    <asp:LinkButton ID="btnAudit" runat="server" onclick="btnAudit_Click" CssClass ="">审核</asp:LinkButton>
    </span> 
   </div>
          
                 <div class="c13110510" id ="Div51">
   <span class="c13110511" id ="Span14">
                 
          </span>
       </div>
                       <div class="c13110507" id ="Div52">
                <span class="c13110503" id ="Span15">
    <asp:LinkButton ID="btnReductionAudit" runat="server" onclick="btnReductionAudit_Click" CssClass ="">撤销审核</asp:LinkButton>
    </span> 
   </div>
                <div class="c13110507" id ="Div30">
                <span class="c13110503" id ="Span7">
    <asp:LinkButton ID="btnReconcile" runat="server" onclick="btnReconcile_Click" CssClass ="">确认对帐</asp:LinkButton>
    </span> 
   </div>
          
                 <div class="c14120111" id ="Div31">
   <span class="c14120111" id ="Span8">
                 
          </span>
       </div>
                       <div class="c13110507" id ="Div32">
                <span class="c13110503" id ="Span9">
    <asp:LinkButton ID="btnReductionReconcil" runat="server" onclick="btnReductionReconcile_Click" CssClass ="">对帐还原</asp:LinkButton>
    </span> 
   </div>
          
                 <div class="c14120111" id ="Div33">
   <span class="c14120111" id ="Span10">
                 
          </span>
       </div>
                      <div class="c13110507" id ="Div48">
                  <span class="c13110503" id ="Span11">
    
          </span>
   </div>
                 <div class="c13110510" id ="Div49">
   <span class="c13110511" id ="Span12">
                
          </span>
       </div>
    </div>
<div  id="i13102301" class ="c13102101">
<span  class ="c13102102"><asp:Label ID="prompt" runat="server"  ForeColor="#f80707"></asp:Label></span>
</div> 
 <div class ="c13101902">
      <div class="c13101903" id ="Div24">
          采购单号</div>
     <div class="c13111503" id ="Div25">
<input id="Text1" type="text"  runat="server"   readonly ="readonly" class="c14112011"/> 
         <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="Text1" Text="必填" runat="server" /></div>
         <div class="c13101903" id ="Div26">
             供应商代码</div>
     <div class="c13102401" id ="Div27">
   <input id="Text2" type="text"  runat ="server"  class ="c14112009"  />
    <span style =" margin-left :5px; margin-right :2px;"><a  href="javascript:f13100202('Text2','');"> 
         选择</a></span>
       </div>
                    <div class="c13101903" id ="Div28">
                        采购日期</div>
     <div class="c14120501" id ="Div29">
         <input id="Text3" type="text" runat="server" onclick ="f13100202('Text3')" readonly="readonly" class ="c13110901"/>
         <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="Text3" Text="必填" runat="server" />
         </div>
           </div>
           
  <div class ="c13101902">
                      <div class="c13101903" id ="Div2">
                          采购员工号</div>
     <div class="c13111503" id ="Div4">
         <input id="Text4" type="text" runat="server"  class ="c14112009" /> 
         <span style =" margin-left :5px;"><a  href="javascript:f13100202('Text4','');"> 
         选择</a></span>
               <asp:Label ID="Label1" runat="server" Text="" ></asp:Label>
         </div>
         <div class="c13101903" id ="Div5">
             供应商名称</div>
     <div class="c13102401" id ="Div6">
   <input id="Text5" type="text"  runat ="server"  class ="c14111909"  /></div>
                        <div class="c13101903" id ="Div38">
                            联系人</div>
     <div class="c14120501" id ="Div39">
         <input id="Text10" type="text" runat="server"  class ="c14112007" /> 
         </div>
           </div>
       <div class ="c13101902">
      <div class="c13101903" id ="Div1">
                   地址</div>
     <div class="c14032101" id ="Div3">
           <input id="Text6" type="text"  runat="server"  readonly ="readonly" class="c14112004"/></div>
                  <div class="c13101903" id ="Div40">
                      联系电话</div>
     <div class="c14112005" id ="Div41">
   <input id="Text11" type="text"  runat ="server"  class ="c14112007"  /></div>
           </div>
           
           <div class ="c13101902">
                      <div class="c13101903" id ="Div15">
                          收货人</div>
     <div class="c13111503" id ="Div21">
         <input id="Text12" type="text" runat="server"  readonly ="readonly" class ="c14111912"/> 
              <span style =" margin-left :5px;"><a  href="javascript:f13100202('Text12','');"> 
         选择</a></span>
         </div>
         <div class="c13101903" id ="Div34">
             收货地址</div>
     <div class="c13102402" id ="Div37">
   <input id="Text13" type="text"  runat ="server"  class ="c14112008"  /></div>
  
           </div>
           <div class ="c13101902">
                      <div class="c13101903" id ="Div42">
                          公司名称</div>
     <div class="c13111503" id ="Div43">
         <input id="Text14" type="text" runat="server" class ="c14032102" /> 
         </div>
         <div class="c13101903" id ="Div44">
             联系人</div>
     <div class="c14112006" id ="Div45">
   <input id="Text15" type="text"  runat ="server"  readonly ="readonly" class ="c14032103"  />
           <span style =" margin-left :5px;"><a  href="javascript:f13100202('Text15','');"> 
         选择</a></span>
   </div>
                        <div class="c13101903" id ="Div46">
                            电话</div>
     <div class="c14112005" id ="Div47">
         <input id="Text16" type="text" runat="server"  class ="c14112007"/> 
         </div>
           </div>
           <div class ="c13111601">
       <div class="c13101903" id ="Div35">
           添加品号信息</div>
     <div class="c13111503" id ="Div36">
      <span style="color :#990033">(税率输入17即17个点)</span>
</div>
 
         
           </div>
<div class ="c14071601">
             
          
            <asp:GridView ID="GridView1" runat="server" 
                    AllowSorting="True"   
                    onrowdatabound="GridView1_RowDataBound" 
                        AutoGenerateColumns="False" PageSize="15" 
                             CssClass ="c13122602"
                   >
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <Columns > 
           <asp:TemplateField HeaderText="ID" >
                <ItemTemplate >
                                <asp:TextBox ID="TextBox1" runat="server"  Text='<%#Eval ("品号") %>'  CssClass ="c14071603"    ></asp:TextBox>   
                                 <a  href="javascript:f13100202('TextBox1','<%#Eval ("项次") %>');"> 选择</a> 
                </ItemTemplate>
                 <HeaderStyle Width="7%" />
                 <ItemStyle Width="7%"/>
            </asp:TemplateField> 
           <asp:TemplateField HeaderText="原物料编码">
                <ItemTemplate >
                 <asp:TextBox ID="TextBox2" runat="server"  Text='<%#Eval ("料号") %>' CssClass ="c13120501" ></asp:TextBox>                     
                </ItemTemplate>
                <HeaderStyle Width="7%" />
                 <ItemStyle Width="7%"/>
            </asp:TemplateField>
                    <asp:TemplateField HeaderText="原物料类别">
                <ItemTemplate >
                 <asp:TextBox ID="TextBox3" runat="server"  Text='<%#Eval ("品名") %>'  CssClass ="c14070103" ></asp:TextBox>                     
                </ItemTemplate>
                 <HeaderStyle Width="7%" />
                 <ItemStyle Width="7%"/>
            </asp:TemplateField> 
              
  
      
                    <asp:TemplateField HeaderText="采购数量">
                <ItemTemplate >
                 <asp:TextBox ID="TextBox5" runat="server" Text='<%#Eval ("采购数量") %>' CssClass ="c13112302" ></asp:TextBox>                     
                </ItemTemplate>
                  <HeaderStyle Width="3%" />
                 <ItemStyle Width="3%"/>
            </asp:TemplateField>
                          <asp:TemplateField HeaderText="采购单位">
                <ItemTemplate >
                 <asp:TextBox ID="TextBox10" runat="server"  Text='<%#Eval ("采购单位") %>' CssClass ="c14120404"></asp:TextBox>      
                    <a  href="javascript:f13100202('TextBox10','<%#Eval ("项次") %>');"> 选择</a>                
                </ItemTemplate>
               <HeaderStyle Width="4%" />
                 <ItemStyle Width="4%"/>
            </asp:TemplateField> 
               
               <asp:TemplateField HeaderText="采购单价">
                <ItemTemplate >
                 <asp:TextBox ID="TextBox6" runat="server" Text='<%#Eval ("采购单价") %>' CssClass ="c13112302"></asp:TextBox>                     
                </ItemTemplate>
                  <HeaderStyle Width="3%" />
                 <ItemStyle Width="3%"/>
            </asp:TemplateField> 
                          <asp:TemplateField HeaderText="币别">
                <ItemTemplate >
                 <asp:TextBox ID="TextBox13" runat="server"  Text='<%#Eval ("币别") %>' CssClass ="c14120404"></asp:TextBox>      
                    <a  href="javascript:f13100202('TextBox13','<%#Eval ("项次") %>');"> 选择</a>                
                </ItemTemplate>
                  <HeaderStyle Width="4%" />
                 <ItemStyle Width="4%"/>
            </asp:TemplateField>
                     <asp:TemplateField HeaderText="税率">
                <ItemTemplate >
                 <asp:TextBox ID="TextBox7" runat="server"  Text='<%#Eval ("税率") %>' CssClass ="c13112302"></asp:TextBox>                     
                </ItemTemplate>
               <HeaderStyle Width="2%" />
                 <ItemStyle Width="2%"/>
            </asp:TemplateField> 
                     <asp:TemplateField HeaderText="需求日期">
                <ItemTemplate >
                 <asp:TextBox ID="TextBox8" runat="server"  Text='<%#Eval ("需求日期") %>' CssClass ="c14071603" ></asp:TextBox>      
                    <a  href="javascript:f13100202('TextBox8','<%#Eval ("项次") %>');"> 选择</a>                
                </ItemTemplate>
                   <HeaderStyle Width="7%" />
                 <ItemStyle Width="7%"/>
            </asp:TemplateField> 
                    <asp:TemplateField HeaderText="备注">
                <ItemTemplate >
                 <asp:TextBox ID="TextBox9" runat="server"  Text='<%#Eval ("备注") %>'  Width ="200px"  CssClass ="c13120501"></asp:TextBox>                     
                </ItemTemplate>
                   <HeaderStyle Width="6%" />
                 <ItemStyle Width="6%"/>
            </asp:TemplateField> 
             <asp:TemplateField HeaderText="规格"   >
                <ItemTemplate >
                 <asp:TextBox ID="TextBox11" runat="server"  Text='<%#Eval ("规格") %>'   CssClass ="c14070203"  ></asp:TextBox>                     
                </ItemTemplate>
                 <HeaderStyle Width="8%" />
                 <ItemStyle Width="8%"/>
            </asp:TemplateField> 
                         <asp:TemplateField HeaderText="品牌"  >
                <ItemTemplate >
                 <asp:TextBox ID="TextBox12" runat="server" Text='<%#Eval ("品牌") %>'  CssClass ="c14070203" ></asp:TextBox>                     
                </ItemTemplate>
                <HeaderStyle Width="5%" />
                 <ItemStyle Width="5%"/>
            </asp:TemplateField> 
                          <asp:TemplateField HeaderText="原厂料号">
                <ItemTemplate >
                 <asp:TextBox ID="TextBox4" runat="server"  Text='<%#Eval ("客户料号") %>'  CssClass ="c14070103"></asp:TextBox>                     
                </ItemTemplate>
                   <HeaderStyle Width="5%" />
                 <ItemStyle Width="5%"/>
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
                        AutoGenerateColumns="False" style="margin-left: 8px" PageSize="15" 
                        CssClass ="c13112304"
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
          <asp:BoundField DataField="品号" HeaderText="ID" >
                              <ItemStyle Width="80px"  ForeColor="#595d5a"/>
                                    <HeaderStyle Width="80px" HorizontalAlign="Center" />
                          </asp:BoundField>
              <asp:BoundField DataField="料号" HeaderText="原物料编码" >
                              <ItemStyle CssClass="c14070204"  ForeColor="#595d5a"/>
                                    <HeaderStyle  HorizontalAlign="Center" />
                          </asp:BoundField>
            <asp:BoundField DataField="品名" HeaderText="原物料类别" >
                              <ItemStyle CssClass="c14071001" ForeColor="#595d5a"/>
                                    <HeaderStyle HorizontalAlign="Center" />
                          </asp:BoundField> 
       <asp:BoundField DataField="客户料号" HeaderText="原厂料号" >
                              <ItemStyle Width="120px"  ForeColor="#595d5a"/>
                                    <HeaderStyle Width="120px" HorizontalAlign="Center" />
                          </asp:BoundField>
      
            <asp:BoundField DataField="采购数量" HeaderText="采购数量" >
                              <ItemStyle Width="80px"  ForeColor="#595d5a"  HorizontalAlign="Right" />
                                    <HeaderStyle Width="80px" HorizontalAlign="Center" />
                          </asp:BoundField>
                           <asp:BoundField DataField="采购单位" HeaderText="采购单位" >
                              <ItemStyle Width="80px"  ForeColor="#595d5a"   />
                                    <HeaderStyle Width="80px" HorizontalAlign="Center" />
                          </asp:BoundField>
            <asp:BoundField DataField="采购单价" HeaderText="采购单价" >
                              <ItemStyle Width="80px"  ForeColor="#595d5a" HorizontalAlign="Right" />
                                    <HeaderStyle Width="80px" HorizontalAlign="Center" />
                          </asp:BoundField>
                            <asp:BoundField DataField="币别" HeaderText="币别" >
                              <ItemStyle Width="40px"  ForeColor="#595d5a"  />
                                    <HeaderStyle Width="40px" HorizontalAlign="Center" />
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
             <asp:BoundField DataField="需求日期" HeaderText="需求日期"   >
                              <ItemStyle Width="80px"  ForeColor="#595d5a" HorizontalAlign="Center" />
                                    <HeaderStyle Width="80px" HorizontalAlign="Center" />
                          </asp:BoundField>
                              <asp:BoundField DataField="备注" HeaderText="备注"   >
                              <ItemStyle Width="200px"  ForeColor="#595d5a" HorizontalAlign="Center" />
                                    <HeaderStyle Width="200px" HorizontalAlign="Center" />
                          </asp:BoundField>
                      
                    </Columns>
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" Font-Bold="False" />   
                </asp:GridView>
                   
                </div>
                            <div class ="c13101902">
                                 <div class="c13102907" id ="Div16">
                                 </div>
      <div class="c14112014" id ="Div7">
          合计未税金额</div>
     <div class="c13101904" id ="Div8">
        <input id="Text7" type="text"  runat="server"    class="c13102908"/></div>
          <div class="c14112014" id ="Div12">
              合计税额</div>
     <div class="c13101904" id ="Div13">
   <input id="Text8" type="text"  runat ="server" class="c13102908" /> 
         </div>
                  <div class="c14112014" id ="Div11">
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
          }

          function f13100202(obj, obj1) {
              var dlgResult;
              if (obj == "Text2") {
                  dlgResult = window.showModalDialog("../PurchaseManage/Supplierinfo.aspx", window, "dialogWidth:970px; dialogHeight:490px; status:0");
                  if (dlgResult != undefined) {

                      document.getElementById("Text2").value = dlgResult[0];
                      document.getElementById("Text5").value = dlgResult[1];
                      document.getElementById("Text6").value = dlgResult[2];
                      document.getElementById("Text10").value = dlgResult[3];
                      document.getElementById("Text11").value = dlgResult[4];
                   
                  }
              }
              else if (obj == "TextBox1") {
              dlgResult = window.showModalDialog("../BaseInfo/Wareinfo.aspx?CUID=" + document.getElementById("Text2").value + "&nature=purchase_det", window, "dialogWidth:970px; dialogHeight:490px; status:0");

                  if (dlgResult != undefined) {

                      var table = document.getElementById('<%=GridView1.ClientID%>');
                      var tr = table.getElementsByTagName("tr");
                      for (i = 1; i < tr.length; i++) {
                          if (obj1 == i) {
                            
                              tr[i].getElementsByTagName("td")[0].getElementsByTagName("input")[0].value = dlgResult[0];
                              tr[i].getElementsByTagName("td")[1].getElementsByTagName("input")[0].value = dlgResult[1];
                              tr[i].getElementsByTagName("td")[2].getElementsByTagName("input")[0].value = dlgResult[2];
                              tr[i].getElementsByTagName("td")[4].getElementsByTagName("input")[0].value = dlgResult[10];
                              
                              tr[i].getElementsByTagName("td")[5].getElementsByTagName("input")[0].value = dlgResult[9];
                              tr[i].getElementsByTagName("td")[10].getElementsByTagName("input")[0].value = dlgResult[6];

                              tr[i].getElementsByTagName("td")[11].getElementsByTagName("input")[0].value = dlgResult[11];
                              tr[i].getElementsByTagName("td")[12].getElementsByTagName("input")[0].value = dlgResult[3];
                           
                              document.getElementById("wareid").value = dlgResult[0];
                              break;
                              /*dlgResult[0] wareid,dlgResult[1] CO_WAREID,dlgResult[2] WNAME,dlgResult[3] CWAREID,dlgResult[4] CNAME,
                              dlgResult[5] SELLUNITPRICE,dlgResult[6] SPEC,dlgResult[7] REMARK*/
                               /*dlgResult[8] BOM_UNIT,dlgResult[9] PURCHASEUNITPRICE,dlgResult[10] MPA_UNIT,dlgResult[11] BRAND,
                               dlgResult[12] SKU,dlgResult[13] CURRENCY,dlgResult[14] STORAGENAME,dlgResult[15] STORAGE_LOCATION,
                               dlgResult[16] BATCHID,dlgResult[17] MAX_STORAGE_COUNT*/
                               
 
                          }
                      }
                  }
              }
              else if (obj == "TextBox10") {
              dlgResult = window.showModalDialog("../BaseInfo/unit.aspx?wareid=" + document.getElementById("wareid").value + "&nature=purchase_det", window, "dialogWidth:970px; dialogHeight:490px; status:0");
                  if (dlgResult != undefined) {
                      var table1 = document.getElementById('<%=GridView1.ClientID%>');
                      var tr1 = table1.getElementsByTagName("tr");
                      for (i = 1; i < tr1.length; i++) {
                          if (obj1 == i) {
                              var v10 = tr1[i].getElementsByTagName("td")[4].getElementsByTagName("input")[0]; //获取girdview里第1列TextBox的值
                              v10.value = dlgResult[0];
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
              else if (obj == "TextBox8") {
              dlgResult = window.showModalDialog("../WDate.aspx", window, "dialogWidth:160px; dialogHeight:240px; status:0;");
                  if (dlgResult != undefined) {

                       table = document.getElementById('<%=GridView1.ClientID%>');
                       tr = table.getElementsByTagName("tr");
                      for (i = 1; i < tr.length; i++) {
                          if (obj1 == i) {
                              v1 = tr[i].getElementsByTagName("td")[8].getElementsByTagName("input")[0]; //获取girdview里第1列TextBox的值
                              v1.value = dlgResult;
                              break;
                          }
                      }
                  }
              }
              else if (obj == "TextBox13") {
                  dlgResult = window.showModalDialog("../BaseInfo/currency.aspx", window, "dialogWidth:970px; dialogHeight:490px; status:0");
                  if (dlgResult != undefined) {
                      var table2 = document.getElementById('<%=GridView1.ClientID%>');
                      var tr2 = table2.getElementsByTagName("tr");
                      for (i = 1; i < tr2.length; i++) {
                          
                              var v11 = tr2[i].getElementsByTagName("td")[6].getElementsByTagName("input")[0]; //获取girdview里第1列TextBox的值
                              v11.value = dlgResult[0]; 
                      }
                  }
              }
             else  if (obj == "Text12") {
                  dlgResult = window.showModalDialog("../BASEINFO/ReceivingAndDelivery.aspx", window, "dialogWidth:970px; dialogHeight:490px; status:0");
                  if (dlgResult != undefined) {

                      document.getElementById("RDID").value = dlgResult[0];
                      document.getElementById("Text12").value = dlgResult[2];
                      document.getElementById("Text13").value = dlgResult[4];
                  }
              }
              
              else if (obj == "Text15") {
                  dlgResult = window.showModalDialog("../BASEINFO/companyinfox.aspx", window, "dialogWidth:970px; dialogHeight:490px; status:0");
                  if (dlgResult != undefined) {

                      document.getElementById("COKEY").value = dlgResult[0];
                      document.getElementById("Text14").value = dlgResult[1];
                      document.getElementById("Text15").value = dlgResult[2];
                      document.getElementById("Text16").value = dlgResult[3];
                  }
              }
              else {
                  dlgResult = window.showModalDialog("../BaseInfo/EMPLOYEEINFO.aspx", window, "dialogWidth:970px; dialogHeight:490px; status:0;");
                  if (dlgResult != undefined) {

                      document.getElementById("Text4").value = dlgResult[0];
                      document.all("Label1").innerText =dlgResult[1];
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