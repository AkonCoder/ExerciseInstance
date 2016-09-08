using System;
using System.Globalization;
using log4net.Repository.Hierarchy;

namespace Infruesture
{
    public static partial class Helper
    {
        /// <summary>
        ///     根据公历,返回对应农历日期
        /// </summary>
        /// <param name="date">公历日期</param>
        /// <returns></returns>
        public static ChinaDate ConvertToLunisolar(DateTime date)
        {
            ChineseLunisolarCalendar calendar = new ChineseLunisolarCalendar();
            if (date > calendar.MaxSupportedDateTime || date < calendar.MinSupportedDateTime)
            {
                //日期范围：1901 年 2 月 19 日 - 2101 年 1 月 28 日
                throw new Exception(string.Format("日期超出范围！必须在{0}到{1}之间！",
                    calendar.MinSupportedDateTime.ToString("yyyy-MM-dd"),
                    calendar.MaxSupportedDateTime.ToString("yyyy-MM-dd")));
            }

            int iYear = calendar.GetYear(date);
            int iMonth = calendar.GetMonth(date);
            int leapMonth = calendar.GetLeapMonth(iYear);
            //判断是否闰月
            var isLeapMonth = iMonth == leapMonth;
            if (leapMonth != 0 && iMonth >= leapMonth)
            {
                iMonth--;
            }
            int iDay = calendar.GetDayOfMonth(date);

            var chinaDate = new ChinaDate();
            chinaDate.Year = iYear;
            chinaDate.Month = iMonth;
            chinaDate.Day = iDay;

            return chinaDate;
        }

        /// <summary>
        ///     根据公历,返回对应农历日期
        /// </summary>
        /// <param name="dt">公历日期</param>
        /// <returns></returns>
        public static string ConvertToLunisolarDate(DateTime dt)
        {
            ChineseLunisolarCalendar calendar = new ChineseLunisolarCalendar();
            if (dt > calendar.MaxSupportedDateTime || dt < calendar.MinSupportedDateTime)
            {
                //日期范围：1901 年 2 月 19 日 - 2101 年 1 月 28 日
                throw new Exception(string.Format("日期超出范围！必须在{0}到{1}之间！",
                    calendar.MinSupportedDateTime.ToString("yyyy-MM-dd"),
                    calendar.MaxSupportedDateTime.ToString("yyyy-MM-dd")));
            }

            int iYear = calendar.GetYear(dt);
            int iMonth = calendar.GetMonth(dt);
            int leapMonth = calendar.GetLeapMonth(iYear);
            //判断是否闰月
            var isLeapMonth = iMonth == leapMonth;
            if (leapMonth != 0 && iMonth >= leapMonth)
            {
                iMonth--;
            }
            int iDay = calendar.GetDayOfMonth(dt);

            return (iYear + "-" + iMonth + "-" + iDay);
        }

        /// <summary>
        ///     根据农历,返回对应公历日期
        /// </summary>
        /// <param name="year">年份</param>
        /// <param name="month">月份</param>
        /// <param name="day">天</param>
        /// <returns></returns>
        public static DateTime ConvertLunisolarToDate(int year, int month, int day)
        {
            var calendar = new ChineseLunisolarCalendar();
            try
            {
                int leapMonth = calendar.GetLeapMonth(year);

                //bool isLeapMonth = month == leapMonth;
                var iMonth = month;
                if (leapMonth != 0 && month >= leapMonth)
                {
                    iMonth++;
                }
                return calendar.ToDateTime(year, iMonth, day, 0, 0, 0, 0);
            }
            catch (Exception ex)
            {
                //Logger.Error(string.Format("农历日期转换错误[{0}-{1}-{2}]:", year, month, day), ex);
                return Convert.ToDateTime("1900-1-1");
            }
        }

        /// <summary>
        ///     农历
        /// </summary>
        public class ChinaDate
        {
            /// <summary>
            ///     年份
            /// </summary>
            public int Year { get; set; }

            /// <summary>
            ///     月份
            /// </summary>
            public int Month { get; set; }

            /// <summary>
            ///     天
            /// </summary>
            public int Day { get; set; }
        }
    }
}