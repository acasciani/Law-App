using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LawAppWeb.Controls
{
    public partial class Alert : System.Web.UI.UserControl
    {
        public AlertType AlertType { get; set; }

        public Guid? Id {
            get
            {
                Guid guid;
                return Guid.TryParse(ViewState["Guid"].ToString(), out guid) ? guid : (Guid?)null;
            }
            set { ViewState["Guid"] = value; }
        }

        public string GetTypeClass()
        {
            switch (AlertType)
            {
                case AlertType.Warning: return "alert-warning";
                case AlertType.Info: return "alert-info";
                case AlertType.Error: return "alert-danger";
                default: return "alert-success";
            }
        }

        public void SetStatus(string content, bool isHTML, AlertType alertType)
        {
            AlertType = alertType;
            AlertHolder.CssClass += " " + GetTypeClass();
            if (isHTML)
            {
                Content.InnerHtml = content;
            }
            else
            {
                Content.InnerText = content;
            }
        }
    }
}