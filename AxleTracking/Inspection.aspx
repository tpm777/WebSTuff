<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Inspection.aspx.cs" Inherits="Inspection" %>

<%@ Register Assembly="MetaBuilders.WebControls.ComboBox, Version=1.1.5000.0, Culture=neutral, PublicKeyToken=8f1b87f9edb00944"
    Namespace="MetaBuilders.WebControls" TagPrefix="mbcbb" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Untitled Page</title><style type="text/css">
html {
overflow-x:hidden;
overflow-y:hidden;

}
</style>
    

</head>
<body bgcolor="#99ffff">
    <form id="form1" runat="server">
    <div>
        <div style="z-index: 102; left: 2px; width: 303px; position: absolute; top: 1px;
            height: 192px">
            <asp:Label ID="lbOpertaorID" runat="server" Style="z-index: 100; left: 177px; position: absolute;
                top: 169px" Text="Operator ID:" Width="65px" Font-Size="X-Small"></asp:Label>
            &nbsp; &nbsp;
            &nbsp; &nbsp;
            <asp:Label ID="lblTitle" runat="server" Style="z-index: 101; left: 70px; position: absolute;
                top: 5px" Text="LooseAxles" Width="231px" Font-Size="Small"></asp:Label>
            <asp:Button ID="btnSummit" runat="server" Style="z-index: 102; left: 114px; position: absolute;
                top: 131px" Text="OK" Width="83px" OnClick="btnSummit_Click"  />
            &nbsp; &nbsp;&nbsp; &nbsp; &nbsp;
            &nbsp; &nbsp;
            <asp:Label ID="lblTrackingID" runat="server" Height="8px" Style="z-index: 103; left: 12px;
                position: absolute; top: 28px" Text="Tag ID:" Width="77px"></asp:Label>
            <asp:Label ID="Label1" runat="server" Height="8px" Style="z-index: 104; left: 12px;
                position: absolute; top: 104px" Text="Status:" Width="77px"></asp:Label>
            <asp:Label ID="lblOperatorIDName" runat="server" Height="8px" Style="z-index: 105; left: 254px;
                position: absolute; top: 170px" Text="Name" Width="38px" Font-Size="X-Small"></asp:Label>
            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
            &nbsp;
            <mbcbb:combobox id="cmbInspectionStatus" runat="server" datasourceid="SqlDataSource1" datatextfield="Status"
                datavaluefield="Status" style="z-index: 106; left: 104px; position: absolute;
                top: 101px">
                <asp:ListItem>Databound</asp:ListItem>
</mbcbb:combobox>
        <asp:TextBox ID="txbTagID" runat="server" AutoPostBack="True" OnTextChanged="txbTagID_TextChanged"
            Style="z-index: 107; left: 104px; position: absolute; top: 26px"></asp:TextBox>
        <asp:HyperLink ID="HyperLink2" runat="server" Font-Size="Small" NavigateUrl="~/Login.aspx"
            Style="z-index: 108; left: 5px; position: absolute; top: 166px">Logoff/Change Input Screen</asp:HyperLink>
            <asp:Label ID="lblCustomer" runat="server" Height="8px" Style="z-index: 109; left: 12px;
                position: absolute; top: 51px" Text="Customer:" Width="67px"></asp:Label>
            <asp:Label ID="lblCustomerName" runat="server" Height="8px" Style="z-index: 110;
                left: 104px; position: absolute; top: 53px" Width="184px"></asp:Label>
            <asp:Label ID="lblLoadIDValue" runat="server" Height="8px" Style="z-index: 111; left: 104px;
                position: absolute; top: 76px" Width="185px"></asp:Label>
            <asp:Label ID="lblLoadIDName" runat="server" Height="8px" Style="z-index: 113; left: 12px;
                position: absolute; top: 76px" Text="Load ID:" Width="68px"></asp:Label>
        </div>
    
    </div>
        <br />
        &nbsp;<br />
        <br />
        <br />
        <br />
        <br />
        &nbsp;<br />
        <br />
        <br />
        <br />
        <br />
        &nbsp;&nbsp;<br />
        <br />
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:RFDBConnectionString %>"
            SelectCommand="SELECT [Status] FROM [AxleInspectionCodes]"></asp:SqlDataSource>
        <br />
        <br />
        <br />
        <br />
        <br />
    </form>
</body>
</html>

