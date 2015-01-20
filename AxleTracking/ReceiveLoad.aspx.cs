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
using System.Security.Principal;
using System.Threading;
using System.Data.SqlClient; 

 
public partial class ReceiveLoad : System.Web.UI.Page
{
//    IIdentity id = HttpContext.Current.User.Identity;
    String strSQLCMD_GetLoadID = "INSERT [LoadID] VALUES (";
    ProcessTracking.AxleInformation objAxle = new ProcessTracking.AxleInformation();
    static String m_strPlantID;
    static int m_nLoadCounter;

    String strSQLCMD_GetLoadIDCounter = "SELECT [Counter] FROM [LoadIDCounter] Where [Plant ID] = '";
    String strSQLCMD_UpdateLoadIDCounter = "UPDATE [LoadIDCounter] SET [Counter] = ";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            objAxle = (ProcessTracking.AxleInformation)Session["AxleInfo"];

            // no access with user id
            if (objAxle.OperatorID == null) Response.Redirect("Login.aspx");
            if (objAxle.OperatorID == "") Response.Redirect("Login.aspx"); 
            
            
            
            lblOperatorIDName.Text = objAxle.OperatorID;
            m_strPlantID = objAxle.Plant_ID;  
        }

    }

    
    public string GetLoadID()
    {
        string strLoadID;

        int nCount=GetLoadIDCount();
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

        strLoadID = m_strPlantID + m_nLoadCounter.ToString(); 
        

        return strLoadID.Trim();
    }
    public int GetLoadIDCount()
    {
        int nTest=-1;
        String csTest;

        ConnectionStringSettings conn =
              System.Configuration.ConfigurationManager.
                     ConnectionStrings["RFDBConnectionString"];
        csTest = conn.ConnectionString;


        SqlConnection sqlConnection = new SqlConnection(csTest);
        sqlConnection.Open();
        SqlCommand cmd = sqlConnection.CreateCommand();
        cmd.CommandText = strSQLCMD_GetLoadIDCounter + m_strPlantID + "'";

        try
        {
            SqlDataReader reader = cmd.ExecuteReader();
            if (!reader.HasRows)
            {
                // Need Error Message Here

            }
            while (reader.Read())
            {
                nTest=System.Convert.ToInt32(reader["Counter"].ToString());
                
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


        return nTest;



    }




    private String ExecuteSQLCmd(String strSQLCMD)
    {
        String csStatusCode = "";
        String csSQLConnectString;
        String csBuffer;

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

            int nRowUpdated = cmd.ExecuteNonQuery();

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
        return csStatusCode;

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
                strSQLCMD_GetLoadID += "'" + strLoadID + "',";
                strSQLCMD_GetLoadID += "'" + cmbCustomers.Text.Trim() + "',";
                strSQLCMD_GetLoadID += txbQuantity.Text + ")";
                ExecuteSQLCmd(strSQLCMD_GetLoadID);

                strSQLCMD_UpdateLoadIDCounter += m_nLoadCounter.ToString() + " Where [Plant ID] = '";
                strSQLCMD_UpdateLoadIDCounter += m_strPlantID + "'";

                ExecuteSQLCmd(strSQLCMD_UpdateLoadIDCounter);

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
