namespace StartProcess.Extensions
{
    public static class Ext
    {
        public static string Separator = 
            "********************************************************************";

        public static bool HasNoCase(
            this string source, 
            string toCheck)
        {
            return source?.IndexOf(
                toCheck, 
                StringComparison.OrdinalIgnoreCase) >= 0;
        }

        public static string Timestamp(
            this string appendTo)
        {
            if (!appendTo.Contains("*")) 
            {
                return appendTo +
                    " - " +
                    DateTime.Now.ToShortDateString() +
                    " " +
                    DateTime.Now.ToShortTimeString();
            }

            return appendTo;
        }
    }
}
