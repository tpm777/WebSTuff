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


public partial class RFQInputDetail : System.Web.UI.UserControl
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


    const int INPUT_TEXTBOX = 0;
    const int INPUT_COMBOBOX = 1;
    const int INPUTCOLUMNWIDTH = 220;
    const int TEXTBOXCELLWIDTH = 200;
    const int TEXTBOXNOTEHEIGHT = 500;

    
    const int DROPDOWNCELLWIDTH = 200;

    const int ALLOWABLEVALUESWIDTH = 350;

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

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            lblError.ForeColor = System.Drawing.Color.Red; 

        }
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

                    blnReqired = IsFieldRequired((string)oRow["Required"]);

                    if (!strInputType.ToUpper().Contains("TEXTBOX"))
                    {
                        if (!string.IsNullOrEmpty(Convert.ToString(oRow["Validation"])))
                        {
                            Session["SQLCMD"] = (string)oRow["Validation"];
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



                    if (strInputType.ToUpper().Contains("TEXTBOX"))
                    {
                        AddUserInputControl(tRow, INPUT_TEXTBOX, strInputControlName, blnReqired, strFieldName);
                    }
                    else
                        AddUserInputControl(tRow, INPUT_COMBOBOX, strInputControlName, blnReqired, strFieldName);

                    if (!string.IsNullOrEmpty(Convert.ToString(oRow["ValidationErrMessage"])))
                        AddRowNotes(Convert.ToString(oRow["ValidationErrMessage"]), tRow);

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
 
        lblDesc.Text = strLabelDesc;
        tCell.Controls.Add(lblDesc);
        
        

        tRow.Cells.Add(tCell);

    }
    private void AddRowNotes(string strLabelDesc, TableRow tRow)
    {
        TableCell tCell = new TableCell();
        Unit width = new Unit(ALLOWABLEVALUESWIDTH, UnitType.Pixel);  // need logic to calculate column width
        int nHeaderTextBoxFontSize = 10;
        tCell.Width = width;
        tCell.HorizontalAlign = HorizontalAlign.Left;
        tCell.BorderWidth = 0;

        tCell.Style.Value = "vertical-align:text-top;";

        Label lblDesc = new Label();

        lblDesc.BorderWidth = 0;
        lblDesc.Font.Size = FontUnit.Point(nHeaderTextBoxFontSize);    
        lblDesc.Text = strLabelDesc;
        tCell.Controls.Add(lblDesc);



        tRow.Cells.Add(tCell);

    }

    private void AddUserInputControl(TableRow tRow, int nType, string strInputID, bool blnRequired, string  strFieldName)
    {
        TableCell tCell = new TableCell();
        Unit width = new Unit(INPUTCOLUMNWIDTH, UnitType.Pixel);
        tCell.Width = width;
        tCell.HorizontalAlign = HorizontalAlign.Left;
        RFQGenericDB oDb = new RFQGenericDB();
        if (nType == INPUT_TEXTBOX)
        {

            // TextBox oControl = new TextBox();


            if (strFieldName.ToUpper().Contains("NOTE"))
            {
                FreeTextBox oControl = new FreeTextBox();
                oControl.Height = new Unit(TEXTBOXNOTEHEIGHT, UnitType.Pixel);
                oControl.Width = new Unit(TEXTBOXCELLWIDTH, UnitType.Pixel);
//                oControl. = TextBoxMode.MultiLine;
                oControl.EnableHtmlMode = true;
                oControl.BreakMode = BreakMode.Paragraph;

                oControl.PasteMode = FreeTextBoxControls.PasteMode.Text; 
                oControl.TextDirection= FreeTextBoxControls.TextDirection.LeftToRight   ;
                
  //              oControl.RenderMode = FreeTextBoxControls.RenderMode.Rich;
 
                oControl.ID = "NotetxbInput" + strInputID;
                //oControl.Attributes.Add("onBlur", "javascript:return ValidateText(RFQInputDetails_" + oControl.ID + ");");
                //oControl.Attributes.Add("onfocus", "javascript:return setStyle(RFQInputDetails_" + oControl.ID + ");");
                oControl.EnableToolbars = true; 
                tCell.Controls.Add(oControl);
                if (blnRequired)
                {
                    tCell.Controls.Add(BuildFieldRequiredLabel());
                }


            }
            else
            {
                TextBox oControl = new TextBox();

                oControl.Width = new Unit(TEXTBOXCELLWIDTH, UnitType.Pixel);
  
                    oControl.ID = "txbInput" + strInputID;
         //           oControl.Attributes.Add("onkeypress", "$('#" + lblError.ClientID + "').text('');");
                    oControl.Attributes.Add("onBlur", "javascript:return ValidateText(RFQInputDetails_" + oControl.ID + ");");
                    oControl.Attributes.Add("onfocus", "javascript:return setStyle(RFQInputDetails_" + oControl.ID + ");");


                oControl.Attributes.Add("Validate", (string)Session["ValidateString"]);
                oControl.Attributes.Add("ValErrMsg", (string)Session["ValidateErrMessage"]);

                tCell.Controls.Add(oControl);
                if (blnRequired)
                {
                    tCell.Controls.Add(BuildFieldRequiredLabel());
                }
            }

           tCell.ID = strInputID;

        }
        else
        {
            ComboBox oControl = new ComboBox();
//            oControl.SelectionMode = ListSelectionMode.Multiple;   
//            oControl.Width = new Unit(DROPDOWNCELLWIDTH, UnitType.Pixel); ;
           
//            DropDownList oControl = new DropDownList();
            oControl.Width = new Unit(DROPDOWNCELLWIDTH, UnitType.Pixel); 
           

            string strDataSource = (string)Session["SQLCMD"];

            if (!string.IsNullOrEmpty(strDataSource))
            {
                if (strDataSource.ToUpper().Contains("SELECT"))
                {
                    DataTable dt = oDb.GetRecordSet((string)Session["SQLCMD"]);

                    foreach (DataRow oRow in dt.Rows)
                    {
 //                       ListItem lstItem = new ListItem((string)oRow[0]);
                        ComboBoxItem lstItem = new ComboBoxItem((string)oRow[0]);

                        oControl.Items.Add(lstItem);
                    }
                }
            }
       //     oControl.DataSource  = dt;
       //     oControl.DataBind();
       //     oControl.Height = new Unit(DROPDOWNCELLWIDTH, UnitType.Pixel); ;
            tCell.Controls.Add(oControl);
            if (blnRequired)
            {
                tCell.Controls.Add(BuildFieldRequiredLabel());
            }

            tCell.ID = strInputID;


        }


        tCell.BorderWidth = 0;

        tRow.Cells.Add(tCell);

    }
    private Label BuildFieldRequiredLabel()
    {
        Label oLabel = new Label();
        oLabel.Text = "*";
        oLabel.Width = new Unit(5, UnitType.Pixel);
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
                CreateDynamicTable((string)Session["RFQType"], (string)Session["RFQSubType"]);
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
                            ((ComboBox)cell.Controls[0]).SelectedText  = txtValues[i++].ToString();

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

    protected void btnSaveRFQDetail_Click(object sender, EventArgs e)
    {
        string strErrorMessage = null;
        foreach (TableRow tr in Table1.Controls)
        {
            foreach (TableCell tc in tr.Controls)
            {

                if (tc.Controls[0] is TextBox)
                {
  
                    CreateRFQDetailRecord(tc.ID, ((TextBox)tc.Controls[0]).Text);

                }
                else if (tc.Controls[0] is FreeTextBox )
                {
                    //                 Response.Write(tc.ID + "=" + ((DropDownList)tc.Controls[0]).Text);
                    CreateRFQDetailRecord(tc.ID, ((FreeTextBox)tc.Controls[0]).Text);
                }
                else if (tc.Controls[0] is DropDownList)
                {
   //                 Response.Write(tc.ID + "=" + ((DropDownList)tc.Controls[0]).Text);
                    CreateRFQDetailRecord(tc.ID, ((DropDownList)tc.Controls[0]).Text);
                }
                else if (tc.Controls[0] is ComboBox )
                {
                    //                 Response.Write(tc.ID + "=" + ((DropDownList)tc.Controls[0]).Text);
                    ComboBox cmbTemp = (ComboBox)tc.Controls[0];
                    if (cmbTemp.SelectionMode != ListSelectionMode.Multiple)
                    {
                        CreateRFQDetailRecord(tc.ID, ((ComboBox)tc.Controls[0]).SelectedText);
                    }
                    else
                    {
                        string strTemp=null;
                        foreach (ComboBoxItem item in cmbTemp.Items)
                        {
                            if (item.Selected)
                            {

                                strTemp += item.Text;
                            }
                        }
                        CreateRFQDetailRecord(tc.ID, strTemp);
                    }

                }
            }
  
        }
        RFQHeaderDB oRFQHeader = new RFQHeaderDB((string)Session["UserID"]);

        if (!oRFQHeader.UpdateLastChanged(DateTime.Now.ToString(m_strDateTimeFormat), Convert.ToString(Session["RFQID"])))
        {
//            Response.Redirect(); 
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

    private bool CreateRFQDetailRecord(string strFieldRef, string strValue)
    {

        RFQDetail clsRFQDetail = new RFQDetail();
        string strInput = null;

        


        RFQType = (string)Session["RFQType"];
        RFQSubType = (string)Session["RFQSubType"];


 //       m_dt = (DataTable)Session["RFQDetailControlRef"];


   //     strInput = "1,1,1,Label,Blank," + strFieldRef + "," + strValue + "," + DateTime.Now + "," + "dave.petersen";

       if ( GetRFQControlInfo( strFieldRef))
       {

           strInput = string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},dave.petersen", RFQDetailID, RFQDetailLine, RFQDetailSequence, RFQType, RFQSubType, strFieldRef, RFQDetailFieldDescription,strValue, DateTime.Now);

     //       strInput =  "1,1,1," + RFQType + "," + RFQSubType + ","  + strFieldRef + "," + strValue + "," + DateTime.Now + "," + "dave.petersen";

            clsRFQDetail.SetInputArray(strInput);
            clsRFQDetail.CreateNewRFQDetailRecord();

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
        RFQDetailLine = (int) Session["RFQMAXLINE"];//(int)oRow[0]["Line"];
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
}