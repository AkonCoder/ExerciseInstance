using System;

namespace Infruesture
{
    /// <summary>
    ///     单例模式（定义：确保一个类只有一个实例，并提供一个全局访问点）
    /// </summary>
    public class Singleton
    {
        // ReSharper disable once UnassignedReadonlyField
        // ReSharper disable once InconsistentNaming
        public static Singleton _Singleton;
        public static readonly Object LockObj = new object();

        /// <summary>
        /// 声明为private，防止在类的外面实例化对象
        /// </summary>
        private Singleton()
        {
        }


        public static Singleton GetInstance()
        {
            //return _Singleton ?? new Singleton();

            //1.在多线程的情况下，保证一个线程下面只有实例，所以这里需要lock的控制
            //if (_Singleton == null)
            //{
            //    lock (LockObj)
            //    {
            //        _Singleton = new Singleton();
            //    }
                
            //}

            //return _Singleton;

            //2.在这里存在一个问题就是如果singleton实例存在的话，就不应该进入，所以采用双重检查加锁
            if (_Singleton == null)
            {
                lock (LockObj)
                {
                    _Singleton = new Singleton();
                }
            }
            return _Singleton;
        }
    }
}