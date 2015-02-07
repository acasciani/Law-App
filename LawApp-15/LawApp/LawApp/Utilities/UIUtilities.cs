using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace LawAppWeb.Utilities
{
    public static class UIUtilities
    {
        public static string AddClass(this string currentClass, string addClass)
        {
            return string.Format("{0} {1}", currentClass.Trim(), addClass).TrimStart().TrimEnd();
        }

        public static string RemoveClass(this string currentClass, string removeClass)
        {
            // selected td-selected selected tr-selected
            // class Pattern will return all instances of selected and remove surround spaces (so replace with a whitespace then trim)
            string classPattern = string.Format(@"(\A|\s)({0})+(\z|\W)", removeClass);
            Regex regex = new Regex(classPattern);

            return regex.Replace(currentClass, " ").TrimStart().TrimEnd();
        }
    }
}