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
    public class RFQGenericDB
    {

        const int RFQID = 0;
        const int LINE = 1;
        const int SEQUENCE = 2;
        const int TYPE = 3;
        const int SUBTYPE = 4;
        const int FIELDREF = 5;
        const int VALUE = 6;
        const int LASTCHANGEDATE = 7;
        const int LASTCHANGEUSER = 8;


        SqlConnection m_sqlConnect = null;
        SqlCommand sqlCmd = null;
        string[] strInputParameters;
        string m_conString = ConfigurationManager.ConnectionStrings["RFQConnectionString"].ConnectionString;
 
        public RFQGenericDB()
        {
            //
            // TODO: Add constructor logic here
            //
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

                return false;
            }

            return true;

        }



        public bool DBClose()
        {

            m_sqlConnect.Close();
            return true;
        }



        public DataTable GetRecordSet( string strSQLCMD)
        {
            try
            {
                DataTable dt = new DataTable();
                string strCMD = strSQLCMD;

                if (!DBConnect()) return null;
                sqlCmd = new SqlCommand(strCMD, m_sqlConnect);
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.CommandText = strCMD;
                sqlCmd.Connection.Open();


                SqlDataReader dr = sqlCmd.ExecuteReader(CommandBehavior.CloseConnection);

                dt.Load(dr);

                m_sqlConnect.Close();

                return dt;

            }
            catch
            {
                return null;

            }
        }

        public int GetNextMaxLineID(string strRFQID)
        {
            DataTable dt = new DataTable();
            string strCMD = "SELECT MAX(Line) FROM RFQDetail WHERE RFQID = " + strRFQID;
            int nMaxValue = -1;

            m_sqlConnect = new SqlConnection(m_conString);
            sqlCmd = new SqlCommand(strCMD, m_sqlConnect);
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = strCMD;
            sqlCmd.Connection.Open();

            try
            {
                nMaxValue = (int)sqlCmd.ExecuteScalar() + 1;
            }
            catch (Exception err)
            {

            }

            m_sqlConnect.Close();

            return nMaxValue;


        }


        public bool UpdateRFQDetailRecord(string strRFQID)
        {



            if (!DBConnect()) return false;

            string strCMD = "Update RFQDetail SET RFQID = " + strInputParameters[RFQID] + "," +
                                                   "LINE = '" + strInputParameters[LINE] + "'," +
                                                   "SEQUENCE = '" + strInputParameters[SEQUENCE] + "'," +
                                                   "TYPE = '" + strInputParameters[TYPE] + "'," +
                                                   "SUBTYPE =  '" + strInputParameters[SUBTYPE] + "'," +
                                                   "FIELDREF = '" + strInputParameters[FIELDREF] + "'," +
                                                   "VALUE = '" + strInputParameters[VALUE] + "'," +
                                                   "LASTCHANGEDATE = '" + Convert.ToDateTime(strInputParameters[LASTCHANGEDATE]) + "'," +
                                                   "WHERE RFQID = " + strRFQID + " " +
                                                   "AND TYPE = '" + strInputParameters[TYPE] + "' " +
                                                   "AND SUBTYPE = '" + strInputParameters[SUBTYPE] + "' " +
                                                   "AND FIELDREF = " + strInputParameters[FIELDREF];


            sqlCmd = new SqlCommand(strCMD, m_sqlConnect);
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = strCMD;

            sqlCmd.Connection.Open();
            sqlCmd.ExecuteNonQuery();
            sqlCmd.Connection.Close();
   
            DBClose();

            return true;
        }
    }
}