﻿using System;

namespace Infruesture.Redis
{
    public interface ICacheService : IDisposable
    {
        /// <summary>
        /// 移除指定Key
        /// </summary>
        /// <param name="key">键</param>
        /// <returns></returns>
        bool RemoveKey(string key);

        /// <summary>
        /// 设置key过期时间
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="secondTimeout">过期秒数</param>
        /// <returns></returns>
        bool KeyExpire(string key, int secondTimeout);

        /// <summary>
        /// 判断是否存在key
        /// </summary>
        /// <param name="key">键</param>
        /// <returns></returns>
        bool HasKey(string key);

        /// <summary>
        /// 存储数据到key
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="value">值</param>
        /// <returns></returns>
        bool Set(string key, string value);

        /// <summary>
        /// 存储数据到key
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="value">值</param>
        /// <param name="secondTimeout">过期秒数</param>
        /// <returns></returns>
        bool Set(string key, string value, int secondTimeout);

        /// <summary>
        /// 获取指定key数据
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        string Get(string key);

        /// <summary>
        /// 存储数据到key
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        bool Set<T>(string key, T value);

        /// <summary>
        /// 存储数据到key
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="secondTimeout">过期秒数</param>
        /// <returns></returns>
        bool Set<T>(string key, T value, int secondTimeout);

        /// <summary>
        /// 获取指定key数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        T Get<T>(string key);

        /// <summary>
        /// 指定key原子加1操作
        /// </summary>
        /// <param name="key">递增之后的value</param>
        /// <returns></returns>
        long StringIncrement(string key);

        /// <summary>
        /// 指定key原子减1操作
        /// </summary>
        /// <param name="key"></param>
        /// <returns>减小之后的value</returns>
        long StringDecrement(string key);
    }
}
