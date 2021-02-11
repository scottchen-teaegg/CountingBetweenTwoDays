using Microsoft.VisualStudio.TestTools.UnitTesting;
using CountingBetweenTwoDays;
using System;
using System.Collections.Generic;
using System.Text;

namespace CountingBetweenTwoDays.Tests
{
    [TestClass()]
    public class DateTimeExtensionsTests
    {
        [TestMethod()]
        public void GetWeekNumberOfMonthTest()
        {
            //Second Tue
            int actualResult = DateTimeExtensions.GetWeekNumberOfMonth(new DateTime(2021, 6, 8));
            int expectedResult = 2;
            Assert.AreEqual(expectedResult, actualResult);

            //Second Fri
            Assert.AreEqual(expectedResult, actualResult);
            actualResult = DateTimeExtensions.GetWeekNumberOfMonth(new DateTime(2021, 2, 12));
            expectedResult = 2;

            Assert.AreEqual(expectedResult, actualResult);

            //First Monday
            actualResult = DateTimeExtensions.GetWeekNumberOfMonth(new DateTime(2021, 1, 4));
            expectedResult = 1;

            Assert.AreEqual(expectedResult, actualResult);

            //First MOnday = FirstDate
            actualResult = DateTimeExtensions.GetWeekNumberOfMonth(new DateTime(2021, 3, 2));
            expectedResult = 1;

            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}