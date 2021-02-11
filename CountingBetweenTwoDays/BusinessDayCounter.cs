using System;
using System.Collections.Generic;
using System.Text;

namespace CountingBetweenTwoDays
{
    public class BusinessDayCounter
    {
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="firstDate"></param>
        /// <param name="secondDate"></param>
        /// <returns> </returns>
        //private bool dateProcess(DateTime firstDate, DateTime secondDate, )
        //{
        //    firstDate
        //}
    }
}
