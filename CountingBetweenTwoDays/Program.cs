using System;
using System.Collections.Generic;

namespace CountingBetweenTwoDays
{
    class Program
    {
        static void Main(string[] args)
        {
            var dayCounter = new BusinessDayCounter();

            Console.WriteLine(dayCounter.WeekdaysBetweenTwoDates(new DateTime(2013, 10, 7), new DateTime(2013, 10, 9)));
            Console.WriteLine(dayCounter.WeekdaysBetweenTwoDates(new DateTime(2013, 10, 5), new DateTime(2013, 10, 14)));
            Console.WriteLine(dayCounter.WeekdaysBetweenTwoDates(new DateTime(2013, 10, 7), new DateTime(2014, 1, 1)));
            Console.WriteLine(dayCounter.WeekdaysBetweenTwoDates(new DateTime(2013, 10, 7), new DateTime(2013, 10, 5)));

            List<DateTime> publicHolidays = new List<DateTime>
            {
                new DateTime(2013, 12, 25),
                new DateTime(2013, 12, 26),
                new DateTime(2014, 1, 1)
            };
            Console.WriteLine(dayCounter.BusinessDaysBetweenTwoDates(new DateTime(2013, 10, 7), new DateTime(2013, 10, 9), publicHolidays));
            Console.WriteLine(dayCounter.BusinessDaysBetweenTwoDates(new DateTime(2013, 12, 24), new DateTime(2013, 12, 27), publicHolidays));
            Console.WriteLine(dayCounter.BusinessDaysBetweenTwoDates(new DateTime(2013, 10, 7), new DateTime(2014, 1, 1), publicHolidays));

            List<HolidayRule> holidayRules = new List<HolidayRule>
            {
                new HolidayRule(25, 4, true),
                new HolidayRule(1, 1, true),
                new HolidayRule(DayOfWeek.Monday, 2, 6)
            };
            Console.WriteLine(dayCounter.BusienssDaysBetweenTwoDates(new DateTime(2021, 4, 22), new DateTime(2021, 4, 28), holidayRules));

        }
    }
}
