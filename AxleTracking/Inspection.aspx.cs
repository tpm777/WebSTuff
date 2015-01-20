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

public partial class Inspection : System.Web.UI.Page
{
    ProcessTracking.AxleInformation objAxle = new ProcessTracking.AxleInformation();
    ProcessTracking.CreateLogFiles LogTrace = new ProcessTracking.CreateLogFiles();
    ProcessTracking.DBFuncs objDB = new ProcessTracking.DBFuncs();
    bool m_blnDebug;
    string m_strBusinssRule;



    String m_csSQLCMD = "SELECT [Description] FROM [Machines] Where [Machine ID] = '";
    String strSQLCMD_CustomerName = "SELECT [Customer Name] FROM [Customers],[Axle] WHERE [Customers].[Customer Code] = [AXLE].[Inbound Customer] AND [Axle].[Tag ID] = ";
    String strSQLCMD_GetLoadID = "SELECT [Load ID] FROM [Axle] Where [Tag ID] = ";
    String strSQLCMD_UpdateInspectionStatus = "UPDATE [Axle] SET ";
    String strSQLCMD_GetBusinessRuleName = "SELECT [BusinessRule] FROM [Machines] Where [Machine ID] = ";



    protected void Page_Load(object sender, EventArgs e)
    {
        m_blnDebug = Session["Debug"].ToString() == "Yes" ? true : false;
        objAxle = (ProcessTracking.AxleInformation)Session["AxleInfo"];

        // no access with user id

        TraceLog("Begin Page_Load ");


        if (objAxle.OperatorID == null) Response.Redirect("Login.aspx");
        if (objAxle.OperatorID == "") Response.Redirect("Login.aspx");
        lblOperatorIDName.Text = objAxle.OperatorID;

        string csSQLCMD = m_csSQLCMD + objAxle.StationID + "'";
        lblTitle.Text = objDB.GetDBStringValue(csSQLCMD);

        m_strBusinssRule = objDB.GetDBStringValue(strSQLCMD_GetBusinessRuleName, objAxle.StationID);
        if (m_strBusinssRule == "")
        {
            m_strBusinssRule = "Inspection";
        }


        if (!IsPostBack) 
        {
            cmbInspectionStatus.Enabled =false; 
            btnSummit.Enabled = false;


        }


    }

    protected void Page_PreRenderComplete(object sender, EventArgs e)
    {
        if (!IsCallback)
        {
            GetCustomerInfo();
            GetLoadIDInfo();
        }

    }
    private void TraceLog(String sMsg)
    {
        if (!m_blnDebug) return;
        LogTrace.TraceDBLog("Inspection", sMsg);
    }

    protected void txbTagID_TextChanged(object sender, EventArgs e)
    {
        // Get Customer and Load ID information associated with Tag ID

        if (txbTagID.Text == null) return;
        if (txbTagID.Text == "") return;


        if (!objDB.IsBRSatisfied(m_strBusinssRule, txbTagID.Text, objAxle.Plant_ID))
        {

            txbTagID.Text = "BR Failed";
            return;

        }

            // First Customer Information
        GetCustomerInfo();
        GetLoadIDInfo();
        

    }
    private void GetCustomerInfo()
    {
        String csBuffer;   
        if (txbTagID.Text == null) return;
        if (txbTagID.Text == "") return;

        csBuffer = objDB.GetDBStringValue(strSQLCMD_CustomerName, txbTagID.Text);

        if (csBuffer.Length>0)
        {
            cmbInspectionStatus.Enabled =true;
            lblCustomerName.Text = csBuffer; 
            btnSummit.Enabled = true;

        }
        else
        {
            
            txbTagID.Text = "Error Customer Info Not Found";
            TraceLog(txbTagID.Text);
            cmbInspectionStatus.Enabled =false;
            lblCustomerName.Text = "";
            btnSummit.Enabled = false;
        }

    



    }
    private void GetLoadIDInfo()
    {
        String csBuffer;

        if (txbTagID.Text == null) return;
        if (txbTagID.Text == "") return;



        // Get Load ID Information
        csBuffer = objDB.GetDBStringValue(strSQLCMD_GetLoadID, txbTagID.Text);


        if (csBuffer.Length > 0)
        {

            cmbInspectionStatus.Enabled = true;
            lblLoadIDValue.Text = csBuffer;  
            btnSummit.Enabled = true;

        }
        else
        {
            txbTagID.Text = "Error Customer Info Not Found";
            TraceLog(txbTagID.Text);
            cmbInspectionStatus.Enabled = false;
            btnSummit.Enabled = false;
            lblLoadIDValue.Text = "";  


        }


    }

    private bool FindLoadIDIbScrapTable()
    {


        int nResult = 0;
        string strSQLCMD;
        strSQLCMD = "Select ScrapAxle From [ScrapStatistics] Where [LoadID] = ";
        strSQLCMD += "'" + lblLoadIDValue.Text + "' AND [Plant ID] = '" + objAxle.Plant_ID + "'";
        strSQLCMD += " AND [TagID] = '" + txbTagID.Text + "'";

        nResult = objDB.GetDBIntFValue(strSQLCMD, "ScrapAxle");

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


        strBuffer = cmbInspectionStatus.Text.ToUpper();
        if (strBuffer.Contains("FAIL"))
        {
            if (!FindLoadIDIbScrapTable())
            {
                strSQLCMD = "INSERT INTO [ScrapStatistics] ";
                strSQLCMD += "([TagiD],[LoadID],[Plant ID],[ScrapAxle],[ScrapWheel],[ScrapBearing],[DateTimeStamp])";
                strSQLCMD += " VALUES( ";
                strSQLCMD += "'" + txbTagID.Text + "',";
                strSQLCMD += "'" + lblLoadIDValue.Text + "',";
                strSQLCMD += "'" + objAxle.Plant_ID + "',";
                strSQLCMD += "1,";
                strSQLCMD += "0,";
                strSQLCMD += "0,";
                strSQLCMD += "'" + DateTime.Now.ToString() + "')";

            }
            else
            {
                strSQLCMD = "UPDATE [ScrapStatistics] SET ";
                strSQLCMD += "[ScrapAxle] = " + "1" + " ";
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



    protected void btnSummit_Click(object sender, EventArgs e)
    {
        string csSQLCMD;


        csSQLCMD = strSQLCMD_UpdateInspectionStatus + " [Axle Status Code]= '" + cmbInspectionStatus.Text + "' ";
        csSQLCMD+= " WHERE [Tag Id] ='" + txbTagID.Text + "' AND [Plant ID] = '" +objAxle.Plant_ID +"'" ;

        if (!objDB.ExecuteSQLCMD(csSQLCMD))
        {

            TraceLog("Error Updating Axle Table"); 

        }
        SetScrapCodeStatistics(); 

        cmbInspectionStatus.Enabled = false;
        cmbInspectionStatus.Text = "";

        lblLoadIDValue.Text = "";
        lblCustomerName.Text = "";
 
        txbTagID.Text =""; 


    }


}
