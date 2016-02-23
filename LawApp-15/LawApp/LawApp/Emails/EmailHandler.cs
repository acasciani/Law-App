using LawAppModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace LawAppWeb.Emails
{
    public class EmailHandler
    {
        private class EmailTemplateResponse
        {
            public EmailTemplateResponse(HttpStatusCode statusCode, string status, WebHeaderCollection headers, string body)
            {
                ResponseStatusCode = statusCode;
                ResponseStatus = status;
                Body = body;
                Headers = headers;
            }

            public HttpStatusCode ResponseStatusCode { get; private set; }
            public string ResponseStatus { get; private set; }
            public string Body { get; private set; }
            public WebHeaderCollection Headers { get; private set; }
        }

         public static void SendEmail(string EmailTemplateLocation, bool IsHTML, string FromName, string FromAddress, IDictionary<string, string> Recipients, IDictionary<string, string> EmailVariables)
        {
            SendEmail(EmailTemplateLocation, IsHTML, FromName, FromAddress, Recipients, new Dictionary<string, string>(), EmailVariables);
        }

        public static void SendEmail(string EmailTemplateLocation, bool IsHTML, string FromName, string FromAddress, IDictionary<string, string> Recipients, IDictionary<string, string> BCCRecipients, IDictionary<string, string> EmailVariables)
        {
            SendEmail(EmailTemplateLocation, IsHTML, FromName, FromAddress, Recipients, BCCRecipients, new Dictionary<string, string>(), EmailVariables);
        }

        public static void SendEmail(string EmailTemplateLocation, bool IsHTML, string FromName, string FromAddress, IDictionary<string, string> Recipients, IDictionary<string, string> BCCRecipients, IDictionary<string, string> CCRecipients, IDictionary<string, string> EmailVariables)
        {
            MailMessage message = new MailMessage();

            // set sender
            message.From = new MailAddress(FromAddress, FromName);

            foreach (string key in Recipients.Keys)
            {
                if (string.IsNullOrWhiteSpace(Recipients[key]))
                {
                    message.To.Add(new MailAddress(key));
                }
                else
                {
                    message.To.Add(new MailAddress(key, Recipients[key]));
                }
            }

            foreach (string key in BCCRecipients.Keys)
            {
                if (string.IsNullOrWhiteSpace(BCCRecipients[key]))
                {
                    message.Bcc.Add(new MailAddress(key));
                }
                else
                {
                    message.Bcc.Add(new MailAddress(key, BCCRecipients[key]));
                }
            }

            foreach (string key in CCRecipients.Keys)
            {
                if (string.IsNullOrWhiteSpace(CCRecipients[key]))
                {
                    message.CC.Add(new MailAddress(key));
                }
                else
                {
                    message.CC.Add(new MailAddress(key, CCRecipients[key]));
                }
            }

            string templateLocation = GetAbsoluteURL(EmailTemplateLocation);
            EmailTemplateResponse response = GetContent(templateLocation, EmailVariables);

            switch (response.ResponseStatusCode)
            {
                case HttpStatusCode.OK:
                    string mltSubject = response.Headers["MLT-EmailSubject"] as string;
                    message.Subject = string.IsNullOrWhiteSpace(mltSubject) ? EmailHandler.GetDefaultSubject() : mltSubject;
                    message.Body = response.Body;
                    message.IsBodyHtml = IsHTML;
                    
                    if (!IsProduction)
                    {
                        message.To.Clear();
                        message.Bcc.Clear();
                        message.CC.Clear();

                        message.To.Add(GetTestEmail());
                    }

                    using (SmtpClient client = new SmtpClient())
                    {
                        client.Send(message);
                    }

                    break;

                case HttpStatusCode.Forbidden:
                    break;

                case HttpStatusCode.Unauthorized:
                    throw new HttpException(401, response.ResponseStatus);

                default:
                    throw new HttpException(response.ResponseStatus);
            }
        }

        private static EmailTemplateResponse GetContent(string url, IDictionary<string, string> postVariables)
        {
            WebRequest request = HttpWebRequest.Create(url);
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";

            string postString = "";
            bool isFirst = true;
            foreach (string key in postVariables.Keys)
            {
                postString += string.Format("{0}{1}={2}", (isFirst ? "" : "&"), HttpUtility.UrlEncode(key), HttpUtility.UrlEncode(postVariables[key]));
                isFirst = false;
            }

            request.ContentLength = postString.Length;

            using (StreamWriter dataIn = new StreamWriter(request.GetRequestStream()))
            {
                dataIn.Write(postString);
                dataIn.Close();
            }

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            using (StreamReader dataOut = new StreamReader(response.GetResponseStream()))
            {
                string result = dataOut.ReadToEnd();
                dataOut.Close();

                return new EmailTemplateResponse(response.StatusCode, response.StatusDescription, response.Headers, result);
            }
        }

        private static string GetAbsoluteURL(string relativeURL)
        {
            using (LawApp lawApp = new LawApp())
            {
                //EmailRequest request = new EmailRequest()
                //{
                //    EmailRequestToken = Guid.NewGuid()
                //};
                //lawApp.Add(request);
                //string Token = (relativeURL.Contains("?") ? "&" : "?") + "Token=" + request.EmailRequestToken;

                return string.Format("{0}://{1}{2}{3}{4}",
                    HttpContext.Current.Request.IsSecureConnection ? "https" : "http",
                    HttpContext.Current.Request.Url.Host,
                    HttpContext.Current.Request.Url.Port == 80 ? "" : ":" + HttpContext.Current.Request.Url.Port.ToString(),
                    VirtualPathUtility.ToAbsolute(relativeURL),
                    "");
            }
        }

        public static string GetDefaultSubject()
        {
            return ConfigurationManager.AppSettings.Get("EmailHandler_DefaultSubject").ToString();
        }

        public static string GetStandardSubjectSuffix()
        {
            return ConfigurationManager.AppSettings.Get("EmailHandler_StandardSubjectSuffix").ToString();
        }

        public static string GetTestEmail()
        {
            return ConfigurationManager.AppSettings.Get("EmailHandler_TestEmail").ToString();
        }

        public static bool IsProduction
        {
            get
            {
                return ConfigurationManager.AppSettings.Get("DeploymentMode").ToString() == "Production";
            }
        }
    }
}