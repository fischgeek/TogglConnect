using System;

namespace SharedLibrary
{
    public static class DateTimeExtensions
    {
        public static string ToDateAndTime(this DateTime dt)
        {
            return dt.ToString(@"M/dd/yyyy h:mm tt");
        }

        public static DateTime Sunday(this DateTime dt)
        {
            return GetDayOfWeek(dt, DayOfWeek.Sunday);
        }

        public static DateTime Monday(this DateTime dt)
        {
            return GetDayOfWeek(dt, DayOfWeek.Monday);
        }

        public static DateTime Tuesday(this DateTime dt)
        {
            return GetDayOfWeek(dt, DayOfWeek.Tuesday);
        }

        public static DateTime Wednesday(this DateTime dt)
        {
            return GetDayOfWeek(dt, DayOfWeek.Wednesday);
        }

        public static DateTime Thursday(this DateTime dt)
        {
            return GetDayOfWeek(dt, DayOfWeek.Thursday);
        }

        public static DateTime Friday(this DateTime dt)
        {
            return GetDayOfWeek(dt, DayOfWeek.Friday);
        }

        public static DateTime Saturday(this DateTime dt)
        {
            return GetDayOfWeek(dt, DayOfWeek.Saturday);
        }

        private static DateTime GetDayOfWeek(DateTime d, DayOfWeek dow)
        {
            int diff = d.DayOfWeek - dow;
            return d.AddDays(-diff);
        }
    }
}
