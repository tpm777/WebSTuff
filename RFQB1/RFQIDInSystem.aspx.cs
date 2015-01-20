﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Obout.Grid;
using System.Collections;
using System.Configuration;
using System.Web.Services;



public partial class RFQIDInSystem : System.Web.UI.Page
{
    string m_strStartPage = ConfigurationManager.AppSettings["StartPage"];
    protected void Page_Load(object sender, EventArgs e)
    {
        string strUserID=null;
//        grid1.FilteringSettings.InitialState = Obout.Grid.GridFilterState.Hidden;
        grid1.FolderStyle = "grid/styles/black_glass";

        
        if (!IsPostBack)
        {
           
            string strQuoteTeam = (string)Request.QueryString["QT"];
            string strOppID =     (string)Request.QueryString["OppID"];
           
            if (!string.IsNullOrEmpty(strOppID))
            {
                FilterCriteria criteriaOppID = new FilterCriteria();
                criteriaOppID.Option.Type = FilterOptionType.Contains;
                criteriaOppID.Value = strOppID;

                FilterOption filOpoID = new FilterOption();
                filOpoID.Type = FilterOptionType.Contains;

                grid1.Columns["OpportunityID"].FilterCriteria = criteriaOppID;
                grid1.Columns["OpportunityID"].FilterOptions.Add(filOpoID);



            }
            else
            {

                string strRequestor = (string)Request.QueryString["Requestor"];
                if (string.IsNullOrEmpty(strRequestor))
                {
                   if (GetFilterSettings()) return;

                    if (!string.IsNullOrEmpty((string)Session["UserID"]))
                        strUserID = (string)Session["UserID"];
                    else
                    {
                        strUserID = GetUserID(this);

                    }
                    strUserID = strUserID.Replace(".", " ");

                }
                else
                    strUserID = strRequestor;

 
                FilterCriteria criteria = new FilterCriteria();
                criteria.Option.Type = FilterOptionType.SmallerThan ;
                criteria.Value = "80";

                FilterCriteria criteriaCancelled= new FilterCriteria();
                criteriaCancelled.Option.Type = FilterOptionType.DoesNotContain;
                criteriaCancelled.Value = "Cancelled";


                if (!string.IsNullOrEmpty(strUserID))
                {
                    FilterCriteria criteria2 = new FilterCriteria();
                    criteria2.Option.Type = FilterOptionType.Contains;
                    criteria2.Value = strUserID;
                    grid1.Columns["Requestor"].FilterCriteria = criteria2;

                    FilterOption filOpt2 = new FilterOption();
                    FilterOption filOpt3 = new FilterOption();

                    filOpt2.Type = FilterOptionType.Contains;
                    grid1.Columns["Requestor"].FilterOptions.Add(filOpt2);
                    filOpt3.Type = FilterOptionType.NoFilter;
                    grid1.Columns["Requestor"].FilterOptions.Add(filOpt3);
                }

                FilterOption filOpt = new FilterOption();

                filOpt.Type = FilterOptionType.Contains;

                grid1.Columns["RFQStatus"].FilterCriteria = criteria;

 //               grid1.Columns["Status"].FilterOptions.Add(filOpt);
           //     grid1.FilteringSettings.InitialState = Obout.Grid.GridFilterState.Hidden;
                 
            }
           
            grid1.DataBind();
          
            


        }

    }

    //protected void grdRFQsInSystem_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    GridViewRow row = grdRFQsInSystem.SelectedRow;

    //    Response.Redirect(m_strStartPage +"?RFQID=" + row.Cells[1].Text, true);  
    //}
    protected void grid1_Select(object sender, Obout.Grid.GridRecordEventArgs e)
    {
        string strSelectedReord;
        if (grid1.SelectedRecords != null)
        {

            foreach (Hashtable oRecord in grid1.SelectedRecords)
            {
                SaveFilterSettings();
                strSelectedReord = (string)oRecord["RFQID"];
                Response.Redirect(m_strStartPage + "?RFQID=" + strSelectedReord, true);
            }


        }
    }
 

    protected void RebindGrid(object sender, EventArgs e)
    {
        CreateGrid();
    }

    private void CreateGrid()
    {

  //      grid1.FilteringSettings.InitialState = Obout.Grid.GridFilterState.Visible;
        grid1.FolderStyle = "grid/styles/black_glass";

        FilterCriteria criteria = new FilterCriteria();
        criteria.Option.Type = FilterOptionType.SmallerThan;
        criteria.Value = "80";

        FilterOption filOpt = new FilterOption();

        filOpt.Type = FilterOptionType.Contains;

        grid1.Columns[1].FilterCriteria = criteria;
        grid1.Columns[1].FilterOptions.Add(filOpt);
        grid1.DataBind();


    }
    public string GetUserID(Page objPage)
    {

   
        // Routine requires Integrated Windows Security enabled
        // for the web site.

        string strUserName;
        strUserName = objPage.User.Identity.Name.ToUpper();

        // Get User Information BEGIN
        strUserName = strUserName.Replace("COMPUTYPE\\", "");
        strUserName = strUserName.Replace(".", " ");
        Session["UserID"] = strUserName;
        return strUserName;
    }
    public void RowDataBound(object sender, GridRowEventArgs e)
    {
        if (e.Row.RowType == GridRowType.DataRow)
        {
            if (e.Row.Cells[7].Text.Contains("1900"))
                e.Row.Cells[7].Text = "";

            if (e.Row.Cells[8].Text.Contains("1900"))
                e.Row.Cells[8].Text = "";

            if (e.Row.Cells[9].Text.Contains("1900"))
                e.Row.Cells[9].Text = "";


        }
    }
    private void SaveFilterSettings()
    {
      

        foreach (Column oCol in grid1.Columns)
        {
//            Enum.Parse(typeof(FilterOptionType),  
            
            if (Enum.Parse(typeof(FilterOptionType), oCol.FilterCriteria.Option.Type.ToString()).ToString() != "")
            {
                string strCookie = oCol.FilterCriteria.Value;
                if (!string.IsNullOrEmpty(strCookie))
                {
                    Response.Cookies["Col" + Convert.ToString(oCol.Index)]["FilterCriteria"] = oCol.FilterCriteria.Value;
                    Response.Cookies["Col" + Convert.ToString(oCol.Index)]["FilterOptions"] = Enum.Parse(typeof(FilterOptionType), oCol.FilterCriteria.Option.Type.ToString()).ToString();
                    Response.Cookies["Col" + Convert.ToString(oCol.Index)].Expires = DateTime.MaxValue;
                }
            }

        }

    }

    private bool GetFilterSettings()
    {
      
        bool blnFound = false;
        foreach (Column oCol in grid1.Columns)
        {
            //            Enum.Parse(typeof(FilterOptionType),  
            if (Request.Cookies["Col" + Convert.ToString(oCol.Index)] != null)
            {
                string strCookie = Request.Cookies["Col" + Convert.ToString(oCol.Index)]["FilterCriteria"];
                if (!string.IsNullOrEmpty(strCookie))
                {
                    FilterCriteria criteria = new FilterCriteria();
                    criteria.Value = strCookie;
                    criteria.Option.Type = (FilterOptionType)Enum.Parse(typeof(FilterOptionType), Request.Cookies["Col" + Convert.ToString(oCol.Index)]["FilterOptions"]);

                    oCol.FilterCriteria = criteria;



                    blnFound = true;

                }

            }

        }

        return blnFound;

    }
    [System.Web.Services.WebMethod]
    public static void ProcessFilter(Grid oGrid1 /* , Page oPage*/)
    {
        string strTest = "Hello World";
       
        //foreach (Column oCol in oGrid1.Columns)
        //{
        //    //            Enum.Parse(typeof(FilterOptionType),  

        //    if (Enum.Parse(typeof(FilterOptionType), oCol.FilterCriteria.Option.Type.ToString()).ToString() != "")
        //    {

        //        //oPage.Response.Cookies["Col" + Convert.ToString(oCol.Index)]["FilterCriteria"] = oCol.FilterCriteria.Value;
        //        //oPage.Response.Cookies["Col" + Convert.ToString(oCol.Index)]["FilterOptions"] = Enum.Parse(typeof(FilterOptionType), oCol.FilterCriteria.Option.Type.ToString()).ToString();
        //        //oPage.Response.Cookies["Col" + Convert.ToString(oCol.Index)].Expires = DateTime.MaxValue;

        //    }

        //}
    }

}
