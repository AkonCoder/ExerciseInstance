using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GenerateAESCode
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //1.生成AES加密后的AppKey
            //原始appkey
            string appKey = "JH01334b46d0c362da33daa2c039e3035d";
            //密码
            string password = "YuanBei";
            //秘钥
            string iv = "9L3Ukxh0sfhiZK3g";
            var newAppkey = Helper.AesEncrypt(appKey, password, iv);
            Console.WriteLine("原始的Appkey是：" + appKey);
            Console.WriteLine("Aes加密后的appKey是:" + newAppkey);
            Console.WriteLine("\n");

            //2.解析原始的appKey
            var oldAppKey = Helper.AesDecrypt(newAppkey, password, iv);
            Console.WriteLine("解密后的原始Appkey是：" + oldAppKey);
            Console.ReadLine();
        }
    }
}