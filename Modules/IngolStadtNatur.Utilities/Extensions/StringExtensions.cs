namespace IngolStadtNatur.Utilities.Extensions
{
    public static class StringExtensions
    {
        public static string ToIconName(this string str)
        {
            return str.Replace(' ', '_');
        }
    }
}
