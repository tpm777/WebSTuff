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

public partial class OBAxles : System.Web.UI.Page
{
    ProcessTracking.AxleInformation objAxle = new ProcessTracking.AxleInformation();
    ProcessTracking.CreateLogFiles LogTrace = new ProcessTracking.CreateLogFiles();
    ProcessTracking.DBFuncs objDB = new ProcessTracking.DBFuncs();

    bool m_blnDebug;
    string m_strAxleType;
    string m_strLoadID;
    string m_strInCustomerID;

    string m_strBearingType;
    string m_strWheelType;
    string m_strWheel_1_Serial_Number_1;
    string m_strWheel_1_Serial_Number_2;
    string m_strWheel_2_Serial_Number_1;
    string m_strWheel_2_Serial_Number_2;


    String strSQLCMD_AxleType = "SELECT [Inbound Axle Type] FROM [Axle] WHERE [Tag ID] = ";
    String strSQLCMD_WheelType = "SELECT [Outbound Wheel Type] FROM [Axle] WHERE [Tag ID] = ";
    String strSQLCMD_BearingType = "SELECT [Outbound Bearing Type] FROM [Axle] WHERE [Tag ID] = ";
    String strSQLCMD_CountOfTagIDs = "SELECT [OBLoadID] FROM [OBAxle] WHERE [OBLoadID] = ";
    String strSQLCMD_GetLoadID = "SELECT [Load ID] FROM [Axle] Where [Tag ID] = ";



    String strSQLCMD_W1S1 = "SELECT [Wheel 1 Serial Number 1] FROM [WM Operation] WHERE [Tag ID] = ";
    String strSQLCMD_W1S2 = "SELECT [Wheel 1 Serial Number 2] FROM [WM Operation] WHERE [Tag ID] = ";
    String strSQLCMD_W2S1 = "SELECT [Wheel 2 Serial Number 1] FROM [WM Operation] WHERE [Tag ID] = ";
    String strSQLCMD_W2S2 = "SELECT [Wheel 1 Serial Number 2] FROM [WM Operation] WHERE [Tag ID] = ";

    protected void Page_Load(object sender, EventArgs e)
    {
        m_blnDebug = Session["Debug"].ToString() == "Yes" ? true : false;

        objAxle = (ProcessTracking.AxleInformation)Session["AxleInfo"];
        // no access with user id
        if (objAxle.OperatorID == null) Response.Redirect("Login.aspx");
        if (objAxle.OperatorID == "") Response.Redirect("Login.aspx");
        lblOperatorIDName.Text = objAxle.OperatorID;
        btnSummit.Enabled = false;

        if (IsPostBack)
        {

            QuantityCounter();
        }
        else
        {
            btnSummit.Enabled = false;

        }



    }
    protected void Page_PreRenderComplete(object sender, EventArgs e)
    {
        if (IsPostBack)
        {
            QuantityCounter();
        }

    }


    private void TraceLog(String sMsg)
    {
        if (!m_blnDebug) return;
        LogTrace.TraceDBLog("OBAxles", sMsg);
    }


    private bool GetAxleInfo()
    {
        // Init vars
        m_strAxleType = "";
        m_strBearingType = "";
        m_strWheelType = "";

        m_strAxleType = objDB.GetDBStringValue(strSQLCMD_AxleType, txbTagID.Text);
        if (m_strAxleType == "")
        {
            TraceLog("Axle Type Not Found");
            return false;
        }

        m_strBearingType = objDB.GetDBStringValue(strSQLCMD_BearingType, txbTagID.Text);
        if (m_strBearingType == "")
        {
            TraceLog("Bearing Type Not Found");
            return false;
        }

        m_strWheelType = objDB.GetDBStringValue(strSQLCMD_WheelType, txbTagID.Text);
        if (m_strWheelType == "")
        {
            TraceLog("Wheel Type Not Found");
            return false;
        }

        return true;
    }

    private void GetWheelSerialNumbers()
    {
        string csSQLCMD;
        m_strWheel_1_Serial_Number_1 = "";
        m_strWheel_1_Serial_Number_2 = "";
        m_strWheel_2_Serial_Number_1 = "";
        m_strWheel_2_Serial_Number_2 = "";


        csSQLCMD = strSQLCMD_W1S1 + "'" + txbTagID.Text + "' AND [Plant ID] = " + "'" + objAxle.Plant_ID + "'";
        m_strWheel_1_Serial_Number_1 = objDB.GetDBStringValue(csSQLCMD).Trim(); ;

        csSQLCMD = strSQLCMD_W1S2 + "'" + txbTagID.Text + "' AND [Plant ID] = " + "'" + objAxle.Plant_ID + "'";
        m_strWheel_1_Serial_Number_2 = objDB.GetDBStringValue(csSQLCMD).Trim();

        csSQLCMD = strSQLCMD_W2S1 + "'" + txbTagID.Text + "' AND [Plant ID] = " + "'" + objAxle.Plant_ID + "'";
        m_strWheel_2_Serial_Number_1 = objDB.GetDBStringValue(csSQLCMD).Trim();

        csSQLCMD = strSQLCMD_W2S2 + "'" + txbTagID.Text + "' AND [Plant ID] = " + "'" + objAxle.Plant_ID + "'";
        m_strWheel_2_Serial_Number_2 = objDB.GetDBStringValue(csSQLCMD).Trim();
    }

    private string  BuildInsertString()
    {
        

        string strSQLCMD;

        if (!GetAxleInfo())  // check for processed axle bearing wheel data
            return "";

        GetWheelSerialNumbers();

        strSQLCMD = "INSERT INTO [OBAxle] (";
        strSQLCMD+= " [OBLoadID],";
        strSQLCMD+= " [Customer],";
        strSQLCMD+= " [Created By],";
        strSQLCMD+= " [Created On],";
        strSQLCMD+= " [Axle Type],";
        strSQLCMD+= " [Wheel Type],";
        strSQLCMD+= " [Bearing Type],";

//        if (m_strWheel_1_Serial_Number_1.Length > 0)  
            strSQLCMD+= " [Wheel 1 Serial Number 1],";
//        if (m_strWheel_1_Serial_Number_2.Length>0) 
            strSQLCMD+= " [Wheel 1 Serial Number 2],";
//        if (m_strWheel_2_Serial_Number_1.Length > 0)  
            strSQLCMD+= " [Wheel 2 Serial Number 1],";
//        if (m_strWheel_2_Serial_Number_2.Length > 0)  
            strSQLCMD+= " [Wheel 2 Serial Number 2])";

        strSQLCMD+= "  VALUES(";
        strSQLCMD+= "'"+ cmbOBLoadIds.Text+"',";  
        strSQLCMD+= "'"+ cmbCustomerID.Text+ "',";
        strSQLCMD += "'" + lblOperatorIDName.Text + "',";  
        strSQLCMD+= "'" + DateTime.Now.ToString() + "',";  
        strSQLCMD+= "'" + m_strAxleType  + "',";  
        strSQLCMD+= "'" + m_strBearingType  + "',";  
        strSQLCMD+= "'" + m_strWheelType  + "',";  

//        if (m_strWheel_1_Serial_Number_1!="") 
            strSQLCMD+= "'" + m_strWheel_1_Serial_Number_1  + "',"; 
//        if (m_strWheel_1_Serial_Number_2!="") 
            strSQLCMD+= "'" + m_strWheel_1_Serial_Number_2  + "',"; 
//        if (m_strWheel_2_Serial_Number_1!="") 
            strSQLCMD+= "'" + m_strWheel_2_Serial_Number_1  + "',"; 
//        if (m_strWheel_2_Serial_Number_2!="") 
            strSQLCMD+= "'" + m_strWheel_2_Serial_Number_2  + "')";

         return strSQLCMD;
        
    }

    private void ScrapSummaryInsert()
    {
        string strBearingScrapCode1 = "";
        string strBearingScrapCode2 = "";
        string strWheelScrapCode = "";

        m_strLoadID = GetInBoundLoadID();
        m_strInCustomerID = GetInBoundCustomerID(); 


        if (FindScrapBearingCnt() > 0)
        {
            strBearingScrapCode1 = GetBearingScrapCode(1);
            strBearingScrapCode2 = GetBearingScrapCode(2);

            if ((strBearingScrapCode1 != "")||(strBearingScrapCode2 != ""))
            {
                InsertBearingScrapCode(strBearingScrapCode1, strBearingScrapCode2);
            }
       }
       if (FindScrapWheelCnt() > 0)
       {
           strWheelScrapCode = GetWheelScrapCode();
           InsertWheelScrapCode(strWheelScrapCode);


       }
    }

    private void InsertBearingScrapCode(string strScrapCode1, string strScrapCode2)
    {
        string strSQLCMD = "";

        strSQLCMD = "INSERT INTO [ScrapSummary] ";
        strSQLCMD+= "([Plant ID], ";
        strSQLCMD+=  "[Tag ID], ";
        strSQLCMD+=  "[Load ID], ";
        strSQLCMD+=  "[Customer ID], ";
        strSQLCMD+=  "[Scrap Bearing 1 Reason], ";
        strSQLCMD+=  "[Scrap Bearing 2 Reason], ";
        strSQLCMD+=  "[TimeStamp]) ";

//     VALUES
  
        strSQLCMD+=  "VALUES ( ";
        strSQLCMD+=  "'" + objAxle.Plant_ID + "', " ;
        strSQLCMD+=  "'" + txbTagID.Text  + "', " ;
        strSQLCMD+=  "'" + m_strLoadID  + "', " ;
        strSQLCMD+=  "'" + m_strInCustomerID + "', " ;
        strSQLCMD+=  "'" + strScrapCode1 + "', " ;
        strSQLCMD+=  "'" + strScrapCode2 + "', " ;
        strSQLCMD+=  "'" + DateTime.Now.ToString() + "') " ;
        
        if (!objDB.ExecuteSQLCMD(strSQLCMD))
        {
            TraceLog("Error Inserting Bearing Scrap Info"); 

        }
    
    }

    private void InsertWheelScrapCode(string strScrapCode)
    {
        string strSQLCMD = "";

        strSQLCMD = "INSERT INTO [ScrapSummary] ";
        strSQLCMD += "([Plant ID], ";
        strSQLCMD += "[Tag ID], ";
        strSQLCMD += "[Load ID], ";
        strSQLCMD += "[Customer ID], ";
        strSQLCMD += "[Wheel Scrap Reason], ";
        strSQLCMD += "[TimeStamp]) ";

        //     VALUES

        strSQLCMD += "VALUES ( ";
        strSQLCMD += "'" + objAxle.Plant_ID + "', ";
        strSQLCMD += "'" + txbTagID.Text + "', ";
        strSQLCMD += "'" + m_strLoadID + "', ";
        strSQLCMD += "'" + m_strInCustomerID + "', ";
        strSQLCMD += "'" + strScrapCode + "', ";
        strSQLCMD += "'" + DateTime.Now.ToString() + "') ";

        if (!objDB.ExecuteSQLCMD(strSQLCMD))
        {
            TraceLog("Error Inserting Bearing Scrap Info");

        }

    }


    private string GetBearingScrapCode(int nBearingID)
    {
        string strScrapCode = "";
        string strSQLCMD = "";
        if (nBearingID==1)
        {
            strSQLCMD = "SELECT [Inbound Bearing 1 Scrap Code] FROM Axle WHERE [Tag ID] = ";

        }
        else if (nBearingID == 2)
        {
            strSQLCMD = "SELECT [Inbound Bearing 2 Scrap Code] FROM Axle WHERE [Tag ID] = ";
        }
        strSQLCMD += "'" + txbTagID.Text + "' AND [Plant ID] = '" + objAxle.Plant_ID + "'";
        strScrapCode = objDB.GetDBStringValue(strSQLCMD);

        return strScrapCode;
    }
    private string GetWheelScrapCode()
    {
        string strScrapCode = "";
        string strSQLCMD = "";
        strSQLCMD = "SELECT [Inbound Wheel Scrap Code] FROM Axle WHERE [Tag ID] = ";
        strSQLCMD += "'" + txbTagID.Text + "' AND [Plant ID] = '" + objAxle.Plant_ID + "'";
        strScrapCode = objDB.GetDBStringValue(strSQLCMD);

        return strScrapCode;
    }
    
    private string GetInBoundLoadID()
    {
        string strInboundLoadID="";
        string strSQLCMD;
        strSQLCMD = "SELECT [Load ID] FROM Axle WHERE [Tag ID] = ";
        strSQLCMD += "'" + txbTagID.Text + "' AND [Plant ID] = '" + objAxle.Plant_ID + "'";
        strInboundLoadID = objDB.GetDBStringValue(strSQLCMD);

        return strInboundLoadID;

    }

    private string GetInBoundCustomerID()
    {
        string strSQLCMD;
        string strInboundCustomerName = "";
        strSQLCMD = "SELECT [Inbound Customer] FROM Axle WHERE [Tag ID] = ";
        strSQLCMD += "'" + txbTagID.Text + "' AND [Plant ID] = '" + objAxle.Plant_ID + "'";
        strInboundCustomerName = objDB.GetDBStringValue(strSQLCMD);

        return strInboundCustomerName;
    }

    private int FindScrapBearingCnt()
    {
        int nResult = -1;
        string strSQLCMD;
        if (m_strLoadID == "") return -1;
        


        strSQLCMD = "Select ScrapBearing From [ScrapStatistics] Where [LoadID] = ";
        strSQLCMD += "'" + m_strLoadID + "' AND [Plant ID] = '" + objAxle.Plant_ID + "'";
        strSQLCMD += " AND [TagID] = '" + txbTagID.Text + "'";

        nResult = objDB.GetDBIntFValue(strSQLCMD, "ScrapBearing");

        if (nResult > 0)
        {
            return nResult ;
        }

        return -1;

    }

    private int FindScrapWheelCnt()
    {
        int nResult = -1;
        string strSQLCMD;

        if (m_strLoadID == "") return -1;


        strSQLCMD = "Select ScrapWheel From [ScrapStatistics] Where [LoadID] = ";
        strSQLCMD += "'" + m_strLoadID + "' AND [Plant ID] = '" + objAxle.Plant_ID + "'";
        strSQLCMD += " AND [TagID] = '" + txbTagID.Text + "'";

        nResult = objDB.GetDBIntFValue(strSQLCMD, "ScrapWheel");

        if (nResult > 0)
        {
            return nResult;
        }

        return -1;

    }


    
    private void QuantityCounter()
    {
        String strNumberOfTagID;

        int nMaxQty = 0;

        if (cmbOBLoadIds.Text != "")
        {

            strNumberOfTagID = strSQLCMD_CountOfTagIDs + "'" + cmbOBLoadIds.Text + "'";

            int nTagIDs = objDB.CountTagIDsFound(strNumberOfTagID);


            nMaxQty = GetLoadIDs();

            if (nTagIDs >= nMaxQty)
            {
                lblMaxQty.ForeColor = Color.Red;
                lblQtyPosted.ForeColor = Color.Red;
            }
            else
            {
                lblMaxQty.ForeColor = Color.Black;
                lblQtyPosted.ForeColor = Color.Black;

            }

            lblQtyPosted.Text = "Posted (" + nTagIDs.ToString() + ")";

            lblMaxQty.Text = "Max (" + nMaxQty.ToString() + ")";
        }


    }


    private int GetLoadIDs()
    {

        string strSQLCMD = "SELECT Qty FROM OBLoadID WHERE [Customer ID] = " + "'" + cmbCustomerID.Text + "'";
        strSQLCMD+=" AND [OBLoadID] = " + "'" + cmbOBLoadIds.Text + "'"; 
        return objDB.GetDBIntValue(strSQLCMD);

    }


    protected void cmbCustomerID_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (cmbCustomerID.Text != "")
        {
            QuantityCounter();
        }

    }

    private bool CleanUpTables()
    {
        string strDeleteSQLCMD;

        // delete tag information from axle table
        strDeleteSQLCMD = "DELETE FROM AXLE WHERE [Tag ID] =" + "'" + txbTagID.Text + "'";
        strDeleteSQLCMD += " AND [Plant ID] = " + "'" + objAxle.Plant_ID + "'";  

        if (!objDB.ExecuteSQLCMD(strDeleteSQLCMD))
        {
            TraceLog("Error Deleting Tag ID from Axle Table");
            return false;

        }


        // delete tag information from axle table
        strDeleteSQLCMD = "DELETE FROM [WM Operation] WHERE [Tag ID] =" + "'" + txbTagID.Text + "'";
        strDeleteSQLCMD += " AND [Plant ID] = " + "'" + objAxle.Plant_ID + "'";  

        if (!objDB.ExecuteSQLCMD(strDeleteSQLCMD))
        {
            TraceLog("Error Deleting Tag ID from Wheel Mount Table");
            return false;

        }


        // delete tag information from axle table
        strDeleteSQLCMD = "DELETE FROM [AP Operation] WHERE [Tag ID] =" + "'" + txbTagID.Text + "'";
        strDeleteSQLCMD += " AND [Plant ID] = " + "'" + objAxle.Plant_ID + "'";  

        if (!objDB.ExecuteSQLCMD(strDeleteSQLCMD))
        {
            TraceLog("Error Deleting Tag ID from Axle Production Table");
            return false;

        }

        return true;

    }

    protected void txbTagID_TextChanged(object sender, EventArgs e)
    {
        string strFoundData = "";
        strFoundData = objDB.GetDBStringValue(strSQLCMD_GetLoadID, txbTagID.Text);

        if (strFoundData.Length == 0)
        {
            txbTagID.Text = "[" + txbTagID.Text + "] Not Found";
            btnSummit.Enabled = false;
        }
        else
        {
            btnSummit.Enabled = true;
            m_strLoadID = GetInBoundLoadID();
            m_strInCustomerID = GetInBoundCustomerID(); 
        }

    }

 
    
    protected void btnSummit_Click(object sender, EventArgs e)
    {
        if (txbTagID.Text != "")
        {
            string strSQLCMD = BuildInsertString();
            if (strSQLCMD != "")
            {
                if (!objDB.ExecuteSQLCMD(strSQLCMD))
                {
                    TraceLog("Error Updating OBAxles Table");
                    return;

                }

            }
            ScrapSummaryInsert();

            if (!CleanUpTables())
                return;


        }
        txbTagID.Text = "";
 
    }

}
