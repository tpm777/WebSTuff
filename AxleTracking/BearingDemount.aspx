<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BearingDemount.aspx.cs" Inherits="BearingDemount" %>

<%@ Register Assembly="MetaBuilders.WebControls.ComboBox, Version=1.1.5000.0, Culture=neutral, PublicKeyToken=8f1b87f9edb00944"
    Namespace="MetaBuilders.WebControls" TagPrefix="mbcbb" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<%
  Response.Expires = 0;
  Response.CacheControl = "no-cache";
%>
<style type="text/css">
html {
overflow-x:hidden;
overflow-y:hidden;

}
</style>


<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body bgcolor="#99ffff">
    <form id="form1" runat="server">
    <div>
        <div style="z-index: 101; left: 2px; width: 308px; position: absolute; top: 3px;
            height: 177px">
            <asp:Label ID="lbOpertaorID" runat="server" Style="z-index: 100; left: 188px; position: absolute;
                top: 158px" Text="Operator ID:" Width="62px" Font-Size="X-Small"></asp:Label>
            &nbsp; &nbsp;
            &nbsp; &nbsp;
            <asp:Label ID="lblTitle" runat="server" Style="z-index: 101; left: 103px; position: absolute;
                top: 5px" Text="Bearing Demount" Width="112px"></asp:Label>
            <asp:Button ID="btnSummit" runat="server" Style="z-index: 102; left: 119px; position: absolute;
                top: 129px" Text="OK" Width="83px" OnClick="btnSummit_Click" />
            &nbsp; &nbsp;&nbsp; &nbsp; &nbsp;
            &nbsp; &nbsp;
            <asp:Label ID="lblTrackingID" runat="server" Height="8px" Style="z-index: 103; left: 4px;
                position: absolute; top: 29px" Text="Tag ID:" Width="86px"></asp:Label>
            <asp:Label ID="lblCustomer" runat="server" Height="8px" Style="z-index: 104; left: 5px;
                position: absolute; top: 53px" Text="Customer:" Width="89px"></asp:Label>
            <asp:Label ID="lblCustomerName" runat="server" Height="8px" Style="z-index: 105; left: 118px;
                position: absolute; top: 53px" Text="No Tag ID" Width="184px"></asp:Label>
            <asp:Label ID="lblLoadIDValue" runat="server" Height="8px" Style="z-index: 106; left: 119px;
                position: absolute; top: 78px" Text="No Tag ID" Width="185px"></asp:Label>
            &nbsp;
            <asp:TextBox ID="txbTrackingID" runat="server" Style="z-index: 107; left: 117px;
                position: absolute; top: 27px" AutoPostBack="True" OnTextChanged="txbTrackingID_TextChanged" Width="184px"></asp:TextBox>
            &nbsp; &nbsp;
            <asp:Label ID="lblBearingStatus" runat="server" Height="8px" Style="z-index: 108;
                left: 4px; position: absolute; top: 104px" Text="# of Bearings Mnt:" Width="107px" Font-Size="Small"></asp:Label>
            &nbsp; &nbsp;
            <br />
            <asp:Label ID="lblOperatorName" runat="server" Style="z-index: 109; left: 258px;
                position: absolute; top: 159px" Text="Name" Width="44px" Font-Size="X-Small"></asp:Label>
            <br />
            <asp:Label ID="lblLoadIDName" runat="server" Height="8px" Style="z-index: 110; left: 4px;
                position: absolute; top: 79px" Text="Load ID:" Width="87px"></asp:Label>
            <asp:HyperLink ID="HyperLink2" runat="server" Font-Size="Small" NavigateUrl="~/Login.aspx"
                Style="z-index: 111; left: 7px; position: absolute; top: 156px">Logoff/Change Input Screen</asp:HyperLink>
            <mbcbb:combobox id="cmBearingStatus" runat="server" datasourceid="SqlDataSource1"
                datatextfield="Demount_Status" datavaluefield="Demount_Status" style="z-index: 113;
                left: 121px; position: absolute; top: 102px" width="172px"><asp:ListItem>Databound</asp:ListItem>
</mbcbb:combobox>
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
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:RFDBConnectionString %>"
            ProviderName="<%$ ConnectionStrings:RFDBConnectionString.ProviderName %>" SelectCommand="SELECT [Demount Status] AS Demount_Status FROM [BearingDemountStatusCodes]">
        </asp:SqlDataSource>
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
    
    </div>
    </form>
</body>
</html>
