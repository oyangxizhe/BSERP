<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="REPLACE_MATERIELT.aspx.cs" Inherits="WPSS.BOM_MANAGE.REPLACE_MATERIELT" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>�༭�������Ϣ</title>
<meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" /> 
<meta name ="Description" content ="ERP����ϵͳ" />
<meta name ="keywords" content ="ERP����ϵͳ,ERP�������,ERP,С΢��ҵ����ϵͳ,ϣ�����" />
       <link href ="../Css/SSBase.css"  type ="text/css" rel ="Stylesheet" />
       <link href ="../Css/S131017.css"  type ="text/css" rel ="Stylesheet" />
    </head>
<body >
   <form id="form1" runat="server">
   <input id="hint" type="hidden"  runat="server" />
      <input id="x" type="hidden"  runat="server" />
      <input id="x1" type="hidden"  runat="server" />
      <input id="x2" type="hidden"  runat="server" />
      <input id="cuid" type="hidden"  runat="server" />
                <div class ="c13101905">
      <div class="c13101906" id ="Div9">
          &gt;�༭�������Ϣ </div>
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
                  (����)           </span>
       </div>
                       <div class="c13110502" id ="Div2">
   <span class="c13110508" id ="Span9">
       <asp:ImageButton ID="btnEdit" runat="server" ImageUrl="~/Image/btnEdit.png" 
                     onclick="btnEdit_Click"  />
          </span>
       </div>
              <div class="c13110510" id ="Div4">
   <span class="c13110511" id ="Span10">
                  (�޸�)
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
       <div class="c13110507" id ="Div32"  style=" display :none;">
                <span class="c13110503" id ="Span7" >
    <asp:LinkButton ID="btnReconcile" runat="server" onclick="btnReconcile_Click" CssClass ="">����</asp:LinkButton>
    </span> 
   </div>
    </div>
<div  id="i13102301_100" class ="c13102101" style ="display:none " >
<span  class ="c13102102"><asp:Label ID="prompt" runat="server"  ForeColor="#f80707"></asp:Label></span>
</div> 
  <div class ="c13101902">
      <div class="c13101903" id ="Div24">
          ������</div>
     <div class="c14031403" id ="Div25">
<input id="Text1" type="text"  runat="server"   readonly ="readonly" class="c14031401" 
            /> 
         <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="Text1" Text="����ģ�" runat="server" /></div>
                         <div class="c13101903" id ="Div11" >
                             �ͻ�</div>
     <div class="c14031403" id ="Div14">
   <input id="Text8" type="text"  runat ="server" class ="c13102103"  /> 
      <span style =" margin-left :5px"><a  href="javascript:f13100202('Text8','');">ѡ�� </a></span> 
         </div>
         <div class="c13101903" id ="Div26">
             ԭ�Ϻ�ID</div>
     <div class="c14063001" id ="Div15">
   <input id="Text2" type="text"  runat ="server" class ="c14031405"  /> 
      <span style =" margin-left :5px"><a  href="javascript:f13100202('Text2','');">ѡ�� </a></span> 
         </div>
                  <div class="c13101903" id ="Div28">
                         ԭ���ϱ���</div>
     <div class="c14120501" id ="Div29">
         <input id="Text3" type="text" runat="server" onclick ="f13100202('Text3')"  class ="c14031401"  readonly ="readonly"/>
         </div>
           </div>
           
  <div class ="c13101902">
    
     <div class="c13101903" id ="Div30">
           ���(���Ʒ)</div>
     <div class="c14031403" id ="Div31">
<input id="Text4" type="text" runat="server" class ="c13102103" />
<span style =" margin-left :5px;"></span> 
 <span  style =" margin-left :10px"></span>
</div>
     <div class="c13101903" id ="Div12">
             ���</div>
     <div class="c14031403" id ="Div13">
   <input id="Text9" type="text"  runat ="server" class ="c14031401" readonly ="readonly" /></div>
         <div class="c13101903" id ="Div5">
             ԭ���Ϻ�</div>
     <div class="c14063001" id ="Div6">
   <input id="Text5" type="text"  runat ="server" class ="c14031401" readonly ="readonly" /></div>
  
           </div>        
<div class ="c13111601">
       <div class="c13101903" id ="Div35">
           Ʒ����Ϣ</div>
     <div class="c14063005" id ="Div36">
       <span style="color :#990033">(���������1�������Ϊ1/100)</span>
</div>
</div>
<div class ="c14061302">
             
          <asp:GridView ID="GridView1" runat="server" 
                    AllowSorting="True"   
                    onrowdatabound="GridView1_RowDataBound" 
                        AutoGenerateColumns="False"  PageSize="15" 
                        CssClass ="c14060501" 
                   >
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <Columns > 
           <asp:TemplateField HeaderText="�����ID" >
                <ItemTemplate >
                                <asp:TextBox ID="TextBox1" runat="server"   Text='<%#Eval ("��ID") %>' CssClass ="c14071603"   ></asp:TextBox>   
                                 <a  href="javascript:f13100202('TextBox1','<%#Eval ("���") %>');">ѡ��</a> 
                </ItemTemplate>
                 <HeaderStyle Width="9%" />
                 <ItemStyle Width="9%"/>
            </asp:TemplateField> 
               <asp:TemplateField HeaderText="���ϱ���">
                <ItemTemplate >
                 <asp:TextBox ID="TextBox2" runat="server"  Text='<%#Eval ("���Ϻ�") %>'  CssClass ="c14070103" ></asp:TextBox>                     
                </ItemTemplate>
             <HeaderStyle Width="8%" />
                 <ItemStyle Width="8%"/>
            </asp:TemplateField>
                    <asp:TemplateField HeaderText="�������">
                <ItemTemplate >
                 <asp:TextBox ID="TextBox3" runat="server"  Text='<%#Eval ("��Ʒ��") %>'  CssClass ="c14070103" ></asp:TextBox>                     
                </ItemTemplate>
               <HeaderStyle Width="8%" />
                 <ItemStyle Width="8%"/>
            </asp:TemplateField> 
        
                
           
                    <asp:TemplateField HeaderText="�������">
                <ItemTemplate >
                 <asp:TextBox ID="TextBox6" runat="server" Text='<%#Eval ("�������") %>' CssClass ="c13112302" ></asp:TextBox>                     
                </ItemTemplate>
                 <HeaderStyle Width="6%" />
                 <ItemStyle Width="6%"/>
            </asp:TemplateField>
            
                 <asp:TemplateField HeaderText="�����">
                <ItemTemplate >
                 <asp:TextBox ID="TextBox8" runat="server"  Text='<%#Eval ("�����") %>' CssClass ="c14072301"></asp:TextBox>                     
                </ItemTemplate>
                <HeaderStyle Width="6%" />
                 <ItemStyle Width="6%"/>
            </asp:TemplateField> 
                     <asp:TemplateField HeaderText="�͹���">
                <ItemTemplate >
                           
                         <asp:DropDownList ID="DropDownList1" runat="server"  Text='<%#Eval ("�͹���") %>' CssClass ="c14071704">
                             <asp:ListItem>N</asp:ListItem>
                   <asp:ListItem>Y</asp:ListItem>
                    <asp:ListItem></asp:ListItem>
                         </asp:DropDownList>         
                </ItemTemplate>
              <HeaderStyle Width="6%" />
                 <ItemStyle Width="6%"/>
            </asp:TemplateField> 
   
                          <asp:TemplateField HeaderText="���Ͻ׶�">
                <ItemTemplate >
                 <asp:TextBox ID="TextBox9" runat="server"   Text='<%#Eval ("���Ͻ׶�") %>' CssClass ="c14120405" ></asp:TextBox>      
                    <a  href="javascript:f13100202('TextBox9','<%#Eval ("���") %>');"> ѡ��</a>                
                </ItemTemplate>
                <HeaderStyle Width="9%" />
                 <ItemStyle Width="9%"/>
            </asp:TemplateField> 
                       <asp:TemplateField HeaderText="λ��">
                <ItemTemplate >
                 <asp:TextBox ID="TextBox12" runat="server"  Text='<%#Eval ("λ��") %>' CssClass ="c14071703"></asp:TextBox>                     
                </ItemTemplate>
                  <HeaderStyle Width="11%" />
                 <ItemStyle Width="11%"/>
            </asp:TemplateField>
                        <asp:TemplateField HeaderText="��ע">
                <ItemTemplate >
                 <asp:TextBox ID="TextBox10" runat="server"     Text='<%#Eval ("��ע") %>' CssClass ="c13120501"></asp:TextBox>                     
                </ItemTemplate>
                  <HeaderStyle Width="10%" />
                 <ItemStyle Width="10%"/>
            </asp:TemplateField>
                <asp:TemplateField HeaderText="���"   >
                <ItemTemplate >
                 <asp:TextBox ID="TextBox5" runat="server"  Text='<%#Eval ("�ӹ��") %>'  CssClass ="c14070203" ></asp:TextBox>                     
                </ItemTemplate>
               <HeaderStyle Width="8%" />
                 <ItemStyle Width="8%"/>
            </asp:TemplateField> 
                         <asp:TemplateField HeaderText="Ʒ��"  >
                <ItemTemplate >
                 <asp:TextBox ID="TextBox11" runat="server"  Text='<%#Eval ("Ʒ��") %>' CssClass ="c14070203" ></asp:TextBox>                     
                </ItemTemplate>
                 <HeaderStyle Width="8%" />
                 <ItemStyle Width="8%"/>
            </asp:TemplateField> 
                                <asp:TemplateField HeaderText="�����Ϻ�">
                <ItemTemplate >
                 <asp:TextBox ID="TextBox4" runat="server"  Text='<%#Eval ("�ӿͻ��Ϻ�") %>' CssClass ="c13120501" ></asp:TextBox>                     
                </ItemTemplate>
                 <HeaderStyle Width="11%" />
                 <ItemStyle Width="11%"/>
            </asp:TemplateField>
               <asp:TemplateField HeaderText="BOM��λ">
                <ItemTemplate >
                 <asp:TextBox ID="TextBox7" runat="server" Text='<%#Eval ("BOM��λ") %>' CssClass ="c14071616"></asp:TextBox>                     
                </ItemTemplate>
                <HeaderStyle Width="6%" />
                 <ItemStyle Width="6%"/>
            </asp:TemplateField> 
                    </Columns>
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" Font-Bold="False" />   
                </asp:GridView>
                </div>
 <div id="i13103001" class ="c14061302">
        
        <asp:GridView ID="GridView2" runat="server" 
                    AllowSorting="True"   
                    onrowdatabound="GridView2_RowDataBound" 
                        AutoGenerateColumns="False"  PageSize="15" 
                        CssClass ="c14071705" onrowdeleting="GridView2_RowDeleting"  
                   >
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <Columns > 
                       <asp:TemplateField HeaderText="ɾ��" >
                <ItemTemplate >
                    <asp:LinkButton ID="LinkButton2" runat="server" 
                        OnClientClick="return confirm('��ȷ��ɾ���ü�¼��?');" Text="ɾ��"  CommandName ="delete" ></asp:LinkButton>                     
                </ItemTemplate>
                 <HeaderStyle Width="2%" />
                 <ItemStyle Width="2%"  />
            </asp:TemplateField>
                         <asp:BoundField DataField="����" HeaderText="����"  Visible ="false"  >
                              <ItemStyle Width="4%"  ForeColor="#595d5a"/>
                                    <HeaderStyle Width="4%" HorizontalAlign="Center" />
                          </asp:BoundField>
                              <asp:TemplateField HeaderText="���" >
                <ItemTemplate >
                  <asp:TextBox ID="TextBox0" runat="server"  Text='<%#Eval ("���") %>'  CssClass="c14071612"  ></asp:TextBox>   
                               
                </ItemTemplate>
                 <HeaderStyle Width="2%" />
                 <ItemStyle Width="2%"  ForeColor="#595d5a" />
            </asp:TemplateField> 
           <asp:TemplateField HeaderText="�����ID" >
                <ItemTemplate >
                                <asp:TextBox ID="TextBox1" runat="server" Text='<%#Eval ("��ID") %>' CssClass ="c14071603"   ></asp:TextBox>   
                                 <a  href="javascript:f13100203('TextBox1','<%#Eval ("���") %>');">ѡ��</a> 
                </ItemTemplate>
                 <HeaderStyle Width="9%" />
                 <ItemStyle Width="9%"  />
            </asp:TemplateField> 
               <asp:TemplateField HeaderText="���ϱ���">
                <ItemTemplate >
                 <asp:TextBox ID="TextBox2" runat="server"  Text='<%#Eval ("���Ϻ�") %>'  CssClass ="c13120501" ></asp:TextBox>                     
                </ItemTemplate>
                 <HeaderStyle Width="8%" />
                 <ItemStyle Width="8%"/>
            </asp:TemplateField>
                    <asp:TemplateField HeaderText="�������">
                <ItemTemplate >
                 <asp:TextBox ID="TextBox3" runat="server" Text='<%#Eval ("��Ʒ��") %>'  CssClass ="c14070103"  ></asp:TextBox>                     
                </ItemTemplate>
               <HeaderStyle Width="8%" />
                 <ItemStyle Width="8%"/>
            </asp:TemplateField> 
      
                    <asp:TemplateField HeaderText="�������">
                <ItemTemplate >
                 <asp:TextBox ID="TextBox6" runat="server" Text='<%#Eval ("�������") %>' CssClass ="c13112302"></asp:TextBox>                     
                </ItemTemplate>
                 <HeaderStyle Width="3%" />
                 <ItemStyle Width="3%"/>
            </asp:TemplateField>
     
                 <asp:TemplateField HeaderText="�����">
                <ItemTemplate >
                 <asp:TextBox ID="TextBox8" runat="server" Text='<%#Eval ("�����") %>' CssClass ="c13112302"></asp:TextBox>                     
                </ItemTemplate>
                  <HeaderStyle Width="3%" />
                 <ItemStyle Width="3%"/>
            </asp:TemplateField> 
                     <asp:TemplateField HeaderText="�͹���">
                <ItemTemplate >
                           
                         <asp:DropDownList ID="DropDownList1"   Text='<%#Eval ("�͹���") %>' runat="server" CssClass ="c13112302">
                             <asp:ListItem>N</asp:ListItem>
                   <asp:ListItem>Y</asp:ListItem>
                         </asp:DropDownList>         
                </ItemTemplate>
                <HeaderStyle Width="3%" />
                 <ItemStyle Width="3%"/>
            </asp:TemplateField> 
   
                          <asp:TemplateField HeaderText="���Ͻ׶�">
                <ItemTemplate >
                 <asp:TextBox ID="TextBox9" runat="server"   Text='<%#Eval ("���Ͻ׶�") %>'  CssClass ="c14120405"  ></asp:TextBox>      
                    <a  href="javascript:f13100203('TextBox9','<%#Eval ("���") %>');"> ѡ��</a>                
                </ItemTemplate>
                 <HeaderStyle Width="9%" />
                 <ItemStyle Width="9%"  />
            </asp:TemplateField> 
                     <asp:TemplateField HeaderText="λ��">
                <ItemTemplate >
                 <asp:TextBox ID="TextBox12" runat="server"  Text='<%#Eval ("λ��") %>'   CssClass ="c14071703"></asp:TextBox>                     
                </ItemTemplate>
                   <HeaderStyle Width="9%" />
                 <ItemStyle Width="9%"  />
            </asp:TemplateField>
                        <asp:TemplateField HeaderText="��ע">
                <ItemTemplate >
                 <asp:TextBox ID="TextBox10" runat="server"   Text='<%#Eval ("��ע") %>' CssClass ="c13120501"></asp:TextBox>                     
                </ItemTemplate>
                <HeaderStyle Width="9%" />
                 <ItemStyle Width="9%"  />
            </asp:TemplateField>
                     <asp:TemplateField HeaderText="���"  >
                <ItemTemplate >
                 <asp:TextBox ID="TextBox5" runat="server"  Text='<%#Eval ("�ӹ��") %>' CssClass ="c14070203" ></asp:TextBox>                     
                </ItemTemplate>
                <HeaderStyle Width="8%" />
                 <ItemStyle Width="8%"/>
            </asp:TemplateField> 
                        <asp:TemplateField HeaderText="Ʒ��"  >
                <ItemTemplate >
                 <asp:TextBox ID="TextBox11" runat="server"   Text='<%#Eval ("Ʒ��") %>' CssClass ="c14070203" ></asp:TextBox>                     
                </ItemTemplate>
                <HeaderStyle Width="8%" />
                 <ItemStyle Width="8%"/>
            </asp:TemplateField>
                               <asp:TemplateField HeaderText="�����Ϻ�">
                <ItemTemplate >
                 <asp:TextBox ID="TextBox4" runat="server"  Text='<%#Eval ("�ӿͻ��Ϻ�") %>' CssClass ="c14070103" ></asp:TextBox>                     
                </ItemTemplate>
                   <HeaderStyle Width="8%" />
                 <ItemStyle Width="8%"/>
            </asp:TemplateField>
                       <asp:TemplateField HeaderText="BOM��λ">
                <ItemTemplate >
                 <asp:TextBox ID="TextBox7" runat="server"  Text='<%#Eval ("BOM��λ") %>' CssClass ="c14071616"></asp:TextBox>                     
                </ItemTemplate>
            <HeaderStyle Width="6%" />
                 <ItemStyle Width="6%"/>
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
                             
                              document.getElementById("i13102301_100").style.display = "block";
                              document.all("prompt").innerText = Invocation;
                          }
                          else {

                             
                              document.getElementById("i13102301_100").style.display = "none";
                          }

                          if (Invocation1 != "") {
                              document.getElementById("i13103001").style.display = "block";

                          }
                          else {

                              document.getElementById("i13103001").style.display = "none";

                          }

                      }

                      function f13100202(obj, obj1) {
                          var dlgResult;
                          if (obj == "Text2") {
                              dlgResult = window.showModalDialog("../BaseInfo/Wareinfo.aspx?CUID=" + document.getElementById("cuid").value + "&nature=bom_det", window, "dialogWidth:970px; dialogHeight:490px; status:0");
                              if (dlgResult != undefined) {

                                  document.getElementById("Text2").value = dlgResult[0];
                                  document.getElementById("Text3").value = dlgResult[1];
                                  document.getElementById("Text4").value = dlgResult[2];
                                  document.getElementById("Text5").value = dlgResult[3];


                              }
                          }
                          else if (obj == "TextBox1") {
                          dlgResult = window.showModalDialog("../BaseInfo/Wareinfo.aspx?nature=bom_det", window, "dialogWidth:970px; dialogHeight:490px; status:0");

                              if (dlgResult != undefined) {

                                  var table = document.getElementById('<%=GridView1.ClientID%>');
                                  var tr = table.getElementsByTagName("tr");
                                  for (i = 1; i < tr.length; i++) {
                                      if (obj1 == i) {
                                          var v0 = tr[i].getElementsByTagName("td")[0].getElementsByTagName("input")[0]; //��ȡgirdview���1��TextBox��ֵ
                                          var v1 = tr[i].getElementsByTagName("td")[1].getElementsByTagName("input")[0];
                                          var v2 = tr[i].getElementsByTagName("td")[2].getElementsByTagName("input")[0];
                                          var v3 = tr[i].getElementsByTagName("td")[9].getElementsByTagName("input")[0];
                                          var v4 = tr[i].getElementsByTagName("td")[10].getElementsByTagName("input")[0];
                                          var v5 = tr[i].getElementsByTagName("td")[11].getElementsByTagName("input")[0]; /*cwareid*/
                                          var v7 = tr[i].getElementsByTagName("td")[12].getElementsByTagName("input")[0];
                                          v0.value = dlgResult[0];
                                          v1.value = dlgResult[1];
                                          v2.value = dlgResult[2];
                                          v3.value = dlgResult[6];
                                          v4.value = dlgResult[11]; /*dlgResult[3] c_wareid ,dlgResult[11] brand ,dlgResult[6] spec ,dlgResult[8] bom_unit*/
                                          v5.value = dlgResult[3];
                                          v7.value = dlgResult[8];
                                          break;
                                      }
                                  }


                              }

                          }

                          else if (obj == "TextBox9") {
                              dlgResult = window.showModalDialog("../bom_manage/picking_stage.aspx", window, "dialogWidth:970px; dialogHeight:490px; status:0");
                              if (dlgResult != undefined) {

                                  table1 = document.getElementById('<%=GridView1.ClientID%>');
                                  tr1 = table1.getElementsByTagName("tr");
                                  for (i = 1; i < tr1.length; i++) {
                                      if (obj1 == i) {
                                          v1 = tr1[i].getElementsByTagName("td")[6].getElementsByTagName("input")[0]; //��ȡgirdview���1��TextBox��ֵ
                                          v1.value = dlgResult[0];
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
                              dlgResult = window.showModalDialog("../WDate.aspx", window, "dialogWidth:160px; dialogHeight:240px; status:0;");
                              if (dlgResult != undefined) {


                                  document.getElementById("Text4").value = dlgResult;
                              }


                          }
                          else if (obj == "Text8") {
                              dlgResult = window.showModalDialog("../sellmanage/customerinfo.aspx", window, "dialogWidth:970px; dialogHeight:490px; status:0");
                              if (dlgResult != undefined) {

                                  document.getElementById("cuid").value = dlgResult[0];
                                  document.getElementById("Text8").value = dlgResult[1];

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
                      function f13100203(obj, obj1) {
                          var dlgResult;
                          if (obj == "TextBox1") {
                              dlgResult = window.showModalDialog("../BaseInfo/Wareinfo.aspx?nature=bom_det", window, "dialogWidth:970px; dialogHeight:490px; status:0");

                              if (dlgResult != undefined) {

                                  var table1 = document.getElementById('<%=GridView2.ClientID%>');
                                  var tr1 = table1.getElementsByTagName("tr");
                                  for (i = 1; i < tr1.length; i++) {
                                      if (obj1 == i) {

                                          var v2 = tr1[i].getElementsByTagName("td")[2].getElementsByTagName("input")[0];
                                          var v3 = tr1[i].getElementsByTagName("td")[3].getElementsByTagName("input")[0];
                                          var v4 = tr1[i].getElementsByTagName("td")[4].getElementsByTagName("input")[0];
                                          var v5 = tr1[i].getElementsByTagName("td")[11].getElementsByTagName("input")[0]; /**/
                                          var v6 = tr1[i].getElementsByTagName("td")[12].getElementsByTagName("input")[0]; /**/
                                          var v7 = tr1[i].getElementsByTagName("td")[13].getElementsByTagName("input")[0]; /**/
                                          var v9 = tr1[i].getElementsByTagName("td")[14].getElementsByTagName("input")[0]; /**/
                                          /*v1.value = dlgResult[0];*/ //v1 be occupied

                                          v2.value = dlgResult[0];
                                          v3.value = dlgResult[1];
                                          v4.value = dlgResult[2];
                                          v5.value = dlgResult[6];
                                          v6.value = dlgResult[11]; /*dlgResult[3] c_wareid ,dlgResult[11] brand ,dlgResult[6] spec ,dlgResult[8] bom_unit*/
                                          v7.value = dlgResult[3];
                                          v9.value = dlgResult[8];
                                          break;
                                      }
                                  }


                              }

                          }
                          else if (obj == "TextBox9") {
                              dlgResult = window.showModalDialog("../bom_manage/picking_stage.aspx", window, "dialogWidth:970px; dialogHeight:490px; status:0");
                              if (dlgResult != undefined) {

                                  table1 = document.getElementById('<%=GridView2.ClientID%>');
                                  tr1 = table1.getElementsByTagName("tr");
                                  for (i = 1; i < tr1.length; i++) {
                                      if (obj1 == i) {
                                          v1 = tr1[i].getElementsByTagName("td")[8].getElementsByTagName("input")[0]; //��ȡgirdview���1��TextBox��ֵ
                                          v1.value = dlgResult[0];
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