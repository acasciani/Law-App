using LawAppModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Security;

namespace LawAppWeb.Utilities
{
    public static class Authorization
    {
        public static SignedWebUser CurrentUser
        {
            get
            {
                if (HttpContext.Current.User.Identity.IsAuthenticated == false) { return null; }

                SignedWebUser user = HttpContext.Current.Session["CurrentWebUser"] as SignedWebUser;
                if (user == null || user.Email != HttpContext.Current.User.Identity.Name)
                {
                    // reload user object
                    using (SignedWebUsersController c = new SignedWebUsersController())
                    {
                        IEnumerable<SignedWebUser> users = c.GetWhere(i => i.Email == HttpContext.Current.User.Identity.Name);
                        if (users.Count() != 1) { return null; }
                        user = users.First();
                        HttpContext.Current.Session["CurrentWebUser"] = user;
                    }
                }

                return user;
            }
        }

        public static bool IsCurrentUserAuthorized(this System.Web.UI.Page refr, string permission)
        {
            IIdentity identity = HttpContext.Current.User.Identity;

            using (SignedWebUsersController c = new SignedWebUsersController())
            {
                SignedWebUser user = c.GetWhere(u => u.Email == identity.Name).FirstOrDefault();
                if (user == null) return false;

                return c.IsAuthorized(user, permission, identity.IsAuthenticated);
            }
        }

        public static void AuthorizePage(this System.Web.UI.Page refr, string permission)
        {
            if (!refr.IsCurrentUserAuthorized(permission))
            {
                HttpContext.Current.Response.Redirect("~/Account/Login.aspx", true);
            }
        }
    }
}