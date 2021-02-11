using System;
using System.Collections.Generic;
using System.Text;

namespace CountingBetweenTwoDays.Checker
{
    public class SameDateChecker : IHolidayChecker
    {
        public bool IsHoliday(DateTime dateTime, HolidayRule rule)
        {
            bool isHoliday = false;

            DateTime holiday = new DateTime(dateTime.Year, rule.MonthOfYear, rule.DateOfMonth);
            if (rule.IsNextMonday && holiday.IsWeekend())
            {
                holiday = holiday.NextWorkingDate();
            }
            if (dateTime == holiday)
            {
                isHoliday = true;
            }
            return isHoliday;
        }
    }
}
