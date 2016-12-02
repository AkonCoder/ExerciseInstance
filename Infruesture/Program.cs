using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using Infruesture.Redis;
using Newtonsoft.Json;

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
            //var tryParseResult = int.TryParse("4", out numResult);
            //Console.WriteLine(tryParseResult);

            //转换空字符串的结果为
            //int outResult;
            ////Console.WriteLine(int.Parse(emptyNum));
            //Console.WriteLine(int.TryParse(emptyNum, out  outResult));
            //Console.WriteLine( Convert.ToInt32(emptyNum));

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

            int firstNum = 10;
            double secondNum = 10;
            int thirdNum = 10;
            string firstStr = "LIUPENG";
            string secondStr = "liupeng";
            string thirdStr = "liupeng";

            //测试题目1：
            //object m1 = 1;
            //object m2 = 1;
            //Console.WriteLine(m1==m2);
            //Console.WriteLine(m1.Equals(m2));

            //测试题目2：
            //string str1 = "ZhangSan";
            //string str2 = "ZhangSan";
            //string str3 = new string(new char[] { 'z', 'h' });
            //string str4 = new string(new char[] { 'z', 'h' });

            //Console.WriteLine("str1 == str2  " + (str1 == str2).ToString());
            //Console.WriteLine("str1 Equals str2  " + str1.Equals(str2));

            //Console.WriteLine("str3 == str4 " + (str3 == str4).ToString());
            //Console.WriteLine("str3 Equals str4 " + str3.Equals(str4)); 


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

            //var path = @"D:\1";
            //Directory.CreateDirectory(path); //创建这个文件夹1,如果这个路径中有这个文件夹,不会覆盖.

            //var showText = StramWriteFile();
            //Console.WriteLine("当前读取的内容为：" + showText);


            //农历日月
            //var result = ChineseLunisolarCalendar.GetChineseDateTime(DateTime.Now);
            //Console.WriteLine("今天是农历：" + result);

            //var result = SolarToChineseLunisolarDate(DateTime.Now);
            //Console.WriteLine("今天是农历：" + result);

            //var month = DateTime.Now.Month;
            //var day = DateTime.Now.Day;
            //var currentDate = Convert.ToDateTime( month + "-" + day);
            //Console.WriteLine("今天是日期为：" + currentDate);

            //var currentShortDate = DateTime.Now.Date.ToShortDateString();
            //Console.WriteLine("当前短日期时间为：" + currentShortDate);

            //var dateString = DateTime.Now.AddDays(0).Date.ToShortDateString() + " " + "08:20";
            //var showDate = Convert.ToDateTime(dateString);
            //Console.WriteLine("当前转换的日期为："+ showDate);

            //var lunnar = new ChineseLunisolarCalendar();
            //var lunnarYear = lunnar.GetYear(DateTime.Now);
            //var lunnarMonth = lunnar.GetMonth(DateTime.Now);
            //var lunnarDay = lunnar.GetDayOfMonth(DateTime.Now);
            //var isLeapYear = lunnar.IsLeapYear(DateTime.Now.Year);
            //var lunnarDateTemp = new DateTime(lunnarYear, lunnarMonth, lunnarDay);
            //var lunnarDate = ChineseCalendarInfo.GetDateFromLunarDate(lunnarDateTemp, isLeapYear);
            //Console.WriteLine("当前转换的日期为：" + lunnarDate);

            //var timeNode = "8:20";
            //var timeContains = timeNode.Split(':');
            //var sendTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day,
            //    Convert.ToInt32(timeContains[0]), Convert.ToInt32(timeContains[1]), 0);
            //Console.WriteLine("当前的时间为：" + sendTime);
            //var timeShow = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 10, 0, 0);
            //Console.WriteLine("当前的日期为：" + timeShow);

            //var date =new DateTime(2016,8,8);
            //var showTime = date.ToString("M月d日", DateTimeFormatInfo.InvariantInfo);

            //Console.WriteLine(showTime);

            //使用yield return
            //MusicTitles titles = new MusicTitles();
            //foreach (string title in titles)
            //{
            //    Console.WriteLine(title);
            //}

            //Console.WriteLine();

            //foreach (string title in titles.Reverse())
            //{
            //    Console.WriteLine(title);
            //}

            //Console.WriteLine();

            //foreach (string title in titles.Subset(2, 2))
            //{
            //    Console.WriteLine(title);
            //    Console.ReadLine();
            //}

            //异步调用
            //var info = "I am king";
            //var sendMessage = new WriteMessageDelegate(WriteMessage);
            //sendMessage.BeginInvoke(info,
            //    item =>
            //    {
            //        if (item == null)
            //        {
            //            throw new ArgumentException("wrong");
            //        }
            //        var del = (WriteMessageDelegate) ((AsyncResult) item).AsyncDelegate;
            //        del.EndInvoke(item);
            //    }, null);

            //Console.WriteLine("异步打印还没有出来");
            //Console.WriteLine("我还在等");

            //#region string类型对于==、Equal、ReferenceEqual的判断

            //Console.WriteLine("****************string类型对于==、Equal、ReferenceEqual的判断*****************");

            //var str1 = new string(new[] {'a'});
            //var str2 = new string(new[] {'a'});
            //Console.WriteLine("直接用==比较相等吗？" + (str1 == str2));
            //Console.WriteLine("直接用Equal比较相等吗？" + str1.Equals(str2));
            //Console.WriteLine("两个字符串的引用相等吗？" + ReferenceEquals(str1, str2));

            //Console.WriteLine("==============我是分割线");

            //var firstName = "AkonCoder";
            //var secondName = "AkonCoder";
            //Console.WriteLine("直接用==比较相等吗？" + (firstName == secondName));
            //Console.WriteLine("直接用Equal比较相等吗？" + firstName.Equals(secondName));
            //Console.WriteLine("两个字符串的引用相等吗？" + ReferenceEquals(firstName, secondName));

            //#endregion

            //#region 值类型对于==、Equual、ReferenceEqual的判断

            //Console.WriteLine("****************值类型对于==、Equual、ReferenceEqual的判断*****************");
            //var num1 = 2;
            //var num2 = 2;
            //Console.WriteLine("当前两个数值比较的值为：" + (num1 == num2));
            //Console.WriteLine("当前两个值用Equal比较的值为：" + num1.Equals(num2));
            //Console.WriteLine("当前两个值用ReferenceEqual比较的值为：" + ReferenceEquals(num1, num2));

            //#endregion

            //#region 引用类型对于==、Equual、ReferenceEqual的判断

            //Console.WriteLine("****************引用类型对于==、Equual、ReferenceEqual的判断*****************");

            //var oneName = new MyName();
            //var twoName = new MyName();
            //Console.WriteLine("引用类型对于==比较的结果为：" + (oneName == twoName));
            //Console.WriteLine("引用类型对于Equal比较的结果为：" + oneName.Equals(twoName));
            //Console.WriteLine("应用类型对于ReferenceEqual比较的结果为：" + ReferenceEquals(oneName, twoName));


            ////Console.WriteLine("当前Class的类型为：" + typeof (MyName));
            ////Console.WriteLine("获取当前对象的Type" + oneName.GetType());

            //#endregion

            //PropertyInfo[] props = null;
            //var type = typeof (MyName);
            //var obj = Activator.CreateInstance(type);
            //props = type.GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.Default);
            //for (var i = 0; i < props.Length; i++)
            //{
            //    Console.WriteLine(props[i]);
            //}

            //写入redis数据
            //var result = WriteRedisData();
            //Console.WriteLine(result ? "写入Redis成功 " : "写入Redis失败");

            //var isOpenWechatOrderPush = ConfigurationManager.AppSettings["IsOpenWechatOrderPush"];
            //if (isOpenWechatOrderPush == "true")
            //{
            //    Console.WriteLine("微信收单账单推送开关打开了");
            //}
            //else
            //{
            //    Console.WriteLine("微信收单账单推送开关关闭了");
            //}

            //var userName = TestStaticClass.UserName;
            //Console.WriteLine("默认的用户名为：" + userName);
            //var couponUrl = GetShortUrl(397, 6757);
            //Console.WriteLine("当前领优惠券的地址为:" + couponUrl);

            //log4net 测试

            //var logInfo = "这是日志";

            //for (var i = 0; i < 100; i++)
            //{
            //    LogHelper.Info(logInfo + "【" + i + "】");
            //}
            //Console.WriteLine("打印日志完成！");

            //引用mysoft.Core组件记录日志
            //var mailAddress = "1013630498@qq.com";

            //for (int i = 0; i < 10; i++)
            //{
            //    SimpleLog.Instance.WriteLogForFile("记录日志",logInfo);
            //    SimpleLog.Instance.WriteLogWithSendMail("记录日志", mailAddress);
            //}
            //Console.WriteLine("记录日志完成！");

            //Random.Next() 返回非负随机数；
            //Random.Next(Int) 返回一个小于所指定最大值的非负随机数
            //Random.Next(Int,Int) 返回一个指定范围内的随机数，例如(-100，0)返回负数

            //var bytes = new byte[4];
            //var rngObj = new RNGCryptoServiceProvider();
            //rngObj.GetBytes(bytes);
            //var seed = BitConverter.ToInt32(bytes, 0);
            //var numRandom = new Random();
            //var numSeedRandom = new Random(seed); 

            ////var numResult = numRandom.Next();
            ////var numGridResult = numRandom.Next(1000);

            ////http://www.cnblogs.com/imjustice/p/random_in_dotNet.html
            ////Console.WriteLine("返回的非负随机数为：" + numResult);
            ////Console.WriteLine("返回小于指定数的随机数为："+ numGridResult);
            //for (int i = 0; i < 1000; i++)
            //{
            //    var numSpanResult = numRandom.Next(1, 10000);
            //    Console.WriteLine("返回指定范围的随机数为：" + numSpanResult);
            //}


            ////产生0~1之间的随机数
            //var numDoubleResult = numRandom.NextDouble();
            //Console.WriteLine("产生的随机小数为："+ numDoubleResult);
            //Console.WriteLine(Environment.TickCount);
            //var maxNum = 2.6;
            //var minNum = 2.40;
            //var len = 4;
            //for (int i = 0; i < 1000; i++)
            //{
            //    var numDoubleResultByRule = Math.Round(numRandom.NextDouble() * (maxNum - minNum) + minNum, len);
            //    Console.WriteLine("产出规定长度的随机小数为：" + numDoubleResultByRule);
            //}


            //dynamic 类型
            //dynamic dyn = 5;
            //Console.WriteLine(dyn.GetType());
            //dyn = "test string";
            //Console.WriteLine(dyn.GetType());
            //dynamic startIndex = 2;
            //string substring = dyn.Substring(startIndex);
            //Console.WriteLine(substring);
            //Console.Read();

            //当前日期是星期几
            //var weekDate = DateTime.Now.AddDays(5).DayOfWeek.ToString();
            //Console.WriteLine("今天是："+ weekDate);

            //Console.WriteLine(Convert.ToBoolean(3));
            //GetWeekBirthdayUsers(397);

            //1.json序列化和反序列化
            //var withdrawingStatus = new Dictionary<string, string>
            //{
            //    {"4", "提现中"},
            //    {"5", "提现成功"},
            //    {"6", "提现失败"}
            //};
            ////微信收款交易状态值
            //var weChatBillingStatus = new Dictionary<string, string>
            //{
            //    {"1", "交易中"},
            //    {"4", "结算中"},
            //    {"1000", "交易成功"}
            //};

            ////手机橱窗交易状态值
            //var mobileShowCaseBillingStatus = new Dictionary<string, string>
            //{
            //    {"1", "待付款"},
            //    {"4", "待收货"},
            //    {"1000", "交易成功"}
            //};

            //var withdrawingAccountStatus = new Dictionary<string, string>
            //{
            //    {"0", "审核中"},
            //    {"1", "已认证"}
            //};

            //var businessType = new Dictionary<string, string>
            //{
            //    {"2", "微信收款"},
            //    {"4", "手机橱窗"}
            //};

            //var summaryStatus = new List<AccountBookStatusList>();
            //var firstStatus = new AccountBookStatusList
            //{
            //    Key = "withdrawingStatus",
            //    Value = withdrawingStatus
            //};
            //var secondStatus = new AccountBookStatusList
            //{
            //    Key = "weChatBillingStatus",
            //    Value = weChatBillingStatus
            //};
            //var thirdStatus = new AccountBookStatusList
            //{
            //    Key = "mobileShowCaseBillingStatus",
            //    Value = mobileShowCaseBillingStatus
            //};
            //var forthStatus = new AccountBookStatusList
            //{
            //    Key = "withdrawingAccountStatus",
            //    Value = withdrawingAccountStatus
            //};
            //var fifthStatus = new AccountBookStatusList
            //{
            //    Key = "billingBusinessType",
            //    Value = businessType
            //};

            //summaryStatus.Add(firstStatus);
            //summaryStatus.Add(secondStatus);
            //summaryStatus.Add(thirdStatus);
            //summaryStatus.Add(forthStatus);
            //summaryStatus.Add(fifthStatus);

            //var serilizeStatus = JsonConvert.SerializeObject(summaryStatus);

            //Console.WriteLine("系列化以后的状态值为：" + serilizeStatus);

            //var deserlizeStatus =
            //    JsonConvert.DeserializeObject<List<AccountBookStatusList>>(serilizeStatus);
            //var withdrawingStatusShow = deserlizeStatus[0];

            //Console.WriteLine("反序列化以后的状态值为：" + withdrawingStatusShow);

            //校验只能输入数字、字母、中文、—、_
            //Console.WriteLine("请输入名称");
            //var checkName = Console.ReadLine();
            //var regExp = new Regex(@"^[a-zA-Z0-9_\-\u4e00-\u9fa5]+$");
            //if (checkName != null && regExp.IsMatch(checkName))
            //{
            //    Console.WriteLine("名称有效");
            //}
            //else
            //{
            //    Console.WriteLine("名称无效");
            //}
            //var num = Math.Round(12.4464,2);
            ////var strNum = "+3.2";
            ////var showNum = Convert.ToInt32(strNum);
            //Console.WriteLine("当前的数字为：" + num);

            //Console.WriteLine("是否是合法的有效数字:"+ Helper.IsNumber("213.2",3,1));

            //Regex reg = new Regex(@"^(\-|\+)?\d+(\.\d+)?$");
            //var isNum = reg.IsMatch("-/2.333");
            //Console.WriteLine("是否是合法的有效数字:" + isNum);

            //var regTestSphericalens = new Regex(@"^((180)|([1-9]\d{0,1})|(1[0-7]\d{1})|(0))$");
            //var result = regTestSphericalens.IsMatch("0");
            //Console.WriteLine("是否匹配:"+ result);

            //ResponseModel responseModel;
            //Console.WriteLine("是否超过最大值：" + CheckMaxintegral(2,99,out responseModel));


            //101.1 测试C# 延迟加载，.Net4.0以后提供延迟加载的东西，对象在使用时候加载

            //var lazyStr = new Lazy<string>(LazyClass.GetLazyPerson);
            //Console.WriteLine(lazyStr.IsValueCreated);
            //Console.WriteLine(lazyStr.Value);
            //Console.WriteLine(lazyStr.IsValueCreated);

            //101.1  子对象延迟加载
            //父亲由于时间不足，只能延迟加载去看多个儿子的showtime
            //var parent = new Parent(4);
            //Console.WriteLine("parent see show is begin:");
            //Console.WriteLine(parent.ShowListTitle.IsValueCreated);
            //foreach (var item in parent.ShowListTitle.Value)
            //{
            //    Console.WriteLine("my age is {0}, my show is {1}", item.Age, item.ShowName);
            //}
            //Console.WriteLine(parent.ShowListTitle.IsValueCreated);]

            //测试时间格式
            const string dateTimeStr = "0001-01-01";
            var result = DateTime.Now;
            var searchDate = DateTime.TryParse(dateTimeStr,out result);
            if (searchDate)
            {
                Console.WriteLine("this is a really Datetime");
            }

            var startDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);
            const int expireDays = 7;
            var endDate = startDate.AddDays(expireDays).AddDays(1).AddSeconds(-1);
            Console.WriteLine(string.Format("开始时间为：{0},结束时间为：{1}",startDate,endDate));
            Console.Read();
            Console.ReadKey();
        }


        public class  NickNameAttribute:Attribute
        {
            public NickNameAttribute(string bigName,string smallName)
            {
                BigName = bigName;
                SmallName = smallName;
            }

            /// <summary>
            /// 大名字
            /// </summary>
            public string BigName { get; set; }

            /// <summary>
            /// 小名字
            /// </summary>
            public string SmallName { get; set; }
        }

      public class NameShow
      {
          [NickName("ZS","zhangsan")]
          public string Zhangsan { get; set; }

          [NickName("LS","lisi")]
          public string Lisi { get; set; }
      }

        public class NickNameConfig
        {
            public string BigName { get; set; }
            public string SmallName { get; set; }
        }

        /// <summary>
        ///     校验最大为整数
        /// </summary>
        /// <param name="integralLength">整数位数</param>
        /// <param name="currentNum">当前数值</param>
        /// <param name="responseModel">返回结果</param>
        /// <returns></returns>
        public static bool CheckMaxintegral(int integralLength, int currentNum, out ResponseModel responseModel)
        {
            //1.根据当前最大位整数位数，产生最大整数
            var maxNumAppend = new StringBuilder();
            for (int i = 0; i < integralLength; i++)
            {
                maxNumAppend.Append(9);
            }
            int maxNum = Convert.ToInt32(maxNumAppend.ToString());
            if (currentNum <= maxNum)
            {
                responseModel = null;
                return false;
            }
            responseModel = new ResponseModel
            {
                Code = 0
            };
            return true;
        }

        public static void GetWeekBirthdayUsers(int accId)
        {
            var strSql = new StringBuilder();
            DateTime dt = DateTime.Now;

            //最近7天生日会员

            //阳历日期
            var strDate = new StringBuilder();
            DateTime lastDay = dt.AddDays(7);
            int lastMonth = lastDay.Month;
            if (lastMonth < dt.Month)
            {
                lastMonth += 12;
            }

            if (dt.Month == lastMonth)
            {
                strDate.Append(string.Format(" bdMonth={0}", dt.Month));
                strDate.Append(string.Format(" and bdDay between {0} and {1}", dt.Day, lastDay.Day));
            }
            else if (lastMonth - dt.Month == 1)
            {
                DateTime tmpDate = dt.AddMonths(1);
                int endDay =
                    Convert.ToDateTime(string.Format("{0}-{1}-{2}", tmpDate.Year, tmpDate.Month, 1)).AddDays(-1).Day;
                strDate.Append(string.Format(" (bdMonth={0} and bdDay between {1} and {2})", dt.Month, dt.Day, endDay));
                strDate.Append(string.Format(" or (bdMonth={0} and bdDay between {1} and {2})", lastDay.Month, 1,
                    lastDay.Day));
            }
            else if (lastMonth - dt.Month == 2)
            {
                DateTime tmpDate = dt.AddMonths(1);
                int endDay =
                    Convert.ToDateTime(string.Format("{0}-{1}-{2}", tmpDate.Year, tmpDate.Month, 1)).AddDays(-1).Day;
                DateTime midDay = dt.AddMonths(1);
                int midDayEndDay =
                    Convert.ToDateTime(string.Format("{0}-{1}-{2}", midDay.Year, midDay.Month, 1)).AddDays(-1).Day;
                strDate.Append(string.Format(" (bdMonth={0} and bdDay between {1} and {2})", dt.Month, dt.Day, endDay));
                strDate.Append(string.Format(" or (bdMonth={0} and bdDay between {1} and {2})", midDay.Month, 1,
                    midDayEndDay));
                strDate.Append(string.Format(" or (bdMonth={0} and bdDay between {1} and {2})", lastDay.Month, 1,
                    lastDay.Day));
            }

            //农历日期
            var strLunarDate = new StringBuilder();
            Helper.ChinaDate lunarDate = Helper.ConvertToLunisolar(dt);
            Helper.ChinaDate lunarLastDate = Helper.ConvertToLunisolar(dt.AddDays(7));

            int nlastMonth = lunarLastDate.Month;

            if (nlastMonth < lunarDate.Month)
            {
                nlastMonth += 12;
            }
            if (lunarDate.Month == nlastMonth)
            {
                strLunarDate.Append(string.Format(" bdMonth={0}", lunarDate.Month));
                strLunarDate.Append(string.Format(" and bdDay between {0} and {1}", lunarDate.Day, lunarLastDate.Day));
            }
            else if (nlastMonth - lunarDate.Month == 1)
            {
                var calendar = new ChineseLunisolarCalendar();
                int endDay = calendar.GetDaysInMonth(lunarDate.Year, lunarDate.Month);
                strLunarDate.Append(string.Format(" (bdMonth={0} and bdDay between {1} and {2})", lunarDate.Month,
                    lunarDate.Day, endDay));
                strLunarDate.Append(string.Format(" or (bdMonth={0} and bdDay between {1} and {2})", lunarLastDate.Month,
                    1, lunarLastDate.Day));
            }
            else if (nlastMonth - lunarDate.Month == 2)
            {
                var calendar = new ChineseLunisolarCalendar();
                int endDay = calendar.GetDaysInMonth(lunarDate.Year, lunarDate.Month);
                int midDay = calendar.GetDaysInMonth(lunarDate.Year, lunarDate.Month + 1);
                strLunarDate.Append(string.Format(" (bdMonth={0} and bdDay between {1} and {2})", lunarDate.Month,
                    lunarDate.Day, endDay));
                strLunarDate.Append(string.Format(" or (bdMonth={0} and bdDay between {1} and {2})", lunarDate.Month + 1,
                    1, midDay));
                strLunarDate.Append(string.Format(" or (bdMonth={0} and bdDay between {1} and {2})", lunarLastDate.Month,
                    1, lunarLastDate.Day));
            }

            strSql.Append(
                "SELECT birthdayID,T_User_Birthday.[uid],T_UserInfo.uName,T_UserInfo.uPhone,T_UserInfo.uQQ,T_UserInfo.uNumber,T_UserInfo.uPortrait,IsLunar, bdName, bdYear, bdDate, bdMonth, bdDay,(uIntegral+uIntegralUsed) as uIntegral,T_UserInfo.uRank rankLv,'' rankName FROM T_User_Birthday left outer join T_UserInfo on T_UserInfo.[uid]=T_User_Birthday.[uid] ");
            strSql.Append(" where T_User_Birthday.[accID]=@accID and [IsLunar]=1 and (" + strDate + ")");
            strSql.Append(" order by  [IsLunar],[bdDate] asc; ");
            strSql.Append(
                "SELECT birthdayID,T_User_Birthday.[uid],T_UserInfo.uName,T_UserInfo.uPhone,T_UserInfo.uQQ,T_UserInfo.uNumber,T_UserInfo.uPortrait,IsLunar, bdName, bdYear, bdDate, bdMonth, bdDay,(uIntegral+uIntegralUsed) as uIntegral,T_UserInfo.uRank rankLv,'' rankName FROM T_User_Birthday left outer join T_UserInfo on T_UserInfo.[uid]=T_User_Birthday.[uid] ");
            strSql.Append(" where T_User_Birthday.[accID]=@accID and [IsLunar]=2 and (" + strLunarDate + ")");
            strSql.Append(" order by  [IsLunar],[bdDate] asc; ");

            IEnumerable<dynamic> result = DapperHelper.Query(strSql.ToString(), new {accID = accId});
        }

        /// <summary>
        ///     获得微信收单优惠券分享地址
        /// </summary>
        /// <param name="accId">店铺ID</param>
        /// <param name="groupId"></param>
        /// <returns>1-短链Url 0-失败，店铺openid</returns>
        public static string GetShortUrl(int accId, int groupId)
        {
            var strSql = new StringBuilder();
            strSql.Append("SELECT longUrl FROM [I200].[dbo].[T_CouponInfo] WHERE accID=@accId AND id=@groupId ;");
            string oResult = string.Empty;
            SqlParameter[] parms =
            {
                new SqlParameter("@accId", SqlDbType.Int),
                new SqlParameter("@groupId", SqlDbType.Int)
            };
            parms[0].Value = accId;
            parms[1].Value = groupId;

            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parms);
            if (ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
            {
                DataRow row = ds.Tables[0].Rows[0];
                if (row["longUrl"] != null && row["longUrl"] != "")
                {
                    oResult = row["longUrl"].ToString();
                }
            }
            return oResult;
        }

        /// <summary>
        ///     写入Redis信息
        /// </summary>
        /// <returns></returns>
        public static bool WriteRedisData()
        {
            string userOpenId = "oHow7xD3tiBtJTerP5KQjPv5wmP8";
            var weChatOrdersPushReport = new WeChatOrdersPushReport
            {
                UserOpenId = userOpenId,
                SubIsSubscribe = 0,
                ShopName = "我爱我家",
                UserName = "liupeng",
                GoodsName = "菜刀",
                IsMember = true,
                Amount = 100,
                Balance = 200,
                PayDate = DateTime.Now,
                ShortUrl = "http://www.baidu.com",
                WeixinPayDefaultCoupon = 13123412
            };

            string sendObj = JsonConvert.SerializeObject(weChatOrdersPushReport);
            var redisProvider = new RedisProvider();
            return redisProvider.Set(userOpenId, sendObj, 1800);
        }

        public static void WriteMessage(string info)
        {
            Thread.Sleep(2000);
            string message = string.Format("当前的发送消息为：{0}", info);
            Console.WriteLine(message);
        }

        /// <summary>
        ///     公历转为农历的函数
        /// </summary>
        /// <param name="solarDateTime">公历日期</param>
        /// <returns>农历的日期</returns>
        private static string SolarToChineseLunisolarDate(DateTime solarDateTime)
        {
            var cal = new ChineseLunisolarCalendar();
            int year = cal.GetYear(solarDateTime);
            int month = cal.GetMonth(solarDateTime);
            int day = cal.GetDayOfMonth(solarDateTime);
            int leapMonth = cal.GetLeapMonth(year);
            return string.Join("-", year, month, day);
        }

        /// <summary>
        ///     StreamRead文件读取
        /// </summary>
        public static string StramWriteFile()
        {
            var showTxt = new StringBuilder();
            string testFilePath = @"D:\tempStudy\1.txt";
            var fs = new FileStream(testFilePath, FileMode.Open);
            var swReader = new StreamReader(fs);
            int iChar = swReader.Read();
            while (iChar != -1)
            {
                showTxt.Append(Convert.ToChar(iChar));
                iChar = swReader.Read();
            }
            swReader.Close();

            return showTxt.ToString();
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
            int seed = BitConverter.ToInt32(bytes, 0);
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
            string strNameKey = "liupeng";
            var strName = new StringBuilder();
            for (int i = 0; i < DoNum; i++)
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
            string strName = "";
            string strNameKey = "liupeng";
            for (int i = 0; i < DoNum; i++)
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
            TimeSpan seconds = stopWatch.Elapsed;
            Console.WriteLine("{0}拼接字符串所消耗的时间为：{1}", operationName, seconds);
        }


        /// <summary>
        ///     创建延迟加载类
        /// </summary>
        public static class LazyClass
        {
            /// <summary>
            ///     获取短日期时间
            /// </summary>
            /// <returns></returns>
            public static string GetLazyPerson()
            {
                return string.Format("i am a lazy person,now is {0},i do not want to get up!", DateTime.Now);
            }
        }

        public class MusicTitles
        {
            private readonly string[] names = {"a", "b", "c", "d"};
            private string[] _tempName = {"1", "2"};

            public IEnumerator<string> GetEnumerator()
            {
                for (int i = 0; i < 4; i++)
                {
                    yield return names[i];
                }
            }

            public IEnumerable<string> Reverse()
            {
                for (int i = 3; i >= 0; i--)
                {
                    yield return names[i];
                }
            }

            public IEnumerable<string> Subset(int index, int length)
            {
                for (int i = index; i < index + length; i++)
                {
                    yield return names[i];
                }
            }
        }

        public class MyName
        {
            public string id;

            public string Id
            {
                get { return id; }
                set { id = value; }
            }

            public string Name { get; set; }
            public string Age { get; set; }
        }

        public class Parent
        {
            /// <summary>
            ///     年龄
            /// </summary>
            public int Id { get; set; }

            public Lazy<IEnumerable<TheShowTitle>> ShowListTitle
            {
                get; set;
            }

            /// <summary>
            /// 初始化
            /// </summary>
            public Parent(int id)
            {
                this.Id = id;
                this.ShowListTitle = new Lazy<IEnumerable<TheShowTitle>>(()=>SonShowService.GetSonShowTimeTitle(5));
            }
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

        public class SonShowService
        {
            /// <summary>
            ///     获取son表演的主题
            /// </summary>
            /// <returns></returns>
            public static IEnumerable<TheShowTitle> GetSonShowTimeTitle(int age)
            {
                var returnShowTitle = new List<TheShowTitle>
                {
                    new TheShowTitle
                    {
                        Age = 5,
                        ShowName = "basketball"
                    },
                    new TheShowTitle
                    {
                        Age = 6,
                        ShowName = "football"
                    },
                    new TheShowTitle
                    {
                        Age = 7,
                        ShowName = "music"
                    },
                    new TheShowTitle
                    {
                        Age = 8,
                        ShowName = "kongfu"
                    }
                };

                return returnShowTitle.Where(x => x.Age == age);
            }
        }

        public class TheShowTitle
        {
            /// <summary>
            ///     年龄
            /// </summary>
            public int Age { get; set; }

            /// <summary>
            ///     表演主题
            /// </summary>
            public string ShowName { get; set; }
        }

        private delegate void WriteMessageDelegate(string msg);
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
    public static partial class Helper
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

    /// <summary>
    ///     微信收单列表状态
    /// </summary>
    public class AccountBookStatusList
    {
        /// <summary>
        ///     Key
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        ///     Value
        /// </summary>
        public Dictionary<string, string> Value { get; set; }
    }


    public class AccountBookStatus
    {
        /// <summary>
        ///     Key
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        ///     显示Text
        /// </summary>
        public string Text { get; set; }
    }
}