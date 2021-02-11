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
            int actualResult = DateTimeExtensions.GetWeekNumberOfMonth(new DateTime(2021, 2, 12));
            int expectedResult = 2;

            Assert.AreEqual(expectedResult, actualResult);

            //First Monday
            actualResult = DateTimeExtensions.GetWeekNumberOfMonth(new DateTime(2021, 1, 4));
            expectedResult = 1;

            Assert.AreEqual(expectedResult, actualResult);

            //Second Friday
            actualResult = DateTimeExtensions.GetWeekNumberOfMonth(new DateTime(2021, 6, 8));
            expectedResult = 2;

            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}