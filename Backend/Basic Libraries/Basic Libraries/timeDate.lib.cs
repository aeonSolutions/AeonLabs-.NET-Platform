using System;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace AeonLabs.BasicLibraries
{
    public static class timeDateLibrary
    {
        public static bool IsWeekday(DateTime theDate)
        {
            bool IsWeekdayRet = default;
            IsWeekdayRet = DateAndTime.Weekday(theDate, Constants.vbMonday) <= 5;
            return IsWeekdayRet;
        }

        public static string isValidTime(string atimestring)
        {
            try
            {
                var dt = DateTime.ParseExact(atimestring, "HH:mm", null);
                return Conversions.ToString(true);
            }
            catch
            {
                return Conversions.ToString(false);
            }
        }
    }
}