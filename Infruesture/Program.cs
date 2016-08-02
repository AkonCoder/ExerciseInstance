using System;
using System.Security.Cryptography;

namespace Infruesture
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //1.随机数据
            //for (int i = 0; i < 100; i++)
            //{
            //    var result = GetRandomNum(GetRandomSeed(), 1.50, 1.70, 5);
            //    Console.WriteLine("当前的随机数是：" + result);
            //}

            //2.类型转换
            //var emptyNum = "";
            //int parseResult = int.Parse(null);
            //Console.WriteLine(parseResult);
            int convertIntResult = Convert.ToInt32(null);
            Console.WriteLine(convertIntResult);
            //int numResult;
            //var tryParseResult = int.TryParse(null, out numResult);
            //Console.WriteLine(tryParseResult);
            //时间类型的转化
            //DateTime outDate;
            //var checkDate = "2016-07-29-999";
            //var currentDate = DateTime.Now.Date.ToShortDateString();
            //Console.WriteLine(currentDate);
            //Console.WriteLine(DateTime.TryParse(checkDate, out outDate));
            Console.ReadLine();
        }


        /// <summary>
        /// 获取随机数
        /// </summary>
        /// <param name="minNum"></param>
        /// <param name="maxNum"></param>
        /// <param name="len"></param>
        /// <returns></returns>
        public static double GetRandomNum(double minNum, double maxNum, int len)
        {
            byte[] bytes = new byte[4];
            System.Security.Cryptography.RNGCryptoServiceProvider rngObj = new RNGCryptoServiceProvider();
            rngObj.GetBytes(bytes);
            var seed = BitConverter.ToInt32(bytes, 0);
            var random = new Random(seed);
            return Math.Round(random.NextDouble()*(maxNum - minNum) + minNum, len);
        }
    }
}