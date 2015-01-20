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

public partial class LooseAxles : System.Web.UI.Page
{
    ProcessTracking.AxleInformation objAxle = new ProcessTracking.AxleInformation();
    ProcessTracking.CreateLogFiles LogTrace = new ProcessTracking.CreateLogFiles();
    ProcessTracking.DBFuncs objDB = new ProcessTracking.DBFuncs();
    bool m_blnDebug;
    String m_strBusinssRule;

    
    
    String m_csSQLCMD = "SELECT [Description] FROM [Machines] Where [Machine ID] = '";
    String strSQLCMD_GetLoadID = "SELECT [Load ID] FROM [Axle] Where [Tag ID] = ";
    String strSQLCMD_GetRuleName = "SELECT [BusinessRule] FROM [Machines] Where [Machine ID] = ";

    String strSQLCMD_CustomerName = "SELECT [Customer Name] FROM [Customers],[Axle] WHERE [Customers].[Customer Code] = [AXLE].[Inbound Customer] AND [Axle].[Tag ID] = ";
     
    
    
    protected void Page_Load(object sender, EventArgs e)
    {
        String csSQLCMD;
        objAxle = (ProcessTracking.AxleInformation)Session["AxleInfo"];

        // no access with user id
        if (objAxle.OperatorID == null) Response.Redirect("Login.aspx");
        if (objAxle.OperatorID == "") Response.Redirect("Login.aspx");

        m_blnDebug = Session["Debug"].ToString() == "Yes" ? true : false;

        m_strBusinssRule = objDB.GetDBStringValue(strSQLCMD_GetRuleName, objAxle.StationID);

        if (m_strBusinssRule == "")
        {
            m_strBusinssRule = "LooseAxles";
        }
       

        
        lblOperatorIDName.Text = objAxle.OperatorID;
        
        csSQLCMD = m_csSQLCMD + objAxle.StationID + "'";
        lblTitle.Text = GetDBStringValue(csSQLCMD);
        
        if (!IsPostBack)
            txbTaskCompleted.Enabled = false;
        btnSummit.Enabled = false;
 
        

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
        LogTrace.TraceDBLog("LooseAxles", sMsg);
    }

    private void GetCustomerInfo()
    {
        String csBuffer;
        if (txbTagID.Text == null) return;
        if (txbTagID.Text == "") return;

        csBuffer = objDB.GetDBStringValue(strSQLCMD_CustomerName, txbTagID.Text);

        if (csBuffer.Length > 0)
        {
      
            lblCustomerName.Text = csBuffer;
            btnSummit.Enabled = true;
            txbTaskCompleted.Enabled = true;

        }
        else
        {

            txbTagID.Text = "Error Customer Info Not Found";
            TraceLog(txbTagID.Text);

            lblCustomerName.Text = "";
            btnSummit.Enabled = false;
            txbTaskCompleted.Enabled = false;

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

  
            lblLoadIDValue.Text = csBuffer;
            btnSummit.Enabled = true;
            txbTaskCompleted.Enabled = true;

        }
        else
        {
            txbTagID.Text = "Error Customer Info Not Found";
            TraceLog(txbTagID.Text);

            btnSummit.Enabled = false;
            lblLoadIDValue.Text = "";
            txbTaskCompleted.Enabled = false;


        }


    }


    private String GetDBStringValue(String strSQLCMD)
    {
        String csSQLConnectString;
        String csBuffer="";

        ConnectionStringSettings conn =
              System.Configuration.ConfigurationManager.
                     ConnectionStrings["RFDBConnectionString"];
        csSQLConnectString = conn.ConnectionString;


        SqlConnection sqlConnection = new SqlConnection(csSQLConnectString);
        sqlConnection.Open();
        SqlCommand cmd = sqlConnection.CreateCommand();

        cmd.CommandText = strSQLCMD;

        try
        {
            SqlDataReader reader = cmd.ExecuteReader();
            if (!reader.HasRows)
            {
                // Need Error Message Here

            }
            else
            {
                while (reader.Read())
                {
                    csBuffer = reader.GetString(0);
                }
            }
            reader.Close();




        }
        catch (Exception ex)
        {
            csBuffer = "Error: " + ex.Message;
        }
        finally
        {
            if (sqlConnection.State != ConnectionState.Closed)
                sqlConnection.Close();
        }
        return csBuffer;

    }


    private String BuildInsertString()
    {

        String csInsertSQLCMD = "INSERT INTO ([Tag ID],[Machine ID],[AP Operator ID] ,[AD DT Stamp],[Task1]) VALUES(";


        csInsertSQLCMD = "INSERT INTO [AP Operation] ";
        csInsertSQLCMD += "([Tag ID],";
        csInsertSQLCMD += "[Machine ID],";
        csInsertSQLCMD += "[AP Operator ID],";
        csInsertSQLCMD += "[Plant ID],";
        csInsertSQLCMD += "[AD DT Stamp],";
        csInsertSQLCMD += "[Task1]) VALUES (";


        csInsertSQLCMD += "'" + txbTagID.Text + "',";
        csInsertSQLCMD += "'" + objAxle.StationID + "',";
        csInsertSQLCMD += "'" + objAxle.OperatorID + "',";
        csInsertSQLCMD += "'" + objAxle.Plant_ID + "',";
        csInsertSQLCMD += "'" + DateTime.Now.ToString() + "',";
        csInsertSQLCMD += "'" + txbTaskCompleted.Text + "')";

        return csInsertSQLCMD;
    }
    private bool ExecuteSQLCmd()
    {
        String csSQLConnectString;
        String csBuffer;
        bool blnRecordFound = false;

        ConnectionStringSettings conn =
              System.Configuration.ConfigurationManager.
                     ConnectionStrings["RFDBConnectionString"];
        csSQLConnectString = conn.ConnectionString;


        SqlConnection sqlConnection = new SqlConnection(csSQLConnectString);
        sqlConnection.Open();
        SqlCommand cmd = sqlConnection.CreateCommand();

        cmd.CommandText = BuildInsertString();


        try
        {

            int nRowUpdated = cmd.ExecuteNonQuery();
            if (nRowUpdated == 1)
                blnRecordFound = true; 

        }
        catch (Exception ex)
        {
            csBuffer = "Error: " + ex.Message;
        }
        finally
        {
            if (sqlConnection.State != ConnectionState.Closed)
                sqlConnection.Close();
        }

        return blnRecordFound;

    }



    protected void txbTagID_TextChanged(object sender, EventArgs e)
    {
     
        txbTagID.Text.Trim();

        if (txbTagID.Text.Length == 0) return;

        if (!objDB.IsBRSatisfied(m_strBusinssRule, txbTagID.Text, objAxle.Plant_ID))
        {

            txbTagID.Text = "BR Failed";
            return;

        }

        GetCustomerInfo();
        GetLoadIDInfo();


    }
    protected void txbTaskCompleted_TextChanged(object sender, EventArgs e)
    {
        if (txbTaskCompleted.Text!="") 
            btnSummit.Enabled = true;
        else
            btnSummit.Enabled = false; 

    }
    protected void btnSummit_Click(object sender, EventArgs e)
    {
        ExecuteSQLCmd();
        txbTaskCompleted.Text = "";
        btnSummit.Enabled = false;


    }

}
