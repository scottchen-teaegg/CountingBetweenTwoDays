using CountingBetweenTwoDays.Checker;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace CountingBetweenTwoDays
{
    public class HolidayRule
    {
        public int MonthOfYear { get; set; }
        public int WeekOfMonth { get; set; }
        public DayOfWeek HolidayOfWeek { get; set; }
        public int DateOfMonth { get; set; }
        public bool IsNextMonday { get; set; }

        private readonly IHolidayChecker holidayChecker;

        public HolidayRule(DayOfWeek holidayOfWeek, int weekOfMonth, int monthOfYear)
        {
            this.HolidayOfWeek = holidayOfWeek;
            this.WeekOfMonth = weekOfMonth;
            this.MonthOfYear = monthOfYear;
            this.holidayChecker = new FixDayOfWeekMonth();
        }

        public HolidayRule(int dayOfMonth, int monthOfYear, bool isNextMonday = false)
        {
            this.DateOfMonth = dayOfMonth;
            this.MonthOfYear = monthOfYear;
            this.IsNextMonday = isNextMonday;
            this.holidayChecker = new SameDateChecker();
        }

        public bool IsMatched(DateTime dateTime)
        {
            return holidayChecker.IsHoliday(dateTime, this);
        }

    }

    interface IHolidayChecker
    {
        bool IsHoliday(DateTime dateTime, HolidayRule holidayRule);
    }
}



