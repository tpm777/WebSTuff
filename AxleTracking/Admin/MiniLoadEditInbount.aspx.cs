using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;

public partial class Admin_MiniLoadEditInbount : System.Web.UI.Page
{
    ProcessTracking.AxleInformation objAxle = new ProcessTracking.AxleInformation();

    protected void Page_Load(object sender, EventArgs e)
    {
        objAxle = (ProcessTracking.AxleInformation)Session["AxleInfo"];

        
        txbCustomer.Text = objAxle.InboundCustomer;
        txbLoadID.Text = objAxle.LoadID;

        if (!IsPostBack)
        {

        } 

        
    }

    protected void Page_PreRenderComplete(object sender, EventArgs e)
    {


 //      GetStationIDs();

  //      form1.DataBind();  

        
       // GridView1.DataBind();
        
    }

    protected void txbLoadID_TextChanged(object sender, EventArgs e)
    {
        string cstest = "cat"; 
    }
}
