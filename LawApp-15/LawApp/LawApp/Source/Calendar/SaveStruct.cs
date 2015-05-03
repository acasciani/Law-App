using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LawAppWeb
{
    public class CaseInformation
    {
        public string Exhibit { get; set; }
        public string CaseName { get; set; }
        public string CaseNumber { get; set; }
        public string ParentBLabel { get; set; }
    }

    public class WeekendOvernights
    {
        public bool IsSelected { get; set; }
        public DateTime? StartDate { get; set; }
    }

    public class IndividualOvernights
    {
        public IndividualOvernight Monday { get; set; }
        public IndividualOvernight Tuesday { get; set; }
        public IndividualOvernight Wednesday { get; set; }
        public IndividualOvernight Thursday { get; set; }
        public IndividualOvernight Friday { get; set; }
        public IndividualOvernight Saturday { get; set; }
        public IndividualOvernight Sunday { get; set; }
    }

    public class IndividualOvernight {
        public DateTime? Start { get; set; }
        public bool EveryActive { get; set; }
        public bool EveryOtherActive { get; set; }
    }

    public class Holidays
    {
        public bool IsSelected { get; set; }
    }

    public class Breaks
    {
        public Break Spring { get; set; }
        public Break Summer { get; set; }
        public Break Winter { get; set; }
    }

    public class Break
    {
        public DateTime? Start { get; set; }
        public DateTime? End { get; set; }
        public bool ShowActive { get; set; }
        public bool ParentBFirstActive { get; set; }
        public bool ParentBSecondActive { get; set; }
        public bool ParentBFullActive { get; set; }
        public bool ClearExistingActive { get; set; }
    }

    public class UniqueDay
    {
        public string DayClass { get; set; }
        public short Day { get; set; }
    }

    public class SaveObject
    {
        public CaseInformation CaseInformation { get; set; }
        public WeekendOvernights WeekendOvernights { get; set; }
        public IndividualOvernights IndividualOvernights { get; set; }
        public Holidays Holidays { get; set; }
        public Breaks Breaks { get; set; }
        public IList<UniqueDay> UniqueDays { get; set; }
    }
}