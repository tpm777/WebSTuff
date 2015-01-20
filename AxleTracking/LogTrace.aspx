<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LogTrace.aspx.cs" Inherits="LogTrace" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body bgcolor="#99ffff">
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="lblTitle" runat="server" Font-Size="X-Large" Style="left: 254px; position: relative;
            top: -2px" Text="LogTrace" Width="105px"></asp:Label>
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True"
            AutoGenerateColumns="False" BorderWidth="4px" CellPadding="4" CellSpacing="4"
            DataSourceID="SqlDataSource1" OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
            PageSize="6" Style="left: 3px; position: relative; top: 10px" Width="601px">
            <FooterStyle BackColor="Lime" BorderColor="Lime" />
            <Columns>
                <asp:BoundField DataField="DateTime" HeaderText="DateTime" SortExpression="DateTime" />
                <asp:BoundField DataField="Module" HeaderText="Module" SortExpression="Module" />
                <asp:BoundField DataField="EventDescription" HeaderText="EventDescription" SortExpression="EventDescription" />
            </Columns>
        </asp:GridView>
        &nbsp;
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:RFDBConnectionString %>"
            SelectCommand="SELECT * FROM [LogTrace]"></asp:SqlDataSource>
    
    </div>
    </form>
</body>
</html>
