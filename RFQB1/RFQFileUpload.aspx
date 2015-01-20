<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RFQFileUpload.aspx.cs" EnableEventValidation="false"
    Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="CSS/ThemeBlue.css" rel="Stylesheet" type="text/css" />

      <style type="text/css">

   .button {
  font-family: arial;
  font-weight: bold;
  color: #0C0C0C !important;
  font-size: 17px;
  text-shadow: 1px 1px 0px #DEDDDC;
  box-shadow: 1px 1px 3px #BEE2F9;
  padding: 10px 25px;
  -moz-border-radius: 10px;
  -webkit-border-radius: 10px;
  border-radius: 10px;
  border: 2px solid #A3A3A3;
  background: #C8EEAC;
  background: linear-gradient(top,  #E0E0E0,  #848383);
  background: -ms-linear-gradient(top,  #E0E0E0,  #848383);
  background: -webkit-gradient(linear, left top, left bottom, from(#E0E0E0), to(#848383));
  background: -moz-linear-gradient(top,  #E0E0E0,  #848383);
}


.button:hover {
  color: #14396A !important;
  background: #468CCF;
  background: linear-gradient(top,  #468CCF,  #63B8EE);
  background: -ms-linear-gradient(top,  #468CCF,  #63B8EE);
  background: -webkit-gradient(linear, left top, left bottom, from(#468CCF), to(#63B8EE));
  background: -moz-linear-gradient(top,  #468CCF,  #63B8EE);
}
      
          </style>
    <script type="text/javascript">
        //Enumeration for messages status
        MessageStatus = {
            Success: 1,
            Information: 2,
            Warning: 3,
            Error: 4
        }

        //Enumeration for messages status class
        MessageCSS = {
            Success: "Success",
            Information: "Information",
            Warning: "Warning",
            Error: "Error"
        }

        //Global variables
        var intervalID = 0;
        var subintervalID = 0;
        var fileUpload;
        var form;
        var previousClass = '';

        //Attach to the upload click event and grab a reference to the progress bar
        function pageLoad() {
            $addHandler($get('upload'), 'click', onUploadClick);
        }

        //Register the form
        function register(form, fileUpload) {
            this.form = form;
            this.fileUpload = fileUpload;
        }

//Start upload process
function onUploadClick() {
if (fileUpload.value.length > 0) {
    var filename = fileExists();
    if (filename == '') {
        //Update the message
        updateMessage(MessageStatus.Information, 'Initializing upload ...', '', '0 of 0 Bytes');
        //Submit the form containing the fileupload control
        form.submit();
        //Set transparancy 20% to the frame and upload button
        Sys.UI.DomElement.addCssClass($get('dvUploader'), 'StartUpload');
        //Initialize progressbar
        setProgress(0);
        //Start polling to check on the progress ...
        startProgress();
        intervalID = window.setInterval(function() {
        PageMethods.GetUploadStatus(function(result) {
            if (result) {
                setProgress(result.percentComplete);
                //Upadte the message every 500 milisecond
                updateMessage(MessageStatus.Information, result.message, result.fileName, result.downloadBytes);
                if (result == 100) {
                    //clear the interval
                    window.clearInterval(intervalID);
                    clearTimeout(subintervalID);
                }
            }
        });
        }, 500);
    }
    else
        onComplete(MessageStatus.Error, "File name '<b>" + filename + "'</b> already exists in the list.", '', '0 of 0 Bytes');
}
else
    onComplete(MessageStatus.Warning, 'You need to select a file.', '', '0 of 0 Bytes');
}

        //Stop progrss when file was successfully uploaded
        function onComplete(type, msg, filename, downloadBytes) {
            window.clearInterval(intervalID);
            clearTimeout(subintervalID);
            updateMessage(type, msg, filename, downloadBytes);
            if (type == MessageStatus.Success) setProgress(100);
            //Set transparancy 100% to the frame and upload button
            Sys.UI.DomElement.removeCssClass($get('dvUploader'), 'StartUpload');
            //Refresh uploaded files list.
            refreshFileList('<%=hdRefereshGrid.ClientID %>');
        }

        //Update message based on status
        function updateMessage(type, message, filename, downloadBytes) {
            var _className = MessageCSS.Error;
            var _messageTemplate = $get('tblMessage');
            var _icon = $get('dvIcon');
            _icon.innerHTML = message;
            $get('dvDownload').innerHTML = downloadBytes;
            $get('dvFileName').innerHTML = filename;
            switch (type) {
                case MessageStatus.Success:
                    _className = MessageCSS.Success;
                    break;
                case MessageStatus.Information:
                    _className = MessageCSS.Information;
                    break;
                case MessageStatus.Warning:
                    _className = MessageCSS.Warning;
                    break;
                default:
                    _className = MessageCSS.Error;
                    break;
            }
            _icon.className = '';
            _messageTemplate.className = '';
            Sys.UI.DomElement.addCssClass(_icon, _className);
            Sys.UI.DomElement.addCssClass(_messageTemplate, _className);
        }

        //Refresh uploaded file list when new file was uploaded successfully
        function refreshFileList(hiddenFieldID) {
            var hiddenField = $get(hiddenFieldID);
            if (hiddenField) {
                hiddenField.value = (new Date()).getTime();
                __doPostBack(hiddenFieldID, '');
            }
        }

        //Set progressbar based on completion value
        function setProgress(completed) {
            $get('dvProgressPrcent').innerHTML = completed + '%';
            $get('dvProgress').style.width = completed + '%';
        }

        //Display mouse over and out effect of file upload list
        function eventMouseOver(_this) {
            previousClass = _this.className;
            _this.className = 'GridHoverRow';
        }
        function eventMouseOut(_this) {
            _this.className = previousClass;
        }

        //This will call every 200 milisecnd and update the progress based on value
        function startProgress() {
            var increase = $get('dvProgressPrcent').innerHTML.replace('%', '');
            increase = Number(increase) + 1;
            if (increase <= 100) {
                setProgress(increase);
                subintervalID = setTimeout("startProgress()", 200);
            }
            else {
                window.clearInterval(subintervalID);
                clearTimeout(subintervalID);
            }
        }

        //This will check whether will was already exist on the server, 
        //if file was already exists it will return file name else empty string.
        function fileExists() {
            var selectedFile = fileUpload.value.split('\\');
            var file = $get('gvNewFiles').getElementsByTagName('a');
            for (var f = 0; f < file.length; f++) {
                if (file[f].innerHTML == selectedFile[selectedFile.length - 1]) {
                    return file[f].innerHTML;
                }
            }
            return '';
        }
    </script>

</head>
 <body style="margin-left:30%;margin-right:30%;">
    <form id="form1" runat="server">
    <div id="header" class="content">

            <div>
                <table>
                    <tr>
                        <td class="noborders">
                            <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/horiz_ComputypeLogoColor_240_62.jpg" Height="71px" Width="282px" />
                        </td>
                        <td class="noborders">
                            <asp:Label ID="lblTtitle" runat="server" Text="Request For Quote" Font-Size="XX-Large" Font-Bold="True"></asp:Label>
                        </td> 
                    </tr>
                </table>

            </div>
        </div>
    <asp:ScriptManager ID="scriptManager" runat="server" EnablePageMethods="true" />
    <table width="60%" cellpadding="5" cellspacing="5" border="0" style="margin-left:20%;margin-right:20%;margin-top:10%;">
        <tr>
            <td>
                <table class="ContainerWrapper" border="0" cellpadding="2" cellspacing="0" width="100%">
                    <tr class="ContainerHeader">
                        <td>
                           <asp:Label ID="lblTitle" runat="server" ></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="ContainerMargin">
                            <table class="Container" cellpadding="0" cellspacing="4" width="100%" border="0">
                                <tr>
                                    <td>
                                        <div id="dvUploader">
                                            <table cellpadding="0" cellspacing="0" width="100%">
                                                <tr>
                                                    <td style="width: 50%">
                                                        <iframe id="uploadFrame" frameborder="0" height="25" width="400" scrolling="no" src="UploadEngine.aspx">
                                                        </iframe>
                                                    </td>
                                                    <td>
                                                        <input id="upload" type="button" style="margin-left:25px;position:relative; width:65px" value="Upload" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <table id="tblMessage" cellpadding="4" cellspacing="4" class="Information" border="0">
                                            <tr>
                                                <td style="text-align: left" colspan="2">
                                                    <div id="dvIcon" class="Information">
                                                        Please select a file to upload
                                                    </div>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <table cellpadding="0" cellspacing="2" width="100%" border="0">
                                            <tr>
                                                <td style="width: 100px; text-align: left">
                                                    Progress
                                                </td>
                                                <td style="width: auto">
                                                    <table cellpadding="0" cellspacing="0" width="100%">
                                                        <tr>
                                                            <td align="left">
                                                                <div id="dvProgressContainer">
                                                                    <div id="dvProgress">
                                                                    </div>
                                                                </div>
                                                            </td>
                                                            <td>
                                                                <div id="dvProgressPrcent">
                                                                    0%
                                                                </div>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: left">
                                                    Download Bytes
                                                </td>
                                                <td align="right">
                                                    <div id="dvDownload">
                                                        Bytes
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: left">
                                                    File Name
                                                </td>
                                                <td align="right">
                                                    <div id="dvFileName">
                                                        FileName
                                                    </div>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                <table class="ContainerWrapper" border="0" cellpadding="2" cellspacing="0" width="100%">
                    <tr class="ContainerHeader">
                        <td>
                            List of uploaded files
                        </td>
                    </tr>
                    <tr>
                        <td class="ContainerMargin">
                            <asp:UpdatePanel runat="server" ID="upFiles" UpdateMode="Conditional">
                                <ContentTemplate>
                                    <asp:HiddenField ID="hdRefereshGrid" runat="server" OnValueChanged="hdRefereshGrid_ValueChanged" />
                                    <table class="Container" cellpadding="0" cellspacing="0" width="100%" border="0">
                                        <tr class="GridHeader">
                                            <td class="Separator" style="width: 8%;" align="right">
                                            </td>
                                            <td class="Separator" style="width: 5%"  align="center" >
                                                Directory
                                            </td>
                                            <td class="Separator" style="width: 89%">
                                                File
                                            </td>
                                            <td class="Separator" style="width: 18%" align="right">
                                                Size
                                            </td>
                                            <td style="width: 4%">
                                            </td>
                                            <td style="width: 4%">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="5">
                                                <div style="height: 140px; overflow: auto;">
                                                    <asp:GridView DataKeyNames="Name" ID="gvNewFiles" AllowPaging="false" runat="server"
                                                        PagerStyle-HorizontalAlign="Center" AutoGenerateColumns="false" Width="100%"
                                                        CellPadding="0" BorderWidth="0" GridLines="None" ShowHeader="false" OnRowCommand="gvNewFiles_RowCommand"
                                                        OnRowDataBound="gvNewFiles_RowDataBound">
                                                        <AlternatingRowStyle CssClass="GridAlternate" />
                                                        <RowStyle CssClass="GridNormalRow" />
                                                        <Columns>
                                                            <asp:TemplateField ItemStyle-HorizontalAlign="Right">
                                                                <ItemTemplate>
                                                                    <table cellpadding="0" cellspacing="0" width="100%" border="0">
                                                                        <tr>
                                                                            <td class="GridNumberRow" style="width: 5%;" align="right">
                                                                                <%# string.Format("{0}",Container.DataItemIndex + 1 +".") %>
                                                                            </td>
                                                                             <td style="width: 25%" align="left">
                                                                                <%#Eval("FolderName")%>
                                                                            </td>
                                                                            <td style="width: 63%; padding-left: 2px;" align="left">
                                                                                <asp:LinkButton ToolTip='<%# String.Format("Download {0}",Eval("Name")) %>' runat="server"
                                                                                    ID="lbtnFiles" Text='<%#Eval("Name") %>' CommandArgument='<%#Eval("Name") %>'
                                                                                    CommandName="downloadFile"></asp:LinkButton>
                                                                            </td>
                                                                            <td style="width: 22%" align="left">
                                                                                <%#Eval("ConvertedSize")%>
                                                                            </td>
                                                                            <td colspan="2" style="width: 5%" align="center">
                                                                                <asp:ImageButton Width="10" runat="server" ImageUrl="~/Images/Grid_ActionDelete.gif"
                                                                                    ID="imgBtnDel" CommandName="deleteFile" CommandArgument='<%#Eval("Name") %>'
                                                                                    AlternateText="Delete" ToolTip="Delete File" />
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                        </Columns>
                                                        <EmptyDataRowStyle CssClass="GridEmptyRow" />
                                                        <EmptyDataTemplate>
                                                            <span>No file uploaded</span>
                                                        </EmptyDataTemplate>
                                                    </asp:GridView>
                                                </div>
                                            </td>
                                        </tr>
                                        <tr class="GridFooter">
                                            <td colspan="5">
                                                <div style="float: left">
                                                    Total Files:
                                                    <%= gvNewFiles.Rows.Count  %>
                                                </div>
                                                <div style="float: right">
                                                    Total Size:
                                                    <asp:Label runat="server" ID="lblTotalSize" Text="0 K"></asp:Label>
                                                </div>
                                            </td>
                                        </tr>
                                    </table>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:PostBackTrigger ControlID="gvNewFiles" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
        <asp:Button ID="btnFinish" runat="server"   OnClick="btnFinish_Click"  Text="Exit" style="width:25%;height:45px;margin-left: 45%;margin-right:45%;" CssClass="button"/>
    </form>
</body>
</html>
