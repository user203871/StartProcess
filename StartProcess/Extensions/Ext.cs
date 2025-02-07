namespace StartProcess.Extensions
{
    public static class Ext
    {
        public static bool HasNoCase(
            this string source, 
            string toCheck)
        {
            return source?.IndexOf(
                toCheck, 
                StringComparison.OrdinalIgnoreCase) >= 0;
        }
    }
}
