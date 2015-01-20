<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LooseAxles.aspx.cs" Inherits="LooseAxles" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<%
  Response.Expires = 0;
  Response.CacheControl = "no-cache";
%>


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
        <div style="z-index: 101; left: 4px; width: 279px; position: absolute; top: 0px;
            height: 161px">
            <asp:Label ID="lbOpertaorID" runat="server" Style="z-index: 100; left: 168px; position: absolute;
                top: 167px" Text="Operator ID:" Width="56px" Font-Size="X-Small"></asp:Label>
            &nbsp; &nbsp;
            &nbsp; &nbsp;
            <asp:Label ID="lblTitle" runat="server" Style="z-index: 101; left: 58px; position: absolute;
                top: 5px" Text="LooseAxles" Width="206px" Font-Size="Small"></asp:Label>
            <asp:Button ID="btnSummit" runat="server" Style="z-index: 102; left: 104px; position: absolute;
                top: 131px" Text="OK" Width="83px" OnClick="btnSummit_Click"  />
            &nbsp; &nbsp;&nbsp; &nbsp; &nbsp;
            &nbsp; &nbsp;
            <asp:Label ID="lblTrackingID" runat="server" Height="8px" Style="z-index: 103; left: 7px;
                position: absolute; top: 28px" Text="Tag ID:" Width="77px"></asp:Label>
            <asp:Label ID="lblOperatorIDName" runat="server" Height="8px" Style="z-index: 104; left: 233px;
                position: absolute; top: 167px" Text="Name" Width="38px" Font-Size="X-Small"></asp:Label>
            <asp:TextBox ID="txbTagID" runat="server" Style="z-index: 105; left: 108px;
                position: absolute; top: 28px" Width="143px" AutoPostBack="True" OnTextChanged="txbTagID_TextChanged" Height="14px"></asp:TextBox>
            &nbsp; &nbsp; &nbsp;&nbsp;&nbsp; &nbsp;
            <asp:Label ID="lblCustomer" runat="server" Height="8px" Style="z-index: 106; left: 7px;
                position: absolute; top: 52px" Text="Customer:" Width="89px"></asp:Label>
            <asp:Label ID="lblCustomerName" runat="server" Height="14px" Style="z-index: 107;
                left: 108px; position: absolute; top: 54px" Width="149px"></asp:Label>
            <asp:Label ID="lblLoadIDValue" runat="server" Height="14px" Style="z-index: 108; left: 108px;
                position: absolute; top: 79px" Width="149px"></asp:Label>
            <asp:Label ID="lblLoadIDName" runat="server" Height="8px" Style="z-index: 109; left: 7px;
                position: absolute; top: 76px" Text="Load ID:" Width="87px"></asp:Label>
            <asp:Label ID="Label1" runat="server" Height="8px" Style="z-index: 110;
                left: 7px; position: absolute; top: 103px" Text="Task Completed" Width="91px" Font-Size="Small"></asp:Label>
                <asp:TextBox ID="txbTaskCompleted" runat="server" Style="z-index: 113; left: 108px; position: absolute;
                    top: 103px" Width="144px" AutoPostBack="True" OnTextChanged="txbTaskCompleted_TextChanged" Height="14px"></asp:TextBox>
        </div>
    
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
        <asp:HyperLink ID="HyperLink2" runat="server" Font-Size="Small" NavigateUrl="~/Login.aspx"
            Style="z-index: 102; left: 8px; position: absolute; top: 166px">Logoff/Change Input Screen</asp:HyperLink>
        &nbsp;<br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
    </form>
</body>
</html>


