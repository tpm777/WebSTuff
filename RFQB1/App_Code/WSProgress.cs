using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Data;
using System.Configuration;
using System.Threading;
using System.Web.UI;

//using CmpTool;

using Progress.Open4GL;
using Progress.Open4GL.Proxy;
using System.Security.Permissions;





public class WSProgressASP 
{
    const int DEVELOPMENT = 0;
    const int PRODUCTION = 1;
    const int TRAIN = 2;
    const int PILOT = 3;
    const int PRODDBTCODE = 4;
    const bool m_blnTrace = true;
    const string PLANTNAMEDELIMITER = "-";
    string m_strErrorMsg = "";
    string m_strReturnMessage = "";



    string m_strConn;                   // string used to connect to Progress Application Server
    Progress.Open4GL.Proxy.Connection m_connObj;    // connection object used with m_strConn to connect to Progress Application Server

    public OpenAppObject m_openAO;


    

    DataSet m_dsGeneric;                // set to null by defau;t at run time
    DataTable m_dtGeneric;

//    private Connection conn;
    // protected CmpTool.CmpTools aoObject;
    
    
    public WSProgressASP()
    {
        SetConnectionString();

    }


    public bool Connect()
    {

        m_connObj = new Connection(m_strConn, "", "", "");
        try
        {
            m_openAO = new OpenAppObject(m_connObj, "NS1");
            m_connObj.SessionModel = 1;
         
        }
        catch (Progress.Open4GL.Exceptions.ConnectException ex)
        {
            m_strErrorMsg = ex.Message;
            return false;
        }
        catch (Progress.Open4GL.DynamicAPI.SessionPool.NoAvailableSessionsException ex)
        {
            m_strErrorMsg = ex.Message;
            return false;
        }

                // clear dataset from memory
        m_dsGeneric = null;
        m_strErrorMsg = null;



        return true;

    }



    public void Disconnect()
    {
        try
        {
            m_connObj.ReleaseConnection();
            m_connObj.Dispose();
            m_openAO.Dispose();
            m_openAO  = null;
            m_connObj = null;
        }
        catch { }
    }


    private bool SetConnectionString()
    {

 

        string csRunMode = ConfigurationManager.AppSettings["RunMode"];
        csRunMode = csRunMode.ToUpper();
  
  

        if (csRunMode.IndexOf("DEVELOPMENT") >= 0)
        {
            m_strConn = ConfigurationManager.AppSettings["AppServerTestName"];
        }
        else if (csRunMode.IndexOf("TEST") >= 0)
            m_strConn = ConfigurationManager.AppSettings["AppServerTestName"];
        else if (csRunMode.IndexOf("TRAIN") >= 0)
            m_strConn = ConfigurationManager.AppSettings["AppServerTrainName"];
        else if (csRunMode.IndexOf("PRODUCTION") >= 0)
            m_strConn = ConfigurationManager.AppSettings["AppServerProductionName"];
        else if (csRunMode.IndexOf("PILOT") >= 0)
            m_strConn = ConfigurationManager.AppSettings["AppServerPilotName"];
        else if (csRunMode.IndexOf("PRODDBTCODE") >= 0)
            m_strConn = ConfigurationManager.AppSettings["AppServerProdDBTestCode"];

        else
        {
            if (string.IsNullOrEmpty(m_strConn) )
            {
                SetErrorMsg("Connection String Can Not Be Blank. Check web.config file.");
                return false;

            }
        }

        return true;

    }



    public bool CallProgressProcedure(string strFName,  ParamArray parms, string strReturnType)
    {



        if (!Connect())
        {
                m_strReturnMessage= m_strErrorMsg;
                SetErrorMsg("Error Connecting to Progress Application Server");
            return false;
        }

        int nLastParameter = parms.ParamSet.NumParams-1;  


        // Init Error recording string. If no error, the value should be blank

        try
        {
            // create sub appobjects
            m_openAO.RunProc(strFName, parms);
        }
        catch (Exception e)
        {
            CleanUp();
            m_strErrorMsg = e.Message;

            return false;

        }


        if (strReturnType.ToUpper().Contains("DS"))
        {

            m_dsGeneric = parms.GetOutputParameter(nLastParameter) as DataSet;
        }
        else if (strReturnType.ToUpper().Contains("DT"))
        {

            m_dtGeneric = parms.GetOutputParameter(nLastParameter) as DataTable;

        }
        else if (strReturnType.ToUpper().Contains("STRING"))
        {

            m_strReturnMessage  = parms.GetOutputParameter(nLastParameter) as string;

        }
        CleanUp();

        return true;

    }




    public DataSet GetDataSet()
    {
        return m_dsGeneric;
    }


    public DataTable GetDataTable()
    {
        return m_dtGeneric;
    }




    private void CleanUp()
    {
        m_connObj.ReleaseConnection();

        m_openAO.Dispose(); 
        m_openAO = null;
        m_connObj = null;


    }

    private void ClearDataSet()
    {
        m_dsGeneric = null;

    }



    public void SetErrorMsg(string strErrorMessage)
    {
        m_strErrorMsg  = strErrorMessage;
    }



    
    
    public string ErrorMsg
    {
        get
        {
            return m_strErrorMsg;
        }
        set
        {
            m_strErrorMsg = value;
        }
    }

    public string ReturnMessage
    {
        get
        {
            return m_strReturnMessage;
        }
        set
        {
            m_strReturnMessage = value;
        }
    }
 

  
}
