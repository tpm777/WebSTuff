<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ViewReceiveLoad.aspx.cs" Inherits="Admin_ViewReceiveLoad" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body bgcolor="#99ff66">
    <form id="form1" runat="server">
    <div>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:RFDBConnectionString %>"
            SelectCommand="SELECT * FROM [LoadID]"></asp:SqlDataSource>
    
    </div>
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True"
            AutoGenerateColumns="False" Caption="Receive Load" CaptionAlign="Top" CellPadding="4"
            DataSourceID="SqlDataSource1" EnableSortingAndPagingCallbacks="True" ForeColor="#333333"
            GridLines="None" Style="z-index: 100; left: 225px; position: absolute; top: 6px"
            Width="274px">
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <Columns>
                <asp:BoundField DataField="Load ID" HeaderText="Load ID" SortExpression="Load ID" />
                <asp:BoundField DataField="Customer ID" HeaderText="Customer ID" SortExpression="Customer ID" />
                <asp:BoundField DataField="Qty" HeaderText="Qty" SortExpression="Qty" />
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
