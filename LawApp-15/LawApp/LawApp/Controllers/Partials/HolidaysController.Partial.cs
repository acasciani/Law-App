using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LawAppModel;
using System.Web.Http;

namespace LawAppWeb
{
    public partial class HolidaysController : OpenAccessBaseApiController<Holiday, LawApp>
    {
        public IEnumerable<Holiday> GetHolidays(int inyear)
        {
            return GetWhere(h => h.HolidayDate.Year == inyear);
        }
    }
}