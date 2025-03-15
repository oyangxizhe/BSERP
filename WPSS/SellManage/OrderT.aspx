<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OrderT.aspx.cs" Inherits="WPSS.SellManage.OrderT" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>编辑订单信息</title>
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
        <input id="x2" type="hidden"  runat="server" />
                <div class ="c13101905">
      <div class="c13101906" id ="Div9">
          &gt;编辑订单信息 </div>
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
       <div class="c13110507" id ="Div44">
                <span class="c13110503" id ="Span10">
    <asp:LinkButton ID="btnAudit" runat="server" onclick="btnAudit_Click" CssClass ="">审核</asp:LinkButton>
    </span> 
   </div>
          
                 <div class="c13110510" id ="Div45">
   <span class="c13110511" id ="Span11">
                 
          </span>
       </div>
                       <div class="c13110507" id ="Div46">
                <span class="c13110503" id ="Span12">
    <asp:LinkButton ID="btnReductionAudit" runat="server" onclick="btnReductionAudit_Click" CssClass ="">撤销审核</asp:LinkButton>
    </span> 
   </div>
        <div class="c13110507" id ="Div32">
                <span class="c13110503" id ="Span7">
    <asp:LinkButton ID="btnReconcile" runat="server" onclick="btnReconcile_Click" CssClass ="">确认对帐</asp:LinkButton>
    </span> 
   </div>
          
                 <div class="c13110510" id ="Div33">
   <span class="c13110511" id ="Span8">
                 
          </span>
       </div>
                       <div class="c13110507" id ="Div34">
                <span class="c13110503" id ="Span9">
    <asp:LinkButton ID="btnReductionReconcil" runat="server" onclick="btnReductionReconcile_Click" CssClass ="">对帐还原</asp:LinkButton>
    </span> 
   </div>
    </div>
<div  id="i13102301" class ="c13102101">
<span  class ="c13102102"><asp:Label ID="prompt" runat="server"  ForeColor="#f80707"></asp:Label></span>
</div> 
  <div class ="c13101902">
      <div class="c13101903" id ="Div24">
          订单号</div>
     <div class="c13102904" id ="Div25">
<input id="Text1" type="text"  runat="server"   readonly ="readonly" class="c14031401"
            /> 
         <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="Text1" Text="必填" runat="server" /></div>
         <div class="c13101903" id ="Div26">
             客户ID</div>
     <div class="c14031403" id ="Div27">
   <input id="Text2" type="text"  runat ="server" class ="c14031405"  /> 
      <span style =" margin-left :5px"><a  href="javascript:f13100202('Text2','');">选择 </a></span> 
         </div>
    <div class="c13101903" id ="Div42">
                          客户代码</div>
     <div class="c13102904" id ="Div43">
         <input id="Text12" type="text" runat="server"  class ="c13102103"/> 
         </div>
                            <div class="c13101903" id ="Div28">
                                订单日期</div>
     <div class="c14120501" id ="Div29">
         <input id="Text3" type="text" runat="server" onclick ="f13100202('Text3')"  class ="c13110901"  readonly ="readonly"/>
         <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="Text3" Text="必填" runat="server" />
         </div>
           </div>
  <div class ="c13101902">
 
     <div class="c13101903" id ="Div30">
           业务员工号</div>
     <div class="c14120312" id ="Div31">
<input id="Text10" type="text" runat="server" class ="c14120310" />
<a  href="javascript:f13100202('Text10','');">选择 </a>
 <span style =" margin-left :1%"><asp:Label ID="Label1" runat="server" Text="" ></asp:Label></span>
</div>
         <div class="c14120311" id ="Div5">
             客户名称</div>
    <div class="c14120309" id ="Div6">
     <input id="Text5" type="text"  runat ="server" class="c13112201" />
 </div>
 <div class="c13101903" id ="Div38">
                          联系人</div>
     <div class="c14120501"  id ="Div39">
         <input id="Text4" type="text" runat="server"  class ="c13102103"/> 
         </div>
           </div>
       <div class ="c13101902">
     
       <div class="c13101903" id ="Div1">
                   公司地址</div>
     <div class="c14070401" id ="Div3">
           <input id="Text6" type="text"  runat="server"   class="c14112004"/></div>
         <div class="c13101903" id ="Div40">
              联系电话</div>
     <div class="c14120501" id ="Div41">
   <input id="Text11" type="text"  runat ="server"  class ="c13102103"  /></div>

           </div>
           <div class ="c13101902">
  
            <div class="c13101903" id ="Div15">
                客户订单号</div>
     <div class="c13102904" id ="Div21">
   <input id="Text13" type="text"  runat ="server"  class ="c14031601" /></div>

           </div>
           
<div class ="c13111601">
       <div class="c13101903" id ="Div35">
           添加品号信息</div>
     <div class="c13111503" id ="Div36">
      <span style="color :#990033">(税率输入17即17个点)</span>
</div>
</div>
<div class ="c14071602">
             
          <asp:GridView ID="GridView1" runat="server" 
                    AllowSorting="True"   
                    onrowdatabound="GridView1_RowDataBound" 
                        AutoGenerateColumns="False" PageSize="15" 
                        CssClass ="c13112304" 
                   >
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <Columns > 
           <asp:TemplateField HeaderText="ID" >
                <ItemTemplate >
                                <asp:TextBox ID="TextBox1" runat="server"   CssClass ="c14071603"    ></asp:TextBox>   
                                 <a  href="javascript:f13100202('TextBox1','<%#Eval ("项次") %>');">选择</a> 
                </ItemTemplate>
                 <HeaderStyle Width="5%" />
                 <ItemStyle Width="5%" />
            </asp:TemplateField> 
               <asp:TemplateField HeaderText="厂内成品料号">
                <ItemTemplate >
                 <asp:TextBox ID="TextBox2" runat="server"  CssClass ="c13120501" ></asp:TextBox>                     
                </ItemTemplate>
              <HeaderStyle Width="5%" />
                 <ItemStyle Width="5%" />
            </asp:TemplateField>
                    <asp:TemplateField HeaderText="品名">
                <ItemTemplate >
                 <asp:TextBox ID="TextBox3" runat="server"   CssClass ="c13120501" ></asp:TextBox>                     
                </ItemTemplate>
                <HeaderStyle Width="4%" />
                 <ItemStyle Width="4%" />
            </asp:TemplateField> 
         
                         
                    <asp:TemplateField HeaderText="订单数量">
                <ItemTemplate >
                 <asp:TextBox ID="TextBox6" runat="server" CssClass ="c13112302"  ></asp:TextBox>                     
                </ItemTemplate>
                 <HeaderStyle Width="2%" />
                 <ItemStyle Width="2%" />
            </asp:TemplateField>
               <asp:TemplateField HeaderText="销售单价">
                <ItemTemplate >
                 <asp:TextBox ID="TextBox7" runat="server" CssClass ="c13112302"></asp:TextBox>                     
                </ItemTemplate>
               <HeaderStyle Width="2%" />
                 <ItemStyle Width="2%" />
            </asp:TemplateField>
                                  <asp:TemplateField HeaderText="币别">
                <ItemTemplate >
                 <asp:TextBox ID="TextBox14" runat="server"  Text='<%#Eval ("币别") %>'  CssClass ="c14120401"></asp:TextBox>      
                    <a  href="javascript:f13100202('TextBox14','<%#Eval ("项次") %>');"> 选择</a>                
                </ItemTemplate>
                <HeaderStyle Width="3%" />
                 <ItemStyle Width="3%" />
            </asp:TemplateField> 
                     <asp:TemplateField HeaderText="税率">
                <ItemTemplate >
                 <asp:TextBox ID="TextBox8" runat="server" Text='<%#Eval ("税率") %>'   CssClass ="c13112302"></asp:TextBox>                     
                </ItemTemplate>
                <HeaderStyle Width="2%" />
                 <ItemStyle Width="2%" />
            </asp:TemplateField> 
   
                          <asp:TemplateField HeaderText="交货日期">
                <ItemTemplate >
                 <asp:TextBox ID="TextBox9" runat="server"  Text='<%#Eval ("交货日期") %>' CssClass ="c14071603" ></asp:TextBox>      
                    <a  href="javascript:f13100202('TextBox9','<%#Eval ("项次") %>');"> 选择</a>                
                </ItemTemplate>
                <HeaderStyle Width="5%" />
                 <ItemStyle Width="5%" />
            </asp:TemplateField> 
              <asp:TemplateField HeaderText="入库前置">
                <ItemTemplate >
                 <asp:TextBox ID="TextBox10" runat="server" Text='<%#Eval ("前置天数") %>'  CssClass ="c14120202"></asp:TextBox>                     
                </ItemTemplate>
               <HeaderStyle Width="2%" />
                 <ItemStyle Width="2%" />
            </asp:TemplateField> 
                         <asp:TemplateField HeaderText="需求日期">
                <ItemTemplate >
                 <asp:TextBox ID="TextBox11" runat="server" Text='<%#Eval ("需求日期") %>' ReadOnly ="true" CssClass ="c14070203"  ></asp:TextBox>                     
                </ItemTemplate>
                <HeaderStyle Width="3%" />
                 <ItemStyle Width="3%" />
            </asp:TemplateField> 
                                     <asp:TemplateField HeaderText="备料前置">
                <ItemTemplate >
                 <asp:TextBox ID="TextBox12" runat="server"  Text='<%#Eval ("备料前置") %>'  CssClass ="c14120202"></asp:TextBox>                     
                </ItemTemplate>
                  <HeaderStyle Width="2%" />
                 <ItemStyle Width="2%" />
            </asp:TemplateField> 
         
                       <asp:TemplateField HeaderText="规格"  >
                <ItemTemplate >
                 <asp:TextBox ID="TextBox5" runat="server"   CssClass ="c14070203" ></asp:TextBox>                     
                </ItemTemplate>
                 <HeaderStyle Width="5%" />
                 <ItemStyle Width="5%" />
                 
            </asp:TemplateField> 
                <asp:TemplateField HeaderText="客户料号">
                <ItemTemplate >
                 <asp:TextBox ID="TextBox4" runat="server"   CssClass ="c14070103"></asp:TextBox>                     
                </ItemTemplate>
                <HeaderStyle Width="5%" />
                 <ItemStyle Width="5%" />
            </asp:TemplateField>
                        <asp:TemplateField HeaderText="备注">
                <ItemTemplate >
                 <asp:TextBox ID="TextBox13" runat="server"    Width ="100px"  CssClass ="c13120501"></asp:TextBox>                     
                </ItemTemplate>
                    <HeaderStyle Width="6%" />
                 <ItemStyle Width="6%" />
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
                               <asp:BoundField DataField="料号" HeaderText="厂内成品料号" >
                              <ItemStyle  CssClass ="c14072705" />
                                    <HeaderStyle Width="80px" HorizontalAlign="Center" />
                          </asp:BoundField>
            <asp:BoundField DataField="品名" HeaderText="品名" >
                              <ItemStyle CssClass="c14072702" />
                                    <HeaderStyle  HorizontalAlign="Center" />
                          </asp:BoundField> 
       <asp:BoundField DataField="客户料号" HeaderText="客户料号" >
                              <ItemStyle CssClass="c14072704" />
                                    <HeaderStyle HorizontalAlign="Center" />
                          </asp:BoundField>
            <asp:BoundField DataField="订单数量" HeaderText="订单数量" >
                              <ItemStyle Width="80px"  ForeColor="#595d5a"  HorizontalAlign="Right" />
                                    <HeaderStyle Width="80px" HorizontalAlign="Center" />
                          </asp:BoundField>
                          
            <asp:BoundField DataField="销售单价" HeaderText="销售单价" >
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
                            <asp:BoundField DataField="交货日期" HeaderText="交货日期"   >
                              <ItemStyle Width="80px"  ForeColor="#595d5a" HorizontalAlign="Center" />
                                    <HeaderStyle Width="80px" HorizontalAlign="Center" />
                          </asp:BoundField>
                                <asp:BoundField DataField="前置天数" HeaderText="前置天数"  >
                              <ItemStyle Width="80px"  ForeColor="#595d5a" HorizontalAlign="Center" />
                                    <HeaderStyle Width="80px" HorizontalAlign="Center" />
                          </asp:BoundField>
                            <asp:BoundField DataField="需求日期" HeaderText="需求日期"   >
                              <ItemStyle Width="80px"  ForeColor="#595d5a" HorizontalAlign="Center" />
                                    <HeaderStyle Width="80px" HorizontalAlign="Center" />
                          </asp:BoundField>
             <asp:BoundField DataField="备料前置" HeaderText="备料前置"   >
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
                
             <div class ="c14041501">
               <div class="c13122302" id ="Div2">
                   上传资料
                 </div>
          
     <div class="c13102203" id ="Div4">
             <asp:DataList ID="DataList1" runat="server" RepeatColumns="1"   >
                 　<ItemTemplate >    
<div style="float:left; width:30px; height:30px; border:0px solid #0000FF; display:none ;">
<%#Eval ("C") %></div>
<input id="File2" type="file" name="File" runat="server" style="width: 300px;  margin-top :5px; margin-left :5px;   border-style: groove; border-width: thin;
"/>
   </div>  
</ItemTemplate> 　
</asp:DataList>
</div>
            <div class="c13102301" id ="Div37">
            <span style =" float :left ; margin-left :30px;">   <asp:Button ID="Button1" runat="server" onclick="btnOnloadFile_Click" 
               Text="上传" /></span>
        <span style=" margin-left :20px; color :Red ;">注：上传的单个附件大小需小于20M</span>
         
                 </div>
</div>
<div class ="c14041501">
     <asp:GridView ID="GridView4" runat="server" Width="58%" 
                    onrowdeleting="GridView4_RowDeleting" 
                    AllowSorting="True"   
                    onrowdatabound="GridView4_RowDataBound" 
                        onselectedindexchanged="GridView4_SelectedIndexChanged" 
                        AutoGenerateColumns="False" style="margin-left: 8px" PageSize="15" 
                        CssClass ="c13102001"
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
                            <asp:BoundField DataField="FLKEY" HeaderText="文件"   Visible ="false" >
                              <ItemStyle Width="500px" ForeColor="#595d5a" />
                                    <HeaderStyle HorizontalAlign="Center" Width="120px" />
                          </asp:BoundField>
             <asp:TemplateField HeaderText="点击打开文件">
                <ItemTemplate >
                    <asp:LinkButton ID="LinkButton1" runat="server" CommandName="Select" 
                        Text='<%# Bind("oldfilename") %>'></asp:LinkButton>                     
                </ItemTemplate>
                 <HeaderStyle Width="150px" />
                 <ItemStyle Width="150px"  ForeColor="#595d5a"/>
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
                  dlgResult = window.showModalDialog("../SellManage/Customerinfo.aspx", window, "dialogWidth:970px; dialogHeight:490px; status:0");
                  if (dlgResult != undefined) {

                      document.getElementById("Text2").value = dlgResult[0];
                      document.getElementById("Text5").value = dlgResult[1];
                      document.getElementById("Text6").value = dlgResult[2];
                      document.getElementById("Text4").value = dlgResult[3];
                      document.getElementById("Text11").value = dlgResult[4];
                  }
              }
              else if (obj == "TextBox1") {
              dlgResult = window.showModalDialog("../BaseInfo/Wareinfo.aspx?CUID=" + document.getElementById("Text2").value + "&nature=order_det", window, "dialogWidth:970px; dialogHeight:490px; status:0");

                  if (dlgResult != undefined) {

                      var table = document.getElementById('<%=GridView1.ClientID%>');
                      var tr = table.getElementsByTagName("tr");
                      for (i = 1; i < tr.length; i++) {
                          if (obj1 == i) {
                             


                              tr[i].getElementsByTagName("td")[0].getElementsByTagName("input")[0].value = dlgResult[0];
                              tr[i].getElementsByTagName("td")[1].getElementsByTagName("input")[0].value = dlgResult[1];
                              tr[i].getElementsByTagName("td")[2].getElementsByTagName("input")[0].value = dlgResult[2];
                              
                              tr[i].getElementsByTagName("td")[4].getElementsByTagName("input")[0].value = dlgResult[5];

                              tr[i].getElementsByTagName("td")[11].getElementsByTagName("input")[0].value = dlgResult[6];
                              tr[i].getElementsByTagName("td")[12].getElementsByTagName("input")[0].value = dlgResult[3];

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
              else if (obj == "TextBox9") {
                  dlgResult = window.showModalDialog("../WDate.aspx", window, "dialogWidth:160px; dialogHeight:240px; status:0;");
                  if (dlgResult != undefined) {

                      table = document.getElementById('<%=GridView1.ClientID%>');
                      tr = table.getElementsByTagName("tr");
                      for (i = 1; i < tr.length; i++) {
                          if (obj1 == i) {
                              v1 = tr[i].getElementsByTagName("td")[7].getElementsByTagName("input")[0]; //获取girdview里第1列TextBox的值
                              v1.value = dlgResult;
                              break;
                          }
                      }


                  }

              }
              else if (obj == "TextBox14") {
                  dlgResult = window.showModalDialog("../BaseInfo/currency.aspx", window, "dialogWidth:970px; dialogHeight:490px; status:0");
                  if (dlgResult != undefined) {
                      var table2 = document.getElementById('<%=GridView1.ClientID%>');
                      var tr2 = table2.getElementsByTagName("tr");
                      for (i = 1; i < tr2.length; i++) {
                          var v11 = tr2[i].getElementsByTagName("td")[5].getElementsByTagName("input")[0]; //获取girdview里第1列TextBox的值
                          v11.value = dlgResult[0];
                      }
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
