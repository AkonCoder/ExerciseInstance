using System;

namespace Infruesture
{
    public class EnumTest
    {
        [Flags]
        public enum RoleEnum
        {
            /// <summary>
            /// 绿色
            /// </summary>
            Green = 0,

            /// <summary>
            /// 红色
            /// </summary>
            Red = 1,

            /// <summary>
            ///黑色
            /// </summary>
            Black = 2,

            /// <summary>
            /// 兼容的颜色
            /// </summary>
            All = Green | Black
        }
    }
}