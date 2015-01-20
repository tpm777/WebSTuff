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


public partial class BearingMount : System.Web.UI.Page
{
    String strSQLCMD_GetStatusCode = "SELECT [Bearing Type ID] FROM [Bearing Type] Where [Description] = ";
    ProcessTracking.AxleInformation objAxle = new ProcessTracking.AxleInformation();
    String strSQLCMD_CustomerName = "SELECT [Customer Name] FROM [Customers],[Axle] WHERE [Customers].[Customer Code] = [AXLE].[Inbound Customer] AND [Axle].[Tag ID] = ";
  
    String strSQLCMD_GetLoadID = "SELECT [Load ID] FROM [Axle] Where [Tag ID] = ";
    String strSQLCMD_UpdateBDStatus = "UPDATE [Axle] SET ";
    String strSQLCMD_GetBearingStaus = "SELECT [Bearing Status] FROM [Axle] Where [Tag ID] = ";
    String strSQLCMD_GetBearingRuleName = "SELECT [BusinessRule] FROM [Machines] Where [Machine ID] = ";



    ProcessTracking.CreateLogFiles LogTrace = new ProcessTracking.CreateLogFiles();
    ProcessTracking.DBFuncs objDB = new ProcessTracking.DBFuncs();
    bool m_blnDebug;
    string m_strBusinssRule;

    
    protected void Page_Load(object sender, EventArgs e)
    {
        objAxle = (ProcessTracking.AxleInformation)Session["AxleInfo"];

        if (objAxle.OperatorID == null) Response.Redirect("Login.aspx");
        if (objAxle.OperatorID == "") Response.Redirect("Login.aspx"); 

        lblOperatorName.Text = objAxle.OperatorID;

        m_blnDebug = Session["Debug"].ToString() == "Yes" ? true : false;

        m_strBusinssRule = objDB.GetDBStringValue(strSQLCMD_GetBearingRuleName, objAxle.StationID);

        if (m_strBusinssRule == "")
        {
            m_strBusinssRule = "BearingMount";
        }


        txbTagID.Focus(); 

    }

    private void TraceLog(String sMsg)
    {
        if (!m_blnDebug) return;
        LogTrace.TraceDBLog("BearingMount", sMsg);
    }

    protected void Page_PreRenderComplete(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            cmbBearingType.Enabled = false;

        }
     

    }




    protected void Page_UnLoad(object sender, EventArgs e)
    {
        if (IsPostBack)
        {
            // test code ..page life cycle
            // String csTest = "here";
            
        }
    }

    private String GetStatusCode(String csStatusDescription)
    {
        String csStatusCode = "";

        csStatusCode = objDB.GetDBStringValue(strSQLCMD_GetStatusCode, csStatusDescription);

        return csStatusCode;

    }

    protected void txbTagID_TextChanged(object sender, EventArgs e)
    {
          String csBuffer;

//        SetCustomerInfo();

        txbTagID.Text.Trim();
   
        if(txbTagID.Text.Length==0)return;


        if (!objDB.IsBRSatisfied(m_strBusinssRule, txbTagID.Text, objAxle.Plant_ID))
        {

            txbTagID.Text = "BR Failed";
            return;

        }



        csBuffer = objDB.GetDBStringValue(strSQLCMD_CustomerName, txbTagID.Text);
        if (csBuffer.Length > 0)
        {

            if (!GetBearingStatus())
            {
                txbTagID.Text = "Bearings Not Removed";
                lblCustomerName.Text = "";
                lblLoadIDValue.Text = "";
                cmbBearingType.SelectedIndex = 0;
                btnSummit.Enabled = false;
                cmbBearingType.Enabled = false;
            

                return;

            }

            lblCustomerName.Text = csBuffer;
            btnSummit.Enabled = true;
            cmbBearingType.Enabled = true;

        
        }
        else
        {
            lblCustomerName.Text = "";
            lblLoadIDValue.Text = "";
            cmbBearingType.SelectedIndex = 0;
            btnSummit.Enabled = false;
            cmbBearingType.Enabled = false;


        }

        csBuffer = objDB.GetDBStringValue(strSQLCMD_GetLoadID, txbTagID.Text);

        if (csBuffer.Length > 0)
        {

            lblLoadIDValue.Text = csBuffer;
            cmbBearingType.Enabled = true;
          


        }
        else
        {
            lblCustomerName.Text = "";
            lblLoadIDValue.Text = "";

        }


    }

    private bool GetBearingStatus()
    {
        String csBearingStatus="";
        bool blnBearingIsDemounted = false; 

        csBearingStatus=objDB.GetDBStringValue(strSQLCMD_GetBearingStaus, txbTagID.Text);

        csBearingStatus=csBearingStatus.ToUpper();

        if (csBearingStatus.Contains("NONE"))
            blnBearingIsDemounted=true; 

        return blnBearingIsDemounted;

    }

    protected void btnSummit_Click(object sender, EventArgs e)
    {
        String csSQLCMD;
        String csTest;

        csTest = cmbBearingType.Text;
        csTest.ToUpper();
        string strBearingType = GetStatusCode(cmbBearingType.Text);

        if (!csTest.Contains("SCRAP"))
        {
            csSQLCMD = strSQLCMD_UpdateBDStatus + " [Bearing Status]='Mounted' WHERE [Tag Id] ='" + txbTagID.Text + "' And [Plant ID] = '" +objAxle.Plant_ID +"'"  ;
            
            if(!objDB.ExecuteSQLCMD(csSQLCMD))
            {
                TraceLog("Error In Setting Mounted Status For ");

            }

            // Now define outbound bearing type
            csSQLCMD = strSQLCMD_UpdateBDStatus + " [Outbound Bearing Type] = '" + strBearingType + "' WHERE [Tag Id] ='" + txbTagID.Text + "' And [Plant ID] = '" + objAxle.Plant_ID + "'";
            objDB.ExecuteSQLCMD(csSQLCMD); 



        }
        txbTagID.Text = "";
        lblLoadIDValue.Text = "";
        lblCustomerName.Text = "";
        cmbBearingType.SelectedIndex = 0;
        cmbBearingType.Enabled = false;
    }


}
