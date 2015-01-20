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

public partial class ReceiveWheel : System.Web.UI.Page
{
    String strSQLCMD_GetWheelStatusCode = "SELECT [Scrap ID] FROM [Wheel Scrap] Where [Description] = ";

    ProcessTracking.AxleInformation objAxle = new ProcessTracking.AxleInformation();
    ProcessTracking.CreateLogFiles LogTrace = new ProcessTracking.CreateLogFiles();
    ProcessTracking.DBFuncs objDBFuncs = new ProcessTracking.DBFuncs(); 

    bool m_blnDebug;

    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Cache.SetCacheability(HttpCacheability.NoCache);

        m_blnDebug = Session["Debug"].ToString() == "Yes" ? true : false;
        
        objAxle = (ProcessTracking.AxleInformation)Session["AxleInfo"];

        // no access with user id
        if (objAxle.OperatorID == null) Response.Redirect("Login.aspx");
        if (objAxle.OperatorID == "") Response.Redirect("Login.aspx");


        lblTagIDValue.Text = objAxle.TagID;
        lblOperatorIDName.Text = objAxle.OperatorID;
    }

    private void TraceLog(String sMsg)
    {
        if (!m_blnDebug) return;
        LogTrace.TraceDBLog("ReceiveWheel", sMsg);  
    }

    private void SetScrapControls()
    {
        TraceLog("Begin SetScrapControls");

        String csBuffer;
        csBuffer = cmbWheelStatus.Text;
        csBuffer = csBuffer.ToUpper(); 
        if (csBuffer.Contains("SCRAP"))
        {
            lblReason.Visible = true;
            cmbScrapReason.Visible = true;

        }
        else
        {
            lblReason.Visible = false;
            cmbScrapReason.Visible = false;

        }

    }

    protected void Page_PreRenderComplete(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
    
            SetScrapControls();

        }

    }



    protected void cmbWheelStatus_SelectedIndexChanged(object sender, EventArgs e)
    {
        SetScrapControls();
    }

    protected bool Verify()
    {
        string csBuffer;
        if (cmbWheelType.Text == "")
        {
            TraceLog("Wheel Type not Given");
            vldError.Text = "Wheel Type not Given";
            vldError.IsValid = false;
            return false;
        }

        
        if (!objDBFuncs.VerifyComboSelection(cmbWheelType))
        {
            TraceLog("Wheel Type Not Found");
            vldError.Text="Wheel Type Not Found";  
            vldError.IsValid = false;
            return false;
        }


        if (cmbWheelStatus.Text == "")
        {
            TraceLog("Wheel Status not Given");
            vldError.Text = "Wheel Status not Given";
            vldError.IsValid = false;
            return false;
        }

        csBuffer=cmbWheelStatus.Text.ToUpper();
        if ((csBuffer.Contains("SCRAP")) && (cmbScrapReason.Text == ""))
        {
            TraceLog("Scrap Reason Not Given");
            vldError.Text = "Scrap Reason Not Given";
            vldError.IsValid = false;
            return false;


        }
 
        return true; 

    }
    protected void btnSummit_Click(object sender, EventArgs e)
    {
        String csBuffer;

        if (!Verify())
            return;
        objAxle.WheelType = cmbWheelType.Text;
        objAxle.InboundWheelStatus = cmbWheelStatus.Text;
        objAxle.WheelStatus = "Mounted";

        if (cmbScrapReason.Visible)
        {
            
            
            // Get Wheel Scrap from scrap code description
            csBuffer = objDBFuncs.GetDBStringValue(strSQLCMD_GetWheelStatusCode, cmbScrapReason.Text);
            if (csBuffer == "")
            {
                TraceLog("Error In cmbWheelStatus_SelectedIndexChanged");
                objAxle.ReceivedWheels = false;
                return;
            }
            objAxle.InboundWheelScrapCode = csBuffer;

        }

        objAxle.ReceivedWheels = true;
        Session["AxleInfo"] = objAxle;

        Response.Redirect("~/ReceiveAxle.aspx"); 


    }
    protected void vldError_ServerValidate(object source, ServerValidateEventArgs args)
    {
 //       if (!Verify())
 //           vldError.ErrorMessage = "Wheel Type Not Found";
        vldError.IsValid = false;
        args.IsValid = false;

        vldError.Text = "Wheel Type Not Found";
        vldError.IsValid = false;
      

    }
}
