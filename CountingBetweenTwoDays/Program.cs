using System;
using System.Collections.Generic;

namespace CountingBetweenTwoDays
{
    class Program
    {
        static void Main(string[] args)
        {
            var dayCounter = new BusinessDayCounter();
            var listWeekdaysBetweenTwoDates = new List<StartEndDays>
            {
                new StartEndDays(new DateTime(2013, 10, 7), new DateTime(2013, 10, 9)),
                new StartEndDays(new DateTime(2013, 10, 5), new DateTime(2013, 10, 14)),
                new StartEndDays(new DateTime(2013, 10, 7), new DateTime(2014, 1, 1)),
                new StartEndDays(new DateTime(2013, 10, 7), new DateTime(2013, 10, 5))
            };

            var listBusinessDaysBetweenTwoDatesWithHoliday = new List<StartEndDays>
            {
                new StartEndDays(new DateTime(2013, 10, 7), new DateTime(2013, 10, 9)),
                new StartEndDays(new DateTime(2013, 12, 24), new DateTime(2013, 12, 27)),
                new StartEndDays(new DateTime(2013, 10, 7), new DateTime(2014, 1, 1))
            };

            var publicHolidays = new List<DateTime>
            {
                new DateTime(2013, 12, 25),
                new DateTime(2013, 12, 26),
                new DateTime(2014, 1, 1)
            };

            var listBusinessDaysBetweenTwoDatesWithRule = new List<StartEndDays>
            {
                new StartEndDays(new DateTime(2011, 12, 29), new DateTime(2012, 1, 4)),
                new StartEndDays(new DateTime(2013, 10, 5), new DateTime(2013, 10, 14)),
                new StartEndDays(new DateTime(2021, 4, 22), new DateTime(2021, 4, 28))
            };

            var holidayRules = new List<HolidayRule>
            {
                new HolidayRule(25, 4),
                new HolidayRule(1, 1, true),
                new HolidayRule(6, 2, DayOfWeek.Monday)
            };

            int result;
            Console.WriteLine("Task 1: ");
            foreach (var testDays in listWeekdaysBetweenTwoDates)
            {
                result = dayCounter.WeekdaysBetweenTwoDates(testDays.StartDate, testDays.EndDate);
                DaysCounterOutput(testDays.StartDate, testDays.EndDate, result);
            }

            Console.WriteLine("Task 2: ");
            foreach (var testDays in listBusinessDaysBetweenTwoDatesWithHoliday)
            {
                result = dayCounter.BusinessDaysBetweenTwoDates(testDays.StartDate, testDays.EndDate, publicHolidays);
                DaysCounterOutput(testDays.StartDate, testDays.EndDate, result);
            }

            Console.WriteLine("Task 3: ");
            foreach (var testDays in listBusinessDaysBetweenTwoDatesWithRule)
            {
                result = dayCounter.BusienssDaysBetweenTwoDates(testDays.StartDate, testDays.EndDate, holidayRules);
                DaysCounterOutput(testDays.StartDate, testDays.EndDate, result);
            }


        }

        private static void DaysCounterOutput(DateTime firstDate, DateTime secondDate, int result)
        {
            Console.WriteLine($"StartDate: {firstDate}, EndDate: {secondDate}, Result: {result}");
        }

        public class StartEndDays
        {
            public StartEndDays(DateTime startDate, DateTime endDate)
            {
                StartDate = startDate;
                EndDate = endDate;
            }
            public DateTime StartDate { get; set; }
            public DateTime EndDate { get; set; }
        }

    }
}
