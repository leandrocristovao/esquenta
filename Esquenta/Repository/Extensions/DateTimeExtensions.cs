using System;

namespace Esquenta.Repository.Extensions
{
    public static class DateTimeExtensions
    {
        public static DateTime PreviousMonth(this DateTime dateTime)
        {
            return dateTime.AddMonths(-1);
        }

        public static DateTime? PreviousMonth(this DateTime? dateTime)
        {
            return dateTime.HasValue
                ? dateTime.PreviousMonth()
                : null;
        }

        public static DateTime NextMonth(this DateTime dateTime)
        {
            return dateTime.AddMonths(1);
        }

        public static DateTime? NextMonth(this DateTime? dateTime)
        {
            return dateTime.HasValue
                ? dateTime.NextMonth()
                : null;
        }

        public static DateTime? FirstDayOfMonth(this DateTime? dateTime)
        {
            return dateTime.HasValue
                ? dateTime.FirstDayOfMonth()
                : null;
        }

        public static DateTime FirstDayOfMonth(this DateTime dateTime)
        {
            return new DateTime(dateTime.Year, dateTime.Month, 1);
        }

        public static DateTime? LastDayOfMonth(this DateTime? dateTime)
        {
            return dateTime.HasValue
                ? dateTime.LastDayOfMonth()
                : null;
        }

        public static DateTime LastDayOfMonth(this DateTime dateTime)
        {
            return dateTime.FirstDayOfMonth().AddMonths(1).AddMilliseconds(-1);
        }

        public static bool IsValidDate(this DateTime? dateTime)
        {
            return dateTime.HasValue
                ? dateTime.IsValidDate()
                : false;
        }

        public static bool IsValidDate(this DateTime dateTime)
        {
            var dateStart = new DateTime(1753, 1, 1, 12, 00, 00);
            var dateEnd = new DateTime(9999, 12, 31, 12, 59, 59);

            return (dateTime >= dateStart && dateTime <= dateEnd);
        }

        public static DateTime AbsoluteStart(this DateTime dateTime)
        {
            return dateTime.Date;
        }

        /// <summary>
        /// Gets the 11:59:59 instance of a DateTime
        /// </summary>
        public static DateTime AbsoluteEnd(this DateTime dateTime)
        {
            return AbsoluteStart(dateTime).AddDays(1).AddTicks(-1);
        }
    }
}