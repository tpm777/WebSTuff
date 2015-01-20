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
using System.Security.Principal;
using System.Data.SqlClient;

public partial class WheelDemount : System.Web.UI.Page
{
    ProcessTracking.AxleInformation objAxle = new ProcessTracking.AxleInformation();

//    String strSQLCMD_GetCustomerInfo = "SELECT [Inbound Customer] FROM [Axle] Where [Tag ID] = ";
    String strSQLCMD_CustomerName = "SELECT [Customer Name] FROM [Customers],[Axle] WHERE [Customers].[Customer Code] = [AXLE].[Inbound Customer] AND [Axle].[Tag ID] = ";

    String strSQLCMD_GetLoadID = "SELECT [Load ID] FROM [Axle] Where [Tag ID] = ";

    String strSQLCMD_GetBearingStaus = "SELECT [Bearing Status] FROM [Axle] Where [Tag ID] = ";
    String strSQLCMD_UpdateWheelStatus = "UPDATE [Axle] SET ";
    String strSQLCMD_GetBusinessRuleName = "SELECT [BusinessRule] FROM [Machines] Where [Machine ID] = ";


    ProcessTracking.CreateLogFiles LogTrace = new ProcessTracking.CreateLogFiles();
    ProcessTracking.DBFuncs objDB = new ProcessTracking.DBFuncs();
    bool m_blnDebug;
    String m_strBusinssRule;


    
    protected void Page_Load(object sender, EventArgs e)
    {
        m_blnDebug = Session["Debug"].ToString() == "Yes" ? true : false;
        objAxle = (ProcessTracking.AxleInformation)Session["AxleInfo"];

        m_strBusinssRule = objDB.GetDBStringValue(strSQLCMD_GetBusinessRuleName, objAxle.StationID);
        if (m_strBusinssRule == "")
        {
            m_strBusinssRule = "WheelDemount";
        }
      
        
        if (!IsPostBack)
        {
            cmbWheelStatusCode.Enabled = false;
            btnSummit.Enabled = false;
 

        }
    }
    protected void Page_PreRenderComplete(object sender, EventArgs e)
    {
        objAxle = (ProcessTracking.AxleInformation)Session["AxleInfo"];
   
        lblOperatorName.Text = objAxle.OperatorID;  

                
  
    }

    private void TraceLog(String sMsg)
    {
        if (!m_blnDebug) return;
        LogTrace.TraceDBLog("WheelDemount", sMsg);
    }


    private void SetControlsState(bool blnState)
    {
        if (blnState)
        {
            cmbWheelStatusCode.Enabled = true;
            btnSummit.Enabled = true; 
        }
        else
        {
            cmbWheelStatusCode.Enabled = false;

            lblCustomerName.Text = "";
            lblLoadIDValue.Text = "";
            btnSummit.Enabled = false ; 

        }
 

    }

    protected void txbTrackingID_TextChanged(object sender, EventArgs e)
    {
        String csBuffer;
        string strArg;
        string strSQLCMD;

        
        txbTagID.Text.Trim();

        if (txbTagID.Text.Length == 0) return;

        if (!objDB.IsBRSatisfied(m_strBusinssRule, txbTagID.Text, objAxle.Plant_ID))
        {

            txbTagID.Text = "BR Failed";
            return;

        }

        strArg = "'" + txbTagID.Text + "' AND [Plant ID] = " + "'" + objAxle.Plant_ID + "'";
        strSQLCMD = strSQLCMD_CustomerName + strArg;
        csBuffer = objDB.GetDBStringValue(strSQLCMD);


        if (csBuffer == "")
        {
            txbTagID.Text = "No Customer Information!";
            SetControlsState(false);
            return;

        }
        else
            lblCustomerName.Text  = csBuffer;

        if (!GetBearingStatus())
        {
            txbTagID.Text = "Bearings Not Removed!";
            SetControlsState(false);
            return;


        }

//        strSQLCMD_GetLoadID += "'" + txbTagID.Text + "'";
  
        
//        csBuffer = GetTableValue(strSQLCMD_GetLoadID);
        csBuffer = objDB.GetDBStringValue(strSQLCMD_GetLoadID, txbTagID.Text);  

        
        if (csBuffer == "")
        {
            txbTagID.Text = "No Load ID Information!";
            SetControlsState(false);
            return;

        }
        else
            lblLoadIDValue.Text = csBuffer;


        SetControlsState(true);
        btnSummit.Enabled = true;

    }

   

    private bool FindLoadIDIbScrapTable()
    {
    
        
        int nResult = 0;
        string strSQLCMD;
        strSQLCMD = "Select ScrapWheel From [ScrapStatistics] Where [LoadID] = ";
        strSQLCMD += "'" + lblLoadIDValue.Text + "' AND [Plant ID] = '" + objAxle.Plant_ID + "'";
        strSQLCMD += " AND [TagID] = '" + txbTagID.Text + "'";

        nResult = objDB.GetDBIntFValue(strSQLCMD, "ScrapWheel");

        if (nResult >= 0)
        {
            return true;
        }

        return false;

    }

    private void SetScrapCodeStatistics()
    {

        string strBuffer;
        string strSQLCMD = "";
        strBuffer = cmbWheelStatusCode.Text.ToUpper();
        if (strBuffer.Contains("NONE"))
        {
            if (!FindLoadIDIbScrapTable())
            {
                strSQLCMD = "INSERT INTO [ScrapStatistics] ";
                strSQLCMD += "([TagiD],[LoadID],[Plant ID],[ScrapAxle],[ScrapWheel],[ScrapBearing],[DateTimeStamp])";
                strSQLCMD += " VALUES( ";
                strSQLCMD += "'" + txbTagID.Text + "',";
                strSQLCMD += "'" + lblLoadIDValue.Text + "',";
                strSQLCMD += "'" + objAxle.Plant_ID + "',";
                strSQLCMD += "0,";
                strSQLCMD += "2,";
                strSQLCMD += "0,";
                strSQLCMD += "'" + DateTime.Now.ToString() + "')";

            }
            else
            {
                strSQLCMD = "UPDATE [ScrapStatistics] SET ";
                strSQLCMD += "[ScrapWheel] = " + "2" + " ";
                strSQLCMD += " WHERE [TagID] = ";
                strSQLCMD += "'" + txbTagID.Text + "' AND";
                strSQLCMD += " [LoadID] = ";
                strSQLCMD += "'" + lblLoadIDValue.Text + "' AND";
                strSQLCMD += " [Plant ID] = ";
                strSQLCMD += "'" + objAxle.Plant_ID + "'";

            }

        }




        if (strSQLCMD != "")
        {
            if (!objDB.ExecuteSQLCMD(strSQLCMD))
            {
                TraceLog("Error Updating Scrap Statistics Table");

            }

        }

    }
   
    
    
    
    
    
    private bool GetBearingStatus()
    {
        String csBuffer;
        bool blnBearingIsDemounted = false;


        csBuffer=objDB.GetDBStringValue(strSQLCMD_GetBearingStaus,txbTagID.Text);
        csBuffer = csBuffer.ToUpper(); 
        if (csBuffer.Contains("NONE"))
            blnBearingIsDemounted = true;

        return blnBearingIsDemounted;

    }



    protected void btnSummit_Click(object sender, EventArgs e)
    {

        String csSQLCMD;

        

        if (txbTagID.Text != "")
        {
            csSQLCMD = strSQLCMD_UpdateWheelStatus + " [Wheel Status] = '" + cmbWheelStatusCode.Text + "' WHERE [Tag Id] ='" + txbTagID.Text + "'";
            csSQLCMD += " AND [Plant ID] = " + "'" + objAxle.Plant_ID + "'"; 
            
            if (!objDB.ExecuteSQLCMD(csSQLCMD))
            {
                TraceLog("Error Updating Wheel Status");
                return;

            }


        }

        SetScrapCodeStatistics();

        txbTagID.Text = "";
        cmbWheelStatusCode.SelectedIndex = 0;
        cmbWheelStatusCode.Enabled = false;
        lblCustomerName.Text = "";
        lblLoadIDValue.Text = "";
        btnSummit.Enabled = false;


    }

}
