<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MISC_PICKINGT.aspx.cs" Inherits="WPSS.STOCKMANAGE.MISC_PICKINGT" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>�༭����������Ϣ</title>
<meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" /> 
<meta name ="Description" content ="ERP����ϵͳ" />
<meta name ="keywords" content ="ERP����ϵͳ,ERP�������,ERP,С΢��ҵ����ϵͳ,ϣ�����" />
       <link href ="../Css/SSBase.css"  type ="text/css" rel ="Stylesheet" />
       <link href ="../Css/S131017.css"  type ="text/css" rel ="Stylesheet" />
    </head>
<body >
   <form id="form1" runat="server">
    <input id="cuid" type="hidden"  runat="server" />
   <input id="hint" type="hidden"  runat="server" />
      <input id="x" type="hidden"  runat="server" />
       <input id="ControlFileDisplay" type="hidden"  runat="server" />
        <input id="x2" type="hidden"  runat="server" />
         <input id="CUKEY" type="hidden"  runat="server" />
                <div class ="c13101905">
      <div class="c13101906" id ="Div9">
          &gt;�༭����������ҵ </div>
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
                  (����)
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
                  (����)
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
                     (�˳�)
          </span>
       </div>
                <div class="c13110507" id ="Div1">
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
          ���ϵ���</div>
     <div class="c13102904" id ="Div25">
<input id="Text1" type="text"  runat="server"   readonly ="readonly"   class="c14031401" /> 
         <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="Text1" Text="����" runat="server" /></div>
                            <div class="c13101903" id ="Div28">
                                ��������</div>
       <div class="c13102904" id ="Div11">
         <input id="Text3" type="text" runat="server" onclick ="f13100202('Text3')" class ="c13110901"/> 
       <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ControlToValidate="Text3" Text="����" runat="server" />
         </div>
                               <div class="c13101903" id ="Div2">
                                   ����Ա����</div>                        
<div class="c14120312" id ="Div4">
<input id="Text4" type="text" runat="server" class ="c14120310" />
<span style =" margin-left :0px;"><a  href="javascript:f13100202('Text4','');">ѡ�� </a> </span> 
 <span  style =" margin-left :0px"><asp:Label ID="Label1" runat="server" Text="" ></asp:Label></span>
</div>
           </div>
<div  class ="c14062101">
           <asp:GridView ID="GridView1" runat="server" 
                    AllowSorting="True"   
                    onrowdatabound="GridView1_RowDataBound" 
                        AutoGenerateColumns="False" style="margin-left: 8px" PageSize="15" 
                           CssClass ="c14072903" onrowdeleting="GridView1_RowDeleting"
                   >
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <Columns > 
   
                       <asp:TemplateField HeaderText="ID" >
                <ItemTemplate >
                                <asp:TextBox ID="TextBox1" runat="server"   CssClass ="c14071603"    ></asp:TextBox>   
                                 <a  href="javascript:f13100202('TextBox1','<%#Eval ("���") %>');"> ѡ��</a> 
                </ItemTemplate>
               <HeaderStyle Width="6%" />
                 <ItemStyle Width="6%"/>
            </asp:TemplateField> 
           
                       <asp:TemplateField HeaderText="���ϱ���">
                <ItemTemplate >
                 <asp:TextBox ID="TextBox2" runat="server"  CssClass="c14071609"></asp:TextBox>                     
                </ItemTemplate>
              <HeaderStyle Width="6%" />
                 <ItemStyle Width="6%"/>
            </asp:TemplateField> 
               <asp:TemplateField HeaderText="�������">
                <ItemTemplate >
                 <asp:TextBox ID="TextBox3" runat="server"  CssClass="c14071610"></asp:TextBox>                     
                </ItemTemplate>
                 <HeaderStyle Width="6%" />
                 <ItemStyle Width="6%"/>
            </asp:TemplateField> 
       
                     <asp:TemplateField HeaderText="��������">
                <ItemTemplate >
                 <asp:TextBox ID="TextBox4" runat="server"   CssClass ="c13112302"></asp:TextBox>                     
                </ItemTemplate>
              <HeaderStyle Width="4%" />
                 <ItemStyle Width="4%"/>
            </asp:TemplateField> 
                      <asp:TemplateField HeaderText="���õ�λ">
                <ItemTemplate >
                 <asp:TextBox ID="TextBox5" runat="server"  CssClass ="c14071616"></asp:TextBox>                     
                </ItemTemplate>
                <HeaderStyle Width="4%" />
                 <ItemStyle Width="4%"/>
            </asp:TemplateField>
                <asp:TemplateField HeaderText="�ֿ�">
                <ItemTemplate >
                 <asp:TextBox ID="TextBox6" runat="server"  CssClass="c14071617"></asp:TextBox>
                 <a  href="javascript:f13100202('TextBox6','<%#Eval ("���") %>');">ѡ�� </a>                     
                </ItemTemplate>
             <HeaderStyle Width="6%" />
                 <ItemStyle Width="6%"/>
            </asp:TemplateField> 
                 <asp:TemplateField HeaderText="��λ">
                <ItemTemplate >
                 <asp:TextBox ID="TextBox7" runat="server" CssClass ="c14120202"></asp:TextBox>                     
                </ItemTemplate>
           <HeaderStyle Width="6%" />
                 <ItemStyle Width="6%"/>
            </asp:TemplateField> 
                <asp:TemplateField HeaderText="����">
                <ItemTemplate >
                 <asp:TextBox ID="TextBox8" runat="server" CssClass ="c14120202"></asp:TextBox>                     
                </ItemTemplate>
               <HeaderStyle Width="6%" />
                 <ItemStyle Width="6%"/>
            </asp:TemplateField> 
                          <asp:TemplateField HeaderText="�������">
                <ItemTemplate >
                 <asp:TextBox ID="TextBox9" runat="server"   CssClass ="c14071615"></asp:TextBox>                     
                </ItemTemplate>
                 <HeaderStyle Width="4%" />
                 <ItemStyle Width="4%"/>
            </asp:TemplateField> 
                       <asp:TemplateField HeaderText="��浥λ">
                <ItemTemplate >
                 <asp:TextBox ID="TextBox10" runat="server"  CssClass ="c14071616"></asp:TextBox>                     
                </ItemTemplate>
              <HeaderStyle Width="6%" />
                 <ItemStyle Width="6%"/>
            </asp:TemplateField> 
        
              <asp:TemplateField HeaderText="���">
                <ItemTemplate >
                 <asp:TextBox ID="TextBox11" runat="server"  CssClass ="c14070203" ></asp:TextBox>                     
                </ItemTemplate>
               <HeaderStyle Width="5%" />
                 <ItemStyle Width="5%"/>
            </asp:TemplateField> 
              <asp:TemplateField HeaderText="Ʒ��">
                <ItemTemplate >
                 <asp:TextBox ID="TextBox12" runat="server"  CssClass ="c14070203"></asp:TextBox>                     
                </ItemTemplate>
               <HeaderStyle Width="6%" />
                 <ItemStyle Width="6%"/>
            </asp:TemplateField> 
        <asp:TemplateField HeaderText="�����Ϻ�">
                <ItemTemplate >
                 <asp:TextBox ID="TextBox13" runat="server"  CssClass ="c14070103"></asp:TextBox>                     
                </ItemTemplate>
                  <HeaderStyle Width="6%" />
                 <ItemStyle Width="6%"/>
            </asp:TemplateField> 
                <asp:TemplateField HeaderText="��ע">
                <ItemTemplate >
                 <asp:TextBox ID="TextBox14" runat="server"    Width ="100px"  CssClass ="c13120501"></asp:TextBox>                     
                </ItemTemplate>
                <HeaderStyle Width="6%" />
                 <ItemStyle Width="6%"/>
            </asp:TemplateField>
                    </Columns>
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" Font-Bold="False" />   
                </asp:GridView>
                </div>
         <div id="i13111001" class ="c13102201">
        <asp:GridView ID="GridView2" runat="server" 
                    onrowdeleting="GridView2_RowDeleting" 
                    AllowSorting="True"   
                    onrowdatabound="GridView2_RowDataBound" 
                        AutoGenerateColumns="False" style="margin-left: 8px" PageSize="15" 
                        CssClass ="c13112304"
                   >
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <Columns > 
                            <asp:TemplateField HeaderText="ɾ��" >
                <ItemTemplate >
                    <asp:LinkButton ID="LinkButton2" runat="server" 
                        OnClientClick="return confirm('��ȷ��ɾ���ü�¼��?');" Text="ɾ��"  CommandName ="delete" ></asp:LinkButton>                     
                </ItemTemplate>
                 <HeaderStyle Width="40px" />
                 <ItemStyle Width="40px"  />
            </asp:TemplateField>
                                     <asp:BoundField DataField="����" HeaderText="����"    >
                              <ItemStyle Width="40px"  ForeColor="#595d5a"/>
                                    <HeaderStyle Width="40px" HorizontalAlign="Center" />
                          </asp:BoundField>
                          <asp:BoundField DataField="���" HeaderText="���" >
                              <ItemStyle Width="40px"  ForeColor="#595d5a"/>
                                    <HeaderStyle Width="40px" HorizontalAlign="Center" />
                          </asp:BoundField>
          <asp:BoundField DataField="ID" HeaderText="ID" >
                              <ItemStyle Width="80px"  ForeColor="#595d5a"/>
                                    <HeaderStyle Width="80px" HorizontalAlign="Center" />
                          </asp:BoundField>
              <asp:BoundField DataField="�Ϻ�" HeaderText="ԭ���ϱ���" >
                              <ItemStyle Width="80px"  ForeColor="#595d5a"/>
                                    <HeaderStyle  HorizontalAlign="Center" />
                          </asp:BoundField>
            <asp:BoundField DataField="Ʒ��" HeaderText="�������" >
                              <ItemStyle Width="80px"  ForeColor="#595d5a"/>
                                    <HeaderStyle HorizontalAlign="Center" />
                          </asp:BoundField> 
       <asp:BoundField DataField="�ͻ��Ϻ�" HeaderText="ԭ���Ϻ�" >
                              <ItemStyle Width="120px"  ForeColor="#595d5a"/>
                                    <HeaderStyle Width="120px" HorizontalAlign="Center" />
                          </asp:BoundField>
      
            <asp:BoundField DataField="��������" HeaderText="��������" >
                              <ItemStyle Width="80px"  ForeColor="#595d5a"  HorizontalAlign="Right" />
                                    <HeaderStyle Width="80px" HorizontalAlign="Center" />
                          </asp:BoundField>
                           <asp:BoundField DataField="��浥λ" HeaderText="���ϵ�λ" >
                              <ItemStyle Width="80px"  ForeColor="#595d5a"   />
                                    <HeaderStyle Width="80px" HorizontalAlign="Center" />
                          </asp:BoundField>
            <asp:BoundField DataField="�ֿ�" HeaderText="�ֿ�" >
                              <ItemStyle Width="120px"  ForeColor="#595d5a"  />
                                    <HeaderStyle Width="120px" HorizontalAlign="Center" />
                          </asp:BoundField>
     <asp:BoundField DataField="��λ" HeaderText="��λ" >
                              <ItemStyle Width="80px"  ForeColor="#595d5a"  />
                                    <HeaderStyle Width="80px" HorizontalAlign="Center" />
                          </asp:BoundField>
                           <asp:BoundField DataField="����" HeaderText="����" >
                              <ItemStyle Width="80px"  ForeColor="#595d5a" />
                                    <HeaderStyle Width="80px" HorizontalAlign="Center" />
                          </asp:BoundField>
                           <asp:BoundField DataField="��浥λ" HeaderText="��浥λ" >
                              <ItemStyle Width="80px"  ForeColor="#595d5a" />
                                    <HeaderStyle Width="80px" HorizontalAlign="Center" />
                          </asp:BoundField>
                           <asp:BoundField DataField="�Ƶ���" HeaderText="�Ƶ���" >
                              <ItemStyle Width="80px"  ForeColor="#595d5a" />
                                    <HeaderStyle Width="80px" HorizontalAlign="Center" />
                          </asp:BoundField>
             <asp:BoundField DataField="�Ƶ�����" HeaderText="�Ƶ�����"   >
                              <ItemStyle  />
                                    <HeaderStyle   HorizontalAlign="Center" />
                          </asp:BoundField>
                              <asp:BoundField DataField="��ע" HeaderText="��ע"   >
                              <ItemStyle Width="100px"  ForeColor="#595d5a" HorizontalAlign="Center" />
                                    <HeaderStyle Width="100px" HorizontalAlign="Center" />
                          </asp:BoundField>
                      
                    </Columns>
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" Font-Bold="False" />   
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
                  document.getElementById("i13111001").style.display = "block";
              }
              else {

                  document.getElementById("i13111001").style.display = "none";
              }
              //document.getElementById("Text10").focus();
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

                      document.getElementById("Text2").value = dlgResult[0];/*woid*/
                      document.getElementById("Text5").value = dlgResult[1];/*cname*/
                      document.getElementById("Text6").value = dlgResult[2];/*id*/
                      document.getElementById("Text7").value = dlgResult[3];/*co_wareid*/
                      document.getElementById("Text8").value = dlgResult[4];/*wname*/
                      document.getElementById("Text9").value = dlgResult[5];/*cwareid*/
                      document.getElementById("Text10").value = dlgResult[6];/*allow picking count*/
                  }
              }
              else if (obj == "TextBox1") {
                  dlgResult = window.showModalDialog("../BaseInfo/Wareinfo.aspx", window, "dialogWidth:970px; dialogHeight:490px; status:0");

                  if (dlgResult != undefined) {

                      var table = document.getElementById('<%=GridView1.ClientID%>');
                      var tr = table.getElementsByTagName("tr");
                      for (i = 1; i < tr.length; i++) {
                          if (obj1 == i) {
                              var wareid = tr[i].getElementsByTagName("td")[0].getElementsByTagName("input")[0]; //��ȡgirdview���1��TextBox��ֵ
                              var co_wareid = tr[i].getElementsByTagName("td")[1].getElementsByTagName("input")[0];/*co_wareid*/
                              var wname = tr[i].getElementsByTagName("td")[2].getElementsByTagName("input")[0]; /*wname*/
                              
                              var sku = tr[i].getElementsByTagName("td")[4].getElementsByTagName("input")[0]; /*sku*/
                              var storage_name= tr[i].getElementsByTagName("td")[5].getElementsByTagName("input")[0];/*storage*/
                              var storage_location = tr[i].getElementsByTagName("td")[6].getElementsByTagName("input")[0]; /*storage_location*/
                              
                              var batchid = tr[i].getElementsByTagName("td")[7].getElementsByTagName("input")[0];/*batchid*/
                              var storagecount = tr[i].getElementsByTagName("td")[8].getElementsByTagName("input")[0];/*storagecount*/
                              var picking_sku = tr[i].getElementsByTagName("td")[9].getElementsByTagName("input")[0]; /*picking_sku*/
                              
                              var spec = tr[i].getElementsByTagName("td")[10].getElementsByTagName("input")[0]; /*spec*/
                              var brand = tr[i].getElementsByTagName("td")[11].getElementsByTagName("input")[0]; /*brand*/
                              var cwareid = tr[i].getElementsByTagName("td")[12].getElementsByTagName("input")[0]; /*cwareid*/
                              wareid.value = dlgResult[0];
                              co_wareid.value = dlgResult[1];
                              wname.value = dlgResult[2];
                              sku.value = dlgResult[12];
                              spec.value = dlgResult[6];
                              brand.value = dlgResult[11];
                              cwareid.value = dlgResult[3];
                              storage_name.value =dlgResult [14];
                              storage_location.value =dlgResult [15];
                              batchid.value=dlgResult [16];
                              storagecount.value=dlgResult [17];
                              break;
                          }
                      }
                  }
              }
              else if (obj == "TextBox6") {
              dlgResult = window.showModalDialog("../StockManage/StorageCase.aspx", window,
                   "dialogWidth:970px; dialogHeight:490px; status:0");
                  if (dlgResult != undefined) {
                      var table1 = document.getElementById('<%=GridView1.ClientID%>');
                      var tr1 = table1.getElementsByTagName("tr");
                      for (i = 1; i < tr1.length; i++) {
                          if (obj1 == i) {
                              var v51 = tr1[i].getElementsByTagName("td")[5].getElementsByTagName("input")[0];
                              var v6 = tr1[i].getElementsByTagName("td")[6].getElementsByTagName("input")[0];
                              var v7 = tr1[i].getElementsByTagName("td")[7].getElementsByTagName("input")[0];
                              var v8 = tr1[i].getElementsByTagName("td")[8].getElementsByTagName("input")[0];
                              v51.value = dlgResult[0];
                              v6.value = dlgResult[1];
                              v7.value = dlgResult[2];
                              v8.value = dlgResult[3];
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