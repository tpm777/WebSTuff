using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.DirectoryServices;
using System.DirectoryServices.AccountManagement;

using RFQSecurity;
using RFQDBFunctions;



public class GetADUsers
{

    public List<ADUsers> ListAllADUsers()
    {
        List<ADUsers> users = new List<ADUsers>();


        using (var ctx = new PrincipalContext(ContextType.Domain, "Computype"))
        {
            using (var PSearcher = new PrincipalSearcher(new UserPrincipal(ctx)))
            {
                foreach (var account in PSearcher.FindAll())
                {

                    string Name = Convert.ToString(account.DisplayName);
                    string SAMAccountName = Convert.ToString(account.SamAccountName);
                    string EmailAddress = Convert.ToString(account.UserPrincipalName);
                 
                    
               

                    users.Add(new ADUsers() { Name = Name, SAMAccountName = SAMAccountName, Email = EmailAddress });
                }
            }
        }
        return users;
    }
}
public class ADUsers
{

    public string Name { get; set; }
    public string SAMAccountName { get; set; }
    public string Email { get; set; }

}


  


public partial class ListOfRFQADUsers : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        GetADUsers objUsers = new GetADUsers();
        List <ADUsers> users =  objUsers.ListAllADUsers(); 
        string[]  strUsers = new string[100] ;
        int nCount=0;

        
        foreach (ADUsers AdUser in users)
        {

            if (getAuthorizationGrps(AdUser.Name, "RFQ NA Sales"))
            {

                strUsers[nCount++] = AdUser.Name;
                lstRFQSales.Items.Add(AdUser.Name); 
            }

            if (getAuthorizationGrps(AdUser.Name, "RFQ US Quote Team"))
            {

                strUsers[nCount++] = AdUser.Name;
                
                lstRFQQuoteTeam.Items.Add(AdUser.Name);
            }
            if (getAuthorizationGrps(AdUser.Name, "RFQ EU Sales"))
            {

                strUsers[nCount++] = AdUser.Name;
                lstRFQEUSales.Items.Add(AdUser.Name);
            }

            if (getAuthorizationGrps(AdUser.Name, "RFQ EU Quote Team"))
            {

                strUsers[nCount++] = AdUser.Name;

                lstRFQEUQuoteTeam.Items.Add(AdUser.Name);
            }

        }
    }

    public bool getAuthorizationGrps(string strUserName, string strGroupName)          
    {
        PrincipalContext pc = new PrincipalContext((Environment.UserDomainName == Environment.MachineName ? ContextType.Machine : ContextType.Domain), "COMPUTYPE" /*Environment.UserDomainName*/);

//        PrincipalContext pc = new PrincipalContext((Environment.UserDomainName == Environment.MachineName ? ContextType.Machine : ContextType.Domain), Environment.UserDomainName);
        try          
        {




            GroupPrincipal gp = GroupPrincipal.FindByIdentity(pc, strGroupName);
            if (gp != null)
            {
                UserPrincipal up = UserPrincipal.FindByIdentity(pc, strUserName);
                if (up.IsMemberOf(gp))
                    return true;
                    
            }


  
            return false;          
        }          
        catch (Exception ex)          
        {          
           
        }          


        return false;
    }

}