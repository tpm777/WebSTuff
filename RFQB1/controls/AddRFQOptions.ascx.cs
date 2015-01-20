using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class AddRFQOptions : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            rbList1.Items[0].Text = "Labels";
            rbList1.Items[1].Text = "Equipment";
            rbList1.Items[2].Text = "Service";
            pnlAddOption.Visible = false;
            pnlSalesOptions.Visible = false;
            pnlSummaryGrid.Visible = false; 

        }
    }

    public bool AutoPostBack
    {
    
        get { return rbList1.AutoPostBack; }
        set { rbList1.AutoPostBack = value; }
    }

    public void rbList1_SelectedIndexChanged(object sender, EventArgs e)
    {
 
        grdOptionalValue.Visible = false;
        pnlSummaryGrid.Visible = false;

        if (rbList1.Items[0].Selected)
        {
            rbList2.Visible = false;
  
            pnlAddOption.Visible = false;
        }

        else if (rbList1.Items[1].Selected)
        {
            rbList2.Visible = true;
            rbList2.Items[0].Text = "Printers";
            rbList2.Items[1].Text = "Scanners";
            rbList2.Items[2].Text  = "";
            rbList2.SelectedIndex = -1;
        }
        else if (rbList1.Items[2].Selected) 
        {
            rbList2.Visible = true;
            rbList2.Items[0].Text = "Warranty";
            rbList2.Items[1].Text = "Non-Warranty";
            rbList2.SelectedIndex = -1;

        }
    }
    protected void rbList2_SelectedIndexChanged(object sender, EventArgs e)
    {
        pnlSummaryGrid.Visible = false;
        if (rbList1.Items[1].Selected) //Equipment
        {
            txbRequired1.Text = "";
            txbOptional1.Text = "";

            txbRequired2.Text = "";
            txbOptional2.Text = "";

            txbRequired3.Text = "";
            txbOptional3.Text = "";

            if (rbList2.Items[0].Selected) // Printers
            {


                lblRequiredR1.Text = "Printer Type";
                lblRequiredR2.Text = "Resolution";
                lblRequiredR3.Text = "WYSIWYG Software";
                

                pnlAddOption.Visible = true;
                pnlSalesOptions.Visible = true; 
            }

            else if (rbList2.Items[1].Selected)  //Printers
            {


                lblRequiredR1.Text = "Scanner Type";
                lblRequiredR2.Text = "Fixed";
                lblRequiredR3.Text = "Focal Length";

                pnlAddOption.Visible = true;
                pnlSalesOptions.Visible = true; 

            }
        }
        else if (rbList1.Items[2].Selected) //Warranty
        {
            if (rbList2.Items[0].Selected)
            {
                lblRequiredR1.Text = "Warranty1";
                lblRequiredR2.Text = "Warranty2";
                lblRequiredR3.Text = "Warranty3";

                pnlAddOption.Visible = true;
                pnlSalesOptions.Visible = true; 

            }

            else if (rbList2.Items[1].Selected)
            {
                lblRequiredR1.Text = "Non-Warranty1";
                lblRequiredR2.Text = "Non-Warranty2";
                lblRequiredR3.Text = "Non-Warranty3";

                pnlAddOption.Visible = true;
                pnlSalesOptions.Visible = true; 

            }


        }
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {

        if (string.IsNullOrEmpty(txbRequired1.Text)) return; 

        string strType = GetRFQType(); ;


        DataTable dt = new DataTable();
    

        dt.Columns.Add(new DataColumn("Item", typeof(string)));
        dt.Columns.Add(new DataColumn("Type", typeof(string)));
        dt.Columns.Add(new DataColumn("RequireValueDesc1", typeof(string)));
        dt.Columns.Add(new DataColumn("RequireValue1", typeof(string)));
        dt.Columns.Add(new DataColumn("RequireValueDesc2", typeof(string)));
        dt.Columns.Add(new DataColumn("RequireValue2", typeof(string)));
        dt.Columns.Add(new DataColumn("RequireValueDesc3", typeof(string)));
        dt.Columns.Add(new DataColumn("RequireValue3", typeof(string)));

        DataRow dr;

        int nCount = 0;
        foreach (GridViewRow gvr in grdRequiredValues.Rows)
        {
    
                dr = dt.NewRow();


                dr["Item"] = gvr.Cells[0].Text.Replace("&nbsp;", "");
                dr["Type"] = gvr.Cells[1].Text.Replace("&nbsp;", "");
                dr["RequireValueDesc1"] = gvr.Cells[2].Text.Replace("&nbsp;", "");
                dr["RequireValue1"] = gvr.Cells[3].Text.Replace("&nbsp;", "");
                dr["RequireValueDesc2"] = gvr.Cells[4].Text.Replace("&nbsp;", "");
                dr["RequireValue2"] = gvr.Cells[5].Text.Replace("&nbsp;", "");
                dr["RequireValueDesc2"] = gvr.Cells[6].Text.Replace("&nbsp;", "");
                dr["RequireValue2"] = gvr.Cells[7].Text.Replace("&nbsp;", "");

                dt.Rows.Add(dr);
                nCount++;
        }


         dr = dt.NewRow();


        dr["Item"] = nCount.ToString()  ;
        dr["Type"] = strType;
        dr["RequireValueDesc1"] = lblRequiredR1.Text  ;
        dr["RequireValue1"] = txbRequired1.Text;
        dr["RequireValueDesc2"] = lblRequiredR2.Text;
        dr["RequireValue2"] = txbRequired2.Text;
        dr["RequireValueDesc3"] = lblRequiredR1.Text;
        dr["RequireValue3"] = txbRequired3.Text;
       
        dt.Rows.Add(dr);

        grdRequiredValues.DataSource  = dt;
        grdRequiredValues.DataBind();

        ResetForNewOption();
        ResetTextBoxes();
        pnlSummaryGrid.Visible = true;
        grdOptionalValue.Visible = true;

    }
    public string GetRFQType()
    {
        string strType=null;
        if (rbList1.Items[0].Selected) //label
        {
            strType = "Label";
        }
        else if (rbList1.Items[1].Selected) //Equipment
        {
            if (rbList2.Items[0].Selected) // Printers
            {
                strType = "Printer";
            }

            else if (rbList2.Items[1].Selected)  //scanners
            {
                strType = "Scanner";

            }
        }
        else if (rbList1.Items[2].Selected) //
        {
            if (rbList2.Items[0].Selected) // Service
            {
                strType = "Warranty";
            }

            else if (rbList2.Items[1].Selected)  //Printers
            {
                strType = "Non-Warranty";

            }
        }

        return strType;
    }
    private void ResetForNewOption()
    {

        pnlAddOption.Visible = false;
        pnlSalesOptions.Visible = false;
        pnlSummaryGrid.Visible = false;
 
        rbList1.SelectedIndex = -1;
        rbList2.SelectedIndex = -1;
        rbList2.Visible = false;
 


    }
    private void ResetTextBoxes()
    {
        txbRequired1.Text = "";
        txbRequired2.Text = "";
        txbRequired3.Text = "";

        txbOptional1.Text = "";
        txbOptional2.Text = "";
        txbOptional3.Text = "";

    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
  


 
    }
    protected void btnReset_Click(object sender, EventArgs e)
    {
        ResetForNewOption();
        ResetTextBoxes();

        grdRequiredValues.DataSource = null;
        grdRequiredValues.DataBind();

        grdOptionalValue.DataSource = null;
        grdOptionalValue.DataBind();
    }
    protected void btnUpload_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/UploadFile.aspx");  
    }
}