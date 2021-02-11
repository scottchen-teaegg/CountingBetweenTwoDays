using Microsoft.VisualStudio.TestTools.UnitTesting;
using CountingBetweenTwoDays;
using System;
using System.Collections.Generic;
using System.Text;

namespace CountingBetweenTwoDays.Tests
{
    [TestClass]
    public class BusinessDayCounterTests
    {
        [TestMethod()]
        public void WeekdaysBetweenTwoDatesTest()
        {
            BusinessDayCounter counter = new BusinessDayCounter();

            var firstDate = new DateTime(2013, 10, 7);
            var secondDate = new DateTime(2013, 10, 9);
            var expectedResult = 1;
            Assert.AreEqual(expectedResult, counter.WeekdaysBetweenTwoDates(firstDate, secondDate));

            firstDate = new DateTime(2013, 10, 5);
            secondDate = new DateTime(2013, 10, 14);
            expectedResult = 5;
            Assert.AreEqual(expectedResult, counter.WeekdaysBetweenTwoDates(firstDate, secondDate));

            firstDate = new DateTime(2013, 10, 7);
            secondDate = new DateTime(2014, 1, 1);
            expectedResult = 61;
            Assert.AreEqual(expectedResult, counter.WeekdaysBetweenTwoDates(firstDate, secondDate));

            firstDate = new DateTime(2013, 10, 7);
            secondDate = new DateTime(2013, 10, 5);
            expectedResult = 0;
            Assert.AreEqual(expectedResult, counter.WeekdaysBetweenTwoDates(firstDate, secondDate));
        }

        [TestMethod()]
        public void BusinessDaysBetweenTwoDatesWithHolidayListTest()
        {
            BusinessDayCounter counter = new BusinessDayCounter();

            List<DateTime> publicHolidays = new List<DateTime>
            {
                new DateTime(2013, 12, 25),
                new DateTime(2013, 12, 26),
                new DateTime(2014, 1, 1)
            };
            var firstDate = new DateTime(2013, 10, 7);
            var secondDate = new DateTime(2013, 10, 9);
            var expectedResult = 1;
            Assert.AreEqual(expectedResult, counter.BusinessDaysBetweenTwoDates(firstDate, secondDate, publicHolidays));

            firstDate = new DateTime(2013, 12, 24);
            secondDate = new DateTime(2013, 12, 27);
            expectedResult = 0;
            Assert.AreEqual(expectedResult, counter.BusinessDaysBetweenTwoDates(firstDate, secondDate, publicHolidays));

            firstDate = new DateTime(2013, 10, 7);
            secondDate = new DateTime(2014, 1, 1);
            expectedResult = 59;
            Assert.AreEqual(expectedResult, counter.BusinessDaysBetweenTwoDates(firstDate, secondDate, publicHolidays));

        }

        [TestMethod()]
        public void BusienssDaysBetweenTwoDatesWithHolidayRuleTest()
        {
            BusinessDayCounter counter = new BusinessDayCounter();

            List<HolidayRule> holidayRules = new List<HolidayRule>
            {
                new HolidayRule(25, 4),
                new HolidayRule(1, 1, true),
                new HolidayRule(6, 2, DayOfWeek.Monday)
            };

            var firstDate = new DateTime(2011, 12, 29);
            var secondDate = new DateTime(2012, 1, 3);
            var expectedResult = 1;
            Assert.AreEqual(expectedResult, counter.BusienssDaysBetweenTwoDates(firstDate, secondDate, holidayRules));

            firstDate = new DateTime(2015, 4, 23);
            secondDate = new DateTime(2015, 4, 28);
            expectedResult = 2;
            Assert.AreEqual(expectedResult, counter.BusienssDaysBetweenTwoDates(firstDate, secondDate, holidayRules));

            firstDate = new DateTime(2021, 6, 2);
            secondDate = new DateTime(2021, 6, 8);
            expectedResult = 3;
            Assert.AreEqual(expectedResult, counter.BusienssDaysBetweenTwoDates(firstDate, secondDate, holidayRules));

            firstDate = new DateTime(2021, 6, 9);
            secondDate = new DateTime(2021, 6, 15);
            expectedResult = 2;
            Assert.AreEqual(expectedResult, counter.BusienssDaysBetweenTwoDates(firstDate, secondDate, holidayRules));

        }
    }
}