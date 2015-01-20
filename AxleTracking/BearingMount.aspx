<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BearingMount.aspx.cs" Inherits="BearingMount" %>

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
        <div style="z-index: 101; left: 0px; width: 320px; position: absolute; top: 3px;
            height: 187px">
            <asp:Label ID="lbOpertaorID" runat="server" Style="z-index: 100; left: 203px; position: absolute;
                top: 165px" Text="Operator ID:" Width="52px" Font-Size="X-Small"></asp:Label>
            <asp:Label ID="lblOperatorName" runat="server" Style="z-index: 101; left: 260px; position: absolute;
                top: 166px" Text="ID:" Width="53px" Font-Size="X-Small"></asp:Label>
            &nbsp; &nbsp;
            &nbsp; &nbsp;
            <asp:Label ID="lblTitle" runat="server" Style="z-index: 102; left: 115px; position: absolute;
                top: 5px" Text="Bearing Mount" Width="99px" Height="15px"></asp:Label>
            <asp:Button ID="btnSummit" runat="server" Style="z-index: 103; left: 117px; position: absolute;
                top: 137px" Text="OK" Width="83px" OnClick="btnSummit_Click" />
            &nbsp; &nbsp;&nbsp; &nbsp; &nbsp;
            <asp:Label ID="lblTagID" runat="server" Height="8px" Style="z-index: 105; left: 5px;
                position: absolute; top: 30px" Text="TagID:" Width="56px"></asp:Label>
            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
            <div id="DIV1" style="z-index: 107; left: 1px; width: 276px; position: absolute;
                top: 103px; height: 31px" language="javascript" onclick="return DIV1_onclick()">
                &nbsp; &nbsp;&nbsp; &nbsp;
                <asp:Label ID="Label1" runat="server" Style="z-index: 100; left: 4px; position: absolute;
                    top: 0px" Text="Bearing Type:" Width="90px"></asp:Label>
                &nbsp; &nbsp; &nbsp;
                <mbcbb:combobox id="cmbBearingType" runat="server" autopostback="True" datasourceid="SqlDataSource1"
                    datatextfield="Description" datavaluefield="Description" style="z-index: 103;
                    left: 105px; position: absolute; top: 0px" width="158px"><asp:ListItem>Databound</asp:ListItem>
</mbcbb:combobox>
            </div>
            &nbsp;
            <asp:TextBox ID="txbTagID" runat="server" Style="z-index: 108; left: 78px; position: absolute;
                top: 28px" Width="176px" AutoPostBack="True" OnTextChanged="txbTagID_TextChanged"></asp:TextBox>
            <asp:Label ID="lblCustomer" runat="server" Height="8px" Style="z-index: 105; left: 5px;
                position: absolute; top: 55px" Text="Customer:" Width="67px"></asp:Label>
            <asp:Label ID="lblCustomerName" runat="server" Height="8px" Style="z-index: 106;
                left: 78px; position: absolute; top: 52px" Width="184px"></asp:Label>
            <asp:Label ID="lblLoadIDValue" runat="server" Height="8px" Style="z-index: 107; left: 79px;
                position: absolute; top: 78px" Width="185px"></asp:Label>
            <asp:Label ID="lblLoadIDName" runat="server" Height="8px" Style="z-index: 112; left: 4px;
                position: absolute; top: 79px" Text="Load ID:" Width="68px"></asp:Label>
            <asp:HyperLink ID="HyperLink2" runat="server" Font-Size="Small" NavigateUrl="~/Login.aspx"
                Style="z-index: 114; left: 7px; position: absolute; top: 167px">Logoff/Change Input Screen</asp:HyperLink>
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
        <br />
        <br />
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:RFDBConnectionString %>"
            ProviderName="<%$ ConnectionStrings:RFDBConnectionString.ProviderName %>" SelectCommand="SELECT [Description] FROM [Bearing Type]">
        </asp:SqlDataSource>
    
    </div>
    </form>
</body>
</html>
