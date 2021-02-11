using System;
using System.Collections.Generic;
using System.Text;

namespace CountingBetweenTwoDays.Checker
{
    public class FixDayOfWeekMonth : IHolidayChecker
    {
        public bool IsHoliday(DateTime dateTime, HolidayRule rule)
        {
            return dateTime.DayOfWeek == rule.HolidayOfWeek && dateTime.Month == rule.MonthOfYear && dateTime.GetWeekNumberOfMonth() == rule.WeekOfMonth;
        }
    }
}
