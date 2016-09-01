namespace Infruesture
{
    public static class TestStaticClass
    {
        private static string _userName = "liupeng";

        public static string UserName
        {
            get { return _userName; }
            set { _userName = value; }
        }
    }
}