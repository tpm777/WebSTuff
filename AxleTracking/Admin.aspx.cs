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
using System.Security.Principal;
using System.Threading;

public partial class Admin : System.Web.UI.Page
{
    ProcessTracking.AxleInformation objAxle = new ProcessTracking.AxleInformation();

    protected void Page_Load(object sender, EventArgs e)
    {
        objAxle = (ProcessTracking.AxleInformation)Session["AxleInfo"];

        // no access with user id
        if (objAxle.OperatorID == null) Response.Redirect("Login.aspx");
        if (objAxle.OperatorID == "") Response.Redirect("Login.aspx"); 

    }
}
