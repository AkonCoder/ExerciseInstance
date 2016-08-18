using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Infruesture
{
    internal class Program
    {
        public delegate void ShowTimes();

        public const int DoNum = 10000;
        public const int NumC = NumD*10;
        private const int NumD = 10;
        // ReSharper disable once StaticMemberInitializerReferesToMemberBelow
        private static readonly int NumA = NumB*10;
        private static readonly int NumB = 10;

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

            ////var seniorEnginer = new SeniorEnginer(10, "牛逼");

            ////0>声明实体
            //User user = new User();
            //user.ID = 1;
            //user.UserName = "liupeng";

            ////第【一】种用法:this用作索引器 public object this[string name]{……}
            //user["UserID"] = 1;
            //Console.WriteLine("第【一】种用法:this用作索引器");

            ////第【二】种用法:this用作参数传递 user.Say(this);
            //Console.WriteLine("第【二】种用法:this用作参数传递");
            //user.Said();

            ////第【三】种用法:this() public VIP:this(){   }
            //Vip vip = new Vip("yezi");
            //vip.Said();
            //Console.WriteLine("第【三】种用法:this()");

            ////第【四】种用法： this扩展VIP类 public static Sing(this User user){……}
            //Console.WriteLine("第【四】种用法： this扩展VIP类");
            //user.Sing();

            //10.String与StringBuild的区别
            //GetRunningTime(GetStrByString, "String");
            //GetRunningTime(GetStrByStringBuild, "StringBuild");

            //11.字符串的常用方法（Length、ToCharArray、Replace等等）
            //var strName = "liupeng is a diaosi Coder";
            ////可见计算字符串的长度时候，空白字符计算在内
            //Console.WriteLine("当前字符串的长度为：" + strName.Length);
            //var strCharArray = strName.ToCharArray();
            //foreach (var t in strCharArray)
            //{
            //    Console.WriteLine("当前的字符数组是：" + t + "\n");
            //}


            //（1） == 对值类型则是完全判断两个值的代数值是否相等，其他一概不管。
            //（2） == 对引用类型则用于比较两个引用类型的对象是否是对于同一个对象的引用，但需要注意的是，对于
            // 字符串引用类型，由于字符串在分配内存空间的时候，存在字符串驻留机制。
            // 字符串驻留是CLR提供的一种提高性能的对待字符串的机制，它保证在一个进程内的某个字符串在内存中只分配一次;
            // 所以secondStr与thirdStr实质上是指向同一个对象的引用。

            var firstNum = 10;
            double secondNum = 10;
            var thirdNum = 10;
            var firstStr = "LIUPENG";
            var secondStr = "liupeng";
            var thirdStr = "liupeng";
            //if (firstNum == secondNum)
            //{
            //    Console.WriteLine("int类型的数值与double类型的==比较是相等的！");
            //}

            //if (thirdStr == secondStr)
            //{
            //    Console.WriteLine("只要我们字符一样，==比较也是一样的！");
            //}

            //（3） Equal 对于值类型女而言,表现为只要类型相同并且值相等,那么就相等
            //（4） Equal 对于引用类型而言，表现为
            //if (!firstNum.Equals(secondNum))
            //{
            //    Console.WriteLine("对于类型不同，值相同的数值，用Equal比较是不相同的！");
            //}

            //if (！thirdStr.Equals(secondStr))
            //{
            //    Console.WriteLine("对于引用类型，只要二者引用相同，就是相等的！");
            //}

            //ReferenceEquals是Object的静态方法，用于比较两个引用类型的对象是否是对于同一个对象的引用。
            //对于值类型它总是返回false（值类型在封装成相应的值类时总是单独开辟空间，如2个相同的int值在栈中就占2块不同的空间，和字符串是不同的）
            //if (object.ReferenceEquals(secondStr, thirdStr))
            //{
            //    Console.WriteLine("ReferenceEquals对于引用类型，只要二者引用相同，就是相等的！");
            //}

            //if (!object.ReferenceEquals(firstNum, thirdNum))
            //{
            //    Console.WriteLine("ReferenceEquals对于值类型，分配的内存地址是不同的，所以一直不相等！");
            //}

            //字符串区分大小写进行比较
            //if (!firstStr.Equals(secondStr))
            //{
            //    Console.WriteLine("分了大小写，我们不一样，不要跟我套近乎！");
            //}
            ////忽略大小写
            //if (firstStr.Equals(secondStr, StringComparison.OrdinalIgnoreCase))
            //{
            //    Console.WriteLine("我们忽略了大小写是一样的!不要觉得自己牛逼！");
            //}

            //12.字符串截取（substring、Contains、Replace等）
            //var sourceStr = "liupeng is a diaosi Coder";
            //12.1 sunString强调从哪开始，截取长度为多少
            //var newStr = sourceStr.Substring(0, 7);
            //Console.WriteLine("新的字符串为：" + newStr);
            //var replaceStr = sourceStr.Replace("Coder", "Boy");
            //Console.WriteLine("Replace以后的字符串为：" + replaceStr);
            //var containBool = sourceStr.Contains("diaosi");
            //Console.WriteLine(containBool ? "具有屌丝气质成立" : "恭喜您，已脱离屌丝气质");
            //var joinStr = "and he is a man";
            //var outPutJoinStr = string.Join(",", sourceStr, joinStr);
            //Console.WriteLine("join以后的气质为：" + outPutJoinStr);

            //13.结构体和类的区别以及使用
            //13.1 ——结构体中不可以直接为字符赋值，而在类中可以直接给字段赋值
            //13.2 ——隐式的无参数的构造函数在结构中无论如何都是存在的,所以程序员不能手动的为结构添加1个无参数的构造函数.
            //在结构体的构造函数中,必须要为结构体的所有字段赋值
            //13.3——在结构体的构造函数中我们为属性赋值,不认为是在对字段赋值,所以我们在构造函数中要直接为字段赋值.
            //13.4—— 创建结构体对象可以不使用new关键字.直接声明1个变量就可以.但是这样的话,结构体对象中的字段是没有初始值的,所以在使用字段之前必须要为这个字段赋值.
            //什么时候用类和结构体?
            /*我们知道,结构存储在栈中,而栈有1个特点,就是空间较小,但是访问速度较快,堆空间较大,但是访问速度相对较慢.所以当我们描述1个轻量级对象的时候,可以将其定义为结构来提高效率.比如点,矩形，颜色,这些对象是轻量级的对象,因为描述他们,只需要少量的字段。
             * 当描述1个重量级对象的时候，我们知道类的对象是存储在堆空间中的,我们就将重量级对象定义为类. 
             * 他们都表示可以包含数据成员和函数成员的数据结构。与类不同的是，结构是值类型并且不需要堆分配。
             * 结构类型的变量直接包含结构的数据，而类类型的变量包含对数据的引用（该变量称为对象）。
             * struct 类型适合表示如点、矩形和颜色这样的轻量对象。尽管可能将一个点表示为类，但结构在某些方案中更有效。
             * 在一些情况下，结构的成本较低。例如，如果声明一个含有 1000 个点对象的数组，则将为引用每个对象分配附加的内存。
             * 所以结构适合表示1个轻量级对象.
             */

            //14.子类调用父类的构造函数
            //15.HashTable的使用
            // 创建一个Hashtable实例
            //Hashtable ht = new Hashtable();

            //// 添加keyvalue键值对
            //ht.Add("A", "1");
            //ht.Add("B", "2");
            //ht.Add("C", "3");
            //ht.Add("D", "4");
            //15.1 HashTable中不允许存在相同的Key，此处会抛错
            //ht.Add("D", "4");

            // 遍历哈希表
            //foreach (DictionaryEntry de in ht)
            //{
            //    Console.WriteLine("Key -- {0}; Value --{1}.", de.Key, de.Value);
            //}

            //// 哈希表排序
            //ArrayList akeys = new ArrayList(ht.Keys);
            //akeys.Sort();
            //foreach (string skey in akeys)
            //{
            //    Console.WriteLine("{0, -15} {1, -15}", skey, ht[skey]);

            //}

            // 判断哈希表是否包含特定键,其返回值为true或false
            //if (ht.Contains("A"))
            //    Console.WriteLine(ht["A"]);

            // 给对应的键赋值
            //ht["A"] = "你好";

            //// 移除一个keyvalue键值对
            //ht.Remove("C");

            //// 遍历哈希表
            //foreach (DictionaryEntry de in ht)
            //{
            //    Console.WriteLine("Key -- {0}; Value --{1}.", de.Key, de.Value);
            //}

            //// 移除所有元素
            //ht.Clear();

            //// 此处将不会有任何输出
            //Console.WriteLine(ht["A"]);


            //16.装箱和拆箱
            //object obj = 4;
            //int objToNum = (int) obj;
            //Console.WriteLine("拆箱过后的类型为：" + objToNum.GetType());
            //Console.WriteLine("拆箱过后的值为：" + objToNum);

            //int oldNum = 10;
            //object toObj = oldNum;
            //Console.WriteLine("装箱过后的类型为：" + toObj.GetType());
            //Console.WriteLine("装箱过后的值为：" + toObj);

            //Point p1 = new Point(10, 10);

            //Point p2 = new Point(20, 20);

            ////调用ToString不装箱，这里ToString是一个虚方法  
            //Console.WriteLine(p1.ToString());

            ////GetType是一个非虚方法，p1要装箱  
            //Console.WriteLine(p1.GetType());

            ////这里调用的是public int CompareTo(Point p)  
            ////p2不会装箱  
            //Console.WriteLine(p1.CompareTo(p2));

            ////p1要装箱，这就是将未装箱的值类型转为类型的某个接口时  
            //IComparable c = p1;

            //Console.WriteLine(c.GetType());

            ////这里调用的是public Int32 CompareTo(Object o)，  
            ////而且c本来就是一个引用，因此不装箱了  
            //Console.WriteLine(p1.CompareTo(c));

            ////这里调用的是c的CompareTo方法，参数是object型的  
            ////所以要对p2装箱  
            //Console.WriteLine(c.CompareTo(p2));

            ////对c拆箱，并复制值到p2中  
            //p2 = (Point)c;

            //Console.WriteLine(p2.ToString());  

            //17.File类的使用
            //创建某个路径下的文件
            //var testFilePath = @"D:\tempStudy\1.txt";
            //File.Create(testFilePath);
            ////删除某个路径下的文件
            //File.Delete(testFilePath);
            //var isExistFile = File.Exists(testFilePath);
            //Console.WriteLine(isExistFile ? "当前路径存在对应的文件" : "当前路径不存在对应的文件");
            ////读取文档的内容
            //var text = File.ReadAllLines(testFilePath, Encoding.Default);
            ////向文档中追加内容
            //var newUserContent = "世界真美好！";
            //File.AppendAllText(testFilePath, newUserContent);

            string path = @"D:\1";
            Directory.CreateDirectory(path);//创建这个文件夹1,如果这个路径中有这个文件夹,不会覆盖.

            Console.Read();

            Console.ReadKey();
        }

        /// <summary>
        ///     获取随机数
        /// </summary>
        /// <param name="minNum"></param>
        /// <param name="maxNum"></param>
        /// <param name="len"></param>
        /// <returns></returns>
        public static double GetRandomNum(double minNum, double maxNum, int len)
        {
            var bytes = new byte[4];
            var rngObj = new RNGCryptoServiceProvider();
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

        /// <summary>
        ///     获取str使用StringBuild
        /// </summary>
        /// <returns></returns>
        public static void GetStrByStringBuild()
        {
            var strNameKey = "liupeng";
            var strName = new StringBuilder();
            for (var i = 0; i < DoNum; i++)
            {
                strName.Append(strNameKey);
            }
        }

        /// <summary>
        ///     获取Str使用String
        /// </summary>
        /// <returns></returns>
        public static void GetStrByString()
        {
            var strName = "";
            var strNameKey = "liupeng";
            for (var i = 0; i < DoNum; i++)
            {
                strName += strNameKey;
            }
        }

        /// <summary>
        ///     获取拼接字符串共耗费的时间
        /// </summary>
        /// <param name="func"></param>
        /// <param name="operationName"></param>
        /// <returns></returns>
        public static void GetRunningTime(ShowTimes func, string operationName)
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            func.Invoke();
            stopWatch.Stop();
            var seconds = stopWatch.Elapsed;
            Console.WriteLine("{0}拼接字符串所消耗的时间为：{1}", operationName, seconds);
        }

        //子类调用父类的构造函数
        public class SeniorEnginerOfSon : SeniorEnginer
        {
            public SeniorEnginerOfSon(int level) : base(level)
            {
            }

            public SeniorEnginerOfSon(int level, string skill) : base(level, skill)
            {
            }
        }
    }

    public struct GetUserName
    {
        public int Age;
        public string UserName;

        public GetUserName(string name, int age)
        {
            UserName = name;
            Age = age;
        }
    }


    // 牛逼的程序猿
    /// <summary>
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
    ///     普通用户
    /// </summary>
    public class User
    {
        /// <summary>
        ///     全局变量
        /// </summary>
        private readonly Dictionary<string, object> _dictInfo;

        /// <summary>
        ///     构造器
        /// </summary>
        public User()
        {
            _dictInfo = new Dictionary<string, object>();
        }

        /// <summary>
        ///     构造函数重载
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="userName"></param>
        public User(int userId, string userName)
        {
            UserName = userName;
            ID = userId;
        }

        /// <summary>
        ///     this，第【1】种用法，索引器
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public object this[string name]
        {
            get { return _dictInfo[name]; }
            set { _dictInfo[name] = value; }
        }

        /// <summary>
        ///     编号
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        ///     用户名
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        ///     this第【2】种用法，当做参数传递
        /// </summary>
        public void Said()
        {
            new Vip().Say(this);
        }
    }

    /// <summary>
    ///     会员
    /// </summary>
    public class Vip : User
    {
        /// <summary>
        ///     构造函数
        /// </summary>
        public Vip()
        {
            ID = 520;
            Integral = 1000;
        }

        /// <summary>
        ///     this第【3】种用法，通过this()调用无参构造函数
        /// </summary>
        /// <param name="userName"></param>
        public Vip(string userName)
            : this()
        {
            UserName = userName;
        }

        /// <summary>
        ///     构造函数重载
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="userName"></param>
        public Vip(int userId, string userName)
            : base(userId, userName)
        {
        }

        /// <summary>
        ///     积分
        /// </summary>
        public int Integral { get; set; }

        /// <summary>
        ///     Say方法
        /// </summary>
        /// <param name="user"></param>
        public void Say([Lcq] User user)
        {
            Console.WriteLine("嗨，大家好！我的编号是{0}，大家可以叫我{1}！", user.ID, user.UserName);
        }
    }

    /// <summary>
    ///     静态类，来扩展User类
    /// </summary>
    public static class Helper
    {
        /// <summary>
        ///     第【4】种用法： this扩展User类
        /// </summary>
        /// <param name="user"></param>
        public static void Sing(this User user)
        {
            Console.WriteLine("嗨，大家好！我的编号是{0}，大家可以叫我{1}！", user.ID, user.UserName);
        }
    }

    /// <summary>
    ///     特性类：指定特性仅适用于方法和方法的参数
    /// </summary>
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Parameter)]
    public class LcqAttribute : Attribute
    {
    }

    internal struct Point : IComparable
    {
        private readonly int x;
        private readonly int y;

        public Point(int x, int y)
        {
            this.x = x;

            this.y = y;
        }

        public int CompareTo(object o)
        {
            if (GetType() != o.GetType())
            {
                throw new ArgumentException("o is not Point.");
            }

            return CompareTo((Point) o);
        }

        public override string ToString()
        {
            return string.Format("{0},{1}", x, y); //这里装箱两次，不知道有没好办法。  
        }

        public int CompareTo(Point p)
        {
            return Math.Sign(Math.Sqrt(x*x + y*y) - Math.Sqrt(p.x*p.x + p.y*p.y));
        }
    }
}