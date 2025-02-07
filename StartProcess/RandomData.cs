using StartProcess.Extensions;
using StartProcess.Logging;

namespace StartProcess
{
    public static class RandomData
    {
        public static string File(
            string logFile,
            string directory)
        {
            try
            {
                var random =
                    new Random();

                return Random.Shared.GetItems(
                    Files(logFile, directory).
                    ToArray(), 1)[0];
            }
            catch (Exception ex)
            {
                Logger.Log(
                    logFile, 
                    ex.Message);

                throw;
            }
        }

        public static List<string> Files(
            string logFile,
            string directory) 
        {
            try
            {
                var filteredList =
                    new List<string>();

                var listOfFiles =
                    new List<string>(
                        Directory.GetFiles(
                            directory));

                filteredList.AddRange(from file in listOfFiles
                                      where !file.ToUpper().HasNoCase("frz")
                                      select file);

                return filteredList;
            } 
            catch (Exception ex)
            {
                Logger.Log(
                    logFile,
                    ex.Message);

                throw;
            }
        }
    }
}