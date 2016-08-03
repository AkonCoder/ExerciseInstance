using System.Globalization;

namespace Infruesture
{
    public static class StaticTest
    {
        public static int _num = 0;

        static StaticTest()
        {
            _num++;
        }
    }
}