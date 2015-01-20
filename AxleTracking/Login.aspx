<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<%@ Register Assembly="MetaBuilders.WebControls.ComboBox, Version=1.1.5000.0, Culture=neutral, PublicKeyToken=8f1b87f9edb00944"
    Namespace="MetaBuilders.WebControls" TagPrefix="mbcbb" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<%
  Response.Expires = 0;
  Response.CacheControl = "no-cache";
%>





<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Untitled Page</title>
<style type="text/css">
html {
overflow-x:hidden;
overflow-y:hidden;

}
</style>    
    <script language="javascript" src="JSLib/Global.js" type="text/javascript"></script>
    <script language="javascript" src="JSLib/Textbox.Restriction.js" type="text/javascript"></script>
    <script language="javascript" src="JSLib/Textbox.MaskEdit.js" type="text/javascript"></script>
    <script language="javascript" src="JSLib/Textbox.Trim.js" type="text/javascript"></script>
    <script language="javascript" src="JSLib/Textbox.Tip.js" type="text/javascript"></script>
    <script language="javascript" src="JSLib/AJAX.js" type="text/javascript"></script>
    <script language="javascript" src="JS/default.js" type="text/javascript"></script> 
</head>
<body bgcolor="#99ffff" onload="OnPageLoad();">
    <form id="form1" runat="server">
    <div>
        <div style="z-index: 102; left: -2px; width: 271px; position: absolute; top: 0px;
            height: 194px">
            &nbsp; &nbsp; &nbsp;&nbsp;
            <asp:Label ID="lblTitle" runat="server" Style="z-index: 100; left: 98px; position: absolute;
                top: 1px" Text="Access Control" Width="123px"></asp:Label>
            <asp:Button ID="btnSummit" runat="server" Style="z-index: 101; left: 91px; position: absolute;
                top: 130px" Text="OK" Width="83px" OnClick="btnSummit_Click" />
            &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
            <asp:Label ID="lblMachineID" runat="server" Height="8px" Style="z-index: 102; left: 6px;
                position: absolute; top: 85px" Text="Station ID:" Width="78px"></asp:Label>
            <asp:Label ID="lblStationPurpose" runat="server" Height="8px" Style="z-index: 111;
                left: 7px; position: absolute; top: 109px" Text="Description:" Width="78px"></asp:Label>
            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp;&nbsp;&nbsp; &nbsp; &nbsp;&nbsp;
            &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
            <asp:TextBox ID="txbLoginID" runat="server" OnTextChanged="txbLoginID_TextChanged"  
                Style="z-index: 104; left: 93px; position: absolute; top: 27px" Width="143px" Height="16px" AutoPostBack="True"></asp:TextBox>
            <asp:Label ID="Label1" runat="server" Style="z-index: 105; left: 6px; position: absolute;
                top: 56px" Text="Password:" Width="82px"></asp:Label>
            <asp:TextBox ID="txbPassword" runat="server" AutoPostBack="True" Font-Names="Wingdings"
                OnTextChanged="txbPassword_TextChanged" Style="z-index: 106; left: 93px; position: absolute;
                top: 56px" Width="142px" Height="16px"></asp:TextBox>
            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;&nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp;
            &nbsp; &nbsp; &nbsp;&nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
            <asp:Label ID="lblMessage" runat="server" Font-Size="Small" ForeColor="Red" Style="z-index: 107;
                left: 38px; position: absolute; top: 157px" Text="lblMessage" Width="203px"></asp:Label>
            <asp:Label ID="lbOpertaorID" runat="server" Style="z-index: 108; left: 7px; position: absolute;
                top: 26px" Text="Operator ID:" Width="82px"></asp:Label>
            <mbcbb:combobox id="cmbStationIDs" runat="server" autopostback="True" onselectedindexchanged="cmbStationIDs_SelectedIndexChanged"
                style="z-index: 109; left: 94px; position: absolute; top: 83px" width="141px"><asp:ListItem></asp:ListItem>
</mbcbb:combobox>
            <asp:Label ID="lblStationDesc" runat="server" Font-Size="X-Small" Height="13px" Style="z-index: 110;
                left: 96px; position: absolute; top: 111px" Width="168px"></asp:Label>
        </div>
        <br />
        <br />
        &nbsp;&nbsp;<br />
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
        <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:RFDBConnectionString %>"
            ProviderName="<%$ ConnectionStrings:RFDBConnectionString.ProviderName %>"
            SelectCommand="SELECT [StationID] FROM [AccessProfiles] WHERE ([StationID] = @StationID)">
            <SelectParameters>
                <asp:ControlParameter ControlID="txbLoginID" Name="StationID" PropertyName="Text"
                    Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>
        &nbsp;<br />
        <br />
        <br />
    
    </div>
    </form>
</body>
</html>



