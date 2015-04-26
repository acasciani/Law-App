using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LawAppWeb.Utilities;
using LawAppModel;
using System.Net.Http;

namespace LawAppWeb.Modules.TSC
{
    public class ExistingCalendar
    {
        public string CaseNumber { get; set; }
        public string CaseName { get; set; }
        public string Exhibit { get; set; }
        public long CalendarId { get; set; }
    }

    public partial class Existing : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                this.AuthorizePage(PermissionHelper.AddNew);
                Module = "TSC";
                PageName = "SavedCalendars";

                if (IsPostBack)
                {
                    return;
                }

                BindResults(reload: true);
            }
            catch (Exception ex)
            {
                ex.HandleException();
            }
        }

        private IList<ExistingCalendar> GetExisting(){
            return Session["TSC_Calendars"] as IList<ExistingCalendar>;
        }

        private void BindResults(bool reload = false)
        {
            if (GetExisting() == null || reload)
            {
                using (TSC_CalendarsController c = new TSC_CalendarsController())
                {
                    int userId = this.GetCurrentUser().WebUserId;
                    Session["TSC_Calendars"] = c.GetWhere(i => i.WebUserId == userId).Select(r => new ExistingCalendar()
                    {
                        CaseNumber = r.CaseNumber,
                        CaseName = r.CaseName,
                        Exhibit = r.Exhibit,
                        CalendarId = r.CalendarId
                    }).OrderBy(i => i.CaseName).ThenBy(i => i.CaseNumber).ThenBy(i => i.Exhibit).ToList();
                }
            }

            Results.DataSource = GetExisting();
            Results.DataBind();
        }

        protected void Clone_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton lb = (LinkButton)sender;
                long calendarId;
                if (!long.TryParse(lb.CommandArgument.ToString(), out calendarId))
                {
                    AlertBox.AddAlert("Could not obtain source calendar information while attempting to duplicate calendar.", false, AlertType.Error);
                    return;
                }

                using (TSC_CalendarsController c = new TSC_CalendarsController())
                {
                    int userId = this.GetCurrentUser().WebUserId;
                    TSC_Calendar calendar = c.GetWhere(i => i.CalendarId == calendarId && i.WebUserId == userId).FirstOrDefault();
                    if (calendar == null)
                    {
                        AlertBox.AddAlert("Could not obtain source calendar information while attempting to duplicate calendar.", false, AlertType.Error);
                        return;
                    }

                    TSC_Calendar cloned = CloneCalendar(calendar);
                    TSC_Calendar result = c.AddNew(cloned);

                    if (result != null)
                    {
                        GetExisting().Insert(0, new ExistingCalendar()
                        {
                            CalendarId = result.CalendarId,
                            CaseName = result.CaseName,
                            CaseNumber = result.CaseNumber,
                            Exhibit = result.Exhibit
                        });
                        BindResults();
                    }
                }

                AlertBox.AddAlert("Successfully duplicated selected calendar and added to the top of the list below.");
            }
            catch (Exception ex)
            {
                Guid tracking = ex.HandleException();
                AlertBox.AddAlert(
                    string.Format("An error occurred duplicating the selected calendar. Please try again. If the issue continues, please contact support with the tracking code: {0}", tracking),
                    false, AlertType.Error);
            }
        }

        private TSC_Calendar CloneCalendar(TSC_Calendar source)
        {
            TSC_Calendar cloned = new TSC_Calendar()
            {
                CaseName = source.CaseName,
                CaseNumber = source.CaseNumber,
                Exhibit = source.Exhibit,
                CreateDate = DateTime.Now,
                DisplayHolidays = source.DisplayHolidays,
                WebUserId = source.WebUserId,
                WeekendsActive = source.WeekendsActive,
                WeekendsStart = source.WeekendsStart,
                Year = source.Year,
                LastSaved = DateTime.Now
            };

            // breaks
            foreach (TSC_Break breakk in source.TSC_Breaks)
            {
                cloned.TSC_Breaks.Add(new TSC_Break()
                {
                    Break = breakk.Break,
                    ClearExisting = breakk.ClearExisting,
                    FirstNight = breakk.FirstNight,
                    LastNight = breakk.LastNight,
                    ParentBFirst = breakk.ParentBFirst,
                    ParentBFull = breakk.ParentBFull,
                    ParentBSecond = breakk.ParentBSecond,
                    ShowBreak = breakk.ShowBreak
                });
            }

            // individual overnights
            foreach (TSC_IndividualOvernight individual in source.TSC_IndividualOvernights)
            {
                cloned.TSC_IndividualOvernights.Add(new TSC_IndividualOvernight()
                {
                    DayOfWeek = individual.DayOfWeek,
                    EveryActive = individual.EveryActive,
                    EveryOtherActive = individual.EveryOtherActive,
                    StartDate = individual.StartDate
                });
            }

            // unique days
            foreach (TSC_UniqueDays unique in source.TSC_UniqueDays)
            {
                cloned.TSC_UniqueDays.Add(new TSC_UniqueDays()
                {
                    Date = unique.Date,
                    Day = unique.Day,
                    DayClass = unique.DayClass,
                    WebUserId = unique.WebUserId
                });
            }

            return cloned;
        }

        protected void Delete_Click(object sender, EventArgs e)
        {
            try { 
                LinkButton lb = (LinkButton)sender;
                long calendarId;
                if (!long.TryParse(lb.CommandArgument.ToString(), out calendarId))
                {
                    AlertBox.AddAlert("Could not obtain calendar information while attempting to delete calendar.", false, AlertType.Error);
                    return;
                }

                using (TSC_CalendarsController c = new TSC_CalendarsController())
                {
                    int userId = this.GetCurrentUser().WebUserId;
                    TSC_Calendar calendar = c.GetWhere(i => i.WebUserId == userId && i.CalendarId == calendarId).FirstOrDefault();

                    if (calendar == null)
                    {
                        AlertBox.AddAlert("Could not obtain calendar information while attempting to delete calendar.", false, AlertType.Error);
                        return;
                    }
                    c.Delete(calendar.CalendarId);

                    ExistingCalendar listItem = GetExisting().Where(i => i.CalendarId == calendarId).FirstOrDefault();
                    if (listItem != null)
                    {
                        GetExisting().Remove(listItem);
                        BindResults();
                    }
                }

                AlertBox.AddAlert("Successfully deleted selected calendar.");
            }
            catch (Exception ex)
            {
                Guid tracking = ex.HandleException();
                AlertBox.AddAlert(
                    string.Format("An error occurred deleting the selected calendar. Please try again. If the issue continues, please contact support with the tracking code: {0}", tracking),
                    false, AlertType.Error);
            }
        }
    }
}