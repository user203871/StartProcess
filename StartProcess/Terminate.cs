using StartProcess.Extensions;
using StartProcess.Logging;
using StartProcess.Config;
using System.Diagnostics;

namespace StartProcess
{
    public static class Terminate
    {
        public static void ExistingProcess(
            ConfigurationRecord config) 
        {
            try 
            {
                var processName =
                    "";

                foreach (var process in config.SourceProcess.Split("\\"))
                {
                    if (process.HasNoCase("exe"))
                    {
                        processName =
                            process.
                            ToLower().
                            Replace(
                                ".exe",
                                "");
                    }
                }

                var runningProcess =
                    Process.GetProcessesByName(
                        processName);

                Logger.Log(
                    config.LogFile,
                    "Terminating process: " +
                    processName);

                foreach (var worker in runningProcess)
                {
                    worker.Kill();
                    worker.WaitForExit();
                    worker.Dispose();
                }
            } 
            catch (Exception ex)
            {
                Logger.Log(
                    config.LogFile,
                    ex.Message);

                throw;
            }          
        }
    }
}
