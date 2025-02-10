using StartProcess.Extensions;
using StartProcess.Logging;
using StartProcess.Config;

namespace StartProcess
{
    public static class RandomData
    {
        public static string File(
            Configuration config)
        {
            try
            {
                var random =
                    new Random();

                return Random.Shared.GetItems(
                    Files(config).
                    ToArray(), 1)[0];
            }
            catch (Exception ex)
            {
                Logger.Log(
                    config.LogFile, 
                    ex.Message);
                throw;
            }
        }

        public static List<string> Files(
            Configuration config) 
        {
            try
            {
                var filteredList =
                    new List<string>();

                var listOfFiles =
                    new List<string>(
                        Directory.GetFiles(
                            config.SourceFiles));

                foreach (var file in listOfFiles) 
                {
                    var addFlag = true;

                    foreach (var type in config.ExcludedFileTypes) 
                    {
                        if (file.ToUpper().HasNoCase(type.ToString()))
                        {                        
                            addFlag = false;
                        }
                    }

                    if (addFlag) 
                    {
                        filteredList.Add(file);
                    }
                }

                return filteredList;
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