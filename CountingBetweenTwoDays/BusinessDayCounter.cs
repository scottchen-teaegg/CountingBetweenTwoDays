using System;
using System.Collections.Generic;
using System.Text;

namespace CountingBetweenTwoDays
{
    public class BusinessDayCounter
    {
        /// <summary>
        /// Calculates the number of weekdays in between two dates.
        /// Weekdays are Monday, Tuesday, Wednesday, Thursday, Friday.
        /// The returned count should not include either firstDate or secondDate -
        ///e.g.between Monday 07-Oct-2013 and Wednesday 09-Oct-2013 is one weekday.
        /// If secondDate is equal to or before firstDate, return 0.
        /// </summary>
        /// <param name="firstDate"></param>
        /// <param name="secondDate"></param>
        /// <returns></returns>
        public int WeekdaysBetweenTwoDates(DateTime firstDate, DateTime secondDate)
        {
            if (!DateTimeExtensions.DatesInit(firstDate, secondDate, out firstDate, out secondDate))
            {
                return 0;
            }

            int dayCounter = 0;
            var tempDate = firstDate.AddDays(1);
            while (tempDate < secondDate)
            {
                if (!tempDate.IsWeekend())
                {
                    dayCounter++;
                }
                tempDate = tempDate.AddDays(1);
            }
            return dayCounter;
        }
        /// <summary>
        /// Calculate the number of business days in between two dates.
        ///● Business days are Monday, Tuesday, Wednesday, Thursday, Friday, but excluding any
        ///dates which appear in the supplied list of public holidays.
        ///● The returned count should not include either firstDate or secondDate - e.g.between Monday
        ///07-Oct-2013 and Wednesday 09-Oct-2013 is one weekday.
        ///● If secondDate is equal to or before firstDate, return 0
        /// </summary>
        /// <param name="firstDate"></param>
        /// <param name="secondDate"></param>
        /// <param name="publicHolidays"></param>
        /// <returns></returns>
        public int BusinessDaysBetweenTwoDates(DateTime firstDate, DateTime secondDate, IList<DateTime> publicHolidays)
        {
            if (!DateTimeExtensions.DatesInit(firstDate, secondDate, out firstDate, out secondDate))
            {
                return 0;
            }

            int dayCounter = 0;
            var tempDate = firstDate.AddDays(1);
            while (tempDate < secondDate)
            {
                if (!tempDate.IsWeekend() && !publicHolidays.Contains(tempDate))
                {
                    dayCounter++;
                }
                tempDate = tempDate.AddDays(1);
            }

            return dayCounter;
        }
        /// <summary>
        /// Calculate the number of business days between two dates using those rules to define public holidays.
        /// </summary>
        /// <param name="firstDate"></param>
        /// <param name="secondDate"></param>
        /// <param name="rules"></param>
        /// <returns></returns>
        public int BusienssDaysBetweenTwoDates(DateTime firstDate, DateTime secondDate, IList<HolidayRule> rules)
        {
            if (!DateTimeExtensions.DatesInit(firstDate, secondDate, out firstDate, out secondDate))
            {
                return 0;
            }

            int dayCounter = 0;
            var tempDate = firstDate.AddDays(1);
            while (tempDate < secondDate)
            {
                if (!tempDate.IsWeekend())
                {
                    bool isMatch = false;
                    foreach (var rule in rules)
                    {
                        if (rule.IsMatched(tempDate))
                        {
                            isMatch = true;
                            break;
                        }
                    }
                    if (!isMatch)
                        dayCounter++;
                }
                tempDate = tempDate.AddDays(1);
            }

            return dayCounter;
        }
    }
}
