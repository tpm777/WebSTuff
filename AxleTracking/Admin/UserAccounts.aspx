<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UserAccounts.aspx.cs" Inherits="UserAccounts" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body bgcolor="#ccff66">
    <form id="form1" runat="server">
    <div>
        &nbsp;</div>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:RFDBConnectionString %>"
            SelectCommand="SELECT [Operator ID] AS Operator_ID, [Password], [AccessProfile], [Plant ID] AS Plant_ID FROM [Operators]" ConflictDetection="CompareAllValues" DeleteCommand="DELETE FROM [Operators] WHERE [Operator ID] = @original_Operator_ID AND [Password] = @original_Password AND [AccessProfile] = @original_AccessProfile AND [Plant ID] = @original_Plant_ID" InsertCommand="INSERT INTO [Operators] ([Operator ID], [Password], [AccessProfile], [Plant ID]) VALUES (@Operator_ID, @Password, @AccessProfile, @Plant_ID)" OldValuesParameterFormatString="original_{0}" UpdateCommand="UPDATE [Operators] SET [Password] = @Password, [AccessProfile] = @AccessProfile, [Plant ID] = @Plant_ID WHERE [Operator ID] = @original_Operator_ID AND [Password] = @original_Password AND [AccessProfile] = @original_AccessProfile AND [Plant ID] = @original_Plant_ID">
            <DeleteParameters>
                <asp:Parameter Name="original_Operator_ID" Type="String" />
                <asp:Parameter Name="original_Password" Type="String" />
                <asp:Parameter Name="original_AccessProfile" Type="String" />
                <asp:Parameter Name="original_Plant_ID" Type="String" />
            </DeleteParameters>
            <UpdateParameters>
                <asp:Parameter Name="Password" Type="String" />
                <asp:Parameter Name="AccessProfile" Type="String" />
                <asp:Parameter Name="Plant_ID" Type="String" />
                <asp:Parameter Name="original_Operator_ID" Type="String" />
                <asp:Parameter Name="original_Password" Type="String" />
                <asp:Parameter Name="original_AccessProfile" Type="String" />
                <asp:Parameter Name="original_Plant_ID" Type="String" />
            </UpdateParameters>
            <InsertParameters>
                <asp:Parameter Name="Operator_ID" Type="String" />
                <asp:Parameter Name="Password" Type="String" />
                <asp:Parameter Name="AccessProfile" Type="String" />
                <asp:Parameter Name="Plant_ID" Type="String" />
            </InsertParameters>
        </asp:SqlDataSource>
        <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="XX-Large" Style="z-index: 100;
            left: 262px; position: absolute; top: 42px" Text="Edit User Accounts" Width="294px"></asp:Label>
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True"
            AutoGenerateDeleteButton="True" AutoGenerateEditButton="True" AutoGenerateSelectButton="True" CaptionAlign="Top"
            CellPadding="4" DataSourceID="SqlDataSource1" ShowFooter="True"
            Style="z-index: 101; left: 62px; position: absolute; top: 102px" PageSize="2" ForeColor="#333333" GridLines="None">
            <EmptyDataRowStyle BackColor="#FFC0C0" />
            <EmptyDataTemplate>
                &nbsp;
            </EmptyDataTemplate>
            <HeaderStyle BackColor="#5D7B9D" BorderColor="Cyan" BorderStyle="Solid" ForeColor="White" Font-Bold="True" />
            <AlternatingRowStyle BackColor="White" BorderColor="Maroon" ForeColor="#284775" />
            <PagerSettings FirstPageImageUrl="~/logo.jpg" PageButtonCount="2" PreviousPageImageUrl="~/logo.jpg" />
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#284775" BorderStyle="Inset" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <EditRowStyle BackColor="#999999" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        </asp:GridView>
        &nbsp;&nbsp;
        <asp:Button ID="txbAddUser" runat="server" OnClick="txbAddUser_Click" Style="z-index: 103;
            left: 127px; position: absolute; top: 273px" Text="Add User" />
    </form>
</body>
</html>
