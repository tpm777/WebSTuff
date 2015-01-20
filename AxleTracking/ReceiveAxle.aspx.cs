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
using System.Drawing;



public partial class ReceiveAxle: System.Web.UI.Page
{
    ProcessTracking.AxleInformation objAxle = new ProcessTracking.AxleInformation();
    ProcessTracking.CreateLogFiles LogTrace = new ProcessTracking.CreateLogFiles();
    ProcessTracking.DBFuncs objDB = new ProcessTracking.DBFuncs();

    
    
    
    String strSQLCMD_UpdateAxleP;
    String strSQLCMD_InsertAxleP = "INSERT INTO [Axle] ([Tag ID],[Created By],[Created On],[Plant ID],[Inbound Customer],[Inbound Customer Location]) ";
    String strSQLCMD_CheckTagID = "SELECT [Tag ID] FROM [Axle] Where [Tag ID] = ";
    String strSQLCMD_CountOfTagIDs = "SELECT [Tag ID] FROM [Axle] WHERE [LOAD ID] = '";
    String strSQLCMD_MaxTagIDs = "SELECT [Qty] FROM [LoadID] WHERE [Load ID] = '";
    String strSQLCMD_CustomerCode = "SELECT [Customer Code] FROM [Customers] WHERE [Customer Name] = ";
    String strSQLCMD_AxleType = "SELECT [Axle Type ID] FROM [Axle Type] WHERE [Description] = ";
    String strSQLCMD_WheelType = "SELECT [Wheel Type ID] FROM [Wheel Type] WHERE [Description] = ";

    String strSQLCMD_LoadIDs = "SELECT [Load ID] AS Load_IDs FROM [LoadID] WHERE [Customer ID] = ";
    string strSQLCMDATS = "Select  AllowLoadCountGTMax From ATSSiteTable Where [Plant ID] = ";

    
    //    String strSQLCMD_BearingType = "SELECT [Bearing Type ID] FROM [Bearing Type] WHERE [Description] = ";
   
    
    bool blnWheelDataComplete=false;
    bool blnBearingDataComplete = false;

    bool m_blnAllowMaxQtyOverRide = false;


    bool m_blnDebug;

     

    protected void Page_Load(object sender, EventArgs e)
    {
       
        
        
        
        objAxle = (ProcessTracking.AxleInformation)Session["AxleInfo"];
        if (objAxle.OperatorID == null) Response.Redirect("Login.aspx"); 
        if (objAxle.OperatorID == "") Response.Redirect("Login.aspx"); 

        lblOperatorIDName.Text = objAxle.OperatorID;
        btnEditLoadIDs.Visible = false;
        btnEditLoadIDs.Enabled = false;
        SetMaxQtyOverIde();
        if (!IsPostBack)
        {

            if (objAxle.TagID != null)
                txbTagID.Text = objAxle.TagID.Trim();

            if (objAxle.InboundCustomer != null)
                cmbCustomerID.Text = objAxle.InboundCustomer;
            if (objAxle.AxleType != null)
                cmbAxleType.Text = objAxle.AxleType;
            if ((objAxle.LoadID != null)&&(cmbLoadID.Items.Count>0))   
                cmbLoadID.Text = objAxle.LoadID;

         
        }
        
        m_blnDebug = Session["Debug"].ToString() == "Yes" ? true : false;
        
        if (Page.IsPostBack)
        {

        }
        if (txbTagID.Text.Equals(""))
        {
            btnWheelData.Enabled = false;
            btnAddEditBearingData.Enabled = false;
            btnSummit.Enabled = false;
            if (cmbAxleType.Text == "")
            {

                cmbAxleType.SelectedIndex = 0;
            }


        }
        else
        {
            if (txbTagID.Text == "Complete") return;

            btnWheelData.Enabled = true;
            btnAddEditBearingData.Enabled = true;

            if (IsWheelDataComplete() && IsBearingDataComplete())
            {
                btnSummit.Enabled = true;
            }
            else
                btnSummit.Enabled = false;                 



        }



    }

    protected void Page_PreRenderComplete(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {


            txbTagID.Text = objAxle.TagID;
            lblOperatorIDName.Text = objAxle.OperatorID;


            cmbCustomerID.Text = objAxle.InboundCustomer;



            GetLoadIDs();
            cmbLoadID.Text = objAxle.LoadID;

            QuantityCounter();

        }
        else
        {
           if ((cmbCustomerID.Text!="")&&(cmbLoadID.Text != ""))
               QuantityCounter();
           else if ((cmbCustomerID.Text != "") && (cmbLoadID.Text == ""))
           {
               GetLoadIDs();
               QuantityCounter();

           }
        }

    }

    private void SetMaxQtyOverIde()
    {
        string strBuffer = objDB.GetDBStringValue(strSQLCMDATS, objAxle.Plant_ID);
        strBuffer = strBuffer.ToUpper();
        m_blnAllowMaxQtyOverRide = strBuffer == "YES" ? true : false;   

    }
    private void DisplayMsg(string sMsg)
    {
        ProcessTracking.MessageBox.Show(sMsg);
    }
    private void GetLoadIDs()
    {
        String csTest;
        cmbLoadID.DataTextField = "Load_IDs";
        cmbLoadID.DataValueField = "Load_IDs";

        cmbLoadID.Items.Clear();

        ConnectionStringSettings conn =
              System.Configuration.ConfigurationManager.
                     ConnectionStrings["RFDBConnectionString"];
        csTest = conn.ConnectionString;


        SqlConnection sqlConnection = new SqlConnection(csTest);
        sqlConnection.Open();
        SqlCommand cmd = sqlConnection.CreateCommand();
        cmd.CommandText = strSQLCMD_LoadIDs + "'" + cmbCustomerID.Text  + "'";

        try
        {
            SqlDataReader reader = cmd.ExecuteReader();
            cmbLoadID.DataSource = reader;
            cmbLoadID.DataBind();

        }
        catch (Exception ex)
        {
            
            csTest = "Error: " + ex.Message;
            DisplayMsg(csTest);
 
        }
        finally
        {
            if (sqlConnection.State != ConnectionState.Closed)
                sqlConnection.Close();
        }


        return;

    }



    private void TraceLog(String sMsg)
    {
        if (!m_blnDebug) return;
        LogTrace.TraceDBLog("BearingDemount", sMsg);
    }


    private String GetDBStringValue(String strSQLCMD)
    {
        String csSQLConnectString;
        String csBuffer = "";

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


    protected void btnWheelData_Click(object sender, EventArgs e)
    {
        objAxle.ReceivedWheels = false;
        SaveInfo();
        

        Response.Redirect("ReceiveWheel.aspx");
    }
    private void SaveInfo()
    {
        objAxle.TagID = txbTagID.Text;
       
        objAxle.LoadID = cmbLoadID.Text;
        objAxle.InboundCustomer = cmbCustomerID.Text;
        objAxle.AxleType = cmbAxleType.Text; 

        Session["AxleInfo"] = objAxle;  


    }
    
    
    private bool IsWheelDataComplete()
    {
        blnWheelDataComplete = false;

        if (txbTagID.Text == "") return false;
        if (txbTagID.Text == "Complete") return false;

        if (objAxle.WheelType == null) return false;

        if (objAxle.WheelType!="")
        {
            blnWheelDataComplete = true;
        }
        return blnWheelDataComplete;
    }

    private bool IsBearingDataComplete()
    {
        blnBearingDataComplete=false ;
        if (txbTagID.Text == "") return false;
        if (txbTagID.Text == "Complete") return false;

        if (objAxle.BearingType == null) return false;
     
        if (objAxle.BearingType!="" )
        {
            blnBearingDataComplete = true;
        }
        
        return blnBearingDataComplete;
    }


    protected void btnWheelBearing_Click(object sender, EventArgs e)
    {

        objAxle.ReceivedBearings  = false;
        SaveInfo();
        Response.Redirect("ReceiveBearing.aspx",true);


    }

 /*   protected void GetWheelBearingInformation()
    {

        objAxle.TagID = txbTagID.Text;
        objAxle.LoadID = cmbLoadID.Text; 
        Session["AxleInfo"] = objAxle;  


        Response.Redirect("ReceiveBearing.aspx",true);
    }
*/    
    
    protected void btnClear_Click(object sender, EventArgs e)
    {
        InitControls();
        ResetSessionVars();
        // reset controls
        txbTagID.Text = "";
        btnSummit.Enabled = false;
        btnWheelData.Enabled = false;
        btnAddEditBearingData.Enabled = false;
        lblMaxQty.Text = "";
        lblQtyPosted.Text = "";

        cmbAxleType.Text = "";
        cmbCustomerID.Text = "";
        cmbLoadID.Items.Clear();  

       
    }

    protected void FinishReceiving(object sender, EventArgs e)
    {

    }

    protected void UpdateAxleDB(object sender, EventArgs e)
    {
        if (IsScrap() != false)
        {


        }

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


        
        
        // Does Tag ID exist

        cmd.CommandText = strSQLCMD_CheckTagID + "'" + txbTagID.Text + "'";

        try
        {

            SqlDataReader reader = cmd.ExecuteReader();
           
            if (reader.HasRows)
            {
                blnRecordFound = true; 

            }

        }
        catch (Exception ex)
        {
            csBuffer = "Error: " + ex.Message;
            return false;
        }


        if (sqlConnection.State != ConnectionState.Closed)
            sqlConnection.Close();

        sqlConnection.Open(); 

        if (!blnRecordFound)
        {
            cmd.CommandText = BuildInsertString();
        }
        else
        {
            cmd.CommandText = BuildUpdateString();
        }



        
        
        try
        {

            int nRowUpdated = cmd.ExecuteNonQuery();

        }
        catch (Exception ex)
        {
            csBuffer = "Error: " + ex.Message;
            return false;
        }
        finally
        {
            if (sqlConnection.State != ConnectionState.Closed)
                sqlConnection.Close();
        }

        return true;

    }

    private String BuildUpdateString()
    {
        String csAxleType;
        String csWheelType;
        String csBearingType;

        ProcessTracking.DBFuncs objDB = new ProcessTracking.DBFuncs();


        csAxleType = objDB.GetDBStringValue(strSQLCMD_AxleType , cmbAxleType.Text);  
        csWheelType = objDB.GetDBStringValue(strSQLCMD_WheelType , objAxle.WheelType);
        
        
        
        csBearingType = objAxle.BearingType;
        
        strSQLCMD_UpdateAxleP = "UPDATE [AXLE] SET ";
        strSQLCMD_UpdateAxleP += "[Tag ID] = '" + txbTagID.Text + "'," ;
        strSQLCMD_UpdateAxleP += "[Load ID] = '" + cmbLoadID.Text + "',";
        strSQLCMD_UpdateAxleP += "[Created By]  = '" + objAxle.OperatorID + "',";
        strSQLCMD_UpdateAxleP += "[Created On]  = '" + DateTime.Now.ToString() + "',";
        strSQLCMD_UpdateAxleP += "[Inbound Axle Type]  = '" + csAxleType + "',";
        strSQLCMD_UpdateAxleP += "[Inbound Wheel Type]  = '" + csWheelType + "',";
        strSQLCMD_UpdateAxleP += "[Inbound Wheel Status]  = '" + objAxle.InboundWheelStatus  + "',";
        strSQLCMD_UpdateAxleP += "[Inbound Bearing Type]  = '" + csBearingType + "',";
        strSQLCMD_UpdateAxleP += "[Inbound Bearing 1 Status]  = '" + objAxle.InboundBearing1_Status + "',";
        strSQLCMD_UpdateAxleP += "[Inbound Bearing 1 Scrap Code]  = '" + objAxle.InboundBearing1_ScrapCode  + "',";

        strSQLCMD_UpdateAxleP += "[Inbound Bearing 2 Status]  = '" + objAxle.InboundBearing2_Status + "', ";
        strSQLCMD_UpdateAxleP += "[Inbound Bearing 2 Scrap Code]  = '" + objAxle.InboundBearing2_ScrapCode + "'";
        strSQLCMD_UpdateAxleP += "WHERE [Tag ID] = '" + txbTagID.Text + "' AND [Plant ID] = '" + objAxle.Plant_ID +"'";

        return strSQLCMD_UpdateAxleP;
    }


    private String BuildInsertString()
    {

        String csAxleType;
        String csWheelType;
        String csBearingType;
        String strCustomerCode;


        ProcessTracking.DBFuncs objDB = new ProcessTracking.DBFuncs();


        csAxleType = objDB.GetDBStringValue(strSQLCMD_AxleType, cmbAxleType.Text);
        csWheelType = objDB.GetDBStringValue(strSQLCMD_WheelType, objAxle.WheelType);
        strCustomerCode = objDB.GetDBStringValue(strSQLCMD_CustomerCode, cmbCustomerID.Text);    

        
        csBearingType = objAxle.BearingType;

        
        strSQLCMD_InsertAxleP = "INSERT INTO [Axle] ";
        strSQLCMD_InsertAxleP+= "([Tag ID],";
        strSQLCMD_InsertAxleP+= "[Created By],";
        strSQLCMD_InsertAxleP+= "[Created On],";
        strSQLCMD_InsertAxleP+= "[Plant ID],";
        strSQLCMD_InsertAxleP+= "[Inbound Customer],";
        strSQLCMD_InsertAxleP+= "[Inbound Customer Location],";
        strSQLCMD_InsertAxleP += "[Inbound Axle Type],";
        strSQLCMD_InsertAxleP += "[Inbound Wheel Type],";
        strSQLCMD_InsertAxleP += "[Wheel Status],";
        strSQLCMD_InsertAxleP += "[Inbound Wheel Status],";
        strSQLCMD_InsertAxleP += "[Inbound Wheel Scrap Code],";

        strSQLCMD_InsertAxleP += "[Inbound Bearing Type],";
        strSQLCMD_InsertAxleP += "[Bearing Status],";
        strSQLCMD_InsertAxleP += "[Inbound Bearing 1 Status],";
        strSQLCMD_InsertAxleP += "[Inbound Bearing 1 Scrap Code],";

        strSQLCMD_InsertAxleP += "[Inbound Bearing 2 Status],";
        strSQLCMD_InsertAxleP += "[Inbound Bearing 2 Scrap Code],";

        strSQLCMD_InsertAxleP += "[Load ID]) VALUES (";



        strSQLCMD_InsertAxleP += "'" + objAxle.TagID + "',";
        strSQLCMD_InsertAxleP += "'" + lblOperatorIDName.Text    + "',";
        strSQLCMD_InsertAxleP += "'" + DateTime.Now.ToString()  + "',";
        strSQLCMD_InsertAxleP += "'" + objAxle.Plant_ID  + "',";
        strSQLCMD_InsertAxleP += "'" + strCustomerCode + "',";
        strSQLCMD_InsertAxleP += "'" + "Cus Loc" + "',";
        strSQLCMD_InsertAxleP += "'" + csAxleType + "',";
        strSQLCMD_InsertAxleP += "'" + csWheelType + "',";
        strSQLCMD_InsertAxleP += "'" + "Mounted" + "',";

        strSQLCMD_InsertAxleP += "'" + objAxle.InboundWheelStatus  + "',";
        strSQLCMD_InsertAxleP += "'" + objAxle.InboundWheelScrapCode  + "',";

        strSQLCMD_InsertAxleP += "'" + csBearingType + "',";
        strSQLCMD_InsertAxleP += "'" + "Mounted" + "',";

        strSQLCMD_InsertAxleP += "'" + objAxle.InboundBearing1_Status + "',";
        strSQLCMD_InsertAxleP += "'" + objAxle.InboundBearing1_ScrapCode  + "',";

        strSQLCMD_InsertAxleP += "'" + objAxle.InboundBearing2_Status + "',";
        strSQLCMD_InsertAxleP += "'" + objAxle.InboundBearing2_ScrapCode + "',";
   
        strSQLCMD_InsertAxleP += "'" + cmbLoadID.Text   + "')";

        return strSQLCMD_InsertAxleP;
    }



    private bool IsScrap()
    {

        return false;
    }
    private void InitControls()
    {
        txbTagID.Text = "";
        btnSummit.Enabled = false;
        btnWheelData.Enabled = false;
        btnAddEditBearingData.Enabled = false;
        lblMaxQty.Text = "";
        lblQtyPosted.Text = "";
 
//        cmbAxleType.Text = "";
//        cmbCustomerID.Text = "";
//        cmbLoadID.Items.Clear();  
   

    }

    
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (IsWheelDataComplete() && IsBearingDataComplete())
        {
            ExecuteSQLCmd();
            
            objAxle = new ProcessTracking.AxleInformation();
            Session["AxleInfo"] = objAxle;
            InitControls(); 
            

        }

    }
    protected void cmbLoadID_SelectedIndexChanged(object sender, EventArgs e)
    {
            QuantityCounter();
    }

    private void QuantityCounter()
    {
        String strNumberOfTagID;
        int nMax = 0;

        if (cmbLoadID.Text!="")
        {

            strNumberOfTagID = strSQLCMD_CountOfTagIDs + cmbLoadID.Text + "'";

            int nTagIDs = CountTagIDsFound(strNumberOfTagID);

            nMax = FindMaxQty();

            if ((nTagIDs >= nMax) && (nMax > 0))
            {
                lblQtyPosted.Text = "Posted!!(" + nTagIDs.ToString() + ")";
                lblMaxQty.Text = "Max!! (" + nMax.ToString() + ")";
                lblMaxQty.ForeColor = Color.Red;
                lblQtyPosted.ForeColor = Color.Red;
                if (m_blnAllowMaxQtyOverRide)
                {
                    btnEditLoadIDs.Visible = true;
                    btnEditLoadIDs.Enabled = true;
                }
                else
                {
                    txbTagID.Text = "Complete";  
                }
            }
            else if ((nTagIDs > nMax*.75) && (nMax > 0))
            {
                lblQtyPosted.Text = "Posted (" + nTagIDs.ToString() + ")";
                lblMaxQty.Text = "Max (" + nMax.ToString() + ")";
                lblMaxQty.ForeColor = Color.PaleVioletRed  ;
                lblQtyPosted.ForeColor = Color.PaleVioletRed;

                btnEditLoadIDs.Visible = false;
                btnEditLoadIDs.Enabled = false; 

            }
            else
            {
                lblQtyPosted.Text = "Posted (" + nTagIDs.ToString() + ")";
                lblMaxQty.Text = "Max (" + nMax.ToString() + ")";
                lblMaxQty.ForeColor = Color.Blue;
                lblQtyPosted.ForeColor = Color.Blue;
                btnEditLoadIDs.Visible = false;
                btnEditLoadIDs.Enabled = false; 

            }



        }


    }

    private int CountTagIDsFound(String strSQLCMD)
    {
        String csSQLConnectString;
        String csBuffer;
        int nTagIDsFound = 0;

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
                    nTagIDsFound += 1;
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
        return nTagIDsFound;

    }


    private int FindMaxQty()
    {
        String csSQLConnectString;
        String csBuffer;
        int nFindMaxQty = 0;

        ConnectionStringSettings conn =
              System.Configuration.ConfigurationManager.
                     ConnectionStrings["RFDBConnectionString"];
        csSQLConnectString = conn.ConnectionString;


        SqlConnection sqlConnection = new SqlConnection(csSQLConnectString);
        sqlConnection.Open();
        SqlCommand cmd = sqlConnection.CreateCommand();



        cmd.CommandText = strSQLCMD_MaxTagIDs+cmbLoadID.Text+"'" ;

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
                    nFindMaxQty = reader.GetInt32(0); 
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
        return nFindMaxQty;

    }

    private void ResetSessionVars()
    {
        objAxle.BearingType = "";
        objAxle.WheelType = "";
        objAxle.TagID = "";
        objAxle.ReceivedBearings = false;
        objAxle.ReceivedWheels = false;
        objAxle.InboundBearing1_ScrapCode = "";
        objAxle.InboundBearing2_ScrapCode = "";
        objAxle.WheelStatus = "";
        objAxle.Bearing_Status = "";
        objAxle.BearingScrapCode1 = "";
        objAxle.BearingScrapCode2 = "";
        Session["AxleInfo"] = objAxle;


    }


    protected void btnSummit_Click(object sender, EventArgs e)
    {
    
        if (txbTagID.Text=="")return;
        if (txbTagID.Text == "Complete") return;
 
        if (!ExecuteSQLCmd())
        {
            TraceLog("Error Posting To Axle Table"); 

        }
        ResetSessionVars();
        InitControls();
        QuantityCounter();
         

    }

    protected void cmbCustomerID_SelectedIndexChanged(object sender, EventArgs e)
    {

        if (cmbCustomerID.Text != objAxle.InboundCustomer)
        {
            GetLoadIDs();
            QuantityCounter();
            objAxle.InboundCustomer = cmbCustomerID.Text;
        }
    }
    protected void btnEditLoadIDs_Click(object sender, EventArgs e)
    {
        SaveInfo();
 
        Response.Redirect("~/Admin/MiniLoadEditInbount.aspx");
    }
}
