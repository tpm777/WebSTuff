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
using System.Security.Principal;
using System.Threading;

public partial class BearingDemount : System.Web.UI.Page
{
//    String strSQLCMD_GetStatusCode = "SELECT [Scrap ID] FROM [Bearing Scrap] Where [Description] = ";
 //   String strSQLCMD_GetCustomerInfo = "SELECT [Inbound Customer] FROM [Axle] Where [Tag ID] = ";
    String strSQLCMD_CustomerName = "SELECT [Customer Name] FROM [Customers],[Axle] WHERE [Customers].[Customer Code] = [AXLE].[Inbound Customer] AND [Axle].[Tag ID] = ";
    String strSQLCMD_GetLoadID = "SELECT [Load ID] FROM [Axle] Where [Tag ID] = ";

    String strSQLCMD_GetInB1SC = "SELECT [Inbound Bearing 1 Scrap Code] FROM [Axle] Where [Tag ID] = ";
    String strSQLCMD_GetInB2SC = "SELECT [Inbound Bearing 2 Scrap Code] FROM [Axle] Where [Tag ID] = ";
    String strSQLCMD_GetBusinessRuleName = "SELECT [BusinessRule] FROM [Machines] Where [Machine ID] = ";

    
    
    String strSQLCMD_UpdateBDStatus =  "UPDATE [Axle] SET ";
    ProcessTracking.AxleInformation objAxle = new ProcessTracking.AxleInformation();

    ProcessTracking.CreateLogFiles LogTrace = new ProcessTracking.CreateLogFiles();
    ProcessTracking.DBFuncs objDB = new ProcessTracking.DBFuncs();
    bool m_blnDebug;

    string m_strBusinssRule;



    protected void Page_Load(object sender, EventArgs e)
    {

        m_blnDebug = Session["Debug"].ToString() == "Yes" ? true : false;

        objAxle = (ProcessTracking.AxleInformation)Session["AxleInfo"];
        // no access with user id
        if (objAxle.OperatorID == null) Response.Redirect("Login.aspx");
        if (objAxle.OperatorID == "")   Response.Redirect("Login.aspx"); 


        lblOperatorName.Text = objAxle.OperatorID;
        btnSummit.Enabled = false;
        cmBearingStatus.Enabled = false;

        m_strBusinssRule = objDB.GetDBStringValue(strSQLCMD_GetBusinessRuleName, objAxle.StationID);

        if (m_strBusinssRule == "")
        {
            m_strBusinssRule = "BearingDemount";
        }


        

    }

    private void TraceLog(String sMsg)
    {
        if (!m_blnDebug) return;
        LogTrace.TraceDBLog("BearingDemount", sMsg);
    }


    protected void Page_PreRenderComplete(object sender, EventArgs e)
    {
        if (!IsCallback)
        {
            GetCustomerInfo();
            GetLoadIDInfo();
        }

    }

 
    protected void txbTrackingID_TextChanged(object sender, EventArgs e)
    {
        // Get Customer and Load ID information associated with Tag ID

        if (txbTrackingID.Text == null) return;
        if (txbTrackingID.Text == "") return;


        if (!objDB.IsBRSatisfied(m_strBusinssRule, txbTrackingID.Text, objAxle.Plant_ID))
        {
           
            txbTrackingID.Text="BR Failed";
            return;
            
        }

        
        
        // First Customer Information


        GetCustomerInfo();
        GetLoadIDInfo();
        

    }
    private void GetCustomerInfo()
    {
        String csBuffer;   
        if (txbTrackingID.Text == null) return;
        if (txbTrackingID.Text == "") return;

        string strArg;
        string strSQLCMD;

        strArg = "'"+ txbTrackingID.Text + "' AND [Plant ID] = " +"'" +objAxle.Plant_ID +"'";
        strSQLCMD = strSQLCMD_CustomerName + strArg;
        csBuffer = objDB.GetDBStringValue(strSQLCMD);

        if (csBuffer.Length>0)
        {
            lblCustomerName.Text = csBuffer;
            lblCustomerName.Visible =true;
            lblCustomer.Visible =true;
            btnSummit.Enabled = true;
            cmBearingStatus.Enabled = true; 

        }
        else
        {
            TraceLog("Error Customer Info Not Found");

            lblCustomerName.Text = "Customer Not Found";
            lblLoadIDName.Text = "";
            lblLoadIDValue.Text = "";
            btnSummit.Enabled = false;
            cmBearingStatus.Enabled = false; 

        }

    }

    private void GetLoadIDInfo()
    {
        String csBuffer;

        if (txbTrackingID.Text == null) return;
        if (txbTrackingID.Text == "") return;
 


        // Get Load ID Information
        csBuffer = objDB.GetDBStringValue(strSQLCMD_GetLoadID, txbTrackingID.Text);


        if (csBuffer.Length > 0)
        {
            lblLoadIDName.Visible = true;
            lblLoadIDName.Text = "Load ID";
            lblLoadIDValue.Text = csBuffer;

        }
        else
        {
            TraceLog("Error Load ID Not Found");

            lblCustomerName.Text = "";
            lblLoadIDValue.Text = "Load ID Not Found";
            cmBearingStatus.SelectedIndex = 0;


        }


    }
    

    private int GetCountOfBearingsScrap()
    {
        string strBuffer;
        int nCount = 0;
        strBuffer = objDB.GetDBStringValue(strSQLCMD_GetInB1SC, txbTrackingID.Text);
        if (strBuffer != "")
        {
            nCount += 1;
        }

        strBuffer = objDB.GetDBStringValue(strSQLCMD_GetInB2SC, txbTrackingID.Text);
        if (strBuffer != "")
        {
            nCount += 1;
        }
        return nCount;
    }

    private bool FindLoadIDIbScrapTable()
    {
        int nResult=0;
        string strSQLCMD;
        strSQLCMD= "Select ScrapBearing From [ScrapStatistics] Where [LoadID] = ";
        strSQLCMD+="'"+lblLoadIDValue.Text +"' AND [Plant ID] = '" +objAxle.Plant_ID +"'";
        strSQLCMD += " AND [TagID] = '" + txbTrackingID.Text  + "'";

        nResult = objDB.GetDBIntFValue(strSQLCMD, "ScrapBearing");

        if (nResult > 0)
        {
            return true;
        }

        return false;

    }

    private void SetScrapCodeStatistics()
    {
        int nCountofBSC=GetCountOfBearingsScrap();
        if (nCountofBSC==0) return;

        string strBuffer;
        string strSQLCMD = "";
        strBuffer = cmBearingStatus.Text.ToUpper();
        if (strBuffer.Contains("NONE"))
        {
            if (!FindLoadIDIbScrapTable())
            {
                strSQLCMD = "INSERT INTO [ScrapStatistics] ";
                strSQLCMD += "([TagiD],[LoadID],[Plant ID],[ScrapAxle],[ScrapWheel],[ScrapBearing],[DateTimeStamp])";
                strSQLCMD += " VALUES( ";
                strSQLCMD += "'" + txbTrackingID.Text   + "',";
                strSQLCMD += "'" + lblLoadIDValue.Text + "',";
                strSQLCMD += "'" + objAxle.Plant_ID + "',";
                strSQLCMD += "0,";
                strSQLCMD += "0,";
                strSQLCMD += nCountofBSC.ToString() + ",";
                strSQLCMD += "'" + DateTime.Now.ToString() + "')";

            }
            else
            {
                strSQLCMD = "UPDATE [ScrapStatistics] SET ";
                strSQLCMD += "[ScrapBearing] = " + nCountofBSC.ToString() + " ";
                strSQLCMD += " WHERE [TagID] = ";
                strSQLCMD += "'" + txbTrackingID.Text  + "' AND";
                strSQLCMD += " [LoadID] = ";
                strSQLCMD += "'" + lblLoadIDValue.Text + "' AND";
                strSQLCMD += " [Plant ID] = ";
                strSQLCMD += "'" + objAxle.Plant_ID + "'";

            }

        }
     
        
        
        
        if (strSQLCMD != "")
        {
            if(!objDB.ExecuteSQLCMD(strSQLCMD))
            {
                TraceLog("Error Updating Scrap Statistics Table"); 

            }

        }

    }

    protected void btnSummit_Click(object sender, EventArgs e)
    {
        String csSQLCMD;
        if (txbTrackingID.Text == "") return;
        if (txbTrackingID.Text == null) return;


       csSQLCMD = strSQLCMD_UpdateBDStatus + " [Bearing Status]= '" + cmBearingStatus.Text + "' WHERE [Tag Id] ='" + txbTrackingID.Text + "'";

       csSQLCMD+= " AND [Plant ID] = "+"'" +objAxle.Plant_ID +"'"; 

       if (!objDB.ExecuteSQLCMD(csSQLCMD))
       {
           TraceLog("Error Updating Bearing Status");
           return;

       }

       SetScrapCodeStatistics();

        txbTrackingID.Text = "";
        lblLoadIDValue.Text = "";
        lblCustomerName.Text = "";
        cmBearingStatus.SelectedIndex = 0;
        cmBearingStatus.Enabled = false;


    }


}
