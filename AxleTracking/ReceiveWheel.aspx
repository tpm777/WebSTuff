<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ReceiveWheel.aspx.cs" Inherits="ReceiveWheel" %>

<%@ Register Assembly="MetaBuilders.WebControls.ComboBox, Version=1.1.5000.0, Culture=neutral, PublicKeyToken=8f1b87f9edb00944"
    Namespace="MetaBuilders.WebControls" TagPrefix="mbcbb" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">



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
        <div style="z-index: 102; left: 2px; width: 314px; position: absolute; top: 0px;
            height: 205px">
            <asp:Label ID="lbOpertaorID" runat="server" Style="z-index: 100; left: 205px; position: absolute;
                top: 181px" Text="Operator ID:" Width="58px" Font-Size="X-Small"></asp:Label>
            &nbsp; &nbsp;&nbsp;
            <asp:Label ID="lblTitle" runat="server" Style="z-index: 101; left: 100px; position: absolute;
                top: 4px" Text="Receive Wheel Set" Width="120px"></asp:Label>
            <asp:Button ID="btnSummit" runat="server" Style="z-index: 102; left: 113px; position: absolute;
                top: 172px" Text="OK" Width="83px" OnClick="btnSummit_Click" />
            &nbsp; &nbsp; &nbsp;
            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
            <asp:Label ID="lblOperatorIDName" runat="server" Height="8px" Style="z-index: 103;
                left: 265px; position: absolute; top: 180px" Text="OperatorID" Width="47px" Font-Size="X-Small"></asp:Label>
            &nbsp;
            <asp:Label ID="lblTagID" runat="server" Height="8px" Style="z-index: 104; left: 7px;
                position: absolute; top: 29px" Text="Tag ID:" Width="135px"></asp:Label>
            &nbsp; &nbsp;&nbsp; &nbsp; &nbsp;&nbsp;
            <asp:Label ID="lblTagIDValue" runat="server" Height="8px" Style="z-index: 105; left: 153px;
                position: absolute; top: 31px" Text="TagID" Width="149px"></asp:Label>
            <asp:Label ID="lblWheelType" runat="server" Height="8px" Style="z-index: 106; left: 7px;
                position: absolute; top: 55px" Text="Wheel Type:" Width="83px"></asp:Label>
            <mbcbb:ComboBox id="cmbWheelType" runat="server" DataSourceID="SqlDataSource1" DataTextField="Description"
                DataValueField="Description" Font-Size="Medium" style="z-index: 107; left: 109px;
                position: absolute; top: 55px" Width="187px">
                <asp:ListItem>Databound</asp:ListItem>
            </mbcbb:ComboBox>
                <asp:Label ID="lblWheel1Status" runat="server" Height="8px" Style="z-index: 108;
                    left: 6px; position: absolute; top: 86px" Text="Receive  Status:" Width="97px"></asp:Label>
            <mbcbb:ComboBox id="cmbWheelStatus" runat="server" AutoPostBack="True" DataSourceID="SqlDataSource2"
                DataTextField="ReceiveStatus" DataValueField="ReceiveStatus" Font-Size="Medium"
                OnSelectedIndexChanged="cmbWheelStatus_SelectedIndexChanged" style="z-index: 109;
                left: 109px; position: absolute; top: 85px" Width="187px">
                <asp:ListItem>Databound</asp:ListItem>
            </mbcbb:ComboBox>
            <asp:Label ID="lblReason" runat="server" Height="8px" Style="z-index: 110; left: 8px;
                position: absolute; top: 116px" Text="Reason:" Width="68px"></asp:Label>
            <mbcbb:ComboBox id="cmbScrapReason" runat="server" DataSourceID="SqlDataSource3"
                DataTextField="Description" DataValueField="Description" Font-Size="Medium" style="z-index: 111;
                left: 109px; position: absolute; top: 115px" Width="187px">
                <asp:ListItem>Databound</asp:ListItem>
            </mbcbb:ComboBox>
            <asp:CustomValidator ID="vldError" runat="server" ErrorMessage="CustomValidator"
                OnServerValidate="vldError_ServerValidate" Style="z-index: 113; left: 85px; position: absolute;
                top: 148px" ValidateEmptyText="True"></asp:CustomValidator>
        </div>
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        &nbsp;&nbsp;<br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:RFDBConnectionString %>"
            SelectCommand="SELECT [Description] FROM [Wheel Type]"></asp:SqlDataSource>
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:RFDBConnectionString %>"
            SelectCommand="SELECT [ReceiveStatus] FROM [ReceiveStatus]"></asp:SqlDataSource><asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:RFDBConnectionString %>"
            SelectCommand="SELECT [Description] FROM [Wheel Scrap]"></asp:SqlDataSource>
        <br />
        <br />
        <br />
        <br />
    
    </div>
    </form>
</body>
</html>
