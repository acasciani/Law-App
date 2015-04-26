using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LawAppWeb.Controls
{
    public partial class AlertBox : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// plain text, success alert
        /// </summary>
        public void AddAlert(string content)
        {
            AddAlert(content, false, AlertType.Success);
        }

        public void AddAlert(string content, bool isHTML, AlertType alertType)
        {
            Alert alert = (Alert)LoadControl("~/Source/Controls/Alert.ascx");
            alert.AlertType = alertType;
            alert.Id = new Guid();

            alert.SetStatus(content, isHTML, alertType);
            AlertContainer.Controls.Add(alert);
        }
    }
}