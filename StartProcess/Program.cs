using System.Runtime.InteropServices;
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

            try 
            {
                Terminate.ExistingProcess(
                    config);

                var fileToProcess =
                    RandomData.File(
                        config.LogFile,
                        config.SourceFiles);

                var startInfo =
                    new ProcessStartInfo
                    {
                        CreateNoWindow = true,
                        UseShellExecute = true,
                        Arguments = fileToProcess + " -hidemenu",
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

                var processRun =
                    Process.Start(
                        startInfo);

                Thread.Sleep(100);

                var id =
                    processRun!.MainWindowHandle;

                MoveWindow(
                    processRun.MainWindowHandle,
                    config.ScreenPositionX,
                    config.ScreenPositionY,
                    config.WindowWidth,
                    config.WindowHeight,
                    true);
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
