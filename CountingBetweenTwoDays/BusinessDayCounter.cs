using System;
using System.Collections.Generic;
using System.Text;

namespace CountingBetweenTwoDays
{
    public class BusinessDayCounter
    {
        public int WeekdaysBetweenTwoDates(DateTime firstDate, DateTime secondDate)
        {
            firstDate = firstDate.Date;
            secondDate = secondDate.Date;
            if (firstDate >= secondDate)
            {
                return 0;
            }
            int dayCounter = 0;
            var timeSpan = secondDate - firstDate;

            return dayCounter;
        }
        public int BusinessDaysBetweenTwoDates(DateTime firstDate, DateTime secondDate, IList<DateTime>
       publicHolidays)
        {
            
            //todo
            int dayCounter = 0;

            return dayCounter;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="firstDate"></param>
        /// <param name="secondDate"></param>
        /// <returns> </returns>
        private bool dateProcess(DateTime firstDate, DateTime secondDate, )
        {
            firstDate
        }
    }
}
