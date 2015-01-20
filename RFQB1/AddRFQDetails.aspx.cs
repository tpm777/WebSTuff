using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RFQDBFunctions;
using System.Data;
using Obout.ComboBox;
using System.Configuration;
using FreeTextBoxControls;


public partial class AddRFQDetails : System.Web.UI.Page
{
    enum BooleanAliases
    {
        Yes = 1,
        Aye = 1,
        Cool = 1,
        Y = 1,
        Naw = 0,
        No = 0,
        N = 0
    }
    const int INPUTLABELFONTSIZE = 10;

    const int INPUT_TEXTBOX = 0;
    const int INPUT_COMBOBOX = 1;
    const int INPUTCOLUMNWIDTH = 300;
    const int TEXTBOXCELLWIDTH = 200;
    const int TEXTBOXNOTEHEIGHT = 150;
    const int TEXTBOXNOTEWIDTH = 400;

    
    const int DROPDOWNCELLWIDTH = 200;

    const int ALLOWABLEVALUESWIDTH = 400;

    private string m_strRFQType;
    private string m_strRFQSubType;
    private string m_strRFQFieldDescription;


    private int m_nRFQDetailID;
    private int m_nRFQDetailLine;
    private int m_nRFQDetailSequence;
    private int m_nRFQDetailFieldRef;

    private DataTable m_dt = null;

    public event EventHandler ButtonClick1;
    string m_strStartPage = ConfigurationManager.AppSettings["StartPage"];
    string m_strDateTimeFormat = "MM/dd/yyyy HH:mm";
    string m_strProductGroup = null;
    string m_strNotAllowedChars = "";

    protected void Page_Load(object sender, EventArgs e)
    {
   //     pnlDynamicInputs.PreRender += new EventHandler(pnlHistory_OnPreRender);

        if (!IsPostBack)
        {
            m_strRFQType = (string)Session["RFQType"];
            m_strRFQSubType = (string)Session["RFQSubType"];
            m_strProductGroup = (string)Session[m_strProductGroup];
            if ((string)Request.QueryString["RFQID"] != null)
            {
                Session["RFQID"] = Convert.ToInt32(Request.QueryString["RFQID"]);
                EditRFQDetail((string)Request.QueryString["RFQID"], (string)Request.QueryString["LineID"]);
                Session["EditMode"] = true;
                Session["LineID"] = (string)Request.QueryString["LineID"];
            }
            else
            {
                lblError.ForeColor = System.Drawing.Color.Red;
                CreateDynamicTable(m_strRFQType, m_strRFQSubType);
                Session["EditMode"] = false;

            }
        }
  
    }
    protected void pnlHistory_OnPreRender(object sender, EventArgs e)
    {
        ScriptManager.RegisterStartupScript(
        pnlDynamicInputs, pnlDynamicInputs.GetType(), "scrollPanelToBottom",
        "scrollPanelToBottom();",
        true);
    }  

    private void DisplayMsg(string sMsg)
    {
        CmpWebBaseMsgBox.MBox.Show(sMsg);
    }

    public void CreateDynamicTable(string strType, string strSubType)
    {

        if (string.IsNullOrEmpty(strType))
        {
            lblError.Text = "RFQ Detail Type Is Not Defined";
            return;
        }

        if (string.IsNullOrEmpty(strSubType))
        {
            lblError.Text = "RFQ Detail Sub Type Is Not Defined";
            return;
        }

        
        
        // Total number of rows.
        int rowCnt;
        // Current row count.
        int rowCtr;
        // Total number of cells per row (columns).
        int cellCtr;
        // Current cell counter.
        int cellCnt;
        int nNumberOfInputsPerRow = 1;
        string strInputType = null;
        string strInputControlName = null;
        string strInputControlOptions = null;
        string strControlTip = null;

        string strEditValue = null;
        bool blnReqired = false;
        // reset table
        Table1.Rows.Clear();
        Table1.Controls.Clear();

        m_dt = new DataTable();
        RFQType = strType;
        RFQSubType = strSubType;



        lblRFQType.Text = RFQType;
        lblRFQSubType.Text = RFQSubType;
        RFQFieldControl dtFieldControls = new RFQFieldControl();

        DataTable dt = dtFieldControls.GetRFQFieldControlTypes(strType, strSubType);
        m_dt = dt.Copy();  
        if (dt.Rows.Count > 0)
        {
            rowCnt = dt.Rows.Count;
            cellCnt = 0;






            for (rowCtr = 0; rowCtr < rowCnt ; rowCtr++)
            {


                // Create a new row and add it to the table.
                TableRow tRow = new TableRow();
                Table1.Rows.Add(tRow);
                Table1.EnableViewState = true;
                ViewState["Table1"] = true;

                //left label desc
                DataRow oRow = dt.Rows[rowCtr];

                if (IsFieldActive((string)oRow["Active"]))
                {


                
             

                    AddLabelControl((string)oRow["Description"], tRow);
                    // left input prompt
                    string strFieldName = (string)oRow["Description"];

           
                    strInputType = (string)oRow["InputControlType"];
                    strInputControlName = Convert.ToString(oRow["FieldRef"]);

                    if (!string.IsNullOrEmpty(oRow["InputControlOptions"].ToString()))
                    {
                        strInputControlOptions = (string)oRow["InputControlOptions"];

                    }
                    else
                    {

                        strInputControlOptions = "";
                    }

                    blnReqired = IsFieldRequired((string)oRow["Required"]);

                    if (!strInputType.ToUpper().Contains("TEXTBOX"))
                    {
                        if (!string.IsNullOrEmpty(oRow["Validation"].ToString()))
                        {
                            Session["SQLCMD"] = BuilDSQLCmd((string)oRow["Validation"]);
                        }
                        else
                        {


                        }
                    }
                    else
                    {
                        if (!string.IsNullOrEmpty(Convert.ToString(oRow["Validation"])))
                        {
                            Session["ValidateString"] = (string)oRow["Validation"];
                            if (!string.IsNullOrEmpty(Convert.ToString(oRow["ValidationErrMessage"])))
                                Session["ValidateErrMessage"] = (string)oRow["ValidationErrMessage"];
                            else
                                Session["ValidateErrMessage"] = "Not Defined";
                        }
                        else
                        {


                        }

                    }
                    // check for TIP

                    if (!string.IsNullOrEmpty(oRow["ControlTip"].ToString()))
                    {
                        strControlTip = (string)oRow["ControlTip"];

                    }
                    else
                    {

                        strControlTip = "";
                    }


                    if (strInputType.ToUpper().Contains("TEXTBOX"))
                    {
                        AddUserInputControl(tRow, INPUT_TEXTBOX, strInputControlName, blnReqired, strFieldName, strInputControlOptions, strControlTip);
                    }
                    else
                        AddUserInputControl(tRow, INPUT_COMBOBOX, strInputControlName, blnReqired, strFieldName, strInputControlOptions, strControlTip);

                    if (!string.IsNullOrEmpty(Convert.ToString(oRow["ValidationErrMessage"])))
                    {
                        AddRowNotes(Convert.ToString(oRow["ValidationErrMessage"]), tRow);
                    }
                    else
                    {
                        if ((strFieldName.ToUpper().Contains("NOTE")) ||
                            (strFieldName.ToUpper().Contains("COMMENT")) ||
                            (strFieldName.ToUpper().Contains("GENERAL DESCRIPTION")))
                        {
                            if (blnReqired)
                            {

                                AddRowNotes(" * " + m_strNotAllowedChars, tRow);
                            }
                            else
                            {
                                AddRowNotes("Chars Not Allowed: " + m_strNotAllowedChars, tRow);

                            }


                        }


                    }

                }

            }

        }
        Session["RFQDetailControlRef"] = m_dt;

    }
    private bool IsFieldRequired(string strFieldRequired)
    {
        bool blnReturnState = false;
        try
        {
            blnReturnState= Convert.ToBoolean(Enum.Parse(typeof(BooleanAliases), strFieldRequired));
        }
        catch (Exception err)
        {
            return false;

        }
        return blnReturnState;

    }

    private bool IsFieldActive(string strFieldRequired)
    {
        bool blnReturnState = false;
        try
        {
            blnReturnState = Convert.ToBoolean(Enum.Parse(typeof(BooleanAliases), strFieldRequired));
        }
        catch (Exception err)
        {
            return false;

        }
        return blnReturnState;

    }
    
    
    public void ResetControl()
    {
        int nCount = 0;
        // reset table
        Table1.Rows.Clear();   
        Table1.Controls.Clear();  
        
             
        Table1.EnableViewState = false;
        ViewState["Table1"] = false;
        SaveViewState();
    }


    public void btnTest_Click(object sender, EventArgs e)
    {
        ButtonClick1(sender, e);
        


  //      CreateDynamicTable();

        
    }

    private void AddLabelControl(string strLabelDesc, TableRow tRow)
    {
        TableCell tCell = new TableCell();
        Unit width = new Unit(INPUTCOLUMNWIDTH, UnitType.Pixel);  // need logic to calculate column width
        tCell.Width = width;
        tCell.HorizontalAlign = HorizontalAlign.Left;
        tCell.BorderWidth = 0;

        tCell.Style.Value = "vertical-align:text-top;";
 
        Label lblDesc = new Label();

        lblDesc.BorderWidth = 0;
        lblDesc.Font.Bold = true;
        lblDesc.Font.Size = INPUTLABELFONTSIZE;
        lblDesc.Width  = width;
   
        lblDesc.Text = strLabelDesc;
        tCell.Controls.Add(lblDesc);
        
        

        tRow.Cells.Add(tCell);

    }
    private void AddRowNotes(string strLabelDesc, TableRow tRow)
    {
        TableCell tCell = new TableCell();
        Unit width = new Unit(ALLOWABLEVALUESWIDTH, UnitType.Pixel);  // need logic to calculate column width
        int nHeaderTextBoxFontSize = 8;
        
        tCell.Width = width;
        tCell.HorizontalAlign = HorizontalAlign.Left;
        tCell.BorderWidth = 0;

        tCell.Style.Value = "vertical-align:text-top;";

        Label lblDesc = new Label();

        lblDesc.BorderWidth = 0;
        lblDesc.ForeColor = System.Drawing.Color.Red;
        lblDesc.Font.Size = FontUnit.Point(nHeaderTextBoxFontSize);    
        lblDesc.Text = strLabelDesc;
        tCell.Controls.Add(lblDesc);



        tRow.Cells.Add(tCell);

    }

    private void AddUserInputControl(TableRow tRow, int nType, string strInputID, bool blnRequired, string  strFieldName, string strInputOptions, string strControlTip)
    {
        TableCell tCell = new TableCell();
        Unit width = new Unit(INPUTCOLUMNWIDTH, UnitType.Pixel);
        tCell.Width = width;
        tCell.HorizontalAlign = HorizontalAlign.Left;
        RFQGenericDB oDb = new RFQGenericDB();
        if (nType == INPUT_TEXTBOX)
        {

            // TextBox oControl = new TextBox();


            if ((strFieldName.ToUpper().Contains("NOTE")) || 
                (strFieldName.ToUpper().Contains("COMMENT"))||
                (strFieldName.ToUpper().Contains("GENERAL DESCRIPTION" )))
            {
                TextBox oControl = new TextBox();
               
                oControl.Height = new Unit(TEXTBOXNOTEHEIGHT, UnitType.Pixel);
                 
                oControl.Width = new Unit(TEXTBOXNOTEWIDTH, UnitType.Pixel);
                oControl.TextMode  = TextBoxMode.MultiLine;
               
 
                oControl.ID = "NotetxbInput" + strInputID;
                //oControl.Attributes.Add("onBlur", "javascript:return ValidateText(RFQInputDetails_" + oControl.ID + ");");
                //oControl.Attributes.Add("onfocus", "javascript:return setStyle(RFQInputDetails_" + oControl.ID + ");");
                tCell.Controls.Add(oControl);
                //if (blnRequired)   will not work with multiline textboxes
                //{
                //    tCell.Controls.Add(BuildFieldRequiredLabel());
                //}


            }
            else
            {
                TextBox oControl = new TextBox();

                oControl.Width = new Unit(TEXTBOXCELLWIDTH, UnitType.Pixel);

                oControl.ID = "txbInput" + strInputID;
         //           oControl.Attributes.Add("onkeypress", "$('#" + lblError.ClientID + "').text('');");
                oControl.Attributes.Add("onBlur", "javascript:return ValidateText(ContentPlaceHolder1_" + oControl.ID + ");");
                oControl.Attributes.Add("onfocus", "javascript:return setStyle(ContentPlaceHolder1_" + oControl.ID + ");");

      

             //   oControl.ID = "ContentPlaceHolder1_txbInput" + strInputID;
                oControl.Attributes.Add("Validate", (string)Session["ValidateString"]);
                oControl.Attributes.Add("ValErrMsg", (string)Session["ValidateErrMessage"]);


                if (!string.IsNullOrEmpty(strControlTip))
                    oControl.ToolTip = strControlTip;

                tCell.Controls.Add(oControl);
                //if (blnRequired)
                //{
                //    tCell.Controls.Add(BuildFieldRequiredLabel(true));
                //}
                //else
                //{
                //    tCell.Controls.Add(BuildFieldRequiredLabel(false));

                //}
            }
           tCell.Controls.Add(BuildFieldRequiredLabel(blnRequired));
           tCell.ID = strInputID;

        }
        else
        {
            ComboBox oControl = new ComboBox();
            if (!string.IsNullOrEmpty(strInputOptions))
            {
                if (strInputOptions.ToUpper().Contains("MULTI"))
                {
                    oControl.SelectionMode = ListSelectionMode.Multiple  ;
                    SqlDataSource sds3 = new SqlDataSource();

                    sds3.ID = "mySqlSourceControl"+strInputID;
                    Page.Controls.Add(sds3);

                    string strSQLCMD = BuilDSQLCmd((string)Session["SQLCMD"]);

                    sds3.ConnectionString = ConfigurationManager.ConnectionStrings["RFQConnectionString"].ConnectionString;
                    sds3.SelectCommand = strSQLCMD;
                    sds3.ProviderName = ConfigurationManager.ConnectionStrings["RFQConnectionString"].ProviderName;





                    oControl.ID = "ComboBox1"  +strInputID;
                    
                    oControl.Width = Unit.Pixel(200);
                    oControl.AllowEdit = false;
                    oControl.DataSourceID = sds3.ID;
                    oControl.DataTextField = "Value";
                    oControl.DataValueField = "Value";

                    
                   

//                    oControl.ItemTemplate = new ItemTemplate();

    //                 oControl.ClientSideEvents.OnItemClick = "ComboBox1_ItemClick";
    //                oControl.Attributes.Add("OnItemClick", "javascript:return ComboBox1_Click(ContentPlaceHolder1_" + oControl.ID + ");");

                    if (!string.IsNullOrEmpty(strControlTip))
                        oControl.ToolTip = strControlTip;

                    tCell.Controls.Add(oControl);
                    //if (blnRequired)
                    //{
                    //    tCell.Controls.Add(BuildFieldRequiredLabel(true));
                    //}
                    //else
                    //{
                    //    tCell.Controls.Add(BuildFieldRequiredLabel(false));

                    //}
                    tCell.ID = strInputID;
                    tCell.BorderWidth = 0;
                    tCell.Controls.Add(BuildFieldRequiredLabel(blnRequired));
                    tRow.Cells.Add(tCell);
                    return;
                }
            }
            else
            {
                oControl.SelectionMode = ListSelectionMode.Single ;

            }
//            oControl.Width = new Unit(DROPDOWNCELLWIDTH, UnitType.Pixel); ;
           
//            DropDownList oControl = new DropDownList();
            oControl.Width = new Unit(DROPDOWNCELLWIDTH, UnitType.Pixel); 
           

            string strDataSource = BuilDSQLCmd( (string)Session["SQLCMD"]);

            if (!string.IsNullOrEmpty(strDataSource))
            {
                if (strDataSource.ToUpper().Contains("SELECT"))
                {
                    DataTable dt = oDb.GetRecordSet(BuilDSQLCmd( (string)Session["SQLCMD"]));

                    if (dt == null)
                    {
                        Object objTest = Session["SQLCMD"];
                        string strSQLCmd= (objTest != null) ? (string)Session["SQLCMD"] : "";

                        DisplayMsg("Error Retrieving Input Controls Definition" + strSQLCmd);
                        return;


                    }

                    foreach (DataRow oRow in dt.Rows)
                    {
 //                       ListItem lstItem = new ListItem((string)oRow[0]);
                        ComboBoxItem lstItem = new ComboBoxItem((string)oRow[0]);
                        if (oControl.SelectionMode == ListSelectionMode.Multiple)
                        {
                            CheckBox chkBox = new CheckBox();
                            lstItem.Controls.Add(chkBox);
                         
                        }
                        oControl.Items.Add(lstItem);
                         
                    }
                }
            }
       //     oControl.DataSource  = dt;
       //     oControl.DataBind();
       //     oControl.Height = new Unit(DROPDOWNCELLWIDTH, UnitType.Pixel); ;

            if (!string.IsNullOrEmpty(strControlTip))
                oControl.ToolTip = strControlTip;

            tCell.Controls.Add(oControl);
            //if (blnRequired)
            //{
            //    if (blnRequired)
            //    {
            //        tCell.Controls.Add(BuildFieldRequiredLabel(true));
            //    }
            //    else
            //    {
            //        tCell.Controls.Add(BuildFieldRequiredLabel(false));

            //    }
            //}
            tCell.Controls.Add(BuildFieldRequiredLabel(blnRequired));
            tCell.ID = strInputID;


        }


        tCell.BorderWidth = 0;

        tRow.Cells.Add(tCell);

    }
    private void AddUserInputControl(TableRow tRow, int nType, string strInputID, bool blnRequired, string strFieldName, string strEditFieldValue, string strInputOptions, string strControlTip)
    {
        TableCell tCell = new TableCell();
        Unit width = new Unit(INPUTCOLUMNWIDTH, UnitType.Pixel);
        tCell.Width = width;
        tCell.HorizontalAlign = HorizontalAlign.Left;
        RFQGenericDB oDb = new RFQGenericDB();
        if (nType == INPUT_TEXTBOX)
        {

            // TextBox oControl = new TextBox();


            if ((strFieldName.ToUpper().Contains("NOTE")) ||
                (strFieldName.ToUpper().Contains("COMMENT")) ||
                (strFieldName.ToUpper().Contains("GENERAL DESCRIPTION")))
            {
                TextBox oControl = new TextBox();
                oControl.Height = new Unit(TEXTBOXNOTEHEIGHT, UnitType.Pixel);
                oControl.Width = new Unit(TEXTBOXNOTEWIDTH, UnitType.Pixel);
                oControl.TextMode  = TextBoxMode.MultiLine;

                oControl.ID = "NotetxbInput" + strInputID;
                //oControl.Attributes.Add("onBlur", "javascript:return ValidateText(RFQInputDetails_" + oControl.ID + ");");
                //oControl.Attributes.Add("onfocus", "javascript:return setStyle(RFQInputDetails_" + oControl.ID + ");");
                oControl.Text = strEditFieldValue;

              

                tCell.Controls.Add(oControl);
                //if (blnRequired)   will not work with multi-line text
                //{
                //    tCell.Controls.Add(BuildFieldRequiredLabel());
                //}


            }
            else
            {
                TextBox oControl = new TextBox();

                oControl.Width = new Unit(TEXTBOXCELLWIDTH, UnitType.Pixel);

                oControl.ID = "txbInput" + strInputID;
                //           oControl.Attributes.Add("onkeypress", "$('#" + lblError.ClientID + "').text('');");
                oControl.Attributes.Add("onBlur", "javascript:return ValidateText(ContentPlaceHolder1_" + oControl.ID + ");");
                oControl.Attributes.Add("onfocus", "javascript:return setStyle(ContentPlaceHolder1_" + oControl.ID + ");");



                //   oControl.ID = "ContentPlaceHolder1_txbInput" + strInputID;
                oControl.Attributes.Add("Validate", (string)Session["ValidateString"]);
                oControl.Attributes.Add("ValErrMsg", (string)Session["ValidateErrMessage"]);

                oControl.Text = strEditFieldValue;

                if (!string.IsNullOrEmpty(strControlTip))
                    oControl.ToolTip = strControlTip;

                tCell.Controls.Add(oControl);
                //if (blnRequired)
                //{
                //    if (blnRequired)
                //    {
                //        tCell.Controls.Add(BuildFieldRequiredLabel(true));
                //    }
                //    else
                //    {
                //        tCell.Controls.Add(BuildFieldRequiredLabel(false));

                //    }
                //}
            }
            tCell.Controls.Add(BuildFieldRequiredLabel(blnRequired));
            tCell.ID = strInputID;

        }
        else
        {
            ComboBox oControl = new ComboBox();

            if (!string.IsNullOrEmpty(strInputOptions))
            {
                if (strInputOptions.ToUpper().Contains("MULTI"))
                    oControl.SelectionMode = ListSelectionMode.Multiple;
            }
            else
            {
                oControl.SelectionMode = ListSelectionMode.Single;
            }
            //            oControl.Width = new Unit(DROPDOWNCELLWIDTH, UnitType.Pixel); ;

            //            DropDownList oControl = new DropDownList();
            oControl.Width = new Unit(DROPDOWNCELLWIDTH, UnitType.Pixel);


            if (!string.IsNullOrEmpty(strControlTip))
                oControl.ToolTip = strControlTip;



            string strDataSource = BuilDSQLCmd( (string)Session["SQLCMD"]);

            if (!string.IsNullOrEmpty(strDataSource))
            {
                if (strDataSource.ToUpper().Contains("SELECT"))
                {
                    DataTable dt = oDb.GetRecordSet(BuilDSQLCmd ((string)Session["SQLCMD"]));

                    foreach (DataRow oRow in dt.Rows)
                    {
                        //                       ListItem lstItem = new ListItem((string)oRow[0]);
                        ComboBoxItem lstItem = new ComboBoxItem((string)oRow[0]);

                        oControl.Items.Add(lstItem);
                    }
                    if (!string.IsNullOrEmpty(strEditFieldValue))
                    {
                        if (!(oControl.SelectionMode == ListSelectionMode.Multiple))
                        {
                            oControl.SelectedValue = strEditFieldValue;
                        }
                        else
                        {
                            string[] separators = {"[", "]"};
                            string[] strEditValues = strEditFieldValue.Split(separators, StringSplitOptions.RemoveEmptyEntries);

                            foreach (ComboBoxItem lstItem in oControl.Items)
                            {
                                foreach (string strBuffer in strEditValues)
                                {

                                    if (lstItem.Value == strBuffer)
                                    {
                                        lstItem.Selected = true;
                                        break;
                                    }
                                }
                            }

                            oControl.SelectedText  = strEditFieldValue;
                        }

                    }
                }

            }
            //     oControl.DataSource  = dt;
            //     oControl.DataBind();
            //     oControl.Height = new Unit(DROPDOWNCELLWIDTH, UnitType.Pixel); ;
            tCell.Controls.Add(oControl);
            tCell.Controls.Add(BuildFieldRequiredLabel(blnRequired));
            tCell.ID = strInputID;


        }


        tCell.BorderWidth = 0;

        tRow.Cells.Add(tCell);

    }

    
    private Label BuildFieldRequiredLabel()
    {
        Label oLabel = new Label();
        oLabel.Text = "*";
        oLabel.Width = new Unit(15, UnitType.Pixel);
        oLabel.ForeColor = System.Drawing.Color.Red;

        return oLabel;

    }

    private Label BuildFieldRequiredLabel(bool blnAddAsterisk)
    {
        Label oLabel = new Label();
        if (blnAddAsterisk)
            oLabel.Text = "*";
        else
            oLabel.Text = "  ";  // need a spacer
        oLabel.Width = new Unit(15, UnitType.Pixel);
        oLabel.ForeColor = System.Drawing.Color.Red;

        return oLabel;

    }

    //protected void btnViewTableContents_Click(object sender, EventArgs e)
    //{

    //    foreach (TableRow tr in Table1.Controls)
    //    {
    //        foreach (TableCell tc in tr.Controls)
    //        {

    //            if (tc.Controls[0] is TextBox)
    //            {
    //                Response.Write(tc.ID + "=" + ((TextBox)tc.Controls[0]).Text);
    //            }
    //            else if (tc.Controls[0] is DropDownList)
    //            {
    //                Response.Write(tc.ID + "=" + ((DropDownList)tc.Controls[0]).Text);
    //            }
    //        }
    //        Response.Write("<br/>");
    //    }

    //}
    protected override object SaveViewState()
    {

        object[] newViewState = new object[2];

        List<string> txtValues = new List<string>();

        foreach (TableRow row in Table1.Controls)
        {
            foreach (TableCell cell in row.Controls)
            {
                if (cell.Controls[0] is TextBox)
                {
                    txtValues.Add(((TextBox)cell.Controls[0]).Text + "," + cell.ID);
                }
                else if (cell.Controls[0] is DropDownList)
                {
                    txtValues.Add(((DropDownList)cell.Controls[0]).Text + "," + cell.ID);
                }
                else if (cell.Controls[0] is ComboBox )
                {
                    txtValues.Add(((ComboBox)cell.Controls[0]).SelectedText  + "," + cell.ID);
                }
                else if (cell.Controls[0] is FreeTextBox)
                {
                    txtValues.Add(((FreeTextBox)cell.Controls[0]).Text + "," + cell.ID);
                }

            }
        }

        newViewState[0] = txtValues.ToArray();
        newViewState[1] = base.SaveViewState();
        return newViewState;
    }
    protected override void LoadViewState(object savedState)
    {

        //if we can identify the custom view state as defined in the override for SaveViewState
        if (savedState is object[] && ((object[])savedState).Length == 2 && ((object[])savedState)[0] is string[])
        {
            object[] newViewState = (object[])savedState;
            string[] txtValues = (string[])(newViewState[0]);
            if (txtValues.Length > 0)
            {
                //re-load tables
                if ((bool)Session["EditMode"])
                {
                    EditRFQDetail(Convert.ToString((int)Session["RFQID"]), (string)Session["LineID"]);
                }
                else
                {

                    //Session["RFQID"] = Convert.ToInt32(Request.QueryString["RFQID"]);
                    //EditRFQDetail((string)Request.QueryString["RFQID"], (string)Request.QueryString["LineID"]);
                    //Session["EditMode"] = true;
                    //Session["LineID"] = (string)Request.QueryString["LineID"];
                    CreateDynamicTable((string)Session["RFQType"], (string)Session["RFQSubType"]);

                }
                int i = 0;

                foreach (TableRow row in Table1.Controls)
                {
                    foreach (TableCell cell in row.Controls)
                    {
                        if (cell.Controls[0] is TextBox && i < txtValues.Length)
                        {
                            ((TextBox)cell.Controls[0]).Text = txtValues[i++].ToString();

                        }
                        else if (cell.Controls[0] is DropDownList && i < txtValues.Length)
                        {
                            ((DropDownList)cell.Controls[0]).Text = txtValues[i++].ToString();

                        }
                        else if (cell.Controls[0] is ComboBox)
                        {
                            ComboBox oTemp = (ComboBox)cell.Controls[0];
                       //     if (oTemp.SelectionMode != ListSelectionMode.Multiple)
                                ((ComboBox)cell.Controls[0]).SelectedText  = txtValues[i++].ToString();
                            //else
                            //{
                            //    foreach (ComboBoxItem item in oTemp.Items)
                            //    {
                            //        CheckBox checkbox = item.FindControl("CheckBox1") as CheckBox;
                            //        if (checkbox.Checked)
                            //        {
                            //            ((ComboBox)cell.Controls[0]).SelectedText += txtValues[i++].ToString();
                            //        }
                            //    }

                            //}
                        }


                    }
                }
            }
            //load the ViewState normally
            base.LoadViewState(newViewState[1]);
        }
        else
        {
            base.LoadViewState(savedState);
        }
    }

    private bool ErrorChecks()
    {
	return true;
        string strNotAllowedChars = "><\'\"";
//        string strNotAllowedChars = "~!%^&*()_+|}{:?><//\\',";
        string strNoteBox = null;
        string strErrorMessage = null;
        foreach (TableRow tr in Table1.Controls)
        {
            foreach (TableCell tc in tr.Controls)
            {

                if (tc.Controls[0] is TextBox)
                {
                    if (((TextBox)tc.Controls[0]).Text.Length > 999)
                    {

                        DisplayMsg("Too Many Characters in Note Box");
                        return false;

                    }
                    if (((TextBox)tc.Controls[0]).Text.Length > 0)
                    {
                        strNoteBox = ((TextBox)tc.Controls[0]).Text;

                        if (strNoteBox.IndexOfAny(strNotAllowedChars.ToCharArray()) >= 0)
                        {
                            strErrorMessage = string.Format("Character in Notes Field Not Allowed [{0}]", strNoteBox[strNoteBox.IndexOfAny(strNotAllowedChars.ToCharArray())]);
                            DisplayMsg(strErrorMessage);
                            return false;


                        }



                    }


                }
                else if (tc.Controls[0] is FreeTextBox)
                {
                    //                 Response.Write(tc.ID + "=" + ((DropDownList)tc.Controls[0]).Text);

                    if (((FreeTextBox)tc.Controls[0]).Text.Length > 999)
                    {

                        DisplayMsg("Too Many Characters in Note Box");
                        return false;

                    }


                }
                else if (tc.Controls[0] is DropDownList)
                {
                    //                 Response.Write(tc.ID + "=" + ((DropDownList)tc.Controls[0]).Text);
                }
                else if (tc.Controls[0] is ComboBox)
                {
                    //                 Response.Write(tc.ID + "=" + ((DropDownList)tc.Controls[0]).Text);
                   // ComboBox cmbTemp = (ComboBox)tc.Controls[0];
                }
            }

        }

        return true;
    }


    protected void btnSaveRFQDetail_Click(object sender, EventArgs e)
    {
        string strErrorMessage = null;
        string strNoteBox=null;
        if (!ErrorChecks()) return; 
        foreach (TableRow tr in Table1.Controls)
        {
            foreach (TableCell tc in tr.Controls)
            {

                if (tc.Controls[0] is TextBox)
                {

                    if ((bool)Session["EditMode"])
                    {

                        if (!UpdateRFQDetailRecord(tc.ID, ((TextBox)tc.Controls[0]).Text))
                        {

                            strErrorMessage = string.Format("Error Updating Line Detail [{0}]", tc.Controls[0].ID);
                            DisplayMsg(strErrorMessage);
                            return;

                        }
                    }
                    else
                    {
                        if (!CreateRFQDetailRecord(tc.ID, ((TextBox)tc.Controls[0]).Text))
                        {
                            strErrorMessage = string.Format("Error Creating Line Detail [{0}]", tc.Controls[0].ID);
                            DisplayMsg(strErrorMessage);
                            return;


                        }
                    }


                }
                else if (tc.Controls[0] is FreeTextBox )
                {
                    //                 Response.Write(tc.ID + "=" + ((DropDownList)tc.Controls[0]).Text);

      
                   
                    if ((bool)Session["EditMode"])
                    {

                        UpdateRFQDetailRecord(tc.ID, ((FreeTextBox)tc.Controls[0]).Text);
                    }
                    else
                    {
                        CreateRFQDetailRecord(tc.ID, ((FreeTextBox)tc.Controls[0]).Text);
                    }

                }
                else if (tc.Controls[0] is DropDownList)
                {
   //                 Response.Write(tc.ID + "=" + ((DropDownList)tc.Controls[0]).Text);
                    if ((bool)Session["EditMode"])
                    {

                        if (!UpdateRFQDetailRecord(tc.ID, ((DropDownList)tc.Controls[0]).Text))
                        {
                            strErrorMessage = string.Format("Error Updating Line Detail [{0}]", tc.Controls[0].ID);
                            DisplayMsg(strErrorMessage);
                            return;
                        }
                    }
                    else
                    {
                        if (!CreateRFQDetailRecord(tc.ID, ((DropDownList)tc.Controls[0]).Text))
                        {
                            strErrorMessage = string.Format("Error Creating Line Detail [{0}]", tc.Controls[0].ID);
                            DisplayMsg(strErrorMessage);
                            return;

                        }
                    }
                }
                else if (tc.Controls[0] is ComboBox )
                {
                    //                 Response.Write(tc.ID + "=" + ((DropDownList)tc.Controls[0]).Text);
                    ComboBox cmbTemp = (ComboBox)tc.Controls[0];
                    if (cmbTemp.SelectionMode != ListSelectionMode.Multiple)
                    {
                      
                        if ((bool)Session["EditMode"])
                        {
                            if (!UpdateRFQDetailRecord(tc.ID, ((ComboBox)tc.Controls[0]).SelectedText))
                            {
                                strErrorMessage = string.Format("Error Updating Line Detail [{0}]", tc.Controls[0].ID);
                                DisplayMsg(strErrorMessage);
                                return;


                            }
                        }
                        else
                        {
                            if (!CreateRFQDetailRecord(tc.ID, ((ComboBox)tc.Controls[0]).SelectedText))
                            {
                                strErrorMessage = string.Format("Error Creating Line Detail [{0}]", tc.Controls[0].ID);
                                DisplayMsg(strErrorMessage);
                                return;

                            }
                        }
                    }
                    else
                    {
                        string strTemp=null;
                        foreach (ComboBoxItem item in cmbTemp.Items)
                        {
                            if (item.Selected)
                            {

                                strTemp += "[" + item.Text + "]";
                            }
                        }
                      
                        if ((bool)Session["EditMode"])
                        {
                            if (!UpdateRFQDetailRecord(tc.ID, strTemp))
                            {
                                strErrorMessage = string.Format("Error Updating Line Detail [{0}]", tc.Controls[0].ID);
                                DisplayMsg(strErrorMessage);
                                return;

                            }
                        }
                        else
                        {
                            if (!CreateRFQDetailRecord(tc.ID, strTemp))
                            {

                                strErrorMessage = string.Format("Error Creating Line Detail [{0}]", tc.Controls[0].ID);
                                DisplayMsg(strErrorMessage);
                                return;
                            }
                        }
                    }

                }
            }
  
        }
        RFQHeaderDB oRFQHeader = new RFQHeaderDB((string)Session["UserID"]);

        if (!oRFQHeader.UpdateLastChanged("Updated Line[" + RFQDetailLine.ToString() + "]", DateTime.Now.ToString(m_strDateTimeFormat), Convert.ToString(Session["RFQID"])))
        {
//            Response.Redirect(); 
            DisplayMsg("Error Updating RFQHeader Record");

            return;

        }
        Response.Redirect(m_strStartPage+"?RFQID=" + (int)Session["RFQID"], true);  
    }
    private bool VerifyTextBox(string strFieldRef, string strValue, ref string strErrMessage)
    {
        RFQFieldControl oFieldControlRecord = new RFQFieldControl();

        DataTable  dt = oFieldControlRecord.GetRFQFieldControlRecord((string)Session["RFQType"], (string)Session["RFQSubType"], strFieldRef);

        if (string.IsNullOrEmpty(strValue))
        {
            if (IsFieldRequired((string)dt.Rows[0]["Required"]))
            {
                strErrMessage = (string)dt.Rows[0]["Description"] + " Can Not Be Blank";
                return false;
            }
        }
        if (IsFieldRequired((string)dt.Rows[0]["Required"]))
        {
            
            if (string.IsNullOrEmpty(Convert.ToString( dt.Rows[0]["Validation"])))
            {

                lblError.Text = (string)dt.Rows[0]["Description"] + " Field Is Required But There Isn't A Validation String";
                return false;
            }

            RegexValidation regTester = new RegexValidation((string)dt.Rows[0]["Validation"]);
            if (!regTester.IsValid(strValue))
            {
                lblError.Text = (string)dt.Rows[0]["Description"] + " Error In Value";
                return false;

            }
        }

        return true;

    }
    private string RemovePuncs(string strSource)
    {


        if (!string.IsNullOrEmpty(strSource))
        {
            strSource = strSource.Replace(",", "[COMMA]");
            strSource = strSource.Replace("&", "[AMPERSAND]");
            strSource = strSource.Replace("_", "[UNDERSCORE]");
            strSource = strSource.Replace("+", "[PLUS]");
            strSource = strSource.Replace("?", "[QUESTIONMARK]");

            strSource = strSource.Replace("\"", "[DOUBLEQUOTE]");
            strSource = strSource.Replace("\'", "[SINGLEQUOTE]");
            strSource = strSource.Replace(">", "[GREATERTHAN]");
            strSource = strSource.Replace("<", "[LESSTHAN]");

        }
        return strSource;
    }

    private string AddPuncs(string strSource)
    {
        if (!string.IsNullOrEmpty(strSource))
        {
            strSource = strSource.Replace("[COMMA]", ",");
            strSource = strSource.Replace("[AMPERSAND]", "&");
            strSource = strSource.Replace("[UNDERSCORE]", "_");
            strSource = strSource.Replace("[PLUS]", "+");
            strSource = strSource.Replace("[QUESTIONMARK]", "?");


            strSource = strSource.Replace("[DOUBLEQUOTE]","\"");
            strSource = strSource.Replace("[SINGLEQUOTE]","\'");
            strSource = strSource.Replace("[GREATERTHAN]",">");
            strSource = strSource.Replace("[LESSTHAN]","<");



        }
        return strSource;
    }

    private bool CreateRFQDetailRecord(string strFieldRef, string strValue)
    {

        RFQDetail clsRFQDetail = new RFQDetail();
        string strInput = null;

        
	strValue = RemovePuncs(strValue);

        RFQType = (string)Session["RFQType"];
        RFQSubType = (string)Session["RFQSubType"];
        RFQProductGroup = (string)Session["ProductGroup"];

 //       m_dt = (DataTable)Session["RFQDetailControlRef"];


   //     strInput = "1,1,1,Label,Blank," + strFieldRef + "," + strValue + "," + DateTime.Now + "," + "dave.petersen";

       if ( GetRFQControlInfo( strFieldRef))
       {
           string strUserID = null;
           if (string.IsNullOrEmpty((string)Session["UserID"]))
           {
               strUserID = "Unknown";

           }
           else
               strUserID = (string)Session["UserID"];


           strInput = string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10}", RFQDetailID, RFQDetailLine, RFQDetailSequence, RFQType, RFQSubType, strFieldRef, RFQDetailFieldDescription, strValue, DateTime.Now, strUserID, RFQProductGroup);

   

            clsRFQDetail.SetInputArray(strInput);
            if (!clsRFQDetail.CreateNewRFQDetailRecord())
            {
                DisplayMsg("Error Creating New RFQDetailRecord + [" + strInput);
                return false;

            }
        
            return true;
        }
       return false;
    }
    private bool UpdateRFQDetailRecord(string strFieldRef, string strValue)
    {

        RFQDetail clsRFQDetail = new RFQDetail();
        string strInput = null;

        strValue = RemovePuncs(strValue); 


        RFQType = (string)Session["RFQType"];
        RFQSubType = (string)Session["RFQSubType"];


        //       m_dt = (DataTable)Session["RFQDetailControlRef"];


        //     strInput = "1,1,1,Label,Blank," + strFieldRef + "," + strValue + "," + DateTime.Now + "," + "dave.petersen";

        if (GetRFQControlInfo(strFieldRef))
        {

            strInput = string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},dave.petersen", RFQDetailID, RFQDetailLine, RFQDetailSequence, RFQType, RFQSubType, strFieldRef, RFQDetailFieldDescription, strValue, DateTime.Now);

            //       strInput =  "1,1,1," + RFQType + "," + RFQSubType + ","  + strFieldRef + "," + strValue + "," + DateTime.Now + "," + "dave.petersen";

            clsRFQDetail.SetInputArray(strInput);
            if (!clsRFQDetail.UpdateRFQDetailRecord(Convert.ToString(RFQDetailID)))
            {
                DisplayMsg("Error Updating RFQ Detail Record");
                return false;
            }

            return true;
        }
        return false;
    }


    private bool GetRFQControlInfo(string strFieldRef)
    {
        DataRow[] oRow = m_dt.Select("FieldRef = " + strFieldRef);  // should only be one else something is corrupt
        if (oRow.Length > 1)
        {
            return false;
        }
        RFQDetailID = (int)Session["RFQID"];
        if (!(bool)Session["EditMode"])
            RFQDetailLine = (int)Session["RFQMAXLINE"];//(int)oRow[0]["Line"];
        else
            RFQDetailLine = Convert.ToInt16((string)Session["LineID"]); 
        RFQDetailSequence = (int)oRow[0]["FieldRef"];
        RFQDetailFieldDescription = (string)oRow[0]["Description"];
        return true;

    }
    public string RFQType
    {
        get{ return m_strRFQType;}
        set { m_strRFQType = value; }

    }
    public string RFQSubType
    {
        get { return m_strRFQSubType; }
        set { m_strRFQSubType = value; }

    }

    public string RFQDetailFieldDescription
    {
        get { return m_strRFQFieldDescription; }
        set { m_strRFQFieldDescription = value; }

    }

    public string RFQProductGroup
    {
        get { return m_strProductGroup; }
        set { m_strProductGroup = value; }

    }
    
    
    public int RFQDetailID
    {
        get { return m_nRFQDetailID; }
        set { m_nRFQDetailID = value; }

    }
    public int RFQDetailLine
    {
        get { return m_nRFQDetailLine; }
        set { m_nRFQDetailLine = value; }

    }
    public int RFQDetailSequence
    {
        get { return m_nRFQDetailSequence; }
        set { m_nRFQDetailSequence = value; }

    }
    public int RFQDetailFieldRef
    {
        get { return m_nRFQDetailFieldRef; }
        set { m_nRFQDetailFieldRef = value; }

    }
    protected bool ValidateData()
    {
        string strErrorMessage = null;
        foreach (TableRow tr in Table1.Controls)
        {
            foreach (TableCell tc in tr.Controls)
            {

                if (tc.Controls[0] is TextBox)
                {
                    //                 Response.Write(tc.ID + "=" + ((TextBox)tc.Controls[0]).Text);
                    if (!VerifyTextBox(tc.ID, ((TextBox)tc.Controls[0]).Text, ref strErrorMessage))
                    {
                        //                     DisplayMsg(strErrorMessage);

                        tc.Controls[0].Focus();
                        return false;

                    }
   

                }
                else if (tc.Controls[0] is DropDownList)
                {
                    //                 Response.Write(tc.ID + "=" + ((DropDownList)tc.Controls[0]).Text);
                   // CreateRFQDetailRecord(tc.ID, ((DropDownList)tc.Controls[0]).Text);
                }
                else if (tc.Controls[0] is ComboBox)
                {
                    //                 Response.Write(tc.ID + "=" + ((DropDownList)tc.Controls[0]).Text);
                   // CreateRFQDetailRecord(tc.ID, ((ComboBox)tc.Controls[0]).SelectedText);
                }
            }

        }
        return true;

    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {

        Response.Redirect(m_strStartPage + "?RFQID=" + Convert.ToString(Session["RFQID"])); 
    }
    public void EditRFQDetail(string strRFQID, string strLineID)
    {
        Session["LineID"] = strLineID;

        if (string.IsNullOrEmpty(strRFQID))
        {
            lblError.Text = "RFQ  Is Not Defined";
            return;
        }

        if (string.IsNullOrEmpty(strLineID))
        {
            lblError.Text = "LINE ID Type Is Not Defined";
            return;
        }



        // Total number of rows.
        int rowCnt;
        // Current row count.
        int rowCtr;
        // Total number of cells per row (columns).
        int cellCtr;
        // Current cell counter.
        int cellCnt;
        int nNumberOfInputsPerRow = 1;
        string strInputType = null;
        string strInputControlName = null;
        string strInputControlOptions = null;

        string strEditValue = null;
        string strFieldName = null;

        bool blnReqired = false;
        // reset table
        Table1.Rows.Clear();
        Table1.Controls.Clear();

        m_dt = new DataTable();
        RFQType = m_strRFQType;
        RFQSubType = m_strRFQSubType;



        lblRFQType.Text = RFQType;
        lblRFQSubType.Text = RFQSubType;
        RFQFieldControl dtFieldControls = new RFQFieldControl();

        RFQDetail dtRFQDetailRecord = new RFQDetail();

      //  DataTable dt = dtFieldControls.GetRFQFieldControlTypes(strType, strSubType);
        DataTable dt = dtRFQDetailRecord.GetRFQIDDetailRecord(strRFQID, strLineID, m_strRFQType, m_strRFQSubType);

        m_dt = dt.Copy();
        if (dt.Rows.Count > 0)
        {
            rowCnt = dt.Rows.Count;
            cellCnt = 0;






            for (rowCtr = 0; rowCtr < rowCnt; rowCtr++)
            {


                // Create a new row and add it to the table.
                TableRow tRow = new TableRow();
                Table1.Rows.Add(tRow);
                Table1.EnableViewState = true;
                ViewState["Table1"] = true;

                //left label desc
                DataRow oRow = dt.Rows[rowCtr];

                if (IsFieldActive((string)oRow["Active"]))
                {





                    AddLabelControl((string)oRow["Description"], tRow);
                    // left input prompt
                    if (!string.IsNullOrEmpty((string)oRow["Description"])) 
                        strFieldName = (string)oRow["Description"];

                    strInputType = (string)oRow["InputControlType"];
        
                    strInputControlName = Convert.ToString(oRow["FieldRef"]);

                    if (!string.IsNullOrEmpty(oRow["InputControlOptions"].ToString()))
                        strInputControlOptions = (string)oRow["InputControlOptions"];
                    else
                        strInputControlOptions = "";

                    if (!string.IsNullOrEmpty((string)oRow["Value"]))
                    {

                        strEditValue = (string)oRow["Value"];
                        strEditValue = AddPuncs(strEditValue);
                    }
                    else
                    {
                        strEditValue = "";
                    }


                    blnReqired = IsFieldRequired((string)oRow["Required"]);

                    if (!strInputType.ToUpper().Contains("TEXTBOX"))
                    {
                        if (!string.IsNullOrEmpty(Convert.ToString(oRow["Validation"])))
                        {
                            Session["SQLCMD"] = BuilDSQLCmd( (string)oRow["Validation"]);
                        }
                        else
                        {


                        }
                    }
                    else
                    {
                        if (!string.IsNullOrEmpty(Convert.ToString(oRow["Validation"])))
                        {
                            Session["ValidateString"] = (string)oRow["Validation"];
                            if (!string.IsNullOrEmpty(Convert.ToString(oRow["ValidationErrMessage"])))
                                Session["ValidateErrMessage"] = (string)oRow["ValidationErrMessage"];
                            else
                                Session["ValidateErrMessage"] = "Not Defined";
                        }
                        else
                        {


                        }

                    }
                    string strControlTip = null;
                    if (!string.IsNullOrEmpty(oRow["ControlTip"].ToString()))
                        strControlTip = (string)oRow["ControlTip"];
  

                   


                    if (strInputType.ToUpper().Contains("TEXTBOX"))
                    {
                        AddUserInputControl(tRow, INPUT_TEXTBOX, strInputControlName, blnReqired, strFieldName, strEditValue, strInputControlOptions, strControlTip );
                    }
                    else
                        AddUserInputControl(tRow, INPUT_COMBOBOX, strInputControlName, blnReqired, strFieldName, strEditValue, strInputControlOptions, strControlTip);




                    if ((strFieldName.ToUpper().Contains("NOTE")) ||
                        (strFieldName.ToUpper().Contains("COMMENT")) ||
                        (strFieldName.ToUpper().Contains("GENERAL DESCRIPTION")))
                    {
                        if (!string.IsNullOrEmpty(Convert.ToString(oRow["ValidationErrMessage"])))
                        {
                            if (blnReqired)
                            {
                               

                               AddRowNotes(" * " + Convert.ToString(oRow["ValidationErrMessage"]), tRow);
                            }
                            else
                            {
                                AddRowNotes(Convert.ToString(oRow["ValidationErrMessage"]), tRow);
                                

                            }
                        }
                        else
                        {
                            if (blnReqired)
                            {

                                AddRowNotes(" * " + m_strNotAllowedChars, tRow);
                            }
                            else
                            {
                                AddRowNotes("Chars Not Allowed: " + m_strNotAllowedChars, tRow);

                            }

                        }

                    }
                    else
                    {
                        if (!string.IsNullOrEmpty(Convert.ToString(oRow["ValidationErrMessage"])))
                            AddRowNotes(Convert.ToString(oRow["ValidationErrMessage"]), tRow);
                    }

                }

            }

        }
        Session["RFQDetailControlRef"] = m_dt;

    }
    private string BuilDSQLCmd(string strValidation)
    {

        if (string.IsNullOrEmpty(strValidation)) return null; 

        if (strValidation.ToUpper().Contains("SELECT"))
            return strValidation;

        return "SELECT VALUE FROM " + strValidation; 



    }

    private string BuilDSQLCmd(object  objVar)
    {
        string strValidation=null;
        if (objVar != null)
        {
            strValidation = (string)objVar;

            if (strValidation.ToUpper().Contains("SELECT"))
                return strValidation;
        }


        return "SELECT VALUE FROM " + strValidation;



    }


    public class ItemTemplate : ITemplate
    {
        public void InstantiateIn(Control container)
        {

            PlaceHolder templatePlaceHolder = new PlaceHolder();
            container.Controls.Add(templatePlaceHolder);
            templatePlaceHolder.DataBinding += new EventHandler(DataBindTemplate);

            Literal divContainer = new Literal();
            divContainer.Text = "<div class=\"item\">";

            CheckBox CheckBox1 = new CheckBox();
            CheckBox1.ID = "CheckBox1";

            Literal innerContainer = new Literal();

            templatePlaceHolder.Controls.Add(divContainer);
            templatePlaceHolder.Controls.Add(CheckBox1);
            templatePlaceHolder.Controls.Add(innerContainer);
        }

        public void DataBindTemplate(object sender, EventArgs e)
        {
            PlaceHolder templatePlaceHolder = sender as PlaceHolder;
            ComboBoxItemTemlateContainer container = templatePlaceHolder.NamingContainer as ComboBoxItemTemlateContainer;
            ComboBoxItem item = (ComboBoxItem)container.Parent;


            

            Literal innerContainer = templatePlaceHolder.Controls[2] as Literal;

            innerContainer.Text = "<div class=\"label\">";
            //        innerContainer.Text += "<img src='resources/images/products/" + DataBinder.Eval(item.DataItem, "ImageName").ToString() + "' alt='' />";
            innerContainer.Text += DataBinder.Eval(item.DataItem, "Value").ToString();
            innerContainer.Text += "</div>";
            innerContainer.Text += "</div>";
        }
    }

}