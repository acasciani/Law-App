using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LawAppWeb.Modules.TSC
{
    public partial class TSC : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!Page.ClientScript.IsClientScriptIncludeRegistered(this.GetType(), "TSC_Main"))
                {
                    Page.ClientScript.RegisterClientScriptInclude(this.GetType(), "TSC_Drawer", "../../Scripts/slider.js");
                }
            }
        }
    }
}