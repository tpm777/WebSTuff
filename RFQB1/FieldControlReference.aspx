<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FieldControlReference.aspx.cs" Inherits="FieldControlReference" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">

              <asp:ScriptManager ID="ScriptManager1" runat="server">
            <Scripts>
                <asp:ScriptReference Name="jquery" Path="~/Scripts/json2.js" />
                <asp:ScriptReference Name="jquery" Path="~/Scripts/jquery-1.8.2.js" />
                <asp:ScriptReference Name="jquery.ui.combined" Path="~/Scripts/jquery-ui-1.9.2.js" />
            </Scripts>
        </asp:ScriptManager>
    <div>
   

    </div>

          <asp:FormView ID="FormView1" runat="server" DataKeyNames="ControlID" DataSourceID="SqlDataSource1" >
            <EditItemTemplate>
    
                Type:
                <asp:TextBox ID="TypeTextBox" runat="server" Text='<%# Bind("Type") %>' />
                <br />
                SubType:
                <asp:TextBox ID="SubTypeTextBox" runat="server" Text='<%# Bind("SubType") %>' />
                <br />
                FieldRef:
                <asp:TextBox ID="FieldRefTextBox" runat="server" Text='<%# Bind("FieldRef") %>' />
                <br />
                SortOrder:
                <asp:TextBox ID="SortOrderTextBox" runat="server" Text='<%# Bind("SortOrder") %>' />
                <br />
                Description:
                <asp:TextBox ID="DescriptionTextBox" runat="server" Text='<%# Bind("Description") %>' />
                <br />
                Active:
                <asp:TextBox ID="ActiveTextBox" runat="server" Text='<%# Bind("Active") %>' />
                <br />
                Required:
                <asp:TextBox ID="RequiredTextBox" runat="server" Text='<%# Bind("Required") %>' />
                <br />
                Validation:
                <asp:TextBox ID="ValidationTextBox" runat="server" Text='<%# Bind("Validation") %>' />
                <br />
                Datatype:
                <asp:TextBox ID="DatatypeTextBox" runat="server" Text='<%# Bind("Datatype") %>' />
                <br />
                UOM:
                <asp:TextBox ID="UOMTextBox" runat="server" Text='<%# Bind("UOM") %>' />
                <br />
                TagTable:
                <asp:TextBox ID="TagTableTextBox" runat="server" Text='<%# Bind("TagTable") %>' />
                <br />
                SecurityLevel:
                <asp:TextBox ID="SecurityLevelTextBox" runat="server" Text='<%# Bind("SecurityLevel") %>' />
                <br />
                InputPrompt:
                <asp:TextBox ID="InputPromptTextBox" runat="server" Text='<%# Bind("InputPrompt") %>' />
                <br />
                InputControlType:
                <asp:TextBox ID="InputControlTypeTextBox" runat="server" Text='<%# Bind("InputControlType") %>' />
                <br />
                InputControlName:
                <asp:TextBox ID="InputControlNameTextBox" runat="server" Text='<%# Bind("InputControlName") %>' />
                <br />
                LastChangeDate:
                <asp:TextBox ID="LastChangeDateTextBox" runat="server" Text='<%# Bind("LastChangeDate") %>' />
                <br />
                LastChangeUser:
                <asp:TextBox ID="LastChangeUserTextBox" runat="server" Text='<%# Bind("LastChangeUser") %>' />
                <br />
                <asp:LinkButton ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="Update" />
                &nbsp;<asp:LinkButton ID="UpdateCancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
            </EditItemTemplate>
            <InsertItemTemplate>
                Type:
                <asp:TextBox ID="TypeTextBox" runat="server" Text='<%# Bind("Type") %>' />
                <br />
                SubType:
                <asp:TextBox ID="SubTypeTextBox" runat="server" Text='<%# Bind("SubType") %>' />
                <br />
                FieldRef:
                <asp:TextBox ID="FieldRefTextBox" runat="server" Text='<%# Bind("FieldRef") %>' />
                <br />
                SortOrder:
                <asp:TextBox ID="SortOrderTextBox" runat="server" Text='<%# Bind("SortOrder") %>' />
                <br />
                Description:
                <asp:TextBox ID="DescriptionTextBox" runat="server" Text='<%# Bind("Description") %>' />
                <br />
                Active:
                <asp:TextBox ID="ActiveTextBox" runat="server" Text='<%# Bind("Active") %>' />
                <br />
                Required:
                <asp:TextBox ID="RequiredTextBox" runat="server" Text='<%# Bind("Required") %>' />
                <br />
                Validation:
                <asp:TextBox ID="ValidationTextBox" runat="server" Text='<%# Bind("Validation") %>' />
                <br />
                Datatype:
                <asp:TextBox ID="DatatypeTextBox" runat="server" Text='<%# Bind("Datatype") %>' />
                <br />
                UOM:
                <asp:TextBox ID="UOMTextBox" runat="server" Text='<%# Bind("UOM") %>' />
                <br />
                TagTable:
                <asp:TextBox ID="TagTableTextBox" runat="server" Text='<%# Bind("TagTable") %>' />
                <br />
                SecurityLevel:
                <asp:TextBox ID="SecurityLevelTextBox" runat="server" Text='<%# Bind("SecurityLevel") %>' />
                <br />
                InputPrompt:
                <asp:TextBox ID="InputPromptTextBox" runat="server" Text='<%# Bind("InputPrompt") %>' />
                <br />
                InputControlType:
                <asp:TextBox ID="InputControlTypeTextBox" runat="server" Text='<%# Bind("InputControlType") %>' />
                <br />
                InputControlName:
                <asp:TextBox ID="InputControlNameTextBox" runat="server" Text='<%# Bind("InputControlName") %>' />
                <br />
                LastChangeDate:
                <asp:TextBox ID="LastChangeDateTextBox" runat="server" Text='<%# Bind("LastChangeDate") %>' />
                <br />
                LastChangeUser:
                <asp:TextBox ID="LastChangeUserTextBox" runat="server" Text='<%# Bind("LastChangeUser") %>' />
                <br />
                <asp:LinkButton ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" Text="Insert" />
                &nbsp;<asp:LinkButton ID="InsertCancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
            </InsertItemTemplate>
            <ItemTemplate>
                ControlID:
                <asp:Label ID="ControlIDLabel" runat="server" Text='<%# Eval("ControlID") %>' />
                <br />
                Type:
                <asp:Label ID="TypeLabel" runat="server" Text='<%# Bind("Type") %>' />
                <br />
                SubType:
                <asp:Label ID="SubTypeLabel" runat="server" Text='<%# Bind("SubType") %>' />
                <br />
                FieldRef:
                <asp:Label ID="FieldRefLabel" runat="server" Text='<%# Bind("FieldRef") %>' />
                <br />
                SortOrder:
                <asp:Label ID="SortOrderLabel" runat="server" Text='<%# Bind("SortOrder") %>' />
                <br />
                Description:
                <asp:Label ID="DescriptionLabel" runat="server" Text='<%# Bind("Description") %>' />
                <br />
                Active:
                <asp:Label ID="ActiveLabel" runat="server" Text='<%# Bind("Active") %>' />
                <br />
                Required:
                <asp:Label ID="RequiredLabel" runat="server" Text='<%# Bind("Required") %>' />
                <br />
                Validation:
                <asp:Label ID="ValidationLabel" runat="server" Text='<%# Bind("Validation") %>' />
                <br />
                Datatype:
                <asp:Label ID="DatatypeLabel" runat="server" Text='<%# Bind("Datatype") %>' />
                <br />
                UOM:
                <asp:Label ID="UOMLabel" runat="server" Text='<%# Bind("UOM") %>' />
                <br />
                TagTable:
                <asp:Label ID="TagTableLabel" runat="server" Text='<%# Bind("TagTable") %>' />
                <br />
                SecurityLevel:
                <asp:Label ID="SecurityLevelLabel" runat="server" Text='<%# Bind("SecurityLevel") %>' />
                <br />
                InputPrompt:
                <asp:Label ID="InputPromptLabel" runat="server" Text='<%# Bind("InputPrompt") %>' />
                <br />
                InputControlType:
                <asp:Label ID="InputControlTypeLabel" runat="server" Text='<%# Bind("InputControlType") %>' />
                <br />
                InputControlName:
                <asp:Label ID="InputControlNameLabel" runat="server" Text='<%# Bind("InputControlName") %>' />
                <br />
                LastChangeDate:
                <asp:Label ID="LastChangeDateLabel" runat="server" Text='<%# Bind("LastChangeDate") %>' />
                <br />
                LastChangeUser:
                <asp:Label ID="LastChangeUserLabel" runat="server" Text='<%# Bind("LastChangeUser") %>' />
                <br />
                <asp:LinkButton ID="EditButton" runat="server" CausesValidation="False" CommandName="Edit" Text="Edit" />
                &nbsp;<asp:LinkButton ID="DeleteButton" runat="server" CausesValidation="False" CommandName="Delete" Text="Delete" />
                &nbsp;<asp:LinkButton ID="NewButton" runat="server" CausesValidation="False" CommandName="New" Text="New" />
            </ItemTemplate>
         </asp:FormView>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" DataKeyNames="ControlID">
            <Columns>
                <asp:BoundField DataField="ControlID" HeaderText="ControlID" InsertVisible="true" ReadOnly="True"  Visible="false"   SortExpression="ControlID" />
                <asp:BoundField DataField="Type" HeaderText="Type" SortExpression="Type" />
                <asp:BoundField DataField="SubType" HeaderText="SubType" SortExpression="SubType" />
                <asp:BoundField DataField="FieldRef" HeaderText="FieldRef" SortExpression="FieldRef" />
                <asp:BoundField DataField="SortOrder" HeaderText="SortOrder" SortExpression="SortOrder" />
                <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description" />
                <asp:BoundField DataField="Active" HeaderText="Active" SortExpression="Active" />
                <asp:BoundField DataField="Required" HeaderText="Required" SortExpression="Required" />
                <asp:BoundField DataField="Validation" HeaderText="Validation" SortExpression="Validation" />
                <asp:BoundField DataField="Datatype" HeaderText="Datatype" SortExpression="Datatype" />
                <asp:BoundField DataField="UOM" HeaderText="UOM" SortExpression="UOM" />
                <asp:BoundField DataField="TagTable" HeaderText="TagTable" SortExpression="TagTable" />
                <asp:BoundField DataField="SecurityLevel" HeaderText="SecurityLevel" SortExpression="SecurityLevel" />
                <asp:BoundField DataField="InputPrompt" HeaderText="InputPrompt" SortExpression="InputPrompt" />
                <asp:BoundField DataField="InputControlType" HeaderText="InputControlType" SortExpression="InputControlType" />
                <asp:BoundField DataField="InputControlName" HeaderText="InputControlName" SortExpression="InputControlName" />
                <asp:BoundField DataField="LastChangeDate" HeaderText="LastChangeDate" SortExpression="LastChangeDate" />
                <asp:BoundField DataField="LastChangeUser" HeaderText="LastChangeUser" SortExpression="LastChangeUser" />
                <asp:CommandField ButtonType="Button" ShowDeleteButton="True" ShowEditButton="True" />
            </Columns>
        </asp:GridView>

        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:RFQConnectionString %>" SelectCommand="SELECT * FROM [RFQFieldControlReference]" ConflictDetection="CompareAllValues" DeleteCommand="DELETE FROM [RFQFieldControlReference] WHERE [ControlID] = @original_ControlID AND [Type] = @original_Type AND [SubType] = @original_SubType AND [FieldRef] = @original_FieldRef AND [SortOrder] = @original_SortOrder AND [Description] = @original_Description AND [Active] = @original_Active AND [Required] = @original_Required AND (([Validation] = @original_Validation) OR ([Validation] IS NULL AND @original_Validation IS NULL)) AND (([Datatype] = @original_Datatype) OR ([Datatype] IS NULL AND @original_Datatype IS NULL)) AND (([UOM] = @original_UOM) OR ([UOM] IS NULL AND @original_UOM IS NULL)) AND (([TagTable] = @original_TagTable) OR ([TagTable] IS NULL AND @original_TagTable IS NULL)) AND (([SecurityLevel] = @original_SecurityLevel) OR ([SecurityLevel] IS NULL AND @original_SecurityLevel IS NULL)) AND [InputPrompt] = @original_InputPrompt AND [InputControlType] = @original_InputControlType AND [InputControlName] = @original_InputControlName AND (([LastChangeDate] = @original_LastChangeDate) OR ([LastChangeDate] IS NULL AND @original_LastChangeDate IS NULL)) AND (([LastChangeUser] = @original_LastChangeUser) OR ([LastChangeUser] IS NULL AND @original_LastChangeUser IS NULL))" InsertCommand="INSERT INTO [RFQFieldControlReference] ([Type], [SubType], [FieldRef], [SortOrder], [Description], [Active], [Required], [Validation], [Datatype], [UOM], [TagTable], [SecurityLevel], [InputPrompt], [InputControlType], [InputControlName], [LastChangeDate], [LastChangeUser]) VALUES (@Type, @SubType, @FieldRef, @SortOrder, @Description, @Active, @Required, @Validation, @Datatype, @UOM, @TagTable, @SecurityLevel, @InputPrompt, @InputControlType, @InputControlName, @LastChangeDate, @LastChangeUser)" OldValuesParameterFormatString="original_{0}" UpdateCommand="UPDATE [RFQFieldControlReference] SET [Type] = @Type, [SubType] = @SubType, [FieldRef] = @FieldRef, [SortOrder] = @SortOrder, [Description] = @Description, [Active] = @Active, [Required] = @Required, [Validation] = @Validation, [Datatype] = @Datatype, [UOM] = @UOM, [TagTable] = @TagTable, [SecurityLevel] = @SecurityLevel, [InputPrompt] = @InputPrompt, [InputControlType] = @InputControlType, [InputControlName] = @InputControlName, [LastChangeDate] = @LastChangeDate, [LastChangeUser] = @LastChangeUser WHERE [ControlID] = @original_ControlID AND [Type] = @original_Type AND [SubType] = @original_SubType AND [FieldRef] = @original_FieldRef AND [SortOrder] = @original_SortOrder AND [Description] = @original_Description AND [Active] = @original_Active AND [Required] = @original_Required AND (([Validation] = @original_Validation) OR ([Validation] IS NULL AND @original_Validation IS NULL)) AND (([Datatype] = @original_Datatype) OR ([Datatype] IS NULL AND @original_Datatype IS NULL)) AND (([UOM] = @original_UOM) OR ([UOM] IS NULL AND @original_UOM IS NULL)) AND (([TagTable] = @original_TagTable) OR ([TagTable] IS NULL AND @original_TagTable IS NULL)) AND (([SecurityLevel] = @original_SecurityLevel) OR ([SecurityLevel] IS NULL AND @original_SecurityLevel IS NULL)) AND [InputPrompt] = @original_InputPrompt AND [InputControlType] = @original_InputControlType AND [InputControlName] = @original_InputControlName AND (([LastChangeDate] = @original_LastChangeDate) OR ([LastChangeDate] IS NULL AND @original_LastChangeDate IS NULL)) AND (([LastChangeUser] = @original_LastChangeUser) OR ([LastChangeUser] IS NULL AND @original_LastChangeUser IS NULL))">
            <DeleteParameters>
                <asp:Parameter Name="original_ControlID" Type="Int32" />
                <asp:Parameter Name="original_Type" Type="String" />
                <asp:Parameter Name="original_SubType" Type="String" />
                <asp:Parameter Name="original_FieldRef" Type="Int32" />
                <asp:Parameter Name="original_SortOrder" Type="Int32" />
                <asp:Parameter Name="original_Description" Type="String" />
                <asp:Parameter Name="original_Active" Type="String" />
                <asp:Parameter Name="original_Required" Type="String" />
                <asp:Parameter Name="original_Validation" Type="String" />
                <asp:Parameter Name="original_Datatype" Type="String" />
                <asp:Parameter Name="original_UOM" Type="String" />
                <asp:Parameter Name="original_TagTable" Type="String" />
                <asp:Parameter Name="original_SecurityLevel" Type="String" />
                <asp:Parameter Name="original_InputPrompt" Type="String" />
                <asp:Parameter Name="original_InputControlType" Type="String" />
                <asp:Parameter Name="original_InputControlName" Type="String" />
                <asp:Parameter DbType="Date" Name="original_LastChangeDate" />
                <asp:Parameter Name="original_LastChangeUser" Type="String" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="Type" Type="String" />
                <asp:Parameter Name="SubType" Type="String" />
                <asp:Parameter Name="FieldRef" Type="Int32" />
                <asp:Parameter Name="SortOrder" Type="Int32" />
                <asp:Parameter Name="Description" Type="String" />
                <asp:Parameter Name="Active" Type="String" />
                <asp:Parameter Name="Required" Type="String" />
                <asp:Parameter Name="Validation" Type="String" />
                <asp:Parameter Name="Datatype" Type="String" />
                <asp:Parameter Name="UOM" Type="String" />
                <asp:Parameter Name="TagTable" Type="String" />
                <asp:Parameter Name="SecurityLevel" Type="String" />
                <asp:Parameter Name="InputPrompt" Type="String" />
                <asp:Parameter Name="InputControlType" Type="String" />
                <asp:Parameter Name="InputControlName" Type="String" />
                <asp:Parameter DbType="Date" Name="LastChangeDate" />
                <asp:Parameter Name="LastChangeUser" Type="String" />
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter Name="Type" Type="String" />
                <asp:Parameter Name="SubType" Type="String" />
                <asp:Parameter Name="FieldRef" Type="Int32" />
                <asp:Parameter Name="SortOrder" Type="Int32" />
                <asp:Parameter Name="Description" Type="String" />
                <asp:Parameter Name="Active" Type="String" />
                <asp:Parameter Name="Required" Type="String" />
                <asp:Parameter Name="Validation" Type="String" />
                <asp:Parameter Name="Datatype" Type="String" />
                <asp:Parameter Name="UOM" Type="String" />
                <asp:Parameter Name="TagTable" Type="String" />
                <asp:Parameter Name="SecurityLevel" Type="String" />
                <asp:Parameter Name="InputPrompt" Type="String" />
                <asp:Parameter Name="InputControlType" Type="String" />
                <asp:Parameter Name="InputControlName" Type="String" />
                <asp:Parameter DbType="Date" Name="LastChangeDate" />
                <asp:Parameter Name="LastChangeUser" Type="String" />
                <asp:Parameter Name="original_ControlID" Type="Int32" />
                <asp:Parameter Name="original_Type" Type="String" />
                <asp:Parameter Name="original_SubType" Type="String" />
                <asp:Parameter Name="original_FieldRef" Type="Int32" />
                <asp:Parameter Name="original_SortOrder" Type="Int32" />
                <asp:Parameter Name="original_Description" Type="String" />
                <asp:Parameter Name="original_Active" Type="String" />
                <asp:Parameter Name="original_Required" Type="String" />
                <asp:Parameter Name="original_Validation" Type="String" />
                <asp:Parameter Name="original_Datatype" Type="String" />
                <asp:Parameter Name="original_UOM" Type="String" />
                <asp:Parameter Name="original_TagTable" Type="String" />
                <asp:Parameter Name="original_SecurityLevel" Type="String" />
                <asp:Parameter Name="original_InputPrompt" Type="String" />
                <asp:Parameter Name="original_InputControlType" Type="String" />
                <asp:Parameter Name="original_InputControlName" Type="String" />
                <asp:Parameter DbType="Date" Name="original_LastChangeDate" />
                <asp:Parameter Name="original_LastChangeUser" Type="String" />
            </UpdateParameters>
        </asp:SqlDataSource>
 
    </form>
</body>
</html>
