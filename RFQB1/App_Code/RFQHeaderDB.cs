using System;
using System.Configuration;
using System.Collections.Generic;
//using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for RFQHeaderDB
/// </summary>
/// 
namespace RFQDBFunctions
{


    public class RFQHeaderDB
    {

        const int RFQDESCRIPTION = 0;
        const int DATECREATED = 1;
        const int DATESUBMITTED = 2;
        const int DATEQUOTED = 3;
        const int DATELASTREVISED = 4;
        const int CURRENCY = 5;
        const int CONTACTNAME = 6;
        const int PARENTCUSTOMERNAME = 7;
        const int OPPORTUNITYID = 8;
        const int REQUESTOR = 9;
        const int RFQSTATUS = 10;
        const int CONTACTCRMID = 11;
        const int PARENTCUSTOMERCRMID = 12;
        const int DATEREVISED = 13;
        const int DATEREQUIRED = 14;
        const int CHANGEDBY = 15;
        const int REASONFORCHANGE = 16;
        const int GHSOPPORTUNITY = 17;
        const int NPRNUMBER = 18;
        const int EPICORQUOTENUM = 19;

        SqlConnection m_sqlConnect = null;
        SqlCommand sqlCmd = null;
        string[] strInputParameters;
        string m_conString = ConfigurationManager.ConnectionStrings["RFQConnectionString"].ConnectionString;
        private int m_nIdentityID = -1;
        private string  m_strUserID;
        string m_strDateTimeFormat = "MM/dd/yyyy HH:mm";
        private string m_strErrorMessage = "";

        public RFQHeaderDB()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public RFQHeaderDB(string strUserID)
        {
            //
            // TODO: Add constructor logic here
            //
            m_strUserID = strUserID;
        }
        public void SetInputArray(string strParams)
        {
            strInputParameters = strParams.Split(',');



        }
        public bool DBConnect()
        {
            try
            {
                m_sqlConnect = new SqlConnection(m_conString);
            }
            catch (Exception err)
            {
                ErrorMsg = err.Message;
                return false;
            }

            return true;

        }


        public bool CreateNewRFQHeaderRecord()
        {
            m_strErrorMessage = "";
            if (!DBConnect()) return false;

            string strCMD = "INSERT into RFQHeader (RFQDescription," +
                                                   "DateCreated," +
                                                   "DateSubmitted," +
                                                   "DateQuoted," +
                                                   "DateLastRevised," +
                                                   "Currency," +
                                                   "ContactName," +
                                                   "ParentCustomerName," +
                                                   "OpportunityID," +
                                                   "Requestor," +
                                                   "RFQStatus," +
                                                   "ContactCRMID," +
                                                   "ParentCustomerCRMID," +
                                                   "DateRevised," +
                                                   "DateRequired," +
                                                   "ChangedBy," +
                                                   "ReasonForChange," +
                                                   "GHSOpportunity," + 
                                                   "NPRNumber," +
                                                   "EpicorQuoteNum)" +             
                                                   "VALUES (@rfqdescription," +
                                                           "@datecreated," +
                                                           "@datesubmitted," +
                                                           "@datequoted," +
                                                           "@datelastrevised," +
                                                           "@currency," +
                                                           "@contactname," +
                                                           "@parentcustomename," +
                                                           "@opportunityid," +
                                                           "@requestor," +
                                                           "@rfqstatus," +
                                                           "@contactCRMID," +
                                                           "@parentCustomerCRMID," +
                                                           "@daterevised," +
                                                           "@daterequired," +
                                                           "@changedBy," +
                                                           "@reasonforchange," +
                                                           "@ghsopportunity," +
                                                           "@nprnumber," + 
                                                           "@epicorquotenum)" + "Select Scope_Identity()"; 

            try
            {
               
                sqlCmd = new SqlCommand(strCMD, m_sqlConnect);
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.CommandText = strCMD;

                //                sqlCmd.Parameters.AddWithValue("@rfqid", strInputParameters[0]);
                sqlCmd.Parameters.AddWithValue("@rfqdescription", strInputParameters[0]);
                sqlCmd.Parameters.AddWithValue("@datecreated", strInputParameters[1]);

                sqlCmd.Parameters.AddWithValue("@datesubmitted", strInputParameters[2]);
                sqlCmd.Parameters.AddWithValue("@datequoted", strInputParameters[3]);
                sqlCmd.Parameters.AddWithValue("@datelastrevised", strInputParameters[4]);

                sqlCmd.Parameters.AddWithValue("@currency", strInputParameters[5]);
                sqlCmd.Parameters.AddWithValue("@contactname", strInputParameters[6]);
                sqlCmd.Parameters.AddWithValue("@parentcustomename", strInputParameters[7]);

                sqlCmd.Parameters.AddWithValue("@opportunityid", strInputParameters[8]);
                sqlCmd.Parameters.AddWithValue("@requestor", strInputParameters[9]);
                sqlCmd.Parameters.AddWithValue("@rfqstatus", strInputParameters[10]);
                sqlCmd.Parameters.AddWithValue("@contactCRMID", strInputParameters[11]);
                sqlCmd.Parameters.AddWithValue("@parentCustomerCRMID", strInputParameters[12]);
                sqlCmd.Parameters.AddWithValue("@daterevised", strInputParameters[13]);
                sqlCmd.Parameters.AddWithValue("@daterequired", strInputParameters[14]);
                sqlCmd.Parameters.AddWithValue("@changedBy", strInputParameters[15]);
                sqlCmd.Parameters.AddWithValue("@reasonforchange", strInputParameters[16]);
                sqlCmd.Parameters.AddWithValue("@ghsopportunity", strInputParameters[17]);
                sqlCmd.Parameters.AddWithValue("@nprnumber", strInputParameters[18]);
                sqlCmd.Parameters.AddWithValue("@epicorquotenum", strInputParameters[EPICORQUOTENUM]);

                try
                {
                    sqlCmd.Connection.Open();

   
                    m_nIdentityID = Convert.ToInt32(sqlCmd.ExecuteScalar());
                }
                catch (SqlException)
                {
                    // error here
                    ErrorMsg = "Error Adding RFQ Header Record";
                    return false;
                }
                finally
                {
                    DBClose();
                }



                return true;
            }
            catch (Exception err)
            {
                ErrorMsg = err.Message;
            }
            return false;

        }


        public bool DBClose()
        {

            m_sqlConnect.Close();
            return true;
        }

        public bool InsertRFQHeaderRec()
        {

            return true;
        }


        public DataTable GetRFQIDRecord(string strConnectionString, string strRFQID)
        {
            DataTable dt = new DataTable();
            string strCMD = "SELECT * FROM RFQHeader WHERE RFQID = " + strRFQID;

            m_sqlConnect = new SqlConnection(strConnectionString);
            sqlCmd = new SqlCommand(strCMD, m_sqlConnect);
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = strCMD;
            sqlCmd.Connection.Open();
      

            SqlDataReader dr = sqlCmd.ExecuteReader(CommandBehavior.CloseConnection);

            dt.Load(dr);
   
            m_sqlConnect.Close();

            return dt;


        }
        public int GetIndentityID()
        {

            return m_nIdentityID;
        }

        public bool UpdateRFQRecords(string strRFQID)
        {



            if (!DBConnect()) return false;

            string strCMD = "Update RFQHeader SET RFQDescription = '" + strInputParameters[RFQDESCRIPTION] + "'," +
                                                   "DateCreated = '" + Convert.ToDateTime (strInputParameters[DATECREATED]) + "'," +
                                                   "DateSubmitted = '" + Convert.ToDateTime (strInputParameters[DATESUBMITTED]) + "'," +
                                                   "DateQuoted = '" + Convert.ToDateTime(strInputParameters[DATEQUOTED]) + "'," +
                                                   "DateLastRevised = '" + Convert.ToDateTime(strInputParameters[DATELASTREVISED]) + "'," +
                                                   "Currency =  '" + strInputParameters[CURRENCY] + "'," +
                                                   "ContactName = '" + strInputParameters[CONTACTNAME] + "'," +
                                                   "ParentCustomerName = '" + strInputParameters[PARENTCUSTOMERNAME] + "'," +
                                                   "OpportunityID = '" + strInputParameters[OPPORTUNITYID] + "'," +
                                                   "Requestor = '" + strInputParameters[REQUESTOR] + "'," +
                                                   "RFQStatus = '" + strInputParameters[RFQSTATUS] + "', " +
                                                   "ContactCRMID = '" + strInputParameters[CONTACTCRMID] + "', " +
                                                   "ParentCustomerCRMID = '" + strInputParameters[PARENTCUSTOMERCRMID] + "', " +
                                                   "DateRevised = '" + Convert.ToDateTime(strInputParameters[DATEREVISED]) + "'," +
                                                   "DateRequired = '" + Convert.ToDateTime(strInputParameters[DATEREQUIRED]) + "'," +
                                                   "ChangedBy = '" + Convert.ToDateTime(strInputParameters[CHANGEDBY]) + "'," +
                                                   "ReasonForChange = '" + Convert.ToDateTime(strInputParameters[REASONFORCHANGE]) + "', " +
                                                   "GHSOpportunity = '" + strInputParameters[GHSOPPORTUNITY] + "', " +
                                                   "NPRNUMBER = '" + strInputParameters[NPRNUMBER] + "', " +
                                                   "EPICORQUOTENUM = '" + strInputParameters[EPICORQUOTENUM] + "' " +
                                                   "WHERE RFQID = " + strRFQID  ;

            sqlCmd = new SqlCommand(strCMD, m_sqlConnect);
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = strCMD;

            sqlCmd.Connection.Open();
            sqlCmd.ExecuteNonQuery();
            sqlCmd.Connection.Close();
   
            DBClose();

            return true;
        }
        public int GetNextHeaderRecord()
        {
            DataTable dt = new DataTable();
            string strCMD = "SELECT MAX(RFQID) FROM RFQHeader";

            m_sqlConnect = new SqlConnection(m_conString);
            sqlCmd = new SqlCommand(strCMD, m_sqlConnect);
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = strCMD;
            sqlCmd.Connection.Open();


            int nNexRFQRecord = (int)sqlCmd.ExecuteScalar()+1; 

    
            sqlCmd.Connection.Close();
  
            m_sqlConnect.Close();

            return nNexRFQRecord;


        }
        public bool UpdateLastRevised(string strLastRevised, string strRFQID)
        {
            string strInProcessValue = "50";
          
            if (string.IsNullOrEmpty(strLastRevised)) return false;
            if (string.IsNullOrEmpty(strRFQID)) return false;
 
            if (!DBConnect()) return false;

            try
            {


                string strCMD = "Update RFQHeader SET DateRevised = '" + Convert.ToDateTime(strLastRevised) + "', " +
                                               "DateLastRevised = '" + Convert.ToDateTime(strLastRevised) + "', " +
                                               "RFQStatus = '" + strInProcessValue + "', " +
                                               "ReasonForChange = '" + "RFQ Status Changed To In Process" + "' " +
                                               (string.IsNullOrEmpty(m_strUserID) ? " " : ",  ChangedBy = '" + m_strUserID + "' ") +
                                               "WHERE RFQID = " + strRFQID;




                sqlCmd = new SqlCommand(strCMD, m_sqlConnect);
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.CommandText = strCMD;

                sqlCmd.Connection.Open();
                sqlCmd.ExecuteNonQuery();
                sqlCmd.Connection.Close();

                DBClose();

                return true;
            }
            catch (Exception err)
            {


            }
            return false;

        }
       
        public bool UpdateLastChanged(string strLastRevised, string strRFQID)
        {

           
            if (string.IsNullOrEmpty(strLastRevised)) return false;
            if (string.IsNullOrEmpty(strRFQID)) return false;
            string strCMD  = null;
            if (!DBConnect()) return false;
            
            try
            {
                if (!string.IsNullOrEmpty(m_strUserID))
                {
                 strCMD = "Update RFQHeader SET DateLastRevised = '" + Convert.ToDateTime(strLastRevised) + "' , " +
                                                       "ChangedBy = '" + m_strUserID  + "' " +
                                                       "WHERE RFQID = " + strRFQID;
                }
                else
                {
                    strCMD = "Update RFQHeader SET DateLastRevised = '" + Convert.ToDateTime(strLastRevised) + "'  " +
                                                
                                                       "WHERE RFQID = " + strRFQID;
                }
  

                sqlCmd = new SqlCommand(strCMD, m_sqlConnect);
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.CommandText = strCMD;

                sqlCmd.Connection.Open();
                sqlCmd.ExecuteNonQuery();
                sqlCmd.Connection.Close();

                DBClose();

                return true;
            }
            catch (Exception err)
            {


            }
            return false;

        }
        public bool UpdateLastChanged(string strReasonForChange, string strLastRevised, string strRFQID)
        {


            if (string.IsNullOrEmpty(strLastRevised)) return false;
            if (string.IsNullOrEmpty(strRFQID)) return false;
            string strCMD = null;
            if (!DBConnect()) return false;

            try
            {
                if (!string.IsNullOrEmpty(m_strUserID))
                {
                    strCMD = "Update RFQHeader SET DateLastRevised = '" + Convert.ToDateTime(strLastRevised) + "' , " +
                                                          "ChangedBy = '" + m_strUserID + "', " +
                                                          "ReasonForChange = '" + strReasonForChange + "' " +
                                                          "WHERE RFQID = " + strRFQID;
                }
                else
                {
                    strCMD = "Update RFQHeader SET DateLastRevised = '" + Convert.ToDateTime(strLastRevised) + "'  " +

                                                       "WHERE RFQID = " + strRFQID;
                }


                sqlCmd = new SqlCommand(strCMD, m_sqlConnect);
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.CommandText = strCMD;

                sqlCmd.Connection.Open();
                sqlCmd.ExecuteNonQuery();
                sqlCmd.Connection.Close();

                DBClose();

                return true;
            }
            catch (Exception err)
            {


            }
            return false;

        }
        
        
        public bool UpdateSubmitted(string strDateSubmitted, string strRFQID)
        {

            string strInProcessValue = "20";
            if (string.IsNullOrEmpty(strDateSubmitted)) return false;
            if (string.IsNullOrEmpty(strRFQID)) return false;

            if (!DBConnect()) return false;

            try
            {
                string strCMD = "Update RFQHeader SET DateSubmitted = '" + Convert.ToDateTime(strDateSubmitted) + "', " +
                                                               "RFQStatus = '" + strInProcessValue + "' " +
                                                               "WHERE RFQID = " + strRFQID;


                sqlCmd = new SqlCommand(strCMD, m_sqlConnect);
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.CommandText = strCMD;

                sqlCmd.Connection.Open();
                sqlCmd.ExecuteNonQuery();
                sqlCmd.Connection.Close();

                DBClose();

                return true;
            }
            catch (Exception err)
            {


            }
            return false;

        }

        public bool UpdateDateRequested(string strDateRequested, string strRFQID)
        {


            if (string.IsNullOrEmpty(strDateRequested)) return false;
            if (string.IsNullOrEmpty(strRFQID)) return false;

            if (!DBConnect()) return false;

            try
            {
                string strCMD = "Update RFQHeader SET DateRequired = '" + Convert.ToDateTime(strDateRequested) + "' " +
                                                               "WHERE RFQID = " + strRFQID;


                sqlCmd = new SqlCommand(strCMD, m_sqlConnect);
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.CommandText = strCMD;

                sqlCmd.Connection.Open();
                sqlCmd.ExecuteNonQuery();
                sqlCmd.Connection.Close();

                DBClose();

                return true;
            }
            catch (Exception err)
            {


            }
            return false;

        }


        public bool UpdateEpicorQuoteNum(string strEpicorQuoteNum, string strRFQID)
        {


            if (string.IsNullOrEmpty(strEpicorQuoteNum)) return false;
            if (string.IsNullOrEmpty(strRFQID)) return false;

            if (!DBConnect()) return false;

            try
            {
                string strCMD = "Update RFQHeader SET EpicorQuoteNum = '" + strEpicorQuoteNum + "' " +
                                                               "WHERE RFQID = " + strRFQID;


                sqlCmd = new SqlCommand(strCMD, m_sqlConnect);
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.CommandText = strCMD;

                sqlCmd.Connection.Open();
                sqlCmd.ExecuteNonQuery();
                sqlCmd.Connection.Close();

                DBClose();

                return true;
            }
            catch (Exception err)
            {
                ErrorMsg = string.Format("Error Updating RFQ Header Quote Num:  [{0}]", err.Message);

            }
            return false;

        }
        
        

        public bool RFQQuoted(string strQuoted, string strRFQID)
        {

            string strInProcessValue = "40";
            if (string.IsNullOrEmpty(strQuoted)) return false;
            if (string.IsNullOrEmpty(strRFQID)) return false;

            if (!DBConnect()) return false;

            try
            {
                    string strCMD = "Update RFQHeader SET DateQuoted = '" + Convert.ToDateTime(strQuoted) + "', " +
                                                                   "DateLastRevised = '" + Convert.ToDateTime(strQuoted) + "', " +
                                                                   "RFQStatus = '" + strInProcessValue + "', " +
                                                                   "ReasonForChange = '" + "RFQ Quoted" + "' " +
                                                                   (string.IsNullOrEmpty(m_strUserID) ? " "  : ",  ChangedBy = '" + m_strUserID + "' " ) +

                                                                   "WHERE RFQID = " + strRFQID;

                        

                sqlCmd = new SqlCommand(strCMD, m_sqlConnect);
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.CommandText = strCMD;

                sqlCmd.Connection.Open();
                sqlCmd.ExecuteNonQuery();
                sqlCmd.Connection.Close();

                DBClose();

                return true;
            }
            catch (Exception err)
            {


            }
            return false;

        }
        public bool RFQCompleted(string strCompletedDateTime, string strRFQID)
        {

            string strInProcessValue = "80";
            if (string.IsNullOrEmpty(strCompletedDateTime)) return false;
            if (string.IsNullOrEmpty(strRFQID)) return false;

            if (!DBConnect()) return false;

            try
            {
                string strCMD = "Update RFQHeader SET DateLastRevised = '" + Convert.ToDateTime(strCompletedDateTime) + "', " +
                                                               "RFQStatus = '" + strInProcessValue + "', " +
                                                               "ReasonForChange = '" + "RFQ Completed" + "' " +
                                                               (string.IsNullOrEmpty(m_strUserID) ? " " : ",  ChangedBy = '" + m_strUserID + "' ") +
                                                               "WHERE RFQID = " + strRFQID;



                sqlCmd = new SqlCommand(strCMD, m_sqlConnect);
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.CommandText = strCMD;

                sqlCmd.Connection.Open();
                sqlCmd.ExecuteNonQuery();
                sqlCmd.Connection.Close();

                DBClose();

                return true;
            }
            catch (Exception err)
            {


            }
            return false;

        }
        public bool RFQCancelled(string strCompletedDateTime, string strRFQID)
        {

            string strInProcessValue = "90";
            if (string.IsNullOrEmpty(strCompletedDateTime)) return false;
            if (string.IsNullOrEmpty(strRFQID)) return false;

            if (!DBConnect()) return false;

            try
            {
                string strCMD = "Update RFQHeader SET DateLastRevised = '" + Convert.ToDateTime(strCompletedDateTime) + "', " +
                                                               "RFQStatus = '" + strInProcessValue + "', " +
                                                               "ReasonForChange = '" + "RFQ Cancelled" + "' " +
                                                               (string.IsNullOrEmpty(m_strUserID) ? " " : ",  ChangedBy = '" + m_strUserID + "' ") +
                                                               "WHERE RFQID = " + strRFQID;



                sqlCmd = new SqlCommand(strCMD, m_sqlConnect);
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.CommandText = strCMD;

                sqlCmd.Connection.Open();
                sqlCmd.ExecuteNonQuery();
                sqlCmd.Connection.Close();

                DBClose();

                return true;
            }
            catch (Exception err)
            {


            }
            return false;

        }

        public bool RFQInProcess(string strRFQID)
        {

            string strInProcessValue = "30";
            if (string.IsNullOrEmpty(strRFQID)) return false;

            if (!DBConnect()) return false;

            try
            {
                string strCMD = "Update RFQHeader SET DateLastRevised = '" + DateTime.Now.ToString(m_strDateTimeFormat) + "', " +
                                                               "RFQStatus = '" + strInProcessValue + "', " +
                                                               "ReasonForChange = '" + "Status Changed To In Process" + "' " +
                                                               (string.IsNullOrEmpty(m_strUserID) ? " " : ",  ChangedBy = '" + m_strUserID + "' ") +
                                                               "WHERE RFQID = " + strRFQID;



                sqlCmd = new SqlCommand(strCMD, m_sqlConnect);
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.CommandText = strCMD;

                sqlCmd.Connection.Open();
                sqlCmd.ExecuteNonQuery();
                sqlCmd.Connection.Close();

                DBClose();

                return true;
            }
            catch (Exception err)
            {


            }
            return false;

        }

        public int GetRFQCurrentStatus(string strRFQID)
        {
            int nRFQStatus = 0;
            try
            {

                if (!DBConnect()) return -1;
                DataTable dt = new DataTable();
                string strCMD = "SELECT RFQStatus FROM RFQHeader Where RFQID = " + strRFQID;

                sqlCmd = new SqlCommand(strCMD, m_sqlConnect);
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.CommandText = strCMD;
                sqlCmd.Connection.Open();


                SqlDataReader dr = sqlCmd.ExecuteReader(CommandBehavior.CloseConnection);
                dr.Read(); 
                nRFQStatus = Convert.ToInt32((string)dr[0] );
                sqlCmd.Connection.Close();
                DBClose();
            }
            catch (Exception err)
            {
                ErrorMsg = err.Message;
                return -1;
            }
            return nRFQStatus;



        }
        public string ErrorMsg
        {
            get { return m_strErrorMessage ; }
            set { m_strErrorMessage = value; }
        }
    }
}