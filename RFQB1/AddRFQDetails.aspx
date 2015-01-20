<%@ Page ValidateRequest="false"  Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AddRFQDetails.aspx.cs" Inherits="AddRFQDetails" %>
<%@ Register Assembly="obout_ComboBox" Namespace="Obout.ComboBox" TagPrefix="cc1" %>
<%@ Register TagPrefix="obout" Namespace="Obout.Interface" Assembly="obout_Interface" %>
<%@ Register Assembly="FreeTextBox" Namespace="FreeTextBoxControls" TagPrefix="FTB" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script type="text/javascript" >
    //function setStyle(x) {

    //    document.getElementById(x.id).style.backgroundColor = "yellow"
    //}

    //function ResetStyle(x) {

    //    document.getElementById(x.id).style.backgroundColor = "white"

        //}

    $(document).ready(function () {
        $('[id^=ContentPlaceHolder1_txbInput]').keydown(function (event) {
            if (event.keyCode == 13) {
                event.preventDefault();
                return false;
            }
        });
    });

  
  

      


</script>
<%--    <script type="text/javascript" src="http://code.jquery.com/jquery-1.7.2.js"></script>--%>
       <script type="text/javascript" src="Scripts/jquery-1.8.2.js"></script>

   <style type="text/css">
        .item
        {
            position: relative;
            width: 100%;
        }
        
        .label
        {
            position: absolute;
            top: 0px;
            left: 25px;
        }
    </style>
</asp:Content>
<asp:Content  ID="Content222" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
      
    
    
    
    
          <div style="width:inherit; margin-left:40%;margin-right:40%;margin-top:-1%;align-content:center;">
            <asp:Label ID="lblRFQType" runat="server" Font-Bold="True" Font-Size="X-Large" ></asp:Label> 
            <asp:Label ID="lblRFQSubType" runat="server" Font-Bold="True" Font-Size="X-Large" ></asp:Label> 

        </div>
    <div style="width:inherit;margin-left:40%;margin-right:40%;align-content:center">
       
        <asp:Label ID="lblError" runat="server" Text="*" ForeColor="#CC3300"></asp:Label>
         <asp:Label ID="Label1" runat="server" Text=" = Required" Font-Bold="True" Font-Size="Large" ></asp:Label>
       
    </div>
    <div>
      
        <asp:Panel  ID="pnlDynamicInputs" runat="server" Height="400px" style="width:inherit;margin-left:0%;margin-right:10%;overflow-y:scroll">
        <asp:Table ID="Table1" runat="server" style="width:80%;margin-left:10%;margin-right:10%" >

        </asp:Table>
           </asp:Panel> 
 <%--       <asp:Button ID="btnTest" runat="server" Text="Test" OnClick="btnTest_Click" />
        <asp:Button ID="btnViewTableContents" runat="server" OnClick="btnViewTableContents_Click" Text="View Table Values" />--%>
        <div style="position:relative;inherit;margin-left:40%;margin-right:30%"">
            <br />
            <br />
        <asp:Button ID="btnSaveRFQDetail" runat="server" OnClick="btnSaveRFQDetail_Click" Text="Save" class="button" />
        <asp:Button ID="btnCancel"  runat="server" Text="Cancel" class="button" OnClientClick='return confirm("Continue to Cancel?");' OnClick="btnCancel_Click" />

         </div>
    </div>
<script type="text/javascript">
    window.onload = function () {

        Obout.Interface.OboutCore.getLeft = function (element) {
            return $(element).offset().left;
        }

        Obout.Interface.OboutCore.getTop = function (element) {
            return $(element).offset().top;
        }
    }
 </script>

</asp:Content>

