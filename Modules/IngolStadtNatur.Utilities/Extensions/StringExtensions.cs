namespace IngolStadtNatur.Utilities.Extensions
{
    public static class StringExtensions
    {
        public static string ToIconName(this string str)
        {
            return str.Replace(' ', '_');
        }

        public static long ToLong(this string s)
        {
            long i;
            return long.TryParse(s, out i) ? i : 0;
        }
    }
}