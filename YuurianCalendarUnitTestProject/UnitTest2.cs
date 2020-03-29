using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using YuurianCalendarApp;

namespace YuurianCalendarUnitTestProject
{
    [TestClass]
    public class UnitTest2
    {
        [TestMethod]
        public void TestMethod1()
        {
            var c = new YuurianCalendar();
            var d = c.ToDateTime(1, 1, 1, 4, 5, 6, 7);
            Assert.AreEqual(1, c.GetDayOfYear(d));
        }

        [TestMethod]
        public void TestMethod2()
        {
            var c = new YuurianCalendar();
            var d = c.ToDateTime(1, 2, 1, 4, 5, 6, 7);
            Assert.AreEqual(31, c.GetDayOfYear(d));
        }

        [TestMethod]
        public void TestMethod3()
        {
            var c = new YuurianCalendar();
            var d = c.ToDateTime(1, 3, 1, 4, 5, 6, 7);
            Assert.AreEqual(61, c.GetDayOfYear(d));
        }

        [TestMethod]
        public void TestMethod4()
        {
            var c = new YuurianCalendar();
            var d = c.ToDateTime(1, 4, 1, 4, 5, 6, 7);
            Assert.AreEqual(91, c.GetDayOfYear(d));
        }

        [TestMethod]
        public void TestMethod5()
        {
            var c = new YuurianCalendar();
            var d = c.ToDateTime(1, 5, 1, 4, 5, 6, 7);
            Assert.AreEqual(121, c.GetDayOfYear(d));
        }

        [TestMethod]
        public void TestMethod6()
        {
            var c = new YuurianCalendar();
            var d = c.ToDateTime(1, 6, 1, 4, 5, 6, 7);
            Assert.AreEqual(151, c.GetDayOfYear(d));
        }

        [TestMethod]
        public void TestMethod7()
        {
            var c = new YuurianCalendar();
            var d = c.ToDateTime(1, 7, 1, 4, 5, 6, 7);
            Assert.AreEqual(181, c.GetDayOfYear(d));
        }

        [TestMethod]
        public void TestMethod8()
        {
            var c = new YuurianCalendar();
            var d = c.ToDateTime(1, 8, 1, 4, 5, 6, 7);
            Assert.AreEqual(211, c.GetDayOfYear(d));
        }

        [TestMethod]
        public void TestMethod9()
        {
            var c = new YuurianCalendar();
            var d = c.ToDateTime(1, 9, 1, 4, 5, 6, 7);
            Assert.AreEqual(241, c.GetDayOfYear(d));
        }

        [TestMethod]
        public void TestMethod10()
        {
            var c = new YuurianCalendar();
            var d = c.ToDateTime(1, 10, 1, 4, 5, 6, 7);
            Assert.AreEqual(271, c.GetDayOfYear(d));
        }

        [TestMethod]
        public void TestMethod11()
        {
            var c = new YuurianCalendar();
            var d = c.ToDateTime(1, 11, 1, 4, 5, 6, 7);
            Assert.AreEqual(301, c.GetDayOfYear(d));
        }

        [TestMethod]
        public void TestMethod12()
        {
            var c = new YuurianCalendar();
            var d = c.ToDateTime(1, 12, 1, 4, 5, 6, 7);
            Assert.AreEqual(331, c.GetDayOfYear(d));
        }
    }
}
