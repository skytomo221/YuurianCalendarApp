using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using YuurianCalendarApp;

namespace YuurianCalendarUnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var c = new YuurianCalendar();
            var d = new DateTime(2012, 6, 2);

            Assert.AreEqual(1, c.GetDayOfMonth(d));
            Assert.AreEqual(DayOfWeek.Sunday, c.GetDayOfWeek(d));
            Assert.AreEqual(2, c.GetEra(d));
            Assert.AreEqual(1, c.GetMonth(d));
            Assert.AreEqual(1, c.GetYear(d));
        }

        [TestMethod]
        public void TestMethod2()
        {
            var c = new YuurianCalendar();
            var d = new DateTime(2012, 6, 2);
            d = c.AddDays(d, 1);

            Assert.AreEqual(2, c.GetDayOfMonth(d), 2);
            Assert.AreEqual(DayOfWeek.Monday, c.GetDayOfWeek(d));
            Assert.AreEqual(2, c.GetEra(d));
            Assert.AreEqual(1, c.GetMonth(d));
            Assert.AreEqual(1, c.GetYear(d));
        }

        [TestMethod]
        public void TestMethod3()
        {
            var c = new YuurianCalendar();
            var d = new DateTime(2012, 6, 2);
            d = c.AddMonths(d, 11);

            var d2 = c.ToDateTime(1, 12, 1, 0, 0, 0, 0);
            Assert.IsTrue(c.GetYear(d) == c.GetYear(d2));
            Assert.IsTrue(c.GetMonth(d) == c.GetMonth(d2));
            Assert.IsTrue(c.GetDayOfMonth(d) == c.GetDayOfMonth(d2));
        }

        [TestMethod]
        public void TestMethod4()
        {
            var c = new YuurianCalendar();
            var d = c.ToDateTime(1, 2, 3, 4, 5, 6, 7);
            Assert.AreEqual(1, c.GetYear(d));
            Assert.AreEqual(2, c.GetMonth(d));
            Assert.AreEqual(3, c.GetDayOfMonth(d));
            Assert.AreEqual(4, c.GetHour(d));
            Assert.AreEqual(5, c.GetMinute(d));
            Assert.AreEqual(6, c.GetSecond(d));
            Assert.AreEqual(7, c.GetMilliseconds(d));
        }

        [TestMethod]
        public void TestMethod5()
        {
            var c = new YuurianCalendar();
            var d = c.ToDateTime(1, 11, 30, 4, 5, 6, 7);
            d = c.AddMonths(d, 2);

            Assert.AreEqual(2, c.GetYear(d));
            Assert.AreEqual(1, c.GetMonth(d));
            Assert.AreEqual(30, c.GetDayOfMonth(d));
        }

        [TestMethod]
        public void TestMethod6()
        {
            var c = new YuurianCalendar();
            var d = c.ToDateTime(7, 6, 5, 4, 3, 2, 1);
            Assert.AreEqual(7, c.GetYear(d));
            Assert.AreEqual(6, c.GetMonth(d));
            Assert.AreEqual(5, c.GetDayOfMonth(d));
            Assert.AreEqual(4, c.GetHour(d));
            Assert.AreEqual(3, c.GetMinute(d));
            Assert.AreEqual(2, c.GetSecond(d));
            Assert.AreEqual(1, c.GetMilliseconds(d));
        }

        [TestMethod]
        public void TestMethod7()
        {
            var c = new YuurianCalendar();
            var d = c.ToDateTime(7, 6, 5, 4, 3, 2, 1);
            Assert.AreEqual(2018, d.Year);
            Assert.AreEqual(11, d.Month);
            Assert.AreEqual(2, d.Day);
        }
    }
}
