<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CO_ORDERT.aspx.cs" Inherits="WPSS.MRP_MANAGE.CO_ORDERT" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>�༭���ڶ�����Ϣ</title>
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
                <div class ="c13101905">
      <div class="c13101906" id ="Div9">
          &gt;�༭���ڶ�����Ϣ </div>
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
        <div class="c14060904" id ="Div32">
                <span class="c14060903" id ="Span7">
    <asp:LinkButton ID="btnReconcile" runat="server" onclick="btnReconcile_Click" CssClass ="">����MRP����</asp:LinkButton>
    </span> 
   </div>
          

          
    </div>
<div  id="i13102301" class ="c13102101">
<span  class ="c13102102"><asp:Label ID="prompt" runat="server"  ForeColor="#f80707"></asp:Label></span>
</div> 
<div id="i14061508">
  <div class ="c13101902">
      <div class="c13101903" id ="Div24">
          ���ڶ�����</div>
     <div class="c14031403" id ="Div4"> <span style =" margin-right :8px;">
<input id="Text1" type="text"  runat="server"   readonly ="readonly" class="c14031401"/> 
         <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="Text1" Text="����" runat="server" /></span></div>
         <div class="c13101903" id ="Div26">
             �ͻ�ID</div>
     <div class="c14031403" id ="Div27">
   <input id="Text2" type="text"  runat ="server" class="c14062901" readonly ="readonly"/>
   <span style =" margin-left :5px;display:none ;"><a  href="javascript:f13100202('Text2','');">
         ѡ�� </a></span> 
   </div>
            <div class="c13101903" id ="Div2">
                �ͻ�����</div>
 <div class="c14031403" id ="Div3">
   <input id="Text6" type="text"  runat ="server"  class="c14062901" /></div>
             <div class="c13101903" id ="Div5">
                 �ͻ�����</div>
     <div class="c14120501" id ="Div6">
   <input id="Text5" type="text"  runat ="server"  class ="c14062902"  readonly ="readonly" /></div>
                 
       </div> 
           </div>
  
           <div class ="c13101902">
              <div class="c13101903" id ="Div28">
                        ��������</div>
     <div class="c14031403" id ="Div29">
         <input id="Text3" type="text" runat="server" onclick ="f13100202('Text3')"  class="c14062901"  readonly ="readonly"/>
         <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="Text3" Text="����" runat="server" />
         </div>
         <div class="c13101903" id ="Div15">
             �ͻ�������</div>
 <div class="c14031403" id ="Div1">
   <input id="Text4" type="text"  runat ="server"  class="c14062901"/>
   </div>
        <div class="c13101903" id ="Div42">
             ������</div>
     <div class="c14031403" id ="Div43">
   <input id="Text14" type="text"  runat ="server"  class="c14062901" /></div>
            <div class="c13101903" id ="Div21">
                BOM���</div>
 <div class="c14120501" id ="Div25">
   <input id="Text10" type="text"  runat ="server"  class="c14062901" />
   </div>
  
           </div>
           <div class ="c13101902">
               <div class="c13101903" id ="Div30">
                   BOM�汾</div>
 <div class="c14031403" id ="Div31">
   <input id="Text11" type="text"  runat ="server"  class="c14062901"/>
   </div>
     
  
           </div>
<div id="i14061503" class ="c13111601">
       <div class="c13101903" id ="Div35">
           Ʒ����Ϣ</div></div>
     
 
         
        
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
                                 <a  href="javascript:f13100202('TextBox1','<%#Eval ("���") %>');"></a> 
                </ItemTemplate>
                 <HeaderStyle Width="6%" />
                 <ItemStyle Width="6%" />
            </asp:TemplateField> 
               <asp:TemplateField HeaderText="���ڳ�Ʒ�Ϻ�">
                <ItemTemplate >
                 <asp:TextBox ID="TextBox2" runat="server"  Text='<%#Eval ("�Ϻ�") %>'  CssClass ="c13120501" ></asp:TextBox>                     
                </ItemTemplate>
                  <HeaderStyle Width="8%" />
                 <ItemStyle Width="8%" />
            </asp:TemplateField>
                    <asp:TemplateField HeaderText="Ʒ��">
                <ItemTemplate >
                 <asp:TextBox ID="TextBox3" runat="server"  Text='<%#Eval ("Ʒ��") %>'   CssClass ="c13120501" ></asp:TextBox>                     
                </ItemTemplate>
                <HeaderStyle Width="8%" />
                 <ItemStyle Width="8%" />
            </asp:TemplateField> 
         
                          <asp:TemplateField HeaderText="�ͻ��Ϻ�">
                <ItemTemplate >
                 <asp:TextBox ID="TextBox4" runat="server"  Text='<%#Eval ("�ͻ��Ϻ�") %>'  CssClass ="c13120501"></asp:TextBox>                     
                </ItemTemplate>
                <HeaderStyle Width="8%" />
                 <ItemStyle Width="8%" />
            </asp:TemplateField>
                       <asp:TemplateField HeaderText="���"  >
                <ItemTemplate >
                 <asp:TextBox ID="TextBox5" runat="server"   Text='<%#Eval ("���") %>'  CssClass ="c13120501" ></asp:TextBox>                     
                </ItemTemplate>
                 <HeaderStyle Width="8%" />
                 <ItemStyle Width="8%" />
            </asp:TemplateField> 
                    <asp:TemplateField HeaderText="��������">
                <ItemTemplate >
                 <asp:TextBox ID="TextBox6" runat="server" Text='<%#Eval ("��������") %>' CssClass ="c14071615"  ReadOnly ="true"></asp:TextBox>                     
                </ItemTemplate>
                 <HeaderStyle Width="5%" />
                 <ItemStyle Width="5%" />
            </asp:TemplateField>
               <asp:TemplateField HeaderText="���۵���">
                <ItemTemplate >
                 <asp:TextBox ID="TextBox7" runat="server" Text='<%#Eval ("���۵���") %>' CssClass ="c14071615" ></asp:TextBox>                     
                </ItemTemplate>
            <HeaderStyle Width="5%" />
                 <ItemStyle Width="5%" />
            </asp:TemplateField> 
                     <asp:TemplateField HeaderText="˰��">
                <ItemTemplate >
                 <asp:TextBox ID="TextBox8" runat="server" Text='<%#Eval ("˰��") %>'   CssClass ="c14071615"></asp:TextBox>                     
                </ItemTemplate>
             <HeaderStyle Width="3%" />
                 <ItemStyle Width="3%" />
            </asp:TemplateField> 
   
                          <asp:TemplateField HeaderText="��������">
                <ItemTemplate >
                 <asp:TextBox ID="TextBox9" runat="server"  Text='<%#Eval ("��������") %>' CssClass ="c14071603 "  ></asp:TextBox>      
                    <a  href="javascript:f13100202('TextBox9','<%#Eval ("���") %>');"> ѡ��</a>                
                </ItemTemplate>
                 <HeaderStyle Width="10%" />
                 <ItemStyle Width="10%" />
            </asp:TemplateField> 
       
                         <asp:TemplateField HeaderText="�����������">
                <ItemTemplate >
                 <asp:TextBox ID="TextBox10" runat="server" Text='<%#Eval ("�����������") %>' CssClass ="c14071603 "  ></asp:TextBox> 
                 <a  href="javascript:f13100202('TextBox10','<%#Eval ("���") %>');"> ѡ��</a>                     
                </ItemTemplate>
                 <HeaderStyle Width="10%" />
                 <ItemStyle Width="10%" />
            </asp:TemplateField> 
         
    
                            <asp:TemplateField HeaderText="������������">
                <ItemTemplate >
                 <asp:TextBox ID="TextBox11" runat="server"  Text='<%#Eval ("������������") %>' CssClass ="c14071603 " ></asp:TextBox>      
                    <a  href="javascript:f13100202('TextBox11','<%#Eval ("���") %>');"> ѡ��</a>                
                </ItemTemplate>
               <HeaderStyle Width="10%" />
                 <ItemStyle Width="10%" />
            </asp:TemplateField>
                                   <asp:TemplateField HeaderText="������������">
                <ItemTemplate >
                 <asp:TextBox ID="TextBox12" runat="server"  Text='<%#Eval ("������������") %>' CssClass ="c14071603 "  ></asp:TextBox>      
                    <a  href="javascript:f13100202('TextBox12','<%#Eval ("���") %>');"> ѡ��</a>                
                </ItemTemplate>
               <HeaderStyle Width="10%" />
                 <ItemStyle Width="10%" />
            </asp:TemplateField>
                                 <asp:TemplateField HeaderText="����ͻ�����">
                <ItemTemplate >
                 <asp:TextBox ID="TextBox13" runat="server"  Text='<%#Eval ("����ͻ�����") %>' CssClass ="c14071603 "  ></asp:TextBox>      
                    <a  href="javascript:f13100202('TextBox13','<%#Eval ("���") %>');"> ѡ��</a>                
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
          �ϼ�δ˰���</div>
     <div class="c13101904" id ="Div8">
        <input id="Text7" type="text"  runat="server"    class="c13102908"/></div>
          <div class="c13101903" id ="Div12">
              �ϼ�˰��</div>
     <div class="c13101904" id ="Div13">
   <input id="Text8" type="text"  runat ="server" class="c13102908" /> 
         </div>
                  <div class="c13101903" id ="Div11">
                      �ϼƺ�˰���</div>
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
              
                                     <asp:BoundField DataField="FLKEY" HeaderText="����"  Visible ="false"  >
                              <ItemStyle Width="40px"  ForeColor="#595d5a"/>
                                    <HeaderStyle Width="40px" HorizontalAlign="Center" />
                          </asp:BoundField>

          <asp:BoundField DataField="WAREID" HeaderText="ID" >
                              <ItemStyle Width="80px"  ForeColor="#595d5a"/>
                                    <HeaderStyle Width="80px" HorizontalAlign="Center" />
                          </asp:BoundField>
                <asp:TemplateField HeaderText="����">
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
                              <asp:TemplateField HeaderText="ɾ��" >
                <ItemTemplate >
                    <asp:LinkButton ID="LinkButton2" runat="server" 
                        OnClientClick="return confirm('��ȷ��ɾ���ü�¼��?');" Text="ɾ��"  CommandName ="delete" ></asp:LinkButton>                     
                </ItemTemplate>
                 <HeaderStyle Width="40px" />
                 <ItemStyle Width="40px"  />
            </asp:TemplateField>
                                     <asp:BoundField DataField="����" HeaderText="����"  Visible ="false"  >
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
                               <asp:BoundField DataField="�Ϻ�" HeaderText="���ڳ�Ʒ�Ϻ�" >
                              <ItemStyle Width="120px"  ForeColor="#595d5a"/>
                                    <HeaderStyle Width="120px" HorizontalAlign="Center" />
                          </asp:BoundField>
            <asp:BoundField DataField="Ʒ��" HeaderText="Ʒ��" >
                              <ItemStyle Width="180px"  ForeColor="#595d5a"/>
                                    <HeaderStyle Width="180px" HorizontalAlign="Center" />
                          </asp:BoundField> 
       <asp:BoundField DataField="�ͻ��Ϻ�" HeaderText="�ͻ��Ϻ�" >
                              <ItemStyle Width="120px"  ForeColor="#595d5a"/>
                                    <HeaderStyle Width="120px" HorizontalAlign="Center" />
                          </asp:BoundField>
            <asp:BoundField DataField="��������" HeaderText="��������" >
                              <ItemStyle Width="80px"  ForeColor="#595d5a"  HorizontalAlign="Right" />
                                    <HeaderStyle Width="80px" HorizontalAlign="Center" />
                          </asp:BoundField>
                          
            <asp:BoundField DataField="���۵���" HeaderText="���۵���" >
                              <ItemStyle Width="80px"  ForeColor="#595d5a" HorizontalAlign="Right" />
                                    <HeaderStyle Width="80px" HorizontalAlign="Center" />
                          </asp:BoundField>
             <asp:BoundField DataField="˰��" HeaderText="˰��" >
                              <ItemStyle Width="40px"  ForeColor="#595d5a" HorizontalAlign="Right" />
                                    <HeaderStyle Width="40px" HorizontalAlign="Center" />
                          </asp:BoundField>
           <asp:BoundField DataField="δ˰���" HeaderText="δ˰���"    DataFormatString="{0:0.00}"  >
                              <ItemStyle Width="80px"  ForeColor="#595d5a" HorizontalAlign="Right" />
                                    <HeaderStyle Width="80px" HorizontalAlign="Center" />
                          </asp:BoundField>
             <asp:BoundField DataField="˰��" HeaderText="˰��"   DataFormatString="{0:0.00}">
                              <ItemStyle Width="80px"  ForeColor="#595d5a" HorizontalAlign="Right" />
                                    <HeaderStyle Width="80px" HorizontalAlign="Center" />
                          </asp:BoundField>
            <asp:BoundField DataField="��˰���" HeaderText="��˰���"   DataFormatString="{0:0.00}">
                              <ItemStyle Width="80px"  ForeColor="#595d5a" HorizontalAlign="Right" />
                                    <HeaderStyle Width="80px" HorizontalAlign="Center" />
                          </asp:BoundField>
                            <asp:BoundField DataField="��������" HeaderText="��������"   >
                              <ItemStyle Width="80px"  ForeColor="#595d5a" HorizontalAlign="Center" />
                                    <HeaderStyle Width="80px" HorizontalAlign="Center" />
                          </asp:BoundField>
                                <asp:BoundField DataField="ǰ������" HeaderText="ǰ������"  >
                              <ItemStyle Width="80px"  ForeColor="#595d5a" HorizontalAlign="Center" />
                                    <HeaderStyle Width="80px" HorizontalAlign="Center" />
                          </asp:BoundField>
                         
             <asp:BoundField DataField="����ǰ��" HeaderText="����ǰ��"   >
                              <ItemStyle Width="80px"  ForeColor="#595d5a" HorizontalAlign="Center" />
                                    <HeaderStyle Width="80px" HorizontalAlign="Center" />
                          </asp:BoundField>
                         <asp:BoundField DataField="�����������" HeaderText="�����������"   >
                              <ItemStyle Width="120px"  ForeColor="#595d5a" HorizontalAlign="Center" />
                                    <HeaderStyle Width="120px" HorizontalAlign="Center" />
                          </asp:BoundField>
                           <asp:BoundField DataField="������������" HeaderText="������������"   >
                              <ItemStyle Width="120px"  ForeColor="#595d5a" HorizontalAlign="Center" />
                                    <HeaderStyle Width="120px" HorizontalAlign="Center" />
                          </asp:BoundField>
                           <asp:BoundField DataField="������������" HeaderText="������������"   >
                              <ItemStyle Width="120px"  ForeColor="#595d5a" HorizontalAlign="Center" />
                                    <HeaderStyle Width="120px" HorizontalAlign="Center" />
                          </asp:BoundField>
                               <asp:BoundField DataField="����ͻ�����" HeaderText="����ͻ�����"   >
                              <ItemStyle Width="120px"  ForeColor="#595d5a" HorizontalAlign="Center" />
                                    <HeaderStyle Width="120px" HorizontalAlign="Center" />
                          </asp:BoundField>
                              <asp:BoundField DataField="��ע" HeaderText="��ע"   >
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
                              var v1 = tr[i].getElementsByTagName("td")[0].getElementsByTagName("input")[0]; //��ȡgirdview���1��TextBox��ֵ
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
                      v1 = tr[1].getElementsByTagName("td")[8].getElementsByTagName("input")[0]; //��ȡgirdview���1��TextBox��ֵ
                      v1.value = dlgResult;
                  }

              }
              else if (obj == "TextBox10") {
                  dlgResult = window.showModalDialog("../WDate.aspx", window, "dialogWidth:160px; dialogHeight:240px; status:0;");
                  if (dlgResult != undefined) {

                      table = document.getElementById('<%=GridView1.ClientID%>');
                      tr = table.getElementsByTagName("tr");
                      v1 = tr[1].getElementsByTagName("td")[9].getElementsByTagName("input")[0]; //��ȡgirdview���1��TextBox��ֵ
                      v1.value = dlgResult;
                  }

              }
              else if (obj == "TextBox11") {
                  dlgResult = window.showModalDialog("../WDate.aspx", window, "dialogWidth:160px; dialogHeight:240px; status:0;");
                  if (dlgResult != undefined) {

                      table = document.getElementById('<%=GridView1.ClientID%>');
                      tr = table.getElementsByTagName("tr");
                      v1 = tr[1].getElementsByTagName("td")[10].getElementsByTagName("input")[0]; //��ȡgirdview���1��TextBox��ֵ
                      v1.value = dlgResult;
                  }

              }
              else if (obj == "TextBox12") {
                  dlgResult = window.showModalDialog("../WDate.aspx", window, "dialogWidth:160px; dialogHeight:240px; status:0;");
                  if (dlgResult != undefined) {

                      table = document.getElementById('<%=GridView1.ClientID%>');
                      tr = table.getElementsByTagName("tr");
                      v1 = tr[1].getElementsByTagName("td")[11].getElementsByTagName("input")[0]; //��ȡgirdview���1��TextBox��ֵ
                      v1.value = dlgResult;
                  }

              }
              else if (obj == "TextBox13") {
                  dlgResult = window.showModalDialog("../WDate.aspx", window, "dialogWidth:160px; dialogHeight:240px; status:0;");
                  if (dlgResult != undefined) {

                      table = document.getElementById('<%=GridView1.ClientID%>');
                      tr = table.getElementsByTagName("tr");
                      v1 = tr[1].getElementsByTagName("td")[12].getElementsByTagName("input")[0]; //��ȡgirdview���1��TextBox��ֵ
                      v1.value = dlgResult;
                  }

              }
              else if (obj == "TextBox14") {
                  dlgResult = window.showModalDialog("../WDate.aspx", window, "dialogWidth:160px; dialogHeight:240px; status:0;");
                  if (dlgResult != undefined) {

                      table = document.getElementById('<%=GridView1.ClientID%>');
                      tr = table.getElementsByTagName("tr");
                      v1 = tr[1].getElementsByTagName("td")[13].getElementsByTagName("input")[0]; //��ȡgirdview���1��TextBox��ֵ
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