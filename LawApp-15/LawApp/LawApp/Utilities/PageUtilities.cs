using LawAppModel;
using LawAppWeb.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace LawAppWeb
{
    public static class PageUtilities
    {
        public static SignedWebUser GetCurrentUser(this Page refr)
        {
            return Authorization.CurrentUser;
        }

        public static System.Web.SessionState.HttpSessionState Session
        {
            get
            {
                return HttpContext.Current.Session;
            }
        }
    }
}