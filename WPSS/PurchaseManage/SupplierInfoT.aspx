<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SupplierInfoT.aspx.cs" Inherits="WPSS.PurchaseManage.SupplierInfoT" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>编辑供应商信息</title>
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
                <div class ="c13101905">
      <div class="c13101906" id ="Div9">
          &gt;编辑供应商信息 </div>
     <div class="c13101907" id ="Div10">
 </div>
    </div>
  <div class ="c13110501">
      <div class="c13110502" id ="Div1">
   <span class="c13110508" id ="Span1">
       <asp:ImageButton ID="btnAdd" runat="server" ImageUrl="~/Image/btnAdd.png"    onclick="btnAdd_Click"  />
          </span>
       </div>
              <div class="c13110510" id ="Div3">
   <span class="c13110511" id ="Span4">
                  (新增)
          </span>
       </div>
             <div class="c13110502" id ="Div18">
   <span class="c13110508" id ="Span3">
       <asp:ImageButton ID="btnSave" runat="server" ImageUrl="~/Image/btnSave.png" 
                     onclick="btnSave_Click"  />
          </span>
       </div>
              <div class="c13110510" id ="Div19">
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
                 <div class="c13110510" id ="Div24">
   <span class="c13110511" id ="Span6">
                     (退出)
          </span>
       </div>
    </div>

<div  id="i13102301" class ="c13102101">
<span  class ="c13102102"><asp:Label ID="prompt" runat="server"  ForeColor="#f80707"></asp:Label></span>
</div> 
  <div class ="c13101902">
      <div class="c13101903" id ="Div2">
          供应商代码</div>
     <div class="c13101904" id ="Div4">
<input id="Text1" type="text"  runat="server"   readonly ="readonly" class="c13102103"/> 
         <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="Text1" Text="必填" runat="server" /></div>
         <div class="c13101903" id ="Div5">
             供应商名称</div>
     <div class="c13102401" id ="Div6">
   <input id="Text2" type="text"  runat ="server"  class ="c13111105" />
   <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="Text2" Text="必填" runat="server" /></div>
    <div class="c13101903" id ="Div25">
          联系人</div>
     <div class="c13101904" id ="Div26">
        <input id="Text7" type="text"  runat="server"    readonly ="readonly"  class="c13112201"/></div>
           </div>
           
           
           <div class ="c13101902">
 
    <div class="c13101903" id ="Div7">
          联系电话</div>
     <div class="c13101904" id ="Div8">
        <input id="Text3" type="text"  runat="server"    readonly ="readonly"  class="c13112201"/></div>
          <div class="c13101903" id ="Div12">
              传真号码</div>
     <div class="c13102401" id ="Div13">
   <input id="Text4" type="text"  runat ="server"   readonly ="readonly" class="c14111906" /> 
         </div>
                        <div class="c13101903" id ="Div11">
                            邮政编码</div>
     <div class="c13101904" id ="Div14">
   <input id="Text5" type="text"  runat ="server"  readonly ="readonly" class="c13112201"/> 
         </div>
           </div>
           
           
             <div class ="c13101902">
  
   
           <div class="c13101903" id ="Div16">
                 EMAIL</div>

     <div class="c13101904" id ="Div17">
   <input id="Text6" type="text"  runat ="server" readonly ="readonly" class="c13112201"/></div>
     <div class="c13101903" id ="Div15">
          付款方式</div>
     <div class="c13101904" id ="Div21">
 <span style =" margin-right :8px;">
   <asp:DropDownList ID="DropDownList1" runat="server" class="c14031402">
           <asp:ListItem>电汇</asp:ListItem>
           <asp:ListItem>承兑</asp:ListItem>
            <asp:ListItem>现金</asp:ListItem>
                    </asp:DropDownList></span>
         &nbsp;</div>
           </div>

                       <div class ="c13101902">
    
     
                  <div class="c13101903" id ="Div20">
                      地址</div>
     <div class="c14111908" id ="Div23">
                    <input id="Text8" type="text"  runat="server"  readonly ="readonly" class="c14111907"/></div>
                          <div class="c13101903" id ="Div27">
                              付款条件</div>
     <div class="c13101904" id ="Div28">
 <span style =" margin-right :8px;">
   <asp:DropDownList ID="DropDownList2" runat="server" class="c14031402">
           <asp:ListItem>月结30天</asp:ListItem>
           <asp:ListItem>预付30%</asp:ListItem>
            <asp:ListItem>款到发货</asp:ListItem>
           <asp:ListItem>货到付款</asp:ListItem>
            <asp:ListItem>票到付款</asp:ListItem>
            <asp:ListItem>预付100%</asp:ListItem>
           <asp:ListItem>月结45天</asp:ListItem>
            <asp:ListItem>月结60天</asp:ListItem>
             <asp:ListItem>月结90天</asp:ListItem>
              <asp:ListItem>月结120天</asp:ListItem>
             <asp:ListItem>月结150天</asp:ListItem>
                    </asp:DropDownList></span>
         &nbsp;</div>   
         </div>
                                  
                      <div class ="c13111601">
       <div class="c13101903" id ="Div35">
           添加信息</div>
     <div class="c13111503" id ="Div36">
     <span style =" margin-right :20px;  "><asp:Button ID="btnClear" runat="server" Text="清空" 
             onclick="btnClear_Click" /></span>
         <asp:Button ID="btnAddContractInfo" runat="server" Text="添加" 
             onclick="btnAddContactInfo_Click" />
</div>
 
         
             <span class ="c13112202">需先添加信息,然后单击联系人为默认联系信息</span></div>
<div class ="c13111602">
             
          
            <asp:GridView ID="GridView1" runat="server" 
                    AllowSorting="True"   
                    onrowdatabound="GridView1_RowDataBound" 
                        AutoGenerateColumns="False" style="margin-left: 8px" PageSize="15" 
                        CssClass ="c13121901"
                   >
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <Columns >
                            <asp:TemplateField HeaderText="SN"  Visible ="false"  >
                <ItemTemplate >
                                
                                <a >'<%#Eval ("项次") %>'</a>   
                </ItemTemplate>
                 <HeaderStyle Width="60px" />
                 <ItemStyle Width="60px"  ForeColor="#595d5a" />
            </asp:TemplateField>  
           <asp:TemplateField HeaderText="联系人" >
                <ItemTemplate >
      <asp:TextBox ID="TextBox1" runat="server"  Text='<%#Eval ("联系人") %>' Width ="60px" BackColor ="#e0efda"  CssClass ="c13120501"></asp:TextBox>   
                </ItemTemplate>
                 <HeaderStyle Width="60px" />
                 <ItemStyle Width="60px"  ForeColor="#595d5a" />
            </asp:TemplateField> 
               <asp:TemplateField HeaderText="联系电话">
                <ItemTemplate >
                 <asp:TextBox ID="TextBox2" runat="server" Text='<%#Eval ("联系电话") %>'  Width ="100px"   CssClass ="c13120501"></asp:TextBox>                     
                </ItemTemplate>
                 <HeaderStyle Width="80px" />
                 <ItemStyle Width="80px"  ForeColor="#595d5a"/>
            </asp:TemplateField> 
                    <asp:TemplateField HeaderText="传真号码">
                <ItemTemplate >
                 <asp:TextBox ID="TextBox3" runat="server" Text='<%#Eval ("传真号码") %>'  Width ="100px"  CssClass ="c13120501" ></asp:TextBox>                     
                </ItemTemplate>
                 <HeaderStyle Width="80px" />
                 <ItemStyle Width="80px"  ForeColor="#595d5a"/>
            </asp:TemplateField> 
                    <asp:TemplateField HeaderText="邮政编码">
                <ItemTemplate >
                 <asp:TextBox ID="TextBox4" runat="server"  Text='<%#Eval ("邮政编码") %>' Width ="60px"   CssClass ="c13120501"></asp:TextBox>                     
                </ItemTemplate>
                 <HeaderStyle Width="60px" />
                 <ItemStyle Width="60px"  ForeColor="#595d5a"/>
            </asp:TemplateField> 
      
                    <asp:TemplateField HeaderText="EMAIL">
                <ItemTemplate >
                 <asp:TextBox ID="TextBox5" runat="server" Text='<%#Eval ("EMAIL") %>'  Width ="150px"  CssClass ="c13120501"></asp:TextBox>                     
                </ItemTemplate>
                 <HeaderStyle Width="150px" />
                 <ItemStyle Width="150px"  ForeColor="#595d5a"/>
            </asp:TemplateField>
               <asp:TemplateField HeaderText="地址">
                <ItemTemplate >
                 <asp:TextBox ID="TextBox6" runat="server"  Width ="420px" BackColor ="#e0efda" ></asp:TextBox>                     
                </ItemTemplate>
                 <HeaderStyle Width="420px" />
                 <ItemStyle Width="420px"  ForeColor="#595d5a"/>
            </asp:TemplateField>  
           <asp:TemplateField HeaderText="部门">
                <ItemTemplate >
                 <asp:TextBox ID="TextBox7" runat="server"  Width ="100px"  ></asp:TextBox>                     
                </ItemTemplate>
                 <HeaderStyle Width="100px" />
                 <ItemStyle Width="100px"  ForeColor="#595d5a"/>
            </asp:TemplateField>  
                    </Columns>
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" Font-Bold="False" />   
                </asp:GridView>
                </div>
<div class ="c13102302">
           <asp:GridView ID="GridView2" runat="server" 
                    onrowdeleting="GridView2_RowDeleting" 
                    AllowSorting="True"   
                    onrowdatabound="GridView2_RowDataBound" 
                        onselectedindexchanged="GridView2_SelectedIndexChanged" 
                        AutoGenerateColumns="False" style="margin-left: 8px" PageSize="15" 
                        CssClass ="c13121901"
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
                      
             <asp:TemplateField HeaderText="联系人">
                <ItemTemplate >
                    <asp:LinkButton ID="LinkButton1" runat="server" CommandName="Select" 
                        Text='<%# Bind("CONTACT") %>'></asp:LinkButton>                     
                </ItemTemplate>
                 <HeaderStyle Width="80px" />
                 <ItemStyle Width="80px"  ForeColor="#595d5a"/>
            </asp:TemplateField>   
            <asp:BoundField DataField="PHONE" HeaderText="联系电话" >
                              <ItemStyle Width="120px"  ForeColor="#595d5a"/>
                                    <HeaderStyle HorizontalAlign="Center" Width="120px" />
                          </asp:BoundField>
                            <asp:BoundField DataField="FAX" HeaderText="传真号码" >
                              <ItemStyle Width="120px"  ForeColor="#595d5a"/>
                                    <HeaderStyle HorizontalAlign="Center" Width="120px" />
                          </asp:BoundField>
                            <asp:BoundField DataField="POSTCODE" HeaderText="邮政编码" >
                              <ItemStyle Width="60px"  ForeColor="#595d5a"/>
                                    <HeaderStyle HorizontalAlign="Center" Width="60px" />
                          </asp:BoundField>
                            <asp:BoundField DataField="EMAIL" HeaderText="EMAIL" >
                              <ItemStyle Width="180px"  ForeColor="#595d5a"/>
                                    <HeaderStyle HorizontalAlign="Center" Width="180px" />
                          </asp:BoundField>
                            <asp:BoundField DataField="ADDRESS" HeaderText="地址" >
                              <ItemStyle Width="500px"  ForeColor="#595d5a"/>
                                    <HeaderStyle HorizontalAlign="Center" Width="500px" />
                          </asp:BoundField>
                      <asp:BoundField DataField="DEPART" HeaderText="部门" >
                              <ItemStyle Width="100px"  ForeColor="#595d5a"/>
                                    <HeaderStyle HorizontalAlign="Center" Width="100px" />
                          </asp:BoundField>
                    </Columns>
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" Font-Bold="False" />   
                </asp:GridView>
                </div>
      <script type ="text/javascript" >
          window.onload = function onload1() {
              var Invocation = document.getElementById("hint").value;
              if (Invocation != "") {
                  document.getElementById("i13102301").style.display = "block";
                  document.all("prompt").innerText = Invocation;
              }
              else {
                  document.getElementById("i13102301").style.display = "none";
              }
          }
          function f13100202(obj, obj1) {
              var dlgResult;
                  if (obj == "TextBox1") {
                  dlgResult = window.showModalDialog("../BaseInfo/Companyinfo.aspx", window, "dialogWidth:970px; dialogHeight:490px; status:0");

                  if (dlgResult != undefined) {

                      var table = document.getElementById('<%=GridView1.ClientID%>');
                      var tr = table.getElementsByTagName("tr");
                      for (i = 1; i < tr.length; i++) {
                          if (obj1 == i) {
                              var v1 = tr[i].getElementsByTagName("td")[6].getElementsByTagName("input")[0]; //获取girdview里第1列TextBox的值
                              var v2 = tr[i].getElementsByTagName("td")[7].getElementsByTagName("input")[0];
                              var v3 = tr[i].getElementsByTagName("td")[8].getElementsByTagName("input")[0];
             
                              v1.value = dlgResult[0];
                              v2.value = dlgResult[1];
                              v3.value = dlgResult[2];
                     

                              break;
                          }
                      }


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