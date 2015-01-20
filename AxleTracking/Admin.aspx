<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Admin.aspx.cs" Inherits="Admin" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body bgcolor="#00ccff">
    <form id="form1" runat="server">
    <div>
        &nbsp;</div>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:RFDBConnectionString %>"
            SelectCommand="SELECT * FROM [Axle]"></asp:SqlDataSource><asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:RFDBConnectionString %>"
            SelectCommand="SELECT * FROM [WM Operation]"></asp:SqlDataSource>
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:RFDBConnectionString %>"
            SelectCommand="SELECT [Tag ID] AS Tag_ID, [Machine ID] AS Machine_ID, [APS Code] AS APS_Code, [AP Operator ID] AS AP_Operator_ID, [AD DT Stamp] AS AD_DT_Stamp, [Task1] FROM [AP Operation]">
        </asp:SqlDataSource>
        <asp:Label ID="Label1" runat="server" Style="z-index: 100; left: 369px; position: absolute;
            top: 69px" Text="Master Axle Table" Width="173px"></asp:Label>
        &nbsp;
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BorderColor="Black"
            BorderStyle="Groove" BorderWidth="1px" CellSpacing="1" DataSourceID="SqlDataSource1"
            HorizontalAlign="Center" Style="z-index: 102; left: 16px; position: relative;
            top: 100px">
            <FooterStyle BackColor="#C0FFC0" />
            <Columns>
                <asp:BoundField DataField="Tag ID" HeaderText="Tag ID" SortExpression="Tag ID" />
                <asp:BoundField DataField="Load ID" HeaderText="Load ID" SortExpression="Load ID" />
                <asp:BoundField DataField="Created By" HeaderText="Created By" SortExpression="Created By" />
                <asp:BoundField DataField="Created On" HeaderText="Created On" SortExpression="Created On" />
                <asp:BoundField DataField="Plant ID" HeaderText="Plant ID" SortExpression="Plant ID" />
                <asp:BoundField DataField="Inbound Customer" HeaderText="Inbound Customer" SortExpression="Inbound Customer" />
                <asp:BoundField DataField="Inbound Customer Location" HeaderText="Inbound Customer Location"
                    SortExpression="Inbound Customer Location" />
                <asp:BoundField DataField="Inbound Axle Type" HeaderText="Inbound Axle Type" SortExpression="Inbound Axle Type" />
                <asp:BoundField DataField="Inbound Wheel Type" HeaderText="Inbound Wheel Type" SortExpression="Inbound Wheel Type" />
                <asp:BoundField DataField="Inbound Wheel1 Status" HeaderText="Inbound Wheel1 Status"
                    SortExpression="Inbound Wheel1 Status" />
                <asp:BoundField DataField="Inbound Wheel2 Status" HeaderText="Inbound Wheel2 Status"
                    SortExpression="Inbound Wheel2 Status" />
                <asp:BoundField DataField="Inbound Bearing Type" HeaderText="Inbound Bearing Type"
                    SortExpression="Inbound Bearing Type" />
                <asp:BoundField DataField="Inbound Bearing 1 Status" HeaderText="Inbound Bearing 1 Status"
                    SortExpression="Inbound Bearing 1 Status" />
                <asp:BoundField DataField="Inbound Bearing 2 Status" HeaderText="Inbound Bearing 2 Status"
                    SortExpression="Inbound Bearing 2 Status" />
                <asp:BoundField DataField="Axle Status Code" HeaderText="Axle Status Code" SortExpression="Axle Status Code" />
                <asp:BoundField DataField="Wheel Status Code" HeaderText="Wheel Status Code" SortExpression="Wheel Status Code" />
                <asp:BoundField DataField="Bearing 1 Status" HeaderText="Bearing 1 Status" SortExpression="Bearing 1 Status" />
                <asp:BoundField DataField="Bearing 2 Status" HeaderText="Bearing 2 Status" SortExpression="Bearing 2 Status" />
                <asp:BoundField DataField="Outbound Customer" HeaderText="Outbound Customer" SortExpression="Outbound Customer" />
                <asp:BoundField DataField="Outbound Sales Order" HeaderText="Outbound Sales Order"
                    SortExpression="Outbound Sales Order" />
                <asp:BoundField DataField="Shipped By" HeaderText="Shipped By" SortExpression="Shipped By" />
                <asp:BoundField DataField="Shipped On" HeaderText="Shipped On" SortExpression="Shipped On" />
                <asp:BoundField DataField="Axle Size" HeaderText="Axle Size" SortExpression="Axle Size" />
                <asp:BoundField DataField="Outbound Wheel Type" HeaderText="Outbound Wheel Type"
                    SortExpression="Outbound Wheel Type" />
                <asp:BoundField DataField="Outbound Bearing Type" HeaderText="Outbound Bearing Type"
                    SortExpression="Outbound Bearing Type" />
                <asp:BoundField DataField="Status Code" HeaderText="Status Code" SortExpression="Status Code" />
            </Columns>
            <AlternatingRowStyle VerticalAlign="Middle" />
        </asp:GridView>
        &nbsp;
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
        <div style="z-index: 104; left: 29px; width: 631px; position: relative; top: -47px;
            height: 37px">
            &nbsp;<asp:Label ID="Label3" runat="server" Style="z-index: 101; left: 26px; position: relative;
                top: 3px" Text="Production Details" Width="173px"></asp:Label>
            <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource2"
                Style="z-index: 103; left: 26px; position: relative; top: 11px">
                <Columns>
                    <asp:BoundField DataField="Tag_ID" HeaderText="Tag_ID" SortExpression="Tag_ID" />
                    <asp:BoundField DataField="Machine_ID" HeaderText="Machine_ID" SortExpression="Machine_ID" />
                    <asp:BoundField DataField="APS_Code" HeaderText="APS_Code" SortExpression="APS_Code" />
                    <asp:BoundField DataField="AP_Operator_ID" HeaderText="AP_Operator_ID" SortExpression="AP_Operator_ID" />
                    <asp:BoundField DataField="AD_DT_Stamp" HeaderText="AD_DT_Stamp" SortExpression="AD_DT_Stamp" />
                    <asp:BoundField DataField="Task1" HeaderText="Task1" SortExpression="Task1" />
                </Columns>
            </asp:GridView>
            <div style="z-index: 104; left: 16px; width: 631px; position: relative; top: 212px;
                height: 100px">
                &nbsp;<asp:Label ID="Label2" runat="server" Style="z-index: 101; left: 26px; position: relative;
                    top: 3px" Text="Wheel Mount Details" Width="173px"></asp:Label>
                <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource3"
                    Style="z-index: 103; left: 26px; position: relative; top: 11px">
                    <Columns>
                        <asp:BoundField DataField="Tag ID" HeaderText="Tag ID" SortExpression="Tag ID" />
                        <asp:BoundField DataField="Plant ID" HeaderText="Plant ID" SortExpression="Plant ID" />
                        <asp:BoundField DataField="Machine ID" HeaderText="Machine ID" SortExpression="Machine ID" />
                        <asp:BoundField DataField="WM Operator ID" HeaderText="WM Operator ID" SortExpression="WM Operator ID" />
                        <asp:BoundField DataField="WM DT Stamp" HeaderText="WM DT Stamp" SortExpression="WM DT Stamp" />
                        <asp:BoundField DataField="Wheel 1 Serial Number 1" HeaderText="Wheel 1 Serial Number 1"
                            SortExpression="Wheel 1 Serial Number 1" />
                        <asp:BoundField DataField="Wheel 1 Serial Number 2" HeaderText="Wheel 1 Serial Number 2"
                            SortExpression="Wheel 1 Serial Number 2" />
                        <asp:BoundField DataField="Wheel 2 Serial Number 1" HeaderText="Wheel 2 Serial Number 1"
                            SortExpression="Wheel 2 Serial Number 1" />
                        <asp:BoundField DataField="Wheel 2 Serial Number 2" HeaderText="Wheel 2 Serial Number 2"
                            SortExpression="Wheel 2 Serial Number 2" />
                        <asp:BoundField DataField="Wheel Type ID" HeaderText="Wheel Type ID" SortExpression="Wheel Type ID" />
                        <asp:BoundField DataField="Misfits" HeaderText="Misfits" SortExpression="Misfits" />
                        <asp:BoundField DataField="Remounts" HeaderText="Remounts" SortExpression="Remounts" />
                    </Columns>
                </asp:GridView>
            </div>
        </div>
        <br />
    </form>
</body>
</html>
