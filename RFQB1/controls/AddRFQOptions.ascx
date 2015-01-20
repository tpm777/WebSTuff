<%@ Control Language="C#" AutoEventWireup="true" CodeFile="AddRFQOptions.ascx.cs" Inherits="AddRFQOptions" %>
 <link rel="stylesheet" href="table.css" type="text/css"/>	
<style type="text/css">
        body {
                margin: 0;
                padding: 0 10px 0 10px;
                height: 100%;
                overflow-y: auto;
        }
    .content {
                margin: 0px 0px 0px 140px;
                display: block;
                padding: 10px;
                position:relative;
        }

        .content2 {
                margin: 20px 0px 0px 30px;
                display: block;
                padding: 10px;
                position:relative;

        }

        .header {
                display: block;
                top: 0px;
                left: 0px;
                width: 100%;
                height: 50px;
                position: fixed;
                background-color: #ffffff;
                border: 1px solid #888;
        }

        .navigation {
                display: block;
                top: 0px;
                left: 0px;
                width: 142px;
                height: 100%;
                position: fixed;
                border: 0px solid #888;
        }


    .auto-style1
    {
        width: 100%;
        border: 5px solid #008080;
    }
</style>

<link rel="stylesheet" href="table.css" type="text/css"/>	
<link rel="stylesheet" href="../StyleSheet.css" type="text/css" />


<div id="navigation" class="navigation">

            <table class="auto-style1">
                <tr>
                    <td>
            <asp:Button ID="btnAdd" runat="server" Text="Add" Width="125px" OnClick="btnAdd_Click" Height="24px" />

                    </td>
                </tr>
                <tr>
                    <td>
            <asp:Button ID="btnSave" runat="server" Text="Save" Width="125px" OnClick="btnSave_Click" Height="24px" />

                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>
            <asp:Button ID="btnReset" runat="server" Text="Reset" Width="125px" OnClick="btnReset_Click" Height="24px" />

                    </td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>
            <asp:Button ID="btnUpload" runat="server" Text="Upload Docs" Width="125px" OnClick="btnUpload_Click" Height="24px" />

                    </td>
                </tr>
            </table>

</div>
<div id="content" class="content">
<table >
    <tr>
        <td >
    
        </td>
        <td>
            <asp:RadioButtonList ID="rbList1" RepeatDirection="Horizontal" runat="server"  AutoPostBack="true" OnSelectedIndexChanged="rbList1_SelectedIndexChanged" >
                <asp:ListItem>Labels</asp:ListItem>
                <asp:ListItem>Equipment</asp:ListItem>
                <asp:ListItem>Service</asp:ListItem>
            </asp:RadioButtonList>
        </td>
    </tr>
    <tr>
        <td>

        </td>
        <td>
            <asp:RadioButtonList ID="rbList2" RepeatDirection="Horizontal" runat="server"  Visible="false" AutoPostBack="True" OnSelectedIndexChanged="rbList2_SelectedIndexChanged" >
                <asp:ListItem>Labels</asp:ListItem>
                <asp:ListItem>Equipment</asp:ListItem>
                <asp:ListItem>Service</asp:ListItem>
            </asp:RadioButtonList>

        </td> 

    </tr>
</table>

<asp:Panel ID="pnlAddOption" runat="server">

    		<div class="CSSMainHeader" style="width:700px;height:150px;">
			<table >
				<tr> 
					<td>
						Required
					</td>
					<td >
						Required Value
					</td>
					<td>
						Optional Name
					</td>
					<td >
						Optional Value
					</td>

				</tr>
				<tr>
					<td >
						&nbsp;<asp:Label ID="lblRequiredR1" runat="server" Text="Label"></asp:Label>
					</td>
					<td>
						&nbsp;<asp:TextBox ID="txbRequired1" runat="server"></asp:TextBox>
					</td>
                    <td>

                        <asp:Label ID="lblOptionalR1" runat="server" Text="Label"></asp:Label>

                    </td>
                    <td>

                        <asp:TextBox ID="txbOptional1" runat="server"></asp:TextBox>

                    </td>
				</tr>
				<tr>
					<td >
						<asp:Label ID="lblRequiredR2" runat="server" Text="Label"></asp:Label>
                    </td>
					<td >
						<asp:TextBox ID="txbRequired2" runat="server"></asp:TextBox>
					</td>
                                    <td>

                                        <asp:Label ID="lblOptionalR2" runat="server" Text="Label"></asp:Label>

                         </td>
                    <td>

                        <asp:TextBox ID="txbOptional2" runat="server"></asp:TextBox>

                    </td>
				</tr>
				<tr>
					<td >
						<asp:Label ID="lblRequiredR3" runat="server" Text="Label"></asp:Label>
					</td>
					<td>
						<asp:TextBox ID="txbRequired3" runat="server"></asp:TextBox>
					</td>
                    <td>

                        <asp:Label ID="lblOptionalR3" runat="server" Text="Label"></asp:Label>

                    </td>
                    <td>

                        <asp:TextBox ID="txbOptional3" runat="server"></asp:TextBox>

                    </td>
				</tr>
			</table>
		</div>


</asp:Panel>

<asp:Panel ID="pnlSalesOptions" runat="server">
    <div style="align-content:center ">
        <br />
        <br />
        <asp:Label ID="lblSalesTitle" Text="Sale Person Options" runat="server"  />
 
    </div>
    		<div class="CSSMainHeader" style="width:700px;height:150px;">
			<table >
				<tr> 
					<td>
						Required
					</td>
					<td >
						Required Value
					</td>
					<td>
						Optional Name
					</td>
					<td >
						Optional Value
					</td>

				</tr>
				<tr>
					<td >
						&nbsp;<asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
					</td>
					<td>
						&nbsp;<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
					</td>
                    <td>

                        <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>

                    </td>
                    <td>

                        <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>

                    </td>
				</tr>
				<tr>
					<td >
						<asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
                    </td>
					<td >
						<asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
					</td>
                                    <td>

                                        <asp:Label ID="Label4" runat="server" Text="Label"></asp:Label>

                         </td>
                    <td>

                        <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>

                    </td>
				</tr>
				<tr>
					<td >
						<asp:Label ID="Label5" runat="server" Text="Label"></asp:Label>
					</td>
					<td>
						<asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
					</td>
                    <td>

                        <asp:Label ID="Label6" runat="server" Text="Label"></asp:Label>

                    </td>
                    <td>

                        <asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>

                    </td>
				</tr>
			</table>
		</div>


</asp:Panel>

    <div id="content2" class="content2">


    <asp:Panel ID="pnlSummaryGrid" runat="server">
        <asp:GridView ID="grdRequiredValues" runat="server" BackColor="White" BorderColor="#336666" BorderStyle="Double" BorderWidth="3px" CellPadding="4" GridLines="Horizontal">
            <FooterStyle BackColor="White" ForeColor="#333333" />
            <HeaderStyle BackColor="#336666" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#336666" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="White" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F7F7F7" />
            <SortedAscendingHeaderStyle BackColor="#487575" />
            <SortedDescendingCellStyle BackColor="#E5E5E5" />
            <SortedDescendingHeaderStyle BackColor="#275353" />
        </asp:GridView>
    </asp:Panel>
    <asp:Panel ID="Panel2" runat="server">
        <asp:GridView ID="grdOptionalValue" runat="server">
        </asp:GridView>
    </asp:Panel>
</div>
</div>