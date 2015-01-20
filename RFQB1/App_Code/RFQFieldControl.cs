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
    public class RFQFieldControl
    {



        SqlConnection m_sqlConnect = null;
        SqlCommand sqlCmd = null;
   
        string m_conString = ConfigurationManager.ConnectionStrings["RFQConnectionString"].ConnectionString;
        public RFQFieldControl()
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


        public DataTable GetRFQFieldControlTypes(string strFieldType, string strSubType)
        {

            if (!DBConnect()) return null;
            DataTable dt = new DataTable();
            string strCMD = "SELECT *  FROM RFQFieldControlReference Where Type = '" + strFieldType + "' AND SubType = '" + strSubType + "' ORDER BY SORTOrder";

            sqlCmd = new SqlCommand(strCMD, m_sqlConnect);
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = strCMD;
            sqlCmd.Connection.Open();


            SqlDataReader dr = sqlCmd.ExecuteReader(CommandBehavior.CloseConnection);

            dt.Load(dr);
            sqlCmd.Connection.Close(); 
            DBClose();

            return dt;



        }
        public DataTable GetRFQFieldControlRecord(string strFieldType, string strSubType, string strFieldRef)
        {

            if (!DBConnect()) return null;
            DataTable dt = new DataTable();
            string strCMD = "SELECT Required, Validation, Description, InputControlOptions, ControlTip FROM RFQFieldControlReference Where Type = '" + strFieldType + "' AND SubType = '" + strSubType + "' AND FieldRef = " + strFieldRef ;

            sqlCmd = new SqlCommand(strCMD, m_sqlConnect);
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = strCMD;
            sqlCmd.Connection.Open();


            SqlDataReader dr = sqlCmd.ExecuteReader(CommandBehavior.CloseConnection);

            dt.Load(dr);
            sqlCmd.Connection.Close();
            DBClose();

            return dt;



        }
        public DataTable GetRFQFieldControlInfo(string strFieldType, string strSubType, string strFieldRef)
        {

            if (!DBConnect()) return null;
            DataTable dt = new DataTable();
            string strCMD = "SELECT Required, Validation, Description, InputControlType, InputControlOptions, ControlTip FROM RFQFieldControlReference Where Type = '" + strFieldType + "' AND SubType = '" + strSubType + "' AND FieldRef = " + strFieldRef;

            sqlCmd = new SqlCommand(strCMD, m_sqlConnect);
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = strCMD;
            sqlCmd.Connection.Open();


            SqlDataReader dr = sqlCmd.ExecuteReader(CommandBehavior.CloseConnection);

            dt.Load(dr);
            sqlCmd.Connection.Close();
            DBClose();

            return dt;



        }

        public bool IsRFQDetailARequiredField(string strFieldType, string strSubType, int nFieldRef)
        {

            if (!DBConnect()) return false;
            DataTable dt = new DataTable();
            string strCMD = "SELECT FieldRef Required FROM RFQFieldControlReference Where Type = '" + strFieldType +
                                                                                  "' AND SubType = '" + strSubType + "' " +
                                                                                  " AND FieldRef = " + nFieldRef + " " + 
                                                                                  " AND Required = 'Y' AND Active = 'Y'"; 
                                                                                   

            sqlCmd = new SqlCommand(strCMD, m_sqlConnect);
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = strCMD;
            sqlCmd.Connection.Open();


            SqlDataReader dr = sqlCmd.ExecuteReader(CommandBehavior.CloseConnection);

            dt.Load(dr);
            sqlCmd.Connection.Close();
            DBClose();

            if (dt.Rows.Count > 0) return true; 

            return false;



        }



        public bool DBClose()
        {

            m_sqlConnect.Close();
            return true;
        }

 

    }
}