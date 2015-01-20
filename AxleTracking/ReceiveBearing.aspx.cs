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



public partial class ReceiveBearing : System.Web.UI.Page
{
    ProcessTracking.AxleInformation objAxle = new ProcessTracking.AxleInformation();
    String strSQLCMD_GetBearingType = "SELECT [Bearing Type ID] FROM [Bearing Type] Where [Description] = ";
    String strSQLCMD_GetBearingScrapCode = "SELECT [Scrap ID] FROM [Bearing Scrap] Where [Description] = ";

    ProcessTracking.CreateLogFiles LogTrace = new ProcessTracking.CreateLogFiles();
    ProcessTracking.DBFuncs objDB = new ProcessTracking.DBFuncs();
    bool m_blnDebug;



    protected void Page_Load(object sender, EventArgs e)
    {
        m_blnDebug = Session["Debug"].ToString() == "Yes" ? true : false;
        objAxle = (ProcessTracking.AxleInformation)Session["AxleInfo"];

        // no access with user id

        TraceLog("Begin Page_Load ");


        if (objAxle.OperatorID == null) Response.Redirect("Login.aspx");
        if (objAxle.OperatorID == "") Response.Redirect("Login.aspx");

        lblTagIDValue.Text = objAxle.TagID;
        lblOperatorIDName.Text = objAxle.OperatorID;

        if (Page.PreviousPage != null &&
               Page.PreviousPage.IsCrossPagePostBack)
        {

        }

        if (Page.IsPostBack)
        {

        }
        SetScrapReasonCombos();

    }

    private void TraceLog(String sMsg)
    {
        if (!m_blnDebug) return;
        LogTrace.TraceDBLog("ReceiveBearing", sMsg);
    }


    protected void Page_PreRenderComplete(object sender, EventArgs e)
    {
        if (!IsCallback)
        {


        }

    }

    private void SetScrapReasonCombos()
    {
        String csTest;
        csTest = cmbBearingStatus1.Text.ToUpper();
        if (csTest.Contains("SCRAP"))
        {

            cmbScrapReasonB1.Enabled = true;
        }
        else
        {
            cmbScrapReasonB1.Enabled = false;
            cmbScrapReasonB1.Text = ""; 
        }


        csTest = cmbBearingStatus2.Text.ToUpper();
        if (csTest.Contains("SCRAP"))
        {
            cmbScrapReasonB2.Enabled = true;
        }
        else
        {
            cmbScrapReasonB2.Enabled = false;
            cmbScrapReasonB2.Text = ""; 

        }

    }

    private bool VerifyData()
    {
        String csResult;
        string strBuffer;

        // Get Bearing Type


        if (!objDB.VerifyComboSelection(cmbBearingType))
        {
            TraceLog("Invalid Bearing Type");
            vldError.Text = "Invalid Bearing Type";
            vldError.IsValid = false;
            return false;
        }
        if (!objDB.VerifyComboSelection(cmbBearingStatus1))
        {
            TraceLog("Invalid Bearing 1 Status ");
            vldError.Text = "Invalid Bearing 1 Status";
            vldError.IsValid = false;
            return false;
        }


        strBuffer = cmbBearingStatus1.Text.ToUpper() ;
        if (strBuffer.Contains("SCRAP"))
        {
            if (!objDB.VerifyComboSelection(cmbScrapReasonB1))
            {
                TraceLog("Invalid Scrap Reason B1");
                vldError.Text = "Invalid Scrap Reason B1";
                vldError.IsValid = false;
                return false;
            }
        }

        if (!objDB.VerifyComboSelection(cmbBearingStatus2))
        {
            TraceLog("Invalid Bearing 2 Status ");
            vldError.Text = "Invalid Bearing 2 Status";
            vldError.IsValid = false;
            return false;
        }

        strBuffer = cmbBearingStatus2.Text.ToUpper() ;
        if (strBuffer.Contains("SCRAP"))
        {
            if (!objDB.VerifyComboSelection(cmbScrapReasonB2))
            {
                TraceLog("Invalid Scrap Reason B2");
                vldError.Text = "Invalid Scrap Reason B2";
                vldError.IsValid = false;
                return false;
            }
        }


        csResult = objDB.GetDBStringValue(strSQLCMD_GetBearingType, cmbBearingType.Text);
        if (csResult != "")
            objAxle.BearingType  = csResult;

        // Get Bearing Status

        objAxle.InboundBearing1_Status = cmbBearingStatus1.Text;
        objAxle.InboundBearing2_Status = cmbBearingStatus2.Text;

  
        // B1 Get Scrap Codes if Any
         
        if (cmbScrapReasonB1.Enabled)
        {
            csResult = objDB.GetDBStringValue(strSQLCMD_GetBearingScrapCode, cmbScrapReasonB1.Text);
            if (csResult != "")
                objAxle.InboundBearing1_ScrapCode  = csResult;
   
        }
        else
            objAxle.InboundBearing1_ScrapCode  = "";

        // B2 Get Scrap Codes if Any
        if (cmbScrapReasonB2.Enabled)
        {
            csResult = objDB.GetDBStringValue(strSQLCMD_GetBearingScrapCode, cmbScrapReasonB2.Text);
            if (csResult != "")
                objAxle.InboundBearing2_ScrapCode  = csResult;
        }
        else
            objAxle.InboundBearing2_ScrapCode  = "";

        return true;
    }


    protected void btnSummit_Click(object sender, EventArgs e)
    {

        if (VerifyData())
        {
            Session["AxleInfo"] = objAxle;
            Response.Redirect("~/ReceiveAxle.aspx"); 
        }
        else
        {
            TraceLog("Verify Data Failed");
            Session["AxleInfo"] = objAxle;

        }
    

    }

 
}