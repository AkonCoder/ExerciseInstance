using System;

namespace Infruesture
{
    public class ChineseLunisolarCalendar
    {
        //C# 获取农历日期

        /// <summary>
        ///     实例化一个 ChineseLunisolarCalendar
        /// </summary>
        private static readonly ChineseLunisolarCalendar ChineseCalendar = new ChineseLunisolarCalendar();

        /// <summary>
        ///     十天干
        /// </summary>
        private static readonly string[] tg = {"甲", "乙", "丙", "丁", "戊", "己", "庚", "辛", "壬", "癸"};

        /// <summary>
        ///     十二地支
        /// </summary>
        private static readonly string[] dz = {"子", "丑", "寅", "卯", "辰", "巳", "午", "未", "申", "酉", "戌", "亥"};

        /// <summary>
        ///     十二生肖
        /// </summary>
        private static readonly string[] sx = {"鼠", "牛", "虎", "免", "龙", "蛇", "马", "羊", "猴", "鸡", "狗", "猪"};

        /// <summary>
        ///     农历月
        /// </summary>
        /// <return s></returns>
        private static readonly string[] months = {"正", "二", "三", "四", "五", "六", "七", "八", "九", "十", "十一", "十二(腊)"};

        /// <summary>
        ///     农历日
        /// </summary>
        private static readonly string[] days1 = {"初", "十", "廿", "三"};

        /// <summary>
        ///     农历日
        /// </summary>
        private static readonly string[] days = {"一", "二", "三", "四", "五", "六", "七", "八", "九", "十"};

        /// <summary>
        ///     返回农历天干地支年
        /// </summary>
        /// <param name="year">农历年</param>
        /// <return s></returns>
        public string GetLunisolarYear(int year)
        {
            if (year > 3)
            {
                var tgIndex = (year - 4)%10;
                var dzIndex = (year - 4)%12;

                return string.Concat(tg[tgIndex], dz[dzIndex], "[", sx[dzIndex], "]");
            }

            throw new ArgumentOutOfRangeException("无效的年份!");
        }

        /// <summary>
        ///     返回农历月
        /// </summary>
        /// <param name="month">月份</param>
        /// <return s></returns>
        public string GetLunisolarMonth(int month)
        {
            if (month < 13 && month > 0)
            {
                return months[month - 1];
            }

            throw new ArgumentOutOfRangeException("无效的月份!");
        }

        /// <summary>
        ///     返回农历日
        /// </summary>
        /// <param name="day">天</param>
        /// <return s></returns>
        public string GetLunisolarDay(int day)
        {
            if (day > 0 && day < 32)
            {
                if (day != 20 && day != 30)
                {
                    return string.Concat(days1[(day - 1)/10], days[(day - 1)%10]);
                }
                return string.Concat(days[(day - 1)/10], days1[1]);
            }

            throw new ArgumentOutOfRangeException("无效的日!");
        }

        /// <summary>
        ///     根据公历获取农历日期
        /// </summary>
        /// <param name="datetime">公历日期</param>
        public static string GetChineseDateTime(DateTime datetime)
        {
            var year = ChineseCalendar.GetLunisolarYear(datetime.Year);
            var month = ChineseCalendar.GetLunisolarMonth(datetime.Month);
            var day = ChineseCalendar.GetLunisolarDay(datetime.Day);
            return string.Concat(year, "年", month, "月", day);
        }
    }
}