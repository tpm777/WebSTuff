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
    public class RFQMailGroups
    {



        SqlConnection m_sqlConnect = null;
        SqlCommand sqlCmd = null;
   
        string m_conString = ConfigurationManager.ConnectionStrings["RFQConnectionString"].ConnectionString;
        public RFQMailGroups()
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


        public DataTable GetRFQMailGroups(string strRFQADGroupName)
        {

            if (!DBConnect()) return null;
            DataTable dt = new DataTable();
            string strCMD = "SELECT MailGroupNameAndAddress  FROM RFQMailGroups Where RFQADGroupName = '" + strRFQADGroupName + "'";

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