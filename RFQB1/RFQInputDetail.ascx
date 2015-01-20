<%@ Control Language="C#" AutoEventWireup="true" CodeFile="RFQInputDetail.ascx.cs" Inherits="RFQInputDetail" %>
<%@ Register Assembly="obout_ComboBox" Namespace="Obout.ComboBox" TagPrefix="cc1" %>
<%@ Register Assembly="FreeTextBox" Namespace="FreeTextBoxControls" TagPrefix="FTB" %>
    <style type="text/css">
 
        .removeTableBorders
        {
            border: none;
            outline: none;
        }
        .removeTableBordersRightAlign
        {
            border: none;
            outline: none;
            text-align: right;
            width:150px;

   
        }

 </style>
<script type="text/javascript" >
    function setStyle(x) {
      
        document.getElementById(x.id).style.backgroundColor = "yellow"
    }

    function ResetStyle(x) {
 
        document.getElementById(x.id).style.backgroundColor = "white"
      
    }
    $(document).ready(function () {
        $('[id^=RFQInputDetails_txbInput]').keydown(function (event) {
            if (event.keyCode == 13) {
                event.preventDefault();
                return false;
            }
        });
    });
</script>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<body>
  <%--  <form id="form2" runat="server" >--%>
        <div>
            <asp:Label ID="lblRFQType" runat="server" ></asp:Label> 
            <asp:Label ID="lblRFQSubType" runat="server" ></asp:Label> 

        </div>
    <div>
        <br />
        <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
        <br />
    </div>
    <div>
        <br />
        <asp:Panel ID="pnlDynamicInputs" runat="server" ScrollBars="Vertical" Height="300px" >
        <asp:Table ID="Table1" runat="server">

        </asp:Table>
           </asp:Panel> 
 <%--       <asp:Button ID="btnTest" runat="server" Text="Test" OnClick="btnTest_Click" />
        <asp:Button ID="btnViewTableContents" runat="server" OnClick="btnViewTableContents_Click" Text="View Table Values" />--%>
            <br />
            <br />
            <br />
            <br />
            <br />

        <asp:Button ID="btnSaveRFQDetail" runat="server" OnClick="btnSaveRFQDetail_Click" Text="Save" Font-Bold="True" Font-Size="X-Large" />
         
    </div>
<%--    </form>
--%>
    </body>
</html>
<asp:sqldatasource ID="Sqldatasource1" runat="server" ConnectionString="<%$ ConnectionStrings:RFQConnectionString %>" SelectCommand="SELECT * FROM [RFQFieldControlReference]"></asp:sqldatasource>

