<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReturnT.aspx.cs" Inherits="WPSS.PurchaseManage.ReturnT" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>编辑退货单</title>
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
       <input id="ControlFileDisplay" type="hidden"  runat="server" />
        <input id="x2" type="hidden"  runat="server" />
         <input id="CUKEY" type="hidden"  runat="server" />
                <div class ="c13101905">
      <div class="c13101906" id ="Div9">
          &gt;编辑退货单 </div>
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
                <div class="c13110507" id ="Div1">
                  <span class="c13110503" id ="Span7">

          </span>
   </div>
                 <div class="c13110510" id ="Div3">
   <span class="c13110511" id ="Span8">
          
          </span>
       </div>
    </div>
<div  id="i13102301" class ="c13102101">
<span  class ="c13102102"><asp:Label ID="prompt" runat="server"  ForeColor="#f80707"></asp:Label></span>
</div> 
  <div class ="c13101902">
      <div class="c13101903" id ="Div24">
          退货单号</div>
     <div class="c13111503" id ="Div25">
<input id="Text1" type="text"  runat="server"   readonly ="readonly"  class="c14112011"/> 
<asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="Text1" Text="必填" runat="server" /></div>
         <div class="c13101903" id ="Div26">
             采购单号</div>
     <div class="c13110801" id ="Div27">
   <input id="Text2" type="text"  runat ="server"  readonly ="readonly" class ="c14112009"  />
   <span style =" margin-left :2px; margin-right :2px;"><a  href="javascript:f13100202('Text2','');">
         选择</a></span> 
   <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="Text2" Text="必填" runat="server" />
       <asp:LinkButton 
             ID="btnSure" runat="server" onclick="btnSure_Click"  
            >确定</asp:LinkButton></div>
                    <div class="c13101903" id ="Div28">
                        退货日期</div>
     <div class="c13101904" id ="Div29">
         <input id="Text3" type="text" runat="server" onclick ="f13100202('Text3')" readonly="readonly" class ="c13110901"/>
         <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="Text3" Text="必填" runat="server" />
          </div>
           </div>
  <div class ="c13101902">
                      <div class="c13101903" id ="Div2">
                          退货员工号</div>
                          
     <div class="c13111503" id ="Div4">
         <input id="Text4" type="text" runat="server"  class ="c14112009"/>
          <span style =" margin-left :2px; margin-right :2px;"><a  href="javascript:f13100202('Text4','');">
         选择</a></span>
                   <asp:Label ID="Label1" runat="server" Text="" ></asp:Label>
   </div>
         <div class="c13101903" id ="Div5">
             供应商名称</div>
     <div class="c13102401" id ="Div6">
   <input id="Text5" type="text"  runat ="server"  class ="c13102103"  /></div>
           </div>
              <div class ="c14060302">
                  注：由于退货含只退货金额不退货数量的需求，所以退货未税金额，退货税额，退货含税金额都需用户自己输入。退货数量与退货金额无直接关联
           </div>
<div class ="c13111602" id="i13122801">
     
     
                  <asp:GridView ID="GridView1" runat="server" 
                    AllowSorting="True"   
                    onrowdatabound="GridView1_RowDataBound" 
                        AutoGenerateColumns="False" PageSize="15" 
                           CssClass ="c14062202" onrowdeleting="GridView1_RowDeleting"
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
                              <asp:TemplateField HeaderText="项次" >
                <ItemTemplate >
                  <asp:TextBox ID="TextBox1" runat="server"  Text='<%#Eval ("项次") %>'  ReadOnly ="true" CssClass="c14071612" ></asp:TextBox>   
                               
                </ItemTemplate>
               <HeaderStyle Width="2%" />
                 <ItemStyle Width="2%"  />
            </asp:TemplateField> 
          
                       <asp:TemplateField HeaderText="原物料编码">
                <ItemTemplate >
                 <asp:TextBox ID="TextBox5" runat="server"  Text='<%#Eval ("料号") %>' ReadOnly ="true" CssClass="c14071609" ></asp:TextBox>                     
                </ItemTemplate>
               <HeaderStyle Width="5%" />
                 <ItemStyle Width="5%"  />
            </asp:TemplateField> 
               <asp:TemplateField HeaderText="原物料类别">
                <ItemTemplate >
                 <asp:TextBox ID="TextBox3" runat="server" Text='<%#Eval ("品名") %>' ReadOnly ="true" CssClass="c14071610"></asp:TextBox>                     
                </ItemTemplate>
                <HeaderStyle Width="4%" />
                 <ItemStyle Width="4%"  />
            </asp:TemplateField> 
                   
           
         
                
                     <asp:TemplateField HeaderText="退货数量">
                <ItemTemplate >
                 <asp:TextBox ID="TextBox11" runat="server" Text='<%#Eval ("退货数量") %>'  CssClass ="c13112302"></asp:TextBox>                     
                </ItemTemplate>
                                  <HeaderStyle Width="3%" />
                 <ItemStyle Width="3%"  />
            </asp:TemplateField> 
       
                <asp:TemplateField HeaderText="仓库">
                <ItemTemplate >
                 <asp:TextBox ID="TextBox12" runat="server" Text='<%#Eval ("仓库") %>' CssClass="c14071617"></asp:TextBox>
                 <a  href="javascript:f13100202('TextBox12','<%#Eval ("项次1") %>');">选择 </a>                     
                </ItemTemplate>
                <HeaderStyle Width="5%" />
                 <ItemStyle Width="5%"  />
            </asp:TemplateField> 
                      <asp:TemplateField HeaderText="库位">
                <ItemTemplate >
                 <asp:TextBox ID="TextBox28" runat="server" Text='<%#Eval ("库位") %>'  CssClass="c14071617"></asp:TextBox>
                 <a  href="javascript:f13100202('TextBox28','<%#Eval ("项次1") %>');">选择 </a>                     
                </ItemTemplate>
                 <HeaderStyle Width="5%" />
                 <ItemStyle Width="5%"  />
            </asp:TemplateField> 
                <asp:TemplateField HeaderText="批号">
                <ItemTemplate >
                 <asp:TextBox ID="TextBox13" runat="server" Text='<%#Eval ("批号") %>' CssClass ="c13112302"></asp:TextBox>                     
                </ItemTemplate>
                <HeaderStyle Width="3%" />
                 <ItemStyle Width="3%"  />
            </asp:TemplateField> 
    <asp:TemplateField HeaderText="退货未税" >
                <ItemTemplate >
                 <asp:TextBox ID="TextBox23" runat="server" Text=' <%#DataBinder.Eval(Container.DataItem, "退货未税金额", "{0:F2}")%>'  CssClass ="c13112302"></asp:TextBox>                     
                </ItemTemplate>
                                      <HeaderStyle Width="3%" />
                 <ItemStyle Width="3%"  />
            </asp:TemplateField> 
                       <asp:TemplateField HeaderText="退货税额">
                <ItemTemplate >
                 <asp:TextBox ID="TextBox24" runat="server" Text=' <%#DataBinder.Eval(Container.DataItem, "退货税额", "{0:F2}")%>'  CssClass ="c13112302"></asp:TextBox>                     
                </ItemTemplate>
                                  <HeaderStyle Width="3%" />
                 <ItemStyle Width="3%"  />
            </asp:TemplateField> 
                       <asp:TemplateField HeaderText="退货含税">
                <ItemTemplate >
                 <asp:TextBox ID="TextBox25" runat="server" Text=' <%#DataBinder.Eval(Container.DataItem, "退货含税金额", "{0:F2}")%>'  CssClass ="c13112302"></asp:TextBox>                     
                </ItemTemplate>
                                 <HeaderStyle Width="3%" />
                 <ItemStyle Width="3%"  />
            </asp:TemplateField> 
                     <asp:TemplateField HeaderText="采购数量">
                <ItemTemplate >
                 <asp:TextBox ID="TextBox6" runat="server" Text='<%#Eval ("采购数量") %>' ReadOnly ="true"  CssClass ="c14071615"></asp:TextBox>                     
                </ItemTemplate>
                            <HeaderStyle Width="2%" />
                 <ItemStyle Width="2%"  />
            </asp:TemplateField>
                              <asp:TemplateField HeaderText="采购单位">
                <ItemTemplate >
                 <asp:TextBox ID="TextBox30" runat="server"   CssClass ="c14071616"></asp:TextBox>                     
                </ItemTemplate>
                          <HeaderStyle Width="4%" />
                 <ItemStyle Width="4%"  />
            </asp:TemplateField>
                             <asp:TemplateField HeaderText="采购单价">
                <ItemTemplate >
                 <asp:TextBox ID="TextBox7" runat="server" Text='<%#Eval ("采购单价") %>'    CssClass ="c14071615"></asp:TextBox>                     
                </ItemTemplate>
                               <HeaderStyle Width="2%" />
                 <ItemStyle Width="2%"  />
            </asp:TemplateField>
                                <asp:TemplateField HeaderText="税率">
                <ItemTemplate >
                 <asp:TextBox ID="TextBox8" runat="server" Text='<%#Eval ("税率") %>'  CssClass ="c14071616"></asp:TextBox>                     
                </ItemTemplate>
                 <HeaderStyle Width="2%" />
                 <ItemStyle Width="2%"  />
            </asp:TemplateField>
             <asp:TemplateField HeaderText="ID" >
                <ItemTemplate >
                                <asp:TextBox ID="TextBox2" runat="server"  Text='<%#Eval ("品号") %>' ReadOnly ="true" CssClass ="c14071608" ></asp:TextBox>   
                               
                </ItemTemplate>
                <HeaderStyle Width="4%" />
                 <ItemStyle Width="4%"  />
            </asp:TemplateField> 
             <asp:TemplateField HeaderText="规格">
                <ItemTemplate >
                 <asp:TextBox ID="TextBox4" runat="server" Text='<%#Eval ("规格") %>' ReadOnly ="true" CssClass ="c14070203"  ></asp:TextBox>                     
                </ItemTemplate>
                 <HeaderStyle Width="6%" />
                 <ItemStyle Width="6%"  />
            </asp:TemplateField> 
         
        <asp:TemplateField HeaderText="原厂料号">
                <ItemTemplate >
                 <asp:TextBox ID="TextBox100" runat="server" Text='<%#Eval ("客户料号") %>'  ReadOnly ="true" CssClass ="c14070103"></asp:TextBox>                     
                </ItemTemplate>
                 <HeaderStyle Width="5%" />
                 <ItemStyle Width="5%"  />
            </asp:TemplateField> 
             <asp:TemplateField HeaderText="累计入库">
                <ItemTemplate >
                 <asp:TextBox ID="TextBox14" runat="server" Text='<%#Eval("累计采购入库数量")%>'  ReadOnly ="true" CssClass="c14071615"></asp:TextBox>                     
                </ItemTemplate>
                               <HeaderStyle Width="5%" />
                 <ItemStyle Width="5%"  />
            </asp:TemplateField> 
                           <asp:TemplateField HeaderText="累计退货">
                <ItemTemplate >
                 <asp:TextBox ID="TextBox10" runat="server" Text='<%#Eval ("累计退货数量") %>' ReadOnly ="true"   CssClass="c14071615"></asp:TextBox>                     
                </ItemTemplate>
                              <HeaderStyle Width="5%" />
                 <ItemStyle Width="5%"  />
              
            </asp:TemplateField>
               <asp:TemplateField HeaderText="可退数量">
                <ItemTemplate >
                 <asp:TextBox ID="TextBox9" runat="server" Text='<%#Eval ("可退货数量") %>' ReadOnly ="true" CssClass="c14071615"></asp:TextBox>                     
                </ItemTemplate>
                             <HeaderStyle Width="5%" />
                 <ItemStyle Width="5%"  />
            </asp:TemplateField> 
                        <asp:TemplateField HeaderText="本退货单累计退货数量">
                <ItemTemplate >
                 <asp:TextBox ID="TextBox15" runat="server" Text='<%#Eval ("本退货单累计退货数量") %>'  ReadOnly ="true" CssClass ="c13112503"></asp:TextBox>                     
                </ItemTemplate>
               <HeaderStyle Width="8%" />
                 <ItemStyle Width="8%"  />
            </asp:TemplateField> 
                                 <asp:TemplateField HeaderText="备注">
                <ItemTemplate >
                 <asp:TextBox ID="TextBox16" runat="server"      CssClass ="c13120501"></asp:TextBox>                     
                </ItemTemplate>
              <HeaderStyle Width="6%" />
                 <ItemStyle Width="6%"  />
            </asp:TemplateField>
                            <asp:TemplateField HeaderText="累计退货未税金额" >
                <ItemTemplate >
                 <asp:TextBox ID="TextBox17" runat="server" Text=' <%#DataBinder.Eval(Container.DataItem, "累计退货未税金额", "{0:F2}")%>'    CssClass ="c13112503"></asp:TextBox>                     
                </ItemTemplate>
                 <HeaderStyle Width="11%" />
                 <ItemStyle Width="11%"  />
            </asp:TemplateField> 
                       <asp:TemplateField HeaderText="累计退货税额">
                <ItemTemplate >
                 <asp:TextBox ID="TextBox18" runat="server" Text=' <%#DataBinder.Eval(Container.DataItem, "累计退货税额", "{0:F2}")%>'   Width ="130px" CssClass ="c13112503"></asp:TextBox>                     
                </ItemTemplate>
                   <HeaderStyle Width="11%" />
                 <ItemStyle Width="11%"  />
            </asp:TemplateField> 
                       <asp:TemplateField HeaderText="累计退货含税金额">
                <ItemTemplate >
                 <asp:TextBox ID="TextBox19" runat="server" Text=' <%#DataBinder.Eval(Container.DataItem, "累计退货含税金额", "{0:F2}")%>'  Width ="130px" CssClass ="c13112503"></asp:TextBox>                     
                </ItemTemplate>
                  <HeaderStyle Width="11%" />
                 <ItemStyle Width="11%"  />
            </asp:TemplateField> 
               <asp:TemplateField HeaderText="可退货未税金额" >
                <ItemTemplate >
                 <asp:TextBox ID="TextBox20" runat="server" Text=' <%#DataBinder.Eval(Container.DataItem, "可退货未税金额", "{0:F2}")%>'   Width ="130px"   CssClass ="c13112503"></asp:TextBox>                     
                </ItemTemplate>
                   <HeaderStyle Width="11%" />
                 <ItemStyle Width="11%"  />
            </asp:TemplateField> 
                       <asp:TemplateField HeaderText="可退货税额">
                <ItemTemplate >
                 <asp:TextBox ID="TextBox21" runat="server" Text=' <%#DataBinder.Eval(Container.DataItem, "可退货税额", "{0:F2}")%>'   Width ="130px" CssClass ="c13112503"></asp:TextBox>                     
                </ItemTemplate>
                <HeaderStyle Width="11%" />
                 <ItemStyle Width="11%"  />
            </asp:TemplateField> 
                       <asp:TemplateField HeaderText="可退货含税金额">
                <ItemTemplate >
                 <asp:TextBox ID="TextBox22" runat="server" Text=' <%#DataBinder.Eval(Container.DataItem, "可退货含税金额", "{0:F2}")%>'  Width ="130px" CssClass ="c13112503"></asp:TextBox>                     
                </ItemTemplate>
                   <HeaderStyle Width="11%" />
                 <ItemStyle Width="11%"  />
            </asp:TemplateField> 
               
              <asp:TemplateField HeaderText="入库仓库">
                <ItemTemplate >
                 <asp:TextBox ID="TextBox26" runat="server" Text='<%#Eval ("入库仓库") %>' ReadOnly ="true" Width ="80px" CssClass ="c13112503"></asp:TextBox>                     
                </ItemTemplate>
                   <HeaderStyle Width="6%" />
                 <ItemStyle Width="6%"  />
            </asp:TemplateField> 
                    <asp:TemplateField HeaderText="入库库位">
                <ItemTemplate >
                 <asp:TextBox ID="TextBox29" runat="server" Text='<%#Eval ("入库库位") %>' ReadOnly ="true" Width ="80px" CssClass ="c13112503"></asp:TextBox>                     
                </ItemTemplate>
                   <HeaderStyle Width="6%" />
                 <ItemStyle Width="6%"  />
            </asp:TemplateField>
                    <asp:TemplateField HeaderText="入库批号">
                <ItemTemplate >
                 <asp:TextBox ID="TextBox27" runat="server" Text='<%#Eval ("入库批号") %>' ReadOnly ="true" Width ="80px" CssClass ="c13112503"></asp:TextBox>                     
                </ItemTemplate>
                 <HeaderStyle Width="6%" />
                 <ItemStyle Width="6%"  />
            </asp:TemplateField>
                    </Columns>
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" Font-Bold="False" />   
                </asp:GridView>
         
                </div>

                   <div id ="i13111501" class ="c13101902">
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
                <div id="i13103001" class ="c13102201">
          
                    <asp:GridView ID="GridView2" runat="server"  CssClass ="c13112502"  onrowdatabound="GridView2_RowDataBound1" >
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

           
                  document.getElementById("i13122801").style.display = "block";
                  document.getElementById("i13111501").style.display = "block";

              }
              else {

               
                  document.getElementById("i13122801").style.display = "none";
                  document.getElementById("i13111501").style.display = "none";

              }
          }

          function f13100202(obj, obj1) {
              var dlgResult;
              if (obj == "Text2") {
              dlgResult = window.showModalDialog("../purchaseManage/purchase.aspx", window, "dialogWidth:970px; dialogHeight:490px; status:0");
                  if (dlgResult != undefined) {

                      document.getElementById("Text2").value = dlgResult[0];
                      document.getElementById("Text5").value = dlgResult[1];
             
                  
             

                  }
              }
              else if (obj == "TextBox12") {
                  dlgResult = window.showModalDialog("../StockManage/StorageINFO.aspx", window, "dialogWidth:970px; dialogHeight:490px; status:0");

                  if (dlgResult != undefined) {

                      var table = document.getElementById('<%=GridView1.ClientID%>');
                      var tr = table.getElementsByTagName("tr");
                      for (i = 1; i < tr.length; i++) {
                          if (obj1 == i) {
                              var v5 = tr[i].getElementsByTagName("td")[5].getElementsByTagName("input")[0];
                              v5.value = dlgResult[1];
                              break;
                          }
                      }


                  }

              }
              else if (obj == "TextBox28") {
                  dlgResult = window.showModalDialog("../StockManage/Storage_location.aspx", window, "dialogWidth:970px; dialogHeight:490px; status:0");

                  if (dlgResult != undefined) {

                      var table1 = document.getElementById('<%=GridView1.ClientID%>');
                      var tr1 = table1.getElementsByTagName("tr");
                      for (i = 1; i < tr1.length; i++) {
                          if (obj1 == i) {
                              var v6 = tr1[i].getElementsByTagName("td")[6].getElementsByTagName("input")[0];
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