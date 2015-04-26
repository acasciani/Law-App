using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LawAppWeb
{
    public class Page : System.Web.UI.Page
    {
        public string Module { get; protected set; }
        public string PageName { get; protected set; }
    }
}