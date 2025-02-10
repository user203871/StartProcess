using StartProcess.Extensions;

namespace StartProcess.Logging
{
    public static class Logger
    {
        public static void Log(
            string logFile,
            string logData)
        {
            Console.WriteLine(
                logData.Timestamp());

            Write(logFile, logData);
        }

        public static void Write(
            string logFile, 
            string logData) 
        {
            var log = 
                !File.Exists(logFile) ? 
                new StreamWriter(logFile) : 
                File.AppendText(logFile);

            log.WriteLine(
                logData.Timestamp());

            log.Close();
        }
    }
}