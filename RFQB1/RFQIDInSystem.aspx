<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RFQIDInSystem.aspx.cs" Inherits="RFQIDInSystem" %>

<%@ Register Assembly="obout_Grid_NET" Namespace="Obout.Grid" TagPrefix="cc2" %>
<%@ Register TagPrefix="cc2" Namespace="Obout.Interface" Assembly="obout_Interface" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
		<style type="text/css">
			.tdText {
				font:11px Verdana;
				color:#333333;
			}
			.option2{
				font:11px Verdana;
				color:#0033cc;
				background-color:#f6f9fc;
				padding-left:4px;
				padding-right:4px;
			}
			a {
				font:11px Verdana;
				color:#315686;
				text-decoration:underline;
			}

			a:hover {
				color:crimson;
			}
			.tdTextSmall {
	            font:9px Verdana;
	            color:#333333;
            }
		</style>		
    
        <script type="text/javascript">


      
        


        function showFilter(btnObj) {
            blurButton(btnObj);

            grid1.showFilter();

            return false;
        }

        function applyFilter() {

            
      
             
           
           
            //   var btn = document.getElementById("btnApplyFilter");
              
          //     blurButton(btn);

            
            //   PageMethods.ProcessFilter(grid1, onSucess, onError);
//            storeFilter();
                grid1.filter();
                return false;
    
        }
        function onSucess() {
            alert("Success");
        }


        function onError() {
            alert('Something wrong.');
        }

        
        function hideFilter(btnObj) {
            blurButton(btnObj);

            grid1.hideFilter();

            return false;
        }

        function removeFilter(btnObj) {
            blurButton(btnObj);

            grid1.removeFilter();

            return false;
        }
        function blurButton(btnId) {
            var btn = eval(btnId);
            btn.blur();
        }
    </script>
</head>

<body>
           

    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true"></asp:ScriptManager>
       <div id="header" class="content">

            <div>
                <table>
                    <tr>
                        <td class="noborders">
                            <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/horiz_ComputypeLogoColor_240_62.jpg" Height="71px" Width="282px" />
                        </td>
                        <td class="noborders">
                            <asp:Label ID="lblTtitle" runat="server" Text="Request For Quote" Font-Size="XX-Large" Font-Bold="True"></asp:Label>
                        </td> 
                    </tr>
                </table>

            </div>
        </div>
        <asp:Panel ID="pnlMain" runat="server" ScrollBars="Vertical" Width="100%"> 
<cc2:Grid id="grid1" runat="server"  PageSizeOptions="1,10,25,50,75,100,500,1000"  PageSize="50" AllowPageSizeSelection="true"  EnableRecordHover="true" AutoGenerateColumns="False" AutoPostBackOnSelect="true" AllowAddingRecords="False" AllowFiltering="true"  FilterType="Normal"     DataSourceID="sqldsRFQsInSystem" OnSelect="grid1_Select" OnRowDataBound="RowDataBound" >
     
    <Columns>
        <cc2:Column DataField="RFQID" HeaderText="RFQID" Index="0" Width="90px">
        </cc2:Column>
        <cc2:Column DataField="EpicorQuoteNum" HeaderText="EpicorQuoteNum" Index="1" Width="90px">
        </cc2:Column>

        <cc2:Column  DataField="RFQStatus" HeaderText="RFQStatus" Index="2" Visible="true" Width="100px">
      <%--      <FilterOptions>
                <cc2:FilterOption  Type="SmallerThan" />
            </FilterOptions> --%>
        </cc2:Column>

        <cc2:Column DataField="STATUS" HeaderText="Status Desc" Index="3" Width="110px" HeaderAlign="center" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
 <%--               <FilterOptions>
        <cc2:CustomFilterOption IsDefault="true" ID="RFQStatusFilter" Text="Contains Either">
            <TemplateSettings FilterTemplateId="Template1"
                FilterControlsIds="txt1,txt2" 
                FilterControlsPropertyNames="value,value" />
        </cc2:CustomFilterOption>
    </FilterOptions>--%>

        </cc2:Column>
        <cc2:Column DataField="RFQDescription" HeaderText="Opportunity (Desc.)" Index="4" Width="240px">
        </cc2:Column>
        <cc2:Column DataField="Requestor" HeaderText="Owner" Index="5" Width="150px">
        </cc2:Column>
        <cc2:Column DataField="ContactName" HeaderText="ContactName" Index="6" Width="130px" Visible="false">
        </cc2:Column>
        <cc2:Column DataField="ParentCustomerName" HeaderText="Customer" Index="7">
        </cc2:Column>
       <cc2:Column DataField="DateCreated" HeaderText="DateCreated" Index="8" DataFormatString="{0:d}"  Width="130px">
        </cc2:Column>
       <cc2:Column DataField="DateSubmitted" HeaderText="DateSubmitted" Index="9" DataFormatString="{0:d}" Width="130px">
        </cc2:Column>
       <cc2:Column DataField="DateQuoted" HeaderText="DateQuoted" Index="10" DataFormatString="{0:d}"  Width="130px" >
        </cc2:Column>
       <cc2:Column DataField="ChangedBy" HeaderText="ChangedBy" Index="11"  Width="130px">
        </cc2:Column>
       <cc2:Column DataField="OpportunityID" HeaderText="OpportunityID" Index="12" Visible="false" >
        </cc2:Column>
    </Columns>
 		<Templates>								
				<cc2:GridTemplate runat="server" ID="tplShowFilter">
                    <Template>
                        <input type="button" id="btnShowFilter" class="tdTextSmall" value="Show Filter" onclick="grid1.showFilter()"/>
                    </Template>
                </cc2:GridTemplate>
                <cc2:GridTemplate runat="server" ID="tplApplyFilter">
                    <Template>
                        <input type="button" id="btnApplyFilter"  class="tdTextSmall" value="Apply Filter" onclick="grid1.filter()"/>
                    </Template>
                </cc2:GridTemplate>
                <cc2:GridTemplate runat="server" ID="tplHideFilter">
                    <Template>
                        <input type="button" id="btnHideFilter" class="tdTextSmall" value="Hide Filter" onclick="grid1.hideFilter()"/>
                    </Template>
                </cc2:GridTemplate>
                <cc2:GridTemplate runat="server" ID="tplRemoveFilter">
                    <Template>
                        <input type="button" id="btnRemoveFilter" class="tdTextSmall" value="Remove Filter" onclick="grid1.removeFilter()"/>
                    </Template>
                </cc2:GridTemplate>			
			</Templates>
			<TemplateSettings FilterShowButton_TemplateId="tplShowFilter" FilterApplyButton_TemplateId="tplApplyFilter"
            FilterHideButton_TemplateId="tplHideFilter" FilterRemoveButton_TemplateId="tplRemoveFilter"/>
            <FilteringSettings InitialState="Hidden" /> 
       

    </cc2:Grid>  

   <div>
        <asp:SqlDataSource ID="sqldsRFQsInSystem" runat="server" ConnectionString="<%$ ConnectionStrings:RFQConnectionString %>" SelectCommand="SELECT RFQID,EpicorQuoteNum,RFQDescription,RFQStatus.RFQStatusShortDesc AS STATUS,RFQSTATUS,GHSOpportunity,Requestor,ContactName,ParentCustomerName,DateSubmitted,DateQuoted,DateCreated,ChangedBy,OpportunityID FROM [RFQHeader],RFQStatus WHERE RFQStatus.RFQStatID=RFQHeader.RFQStatus ORDER By RFQID DESC;"></asp:SqlDataSource>
    </div>
<%-- 
        <asp:Panel runat="server" ScrollBars="Vertical">
        <asp:GridView ID="grdRFQsInSystem" runat="server" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="RFQID" DataSourceID="sqldsRFQsInSystem" OnSelectedIndexChanged="grdRFQsInSystem_SelectedIndexChanged" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" AllowPaging="True">
            <Columns>  
                <asp:CommandField ShowSelectButton="True" />
                <asp:BoundField DataField="RFQID" HeaderText="RFQID" ReadOnly="True" SortExpression="RFQID" InsertVisible="False" />
                <asp:BoundField DataField="RFQStatus" HeaderText="Status" SortExpression="RFQStatus" />
                <asp:BoundField DataField="RFQDescription" HeaderText="Description" SortExpression="RFQDescription" />
                <asp:BoundField DataField="Requestor" HeaderText="Requestor" SortExpression="Requestor" />
                <asp:BoundField DataField="ContactName" HeaderText="Contact" SortExpression="ContactName" />
                <asp:BoundField DataField="ParentCustomerName" HeaderText="Customer" SortExpression="ParentCustomerName" />
                <asp:BoundField DataField="Currency" HeaderText="Currency" SortExpression="Currency" />
                <asp:BoundField DataField="DateCreated" HeaderText="Created" SortExpression="DateCreated" />
                <asp:BoundField DataField="DateSubmitted" HeaderText="Submitted" SortExpression="DateSubmitted" />
                <asp:BoundField DataField="DateRequired" HeaderText="Required" SortExpression="DateRequired" />
                <asp:BoundField DataField="DateQuoted" HeaderText="Quoted" SortExpression="DateQuoted" />
                <asp:BoundField DataField="TurnAroundDays" HeaderText="Turn Around Days" SortExpression="TurnAroundDays" />
                <asp:BoundField DataField="DateLastRevised" HeaderText="Last Changed Date" SortExpression="DateLastRevised" />
                <asp:BoundField DataField="ChangedBy" HeaderText="Last Change User" SortExpression="ChangedBy" />
            </Columns>
            <FooterStyle BackColor="White" ForeColor="#000066" />
            <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
            <PagerSettings Mode="NextPrevious" />
            <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
            <RowStyle ForeColor="#000066" />
            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#007DBB" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#00547E" />
        </asp:GridView>
     </asp:Panel>--%>
            </asp:Panel>

    </form>
</body>

</html>
