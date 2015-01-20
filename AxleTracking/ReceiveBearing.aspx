<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ReceiveBearing.aspx.cs" Inherits="ReceiveBearing" %>

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
        <div style="z-index: 101; left: 1px; width: 320px; position: absolute; top: 1px;
            height: 223px">
            <asp:Label ID="lbOpertaorID" runat="server" Style="z-index: 100; left: 196px; position: absolute;
                top: 203px" Text="Operator ID:" Width="60px" Font-Size="X-Small"></asp:Label>
            &nbsp; &nbsp;&nbsp;
            <asp:Label ID="lblTitle" runat="server" Style="z-index: 101; left: 103px; position: absolute;
                top: 3px" Text="Receiving  Bearing " Width="118px"></asp:Label>
            <asp:Button ID="btnSummit" runat="server" Style="z-index: 102; left: 105px; position: absolute;
                top: 197px" Text="OK" Width="83px" OnClick="btnSummit_Click" />
            &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;<br />
            <br />
            &nbsp;
            &nbsp;
            <asp:Label ID="lblOperatorIDName" runat="server" Height="8px" Style="z-index: 103;
                left: 261px; position: absolute; top: 203px" Text="OperatorID" Width="51px" Font-Size="X-Small"></asp:Label>
            &nbsp;
            <asp:Label ID="lblTagID" runat="server" Height="8px" Style="z-index: 104; left: 7px;
                position: absolute; top: 28px" Text="Tag ID:" Width="67px"></asp:Label>
            &nbsp; &nbsp;&nbsp; &nbsp; &nbsp;&nbsp;
            <asp:Label ID="lblTagIDValue" runat="server" Height="8px" Style="z-index: 105; left: 106px;
                position: absolute; top: 27px" Text="TagID" Width="202px"></asp:Label>
            <div style="z-index: 108; left: 0px; width: 316px; position: absolute; top: 74px;
                height: 103px">
            <asp:Label ID="lblBearingType" runat="server" Height="8px" Style="z-index: 100; left: 6px;
                position: absolute; top: -23px" Text="Bearing Type:" Width="92px"></asp:Label>
                &nbsp; &nbsp;&nbsp;
            <asp:Label ID="lblBearing2Status" runat="server" Height="8px" Style="z-index: 102; left: 4px;
                position: absolute; top: 56px" Text="Bearing 2 Status:" Width="103px"></asp:Label>
                &nbsp;
                <asp:Label ID="lblBearing1Status" runat="server" Height="8px" Style="z-index: 103;
                    left: 4px; position: absolute; top: 6px" Text="Bearing 1 Status:" Width="103px"></asp:Label>
                <asp:Label ID="lblScrapReason1" runat="server" Height="8px" Style="z-index: 104;
                    left: 4px; position: absolute; top: 31px" Text="Reason:" Width="103px"></asp:Label>
                <asp:Label ID="Label1" runat="server" Height="8px" Style="z-index: 105; left: 4px;
                    position: absolute; top: 81px" Text="Reason:" Width="103px"></asp:Label>
                &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp;
                <mbcbb:combobox id="cmbBearingStatus1" runat="server" datasourceid="SqlDataSource3"
                    datatextfield="ReceiveStatus" datavaluefield="ReceiveStatus" style="z-index: 110;
                    left: 115px; position: absolute; top: 2px" width="189px" AutoPostBack="True">
                    <asp:ListItem>Databound</asp:ListItem>
</mbcbb:combobox>
                <mbcbb:combobox id="cmbBearingStatus2" runat="server" datasourceid="SqlDataSource3"
                    datatextfield="ReceiveStatus" datavaluefield="ReceiveStatus" style="z-index: 111;
                    left: 116px; position: absolute; top: 53px" width="189px" AutoPostBack="True">
                    <asp:ListItem>Databound</asp:ListItem>
</mbcbb:combobox>
                <mbcbb:combobox id="cmbScrapReasonB1" runat="server" datasourceid="SqlDataSource2"
                    datatextfield="Description" datavaluefield="Description" style="z-index: 112;
                    left: 116px; position: absolute; top: 27px" width="189px"><asp:ListItem>Databound</asp:ListItem>
</mbcbb:combobox>
                <mbcbb:combobox id="cmbScrapReasonB2" runat="server" datasourceid="SqlDataSource2"
                    datatextfield="Description" datavaluefield="Description" style="z-index: 114;
                    left: 117px; position: absolute; top: 79px" width="189px"><asp:ListItem>Databound</asp:ListItem>
</mbcbb:combobox>
            </div>
            <asp:CustomValidator ID="vldError" runat="server" ErrorMessage="CustomValidator"
                Font-Size="Small" Height="16px" Style="z-index: 106;
                left: 95px; position: absolute; top: 178px" ValidateEmptyText="True" Width="183px"></asp:CustomValidator>
            <mbcbb:ComboBox id="cmbBearingType" runat="server" DataSourceID="SqlDataSource1"
                DataTextField="Description" DataValueField="Description" style="z-index: 109;
                left: 117px; position: absolute; top: 48px" Width="187px">
                <asp:ListItem>Databound</asp:ListItem>
            </mbcbb:ComboBox>
        </div>
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        &nbsp; &nbsp;&nbsp;<br />
        <br />
        <br />
        <br />
        &nbsp;&nbsp;
        <br />
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:RFDBConnectionString %>"
                SelectCommand="SELECT [Description] FROM [Bearing Type]"></asp:SqlDataSource>
        <br /><asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:RFDBConnectionString %>"
            SelectCommand="SELECT [Description] FROM [Bearing Scrap]"></asp:SqlDataSource>
        <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:RFDBConnectionString %>"
            SelectCommand="SELECT [ReceiveStatus] FROM [ReceiveStatus]"></asp:SqlDataSource>
        &nbsp;<br />
        &nbsp;<br />
        <br />
        <br />
        &nbsp;<br />
    
    </div>
    </form>
</body>
</html>
