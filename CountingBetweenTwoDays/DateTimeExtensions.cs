using System;
using System.Collections.Generic;
using System.Text;

namespace CountingBetweenTwoDays
{
    public static class DateTimeExtensions
    {
        /// <summary>
        /// Determines if a given date is between a certain range.
        /// </summary>
        /// <param name="date"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        public static bool Between(this DateTime date, DateTime startDate, DateTime endDate)
        {
            return date.Ticks >= startDate.Ticks && date.Ticks <= endDate.Ticks;
        }

        /// <summary>
        /// Returns if the current date is a working day.
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static bool IsWorkingDay(this DateTime date)
        {
            return date.DayOfWeek != DayOfWeek.Saturday && date.DayOfWeek != DayOfWeek.Sunday;
        }


        /// <summary>
        /// Returns true if the current date is a weekend.
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static bool IsWeekend(this DateTime date)
        {
            return date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday;
        }

        /// <summary>
        /// Returns the next working day from the given date.
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static DateTime NextWorkday(this DateTime date)
        {
            DateTime nextDay = date;
            while (!nextDay.IsWorkingDay())
            {
                nextDay = nextDay.AddDays(1);
            }

            return nextDay;
        }

        public static DateTime 
    }
}
