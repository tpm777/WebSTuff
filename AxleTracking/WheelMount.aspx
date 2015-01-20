<%@ Page Language="C#" AutoEventWireup="true" CodeFile="WheelMount.aspx.cs" Inherits="WheelMount" %>

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
</head>
<body bgcolor="#99ffff">
    <form id="form1" runat="server">
    <div>
        <div style="z-index: 101; left: 1px; width: 307px; position: absolute; top: 0px;
            height: 236px">
            <asp:Label ID="lbOpertaorID" runat="server" Style="z-index: 100; left: 189px; position: absolute;
                top: 218px" Text="Operator ID:" Width="61px" Font-Size="X-Small"></asp:Label>
            <asp:Label ID="lblOperatorName" runat="server" Style="z-index: 101; left: 257px;
                position: absolute; top: 217px" Text="Name:" Width="40px" Font-Size="X-Small"></asp:Label>
            &nbsp; &nbsp;
            &nbsp; &nbsp;
            <asp:Label ID="lblTitle" runat="server" Style="z-index: 102; left: 110px; position: absolute;
                top: 2px" Text="Wheel Mount" Width="91px" Font-Size="Small"></asp:Label>
            <asp:Button ID="btnSummit" runat="server" Style="z-index: 103; left: 106px; position: absolute;
                top: 169px" Text="OK" Width="83px" OnClick="btnSummit_Click" />
            &nbsp; &nbsp;&nbsp; &nbsp; &nbsp;
            <asp:Label ID="lblTagID" runat="server" Height="8px" Style="z-index: 104; left: 7px;
                position: absolute; top: 22px" Text="TagID:" Width="89px"></asp:Label>
            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
            <div id="DIV1" style="z-index: 108; left: 5px; width: 292px; position: absolute;
                top: 66px; height: 92px" language="javascript" onclick="return DIV1_onclick()">
                <asp:Label ID="lblWheel1Barcode1" runat="server" Height="3px" Style="z-index: 100;
                    left: 9px; position: absolute; top: 5px" Text="Wheel 1 Barcode 1:" Width="110px" Font-Size="Small"></asp:Label>
                <asp:TextBox ID="txbWheel_1_Barcode_1" runat="server" Style="z-index: 101; left: 123px;
                    position: absolute; top: 4px" Width="152px" Height="13px"></asp:TextBox>
                <asp:Label ID="lblWheel1Barcode2" runat="server" Height="3px" Style="z-index: 102;
                    left: 9px; position: absolute; top: 27px" Text="Wheel 1 Barcode 2:" Width="110px" Font-Size="Small"></asp:Label>
                <asp:TextBox ID="txbWheel_1_Barcode_2" runat="server" Style="z-index: 103; left: 123px; position: absolute;
                    top: 25px" Width="152px" Height="13px"></asp:TextBox>
                &nbsp;&nbsp;
                <asp:Label ID="Label2" runat="server" Height="3px" Style="z-index: 100; left: 4px;
                    position: absolute; top: -79px" Text="Wheel 2 Barcode 1:" Width="108px" Font-Size="Small"></asp:Label>
                <asp:TextBox ID="txbWheel_2_Barcode_1" runat="server" Style="z-index: 101; left: 123px; position: absolute;
                    top: 47px" Width="152px" Font-Size="Small" Height="13px"></asp:TextBox>
                &nbsp;

                    <asp:Label ID="Label3" runat="server" Height="8px" Style="z-index: 103; left: 9px;
                        position: absolute; top: 68px" Text="Wheel 2 Barcode 2:" Width="105px" Font-Size="Small"></asp:Label>
                <asp:Label ID="Label1" runat="server" Font-Size="Small" Height="8px" Style="z-index: 103;
                    left: 9px; position: absolute; top: 49px" Text="Wheel 2 Barcode 1:" Width="105px"></asp:Label>
                    <asp:TextBox ID="txbWheel_2_Barcode_2" runat="server" Style="z-index: 104; left: 123px; position: absolute;
                        top: 69px" Width="152px" Height="13px"></asp:TextBox>
                    &nbsp;&nbsp;
            </div>
            &nbsp;
            <asp:TextBox ID="txbTagID" runat="server" Style="z-index: 105; left: 104px; position: absolute;
                top: 20px" Width="187px" AutoPostBack="True" OnTextChanged="txbTagID_TextChanged"></asp:TextBox>
                <asp:Label ID="lblWheel1SizeType" runat="server" Style="z-index: 106; left: 8px;
                    position: absolute; top: 45px" Text="Wheel Type:" Width="86px" Font-Size="X-Small"></asp:Label>
            &nbsp; &nbsp;&nbsp;
            <mbcbb:combobox id="cmbWheelType" runat="server" autopostback="True" datasourceid="SqlDataSource1"
                datatextfield="Description" datavaluefield="Description" font-size="X-Small"
                onselectedindexchanged="cmbWheelType_SelectedIndexChanged" style="z-index: 109;
                left: 108px; position: absolute; top: 44px" width="172px"><asp:ListItem>Databound</asp:ListItem>
</mbcbb:combobox>
        </div>
        <asp:HyperLink ID="HyperLink2" runat="server" Font-Size="Small" NavigateUrl="~/Login.aspx"
            Style="z-index: 102; left: 4px; position: absolute; top: 215px">Logoff/Change Input Screen</asp:HyperLink>
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
            SelectCommand="SELECT [Description] FROM [Wheel Type]"></asp:SqlDataSource>
    
    </div>
    </form>
</body>
</html>
