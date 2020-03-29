using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using YuurianCalendarApp;

namespace YuurianCalendarUnitTestProject
{
    [TestClass]
    public class UnitTest3
    {
        [TestMethod]
        public void TestMethod1()
        {
            var c = new YuurianCalendar();
            var d = c.ToDateTime(1, 1, 30, 4, 5, 6, 7);
            Assert.AreEqual(30, c.GetDayOfYear(d));
        }

        [TestMethod]
        public void TestMethod2()
        {
            var c = new YuurianCalendar();
            var d = c.ToDateTime(1, 2, 30, 4, 5, 6, 7);
            Assert.AreEqual(60, c.GetDayOfYear(d));
        }

        [TestMethod]
        public void TestMethod3()
        {
            var c = new YuurianCalendar();
            var d = c.ToDateTime(1, 3, 30, 4, 5, 6, 7);
            Assert.AreEqual(90, c.GetDayOfYear(d));
        }

        [TestMethod]
        public void TestMethod4()
        {
            var c = new YuurianCalendar();
            var d = c.ToDateTime(1, 4, 30, 4, 5, 6, 7);
            Assert.AreEqual(120, c.GetDayOfYear(d));
        }

        [TestMethod]
        public void TestMethod5()
        {
            var c = new YuurianCalendar();
            var d = c.ToDateTime(1, 5, 30, 4, 5, 6, 7);
            Assert.AreEqual(150, c.GetDayOfYear(d));
        }

        [TestMethod]
        public void TestMethod6()
        {
            var c = new YuurianCalendar();
            var d = c.ToDateTime(1, 6, 30, 4, 5, 6, 7);
            Assert.AreEqual(180, c.GetDayOfYear(d));
        }

        [TestMethod]
        public void TestMethod7()
        {
            var c = new YuurianCalendar();
            var d = c.ToDateTime(1, 7, 30, 4, 5, 6, 7);
            Assert.AreEqual(210, c.GetDayOfYear(d));
        }

        [TestMethod]
        public void TestMethod8()
        {
            var c = new YuurianCalendar();
            var d = c.ToDateTime(1, 8, 30, 4, 5, 6, 7);
            Assert.AreEqual(240, c.GetDayOfYear(d));
        }

        [TestMethod]
        public void TestMethod9()
        {
            var c = new YuurianCalendar();
            var d = c.ToDateTime(1, 9, 30, 4, 5, 6, 7);
            Assert.AreEqual(270, c.GetDayOfYear(d));
        }

        [TestMethod]
        public void TestMethod10()
        {
            var c = new YuurianCalendar();
            var d = c.ToDateTime(1, 10, 30, 4, 5, 6, 7);
            Assert.AreEqual(300, c.GetDayOfYear(d));
        }

        [TestMethod]
        public void TestMethod11()
        {
            var c = new YuurianCalendar();
            var d = c.ToDateTime(1, 11, 30, 4, 5, 6, 7);
            Assert.AreEqual(330, c.GetDayOfYear(d));
        }

        [TestMethod]
        public void TestMethod12()
        {
            var c = new YuurianCalendar();
            var d = c.ToDateTime(1, 12, 35, 4, 5, 6, 7);
            Assert.AreEqual(365, c.GetDayOfYear(d));
        }
    }
}
