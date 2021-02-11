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
        /// <summary>
        ///  Public holidays on a certain occurrence of a certain day in a month. e.g. Queen's Birthday on the second Monday in June every year.
        /// </summary>
        /// <param name="monthOfYear">Month</param>
        /// <param name="weekOfMonth">Week of Month</param>
        /// <param name="holidayOfWeek">Which day of week is holiday</param>
        public HolidayRule(int monthOfYear, int weekOfMonth, DayOfWeek holidayOfWeek)
        {
            this.HolidayOfWeek = holidayOfWeek;
            this.WeekOfMonth = weekOfMonth;
            this.MonthOfYear = monthOfYear;
            this.holidayChecker = new FixDayOfWeekMonth();
        }
        /// <summary>
        /// Public holidays which are always on the same day, e.g. Anzac Day on April 25th every year
        /// </summary>
        /// <param name="dayOfMonth">Fix Date</param>
        /// <param name="monthOfYear">Fix Month</param>
        /// <param name="isNextMonday">If true, the actual holiday will fall on the following Monday when that hoilday falls on a weekend.</param>
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



