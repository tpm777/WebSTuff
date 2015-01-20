<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" ClientIDMode="Static"  CodeFile="RFQMain.aspx.cs"   EnableViewStateMac="false"   Inherits="RFQMain" %>





<%@ Register Assembly="obout_ComboBox" Namespace="Obout.ComboBox" TagPrefix="cc3" %>

<%@ Register Assembly="obout_Grid_NET" Namespace="Obout.Grid" TagPrefix="cc2" %>

<%@ Register TagPrefix="obout" Namespace="Obout.Interface" Assembly="obout_Interface" %>


<%@ Register TagPrefix="obout" Namespace="Obout.Interface" Assembly="obout_Interface" %>





<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

 


    <link rel="stylesheet" href="../StyleSheet.css" type="text/css" />
    <style type="text/css">
        .auto-style22
        {
            border-style: none;
            border-color: inherit;
            border-width: medium;
            width: 200px;
            outline: none;
            background-color: #F0F0F0;
/* Standard syntax */padding: 0px;
            height: 21px;
        }
        .auto-style23
        {
            border-style: none;
            border-color: inherit;
            border-width: medium;
            width: 230px;
            outline: none;
            background-color: #FCFCFC;
            top: 0px;
            left: 0px;
            padding: 0px;
            height: 21px;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

                


              <asp:HiddenField ID="hfldUniqueTabGuid" runat="server" /> 
               <asp:Panel runat="server" ID="Test1" Width="1200px">
                   <asp:Panel runat="server" ID="pnlTestADProfile">
                   <table style="border: 0px; border-collapse: collapse">
                       <tr>
                           <td class="removeTableBordersLbl">Test AD Group Profile</td>
                           <td class="removeTableBordersLbl"> 
                                  <cc3:ComboBox ID="cmbUserProfiles" runat="server" DataSourceID="sqlUserSecurityProfiles" DataTextField="UserProfileName" EmptyText="Select UserProfile" MenuWidth="150px" Width="150px" AutoPostBack="true" OnSelectedIndexChanged="cmbUserProfiles_SelectedIndexChanged" >
                                  </cc3:ComboBox>
                           </td>
                       </tr>

                   </table>
                 </asp:Panel>
            <div id="RFQHeader" class="content" style="width:inherit; height: 125px;" runat="server">
                <table id="Main1" style="border: 0px; border-collapse: collapse" class="tableHdr">
                            <tr>
                        <td class="removeTableBordersLbl">
                            <asp:Label ID="lblRFQNum" runat="server" Text="RFQ #:"></asp:Label>
                        </td>
                        <td class="removeTableBordersTXB">
                            <asp:TextBox ID="txbRFQNum" runat="server" ReadOnly="True" BorderColor="White" BorderStyle="None" CssClass="removeTextBoxBordersTXB">
                                    
                            </asp:TextBox>
                        </td>
                        <td class="removeTableBordersLbl">
                            <asp:Label ID="lblDatedCreated" runat="server" Text="Created:"></asp:Label>
                        </td>
                        <td class="removeTableBordersTXB">
                            <asp:TextBox ID="txbDateCreated" runat="server" Width="150px" BorderColor="White" BorderStyle="None" ReadOnly="True" CssClass="removeTableBordersTXB"></asp:TextBox>
                        </td>
     
       <td class="removeTableBordersLbl">
                            <asp:Label ID="lblParentCustomer" runat="server" Text="Account (CRM):" Width="190px"></asp:Label>
                        </td>
                        <td class="removeTableBordersTXB">
                            <asp:Label ID="lblParentCustomerName" runat="server" BorderColor="White" BorderStyle="None" CssClass="removeTableBordersTXB" Width="200px"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="removeTableBordersLbl">
                            <asp:Label ID="lblRequestor" runat="server" Text="Owner (CRM):"></asp:Label>

                        </td>
                        <td class="removeTableBordersTXB">
                            <asp:TextBox ID="txbRequestor" runat="server" ReadOnly="True" BorderColor="White" BorderStyle="None" CssClass="removeTextBoxBordersTXB"></asp:TextBox>
                        </td>
                        <td class="removeTableBordersLbl">

                            <asp:Label ID="lblDateSubMitted" runat="server" Text="Submitted:" Width="150px"></asp:Label>

                        </td>
                        <td class="removeTableBordersTXB">

                            <asp:TextBox ID="txbDateSubmitted" runat="server" AutoPostBack="true" BorderColor="White" BorderStyle="None" CssClass="removeTableBordersTXB" ReadOnly="True" Width="150px"></asp:TextBox>

                        </td>
                            <td class="removeTableBordersLbl">
                            <asp:Label ID="lblCustomer" runat="server" Text="Contact (CRM):" ></asp:Label>
                        </td>
                        <td class="removeTableBordersTXB">
                            <asp:Label ID="lblCustomerName" Visible="false" runat="server" BorderColor="White" BorderStyle="None" CssClass="removeTableBordersTXB"></asp:Label>
                        </td>        

                    </tr>
                    <tr>
                        <td class="removeTableBordersLbl">
                            <asp:Label ID="lblStatus" runat="server" Text="Status:"></asp:Label>
                        </td>
                        <td class="removeTableBordersTXB">
                            <cc3:ComboBox ID="cmbStatus" runat="server" DataSourceID="sqldsRFQDefinitions" DataTextField="RFQStatusShortDesc" DataValueField="RFQStatID" AutoPostBack="True" OnSelectedIndexChanged="cmbStatus_SelectedIndexChanged" style="top: 0px; left: 0px" Enabled="False">
                                <ClientSideEvents OnSelectedIndexChanged="AllowSelectionChange" />
                            </cc3:ComboBox>
                        </td>
                        <td class="removeTableBordersLbl">
                            <asp:Label ID="lblDateRequested" runat="server" Text="Required:" Width="150px"></asp:Label>
                        </td>
                        <td class="removeTableBordersTXB">

                            <asp:TextBox ID="txbDateRequested" runat="server" BorderColor="White" BorderStyle="Inset" CssClass="lblTableBordersnarrow" ReadOnly="false" Width="150px" AutoPostBack="True" OnTextChanged="txbDateRequested_TextChanged"></asp:TextBox>
                        </td>
                        <td class="removeTableBordersLbl">
                            <asp:Label ID="lblGHSEquipment0" runat="server" Text="GHS (CRM):"></asp:Label>
                        </td>
                        <td class="removeTableBordersTXB">

                            <asp:CheckBox ID="chkGHS" runat="server" Enabled="False" />
                        </td>

                    </tr>
                    <tr>
                        <td class="removeTableBordersLbl">
                            <asp:Label ID="lblRFQDescription" runat="server" Text="Topic (CRM):"></asp:Label>
                        </td>
                        <td class="removeTableBordersTXB">
                            <asp:Label ID="lblRFQDescriptionValue" runat="server" BorderColor="White" BorderStyle="None" CssClass="removeTextBoxBordersTXB" ReadOnly="True"></asp:Label>

                        </td>
                        <td class="removeTableBordersLbl">
                            <asp:Label ID="lblDateQuoted" runat="server" Text="Quoted:" Width="150px"></asp:Label>
                            &nbsp;</td>
                        <td class="removeTableBordersTXB">

                            <asp:TextBox ID="txbDateQuoted" runat="server" BorderColor="White" BorderStyle="None" CssClass="removeTableBordersTXB" ReadOnly="true" Width="150px" AutoPostBack="false"></asp:TextBox>
                        </td>
                        <td class="removeTableBordersLbl">
                            <asp:Label ID="lblNPRNumber" runat="server" Text="NPR Number (CRM):" Width="190px"></asp:Label>
                        </td>
                        <td class="removeTableBordersTXB">
                            <asp:Label ID="lblNPRNumberValue" runat="server" Text=""></asp:Label>
                        </td>

                    </tr>
                    <tr>
                        <td class="removeTableBordersLbl">
                            <asp:Label ID="lblDateLastRevised" runat="server" Text="Last Revised:"></asp:Label>
                        </td>
                        <td class="removeTableBordersTXB">
                            <asp:TextBox ID="txbDateLastRevised" runat="server" AutoPostBack="True" BorderColor="White" BorderStyle="None" CssClass="removeTableBordersTXB" ReadOnly="TRUE" Width="150px"></asp:TextBox>
                        </td>
                        <td class="removeTableBordersLbl">

                            <asp:Label ID="lblEpicorQuoteNum" runat="server" Text="Epicor Quote #:" Visible="False"></asp:Label>

                        </td>
                        <td class="removeTableBordersTXB">
                            <asp:Label ID="lblEpicorQuoteNumValue" runat="server" BorderColor="White" BorderStyle="None"  CssClass="removeTableBordersTXB"  Width="150px" Visible="False"></asp:Label>

                        </td>
                        <td class="removeTableBordersLbl">
                            <asp:Label ID="lblCurrency" runat="server" Text="Currency:"></asp:Label>
                        </td>
                        <td class="removeTableBordersTXB">
                            <asp:Label ID="lblCurrencyCRM" runat="server" Text=""></asp:Label>
                        </td>

                    </tr>
                    <tr>
                        <td class="removeTableBordersLbl">

                            <asp:Label ID="lblLastChanged" runat="server" Text="Last Changed:"></asp:Label>

                        </td>
                        <td class="removeTableBordersTXB">

                            <asp:TextBox ID="txbDateLastChanged" runat="server" BorderColor="White" BorderStyle="None" CssClass="removeTableBordersTXB" ReadOnly="True" Width="150px"></asp:TextBox>

                        </td>
                        <td class="removeTableBordersLbl">

                            <asp:Label ID="lblWhoChanged" runat="server" Text="By:"></asp:Label>

                        </td>
                        <td class="removeTableBordersTXB">
                            <asp:TextBox ID="txbChangedBy" runat="server" AutoPostBack="True" BorderColor="White" BorderStyle="None" CssClass="removeTableBordersTXB" OnTextChanged="txbDateLastRevised_TextChanged" ReadOnly="FALSE" Width="150px"></asp:TextBox>

                        </td>
                        <td class="removeTableBordersLbl">

                            <asp:Label ID="lblWhoChanged0" runat="server" Text="Changed Item:"></asp:Label>

                        </td>
                        <td class="removeTableBordersTXB">

                            <asp:TextBox ID="txbReasonForChange" runat="server" AutoPostBack="True" BorderColor="White" BorderStyle="None" CssClass="removeTableBordersTXB" OnTextChanged="txbDateLastRevised_TextChanged" ReadOnly="FALSE" Width="170px"></asp:TextBox>
                        </td>

                    </tr>

                </table>
            </div>
             <br />
            <asp:Panel width="1300px" ID="pnlMain" runat="server" ScrollBars="Vertical" class="content" Visible="false" HorizontalAlign="Center">
                  <div id="rfqdetail" class="rounded_corners" runat="server">
                <asp:GridView  ID="grdRequiredValues" EnableViewState="true" AutoGenerateColumns="false" runat="server"  OnRowCreated="grdRequiredValues_RowCreated" OnRowDeleting="grdRequiredValues_RowDeleting" OnRowDataBound="grdRequiredValues_RowDataBound" OnRowEditing="grdRequiredValues_RowEditing" BackColor="#E5E5E5">
                   <AlternatingRowStyle BackColor="#F7F7F7" />
                   <PagerStyle BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" />
                   <HeaderStyle Height="30px" BackColor="#A8AEBD" Font-Size="15px" BorderColor="#CCCCCC"
                BorderStyle="Solid" BorderWidth="1px"  Font-Bold="true" />
                     <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <img alt="" style="cursor: pointer" src="images/plus.png" />
                                <asp:Panel ID="pnlRFQDetailSum" runat="server" Style="display: none">
                                    <asp:GridView ID="gvRFQDetails" runat="server" AutoGenerateColumns="false"  EnableViewState="false" OnRowCancelingEdit="gvRFQDetails_RowCancelingEdit" OnRowCommand="gvRFQDetails_RowCommand" OnRowDataBound="gvRFQDetails_RowDataBound" OnRowDeleting="gvRFQDetails_RowDeleting" OnRowEditing="gvRFQDetails_RowEditing" OnRowUpdating="gvRFQDetails_RowUpdating" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px">
                                        <AlternatingRowStyle BackColor="#F7F7F7" />
                                        <PagerStyle BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" />
                                        <HeaderStyle Height="30px" BackColor="#A8AEBD" Font-Size="15px" BorderColor="#CCCCCC"
                                            BorderStyle="Solid" BorderWidth="1px"  Font-Bold="true"  />
                                        <RowStyle Height="20px" Font-Size="13px" BorderColor="#CCCCCC" BorderStyle="Solid"
                                            BorderWidth="1px" />
                                         <Columns>
                                            <asp:TemplateField HeaderText="FieldRef" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbFieldRef" runat="server" Text='<%#Bind("FieldRef")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Description" ItemStyle-CssClass="NotesLabel" ItemStyle-HorizontalAlign="left">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblDescription" runat="server" CssClass="NotesLabel" Text='<%#Bind("Description")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Value" ItemStyle-CssClass="ValuesCSS" ItemStyle-HorizontalAlign="left">
                                                <ItemTemplate>
                                                    <%--                                                    <Columns> 
                                                  <asp:BoundField ItemStyle-Width="150px" DataField="Value" HeaderText="Value" />
                                                        </Columns>--%>
                                                    <asp:Label ID="lblValue" runat="server" Text='<%#Eval("Value")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderStyle-Width="5px" HeaderText="Req." ItemStyle-HorizontalAlign="left" ItemStyle-Width="15px">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbFieldRequired" runat="server" Font-Size="Large" ForeColor="Red" Text='<%#Bind("Required")%>' Width="25px"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Allowed Values" ItemStyle-HorizontalAlign="left">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbFieldRequiredValue" runat="server" Font-Size="Small" Text='<%#Bind("ValidationErrMessage")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <%--                                         <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:Button ButtonType="Button" CommandName="Delete" Text="Delete" runat="server" visible="false"/>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:Button ButtonType="Button" CommandName="Cancel" Text="Cancel" runat="server" />
                                                </EditItemTemplate>
                                            </asp:TemplateField>--%>
                                        </Columns>
                                    </asp:GridView>
                                </asp:Panel>
                                <asp:HiddenField ID="IsExpanded" runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="Line" HeaderStyle-Width="10%" HeaderText="Line" ItemStyle-Width="10%">
                        <HeaderStyle Width="10%" />
                        <ItemStyle Width="10%" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Type" HeaderStyle-Width="10%" HeaderText="Type" ItemStyle-Width="10%">
                        <HeaderStyle Width="10%" />
                        <ItemStyle Width="10%" />
                        </asp:BoundField>
                        <asp:BoundField DataField="SubType" HeaderStyle-Width="10%" HeaderText="Sub Type" ItemStyle-Width="10%">
                        <HeaderStyle Width="10%" />
                        <ItemStyle Width="10%" />
                        </asp:BoundField>
                        <asp:BoundField DataField="ProductGroup" HeaderStyle-Width="45%" HeaderText="Product Group" ItemStyle-Width="45%">
                        <HeaderStyle Width="45%" />
                        <ItemStyle Width="45%" />
                        </asp:BoundField>
                        <asp:ButtonField runat="server" ButtonType="Button" CommandName="Edit" HeaderStyle-Width="10%" ItemStyle-CssClass="CenterItemStype"  Text="Edit">
                        <HeaderStyle Width="10%" />
                        </asp:ButtonField>
                        <asp:ButtonField runat="server"  ButtonType="Button" CommandName="Delete" HeaderStyle-Width="10%"  Text="Delete">
                        <HeaderStyle Width="10%" />
                               <ItemStyle CssClass="CenterItemStype" />
                            
                        </asp:ButtonField>
                    </Columns>

                </asp:GridView>
                    </div>
                <br />
                <asp:Panel ID="pnlSelects" runat="server"  class="content" style="width: 60%;margin-left:20%;margin-right:20%" Visible="false" >
                        <asp:Panel ID="pnlRFQSelect" runat="server" BorderWidth="1px" style="margin-left:15%;margin-right:15%;border-radius:15px" >

                    <div style="margin-left:5%;margin-right:5%">
  
                                      
                        <table class="content3">
   
                            <tr>
                                  <td class="removeTableBordersLeftAlign">
                                    <asp:Label ID="lblRFQType" runat="server" Text="Line Type"></asp:Label>
                                                                      :</td>
                                <td class="removeTableBordersLeftAlign">
                                    <cc3:ComboBox id="cmbRFQTYPE" runat="server" DataSourceID="sqldsRFQTypes" MenuWidth="150px" Width="150px" DataTextField="Type" DataValueField="Type" AutoPostBack="True" EmptyText="&quot;Select RFQ Type&quot;" OnSelectedIndexChanged="cmbRFQTYPE_SelectedIndexChanged">
                                        <ClientSideEvents OnSelectedIndexChanged="OverRideWindowsUnload" />
                                    </cc3:ComboBox>
                                </td>
                            </tr>
                             <tr>
                                  <td class="removeTableBordersLeftAlign">
                                    <asp:Label ID="lblRFQSubType" runat="server" Text="Line SubType:"></asp:Label>
                                </td>
                                <td class="removeTableBordersLeftAlign">
                                    <cc3:ComboBox id="cmbRFQSubType" runat="server" DataTextField="SubType" AutoPostBack="True" OnSelectedIndexChanged="cmbRFQSubType_SelectedIndexChanged">
                                        <ClientSideEvents OnSelectedIndexChanged="OverRideWindowsUnload" />
                                    </cc3:ComboBox>
                                </td>
                                 <td class="removeTableBordersRightAlign">

                                 </td>
                            </tr>
                             <tr>
                                  <td class="removeTableBordersLeftAlign">
                                    <asp:Label ID="Label2" runat="server" Text="Product Group:"></asp:Label>
                                </td>
                                <td class="removeTableBordersLeftAlign">
                                    <cc3:ComboBox id="cmbProductGroup" runat="server" AutoClose="false"
                                         DataTextField="Market"  DataSourceID="sqlProductGroups" DataValueField="Market" 
                                         MenuWidth="150px" Width="250px" Enabled="False" style="top: 0px; left: 0px" >
                                        <ClientSideEvents OnSelectedIndexChanged="OverRideWindowsUnload" />
                                        <Details>
                                        <cc3:ComboBox runat="server" ID="Detail" 
                                                EnableLoadOnDemand="true" OnLoadingItems="Detail_LoadingItems" Width="250" Height="150"
                                                DataSourceID="sds2" DataValueField="ProductGroup" DataTextField="ProductGroup" AutoPostBack="true" OnSelectedIndexChanged="cmbProductGroup_SelectedIndexChanged">
                                                <HeaderTemplate>
                                                    ProductGroup
                                                </HeaderTemplate>
                                             
                                             
                                            </cc3:ComboBox>
                                        </Details> 
                                        
                                     </cc3:ComboBox>
                                    <asp:SqlDataSource ID="sqlProductGroups" runat="server" ConnectionString="<%$ ConnectionStrings:RFQConnectionString %>" SelectCommand="SELECT Distinct [Market] FROM [RFQProductGroups]"></asp:SqlDataSource>
                                      <asp:SqlDataSource ID="sds2" runat="server" SelectCommand="SELECT Market, ProductGroup FROM RFQProductGroups WHERE Market = @MarketID"
		                                     ConnectionString="<%$ ConnectionStrings:RFQConnectionString %>">
	                                    <SelectParameters>
	                                        <asp:Parameter Name="MarketID" Type="String" />
	                                    </SelectParameters>	    
                                    </asp:SqlDataSource>

                                                                 </td>
                                 <td class="removeTableBordersRightAlign">

                                 </td>
                            </tr>

                            <tr>
                                <td class="removeTableBordersCenterAlign">

                                </td>
                                <td class="removeTableBordersCenterAlign">
                                    <asp:Button runat="server" ID="btnAddRFQDetail" Text="Add" OnClick="btnAddRFQDetail_Click" Width="85px" Enabled="False" class="addeditdeletebutton" />
                                 </td>
                                <td class="removeTableBordersRightAlign">

                                </td>
                            </tr>
                        </table>

                    </div>
                    </asp:Panel>
                </asp:Panel>



   

                <asp:SqlDataSource ID="sqldsRFQDefinitions" runat="server" ConnectionString="<%$ ConnectionStrings:RFQConnectionString %>" SelectCommand="SELECT * FROM [RFQStatus]"></asp:SqlDataSource>

                <asp:SqlDataSource ID="sqldsRFQTypes" runat="server" ConnectionString="<%$ ConnectionStrings:RFQConnectionString %>" SelectCommand="SELECT DISTINCT [Type] FROM [RFQTypes]"></asp:SqlDataSource>
                <asp:SqlDataSource ID="sqlUserSecurityProfiles" runat="server" ConnectionString="<%$ ConnectionStrings:RFQConnectionString %>" SelectCommand="SELECT [UserProfileName] FROM [RFQUserSecurityProfiles]"></asp:SqlDataSource>



                <div style="position: relative">
                    <br />
                    <br />
                    <table style="border: none; border-collapse: collapse; outline: none; width: 100%" class="removeTableBordersNoBkgColor">
                        <tr>
                   
                              <td class="removeTableBordersNoBkgColor">
                                  </td>

                        </tr>
                        <tr>
 
                            <td class="removeTableBordersNoBkgColor">
                                <asp:Button ID="btnSubmit" runat="server" Text="Submit" Height="40px" Width="175px" Enabled="true" OnClick="btnSubmit_Click" Visible="false" CssClass="button" OnClientClick="OverRideWindowsUnload();" />

                            </td>
                        </tr>
                        <tr>
                            <td class="removeTableBordersNoBkgColor">
                                  <asp:Button ID="btnUpload" runat="server" Text="Attach/View File(s)" Width="175px" OnClick="btnUpload_Click" Height="40px" CssClass="button" OnClientClick="OverRideWindowsUnload();" />
                            </td>
                        </tr>
                        <tr>
                            <td class="removeTableBordersNoBkgColor">
                                  <asp:Button ID="btnCancel" runat="server" Text="Cancel RFQ" Width="175px" Height="40px" CssClass="button" Visible="false" OnClientClick='OverRideWindowsUnload(); return confirm("Continue to Cancel?");' OnClick="btnCancel_Click" />
                            </td>
                        </tr>

                    </table>
                </div>
            </asp:Panel>
            <juice:Datepicker runat="server" ID="dRequestedDate" TargetControlID="txbDateRequested" MinDate="0" AutoPostBack="true" OnOnSelect="txbDateRequested_TextChanged" />
 

        </asp:Panel>
       <script type="text/javascript">


           function OverRideWindowsUnload() {

               window.onbeforeunload = null;
 
           };
       
           
           window.onbeforeunload = confirmExit;
           function confirmExit() {
               var nIndex = cmbStatus.selectedIndex();
               if (typeof(cmbRFQTYPE) != "undefined")
                   var nIndexRFQType = cmbRFQTYPE.selectedIndex();
               if (typeof(cmbRFQSubType) != "undefined")
                   var nIndexRFQSubType = cmbRFQSubType.selectedIndex();
               var totalRows = $("#<%=grdRequiredValues.ClientID %> tr").length;

      
               var chkPostBack = '<%= Page.IsPostBack ? "true" : "false" %>';
  

               if (nIndex == 0 && totalRows > 0 && (typeof (chkPostBack) != "undefined" && chkPostBack != "true")) 
                       {         

                   alert("WARNING: RFQ Has Not Been Submitted" );
                   return false;
               }
          
              
           }
           

         
 

        
   
</script>    

</asp:Content>

