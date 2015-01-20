<%@ Page Language="C#" AutoEventWireup="true" CodeFile="OBAxles.aspx.cs" Inherits="OBAxles" %>

<%@ Register Assembly="MetaBuilders.WebControls.ComboBox, Version=1.1.5000.0, Culture=neutral, PublicKeyToken=8f1b87f9edb00944"
    Namespace="MetaBuilders.WebControls" TagPrefix="mbcbb" %>



<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Untitled Page</title>
<style type="text/css">
html {
overflow-x:hidden;
overflow-y:hidden;
}
</style>    
<script language="javascript" type="text/javascript">
<!--

function DIV1_onclick() {

}

// -->
</script>
</head>
<body bgcolor="#99ffff">
    <form id="form1" runat="server">
    <div>
        <div style="z-index: 103; left: 4px; width: 320px; position: absolute; top: 4px;
            height: 217px" id="DIV1" language="javascript" onclick="return DIV1_onclick()">
            <asp:Label ID="lbOpertaorID" runat="server" Style="z-index: 100; left: 197px; position: absolute;
                top: 190px" Text="Operator ID:" Width="60px" Font-Size="X-Small"></asp:Label>
            <asp:Label ID="lblMaxQty" runat="server" Font-Size="Small" Qty=" " Style="z-index: 101;
                left: 236px; position: absolute; top: 69px" Text="Max" Width="60px"></asp:Label>
            <asp:Label ID="lblQtyPosted" runat="server" Font-Size="Small" Posted=" " Style="z-index: 102;
                left: 237px; position: absolute; top: 100px" Text="Qty" Width="63px"></asp:Label>
            &nbsp; &nbsp; &nbsp;
            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
            <asp:Label ID="lblTitle" runat="server" Style="z-index: 103; left: 101px; position: absolute;
                top: 5px" Text="Process Outbound Axle" Width="165px"></asp:Label>
            <asp:Button ID="btnSummit" runat="server" Style="z-index: 104; left: 108px; position: absolute;
                top: 136px" Text="OK" Width="83px" OnClick="btnSummit_Click" BorderStyle="Ridge" />
            &nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp;
            <asp:Label ID="lblOperatorIDName" runat="server" Height="8px" Style="z-index: 105;
                left: 269px; position: absolute; top: 191px" Text="OperatorID" Width="45px" Font-Size="X-Small"></asp:Label>
            &nbsp;
            <asp:Label ID="lblTagID" runat="server" Height="8px" Style="z-index: 106; left: 9px;
                position: absolute; top: 97px" Text="Tag ID:" Width="50px"></asp:Label>
            <asp:Label ID="lblCustomerID" runat="server" Height="8px" Style="z-index: 107; left: 8px;
                position: absolute; top: 32px" Text="Customer" Width="62px"></asp:Label>
            &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
            <asp:TextBox ID="txbTagID" runat="server" Style="z-index: 108; left: 87px; position: absolute;
                top: 97px" Width="138px" AutoPostBack="True" OnTextChanged="txbTagID_TextChanged"></asp:TextBox>
            &nbsp;
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txbTagID"
                ErrorMessage="*" Style="z-index: 109; left: 64px; position: absolute; top: 98px"
                Width="16px"></asp:RequiredFieldValidator>
            &nbsp;
            <asp:Label ID="lblLoadID" runat="server" Height="8px" Style="z-index: 110; left: 7px;
                position: absolute; top: 68px" Text="LoadID:" Width="67px"></asp:Label>
            &nbsp;
            <asp:HyperLink ID="HyperLink2" runat="server" Font-Size="Small" NavigateUrl="~/Login.aspx"
                Style="z-index: 111; left: 8px; position: absolute; top: 189px">Logoff/Change Input Screen</asp:HyperLink>
            &nbsp; &nbsp;&nbsp;&nbsp;
        <asp:DropDownList ID="cmbOBLoadIds" runat="server" Style="z-index: 112; left: 88px;
            position: absolute; top: 68px" Width="110px" DataSourceID="SqlDataSource2" DataTextField="OBLoadID" DataValueField="OBLoadID" AutoPostBack="True">
        </asp:DropDownList>
        <mbcbb:ComboBox id="cmbCustomerID" runat="server" AutoPostBack="True" DataSourceID="SqlDataSource1"
            DataTextField="Customer_Name" DataValueField="Customer_Name" style="z-index: 114;
            left: 89px; position: absolute; top: 32px" Width="139px" OnSelectedIndexChanged="cmbCustomerID_SelectedIndexChanged">
            <asp:ListItem>Databound</asp:ListItem>
        </mbcbb:ComboBox>
        </div>
        &nbsp;<br />
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
        <br />
        <br />
        <br />
        <br />
        <br />
        &nbsp;
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:RFDBConnectionString %>"
            SelectCommand="SELECT [Customer Name] AS Customer_Name FROM [Customers]"></asp:SqlDataSource><asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:RFDBConnectionString %>"
            SelectCommand="SELECT [OBLoadID] FROM [OBLoadID] WHERE ([Customer ID] = @Customer_ID)">
                <SelectParameters>
                    <asp:ControlParameter ControlID="cmbCustomerID" Name="Customer_ID" PropertyName="SelectedValue"
                        Type="String" />
                </SelectParameters>
            </asp:SqlDataSource>
        &nbsp; &nbsp;&nbsp;
    
    </div>
    </form>
</body>
</html>

