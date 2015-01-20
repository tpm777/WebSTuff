using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for RFQHeaderDB
/// </summary>
/// 
namespace RFQDBFunctions
{
    public class GenerateLoadTestData
    {

        string[] m_strInputParameters;
        string[] m_strInputDetailParameters;

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



        const int RFQID = 0;
        const int LINE = 1;
        const int SEQUENCE = 2;
        const int TYPE = 3;
        const int SUBTYPE = 4;
        const int FIELDREF = 5;
        const int DESCRIPTION = 6;
        const int VALUE = 7;
        const int LASTCHANGEDATE = 8;
        const int LASTCHANGEUSER = 9;
        const int PRODUCTGROUP = 10;


        SqlConnection m_sqlConnect = null;
        SqlCommand sqlCmd = null;
     
        private int m_nIdentityID = -1;
        private string m_strUserID;
        string m_strDateTimeFormat = "MM/dd/yyyy HH:mm";
        private string m_strErrorMessage = "";
   
        string m_conString = ConfigurationManager.ConnectionStrings["RFQLoadTestConnectionString"].ConnectionString;
        public GenerateLoadTestData()
  	    {
		//
		// TODO: Add constructor logic here
		//
	    }
        public bool DBConnect()
        {
            try
            {
                m_sqlConnect = new SqlConnection(m_conString);
            }
            catch (Exception err)
            {

                return false;
            }

            return true;

        }



        public bool DBClose()
        {

            m_sqlConnect.Close();
            return true;
        }

        public void GenerateTestDataSet()
        {
            InitDataSet();
            for (int nTest=0;nTest<100;nTest++)
            {

                int nRFQID = CreateNewRFQHeaderRecord();
                if (nRFQID == -1) return;
                m_strInputDetailParameters[RFQID] = nRFQID.ToString();
                m_strInputDetailParameters[TYPE] = "Hardware";
                m_strInputDetailParameters[SUBTYPE] = "Printer";
                m_strInputDetailParameters[LINE] = "1";
                m_strInputDetailParameters[LASTCHANGEDATE] = "2014-11-04";
                m_strInputDetailParameters[LASTCHANGEUSER] = "LoadTest";
                m_strInputDetailParameters[PRODUCTGROUP] = "0902 - Vial Labels";


                m_strInputDetailParameters[SEQUENCE] = "1";
                m_strInputDetailParameters[FIELDREF] = "1";
                m_strInputDetailParameters[DESCRIPTION] = "Make and Model";
                m_strInputDetailParameters[VALUE] = "GX430t";
                if (!CreateNewRFQDetailRecord()) return;

                m_strInputDetailParameters[SEQUENCE] = "2";
                m_strInputDetailParameters[FIELDREF] = "2";
                m_strInputDetailParameters[DESCRIPTION] = "Resolution";
                m_strInputDetailParameters[VALUE] = "300";
                if (!CreateNewRFQDetailRecord()) return;


                m_strInputDetailParameters[SEQUENCE] = "3";
                m_strInputDetailParameters[FIELDREF] = "3";
                m_strInputDetailParameters[DESCRIPTION] = "Option/Accessories";
                m_strInputDetailParameters[VALUE] = "[Enhanced (Zebra)]";
                if (!CreateNewRFQDetailRecord()) return;


                m_strInputDetailParameters[SEQUENCE] = "4";
                m_strInputDetailParameters[FIELDREF] = "4";
                m_strInputDetailParameters[DESCRIPTION] = "Service Contract";
                m_strInputDetailParameters[VALUE] = "Bronze";
                if (!CreateNewRFQDetailRecord()) return;

                m_strInputDetailParameters[SEQUENCE] = "5";
                m_strInputDetailParameters[FIELDREF] = "5";
                m_strInputDetailParameters[DESCRIPTION] = "Drop Ship?";
                m_strInputDetailParameters[VALUE] = "No";
                if (!CreateNewRFQDetailRecord()) return;

                m_strInputDetailParameters[SEQUENCE] = "6";
                m_strInputDetailParameters[FIELDREF] = "6";
                m_strInputDetailParameters[DESCRIPTION] = "Set-up Labels Required?";
                m_strInputDetailParameters[VALUE] = "Yes";
                if (!CreateNewRFQDetailRecord()) return;


                m_strInputDetailParameters[SEQUENCE] = "7";
                m_strInputDetailParameters[FIELDREF] = "7";
                m_strInputDetailParameters[DESCRIPTION] = "Notes";
                m_strInputDetailParameters[VALUE] = "This is a new Label Replicator Quote";
                if (!CreateNewRFQDetailRecord()) return;
            
            }

        }
        private void InitDataSet()
        {
           m_strInputParameters[RFQDESCRIPTION]       = "Color Ink jet Prime Product Labels";

           m_strInputParameters[DATECREATED]          = DateTime.Now.ToShortTimeString(); 
           m_strInputParameters[DATESUBMITTED]        = "";
           m_strInputParameters[DATEQUOTED]           = "";
           m_strInputParameters[DATELASTREVISED]      = "";
           m_strInputParameters[CURRENCY]             = "US Dollar";
           m_strInputParameters[CONTACTNAME]          = "Daniel Pedro de Souza";
           m_strInputParameters[PARENTCUSTOMERNAME]   = "Veyance Technologies do Brasil";
           m_strInputParameters[OPPORTUNITYID]        = "{CD0D6E45-3264-E411-80E8-005056814F09}";
           m_strInputParameters[REQUESTOR]            = "Paul Burlington";          
           m_strInputParameters[RFQSTATUS]            = "40";
           m_strInputParameters[CONTACTCRMID]         = "{FC5727A6-3064-E411-80E8-005056814F09}";
           m_strInputParameters[PARENTCUSTOMERCRMID]  = "{A4D44E82-B9E5-DF11-A1B2-7ACD9F6233CC}";
           m_strInputParameters[DATEREVISED]          = "";
           m_strInputParameters[DATEREQUIRED]         = "";
           m_strInputParameters[CHANGEDBY]            = "";
           m_strInputParameters[REASONFORCHANGE]      = "";
           m_strInputParameters[GHSOPPORTUNITY]       = "NO";
           m_strInputParameters[NPRNUMBER]            = "";
           m_strInputParameters[EPICORQUOTENUM]       = "";
           


        }


        public int CreateNewRFQHeaderRecord()
        {
            m_strErrorMessage = "";
            if (!DBConnect()) return -1;

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

                sqlCmd.Parameters.AddWithValue("@rfqdescription", m_strInputParameters[RFQDESCRIPTION]);
                sqlCmd.Parameters.AddWithValue("@datecreated", m_strInputParameters[DATECREATED]);

                sqlCmd.Parameters.AddWithValue("@datesubmitted", m_strInputParameters[DATESUBMITTED]);
                sqlCmd.Parameters.AddWithValue("@datequoted", m_strInputParameters[DATEQUOTED]);
                sqlCmd.Parameters.AddWithValue("@datelastrevised", m_strInputParameters[DATELASTREVISED]);

                sqlCmd.Parameters.AddWithValue("@currency", m_strInputParameters[CURRENCY]);
                sqlCmd.Parameters.AddWithValue("@contactname", m_strInputParameters[CONTACTNAME]);
                sqlCmd.Parameters.AddWithValue("@parentcustomename", m_strInputParameters[PARENTCUSTOMERNAME]);

                sqlCmd.Parameters.AddWithValue("@opportunityid", m_strInputParameters[OPPORTUNITYID]);
                sqlCmd.Parameters.AddWithValue("@requestor", m_strInputParameters[REQUESTOR]);
                sqlCmd.Parameters.AddWithValue("@rfqstatus", m_strInputParameters[RFQSTATUS]);
                sqlCmd.Parameters.AddWithValue("@contactCRMID", m_strInputParameters[CONTACTCRMID]);
                sqlCmd.Parameters.AddWithValue("@parentCustomerCRMID", m_strInputParameters[PARENTCUSTOMERCRMID]);
                sqlCmd.Parameters.AddWithValue("@daterevised", m_strInputParameters[DATEREVISED]);
                sqlCmd.Parameters.AddWithValue("@daterequired", m_strInputParameters[DATEREQUIRED]);
                sqlCmd.Parameters.AddWithValue("@changedBy", m_strInputParameters[CHANGEDBY]);
                sqlCmd.Parameters.AddWithValue("@reasonforchange", m_strInputParameters[REASONFORCHANGE]);
                sqlCmd.Parameters.AddWithValue("@ghsopportunity", m_strInputParameters[GHSOPPORTUNITY]);
                sqlCmd.Parameters.AddWithValue("@nprnumber", m_strInputParameters[NPRNUMBER]);
                sqlCmd.Parameters.AddWithValue("@epicorquotenum",m_strInputParameters[EPICORQUOTENUM]);

                try
                {
                    sqlCmd.Connection.Open();


                    m_nIdentityID = Convert.ToInt32(sqlCmd.ExecuteScalar());
                }
                catch (SqlException)
                {
                    // error here
                    ErrorMsg = "Error Adding RFQ Header Record";
                    return -1;
                }
                finally
                {
                    DBClose();
                }



                return m_nIdentityID;
            }
            catch (Exception err)
            {
                ErrorMsg = err.Message;
            }
            return -1;

        }

        public bool CreateNewRFQDetailRecord()
        {




            if (!DBConnect()) return false;

            string strCMD = "INSERT into RFQDetail (RFQID," +
                                                   "Line," +
                                                   "Sequence," +
                                                   "Type," +
                                                   "SubType," +
                                                   "FieldRef," +
                                                   "Description," +
                                                   "Value," +
                                                   "LastChangeDate," +
                                                   "LastChangeUser," +
                                                   "ProductGroup)"
                                                   +
                                                   "VALUES (@rfqid," +
                                                           "@line," +
                                                           "@sequence," +
                                                           "@type," +
                                                           "@subtype," +
                                                           "@fieldref," +
                                                           "@description," +
                                                           "@value," +
                                                           "@lastchangedate," +
                                                           "@lastchangeuser," +
                                                           "@productgroup)";
            try
            {



                sqlCmd = new SqlCommand(strCMD, m_sqlConnect);
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.CommandText = strCMD;

                sqlCmd.Parameters.AddWithValue("@rfqid", m_strInputDetailParameters[RFQID]);
                sqlCmd.Parameters.AddWithValue("@line", m_strInputDetailParameters[LINE]);

                sqlCmd.Parameters.AddWithValue("@sequence", m_strInputDetailParameters[SEQUENCE]);
                sqlCmd.Parameters.AddWithValue("@type", m_strInputDetailParameters[TYPE]);
                sqlCmd.Parameters.AddWithValue("@subtype", m_strInputDetailParameters[SUBTYPE]);
                sqlCmd.Parameters.AddWithValue("@fieldref", m_strInputDetailParameters[FIELDREF]);
                sqlCmd.Parameters.AddWithValue("@description", m_strInputDetailParameters[DESCRIPTION]);
                sqlCmd.Parameters.AddWithValue("@value", m_strInputDetailParameters[VALUE]);
                sqlCmd.Parameters.AddWithValue("@lastchangedate", m_strInputDetailParameters[LASTCHANGEDATE]);
                sqlCmd.Parameters.AddWithValue("@lastchangeuser", m_strInputDetailParameters[LASTCHANGEUSER]);
                sqlCmd.Parameters.AddWithValue("@productgroup", m_strInputDetailParameters[PRODUCTGROUP]);

                try
                {
                    sqlCmd.Connection.Open();
                    sqlCmd.ExecuteNonQuery();

                }
                catch (SqlException)
                {
                    // error here
                }
                finally
                {
                    DBClose();
                }



                return true;
            }
            catch (Exception err)
            {

            }
            return false;

        }


        public string ErrorMsg
        {
            get { return m_strErrorMessage; }
            set { m_strErrorMessage = value; }
        }
    }
}