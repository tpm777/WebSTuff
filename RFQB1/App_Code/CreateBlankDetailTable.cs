using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;


/// <summary>
/// Summary description for CreateBlankDetailTable
/// </summary>
namespace RFQDBFunctions
{/// 
    public class CreateBlankDetailTable
    {
        private string m_strType;
        private string m_strSubType;
 
        SqlDataReader sqlReader; 

        public CreateBlankDetailTable(string strType, string strSubType)
        {
            //
            // TODO: Add constructor logic here
            //
            m_strType = strType;
            m_strSubType = strSubType;

        }
        public DataTable CreateNewEditRecord()
        {

            RFQDetail oDBRFQDetail = new RFQDetail();
            DataTable dt = oDBRFQDetail.GetDataColumns();

            // maybe need to clone the table

            return dt;

        }

    }



}