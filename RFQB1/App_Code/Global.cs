using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

using System.Text;
using System.Collections;

/// <summary>
/// Summary description for Global
/// </summary>
namespace CmpWebBaseMsgBox
{


    public class Global : System.Web.HttpApplication
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>


        public Global()
        {

        }

        protected void Application_Start(Object sender, EventArgs e)
        {


            //            ProfileCommon  
        }

        protected void Session_Start(Object sender, EventArgs e)
        {
        }

        protected void Application_BeginRequest(Object sender, EventArgs e)
        {

        }

        protected void Application_EndRequest(Object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(Object sender, EventArgs e)
        {

        }

        protected void Application_Error(Object sender, EventArgs e)
        {

        }

        protected void Session_End(Object sender, EventArgs e)
        {
            int nTest = 5;
        }

        protected void Application_End(Object sender, EventArgs e)
        {
            int nTest = 5;
        }


        #region Web Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        #endregion
    }

}


namespace CmpWebBaseMsgBox
{
    /// <summary>
    /// Summary description for MessageBox.
    /// </summary>
    public class MBox
    {
        private static Hashtable m_executingPages = new Hashtable();

        private MBox() { }

        public static void Show(string sMessage)
        {
            // If this is the first time a page has called this method then
            if (!m_executingPages.Contains(HttpContext.Current.Handler))
            {
                // Attempt to cast HttpHandler as a Page.
                Page executingPage = HttpContext.Current.Handler as Page;

                if (executingPage != null)
                {
                    // Create a Queue to hold one or more messages.
                    Queue messageQueue = new Queue();

                    // Add our message to the Queue
                    messageQueue.Enqueue(sMessage);

                    // Add our message queue to the hash table. Use our page reference
                    // (IHttpHandler) as the key.
                    m_executingPages.Add(HttpContext.Current.Handler, messageQueue);

                    // Wire up Unload event so that we can inject some JavaScript for the alerts.
                    executingPage.Unload += new EventHandler(ExecutingPage_Unload);
                }
            }
            else
            {
                // If were here then the method has allready been called from the executing Page.
                // We have allready created a message queue and stored a reference to it in our hastable. 
                Queue queue = (Queue)m_executingPages[HttpContext.Current.Handler];

                // Add our message to the Queue
                queue.Enqueue(sMessage);
            }
        }


        // Our page has finished rendering so lets output the JavaScript to produce the alert's
        private static void ExecutingPage_Unload(object sender, EventArgs e)
        {
            // Get our message queue from the hashtable
            Queue queue = (Queue)m_executingPages[HttpContext.Current.Handler];

            if (queue != null)
            {
                StringBuilder sb = new StringBuilder();

                // How many messages have been registered?
                int iMsgCount = queue.Count;

                // Use StringBuilder to build up our client slide JavaScript.
                sb.Append("<script language='javascript'>");

                // Loop round registered messages
                string sMsg;
                while (iMsgCount-- > 0)
                {
                    sMsg = (string)queue.Dequeue();
                    sMsg = sMsg.Replace("\n", "\\n");
                    sMsg = sMsg.Replace("\"", "'");
                    sb.Append(@"alert( """ + sMsg + @""" );");
                }

                // Close our JS
                sb.Append(@"</script>");

                // Were done, so remove our page reference from the hashtable
                m_executingPages.Remove(HttpContext.Current.Handler);

                // Write the JavaScript to the end of the response stream.
                HttpContext.Current.Response.Write(sb.ToString());
            }
        }
    }
}
