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
    public class RFQDetail
    {

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
        string[] strInputParameters;
        string m_conString = ConfigurationManager.ConnectionStrings["RFQConnectionString"].ConnectionString;
 
        public RFQDetail()
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

                sqlCmd.Parameters.AddWithValue("@rfqid", strInputParameters[RFQID]);
                sqlCmd.Parameters.AddWithValue("@line", strInputParameters[LINE]);

                sqlCmd.Parameters.AddWithValue("@sequence", strInputParameters[SEQUENCE]);
                sqlCmd.Parameters.AddWithValue("@type", strInputParameters[TYPE]);
                sqlCmd.Parameters.AddWithValue("@subtype", strInputParameters[SUBTYPE]);
                sqlCmd.Parameters.AddWithValue("@fieldref", strInputParameters[FIELDREF]);
                sqlCmd.Parameters.AddWithValue("@description", strInputParameters[DESCRIPTION]);
                sqlCmd.Parameters.AddWithValue("@value", strInputParameters[VALUE]);
                sqlCmd.Parameters.AddWithValue("@lastchangedate", strInputParameters[LASTCHANGEDATE]);
                sqlCmd.Parameters.AddWithValue("@lastchangeuser", strInputParameters[LASTCHANGEUSER]);
                sqlCmd.Parameters.AddWithValue("@productgroup", strInputParameters[PRODUCTGROUP]);

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


        public bool DBClose()
        {

            m_sqlConnect.Close();
            return true;
        }

        public bool InsertRFQHeaderRec()
        {

            return true;
        }


        public DataTable GetRFQIDDetailRecord( string strRFQID)
        {
            DataTable dt = new DataTable();
            string strCMD = "SELECT * FROM RFQDetail WHERE RFQID = " + strRFQID;

            m_sqlConnect = new SqlConnection(m_conString);
            sqlCmd = new SqlCommand(strCMD, m_sqlConnect);
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = strCMD;
            sqlCmd.Connection.Open();
      

            SqlDataReader dr = sqlCmd.ExecuteReader(CommandBehavior.CloseConnection);

            dt.Load(dr);
   
            m_sqlConnect.Close();

            return dt;


        }
       private void CheckForMissingDetailRecords(string strRFQID, string strLineID, string strType, string strSubType)
       {

           if (string.IsNullOrEmpty(strType)) return;
           if (string.IsNullOrEmpty(strSubType)) return;

           int nRecordID = 0;
            
           DataTable dt = new DataTable();


           string strCMD = "SELECT RFQDetail.Description, RFQDetail.Value, RFQDetail.TYPE, RFQDetail.SubType, RFQDetail.ProductGroup, ";
           strCMD = strCMD + " RFQFieldControlReference.FieldRef, RFQFieldControlReference.Active, RFQFieldControlReference.Required, ";
           strCMD = strCMD + " RFQFieldControlReference.InputControlType, RFQFieldControlReference.InputControlOptions, RFQFieldControlReference.Validation, RFQFieldControlReference.ValidationErrMessage, RFQFieldControlReference.ControlTip, RFQFieldControlReference.SortOrder ";
           strCMD = strCMD + " FROM RFQDetail INNER JOIN  RFQFieldControlReference";
           strCMD = strCMD + " ON RFQDetail.RFQID = " + strRFQID;
           strCMD = strCMD + " AND Line = " + strLineID;
           strCMD = strCMD + " AND RFQDetail.FieldRef = RFQFieldControlReference.FieldRef";
           strCMD = strCMD + " AND RFQFieldControlReference.Type =  RFQDetail.TYPE";
           strCMD = strCMD + " AND RFQFieldControlReference.Active =  'Y' ";
           strCMD = strCMD + " AND RFQFieldControlReference.SubType = RFQDetail.SubType ORDER BY RFQFieldControlReference.SortOrder ";


           m_sqlConnect = new SqlConnection(m_conString);
           sqlCmd = new SqlCommand(strCMD, m_sqlConnect);
           sqlCmd.CommandType = CommandType.Text;
           sqlCmd.CommandText = strCMD;
           sqlCmd.Connection.Open();


           SqlDataReader dr = sqlCmd.ExecuteReader(CommandBehavior.CloseConnection);

           dt.Load(dr);
           string strProductGroup = dt.Rows[0]["ProductGroup"].ToString(); 

           int nRowCount = dt.Rows.Count;  // current line info

           int nExpectedNumberOfRows = GetNumberOfFieldRefs(strType, strSubType);

           DataTable dtRef = GetCurrentActiveFieldRefs(strType, strSubType);
           nExpectedNumberOfRows = dtRef.Rows.Count;
           string strRefIDNotFound = null;

           int nRecordRefFoundCount = 0;

           if (nRowCount > nExpectedNumberOfRows)  //duplicate 
           {

               foreach (DataRow oRow in dtRef.Rows) // reference recordset
               {
                   nRecordID = Convert.ToInt16(oRow["FieldRef"]);
                   nRecordRefFoundCount = 0;
                   foreach (DataRow oRowCurrentLine in dt.Rows)
                   {
                       int nCurrentLineIDRef = Convert.ToInt16(oRowCurrentLine["FieldRef"]);
                       if (nRecordID == nCurrentLineIDRef)
                       {
                           nRecordRefFoundCount++;
                       }
                   }
                   if (nRecordRefFoundCount > 1)
                   {

                       DeleteRFQDetailLineItem(strRFQID, strLineID, nRecordID.ToString());


                   }

               }



           }



           m_sqlConnect = new SqlConnection(m_conString);
           sqlCmd = new SqlCommand(strCMD, m_sqlConnect);
           sqlCmd.CommandType = CommandType.Text;
           sqlCmd.CommandText = strCMD;
           sqlCmd.Connection.Open();
           

           dr = sqlCmd.ExecuteReader(CommandBehavior.CloseConnection);
           dt.Reset();
 
           dt.Load(dr);
           strProductGroup = dt.Rows[0]["ProductGroup"].ToString();

           nRowCount = dt.Rows.Count;  // current line info
           
           dtRef = GetCurrentActiveFieldRefs(strType, strSubType);
           nExpectedNumberOfRows = dtRef.Rows.Count;



            
           if (nRowCount < nExpectedNumberOfRows)  //missing line ref
           {
               foreach (DataRow oRowRef in dtRef.Rows)
               {
                   int nRequiredRefID = Convert.ToInt16(oRowRef["FieldRef"]);
                   bool blnFound = false;
                   foreach (DataRow oRowCurrentLine in dt.Rows)
                   {
                       int nCurrentLineIDRef = Convert.ToInt16(oRowCurrentLine["FieldRef"]);
                       if (nRequiredRefID == nCurrentLineIDRef)
                       {
                           blnFound = true;
                           break;

                       }
                   }
                   if (!blnFound)
                   {
                       if (string.IsNullOrEmpty(strRefIDNotFound))
                           strRefIDNotFound = nRequiredRefID.ToString();
                       else
                       {
                            strRefIDNotFound += "," + nRequiredRefID.ToString();
                   
                       }

                   }
               }


           }
           if (!string.IsNullOrEmpty(strRefIDNotFound))
           {
               string[] strMissingRefs = strRefIDNotFound.Split(',');

               foreach (string strMissingRef in strMissingRefs)
               {
                   DataTable dtFieldRef = GetMissingFieldRef(strType, strSubType, Convert.ToInt16(strMissingRef));
                   string strInput = string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10}", strRFQID, strLineID, strMissingRef, strType, strSubType, strMissingRef, dtFieldRef.Rows[0]["Description"].ToString(), "", DateTime.Now, "System Fix", strProductGroup);
                   SetInputArray(strInput);
                   CreateNewRFQDetailRecord(); 

               }

           }


       }



        public DataTable GetRFQIDDetailRecord(string strRFQID, string strLineID, string strType, string strSubType)
        {

            CheckForMissingDetailRecords(strRFQID, strLineID, strType, strSubType);


            DataTable dt = new DataTable();
                   

            string strCMD = "SELECT RFQDetail.Description, RFQDetail.Value, RFQDetail.TYPE, RFQDetail.SubType, RFQDetail.ProductGroup, ";
            strCMD = strCMD + " RFQFieldControlReference.FieldRef, RFQFieldControlReference.Active, RFQFieldControlReference.Required, ";
            strCMD = strCMD + " RFQFieldControlReference.InputControlType, RFQFieldControlReference.InputControlOptions, RFQFieldControlReference.Validation, RFQFieldControlReference.ValidationErrMessage, RFQFieldControlReference.ControlTip, RFQFieldControlReference.SortOrder ";
                   strCMD = strCMD + " FROM RFQDetail INNER JOIN  RFQFieldControlReference"; 
                   strCMD = strCMD + " ON RFQDetail.RFQID = " + strRFQID; 
                   strCMD = strCMD + " AND Line = " + strLineID ;
                   strCMD = strCMD + " AND RFQDetail.FieldRef = RFQFieldControlReference.FieldRef";
                   strCMD = strCMD + " AND RFQFieldControlReference.Type =  RFQDetail.TYPE";
                   strCMD = strCMD + " AND RFQFieldControlReference.SubType = RFQDetail.SubType ORDER BY RFQFieldControlReference.SortOrder";


            m_sqlConnect = new SqlConnection(m_conString);
            sqlCmd = new SqlCommand(strCMD, m_sqlConnect);
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = strCMD;
            sqlCmd.Connection.Open();


            SqlDataReader dr = sqlCmd.ExecuteReader(CommandBehavior.CloseConnection);

            dt.Load(dr);




            m_sqlConnect.Close();

            return dt;


        }

        //private bool AddMissingDetail(ref DataTable dt, int nExpectedDetailNoOfRecords, string strType, string strSubType)
        //{
        //    int nFieldRefCounter=1;



        //    foreach (DataRow oRow in dt.Rows)
        //    {
        //        if (Convert.ToInt16(oRow["FieldRef"]) != nFieldRefCounter)
        //        {
        //            GetMissingFieldRef(strType, strSubType, nFieldRefCounter);

        //        }
        //        else
        //            nFieldRefCounter++;
                


        //    }
        //    if (nFieldRefCounter == nExpectedDetailNoOfRecords)
        //    {
        //        DataTable dtNew = GetMissingFieldRef(strType, strSubType, nFieldRefCounter);  // last record

        //        CreateNewRFQDetailRecord();


        //        return true;
        //    }


        //    return true;

        //}
        private DataTable  GetMissingFieldRef(string strType, string strSubType, int nFieldRef)
        {
          
            DataTable dt = GetRFQFieldRefRecord(strType, strSubType, nFieldRef);
            return dt;
        }
        
        public DataTable GetRFQIDDistinctDetailRecord(string strRFQID)
        {
            DataTable dt = new DataTable();
            string strCMD = "SELECT DISTINCT LINE, TYPE, SUBTYPE, PRODUCTGROUP FROM RFQDetail WHERE RFQID = " + strRFQID;

            m_sqlConnect = new SqlConnection(m_conString);
            sqlCmd = new SqlCommand(strCMD, m_sqlConnect);
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = strCMD;
            sqlCmd.Connection.Open();


            SqlDataReader dr = sqlCmd.ExecuteReader(CommandBehavior.CloseConnection);

            dt.Load(dr);

            m_sqlConnect.Close();

            return dt;


        }

        public DataTable GetRFQIDDistinctGenericRecord(string strSQLCmd)
        {
            DataTable dt = new DataTable();
            string strCMD = strSQLCmd;

            m_sqlConnect = new SqlConnection(m_conString);
            sqlCmd = new SqlCommand(strCMD, m_sqlConnect);
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = strCMD;
            sqlCmd.Connection.Open();


            SqlDataReader dr = sqlCmd.ExecuteReader(CommandBehavior.CloseConnection);

            dt.Load(dr);

            m_sqlConnect.Close();

            return dt;


        }


        public int GetNextMaxLineID(string strRFQID)
        {
            DataTable dt = new DataTable();
            string strCMD = "SELECT MAX(Line) FROM RFQDetail WHERE RFQID = " + strRFQID;
            int nMaxValue = 1;

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


            try
            {
                if (!DBConnect()) return false;

                //string strCMD = "Update RFQDetail SET RFQID = " + strInputParameters[RFQID] + "," +
                //                                       "LINE = '" + strInputParameters[LINE] + "'," +
                //                                       "SEQUENCE = '" + strInputParameters[SEQUENCE] + "'," +
                //                                       "TYPE = '" + strInputParameters[TYPE] + "'," +
                //                                       "SUBTYPE =  '" + strInputParameters[SUBTYPE] + "'," +
                //                                       "FIELDREF = '" + strInputParameters[FIELDREF] + "'," +
                //                                       "DESCRIPTION = '" + strInputParameters[DESCRIPTION] + "'," +
                //                                       "VALUE = '" + strInputParameters[VALUE] + "'," +
                //                                       "LASTCHANGEDATE = '" + Convert.ToDateTime(strInputParameters[LASTCHANGEDATE]) + "' " +
                //                                       "WHERE RFQID = " + strRFQID + " " +
                //                                       "AND TYPE = '" + strInputParameters[TYPE] + "' " +
                //                                       "AND SUBTYPE = '" + strInputParameters[SUBTYPE] + "' " +
                //                                       "AND FIELDREF = " + strInputParameters[FIELDREF];



                string strCMD = "Update RFQDetail SET VALUE = '" + strInputParameters[VALUE] + "'," +
                                                        "LASTCHANGEDATE = '" + Convert.ToDateTime(strInputParameters[LASTCHANGEDATE]) + "' " +
                                                        "WHERE RFQID = " + strRFQID + " " +
                                                        "AND TYPE = '" + strInputParameters[TYPE] + "' " +
                                                        "AND SUBTYPE = '" + strInputParameters[SUBTYPE] + "' " +
                                                        "AND LINE = '" + strInputParameters[LINE] + "' " +
                                                        "AND SEQUENCE = '" + strInputParameters[SEQUENCE] + "' " +
                                                        "AND FIELDREF = " + strInputParameters[FIELDREF];



                sqlCmd = new SqlCommand(strCMD, m_sqlConnect);
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.CommandText = strCMD;

                sqlCmd.Connection.Open();
                sqlCmd.ExecuteNonQuery();
                sqlCmd.Connection.Close();

                DBClose();
            }
            catch (Exception err)
            {

                return false;
            }
            return true;
        }
        public bool UpdateRFQDetailValue(string strValue, string strRFQID, string strLineID, string strType, string strSubType, string strFieldRef)
        {



            if (!DBConnect()) return false;

            string strCMD = "Update RFQDetail SET VALUE = '" + strValue + "' " +
                                                   "WHERE RFQID = " + strRFQID + " " +
                                                   "AND LINE = " + strLineID + " " +
                                                   "AND TYPE = '" + strType + "' " +
                                                   "AND SUBTYPE = '" + strSubType + "' " +
                                                   "AND FIELDREF = " + strFieldRef;


            sqlCmd = new SqlCommand(strCMD, m_sqlConnect);
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = strCMD;

            sqlCmd.Connection.Open();
            sqlCmd.ExecuteNonQuery();
            sqlCmd.Connection.Close();

            DBClose();

            return true;
        }
        public bool DeleteRFQDetailLine(string strRFQID, string strLine)
        {



            if (!DBConnect()) return false;

            string strCMD = "DELETE FROM RFQDetail WHERE RFQID = " + strRFQID + " " +
                                                   "AND LINE = " + strLine + "";


            sqlCmd = new SqlCommand(strCMD, m_sqlConnect);
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = strCMD;

            sqlCmd.Connection.Open();
            sqlCmd.ExecuteNonQuery();
            sqlCmd.Connection.Close();


            //strCMD = "Update RFQDetail SET Line = Line - 1 WHERE RFQID = " + strRFQID ;

            //sqlCmd = new SqlCommand(strCMD, m_sqlConnect);
            //sqlCmd.CommandType = CommandType.Text;
            //sqlCmd.CommandText = strCMD;

            //sqlCmd.Connection.Open();
            //sqlCmd.ExecuteNonQuery();
            //sqlCmd.Connection.Close();


            DBClose();

            return true;
        }

        public bool DeleteRFQDetailLineItem(string strRFQID, string strLine, string strFieldRef)
        {


            try
            {
                if (!DBConnect()) return false;

                // double check that there is a duplicate
                string strCMDChk = "SELECT Count(RFQID) FROM RFQDetail WHERE RFQID = " + strRFQID + " " +
                                                       "AND LINE = " + strLine + " AND FieldRef = " + strFieldRef ;

                sqlCmd = new SqlCommand(strCMDChk, m_sqlConnect);
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.CommandText = strCMDChk;

                sqlCmd.Connection.Open();
                int nRecordsFound = (int)sqlCmd.ExecuteScalar();

                if (nRecordsFound > 1)
                {
                    //"DELETE FROM RFQDetail WHERE ID NOT IN (SELECT MIN(ID) FROM RFQDetail WHERE RFQID = x   "AND LINE = " + strLine + " AND FieldRef = " + strFieldRef + " AND Value = ''"";

                    string strCMD = "DELETE FROM RFQDetail WHERE RFQID = " + strRFQID + " " +
                                                           "AND LINE = " + strLine + " AND FieldRef = " + strFieldRef ;


                    sqlCmd = new SqlCommand(strCMD, m_sqlConnect);
                    sqlCmd.CommandType = CommandType.Text;
                    sqlCmd.CommandText = strCMD;

  //                  sqlCmd.Connection.Open();
                    nRecordsFound = sqlCmd.ExecuteNonQuery();
                }
                sqlCmd.Connection.Close();



                DBClose();
            }
            catch (Exception err)
            {

                return false;
            }
            return true;
        }
        
        
        public DataTable GetDataColumns()
        {
            if (!DBConnect()) return null;
            DataTable schemaTable = new DataTable();
  


            string strCMD = "SELECT TOP 1  * FROM RFQDetail WHERE RFQID > " + "0";

            sqlCmd = new SqlCommand(strCMD, m_sqlConnect);
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = strCMD;

            sqlCmd.Connection.Open();

            SqlDataReader dr = sqlCmd.ExecuteReader(CommandBehavior.CloseConnection);

            schemaTable.Load(dr);

            m_sqlConnect.Close();
            //myReader = sqlCmd.ExecuteReader(CommandBehavior.KeyInfo);

            ////Retrieve column schema into a DataTable.
            //schemaTable = myReader.GetSchemaTable();

            return schemaTable;




        }

        public DataTable CreateNewRFQDetailRecords(int nRFQID, int nLineNumber, string strType, string strSubType)
        {
            DataTable dtNewtable =  GetDataColumns();

            dtNewtable.Rows.Clear();
            int nNewLine = GetNextMaxLineID(Convert.ToString(nRFQID));

            RFQFieldControl oFieldControl = new RFQFieldControl();

            DataTable dtFieldControl = oFieldControl.GetRFQFieldControlTypes(strType, strSubType);

            foreach (DataRow oRow in dtFieldControl.Rows)
            {
                DataRow oNewRow = dtNewtable.NewRow();
                oNewRow["RFQID"] = nRFQID;
                oNewRow["Line"] = nNewLine;

                oNewRow["Type"] = strType;
                oNewRow["SubType"] = strSubType;

                oNewRow["FieldRef"] = oRow["FieldRef"];
                oNewRow["Description"] = oRow["Description"];
                //oNewRow["Value"] = oRow["Value"];
                //oNewRow["LastChangeDate"] = oRow["LastChangeDate"];
                //oNewRow["LastChangeUser"] = oRow["LastChangeUser"];

                dtNewtable.Rows.Add(oNewRow);
                dtNewtable.AcceptChanges();


            }
            return dtNewtable;

        }
        public DataTable GetRFQFieldValues(string strRFQID)
        {

            if (!DBConnect()) return null;
            DataTable dt = new DataTable();
            string strCMD = "SELECT Line, Type, SubType, FieldRef, Description, ProductGroup, Value FROM RFQDetail Where RFQID = '" + strRFQID + "'";


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

        public int GetNumberOfFieldRefs(string strType, string strSubType)
        {
            DataTable dt = new DataTable();
            string strCMD = "SELECT COUNT(*) FROM RFQFieldControlReference WHERE Type = '" + strType + "' AND SubType = '" + strSubType + "' AND Active = 'Y'";
            int nMaxValue = -1;

            m_sqlConnect = new SqlConnection(m_conString);
            sqlCmd = new SqlCommand(strCMD, m_sqlConnect);
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = strCMD;
            sqlCmd.Connection.Open();

            try
            {
                nMaxValue = (int)sqlCmd.ExecuteScalar();
            }
            catch (Exception err)
            {

            }

            m_sqlConnect.Close();

            return nMaxValue;


        }

        public DataTable GetCurrentActiveFieldRefs(string strType, string strSubType)
        {
            DataTable dt = new DataTable();
            string strCMD = "SELECT * FROM RFQFieldControlReference WHERE Type = '" + strType + "' AND SubType = '" + strSubType + "' AND Active = 'Y'";

            m_sqlConnect = new SqlConnection(m_conString);
            sqlCmd = new SqlCommand(strCMD, m_sqlConnect);
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = strCMD;
            sqlCmd.Connection.Open();

            try
            {
                SqlDataReader dr = sqlCmd.ExecuteReader(CommandBehavior.CloseConnection);

                dt.Load(dr);
                sqlCmd.Connection.Close();
                DBClose();
            }
            catch (Exception err)
            {
                return null;
            }

          

    

            return dt;
        }
        
        
        public DataTable GetRFQFieldRefRecord(string strType, string strSubType, int nFieldRef)
        {

            RFQFieldControl oDB = new RFQFieldControl();
            DataTable dt = oDB.GetRFQFieldControlRecord(strType, strSubType, Convert.ToString(nFieldRef));   


            return dt;



        }

    }
}