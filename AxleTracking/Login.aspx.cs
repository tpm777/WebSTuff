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
using System.ComponentModel;



public partial class Login : System.Web.UI.Page
{

    String strSQLCMD_GetUserProfile = "SELECT [AccessProfile],[Plant ID] FROM [Operators] Where [Operator ID] = '";
    String strSQLCMD_GetStationName = "SELECT [ASPModuleName] AS Load_ID FROM [Machines] Where [Machine ID] = ";
    String strSQLCMD_GetStationDesc = "SELECT [Description] FROM [Machines] Where [Machine ID] = ";

    static String m_strUserAccessProfile;
    static String m_strPlantID;

    String strSQLCMD_GetStationIDs = "SELECT [AllowedWorkCenterIDs] AS Station_ID FROM [AccessProfiles] Where [ProfileName] = '";
    ProcessTracking.AxleInformation objAxle = new ProcessTracking.AxleInformation();
    ProcessTracking.CreateLogFiles LogTrace = new ProcessTracking.CreateLogFiles();

    string m_strSaveP;
    bool m_blnDebug;


    ProcessTracking.DBFuncs objDB = new ProcessTracking.DBFuncs();

   
    
    protected void Page_Load(object sender, EventArgs e)
    {
        SetMessage(false, null);
        btnSummit.Enabled = false;
        m_blnDebug = Session["Debug"].ToString() == "Yes" ? true : false;
        lblStationPurpose.Visible = false;


        
         

        if (!IsPostBack)
        {
            objAxle = (ProcessTracking.AxleInformation)Session["AxleInfo"];
            txbLoginID.Text = objAxle.OperatorID ;
            txbLoginID.Text.Trim();
            txbPassword.Text  = objAxle.Password;
 
            if (txbLoginID.Text!="")
            {
                if (txbPassword.Text != "")
                {
                    GetUserProfile();
                    if (m_strUserAccessProfile.Length > 0)
                    {
                        cmbStationIDs.DataTextField = "Station_ID";
                        cmbStationIDs.DataValueField = "Station_ID";
                        GetStationIDs();
                        m_strSaveP = txbLoginID.Text;// in case user changes id
                        // wo changing password
                        btnSummit.Enabled = true;

                    }
                }
            }
            // Set Input Focus
            txbLoginID.Focus();  
        }
        else
        {
            if (txbLoginID.Text.Trim().Length == 0)
            {
                m_strUserAccessProfile = "";
                cmbStationIDs.Items.Clear();
                SetMessage(false, null);
                btnSummit.Enabled = false;
                lblStationPurpose.Visible = false;

            }
            else
            {

                if (txbPassword.Text.Trim().Length != 0)
                {
                    if (GetUserProfile() != "") btnSummit.Enabled = true;
                }

                // failsafe's

                if (m_strUserAccessProfile == null) btnSummit.Enabled = false;
                if (m_strUserAccessProfile == "") btnSummit.Enabled = false;

            }

        }

    }

    private void TraceLog(String sMsg)
    {
        if (!m_blnDebug) return;
        LogTrace.TraceDBLog("Login", sMsg);
    }


    private void SetMessage(bool blnState, String strMessage)
    {

        if (blnState == false)
        {
            lblMessage.Text = ""; 
            lblMessage.Visible = false;
        }
        else
        {
            lblMessage.Text = strMessage;
            lblMessage.Visible = true;

        }
    }

    protected void txbPassword_TextChanged(object sender, EventArgs e)
    {
        GetUserProfile();
        if (m_strUserAccessProfile.Length > 0)
        {
            cmbStationIDs.DataTextField = "Station_ID";
            cmbStationIDs.DataValueField = "Station_ID";
            GetStationIDs();
            cmbStationIDs.SelectedIndex = 0;
            lblStationDesc.Text = objDB.GetDBStringValue(strSQLCMD_GetStationDesc, cmbStationIDs.Text ); 
            lblStationPurpose.Visible = true;
            btnSummit.Enabled = true;

        }
        else
        {
            cmbStationIDs.Items.Clear();
            SetMessage(true, "Invalid Operator ID/Password");
            btnSummit.Enabled = false;
            lblStationPurpose.Visible = false;
            lblStationDesc.Text="";

        }

    }




    
    protected void txbLoginID_TextChanged(object sender, EventArgs e)
    {
        if (IsPostBack)
        {
            if (m_strSaveP != txbLoginID.Text)
                cmbStationIDs.Items.Clear();
            txbPassword.Text = "";
            txbPassword.Focus();
        }
    }
    private String GetUserProfile()
    {
        String csTest;

        m_strUserAccessProfile = "";

        ConnectionStringSettings conn =
              System.Configuration.ConfigurationManager.
                     ConnectionStrings["RFDBConnectionString"];
        csTest = conn.ConnectionString;


        SqlConnection sqlConnection = new SqlConnection(csTest);
        sqlConnection.Open();
        SqlCommand cmd = sqlConnection.CreateCommand();
        cmd.CommandText = strSQLCMD_GetUserProfile + txbLoginID.Text + "' AND [Password] = '" + txbPassword.Text +"'" ;

        try
        {
            SqlDataReader reader = cmd.ExecuteReader();
            if (!reader.HasRows)
            {
                // Need Error Message Here

            }

            while (reader.Read())
            {
                m_strUserAccessProfile = reader["AccessProfile"].ToString().Trim();
                m_strPlantID = reader["Plant ID"].ToString().Trim();
                if (!m_strUserAccessProfile.Equals(""))
                {

                    if (sqlConnection.State != ConnectionState.Closed)
                        sqlConnection.Close();
                    break;

                }
            }
            reader.Close(); 

        }
        catch (Exception ex)
        {
            csTest = "Error: " + ex.Message;
        }
        finally
        {
            if (sqlConnection.State != ConnectionState.Closed)
                sqlConnection.Close();
        }


        return m_strUserAccessProfile;

    }

    private void GetStationIDs()
    {
        String csTest;

        cmbStationIDs.Items.Clear(); 

        ConnectionStringSettings conn =
              System.Configuration.ConfigurationManager.
                     ConnectionStrings["RFDBConnectionString"];
        csTest = conn.ConnectionString;


        SqlConnection sqlConnection = new SqlConnection(csTest);
        sqlConnection.Open();
        SqlCommand cmd = sqlConnection.CreateCommand();
        cmd.CommandText = strSQLCMD_GetStationIDs + m_strUserAccessProfile + "'";

        try
        {
            SqlDataReader reader = cmd.ExecuteReader();

            cmbStationIDs.DataSource = reader;
            cmbStationIDs.DataBind(); 

        }
        catch (Exception ex)
        {
            csTest = "Error: " + ex.Message;
        }
        finally
        {
            if (sqlConnection.State != ConnectionState.Closed)
                sqlConnection.Close();
        }


        return ;

    }

    private String GetASPModuleName()
    {
        String csASPModule = "";
        String csSQLConnectString;
        String csBuffer;

        ConnectionStringSettings conn =
              System.Configuration.ConfigurationManager.
                     ConnectionStrings["RFDBConnectionString"];
        csSQLConnectString = conn.ConnectionString;


        SqlConnection sqlConnection = new SqlConnection(csSQLConnectString);
        sqlConnection.Open();
        SqlCommand cmd = sqlConnection.CreateCommand();
        cmd.CommandText = strSQLCMD_GetStationName + "'" + cmbStationIDs.Text.Trim() + "'";

        try
        {
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                csBuffer = reader.GetString(0).Trim();

                if (csBuffer != "")
                {
                    csASPModule = csBuffer;
                    break;
                }
            }
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

        return csASPModule;

    }
    protected void btnSummit_Click(object sender, EventArgs e)
    {

        String csBuffer;
        objAxle = (ProcessTracking.AxleInformation)Session["AxleInfo"];

        objAxle.OperatorID = txbLoginID.Text;
        objAxle.Password  = txbPassword.Text;
        
        objAxle.Plant_ID = m_strPlantID;

        objAxle.StationID = cmbStationIDs.Text;

        Session["AxleInfo"] = objAxle;


        csBuffer = GetASPModuleName();
        TraceLog("Operator[" + txbLoginID.Text + "] Logged In");
        if (csBuffer.Length > 0)
            Response.Redirect(csBuffer, true);

    }



    protected void cmbStationIDs_SelectedIndexChanged(object sender, EventArgs e)
    {
        string csBuffer = cmbStationIDs.Text.Trim();
        if (csBuffer != "")
        {
            lblStationPurpose.Visible = true;
            lblStationDesc.Text = objDB.GetDBStringValue(strSQLCMD_GetStationDesc, cmbStationIDs.Text);
        }
        else
        {
            lblStationDesc.Text = "";
            lblStationPurpose.Visible = false;
        }

    }
}
