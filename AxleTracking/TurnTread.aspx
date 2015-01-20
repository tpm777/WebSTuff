<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TurnTread.aspx.cs" Inherits="TurnTread" %>

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
        <div style="z-index: 101; left: 3px; width: 320px; position: absolute; top: 4px;
            height: 197px">
            <asp:Label ID="lbOpertaorID" runat="server" Style="z-index: 100; left: 183px; position: absolute;
                top: 180px" Text="Operator ID:" Width="92px" Font-Size="X-Small"></asp:Label>
            <asp:Label ID="lblOperatorName" runat="server" Style="z-index: 101; left: 283px;
                position: absolute; top: 181px" Text="Name:" Width="30px" Font-Size="X-Small"></asp:Label>
            &nbsp; &nbsp;
            &nbsp; &nbsp;
            <asp:Label ID="lblTitle" runat="server" Style="z-index: 102; left: 121px; position: absolute;
                top: 4px" Text="Turned Tread" Width="83px"></asp:Label>
            <asp:Button ID="btnSummit" runat="server" Style="z-index: 103; left: 113px; position: absolute;
                top: 150px" Text="OK" Width="83px" OnClick="btnSummit_Click" />
            &nbsp; &nbsp;&nbsp; &nbsp; &nbsp;
            <asp:Label ID="lblTagID" runat="server" Height="8px" Style="z-index: 105; left: 8px;
                position: absolute; top: 27px" Text="TagID:" Width="70px"></asp:Label>
            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
            <div id="DIV1" style="z-index: 108; left: 8px; width: 298px; position: absolute;
                top: 58px; height: 91px" language="javascript" onclick="return DIV1_onclick()">
                <asp:Label ID="lblWheelSerialNumber" runat="server" Height="8px" Style="z-index: 100;
                    left: 8px; position: absolute; top: 11px" Text="Wheel 1 Serial #:" Width="109px"></asp:Label>
                <asp:Label ID="Label1" runat="server" Height="8px" Style="z-index: 100; left: 8px;
                    position: relative; top: 35px" Text="Wheel  2 Serial #:" Width="109px"></asp:Label>
                <asp:TextBox ID="txbWheel_1_SerialNumber" runat="server" Style="z-index: 101; left: 138px;
                    position: absolute; top: 11px" Width="140px"></asp:TextBox>
                <asp:TextBox ID="txbWheel_2_SerialNumber" runat="server" Style="z-index: 101; left: 138px;
                    position: absolute; top: 35px" Width="140px"></asp:TextBox>
                <asp:Label ID="lblNumberOfCusts" runat="server" Height="8px" Style="z-index: 102;
                    left: 8px; position: absolute; top: 64px" Text="Number Of Cuts:" Width="111px"></asp:Label>
                <asp:TextBox ID="txbNumberOfCuts" runat="server" Style="z-index: 103; left: 138px; position: absolute;
                    top: 63px" Width="63px"></asp:TextBox>
                &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;
                <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="txbNumberOfCuts"
                    ErrorMessage="Value Not Allowed" MaximumValue="50" MinimumValue="0" Style="left: 64px;
                    position: relative; top: 65px" Width="130px"></asp:RangeValidator></div>
            &nbsp;
            <asp:TextBox ID="txbTagID" runat="server" Style="z-index: 106; left: 89px; position: absolute;
                top: 26px" Width="209px" AutoPostBack="True" OnTextChanged="txbTagID_TextChanged"></asp:TextBox>
            <asp:HyperLink ID="HyperLink2" runat="server" Font-Size="Small" NavigateUrl="~/Login.aspx"
                Style="z-index: 109; left: 4px; position: absolute; top: 178px">Logoff/Change Input Screen</asp:HyperLink>
        </div>
    
    </div>
    </form>
</body>
</html>
