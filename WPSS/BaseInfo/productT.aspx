<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="productT.aspx.cs" Inherits="WPSS.BaseInfo.productT" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>�༭��Ʒ��Ϣ</title>
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
    <input id="x2" type="hidden"  runat="server" />
        <input id="x3" type="hidden"  runat="server" />
                <div class ="c13101905">
      <div class="c13101906" id ="Div911">
          &gt;�༭��Ʒ��Ϣ</div>
     <div class="c13101907" id ="Div111">
 </div>
    </div>
    <div class ="c13110501">
      <div class="c13110502" id ="Div923">
   <span class="c13110508" id ="Span1">
       <asp:ImageButton ID="btnAdd" runat="server" ImageUrl="~/Image/btnAdd.png"    onclick="btnAdd_Click"  />
          </span>
       </div>
              <div class="c13110510" id ="Div130">
   <span class="c13110511" id ="Span4">
                  (����)
          </span>
       </div>
             <div class="c13110502" id ="Div16">
   <span class="c13110508" id ="Span3">
       <asp:ImageButton ID="btnSave" runat="server" ImageUrl="~/Image/btnSave.png" 
                     onclick="btnSave_Click"  />
          </span>
       </div>
              <div class="c13110510" id ="Div17">
   <span class="c13110511" id ="Span5">
                  (����)
          </span>
       </div>
          
         <div class="c13110507" id ="Div18">
                  <span class="c13110503" id ="Span2">
     <asp:ImageButton ID="btnExit" 
                 runat="server" ImageUrl="~/Image/btnExit.png" Width="60px" 
                      onclick="btnExit_Click" />
          </span>
   </div>
                 <div class="c13110510" id ="Div19">
   <span class="c13110511" id ="Span6">
                     (�˳�)
          </span>
       </div>
       <div class="c13110507" id ="Div23">
                <span class="c13110503" id ="Span7">
    <asp:LinkButton ID="btnReconcile" runat="server" onclick="btnReconcile_Click" CssClass ="">����</asp:LinkButton>
    </span> 
   </div>
          
                 <div class="c13110510" id ="Div34">
   <span class="c13110511" id ="Span8">
                 
          </span>
       </div>
    </div>
<div  id="i13102301" class ="c13102101">
<span  class ="c13102102"><asp:Label ID="prompt" runat="server"  ForeColor="#f80707"></asp:Label></span>
</div> 
  <div class ="c13101902">
      <div class="c13122302" id ="Div2">
          ID</div>
     <div class="c14031403" id ="Div4"> <span style =" margin-right :8px;">
<input id="Text1" type="text"  runat="server"   readonly ="readonly" class="c14031401"/> 
         <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="Text1" Text="����" runat="server" /></span></div>
         <div class="c13122302" id ="Div5">
              ���ڳ�Ʒ�Ϻ�</div>
     <div class="c14031403" id ="Div6">
<span style =" margin-right :8px;">
  <input id="Text2" type="text"  runat ="server" class ="c14031405"  /> 
  <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="Text2" Text="����" runat="server" /></span> 
         </div>
                <div class="c13122302" id ="Div1">
                    Ʒ�� </div>
     <div class="c14031403" id ="Div3">
     <input id="Text3" type="text"  runat ="server"  class="c14033101"  />
 
    </div>     
     <div class="c13122302" id ="Div7">
          �ͻ��Ϻ�
   </div>
     <div class="c14120501" id ="Div8">
     <input id="Text4" type="text"  runat ="server" class="c14031401" />
 </div>
           </div>
             <div class ="c13101902">

          <div class="c13122302" id ="Div12">
                ���</div>
<div class="c14031403" id ="Div13">
  <input id="Text10" type="text"  runat ="server" class="c14031401" />
         </div>
                  <div class="c13122302" id ="Div11" >
                      �ͻ�����</div>
     <div class="c14031403" id ="Div14">
   <input id="Text5" type="text"  runat ="server" class ="c14031405"  /> 
      <span style =" margin-left :5px"><a  href="javascript:f13100202('Text5','');">ѡ�� </a></span> 
         </div>
              <div class="c13122302" id ="Div36">
          �ͻ�����
   </div>
     <div class="c14031403" id ="Div37">
     <input id="Text9" type="text"  runat ="server" class="c13112201" />
 </div>
          <div class="c13122302" id ="Div26">
                 ״̬</div>
    
     <div class="c14120501" id ="Div27">
  <asp:DropDownList ID="DropDownList1" runat="server" CssClass="c14031402" Height="20px">
        <asp:ListItem>����</asp:ListItem>
      <asp:ListItem>Hold</asp:ListItem>
      <asp:ListItem>����</asp:ListItem>
                    </asp:DropDownList>
         </div>
       
           </div>
           <div class ="c13101902">
                                     <div class="c13122302" id ="Div20">
                              ��������(��)
   </div>
  <div class="c14031403" id ="Div35">
<span style =" margin-right :8px;">
  <input id="Text8" type="text"  runat ="server" class ="c14031405"  /> 
  <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="Text8" Text="����" runat="server" /></span> 
         </div> 
   
 

 
           </div>
           <div class ="c13101902">
                          <div class="c14113003" id ="Div24" >
                      1���ɹ���λ</div>
     <div class="c14113002" id ="Div25">
   <span style =" margin-right :8px;">
   <asp:DropDownList ID="DropDownList2" runat="server" CssClass="c14062705">
   </asp:DropDownList>
  </span>
         </div>
                    <div class="c14062702" id ="Div28">
                <span style =" margin-right :15px; margin-left:10px;" >=</span></div>
    
     <div class="c14113002"  id ="Div29">
     <span style =" margin-right :8px;"><input id="Text6" type="text"  runat ="server" class ="c14031405"  /> 
  </span> 
         </div>
                                 <div class="c14113003"  id ="Div30">
                          ����浥λ</div>
    
     <div class="c14113002"  id ="Div31"><span style =" margin-right :8px;">
  <asp:DropDownList ID="DropDownList3" runat="server" CssClass="c14062705" >
  
                    </asp:DropDownList></span> 
         </div>
                             <div class="c14062702" id ="Div32">
                     <span style =" margin-right :15px; margin-left:10px;" >=</span></div>
<div class="c14113002"  id ="Div33">
<span style =" margin-right :8px;">
  <input id="Text7" type="text"  runat ="server" class ="c14031405"  /> 
  </span> 
         </div>
                  <div class="c14113003"  id ="Div9" >
                      ��BOM��λ</div>
                  <div class="c14113002"  id ="Div10">
                      <span style =" margin-right :8px;">
                      <asp:DropDownList ID="DropDownList4" runat="server" CssClass="c14062705">
                      </asp:DropDownList>
                      </span>
                  </div>

           </div>
           <div class ="c14060302">

               (1���ɹ���λ=���ٸ���浥λ=���ٸ�BOM����λ)
         
                
           </div>
            <div class ="c13122402">
          <div class="c13122302" id ="Div108">
                 ��ע</div>
     <div class="c13122401" id ="Div109">

         <asp:TextBox ID="TextBox1" runat="server"   TextMode="MultiLine" CssClass ="c13122403"></asp:TextBox>
         </div>
                
           </div>
           <div class ="c13102201">
               <div class="c13122302" id ="Div21">
                   �ϴ�����
                 </div>
          
     <div class="c13102203" id ="Div22">
             <asp:DataList ID="DataList1" runat="server" RepeatColumns="1"   >
                 ��<ItemTemplate >    
<div style="float:left; width:30px; height:30px; border:0px solid #0000FF; display:none ;">
<%#Eval ("C") %></div>
<input id="File2" type="file" name="File" runat="server" style="width: 300px;  margin-top :5px; margin-left :5px;   border-style: groove; border-width: thin;
"/>
   </div>  
</ItemTemplate> ��
</asp:DataList>
</div>
            <div class="c13102301" id ="Div15">
            <span style =" float :left ; margin-left :30px;">   <asp:Button ID="Button1" runat="server" onclick="btnOnloadFile_Click" 
               Text="�ϴ�" /></span>
        <span style=" margin-left :20px; color :Red ;">ע���ϴ��ĵ���������С��С��20M</span>
                 </div>
           
                 </div>
                  
<div class ="c13102201">
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
                  <asp:TemplateField HeaderText="ɾ��" >
                <ItemTemplate >
                    <asp:LinkButton ID="LinkButton2" runat="server" 
                        OnClientClick="return confirm('��ȷ��ɾ���ü�¼��?');" Text="ɾ��"  CommandName ="delete" ></asp:LinkButton>                     
                </ItemTemplate>
                 <HeaderStyle Width="40px" />
                 <ItemStyle Width="40px"  />
            </asp:TemplateField>
                            <asp:BoundField DataField="FLKEY" HeaderText="�ļ�"   Visible ="false" >
                              <ItemStyle Width="500px" ForeColor="#595d5a" />
                                    <HeaderStyle HorizontalAlign="Center" Width="120px" />
                          </asp:BoundField>
             <asp:TemplateField HeaderText="������ļ�">
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
       
<script type="text/javascript" language="javascript">
    function f13100302(result) {
        if (window.opener != undefined) {
            //for chrome
            window.opener.returnValue = result;
        }
        else {
            window.returnValue = result;
        }
        window.close();
    }
    window.onload = function onload1() {
        var Invocation = document.getElementById("hint").value;
        if (Invocation != "") {
            document.getElementById("i13102301").style.display = "block";
            document.all("prompt").innerText = Invocation;
        }
        else {
            document.getElementById("i13102301").style.display = "none";
        }
        document.getElementById("Text2").focus();
    }
    function f13100202(obj, obj1) {
        var dlgResult;
        if (obj == "Text5") {
            dlgResult = window.showModalDialog("../SellManage/Customerinfo.aspx", window, "dialogWidth:970px; dialogHeight:490px; status:0");
            if (dlgResult != undefined) {
                document.getElementById("Text5").value = dlgResult[5];
                document.getElementById("Text9").value = dlgResult[1];

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