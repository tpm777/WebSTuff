<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AdminMain.aspx.cs" Inherits="Admin_AdminMain" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body bgcolor="#99ff66">
    <form id="form1" runat="server">
    <div>
        <asp:Button ID="btnViewAxle" runat="server" OnClick="Button1_Click" Style="z-index: 100;
            left: 97px; position: absolute; top: 72px" Text="View Axle Table" Width="150px" />
        <asp:Button ID="btnReceiveLoad" runat="server" OnClick="btnReceiveLoad_Click" Style="z-index: 102;
            left: 96px; position: absolute; top: 103px" Text="View Receive Load" Width="150px" />
    
    </div>
    </form>
</body>
</html>
