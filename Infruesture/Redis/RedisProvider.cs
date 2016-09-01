using System;
using Newtonsoft.Json;
using StackExchange.Redis;
using Formatting = System.Xml.Formatting;

namespace Infruesture.Redis
{
    public class RedisProvider : ICacheService
    {
        private static readonly string RedisHost = System.Configuration.ConfigurationManager.AppSettings["RedisHost"];
        private static ConnectionMultiplexer _connection = null;
        private static readonly object LockObject=new object();

        public RedisProvider()
        {
            if (_connection == null || !_connection.IsConnected)
            {
                lock (LockObject)
                {
                    ConfigurationOptions config = new ConfigurationOptions()
                    {
                        AbortOnConnectFail = false,
                        ConnectRetry = 10,
                        ConnectTimeout = 5000,
                        SyncTimeout = 5000,
                        EndPoints = { { RedisHost } },
                        AllowAdmin = true,
                        KeepAlive = 180
                    };
                    _connection = ConnectionMultiplexer.Connect(config);
                }
            }
        }

        /// <summary>
        /// 移除指定Key
        /// </summary>
        /// <param name="key">键</param>
        /// <returns></returns>
        public bool RemoveKey(string key)
        {
            if (_connection != null && _connection.IsConnected)
            {
                return _connection.GetDatabase().KeyDelete(key);
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 设置key过期时间
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="secondTimeout">过期秒数</param>
        /// <returns></returns>
        public bool KeyExpire(string key, int secondTimeout)
        {
            if (_connection != null && _connection.IsConnected)
            {
                return _connection.GetDatabase().KeyExpire(key,TimeSpan.FromSeconds(secondTimeout));
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 判断是否存在key
        /// </summary>
        /// <param name="key">键</param>
        /// <returns></returns>
        public bool HasKey(string key)
        {
            if (_connection != null && _connection.IsConnected)
            {
                return _connection.GetDatabase().KeyExists(key);
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 存储数据到key
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="value">值</param>
        /// <returns></returns>
        public bool Set(string key, string value)
        {
            if (_connection != null && _connection.IsConnected)
            {
                return _connection.GetDatabase().StringSet(key, value);
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 存储数据到key
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="value">值</param>
        /// <param name="secondTimeout">过期秒数</param>
        /// <returns></returns>
        public bool Set(string key, string value, int secondTimeout)
        {
            if (_connection != null && _connection.IsConnected)
            {
                return _connection.GetDatabase().StringSet(key, value,TimeSpan.FromSeconds(secondTimeout));
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 获取指定key数据
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public string Get(string key)
        {
            if (_connection != null && _connection.IsConnected)
            {
                return _connection.GetDatabase().StringGet(key);
            }
            else
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// 存储数据到key
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool Set<T>(string key, T value)
        {
            if (_connection != null && _connection.IsConnected)
            {
                var stringObj = JsonSerialize(value);
                return _connection.GetDatabase().StringSet(key, stringObj);
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 存储数据到key
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="secondTimeout">过期秒数</param>
        /// <returns></returns>
        public bool Set<T>(string key, T value, int secondTimeout)
        {
            if (_connection != null && _connection.IsConnected)
            {
                var stringObj = JsonSerialize(value);
                return _connection.GetDatabase().StringSet(key, stringObj,TimeSpan.FromSeconds(secondTimeout));
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 获取指定key数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public T Get<T>(string key)
        {
            if (_connection != null && _connection.IsConnected)
            {
                var stringObj = _connection.GetDatabase().StringGet(key);
                if (!stringObj.IsNullOrEmpty)
                {
                    return JsonDeserialize<T>(stringObj);
                }
            }

            return default(T);
        }

        /// <summary>
        /// 指定key原子加1操作
        /// </summary>
        /// <param name="key">递增之后的value</param>
        /// <returns></returns>
        public long StringIncrement(string key)
        {
            if (_connection != null && _connection.IsConnected)
            {
                return _connection.GetDatabase().StringIncrement(key);
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// 指定key原子减1操作
        /// </summary>
        /// <param name="key"></param>
        /// <returns>减小之后的value</returns>
        public long StringDecrement(string key)
        {
            if (_connection != null && _connection.IsConnected)
            {
                return _connection.GetDatabase().StringDecrement(key);
            }
            else
            {
                return 0;
            }
        }


        /// <summary>
        /// 序列化对象为Json字符串
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        private string JsonSerialize(object obj)
        {
            var formatSetting = new JsonSerializerSettings
            {
                DateTimeZoneHandling = DateTimeZoneHandling.Local,
                DateFormatString = "yyyy-MM-dd HH:mm:ss",
                Formatting = (Newtonsoft.Json.Formatting) Formatting.Indented
            };
            var jSonStr = JsonConvert.SerializeObject(obj, formatSetting);

            return jSonStr;
        }

        /// <summary>
        /// 反序列化为T对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="strJson"></param>
        /// <returns></returns>
        private T JsonDeserialize<T>(string strJson)
        {
            return JsonConvert.DeserializeObject<T>(strJson);
        }


        public void Dispose()
        {
            if (_connection != null)
            {
                _connection.Dispose();
            }
        }
    }
}
