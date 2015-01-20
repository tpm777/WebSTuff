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

public partial class OutBound : System.Web.UI.Page
{
    String strSQLCMD_GetLoadIDCounter = "SELECT [Counter] FROM [OBLoadIDCounter] Where [Plant ID] = ";
    String strSQLCMD_UpdateOBLoadIDCounter = "UPDATE [OBLoadIDCounter] SET [Counter] = ";
    String strSQLCMD_SetOBLoadID = "INSERT [OBLoadID] VALUES (";

    ProcessTracking.AxleInformation objAxle = new ProcessTracking.AxleInformation();

    ProcessTracking.CreateLogFiles LogTrace = new ProcessTracking.CreateLogFiles();
    ProcessTracking.DBFuncs objDB = new ProcessTracking.DBFuncs();
    bool m_blnDebug;
    static int m_nLoadCounter;
 
    
    protected void Page_Load(object sender, EventArgs e)
    {
        objAxle = (ProcessTracking.AxleInformation)Session["AxleInfo"];

        if (objAxle.OperatorID == null) Response.Redirect("Login.aspx");
        if (objAxle.OperatorID == "") Response.Redirect("Login.aspx");

        lblOperatorIDName.Text = objAxle.OperatorID;

        m_blnDebug = Session["Debug"].ToString() == "Yes" ? true : false;

    }

    private void TraceLog(String sMsg)
    {
        if (!m_blnDebug) return;
        LogTrace.TraceDBLog("OutBound", sMsg);
    }

    public string GetLoadID()
    {
        string strLoadID;

        int nCount = objDB.GetDBIntValue(strSQLCMD_GetLoadIDCounter,objAxle.Plant_ID );
        if (nCount < 0)
        {
            return "ERROR";
        }
        else
        {
            if (nCount > 999999)
            {
                nCount = 100000;

            }
            m_nLoadCounter = nCount + 1;
        }

        strLoadID = objAxle.Plant_ID + m_nLoadCounter.ToString();


        return strLoadID.Trim();
    }


    protected void btnSummit_Click(object sender, EventArgs e)
    {
        String strLoadID;
        // Need verify data function

        if (lblQuantity.Text.Contains("Q"))
        {


            // Does Tag ID exist

            strLoadID = GetLoadID();
            if (strLoadID.Length == 8)
            {
                
                strSQLCMD_SetOBLoadID += "'" + strLoadID + "',";
                strSQLCMD_SetOBLoadID += "'" + cmbCustomers.Text.Trim() + "',";
                strSQLCMD_SetOBLoadID += txbQuantity.Text + ")";
                objDB.ExecuteSQLCMD(strSQLCMD_SetOBLoadID);

                strSQLCMD_UpdateOBLoadIDCounter += m_nLoadCounter.ToString() + " Where [Plant ID] = '";
                strSQLCMD_UpdateOBLoadIDCounter += objAxle.Plant_ID + "'";

                objDB.ExecuteSQLCMD(strSQLCMD_UpdateOBLoadIDCounter);

                lblQuantity.Text = "LoadID";
                txbQuantity.Text = strLoadID;
 
            }



            // UpdateLoadCounter 
        }
        else
        {
            lblQuantity.Text = "Quantity";
            txbQuantity.Text = "";
        }
    
    }
}
