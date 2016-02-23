using LawAppModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LawAppWeb.Emails
{
    /// <summary>
    /// All emails should use this Masterpage or their Masterpage should use this Masterpage. This Masterpage does authorization checking like ensuring that http requests are 
    /// made by the localhost only. Additional check can be done by ensuring that requests are made over a secure layer.
    /// </summary>
    public partial class Email : System.Web.UI.MasterPage
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            // Check to see if the request is originating locally, and if not, check for a valid SessionID
            if (!Request.IsLocal)
            {/*
                // Check for a Token passed in the query string
                if (!String.IsNullOrWhiteSpace(Request.QueryString["Token"]))
                {
                    // Check for a parseable Token
                    Guid Token;
                    if (Guid.TryParse(Request.QueryString["Token"], out Token))
                    {
                        using (LawApp lawApp = new LawApp())
                        {
                            // Get the session
                            int count = lawApp.EmailRequests.Count(i => i.EmailRequestToken == Token);
                            if (count > 0)   // We got one
                            {
                                // Dispose of the session
                                var emailRequests = lawApp.EmailRequests.Where(i => i.EmailRequestToken == Token).ToList();
                                emailRequests.ForEach(i => lawApp.Delete(i));
                            }
                            // We didn't got one
                            else
                            {
                                Send403();
                            }
                        }
                    }
                    // No parseable SessionID
                    else
                    {
                        Send403();
                    }
                }
                // We didn't get a SessionID
                else
                {
                    Send403();
                }
                Send403();*/
            }

            if (!Request.IsSecureConnection)
            {
                //Send401();
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            Response.AddHeader("MLT-EmailSubject", string.Format("{0} - {1}", Page.Title, EmailHandler.GetStandardSubjectSuffix())); // The subject is accessible via the header.
        }

        private void Send403()
        {
            Response.ClearHeaders();
            Response.ClearContent();
            Response.Status = "403 Forbidden";
            Response.StatusCode = 403;
            Response.StatusDescription = "Unauthorized use.";
            Response.Flush();
            throw new HttpException(403, "Unauthorized use of resource");
        }

        private void Send401()
        {
            Response.ClearHeaders();
            Response.ClearContent();
            Response.Status = "400 Bad Request";
            Response.StatusCode = 400;
            Response.StatusDescription = "The request was not made over a secure connection.";
            Response.Flush();
            throw new HttpException(400, "Bad request using no secure connection");
        }
    }
}