using System;
using System.Security.Cryptography;

namespace Infruesture
{
    internal class Program
    {
        // ReSharper disable once StaticMemberInitializerReferesToMemberBelow
        private static readonly int NumA = NumB*10;
        private static readonly int NumB = 10;

        public const int NumC = NumD*10;
        private const int NumD = 10;

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
            //int convertIntResult = Convert.ToInt32(null);
            //Console.WriteLine(convertIntResult);
            //int numResult;
            //var tryParseResult = int.TryParse(null, out numResult);
            //Console.WriteLine(tryParseResult);
            //时间类型的转化
            //DateTime outDate;
            //var checkDate = "2016-07-29-999";
            //var currentDate = DateTime.Now.Date.ToShortDateString();
            //Console.WriteLine(currentDate);
            //Console.WriteLine(DateTime.TryParse(checkDate, out outDate));


            //3.静态类
            //var firestNum = StaticTest._num;
            //Console.WriteLine("第一次调用num值为：" + firestNum);
            //var secondNum = StaticTest._num;
            //Console.WriteLine("第二次调用num值为：" + secondNum);
            //var thirdNum = StaticTest._num;
            //Console.WriteLine("第三次调用num值为：" + thirdNum);


            //4.static readonly与static
            //4.1 对于那些本质上应该是常量，但是却无法使用const来声明的地方，可以使用static readonly。 
            //输出static readonly的值
            //Console.WriteLine("NumA的值为" + NumA + ";\nNumB的值为：" + NumB);
            ////输出const的值
            //Console.WriteLine("NumC的值为：" + NumC + ";\nNumD的值为：" + NumD);


            //5.ref与out的比较使用
            //var testNumA = 100;
            //var testNumB = 200;
            //GetRefValue(ref testNumA, ref testNumB);
            //Console.WriteLine("numA的值为：" + testNumA + ";numB的值为：" + testNumB);
            //GetOutValue(out testNumA, out testNumB);
            //Console.WriteLine("numC的值为：" + testNumA + ";numD的值为：" + testNumB);

            //int tryNum = 0;
            //var result = int.TryParse("100", out tryNum);
            //Console.WriteLine("转化后的值为：" + tryNum);


            //6.引用类型的区别
            var tempObj = new Program();
            Console.WriteLine("当前Program的FullName是：" + tempObj.GetType().FullName);
            Console.WriteLine("当前Program的类型是Class：" + tempObj.GetType().IsClass);
            var attributes = tempObj.GetType().Attributes;
            Console.WriteLine("当前program的attribute有：" + attributes);

            //7.struct类型
            var structObj = new GetUserName("liupeng", 25);
            Console.WriteLine("当前的姓名为：" + structObj.UserName + "当前的年龄为：" + structObj.Age);

            Console.ReadKey();
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
            RNGCryptoServiceProvider rngObj = new RNGCryptoServiceProvider();
            rngObj.GetBytes(bytes);
            var seed = BitConverter.ToInt32(bytes, 0);
            var random = new Random(seed);
            return Math.Round(random.NextDouble()*(maxNum - minNum) + minNum, len);
        }


        public static void GetRefValue(ref int testA, ref int testB)
        {
            testA = 10;
            testB = 20;
        }

        public static void GetOutValue(out int testA, out int testB)
        {
            testA = 200;
            testB = 300;
        }
    }

    public struct GetUserName
    {
        public string UserName;
        public int Age;

        public GetUserName(string name, int age)
        {
            UserName = name;
            Age = age;
        }
    }
}