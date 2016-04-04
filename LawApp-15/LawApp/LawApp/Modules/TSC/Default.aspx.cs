using LawAppWeb.Controls;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.UI;
using LawAppWeb.Utilities;
using LawAppModel;
using System.Net;
using System.Web;

namespace LawAppWeb.Modules.TSC
{
    public partial class Default : Page
    {

        private List<Calendar> calendars = new List<Calendar>();
        public int CalendarYear { get; private set; }

        protected void Page_Init(object sender, EventArgs e)
        {
            this.AuthorizePage(PermissionHelper.AddNew);
            Module = "TSC";
            PageName = "NewCalendar";

            if (IsPostBack)
            {
                return;
            }

            int calendarID;
            if (int.TryParse(Request.QueryString["cid"], out calendarID))
            {
                // existing, make sure this user is scoped otherwise bounce to create new calendar
                using (TSC_CalendarsController tcc = new TSC_CalendarsController())
                {
                    int userId = this.GetCurrentUser().WebUserId;
                    var calendars = tcc.GetWhere(i => i.CalendarId == calendarID && i.WebUserId == userId);
                    if (calendars.Count() == 0)
                    {
                        Response.Redirect("Default.aspx", true);
                        return;
                    }
                    else
                    {
                        CalendarYear = (int)calendars.First().Year;
                    }
                }
            }
            else
            {
                CalendarYear = DateTime.Today.Year;
            }

            for (int i = 1; i <= 12; i++)
            {
                Calendar control = (Calendar)LoadControl("~/Source/Controls/Calendar.ascx");
                control.MonthReference = new DateTime(CalendarYear, i, 1);
                calendars.Add(control);
                CalendarsHolder.Controls.Add(control);
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!Page.ClientScript.IsClientScriptIncludeRegistered(this.GetType(), "TSC_Main"))
                {
                    Page.ClientScript.RegisterClientScriptInclude(this.GetType(), "TSC_Main", "../../Scripts/Modules/TSC/Main.js");
                }

                if (!Page.ClientScript.IsClientScriptIncludeRegistered(this.GetType(), "TSC_SaveCalendar"))
                {
                    Page.ClientScript.RegisterClientScriptInclude(this.GetType(), "TSC_SaveCalendar", "../../Scripts/Modules/TSC/SaveCalendar.js");
                }
            }
        }

        private TSC_Calendar GetCalendar()
        {
            string cidRaw = Request.QueryString["cid"];
            int calendarId;

            TSC_Calendar calendar = null;
            if (!string.IsNullOrWhiteSpace(cidRaw) && int.TryParse(cidRaw, out calendarId))
            {
                using (TSC_CalendarsController c = new TSC_CalendarsController())
                {
                    calendar = c.GetWhere(i => i.CalendarId == calendarId && i.WebUserId == this.GetCurrentUser().WebUserId).FirstOrDefault();
                }
            }

            if(calendar == null){
                calendar = new TSC_Calendar()
                {
                    Year = Convert.ToInt16(DateTime.Today.Year),
                    CreateDate = DateTime.Now,
                    WebUserId = this.GetCurrentUser().WebUserId
                };
            }

            return calendar;
        }

        protected void saveBtn_Click(object sender, EventArgs e)
        {
            this.AuthorizePage(PermissionHelper.Save);

            TSC_Calendar calendar = GetCalendar();

            // save the calendar
            HttpCookie cookie = Request.Cookies["StagedCalendar"];
            SaveObject input = (SaveObject)Newtonsoft.Json.JsonConvert.DeserializeObject(HttpUtility.UrlDecode(cookie.Value), typeof(SaveObject));

            // do special hack for unique days using hidden input field
            string uniqueDays = hdnUniqueDays.Value.Trim();
            if (!string.IsNullOrWhiteSpace(uniqueDays))
            {
                if(input.UniqueDays == null){
                    input.UniqueDays = new List<UniqueDay>();
                }

                // it's a csv then a pipe for doy/class
                string[] days = uniqueDays.Split(',');
                foreach (string day in days)
                {
                    string[] components = day.Trim().Split('|');
                    input.UniqueDays.Add(new UniqueDay()
                    {
                        Day = short.Parse(components[0].Trim()),
                        DayClass = components[1].Trim()
                    });
                }
            }

            // Save Case information
            calendar.CaseName = input.CaseInformation == null ? null : input.CaseInformation.CaseName;
            calendar.CaseNumber = input.CaseInformation == null ? null : input.CaseInformation.CaseNumber;
            calendar.Exhibit = input.CaseInformation == null ? null : input.CaseInformation.Exhibit;
            calendar.ParentBLabel = input.CaseInformation == null ? null : (string.IsNullOrWhiteSpace(input.CaseInformation.ParentBLabel) ? "" : input.CaseInformation.ParentBLabel.Trim());

            // Save weekend overnight
            calendar.WeekendsActive = input.WeekendOvernights == null ? false : input.WeekendOvernights.IsSelected;
            calendar.WeekendsStart = input.WeekendOvernights == null ? (DateTime?)null : input.WeekendOvernights.StartDate;

            // Save holidays
            calendar.DisplayHolidays = input.Holidays == null ? false : input.Holidays.IsSelected;
            
            // Save breaks
            if(input.Breaks != null){
                MapBreak(HolidayBreak.Spring, input.Breaks.Spring, calendar.TSC_Breaks, calendar);
                MapBreak(HolidayBreak.Summer, input.Breaks.Summer, calendar.TSC_Breaks, calendar);
                MapBreak(HolidayBreak.Winter, input.Breaks.Winter, calendar.TSC_Breaks, calendar);
            }
            
            // Save individual overnights
            if (input.IndividualOvernights != null)
            {
                MapIndividual(LawAppModel.DayOfWeek.Monday, input.IndividualOvernights.Monday, calendar.TSC_IndividualOvernights, calendar);
                MapIndividual(LawAppModel.DayOfWeek.Tuesday, input.IndividualOvernights.Tuesday, calendar.TSC_IndividualOvernights, calendar);
                MapIndividual(LawAppModel.DayOfWeek.Wednesday, input.IndividualOvernights.Wednesday, calendar.TSC_IndividualOvernights, calendar);
                MapIndividual(LawAppModel.DayOfWeek.Thursday, input.IndividualOvernights.Thursday, calendar.TSC_IndividualOvernights, calendar);
                MapIndividual(LawAppModel.DayOfWeek.Friday, input.IndividualOvernights.Friday, calendar.TSC_IndividualOvernights, calendar);
                MapIndividual(LawAppModel.DayOfWeek.Saturday, input.IndividualOvernights.Saturday, calendar.TSC_IndividualOvernights, calendar);
                MapIndividual(LawAppModel.DayOfWeek.Sunday, input.IndividualOvernights.Sunday, calendar.TSC_IndividualOvernights, calendar);
            }

            // Save unique days
            if (input.UniqueDays != null)
            {
                foreach (UniqueDay day in input.UniqueDays)
                {
                    MapUnique(day.Day, day, calendar.TSC_UniqueDays, calendar);
                }

                // Remove old ones not in new set
                IEnumerable<short> newOnes = input.UniqueDays.Select(i=>i.Day);
                using (TSC_UniqueDaysController udc = new TSC_UniqueDaysController())
                {
                    udc.DeleteAll(t => !newOnes.Contains(t.Day) && t.CalendarId == calendar.CalendarId);
                }
            }

            // Save to data source
            calendar.LastSaved = DateTime.Now;
            TSC_Calendar added;
            using (TSC_CalendarsController c = new TSC_CalendarsController())
            {
                if (calendar.CalendarId == 0)
                {
                    added = c.AddNew(calendar);
                }
                else
                {
                    added = c.Update(calendar);
                }
            }

            Response.Redirect("Default.aspx?cid=" + added.CalendarId);
        }

        private void MapUnique(short doy, UniqueDay input, IList<TSC_UniqueDays> existingCollection, TSC_Calendar calendar)
        {
            TSC_UniqueDays individual = existingCollection.Where(i => i.Day == doy).FirstOrDefault();
            if (individual == null)
            {
                TSC_UniqueDays result = Map(input, new TSC_UniqueDays() { Day = doy, TSC_Calendar = calendar });
                if (result != null) { existingCollection.Add(result); } // create new and add
            }
            else
            {
                Map(input, individual);
            }
        }

        private void MapIndividual(LawAppModel.DayOfWeek dayOfWeek, IndividualOvernight input, IList<TSC_IndividualOvernight> existingCollection, TSC_Calendar calendar)
        {
            TSC_IndividualOvernight individual = existingCollection.Where(i => i.DayOfWeek == dayOfWeek).FirstOrDefault();
            if (individual == null)
            {
                if (input == null) { return; } // Input is null, nothing to remove and we do not want to add
                TSC_IndividualOvernight result = Map(input, new TSC_IndividualOvernight() { DayOfWeek = dayOfWeek, TSC_Calendar = calendar });
                if (result != null) { existingCollection.Add(result); } // create new and add
            }
            else
            {
                if (input == null)
                {
                    // remove only
                    existingCollection.Remove(individual);
                    return;
                }

                Map(input, individual);
                return;
            }
        }

        private void MapBreak(HolidayBreak holidayBreak, Break input, IList<TSC_Break> existingCollection, TSC_Calendar calendar)
        {
            TSC_Break breakk = existingCollection.Where(i => i.Break == holidayBreak).FirstOrDefault();
            if (breakk == null)
            {
                if (input == null) { return; } // Input is null, nothing to remove and we do not want to add
                TSC_Break result = Map(input, new TSC_Break() { Break = holidayBreak, TSC_Calendar = calendar });
                if (result != null) { existingCollection.Add(result); } // create new and add
            }
            else
            {
                if (input == null)
                {
                    // remove only
                    existingCollection.Remove(breakk);
                    return;
                }

                Map(input, breakk);
                return;
            }
        }

        private TSC_Break Map(Break input, TSC_Break existing)
        {
            if (input == null) { return null; }
            existing.ClearExisting = input.ClearExistingActive;
            existing.FirstNight = input.Start;
            existing.LastNight = input.End;
            existing.ParentBFirst = input.ParentBFirstActive;
            existing.ParentBFull = input.ParentBFullActive;
            existing.ParentBSecond = input.ParentBSecondActive;
            existing.ShowBreak = input.ShowActive;
            return existing;
        }

        private TSC_IndividualOvernight Map(IndividualOvernight input, TSC_IndividualOvernight existing)
        {
            if (input == null) { return null; }
            existing.EveryActive = input.EveryActive;
            existing.EveryOtherActive = input.EveryOtherActive;
            existing.StartDate = input.Start;
            return existing;
        }

        private TSC_UniqueDays Map(UniqueDay input, TSC_UniqueDays existing)
        {
            if (input == null) { return null; }
            existing.DayClass = input.DayClass;
            existing.WebUserId = this.GetCurrentUser().WebUserId;
            return existing;
        }
    }
}