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
    public class RFQTypes
    {



        SqlConnection m_sqlConnect = null;
        SqlCommand sqlCmd = null;
   
        string m_conString = ConfigurationManager.ConnectionStrings["RFQConnectionString"].ConnectionString;
        public RFQTypes()
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


        public DataTable GetRFQTypes()
        {

            if (!DBConnect()) return null;
            DataTable dt = new DataTable();
            string strCMD = "SELECT DISTINCT Type  FROM RFQTypes";

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


        public bool DBClose()
        {

            m_sqlConnect.Close();
            return true;
        }

 

    }
}