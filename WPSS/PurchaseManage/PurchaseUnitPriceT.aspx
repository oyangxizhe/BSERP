<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PurchaseUnitPriceT.aspx.cs" Inherits="WPSS.PurchaseManage.PurchaseUnitPriceT" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>编辑采购核价单</title>
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
    <input id="suid" type="hidden"  runat="server" />
                <div class ="c13101905">
      <div class="c13101906" id ="Div9">
>编辑采购核价单 </div>
     <div class="c13101907" id ="Div10">
 </div>
    </div>
<div class ="c13110501">
      <div class="c13110502" id ="Div2">
   <span class="c13110508" id ="Span1">
       <asp:ImageButton ID="btnAdd" runat="server" ImageUrl="~/Image/btnAdd.png"    onclick="btnAdd_Click"  />
          </span>
       </div>
              <div class="c13110510" id ="Div4">
   <span class="c13110511" id ="Span4">
(新增)
          </span>
       </div>
             <div class="c13110502" id ="Div5">
   <span class="c13110508" id ="Span3">
       <asp:ImageButton ID="btnSave" runat="server" ImageUrl="~/Image/btnSave.png" 
                     onclick="btnSave_Click"  />
          </span>
       </div>
              <div class="c13110510" id ="Div6">
   <span class="c13110511" id ="Span5">
(保存)
          </span>
       </div>
          
         <div class="c13110507" id ="Div21">
                  <span class="c13110503" id ="Span2">
     <asp:ImageButton ID="btnExit" 
                 runat="server" ImageUrl="~/Image/btnExit.png" Width="60px" 
                      onclick="btnExit_Click" />
          </span>
   </div>
                 <div class="c13110510" id ="Div15">
   <span class="c13110511" id ="Span6">
                     (退出)
          </span>
       </div>
    </div>
<div  id="i13102301" class ="c13102101">
<span  class ="c13102102"><asp:Label ID="prompt" runat="server"  ForeColor="#f80707"></asp:Label></span>
</div> 

 <div class ="c13101902">
      <div class="c13122302" id ="Div1">
          代码</div>
     <div class="c14031403" id ="Div3">
<input id="Text1" type="text"  runat="server"   readonly ="readonly" class="c14031401"/> 
         </div>
                 <div class="c13122302" id ="Div12">
              ID</div>
     <div class="c14031403" id ="Div13">
   <input id="Text2" type="text"    runat ="server" class ="c14031405" /> 
        <span style =" margin-left :5px"> <a  href="javascript:f13100202('Text2');">选择</a></span> 
        </div>
                  <div class="c13122302" id ="Div11">
                     原物料编码</div>
     
  <div class="c14031403" id ="Div14">
   <input id="Text3" type="text"  runat ="server" class ="c14040704" /> </div>
         <div class="c13122302" id ="Div7">
          物料类别</div>
     <div class="c14120501" id ="Div8">
<input id="Text4" type="text"  runat="server"   readonly ="readonly" class="c14040704"/> 
         </div>
           </div>
           <div class ="c13101902">

                 <div class="c13122302" id ="Div18">
              原厂料号</div>
     <div class="c14031403" id ="Div19">
   <input id="Text5" type="text"    runat ="server" class ="c14040704" /> 
     </div>
                  <div class="c13122302" id ="Div20">
                      供应商</div>
     
  <div class="c14031403" id ="Div22">
   <input id="Text6" type="text"    runat ="server" class ="c14031405" /> 
        <span style =" margin-left :5px"> <a  href="javascript:f13100202('Text6');">选择</a></span> 
        </div>
                            <div class="c13122302" id ="Div16">
                     采购单价</div>
     <div class="c14031403" id ="Div17">
   <input id="Text7" type="text"    runat ="server"  class ="c14120106"/> (未税)
         </div>
                          <div class="c13122302" id ="Div26">
                     币别</div>
     <div class="c14120501" id ="Div35">
    <span style =" margin-right :8px;">
   <asp:DropDownList ID="DropDownList1" runat="server" CssClass="c14072802">
                    </asp:DropDownList><asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="DropDownList1" Text="必填" runat="server" /></span>
         </div>
           </div> 
           <div class ="c13122402">

          <div class="c13122302" id ="Div108">
                 备注</div>
     <div class="c13122401" id ="Div109">

         <asp:TextBox ID="TextBox1" runat="server"   TextMode="MultiLine" CssClass ="c13122403"></asp:TextBox>
         </div>
                        <div class ="c14031406">
               <div class="c13122302" id ="Div23">
         上传资料
                 </div>
          
     <div class="c13102203" id ="Div24">
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
            <div class="c13102301" id ="Div25">
            <span style =" float :left ; margin-left :30px;">   <asp:Button ID="Button1" runat="server" onclick="btnOnloadFile_Click" 
               Text="上传" /></span>
        <span style=" margin-left :20px; color :Red ;">注：上传的单个附件大小需小于20M</span>
                 </div>
</div><div class ="c14031406">
     <asp:GridView ID="GridView1" runat="server" Width="58%" 
                    onrowdeleting="GridView1_RowDeleting" 
                    AllowSorting="True"   
                    onrowdatabound="GridView1_RowDataBound" 
                        onselectedindexchanged="GridView1_SelectedIndexChanged" 
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
                </div> 
      <script type ="text/javascript" >
          window.onload = function onload1() {
              document.getElementById("suid").value = "";
              var Invocation = document.getElementById("hint").value;
              if (Invocation != "") {
                  document.getElementById("i13102301").style.display = "block";
                  document.all("prompt").innerText = Invocation;
              }
              else {
                  document.getElementById("i13102301").style.display = "none";
              }

          }
          function f13100202(obj) {
              var dlgResult;
              if (obj == "Text2") {
                  dlgResult = window.showModalDialog("../baseinfo/wareinfo.aspx?CUID=" + document.getElementById("suid").value +
                   "&nature=purchase_unitprice", window, "dialogWidth:960px; dialogHeight:480px; status:0");
                  if (dlgResult != undefined) {

                      document.getElementById("Text2").value = dlgResult[0];
                      document.getElementById("Text3").value = dlgResult[1];
                      document.getElementById("Text4").value = dlgResult[2];
                      document.getElementById("Text5").value = dlgResult[3];
                      document.getElementById("Text6").value = dlgResult[4];
                  }
              }
              else if (obj == "Text6") {
                  dlgResult = window.showModalDialog("../PurchaseManage/Supplierinfo.aspx", window, "dialogWidth:960px; dialogHeight:480px; status:0");
                  if (dlgResult != undefined) {
                      document.getElementById("suid").value = dlgResult[0];
                      document.getElementById("Text6").value = dlgResult[1];
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