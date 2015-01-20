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
    public class RFQSubTypes
    {



        SqlConnection m_sqlConnect = null;
        SqlCommand sqlCmd = null;
 
        string m_conString = ConfigurationManager.ConnectionStrings["RFQConnectionString"].ConnectionString;
 
        public RFQSubTypes()
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


        public DataTable GetRFQSubTypes(string strRFQType)
        {

            if (!DBConnect()) return null;
            DataTable dt = new DataTable();
            string strCMD = "SELECT DISTINCT SubType   FROM RFQTypes  WHERE TYPE = '" + strRFQType + "'";

            sqlCmd = new SqlCommand(strCMD, m_sqlConnect);
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = strCMD;
            sqlCmd.Connection.Open();


            SqlDataReader dr = sqlCmd.ExecuteReader(CommandBehavior.CloseConnection);

            dt.Load(dr);

            m_sqlConnect.Close();

            return dt;



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


    }
}