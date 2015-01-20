using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using System.Configuration;
using RFQSecurity;


public partial class _Default : System.Web.UI.Page
{
    #region Private Member Variables
    string UPLOADFOLDER = ConfigurationManager.AppSettings["UploadRootPath"];
    string UPLOADFOLDERROOT = ConfigurationManager.AppSettings["UploadRootPath"];
    string m_strStartPage = ConfigurationManager.AppSettings["StartPage"];

    #endregion

    #region Web Methods
    protected void Page_Load(object sender, EventArgs args)
    {

        if (!IsPostBack)
        {
            if (string.IsNullOrEmpty((string)Session["GroupID"]))
            {
                if (!AllowUserAccess())
                {
                    DisplayMsg("Access Not Allowed");
                    Response.Redirect(m_strStartPage + "?RFQID=" + (string)Session["RFQID"], true);

                }
            }

        }

        if (string.IsNullOrEmpty((string)Session["RFQID"]))
        {


            DisplayMsg("NO RFQID Available");
            Response.Redirect(m_strStartPage,true);  
            return;

        }

        UPLOADFOLDERROOT = ConfigurationManager.AppSettings["UploadRootPath"] + @"\" + (string)Session["RFQID"];
        UPLOADFOLDER = ConfigurationManager.AppSettings["UploadRootPath"] + @"\" + (string)Session["RFQID"];
        if (Session["GroupID"].ToString().ToUpper()   == "SALES")
        {
            UPLOADFOLDER = UPLOADFOLDER + @"\";
        }
        else if (Session["GroupID"].ToString().ToUpper()  == "ENGINEERING")
        {
            UPLOADFOLDER = UPLOADFOLDER + @"\" + "Engineering";
        }
  
        if (!this.IsPostBack)
        {
            lblTitle.Text = string.Format("RFQ File Upload Utility [{0}]", (string)Session["RFQID"]);

            lblTitle.Text = lblTitle.Text + string.Format("GroupdID[{0}]",(string)Session["GroupID"]);
            
            //Reserve a spot in Session for the UploadDetail object
            this.Session["UploadDetail"] = new UploadDetail { IsReady = false };
            LoadUploadedFiles(ref gvNewFiles);
        }
       
    }

    private bool AllowUserAccess()
    {
        //if (Session["AllowedAccess"] != null)
        //{
        //    if ((bool)Session["AllowedAccess"])
        //    {
        //        return true;

        //    }
        //    return false;
        //}

        RFQSecurityFunctions clsUserSecurity = new RFQSecurityFunctions(this);

        Session["UserID"] = clsUserSecurity.GetUserID();

        if (string.IsNullOrEmpty((string)Session["UserID"]))
        {
            DisplayMsg("UnKnown User");
            return false;


        }

        string strAccessList = ConfigurationManager.AppSettings["RFQSalesADGroupName"].ToString();

        if (clsUserSecurity.AllowUserAccess(strAccessList))
        {
            Session["AllowedAccess"] = true;
            Session["GroupID"] = "Sales"; 
            return true;

        }

        strAccessList = ConfigurationManager.AppSettings["RFQEngineeringADGroupName"].ToString();
        
        if (clsUserSecurity.AllowUserAccess(strAccessList))
        {
            Session["AllowedAccess"] = true;
            Session["GroupID"] = "Engineering";
            return true;

        }
        else
        {
            Session["AllowedAccess"] = false;
        }
        return false;
    }

    private void DisplayMsg(string sMsg)
    {
        CmpWebBaseMsgBox.MBox.Show(sMsg);
    }


    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod]
    public static object GetUploadStatus()
    {
        //Get the length of the file on disk and divide that by the length of the stream
        UploadDetail info = (UploadDetail)HttpContext.Current.Session["UploadDetail"];
        if (info != null && info.IsReady)
        {
            int soFar = info.UploadedLength;
            int total = info.ContentLength;
            int percentComplete = (int)Math.Ceiling((double)soFar / (double)total * 100);
            string message = "Uploading...";
            string fileName = string.Format("{0}", info.FileName);
            string downloadBytes = string.Format("{0} of {1} Bytes", soFar, total);
            return new
            {
                percentComplete = percentComplete,
                message = message,
                fileName = fileName,
                downloadBytes = downloadBytes
            };
        }
        //Not ready yet
        return null;
    }
    #endregion

    #region Web Callbacks
    protected void gvNewFiles_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes.Add("onmouseover", "eventMouseOver(this)");
            e.Row.Attributes.Add("onmouseout", "eventMouseOut(this)");
        }
    }
    protected void gvNewFiles_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        switch (e.CommandName)
        {
            case "deleteFile":
                DeleteFile(e.CommandArgument.ToString());
                LoadUploadedFiles(ref gvNewFiles);
                break;
            case "downloadFile":
                
             //   GridView grdView = (GridView)sender; //

             //   GridViewRow gvRow = (GridViewRow)((Control)e.CommandSource).NamingContainer;
             //   int index = gvRow.RowIndex;
             ////   GridViewRow oRow = ((GridViewRow) (((LinkButton) (e.CommandSource)). Parent.Parent));

            
             //   int nTest = gvRow.Cells.Count;


             //   GridViewRow oRow = gvNewFiles.Rows[index];

             //   string strTest = oRow.Cells[1].Text;

      

                string strFolderSales = UPLOADFOLDERROOT;
                string strFolderEngineering = UPLOADFOLDERROOT + @"\" + "Engineering";


                string filePathSales = Path.Combine(strFolderSales, e.CommandArgument.ToString());
                string filePathEngineering = Path.Combine(strFolderEngineering, e.CommandArgument.ToString());



                if (File.Exists(Server.MapPath(filePathSales)))
                    DownloadFile(filePathSales);
                else
                    DownloadFile(filePathEngineering);
                break;
        }
    }
    protected void hdRefereshGrid_ValueChanged(object sender, EventArgs e)
    {
        LoadUploadedFiles(ref gvNewFiles);
    }
    #endregion

    #region Support Methods
    public void LoadUploadedFiles(ref GridView gv)
    {

        DataTable dtFiles = GetFilesInDirectory(HttpContext.Current.Server.MapPath(UPLOADFOLDERROOT));
        gv.DataSource = dtFiles;
        gv.DataBind();
        if (dtFiles != null && dtFiles.Rows.Count > 0)
        {
            double totalSize = Convert.ToDouble(dtFiles.Compute("SUM(Size)", ""));
            if (totalSize > 0) lblTotalSize.Text = CalculateFileSize(totalSize);
        }
    }
    public DataTable GetFilesInDirectory(string sourcePath)
    {
        System.Data.DataTable dtFiles = new System.Data.DataTable();
        SearchOption optSearch;
        if ((Directory.Exists(sourcePath)))
        {
            dtFiles.Columns.Add(new System.Data.DataColumn("FolderName"));
            dtFiles.Columns.Add(new System.Data.DataColumn("Name"));
            dtFiles.Columns.Add(new System.Data.DataColumn("Size"));
            dtFiles.Columns["Size"].DataType = typeof(double);
            dtFiles.Columns.Add(new System.Data.DataColumn("ConvertedSize"));
            DirectoryInfo dir = new DirectoryInfo(sourcePath);
            if ((string)Session["GroupID"].ToString().ToUpper() == "SALES")
            {

                 optSearch = SearchOption.TopDirectoryOnly;
            }
            else
            {
                 optSearch = SearchOption.AllDirectories;

            }
            foreach (FileInfo files in dir.GetFiles("*.*", optSearch))
            {
                System.Data.DataRow drFile = dtFiles.NewRow();
                if (files.DirectoryName.ToUpper().Contains("ENGINEER")) 
                    drFile["FolderName"] = "ENGINEERING";
                else
                    drFile["FolderName"] = "SALES";
                drFile["Name"] = files.Name;
                drFile["Size"] = files.Length;
                drFile["ConvertedSize"] = CalculateFileSize(files.Length);
                dtFiles.Rows.Add(drFile);
            }
        }
        return dtFiles;
    }
    public void DownloadFile(string filePath)
    {
        if (File.Exists(Server.MapPath(filePath)))
        {
            string strFileName = Path.GetFileName(filePath).Replace(" ", "%20");
            Response.ContentType = "application/octet-stream";
            Response.AddHeader("Content-Disposition", "attachment; filename=" + strFileName);
            Response.Clear();
            Response.WriteFile(Server.MapPath(filePath));
            Response.End();
        }
    }
    public string DeleteFile(string FileName)
    {
        string strMessage = "";

        string strFolderSales = UPLOADFOLDERROOT;
        string strFolderEngineering = UPLOADFOLDERROOT + @"\" + "Engineering";


        string filePathSales = Path.Combine(strFolderSales, FileName);
        string filePathEngineering = Path.Combine(strFolderEngineering, FileName);



        try
        {
            //string strPath = Path.Combine(UPLOADFOLDER, FileName);
            //if (File.Exists(Server.MapPath(strPath)) == true)
            //{
            //    File.Delete(Server.MapPath(strPath));
            //    strMessage = "File Deleted";
            //}
            //else
            //    strMessage = "File Not Found";

            if (File.Exists(Server.MapPath(filePathSales)))
                File.Delete(Server.MapPath(filePathSales));
            else if (File.Exists(Server.MapPath(filePathEngineering)))
                File.Delete(Server.MapPath(filePathEngineering));
            else
                strMessage = "File Not Found";



        }
        catch (Exception ex)
        {
            strMessage = ex.Message;
        }
        return strMessage;
    }
    public string CalculateFileSize(double FileInBytes)
    {
        string strSize = "00";
        if (FileInBytes < 1024)
            strSize = FileInBytes + " B";//Byte
        else if (FileInBytes > 1024 & FileInBytes < 1048576)
            strSize = Math.Round((FileInBytes / 1024), 2) + " KB";//Kilobyte
        else if (FileInBytes > 1048576 & FileInBytes < 107341824)
            strSize = Math.Round((FileInBytes / 1024) / 1024, 2) + " MB";//Megabyte
        else if (FileInBytes > 107341824 & FileInBytes < 1099511627776)
            strSize = Math.Round(((FileInBytes / 1024) / 1024) / 1024, 2) + " GB";//Gigabyte
        else
            strSize = Math.Round((((FileInBytes / 1024) / 1024) / 1024) / 1024, 2) + " TB";//Terabyte
        return strSize;
    }
    #endregion
    protected void btnFinish_Click(object sender, EventArgs e)
    {
        Response.Redirect(m_strStartPage+"?RFQID=" + (string)Session["RFQID"], true);
    }
}
