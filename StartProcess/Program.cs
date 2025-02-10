using System.Runtime.InteropServices;
using StartProcess.Extensions;
using StartProcess.Logging;
using StartProcess.Config;
using System.Diagnostics;

namespace StartProcess
{
    internal class Program
    {
        [DllImport("user32.dll", SetLastError = true)]
        internal static extern bool MoveWindow(
            IntPtr hWnd, 
            int X, 
            int Y, 
            int nWidth, 
            int nHeight, 
            bool bRepaint);

        static void Main()
        {
            var config =
                Configure.Json();

            var i = 
                0;

            while (config.ExecutionLoops > i) 
            {
                i++;

                try
                {
                    Logger.Log(
                        config.LogFile,
                        Ext.Separator);

                    Logger.Log(
                        config.LogFile,
                        Ext.Separator);

                    Terminate.ExistingProcess(
                        config);

                    var fileToProcess =
                        RandomData.File(config);

                    var startInfo =
                        new ProcessStartInfo
                        {
                            CreateNoWindow = true,
                            UseShellExecute = true,
                            Arguments = "\"" + fileToProcess + "\"" + " " + config.Arguments,
                            FileName = config.SourceProcess,
                            WindowStyle = ProcessWindowStyle.Normal
                        };

                    Logger.Log(
                        config.LogFile,
                        "Running process: " +
                        config.SourceProcess);

                    Logger.Log(
                        config.LogFile,
                        "Running file: " +
                        fileToProcess);

                    Logger.Log(
                        config.LogFile,
                        "Execution count: " +
                        i + 
                        " of " +
                        config.ExecutionLoops);

                    var processRun =
                        Process.Start(
                            startInfo);

                    Thread.Sleep(1000);

                    var id =
                        processRun!.MainWindowHandle;

                    MoveWindow(
                        processRun.MainWindowHandle,
                        config.ScreenPositionX,
                        config.ScreenPositionY,
                        config.WindowWidth,
                        config.WindowHeight,
                        true);

                    Thread.Sleep(
                        config.ExecutionSeconds * 
                        1000);
                }
                catch (Exception ex)
                {
                    Logger.Log(
                        config.LogFile,
                        ex.Message);
                    throw;
                }
            }

            Logger.Log(
                config.LogFile,
                Ext.Separator);

            Logger.Log(
                config.LogFile,
                Ext.Separator);

            Logger.Log(
                config.LogFile,
                "Runs complete, exiting...");
        }
    }
}
