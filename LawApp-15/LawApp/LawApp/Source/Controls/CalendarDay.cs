using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LawAppWeb.Controls
{
    [DefaultProperty("Text")]
    [ToolboxData("<{0}:CalendarDay runat=server></{0}:CalendarDay>")]
    public class CalendarDay : WebControl, IPostBackEventHandler
    {
        [Bindable(true)]
        [Category("Appearance")]
        [DefaultValue("")]
        [Localizable(true)]
        public DateTime? Date
        {
            get { return (ViewState["Date"] == null) ? (DateTime?)null : (DateTime?)ViewState["Date"]; }
            set { ViewState["Date"] = value; }
        }

        [Bindable(true)]
        [Category("Appearance")]
        [DefaultValue("")]
        [Localizable(true)]
        public bool IsChecked
        {
            get { return (ViewState["IsChecked"] == null) ? false : (bool)ViewState["IsChecked"]; }
            set { ViewState["IsChecked"] = value; }
        }

        protected override void RenderContents(HtmlTextWriter output)
        {
            output.Write(Date.HasValue ? Date.Value.Day.ToString() : "");
            output.BeginRender();

            output.EndRender();
        }

        public event EventHandler DayClicked;
        private string clientPostBackScript;

        protected override void OnPreRender(EventArgs e)
        {
            clientPostBackScript = Page.ClientScript.GetPostBackEventReference(this, String.Empty);
            base.OnPreRender(e);
        }

        protected override HtmlTextWriterTag TagKey
        {
            get
            {
                return HtmlTextWriterTag.Td;
            }
        }

        protected override void AddAttributesToRender(HtmlTextWriter writer)
        {
            if (Date.HasValue)
            {
                writer.AddAttribute(HtmlTextWriterAttribute.Onclick, clientPostBackScript);
            }
            base.AddAttributesToRender(writer);
        }

        public void RaisePostBackEvent(string eventArgument)
        {
            OnClicked(EventArgs.Empty);
        }

        protected virtual void OnClicked(EventArgs e)
        {
            if (DayClicked != null)
            {
                DayClicked(this, e);
            }
        }
    }
}
