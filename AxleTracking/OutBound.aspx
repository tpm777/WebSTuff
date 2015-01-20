<%@ Page Language="C#" AutoEventWireup="true" CodeFile="OutBound.aspx.cs" Inherits="OutBound" %>

<%@ Register Assembly="MetaBuilders.WebControls.ComboBox, Version=1.1.5000.0, Culture=neutral, PublicKeyToken=8f1b87f9edb00944"
    Namespace="MetaBuilders.WebControls" TagPrefix="mbcbb" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Untitled Page</title>
    <style type="text/css">
html {
overflow-x:hidden;
overflow-y:hidden;

}
</style>

</head>
<body bgcolor="#99ffff">
    <form id="form1" runat="server">
    <div>
        <div style="z-index: 101; left: 2px; width: 320px; position: absolute; top: 3px;
            height: 131px">
            <asp:Label ID="lbOpertaorID" runat="server" Style="z-index: 100; left: 181px; position: absolute;
                top: 109px" Text="Operator ID:" Width="58px" Font-Size="X-Small"></asp:Label>
            &nbsp; &nbsp;&nbsp;
            <asp:Label ID="lblTitle" runat="server" Style="z-index: 101; left: 76px; position: absolute;
                top: 4px" Text="Create Outbound Load ID" Width="203px" Height="10px"></asp:Label>
            <asp:Button ID="btnSummit" runat="server" Style="z-index: 102; left: 108px; position: absolute;
                top: 79px" Text="OK   " Width="83px" OnClick="btnSummit_Click" />
            &nbsp; &nbsp;&nbsp; &nbsp; &nbsp;
            <asp:Label ID="lblOperatorIDName" runat="server" Height="8px" Style="z-index: 103;
                left: 245px; position: absolute; top: 110px" Text="OperatorID" Width="67px" OnDataBinding="Page_Load" Font-Size="X-Small"></asp:Label>
            &nbsp;
            <asp:Label ID="lblCustomer" runat="server" Height="8px" Style="z-index: 104; left: 5px;
                position: absolute; top: 28px" Text=" Customer:" Width="69px"></asp:Label>
            &nbsp;
            <asp:Label ID="lblQuantity" runat="server" Height="8px" Style="z-index: 105; left: 8px;
                position: absolute; top: 54px" Text="Quantity :" Width="64px"></asp:Label>
            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
            <asp:TextBox ID="txbQuantity" runat="server" Style="z-index: 106; left: 94px; position: absolute;
                top: 54px" Width="66px"></asp:TextBox>
            &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txbQuantity"
                ErrorMessage="*" Style="z-index: 107; left: 183px; position: absolute; top: 52px"
                Width="14px"></asp:RequiredFieldValidator>
            &nbsp;
            <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="txbQuantity"
                ErrorMessage="Value Not Allow" MaximumValue="99999999" MinimumValue="1" Style="z-index: 108;
                left: 199px; position: absolute; top: 53px" Width="105px" Type="Integer"></asp:RangeValidator>
            &nbsp;
            <asp:HyperLink ID="HyperLink1" runat="server" Font-Size="Small" NavigateUrl="~/Login.aspx"
                Style="z-index: 109; left: 8px; position: absolute; top: 109px">Logoff/Change Input Screen</asp:HyperLink>
            &nbsp;
        </div>
        <br />
        <br />
        <br />
        <asp:DropDownList ID="cmbCustomers" runat="server" DataSourceID="SqlDataSource1"
            DataTextField="Customer_Name" DataValueField="Customer_Name" Style="z-index: 102;
            left: 84px; position: absolute; top: 30px" Width="197px">
        </asp:DropDownList>
        <br />
        <br />
        <br />
        <br />
        <br />
        &nbsp;<br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:RFDBConnectionString %>"
            ProviderName="<%$ ConnectionStrings:RFDBConnectionString.ProviderName %>"
            SelectCommand="SELECT [Customer Name] AS Customer_Name FROM [Customers]"></asp:SqlDataSource>
        <br />
        &nbsp;</div>
    </form>
</body>
</html>
