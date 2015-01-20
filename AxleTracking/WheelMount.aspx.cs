using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Drawing;



public partial class WheelMount : System.Web.UI.Page
{
    ProcessTracking.AxleInformation objAxle = new ProcessTracking.AxleInformation();
    String strSQLCMD_GetLoadID = "SELECT [Load ID] FROM [Axle] Where [Tag ID] = ";
    String strSQLCMD_CheckTagID = "SELECT [Tag ID] FROM [WM Operation] Where [Tag ID] = ";
    String strSQLCMD_GetWheelTypeCode = "SELECT [Wheel Type ID] FROM [Wheel Type] Where [Description] = ";
    String strSQLCMD_GetBusinessRuleName = "SELECT [BusinessRule] FROM [Machines] Where [Machine ID] = ";

    const int RECORDFOUND = 1;
    const int RECORDNOTFOUND = 0;
    const int ERRORINSQLCMD = -1;

    ProcessTracking.CreateLogFiles LogTrace = new ProcessTracking.CreateLogFiles();
    ProcessTracking.DBFuncs objDB = new ProcessTracking.DBFuncs();
    bool m_blnDebug;
    String m_strBusinssRule;




    protected void Page_Load(object sender, EventArgs e)
    {
        objAxle = (ProcessTracking.AxleInformation)Session["AxleInfo"];
        lblOperatorName.Text = objAxle.OperatorID;
        m_blnDebug = Session["Debug"].ToString() == "Yes" ? true : false;
         
        // no access with user id
        if (objAxle.OperatorID == null) Response.Redirect("Login.aspx");
        if (objAxle.OperatorID == "") Response.Redirect("Login.aspx");
        m_strBusinssRule = objDB.GetDBStringValue(strSQLCMD_GetBusinessRuleName, objAxle.StationID);
        if (m_strBusinssRule == "")
        {
            m_strBusinssRule = "WheelMount";
        }


        if (!IsPostBack)
        {
            txbTagID.ForeColor = Color.Black;
 
            if (txbTagID.Text == "")
            {
                txbWheel_1_Barcode_1.Enabled = false;
                txbWheel_1_Barcode_2.Enabled = false;
                txbWheel_2_Barcode_1.Enabled = false;
                txbWheel_2_Barcode_2.Enabled = false;
      
                SetControlsState(false); 
            }

        
        }

    }


    private void TraceLog(String sMsg)
    {
        if (!m_blnDebug) return;
        LogTrace.TraceDBLog("WheelMount", sMsg);
    }


    private void SetControlsState(bool blnState)
    {

        if (!blnState)
        {

//            txbWheel_1_Barcode_1.Enabled = false;
//            txbWheel_1_Barcode_2.Enabled = false;
//           txbWheel_2_Barcode_1.Enabled = false;
//            txbWheel_2_Barcode_2.Enabled = false;
//            cmbWheelType.Enabled = false;
//            btnSummit.Enabled = false;

        }
        else
        {
            txbWheel_1_Barcode_1.Enabled = true;
            txbWheel_1_Barcode_2.Enabled = true;
            txbWheel_2_Barcode_1.Enabled = true;
            txbWheel_2_Barcode_2.Enabled = true;
            cmbWheelType.Enabled = true;
            btnSummit.Enabled = true;


        }

    }

    private String BuildAxleUpdateString()
    {
       
        String strSQLCMD_UpdateAxle;
        String csWheelType;

        csWheelType=objDB.GetDBStringValue(strSQLCMD_GetWheelTypeCode, cmbWheelType.Text);

        if (csWheelType == "")
        {
            TraceLog("Error Retrieving Wheel Type Code");
            return "";

        }

        strSQLCMD_UpdateAxle = "UPDATE [Axle] SET ";
        strSQLCMD_UpdateAxle += "[Wheel Status]  = '" + "Mounted" + "', ";
        strSQLCMD_UpdateAxle += "[Outbound Wheel Type]  = '" + csWheelType + "' ";
        strSQLCMD_UpdateAxle += "WHERE [Tag ID] = '" + txbTagID.Text + "' AND [Plant ID] = '" + objAxle.Plant_ID + "'";
        return strSQLCMD_UpdateAxle;
    }

    
    
    
    private String BuildUpdateString()
    {
        String strSQLCMD_UpdateWM;

        strSQLCMD_UpdateWM = "UPDATE [WM Operation] SET ";
        strSQLCMD_UpdateWM += "[Tag ID] = '" + txbTagID.Text    + "', ";
        strSQLCMD_UpdateWM += "[Plant ID]  = '" + objAxle.Plant_ID + "', ";
        strSQLCMD_UpdateWM += "[Machine ID]  = '" + objAxle.StationID + "', ";
        strSQLCMD_UpdateWM += "[WM Operator ID]  = '" + objAxle.OperatorID + "', ";
        strSQLCMD_UpdateWM += "[WM DT Stamp]  = '" + DateTime.Now.ToString() + "', ";
        strSQLCMD_UpdateWM += "[Wheel 1 Serial Number 1]  = '" + txbWheel_1_Barcode_1.Text + "', ";
        strSQLCMD_UpdateWM += "[Wheel 1 Serial Number 2]  = '" + txbWheel_1_Barcode_2.Text + "', ";
        strSQLCMD_UpdateWM += "[Wheel 2 Serial Number 1]  = '" + txbWheel_2_Barcode_1.Text + "', ";
        strSQLCMD_UpdateWM += "[Wheel 2 Serial Number 2]  = '" + txbWheel_2_Barcode_2.Text + "' ";
        strSQLCMD_UpdateWM += "WHERE [Tag ID] = '" + txbTagID.Text + "'";
        return strSQLCMD_UpdateWM;
    }



    private String BuildInsertString()
    {
        String strSQLCMD_InsertWheelMount;

        strSQLCMD_InsertWheelMount = "INSERT INTO [WM Operation] ";
        strSQLCMD_InsertWheelMount += "([Tag ID],";
        strSQLCMD_InsertWheelMount += "[Plant ID],";
        strSQLCMD_InsertWheelMount += "[Machine ID],";
        strSQLCMD_InsertWheelMount += "[WM Operator ID],";
        strSQLCMD_InsertWheelMount += "[WM DT Stamp],";
        strSQLCMD_InsertWheelMount += "[Wheel 1 Serial Number 1],";
        strSQLCMD_InsertWheelMount += "[Wheel 1 Serial Number 2],";
        strSQLCMD_InsertWheelMount += "[Wheel 2 Serial Number 1],";
        strSQLCMD_InsertWheelMount += "[Wheel 2 Serial Number 2]) VALUES (";

        strSQLCMD_InsertWheelMount += "'" + txbTagID.Text   + "',";
        strSQLCMD_InsertWheelMount += "'" + objAxle.Plant_ID + "',";
        strSQLCMD_InsertWheelMount += "'" + objAxle.StationID + "',";
        strSQLCMD_InsertWheelMount += "'" + objAxle.OperatorID + "',";
        strSQLCMD_InsertWheelMount += "'" + DateTime.Now.ToString() + "',";
        strSQLCMD_InsertWheelMount += "'" + txbWheel_1_Barcode_1.Text + "',";
        strSQLCMD_InsertWheelMount += "'" + txbWheel_1_Barcode_2.Text + "',";
        strSQLCMD_InsertWheelMount += "'" + txbWheel_2_Barcode_1.Text + "',";
        strSQLCMD_InsertWheelMount += "'" + txbWheel_2_Barcode_2.Text + "')";

        return strSQLCMD_InsertWheelMount;
    }


    
    protected void txbTagID_TextChanged(object sender, EventArgs e)
    {
        String csBuffer;

        txbTagID.Text.Trim();

        if (txbTagID.Text.Length == 0) return;

        if (!objDB.IsBRSatisfied(m_strBusinssRule, txbTagID.Text, objAxle.Plant_ID))
        {
            txbTagID.Text = "BR Failed";
            txbTagID.ForeColor = Color.Red; 
            return;
        }

        
        csBuffer = objDB.GetDBStringValue(strSQLCMD_GetLoadID, txbTagID.Text);

        if (csBuffer == "")
        {
            txbTagID.Text = "No Load ID Found!";
            txbTagID.ForeColor = Color.Red;
            SetControlsState(false);
            return;

        }
        else
        {
            SetControlsState(true);
            txbTagID.ForeColor = Color.Black; 

        }

    }
    private int GetNumberOfWheelSerialNumbers(int nWheelNumber)
    {
        int nCount = 0;
        switch (nWheelNumber) 
        {
            case 1:

                if (txbWheel_1_Barcode_1.Text != "") nCount++;
                if (txbWheel_1_Barcode_2.Text != "") nCount++;
                break;
            case 2:
                if (txbWheel_2_Barcode_1.Text != "") nCount++;
                if (txbWheel_2_Barcode_2.Text != "") nCount++;
                break;
            default:
                nCount = -1;
                break;
        };
        return nCount;
    }

    private int IsNewRecord(String csSQLCMD)
    {

        String csBuffer;

        if (csSQLCMD == "") return ERRORINSQLCMD;

        csBuffer = objDB.GetDBStringValue(csSQLCMD);
        if (csBuffer!="")
        {
            return RECORDFOUND; 

        }

        return RECORDNOTFOUND; 


    }

    private bool ProcessWMTable()
    {
        String csSQLCMD;
        int nNewRecordFound;

        csSQLCMD = strSQLCMD_CheckTagID + "'" + txbTagID.Text + "' AND [Plant ID] = '" + objAxle.Plant_ID + "'";
        
        nNewRecordFound = IsNewRecord(csSQLCMD);

        if (nNewRecordFound == RECORDFOUND)
        {
            csSQLCMD = BuildUpdateString();
        }
        else if (nNewRecordFound == RECORDNOTFOUND)
        {
            csSQLCMD = BuildInsertString();
        }
        else
        {
            return false;

        }


        if (!objDB.ExecuteSQLCMD(csSQLCMD))
        {
            SetControlsState(false);
            TraceLog("Error During Wheel Mount Operation");
            return false ;
        }
        return true;


    }

    private bool ProcessAxleTable()
    {
        String csSQLCMD;
        int nNewRecordFound;

        csSQLCMD = strSQLCMD_GetLoadID + "'" + txbTagID.Text + "' AND [Plant ID] = '" + objAxle.Plant_ID + "'";
        nNewRecordFound = IsNewRecord(csSQLCMD);


        if (nNewRecordFound == RECORDFOUND)
        {

            if (!objDB.ExecuteSQLCMD(BuildAxleUpdateString()))
            {
                SetControlsState(false);
                return false ;
            }
        }


        return true;

    }

    private bool TestWheelSerialNumbers()
    {

        if (txbWheel_1_Barcode_1.Text.Contains("Enter Serial Number")) return false;
        if (txbWheel_2_Barcode_1.Text.Contains("Enter Serial Number")) return false;
 
        int nNumberOfWheel_1_SerialNumbers = GetNumberOfWheelSerialNumbers(1);
        int nNumberOfWheel_2_SerialNumbers = GetNumberOfWheelSerialNumbers(2);

        if (nNumberOfWheel_1_SerialNumbers < 1)
        {
            txbWheel_1_Barcode_1.Text = "Enter Serial Number!";
            return false;
        }

        if (nNumberOfWheel_2_SerialNumbers < 1)
        {
            txbWheel_2_Barcode_1.Text = "Enter Serial Number!";
            return false;
        }
        if ((nNumberOfWheel_2_SerialNumbers > 2)||
            (nNumberOfWheel_1_SerialNumbers > 2))

        {
            txbTagID.Text = "Count Of Serial #'s Corrupt";
            return false;
        }
        return true; 

    }
    protected void cmbWheelType_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (cmbWheelType.Text != "")
        {
            txbWheel_1_Barcode_1.Enabled = true;
            txbWheel_1_Barcode_2.Enabled = true;
            txbWheel_2_Barcode_1.Enabled = true;
            txbWheel_2_Barcode_2.Enabled = true;
        }
        else
        {
            txbWheel_1_Barcode_1.Enabled = false;
            txbWheel_1_Barcode_2.Enabled = false;
            txbWheel_2_Barcode_1.Enabled = false;
            txbWheel_2_Barcode_2.Enabled = false;


        }
    }

    protected void btnSummit_Click(object sender, EventArgs e)
    {

        if (!TestWheelSerialNumbers())
        {
              SetControlsState(false);
              return;
        }


        if (!ProcessWMTable())
        {
              SetControlsState(false);
              txbTagID.Text = "Error With WM Table";
              return;
        }

        if (!ProcessAxleTable())
        {
            SetControlsState(false);
            txbTagID.Text = "Error With WM Table";
            return;
        }
                
        SetControlsState(false);
        txbTagID.Text = "";
        txbWheel_1_Barcode_1.Text = "";
        txbWheel_1_Barcode_2.Text = "";
        txbWheel_2_Barcode_1.Text = "";
        txbWheel_2_Barcode_2.Text = "";
        btnSummit.Enabled = false; 

    }


}
