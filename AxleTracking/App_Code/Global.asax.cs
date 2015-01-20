using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Security.Principal;
using System.Threading;
using System.IO;
using System.Data.SqlClient;




/// <summary>
/// Summary description for Global
/// </summary>
/// 
namespace ProcessTracking
{

    
    public class Global : System.Web.HttpApplication
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>

        private System.ComponentModel.IContainer components = null;


        
        public Global()
        {
            InitializeComponent();
        }

        protected void Application_Start(Object sender, EventArgs e)
        {
                  
 
//            ProfileCommon  
        }

        protected void Session_Start(Object sender, EventArgs e)
        {
            Session["AxleInfo"] = new ProcessTracking.AxleInformation();
            Session["Debug"] = "Yes"; 
        }

        protected void Application_BeginRequest(Object sender, EventArgs e)
        {

        }

        protected void Application_EndRequest(Object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(Object sender, EventArgs e)
        {

        }

        protected void Application_Error(Object sender, EventArgs e)
        {

        }

        protected void Session_End(Object sender, EventArgs e)
        {

        }

        protected void Application_End(Object sender, EventArgs e)
        {

        }

        public class UserInfo
        {
            private int intID = 0;
            private string strName = "";
            private string strPassword = "";
            private byte bytPermissions = 0;

            public int ID
            {
                get
                {
                    return intID;
                }
                set
                {
                    intID = value;
                }
            }

            public string Name
            {
                get
                {
                    return strName;
                }
                set
                {
                    strName = value;
                }
            }

            public string Password
            {
                get
                {
                    return strPassword;
                }
                set
                {
                    strPassword = value;
                }
            }

            public byte Permissions
            {
                get
                {
                    return bytPermissions;
                }
                set
                {
                    bytPermissions = value;
                }
            }
        }


        public class TagIDInfo
        {
            private string strTagID;
            public string TagID
            {
                get
                {
                    return strTagID;
                }
                set
                {
                    strTagID = value;
                }
            }
        }
      

        
        public class EditStatus
        {
            public const byte NONE = 0;
            public const byte EDIT = 1;
            public const byte ADD = 2;

            private byte bytMode = NONE;

            public byte Mode
            {
                get
                {
                    return bytMode;
                }
                set
                {
                    bytMode = value;
                }
            }
        }
      
       [Serializable]
       public class AxleInfo
        {
           public AxleInfo()
           {


           }
           
           private string strAxleType = "";

            public string AxleType
            {
                get
                {
                    return strAxleType;
                }
                set
                {
                    strAxleType = value;
                }
            }

        }

        #region Web Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
        }
        #endregion
    }

}

    

namespace ProcessTracking
{

    
    [Serializable]
    public class AxleInformation
    {
        public string OperatorID;
        public string Password;
        public string StationID;
        public DateTime Received;
        public DateTime LastUpdated;
        public string TagID;
        public string LoadID;
        public string Bearing_Status;
        public string Created_By;
        public string Created_On;
        public string Plant_ID;
        public string InboundCustomer;
        public string InboundCustomerLocation;
        public string AxleType;
        public string WheelType;
        public string InboundWheelStatus;
        public string InboundWheelScrapCode;

        public string BearingType;
        public string InboundBearing1_Status;
        public string InboundBearing1_ScrapCode;
        
        public string InboundBearing2_Status;
        public string InboundBearing2_ScrapCode;

        public string AxleStatus;
        public string BearingStatus;
        public string WheelStatus;

        public string BearingScrapCode1;
        public string BearingScrapCode2;
        public string OutboundCustomer;
        public string OutboundSalesOrder;
        public string ShippedBy;
        public string ShippedOn;
        public string OutboundAxleType;
        public string OutboundWheelType;
        public string OutboundBearingType;
        public string StatusCode;
        public Boolean  ReceivedWheels;
        public Boolean  ReceivedBearings;


    }

    //<Summary>
    // This class used to created log files
    //</Summary>

    public class CreateLogFiles
    {
        private string sLogFormat;
        private string sLogTime;
        private string sPathName;

        public CreateLogFiles()
        {
            //sLogFormat used to create log files format :
            // dd/mm/yyyy hh:mm:ss AM/PM ==> Log Message
            sLogFormat = DateTime.Now.ToShortDateString().ToString() + " " + DateTime.Now.ToLongTimeString().ToString() + ",";

            //this variable used to create log filename format "
            string sYear = DateTime.Now.Year.ToString();
            string sMonth = DateTime.Now.Month.ToString();
            string sDay = DateTime.Now.Day.ToString();
            sLogTime = sYear + sMonth + sDay;
        }

        public void TraceLog( string sMsg)
        {
            sPathName = HttpContext.Current.Server.MapPath("~/Logs/LogTrace.csv");

            if (sPathName=="") return;
            if (sPathName == null) return;
            
            sLogFormat = DateTime.Now.ToShortDateString().ToString() + " " + DateTime.Now.ToLongTimeString().ToString() + ",   ";
            
            StreamWriter sw = new StreamWriter(sPathName, true);
            sw.WriteLine(sLogFormat + sMsg);
            sw.Flush();
            sw.Close();
        }
        public void TraceLog(string sTracePathName, string sMsg)
        {
            if (sTracePathName == "") return;
            if (sTracePathName == null) return;
            sPathName = sTracePathName;
            sLogFormat = DateTime.Now.ToShortDateString().ToString() + " " + DateTime.Now.ToLongTimeString().ToString() + " ==> ";

            StreamWriter sw = new StreamWriter(sPathName, true);
            sw.WriteLine(sLogFormat + sMsg);
            sw.Flush();
            sw.Close();
        }

        public void TraceDBLog(string sModule, string sMsg)
        {
            if (sMsg == "") return;
            if (sMsg == null) return;

            if (sModule == "") return;
            if (sModule == null) return;


            sLogFormat = DateTime.Now.ToShortDateString().ToString() + " " + DateTime.Now.ToLongTimeString().ToString();

            sMsg = BuildInsertString(sModule, sMsg);
            ExecuteSQLCmd(sMsg);
            

        }


        private String BuildInsertString(String sModule, String strMsg)
        {

            String csSQLCMD;
            sLogFormat = DateTime.Now.ToShortDateString().ToString() + " " + DateTime.Now.ToLongTimeString().ToString();



            csSQLCMD = "INSERT INTO [LogTrace] ";
            csSQLCMD += "([DateTime],";
            csSQLCMD += "[Module],";
            csSQLCMD += "[EventDescription]) VALUES (";
            csSQLCMD += "'" + sLogFormat + "',";
            csSQLCMD += "'" + sModule + "',";
            csSQLCMD += "'" + strMsg + "' )";

            return csSQLCMD;
        }

        private String ExecuteSQLCmd(String csSQLCMD)
        {
            String csSQLConnectString;
            String csBuffer;
            bool blnResult = false;

            ConnectionStringSettings conn =
                  System.Configuration.ConfigurationManager.
                         ConnectionStrings["RFDBConnectionString"];
            csSQLConnectString = conn.ConnectionString;


            SqlConnection sqlConnection = new SqlConnection(csSQLConnectString);
            sqlConnection.Open();
            SqlCommand cmd = sqlConnection.CreateCommand();

            cmd.CommandText = csSQLCMD;


            try
            {

                if (csSQLCMD.Contains("INSERT"))
                {
                    SqlDataReader reader = cmd.ExecuteReader();

                    reader.Close();
                    blnResult = true;
                }
                else
                {

                    int nRowUpdated = cmd.ExecuteNonQuery();
                    if (nRowUpdated > 0)
                         blnResult = true;
                }
           
            
            }
            catch (Exception ex)
            {
                csBuffer = "Error: " + ex.Message;
                String filePath = HttpContext.Current.Server.MapPath("~/Logs/ErrorLog.csv");
                TraceLog(filePath, csBuffer); 
            }
            finally
            {
                if (sqlConnection.State != ConnectionState.Closed)
                    sqlConnection.Close();
            }

            if (!blnResult) return "";
            return "OK";

        }

       


    }

    public class DBFuncs
    {
        CreateLogFiles oLogTrace = new CreateLogFiles();

        public String GetDBStringValue(String strSQLCMD, String strCriteria)
        {
            String csBuffer;
            String csSQLCMD;

            csSQLCMD = strSQLCMD + "'" + strCriteria + "'";
            csBuffer = GetDBStringValue(csSQLCMD);

            return csBuffer;

        }


        
        public String GetDBStringValue(String strSQLCMD)
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
            csBuffer = "";
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
                oLogTrace.TraceLog(csBuffer);
                oLogTrace.TraceDBLog("DBFuncs->GetDBStringValue",csBuffer);
 
            }
            finally
            {
                if (sqlConnection.State != ConnectionState.Closed)
                    sqlConnection.Close();
            }
            return csBuffer;

        }

        public bool ExecuteSQLCMD(String strSQLCMD)
        {
            String csSQLConnectString;
            String csBuffer;
            bool blnSQLResult = true;

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

                if (strSQLCMD.Contains("INSERT"))
                {
                    SqlDataReader reader = cmd.ExecuteReader();

                    reader.Close();
                    blnSQLResult = true;
                }
                else
                {

                    int nRowUpdated = cmd.ExecuteNonQuery();
                    if (nRowUpdated > 0)
                        blnSQLResult = true;
                }


            }
            catch (Exception ex)
            {
                csBuffer = "Error: " + ex.Message;
                blnSQLResult = false;
                oLogTrace.TraceLog(csBuffer);
                oLogTrace.TraceDBLog("DBFuncs->ExecuteSQLCMD", csBuffer);

            }
            finally
            {
                if (sqlConnection.State != ConnectionState.Closed)
                    sqlConnection.Close();
            }
            return blnSQLResult;

        }

        public int GetDBIntValue(string strSQLCMD, string strArg)
        {
            int nTest = -1;
            String csTest;

            ConnectionStringSettings conn =
                  System.Configuration.ConfigurationManager.
                         ConnectionStrings["RFDBConnectionString"];
            csTest = conn.ConnectionString;


            SqlConnection sqlConnection = new SqlConnection(csTest);
            sqlConnection.Open();
            SqlCommand cmd = sqlConnection.CreateCommand();
            cmd.CommandText = strSQLCMD + "'" + strArg + "'";

            try
            {
                SqlDataReader reader = cmd.ExecuteReader();
                if (!reader.HasRows)
                {
                    // Need Error Message Here

                }
                while (reader.Read())
                {
                    nTest = System.Convert.ToInt32(reader["Counter"].ToString());

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

        public int GetDBIntFValue(string strSQLCMD, string strFieldName)
        {
            int nTest = -1;
            String csTest;

            ConnectionStringSettings conn =
                  System.Configuration.ConfigurationManager.
                         ConnectionStrings["RFDBConnectionString"];
            csTest = conn.ConnectionString;


            SqlConnection sqlConnection = new SqlConnection(csTest);
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
                while (reader.Read())
                {
                    nTest = System.Convert.ToInt32(reader[strFieldName].ToString());

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

        public int GetDBIntValue(string strSQLCMD)
        {
            int nTest = -1;
            String csTest;

            ConnectionStringSettings conn =
                  System.Configuration.ConfigurationManager.
                         ConnectionStrings["RFDBConnectionString"];
            csTest = conn.ConnectionString;


            SqlConnection sqlConnection = new SqlConnection(csTest);
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
                while (reader.Read())
                {
                    nTest = System.Convert.ToInt32(reader["Qty"].ToString());

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



        public String GetBusinessRule(String csRuleName)
        {
            String csRule = "SELECT * FROM AXLE WHERE ";
            String csBuffer;
            bool blnRuleFound = false;
            ConnectionStringSettings conn =
                  System.Configuration.ConfigurationManager.
                         ConnectionStrings["RFDBConnectionString"];
            csBuffer = conn.ConnectionString;


            SqlConnection sqlConnection = new SqlConnection(csBuffer);
            sqlConnection.Open();
            SqlCommand cmd = sqlConnection.CreateCommand();
            cmd.CommandText = "SELECT * FROM [Business Rules] WHERE [BusinessRuleName] = '" + csRuleName + "'";

            try
            {
                SqlDataReader reader = cmd.ExecuteReader();
                if (!reader.HasRows)
                {
                    // Need Error Message Here

                }
                csBuffer = "";

                while (reader.Read())
                {
                    int nMaxFieldCount = reader.FieldCount;
                   
                    // first ordinal business rule name
                    for (int nCount=1;nCount<nMaxFieldCount;nCount++)
                    {
                        blnRuleFound = true;
 
                        if (!((reader.GetValue(nCount) == null) || (reader.GetValue(nCount).ToString() == "")))
                        {
                            if ((nCount > 1)&&csBuffer!="") csBuffer += " AND ";

                            if (reader.GetValue(nCount).ToString().Contains("%"))
                            {
                                csBuffer += "["+ reader.GetName(nCount)  + "] LIKE '" + reader.GetValue(nCount).ToString() +"' "; 
                            }
                            else
                                csBuffer += "["+ reader.GetName(nCount)  + "] = '" + reader.GetValue(nCount).ToString() +"' "; 

                        }
                        


                    }
                    csRule +=csBuffer;

                }
                reader.Close();

            }
            catch (Exception ex)
            {
                csBuffer = "Error: " + ex.Message;
                oLogTrace.TraceLog(csBuffer);
                oLogTrace.TraceDBLog("DBFuncs->GetBusinessRule", csBuffer);
            }
            finally
            {
                if (sqlConnection.State != ConnectionState.Closed)
                    sqlConnection.Close();
            }

            if (blnRuleFound) return csRule; 
            return "";

        }
        public bool IsBRSatisfied(string strBR, string strTagID, string strPlantID)
        {
            string csBuffer;
            string strSQLCMD;
            strSQLCMD = "SELECT AllowBusinessRules FROM ATSSiteTable WHERE [Plant ID] = " +"'" + strPlantID +"'";
            csBuffer=GetDBStringValue(strSQLCMD).ToUpper();

            if (csBuffer.Contains("Y")||csBuffer.Contains("T"))
            {
                csBuffer = GetBusinessRule(strBR);
                if (csBuffer =="") return false;

                csBuffer = csBuffer + " AND [Tag ID] = " + "'" + strTagID + "' ";
                csBuffer = csBuffer + " AND [Plant ID] = " + "'" + strPlantID + "' ";
                csBuffer = GetDBStringValue(csBuffer);


                if (csBuffer == "")
                {
                   return false;
                }
            }
            return true;
        }

        public int CountTagIDsFound(String strSQLCMD)
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
        public bool VerifyComboSelection(MetaBuilders.WebControls.ComboBox objCombo)
        {
            if (objCombo.Text=="") return false;

            for (int nCount = 0; nCount < objCombo.Items.Count; nCount++)
            {
                if (objCombo.Text == objCombo.Items[nCount].Text)
                    return true;

            }
            return false;
        }



    }


}