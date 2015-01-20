<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MiniLoadEditInbount.aspx.cs" Inherits="Admin_MiniLoadEditInbount" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body bgcolor="#99ff66">
    <form id="form1" runat="server">
    <div>
        <asp:Button ID="btnFinish" runat="server" PostBackUrl="~/ReceiveAxle.aspx" Style="z-index: 100;
            left: 97px; position: absolute; top: 235px" Text="Finish" Width="61px" />
        &nbsp;
        <br />
        <br />
        <br />
        <br />
        <br />
        <asp:DetailsView ID="DetailsView1" runat="server" AutoGenerateRows="False" DataKeyNames="Load_ID"
            DataSourceID="SqlDataSource1" Height="141px" Style="z-index: 107; left: 43px;
            position: absolute; top: 84px" Width="167px">
            <Fields>
                <asp:BoundField DataField="Load_ID" HeaderText="Load_ID" ReadOnly="True" SortExpression="Load_ID" />
                <asp:BoundField DataField="Customer_ID" HeaderText="Customer_ID" SortExpression="Customer_ID" />
                <asp:BoundField DataField="Qty" HeaderText="Qty" SortExpression="Qty" />
                <asp:CommandField ShowEditButton="True" />
            </Fields>
        </asp:DetailsView>
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
        <asp:SqlDataSource ID="SqlDataSource1" runat="server"
            ConnectionString="<%$ ConnectionStrings:RFDBConnectionString %>"
            OldValuesParameterFormatString="original_{0}" SelectCommand="SELECT [Load ID] AS Load_ID, [Customer ID] AS Customer_ID, [Qty] FROM [LoadID] WHERE ([Load ID] = @Load_ID)" ConflictDetection="CompareAllValues" DeleteCommand="DELETE FROM [LoadID] WHERE [Load ID] = @original_Load_ID AND [Customer ID] = @original_Customer_ID AND [Qty] = @original_Qty" InsertCommand="INSERT INTO [LoadID] ([Load ID], [Customer ID], [Qty]) VALUES (@Load_ID, @Customer_ID, @Qty)" UpdateCommand="UPDATE [LoadID] SET [Customer ID] = @Customer_ID, [Qty] = @Qty WHERE [Load ID] = @original_Load_ID AND [Customer ID] = @original_Customer_ID AND [Qty] = @original_Qty">
            <DeleteParameters>
                <asp:Parameter Name="original_Load_ID" Type="String" />
                <asp:Parameter Name="original_Customer_ID" Type="String" />
                <asp:Parameter Name="original_Qty" Type="Int32" />
            </DeleteParameters>
            <UpdateParameters>
                <asp:Parameter Name="Customer_ID" Type="String" />
                <asp:Parameter Name="Qty" Type="Int32" />
                <asp:Parameter Name="original_Load_ID" Type="String" />
                <asp:Parameter Name="original_Customer_ID" Type="String" />
                <asp:Parameter Name="original_Qty" Type="Int32" />
            </UpdateParameters>
            <SelectParameters>
                <asp:ControlParameter ControlID="txbLoadID" Name="Load_ID" PropertyName="Text" Type="String" />
            </SelectParameters>
            <InsertParameters>
                <asp:Parameter Name="Load_ID" Type="String" />
                <asp:Parameter Name="Customer_ID" Type="String" />
                <asp:Parameter Name="Qty" Type="Int32" />
            </InsertParameters>
        </asp:SqlDataSource>
    
    </div>
        <asp:Label ID="Label1" runat="server" Style="z-index: 102; left: 17px; position: absolute;
            top: 18px" Text="Customer:" Width="76px"></asp:Label>
        <asp:Label ID="lblLoadID" runat="server" Style="z-index: 103; left: 14px; position: absolute;
            top: 47px" Text="Load ID:" Width="76px"></asp:Label>
        <asp:TextBox ID="txbCustomer" runat="server" Enabled="False" Style="z-index: 104;
            left: 102px; position: absolute; top: 18px"></asp:TextBox>
        <asp:TextBox ID="txbLoadID" runat="server" AutoPostBack="True"
            OnTextChanged="txbLoadID_TextChanged" Style="z-index: 105; left: 102px; position: absolute;
            top: 45px" Enabled="False" Width="147px">13100004</asp:TextBox>
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    </form>
</body>
</html>
