using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using Xrm;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using System.Net;
using System.Net.Mail;
using Obout.Interface;
using Obout.Grid;
using Obout.ComboBox;
using System.IO;
using System.Web.SessionState;

using RFQDBFunctions;
using RFQSecurity;
using EpicorDataFunctions;

using Telerik.Web.UI;
using FreeTextBoxControls;


//using Progress.Open4GL.DynamicAPI;
//using Progress.Open4GL.Proxy;
//using Progress.Open4GL;

using System.DirectoryServices.AccountManagement;
using System.Data.SqlClient;



public static class SessionHandler 
{ 
    const string validInstanceGuid = "validInstanceGuid"; 
    public static string ValidInstanceGuid 
    { 
        get 
        { 
            if (HttpContext.Current.Session[validInstanceGuid] == null) 
            { return string.Empty; } 
            else 
            { return HttpContext.Current.Session[validInstanceGuid].ToString(); 
            } 
        } 
        set
        { 
            HttpContext.Current.Session[validInstanceGuid] = value;
        } 
    } 
} 

public partial class RFQMain : System.Web.UI.Page
{
    DataTable dt = new DataTable();
    string m_conString = ConfigurationManager.ConnectionStrings["RFQConnectionString"].ConnectionString;
    string m_strStartPage = ConfigurationManager.AppSettings["StartPage"];


    string m_strCRMVersion = ConfigurationManager.AppSettings["CRMVersion"];


    string m_strFullPrivilageUserName = "ENGINEERING";
    int m_nDeleteStatusValue = 90;

    int m_nGridValuesOffset = 2;
    int m_nRFQID = -1;
    bool __DEBUG = false;
    string m_strDateTimeFormat = "MM/dd/yyyy HH:mm";

    int MAINGRIDLINEID_CELLID = 1;
    int MAINGRIDTYPEID_CELLID = 2;
    int MAINGRIDSUBTYPEID_CELLID = 3;
    int EDITBUTTONOFFSET = 5;
    int DELETEBUTTONOFFSET = 6;

    string UPLOADFOLDER = ConfigurationManager.AppSettings["UploadRootPath"];
    string UPLOADFOLDERROOT = ConfigurationManager.AppSettings["UploadRootPath"];


    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Cache.SetCacheability(System.Web.HttpCacheability.NoCache);


        //if (!IsPostBack)
        //{
        //    hfldUniqueTabGuid.Value = GenerateUniqueTabGuid(); 

        //}
        //if (!IsPostBack)
        //{
        //    foreach (string fieldName in Request.Form)
        //    {
        //        if (fieldName == "ctl00$MainContent$hfldUniqueTabGuid")
        //        {
        //            ViewState["validInstanceGuid"] = Request.Form["ctl00$MainContent$hfldUniqueTabGuid"].ToString();
        //        }
        //    }
        //}
        //else
        //{
        //    if (ViewState["validInstanceGuid"].ToString() != SessionHandler.ValidInstanceGuid)
        //    {
        //        Response.Redirect("InvalidAccess.aspx");
        //    }
        //}
        //     btnEditRow.Attributes.Add("onclick","$(this).closest("tr").after("<tr><td></td><td colspan = '999'>" + $(this).next().html() + "</td></tr>")"); 
        string strRequestor = null;
        string strRFQID = null;
        string strGroupIDTest = "NO";

        //    RFQInputDetails.ButtonClick1 += new EventHandler(btnTest_Click);
        //     btnClose.Attributes.Add("OnClick", "btnClose_Click");  

      
        lblRFQDescription.ToolTip = "CRM Supplied Description";

        lblRFQDescriptionValue.ToolTip = "RFQ Description Tip";
        lblRequestor.ToolTip = "Supplied from CRM";
   
        lblCustomer.ToolTip = "CRM Supplied Customer Name";
        lblCustomerName.ToolTip = "Click To View Customer Information";

        lblCurrencyCRM.ToolTip = "Supplied from CRM";


  
        lblStatus.ToolTip = "RFQ Status Indicator";
        lblLastChanged.ToolTip = "Date When RFQ Was Last Changed";

        lblDatedCreated.ToolTip = "Date When RFQ Was Created";
        lblDateQuoted.ToolTip = "Date When RFQ Was Quoted";
        lblDateSubMitted.ToolTip = "Date When RFQ Was Submitted";
        lblDateRequested.ToolTip = "When Customer Requires Quote";

        lblDateLastRevised.ToolTip = " Date Revised";
        lblWhoChanged.ToolTip = "Displays User ID Of Person That Made The Last Change To A RFQ";


        lblCustomer.ToolTip = "CRM Contact Name";
        lblParentCustomer.ToolTip = "Parent Company";
        lblGHSEquipment0.ToolTip = "Flagged from CRM As Either A GHS Consumable Or Equipment";
        lblCurrency.ToolTip = "Required Currency for RFQ";
        lblWhoChanged0.ToolTip = "What Was Last Changed";

    
        btnSubmit.ToolTip = "Submit Button Tooltip";
        btnUpload.ToolTip = "Upload ToolTip";


        if (!AllowUserAccess())
        {
            DisplayMsg("Access Not Allowed");
            return;
        }


        string script;
        //if (IsPostBack)
        //{
        //    script = "var isPostBack = true;";

        //    Page.ClientScript.RegisterStartupScript(GetType(), "IsPostBack", script, true);
        //}
        //else
        //{
        //    script = "var isPostBack = false;";

        //    Page.ClientScript.RegisterStartupScript(GetType(), "IsPostBack", script, true);

        //}


 
        if (!IsPostBack)
        {

        //    cmbStatus.FolderStyle = "ComboBox/styles/black_glass/OboutDropDownList";

            try
            {
                strGroupIDTest = string.IsNullOrEmpty(ConfigurationManager.AppSettings["EnableGroupIDTesting"])?"":"NO";
            }
            catch (EvaluateException err)
            {
                strGroupIDTest = "NO";

            }

            if (strGroupIDTest.ToUpper().Contains("YES"))
            {
                cmbUserProfiles.Enabled = true;
                cmbUserProfiles.Visible = true;
                pnlTestADProfile.Visible = true;
                SetTestingEnv();
            }
            else
            {
                pnlTestADProfile.Visible = false;
                cmbUserProfiles.Enabled = false;
                cmbUserProfiles.Visible = false;
            }



            SetHeaderFontSizes();

            InitBottomCmdBtns(false);

            //if (!AllowUserAccess())
            //{
            //    DisplayMsg("Accessed Not Allowed");
            //    return;

            //}

            Session["UserID"] = GetUserID(this);

            Session["DONOTBIND"] = false;

            //    Test();  // Test Epicor Connection.
            //    cmbStatus.BorderWidth = 0;
            //   cmbStatus.BorderStyle = BorderStyle.None;

            lblCurrencyCRM.BorderStyle = BorderStyle.None;



            string[] ctrls;
            Session["DisplayingSubTypes"] = false;
            //lblNewMediaType.Text = "Select Type:";

            lblRFQNum.Text = "RFQID:(" + "<a href='RFQIDInSystem.aspx' Title='Select To Display List View OF RFQs'>ListView</a>)";

            //txbRequired1.Attributes.Add("onkeyup", "handleKeyUp(this);");

            //rbList1.Items[0].Text = "Labels";
            //rbList1.Items[1].Text = "Printers";
            //rbList1.Items[2].Text = "Scanners";
            //rbList1.Items[3].Text = "Service";

            //pnlAddOption.Visible = false;

            InitControls();



            // test to see if coming from RFQ List
            try
            {
                if ((string)Request.QueryString["RFQID"] != null)
                {
                 //   imgBtn.Visible = false;
                    txbRFQNum.Text = (string)Request.QueryString["RFQID"];
                    if ((txbRFQNum.Text.ToUpper() != "NEW") && (txbRFQNum.Text.ToUpper() != "NULL"))
                    {
                        try
                        {
                            GetUploadedFiles();
                        }
                        catch (Exception err)
                        {


                        }
                        RFQHeaderDB db = new RFQHeaderDB();
                        dt = db.GetRFQIDRecord(m_conString, txbRFQNum.Text);

                        if (dt.Rows.Count > 0)
                        {
                            pnlMain.Visible = true; 
                            InitBottomCmdBtns(true);
                            if (!SetHeaderValues(dt)) return;

                            if (!string.IsNullOrEmpty(txbRFQNum.Text))
                            {
                                Session["RFQID"] = txbRFQNum.Text;
                                RFQDetail oRFQDetail = new RFQDetail();



                                grdRequiredValues.DataSource = null;
                                //                  grdRequiredValues.DataSourceID = null;
                                grdRequiredValues.DataSource = oRFQDetail.GetRFQIDDistinctDetailRecord(txbRFQNum.Text);
                                Session["OriginalData"] = (DataTable)oRFQDetail.GetRFQIDDistinctDetailRecord(txbRFQNum.Text);

                                Session["ADDNEWRFQDETAILS"] = false;
                                grdRequiredValues.DataBind();

                                //grdMasterRFQDetails.DataSource = oRFQDetail.GetRFQIDDistinctDetailRecord(txbRFQNum.Text);
                                //grdMasterRFQDetails.DataBind();

                                Session["RFQMAXLINE"] = oRFQDetail.GetNextMaxLineID(txbRFQNum.Text);
                                if (!IsSessionVarOK(Session["RFQMAXLINE"]))
                                {
                                    DisplayMsg("SQL Server Did Not Return Next RFQDetail Index");
                                    return;

                                }
                                int nSelectedValue = Convert.ToInt16(cmbStatus.SelectedValue);
                                if (((int)Session["RFQMAXLINE"] > 1)&&(nSelectedValue<80))
                                {
                                    pnlSelects.Visible = true;

                                    btnSubmit.Visible = true;
                              

                                    if (nSelectedValue >= 20)
                                    {
                                        btnSubmit.Visible = false;
                                        btnSubmit.Text = "Update";
                                    }
                                    if (nSelectedValue >= 80)
                                    {
                                        btnSubmit.Visible = false;
                                        btnUpload.Visible = true;
                                        btnUpload.Enabled = true;

                                        pnlRFQSelect.Visible = false;

                                    }
   

                                }
                                else
                                {
                                    // deleted all lines
                                    rfqdetail.Visible = false;
                                    if (nSelectedValue == 10)
                                    {
                                        pnlSelects.Visible = true;
                                        btnSubmit.Visible = true;
                                    }
                                    else if ((nSelectedValue > 10)&&(nSelectedValue < 80))
                                    {
                                        pnlSelects.Visible = true;

                                    }
    

                                }


                                //For Re Exapnding the expanded rows 
                                //    foreach (GridViewRow row in grdRequiredValues.Rows)
                                //    {        
                                //        if (row.RowType == DataControlRowType.DataRow) 
                                //        {             
                                //            HiddenField IsExpanded = row.FindControl("IsExpanded") as HiddenField;  
                                //            IsExpanded.Value = Request.Form[IsExpanded.UniqueID]; 
                                //        }
                                //    } 
                            }
                            LockRFQFromChange();
                        }
                        else
                        {
                            txbRFQNum.Text = "new";
                            InitBottomCmdBtns(true);

                        }
                    }
                    else    // new RFQ Request
                    {
                        Session["RFQMAXLINE"] = 1;
                        NewRFQRequest();
                        InitBottomCmdBtns(false);
                        pnlSelects.Visible = true;
                        pnlMain.Visible = true;
                    }
                    foreach (GridViewRow row in grdRequiredValues.Rows)
                    {
                        if (row.RowType == DataControlRowType.DataRow)
                        {
                            HiddenField IsExpanded = row.FindControl("IsExpanded") as HiddenField;
                            IsExpanded.Value = Request.Form[IsExpanded.UniqueID];
                        }
                    }
                }
            }
            catch (Exception err)
            {



            }
        }
        else  //Is a POSTBACK
        {
            // try
            //{
            //    if (!NewRFQRequest())
            //    {
            //        // TBD

            //    }
            //}
            //catch (Exception err)
            //{




            //}
            if (!string.IsNullOrEmpty((string)Session["ContactID"]))
                BuildHyperLink(lblCustomerName, (string)Session["ContactID"], "Contact");

            if (!string.IsNullOrEmpty((string)Session["AccountID"]))
//                BuildHyperLink(lblParentCustomerName, (string)Session["AccountID"], "Account");
            
            if (!string.IsNullOrEmpty((string)Session["OpportunityID"]))
                BuildHyperLink(lblRFQDescriptionValue, (string)Session["OpportunityID"], "Opportunity");

        }
    }
    private void SetTestingEnv()
    {
        if (cmbUserProfiles.Enabled)// not in test/design mode
        {

            Object objTest = Session["GroupID"];
            if (objTest != null)
            {
                cmbUserProfiles.SelectedValue = (string)Session["GroupID"];
              

            }
        }

    }
    
    protected void Detail_LoadingItems(object sender, ComboBoxLoadingItemsEventArgs e)
    {
        if (!string.IsNullOrEmpty(e.Text))
        {
            if (!string.IsNullOrEmpty(e.Text))
            {
                sds2.SelectParameters["MarketID"].DefaultValue = e.Text;
                sds2.DataBind();
            }
        }
    }
    private void SetHeaderFontSizes()
    {
        int nHeaderTextBoxFontSize = 12;
        txbRFQNum.Font.Size = FontUnit.Point(nHeaderTextBoxFontSize);
        lblRFQDescriptionValue.Font.Size = FontUnit.Point(nHeaderTextBoxFontSize);
        txbDateCreated.Font.Size = FontUnit.Point(nHeaderTextBoxFontSize);
        txbDateLastRevised.Font.Size = FontUnit.Point(nHeaderTextBoxFontSize);
        txbDateQuoted.Font.Size = FontUnit.Point(nHeaderTextBoxFontSize);
        txbDateSubmitted.Font.Size = FontUnit.Point(nHeaderTextBoxFontSize);
        txbRequestor.Font.Size = FontUnit.Point(nHeaderTextBoxFontSize);
        //      cmbStatus.Font.Size = FontUnit.Point(nHeaderTextBoxFontSize);
        lblCustomerName.Font.Size = FontUnit.Point(nHeaderTextBoxFontSize);
        txbDateLastRevised.Font.Size = FontUnit.Point(nHeaderTextBoxFontSize);
        txbDateLastChanged.Font.Size = FontUnit.Point(nHeaderTextBoxFontSize);
        txbDateRequested.Font.Size = FontUnit.Point(nHeaderTextBoxFontSize);
        txbChangedBy.Font.Size = FontUnit.Point(nHeaderTextBoxFontSize);
        txbReasonForChange.Font.Size = FontUnit.Point(nHeaderTextBoxFontSize);
    }
    private bool NewRFQRequest()
    {

      

        if ((string)Request.QueryString["OppID"] != null)
        {

            if ((string)Request.QueryString["Currency"] != null)
            {
                lblCurrencyCRM.Text = (string)Request.QueryString["Currency"];


            }


            if ((string)Request.QueryString["Requestor"] != null)
                txbRequestor.Text = (string)Request.QueryString["Requestor"];

            if ((string)Request.QueryString["RFQID"] != null)
                txbRFQNum.Text = (string)Request.QueryString["RFQID"];

            if ((string)Request.QueryString["RFQDescription"] != null)
            {
                lblRFQDescriptionValue.Text = (string)Request.QueryString["RFQDescription"];

                if ((string)Request.QueryString["OppID"] != null)
                {
                    Session["OppID"] = (string)Request.QueryString["OppID"];

                    BuildHyperLink(lblRFQDescriptionValue, (string)Request.QueryString["OppID"], "Opportunity");
                }
            }

            if (m_strCRMVersion.Contains("2011"))
            {
                PopulateAccountContactFields_2011();

            }
            else if (m_strCRMVersion.Contains("2013"))
            {

                PopulateAccountContactFields_2013();

            }

            //       lblCustomerName.Text = (string)Request.QueryString["CustomerID"];

            //            lblCustomerName.Text = "<a href='ViewCustomerInfo.aspx'>" + (string)Request.QueryString["CustomerID"] + "</a>";

            if ((string)Request.QueryString["OppID"] != null)
                Session["OppID"] = (string)Request.QueryString["OppID"];

            if ((string)Request.QueryString["GHSEquipment"] != null)
            {
                Session["GHSOpportunity"] = (string)Request.QueryString["GHSEquipment"];
                if (Session["GHSOpportunity"].ToString().ToUpper() == "YES")
                    chkGHS.Checked = true;
                else
                    chkGHS.Checked = false;
            }

            else if ((string)Request.QueryString["GHSConsumable"] != null)
            {
                Session["GHSOpportunity"] = (string)Request.QueryString["GHSEquipment"];
                if (Session["GHSOpportunity"].ToString().ToUpper() == "YES")
                    chkGHS.Checked = true;
                else
                    chkGHS.Checked = false;
            }
            else
            {

                chkGHS.Checked = false;

            }

            if ((string)Request.QueryString["NPRNumber"] != null)
            {
                Session["NPRNumber"] = (string)Request.QueryString["NPRNumber"];
                lblNPRNumberValue.Text = (string)Request.QueryString["NPRNumber"];
            }

            
            if (txbRFQNum.Text.ToUpper() == "NEW")
            {
                cmbStatus.EmptyText = "New";
                RFQHeaderDB objRFQHeader = new RFQHeaderDB();
                //   txbDateCreated.Text = DateTime.Now.ToString(m_strDateTimeFormat);
                // txbRFQNum.Text = Convert.ToString(objRFQHeader.GetNextHeaderRecord());
                // CreateNewRFQHeaderRecord();
                return true;
            }



            return true;

        }
        return false;

    }
    private void PopulateAccountContactFields_2011()
    {

        if (!string.IsNullOrEmpty((string)Request.QueryString["CustomerName"]))
        {
            Session["ContactName"] = (string)Request.QueryString["CustomerName"];

            lblCustomer.Visible = true;
            lblCustomerName.Visible = true;


            string strLinkInfo = "lblTemp";
            //                lblCustomerName.Text = (string)Request.QueryString["CustomerName"];
            lblParentCustomerName.Text = (string)Request.QueryString["CustomerName"];


            //lblCustomerName.Controls.Add(lnkCustomer);  // need to correct the name
            if ((string)Request.QueryString["CustomerID"] != null)
            {
                Session["ContactID"] = (string)Request.QueryString["CustomerID"];
                //                  BuildHyperLink(lblCustomerName, (string)Request.QueryString["CustomerID"], "Contact");
                BuildHyperLink(lblParentCustomerName, (string)Request.QueryString["CustomerID"], "Contact");

            }



        }
        else
        {
            Session["ContactName"] = "";
            Session["ContactID"] = "";
            lblCustomer.Visible = false;
            lblCustomerName.Visible = false;

        }


        if (!string.IsNullOrEmpty((string)Request.QueryString["AccountName"]))
        {
            Session["AccountName"] = (string)Request.QueryString["AccountName"];

            lblParentCustomerName.Visible = true;
            lblParentCustomer.Visible = true; 

            string strLinkInfo = "lblTemp";
            lblParentCustomerName.Text = (string)Request.QueryString["AccountName"];






        }
        else
        {
            Session["AccountName"] = "";
            lblParentCustomerName.Visible = false;
            lblParentCustomer.Visible = false; 

        }
        if (!string.IsNullOrEmpty((string)Request.QueryString["AccountID"]))
        {
            Session["AccountID"] = (string)Request.QueryString["AccountID"];



            lblParentCustomerName.Text = (string)Request.QueryString["AccountName"];
            if (!string.IsNullOrEmpty(lblParentCustomerName.Text))
                BuildHyperLink(lblParentCustomerName, (string)Request.QueryString["AccountID"], "Account");

        }
        else
        {
            Session["AccountID"] = "";
            lblParentCustomerName.Visible = false;
            lblParentCustomer.Visible = false; 

        }




    }
    private void PopulateAccountContactFields_2013()
    {

        if (!string.IsNullOrEmpty((string)Request.QueryString["CustomerName"]))
        {
            Session["ContactName"] = (string)Request.QueryString["CustomerName"];



            string strLinkInfo = "lblTemp";
            lblCustomerName.Text = (string)Request.QueryString["CustomerName"];

            lblCustomer.Visible = true; 

            //lblCustomerName.Controls.Add(lnkCustomer);  // need to correct the name
            if ((string)Request.QueryString["CustomerID"] != null)
            {
                lblCustomerName.Visible = true;

                Session["ContactID"] = (string)Request.QueryString["CustomerID"];
                BuildHyperLink(lblCustomerName, (string)Request.QueryString["CustomerID"], "Contact");
            
            }



        }
        else
        {
            Session["ContactName"] = "";
            Session["ContactID"] = "";
            lblCustomer.Visible = false;
            lblCustomerName.Visible = false;

        }


        if (!string.IsNullOrEmpty((string)Request.QueryString["AccountName"]))
        {
            Session["AccountName"] = (string)Request.QueryString["AccountName"];

            lblParentCustomer.Text = "Account (CRM):";

            string strLinkInfo = "lblTemp";
            lblParentCustomerName.Text = (string)Request.QueryString["AccountName"];


        }
        else
        {
            Session["AccountName"] = "";

        }
        if (!string.IsNullOrEmpty((string)Request.QueryString["AccountID"]))
        {
            Session["AccountID"] = (string)Request.QueryString["AccountID"];



            lblParentCustomerName.Text = (string)Request.QueryString["AccountName"];
            if (!string.IsNullOrEmpty(lblParentCustomerName.Text))
                BuildHyperLink(lblParentCustomerName, (string)Request.QueryString["AccountID"], "Account");

        }
        else
        {
            Session["AccountID"] = "";
            lblParentCustomerName.Visible = false;
            lblParentCustomer.Visible = false; 
        }




    }

    private void InitBottomCmdBtns(bool blnState)
    {

        btnUpload.Enabled = blnState;
        btnUpload.Visible = blnState;
        rfqdetail.Visible = blnState;

        //btnSubmit.Enabled = blnState;
        //btnSubmit.Visible = blnState;


        //btnSave.Enabled = blnState;
        //btnSave.Visible = blnState;


    }
    private int FindOccurence(string substr)
    {

        string reqstr = Request.Form.ToString();

        return ((reqstr.Length - reqstr.Replace(substr, "").Length)

                          / substr.Length);

    }


    protected void gvRFQDetails_RowEditing(object sender, GridViewEditEventArgs e)
    {
        int nIndex = 0;
        string strFieldRef = null;
        RFQDetail oRFQDetail = new RFQDetail();





        GridView grdView = (GridView)sender; // cast sender to TextBox
        GridViewRow row = (GridViewRow)grdView.NamingContainer;  // It will return the child gridview row in which textBox



        nIndex = row.RowIndex;


        string strLineID = row.Cells[1].Text;
        string strType = row.Cells[2].Text;
        string strSubType = row.Cells[3].Text;


        GridViewRow parent_row = grdRequiredValues.Rows[nIndex];



        GridView gvRFQDetail = parent_row.FindControl("gvRFQDetails") as GridView;







        //      strFieldRef = gvRFQDetail.Rows[e.NewEditIndex].Cells[0].Text;
        System.Web.UI.WebControls.Label lblTest = (System.Web.UI.WebControls.Label)grdView.Rows[e.NewEditIndex].Cells[0].FindControl("lbFieldRef");

        strFieldRef = lblTest.Text;




        gvRFQDetail.EditIndex = e.NewEditIndex;

        grdView.EditIndex = e.NewEditIndex;

        //    System.Web.UI.WebControls.Label lblTest = (System.Web.UI.WebControls.Label)grdView.Rows[e.NewEditIndex].FindControl("lblValue");

        //        DropDownList cmbValue = (DropDownList)grdView.Rows[e.NewEditIndex].FindControl("cmbValue");

        //        gvRFQDetail.DataSource = oRFQDetail.GetRFQIDDistinctGenericRecord(string.Format("SELECT * from RFQDetail where RFQID={0} AND Line={1} ", txbRFQNum.Text, strLineID));

        gvRFQDetail.DataSource = oRFQDetail.GetRFQIDDistinctGenericRecord(string.Format("SELECT * from RFQDetail CROSS JOIN RFQFieldControlReference where RFQID={0} AND Line={1} AND RFQDetail.FieldRef = RFQFieldControlReference.FieldRef AND RFQDetail.Type = RFQFieldControlReference.Type AND RFQDetail.SubType = RFQFieldControlReference.SubType", txbRFQNum.Text, strLineID));


        gvRFQDetail.EditIndex = e.NewEditIndex;


        gvRFQDetail.DataBind();

        // Request.Form.Clear();   

    }

    private void DisplayMsg(string sMsg)
    {
        CmpWebBaseMsgBox.MBox.Show(sMsg);
    }


    protected void RFQInputDetail_ButtonClickDemo(object sender, EventArgs e)
    {
        Response.Write("It's working");
    }
    private void InitControls()
    {
   
        btnSubmit.Visible = false;
        btnUpload.Visible = false;


    }
    private void DisplaySubTypes(string strSubType)
    {
        if (!string.IsNullOrEmpty(strSubType))
        {
            RFQSubTypes clsSubTypes = new RFQSubTypes();

            DataTable dt = clsSubTypes.GetRFQSubTypes(strSubType);
   
            cmbRFQSubType.EmptyText = "Select RFQ SubType";
            cmbRFQSubType.DataSource = dt;
            cmbRFQSubType.DataBind();


 
            Session["DisplayingSubTypes"] = true;

        }

    }
    private void DisplayAddEditPage()
    {
 

        string strRFQType = (string)Session["RFQType"];
        string strRFQSubType = (string)Session["RFQSubType"];

 //       btnCloseTest.Visible = true;

        Response.Redirect("AddRFQDetails.aspx", false);



    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {


    }

    private void ResetForNewOption()
    {

        //  pnlAddOption.Visible = false;
        //      pnlSalesOptions.Visible = false;
        //     pnlSummaryGrid.Visible = false;

 //       rbList1.SelectedIndex = -1;



    }


    protected void btnReset_Click(object sender, EventArgs e)
    {
        ResetForNewOption();
        //ResetTextBoxes();

        grdRequiredValues.DataSource = null;
        grdRequiredValues.DataBind();

        //grdOptionalValue.DataSource = null;
        //grdOptionalValue.DataBind();
    }
    protected void btnUpload_Click(object sender, EventArgs e)
    {
        if (cmbUserProfiles.Enabled)
        {
            if (!cmbUserProfiles.SelectedText.Contains("Select"))
            {

                Session["GroupID"] = cmbUserProfiles.SelectedText;
            }
        }

        //if (chkUserProfile.Checked)
        //{

        //    Session["AllowedAccess"] = true;

        //    if (optUserProfile.SelectedValue == "Sales")
        //    {
        //        Session["GroupID"] = "Sales";

        //    }
        //    else
        //    {
        //        Session["GroupID"] = "Engineering";
        //    }
        //    Session["TestGroupID"] = true;
        //}
        //else
        //{
        //    Session["TestGroupID"] = false;
        //}

        Response.Redirect("RFQFileUpload.aspx");
    }

    protected void btnEditLineItem_Click(object sender, EventArgs e)
    {
        // Response.Redirect("~/UploadFile.aspx");

        //  LabelSizeandFinish uc =
        //(LabelSizeandFinish)Page.LoadControl("LabelSizeAndFinish.ascx");
        //   PlaceHolder1.Controls.Add(uc); 

        //    mp1.Show();
    }

    protected void btnViewCustomer_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/ViewCustomerInfo.aspx", false);
    }
    protected void grdRequiredValues_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        //if (e.CommandName.ToUpper() == "EDIT")
        //{
        //    GridView grdView = (GridView)sender; //
        //}


    }
    protected void grdRequiredValues_RowEditing(object sender, GridViewEditEventArgs e)
    {

     
        GridView grdView = (GridView)sender; //


        GridViewRow row = grdView.Rows[e.NewEditIndex ];

        string strLineNum = row.Cells[MAINGRIDLINEID_CELLID].Text;
        string strRFQID = txbRFQNum.Text;
        Session["RFQType"] = row.Cells[MAINGRIDTYPEID_CELLID].Text;
        Session["RFQSubType"] = row.Cells[MAINGRIDSUBTYPEID_CELLID].Text;


        Response.Redirect("AddRFQDetails.aspx?RFQID=" + txbRFQNum.Text + "&LineID=" + strLineNum, true);




    }
    protected void grdRequiredValues_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        GridView grdView = (GridView)sender; //
        //    GridViewRow row = (GridViewRow)grdView.NamingContainer;  // It will return the child gridview row in which textBox

        GridViewRow row = grdView.Rows[e.RowIndex];

        RFQDetail oRFQDetail = new RFQDetail();



        int nIndex = row.RowIndex;

        string strLineNum = row.Cells[1].Text;

        oRFQDetail.DeleteRFQDetailLine(txbRFQNum.Text, strLineNum);

        Response.Redirect(m_strStartPage + "?RFQID=" + txbRFQNum.Text, true);



    }

    protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string item = e.Row.Cells[1].Text;
            foreach (Button button in e.Row.Cells[2].Controls.OfType<Button>())
            {
                if (button.CommandName == "Delete")
                {
                    button.Attributes["onclick"] = "if(!confirm('Do you want to delete " + item + "?')){ return false; };";
                }
            }
        }
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            RFQDetail oRFQDetail = new RFQDetail();

            string strRFQID = txbRFQNum.Text;
            string strLineItem = e.Row.Cells[1].Text;

            GridView gvRFQDetail = e.Row.FindControl("gvRFQDetails") as GridView;



            gvRFQDetail.DataSource = oRFQDetail.GetRFQIDDistinctGenericRecord(string.Format("SELECT * from RFQDetail where RFQID={0} AND Line={1}", strRFQID, strLineItem));

            gvRFQDetail.DataBind();
        }
    }

    protected void grdRequiredValues_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //if ((bool)Session["DONOTBIND"])
        //{
        //    return;

        //}
        string strRFQID = null;
        strRFQID = Convert.ToString(Session["RFQID"]);
        if (e.Row.RowState != DataControlRowState.Edit) // check for RowState
        {

            if (e.Row.RowType == DataControlRowType.DataRow) //check for RowType
            {

                string id = e.Row.Cells[3].Text; // Get the id to be deleted

                //cast the ShowDeleteButton link to linkbutton 

                //                Button lb = (Button)e.Row.Cells[0].FindControl("Delete");
                //              ((LinkButton)e.Row.Cells[0].Controls[0]).OnClientClick = "return confirm('Do you really want to delete?');";



            }


            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                if (string.IsNullOrEmpty(strRFQID))
                {

                    DisplayMsg("RFQID Can Not Be Blank");
                    return;
                }
                RFQDetail oRFQDetail = new RFQDetail();

                string strLineItem = e.Row.Cells[1].Text;

                GridView gvRFQDetail = e.Row.FindControl("gvRFQDetails") as GridView;


                if ((bool)Session["ADDNEWRFQDETAILS"] == false)
                {
                    //                    gvRFQDetail.DataSource = oRFQDetail.GetRFQIDDistinctGenericRecord(string.Format("SELECT * from RFQDetail where RFQID={0} AND Line={1}", strRFQID, strLineItem));
                    gvRFQDetail.DataSource = oRFQDetail.GetRFQIDDistinctGenericRecord(string.Format("SELECT * from RFQDetail CROSS JOIN RFQFieldControlReference where RFQID={0} AND Line={1} AND RFQDetail.FieldRef = RFQFieldControlReference.FieldRef AND RFQDetail.Type = RFQFieldControlReference.Type AND RFQDetail.SubType = RFQFieldControlReference.SubType ORDER BY RFQFieldControlReference.SORTORDER", strRFQID, strLineItem));

                    //                   SELECT * from RFQDetail CROSS JOIN RFQFieldControlReference  WHERE RFQDetail.RFQID=10000112 AND RFQDetail.Line=1 AND RFQDetail.FieldRef = RFQFieldControlReference.FieldRef AND RFQDetail.Type = RFQFieldControlReference.Type AND RFQDetail.SubType = RFQFieldControlReference.SubType


                }
                else
                {
                    if (Convert.ToInt32(strLineItem) == GetNewRowID())
                    {
                        gvRFQDetail.DataSource = oRFQDetail.CreateNewRFQDetailRecords(Convert.ToInt32(strRFQID), Convert.ToInt32(strLineItem), (string)Session["RFQType"], (string)Session["RFQSubType"]);

                    }
                    else
                    {
                        gvRFQDetail.DataSource = oRFQDetail.GetRFQIDDistinctGenericRecord(string.Format("SELECT * from RFQDetail where RFQID={0} AND Line={1}", strRFQID, strLineItem));

                    }
                }

                gvRFQDetail.DataBind();



                Session["DetailGrid" + Convert.ToString(e.Row.DataItemIndex)] = (GridView)gvRFQDetail;

            }
        }
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string item = e.Row.Cells[DELETEBUTTONOFFSET].Text;
            foreach (Button button in e.Row.Cells[DELETEBUTTONOFFSET].Controls.OfType<Button>())
            {
                if (button.CommandName == "Delete")
                {
                    button.Attributes["onclick"] = "if(!confirm('Do you want to delete " + item + "?')){ return false; };";
                    button.Attributes["onblur"] = "window.onbeforeunload = null;";
                }
        

            }
            foreach (Button button in e.Row.Cells[EDITBUTTONOFFSET].Controls.OfType<Button>())
            {
                if (button.CommandName == "Edit")
                {
                    button.Attributes["onclick"] = "window.onbeforeunload = null;";
                }

            }

        }


    }

    protected void gvRFQDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        string strFieldRef = null;
        string strRFQType = null;
        string strRFQSubType = null;
        string strValue = null;
        string strValidation = null;

        GridView grdView = (GridView)sender; //

        GridViewRow row = (GridViewRow)grdView.NamingContainer;  // It will return the child gridview row in which textBox


        int nIndex = row.RowIndex;


        if (e.Row.RowState != DataControlRowState.Edit) // check for RowState
        {

            if (e.Row.RowType == DataControlRowType.DataRow) //check for RowType
            {

                string id = e.Row.Cells[3].Text; // Get the id to be deleted

                //cast the ShowDeleteButton link to linkbutton 

                //                Button lb = (Button)e.Row.Cells[0].FindControl("Delete");
                //              ((LinkButton)e.Row.Cells[0].Controls[0]).OnClientClick = "return confirm('Do you really want to delete?');";



                string strTest = e.Row.Parent.ClientID;


            }

        }
        if ((e.Row.RowState & DataControlRowState.Edit) > 0) // check for RowState need bitwise check
        {

            strFieldRef = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "FieldRef"));
            strRFQType = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Type"));
            strRFQSubType = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "SubType"));
            strValue = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Value"));



            RFQFieldControl dbControl = new RFQFieldControl();
            DataTable dt = dbControl.GetRFQFieldControlRecord(strRFQType, strRFQSubType, strFieldRef);

            strValidation = (string)dt.Rows[0]["Validation"];


            if (!string.IsNullOrEmpty(strFieldRef))
            {
                GridCellControls oControl = new GridCellControls();
                if (string.IsNullOrEmpty(strValue))
                {
                    e.Row.Cells[2].Controls.Add(oControl.GetGridCellControlWR(Convert.ToString(nIndex), strRFQType, strRFQSubType, strFieldRef, strValidation));
                    //                   e.Row.Cells[2].Controls[0].e 
                }
                else
                {
                    e.Row.Cells[2].Text = "";


                    e.Row.Cells[2].Controls.Add(oControl.GetGridCellControlWR(Convert.ToString(nIndex), strRFQType, strRFQSubType, strFieldRef, strValue, strValidation));
                    //                  e.Row.Cells[2].Enabled = true;
                }
            }

           
 
        }
        if (e.Row.RowType == DataControlRowType.DataRow)
        {

            string strRequired = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Required")); // 
            System.Web.UI.WebControls.Label lblTemp = e.Row.FindControl("lbFieldRequired") as System.Web.UI.WebControls.Label;

            System.Web.UI.WebControls.Label lblValue = e.Row.FindControl("lblValue") as System.Web.UI.WebControls.Label;
            System.Web.UI.WebControls.Label lblDescription = e.Row.FindControl("lblDescription") as System.Web.UI.WebControls.Label;

            if (lblValue != null)
            {
                lblValue.Text = lblValue.Text.ToString().Replace(Environment.NewLine, "<br/>");
                lblValue.Text = AddPuncs(lblValue.Text);
                lblValue.Attributes.Add("style", "color:green;font-weight:bold;text-align:left;");
            }

            if (lblDescription != null)
            {
            
                lblDescription.Attributes.Add("style", "color:blue;font-weight:bold;text-align:left;");
            }


            if (strRequired.ToUpper() == "Y")
            {
                e.Row.Cells[3].ForeColor = System.Drawing.Color.Red; // change cell bg colour
                lblTemp.ForeColor = System.Drawing.Color.Red;
                lblTemp.Text = "*";
            }
            else
            {
                e.Row.Cells[3].ForeColor = System.Drawing.Color.Green; // change cell bg colour
                lblTemp.ForeColor = System.Drawing.Color.Green;
                lblTemp.Text = "";

            }



            string item = e.Row.Cells[e.Row.Cells.Count - 1].Text;
            foreach (Button button in e.Row.Cells[e.Row.Cells.Count - 1].Controls.OfType<Button>())  //always last item on roll
            {
                if (button.CommandName == "Delete")
                {
                    button.Attributes["onclick"] = "if(!confirm('Do you want to delete " + item + "?')){ return false; };";
                }
            }
        }


    }
    private string RemovePuncs(string strSource)
    {


        if (!string.IsNullOrEmpty(strSource))
        {
            strSource = strSource.Replace(",", "[COMMA]");
            strSource = strSource.Replace("&", "[AMPERSAND]");
            strSource = strSource.Replace("_", "[UNDERSCORE]");
            strSource = strSource.Replace("+", "[PLUS]");
            strSource = strSource.Replace("?", "[QUESTIONMARK]");

            strSource = strSource.Replace("\"", "[DOUBLEQUOTE]");
            strSource = strSource.Replace("\'", "[SINGLEQUOTE]");
            strSource = strSource.Replace(">", "[GREATERTHAN]");
            strSource = strSource.Replace("<", "[LESSTHAN]");

        }
        return strSource;
    }

    private string AddPuncs(string strSource)
    {
        if (!string.IsNullOrEmpty(strSource))
        {
            strSource = strSource.Replace("[COMMA]", ",");
            strSource = strSource.Replace("[AMPERSAND]", "&");
            strSource = strSource.Replace("[UNDERSCORE]", "_");
            strSource = strSource.Replace("[PLUS]", "+");
            strSource = strSource.Replace("[QUESTIONMARK]", "?");


            strSource = strSource.Replace("[DOUBLEQUOTE]", "\"");
            strSource = strSource.Replace("[SINGLEQUOTE]", "\'");
            strSource = strSource.Replace("[GREATERTHAN]", ">");
            strSource = strSource.Replace("[LESSTHAN]", "<");



        }
        return strSource;
    }

    protected void gvRFQDetails_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {



    }




    private bool UpdateCRMOpportunityRecord()
    {
        try
        {
            string strIsXRMCommunicationEnabled = ConfigurationManager.AppSettings["EnableXRMCommunication"];

            if (strIsXRMCommunicationEnabled.ToUpper() != "YES")
                return true;

        }
        catch (Exception err)
        {
            return true;


        }
  


        if (string.IsNullOrEmpty((string)Session["OppID"]))
        {

            return false;
        }
        try
        {
            var xrm = new XrmServiceContext("Xrm");


            Guid OppID = new Guid((string)Session["OppID"]);



            ColumnSet cols = new ColumnSet(new String[] { "ctype_rfqid", "ctype_rfqstatus" });

            Opportunity retrievedOpp = (Opportunity)xrm.Retrieve(Opportunity.EntityLogicalName, OppID, cols);


            retrievedOpp.ctype_RFQID = txbRFQNum.Text;
            if (Convert.ToInt16(cmbStatus.SelectedValue) == 10)
                retrievedOpp.ctype_RFQStatus = "Created(10)";
            else if (Convert.ToInt16(cmbStatus.SelectedValue) == 20)
                retrievedOpp.ctype_RFQStatus = "Submitted(20)";
            else if (Convert.ToInt16(cmbStatus.SelectedValue) == 30)
                retrievedOpp.ctype_RFQStatus = "InProcess(30)";
            else if (Convert.ToInt16(cmbStatus.SelectedValue) == 40)
                retrievedOpp.ctype_RFQStatus = "Quoted(40)";
            else if (Convert.ToInt16(cmbStatus.SelectedValue) == 80)
                retrievedOpp.ctype_RFQStatus = "Completed(80)";
            else if (Convert.ToInt16(cmbStatus.SelectedValue) == 90)
                retrievedOpp.ctype_RFQStatus = "Cancelled(90)";
            else
                retrievedOpp.ctype_RFQStatus = "Status Unknown";

            xrm.Update(retrievedOpp);
        }
        catch (Exception err)
        {
            DisplayMsg(string.Format("Error Updating RFQ Status: [{0}]", err.Message));
            return false;

        }


        return true;
    }

    private bool CreateNewRFQHeaderRecord()
    {

        cmbStatus.SelectedValue = "10";  //use value not textvalue
        txbDateCreated.Text = DateTime.Now.ToString(m_strDateTimeFormat);


        string strOppID = "OpportunityID Not Found";

        if (!string.IsNullOrEmpty((string)Session["OppID"]))
        {
            strOppID = (string)Session["OppID"];

        }

        RFQHeaderDB clsRFQHeader = new RFQHeaderDB();

        txbDateSubmitted.Text = null;


        //       string strInput = txbRFQNum.Text + ",";

        //if(lblRFQDescriptionValue.Text.IndexOfAny(new char[] {','})>=0)
        //{
        //    lblRFQDescriptionValue.Text = lblRFQDescriptionValue.Text.Replace(",", " "); 
        //}

    
   

        
        string strInput = RemovePuncs(lblRFQDescriptionValue.Text) + ",";
        strInput = strInput + txbDateCreated.Text + ",";
        strInput = strInput + txbDateSubmitted.Text + ",";
        strInput = strInput + txbDateQuoted.Text + ",";
        strInput = strInput + txbDateCreated.Text + ",";  //datelastchange = datecreated

        strInput = strInput + lblCurrencyCRM.Text + ",";// cmbCurrency.Text + ",";




        strInput = strInput + RemovePuncs((string)Session["ContactName"]) + ",";
        strInput = strInput + RemovePuncs((string)Session["AccountName"]) + ",";
        strInput = strInput + strOppID + ",";

        strInput = strInput + txbRequestor.Text + ",";
        strInput = strInput + cmbStatus.SelectedValue + ",";
        strInput = strInput + (string)Session["ContactID"] + ",";
        strInput = strInput + (string)Session["AccountID"] + ",";
        strInput = strInput + txbDateLastRevised.Text + ",";

        strInput = strInput + txbDateRequested.Text + ",";

        strInput = strInput + GetUserID(this) + ",";
        strInput = strInput + "Created RFQ" + ",";
        strInput = strInput + (chkGHS.Checked == true? "Yes" : "No") + "," ;
        strInput = strInput + lblNPRNumberValue.Text + ",";
        strInput = strInput + (!string.IsNullOrEmpty(lblEpicorQuoteNumValue.Text) ? lblEpicorQuoteNumValue.Text : "") ; 

        clsRFQHeader.SetInputArray(strInput);

        if (clsRFQHeader.CreateNewRFQHeaderRecord())
        {
            if (clsRFQHeader.GetIndentityID() < 0)
            {
                DisplayMsg("Error Creating RFQID. Possible Corrupted Data from CRM");
                return false;

            }
            Session["RFQID"] = clsRFQHeader.GetIndentityID();
            Session["RFQMAXLINE"] = 1;
            //            txbRFQNum.Text = Convert.ToString(clsRFQHeader.GetIndentityID());

        }

        UpdateCRMOpportunityRecord();
        return true;
    }

    private bool SetHeaderValues(DataTable dt)
    {
        string strLinkInfo;
        try
        {
            if (dt.Rows.Count > 0)
            {
                DataRow oRow = dt.Rows[0];
                lblRFQDescriptionValue.Text = AddPuncs((string)oRow["RFQDescription"]);
                if (!string.IsNullOrEmpty(oRow["DateCreated"].ToString().Trim()))
                    txbDateCreated.Text = Convert.ToDateTime(oRow["DateCreated"]).ToString(m_strDateTimeFormat);
                if (!string.IsNullOrEmpty(oRow["DateSubmitted"].ToString().Trim()))
                    txbDateSubmitted.Text = Convert.ToDateTime(oRow["DateSubmitted"]).ToString(m_strDateTimeFormat);
                if (!string.IsNullOrEmpty(oRow["DateQuoted"].ToString().Trim()))
                    txbDateQuoted.Text = Convert.ToDateTime(oRow["DateQuoted"]).ToString(m_strDateTimeFormat);

                if (!string.IsNullOrEmpty(oRow["DateLastRevised"].ToString().Trim()))
                    txbDateLastChanged.Text = Convert.ToDateTime(oRow["DateLastRevised"]).ToString(m_strDateTimeFormat);

                if (!string.IsNullOrEmpty(oRow["DateRevised"].ToString().Trim()))
                    txbDateLastRevised.Text = Convert.ToDateTime(oRow["DateRevised"]).ToString(m_strDateTimeFormat);

                if (!string.IsNullOrEmpty(oRow["DateRequired"].ToString().Trim()))
                    txbDateRequested.Text = Convert.ToDateTime(oRow["DateRequired"]).ToString(m_strDateTimeFormat);



                Session["OppID"] = (string)oRow["OpportunityID"];


                // Purge bogus date values

                if (txbDateCreated.Text.Contains("1900")) txbDateCreated.Text = "";
                if (txbDateSubmitted.Text.Contains("1900")) txbDateSubmitted.Text = "";
                if (txbDateQuoted.Text.Contains("1900")) txbDateQuoted.Text = "";
                if (txbDateLastChanged.Text.Contains("1900")) txbDateLastChanged.Text = "";
                if (txbDateLastRevised.Text.Contains("1900")) txbDateLastRevised.Text = "";
                if (txbDateRequested.Text.Contains("1900")) txbDateRequested.Text = "";

                if (!string.IsNullOrEmpty(oRow["Requestor"].ToString().Trim()))
                    txbRequestor.Text = (string)oRow["Requestor"];

                lblCurrencyCRM.Text = (string)oRow["Currency"];


                cmbStatus.SelectedValue = (string)oRow["RFQStatus"];

                if (Convert.ToInt16(cmbStatus.SelectedValue) > 10)
                {
                    btnSubmit.Visible = false;

                }

                if (Convert.ToInt16(cmbStatus.SelectedValue) > 10)
                {
                    cmbStatus.Enabled = true; 

                }
                else
                    cmbStatus.Enabled = false;

                if (Convert.ToInt16(cmbStatus.SelectedValue) >= 80)
                {
                    btnCancel.Visible = false;

                }
                else
                {
                    if (!string.IsNullOrEmpty(txbRequestor.Text))
                    {
                        string strOwner = txbRequestor.Text.ToUpper();
                        string strGroupID = Session["GroupID"].ToString().ToUpper();
                        if (strOwner != GetUserID(this))
                        {
                            if (strGroupID.Contains(m_strFullPrivilageUserName.ToUpper()))
                                btnCancel.Visible = true;
                            else
                                btnCancel.Visible = false;
                        }
                        else
                            btnCancel.Visible = true;


                    }
                }

                HyperLink lnkCustomer = new HyperLink();
                lnkCustomer.Text = AddPuncs((string)oRow["ContactName"]);
                lnkCustomer.NavigateUrl = "ViewCustomerInfo.aspx";



                if (!string.IsNullOrEmpty(oRow["ContactName"].ToString().Trim()))
                    lblCustomerName.Text = AddPuncs((string)oRow["ContactName"]);


     

                if (!string.IsNullOrEmpty(oRow["ChangedBy"].ToString().Trim()))
                    txbChangedBy.Text = (string)oRow["ChangedBy"];

                if (!string.IsNullOrEmpty(oRow["ReasonForChange"].ToString().Trim()))
                    txbReasonForChange.Text = (string)oRow["ReasonForChange"];

                if (!string.IsNullOrEmpty(oRow["GHSOpportunity"].ToString().Trim()))
                {
                    string strGHSOpportunity = (string)oRow["GHSOpportunity"].ToString().ToUpper();
                    chkGHS.Checked = strGHSOpportunity == "YES" ? true : false;
                }
                else
                    chkGHS.Checked = false;


 

                //lblCustomerName.Controls.Add(lnkCustomer);  // need to correct the name

                lblCustomerName.Visible = true;
                lblCustomer.Visible = true; 

                if (!string.IsNullOrEmpty((string)oRow["ContactName"]))
                {


                    if (!string.IsNullOrEmpty(oRow["ContactName"].ToString().Trim()))
                    {
                        lblCustomerName.Text = AddPuncs((string)oRow["ContactName"]);
                         
                    }


                    if (!string.IsNullOrEmpty(oRow["ContactCRMID"].ToString().Trim()))
                    {
                        strLinkInfo = (string)oRow["ContactCRMID"].ToString().ToUpper();

                    }
                    else
                        strLinkInfo = "NOT AVAIL";




                    if (!strLinkInfo.ToUpper().Contains("NOT AVAIL"))
                    {

                        BuildHyperLink(lblCustomerName, strLinkInfo, "Contact");
                        Session["ContactID"] = (string)oRow["ContactCRMID"];
                    }

         

                }
             

                    if (!string.IsNullOrEmpty(oRow["ParentCustomerName"].ToString().Trim()))
                    {
                        lblParentCustomerName.Text = AddPuncs((string)oRow["ParentCustomerName"]);

                    }

                    
                    
                    if (!string.IsNullOrEmpty(oRow["ParentCustomerCRMID"].ToString().Trim()))
                    {
                        strLinkInfo = (string)oRow["ParentCustomerCRMID"].ToString().ToUpper();

                    }
                    else
                        strLinkInfo = "NOT AVAIL";



                    if (!strLinkInfo.ToUpper().Contains("NOT AVAIL"))
                    {
                        lblParentCustomerName.Text = AddPuncs((string)oRow["ParentCustomerName"]);
                        BuildHyperLink(lblParentCustomerName, (string)oRow["ParentCustomerCRMID"], "Account");
                        Session["AccountID"] = (string)oRow["ParentCustomerCRMID"];
                    }

                


                if (!string.IsNullOrEmpty(oRow["OpportunityID"].ToString().Trim()))
                {
                    strLinkInfo = (string)oRow["OpportunityID"].ToString().ToUpper();

                }
                else
                    strLinkInfo = "NOT AVAIL";

                if (!strLinkInfo.ToUpper().Contains("NOT AVAIL"))
                {


                    BuildHyperLink(lblRFQDescriptionValue, (string)oRow["OpportunityID"], "Opportunity");
                    Session["OpportunityID"] = (string)oRow["OpportunityID"];
                }


                if (!string.IsNullOrEmpty(oRow["NPRNumber"].ToString().Trim()))
                {
                    lblNPRNumberValue.Text = (string)oRow["NPRNumber"];
                }
                else
                {
                    lblNPRNumberValue.Text = "";
                }

                lblEpicorQuoteNum.Visible = false;
                lblEpicorQuoteNumValue.Visible = false;
                if (Convert.ToInt16(cmbStatus.SelectedValue) >= 40)
                {

                    if (string.IsNullOrEmpty(oRow["EpicorQuoteNum"].ToString()))
                    {


                        EpicorData oEpicorData = new EpicorData();

                        string strQuoteNum = oEpicorData.GetQuoteNum(txbRFQNum.Text);


                        if (!string.IsNullOrEmpty(strQuoteNum))
                        {
                            lblEpicorQuoteNum.Visible = true;
                            lblEpicorQuoteNumValue.Visible = true;
                            lblEpicorQuoteNumValue.Text = strQuoteNum;

                            //Update RFQHeader 

                            RFQHeaderDB oHeader = new RFQHeaderDB();

                            if (!oHeader.UpdateEpicorQuoteNum(strQuoteNum, txbRFQNum.Text))
                            {
                                DisplayMsg(oHeader.ErrorMsg);

                            }


                        }
                    }
                    else
                    {
                        lblEpicorQuoteNum.Visible = true;
                        lblEpicorQuoteNumValue.Visible = true;
                        lblEpicorQuoteNumValue.Text = oRow["EpicorQuoteNum"].ToString();


                    }
                }

               


                //              UpdateCRMOpportunityRecord();

  


            }

          
            
            // Show Cancel Button

     



        }
        catch (Exception err)
        {

            DisplayMsg("Error: " + err.Message);
            return false;
        }
        return true;
    }

    private void BuildHyperLink(System.Web.UI.WebControls.Label lblTemp, string strUIID, string strCRMType)
    {
        string strCRMWebSite = GetCRMWebSite();
        if (string.IsNullOrEmpty(strCRMWebSite))
        {
            DisplayMsg("CRM Site Not Defined. Contact System Administrator");
            return;

        }
        string strCRMTargetURL = GetCRMTargetSite(strCRMType);
        if (string.IsNullOrEmpty(strCRMWebSite))
        {
            DisplayMsg("CRM Target Site Not Defined. Contact System Administrator");
            return;

        }
        HyperLink lnkAddress = new HyperLink();

        lnkAddress.Text = lblTemp.Text;
        lnkAddress.Target = "_blank";  //Opens new browser tab
        lnkAddress.NavigateUrl = string.Format("{0}{1}={2}", strCRMWebSite.Trim(), strCRMTargetURL.Trim(), strUIID.Trim());

        lblTemp.Controls.Add(lnkAddress);



    }
    private string GetCRMTargetSite(string strTargetURL)
    {
        string strTargetSite = null;

        if (string.IsNullOrEmpty(strTargetURL))
            return null; // calling func will display msg
        try
        {
            if (strTargetURL.ToUpper() == "CONTACT")
            {

                strTargetSite = ConfigurationManager.AppSettings["CRMContactURL"];
            }
            else if (strTargetURL.ToUpper() == "ACCOUNT")
            {
                strTargetSite = ConfigurationManager.AppSettings["CRMAccountURL"];

            }
            // CRMOpportunityURL
            else if (strTargetURL.ToUpper() == "OPPORTUNITY")
            {
                strTargetSite = ConfigurationManager.AppSettings["CRMOpportunityURL"];

            }

            if (string.IsNullOrEmpty(strTargetSite))
            {
                return null; // Calling func will display error message

            }
        }
        catch (ConfigurationErrorsException err)
        {

            return null;
        }
        return strTargetSite;

    }



    private string GetCRMWebSite()
    {
        string strWebSite = null;


        if (ConfigurationManager.AppSettings["Mode"].ToUpper().Contains("TEST"))
        {
            strWebSite = ConfigurationManager.AppSettings["DevCRMHostSite"];

        }
        else
            strWebSite = ConfigurationManager.AppSettings["ProdCRMHostSite"];

        if (string.IsNullOrEmpty(strWebSite))
        {
            return null; // Calling func will display error message

        }
        return strWebSite;

    }

    //private void BuildAccountIDHyperLink(System.Web.UI.WebControls.Label lblTemp, string strUIID)
    //{
    //    HyperLink lnkAddress = new HyperLink();
    //    lnkAddress.Text = lblTemp.Text;
    //    lnkAddress.Target = "_blank";  //Opens new browser tab

    //    lnkAddress.NavigateUrl = string.Format("http://crm01/DEVCRM13/main.aspx?etn=account&pagetype=entityrecord&id={0}",strUIID);
    //    lnkAddress.ViewStateMode = System.Web.UI.ViewStateMode.Enabled; 
    //    lblTemp.Controls.Add(lnkAddress);
    //}

    private bool IsReadyToSubmit(ref string strErrMessage)
    {
        if (string.IsNullOrEmpty(txbRFQNum.Text)) return false;

        RFQFieldControl dbControl = new RFQFieldControl();
        RFQDetail dbDetail = new RFQDetail();

        DataTable dtDetail = dbDetail.GetRFQFieldValues(txbRFQNum.Text);

        if (dtDetail.Rows.Count == 0)
        {
            strErrMessage = string.Format("No Line Data For Line[{0}] ", txbRFQNum.Text);
            strErrMessage = strErrMessage.Replace("\n", "");
            strErrMessage = strErrMessage.Replace("\r", "");
            return false;



        }
 

        foreach (DataRow oRow in dtDetail.Rows)
        {
            if (dbControl.IsRFQDetailARequiredField((string)oRow["Type"], (string)oRow["SubType"], (int)oRow["FieldRef"]))
            {
                if (string.IsNullOrEmpty((string)oRow["Value"]))
                {
                    strErrMessage = string.Format("Missing Data For Line[{0}] Value[{1}]", (int)oRow["Line"], (string)oRow["Description"]);
                    strErrMessage = strErrMessage.Replace("\n", "");
                    strErrMessage = strErrMessage.Replace("\r", "");
                    return false;
                }
            }

        }


        return true;
    }


    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(txbRFQNum.Text)) return;
        RFQHeaderDB dbHeader = new RFQHeaderDB();
        string strErrMessage = null;
        if (!IsReadyToSubmit(ref strErrMessage))
        {
            DisplayMsg(strErrMessage);
            return;

        }


        //if (cmbStatus.SelectedText.Trim().ToUpper() == "CREATED")
        if (cmbStatus.SelectedValue == "10")
        {
            //            cmbStatus.SelectedValue = "10";

            

 

 
            txbDateSubmitted.Text = DateTime.Now.ToString(m_strDateTimeFormat);
            UpdateCRMOpportunityRecord();
            dbHeader.UpdateSubmitted(txbDateSubmitted.Text, txbRFQNum.Text);
            if (!btnSendMail()) return;
            cmbStatus.Enabled = true; 
            cmbStatus.SelectedValue = "20";
            btnSubmit.Visible = false;
 
       

 
        }
        else
        {


            if (!string.IsNullOrEmpty(txbDateQuoted.Text) && (cmbStatus.SelectedText != "Quoted"))
            {
                dbHeader.RFQQuoted(txbDateQuoted.Text, txbRFQNum.Text);
            }



            if (!string.IsNullOrEmpty(txbDateRequested.Text))
            {

                dbHeader.UpdateDateRequested(txbDateRequested.Text, txbRFQNum.Text);
            }

            if (!string.IsNullOrEmpty(txbDateLastRevised.Text))
            {

                dbHeader.UpdateLastRevised(txbDateLastRevised.Text, txbRFQNum.Text);
            }

            txbDateLastChanged.Text = DateTime.Now.ToString(m_strDateTimeFormat);
            dbHeader.UpdateLastChanged(txbDateLastChanged.Text, txbRFQNum.Text);

            txbChangedBy.Text = GetUserID(this);


        }
        Response.Redirect(m_strStartPage + "?RFQID=" + txbRFQNum.Text, true);

        return;


        cmbStatus.SelectedIndex = 1;
        ResetForNewOption();
        //ResetTextBoxes();
        InitControls();
        grdRequiredValues.DataSource = null; ;
        grdRequiredValues.DataBind();

    }
    private string BuildMailMessage()
    {
        string strStartPage = ConfigurationManager.AppSettings["StartPage"].ToString();
        string strHostSite = ConfigurationManager.AppSettings["HostSite"].ToString();

        string strMailMessage = strHostSite + "/" + strStartPage + "?RFQID=" + txbRFQNum.Text;
        return strMailMessage;

    }

    private string BuildSendToEmailAddress(string strADGroupName)
    {
        string strSendToEmailAddress = null;
        RFQMailGroups dbMailGroups = new RFQMailGroups();
        
        DataTable dt = dbMailGroups.GetRFQMailGroups(strADGroupName);

        foreach (DataRow oRow in dt.Rows)
        {
            if (string.IsNullOrEmpty(strSendToEmailAddress))
            {
                strSendToEmailAddress = oRow["MailGroupNameAndAddress"].ToString();
            }
            else
            {
                strSendToEmailAddress += "," + oRow["MailGroupNameAndAddress"].ToString();
            }

        }

        return strSendToEmailAddress;
    }


    protected bool btnSendMail()
    {

        string strSubject = null;
        string strADGroupName = null;
        string strSMTPServerName = "mail.computype.com"; // default smtp server
        string strSMTPServerTest = "No"; // default smtp server
        string strMessage = @"
Message generated from within new rfq form.  
Invoked by 'magic ' button.
";
        try
        {
            strSMTPServerName = ConfigurationManager.AppSettings["SMTPServerName"].ToString();
        }
        catch (Exception err)
        {
            DisplayMsg("SMTP Server Undefined");
            return false;

        }

        try
        {
            strSMTPServerTest = ConfigurationManager.AppSettings["SMTPServerTest"].ToString();
        }
        catch (Exception err)
        {
            strSMTPServerTest = "NO";
        }

        strSMTPServerTest = strSMTPServerTest.ToUpper();


        strMessage = BuildMailMessage();
        string strToEmailAddress = "";
        string strUserID = GetUserID(this);
        if (!string.IsNullOrEmpty((string)Session["GroupID"]))
        {
            strADGroupName = (string)Session["GroupID"];
        }
        else
        {
            strADGroupName = "RFQ Group Unknown";

        }
        if (!string.IsNullOrEmpty(strUserID)&&(strSMTPServerTest!="YES"))
        {
            strUserID = strUserID.ToLower();
            if (!string.IsNullOrEmpty((string)Session["MailGroupID"]))
                strToEmailAddress = /*strUserID.Replace(" ", ".") + (string)("@computype.com").Trim() + "," +*/ BuildSendToEmailAddress((string)Session["MailGroupID"]);
            else
                strToEmailAddress = BuildSendToEmailAddress((string)Session["GroupID"]);  //use default 

        }
        else
        {
            strUserID = strUserID.Replace(" ", ".");
            strToEmailAddress = strUserID + "@Computype.com";
        }
 
        try
        {
            strSubject = string.Format("New RFQ[{0}] was Submitted for [{1}] on [{2}] From [{3}]", txbRFQNum.Text, lblParentCustomerName.Text, txbDateSubmitted.Text, txbRequestor.Text );
        MailMessage message = new MailMessage("no-replyRFQ@computype.com", strToEmailAddress, strSubject, strMessage);
//            MailMessage message = new MailMessage("dave.petersen@computype.com", "dave.petersen@computype.com", strSubject, strMessage);        
            message.IsBodyHtml = true;
            message.BodyEncoding = System.Text.Encoding.UTF8;
            message.SubjectEncoding = System.Text.Encoding.UTF8;

  

        System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient();

       
        client.Host = strSMTPServerName;
        

            
        //    client.UseDefaultCredentials = true;

            client.Send(message);
            
        }
        catch (Exception err)
        {
            DisplayMsg("Error Sending Email " + err.Message);
            return false;
        }



        return true;

    }

    private void EmailTest(string strToGroup)
    {
        SmtpClient client = new SmtpClient("mail.computype.com");
        MailAddress from = new MailAddress("sender@SenderMailServerName.com", "Sender Name");
        MailAddress to = new MailAddress(strToGroup, "Recepient Name");
        MailMessage message = new MailMessage(from, to);

        message.Body = "This is a test e-mail message sent by an application. ";
        message.Subject = "Test Email using Credentials";

        NetworkCredential myCreds = new NetworkCredential("username", "password", "domain");
        CredentialCache myCredentialCache = new CredentialCache();
        try
        {
            myCredentialCache.Add("ContoscoMail", 35, "Basic", myCreds);
            myCredentialCache.Add("ContoscoMail", 45, "NTLM", myCreds);

            client.Credentials = myCredentialCache.GetCredential("ContosoMail", 45, "NTLM");
            client.Send(message);
            Console.WriteLine("Goodbye.");
        }
        catch (Exception e)
        {
            Console.WriteLine("Exception is raised. ");
            Console.WriteLine("Message: {0} ", e.Message);
        }


    }

    protected void btnClose_Click(object sender, EventArgs e)
    {

        //RFQInputDetails.ResetControl();
        //mp1.Hide();
        //btnCloseTest.Visible = false;

    }
    protected void gvRFQDetails_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int nTest = 5;
    }
    protected void gvRFQDetails_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridView grdView = (GridView)sender; //
        GridViewRow row = (GridViewRow)grdView.NamingContainer;  // It will return the child gridview row in which textBox

        RFQDetail oRFQDetail = new RFQDetail();

        int nIndex = row.RowIndex;
        GridView gvRFQDetails = grdRequiredValues.Rows[nIndex].FindControl("gvRFQDetails") as GridView;


        gvRFQDetails.EditIndex = -1;




        string strLineID = row.Cells[1].Text;



        //      gvRFQDetails.DataSource = oRFQDetail.GetRFQIDDistinctGenericRecord(string.Format("SELECT * from RFQDetail where RFQID={0} AND Line={1}", txbRFQNum.Text, strLineID));

        gvRFQDetails.DataSource = oRFQDetail.GetRFQIDDistinctGenericRecord(string.Format("SELECT * from RFQDetail CROSS JOIN RFQFieldControlReference where RFQID={0} AND Line={1} AND RFQDetail.FieldRef = RFQFieldControlReference.FieldRef AND RFQDetail.Type = RFQFieldControlReference.Type AND RFQDetail.SubType = RFQFieldControlReference.SubType", txbRFQNum.Text, strLineID));


        gvRFQDetails.DataBind();



    }
    protected void gvRFQDetails_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        GridView grdView = (GridView)sender; //


        GridViewRow row = (GridViewRow)grdView.NamingContainer;  // It will return the child gridview row in which textBox

        int nParentRow = row.RowIndex;

        RFQDetail oRFQDetail = new RFQDetail();



        int nIndex = row.RowIndex;
        GridView gvRFQDetails = grdRequiredValues.Rows[nIndex].FindControl("gvRFQDetails") as GridView;


        string strLineID = grdRequiredValues.Rows[nIndex].Cells[1].Text;


        System.Web.UI.WebControls.Label lblTemp = grdView.Rows[e.RowIndex].FindControl("lbFieldRef") as System.Web.UI.WebControls.Label;



        string strFieldRef = lblTemp.Text;
        DropDownList oBox = gvRFQDetails.Rows[e.RowIndex].Cells[2].FindControl("COMBORow" + Convert.ToString(nParentRow) + "_" + strFieldRef) as DropDownList;
        TextBox oBoxT = gvRFQDetails.Rows[e.RowIndex].Cells[2].FindControl("TEXTBOXRow" + Convert.ToString(nParentRow) + "_" + strFieldRef) as TextBox;



        //string strRowValue = oBox.SelectedValue;

        //strRowValue=Request.QueryString["COMBORow" + Convert.ToString(nParentRow) +"_"+ strFieldRef];
        //strRowValue = Request.Form["COMBORow" + Convert.ToString(nParentRow) +"_"+ strFieldRef]; 
        //strRowValue = cmbValue.SelectedValue;
        //int nItem = cmbValue.SelectedIndex;
        //ListItem item = cmbValue.SelectedItem;

        //          DropDownList cmbValue = (DropDownList)gvRFQDetails.Rows[e.RowIndex].FindControl("COMBO"+Convert.ToString(nIndex));


        string strRowValue = RecreateControls("COMBORow" + Convert.ToString(nParentRow) + "_" + strFieldRef, "DropDownList");         //gvRFQDetails.Rows[e.RowIndex].Cells[2].Text;
        if (string.IsNullOrEmpty(strRowValue))
        {
            strRowValue = RecreateControls("TEXTBOXRow" + Convert.ToString(nParentRow) + "_" + strFieldRef, "DropDownList");         //gvRFQDetails.Rows[e.RowIndex].Cells[2].Text;

        }

        string strLine = row.Cells[1].Text;
        string strType = row.Cells[2].Text;
        string strSubType = row.Cells[3].Text;

        oRFQDetail.UpdateRFQDetailValue(strRowValue, txbRFQNum.Text, strLineID, strType, strSubType, strFieldRef);

        gvRFQDetails.EditIndex = -1;


        //        gvRFQDetails.DataSource = oRFQDetail.GetRFQIDDistinctGenericRecord(string.Format("SELECT * from RFQDetail where RFQID={0} AND Line={1}", txbRFQNum.Text, strLine));
        gvRFQDetails.DataSource = oRFQDetail.GetRFQIDDistinctGenericRecord(string.Format("SELECT * from RFQDetail CROSS JOIN RFQFieldControlReference where RFQID={0} AND Line={1} AND RFQDetail.FieldRef = RFQFieldControlReference.FieldRef AND RFQDetail.Type = RFQFieldControlReference.Type AND RFQDetail.SubType = RFQFieldControlReference.SubType", txbRFQNum.Text, strLine));


        gvRFQDetails.DataBind();



        txbDateLastChanged.Text = DateTime.Now.ToString(m_strDateTimeFormat);

        RFQHeaderDB oRFQHeader = new RFQHeaderDB();



        if (!oRFQHeader.UpdateLastChanged(txbDateLastChanged.Text, txbRFQNum.Text))
        {
            DisplayMsg("Error Updating Last Revised Date");
            return;

        }

    }

    private string RecreateControls(string ctrlPrefix, string ctrlType)
    {
        string ctrlValue = null;
        string[] ctrls = Request.Form.ToString().Split('&');

        int cnt = FindOccurence(ctrlPrefix);

        if (cnt > 0)
        {


            for (int i = 0; i < ctrls.Length; i++)
            {

                if (ctrls[i].Contains(ctrlPrefix))
                {

                    string ctrlName = ctrls[i].Split('=')[0];

                    ctrlValue = ctrls[i].Split('=')[1];



                    //Decode the Value

                    ctrlValue = Server.UrlDecode(ctrlValue);





                }

            }


        }
        return ctrlValue;
    }
 

    public string GetUserID(Page objPage)
    {
        string strUserName;
        string strTestUserID;

        try
        {
            strTestUserID = ConfigurationManager.AppSettings["TestUserID"];
            strUserName = ConfigurationManager.AppSettings["UserID"].ToUpper();  // here to test that appsetting exist
        }
        catch
        {
            strTestUserID = null;

        }
        // Routine requires Integrated Windows Security enabled
        // for the web site.
        if (string.IsNullOrEmpty(strTestUserID)) 
            strUserName = objPage.User.Identity.Name.ToUpper();
        else if (strTestUserID.ToUpper() == "YES")
        {
            strUserName = ConfigurationManager.AppSettings["UserID"].ToUpper();
        }
        else
        {
            strUserName = objPage.User.Identity.Name.ToUpper();
            strUserName = strUserName.Replace("COMPUTYPE\\", "");

        }

        // Get User Information BEGIN
        strUserName = strUserName.Replace("COMPUTYPE\\", "");
        strUserName = strUserName.Replace(".", " ");
        Session["UserID"] = strUserName;
        return strUserName;
    }



    private bool AllowUserAccess()
    {
        Boolean blnIsInSalesGroup = false;
        string strUserID = GetUserID(this);

        RFQSecurityFunctions clsUserSecurity = new RFQSecurityFunctions(strUserID);

        if (Session["AllowedAccess"] != null)
        {
  
            if ((bool)Session["AllowedAccess"])
            {

                return true;

            }
            return false;
        }



        //First Assume person is in a sales group

        string strAccessList = ConfigurationManager.AppSettings["RFQSalesADGroupName"].ToString();

//        clsUserSecurity.GetGroups("lisa.sarvie");

        if (clsUserSecurity.AllowUserAccess(strAccessList))
        {
            Session["AllowedAccess"] = true;

            if (!SetGroupID())
            {
                DisplayMsg("Unknown Group ID");
                Session["AllowedAccess"] = false;
  //              return false;
                blnIsInSalesGroup = false;
            }
            else
            {
                blnIsInSalesGroup = true;
                if (txbRFQNum.Text.ToUpper() != "NEW")
                {
                    if (!string.IsNullOrEmpty(txbRFQNum.Text))
                        GetUploadedFiles();
                }
            }
      //      return true;

        }

        // if not sales then try quoteteam

        strAccessList = ConfigurationManager.AppSettings["RFQEngineeringADGroupName"].ToString();

        

        if (clsUserSecurity.AllowUserAccess(strAccessList))
        {
            Session["AllowedAccess"] = true;

            if (!SetGroupID())
            {
    //            DisplayMsg("Unknown Group ID");
                if (!blnIsInSalesGroup)
                {
                    DisplayMsg("Unknown Group ID");

                    Session["AllowedAccess"] = false;
                    return false;
                }
            }

            if (txbRFQNum.Text.ToUpper() != "NEW")
            {
                if (!string.IsNullOrEmpty(txbRFQNum.Text))
                    GetUploadedFiles();
            }
            return true;

        }

        if (blnIsInSalesGroup)
        {
            Session["AllowedAccess"] = true;
        }
        else
        {
            Session["AllowedAccess"] = false;
        }
        return (bool)Session["AllowedAccess"];
    }

    private bool SetGroupID()
    {
        string strUserID = GetUserID(this);

        RFQSecurityFunctions clsUserSecurity = new RFQSecurityFunctions(strUserID);


//        RFQSecurityFunctions clsUserSecurity = new RFQSecurityFunctions(strUserID);
        string strGroupID = clsUserSecurity.ADGroupType();
        if (string.IsNullOrEmpty(strGroupID))        return false;
        Session["MailGroupID"] = clsUserSecurity.ADGroupName; 
        Session["GroupID"] = strGroupID;
        Session["UserID"] = strUserID; //clsUserSecurity.GetUserID();
        return true;
    }

    private void GetUploadedFiles()
    {
        bool blnFilesFound = false;
        UPLOADFOLDERROOT = ConfigurationManager.AppSettings["UploadRootPath"] + @"\" + txbRFQNum.Text;
        UPLOADFOLDER = ConfigurationManager.AppSettings["UploadRootPath"] + @"\" + txbRFQNum.Text;
        if ((string)Session["GroupID"].ToString().ToUpper()  == "ENGINEERING")
        {
            UPLOADFOLDER = UPLOADFOLDER + @"\" + "Engineering";
            
        }
        else //Default
        {
            UPLOADFOLDER = UPLOADFOLDER + @"\";
        }
        
        
        string strFileList = null;
        string strUploadRootPath = ConfigurationManager.AppSettings["UploadRootPath"].ToString();

        DataTable dtFiles = GetFilesInDirectory(HttpContext.Current.Server.MapPath(UPLOADFOLDERROOT));
        btnUpload.BackColor = System.Drawing.Color.LightGray;
        btnUpload.Text = "Attach/View Files";

        btnUpload.ToolTip = "";   //Clear out any default tool tip.
        foreach (DataRow oRow in dtFiles.Rows)
        {
            btnUpload.ToolTip += (string)oRow["Name"]+ Environment.NewLine;
            if (!blnFilesFound)
            {
                blnFilesFound = true;
                btnUpload.Text = "Attachment(s)";

                 btnUpload.CssClass = btnUpload.CssClass.Replace("button", "");
                 btnUpload.BackColor = System.Drawing.Color.LightGreen;
                 btnUpload.Font.Bold = true;
                 btnUpload.Style.Add(" font-family", "arial");
                 btnUpload.Style.Add(" font-size", "17px");
                 btnUpload.Style.Add(" border-radius", "10px");
                 btnUpload.Style.Add(" color", " #fa0808");
                 btnUpload.Style.Add(" background", "linear-gradient(top,  #E0E0E0,  #848383)");
  //               btnUpload.Style.Add(" background", "-ms-linear-gradient(top,  #E0E0E0,  #848383)");
 

            }


        }

    }

    private void AddRowToDetailGrid()
    {
        int nNewRowID;
        RFQDetail oRFQDetail = new RFQDetail();
        string strRFQID = txbRFQNum.Text;
        nNewRowID = oRFQDetail.GetNextMaxLineID(strRFQID);

        DataTable dtTemp = (DataTable)Session["OriginalData"];

        DataRow oEditRow = dtTemp.NewRow();

        oEditRow["Line"] = (int)Session["RFQMAXLINE"];
        oEditRow["Type"] = (string)Session["RFQType"];
        oEditRow["SubType"] = (string)Session["RFQSubType"];

        Session["ADDNEWRFQDETAILS"] = true;
        SetNewRowIDInfo();

        dtTemp.Rows.Add(oEditRow);
        dtTemp.AcceptChanges();
        grdRequiredValues.DataSource = dtTemp;
        grdRequiredValues.DataBind();
        Session["ADDNEWRFQDETAILS"] = false;



    }
    private void SetNewRowIDInfo()
    {
        int nNewRowID;
        RFQDetail oRFQDetail = new RFQDetail();
        nNewRowID = oRFQDetail.GetNextMaxLineID(txbRFQNum.Text);
        Session["NEWROWID"] = nNewRowID;
    }
    private int GetNewRowID()
    {
        return (int)Session["NEWROWID"];

    }

    protected void grdRequiredValues_RowCreated(object sender, GridViewRowEventArgs e)
    {

    }
    protected void cmbValue_SelectedIndexChanged(object sender, EventArgs e)
    {
        int nTest = 5;
    }

    //protected override void LoadViewState(object savedState)
    //{

    //    //if we can identify the custom view state as defined in the override for SaveViewState
    //    if (savedState is object[] && ((object[])savedState).Length == 2 && ((object[])savedState)[0] is string[])
    //    {
    //        object[] newViewState = (object[])savedState;
    //        string[] txtValues = (string[])(newViewState[0]);
    //        if (txtValues.Length > 0)
    //        {
    //            //re-load tables
    //            CreateGridData();
    //            int ii = 0;
    //            foreach (GridViewRow oRow in grdRequiredValues.Rows)
    //            {

    //                GridView grdView = (GridView)oRow.FindControl("gvRFQDetails");


    //                //Transfer rows from GridView to table
    //                for (int i = 0; i < grdView.Rows.Count; i++)
    //                {
    //                    if (grdView.Rows[i].RowType == DataControlRowType.DataRow)
    //                    {
    //                        for (int j = 0; j < grdView.Rows[i].Cells.Count; j++)
    //                        {
    //                            for (int k = 0; k < grdView.Rows[i].Cells[j].Controls.Count; k++)
    //                            {
    //                                if (grdView.Rows[i].Cells[j].Controls[k] is System.Web.UI.WebControls.Label)
    //                                {
    //                                    ((System.Web.UI.WebControls.Label)grdView.Rows[i].Cells[j].Controls[k]).Text = txtValues[ii++].ToString();
    //                                }                         //Add your code here..
    //                                else if (grdView.Rows[i].Cells[j].Controls[k] is TextBox)
    //                                {
    //                                    ((TextBox)grdView.Rows[i].Cells[j].Controls[k]).Text = txtValues[ii++].ToString();
    //                                }
    //                                else if (grdView.Rows[i].Cells[j].Controls[k] is DropDownList)
    //                                {
    //                                    ((DropDownList)grdView.Rows[i].Cells[j].Controls[k]).Text = txtValues[ii++].ToString();
    //                                }
    //                                else if (grdView.Rows[i].Cells[j].Controls[k] is ComboBox)
    //                                {
    //                                    ((ComboBox)grdView.Rows[i].Cells[j].Controls[k]).SelectedText = txtValues[ii++].ToString();
    //                                }

    //                            }

    //                        }
    //                    }
    //                }




    //                //else if (cell.Controls[0] is ComboBox)
    //                //{
    //                //    txtValues.Add(((ComboBox)cell.Controls[0]).SelectedText + "," + cell.ID);
    //                //}

    //            }

    //        }
    //        //load the ViewState normally
    //        base.LoadViewState(newViewState[1]);
    //    }
    //    else
    //    {
    //        base.LoadViewState(savedState);
    //    }
    //}


    //protected override object SaveViewState()
    //{

    //    object[] newViewState = new object[2];

    //    List<string> txtValues = new List<string>();



    //    foreach (GridViewRow oRow in grdRequiredValues.Rows)
    //    {

    //        GridView grdView = (GridView)oRow.FindControl("gvRFQDetails");


    //        //Transfer rows from GridView to table
    //        for (int i = 0; i < grdView.Rows.Count; i++)
    //        {
    //            if (grdView.Rows[i].RowType == DataControlRowType.DataRow)
    //            {
    //                for (int j = 0; j < grdView.Rows[i].Cells.Count; j++)
    //                {
    //                    for (int k = 0; k < grdView.Rows[i].Cells[j].Controls.Count; k++)
    //                    {
    //                        if (grdView.Rows[i].Cells[j].Controls[k] is System.Web.UI.WebControls.Label)
    //                        {
    //                            txtValues.Add(((System.Web.UI.WebControls.Label)grdView.Rows[i].Cells[j].Controls[k]).Text);
    //                        }                         //Add your code here..
    //                        else if (grdView.Rows[i].Cells[j].Controls[k] is TextBox)
    //                        {
    //                            txtValues.Add(((TextBox)grdView.Rows[i].Cells[j].Controls[k]).Text);
    //                        }
    //                        else if (grdView.Rows[i].Cells[j].Controls[k] is DropDownList)
    //                        {
    //                            txtValues.Add(((DropDownList)grdView.Rows[i].Cells[j].Controls[k]).SelectedValue);
    //                        }
    //                        else if (grdView.Rows[i].Cells[j].Controls[k] is ComboBox)
    //                        {
    //                            txtValues.Add(((ComboBox)grdView.Rows[i].Cells[j].Controls[k]).SelectedText);
    //                        }

    //                    }
    //                }
    //            }
    //        }




    //        //else if (cell.Controls[0] is ComboBox)
    //        //{
    //        //    txtValues.Add(((ComboBox)cell.Controls[0]).SelectedText + "," + cell.ID);
    //        //}

    //    }

    //    newViewState[0] = txtValues.ToArray();
    //    newViewState[1] = base.SaveViewState();
    //    return newViewState;
    //}
    private void CreateGridData()
    {
        RFQDetail oRFQDetail = new RFQDetail();

        //                  grdRequiredValues.DataSourceID = null;
        grdRequiredValues.DataSource = oRFQDetail.GetRFQIDDistinctDetailRecord((string)Session["RFQID"]);
        grdRequiredValues.DataBind();


    }
    protected void cmbValue_SelectedIndexChanged1(object sender, EventArgs e)
    {
        int nTest = 5;
    }
    //protected void imgBtn_Click(object sender, ImageClickEventArgs e)
    //{
    //    imgBtn.Visible = false;
    //    DisplayRFQTypes();

    //}
    protected void txbDateQuoted_TextChanged(object sender, EventArgs e)
    {
        try
        {
            DateTime dTest = Convert.ToDateTime(txbDateQuoted.Text);
        }
        catch (Exception err)
        {
            DisplayMsg("Invalid Quoted Date");
            return;

        }
        if (string.IsNullOrEmpty(txbRFQNum.Text)) return;


        if (!string.IsNullOrEmpty(txbDateQuoted.Text))
        {
            RFQHeaderDB odbHeader = new RFQHeaderDB();
            odbHeader.RFQQuoted(txbDateQuoted.Text, txbRFQNum.Text);
        }
        UpdateCRMOpportunityRecord();
    }
    protected void txbDateLastRevised_TextChanged(object sender, EventArgs e)
    {
        try
        {
            DateTime dTest = Convert.ToDateTime(txbDateLastRevised.Text);
        }
        catch (Exception err)
        {
            DisplayMsg("Invalid Date Revised ");
            return;

        }
        if (string.IsNullOrEmpty(txbRFQNum.Text)) return;


        if (!string.IsNullOrEmpty(txbDateLastRevised.Text))
        {
            RFQHeaderDB odbHeader = new RFQHeaderDB();

            odbHeader.UpdateLastRevised(txbDateLastRevised.Text, txbRFQNum.Text);
        }
        //    UpdateCRMOpportunityRecord();

    }
    protected void txbDateRequested_TextChanged(object sender, EventArgs e)
    {
        try
        {
            DateTime dTest = Convert.ToDateTime(txbDateRequested.Text);
        }
        catch (Exception err)
        {
            DisplayMsg("Invalid Date Requested ");
            return;

        }
        if (string.IsNullOrEmpty(txbRFQNum.Text)) return;


        if (!string.IsNullOrEmpty(txbDateRequested.Text))
        {
            RFQHeaderDB odbHeader = new RFQHeaderDB();
            odbHeader.UpdateDateRequested(txbDateRequested.Text, txbRFQNum.Text);
        }
    }
    protected void cmbStatus_SelectedIndexChanged(object sender, ComboBoxItemEventArgs e)
    {
        RFQHeaderDB oDBHdr = new RFQHeaderDB();

        int nStatus = oDBHdr.GetRFQCurrentStatus(txbRFQNum.Text);

        if (nStatus >= 20)
        {
            if (string.IsNullOrEmpty((string)Session["GroupID"]))
            {
                cmbStatus.SelectedValue = Convert.ToString(nStatus);
                DisplayMsg("Unknown GroupID");
                return;
                
            }
            if (Session["GroupID"].ToString().ToUpper() == "SALES")
            {
                cmbStatus.SelectedValue = Convert.ToString(nStatus);
                DisplayMsg("Changing the RFQ Status Above \"Submitted\" Is Not Allowed With the Current User Profile.");
                    return;

            }
            else if (cmbUserProfiles.Enabled)
            {
                if (cmbUserProfiles.SelectedText.ToUpper() == "SALES")
                {
                    cmbStatus.SelectedValue = Convert.ToString(nStatus);
                    DisplayMsg("Changing Status Not Allowed");
                    return;

                }
            }

        }
        if (nStatus == 80)
        {
            cmbStatus.SelectedValue = Convert.ToString(nStatus);
            DisplayMsg("RFQ Is Completed. No Change Is Allowed");
            return;

        }
        if (nStatus == 90)
        {
            cmbStatus.SelectedValue = Convert.ToString(nStatus);
            DisplayMsg("RFQ Was Cancelled. No Change Is Allowed");
            return;

        }

        int nSelectedStatus = Convert.ToInt32(cmbStatus.SelectedValue);

        if (nSelectedStatus < nStatus)
        {
            cmbStatus.SelectedValue = Convert.ToString(nStatus);
            DisplayMsg("Status Must Move Forward");

            return;

        }

        if (cmbStatus.SelectedValue == "10")
        {


        }
        else if (cmbStatus.SelectedValue == "20")
        {


        }
        else if (cmbStatus.SelectedValue == "30")   // In Process
        {
            if (!UpdateStatusToInProcess())
            {
                cmbStatus.SelectedValue = Convert.ToString(nStatus);
                DisplayMsg("Error Updating Status To In Process");
                return;

            }



        }
        else if (cmbStatus.SelectedValue == "40")
        {
            if (!UpdateDateQuoted())
            {
                cmbStatus.SelectedValue = Convert.ToString(nStatus);
                DisplayMsg("Error Updating Status To Quoted");
                return;

            }

        }
        else if (cmbStatus.SelectedValue == "50")
        {

            if (nStatus != 40)
            {
                cmbStatus.SelectedValue = Convert.ToString(nStatus);
                DisplayMsg("Error Updating Status To Revised, RFQ Status Must = Quoted");
                return;


            }
            if (!UpdateRevised())
            {
                cmbStatus.SelectedValue = Convert.ToString(nStatus);
                DisplayMsg("Error Updating Status To Quoted");
                return;

            }

        }
        else if (cmbStatus.SelectedValue == "80")
        {

            if (!UpdateCompleted())
            {
                cmbStatus.SelectedValue = Convert.ToString(nStatus);
                DisplayMsg("Error Updating Status To Completed");
                return;


            }

        }
        else if (cmbStatus.SelectedValue == "90")
        {

            if (!RFQCancelled())
            {
                cmbStatus.SelectedValue = Convert.ToString(nStatus);
                DisplayMsg("Error Updating Status To Cancelled");
                return;


            }

        }


        Response.Redirect(m_strStartPage + "?RFQID=" + txbRFQNum.Text, true);


    }
    private bool UpdateDateQuoted()
    {


        if (string.IsNullOrEmpty(txbRFQNum.Text)) return false;

        txbDateQuoted.Text = DateTime.Now.ToString(m_strDateTimeFormat);

        if (!string.IsNullOrEmpty(txbDateQuoted.Text))
        {
            RFQHeaderDB odbHeader = new RFQHeaderDB(GetUserID(this));
            odbHeader.RFQQuoted(txbDateQuoted.Text, txbRFQNum.Text);
        }
        UpdateCRMOpportunityRecord();
        return true;

    }

    private bool UpdateCompleted()
    {


        if (string.IsNullOrEmpty(txbRFQNum.Text)) return false;


        txbDateLastChanged.Text = DateTime.Now.ToString(m_strDateTimeFormat);

        if (!string.IsNullOrEmpty(txbDateLastChanged.Text))
        {
            RFQHeaderDB odbHeader = new RFQHeaderDB(GetUserID(this));
            odbHeader.RFQCompleted(txbDateLastChanged.Text, txbRFQNum.Text);


        }
        UpdateCRMOpportunityRecord();
        return true;

    }
    private bool RFQCancelled()
    {


        if (string.IsNullOrEmpty(txbRFQNum.Text)) return false;


        txbDateLastChanged.Text = DateTime.Now.ToString(m_strDateTimeFormat);

        if (!string.IsNullOrEmpty(txbDateLastChanged.Text))
        {
            RFQHeaderDB odbHeader = new RFQHeaderDB(GetUserID(this));
            odbHeader.RFQCancelled(txbDateLastChanged.Text, txbRFQNum.Text);


        }
        UpdateCRMOpportunityRecord();
        return true;

    }

    private bool UpdateStatusToInProcess()
    {


        if (string.IsNullOrEmpty(txbRFQNum.Text)) return false;
        txbDateLastChanged.Text = DateTime.Now.ToString(m_strDateTimeFormat);





        RFQHeaderDB odbHeader = new RFQHeaderDB(GetUserID(this));
        odbHeader.RFQInProcess(txbRFQNum.Text);


        UpdateCRMOpportunityRecord();
        return true;

    }

    private bool UpdateRevised()
    {


        if (string.IsNullOrEmpty(txbRFQNum.Text)) return false;
        txbDateLastChanged.Text = DateTime.Now.ToString(m_strDateTimeFormat);





        RFQHeaderDB odbHeader = new RFQHeaderDB(GetUserID(this));
        odbHeader.UpdateLastRevised(txbDateLastChanged.Text, txbRFQNum.Text);


        UpdateCRMOpportunityRecord();
        return true;

    }

    private void LockRFQFromChange()
    {
        RFQHeaderDB oDBHdr = new RFQHeaderDB();

        int nStatus = oDBHdr.GetRFQCurrentStatus(txbRFQNum.Text);
        if ((nStatus == 80) || (nStatus == 90))
        {
            cmbStatus.Enabled = false;
 
            btnUpload.Enabled = false;
            btnSubmit.Enabled = false;

            grdRequiredValues.Enabled = false;

            txbDateRequested.Enabled = false;
            //rbList1.Enabled = false;



        }


    }


    protected void cmbRFQTYPE_SelectedIndexChanged(object sender, ComboBoxItemEventArgs e)
    {
       string strRFQType = cmbRFQTYPE.SelectedText;

       cmbRFQSubType.Items.Clear();   
       btnAddRFQDetail.Enabled = false; 
       DisplaySubTypes(strRFQType);


    }


    protected void btnAddRFQDetail_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(cmbRFQTYPE.SelectedValue))
        {
            DisplayMsg("Unknown RFQ Type");
            return;
        }
        else if (cmbRFQTYPE.SelectedValue.ToUpper().Contains("SELECT"))
        {
            DisplayMsg("RFQ Type Has Not Been Selected");
            return;
        }
        if (string.IsNullOrEmpty(cmbRFQSubType.SelectedValue))
        {
            DisplayMsg("Unknown RFQ Type");
            return;
        }
        else if (cmbRFQSubType.SelectedValue.ToUpper().Contains("SELECT"))
        {
            DisplayMsg("RFQ Type Has Not Been Selected");
            return;
        }

        if (string.IsNullOrEmpty(cmbProductGroup.SelectedValue))
        {
            DisplayMsg("Unknown Product Group ");
            return;
        }
        else if (cmbProductGroup.SelectedValue.ToUpper().Contains("SELECT"))
        {
            DisplayMsg(" Product Group Has Not Been Selected");
            return;
        }


        Session["RFQType"] = cmbRFQTYPE.SelectedValue;
        Session["RFQSubType"] = cmbRFQSubType.SelectedValue;
        Session["ProductGroup"] = cmbProductGroup.SelectedValue;
 

        if (txbRFQNum.Text.ToUpper() == "NEW")
        {
            CreateNewRFQHeaderRecord();
        }
        else if (!string.IsNullOrEmpty(txbRFQNum.Text))
        {
            Session["RFQID"] = Convert.ToInt32(txbRFQNum.Text);
        }
        else
        {
            DisplayMsg("RFQ ID Can Not Be Blank");
            return;

        }
           

        DisplayAddEditPage(); 
    }
    protected void cmbRFQSubType_SelectedIndexChanged(object sender, ComboBoxItemEventArgs e)
    {
        if (!cmbRFQSubType.SelectedValue.ToUpper().Contains("SELECT"))
        {
            cmbProductGroup.Enabled = true;
            cmbProductGroup.EmptyText = "Select Product Group";
    //        btnAddRFQDetail.Enabled = true;
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
            if ((string)Session["GroupID"].ToString().ToUpper()  == "SALES")
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
    private bool IsSessionVarOK(Object objSession)
    {
        if (objSession == null)
            return false;

        return true;
    }
    protected void cmbProductGroup_SelectedIndexChanged(object sender, ComboBoxItemEventArgs e)
    {
        if (!cmbProductGroup.SelectedValue.ToUpper().Contains("SELECT"))
        {
            btnAddRFQDetail.Enabled = true;
        }
        else
        {
            btnAddRFQDetail.Enabled = false;

        }
    }
    protected void cmbUserProfiles_SelectedIndexChanged(object sender, ComboBoxItemEventArgs e)
    {
        if (!cmbUserProfiles.SelectedText.Contains("Select"))
        {

            Session["GroupID"] = cmbUserProfiles.SelectedText;
        }
        if (txbRFQNum.Text.ToUpper() != "NEW")
        {
            if (!string.IsNullOrEmpty(txbRFQNum.Text))
                GetUploadedFiles();
        }
    }
    public string GenerateUniqueTabGuid() 
    { 
        
        SessionHandler.ValidInstanceGuid= Guid.NewGuid().ToString().Replace("-", ""); 
        return SessionHandler.ValidInstanceGuid; 
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {

        if (!string.IsNullOrEmpty(txbRequestor.Text))
        {
            string strOwner = txbRequestor.Text.ToUpper();
            string strGroupID = Session["GroupID"].ToString().ToUpper();
            if (strOwner != GetUserID(this))
            {
                if (!strGroupID.Contains(m_strFullPrivilageUserName.ToUpper()))
                {
                    return;



                }
            }

            if (!RFQCancelled())
            {
                cmbStatus.SelectedValue = Convert.ToString(m_nDeleteStatusValue);
                DisplayMsg("Error Updating Status To Cancelled");
                return;


            }
            Response.Redirect(m_strStartPage + "?RFQID=" + txbRFQNum.Text, true);
          
        }
    }

}