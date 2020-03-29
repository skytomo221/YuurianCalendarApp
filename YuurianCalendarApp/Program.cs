using System;
using System.Collections.Generic;
using System.Globalization;

namespace YuurianCalendarApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var c = new YuurianCalendar();
            var ds = new List<DateTime>()
            {
                DateTime.Now,
                DateTime.MinValue,
                DateTime.MaxValue,
            };
            foreach (var d in ds)
            {
                Console.WriteLine(d);
                Console.WriteLine($"{c.GetYear(d)}/{c.GetMonth(d)}/{c.GetDayOfMonth(d)} {c.GetHour(d)}:{c.GetMinute(d)}:{c.GetSecond(d)}.{c.GetMilliseconds(d)}");
                Console.WriteLine();
            }
        }
    }

    class BigLiparaoneDate
    {
        private const long TicksPerMillisecond = 10000;
        private const long TicksPerSecond = TicksPerMillisecond * 1000;
        private const long TicksPerMinute = TicksPerSecond * 60;
        private const long TicksPerHour = TicksPerMinute * 60;
        private const long TicksPerDay = TicksPerHour * 24;

        public long Date { get; private set; }
        private const long StususnPerRukest = 125;
        private const long StususnPerLiestu = StususnPerRukest * 36;
        private const long StususnPerSnenik = StususnPerLiestu * 24;
        private const long SnenikPerYear = 365;

        public long Year
        {
            get
            {
                return Date / (StususnPerSnenik * SnenikPerYear);
            }
        }

        public void AddTick()
        {
            Date++;
        }
    }
}
