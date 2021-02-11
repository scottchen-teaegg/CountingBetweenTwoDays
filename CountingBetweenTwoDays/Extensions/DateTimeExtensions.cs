using System;
using System.Collections.Generic;
using System.Text;

namespace CountingBetweenTwoDays
{
    public static class DateTimeExtensions
    {
        /// <summary>
        /// Process Dates
        /// </summary>
        /// <param name="firstDate"></param>
        /// <param name="secondDate"></param>
        /// <param name="processedFirstDate"></param>
        /// <param name="processedSecondDate"></param>
        /// <returns></returns>
        public static bool DatesInit(DateTime firstDate, DateTime secondDate, out DateTime processedFirstDate, out DateTime processedSecondDate)
        {
            processedFirstDate = firstDate.Date;
            processedSecondDate = secondDate.Date;

            if (processedFirstDate >= processedSecondDate)
            {
                return false;
            }
            else
            {
                return true;
            }
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
        public static DateTime NextWorkingDate(this DateTime date)
        {
            DateTime nextDay = date;
            while (!nextDay.IsWorkingDay())
            {
                nextDay = nextDay.AddDays(1);
            }

            return nextDay;
        }

        public static int GetWeekNumberOfMonth(this DateTime date)
        {
            date = date.Date;
            DateTime firstMonthDay = new DateTime(date.Year, date.Month, 1);
            DateTime firstMonthMonday = firstMonthDay.AddDays((DayOfWeek.Monday + 7 - firstMonthDay.DayOfWeek) % 7);
       
            if (firstMonthMonday < date)
            {
                int diff = (date - firstMonthMonday).Days;
                if (diff < 7 && firstMonthDay != firstMonthMonday)
                    return 2;
                else
                    return diff / 7 + 1;
            }
            else
            {
                return 1;
            }    
            
        }



    }
}
