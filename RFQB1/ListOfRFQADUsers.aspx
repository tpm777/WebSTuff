<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ListOfRFQADUsers.aspx.cs" Inherits="ListOfRFQADUsers" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
     <table style="position:relative;margin-left:20%;margin-right:20%;width:100%">
         <tr>
             <td>
                 RFQ NA Sales
             </td>
             <td>
                 RFQ NA Quote Team
             </td>

         </tr>
         <tr>
             <td>
                <asp:ListBox ID="lstRFQSales" runat="server" Height="141px" Width="149px"></asp:ListBox>

             </td>
             <td>
               <asp:ListBox ID="lstRFQQuoteTeam" runat="server" Height="130px" Width="129px"></asp:ListBox>
             </td>
         </tr>
      <tr>
             <td>
                 RFQ EU Sales
             </td>
             <td>
                 RFQ EU Quote Team
             </td>

         </tr>
        <tr>
         <td>
                <asp:ListBox ID="lstRFQEUSales" runat="server" Height="188px" Width="147px"></asp:ListBox>

         </td>
            <td>
                  <asp:ListBox ID="lstRFQEUQuoteTeam" runat="server" Height="176px" Width="130px"></asp:ListBox>

            </td>
            </tr>
     </table>   

    </div>

    </form>

</body>
</html>
