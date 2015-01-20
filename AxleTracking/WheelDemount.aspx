<%@ Page Language="C#" AutoEventWireup="true" CodeFile="WheelDemount.aspx.cs" Inherits="WheelDemount" %>

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
<script language="javascript" type="text/javascript">
<!--

function DIV1_onclick() {

}

// -->
</script>
</head>
<body bgcolor="#99ffff">
    <form id="form1" runat="server">
    <div>
        <div style="z-index: 101; left: 1px; width: 320px; position: absolute; top: 3px;
            height: 177px">
            <asp:Label ID="lbOpertaorID" runat="server" Style="z-index: 100; left: 203px; position: absolute;
                top: 156px" Text="Operator ID:" Width="58px" Font-Size="X-Small"></asp:Label>
            &nbsp; &nbsp;
            &nbsp; &nbsp;
            <asp:Label ID="lblTitle" runat="server" Style="z-index: 101; left: 108px; position: absolute;
                top: 5px" Text="Wheel Demount" Width="108px" Height="6px"></asp:Label>
            <asp:Button ID="btnSummit" runat="server" Style="z-index: 102; left: 116px; position: absolute;
                top: 131px" Text="OK" Width="83px" OnClick="btnSummit_Click" />
            &nbsp; &nbsp;&nbsp; &nbsp; &nbsp;
            &nbsp; &nbsp;
            <asp:Label ID="lblTrackingID" runat="server" Height="8px" Style="z-index: 104; left: 7px;
                position: absolute; top: 31px" Text="Tag ID:" Width="66px"></asp:Label>
            <asp:Label ID="lblOperatorName" runat="server" Height="8px" Style="z-index: 105; left: 264px;
                position: absolute; top: 157px" Text="Name" Width="55px" Font-Size="X-Small"></asp:Label>
            <asp:TextBox ID="txbTagID" runat="server" Style="z-index: 106; left: 91px;
                position: absolute; top: 29px" Width="212px" AutoPostBack="True" OnTextChanged="txbTrackingID_TextChanged"></asp:TextBox>
            &nbsp; &nbsp; &nbsp;&nbsp;
            <div id="DIV1" style="z-index: 111; left: 0px; width: 311px; position: absolute;
                top: 98px; height: 29px" language="javascript" onclick="return DIV1_onclick()">
                &nbsp;
            <asp:Label ID="Label1" runat="server" Height="8px" Style="z-index: 100;
                left: 6px; position: absolute; top: 8px" Text="# of Wheels Mounted:" Width="140px" Font-Size="Small"></asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp;
                <mbcbb:combobox id="cmbWheelStatusCode" runat="server" datasourceid="SqlDataSource1"
                    datatextfield="Demount_Status" datavaluefield="Demount_Status" style="z-index: 102;
                    left: 154px; position: absolute; top: 5px" width="138px"><asp:ListItem>Databound</asp:ListItem>
</mbcbb:combobox>
            </div>
            <asp:Label ID="lblCustomer" runat="server" Height="8px" Style="z-index: 107; left: 7px;
                position: absolute; top: 55px" Text="Customer:" Width="67px"></asp:Label>
            <asp:Label ID="lblCustomerName" runat="server" Height="8px" Style="z-index: 108;
                left: 92px; position: absolute; top: 55px" Width="184px"></asp:Label>
            <asp:Label ID="lblLoadIDValue" runat="server" Height="8px" Style="z-index: 109; left: 89px;
                position: absolute; top: 78px" Width="185px"></asp:Label>
            <asp:Label ID="lblLoadIDName" runat="server" Height="8px" Style="z-index: 112; left: 6px;
                position: absolute; top: 78px" Text="Load ID:" Width="68px"></asp:Label>
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
            Style="z-index: 102; left: 8px; position: absolute; top: 161px">Logoff/Change Input Screen</asp:HyperLink>
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:RFDBConnectionString %>"
            ProviderName="<%$ ConnectionStrings:RFDBConnectionString.ProviderName %>"
            SelectCommand="SELECT [Demount Status] AS Demount_Status FROM [WheelDemountStatusCodes]"></asp:SqlDataSource>
    </form>
</body>
</html>

