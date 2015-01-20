<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ReceiveAxle.aspx.cs" Inherits="ReceiveAxle" %>


<%@ Register Assembly="MetaBuilders.WebControls.ComboBox, Version=1.1.5000.0, Culture=neutral, PublicKeyToken=8f1b87f9edb00944"
    Namespace="MetaBuilders.WebControls" TagPrefix="mbcbb" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<%
  Response.Expires = 0;
  Response.CacheControl = "no-cache";
%>


<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
<style type="text/css">
html {
overflow-x:hidden;
overflow-y:hidden;
}
</style>    
<script language="javascript" type="text/javascript">
<!--



// -->
</script>
</head>
<body bgcolor="#99ffff">
    <form id="form1" runat="server">
    <div>
        <div style="z-index: 101; left: 0px; width: 320px; position: absolute; top: 2px;
            height: 223px" id="DIV1" language="javascript" onclick="return DIV1_onclick()">
            <asp:Label ID="lbOpertaorID" runat="server" Style="z-index: 100; left: 197px; position: absolute;
                top: 201px" Text="Operator ID:" Width="60px" Font-Size="X-Small"></asp:Label>
            <asp:Label ID="lblMaxQty" runat="server" Font-Size="Small" Qty=" " Style="z-index: 101;
                left: 218px; position: absolute; top: 55px" Text="Max" Width="84px"></asp:Label>
            <asp:Label ID="lblQtyPosted" runat="server" Font-Size="Small" Posted=" " Style="z-index: 102;
                left: 215px; position: absolute; top: 78px" Text="Qty" Width="86px"></asp:Label>
            &nbsp; &nbsp; &nbsp;
            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
            <asp:Label ID="lblTitle" runat="server" Style="z-index: 103; left: 119px; position: absolute;
                top: 4px" Text="Receive Axle" Width="106px"></asp:Label>
            <asp:Button ID="btnSummit" runat="server" Style="z-index: 104; left: 108px; position: absolute;
                top: 168px" Text="OK" Width="83px" OnClick="btnSummit_Click" BorderStyle="Ridge" />
            &nbsp; &nbsp;&nbsp; &nbsp;
            <asp:Label ID="lblAxleType" runat="server" Height="8px" Style="z-index: 105; left: 9px;
                position: absolute; top: 104px" Text="Axle Type:" Width="78px"></asp:Label>
            <asp:Label ID="lblOperatorIDName" runat="server" Height="8px" Style="z-index: 106;
                left: 269px; position: absolute; top: 202px" Text="OperatorID" Width="45px" Font-Size="X-Small"></asp:Label>
            &nbsp;
            <asp:Label ID="lblTagID" runat="server" Height="8px" Style="z-index: 107; left: 7px;
                position: absolute; top: 76px" Text="Tag ID:" Width="62px"></asp:Label>
            <asp:Label ID="lblCustomerID" runat="server" Height="8px" Style="z-index: 108; left: 8px;
                position: absolute; top: 27px" Text="Customer ID:" Width="88px"></asp:Label>
            &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
            <asp:TextBox ID="txbTagID" runat="server" Style="z-index: 109; left: 102px; position: absolute;
                top: 77px" Width="89px" AutoPostBack="True"></asp:TextBox>
            <div style="z-index: 117; left: 7px; width: 285px; position: absolute; top: 135px;
                height: 30px">
                &nbsp; &nbsp;
                <asp:Button ID="btnWheelData" runat="server" OnClick="btnWheelData_Click" Style="z-index: 103;
                    left: 27px; position: absolute; top: 5px" Text="Wheel Data" Width="95px" />
                <asp:Button ID="btnAddEditBearingData" runat="server" OnClick="btnWheelBearing_Click" Style="z-index: 103; left: 157px; position: absolute;
                    top: 4px" Text="Bearing Data" Width="95px" />
            </div>
            <asp:Button ID="btnClear" runat="server" Style="z-index: 110; left: 207px; position: absolute;
                top: 168px" Text="Reset" Width="68px" OnClick="btnClear_Click" /><asp:Button ID="btnEditLoadIDs" runat="server" Style="z-index: 118; left: 24px; position: absolute;
                top: 168px" Text="LoadID " Width="68px" OnClick="btnEditLoadIDs_Click" />
            &nbsp;&nbsp;
            <asp:DropDownList ID="cmbLoadID" runat="server" Style="z-index: 112; left: 102px;
                position: absolute; top: 52px" Width="99px" AutoPostBack="True" OnSelectedIndexChanged="cmbLoadID_SelectedIndexChanged">
            </asp:DropDownList>
            <asp:Label ID="lblLoadID" runat="server" Height="8px" Style="z-index: 113; left: 7px;
                position: absolute; top: 49px" Text="LoadID:" Width="88px"></asp:Label>
            &nbsp;
            <asp:HyperLink ID="HyperLink2" runat="server" Font-Size="Small" NavigateUrl="~/Login.aspx"
                Style="z-index: 114; left: 8px; position: absolute; top: 200px">Logoff/Change Input Screen</asp:HyperLink>
            <mbcbb:ComboBox id="cmbCustomerID" runat="server" AutoPostBack="True" DataSourceID="SqlDataSource2"
                DataTextField="Customer_Name" DataValueField="Customer_Name" style="z-index: 115;
                left: 102px; position: absolute; top: 24px" Width="180px" OnSelectedIndexChanged="cmbCustomerID_SelectedIndexChanged">
                <asp:ListItem>Databound</asp:ListItem>
            </mbcbb:ComboBox>
        <mbcbb:ComboBox id="cmbAxleType" runat="server" DataSourceID="SqlDataSource1" DataTextField="Description"
            DataValueField="Description" style="z-index: 116; left: 104px; position: absolute;
            top: 103px" Width="185px" Font-Size="Medium">
            <asp:ListItem>Databound</asp:ListItem>
        </mbcbb:ComboBox>
        </div>
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        &nbsp;
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:RFDBConnectionString %>"
            SelectCommand="SELECT [Description] FROM [Axle Type]"></asp:SqlDataSource><asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:RFDBConnectionString %>"
            SelectCommand="SELECT [Customer Name] AS Customer_Name FROM [Customers]"></asp:SqlDataSource>
        <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:RFDBConnectionString %>"
            SelectCommand="SELECT [Load ID] AS Load_ID FROM [LoadID] WHERE ([Customer ID] = @Customer_Name)">
            <SelectParameters>
                <asp:ControlParameter ControlID="cmbCustomerID" Name="Customer_Name" PropertyName="SelectedValue"
                    Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>
    
    </div>
    </form>
</body>
</html>
