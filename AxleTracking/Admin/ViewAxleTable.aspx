<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ViewAxleTable.aspx.cs" Inherits="Admin_ViewAxleTable" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body bgcolor="#99ff66">
    <form id="form1" runat="server">
    <div>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:RFDBConnectionString %>"
            SelectCommand="SELECT * FROM [Axle]"></asp:SqlDataSource>
    
    </div>
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False"
            Caption="Inbound Axle Information" CaptionAlign="Top" CellPadding="4" DataSourceID="SqlDataSource1"
            ForeColor="#333333" GridLines="None" Style="z-index: 100; left: 3px; position: absolute;
            top: 31px">
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <Columns>
                <asp:BoundField DataField="Tag ID" HeaderText="Tag ID" SortExpression="Tag ID" />
                <asp:BoundField DataField="Load ID" HeaderText="Load ID" SortExpression="Load ID" />
                <asp:BoundField DataField="Created By" HeaderText="Created By" SortExpression="Created By" />
                <asp:BoundField DataField="Created On" HeaderText="Created On" SortExpression="Created On" />
                <asp:BoundField DataField="Plant ID" HeaderText="Plant ID" SortExpression="Plant ID" />
                <asp:BoundField DataField="Inbound Customer" HeaderText="Inbound Customer" SortExpression="Inbound Customer" />
                <asp:BoundField DataField="Inbound Customer Location" HeaderText="ICustomer Loc"
                    SortExpression="Inbound Customer Location" />
                <asp:BoundField DataField="Inbound Axle Type" HeaderText="Inbound Axle Type" SortExpression="Inbound Axle Type" />
                <asp:BoundField DataField="Inbound Bearing Type" HeaderText="Inbound Bearing Type"
                    SortExpression="Inbound Bearing Type" />
                <asp:BoundField DataField="Inbound Bearing 1 Status" HeaderText=" B1 Status" SortExpression="Inbound Bearing 1 Status" />
                <asp:BoundField DataField="Inbound Bearing 1 Scrap Code" HeaderText="B1 SC" SortExpression="Inbound Bearing 1 Scrap Code" />
                <asp:BoundField DataField="Inbound Bearing 2 Status" HeaderText="B2 Status" SortExpression="Inbound Bearing 2 Status" />
                <asp:BoundField DataField="Inbound Bearing 2 Scrap Code" HeaderText="B2 SC" SortExpression="Inbound Bearing 2 Scrap Code" />
                <asp:BoundField DataField="Inbound Wheel Type" HeaderText="Inbound Wheel Type" SortExpression="Inbound Wheel Type" />
                <asp:BoundField DataField="Inbound Wheel Status" HeaderText="Inbound Wheel Status"
                    SortExpression="Inbound Wheel Status" />
                <asp:BoundField DataField="Inbound Wheel Scrap Code" HeaderText="Inbound Wheel Scrap Code"
                    SortExpression="Inbound Wheel Scrap Code" />
                <asp:BoundField DataField="Axle Status Code" HeaderText="Axle Status Code" SortExpression="Axle Status Code" />
                <asp:BoundField DataField="Bearing Status" HeaderText="Bearing Status" SortExpression="Bearing Status" />
                <asp:BoundField DataField="Wheel Status" HeaderText="Wheel Status" SortExpression="Wheel Status" />
                <asp:BoundField DataField="Status Code" HeaderText="Status Code" SortExpression="Status Code" />
            </Columns>
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <EditRowStyle BackColor="#999999" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        </asp:GridView>
    </form>
</body>
</html>
