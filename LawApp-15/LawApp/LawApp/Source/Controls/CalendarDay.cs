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
    public class CalendarDayEventArgs : EventArgs { } // could do some stuff here for now this is just used so we don't need to use FindControl alot

    [DefaultProperty("Text")]
    [ToolboxData("<{0}:CalendarDay runat=server></{0}:CalendarDay>")]
    public class CalendarDay : WebControl, IPostBackEventHandler
    {
        [Bindable(true)]
        [Category("Appearance")]
        [DefaultValue("")]
        [Localizable(true)]
        public Day Date
        {
            get { return (ViewState["Date"] == null) ? null : (Day)ViewState["Date"]; }
            set { ViewState["Date"] = value; }
        }

        protected override void RenderContents(HtmlTextWriter output)
        {
            output.Write(Date != null ? Date.Date.Day.ToString() : "");
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
            if (Date != null)
            {
                writer.AddAttribute(HtmlTextWriterAttribute.Onclick, clientPostBackScript);
            }
            base.AddAttributesToRender(writer);
        }

        public void RaisePostBackEvent(string eventArgument)
        {
            OnClicked(new CalendarDayEventArgs());
        }

        protected virtual void OnClicked(EventArgs e)
        {
            if (DayClicked != null)
            {
                DayClicked(this, e);
            }
        }

        public override bool Equals(object obj)
        {
            Day day = obj as Day;
            if (day != null) return day.Date == Date.Date;

            return base.Equals(obj);
        }
    }
}
