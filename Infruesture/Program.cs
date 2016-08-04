using System;
using System.Collections.Generic;
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
            //var tempObj = new Program();
            //Console.WriteLine("当前Program的FullName是：" + tempObj.GetType().FullName);
            //Console.WriteLine("当前Program的类型是Class：" + tempObj.GetType().IsClass);
            //var attributes = tempObj.GetType().Attributes;
            //Console.WriteLine("当前program的attribute有：" + attributes);

            ////7.struct类型
            //var structObj = new GetUserName("liupeng", 25);
            //Console.WriteLine("当前的姓名为：" + structObj.UserName + "当前的年龄为：" + structObj.Age);

            //8.Enum的使用的和技巧

            //var currentColor =EnumTest.RoleEnum.All;
            //if (currentColor.HasFlag(EnumTest.RoleEnum.Red))
            //{
            //    Console.WriteLine("当前颜色包含黑色");
            //}

            //第二种权限枚举
            //var testSysNum1 = 1;
            //var testSysNum2 = 5;
            //var testSysNum3 = testSysNum1 | testSysNum2;
            //var sysResult1 = testSysNum3 & testSysNum1;
            //var sysResult2 = testSysNum3 & testSysNum2;
            //if (sysResult1 == testSysNum1)
            //{
            //    Console.WriteLine("当前有testSysNum1的权限");
            //}

            //if (sysResult2 == testSysNum2)
            //{
            //    Console.WriteLine("当前有testSysNum2的权限");
            //}


            //9.this关键字的用法和索引器

            //var seniorEnginer = new SeniorEnginer(10, "牛逼");

            //0>声明实体
            User user = new User();
            user.ID = 1;
            user.UserName = "liupeng";

            //第【一】种用法:this用作索引器 public object this[string name]{……}
            user["UserID"] = 1;
            Console.WriteLine("第【一】种用法:this用作索引器");

            //第【二】种用法:this用作参数传递 user.Say(this);
            Console.WriteLine("第【二】种用法:this用作参数传递");
            user.Said();

            //第【三】种用法:this() public VIP:this(){   }
            Vip vip = new Vip("yezi");
            vip.Said();
            Console.WriteLine("第【三】种用法:this()");

            //第【四】种用法： this扩展VIP类 public static Sing(this User user){……}
            Console.WriteLine("第【四】种用法： this扩展VIP类");
            user.Sing();


            Console.Read();

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


    /// <summary>
    // 牛逼的程序猿
    /// </summary>
    public class SeniorEnginer
    {
        public int Level;
        public string Skill;

        public SeniorEnginer(int level)
        {
            Level = level;
            Console.WriteLine("我的级别是：" + level);
        }

        public SeniorEnginer(int level, string skill) : this(4)
        {
            Level = level;
            Skill = skill;
            Console.WriteLine("我的级别是：" + level + ";我的技术很" + skill);
        }
    }

    /// <summary>
    /// 普通用户
    /// </summary>
    public class User
    {
        /// <summary>
        /// 全局变量
        /// </summary>
        private readonly Dictionary<string, object> _dictInfo = null;

        /// <summary>
        /// 构造器
        /// </summary>
        public User()
        {
            _dictInfo = new Dictionary<string, object>();
        }

        /// <summary>
        /// 构造函数重载
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="userName"></param>
        public User(int userId, string userName)
        {
            this.UserName = userName;
            this.ID = userId;
        }

        /// <summary>
        /// this，第【1】种用法，索引器
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public object this[string name]
        {
            get { return _dictInfo[name]; }
            set { _dictInfo[name] = value; }
        }


        /// <summary>
        /// 编号
        /// </summary>
        public int ID { get; set; }


        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// this第【2】种用法，当做参数传递
        /// </summary>
        public void Said()
        {
            new Vip().Say(this);
        }
    }

    /// <summary>
    /// 会员
    /// </summary>
    public class Vip : User
    {
        /// <summary>
        /// 积分
        /// </summary>
        public int Integral { get; set; }

        /// <summary>
        /// 构造函数
        /// </summary>
        public Vip()
        {
            ID = 520;
            Integral = 1000;
        }

        /// <summary>
        /// this第【3】种用法，通过this()调用无参构造函数
        /// </summary>
        /// <param name="userName"></param>
        public Vip(string userName)
            : this()
        {
            this.UserName = userName;
        }

        /// <summary>
        /// 构造函数重载
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="userName"></param>
        public Vip(int userId, string userName)
            : base(userId, userName)
        {
        }

        /// <summary>
        ///Say方法
        /// </summary>
        /// <param name="user"></param>
        public void Say([Lcq] User user)
        {
            Console.WriteLine(string.Format("嗨，大家好！我的编号是{0}，大家可以叫我{1}！", user.ID, user.UserName));
        }
    }

    /// <summary>
    /// 静态类，来扩展User类
    /// </summary>
    public static class Helper
    {
        /// <summary>
        /// 第【4】种用法： this扩展User类
        /// </summary>
        /// <param name="user"></param>
        public static void Sing(this User user)
        {
            Console.WriteLine(string.Format("嗨，大家好！我的编号是{0}，大家可以叫我{1}！", user.ID, user.UserName));
        }
    }

    /// <summary>
    /// 特性类：指定特性仅适用于方法和方法的参数
    /// </summary>
    [System.AttributeUsage(AttributeTargets.Method | AttributeTargets.Parameter)]
    public class LcqAttribute : System.Attribute
    {
    }
}