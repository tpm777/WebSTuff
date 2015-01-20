using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Security;
using System.Security.Principal;
using System.DirectoryServices;
using System.DirectoryServices.ActiveDirectory;
using System.DirectoryServices.AccountManagement;  
using RFQDBFunctions;


//using Progress.Open4GL.DynamicAPI;
//using Progress.Open4GL.Proxy;
//using Progress.Open4GL;



/// <summary>
/// Summary description for RFQSecurityFunctions
/// </summary>
/// 
namespace RFQSecurity
{
    public class RFQSecurityFunctions
    {
        private Page m_objPage = null;
        private string m_strUserID;
        private string m_strADGroup;
        private string m_strADGroupName;
        string m_strSecurityTest = ConfigurationManager.AppSettings["SecurityTest"];
        public RFQSecurityFunctions(Page objPage) 
        {
            m_objPage = objPage;
            //
            // TODO: Add constructor logic here
            //
        }
        public RFQSecurityFunctions(string strUserID)
        {
            m_strUserID = strUserID;
        }

        public bool AllowUserAccess(string strSecurityGroup)
        {
            return IsUserMemberOf(strSecurityGroup);
        }

        public string GetUserID()
        {
            // Routine requires Integrated Windows Security enabled
            // for the web site.

            string strUserName;
            strUserName = m_objPage.User.Identity.Name.ToUpper();

            // Get User Information BEGIN
            strUserName = strUserName.Replace("COMPUTYPE\\", "");

            return strUserName;
        }

        //public Boolean UserSecurity(string strUserID, string strSecProfile)  // for Epicor
        //{
        //    WSProgressASP objProgress = new WSProgressASP();
        //    ParamArray paramSysTaskProc = new ParamArray(3);


        //    paramSysTaskProc.AddCharacter(0, strUserID, ParamArrayMode.INPUT);
        //    paramSysTaskProc.AddCharacter(1, strSecProfile, ParamArrayMode.INPUT);

        //    paramSysTaskProc.AddCharacter(2, null, ParamArrayMode.OUTPUT);

        //    objProgress.CallProgressProcedure("RFQUserAccess.p", paramSysTaskProc, "string");




        //    string strResult = objProgress.ReturnMessage;

        //    strResult = strResult.ToUpper();
        //    if (strResult == "NOACCESS")
        //    {
        //        return false;
        //    }
        //    return true;

        //}
        public List<GroupPrincipal> GetGroupSets(string userName)
        {
            List<GroupPrincipal> result = new List<GroupPrincipal>();

            // establish domain context
            PrincipalContext yourDomain = new PrincipalContext(ContextType.Domain);

            // find your user
            UserPrincipal user = UserPrincipal.FindByIdentity(yourDomain, userName);

            // if found - grab its groups
            if (user != null)
            {
                PrincipalSearchResult<Principal> groups = user.GetAuthorizationGroups();

                // iterate over all groups
                foreach (Principal p in groups)
                {
                    // make sure to add only group principals
                    if (p is GroupPrincipal)
                    {
                        result.Add((GroupPrincipal)p);
                    }
                }
            }

            return result;
        }

     

        public List<string> GetGroups(string userName)
        {
            List<string> result = new List<string>();
            WindowsIdentity wi = new WindowsIdentity(userName);

            foreach (IdentityReference group in wi.Groups)
            {
                try
                {
                    result.Add(group.Translate(typeof(NTAccount)).ToString());
                }
                catch (Exception ex) { }
            }
            result.Sort();
            return result;
        }
        public bool IsUserMemberOf(string strGroupName)
        {
            return true;
            string strUserName = null;

            if (string.IsNullOrEmpty(m_strUserID))
                strUserName = GetUserID();
            else
                strUserName = m_strUserID;
 
            GroupPrincipal gp = null;
            UserPrincipal up = null;
 
            PrincipalContext pc = new PrincipalContext((Environment.UserDomainName == Environment.MachineName ? ContextType.Machine : ContextType.Domain), "COMPUTYPE" /*Environment.UserDomainName*/);

            //GroupPrincipal gp = GroupPrincipal.FindByIdentity(pc, "{GroupName}");  //prototype;
            //UserPrincipal up = UserPrincipal.FindByIdentity(pc, Environment.UserName);  prototype;
            
            if (strGroupName.Contains(","))
            {
                string[] strGroups = strGroupName.Split(',');
                foreach (string strGroup in strGroups)
                {
                

                    gp = GroupPrincipal.FindByIdentity(pc, strGroup);
                    if (gp != null)
                    {
                        
                        up = UserPrincipal.FindByIdentity(pc, strUserName);
                        if (up.IsMemberOf(gp))
                        {

                            m_strADGroup = strGroup;
                            return true;
                        }
                    }

                }
                return false;
            }


            gp = GroupPrincipal.FindByIdentity(pc, strGroupName);

            if (gp == null) return false;

            up = UserPrincipal.FindByIdentity(pc, strUserName);
            m_strADGroup = strGroupName;
            return up.IsMemberOf(gp);


        }
        public bool IsUserMemberOf(string[] strGroupNames)
        {
            return true;
            string strUserName = GetUserID();

            PrincipalContext pc = new PrincipalContext((Environment.UserDomainName == Environment.MachineName ? ContextType.Machine : ContextType.Domain), Environment.UserDomainName);

            //GroupPrincipal gp = GroupPrincipal.FindByIdentity(pc, "{GroupName}");  //prototype;

            //UserPrincipal up = UserPrincipal.FindByIdentity(pc, Environment.UserName);  prototype;

            foreach (string strGroupName in strGroupNames)
            {
                GroupPrincipal gp = GroupPrincipal.FindByIdentity(pc, strGroupName);
                if (gp != null)
                {
                    m_strADGroup = strGroupName;
                    UserPrincipal up = UserPrincipal.FindByIdentity(pc, strUserName);
                    if (up.IsMemberOf(gp))
                        return true;
                }
                
            }

            return false;


        }
        public string ADGroupName
        {
              get { return m_strADGroup ; }
              set { m_strADGroup = value; }
        }

        public string ADGroupType()
        {
            string strGroupType = null;

            string strAccessList = ConfigurationManager.AppSettings["RFQSalesADGroupName"].ToString();

            if (AllowUserAccess(strAccessList))
            {
              
                strGroupType = "Sales";

            }

            strAccessList = ConfigurationManager.AppSettings["RFQEngineeringADGroupName"].ToString();

            if (AllowUserAccess(strAccessList))
            {
 
              
                strGroupType = "Engineering";

            }
            return strGroupType;
        }

    }
}