<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WORKORDERT.aspx.cs" Inherits="WPSS.WORKORDER_MANAGE.WORKORDERT" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>�༭������Ϣ</title>
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
          &gt;������Ϣ </div>
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
      <div class="c13110507" id ="Div32">
                <span class="c13110503" id ="Span7">
    <asp:LinkButton ID="btnCancellation" runat="server" onclick="btnCancellation_Click" CssClass ="">����</asp:LinkButton>
    </span> 
   </div>
          
                 <div class="c13110510" id ="Div33">
   <span class="c13110511" id ="Span8">
                 
          </span>
       </div>
             <div class="c13110507" id ="Div49">
                <span class="c13110503" id ="Span9">
    <asp:LinkButton ID="btnReduction_Cancellation" runat="server" onclick="btnReduction_Cancellation_Click" CssClass ="">ȡ������</asp:LinkButton>
    </span> 
   </div>
          
                 <div class="c13110510" id ="Div50">
   <span class="c13110511" id ="Span10">
                 
          </span>
       </div>          
    </div>
<div  id="i13102301" class ="c13102101">
<span  class ="c13102102"><asp:Label ID="prompt" runat="server"  ForeColor="#f80707"></asp:Label></span>
</div> 
  <div class ="c13101902">
      <div class="c13101903" id ="Div24">
          ������</div>
     <div class="c14031403" id ="Div25">
<input id="Text1" type="text"  runat="server"   readonly ="readonly"   class="c14031401" /> 
         <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="Text1" Text="����" runat="server" /></div>
                 <div class="c13101903" id ="Div43">
                     �ͻ�ID</div>
     <div class="c14031403" id ="Div44">
   <input id="Text17" type="text"  runat ="server" class ="c13102103"  /> 
      <span style =" margin-left :5px"><a  href="javascript:f13100202('Text17','');">ѡ�� </a></span> 
         </div>
            <div class="c13101903" id ="Div45">
                �ͻ�����</div>
 <div class="c14031403" id ="Div46">
   <input id="Text18" type="text"  runat ="server"  class="c14062901" /></div>
             <div class="c13101903" id ="Div47">
                 �ͻ�����</div>
    <div class="c14120501" id ="Div48">
<input id="Text19" type="text" runat="server" class ="c14060902" />
<span style =" margin-left :5px;"></span> 

</div>
           </div>
                     <div class ="c13101902">
    <div class="c13101903" id ="Div26">
             ID</div>
     <div class="c14031403" id ="Div27">
<input id="Text2" type="text"  runat="server"   readonly ="readonly"    class ="c14120106" /> 
<a  href="javascript:f13100202('Text2','');">
         ѡ�� </a>
   <asp:LinkButton ID="btnSure" runat="server" onclick="btnSure_Click"   ForeColor ="Blue">ȷ��</asp:LinkButton>
   </div>
                    <div class="c13101903" id ="Div28">
                        �Ϻ�</div>
     <div class="c14031403"  id ="Div29">
         <input id="Text3" type="text" runat="server" onclick ="f13100202('Text3')"  class="c14060901"  readonly ="readonly"/>
         </div>
              <div class="c13101903" id ="Div30">
                  Ʒ��</div>
     <div class="c14031403" id ="Div31">
<input id="Text4" type="text" runat="server" class ="c14060902" />
<span style =" margin-left :5px;"></span> 

</div>
        <div class="c13101903" id ="Div5">
             �ͻ��Ϻ�</div>
     <div class="c14120501" id ="Div6">
   <input id="Text5" type="text"  runat ="server" class="c14060901"  readonly ="readonly" /></div>
   </div>
  <div class ="c13101902">

 
  <div class="c13101903" id ="Div38">
                          ��������</div>
     <div class="c14031403" id ="Div39">
         <input id="Text6" type="text" runat="server" class ="c14072604" /> 
           <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="Text6" Text="����" runat="server" />
         </div>
              <div class="c13101903" id ="Div13">
                  ���ڶ�����</div>
     <div class="c14031403" id ="Div14">
<input id="Text7" type="text" runat="server"  readonly ="readonly" class="c14031401" />
<span style =" margin-left :5px;"></span> 
 <span  style =" margin-left :10px"></span>
</div>
         <div class="c13101903" id ="Div15">
             ��������</div>
     <div class="c14031403"  id ="Div16">
   <input id="Text8" type="text"  runat ="server" class="c14031401" onclick ="f13100202('Text8')" readonly ="readonly" /></div>
                <div class="c13101903" id ="Div21">
                        �����������</div>
     <div class="c14120501" id ="Div34">
         <input id="Text9" type="text" runat="server" class="c14031401" onclick ="f13100202('Text9')"  readonly ="readonly"/>
         
         </div>
           </div>   
           
           <div class ="c13101902">

      
              <div class="c13101903" id ="Div35">
                  ������������</div>
     <div class="c14031403"  id ="Div36">
<input id="Text10" type="text" runat="server" onclick ="f13100202('Text10')" class="c14031401" />
<span style =" margin-left :5px;"></span> 
 <span  style =" margin-left :10px"></span>
</div>
         <div class="c13101903" id ="Div37">
             ������������</div>
     <div class="c14031403"  id ="Div40">
   <input id="Text11" type="text"  runat ="server" class="c14031401" onclick ="f13100202('Text11')"  readonly ="readonly" /></div>
                   <div class="c13101903" id ="Div41">
                        ���齻��</div>
     <div class="c14031403" id ="Div42">
         <input id="Text12" type="text" runat="server"  class="c14031401"  onclick ="f13100202('Text12')" readonly ="readonly"/>
         
         </div>
              <div class="c13101903" id ="Div1">
                  BOM���</div>
     <div class="c14120501" id ="Div2">
<input id="Text13" type="text" runat="server" class="c14060901" />
<span style =" margin-left :5px;"></span> 
 <span  style =" margin-left :10px"></span>
</div>
           </div>   
           <div class ="c13101902">

         <div class="c13101903" id ="Div3">
             BOM�汾</div>
     <div class="c14031403" id ="Div4">
   <input id="Text14" type="text"  runat ="server" class="c14060901"  readonly ="readonly" />
   </div>
        <div class="c13101903" id ="Div7">
            ���������</div>
     <div class="c14031403" id ="Div8">
<input id="Text15" type="text" runat="server" class="c14072605"/>
<span style =" margin-left :5px;"></span> 
 <span  style =" margin-left :10px"></span>
</div>
         <div class="c13101903" id ="Div51">
             �ѱ�������</div>
     <div class="c14031403" id ="Div52">
   <input id="Text20" type="text"  runat ="server" class="c14072605"   />
   </div>
            <div class="c13101903" id ="Div11">
                δ�������</div>
     <div class="c14120501" id ="Div12">
   <input id="Text16" type="text"  runat ="server" class="c14072605" />
 
 
   </div>
   </div>
 
           
<div id="i13103001" class ="c14061302">
             
          <asp:GridView ID="GridView1" runat="server" 
                    AllowSorting="True"   
                    onrowdatabound="GridView1_RowDataBound" 
                        AutoGenerateColumns="False"  PageSize="15" 
                        CssClass ="c14061301" 
                   >
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <Columns > 
           <asp:TemplateField HeaderText="ID(�����ID)" >
                <ItemTemplate >
                                <asp:TextBox ID="TextBox1" runat="server"   CssClass ="c14071603" ></asp:TextBox>   
                                <a  href="javascript:f13100203('TextBox1','<%#Eval ("���") %>','<%#Eval ("BOM_ID") %>' );">
                                ѡ��</a>   
                </ItemTemplate>
                 <HeaderStyle Width="11%" />
                 <ItemStyle Width="11%"  />
            </asp:TemplateField> 
            
              <asp:TemplateField HeaderText="���">
                <ItemTemplate >
                 <asp:TextBox ID="TextBox2" runat="server"  Text='<%#Eval ("���") %>' CssClass="c14071612" ></asp:TextBox>                     
                </ItemTemplate>
                  <HeaderStyle Width="4%" />
                 <ItemStyle Width="4%"  />
            </asp:TemplateField>
             <asp:TemplateField HeaderText="BOM ID" >
                <ItemTemplate >
                                <asp:TextBox ID="TextBox3" runat="server" Text='<%#Eval ("BOM_ID") %>'   CssClass ="c14072602"  ></asp:TextBox>   
                                  
                </ItemTemplate>
                  <HeaderStyle Width="6%" />
                 <ItemStyle Width="6%"  />
            </asp:TemplateField>
      
               <asp:TemplateField HeaderText="���ϱ���">
                <ItemTemplate >
                 <asp:TextBox ID="TextBox4" runat="server"   CssClass ="c14070103" ></asp:TextBox>                     
                </ItemTemplate>
                   <HeaderStyle Width="6%" />
                 <ItemStyle Width="6%"  />
            </asp:TemplateField>
                    <asp:TemplateField HeaderText="�������">
                <ItemTemplate >
                 <asp:TextBox ID="TextBox5" runat="server"    CssClass ="c14070103"  ></asp:TextBox>                     
                </ItemTemplate>
                    <HeaderStyle Width="6%" />
                 <ItemStyle Width="6%"  />
            </asp:TemplateField> 
         
                          <asp:TemplateField HeaderText="�ͻ��Ϻ�">
                <ItemTemplate >
                 <asp:TextBox ID="TextBox6" runat="server" CssClass =" c14071613" ></asp:TextBox>                     
                </ItemTemplate>
                   <HeaderStyle Width="6%" />
                 <ItemStyle Width="6%"  />
            </asp:TemplateField>
         
                    <asp:TemplateField HeaderText="�������">
                <ItemTemplate >
                 <asp:TextBox ID="TextBox8" runat="server"  CssClass ="c14071615"  ></asp:TextBox>                     
                </ItemTemplate>
                   <HeaderStyle Width="6%" />
                 <ItemStyle Width="6%"  />
            </asp:TemplateField>
               <asp:TemplateField HeaderText="�����">
                <ItemTemplate >
                 <asp:TextBox ID="TextBox9" runat="server"  CssClass ="c14071615" ></asp:TextBox>                     
                </ItemTemplate>
                  <HeaderStyle Width="6%" />
                 <ItemStyle Width="6%"  />
            </asp:TemplateField> 
                     <asp:TemplateField HeaderText="������">
                <ItemTemplate >
                 <asp:TextBox ID="TextBox10" runat="server"    CssClass ="c14071615" ></asp:TextBox>                     
                </ItemTemplate>
                 <HeaderStyle Width="6%" />
                 <ItemStyle Width="6%"  />
            </asp:TemplateField> 
   
                          <asp:TemplateField HeaderText="��������">
                <ItemTemplate >
               <asp:TextBox ID="TextBox11" runat="server"   CssClass ="c13112302"></asp:TextBox>                      
                </ItemTemplate>
                  <HeaderStyle Width="6%" />
                 <ItemStyle Width="6%"  />
            </asp:TemplateField> 
                      <asp:TemplateField HeaderText="MPA_STOCK">
                <ItemTemplate >
                 <asp:TextBox ID="TextBox12" runat="server"  CssClass ="c14072801"></asp:TextBox>                     
                </ItemTemplate>
                <HeaderStyle Width="6%" />
                 <ItemStyle Width="6%"  />
            </asp:TemplateField> 
              <asp:TemplateField HeaderText="MPA_BOM">
                <ItemTemplate >
                 <asp:TextBox ID="TextBox13" runat="server"   CssClass ="c14071615"></asp:TextBox>                     
                </ItemTemplate>
                     <HeaderStyle Width="6%" />
                 <ItemStyle Width="6%"  />
            </asp:TemplateField>
              <asp:TemplateField HeaderText="BOM��λ">
                <ItemTemplate >
                 <asp:TextBox ID="TextBox14" runat="server"  CssClass ="c14071616"></asp:TextBox>                     
                </ItemTemplate>
                     <HeaderStyle Width="6%" />
                 <ItemStyle Width="6%"  />
            </asp:TemplateField> 
                    <asp:TemplateField HeaderText="��浥λ">
                <ItemTemplate >
                 <asp:TextBox ID="TextBox15" runat="server"  CssClass ="c14071616"></asp:TextBox>                     
                </ItemTemplate>
                    <HeaderStyle Width="4%" />
                 <ItemStyle Width="4%"  />
            </asp:TemplateField>
                         <asp:TemplateField HeaderText="�͹���">
                <ItemTemplate >
                 <asp:TextBox ID="TextBox16" runat="server"  CssClass ="c14071616"></asp:TextBox>                     
                </ItemTemplate>
              <HeaderStyle Width="4%" />
                 <ItemStyle Width="4%"  />
            </asp:TemplateField> 
                                     <asp:TemplateField HeaderText="���Ͻ׶�">
                <ItemTemplate >
                 <asp:TextBox ID="TextBox17" runat="server"   CssClass ="c14070103" ></asp:TextBox>                     
                </ItemTemplate>
                <HeaderStyle Width="6%" />
                 <ItemStyle Width="6%"  />
            </asp:TemplateField> 
                                <asp:TemplateField HeaderText="���"  >
                <ItemTemplate >
                 <asp:TextBox ID="TextBox7" runat="server"   CssClass ="c14070203"  ></asp:TextBox>                     
                </ItemTemplate>
                    <HeaderStyle Width="8%" />
                 <ItemStyle Width="8%"  />
            </asp:TemplateField> 
                    </Columns>
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" Font-Bold="False" />   
                </asp:GridView>
                </div>
 
 <div id="Div55" class ="c14061302">
             
          <asp:GridView ID="GridView2" runat="server" 
                    AllowSorting="True"   
                    onrowdatabound="GridView1_RowDataBound" 
                        AutoGenerateColumns="False"  PageSize="15" 
                        CssClass ="c14072701" 
                   >
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <Columns > 
           <asp:TemplateField HeaderText="ID(�����ID)" >
                <ItemTemplate >
                                <asp:TextBox ID="TextBox1" runat="server" Text='<%#Eval ("��ID") %>'   CssClass ="c14071603" ></asp:TextBox>   
                                <a  href="javascript:f13100204('TextBox1','<%#Eval ("���") %>','<%#Eval ("BOM_ID") %>');">
                                ѡ��</a>   
                </ItemTemplate>
                 <HeaderStyle CssClass ="id_yellow" />
                 <ItemStyle  />
            </asp:TemplateField> 
            
              <asp:TemplateField HeaderText="���">
                <ItemTemplate >
                 <asp:TextBox ID="TextBox2" runat="server"  Text='<%#Eval ("���") %>' CssClass="c14071612" ></asp:TextBox>                     
                </ItemTemplate>
                 <HeaderStyle  CssClass ="sn"/>
                 <ItemStyle  />
            </asp:TemplateField>
             <asp:TemplateField HeaderText="BOM ID" >
                <ItemTemplate >
                                <asp:TextBox ID="TextBox3" runat="server" Text='<%#Eval ("BOM_ID") %>'   CssClass ="c14072602"  ></asp:TextBox>   
                                  
                </ItemTemplate>
                 <HeaderStyle CssClass ="id_read " />
                 <ItemStyle />
            </asp:TemplateField>
      
               <asp:TemplateField HeaderText="���ϱ���">
                <ItemTemplate >
                 <asp:TextBox ID="TextBox4" runat="server"  Text='<%#Eval ("���Ϻ�") %>' CssClass ="c14070103" ></asp:TextBox>                     
                </ItemTemplate>
                 <HeaderStyle CssClass ="c14072705 " />
                 <ItemStyle />
            </asp:TemplateField>
                    <asp:TemplateField HeaderText="�������">
                <ItemTemplate >
                 <asp:TextBox ID="TextBox5" runat="server"  Text='<%#Eval ("��Ʒ��") %>'   CssClass ="c14070103"  ></asp:TextBox>                     
                </ItemTemplate>
                 <HeaderStyle CssClass ="c14072705 "  />
                 <ItemStyle />
            </asp:TemplateField> 
         
                          <asp:TemplateField HeaderText="�ͻ��Ϻ�">
                <ItemTemplate >
                 <asp:TextBox ID="TextBox6" runat="server" Text='<%#Eval ("�ӿͻ��Ϻ�") %>' CssClass =" c14071613" ></asp:TextBox>                     
                </ItemTemplate>
                 <HeaderStyle CssClass ="c14072705 " />
                 <ItemStyle />
            </asp:TemplateField>
               
                    <asp:TemplateField HeaderText="�������">
                <ItemTemplate >
                 <asp:TextBox ID="TextBox8" runat="server" Text='<%#Eval ("�������") %>' CssClass ="c14071615"  ></asp:TextBox>                     
                </ItemTemplate>
                   <HeaderStyle Width="5%" />
                 <ItemStyle Width="5%"/>
            </asp:TemplateField>
               <asp:TemplateField HeaderText="�����">
                <ItemTemplate >
                 <asp:TextBox ID="TextBox9" runat="server" Text='<%#Eval ("�����") %>' CssClass ="c14071615" ></asp:TextBox>                     
                </ItemTemplate>
                 <HeaderStyle CssClass ="count_read " />
                 <ItemStyle />
            </asp:TemplateField> 
                     <asp:TemplateField HeaderText="������">
                <ItemTemplate >
                 <asp:TextBox ID="TextBox10" runat="server" Text='<%#Eval ("������") %>'   CssClass ="c14071615" ></asp:TextBox>                     
                </ItemTemplate>
                 <HeaderStyle CssClass ="count_read "/>
                 <ItemStyle />
            </asp:TemplateField> 
   
                          <asp:TemplateField HeaderText="��������">
                <ItemTemplate >
               <asp:TextBox ID="TextBox11" runat="server"  Text='<%#Eval ("��������") %>' CssClass ="c13112302" ></asp:TextBox>                      
                </ItemTemplate>
                 <HeaderStyle Width="6%" />
                 <ItemStyle Width="6%"/>
            </asp:TemplateField> 
           
              <asp:TemplateField HeaderText="MPA_STOCK">
                <ItemTemplate >
                 <asp:TextBox ID="TextBox13" runat="server" Text='<%#Eval ("MPA_TO_STOCK") %>' CssClass ="c14072801"></asp:TextBox>                     
                </ItemTemplate>
                  <HeaderStyle Width="6%" />
                 <ItemStyle Width="6%"/>
            </asp:TemplateField> 
              <asp:TemplateField HeaderText="MPA_BOM">
                <ItemTemplate >
                 <asp:TextBox ID="TextBox14" runat="server" Text='<%#Eval ("MPA_TO_BOM") %>'  CssClass ="c14071615"></asp:TextBox>                     
                </ItemTemplate>
                   <HeaderStyle Width="6%" />
                 <ItemStyle Width="6%"/>
            </asp:TemplateField> 
               <asp:TemplateField HeaderText="BOM��λ">
                <ItemTemplate >
                 <asp:TextBox ID="TextBox12" runat="server" Text='<%#Eval ("BOM��λ") %>'  CssClass ="c14071616"></asp:TextBox>                     
                </ItemTemplate>
              <HeaderStyle Width="6%" />
                 <ItemStyle Width="6%"/>
            </asp:TemplateField> 
                 <asp:TemplateField HeaderText="��װ����">
                <ItemTemplate >
                 <asp:TextBox ID="TextBox15" runat="server" Text='<%#Eval ("������װ������") %>'   CssClass ="c14071615" ></asp:TextBox>                     
                </ItemTemplate>
                    <HeaderStyle Width="6%" />
                 <ItemStyle Width="6%"/>
            </asp:TemplateField> 
                    <asp:TemplateField HeaderText="�ۼ�����">
                <ItemTemplate >
                 <asp:TextBox ID="TextBox16" runat="server" Text='<%#Eval ("�ۼ�������") %>'   CssClass ="c14071615"></asp:TextBox>                     
                </ItemTemplate>
                   <HeaderStyle Width="6%" />
                 <ItemStyle Width="6%"/>
            </asp:TemplateField> 
                  <asp:TemplateField HeaderText="�ۼ�����">
                <ItemTemplate >
                 <asp:TextBox ID="TextBox17" runat="server" Text='<%#Eval ("�ۼ�������") %>'  CssClass ="c14071615" ></asp:TextBox>                     
                </ItemTemplate>
                  <HeaderStyle Width="6%" />
                 <ItemStyle Width="6%"/>
            </asp:TemplateField> 
                       <asp:TemplateField HeaderText="δ������">
                <ItemTemplate >
                 <asp:TextBox ID="TextBox18" runat="server" Text='<%#Eval ("δ������") %>'   CssClass ="c14071615" Width ="60px"></asp:TextBox>                     
                </ItemTemplate>
                   <HeaderStyle Width="6%" />
                 <ItemStyle Width="6%"/>
            </asp:TemplateField> 
                     <asp:TemplateField HeaderText="��浥λ">
                <ItemTemplate >
                 <asp:TextBox ID="TextBox19" runat="server" Text='<%#Eval ("��浥λ") %>'  CssClass ="c14071615" Width ="60px"></asp:TextBox>                     
                </ItemTemplate>
                    <HeaderStyle Width="4%" />
                 <ItemStyle Width="4%"/>
            </asp:TemplateField> 
                         <asp:TemplateField HeaderText="�͹���">
                <ItemTemplate >
                 <asp:TextBox ID="TextBox20" runat="server" Text='<%#Eval ("�͹���") %>' CssClass ="c14071615" Width ="60px"></asp:TextBox>                     
                </ItemTemplate>
                      <HeaderStyle Width="6%" />
                 <ItemStyle Width="6%"/>
            </asp:TemplateField> 
                                     <asp:TemplateField HeaderText="���Ͻ׶�">
                <ItemTemplate >
                 <asp:TextBox ID="TextBox21" runat="server" Text='<%#Eval ("���Ͻ׶�") %>' CssClass ="c14071615" Width ="60px"></asp:TextBox>                     
                </ItemTemplate>
                  <HeaderStyle Width="6%" />
                 <ItemStyle Width="6%"/>
            </asp:TemplateField> 
                    <asp:TemplateField HeaderText="���"  >
                <ItemTemplate >
                 <asp:TextBox ID="TextBox7" runat="server"  Text='<%#Eval ("�ӹ��") %>' CssClass ="c14070203"  ></asp:TextBox>                     
                </ItemTemplate>
                 <HeaderStyle CssClass ="c14072705 "  />
                 <ItemStyle />
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
         function f13100202(obj, obj1)
             {
                   if (obj == "Text2") {
              dlgResult = window.showModalDialog("../BaseInfo/Wareinfo.aspx?CUID=" + document.getElementById("cuid").value + "&nature=workorder_mst", window, "dialogWidth:970px; dialogHeight:490px; status:0");
                  if (dlgResult != undefined) {
                      document.getElementById("Text2").value = dlgResult[0];
                      document.getElementById("Text3").value = dlgResult[1];
                      document.getElementById("Text4").value = dlgResult[2];
                      document.getElementById("Text5").value = dlgResult[3];
                 }
              }
            else  if (obj == "Text8") {
                  dlgResult = window.showModalDialog("../WDate.aspx", window, "dialogWidth:160px; dialogHeight:240px; status:0;");
                  if (dlgResult != undefined) {
                      document.getElementById("Text8").value = dlgResult;
                  }

              }
              else if (obj == "Text9") {
                  dlgResult = window.showModalDialog("../WDate.aspx", window, "dialogWidth:160px; dialogHeight:240px; status:0;");
                  if (dlgResult != undefined) {
                      document.getElementById("Text9").value = dlgResult;
                  }
              }
              else if (obj == "Text10") {
                  dlgResult = window.showModalDialog("../WDate.aspx", window, "dialogWidth:160px; dialogHeight:240px; status:0;");
                  if (dlgResult != undefined) {
                      document.getElementById("Text10").value = dlgResult;
                  }

              }
              else if (obj == "Text11") {
                  dlgResult = window.showModalDialog("../WDate.aspx", window, "dialogWidth:160px; dialogHeight:240px; status:0;");
                  if (dlgResult != undefined) {
                      document.getElementById("Text11").value = dlgResult;
                  }
              }
              else if (obj == "Text12") {
                  dlgResult = window.showModalDialog("../WDate.aspx", window, "dialogWidth:160px; dialogHeight:240px; status:0;");
                  if (dlgResult != undefined) {
                      document.getElementById("Text12").value = dlgResult;
                  }
              }
              else if (obj == "Text17") {
                  dlgResult = window.showModalDialog("../SellManage/Customerinfo.aspx", window, "dialogWidth:970px; dialogHeight:490px; status:0");
                  if (dlgResult != undefined) {
                      document.getElementById("Text17").value = dlgResult[0];
                      document.getElementById("Text18").value = dlgResult[5];
                      document.getElementById("Text19").value = dlgResult[1];
                      document.getElementById("cuid").value = dlgResult[0];
                  }
              }
          }
          function f13100203(obj, obj1,obj2) {
               if (obj == "TextBox1") {
                   dlgResult = window.showModalDialog("../bom_manage/replace_materiel.aspx?wareid=" +obj2 +
                   "&nature=workorder_det", window, "dialogWidth:970px; dialogHeight:490px; status:0");
                  if (dlgResult != undefined) {
                      var table = document.getElementById('<%=GridView1.ClientID%>');
                      var tr = table.getElementsByTagName("tr");
                      for (i = 1; i < tr.length; i++) {
                          if (obj1 == i) {
                              var v0 = tr[i].getElementsByTagName("td")[0].getElementsByTagName("input")[0]; //��ȡgirdview���1��TextBox��ֵ
                              var v1 = tr[i].getElementsByTagName("td")[3].getElementsByTagName("input")[0];
                              var v2 = tr[i].getElementsByTagName("td")[4].getElementsByTagName("input")[0];
                              var v3 = tr[i].getElementsByTagName("td")[5].getElementsByTagName("input")[0];
                              var v4 = tr[i].getElementsByTagName("td")[6].getElementsByTagName("input")[0];
                         
                              v0.value = dlgResult[0];
                              v1.value = dlgResult[1];
                              v2.value = dlgResult[2];
                              v3.value = dlgResult[3];
                              tr[i].getElementsByTagName("td")[6].getElementsByTagName("input")[0].value = dlgResult[6];
                              tr[i].getElementsByTagName("td")[7].getElementsByTagName("input")[0].value = dlgResult[7];
                              tr[i].getElementsByTagName("td")[8].getElementsByTagName("input")[0].value = dlgResult[8];
                              tr[i].getElementsByTagName("td")[10].getElementsByTagName("input")[0].value = dlgResult[9];  
                              tr[i].getElementsByTagName("td")[11].getElementsByTagName("input")[0].value = dlgResult[10]; 
                              tr[i].getElementsByTagName("td")[12].getElementsByTagName("input")[0].value = dlgResult[11];  
                              tr[i].getElementsByTagName("td")[13].getElementsByTagName("input")[0].value = dlgResult[12];
                              tr[i].getElementsByTagName("td")[14].getElementsByTagName("input")[0].value = dlgResult[13];
                              tr[i].getElementsByTagName("td")[15].getElementsByTagName("input")[0].value = dlgResult[14];
                              tr[i].getElementsByTagName("td")[16].getElementsByTagName("input")[0].value = dlgResult[4];
                              break;
                              /*dlgResult[0] ��ID, dlgResult[1] ���Ϻ�,dlgResult[2] ��Ʒ��,dlgResult[3] �ӿͻ��Ϻ�,dlgResult[4] �ӹ��,dlgResult[5] Ʒ��*/
                              /*dlgResult[6] �������, dlgResult[7] �����,dlgResult[8] ������ ,dlgResult[9] MPA_TO_STOCK,dlgResult[10] STOCK_TO_BOM*/
                              /*dlgResult[11] BOM��λ*/
                              /*dlgResult[12] ��浥λ, dlgResult[13] �͹���,dlgResult[14] ���Ͻ׶�*/
                          }
                      }
                  }
              }
          }
          function f13100204(obj, obj1, obj2) {

              if (obj == "TextBox1") {
                  dlgResult = window.showModalDialog("../bom_manage/replace_materiel.aspx?wareid=" + obj2 +
                   "&nature=workorder_det", window, "dialogWidth:970px; dialogHeight:490px; status:0");

                  if (dlgResult != undefined) {

                      var table = document.getElementById('<%=GridView2.ClientID%>');
                      var tr = table.getElementsByTagName("tr");
                      for (i = 1; i < tr.length; i++) {
                          if (obj1 == i) {

                              tr[i].getElementsByTagName("td")[0].getElementsByTagName("input")[0].value = dlgResult[0];
                              tr[i].getElementsByTagName("td")[3].getElementsByTagName("input")[0].value = dlgResult[1];
                              tr[i].getElementsByTagName("td")[4].getElementsByTagName("input")[0].value = dlgResult[2];
                              tr[i].getElementsByTagName("td")[5].getElementsByTagName("input")[0].value = dlgResult[3];
                            
                              tr[i].getElementsByTagName("td")[6].getElementsByTagName("input")[0].value = dlgResult[6];
                              tr[i].getElementsByTagName("td")[7].getElementsByTagName("input")[0].value = dlgResult[7];
                              tr[i].getElementsByTagName("td")[8].getElementsByTagName("input")[0].value = dlgResult[8];
                              tr[i].getElementsByTagName("td")[10].getElementsByTagName("input")[0].value = dlgResult[9];
                              tr[i].getElementsByTagName("td")[11].getElementsByTagName("input")[0].value = dlgResult[10];
                              tr[i].getElementsByTagName("td")[12].getElementsByTagName("input")[0].value = dlgResult[11];

                              tr[i].getElementsByTagName("td")[17].getElementsByTagName("input")[0].value = dlgResult[12];
                              tr[i].getElementsByTagName("td")[18].getElementsByTagName("input")[0].value = dlgResult[13];
                              tr[i].getElementsByTagName("td")[19].getElementsByTagName("input")[0].value = dlgResult[14];
                              tr[i].getElementsByTagName("td")[20].getElementsByTagName("input")[0].value = dlgResult[4];
                              /*dlgResult[0] ��ID, dlgResult[1] ���Ϻ�,dlgResult[2] ��Ʒ��,dlgResult[3] �ӿͻ��Ϻ�,dlgResult[4] �ӹ��,dlgResult[5] Ʒ��*/
                              /*dlgResult[6] �������, dlgResult[7] �����,dlgResult[8] ������ ,dlgResult[9] MPA_TO_STOCK,dlgResult[10] STOCK_TO_BOM*/
                              /*dlgResult[11] BOM��λ*/
                              /*dlgResult[12] ��浥λ, dlgResult[13] �͹���,dlgResult[14] ���Ͻ׶�*/
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