<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PURCHASE_PLANT.aspx.cs" Inherits="WPSS.MRP_MANAGE.PURCHASE_PLANT" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>发放采购计划</title>
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
          批次采购计划 </div>
     <div class="c13101907" id ="Div10">
 </div>
    </div>
<div id="i14073104" class ="c13110501">
              <div class="c13110507" id ="Div50">
                <span class="c13110503" id ="Span13">
    <asp:LinkButton ID="btnReconcile" runat="server" onclick="btnReconcile_Click" CssClass ="">发放采购单</asp:LinkButton>
    </span> 
   </div>
          
                 <div class="c13110510" id ="Div51">
   <span class="c13110511" id ="Span14">
                 
          </span>
       </div>
        
    </div>
<div  id="i13102301" class ="c13102101">
<span  class ="c13102102"><asp:Label ID="prompt" runat="server"  ForeColor="#f80707"></asp:Label></span>
</div> 
  <div id="i14073103" class ="c13101902">
         <div class="c13101903" id ="Div26">
             供应商ID</div>
     <div  class="c14031403" id ="Div27">
   <input id="Text2" type="text"  runat ="server"  class ="c13110901"  />
    <span style =" margin-left :5px; margin-right :2px;"><a  href="javascript:f13100202('Text2','');"> 
         选择</a></span>
       </div>
                <div class="c13101903" id ="Div5">
                    供应商名称</div>
     <div class="c14031403" id ="Div37">
     <input id="Text5" type="text"  runat ="server" class="c13112201" />
 </div>
                    <div class="c13101903" id ="Div28">
                        采购日期</div>
     <div class="c14120102" id ="Div29">
         <input id="Text3" type="text" runat="server" onclick ="f13100202('Text3')" readonly="readonly" class ="c14120104"/>
         <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="Text3" Text="必填" runat="server" />
         </div>
                               <div class="c13101903" id ="Div2">
                                   采购员工号</div>
     <div class="c14120103 " id ="Div4">
         <input id="Text4" type="text" runat="server"  class ="c14120101"/> 
        <a  href="javascript:f13100202('Text4','');"> 
         选择</a>
               <asp:Label ID="Label1" runat="server" Text="" ></asp:Label>
         </div>

           </div>
           <div id="i14073102" class ="c13111601">
     
               
     <div class="c14103101" id ="Div36">
      <span style="color :#990033">(同料号的采购项将被合并数量发放 需采购量=(采购数量/最小采购量)取整*最小采购量)</span>
</div>
<asp:CheckBox ID="CheckBox2" runat="server"  Text ="全选" oncheckedchanged="CheckBox2_CheckedChanged"  /> 
           <asp:CheckBox ID="CheckBox3" runat="server" Text ="反选" oncheckedchanged="CheckBox3_CheckedChanged" />
          </div>   
<div id="i14073101" class ="c14071601">
            
            <asp:GridView ID="GridView1" runat="server" 
                    AllowSorting="True"   
                    onrowdatabound="GridView1_RowDataBound" 
                        AutoGenerateColumns="False" PageSize="15" 
                             CssClass ="c14073101"
                   >
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <Columns > 
                        <asp:TemplateField HeaderText="选择" >
                <ItemTemplate >
                    <asp:CheckBox ID="CheckBox1" runat="server"  Checked='<%# Bind("选择")%>'   CssClass ="c14080104" />
                </ItemTemplate>
                 <HeaderStyle Width="4%" />
                 <ItemStyle Width="4%"  />
            </asp:TemplateField>
       
           <asp:TemplateField HeaderText="原物料编码">
                <ItemTemplate >
                 <asp:TextBox ID="TextBox4" runat="server"  Text='<%#Eval ("料号") %>' CssClass ="c14070203" ></asp:TextBox>                     
                </ItemTemplate>
               <HeaderStyle Width="8%" />
                 <ItemStyle Width="8%"  />
            </asp:TemplateField>
                    <asp:TemplateField HeaderText="原物料类别">
                <ItemTemplate >
                 <asp:TextBox ID="TextBox5" runat="server"  Text='<%#Eval ("品名") %>'  CssClass ="c14070203" ></asp:TextBox>                     
                </ItemTemplate>
                <HeaderStyle Width="8%" />
                 <ItemStyle Width="8%"  />
            </asp:TemplateField> 
             
               <asp:TemplateField HeaderText="规格"   >
                <ItemTemplate >
                 <asp:TextBox ID="TextBox6" runat="server"  Text='<%#Eval ("规格") %>'   CssClass ="c14070203"  ></asp:TextBox>                     
                </ItemTemplate>
                 <HeaderStyle Width="8%" />
                 <ItemStyle Width="8%"  />
            </asp:TemplateField> 
                         <asp:TemplateField HeaderText="品牌"  >
                <ItemTemplate >
                 <asp:TextBox ID="TextBox7" runat="server" Text='<%#Eval ("品牌") %>'  CssClass ="c14070203" ></asp:TextBox>                     
                </ItemTemplate>
                 <HeaderStyle Width="8%" />
                 <ItemStyle Width="8%"/>
            </asp:TemplateField> 
                          <asp:TemplateField HeaderText="原厂料号">
                <ItemTemplate >
                 <asp:TextBox ID="TextBox8" runat="server"  Text='<%#Eval ("客户料号") %>'  CssClass ="c14070103"></asp:TextBox>                     
                </ItemTemplate>
               <HeaderStyle Width="8%" />
                 <ItemStyle Width="8%"/>
            </asp:TemplateField>
   
      
                    <asp:TemplateField HeaderText="采购数量">
                <ItemTemplate >
                 <asp:TextBox ID="TextBox9" runat="server" Text='<%#Eval ("采购数量") %>' CssClass ="c14071615" ></asp:TextBox>                     
                </ItemTemplate>
                 <HeaderStyle Width="4%" />
                 <ItemStyle Width="4%"/>
            </asp:TemplateField>
                <asp:TemplateField HeaderText="默认供应商">
                <ItemTemplate >
                 <asp:TextBox ID="TextBox17" runat="server"  Text='<%#Eval ("供应商") %>' CssClass ="c14070203"  ></asp:TextBox>                     
                </ItemTemplate>
          <HeaderStyle Width="8%" />
                 <ItemStyle Width="8%"/>
            </asp:TemplateField> 
                 <asp:TemplateField HeaderText="最小采购量">
                <ItemTemplate >
                 <asp:TextBox ID="TextBox18" runat="server" Text='<%#Eval ("最小采购量") %>' CssClass ="c14071615" ></asp:TextBox>                     
                </ItemTemplate>
              <HeaderStyle Width="8%" />
                 <ItemStyle Width="8%"/>
            </asp:TemplateField>
              <asp:TemplateField HeaderText="需采购量">
                <ItemTemplate >
                 <asp:TextBox ID="TextBox19" runat="server" Text='<%#Eval ("需采购量") %>' CssClass ="c14071615" ></asp:TextBox>                     
                </ItemTemplate>
               <HeaderStyle Width="6%" />
                 <ItemStyle Width="6%"/>
            </asp:TemplateField>
              
                          <asp:TemplateField HeaderText="采购单位">
                <ItemTemplate >
                 <asp:TextBox ID="TextBox10" runat="server"  Text='<%#Eval ("采购单位") %>'  CssClass ="c14071616"></asp:TextBox>      
                                
                </ItemTemplate>
         <HeaderStyle Width="2%" />
                 <ItemStyle Width="2%"/>
            </asp:TemplateField> 
               
               <asp:TemplateField HeaderText="采购单价">
                <ItemTemplate >
                 <asp:TextBox ID="TextBox11" runat="server"  CssClass ="c14080103"></asp:TextBox>                     
                </ItemTemplate>
              <HeaderStyle Width="4%" />
                 <ItemStyle Width="4%"/>
            </asp:TemplateField> 
                          <asp:TemplateField HeaderText="币别">
                <ItemTemplate >
                 <asp:TextBox ID="TextBox12" runat="server"  Text='<%#Eval ("币别") %>'  CssClass ="c14071616"></asp:TextBox>      
                                 
                </ItemTemplate>
            <HeaderStyle Width="2%" />
                 <ItemStyle Width="2%"/>
            </asp:TemplateField>
                     <asp:TemplateField HeaderText="税率">
                <ItemTemplate >
                 <asp:TextBox ID="TextBox13" runat="server"  Text='<%#Eval ("税率") %>'  CssClass ="c14071616"></asp:TextBox>                     
                </ItemTemplate>
                <HeaderStyle Width="4%" />
                 <ItemStyle Width="4%"/>
            </asp:TemplateField> 
                     <asp:TemplateField HeaderText="需求日期">
                <ItemTemplate >
                 <asp:TextBox ID="TextBox14" runat="server"  Text='<%#Eval ("需求日期") %>'  CssClass ="c14080103" ></asp:TextBox>      
                              
                </ItemTemplate>
              <HeaderStyle Width="8%" />
                 <ItemStyle Width="8%"/>
            </asp:TemplateField> 
                    <asp:TemplateField HeaderText="备注">
                <ItemTemplate >
                 <asp:TextBox ID="TextBox15" runat="server"  Text='<%#Eval ("备注") %>'  CssClass ="c14080103"></asp:TextBox>                     
                </ItemTemplate>
                 <HeaderStyle Width="8%" />
                 <ItemStyle Width="8%"/>
            </asp:TemplateField>
                 <asp:TemplateField HeaderText="索引"  >
                <ItemTemplate >
                 <asp:TextBox ID="TextBox16" runat="server"  Text='<%#Eval ("PLKEY") %>'   CssClass ="c14071608"></asp:TextBox>                     
                </ItemTemplate>
                 <HeaderStyle Width="8%" />
                 <ItemStyle Width="8%" />
            </asp:TemplateField>
            
        
            
                           <asp:TemplateField HeaderText="采购计划批号" >
                <ItemTemplate >
                                <asp:TextBox ID="TextBox1" runat="server"  Text='<%#Eval ("采购计划批号") %>'  CssClass ="c14071608"    ></asp:TextBox>   
                               
                </ItemTemplate>
              <HeaderStyle Width="8%" />
                 <ItemStyle Width="8%"/>
            </asp:TemplateField> 
                              <asp:TemplateField HeaderText="项次" >
                <ItemTemplate >
                  <asp:TextBox ID="TextBox2" runat="server"  Text='<%#Eval ("项次") %>'  ReadOnly ="true" CssClass="c14071612" ></asp:TextBox>   
                               
                </ItemTemplate>
                <HeaderStyle Width="2%" />
                 <ItemStyle Width="2%"/>
            </asp:TemplateField>
           <asp:TemplateField HeaderText="ID" >
                <ItemTemplate >
                                <asp:TextBox ID="TextBox3" runat="server"  Text='<%#Eval ("品号") %>'  CssClass ="c14071608"   ></asp:TextBox>   
                                
                </ItemTemplate>
             <HeaderStyle Width="8%" />
                 <ItemStyle Width="8%"/>
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
                  document.getElementById("i14073101").style.display = "block";
                  document.getElementById("i14073102").style.display = "block";
                  document.getElementById("i14073103").style.display = "block";
                  document.getElementById("i14073104").style.display = "block";
              }
              else {
                  document.getElementById("i14073101").style.display = "none";
                  document.getElementById("i14073102").style.display = "none"
                  document.getElementById("i14073103").style.display = "none";
                  document.getElementById("i14073104").style.display = "none";
              }
          }

          function f13100202(obj, obj1) {
              var dlgResult;
              if (obj == "Text2") {
                  dlgResult = window.showModalDialog("../PURCHASEManage/Supplierinfo.aspx", window, "dialogWidth:970px; dialogHeight:490px; status:0");
                  if (dlgResult != undefined) {
                      document.getElementById("Text2").value = dlgResult[0];
                      document.getElementById("Text5").value = dlgResult[1];
                  }
              }
              else if (obj == "TextBox1") {
              dlgResult = window.showModalDialog("../BaseInfo/Wareinfo.aspx?CUID=" + document.getElementById("Text2").value + "&nature=PURCHASE_det", window, "dialogWidth:970px; dialogHeight:490px; status:0");

                  if (dlgResult != undefined) {

                      var table = document.getElementById('<%=GridView1.ClientID%>');
                      var tr = table.getElementsByTagName("tr");
                      for (i = 1; i < tr.length; i++) {
                          if (obj1 == i) {
                              var v0 = tr[i].getElementsByTagName("td")[0].getElementsByTagName("input")[0]; /*wareid*/
                              var v1 = tr[i].getElementsByTagName("td")[1].getElementsByTagName("input")[0];/*co_wareid*/
                              var v2 = tr[i].getElementsByTagName("td")[2].getElementsByTagName("input")[0];/*wname*/
                              var v3 = tr[i].getElementsByTagName("td")[3].getElementsByTagName("input")[0];/*spec*/
                              var v4 = tr[i].getElementsByTagName("td")[4].getElementsByTagName("input")[0];/*brand*/
                              var v5 = tr[i].getElementsByTagName("td")[5].getElementsByTagName("input")[0];/*cwareid*/
                              /*var v6 = tr[i].getElementsByTagName("td")[6].getElementsByTagName("input")[0]; pcount*/
                              
                              var v7 = tr[i].getElementsByTagName("td")[7].getElementsByTagName("input")[0]; /*mpa_unit*/
                              var v8 = tr[i].getElementsByTagName("td")[8].getElementsByTagName("input")[0]; /*currency*/
                              var v9 = tr[i].getElementsByTagName("td")[9].getElementsByTagName("input")[0]; /*sellunitprice*/
                              v0.value = dlgResult[0];
                              v1.value = dlgResult[1];
                              v2.value = dlgResult[2];
                              v3.value = dlgResult[6];
                              v4.value = dlgResult[11];
                              v5.value = dlgResult[3];
                              
                              v7.value = dlgResult[10];
                              v8.value = dlgResult[13];
                              v9.value = dlgResult[9];
                              document.getElementById("wareid").value = dlgResult[0];
                              break;
                          }
                      }
                  }
              }
              else if (obj == "TextBox10") {
              dlgResult = window.showModalDialog("../BaseInfo/unit.aspx?wareid=" + document.getElementById("wareid").value + "&nature=PURCHASE_det", window, "dialogWidth:970px; dialogHeight:490px; status:0");
                  if (dlgResult != undefined) {
                      var table1 = document.getElementById('<%=GridView1.ClientID%>');
                      var tr1 = table1.getElementsByTagName("tr");
                      for (i = 1; i < tr1.length; i++) {
                          if (obj1 == i) {
                              var v10 = tr1[i].getElementsByTagName("td")[7].getElementsByTagName("input")[0]; //获取girdview里第1列TextBox的值
                              v10.value = dlgResult[0];
                              break;
                          }
                      }
                  }

              }
              else if (obj == "TextBox12") {
                  dlgResult = window.showModalDialog("../BaseInfo/currency.aspx", window, "dialogWidth:970px; dialogHeight:490px; status:0");
                  if (dlgResult != undefined) {
                      var table2 = document.getElementById('<%=GridView1.ClientID%>');
                      var tr2 = table2.getElementsByTagName("tr");
                      for (i = 1; i < tr2.length; i++) {
                          if (obj1 == i) {
                              var v11 = tr2[i].getElementsByTagName("td")[9].getElementsByTagName("input")[0]; //获取girdview里第1列TextBox的值
                              v11.value = dlgResult[0];
                              break;
                          }
                      }
                  }
              }
              else if (obj == "TextBox14") {
                  dlgResult = window.showModalDialog("../WDate.aspx", window, "dialogWidth:160px; dialogHeight:240px; status:0;");
                  if (dlgResult != undefined) {

                      table = document.getElementById('<%=GridView1.ClientID%>');
                      tr = table.getElementsByTagName("tr");
                      for (i = 1; i < tr.length; i++) {
                          if (obj1 == i) {
                              v1 = tr[i].getElementsByTagName("td")[11].getElementsByTagName("input")[0]; //获取girdview里第1列TextBox的值
                              v1.value = dlgResult;
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
              else if (obj == "Text4") {
                  dlgResult = window.showModalDialog("../BaseInfo/EMPLOYEEINFO.aspx", window, "dialogWidth:970px; dialogHeight:490px; status:0;");
                  if (dlgResult != undefined) {

                      document.getElementById("Text4").value = dlgResult[0];
                      document.all("Label1").innerText =dlgResult[1];
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