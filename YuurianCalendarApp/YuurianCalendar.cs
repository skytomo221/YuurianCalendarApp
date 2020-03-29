using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YuurianCalendarApp
{
    public class YuurianCalendar : Calendar
    {
        public YuurianCalendar()
        {
            TicksPerSecond = DefaultTicksPerSecond;
        }

        [System.Runtime.InteropServices.ComVisible(false)]
        public override DateTime MinSupportedDateTime
        {
            get
            {
                return DateTime.MinValue;
            }
        }

        [System.Runtime.InteropServices.ComVisible(false)]
        public override DateTime MaxSupportedDateTime
        {
            get
            {
                return DateTime.MaxValue;
            }
        }


        [System.Runtime.InteropServices.ComVisible(false)]
        public override CalendarAlgorithmType AlgorithmType
        {
            get
            {
                return CalendarAlgorithmType.SolarCalendar;
            }
        }

        /// <summary>
        /// 修正リパラオネ暦1年1月1日（西暦2012年6月2日）を表します。
        /// </summary>
        private static long DefaultStandardTicks = 634741920000000000;
        /// <summary>
        /// 時差を表します。
        /// 24時間以上の時差も代入可能です。
        /// </summary>
        public long CustomStandardTicks { get; set; }
        public long StandardTicks
        {
            get
            {
                return DefaultStandardTicks + CustomStandardTicks;
            }
            set
            {
                CustomStandardTicks = value - DefaultStandardTicks;
            }
        }

        internal static readonly int[] DaysToMonth =
        {
            0, 30, 60, 90, 120, 150, 180, 210, 240, 270, 300, 330, 365
        };

        private const long DefaultTicksPerMillisecond = 8000;
        private const long DefaultTicksPerSecond = DefaultTicksPerMillisecond * 1000;
        private const long DefaultTicksPerMinute = DefaultTicksPerSecond * 125;
        private const long DefaultTicksPerHour = DefaultTicksPerMinute * 36;
        private const long DefaultTicksPerDay = DefaultTicksPerHour * 24;
        private const long DefaultTicksPerYear = DefaultTicksPerDay * 365;

        public long TicksPerMillisecond { get; private set; } = DefaultTicksPerMillisecond;

        private long ticksPerSecond;
        public long TicksPerSecond
        {
            get { return ticksPerSecond; }
            set
            {
                TicksPerMillisecond = value / 1000;
                ticksPerSecond = TicksPerMillisecond * 1000;
                TicksPerMinute = TicksPerSecond * 125;
                TicksPerHour = TicksPerMinute * 36;
                TicksPerDay = TicksPerHour * 24;
                TicksPerYear = TicksPerDay * 365;
            }
        }
        public long TicksPerMinute { get; private set; } = DefaultTicksPerMinute;
        public long TicksPerHour { get; private set; } = DefaultTicksPerHour;
        public long TicksPerDay { get; private set; } = DefaultTicksPerDay;
        public long TicksPerYear { get; private set; } = DefaultTicksPerYear;

        public override int[] Eras => new int[2] { 2, 1 };

        public override DateTime AddDays(DateTime time, int days)
        {
            return new DateTime(time.Ticks + days * TicksPerDay);
        }

        public override DateTime AddHours(DateTime time, int hours)
        {
            return new DateTime(time.Ticks + hours * TicksPerHour);
        }

        public override DateTime AddMinutes(DateTime time, int minutes)
        {
            return new DateTime(time.Ticks + minutes * TicksPerMinute);
        }

        public override DateTime AddMilliseconds(DateTime time, double milliseconds)
        {
            return new DateTime(time.Ticks + (int)(milliseconds * TicksPerMillisecond));
        }

        public override DateTime AddMonths(DateTime time, int months)
        {
            var days = months % 12 * 30 + (GetMonth(time) + months % 12 - 1 < 12 ? 0 : 5);
            return new DateTime(time.Ticks + months / 12 * TicksPerYear + days * TicksPerDay);
        }

        public override DateTime AddSeconds(DateTime time, int seconds)
        {
            return new DateTime(time.Ticks + seconds * TicksPerSecond);
        }

        public override DateTime AddYears(DateTime time, int years)
        {
            return AddMonths(time, years * 12);
        }

        public override int GetDayOfMonth(DateTime time)
        {
            return GetDayOfYear(time) - DaysToMonth[GetMonth(time) - 1];
        }

        public override DayOfWeek GetDayOfWeek(DateTime time)
        {
            return (DayOfWeek)((GetDayOfYear(time) + 4) % 5);
        }

        public override int GetDayOfYear(DateTime time)
        {
            return (int)(((time.Ticks - StandardTicks) % TicksPerYear / TicksPerDay + 365) % 365 + 1);
        }

        public override int GetDaysInMonth(int year, int month, int era)
        {
            return month != 12 ? 30 : 35;
        }

        public override int GetDaysInYear(int year, int era)
        {
            return 365;
        }

        public override int GetEra(DateTime time)
        {
            return time.Ticks < StandardTicks ? 1 : 2;
        }

        public override int GetHour(DateTime time)
        {
            return (int)(((time.Ticks - StandardTicks) % TicksPerDay / TicksPerHour + 24) % 24);
        }

        public override int GetMinute(DateTime time)
        {
            return (int)(((time.Ticks - StandardTicks) % TicksPerHour / TicksPerMinute + 36) % 36);
        }

        public override double GetMilliseconds(DateTime time)
        {
            return ((time.Ticks - StandardTicks) % TicksPerSecond / TicksPerMillisecond + 1000) % 1000;
        }

        public override int GetMonth(DateTime time)
        {
            var month = (GetDayOfYear(time) - 1) / 30 + 1;
            return month < 12 ? month : 12;
        }

        public override int GetMonthsInYear(int year, int era)
        {
            return 12;
        }

        public override int GetSecond(DateTime time)
        {
            return (int)(((time.Ticks - StandardTicks) % TicksPerMinute / TicksPerSecond + 125) % 125);
        }

        public override int GetYear(DateTime time)
        {
            return (int)((time.Ticks - StandardTicks) / TicksPerYear) + ((GetEra(time) - 1) * 2 - 1);
        }

        public override bool IsLeapDay(int year, int month, int day, int era)
        {
            return false;
        }

        public override bool IsLeapMonth(int year, int month, int era)
        {
            return false;
        }

        public override bool IsLeapYear(int year, int era)
        {
            return false;
        }
        public override DateTime ToDateTime(int year, int month, int day, int hour, int minute, int second, int millisecond)
        {
            return ToDateTime(year, month, day, hour, minute, second, millisecond, 2);
        }

        public override DateTime ToDateTime(int year, int month, int day, int hour, int minute, int second, int millisecond, int era)
        {
            var d = new DateTime(2012, 6, 2);
            d = AddYears(d, year - ((era - 1) * 2 - 1));
            d = AddMonths(d, month - 1);
            d = AddDays(d, day - 1);
            d = AddHours(d, hour);
            d = AddMinutes(d, minute);
            d = AddSeconds(d, second);
            return AddMilliseconds(d, millisecond);
        }
    }
}
