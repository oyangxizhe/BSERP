<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MRPT.aspx.cs" Inherits="WPSS.MRP_MANAGE.MRPT" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>�༭MRP����Ϣ</title>
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
          &gt;MRP��Ϣ </div>
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
       
          </span>
       </div>
              <div class="c13110510" id ="Div20">
   <span class="c13110511" id ="Span5">
                
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
    <asp:LinkButton ID="btnReconcile" runat="server" onclick="btnReconcile_Click" CssClass ="">����������ɹ��ƻ�</asp:LinkButton>
    </span> 
   </div>
          
                 <div class="c13110510" id ="Div33">
   <span class="c13110511" id ="Span8">
                 
          </span>
       </div>
                              <div class="c14060904" id ="Div1">
                <span class="c14060903" id ="Span9">
    <asp:LinkButton ID="LinkButton1" runat="server" onclick="btnReconcile_Click" CssClass =""></asp:LinkButton>
    </span> 
   </div>
          
                 <div class="c13110510" id ="Div2">
   <span class="c13110511" id ="Span10">
                 
          </span>
       </div>
    </div>
<div  id="i13102301" class ="c13102101">
<span  class ="c13102102"><asp:Label ID="prompt" runat="server"  ForeColor="#f80707"></asp:Label></span>
</div> 
  <div class ="c13101902">
      <div class="c13101903" id ="Div24">
          ���ڶ�����</div>
     <div class="c14031403" id ="Div25">
<input id="Text1" type="text"  runat="server"   readonly ="readonly"   class="c14060901" 
            /> 
         <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="Text1" Text="����" runat="server" /></div>
         <div class="c13101903" id ="Div26">
             ID</div>
     <div class="c14031403" id ="Div27">
   <input id="Text2" type="text"  runat ="server" class="c14060901"   readonly ="readonly"/>
   </div>
                    <div class="c13101903" id ="Div28">
                        �Ϻ�</div>
     <div class="c14031403" id ="Div29">
         <input id="Text3" type="text" runat="server" onclick ="f13100202('Text3')"  class="c14060901"  readonly ="readonly"/>
         </div>
             <div class="c13101903" id ="Div30">
                 Ʒ��</div>
     <div class="c14120501" id ="Div31">
<input id="Text4" type="text" runat="server" class="c14060901"  />
<span style =" margin-left :5px;"></span> 
 <span  style =" margin-left :10px"></span>
</div>
           </div>
  <div class ="c13101902">
 
         <div class="c13101903" id ="Div5">
             �ͻ��Ϻ�</div>
     <div class="c14031403" id ="Div6">
   <input id="Text5" type="text"  runat ="server" class="c14060901"  readonly ="readonly" /></div>
  <div class="c13101903" id ="Div38">
                          ���ڶ�������</div>
     <div class="c14031403" id ="Div39">
         <input id="Text6" type="text" runat="server" class="c14060901" /> 
         </div>
           <div class="c13101903" id ="Div3">
               �������</div>
     <div class="c14031403" id ="Div4">
<input id="Text7" type="text" runat="server" class="c14060901"  />
<span style =" margin-left :5px;"></span> 
 <span  style =" margin-left :10px"></span>
</div>
<div class="c13101903" id ="Div7">
             ����ռ�ÿ��</div>
     <div class="c14120501" id ="Div8">
   <input id="Text9" type="text"  runat ="server" class="c14060901"  readonly ="readonly" /></div>
    
           </div> 
           <div class ="c13101902">
 
         
  <div class="c13101903" id ="Div13">
                          ��������</div>
     <div class="c14031403" id ="Div14">
         <input id="Text10" type="text" runat="server" class="c14060901" /> 
         </div>

               <div class="c13101903" id ="Div11">
                        ��������</div>
     <div class="c14031403" id ="Div12">
         <input id="Text8" type="text" runat="server"  class="c14060901"  readonly ="readonly"/>
         
         </div>
 
           </div>   
           <div class ="c14060302">
               (��������=���ڶ�������-(�������-����ռ�ÿ��+��������)) (�ɹ���=������װ������-(�������-����ռ�ÿ��+�ɹ���;))   
           </div>  
           <div class ="c14060302">
              (�����к�"(P)","(S)","(B)",�ֱ��ʾ����ֵΪ�ɹ���λ,��浥λ,BOM��λ)
           </div>
 <div id="i13103001" class ="c13102201">
        <asp:GridView ID="GridView1" runat="server" 
                  
                    AllowSorting="True"   
                    onrowdatabound="GridView1_RowDataBound" 
                        AutoGenerateColumns="False" style="margin-left: 8px" PageSize="15" 
                        CssClass ="c14061101"
                   >
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <Columns > 
                        
            <asp:BoundField DataField="��ID" HeaderText="ID" >
                              <ItemStyle Width="80px"  ForeColor="#595d5a" />
                                    <HeaderStyle Width="80px" HorizontalAlign="Center" />
                          </asp:BoundField>
                          <asp:BoundField DataField="���" HeaderText="���" >
                              <ItemStyle Width="60px"  ForeColor="#595d5a" />
                                    <HeaderStyle Width="60px" HorizontalAlign="Center" />
                          </asp:BoundField>
             <asp:BoundField DataField="���Ϻ�" HeaderText="ԭ����(���Ʒ)����" >
                              <ItemStyle Width="150px"  ForeColor="#595d5a" />
                                    <HeaderStyle Width="150px" HorizontalAlign="Center" />
                          </asp:BoundField>
           <asp:BoundField DataField="��Ʒ��" HeaderText="ԭ�������(���Ʒ)" >
                              <ItemStyle Width="150px"  ForeColor="#595d5a"  />
                                    <HeaderStyle Width="150px" HorizontalAlign="Center" />
                          </asp:BoundField>
  <asp:BoundField DataField="�������" HeaderText="�������"    DataFormatString="{0:0.00}"  >
                              <ItemStyle Width="80px"  ForeColor="#595d5a" HorizontalAlign="Right" />
                                    <HeaderStyle Width="80px" HorizontalAlign="Center" />
                          </asp:BoundField>
                     
                               <asp:BoundField DataField="�����" HeaderText="�����" DataFormatString="{0:0.00}"  >
                              <ItemStyle Width="80px"  ForeColor="#595d5a" HorizontalAlign="Right" />
                                    <HeaderStyle Width="80px" HorizontalAlign="Center" />
                          </asp:BoundField>
                                  <asp:BoundField DataField="������" HeaderText="������" DataFormatString="{0:0.00}"  >
                              <ItemStyle Width="80px"  ForeColor="#595d5a" HorizontalAlign="Right" />
                                    <HeaderStyle Width="80px" HorizontalAlign="Center" />
                          </asp:BoundField>
                                        <asp:BoundField DataField="��������" HeaderText="��������(B)" DataFormatString="{0:0.00}"  >
                              <ItemStyle Width="80px"  ForeColor="#595d5a" HorizontalAlign="Right" />
                                    <HeaderStyle Width="80px" HorizontalAlign="Center" />
                          </asp:BoundField>
                                 <asp:BoundField DataField="BOM��λ" HeaderText="BOM��λ"   >
                              <ItemStyle Width="80px"  ForeColor="#595d5a" />
                                    <HeaderStyle Width="80px" HorizontalAlign="Center" />
                          </asp:BoundField>
                                         <asp:BoundField DataField="������װ������" HeaderText="������װ������(S)" DataFormatString="{0:0.00}"  >
                              <ItemStyle Width="120px"  ForeColor="#595d5a" HorizontalAlign="Right" />
                                    <HeaderStyle Width="120px" HorizontalAlign="Center" />
                          </asp:BoundField>
                                         <asp:BoundField DataField="���õ�λ" HeaderText="���õ�λ" DataFormatString="{0:0.00}"  >
                              <ItemStyle Width="80px"  ForeColor="#595d5a"  />
                                    <HeaderStyle Width="80px" HorizontalAlign="Center" />
                          </asp:BoundField>
                           <asp:BoundField DataField="�������" HeaderText="�������" DataFormatString="{0:0.00}" >
                              <ItemStyle Width="80px"  ForeColor="#595d5a" HorizontalAlign="Right"/>
                                    <HeaderStyle Width="80px" HorizontalAlign="Right" />
                          </asp:BoundField>
                          
                                  <asp:BoundField DataField="����ռ�ÿ��" HeaderText="����ռ�ÿ��(S)"   DataFormatString="{0:0.00}"  >
                              <ItemStyle Width="100px"  ForeColor="#595d5a" HorizontalAlign="Right" />
                                    <HeaderStyle Width="100px" HorizontalAlign="Center" />
                          </asp:BoundField>
                           
                                      <asp:BoundField DataField="�ɹ���;" HeaderText="�ɹ���;(S)"   DataFormatString="{0:0.00}"  >
                              <ItemStyle Width="80px"  ForeColor="#595d5a" HorizontalAlign="Right" />
                                    <HeaderStyle Width="80px" HorizontalAlign="Center" />
                          </asp:BoundField>
                      
                                        <asp:BoundField DataField="�ɹ���" HeaderText="�ɹ���(S)"   DataFormatString="{0:0.00}"  >
                              <ItemStyle Width="80px"  ForeColor="#595d5a" HorizontalAlign="Right" />
                                    <HeaderStyle Width="80px" HorizontalAlign="Center" />
                          </asp:BoundField>
                            <asp:BoundField DataField="��浥λ" HeaderText="��浥λ"  >
                              <ItemStyle Width="80px"  ForeColor="#595d5a"/>
                                    <HeaderStyle Width="80px" HorizontalAlign="Center" />
                          </asp:BoundField>
                                      <asp:BoundField DataField="�ɹ��ۺϿ�滻��" HeaderText="�ɹ��ۺϿ�滻��"   DataFormatString="{0:0.00}"  >
                              <ItemStyle Width="80px"  ForeColor="#595d5a" HorizontalAlign="Right" />
                                    <HeaderStyle Width="80px" HorizontalAlign="Center" />
                          </asp:BoundField>
                                     <asp:BoundField DataField="�ɹ���λ��" HeaderText="�ɹ���λ��(P)"   DataFormatString="{0:0.00}"  >
                              <ItemStyle Width="80px"  ForeColor="#595d5a" HorizontalAlign="Right" />
                                    <HeaderStyle Width="80px" HorizontalAlign="Center" />
                          </asp:BoundField>
                                      <asp:BoundField DataField="�ɹ���λ" HeaderText="�ɹ���λ"   DataFormatString="{0:0.00}"  >
                              <ItemStyle Width="80px"  ForeColor="#595d5a" />
                                    <HeaderStyle Width="80px" HorizontalAlign="Center" />
                          </asp:BoundField>
                              <asp:BoundField DataField="�͹���" HeaderText="�͹���"  >
                              <ItemStyle Width="80px"  ForeColor="#595d5a" />
                                    <HeaderStyle Width="80px" HorizontalAlign="Center" />
                          </asp:BoundField>
                                    <asp:BoundField DataField="���Ͻ׶�" HeaderText="���Ͻ׶�"  >
                              <ItemStyle Width="80px"  ForeColor="#595d5a" />
                                    <HeaderStyle Width="80px" HorizontalAlign="Center" />
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
            
      
          }

         
          function enter2tab(e) {
              if (window.event.keyCode == 13) window.event.keyCode = 9
          }
          document.onkeydown = enter2tab;
          
        </script>

    </form>
</body>
</html>